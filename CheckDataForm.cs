using System.Windows.Forms;

namespace WebDataExtractor
{
    public partial class CheckDataForm : Form
    {
        public CheckDataForm(string fullData)
        {
            InitializeComponent();

            // Initialize RichTextBox to display full data
            richTextBox1.Text = fullData; // Assuming you have a richTextBox1 on this form
        }
    }
}
