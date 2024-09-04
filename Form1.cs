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
                var priceElements = driver.FindElements(By.XPath("//div[@detail-module-name='module_price']"));
                string prices = string.Empty;

                foreach (var priceElement in priceElements)
                {
                    string price = priceElement.Text.Trim();
                    prices += string.IsNullOrWhiteSpace(prices) ? price : $" - {price}";
                }

                priceTextBox.Text = string.IsNullOrWhiteSpace(prices) ? "Price not found" : prices;

                // Extract all text from Description Layout (module_description)
                var descriptionElement = driver.FindElement(By.XPath("//div[contains(@class, 'module_description')]"));
                string allData = descriptionElement?.Text.Trim() ?? "No data found in Description Layout";
                dataRichTextBox.Text = allData;

                // Extract and display images with fancy copy button
                var imageElements = driver.FindElements(By.XPath("//div[contains(@class, 'module_productImage')]//img"));
                foreach (var img in imageElements)
                {
                    string? src = img.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        AddImageWithFancyCopyButton(src);
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

        private void AddImageWithFancyCopyButton(string imageUrl)
{
    // Create a panel to contain the image and the button, with a fixed size
    Panel containerPanel = new Panel
    {
        Size = new Size(140, 170), // Ukuran panel tetap untuk menampung gambar dan tombol
        Margin = new Padding(10), // Margin untuk memastikan jarak antar panel
        BackColor = Color.FromArgb(37, 37, 38) // Warna latar belakang panel
    };

    // Create PictureBox to display the image with a fixed size
    PictureBox pictureBox = new PictureBox
    {
        Size = new Size(120, 120), // Ukuran tetap untuk gambar
        SizeMode = PictureBoxSizeMode.StretchImage, // Pastikan gambar memenuhi PictureBox
        ImageLocation = imageUrl,
        Location = new Point(10, 10) // Letakkan gambar di bagian atas panel
    };

    // Create Button to copy the image to clipboard with a smaller size
    Button copyButton = new Button
    {
        Text = "Copy Image",
        Tag = imageUrl,
        AutoSize = false,
        Width = 120, // Lebar tombol sama dengan gambar
        Height = 30, // Ukuran tombol tetap
        BackColor = Color.FromArgb(28, 151, 234), // Soft Blue
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
        Location = new Point(10, 140) // Letakkan tombol di bawah gambar
    };
    copyButton.FlatAppearance.BorderSize = 0; // Menghilangkan border
    copyButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 122, 204); // Hover effect

    copyButton.Click += async (sender, args) => await CopyButton_Click(sender, args, imageUrl);

    // Add PictureBox and Button to the container panel
    containerPanel.Controls.Add(pictureBox);
    containerPanel.Controls.Add(copyButton);

    // Add the container panel to the FlowLayoutPanel
    flowLayoutPanel.Controls.Add(containerPanel);
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
