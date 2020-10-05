using System;

namespace leapyearcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Räkna ut hur många skottår som passerat mellan två inmatade värden.
            Console.WriteLine("Mata in det lägsta året");
            string firstYear = Console.ReadLine();
            Console.WriteLine("Mata in det högsta året");
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
                    Console.WriteLine("  Leap year from {0} is {1}.",
                                      leapDay.ToString("d"),
                                      nextYear.ToString("d"));
                }
            }





            // DateTime.IsLeapYear(year) är en metod man kan använda.
        }
    }
}

