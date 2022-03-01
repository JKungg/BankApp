using System.Windows.Forms;

namespace BankApp
{
    public partial class loginScreen : Form
    {
        public loginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {


            if (mainSplash.user.isValidUser(textBox1.Text, textBox2.Text))
            {
                new mainSplash().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error with Username and Password!");
            }
        }

        private void exitBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
