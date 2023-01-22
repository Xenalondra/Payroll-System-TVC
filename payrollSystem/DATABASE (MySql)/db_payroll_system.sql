-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 20, 2020 at 05:00 AM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_payroll_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_audit_trail`
--

CREATE TABLE `tbl_audit_trail` (
  `HID` int(11) NOT NULL,
  `UserResponsible` varchar(20) DEFAULT NULL,
  `TransactionHistory` varchar(150) DEFAULT NULL,
  `DateOfTransaction` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_audit_trail`
--

INSERT INTO `tbl_audit_trail` (`HID`, `UserResponsible`, `TransactionHistory`, `DateOfTransaction`) VALUES
(1, 'SUPER ADMIN', 'Login the system. (SUPER ADMIN: super)', '2020-01-20'),
(2, 'SUPER ADMIN', 'Deleted the record of employee (5656) from the database.', '2020-01-20'),
(3, 'SUPER ADMIN', 'Logout of the system.', '2020-01-20'),
(4, 'ADMINISTRATOR', 'Login the system. (ADMINISTRATOR: admin)', '2020-01-20'),
(5, 'ADMINISTRATOR', 'Addded a new user alondra (Administrator).', '2020-01-20'),
(6, 'ADMINISTRATOR', 'Deleted user account of alondra (Administrator).', '2020-01-20'),
(7, 'ADMIN', 'Logout of the system.', '2020-01-20');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_employee`
--

CREATE TABLE `tbl_employee` (
  `EID` varchar(30) NOT NULL,
  `FirstName` varchar(50) DEFAULT NULL,
  `MiddleName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `PermanentAdd` varchar(100) DEFAULT NULL,
  `Contact` varchar(20) DEFAULT NULL,
  `MaritalStatus` varchar(10) DEFAULT NULL,
  `Birthdate` date DEFAULT NULL,
  `Birthplace` varchar(50) DEFAULT NULL,
  `Sex` varchar(10) DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  `Emergency_Contact` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_employee`
--

INSERT INTO `tbl_employee` (`EID`, `FirstName`, `MiddleName`, `LastName`, `Address`, `PermanentAdd`, `Contact`, `MaritalStatus`, `Birthdate`, `Birthplace`, `Sex`, `Age`, `Emergency_Contact`) VALUES
('19-0000', 'Jhon', 'Bagtas', 'De Villa', '87, 9th Avenue, Cubao, Quezon City, 1109 Metro Manila', '87, 9th Avenue, Cubao, Quezon City, 1109 Metro Manila', '09502315241', 'Single', '1984-10-16', 'Batanes', 'Male', 35, '09215636458'),
('19-0001', 'Emilio', 'Jacinto', 'San Juan', '96, 7th Avenue, Caloocan City', '96, 7th Avenue, Caloocan City', '09215636485', 'Married', '1993-08-23', 'Quezon City', 'Male', 26, '09215363214'),
('19-0002', 'Cesar', 'Santiago', 'Juanico', '24, Baesa,  Caloocan City', '24, Baesa,  Caloocan City', '09356987545', 'Married', '1983-01-04', 'Quezon City', 'Male', 36, '09552369865'),
('19-0003', 'Emmanuel', 'Francisco', 'Marcos', '13 Ecol St., Commonwealth, Caloocan City', '13 Ecol St., Commonwealth, Caloocan City', '09312546935', 'Single', '1990-10-01', 'Cubao City', 'Male', 29, '09213656535'),
('19-0004', 'Efren', 'Kalungcutan', 'Susano', '105, 12th Avenue, Cubao, Quezon City', '105, 12th Avenue, Cubao, Quezon City', '09152363263', 'Married', '1987-06-16', 'Marikina City', 'Male', 32, '09032356945'),
('19-0005', 'Marcelino', 'Lopez', 'Santos', '103, 14th Avenue, Cubao, Quezon City', '105, 12th Avenue, Cubao, Quezon City', '09152363565', 'Married', '1989-11-14', 'Marikina City', 'Male', 30, '09365485865'),
('19-0006', 'Carlito', 'Garcia', 'Fortaleza', '16 Pinatubo, Quezon City', '105, 12th Avenue, Cubao, Quezon City', '09156321152', 'Single', '1996-03-22', 'Quezon  City', 'Male', 23, '09636452135'),
('19-0007', 'Emilito', 'Abano', 'Garcia', '60, 19th Ave, San Roque, Quezon City', '36, 20th Ave, Cubao, Quezon City', '09323365655', 'Married', '1977-12-06', 'Quezon  City', 'Male', 42, '09213636545'),
('19-0008', 'Lito', 'Jose', 'De Guzman', '15, 13th Ave, Cubao, Quezon City General Trias Cavite', '15, 13th Ave, Cubao, Quezon City General Trias Cavite', '09503263261', 'Single', '1997-01-01', 'Quezon  City', 'Male', 22, '09205469878'),
('19-0009', 'Cecilio', 'Roxas', 'Del Mundo', '37, A.Rigor, Masagna, Quezon City', '37, A.Rigor, Masagna, Quezon City', '09545233698', 'Single', '1997-07-26', 'Quezon  City', 'Male', 27, '092122153654'),
('19-0010', 'Rosaline ', 'Santiago', 'Francisco', 'General Arellano, Project 4, Quezon City', 'Valenzuela City', '095523648535', 'Married', '1983-10-12', 'Quezon  City', 'Female', 36, '091024563354'),
('19-0011', 'Angel', 'Burgos', 'Cariaga', '14, 1109 Don Jose, Cubao, Quezon City', '14, 1109 Don Jose, Cubao, Quezon City', '095663212332', 'Married', '1984-02-03', 'Quezon  City', 'Female', 35, '090023256945'),
('19-0012', 'Cyralyn', 'Zuniega', 'Cagampang', '13, Velante Drive Cubao, Quezon City', '13, Velante Drive Cubao, Quezon City', '090123452525', 'Single', '1983-05-30', 'Valenzuela City', 'Female', 23, '090356448554'),
('19-0013', 'Jaimee', 'Marbella', 'Bilolo', '60, Main Ave, Cubao, Quezon City', '60, Main Ave, Cubao, Quezon City', '090123452525', 'Single', '1984-03-03', 'Quezon City', 'Female', 35, '090356448554'),
('19-0014', 'Denise Marie', 'Susano', 'Cabang', '28-A 13th Avenue, Quezon City', '28-A 13th Avenue, Quezon City', '09321458754', 'Single', '1987-01-15', 'Quezon City', 'Female', 32, '093233358998'),
('19-0015', 'Maria Carmelita', 'Guzman', 'Pascual', '114B 12th Ave, Soloro, Quezon ', '114B 12th Ave, Soloro, Quezon', '098965354216', 'Single', '1972-01-22', 'Quezon City', 'Female', 32, '093125246635');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_employee_workinfo`
--

CREATE TABLE `tbl_employee_workinfo` (
  `ID` int(11) NOT NULL,
  `EID` varchar(30) DEFAULT NULL,
  `DailyRate` double DEFAULT NULL,
  `Position` varchar(30) DEFAULT NULL,
  `WorkStatus` varchar(10) DEFAULT NULL,
  `HiredDate` date DEFAULT NULL,
  `Monthly_salary` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_employee_workinfo`
--

INSERT INTO `tbl_employee_workinfo` (`ID`, `EID`, `DailyRate`, `Position`, `WorkStatus`, `HiredDate`, `Monthly_salary`) VALUES
(1, '19-0000', 961.54, 'Permanent', 'Active', '2000-02-09', 25000.04),
(2, '19-0001', 769.23, 'Casual', 'Active', '2014-09-02', 19999.98),
(3, '19-0002', 692.31, 'Permanent', 'Active', '2003-01-26', 18000.059999999998),
(4, '19-0003', 692.31, 'Casual', 'Active', '2013-12-03', 18000.059999999998),
(5, '19-0004', 600, 'Casual', 'Active', '2016-02-13', 15600),
(6, '19-0005', 576.92, 'Casual', 'Active', '2014-03-06', 14999.919999999998),
(7, '19-0006', 519.23, 'Casual', 'Active', '2018-04-02', 13499.98),
(8, '19-0007', 615.38, 'Permanent', 'Active', '2004-05-21', 15999.88),
(9, '19-0008', 538.46, 'Casual', 'Active', '2019-07-11', 13999.960000000001),
(10, '19-0009', 538.46, 'Casual', 'Active', '2016-03-13', 13999.960000000001),
(11, '19-0010', 769.23, 'Permanent', 'Active', '2001-10-02', 19999.98),
(12, '19-0011', 769.23, 'Permanent', 'Active', '2008-07-06', 19999.98),
(13, '19-0012', 538.46, 'Trainee', 'Active', '2018-06-08', 13999.960000000001),
(14, '19-0013', 576.92, 'Casual', 'Active', '2015-07-07', 14999.919999999998),
(15, '19-0014', 629.31, 'Permanent', 'Active', '2003-06-04', 16362.059999999998),
(16, '19-0015', 629.31, 'Permanent', 'Active', '2003-06-12', 16362.059999999998);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_notes`
--

CREATE TABLE `tbl_notes` (
  `noteID` int(11) NOT NULL,
  `DateWritten` date DEFAULT NULL,
  `Title` varchar(200) DEFAULT NULL,
  `Note` varchar(300) DEFAULT NULL,
  `userType` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_notes`
--

INSERT INTO `tbl_notes` (`noteID`, `DateWritten`, `Title`, `Note`, `userType`) VALUES
(1, '2019-12-04', 'Monitor the Users', 'Always check the transaction history.', 'SUPER ADMIN'),
(2, '2019-12-04', 'Release of payroll', 'The released of payroll will be on December 15, 2019. Be sure to generate the payroll of active employees.', 'PAYROLL MASTER'),
(3, '2019-12-04', 'ADD new records', 'add the 201 files of newly hire employees this week.', 'HUMAN RESOURCE'),
(4, '2019-12-15', 'Add new user', 'add new users as instructed by the president.', 'ADMIN');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_other_deduction`
--

CREATE TABLE `tbl_other_deduction` (
  `EID` varchar(30) DEFAULT NULL,
  `Deduc1` varchar(50) DEFAULT NULL,
  `Deduc_amt1` double DEFAULT NULL,
  `Deduc2` varchar(50) DEFAULT NULL,
  `Deduc_amt2` double DEFAULT NULL,
  `Deduc3` varchar(50) DEFAULT NULL,
  `Deduc_amt3` double DEFAULT NULL,
  `Total_Deduc` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_other_deduction`
--

INSERT INTO `tbl_other_deduction` (`EID`, `Deduc1`, `Deduc_amt1`, `Deduc2`, `Deduc_amt2`, `Deduc3`, `Deduc_amt3`, `Total_Deduc`) VALUES
('19-0000', '', 0, '', 0, '', 0, 826.62),
('19-0001', 'Late', 96.15, '', 0, '', 0, 574.3),
('19-0002', 'Late', 346.16, 'Absent', 2769.28, 'Undertime', 346.16, 3926),
('19-0003', '', 0, '', 0, '', 0, 1447.9),
('19-0004', 'Absent', 515.63, '', 0, '', 0, 954.73),
('19-0005', 'Late', 216.36, '', 0, '', 0, 641.99),
('19-0006', 'Late', 74.64, '', 0, '', 0, 471.7),
('19-0007', '', 0, '', 0, '', 0, 1868.6),
('19-0008', 'Undertime', 303.85, '', 0, '', 0, 1236.62),
('19-0009', 'Late', 88.46, '', 0, '', 0, 649.81),
('19-0010', 'Late', 96.15, 'Undertime', 384.615, '', 0, 2541.415),
('19-0011', '', 0, '', 0, '', 0, 622.38),
('19-0012', '', 0, '', 0, '', 0, 370.5),
('19-0013', 'Late', 144, '', 0, '', 0, 594.65),
('19-0014', 'Absent', 629.31, '', 0, '', 0, 1093.71),
('19-0015', '', 0, '', 0, '', 0, 175.9);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_payroll`
--

CREATE TABLE `tbl_payroll` (
  `transID` int(11) NOT NULL,
  `EID` varchar(30) DEFAULT NULL,
  `PayDay` date DEFAULT NULL,
  `Num_days` double DEFAULT NULL,
  `RateWage` double DEFAULT NULL,
  `Overtime` double DEFAULT NULL,
  `OThours` double DEFAULT NULL,
  `NightDifferential` double DEFAULT NULL,
  `HollPay` double DEFAULT NULL,
  `Basic_Pay` double DEFAULT NULL,
  `Cash_ad` double DEFAULT NULL,
  `Philhealth` double DEFAULT NULL,
  `WithholdingTax` double DEFAULT NULL,
  `Pagibig` double DEFAULT NULL,
  `SSS` double DEFAULT NULL,
  `Net_income` double DEFAULT NULL,
  `remarks` varchar(200) DEFAULT NULL,
  `dateIssued` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_payroll`
--

INSERT INTO `tbl_payroll` (`transID`, `EID`, `PayDay`, `Num_days`, `RateWage`, `Overtime`, `OThours`, `NightDifferential`, `HollPay`, `Basic_Pay`, `Cash_ad`, `Philhealth`, `WithholdingTax`, `Pagibig`, `SSS`, `Net_income`, `remarks`, `dateIssued`) VALUES
(1, '19-0000', '2019-12-15', 13, 12500.02, 0, 0, 0, 0, 12500.02, 0, 171.88, 171.88, 50, 290.65, 11673.4, 'Industrius', '2019-12-04'),
(3, '19-0001', '2019-12-15', 13, 9999.99, 576.9225, 6, 0, 0, 10576.9125, 0, 137.5, 137.5, 50, 290.65, 10002.6125, '', '2019-12-04'),
(4, '19-0002', '2019-12-15', 13, 9000.03, 302.885625, 3.5, 59.5, 0, 9362.415625, 0, 123.75, 123.75, 50, 290.65, 5436.415625, 'Always late and absent', '2019-12-04'),
(5, '19-0003', '2019-12-15', 13, 9000.03, 475.963125, 5.5, 0, 0, 9475.993125, 1000, 107.25, 107.25, 50, 290.65, 8028.093125, '', '2019-12-04'),
(6, '19-0004', '2019-12-15', 13, 7800, 412.5, 5.5, 0, 0, 8212.5, 0, 107.5, 107.5, 50, 281.6, 7257.77, '', '2019-12-04'),
(7, '19-0005', '2019-12-15', 13, 7499.96, 612.9775, 8.5, 0, 0, 8112.9375, 0, 103.13, 103.13, 50, 272.5, 7470.9475, '', '2019-12-04'),
(8, '19-0006', '2019-12-15', 13, 6749.99, 259.615, 4, 0, 0, 7009.605, 0, 92.81, 92.81, 50, 254.25, 6537.905, '', '2019-12-04'),
(9, '19-0007', '2019-12-15', 13, 7999.94, 1999.985, 26, 0, 0, 9999.925, 1468, 96.25, 96.25, 50, 254.35, 8131.325, '', '2019-12-04'),
(10, '19-0008', '2019-12-15', 13, 6999.98, 2894.2225, 43, 1216.35, 0, 11110.5525, 0, 110, 110, 50, 290.65, 9873.9325, '', '2019-12-04'),
(11, '19-0009', '2019-12-15', 13, 6999.98, 1682.6875, 25, 1057.69, 0, 9740.3575, 0, 110, 110, 50, 290.65, 9090.5475, '', '2019-12-04'),
(12, '19-0010', '2019-12-15', 13, 9999.99, 1153.845, 12, 0, 1538.46, 12692.295, 1500, 110, 110, 290.65, 50, 10150.88, '', '2019-12-04'),
(13, '19-0011', '2019-12-15', 13, 9999.99, 1249.99875, 13, 0, 1538.46, 12788.44875, 0, 171.88, 171.88, 50, 290.5, 12166.06875, '', '2019-12-04'),
(14, '19-0012', '2019-12-15', 13, 6999.98, 2019.225, 30, 0, 0, 9019.205, 0, 103, 103, 50, 217.5, 8648.705, '', '2019-12-04'),
(15, '19-0013', '2019-12-15', 13, 7499.96, 1081.725, 15, 0, 0, 8581.685, 0, 110, 110, 50, 290.65, 7987.035, '', '2019-12-04'),
(16, '19-0014', '2019-12-15', 13, 8181.03, 1258.62, 16, 1000, 0, 10439.65, 0, 123.75, 123.75, 50, 290.65, 9345.94, '', '2019-12-04'),
(17, '19-0015', '2019-12-15', 13, 8181.03, 1573.275, 20, 0, 0, 9754.305, 0, 96.25, 96.25, 50, 29.65, 9578.405, '', '2019-12-04');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_users`
--

CREATE TABLE `tbl_users` (
  `UserID` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Username` varchar(100) DEFAULT NULL,
  `Pass` varchar(200) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_users`
--

INSERT INTO `tbl_users` (`UserID`, `Name`, `Username`, `Pass`, `Type`) VALUES
(1, 'Administrator', 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'ADMINISTRATOR'),
(2, 'Payroll Master', 'Payroll', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'PAYROLL MASTER'),
(3, 'Human Resources', 'hr123', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'HUMAN RESOURCES'),
(4, 'Super Admin', 'super', '73d1b1b1bc1dabfb97f216d897b7968e44b06457920f00f2dc6c1ed3be25ad4c', 'SUPER ADMIN');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_audit_trail`
--
ALTER TABLE `tbl_audit_trail`
  ADD PRIMARY KEY (`HID`);

--
-- Indexes for table `tbl_employee`
--
ALTER TABLE `tbl_employee`
  ADD PRIMARY KEY (`EID`);

--
-- Indexes for table `tbl_employee_workinfo`
--
ALTER TABLE `tbl_employee_workinfo`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `tbl_employee_workinfo_ibfk_1` (`EID`);

--
-- Indexes for table `tbl_notes`
--
ALTER TABLE `tbl_notes`
  ADD PRIMARY KEY (`noteID`);

--
-- Indexes for table `tbl_other_deduction`
--
ALTER TABLE `tbl_other_deduction`
  ADD KEY `EID` (`EID`);

--
-- Indexes for table `tbl_payroll`
--
ALTER TABLE `tbl_payroll`
  ADD PRIMARY KEY (`transID`),
  ADD KEY `EID` (`EID`);

--
-- Indexes for table `tbl_users`
--
ALTER TABLE `tbl_users`
  ADD PRIMARY KEY (`UserID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_audit_trail`
--
ALTER TABLE `tbl_audit_trail`
  MODIFY `HID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `tbl_employee_workinfo`
--
ALTER TABLE `tbl_employee_workinfo`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `tbl_notes`
--
ALTER TABLE `tbl_notes`
  MODIFY `noteID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tbl_payroll`
--
ALTER TABLE `tbl_payroll`
  MODIFY `transID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `tbl_users`
--
ALTER TABLE `tbl_users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_employee_workinfo`
--
ALTER TABLE `tbl_employee_workinfo`
  ADD CONSTRAINT `tbl_employee_workinfo_ibfk_1` FOREIGN KEY (`EID`) REFERENCES `tbl_employee` (`EID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tbl_other_deduction`
--
ALTER TABLE `tbl_other_deduction`
  ADD CONSTRAINT `tbl_other_deduction_ibfk_1` FOREIGN KEY (`EID`) REFERENCES `tbl_employee` (`EID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tbl_payroll`
--
ALTER TABLE `tbl_payroll`
  ADD CONSTRAINT `tbl_payroll_ibfk_1` FOREIGN KEY (`EID`) REFERENCES `tbl_employee` (`EID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
