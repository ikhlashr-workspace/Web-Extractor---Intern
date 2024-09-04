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
            copyPromptButton.Visible = false; // Hide the Copy Prompt button initially
            checkDataButton.Visible = false; // Hide the Check Data button initially
        }

        private string fullDataHtml; // Raw HTML without trimming

        private async void fetchButton_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text;

            // Set ChromeOptions for headless mode
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Run Chrome without UI
            options.AddArgument("--disable-gpu"); // Avoid rendering issues in Windows
            options.AddArgument("--disable-dev-shm-usage"); // Reduce shared memory usage
            options.AddArgument("--no-sandbox"); // Avoid sandboxing for stability
            options.AddArgument("--disable-extensions"); // Disable extensions
            options.AddArgument("--window-size=1920,1080"); // Set window size for correct element retrieval

            // Setup ChromeDriverService to hide the console window
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true; // Hide the command prompt window

            // Show loading indicator
            progressBar1.Visible = true;
            checkDataButton.Visible = false; // Hide the Check Data button initially

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
                fullDataHtml = descriptionElement?.GetAttribute("outerHTML") ?? "No full data found in Description Layout"; // Store raw HTML

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

                // Show the buttons after fetching the data
                copyPromptButton.Visible = true;
                checkDataButton.Visible = true; // Make the Check Data button visible after data is fetched
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
                Size = new Size(140, 170), // Fixed size to contain image and button
                Margin = new Padding(10), // Margin to ensure spacing between panels
                BackColor = Color.FromArgb(37, 37, 38) // Panel background color
            };

            // Create PictureBox to display the image with a fixed size
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(120, 120), // Fixed size for image
                SizeMode = PictureBoxSizeMode.StretchImage, // Ensure image fits the PictureBox
                ImageLocation = imageUrl,
                Location = new Point(10, 10) // Place image at the top of the panel
            };

            // Create Button to copy the image to clipboard with a smaller size
            Button copyButton = new Button
            {
                Text = "Copy Image",
                Tag = imageUrl,
                AutoSize = false,
                Width = 120, // Button width same as image
                Height = 30, // Fixed button size
                BackColor = Color.FromArgb(28, 151, 234), // Soft Blue
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(10, 140) // Place button below the image
            };
            copyButton.FlatAppearance.BorderSize = 0; // Remove border
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
        private void CheckDataButton_Click(object sender, EventArgs e)
        {
            // Prepare the full data to display
            string fullData = $"Data: {fullDataHtml}"; // Use raw HTML stored in fullDataHtml

            // Create a new instance of CheckDataForm and pass the full data
            CheckDataForm checkDataForm = new CheckDataForm(fullData);
            
            // Show the new form
            checkDataForm.ShowDialog(); // Use ShowDialog to keep the form integrated with Form1
        }

        private void copyAllButton_Click(object sender, EventArgs e)
        {
            string allData = $"Product Name: {productNameTextBox.Text}\n" +
                             $"Link Website: {linkWebsiteTextBox.Text}\n" +
                             $"Price: {priceTextBox.Text}\n" +
                             $"Supplier Link: {supplierLinkTextBox.Text}\n" +
                             $"Data: {dataRichTextBox.Text}";
            Clipboard.SetText(allData); // Copy all text to clipboard
        }

        private void copyPromptButton_Click(object sender, EventArgs e)
        {
            string promptFilePath = "prompt.txt"; // Path to the external file
            string prompt;
            try
            {
                // Read the prompt from the file
                prompt = File.ReadAllText(promptFilePath);
            }
            catch (Exception ex)
            {
                // If there's an error (e.g., file not found), use a default prompt
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
            MessageBox.Show("Prompt and data copied to clipboard!");
        }
    }
}
