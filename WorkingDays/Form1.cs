///////////////////////////////////////////////////////////////////////////////////
//
// Working Days Summary Usage Samples 
// [Form1.cs]
// (c) Sep 2023, Younes Jafari
// 
///////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkingDaySummary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<WorkingDay> workingDays = null;
            if (radioButton1.Checked)
            {
                workingDays = new List<WorkingDay>
                {
                    new WorkingDay(0, "Mon", "16:30 to 20:00"),
                    new WorkingDay(1, "Tue", "16:30 to 20:00"),
                    new WorkingDay(2, "Wed", "16:30 to 20:00"),
                    new WorkingDay(3, "Thu", "16:30 to 20:00"),
                    new WorkingDay(4, "Fri", "16:30 to 20:00"),
                    new WorkingDay(5, "Sat", "16:30 to 20:00")
                };
            }
            else if (radioButton2.Checked)
            {
                workingDays = new List<WorkingDay>
                {
                    new WorkingDay(0, "Mon", "16:30 to 20:00"),
                    new WorkingDay(2, "Wed", "16:30 to 20:00"),
                    new WorkingDay(4, "Fri", "16:30 to 20:00"),
                };
            }
            else if (radioButton3.Checked)
            {
                workingDays = new List<WorkingDay>
                {
                    new WorkingDay(1, "Tue", "16:30 to 20:00"),
                    new WorkingDay(3, "Thu", "16:30 to 20:00"),
                    new WorkingDay(5, "Sat", "16:30 to 20:00"),
                };
            }
            else if (radioButton4.Checked)
            {
                workingDays = new List<WorkingDay>
                {
                    new WorkingDay(0, "Mon", "16:30 to 20:00"),
                    new WorkingDay(1, "Tue", "16:30 to 20:00"),
                    new WorkingDay(2, "Wed", "16:30 to 20:00"),
                    new WorkingDay(3, "Thu", "16:30 to 20:00"),
                    new WorkingDay(4, "Fri", "16:30 to 20:00"),
                    new WorkingDay(5, "Sat", "16:00 to 21:00")
                };
            }
            else if (radioButton5.Checked)
            {
                workingDays = new List<WorkingDay>
                {
                    new WorkingDay(0, "Mon", "12:30 to 18:00"),
                    new WorkingDay(1, "Tue", "16:30 to 20:00"),
                    new WorkingDay(2, "Wed", "16:30 to 20:00"),
                    new WorkingDay(3, "Thu", "16:30 to 20:00"),
                    new WorkingDay(4, "Fri", "16:30 to 20:00"),
                    new WorkingDay(5, "Sat", "16:30 to 20:00")
                };
            }
            else if (radioButton6.Checked)
            {
                workingDays = new List<WorkingDay>
                {
                    new WorkingDay(0, "Mon", "08:30 to 11:00", "16:30 to 20:00"),
                    new WorkingDay(1, "Tue", "16:30 to 20:00"),
                    new WorkingDay(2, "Wed", "08:30 to 11:00", "16:30 to 20:00"),
                    new WorkingDay(3, "Thu", "16:30 to 20:00"),
                    new WorkingDay(4, "Fri", "08:30 to 11:00", "16:30 to 20:00"),
                    new WorkingDay(5, "Sat", "16:30 to 20:00")
                };
            }
            else if (radioButton7.Checked)
            {
                workingDays = new List<WorkingDay>
                {
                    new WorkingDay(0, "Mon", "12:30 to 18:00"),
                    new WorkingDay(1, "Tue", "11:30 to 20:00"),
                    new WorkingDay(2, "Wed", "16:30 to 20:00"),
                    new WorkingDay(3, "Thu", "16:30 to 20:00"),
                    new WorkingDay(4, "Fri", "18:30 to 20:00"),
                    new WorkingDay(5, "Sat", "16:30 to 20:00")
                };
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(workingDays.ToArray());


            textBox1.Text = WorkingDay.GetWorkdaysSummary(workingDays);
        }
    }
}
