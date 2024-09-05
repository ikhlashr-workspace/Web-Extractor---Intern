using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WebDataExtractor
{
    public partial class CheckDataForm : Form
    {
        public CheckDataForm(string fullData)
        {
            InitializeComponent();

            
            try
            {
                var tableDataList = ExtractTablesFromHtml(fullData);

                
                PopulateDataGridView(tableDataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extracting table: " + ex.Message);
            }
        }

        
        private List<List<string[]>> ExtractTablesFromHtml(string htmlData)
        {
            
            string tablePattern = @"<table.*?>(.*?)<\/table>";
            string rowPattern = @"<tr.*?>(.*?)<\/tr>";
            string cellPattern = @"<(td|th).*?>(.*?)<\/\1>"; 

            
            MatchCollection tableMatches = Regex.Matches(htmlData, tablePattern, RegexOptions.Singleline);
            List<List<string[]>> tableDataList = new List<List<string[]>>();

            foreach (Match tableMatch in tableMatches)
            {
                
                MatchCollection rowMatches = Regex.Matches(tableMatch.Value, rowPattern, RegexOptions.Singleline);
                List<string[]> tableData = new List<string[]>();

                foreach (Match rowMatch in rowMatches)
                {
                    
                    MatchCollection cellMatches = Regex.Matches(rowMatch.Value, cellPattern, RegexOptions.Singleline);
                    List<string> rowData = new List<string>();

                    foreach (Match cellMatch in cellMatches)
                    {
                        
                        string cellValue = Regex.Replace(cellMatch.Groups[2].Value, @"<.*?>", string.Empty).Trim();
                        rowData.Add(cellValue);
                    }

                    
                    if (rowData.Count > 0)
                    {
                        tableData.Add(rowData.ToArray());
                    }
                }

                if (tableData.Count > 0)
                {
                    tableDataList.Add(tableData); 
                }
            }

            return tableDataList;
        }

        
        private void PopulateDataGridView(List<List<string[]>> tableDataList)
        {
            
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            if (tableDataList.Count == 0)
            {
                MessageBox.Show("No tables found in the provided HTML data.");
                return;
            }

            
            var firstTable = tableDataList[0];
            int maxColumns = 0;

            
            foreach (var row in firstTable)
            {
                if (row.Length > maxColumns)
                {
                    maxColumns = row.Length;
                }
            }

            
            for (int i = 0; i < maxColumns; i++)
            {
                dataGridView1.Columns.Add("Column" + (i + 1), "Column " + (i + 1));
            }

            
            foreach (var row in firstTable)
            {
                dataGridView1.Rows.Add(row);
            }

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
