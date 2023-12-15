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

namespace sql_connection_uyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            int age = Convert.ToInt32(textBox3.Text);
            int schoolNumber = Convert.ToInt32(textBox4.Text);

            string connectionString = "Data Source=your_server_name;Initial Catalog=your_database_name;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (FirstName, LastName, Age, SchoolNumber) VALUES (@FirstName, @LastName, @Age, @SchoolNumber)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@SchoolNumber", schoolNumber);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kullanıcı başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.");
                    }
                }
            }
        }
    }
}
