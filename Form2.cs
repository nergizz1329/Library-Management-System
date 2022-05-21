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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-U648IRH; Initial Catalog = Library; Integrated Security = True");
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Kitabın adı mütləq daxil edilməlidir.");
            }
            else
            {
                con.Open();
                SqlCommand com = new SqlCommand("insert into Book (title,author,category,publisher,number,shelfno) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox6.Text + "','" + textBox5.Text + "')", con);
                com.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Kitab sistemə əlavə edildi.");
                Form1 frm = new Form1();
                this.Hide();
                frm.Show();
            }
            

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int con;
            con = Form1.control;
            if (con == 1)
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            }
            else
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("aze");

            this.Controls.Clear();
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}
