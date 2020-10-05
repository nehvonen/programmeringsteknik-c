using System;

namespace leapyearcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Räkna ut hur många skottår som passerat mellan två inmatade värden.
            Console.WriteLine("Please write a year (Example: 1992)");
            string firstYear = Console.ReadLine();
            Console.WriteLine("Please write another year (Example: 2020)");
            string secondYear = Console.ReadLine();
            int integerYearone = int.Parse(firstYear);
            int integerYearSecond = int.Parse(secondYear);

            for (int year = integerYearone; year <= integerYearSecond; year++)
            {
                if (DateTime.IsLeapYear(year))
                {
                    Console.WriteLine("{0} is a leap year.", year);
                    DateTime leapDay = new DateTime(year, 2, 29);
                    DateTime nextYear = leapDay.AddYears(1);
                }
            }
        }
    }
}

