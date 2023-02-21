using System;
using System.Windows.Forms;

namespace AutoRego
{
    public partial class BD : Form
    {
        public BD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autoriz Win = new Autoriz();
            Win.Show();
            this.Close();
        }
    }
}
