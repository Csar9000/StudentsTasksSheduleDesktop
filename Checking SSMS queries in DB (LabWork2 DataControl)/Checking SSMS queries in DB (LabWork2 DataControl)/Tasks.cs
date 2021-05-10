using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checking_SSMS_queries_in_DB__LabWork2_DataControl_
{
    public partial class Tasks : Form
    {
        public Tasks()
        {
            InitializeComponent();
        }

        private void Tasks_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Tasks". При необходимости она может быть перемещена или удалена.
            this.tasksTableAdapter.Fill(this._Students___TasksDataSet5.Tasks);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet.Tasks". При необходимости она может быть перемещена или удалена.
            //this.tasksTableAdapter.Fill(this._Students___TasksDataSet.Tasks);
            this._Students___TasksDataSet5.Tasks.Clear();
            sqlDataAdapter1.Fill(this._Students___TasksDataSet5.Tasks);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlInsertCommand1.Parameters["@idTaskNumber"].Value = Convert.ToInt32(textBox1.Text);
            sqlInsertCommand1.Parameters["@TaskNumber"].Value = Convert.ToInt32(textBox2.Text);
            sqlInsertCommand1.Parameters["@Subject_SubjectName"].Value = textBox3.Text;
            sqlInsertCommand1.Parameters["@Summary"].Value = textBox4.Text;
            sqlInsertCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись добавлена");
            Tasks_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            string s = Convert.ToString(row["idTaskNumber"]).Trim();
            sqlConnection1.Open();
            sqlDeleteCommand1.Parameters["@idTaskNumber"].Value = Convert.ToInt32(s);
            sqlDeleteCommand1.Parameters["@TaskNumber"].Value = Convert.ToInt32(row["TaskNumber"]);
            sqlDeleteCommand1.Parameters["@Subject_SubjectName"].Value = row["Subject_SubjectName"];
            sqlDeleteCommand1.Parameters["@Summary"].Value = row["Summary"];
            sqlDeleteCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись удалена");
            Tasks_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlUpdateCommand1.Parameters["@idTaskNumber"].Value = Convert.ToInt32(textBox1.Text);
            sqlUpdateCommand1.Parameters["@TaskNumber"].Value = Convert.ToInt32(textBox2.Text);
            sqlUpdateCommand1.Parameters["@Subject_SubjectName"].Value = textBox3.Text;
            sqlUpdateCommand1.Parameters["@Summary"].Value = textBox4.Text;
            sqlUpdateCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            Tasks_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            textBox1.Text = row["idTaskNumber"].ToString();
            textBox2.Text = row["TaskNumber"].ToString();
            textBox3.Text = row["Subject_SubjectName"].ToString();
            textBox4.Text = row["Summary"].ToString();
        }
    }
}
