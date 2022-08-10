using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intParameters = new[] { 5, 8, 12, 10, 79 };
            double[] doubleParameters = new[] { 1.5, 2.3, 0.8, 15.6 };
            Console.WriteLine($"Source array of integer\n{intParameters.PrintArray()}");
            Console.WriteLine($"Minimal parameter is: {GetMinParam(intParameters)}; maximal parameter is: {GetMaxParam(intParameters)}");
            Console.WriteLine($"Source array of double\n{doubleParameters.PrintArray()}");
            Console.WriteLine($"Minimal parameter is: {GetMinParam(doubleParameters)}; maximal parameter is: {GetMaxParam(doubleParameters)}");
            Console.WriteLine("Enter two digit divide by whitespace");
            if (!GetParamsForSum(Console.ReadLine(), out int[] userInput))
            {
                Console.WriteLine("User input error");
                Console.ReadKey();
                return;
            }
            if (TrySumIfOdd(userInput, out int oddSum))
                Console.WriteLine($"Sum of element is odd and equal: {oddSum}");
            else
                Console.WriteLine("Sum of element is not odd");

            Console.WriteLine("Extra task");
            Console.WriteLine(Repeat("Qwe", 9));
            Console.ReadKey();
        }

        public static int GetMaxParam(params int[] numbers) => numbers.Max();
        public static int GetMinParam(params int[] numbers) => numbers.Min();
        //overloads methods by double type
        public static double GetMaxParam(params double[] numbers) => numbers.Max();
        public static double GetMinParam(params double[] numbers) => numbers.Min();

        public static bool TrySumIfOdd(int[] parameters, out int oddSum)
        {
            oddSum = GetSum(parameters);
            return oddSum.IsOdd();
        }

        public static bool GetParamsForSum(string userInput, out int[] paramsArray)
        {
            bool result = false;
            try
            {
                paramsArray = userInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(row => Convert.ToInt32(row)).ToArray();
                if (paramsArray.Length == 2)
                    result = true;
            }
            catch (Exception)
            {
                paramsArray = null;
                return result;
            }
            return result;
        }


        private static int GetSum(int[] argsForSum)
        {
            int sum = 0;
            int minNum = argsForSum.Min();
            int maxNum = argsForSum.Max();
            minNum++;
            while (minNum < maxNum)
            {
                sum += minNum;
                minNum++;
            }
            return sum;
        }

        static string Repeat(string str, int count)
        {
            if (count == 0 || str == null)
            {
                return "Invalid arguments";
            }
            if (count == 1)
                return str;
            else
                return str + Repeat(str, count -1);
        }
    }

    public static class MyExtention
    {
        public static bool IsOdd(this int number)
        { 
            return (number % 2 == 0)? true: false;
        }

        public static string PrintArray(this int[] intArr)
        {
            return (intArr.Length > 0)? string.Join(" ", intArr): "parameter array is empty";
        }

        public static string PrintArray(this double[] doubleArr)
        {
            return (doubleArr.Length > 0) ? string.Join(" ", doubleArr) : "parameter array is empty";
        }
    }
}
//checked
