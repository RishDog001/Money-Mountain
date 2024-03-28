using System;
using PayPal.Api;
using System.Windows.Forms;
using PayPal;

namespace MoneyMountain
{
    public partial class FundTransferForm : Form
    {
        private string userName;
        private string password;
        private string accountNumber;
        private bool error = false;
        private const string PayPalClientID = "AZoRcaDiFYjR6dilw13mpUEsGLz1wXWCwzXEhzAlsInoSOMZYz45mAh_Nzan7yHfbm9SmDi0IfvvFYch";
        private const string PayPalClientSecret = "EGYym4AC3prWP8_6gXVt2jwz0JhWwfagQmxJowZGRnRgM0S8kpJoyhyM7k8P5Aai9SCj6DalyoNDpM2f";

        public FundTransferForm()
        {
            InitializeComponent();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                accountNumber = txtAccountNumber.Text.Trim();
                userName = txtUserName.Text.Trim();
                password = txtPassword.Text.Trim();

                if (!int.TryParse(accountNumber, out int accountNum) || accountNum.ToString().Length < 3)
                {
                    MessageBox.Show("Account number must be a valid number that contains at least 3 digits!", "Transfer Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    error = true;
                    return;
                }

                else if (!int.TryParse(txtTransferAmount.Text, out int transferAmount) || transferAmount <= 0)
                {
                    MessageBox.Show("Transfer amount must be a valid number greater than 0!", "Transfer Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    error = true;
                    return;
                }

                else
                {
                    try
                    {
                        APIContext apiContext = new APIContext(new OAuthTokenCredential(PayPalClientID, PayPalClientSecret).GetAccessToken());
                    }

                    catch (PayPalException ex)
                    {
                        MessageBox.Show($"PayPal Error: {ex.Message}", "PayPal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                        return;
                    }

                    finally
                    {
                        if (!error)
                        {
                            MessageBox.Show("Transaction Successful!", "Transfer Funds", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Dispose();
                            Application.Exit();
                        }
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            accountNumber = txtAccountNumber.Text.Trim();
            userName = txtUserName.Text.Trim();
            password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(accountNumber) || string.IsNullOrWhiteSpace(txtTransferAmount.Text) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("All fields are required!", "Transfer Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (!password.Equals(txtConfirmPassword.Text))
            {
                MessageBox.Show("Passwords do not match!", "Transfer Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}