using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject2
{
    public partial class Form1 : Form
    {
        public static string currentUsername;

        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           if(checkBox1.Checked)
            {
                Vendor form = new Vendor();
                form.Show();
            }
            else
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=.;Initial Catalog=database;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                if (checkBox1.Checked)
                {

                    int id = int.Parse(password.Text);

                    SqlCommand smd = new SqlCommand("select * from Vendor where Vendor_Name= '" + username.Text + "' and VendorID = '" + id + "';", connection);
                    connection.Open();
                    SqlDataReader R = smd.ExecuteReader();
                    if (R.Read())
                    {
                        ///////////////////////////////////////////////////////////
                        currentUsername = username.Text;
                        Form5 form = new Form5();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("please enter valid vendor name and ID");
                    }
                }
                else
                {
                    int p = int.Parse(password.Text);

                    SqlCommand cmd = new SqlCommand("select * from customer where cust_username= '" + username.Text + "' and cust_password = '" + p + "';", connection);
                    connection.Open();
                    SqlDataReader d = cmd.ExecuteReader();
                    if (d.Read())
                    {

                        currentUsername = username.Text;
                        Form3 form3 = new Form3();
                        form3.Show();
                    }
                    else
                    {
                        MessageBox.Show("please enter valid username and password");
                    }
                }
            }
           
            catch (Exception)
            {
                MessageBox.Show("check your data");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Text = "Vendor name";
                label2.Text = "Vendor ID";             
            }
            else
            {
                
                label1.Text = "Username";
                label2.Text = "Password";
            }
        }
        

    }
}