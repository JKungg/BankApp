using System;
using System.Windows.Forms;

namespace BankApp
{
    public partial class depositSplash : Form
    {
        string balance = mainSplash.user.getUserBalance(mainSplash.user.username);
        string username = mainSplash.user.username;
        public depositSplash()
        {
            InitializeComponent();
        }

        private void confirmDepositBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double currentBal = double.Parse(balance);

                double depositAmt = double.Parse(depositTextBox.Text);

                double newBal = currentBal + depositAmt;
                balance = newBal.ToString();


                // Need to make function to update balance to DynamoDB
                mainSplash.user.updateBalance(username, newBal.ToString(), currentBal.ToString());
                balanceLabel.Text = balance;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void depositSplash_Load(object sender, EventArgs e)
        {
            balanceLabel.Text = balance;

            helloLabel.Text = "Hello, " + username.ToUpper();
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new mainSplash().Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            new loginScreen().Show();
            this.Hide();
        }
    }
}
