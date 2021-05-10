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
    using Excel = Microsoft.Office.Interop.Excel;

    public partial class ComplexTable : Form
    {
        public Excel.Application excelapp;
        private Excel.Workbooks excelappworkbooks;
        private Excel.Workbook excelappworkbook;
        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelcells;




        public ComplexTable()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {// TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.TaskOne". При необходимости она может быть перемещена или удалена.
            this.taskOneTableAdapter.Fill(this._Students___TasksDataSet5.TaskOne);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Tasks". При необходимости она может быть перемещена или удалена.
            this.tasksTableAdapter.Fill(this._Students___TasksDataSet5.Tasks);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Student". При необходимости она может быть перемещена или удалена.
            this.studentTableAdapter.Fill(this._Students___TasksDataSet5.Student);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet5.Student_has_Tasks". При необходимости она может быть перемещена или удалена.
            this.student_has_TasksTableAdapter.Fill(this._Students___TasksDataSet5.Student_has_Tasks);
            /*
                        // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet4.TaskOne". При необходимости она может быть перемещена или удалена.
                        //this.taskOneTableAdapter.Fill(this._Students___TasksDataSet4.TaskOne);
                        // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet3.Tasks". При необходимости она может быть перемещена или удалена.
                       // this.tasksTableAdapter.Fill(this._Students___TasksDataSet3.Tasks);
                       // // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet3.Student". При необходимости она может быть перемещена или удалена.
                        this.studentTableAdapter.Fill(this._Students___TasksDataSet3.Student);
                       // // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet3.Student_has_Tasks". При необходимости она может быть перемещена или удалена.
                        //this.student_has_TasksTableAdapter.Fill(this._Students___TasksDataSet3.Student_has_Tasks);
                        // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet3.Group_2". При необходимости она может быть перемещена или удалена.
                        this.group_2TableAdapter.Fill(this._Students___TasksDataSet3.Group_2);
                        // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet3.Curriculum". При необходимости она может быть перемещена или удалена.
                        this.curriculumTableAdapter.Fill(this._Students___TasksDataSet3.Curriculum);
                        // TODO: данная строка кода позволяет загрузить данные в таблицу "_Students___TasksDataSet3.Group_2". При необходимости она может быть перемещена или удалена.
                        this.group_2TableAdapter.Fill(this._Students___TasksDataSet3.Group_2);
                        */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlInsertCommand1.Parameters["@Student_NumberOfCreditBook"].Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            sqlInsertCommand1.Parameters["@Tasks_idTaskNumber"].Value = Convert.ToInt32(textBox4.Text);
            sqlInsertCommand1.Parameters["@TaskPassDate"].Value = Convert.ToDateTime(textBox1.Text);
            sqlInsertCommand1.Parameters["@TaskGetDate"].Value = Convert.ToDateTime(textBox3.Text);
            sqlInsertCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            MessageBox.Show("Запись добавлена");
            Form1_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow row = PublicClass.GetCurrentRow(dataGridView1);
            comboBox1.SelectedValue = Convert.ToInt32(row["Student_NumberOfCreditBook"].ToString());
            comboBox2.SelectedValue = Convert.ToInt32(row["Tasks_idTaskNumber"].ToString());
            comboBox3.SelectedValue = Convert.ToInt32(row["Tasks_idTaskNumber"].ToString());
            comboBox4.SelectedValue = Convert.ToInt32(row["Student_NumberOfCreditBook"].ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveToExcel()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Ошибка: нет данных для сохранения!", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = "Student_NumberOfCreditBook";
            workSheet.Cells[1, "B"] = "Паспортные данные";
            workSheet.Cells[1, "C"] = "Регистрационный номер книги";
            workSheet.Cells[1, "D"] = "Дата выдачи";


            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                workSheet.Cells[(i + 2), "A"] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                workSheet.Cells[(i + 2), "B"] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                workSheet.Cells[(i + 2), "C"] = dataGridView1.Rows[i].Cells[2].Value.ToString();
                workSheet.Cells[(i + 2), "D"] = dataGridView1.Rows[i].Cells[3].Value.ToString();
            }

            try
            {
                workSheet.SaveAs(filename);
                MessageBox.Show("Данные сохранены!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка: неудалось сохранить файл!", "Ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void ReadExcel()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            dataGridView2.Rows.Clear();

            string filename = openFileDialog1.FileName;

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelBook = excelApp.Workbooks.Open(filename);
            Excel._Worksheet excelSheet = excelBook.Sheets[1];
            Excel.Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            List<List<string>> maping = new List<List<string>>();
            for (int i = 1; i <= rows; i++)
            {
                maping.Add(new List<string>());
                for (int j = 1; j <= cols; j++)
                {
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                        maping[(i - 1)].Add(excelRange.Cells[i, j].Value2.ToString());
                }
            }

            excelBook.Close();
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            for (int i = 1; i < maping.Count-1; i++)
            {
                dataGridView2.Rows.Add(
                maping[i][0],
                maping[i][1],
                maping[i][2],
                maping[i][3]);
            }

            dataGridView2.Refresh();

            MessageBox.Show("Данные считаны!", "Информация",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveToExcel();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReadExcel();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
           sqlConnection1.Open();

            using (SqlCommand command = new SqlCommand("dbo.TaskOneProc", sqlConnection1))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@GroupNum", textGroupTask.Text);
                SqlDataReader sqlReader = command.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        String fullName = sqlReader.GetValue(0).ToString();
                        String Number = sqlReader.GetValue(1).ToString();
                        String Subject = sqlReader.GetValue(2).ToString();


                        dataGridView2.Rows.Add(fullName,Number,Subject);
                    }
                }
                sqlReader.Close();
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                using (SqlCommand command = new SqlCommand("dbo.TaskOneProcFindNumber", sqlConnection1))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@GroupNum", textGroupTask.Text);
                    SqlDataReader sqlReader = command.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            String Count = sqlReader.GetValue(0).ToString();

                            dataGridView2.Rows[i].Cells[dataGridView2.Rows[i].Cells.Count - 1].Value = Count;
                        }
                    }
                    sqlReader.Close();
                }
            }

            sqlConnection1.Close();
            //this._Students___TasksDataSet5.TaskOne.Clear();
           // sqlDataAdapter3.Fill( this._Students___TasksDataSet5.TaskOne);
        }

        private void sqlConnection3_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {

        }
    }

   
}
