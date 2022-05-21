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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = DESKTOP-U648IRH; Initial Catalog = Library; Integrated Security = True");
        SqlDataReader dr;

        public bool checklend=false;
        public void lendbook()
        {
            checklend = false;
            con.Open();
            //yoxlayiriq bu id-de olan istifadecide kitab varmi
            SqlCommand com2 = new SqlCommand("select *from lendbook where id=('" + textBox1.Text + "')", con);
            dr = com2.ExecuteReader();
            if (dr.Read())
            {
                checklend = true;
                con.Close();
            }
            con.Close();
            if (checklend == true)
            {
                //varsa kitabin id-sini ve qaytarilma tarixini o cedvelden cekirik
                con.Open();
                dr = com2.ExecuteReader();
                while (dr.Read())
                {
                    lendbookid = Int32.Parse(dr[1].ToString());
                    dateTimePicker5.Value = Convert.ToDateTime(dr[3].ToString());
                }
                //hemen id-deki kitabi textbox8-de gosteririk. yuxarida da vaxtini gosterdik
                SqlCommand com = new SqlCommand("select *from Book where id='" + lendbookid + "'", con);
                con.Close();
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    textBox8.Text = dr["title"].ToString();
                }
                con.Close();
            }
            if (checklend == false) textBox8.Text = "Yoxdur"; //kitab goturmeyibse yoxdur yazilir


        }

        public void goruntule()
        {
            bool check = false;
            con.Open();
            //yoxlayiriq ki bu id-de istifadeci varmi
            SqlCommand com = new SqlCommand("select *from student where id=('" + textBox1.Text + "')", con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                check = true;
                con.Close();
            }
            if (check == true)
            {
               //eger varsa melumatlarini gosteririk
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[3].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[6].ToString();
                    textBox6.Text = dr[7].ToString();
                    dateTimePicker2.Value = Convert.ToDateTime((dr[2]).ToString());
                    dateTimePicker1.Value = Convert.ToDateTime((dr[5]).ToString());
                }
                con.Close();
                lendbook();
               
            }
            else MessageBox.Show("Bu ID-də istifadəçi mövcud deyil!"); //yoxdursa bildiris gedir
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goruntule();
            
        }
        public int say,id,lendbookid;
        public string title;
        bool check = false;

        

        

        private void Form5_Load(object sender, EventArgs e)
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

        public void yoxla()
        {
            con.Open();
            SqlCommand com = new SqlCommand("select *from Book where title='" + textBox7.Text + "'", con);
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                check = true;
                
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yoxla(); //yoxlayir ele kitab varmi
            
            if (check == true)
            {
                //varsa sayini yoxlayir,1-den yuxaridisa bazada hemen kitabin sayini azaldir, lendbook cedvelinde ise qeyd edir hansi istifadeciye hansi kitabin hansi tarixler ucun verildiyini
                con.Open();
                SqlCommand com = new SqlCommand("select *from Book where title='" + textBox7.Text + "'", con);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    say = Int32.Parse(dr[5].ToString());
                    id = Int32.Parse(dr[0].ToString());
                    title = dr[1].ToString();
                }
                con.Close();
                if (say > 0)
                {

                    con.Open();
                    SqlCommand comm = new SqlCommand("update Book set number='" + (say - 1) + "'where id=" + id + "", con);
                    comm.ExecuteNonQuery();

                    SqlCommand com2 = new SqlCommand("insert into lendbook(id,book,bordate,retdate)values('" + textBox1.Text + "','" + id + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "')", con);
                    com2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kitab verildi");


                }
                else if (say ==0) MessageBox.Show("Hal-hazırda bu kitab digər istifadəçilərdədir.");// yox eger sayi 0-dirsa bildiris verir
                
                con.Close();
            }
            if (check == false) MessageBox.Show("Sistemdə belə kitab yoxdur.");//o adda kitab tapmirsa bildiris verir
        }
    }
       
    
}
