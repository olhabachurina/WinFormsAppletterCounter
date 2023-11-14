using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsAppletterCounter
{
    public partial class Form1 : Form
    {
        private List<WordData> wordDataList = new List<WordData>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string word = wordtextBox.Text.ToLower();
            string targetPhrase = lettertextBox.Text.ToLower();

            int count = CountPhrases(word, targetPhrase);
            label1.Text = $"Словосочетание '{targetPhrase}' встречается в слове '{word}' {count} раз";

            wordDataList.Add(new WordData { Word = word, TargetPhrase = targetPhrase, Count = count });
            UpdateDataGridView();
        }

        private int CountPhrases(string word, string targetPhrase)
        {
            int count = 0;
            int index = -1;

            while ((index = word.IndexOf(targetPhrase, index + 1)) != -1)
            {
                count++;
            }

            return count;
        }

        private void UpdateDataGridView()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Слово", typeof(string));
            dataTable.Columns.Add("Словосочетание", typeof(string));
            dataTable.Columns.Add("Количество", typeof(int));

            // Заполняем DataTable данными из списка
            foreach (WordData wordData in wordDataList)
            {
                dataTable.Rows.Add(wordData.Word, wordData.TargetPhrase, wordData.Count);
            }

            // Устанавливаем DataTable как источник данных для DataGridView
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoResizeColumns();
        }

        private class WordData
        {
            public string Word { get; set; }
            public string TargetPhrase { get; set; }
            public int Count { get; set; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}