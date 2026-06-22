
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Flagship Laptop', 'Electronics', 1500.00),
(2, 'Pro Laptop', 'Electronics', 1200.00),
(3, 'Budget Laptop', 'Electronics', 1200.00), -- Tie price with Product 2!
(4, 'Office Laptop', 'Electronics', 900.00),
(5, 'Student Laptop', 'Electronics', 600.00),
(6, 'Running Shoes X', 'Footwear', 150.00),
(7, 'Running Shoes Y', 'Footwear', 150.00),    -- Tie price with Product 6!
(8, 'Walking Shoes', 'Footwear', 100.00),
(9, 'Casual Sneakers', 'Footwear', 80.00),
(10, 'Sandals', 'Footwear', 50.00);

-- 3. IMPLEMENTATION & ANALYSIS: Use PARTITION BY Category and ORDER BY Price DESC
WITH RankedProducts AS (
    SELECT 
        Category,
        ProductName,
        Price,
        -- Assigns a completely unique sequential row integer, ignoring any ties
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        
        -- Leaves gaps in the ranking sequence if there is a tie
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankVal,
        
        -- Keeps ranks sequential with no gaps even when ties occur
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankVal
    FROM Products
)
SELECT 
    Category,
    ProductName,
    Price,
    RowNum,
    RankVal,
    DenseRankVal
FROM RankedProducts
WHERE DenseRankVal <= 3; -- Filters to retrieve only the top 3 items per category
