using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            this.Hide();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            this.Hide();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            this.Hide();
            frm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            this.Hide();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static int control = 0;

        private void button8_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            this.Controls.Clear();
            InitializeComponent();
            control = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("aze");
            this.Controls.Clear();
            InitializeComponent();
            control = 0;
        }
    }
}
