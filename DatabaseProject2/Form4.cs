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

namespace DatabaseProject2
{
    public partial class Vendor : Form
    {
        public Vendor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=.;Initial Catalog=database;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand($"insert into Vendor(Vendor_Name,VendorID)" +
                    "values('" + textBox1.Text + "'," + int.Parse(textBox2.Text) + ")", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Done!");
                this.Close();
                Form5 form = new Form5();
                form.Show();
            } catch(SqlException)
            {
                MessageBox.Show("Vendor name is already taken :(");
            }
            catch (Exception)
            {
                MessageBox.Show("enter a numerical value in ID and check Vendor Name");
            }

        }
    }
}
