using Konscious.Security.Cryptography;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoneyMountain
{
    public partial class LoginForm : Form
    {
        private const string connectionString = "server=localhost;database=userdb;uid=root;password='';";
        private bool error = false;

        public LoginForm()
        {
            InitializeComponent();
            btnNext.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required!", "Account Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error = true;
                return;
            }

            else
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    const string query = "SELECT password FROM users WHERE username = @username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            //ToString() will only be called if the value of result is not null. This is to prevent a NullReferenceException from being thrown
                            string hashedPassword = result.ToString();

                            //Verifying the password using argon2
                            var argon2 = new Argon2d(Encoding.UTF8.GetBytes(password))
                            {
                                Salt = Encoding.UTF8.GetBytes(username), //Using username as salt
                                DegreeOfParallelism = 8,
                                Iterations = 4,
                                MemorySize = 1024 * 1024 //1 GB
                            };

                            if (Convert.ToBase64String(argon2.GetBytes(32)) != hashedPassword)
                            {
                                MessageBox.Show("The password you entered is incorrect!", "Account Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                error = true;
                                return;
                            }
                        }

                        else
                        {
                            MessageBox.Show("User Not Found!", "Account Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            error = true;
                            return;
                        }
                    }

                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"MySQL Error: {ex.Message}", "MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ex.StackTrace.ToString();
                        error = true;
                        return;
                    }

                    finally
                    {
                        if (!error)
                        {
                            MessageBox.Show("Login Successful", "Account Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            error = false;
                            connection.Close();
                            btnNext.Visible = true;
                        }
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            Regex regex = new Regex(emailPattern);
            Regex passwordRegex = new Regex(passwordPattern);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required!", "Account Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error = true;
                return;
            }

            else if (username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long!", "Account Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error = true;
                return;
            }

            else if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Invalid Email!", "Account Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error = true;
                return;
            }

            else if (!Regex.IsMatch(password, passwordPattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Password must contain at least 8 characters, including at least one uppercase letter, one lowercase letter, one digit, and one special character!", "Account Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                error = true;
                return;
            }

            else
            {
                //Using argon2 to hash the password
                var argon2 = new Argon2d(Encoding.UTF8.GetBytes(password))
                {
                    Salt = Encoding.UTF8.GetBytes(username), //Using username as salt
                    DegreeOfParallelism = 8,
                    Iterations = 4,
                    MemorySize = 1024 * 1024 //1 GB
                };

                string hashedPassword = Convert.ToBase64String(argon2.GetBytes(32));
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    const string query = "INSERT INTO users (username, email, password) VALUES (@username, @email, @password);";
                    MySqlCommand command = new MySqlCommand(query, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected <= 0)
                        {
                            MessageBox.Show("Registration Failed!", "Account Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = true;
                            return;
                        }
                    }

                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"MySQL Error: {ex.Message}", "MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ex.StackTrace.ToString();
                        error = true;
                        return;
                    }

                    finally
                    {
                        if (!error)
                        {
                            MessageBox.Show("Registration Successful!", "Account Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            error = false;
                            connection.Close();
                            btnNext.Visible = true;
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FundTransferForm fundTransferForm = new FundTransferForm();
            Close();
            fundTransferForm.Show();
        }
    }
}