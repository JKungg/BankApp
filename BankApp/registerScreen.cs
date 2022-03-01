using System;
using System.Windows.Forms;

namespace BankApp
{
    public partial class registerScreen : Form
    {
        public registerScreen()
        {
            InitializeComponent();
        }

        private void alreadyUserBtn_Click(object sender, EventArgs e)
        {
            new loginScreen().Show();
            this.Hide();
            //
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {

            mainSplash.user.registerUser(usernameTextBox.Text, passwordTextBox.Text);

            new mainSplash().Show();
            this.Hide();

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
