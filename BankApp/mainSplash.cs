using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankApp
{
    public partial class mainSplash : Form
    {
        public static User user = new User();

        public mainSplash()
        {
            InitializeComponent();

        }

        private void resetButtonFont()
        {
            accountBtn.Font = new Font("Bahnschrift", accountBtn.Font.Size);
            depositBtn.Font = new Font("Bahnschrift", depositBtn.Font.Size);
            withdrawBtn.Font = new Font("Bahnschrift", withdrawBtn.Font.Size);
            transferBtn.Font = new Font("Bahnschrift", transferBtn.Font.Size);
            settingsBtn.Font = new Font("Bahnschrift", settingsBtn.Font.Size);
        }

        private void mainSplash_Load(object sender, EventArgs e)
        {

            balanceLabel.Text = user.balance;

            helloLabel.Text = "Hello, " + user.username.ToUpper();
        }

        //Deposit Button Dashboard Click
        private void button2_Click(object sender, EventArgs e)
        {
            new depositSplash().Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Confirm Deposit Button
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double currentBal = double.Parse(user.balance);

        //        double depositAmt = double.Parse(depositTextBox.Text);

        //        double newBal = currentBal + depositAmt;
        //        user.balance = newBal.ToString();


        //        // Need to make function to update balance to DynamoDB
        //        user.updateBalance(user.username, newBal.ToString(), currentBal.ToString());
        //        balanceLabel.Text = user.balance;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        //Withdraw button dashboard click
        private void withdrawBtn_Click(object sender, EventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            new loginScreen().Show();
            this.Hide();
        }

        private void withdrawBtn_Click_1(object sender, EventArgs e)
        {
            resetButtonFont();
            withdrawBtn.Font = new Font("Bahnschrift SemiBold", depositBtn.Font.Size);

        }
    }
}
