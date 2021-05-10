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
    public partial class Curriculum : Form
    {
        public Curriculum()
        {
            InitializeComponent();
        }

        private void Curriculum_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Curriculum". При необходимости она может быть перемещена или удалена.
            this.curriculumTableAdapter.Fill(this._Students___TasksDataSet5.Curriculum);
            //this._Students___TasksDataSet.Curriculum.Clear();
            sqlDataAdapter1.Fill(this._Students___TasksDataSet5.Curriculum);
             this.curriculumTableAdapter.Fill(this._Students___TasksDataSet5.Curriculum);

        }

        private void Curriculum_Deactivate(object sender, EventArgs e)
        {
            //sqlDataAdapter1.Update(this._Students___TasksDataSet.Curriculum);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlInsertCommand1.Parameters["@GroupNum"].Value = textBox1.Text;
            sqlInsertCommand1.Parameters["@SubjectName"].Value = textBox2.Text;
            sqlInsertCommand1.ExecuteNonQuery();
            sqlConnection1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            textBox1.Text = row["GroupNum"].ToString();
            textBox2.Text = row["SubjectName"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlUpdateCommand1.Parameters["@GroupNum"].Value = textBox1.Text;
            sqlUpdateCommand1.Parameters["@SubjectName"].Value = textBox2.Text;
            sqlUpdateCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            sqlConnection1.Open();
            sqlDeleteCommand1.Parameters["@GroupNum"].Value = row["Group_2_GroupNum"];
            sqlDeleteCommand1.Parameters["@SubjectName"].Value = row["Subject_SubjectName"];
            sqlDeleteCommand1.ExecuteNonQuery();
            sqlConnection1.Close();

        }
    }
}
