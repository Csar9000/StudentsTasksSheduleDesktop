using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checking_SSMS_queries_in_DB__LabWork2_DataControl_
{
    public partial class Group : Form
    {
        public Group()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Group_2". При необходимости она может быть перемещена или удалена.
            this.group_2TableAdapter.Fill(this._Students___TasksDataSet5.Group_2);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet.Group_2". При необходимости она может быть перемещена или удалена.
            // this.group_2TableAdapter.Fill(this._Students___TasksDataSet.Group_2);
            //this._Students___TasksDataSet.Group_2.Clear();
            // sqlDataAdapter1.Fill(this._Students___TasksDataSet.Group_2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlInsertCommand1.Parameters["@GroupNum"].Value = textBox1.Text;
            sqlInsertCommand1.Parameters["@MajorName"].Value = textBox2.Text;
            sqlInsertCommand1.Parameters["@Year"].Value =Convert.ToDateTime(textBox3.Text);
            sqlInsertCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись добавлена");
            Form1_Load(null,null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            sqlConnection1.Open();
            sqlDeleteCommand.Parameters["@GroupNum"].Value = row["GroupNum"];
            sqlDeleteCommand.ExecuteNonQuery();
            sqlConnection1.Close();
            Form1_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlUpdateCommand1.Parameters["@GroupNum"].Value = textBox1.Text;
            sqlUpdateCommand1.Parameters["@MajorName"].Value = textBox2.Text;
            sqlInsertCommand1.Parameters["@Year"].Value = Convert.ToDateTime(textBox3.Text);
            sqlUpdateCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            textBox1.Text = row["GroupNum"].ToString();
            textBox2.Text = row["MajorName"].ToString();
            textBox3.Text = row["Year_2"].ToString();
        }
    }
}
