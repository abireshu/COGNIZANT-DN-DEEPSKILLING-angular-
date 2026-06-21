using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("        Financial Forecasting         ");
            Console.WriteLine("==================================================\n");

            double presentValue = 1000.0; // Initial investment ($1000)
            double growthRate = 0.05;     // 5% constant annual growth rate
            int yearsToForecast = 5;      // Forecast for 5 years

            Console.WriteLine($"Initial Investment: ${presentValue}");
            Console.WriteLine($"Annual Growth Rate: {growthRate * 100}%");
            Console.WriteLine($"Forecasting Period: {yearsToForecast} years\n");

            // Execute the recursive calculation
            double futureValue = CalculateFutureValue(presentValue, growthRate, yearsToForecast);

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Predicted Future Value: ${Math.Round(futureValue, 2)}");
            Console.WriteLine("==================================================");

            // Print optimization analysis
            PrintAnalysis();
        }

        /// <summary>
        /// Recursive method to calculate future value.
        /// Formula: FV = PV * (1 + rate)^years
        /// </summary>
        public static double CalculateFutureValue(double currentValue, double rate, int years)
        {
            //  If no years are left, the value is just the current value.
            if (years == 0)
            {
                return currentValue;
            }

            // Calculate the value for next year by reducing the remaining years by 1
            return CalculateFutureValue(currentValue * (1 + rate), rate, years - 1);
        }

        private static void PrintAnalysis()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("             ALGORITHM ANALYSIS SUMMARY           ");
            Console.WriteLine("==================================================");
            Console.WriteLine("* Time Complexity: O(N) where N is the number of years.");
            Console.WriteLine("  Each year adds exactly one more recursive call block to the stack execution.");
            Console.WriteLine("\nHow to Optimize This Solution:");
            Console.WriteLine("1. Iteration (Loops): Convert it into a simple 'for' or 'while' loop. Loops consume");
            Console.WriteLine("   far less memory because they don't add frames to the call stack, preventing");
            Console.WriteLine("   StackOverflowExceptions over long horizons.");
            Console.WriteLine("2. Memoization: If growth rates vary unpredictably, cache intermediate calculations");
            Console.WriteLine("   in a dictionary/map array so you never recalculate a specific year twice.");
            Console.WriteLine("==================================================");
        }
    }
}