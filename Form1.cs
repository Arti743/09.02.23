using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoRego
{
    public partial class Registr : Form
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Autoriz Win = new Autoriz();
            Win.Show();
            this.Hide();
              
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionStrig = @"Data Source=PC_203_7; Initial Catalog=AutoRego; Integrated Security=true";
            SqlConnection conn = new SqlConnection(connectionStrig);
            try
            {
                    SqlCommand comand = new SqlCommand("INSERT INTO auth VALUES (@auth_log, @auth_pwd, @auth_role)", conn);
                    comand.Parameters.AddWithValue("@auth_log", textBox1.Text);
                    comand.Parameters.AddWithValue("@auth_pwd", textBox2.Text);
                    comand.Parameters.AddWithValue("@auth_role", textBox3.Text);
                    conn.Open();
                    comand.ExecuteNonQuery();
            }
            finally
            {
                MessageBox.Show("Регистрация прошла успешно!");

                Autoriz Win = new Autoriz();
                Win.Show();
                this.Hide();

                conn.Close();
            }
        }
    }
}