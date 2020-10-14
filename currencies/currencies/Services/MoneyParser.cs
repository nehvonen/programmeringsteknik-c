using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using currencies.Models;

namespace currencies.Services
{
    public class MoneyParser
    {
        public static Money Parse(string input)
        {
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 2)
                throw new ArgumentOutOfRangeException($"Missing data for money conversion from {input}");

            decimal amount = decimal.Parse(data[0]);

            return new Money(amount, data[1].ToUpper());
        }

        public static decimal ParseAmount(string input)

        {
            return decimal.Parse(input, CultureInfo.InvariantCulture);
        }
    }
}
