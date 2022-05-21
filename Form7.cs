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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = DESKTOP-U648IRH; Initial Catalog = Library; Integrated Security = True");
        SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("insert into Student(name,birth,school,gender,contact,adress,regdate) values('"+textBox2.Text+"','"+ dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','"+textBox3.Text+"','"+comboBox1.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+ dateTimePicker1.Value.ToString("MM/dd/yyyy") + "')",con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Uğurla əlavə olundu!","",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        

        private void Form7_Load(object sender, EventArgs e)
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
