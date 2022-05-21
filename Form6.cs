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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = DESKTOP-U648IRH; Initial Catalog = Library; Integrated Security = True");
        SqlDataReader dr;

        public bool check = false;
        public void goruntule()
        {
            check = false;
            con.Open();
            SqlCommand com = new SqlCommand("Select *from student where id=('"+textBox1.Text+"')",con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                check = true;
                con.Close();

            }
            if (check == true)
            {
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr[1].ToString();
                }
                con.Close();
                lendbook();
            }
            else MessageBox.Show("Bu ID-də istifadəçi mövcud deyil!");
            con.Close();
        }

        public int bookid;
        public bool checklend = false;
        public void lendbook()
        {
            checklend = false;
            con.Open();
            SqlCommand com = new SqlCommand("select *from lendbook where id=('"+textBox1.Text+"')",con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                checklend = true;
                con.Close();
            }
            if (checklend == true)
            {
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    bookid = Int32.Parse(dr[1].ToString());
                }
                
                con.Close();
                //textBox3.Text = bookid.ToString();

                getbook();

            }
            else
            {
                textBox8.Text = "Yoxdur";
                textBox3.Text = "0";
            }
        }
        public void getbook()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from Book where id=('" + bookid + "')",con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox8.Text = dr[1].ToString();
                textBox3.Text = dr[0].ToString();
                say =Int32.Parse(dr[5].ToString());
            }
            con.Close();

        }
        public int say;
        private void button1_Click(object sender, EventArgs e)
        {
            goruntule();

        }
        public bool checkqaytar=false;

        public void yox()
        {
            if (checklend == true)
            {
                con.Open();
                SqlCommand comm = new SqlCommand("update Book set number='" + (say + 1) + "'where id=" + bookid + "", con);
                comm.ExecuteNonQuery();
                SqlCommand cmmd = new SqlCommand("delete from lendbook where book=('" + bookid + "')", con);
                cmmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Qayarıldı");
            }
            else MessageBox.Show("Qaytarılacaq kitab yoxdur.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            yox();

        }

        

        

        private void Form6_Load(object sender, EventArgs e)
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
