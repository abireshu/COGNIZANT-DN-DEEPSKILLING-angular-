Employee Management System SQL Exercises
Database Schema
The following schema defines the structure for an Employee Management System:
Departments Table
CREATE TABLE Departments ( DepartmentID INT PRIMARY KEY, DepartmentName VARCHAR(100) );
Employees Table
CREATE TABLE Employees ( EmployeeID INT PRIMARY KEY, FirstName VARCHAR(50), LastName VARCHAR(50), DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID), Salary DECIMAL(10,2), JoinDate DATE );
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES 
(1, 'HR'), 
(2, 'Finance'), 
(3, 'IT'), 
(4, 'Marketing');


SET IDENTITY_INSERT Employees ON;
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES 
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'), 
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'), 
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');
SET IDENTITY_INSERT Employees OFF;

GO
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DeptID INT
AS
BEGIN
    -- Select operational details by matching the incoming parameter
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        d.DepartmentName,
        e.Salary,
        e.JoinDate
    FROM Employees e
    INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DeptID;
END;
GO


-- EXEC sp_GetEmployeesByDepartment @DeptID = 3;



GO
CREATE PROCEDURE sp_InsertEmployee 
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @DepartmentID INT, 
    @Salary DECIMAL(10,2), 
    @JoinDate DATE 
AS 
BEGIN 
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) 
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate); 
END;
GO

-- EXEC sp_InsertEmployee 'Robert', 'Miller', 3, 6500.00, '2026-06-22';