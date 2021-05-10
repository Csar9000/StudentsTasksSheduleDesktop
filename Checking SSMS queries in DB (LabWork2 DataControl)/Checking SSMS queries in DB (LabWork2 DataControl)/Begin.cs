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
    public partial class Begin : Form
    {
        public Begin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Curriculum gr = new Curriculum();
            gr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Group gr = new Group();
            gr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student gr = new Student();
            gr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Subject gr = new Subject();
            gr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SudentHasTasks gr = new SudentHasTasks();
            gr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tasks gr = new Tasks();
            gr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ComplexTable fr = new ComplexTable();
            fr.Show();
        }
    }
}
