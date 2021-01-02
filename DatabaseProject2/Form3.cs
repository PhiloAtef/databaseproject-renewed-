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
    public partial class Form3 : Form
    {
        public static string currentUsername;
        public static string connectionString = "Data Source=.;Initial Catalog=database;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        SqlDataAdapter adapter;
        DataTable dataTable;
        public Form3()
        {
            InitializeComponent();
            showdata();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            currentUsername = Form1.currentUsername;
        }

        public void showdata()
        {
            adapter = new SqlDataAdapter("SELECT * FROM VideoGame", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Cells[1].Value.ToString().Split(',').ToList().ForEach(r => listBox1.Items.Add(r.Trim()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
