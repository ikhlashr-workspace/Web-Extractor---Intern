//create by iklashR
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WebDataExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Icon = new Icon("productintern.ico");
            copyPromptButton.Visible = false;
            checkDataButton.Visible = false;
        }

        private string fullDataHtml;

        private async void fetchButton_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text.Trim();

            string urlPattern = @"^(https?:\/\/|www\.).+";

            if (string.IsNullOrEmpty(url) || !Regex.IsMatch(url, urlPattern))
            {
                MessageBox.Show("Please enter a valid URL that starts with http://, https://, or www.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fetchButton.Enabled = false;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--window-size=1920,1080");

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            progressBar1.Visible = true;
            checkDataButton.Visible = false;

            IWebDriver driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl(url);

            try
            {
                flowLayoutPanel.Controls.Clear();
                var metaDescriptionElement = driver.FindElement(By.XPath("//meta[@name='description']"));
                string? productName = metaDescriptionElement?.GetAttribute("content") ?? "Product name not found";
                productNameTextBox.Text = productName;
                linkWebsiteTextBox.Text = url;
                var supplierElement = driver.FindElement(By.XPath("//span[@class='company-name detail-separator']/a"));
                string? supplierLink = supplierElement?.GetAttribute("href") ?? "Supplier link not found";
                supplierLinkTextBox.Text = supplierLink;

                var priceElements = driver.FindElements(By.XPath("//div[@detail-module-name='module_price']"));
                string prices = string.Empty;

                foreach (var priceElement in priceElements)
                {
                    string price = priceElement.Text.Trim();
                    prices += string.IsNullOrWhiteSpace(prices) ? price : $" - {price}";
                }

                priceTextBox.Text = string.IsNullOrWhiteSpace(prices) ? "Price not found" : prices;

                var descriptionElement = driver.FindElement(By.XPath("//div[contains(@class, 'module_description')]"));
                string allData = descriptionElement?.Text.Trim() ?? "No data found in Description Layout";
                dataRichTextBox.Text = allData;
                fullDataHtml = descriptionElement?.GetAttribute("outerHTML") ?? "No full data found in Description Layout";

                var imageElements = driver.FindElements(By.XPath("//div[contains(@class, 'module_productImage')]//img"));
                foreach (var img in imageElements)
                {
                    string? src = img.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        AddImageWithFancyCopyButton(src);
                    }
                }

                copyPromptButton.Visible = true;
                checkDataButton.Visible = true;
            }
            catch (NoSuchElementException)
            {
                productNameTextBox.Text = "Element not found on the page.";
            }
            finally
            {
                driver.Quit();
                progressBar1.Visible = false;
                fetchButton.Enabled = true;
            }
        }

        private void AddImageWithFancyCopyButton(string imageUrl)
        {
            Panel containerPanel = new Panel
            {
                Size = new Size(140, 170),
                Margin = new Padding(10),
                BackColor = Color.FromArgb(37, 37, 38)
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(120, 120),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ImageLocation = imageUrl,
                Location = new Point(10, 10)
            };

            Button copyButton = new Button
            {
                Text = "Copy Image",
                Tag = imageUrl,
                AutoSize = false,
                Width = 120,
                Height = 30,
                BackColor = Color.FromArgb(28, 151, 234),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(10, 140)
            };
            copyButton.FlatAppearance.BorderSize = 0;
            copyButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 122, 204);

            copyButton.Click += async (sender, args) => await CopyButton_Click(sender, args, imageUrl);

            containerPanel.Controls.Add(pictureBox);
            containerPanel.Controls.Add(copyButton);
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
                        MessageBox.Show("Image copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to copy image: {ex.Message}");
                    }
                }
            }
        }

        private void CheckDataButton_Click(object sender, EventArgs e)
        {
            string fullData = $"Data: {fullDataHtml}";
            CheckDataForm checkDataForm = new CheckDataForm(fullData);
            checkDataForm.ShowDialog();
        }

        private void copyAllButton_Click(object sender, EventArgs e)
        {
            string allData = $"Product Name: {productNameTextBox.Text}\n" +
                             $"Link Website: {linkWebsiteTextBox.Text}\n" +
                             $"Price: {priceTextBox.Text}\n" +
                             $"Supplier Link: {supplierLinkTextBox.Text}\n" +
                             $"Data: {dataRichTextBox.Text}";
            Clipboard.SetText(allData);
            MessageBox.Show("All data copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void copyPromptButton_Click(object sender, EventArgs e)
        {
            string promptFilePath = "prompt.txt";
            string prompt;
            try
            {
                prompt = File.ReadAllText(promptFilePath);
            }
            catch (Exception ex)
            {
                prompt = "Default prompt because file not found or error occurred.";
                MessageBox.Show($"Error loading prompt: {ex.Message}");
            }

            string allData = $"Product Name: {productNameTextBox.Text}\n" +
                             $"Link Website: {linkWebsiteTextBox.Text}\n" +
                             $"Price: {priceTextBox.Text}\n" +
                             $"Supplier Link: {supplierLinkTextBox.Text}\n" +
                             $"Data: {dataRichTextBox.Text}";
            string result = $"{prompt}\n\n{allData}";
            Clipboard.SetText(result);
            MessageBox.Show("Prompt and data copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
