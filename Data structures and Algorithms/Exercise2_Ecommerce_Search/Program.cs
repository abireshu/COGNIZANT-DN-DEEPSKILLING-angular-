using System;
using System.Diagnostics;

namespace EcommerceSearch
{
    
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        // This allows us to sort products easily by their ProductId for Binary Search
        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return this.ProductId.CompareTo(other.ProductId);
        }

        public override string ToString()
        {
            return $"[ID: {ProductId} | Name: {ProductName} | Category: {Category}]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("   Exercise 2: E-commerce Search Optimization     ");
            Console.WriteLine("==================================================\n");

            // 1. Create an array of sample products
            Product[] products = new Product[]
            {
                new Product(105, "Wireless Mouse", "Electronics"),
                new Product(101, "Leather Wallet", "Accessories"),
                new Product(104, "Mechanical Keyboard", "Electronics"),
                new Product(102, "Running Shoes", "Footwear"),
                new Product(103, "Coffee Mug", "Kitchenware")
            };

            int targetId = 104; // The Product ID we want to find

            // --- IMPLEMENTATION: Linear Search ---
            Console.WriteLine($"--- Running Linear Search for Product ID: {targetId} ---");
            Product linearResult = LinearSearch(products, targetId);
            PrintResult(linearResult);

            // --- IMPLEMENTATION: Binary Search ---
            // CRITICAL STEP: Binary search REQUIRES the array to be sorted by the lookup key first!
            Console.WriteLine("\nSorting array for Binary Search...");
            Array.Sort(products); 

            Console.WriteLine($"--- Running Binary Search for Product ID: {targetId} ---");
            Product binaryResult = BinarySearch(products, targetId);
            PrintResult(binaryResult);

            // --- ANALYSIS SUMMARY ---
            PrintAnalysis();
        }

        /// <summary>
        /// Linear Search Algorithm
        /// Time Complexity: Worst Case O(N), Best Case O(1)
        /// </summary>
        public static Product LinearSearch(Product[] arr, int targetId)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].ProductId == targetId)
                {
                    return arr[i]; // Target found
                }
            }
            return null; // Target not found
        }

        /// <summary>
        /// Binary Search Algorithm
        /// Time Complexity: Worst Case O(log N), Best Case O(1)
        /// </summary>
        public static Product BinarySearch(Product[] arr, int targetId)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid].ProductId == targetId)
                {
                    return arr[mid]; // Target found
                }

                if (arr[mid].ProductId < targetId)
                {
                    left = mid + 1; // Look in the right half
                }
                else
                {
                    right = mid - 1; // Look in the left half
                }
            }
            return null; // Target not found
        }

        private static void PrintResult(Product result)
        {
            if (result != null)
                Console.WriteLine($"SUCCESS: Found Product -> {result}");
            else
                Console.WriteLine("ERROR: Product not found.");
        }

        private static void PrintAnalysis()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("             ALGORITHM ANALYSIS SUMMARY           ");
            Console.WriteLine("==================================================");
            Console.WriteLine("* Linear Search Time Complexity: Worst-case O(N). It checks every element sequentialy.");
            Console.WriteLine("* Binary Search Time Complexity: Worst-case O(log N). It repeatedly divides search space.");
            Console.WriteLine("\nPlatform Choice Recommendation:");
            Console.WriteLine("For a scalable e-commerce platform with thousands or millions of products, BINARY SEARCH");
            Console.WriteLine("is vastly superior because O(log N) performs virtually instantaneous lookups, whereas O(N)");
            Console.WriteLine("will introduce severe, noticeable lag as your catalog grows.");
            Console.WriteLine("==================================================");
        }
    }
}