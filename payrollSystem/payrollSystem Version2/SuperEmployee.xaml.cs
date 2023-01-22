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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class SuperEmployee : Window
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
        Employees currUser = null;
        string rdo;
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
        public SuperEmployee()
        {
            InitializeComponent();
            listEmployees();
            date.Text = DateTime.Now.ToString("dddd, MMM dd yyyy");
            date1.Text = DateTime.Now.ToString("dddd, MMM dd yyyy");
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int index = tabControl.SelectedIndex - 1;
            tabControl.SelectedIndex = index;
            btnSave.IsEnabled = false;
            btnUpdate.IsEnabled = true;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dtgemplist.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure to delete this employee?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM `tbl_employee` WHERE `tbl_employee`.`EID` = @EID";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;
                   
                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();
                        databaseConnection.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    try
                    {
                        string sql = "DELETE FROM `tbl_employee_workinfo` WHERE `tbl_employee_workinfo`.`EID` = @EID";
                    MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase1 = new MySqlCommand(sql, databaseConnection1);
                    commandDatabase1.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                    commandDatabase1.CommandTimeout = 60;
                    MySqlDataReader reader1;
                   
                        databaseConnection1.Open();
                        reader1 = commandDatabase1.ExecuteReader();
                        databaseConnection1.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    transactionDelete();
                    listEmployees();
                    btnNew_Click(sender, e);
                }
                else
                {
                    listEmployees();
                }
            }
            else
            {
                MessageBox.Show("Please select an employee you want to delete!");
            }
        }
        public void transactionDelete() {
            string query2 = "INSERT INTO  `tbl_audit_trail` ( `UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase2.Parameters.AddWithValue("@history", "Deleted the record of employee (" + txtEmployeeId.Text + ") from the database.");
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
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmployeeId.Text == "" || txtFirstName.Text == "" || txtLastname.Text == ""
                    || txtAddress.Text == "" || txtContactnumber.Text == "" || txtPlaceofbirth.Text == "" || txtAge.Text == ""
                    || txtEmergency.Text == "" || txtDailyRate.Text == "" || txtPosition.Text == "" || txtPermanentAdd.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.");
            }
            else
            {
                if (rbMale.IsChecked == true)
                {
                    rdo = "Male";
                }
                else
                {
                    rdo = "Female";
                }
                try
                {
                    String query = "INSERT INTO `tbl_employee` ( `EID`,`FirstName`,`MiddleName`, `LastName`, `Address`, `PermanentAdd`, `Contact`,`MaritalStatus`,`Birthdate`,`Birthplace`,`Sex`,`Age`,`Emergency_Contact`) VALUES (@EID, @firstName, @middleName, @lastName, @address, @permAdd, @contact, @status, @birthdate, @birthplace, @sex, @age, @eContact)";
                
                MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase2 = new MySqlCommand(query, databaseConnection2);
                commandDatabase2.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                commandDatabase2.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                commandDatabase2.Parameters.AddWithValue("@middleName", txtMiddlename.Text);
                commandDatabase2.Parameters.AddWithValue("@lastName", txtLastname.Text);
                commandDatabase2.Parameters.AddWithValue("@address", txtAddress.Text);
                commandDatabase2.Parameters.AddWithValue("@permAdd", txtPermanentAdd.Text);
                commandDatabase2.Parameters.AddWithValue("@contact", txtContactnumber.Text);
                commandDatabase2.Parameters.AddWithValue("@status", cbMaritalStatus.Text);
                commandDatabase2.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(DateOfBirth.Text));
                commandDatabase2.Parameters.AddWithValue("@birthplace", txtPlaceofbirth.Text);
                commandDatabase2.Parameters.AddWithValue("@sex", rdo);
                commandDatabase2.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));
                commandDatabase2.Parameters.AddWithValue("@eContact", txtEmergency.Text);
                commandDatabase2.CommandTimeout = 60;

               
                    databaseConnection2.Open();
                    MySqlDataReader myReader = commandDatabase2.ExecuteReader();

                    //  MessageBox.Show("User succesfully registered!");

                    databaseConnection2.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please check your inputs!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                workinfo();
                transactionAdd();
            }
        }
        public void transactionAdd()
        {
            string query2 = "INSERT INTO  `tbl_audit_trail` ( `UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query2, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase.Parameters.AddWithValue("@history", "Added a new record of employee (" + txtEmployeeId.Text + ") to the database.");
            commandDatabase.Parameters.AddWithValue("@date", DateTime.Now);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void workinfo()
        {
            //employee details
            try
            {
            string query = "INSERT INTO `tbl_employee_workinfo` ( `EID`, `DailyRate`, `Position`, `WorkStatus`, `HiredDate`, `Monthly_salary`)  VALUES (@EID, @dailyRate, @position, @workStatus, @hired, @monthly)";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
            commandDatabase.Parameters.AddWithValue("@dailyRate", Convert.ToDouble(txtDailyRate.Text));
            commandDatabase.Parameters.AddWithValue("@position", txtPosition.Text);
            commandDatabase.Parameters.AddWithValue("@workStatus", cbWorkStatus.Text);
            commandDatabase.Parameters.AddWithValue("@Hired", Convert.ToDateTime(hiredDate.Text));
            commandDatabase.Parameters.AddWithValue("@monthly", Convert.ToDouble(txtDailyRate.Text) * 26);
                commandDatabase.CommandTimeout = 60;
           
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            listEmployees();
            MessageBox.Show("Succesfully registered the employee!");
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmployeeId.Text == "" || txtFirstName.Text == "" || txtLastname.Text == ""
                   || txtAddress.Text == "" || txtContactnumber.Text == "" || txtPlaceofbirth.Text == "" || txtAge.Text == ""
                   || txtEmergency.Text == "" || txtDailyRate.Text == "" || txtPosition.Text == "" || txtPermanentAdd.Text == "")
            {
                MessageBox.Show("One of the box is empty. Data is required.");
            }
            else
            {
                if (rbMale.IsChecked == true)
                {
                    rdo = "Male";
                }
                else
                {
                    rdo = "Female";
                }
                try
                {
                string query = "UPDATE `tbl_employee` SET `EID`= @EID,`FirstName`=@firstName, `MiddleName`= @middleName, `LastName`= @lastName, `Address`= @address, `PermanentAdd`= @permAdd, `Contact` = @contact,`MaritalStatus`=@status, `Birthdate`=@birthdate, `Birthplace`=@birthplace, `Sex`=@sex,`Age`=@age,`Emergency_Contact`= @eContact WHERE EID = @EID";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                commandDatabase.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                commandDatabase.Parameters.AddWithValue("@middleName", txtMiddlename.Text);
                commandDatabase.Parameters.AddWithValue("@lastName", txtLastname.Text);
                commandDatabase.Parameters.AddWithValue("@address", txtAddress.Text);
                commandDatabase.Parameters.AddWithValue("@permAdd", txtPermanentAdd.Text);
                commandDatabase.Parameters.AddWithValue("@contact", txtContactnumber.Text);
                commandDatabase.Parameters.AddWithValue("@status", cbMaritalStatus.Text);
                commandDatabase.Parameters.AddWithValue("@birthdate", Convert.ToDateTime(DateOfBirth.Text));
                commandDatabase.Parameters.AddWithValue("@birthplace", txtPlaceofbirth.Text);
                commandDatabase.Parameters.AddWithValue("@sex", rdo);
                commandDatabase.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));
                commandDatabase.Parameters.AddWithValue("@eContact", txtEmergency.Text);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
               
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                    Updateworkinfo();
                    transactionUpdate();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please check your inputs!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
             
               
            }
        }
        public void transactionUpdate()
        {
            try
            {
                string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase2.Parameters.AddWithValue("@history", "Updated the record of employee (" + txtEmployeeId.Text + ") from the database.");
            commandDatabase2.Parameters.AddWithValue("@date", DateTime.Now);
            commandDatabase2.CommandTimeout = 60;
            MySqlDataReader reader2;
           
                databaseConnection2.Open();
                reader2 = commandDatabase2.ExecuteReader();
                databaseConnection2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Updateworkinfo()
        {
            //employee details
            try
            {
            string query = "UPDATE `tbl_employee_workinfo` SET `EID`= @EID,`DailyRate`=@payRate, `Position`= @position, `WorkStatus`= @workStatus, `HiredDate` = @hired, `Monthly_salary` = @monthly WHERE EID = @EID";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
            commandDatabase.Parameters.AddWithValue("@payRate", Convert.ToDouble(txtDailyRate.Text));
            commandDatabase.Parameters.AddWithValue("@position", txtPosition.Text);
            commandDatabase.Parameters.AddWithValue("@workStatus", cbWorkStatus.Text);
            commandDatabase.Parameters.AddWithValue("@Hired", Convert.ToDateTime(hiredDate.Text));
            commandDatabase.Parameters.AddWithValue("@monthly", Convert.ToDouble(txtDailyRate.Text) * 26);
                commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Successfully Updated!");
                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please check your inputs!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            listEmployees();
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = "";
            txtAge.Text = "";
            txtContactnumber.Text = "";
            txtDailyRate.Text = "";
            txtEmergency.Text = "";
            txtEmployeeId.Text = "";
            txtFirstName.Text = "";
            txtLastname.Text = "";
            txtMiddlename.Text = "";
            txtPlaceofbirth.Text = "";
            txtPosition.Text = "";
            DateOfBirth.Text = "";
            hiredDate.Text = "";
            txtPermanentAdd.Text = "";
            cbMaritalStatus.SelectedIndex = 1;
            cbWorkStatus.SelectedIndex = 0;
            rbMale.IsChecked = true;
            btnSave.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            txtEmployeeId.Clear();

            listEmployees();
        }

        private void dtgemplist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgemplist.SelectedIndex > -1)
            {
                currUser = (Employees)dtgemplist.SelectedItem;
                btnEdit.IsEnabled = true;
                BtnDelete.IsEnabled = true;
                txtEmployeeId.Text = currUser.EmployeeID.ToString();
                string query1 = "SELECT * FROM `tbl_employee` WHERE EID = @EID";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                commandDatabase1.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
                commandDatabase1.CommandTimeout = 60;
                MySqlDataReader reader1;
                try
                {
                    databaseConnection1.Open();
                    reader1 = commandDatabase1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            txtLastname.Text = reader1.GetString(3);
                            txtFirstName.Text = reader1.GetString(1);
                            txtMiddlename.Text = reader1.GetString(2);
                            txtEmergency.Text = reader1.GetString(12);
                            DateOfBirth.Text = reader1.GetString(8);
                            txtPlaceofbirth.Text = reader1.GetString(9);
                            txtPermanentAdd.Text = reader1.GetString(5);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    databaseConnection1.Close();
                }
                catch (Exception)
                {

                }

                txtAddress.Text = currUser.Address;
                txtAge.Text = currUser.Age.ToString();
                txtContactnumber.Text = currUser.Contact;
                cbMaritalStatus.Text = currUser.Status;
                if (currUser.Gender == "Male")
                {
                    rbMale.IsChecked = true;
                }
                else
                {
                    rbFemale.IsChecked = true;
                }
                string query = "SELECT * FROM `tbl_employee_workinfo` WHERE EID = @EID";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId.Text);
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
                            txtDailyRate.Text = reader.GetString(2);
                            txtPosition.Text = reader.GetString(3);
                            cbWorkStatus.Text = reader.GetString(4);
                            hiredDate.Text = reader.GetString(5);
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
                }
                currUser = null;
                btnEdit.IsEnabled = true;
                BtnDelete.IsEnabled = true;
            }
            else
            {
                currUser = null;
                btnEdit.IsEnabled = true;
                BtnDelete.IsEnabled = true;
            }
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
                // Success, now list 
                // If there are available rows
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

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedResult();
            if (txtSearch.Text == "")
            {
                listEmployees();
            }
        }

        private void btnHome_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            SuperAdmin home = new SuperAdmin();
            home.ShowDialog();
        }
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WHO ARE WE? \n\n\tWith a team of dedicated IT students of Pamantasan ng Lungsod ng Valenzuela, TvCon Payroll System was created on December 3, 2019. TvCon Payroll System was designed to meet the company's specific needs. The Payroll System take away the hassle of creating payroll and managing employee records. It allows the user to experience stress-free managing and monitoring of records.Our leadership team is dedicated to create a system that is easy to use, efficient and helpful.", "ABOUT US", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nCONTACT US \n\nGet in touch with us. We gladly welcome your inquiries and feedback. Please feel free to contact us at our email (Tvcon09@gmail.com) and contact number(09771865983). \n\nHAVE A GOOD DAY!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nHELP \nYou can add, delete or update the employee's record with the given fields and button below. \n\nHow can I add employee? \nYou'll need to input the necessary informations specifically the personal and working information of the employee's. \n\nHow can I edit the employee's record?? \nYou can Edit or update employee details by clicking the row of employee information that you want to edit on the list then click edit.\n\nWhere can I find the Employee list?\nYou can see the employee list on the next tab, just click the tab named employee list. just select the employee details then click edit. After editting the details you can now click update button to save the changes you've made.\n\nHow can I delete employee record/s? \nYou can delete employee/s by clicking the employee on the list and Clicking the delete button after.\n\nWhat is the purpose of new button? \nThe sole purpose of the new button is just to clear all the fields at once. \n\nHopefully this information was helpful to you. \n\nHave a good day!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }
      
        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            pmCalendar calendar = new pmCalendar();
            calendar.Show();
        }
    }
        } 

       
