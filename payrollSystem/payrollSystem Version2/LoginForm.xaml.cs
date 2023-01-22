using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace payrollSystem_Version2
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        string password1;
        
        public LoginForm()
        {
            InitializeComponent();
            string plainData = "Mahesh";
            Console.WriteLine("Raw data: {0}", plainData);
            string hashedData = ComputeSha256Hash(plainData);
            Console.WriteLine("Hash {0}", hashedData);
            Console.WriteLine(ComputeSha256Hash("Mahesh"));
            Console.ReadLine();
            passwordtextbox.Visibility = System.Windows.Visibility.Hidden;

        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public void login()
        {
            const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            if (txtUsername.Text == "" && password.Password == "")
            {
                MessageBox.Show("Insert Username and Password!!");
            }
            else
            {
                try
                {
                    String hashedData = ComputeSha256Hash(password.Password);
                    MySqlCommand commandDatabase = new MySqlCommand("SELECT * from tbl_users WHERE Username = '" + txtUsername.Text + "' AND Pass = '" + (hashedData) + "' AND Type = '" + cbUserType.Text + "' ", databaseConnection);
                    MySqlDataReader reader;
                    reader = commandDatabase.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1 && cbUserType.Text == "SUPER ADMIN")
                    {
                        transactionAdd();
                        MessageBox.Show("SUCCESSFULLY LOGIN!");
                        SuperAdmin load = new SuperAdmin();
                        load.Show();
                        this.Close();
                    }
                    else if (count == 1 && cbUserType.Text == "ADMINISTRATOR")
                    {
                        transactionAdd();
                        MessageBox.Show("SUCCESSFULLY LOGIN!");
                        AdminPage load = new AdminPage();
                        load.Show();
                        this.Close();
                    }
                    else if
                        (count == 1 && cbUserType.Text == "HUMAN RESOURCE")
                    {
                        transactionAdd();
                        MessageBox.Show("SUCCESSFULLY LOGIN!");
                        HumanResource load = new HumanResource();
                        load.Show();
                        this.Close();
                    }
                    else if
                       (count == 1 && cbUserType.Text == "PAYROLL MASTER")
                    {
                        transactionAdd();
                        MessageBox.Show("SUCCESSFULLY LOGIN!");
                        PayrollMaster load = new PayrollMaster();
                        load.Show();
                        this.Close();
                    }
                    else if (count > 0)
                    {
                        MessageBox.Show("Duplicate Username and Password");
                    }
                    else
                    {
                        MessageBox.Show("Username, password and User type did not match!");
                    }
                   
                    txtUsername.Text = "";
                    password.Password = "";
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void transactionAdd()
        {
            const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
            string query2 = "INSERT INTO `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", cbUserType.Text);
            commandDatabase2.Parameters.AddWithValue("@history", "Login the system. ("+cbUserType.Text+": "+ txtUsername.Text +")");
            commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
            commandDatabase2.CommandTimeout = 60;
            MySqlDataReader reader2;
            try
            {
                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void mouseentercover(object sender, MouseEventArgs e)
        {
            password.Visibility = Visibility.Hidden;
            passwordtextbox.Visibility = Visibility.Visible;
            password1 = password.Password;
            passwordtextbox.Text = password1;
        }

        private void mouseleaving(object sender, MouseEventArgs e)
        {
            password.Visibility = System.Windows.Visibility.Visible;
            passwordtextbox.Visibility = System.Windows.Visibility.Hidden;
           
        }

        private void passwordtextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (password.Password != "" && txtUsername.Text != "" && e.Key == Key.Enter)
            {
                login();
            }
        }
    }
    }

