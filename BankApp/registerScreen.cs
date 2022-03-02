using Amazon.Runtime.CredentialManagement;
using System;
using System.Windows.Forms;

namespace BankApp
{
    public partial class registerScreen : Form
    {
        public registerScreen()
        {
            InitializeComponent();

            var creds = System.IO.File.ReadAllLines("C:\\Users\\jackd\\Documents\\creds.txt"); // insert local file with creds here.
            string credID = creds[0];
            string secretID = creds[1];
            WriteProfile("user", credID, secretID);
        }

        void WriteProfile(string profileName, string keyId, string secret)
        {
            var options = new CredentialProfileOptions
            {
                AccessKey = keyId,
                SecretKey = secret
            };
            var profile = new CredentialProfile(profileName, options);
            var netSdkStore = new NetSDKCredentialsFile();
            netSdkStore.RegisterProfile(profile);
        }



        private void alreadyUserBtn_Click(object sender, EventArgs e)
        {
            new loginScreen().Show();
            this.Hide();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (mainSplash.user.checkIfUserExists(usernameTextBox.Text))
            {
                MessageBox.Show("Account with that username already exists!");
                return;
            }

            mainSplash.user.registerUser(usernameTextBox.Text, passwordTextBox.Text);

            new mainSplash().Show();
            this.Hide();

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
