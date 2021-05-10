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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Group_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Student". При необходимости она может быть перемещена или удалена.
            this.studentTableAdapter.Fill(this._Students___TasksDataSet5.Student);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet.Student". При необходимости она может быть перемещена или удалена.
            //this.studentTableAdapter.Fill(this._Students___TasksDataSet.Student);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet.Group_2". При необходимости она может быть перемещена или удалена.
            // this.group_2TableAdapter.Fill(this._Students___TasksDataSet.Group_2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet.Group_2". При необходимости она может быть перемещена или удалена.
            // this.group_2TableAdapter.Fill(this._Students___TasksDataSet.Group_2);
           // this._Students___TasksDataSet.Group_2.Clear();
           // sqlDataAdapter1.Fill(this._Students___TasksDataSet.Student);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();

            sqlInsertCommand1.Parameters["@NumberOfCreditBook"].Value = Convert.ToInt32(textBox2.Text);
            sqlInsertCommand1.Parameters["@NewGroupNum"].Value = textBox1.Text;
            sqlInsertCommand1.Parameters["@NewFIO"].Value = textBox3.Text;
            sqlInsertCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись добавлена");
            Form1_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            string s = Convert.ToString(Convert.ToInt32(row["NumberOfCreditBook"])).Trim();
            sqlConnection1.Open();
            sqlDeleteCommand1.Parameters["@NumberOfCreditBook"].Value = Convert.ToInt32(s);
            sqlDeleteCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            Form1_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlUpdateCommand1.Parameters["@NumberOfCreditBook"].Value = Convert.ToInt32(textBox2.Text);
            sqlUpdateCommand1.Parameters["@NewGroupNum"].Value = textBox1.Text;
            sqlUpdateCommand1.Parameters["@NewFIO"].Value = textBox3.Text;
            sqlUpdateCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            Form1_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            textBox2.Text = row["NumberOfCreditBook"].ToString();
            textBox1.Text = row["Group_2_GroupNum"].ToString();
            textBox3.Text = row["FIO"].ToString();
        }

    }
}

