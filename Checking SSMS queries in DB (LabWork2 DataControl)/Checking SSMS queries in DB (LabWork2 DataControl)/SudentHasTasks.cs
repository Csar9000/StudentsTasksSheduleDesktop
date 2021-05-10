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
    public partial class SudentHasTasks : Form
    {
        public SudentHasTasks()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Student_has_Tasks". При необходимости она может быть перемещена или удалена.
            this.student_has_TasksTableAdapter.Fill(this._Students___TasksDataSet5.Student_has_Tasks);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet.Student_has_Tasks". При необходимости она может быть перемещена или удалена.
            //this.student_has_TasksTableAdapter.Fill(this._Students___TasksDataSet.Student_has_Tasks);
             this._Students___TasksDataSet5.Student_has_Tasks.Clear();
             sqlDataAdapter1.Fill(this._Students___TasksDataSet5.Student_has_Tasks);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            sqlConnection1.Open();
            sqlInsertCommand1.Parameters["@Student_NumberOfCreditBook"].Value = Convert.ToInt32(textBox2.Text);
            sqlInsertCommand1.Parameters["@Tasks_idTaskNumber"].Value = Convert.ToInt32(textBox4.Text);
            sqlInsertCommand1.Parameters["@TaskPassDate"].Value = Convert.ToDateTime(textBox1.Text);
            sqlInsertCommand1.Parameters["@TaskGetDate"].Value = Convert.ToDateTime(textBox3.Text);
            sqlInsertCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись добавлена");
            Form1_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            sqlConnection1.Open();
            sqlDeleteCommand1.Parameters["@Student_NumberOfCreditBook"].Value = Convert.ToInt32(row["Student_NumberOfCreditBook"]);
            sqlDeleteCommand1.Parameters["@Tasks_idTaskNumber"].Value = Convert.ToInt32(row["Tasks_idTaskNumber"]);
            sqlDeleteCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            Form1_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            string s = Convert.ToString(textBox2.Text).Trim();
            sqlUpdateCommand1.Parameters["@Student_NumberOfCreditBook"].Value = Convert.ToInt32(s);
            sqlUpdateCommand1.Parameters["@Tasks_idTaskNumber"].Value = Convert.ToInt32(textBox4.Text);
            sqlUpdateCommand1.Parameters["@TaskPassDate"].Value = Convert.ToDateTime(textBox1.Text);
            sqlUpdateCommand1.Parameters["@TaskGetDate"].Value = Convert.ToDateTime(textBox3.Text);
            sqlUpdateCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            Form1_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            textBox2.Text = row["Student_NumberOfCreditBook"].ToString();
            textBox4.Text = row["Tasks_idTaskNumber"].ToString();
            textBox1.Text = row["TaskPassDate"].ToString();
            textBox3.Text = row["TaskGetDate"].ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

