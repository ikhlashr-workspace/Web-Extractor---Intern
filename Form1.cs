using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebDataExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void fetchButton_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text;

            // Set ChromeOptions for headless mode
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Menjalankan Chrome tanpa UI
            options.AddArgument("--disable-gpu"); // Menghindari masalah rendering di Windows
            options.AddArgument("--disable-dev-shm-usage"); // Mengurangi penggunaan memori bersama
            options.AddArgument("--no-sandbox"); // Menghindari sandboxing untuk stabilitas
            options.AddArgument("--disable-extensions"); // Menonaktifkan ekstensi
            options.AddArgument("--window-size=1920,1080"); // Mengatur ukuran jendela untuk mendapatkan elemen dengan benar

            // Setup ChromeDriverService to hide the console window
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true; // Menyembunyikan jendela command prompt

            // Show loading indicator
            progressBar1.Visible = true;

            IWebDriver driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl(url);

            try
            {
                // Clear any previous controls
                flowLayoutPanel.Controls.Clear();

                // Extract Product Name from <meta name="description">
                var metaDescriptionElement = driver.FindElement(By.XPath("//meta[@name='description']"));
                string? productName = metaDescriptionElement?.GetAttribute("content") ?? "Product name not found";
                productNameTextBox.Text = productName;

                // Extract Link Website (Display the input URL)
                linkWebsiteTextBox.Text = url;

                // Extract Supplier Link
                var supplierElement = driver.FindElement(By.XPath("//span[@class='company-name detail-separator']/a"));
                string? supplierLink = supplierElement?.GetAttribute("href") ?? "Supplier link not found";
                supplierLinkTextBox.Text = supplierLink;

                // Extract all price information from the price module
                var priceElements = driver.FindElements(By.XPath("//div[@detail-module-name='module_price']//div[@class='price-item']"));
                string prices = string.Empty;
                foreach (var priceElement in priceElements)
                {
                    string quantity = priceElement.FindElement(By.XPath(".//div[@class='quality']")).Text;
                    string price = priceElement.FindElement(By.XPath(".//div[@class='price']")).Text;
                    prices += $"{quantity}: {price}\n";
                }
                priceTextBox.Text = string.IsNullOrWhiteSpace(prices) ? "Price not found" : prices.Trim();

                // Extract all text from Description Layout (module_description)
                var descriptionElement = driver.FindElement(By.XPath("//div[contains(@class, 'module_description')]"));
                string allData = descriptionElement?.Text.Trim() ?? "No data found in Description Layout";
                dataRichTextBox.Text = allData;

                // Extract and display images with copy button
                var imageElements = driver.FindElements(By.XPath("//div[contains(@class, 'module_productImage')]//img"));
                foreach (var img in imageElements)
                {
                    string? src = img.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        AddImageWithCopyButton(src);
                    }
                }
            }
            catch (NoSuchElementException)
            {
                productNameTextBox.Text = "Element not found on the page.";
            }
            finally
            {
                driver.Quit();
                // Hide loading indicator
                progressBar1.Visible = false;
            }
        }

        private void AddImageWithCopyButton(string imageUrl)
        {
            // Create PictureBox to display the image
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ImageLocation = imageUrl
            };

            // Create Button to copy the image to clipboard
            Button copyButton = new Button
            {
                Text = "Copy Image",
                Tag = imageUrl
            };
            copyButton.Click += async (s, e) => await CopyButton_Click(s, e, imageUrl);

            // Add PictureBox and Button to a FlowLayoutPanel
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(copyButton);

            flowLayoutPanel.Controls.Add(panel);
        }

        private async Task CopyButton_Click(object? sender, EventArgs e, string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var imageStream = await client.GetStreamAsync(imageUrl);
                        using (var bitmap = new Bitmap(imageStream))
                        {
                            Clipboard.SetImage(bitmap);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to copy image: {ex.Message}");
                    }
                }
            }
        }

        private void copyAllButton_Click(object sender, EventArgs e)
        {
            string allData = $"Product Name: {productNameTextBox.Text}\n" +
                             $"Link Website: {linkWebsiteTextBox.Text}\n" +
                             $"Price: {priceTextBox.Text}\n" +
                             $"Supplier Link: {supplierLinkTextBox.Text}\n" +
                             $"Data: {dataRichTextBox.Text}";
            Clipboard.SetText(allData); // Menyalin semua teks ke clipboard
        }
    }
}
