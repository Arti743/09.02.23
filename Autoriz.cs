using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoRego
{
    public partial class Autoriz : Form
    {
        public Autoriz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=PC_203_7; Initial Catalog=AutoRego; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            bool success = false;
            try
            {
                const string comand = "SELECT * FROM auth WHERE auth_log=@auth_log AND auth_pwd=@auth_pwd";
                SqlCommand check = new SqlCommand(comand, conn);
                check.Parameters.AddWithValue("@auth_log", textBox1.Text);
                check.Parameters.AddWithValue("@auth_pwd", textBox2.Text);
                conn.Open();

                using (var dataReader = check.ExecuteReader())
                {
                    success = dataReader.Read();
                }
            }
            finally
            {
                conn.Close();
            }
            if (success)
            {
                BD Win = new BD();
                Win.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Registr Win = new Registr();
            Win.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
            }else
            {
                textBox2.PasswordChar = '*';
            }
       
        }

        private void Autoriz_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обратитесь к администратору сервера на почту: qwerty@mail.ru", "Забыли проль?");
        }
    }
}
