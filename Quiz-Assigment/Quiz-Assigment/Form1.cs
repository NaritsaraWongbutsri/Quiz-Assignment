using System.Text;

namespace Quiz_Assigment
{
    public partial class Form1 : Form
    {
        private int inIn;
        private int inEx;


        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV(*.csv)|*.csv";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                this.dataGridView1.Text = readAllLine[0];
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBoxList.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBoxIncome.Text;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string listRAW = readAllLine[i];
                    string[] listSplited = listRAW.Split(',');
                    IncomeAndExpenses list = new IncomeAndExpenses(listSplited[0], listSplited[1], listSplited[2]);
                }

            }

        }
        private void addDataToGridView(string list, string income, string expenses)
        {
            this.dataGridView1.Rows.Add(new string[] { list, income, expenses });
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strData = string.Empty;
            string filepath = String.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = " CSV(*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != String.Empty)
                {
                    int row = this.dataGridView1.Rows.Count;
                    for (int i = 0; i < row; i++)
                    {
                        int column = this.dataGridView1.Columns.Count;
                        for (int j = 0; j < column; j++)
                        {
                            if (this.dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                strData = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    File.WriteAllText(saveFileDialog.FileName, this.dataGridView1.Text, Encoding.UTF8);
                }
            }
        }


        int sumin = 0, sumex = 0, inin = 0, inex = 0;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxList.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxIncome.Text;
            dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;


            //inIn = Convert.ToInt32(textBoxIncome.Text);
            //inEx = Convert.ToInt32(textBoxExpenses.Text);

            sumin = inIn + sumin;
            sumex = inEx + sumex;

            textBox4.Text = sumin.ToString();
            textBox5.Text = sumex.ToString();
        }

    }
}  