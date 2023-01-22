using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AdminEmployee.xaml
    /// </summary>
    public partial class AdminEmployee : Window
    {

        public class Employees
        {
            public String EmployeeID { get; set; }
            public String Name { get; set; }
            public Int32 Age { get; set; }
            public String Gender { get; set; }
            public String Status { get; set; }
            public String Address { get; set; }
            public String Contact { get; set; }
        }

        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";

        private void listEmployees()
        {
            dtgemplist.Items.Clear();

            string query = "SELECT * FROM `tbl_employee`";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // Success, now list 
                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Employees _tmpEmp = new Employees { EmployeeID = reader.GetString(0), Name = reader.GetString(3) + ", " + reader.GetString(1) + " " + reader.GetString(2), Age = reader.GetInt32(11), Gender = reader.GetString(10), Status = reader.GetString(7), Address = reader.GetString(4), Contact = reader.GetString(6) };
                        dtgemplist.Items.Add(_tmpEmp);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public AdminEmployee()
        {
            InitializeComponent();
            listEmployees();
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
        }

        public void searchedResult()
        {
            dtgemplist.Items.Clear();

            string query = "SELECT * FROM `tbl_employee` WHERE `EID` LIKE '" + txtSearch.Text + "%'" + " OR `LastName` LIKE '" + txtSearch.Text + "%'" + " OR `FirstName` LIKE '" + txtSearch.Text + "%'" + " OR `Sex` LIKE '" + txtSearch.Text + "%'" + " OR `Address` LIKE '" + txtSearch.Text + "%'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Employees _tmpUser = new Employees { EmployeeID = reader.GetString(0), Name = reader.GetString(3) + ", " + reader.GetString(1) + " " + reader.GetString(2), Age = reader.GetInt32(11), Gender = reader.GetString(10), Status = reader.GetString(7), Address = reader.GetString(4), Contact = reader.GetString(6) };
                        dtgemplist.Items.Add(_tmpUser);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            AdminPage admin = new AdminPage();
            admin.Show();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedResult();
            if (txtSearch.Text == "")
            {
                listEmployees();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELP \nWhat can I do? \nYou can search the employee details with the search field. However, you can only view the details of the employees you cannot edit or delete it. For other queries please contact us. \n\nHopefully this is helpful for you! \n\nHAVE A GOOD DAY!!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WHO ARE WE? \n\n\tWith a team of dedicated IT students of Pamantasan ng Lungsod ng Valenzuela, TvCon Payroll System was created on December 3, 2019. TvCon Payroll System was designed to meet the company's specific needs. The Payroll System take away the hassle of creating payroll and managing employee records. It allows the user to experience stress-free managing and monitoring of records.Our leadership team is dedicated to create a system that is easy to use, efficient and helpful.", "ABOUT US", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nCONTACT US \n\nGet in touch with us. We gladly welcome your inquiries and feedback. Please feel free to contact us at our email (Tvcon09@gmail.com) and contact number(09771865983). \n\nHAVE A GOOD DAY!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }
    }
    }

