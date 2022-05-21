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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = DESKTOP-U648IRH; Initial Catalog = Library; Integrated Security = True");
        SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = false;
            bool sure = false;
            
            con.Open();
            SqlCommand com = new SqlCommand("select *from Book where title=('" + textBox1.Text.ToString() + "')",con);
            
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                check = true;
                con.Close();
                DialogResult dialog = MessageBox.Show("Əminsiniz?", "Kitabı sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    sure = true;
                }
            }
            if (check == true && sure==true)
            {
                con.Open();
                com.CommandText = "delete  from Book where title = ('" + textBox1.Text.ToString() + "')";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kitab sistemdən silindi");

            }
            if (check == false) MessageBox.Show("Belə kitab yoxdur!");
            con.Close();
            
        }

        

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
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
    }
}
