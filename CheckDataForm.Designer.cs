//create by iklashR
namespace WebDataExtractor
{
    partial class CheckDataForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new DataGridView();
            this.SuspendLayout();
            
            // dataGridView1
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // Kolom otomatis menyesuaikan
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;   // Baris otomatis menyesuaikan
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Font = new System.Drawing.Font("Segoe UI", 12F);  // Perbesar font
            this.dataGridView1.RowTemplate.Height = 40;  // Ukuran baris lebih besar
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);  // Header font lebih besar
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;

            // CheckDataForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);  // Perbesar ukuran form
            this.Controls.Add(this.dataGridView1);
            this.Name = "Technical Spesifications";
            this.Text = "Technical Spesifications";
            this.ResumeLayout(false);
        }
    }
}
