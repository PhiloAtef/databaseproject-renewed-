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
    public partial class Form5 : Form
        
    {
        public string currentUsername = Form1.currentUsername;
        public static string connectionString = "Data Source=.;Initial Catalog=database;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        int gameId;
        public Form5()
        {
            InitializeComponent();
            showdata();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
          

        }
        public void showdata()
        {
           SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM VideoGame where VendorName = '" + currentUsername + "'" , connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cnt = new SqlCommand("SELECT COUNT(*)FROM VideoGame;", connection);
                connection.Open();
                int count = (int)cnt.ExecuteScalar() + 1;
                connection.Close();

                SqlCommand cmd = new SqlCommand("insert into VideoGame ( GameId, GameName, Quantity,GamePrice, VendorName) values(" +
                count + ",'" + textBox1.Text + "'," + int.Parse(textBox2.Text) + "," + int.Parse(textBox3.Text) + ",'" + currentUsername + "')", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("done!");
                showdata();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("check your data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand c = new SqlCommand("delete from VideoGame where GameID = " + gameId, connection);
                connection.Open();
                c.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("done!");
                showdata();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }catch(Exception)
            {
                //MessageBox.Show("Something went wrong:(");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("update VideoGame " +
                    "set GameName = '" + textBox1.Text + "' , Quantity = '" + int.Parse(textBox2.Text) + "' , GamePrice =" + int.Parse(textBox3.Text) +
                    "where GameID =" + gameId , connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("done!");
                showdata();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }catch(Exception)
            {
                MessageBox.Show("something went wrong!");
            }
           
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gameId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("invaled row");
            }
        }
    }
}
