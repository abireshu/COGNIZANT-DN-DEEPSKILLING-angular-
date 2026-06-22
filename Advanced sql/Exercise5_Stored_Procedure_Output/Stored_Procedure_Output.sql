

GO
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DeptID INT,
    @EmployeeCount INT OUTPUT -- This parameter acts as an exit-door to pass data back out
AS
BEGIN
    -- Count the rows matching the DepartmentID and assign it directly to our Output variable
    SELECT @EmployeeCount = COUNT(*)
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;
GO

-- =========================================================================
-- HOW TO RUN AND TEST THIS EXPANDED EXERCISE:
-- Because this procedure uses an OUTPUT parameter, you must declare a 
-- variable to catch the number when you execute it.
-- =========================================================================

/*
1. Declare a variable to store the caught number
DECLARE @ResultCount INT;
2. Execute the procedure, passing in DepartmentID = 3 (IT Department) 
   and marking our variable with 'OUTPUT' so it receives the data
EXEC sp_GetEmployeeCountByDepartment 
    @DeptID = 3, 
    @EmployeeCount = @ResultCount OUTPUT;

3. Print or Select the final value to see it in your results grid!
SELECT @ResultCount AS 'Total Employees in Department 3';
*/