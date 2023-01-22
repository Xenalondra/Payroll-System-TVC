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
    /// Interaction logic for Payroll.xaml
    /// </summary>
    public partial class SuperPayroll : Window
    {


        public class Pays
        {
            public string EID { get; set; }
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
            public double Net_income { get; set; }
            public DateTime PayDay { get; set; }
        }

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
        private void listPayroll()
        {
            lvPayroll.Items.Clear();
            string query = "SELECT * FROM `tbl_payroll`";
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
                            EID = reader.GetString(1),
                            Num_days = reader.GetDouble(3),
                            RateWage = reader.GetDouble(4),
                            OThours = reader.GetDouble(6),
                            Overtime = reader.GetDouble(5),
                            NightDifferential = reader.GetDouble(7),
                            HollPay = reader.GetDouble(8),
                            Basic_Pay = reader.GetDouble(9),
                            Cash_ad = reader.GetDouble(10),
                            Philhealth = reader.GetDouble(11),
                            WithholdingTax = reader.GetDouble(12),
                            Pagibig = reader.GetDouble(13),
                            SSS = reader.GetDouble(14),
                            Net_income = reader.GetDouble(15),
                            PayDay = reader.GetDateTime(2),
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

        private void listEmployees()
        {
            try
            {
                dtgemplist.Items.Clear();

            string query = "SELECT * FROM `tbl_employee`";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
           
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

        public SuperPayroll()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            date1.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            date2.Text = DateTime.Now.ToString("dddd , MMM dd yyyy");
            listPayroll();
            listEmployees();
           
        }
       

        //CALCULATIONS
        private void calc_dedution()
        {
            try
            {
                //may mali , mali ung data type
                double withholding;
                double ca, phi, sss, pagibig, d1, d2, d3, total_deduction, basicpay, netincome;
                if (txtcashAdvance.Text == "" || txtcashAdvance.Text == "0")
                {
                    txtcashAdvance.Text = "0";
                }
                if (txtPagibig.Text == "" || txtPagibig.Text == "0")
                {
                    txtPagibig.Text = "0";
                }
                if (txtSSS.Text == "" || txtSSS.Text == "0")
                {
                    txtSSS.Text = "0";
                }
                if (txtPhilhealth.Text == "" || txtPhilhealth.Text == "0")
                {
                    txtPhilhealth.Text = "0";
                }
                if (txtWithholding.Text == "" || txtWithholding.Text == "0")
                {
                    txtWithholding.Text = "0";
                }
                if (txtdeduction1val.Text == "" || txtdeduction1val.Text == "0")
                {
                    txtdeduction1val.Text = "0";
                }
                if (txtdeduction2val.Text == "" || txtdeduction2val.Text == "0")
                {
                    txtdeduction2val.Text = "0";
                }
                if (txtdeduction3val.Text == "" || txtdeduction3val.Text == "0")
                {
                    txtdeduction3val.Text = "0";
                }
               
                ca = Convert.ToDouble(txtcashAdvance.Text);
                phi = Convert.ToDouble(txtPhilhealth.Text);
                sss = Convert.ToDouble(txtSSS.Text);
                pagibig = Convert.ToDouble(txtPagibig.Text);
                d1 = Convert.ToDouble(txtdeduction1val.Text);
                d2 = Convert.ToDouble(txtdeduction2val.Text);
                d3 = Convert.ToDouble(txtdeduction3val.Text);
                basicpay = Convert.ToDouble(txtBasicPay.Text);
                withholding = Convert.ToDouble(txtWithholding.Text);

                total_deduction = ca + phi + sss + pagibig + withholding + d1 + d2 + d3;
                txtTotaldeduction.Text = total_deduction.ToString();

                netincome = basicpay - total_deduction;
                txtNetIncome.Text = netincome.ToString();
                listPayroll();
            }
            catch (Exception)
            {
               
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEmployeeId1.Text !="" || txtNumDays.Text != "" || txtEmployeeName.Text != "" || txtDailyRate.Text != "" || txtBasicPay.Text != "" || txtNetIncome.Text != "") {
                    String query = "INSERT INTO `tbl_payroll` (`EID`,`PayDay`,`Num_days`,`RateWage`, `Overtime`, `OThours`,`NightDifferential`,`HollPay`,`Basic_Pay`,`Cash_ad`,`Philhealth`,`WithholdingTax`,`Pagibig`,`SSS`, `Net_income`, `remarks`, `dateIssued`) VALUES (@EID, @payday, @numdays, @ratewage, @overtime, @othours, @nd, @hollpay, @basicpay, @cashad, @philhealth, @withholding, @pagibig, @SSS, @netincome, @remarks, @dateissued)";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                    commandDatabase.Parameters.AddWithValue("@payday", Convert.ToDateTime(PayDay.Text));
                    commandDatabase.Parameters.AddWithValue("@numdays", Convert.ToDouble(txtNumDays.Text));
                    commandDatabase.Parameters.AddWithValue("@ratewage", Convert.ToDouble(txtRatewage.Text));
                    commandDatabase.Parameters.AddWithValue("@overtime", Convert.ToDouble(txtRegOTperDay.Text));
                    commandDatabase.Parameters.AddWithValue("@othours", Convert.ToDouble(txtHoursOT.Text));
                    commandDatabase.Parameters.AddWithValue("@nd", Convert.ToDouble(txtDifferential.Text));
                    commandDatabase.Parameters.AddWithValue("@hollpay", Convert.ToDouble(txtHollidayPay.Text));
                    commandDatabase.Parameters.AddWithValue("@basicpay", Convert.ToDouble(txtBasicPay.Text));
                    commandDatabase.Parameters.AddWithValue("@cashad", Convert.ToDouble(txtcashAdvance.Text));
                    commandDatabase.Parameters.AddWithValue("@philhealth", Convert.ToDouble(txtPhilhealth.Text));
                    commandDatabase.Parameters.AddWithValue("@withholding", Convert.ToDouble(txtPhilhealth.Text));
                    commandDatabase.Parameters.AddWithValue("@pagibig", Convert.ToDouble(txtPagibig.Text));
                    commandDatabase.Parameters.AddWithValue("@SSS", Convert.ToDouble(txtSSS.Text));
                    commandDatabase.Parameters.AddWithValue("@netincome", Convert.ToDouble(txtNetIncome.Text));
                    commandDatabase.Parameters.AddWithValue("@remarks", txtRemarks.Text);
                    commandDatabase.Parameters.AddWithValue("@dateissued", Convert.ToDateTime(date.Text));
                    commandDatabase.CommandTimeout = 60;
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();

                    databaseConnection.Close();
                    otherDeduction();
                }
                else
                {
                    MessageBox.Show("Please input necessary data first!");
                }
            }
                
                catch (Exception)
                {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
              
          
        }
        public void otherDeduction()
        {
            try
            {
                //employee details
                string query = "INSERT INTO `tbl_other_deduction` (`EID`,`Deduc1`, `Deduc_amt1`, `Deduc2`, `Deduc_amt2`, `Deduc3`, `Deduc_amt3`, `Total_Deduc` )  VALUES (@EID, @d1, @d1Amt, @d2, @d2Amt, @d3, @d3Amt, @total)";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
            commandDatabase.Parameters.AddWithValue("@d1",txtdeduction1.Text);
            commandDatabase.Parameters.AddWithValue("@d1Amt", Convert.ToDouble(txtdeduction1val.Text));
            commandDatabase.Parameters.AddWithValue("@d2", txtdeduction2.Text);
            commandDatabase.Parameters.AddWithValue("@d2Amt", Convert.ToDouble(txtdeduction2val.Text));
            commandDatabase.Parameters.AddWithValue("@d3", txtdeduction3.Text);
            commandDatabase.Parameters.AddWithValue("@d3Amt", Convert.ToDouble(txtdeduction3val.Text));
            commandDatabase.Parameters.AddWithValue("@total", Convert.ToDouble(txtTotaldeduction.Text));
            commandDatabase.CommandTimeout = 60;
           
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Succesfully generated payroll!");
                databaseConnection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            transactionGenerate();
            listPayroll();
        }
        public void transactionGenerate()
        {
            try
            {
            string query2 = "INSERT INTO  `tbl_audit_trail` (`UserResponsible`, `TransactionHistory`, `DateOfTransaction`)  VALUES (@user, @history, @date)";
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
            commandDatabase2.Parameters.AddWithValue("@user", "SUPER ADMIN");
            commandDatabase2.Parameters.AddWithValue("@history", "Generate a payroll for "+txtEmployeeName.Text+" (" + txtEmployeeId1.Text +").");
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
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
           
            txtEmployeeId1.Text = "";
            txtEmployeeName.Text = "";
            txtBasicPay.Text = "";
            PayDay.Text = "";
            txtholnumdays.Text = "";
            txtDifferential.Text = "";
            txtcashAdvance.Text = "";
            txtDailyRate.Text = "";
            txtdeduction1.Text = "";
            txtdeduction1val.Text = "";
            txtdeduction2.Text = "";
            txtdeduction2val.Text = "";
            txtdeduction3.Text = "";
            txtdeduction3val.Text = "";
            txtHollidayPay.Text = "";
            txtHoursOT.Text = "";
            txtNetIncome.Text = "";
            txtNumDays.Text = "";
            txtPagibig.Text = "";
            txtPhilhealth.Text = "";
            txtRatewage.Text = "";
            txtRegOTperDay.Text = "";
            txtRemarks.Text = "";
            txtSSS.Text = "";
            txtTotaldeduction.Text = "";
            txtWithholding.Text = "";
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           searchedEmployee();
            if (txtSearch.Text == "")
            {
                listEmployees();
            }
        }
        public void searchedPay()
        {
            try
            {
                lvPayroll.Items.Clear();
            string query = "SELECT * FROM `tbl_payroll` WHERE `EID` LIKE '" + txtSearchPay.Text + "%'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
           
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Pays _tmpPayroll = new Pays
                        {
                            EID = reader.GetString(1),
                            Num_days = reader.GetDouble(3),
                            RateWage = reader.GetDouble(4),
                            OThours = reader.GetDouble(6),
                            Overtime = reader.GetDouble(5),
                            NightDifferential = reader.GetDouble(7),
                            HollPay = reader.GetDouble(8),
                            Basic_Pay = reader.GetDouble(9),
                            Cash_ad = reader.GetDouble(10),
                            Philhealth = reader.GetDouble(11),
                            WithholdingTax = reader.GetDouble(12),
                            Pagibig = reader.GetDouble(13),
                            SSS = reader.GetDouble(14),
                            Net_income = reader.GetDouble(15),
                            PayDay = reader.GetDateTime(2),
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
        public void searchedEmployee()
        {
            dtgemplist.Items.Clear();
            try
            {
            string query = "SELECT * FROM `tbl_employee` WHERE `EID` LIKE '" + txtSearch.Text + "%'" + " OR `LastName` LIKE '" + txtSearch.Text + "%'" + " OR `FirstName` LIKE '" + txtSearch.Text + "%'" + " OR `Sex` LIKE '" + txtSearch.Text + "%'" + " OR `Address` LIKE '" + txtSearch.Text + "%'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
          
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
      
        public void searchedResult()
        {
            if (txtEmployeeId1.Text != "")
            {
                string query = "SELECT * FROM `tbl_employee` WHERE `EID` LIKE '" + txtEmployeeId1.Text + "%'";

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
                            txtEmployeeName.Text = reader.GetString(3) + ", " + reader.GetString(1) + " " + reader.GetString(2);
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

                string query1 = "SELECT * FROM `tbl_employee_workinfo` WHERE EID = @EID";
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                commandDatabase1.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
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
                            txtDailyRate.Text= Convert.ToString(reader1.GetDouble(2));
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
            }
            else
            {
               
                txtEmployeeName.Text = "";
                txtholnumdays.Text = "";
                txtDifferential.Text = "";
                txtBasicPay.Text = "";
                PayDay.Text = "";
                txtcashAdvance.Text = "";
                txtDailyRate.Text = "";
                txtdeduction1.Text = "";
                txtdeduction1val.Text = "";
                txtdeduction2.Text = "";
                txtdeduction2val.Text = "";
                txtHollidayPay.Text = "";
                txtHoursOT.Text = "";
                txtNetIncome.Text = "";
                txtNumDays.Text = "";
                txtPagibig.Text = "";
                txtPhilhealth.Text = "";
                txtRatewage.Text = "";
                txtRegOTperDay.Text = "";
                txtRemarks.Text = "";
                txtSSS.Text = "";
                txtTotaldeduction.Text = "";
                txtWithholding.Text = "";
            }
        }
        private void txtEmployeeId1_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedResult();
        }

        private void txtNumDays_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                double rateWage, numberofdays;
                double dailyratesample, basicpay, netincome, nd, ot, holpay;
                
                if (txtNumDays.Text == "" || txtNumDays.Text == "0")
                {
                    txtRatewage.Text = "0";
                }
                else
                {
                    if (txtDifferential.Text == "" || txtDifferential.Text == "0")
                    {
                        txtDifferential.Text = "0";
                    }
                    if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                    {
                        txtRegOTperDay.Text = "0";
                    }
                    if (txtholnumdays.Text == "" || txtholnumdays.Text == "0")
                    {
                        txtHollidayPay.Text = "0";
                    }
                    ot = Convert.ToDouble(this.txtRegOTperDay.Text);
                    holpay = Convert.ToDouble(this.txtHollidayPay.Text);
                    nd = Convert.ToDouble(txtDifferential.Text);
                    numberofdays = Double.Parse(txtNumDays.Text);
                    dailyratesample = Double.Parse(txtDailyRate.Text) ;
                    rateWage = numberofdays * dailyratesample;
                    txtRatewage.Text = rateWage.ToString();
                    calc_dedution();
                    basicpay = rateWage + ot + holpay + nd;
                    txtBasicPay.Text = basicpay.ToString();
                    netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                    txtNetIncome.Text = netincome.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtHoursOT_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double total, total_OT, basicpay, netincome, ot, holpay, rateWage;


                if (txtHoursOT.Text == "" || txtHoursOT.Text == "0")
                {
                    txtRegOTperDay.Text = "0";
                }
                else
                {
                    total = Double.Parse(txtDailyRate.Text) / 8;
                    total_OT = total * Double.Parse(txtHoursOT.Text);
                    txtRegOTperDay.Text = total_OT.ToString();

                }
                if (txtDifferential.Text == "" || txtDifferential.Text == "0")
                {
                    txtDifferential.Text = "0";
                }
                double nd = Convert.ToDouble(txtDifferential.Text);
                ot = double.Parse(txtRegOTperDay.Text);
                holpay = double.Parse(txtHollidayPay.Text);
                rateWage = double.Parse(txtRatewage.Text);

                basicpay = rateWage + ot + holpay +nd;
                txtBasicPay.Text = basicpay.ToString();
                calc_dedution();
                netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                txtBasicPay.Text = netincome.ToString();

            }
            catch
            {

            }
        }

        private void txtholnumdays_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double hollidaypay, pay, dailyrate, ot, ratewage, basicpay, netincome, nd, numdays;

                if (txtholnumdays.Text == "" || txtholnumdays.Text == "0")
                {
                    txtHollidayPay.Text = "0";
                }
                else
                {
                    ot = double.Parse(txtRegOTperDay.Text);
                    ratewage = double.Parse(txtRatewage.Text);
                    nd = double.Parse(txtDifferential.Text);
                    numdays = double.Parse(txtholnumdays.Text);
                    hollidaypay = Double.Parse(txtDailyRate.Text);
                    dailyrate = hollidaypay * 2;
                    pay = numdays * dailyrate;
                    txtHollidayPay.Text = pay.ToString();
                    basicpay = ratewage + ot + pay + nd;
                    txtBasicPay.Text = basicpay.ToString();
                    calc_dedution();
                    netincome = basicpay - double.Parse(txtTotaldeduction.Text);
                    txtBasicPay.Text = netincome.ToString();
                }
            }
            catch (Exception)
            {

            }
        }
        private void txtcashAdvance_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }

        private void txtPagibig_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }

        private void txtSSS_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }

        private void txtPhilhealth_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }

        private void txtWithholding_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }
        private void txtdeduction1val_TextChanged(object sender, TextChangedEventArgs e)
        {
            calc_dedution();
        }

        private void txtdeduction2val_TextChanged(object sender, TextChangedEventArgs e)
        {
          calc_dedution();
        }

        private void txtdeduction3val_TextChanged(object sender, TextChangedEventArgs e)
        {
           calc_dedution();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            SuperAdmin home = new SuperAdmin();
            home.ShowDialog();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELP \nHow do I start? \nInput the employee ID on the textfield first. Another option is to go to the employee list tab then click the employee details that you want to create a payroll. However, you cannot add, edit, nor delete employee records. You can also use the search textfield to look for the employee that you are searching. \n\nDo I input everything manually? \nYou don't have to input every data manually. The program will calculate it for you.\n\nWhat are the data that I need to input? \nYou need to Input the number of days the employee goes to work, the number of Overtime hours, Night Differential if the employee is night shift, the number of holliday(how many days) and the deductions if there is any.\nAfter generating the payroll you can click the new button to clear the textfields at once. Then you can now create another payroll by either typing the employee ID on the field or just by clicking the employee on the employee list.\n\nIMPORTANT NOTE: You cannot edit the payroll once it is save on the database please check the information you input carefully before saving it.\n\nHopefully this is helpful for you! \n\nHave a good day!!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question );
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dtgemplist.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select an employee first!!");
            }
            else
            {
                int index = tabControl.SelectedIndex - 1;
                tabControl.SelectedIndex = index;
                btnSave.IsEnabled = true;
            }
        }
      
        private void dtgemplist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dtgemplist.SelectedIndex > -1)
                {
                    currUser = (Employees)dtgemplist.SelectedItem;
                    txtEmployeeId1.Text = currUser.EmployeeID.ToString();
                    string query1 = "SELECT * FROM `tbl_employee` WHERE EID = @EID";
                    MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                    commandDatabase1.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                    commandDatabase1.CommandTimeout = 60;
                    MySqlDataReader reader1;

                    databaseConnection1.Open();
                    reader1 = commandDatabase1.ExecuteReader();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            txtEmployeeName.Text = reader1.GetString(3) + ", " + reader1.GetString(1) + " " + reader1.GetString(2);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    databaseConnection1.Close();
                }
            }
            catch (Exception)
            {

            }
                try
                {
                    string query = "SELECT * FROM `tbl_employee_workinfo` WHERE EID = @EID";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@EID", txtEmployeeId1.Text);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
              
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtDailyRate.Text = Convert.ToString(reader.GetDouble(2));
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
            }
        
         private void txtSearchPay_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchedPay();
            if (txtSearchPay.Text == "")
            {
                listPayroll();
            }
        }
      
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WHO ARE WE? \n\n\tWith a team of dedicated IT students of Pamantasan ng Lungsod ng Valenzuela, TvCon Payroll System was created on December 3, 2019. TvCon Payroll System was designed to meet the company's specific needs. The Payroll System take away the hassle of creating payroll and managing employee records. It allows the user to experience stress-free managing and monitoring of records.Our leadership team is dedicated to create a system that is easy to use, efficient and helpful.", "ABOUT US", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\nCONTACT US \n\nGet in touch with us. We gladly welcome your inquiries and feedback. Please feel free to contact us at our email (Tvcon09@gmail.com) and contact number(09771865983). \n\nHAVE A GOOD DAY!", "HELP", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            pmCalendar calendar = new pmCalendar();
            calendar.Show();
        }
    }
    }
    
    

