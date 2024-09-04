namespace WebDataExtractor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button fetchButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.GroupBox productNameGroupBox;
        private System.Windows.Forms.GroupBox linkWebsiteGroupBox;
        private System.Windows.Forms.GroupBox priceGroupBox;
        private System.Windows.Forms.GroupBox supplierLinkGroupBox;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.TextBox linkWebsiteTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox supplierLinkTextBox;
        private System.Windows.Forms.RichTextBox dataRichTextBox;
        private System.Windows.Forms.Button copyAllButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button copyPromptButton;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.fetchButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.productNameGroupBox = new System.Windows.Forms.GroupBox();
            this.linkWebsiteGroupBox = new System.Windows.Forms.GroupBox();
            this.priceGroupBox = new System.Windows.Forms.GroupBox();
            this.supplierLinkGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.linkWebsiteTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.supplierLinkTextBox = new System.Windows.Forms.TextBox();
            this.dataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.copyAllButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.copyPromptButton = new System.Windows.Forms.Button(); 
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark Gray
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 60;
            this.headerPanel.Controls.Add(this.titleLabel);
            // 
            // titleLabel
            // 
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Text = "GAOTEKMAGANG WEBEXTRACTOR";
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(12, 70);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(650, 23);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.urlTextBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); // Dark Background
            this.urlTextBox.ForeColor = System.Drawing.Color.White;
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urlTextBox.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right); // Responsive pada sisi kiri, atas, dan kanan
            // 
            // fetchButton
            // 
            this.fetchButton.Location = new System.Drawing.Point(680, 70);
            this.fetchButton.Name = "fetchButton";
            this.fetchButton.Size = new System.Drawing.Size(100, 30); // Ukuran diperbesar untuk menampung teks lebih baik
            this.fetchButton.TabIndex = 1;
            this.fetchButton.Text = "Fetch Data";
            this.fetchButton.UseVisualStyleBackColor = false;
            this.fetchButton.BackColor = System.Drawing.Color.FromArgb(28, 151, 234); // Soft Blue
            this.fetchButton.ForeColor = System.Drawing.Color.White;
            this.fetchButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.fetchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fetchButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; // Memastikan teks berada di tengah
            this.fetchButton.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right); // Responsive pada sisi atas dan kanan
            this.fetchButton.Click += new System.EventHandler(this.fetchButton_Click);
            // 
            // productNameGroupBox
            // 
            this.productNameGroupBox.Controls.Add(this.productNameTextBox);
            this.productNameGroupBox.Location = new System.Drawing.Point(12, 110);
            this.productNameGroupBox.Name = "productNameGroupBox";
            this.productNameGroupBox.Size = new System.Drawing.Size(770, 50);
            this.productNameGroupBox.TabIndex = 2;
            this.productNameGroupBox.Text = "Product Name";
            this.productNameGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.productNameGroupBox.ForeColor = System.Drawing.Color.White;
            this.productNameGroupBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38); // Darker Gray
            this.productNameGroupBox.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right); // Responsive pada sisi kiri, atas, dan kanan
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productNameTextBox.ReadOnly = true;
            this.productNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.productNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productNameTextBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); // Dark Background
            this.productNameTextBox.ForeColor = System.Drawing.Color.White;
            // 
            // linkWebsiteGroupBox
            // 
            this.linkWebsiteGroupBox.Controls.Add(this.linkWebsiteTextBox);
            this.linkWebsiteGroupBox.Location = new System.Drawing.Point(12, 170);
            this.linkWebsiteGroupBox.Name = "linkWebsiteGroupBox";
            this.linkWebsiteGroupBox.Size = new System.Drawing.Size(770, 50);
            this.linkWebsiteGroupBox.TabIndex = 3;
            this.linkWebsiteGroupBox.Text = "Link Website";
            this.linkWebsiteGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.linkWebsiteGroupBox.ForeColor = System.Drawing.Color.White;
            this.linkWebsiteGroupBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38); // Darker Gray
            this.linkWebsiteGroupBox.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right); // Responsive pada sisi kiri, atas, dan kanan
            // 
            // linkWebsiteTextBox
            // 
            this.linkWebsiteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkWebsiteTextBox.ReadOnly = true;
            this.linkWebsiteTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.linkWebsiteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linkWebsiteTextBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); // Dark Background
            this.linkWebsiteTextBox.ForeColor = System.Drawing.Color.White;
            // 
            // priceGroupBox
            // 
            this.priceGroupBox.Controls.Add(this.priceTextBox);
            this.priceGroupBox.Location = new System.Drawing.Point(12, 230);
            this.priceGroupBox.Name = "priceGroupBox";
            this.priceGroupBox.Size = new System.Drawing.Size(770, 50);
            this.priceGroupBox.TabIndex = 4;
            this.priceGroupBox.Text = "Price";
            this.priceGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.priceGroupBox.ForeColor = System.Drawing.Color.White;
            this.priceGroupBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38); // Darker Gray
            this.priceGroupBox.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right); // Responsive pada sisi kiri, atas, dan kanan
            // 
            // priceTextBox
            // 
            this.priceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceTextBox.ReadOnly = true;
            this.priceTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.priceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priceTextBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); // Dark Background
            this.priceTextBox.ForeColor = System.Drawing.Color.White;
            // 
            // supplierLinkGroupBox
            // 
            this.supplierLinkGroupBox.Controls.Add(this.supplierLinkTextBox);
            this.supplierLinkGroupBox.Location = new System.Drawing.Point(12, 290);
            this.supplierLinkGroupBox.Name = "supplierLinkGroupBox";
            this.supplierLinkGroupBox.Size = new System.Drawing.Size(770, 50);
            this.supplierLinkGroupBox.TabIndex = 5;
            this.supplierLinkGroupBox.Text = "Supplier Link";
            this.supplierLinkGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.supplierLinkGroupBox.ForeColor = System.Drawing.Color.White;
            this.supplierLinkGroupBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38); // Darker Gray
            this.supplierLinkGroupBox.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right); // Responsive pada sisi kiri, atas, dan kanan
            // 
            // supplierLinkTextBox
            // 
            this.supplierLinkTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supplierLinkTextBox.ReadOnly = true;
            this.supplierLinkTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.supplierLinkTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supplierLinkTextBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); // Dark Background
            this.supplierLinkTextBox.ForeColor = System.Drawing.Color.White;
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Controls.Add(this.dataRichTextBox);
            this.dataGroupBox.Location = new System.Drawing.Point(12, 350);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(770, 150);
            this.dataGroupBox.TabIndex = 6;
            this.dataGroupBox.Text = "Data";
            this.dataGroupBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dataGroupBox.ForeColor = System.Drawing.Color.White;
            this.dataGroupBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38); // Darker Gray
            this.dataGroupBox.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right); // Responsive pada sisi kiri, atas, dan kanan
            // 
            // dataRichTextBox
            // 
            this.dataRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataRichTextBox.ReadOnly = true;
            this.dataRichTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataRichTextBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); // Dark Background
            this.dataRichTextBox.ForeColor = System.Drawing.Color.White;
            // 
            // copyAllButton
            // 
            this.copyAllButton.Location = new System.Drawing.Point(12, 510); // Pindahkan tombol Copy All di antara dataGroupBox dan flowLayoutPanel
            this.copyAllButton.Name = "copyAllButton";
            this.copyAllButton.Size = new System.Drawing.Size(100, 30); // Ukuran diperbesar untuk menampung teks lebih baik
            this.copyAllButton.TabIndex = 7;
            this.copyAllButton.Text = "Copy Data";
            this.copyAllButton.UseVisualStyleBackColor = false;
            this.copyAllButton.BackColor = System.Drawing.Color.FromArgb(255, 69, 0); // RedOrange
            this.copyAllButton.ForeColor = System.Drawing.Color.White;
            this.copyAllButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.copyAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyAllButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; // Memastikan teks berada di tengah
            this.copyAllButton.Click += new System.EventHandler(this.copyAllButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 550);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(776, 150);
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.TabIndex = 8;
            this.flowLayoutPanel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right); // Responsive penuh
            // 
            // ProgressBar
            // 
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar1.Location = new System.Drawing.Point(12, 50); // Di bawah judul
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(770, 10); // Lebar lebih besar
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee; // Gaya marquee
            this.progressBar1.Visible = false;
            this.progressBar1.ForeColor = System.Drawing.Color.LimeGreen; // Warna hijau
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark Gray Background
            this.Controls.Add(this.progressBar1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); // Dark Mode Background
            this.ClientSize = new System.Drawing.Size(800, 720); // Ukuran disesuaikan agar pas dengan penambahan copyAllButton
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.productNameGroupBox);
            this.Controls.Add(this.linkWebsiteGroupBox);
            this.Controls.Add(this.priceGroupBox);
            this.Controls.Add(this.supplierLinkGroupBox);
            this.Controls.Add(this.dataGroupBox);
            this.Controls.Add(this.copyAllButton); // Tambahkan copyAllButton di sini
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.urlTextBox); // Menambahkan TextBox untuk URL
            this.Controls.Add(this.fetchButton); // Menambahkan tombol untuk memulai fetch data
            this.Name = "Form1";
            this.Text = "GAOTEKMAGANG-WEBEXTRACTOR";
            this.copyPromptButton.Location = new System.Drawing.Point(120, 510);
            this.copyPromptButton.Name = "copyPromptButton";
            this.copyPromptButton.Size = new System.Drawing.Size(200, 30);
            this.copyPromptButton.TabIndex = 9;
            this.copyPromptButton.Text = "Copy Prompt and Data";
            this.copyPromptButton.UseVisualStyleBackColor = false;
            this.copyPromptButton.BackColor = System.Drawing.Color.FromArgb(28, 151, 234);
            this.copyPromptButton.ForeColor = System.Drawing.Color.White;
            this.copyPromptButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.copyPromptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyPromptButton.Click += new System.EventHandler(this.copyPromptButton_Click);
            this.copyPromptButton.Visible = false; // Hidden initially

            // Add other components to the form
            this.Controls.Add(this.copyPromptButton);
            this.ResumeLayout(false);
            this.PerformLayout();

            
        }

        #endregion
    }
}
