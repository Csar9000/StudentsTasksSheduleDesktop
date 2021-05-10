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
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet.Subject". При необходимости она может быть перемещена или удалена.
            //this.subjectTableAdapter.Fill(this._Students___TasksDataSet.Subject);
            this._Students___TasksDataSet5.Subject.Clear();
            sqlDataAdapter1.Fill(this._Students___TasksDataSet5.Subject);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlInsertCommand1.Parameters["@SubjectName"].Value = textBox4.Text;
            sqlInsertCommand1.Parameters["@TeachersFIO"].Value = textBox5.Text;
            sqlInsertCommand1.Parameters["@Department"].Value =textBox6.Text;
            sqlInsertCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись добавлена");
            Form1_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            string s= Convert.ToString(row["SubjectName"]).Trim();
            sqlConnection1.Open();
            sqlDeleteCommand1.Parameters["@SubjectName"].Value =s;
            sqlDeleteCommand1.Parameters["@TeachersFIO"].Value =textBox4.Text;
            sqlDeleteCommand1.Parameters["@Department"].Value = textBox6.Text;
            sqlDeleteCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись удалена");
            Form1_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlUpdateCommand1.Parameters["@SubjectName"].Value = textBox4.Text;
            sqlUpdateCommand1.Parameters["@TeachersFIO"].Value = textBox5.Text;
            sqlUpdateCommand1.Parameters["@Department"].Value = textBox6.Text;
            sqlUpdateCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись изменена");
            Form1_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            textBox4.Text = row["SubjectName"].ToString();
            textBox5.Text = row["TeachersFIO"].ToString();
            textBox6.Text = row["Department"].ToString();
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Subject". При необходимости она может быть перемещена или удалена.
            this.subjectTableAdapter1.Fill(this._Students___TasksDataSet5.Subject);

        }
    }
}
