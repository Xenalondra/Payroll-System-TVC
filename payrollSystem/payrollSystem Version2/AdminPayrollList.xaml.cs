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
    /// Interaction logic for AdminPayrollList.xaml
    /// </summary>
    public partial class AdminPayrollList : Window
    {
        public class Pays
        {
            public string EID { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
            public double DailyRate { get; set; }
            public double Num_days { get; set; }
            public double RateWage { get; set; }
            public double OThours { get; set; }
            public double Overtime { get; set; }
            public double NightDifferential { get; set; }
            public double HollPay { get; set; }
            public double Basic_Pay { get; set; }
            public double Cash_ad { get; set; }
            public double Philhealth { get; set; }
            public double WithholdingTax { get; set; }
            public double Pagibig { get; set; }
            public double SSS { get; set; }
            public string OtherDeduc { get; set; }
            public double Amount { get; set; }
            public double Total_Deduc { get; set; }
            public double Net_income { get; set; }
            public DateTime PayDay { get; set; }
        }
        const string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_payroll_system;";
      
        private void listPayroll()
        {
            lvPayroll.Items.Clear();

            string query = "SELECT `tbl_employee`.`EID`, `tbl_employee`.`FirstName`, `tbl_employee`.`MiddleName`,`tbl_employee`.`LastName`, `tbl_employee_workinfo`.`Position`, `tbl_employee_workinfo`.`DailyRate`, `tbl_payroll`.`Num_days`, `tbl_payroll`.`RateWage`, `tbl_payroll`.`OThours`, `tbl_payroll`.`Overtime`, `tbl_payroll`.`NightDifferential`, `tbl_payroll`.`HollPay`, `tbl_payroll`.`Basic_Pay`, `tbl_payroll`.`Cash_ad`, `tbl_payroll`.`Philhealth`, `tbl_payroll`.`WithholdingTax`, `tbl_payroll`.`Pagibig`, `tbl_payroll`.`SSS`, `tbl_other_deduction`.`Deduc1`, `tbl_other_deduction`.`Deduc_amt1`, `tbl_other_deduction`.`Deduc2`, `tbl_other_deduction`.`Deduc_amt2`, `tbl_other_deduction`.`Deduc3`, `tbl_other_deduction`.`Deduc_amt3`, `tbl_other_deduction`.`Total_Deduc`, `tbl_payroll`.`Net_income`, `tbl_payroll`.`PayDay`FROM `tbl_employee` LEFT JOIN `tbl_employee_workinfo` ON `tbl_employee_workinfo`.`EID` = `tbl_employee`.`EID` LEFT JOIN `tbl_payroll` ON `tbl_payroll`.`EID` = `tbl_employee`.`EID` LEFT JOIN `tbl_other_deduction` ON `tbl_other_deduction`.`EID` = `tbl_employee`.`EID`";
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

                        Pays _tmpPayroll = new Pays
                        {
                            EID = reader.GetString(0),
                            Name = reader.GetString(3) + ", " + reader.GetString(1) + " " + reader.GetString(2),
                            Position = reader.GetString(4),
                            DailyRate = reader.GetDouble(5),
                            Num_days = reader.GetDouble(6),
                            RateWage = reader.GetDouble(7),
                            OThours = reader.GetDouble(8),
                            Overtime = reader.GetDouble(9),
                            NightDifferential = reader.GetDouble(10),
                            HollPay = reader.GetDouble(11),
                            Basic_Pay = reader.GetDouble(12),
                            Cash_ad = reader.GetDouble(13),
                            Philhealth = reader.GetDouble(14),
                            WithholdingTax = reader.GetDouble(15),
                            Pagibig = reader.GetDouble(16),
                            SSS = reader.GetDouble(17),
                            OtherDeduc = reader.GetString(18) + " " + reader.GetString(20) + " " + reader.GetString(22),
                            Amount = reader.GetDouble(19) + reader.GetDouble(21) + reader.GetDouble(23),
                            Total_Deduc = reader.GetDouble(24),
                            Net_income = reader.GetDouble(25),
                            PayDay = reader.GetDateTime(26),
                        };
                        lvPayroll.Items.Add(_tmpPayroll);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception )
            {
            }
        }
        public AdminPayrollList()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            listPayroll();
        }

        private void btnHome_Click_1(object sender, RoutedEventArgs e)
        {
            AdminPage load = new AdminPage();
            load.Show();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedPay();
            if (txtSearch.Text == "")
            {
                listPayroll();
            }
        }
        public void searchedPay()
        {
            lvPayroll.Items.Clear();
            string query = "SELECT `tbl_employee`.`EID`, `tbl_employee`.`FirstName`, `tbl_employee`.`MiddleName`,`tbl_employee`.`LastName`, `tbl_employee_workinfo`.`Position`, `tbl_employee_workinfo`.`DailyRate`, `tbl_payroll`.`Num_days`, `tbl_payroll`.`RateWage`, `tbl_payroll`.`OThours`, `tbl_payroll`.`Overtime`, `tbl_payroll`.`NightDifferential`, `tbl_payroll`.`HollPay`, `tbl_payroll`.`Basic_Pay`, `tbl_payroll`.`Cash_ad`, `tbl_payroll`.`Philhealth`, `tbl_payroll`.`WithholdingTax`, `tbl_payroll`.`Pagibig`, `tbl_payroll`.`SSS`, `tbl_other_deduction`.`Deduc1`, `tbl_other_deduction`.`Deduc_amt1`, `tbl_other_deduction`.`Deduc2`, `tbl_other_deduction`.`Deduc_amt2`, `tbl_other_deduction`.`Deduc3`, `tbl_other_deduction`.`Deduc_amt3`, `tbl_other_deduction`.`Total_Deduc`, `tbl_payroll`.`Net_income`, `tbl_payroll`.`PayDay` FROM `tbl_employee` LEFT JOIN `tbl_employee_workinfo` ON `tbl_employee_workinfo`.`EID` = `tbl_employee`.`EID` LEFT JOIN `tbl_payroll` ON `tbl_payroll`.`EID` = `tbl_employee`.`EID` LEFT JOIN `tbl_other_deduction` ON `tbl_other_deduction`.`EID` = `tbl_employee`.`EID` WHERE `tbl_employee`.`EID` LIKE '" + txtSearch.Text + "%'" + " OR `tbl_employee`.`LastName` LIKE '" + txtSearch.Text + "%'" + " OR  `tbl_employee_workinfo`.`Position` LIKE '" + txtSearch.Text + "%'";
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

                        Pays _tmpPayroll = new Pays
                        {
                            EID = reader.GetString(0),
                            Name = reader.GetString(3) + ", " + reader.GetString(1) + " " + reader.GetString(2),
                            Position = reader.GetString(4),
                            DailyRate = reader.GetDouble(5),
                            Num_days = reader.GetDouble(6),
                            RateWage = reader.GetDouble(7),
                            OThours = reader.GetDouble(8),
                            Overtime = reader.GetDouble(9),
                            NightDifferential = reader.GetDouble(10),
                            HollPay = reader.GetDouble(11),
                            Basic_Pay = reader.GetDouble(12),
                            Cash_ad = reader.GetDouble(13),
                            Philhealth = reader.GetDouble(14),
                            WithholdingTax = reader.GetDouble(15),
                            Pagibig = reader.GetDouble(16),
                            SSS = reader.GetDouble(17),
                            OtherDeduc = reader.GetString(18) + " " + reader.GetString(20) + " " + reader.GetString(22),
                            Amount = reader.GetDouble(19) + reader.GetDouble(21) + reader.GetDouble(23),
                            Total_Deduc = reader.GetDouble(24),
                            Net_income = reader.GetDouble(25),
                            PayDay = reader.GetDateTime(26),
                        };
                        lvPayroll.Items.Add(_tmpPayroll);
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
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELP \nWhat can I do? \nYou can search the payroll table with the search field. However, you can only view the details of the employee's payroll you cannot edit or delete it. For other queries please contact us. \n\nHopefully this is helpful for you! \n\nHAVE A GOOD DAY!!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
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
