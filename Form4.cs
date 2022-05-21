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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = DESKTOP-U648IRH; Initial Catalog = Library; Integrated Security = True");


        public void listigoster()
        {
            listView1.Items.Clear();
            con.Open();
            SqlCommand com = new SqlCommand("Select *from Book", con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem elave = new ListViewItem();
                elave.Text = dr["id"].ToString();
                elave.SubItems.Add(dr["title"].ToString());
                elave.SubItems.Add(dr["author"].ToString());
                elave.SubItems.Add(dr["category"].ToString());
                elave.SubItems.Add(dr["publisher"].ToString());
                elave.SubItems.Add(dr["number"].ToString());
                elave.SubItems.Add(dr["shelfno"].ToString());

                listView1.Items.Add(elave);
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            listigoster();
        }

        

        

        private void Form4_Load(object sender, EventArgs e)
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
