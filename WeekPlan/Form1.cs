using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace WeekPlan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
        }

        Commands command = new Commands();
        private void button1_Click(object sender, EventArgs e)
        {

            command.saveFile(comboBox1, dateTimePicker1, textBox2);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            command.fileOpen(comboBox1, dateTimePicker1, textBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = command.DataCSV();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
