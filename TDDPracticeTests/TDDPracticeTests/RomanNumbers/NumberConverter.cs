using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPracticeTests.RomanNumbers
{
    public static class NumberConverter
    {
        static readonly Dictionary<int, string> NumberRoman = new Dictionary<int, string>
        {
            {1000,"M" },
            {900,"CM" },
            {500,"D" },
            {400,"CD" },
            {100,"C" },
            {50,"L" },
            {40,"XL" },
            {10,"X" },
            {9,"IX" },
            {5,"V" },
            {4,"IV" },
            {1,"I" },
        };
        public static string ConvertToRomanNumber(int number)
        {
            #region Validation
            if (number == 0)
            {
                throw new ArgumentException("Number must no be zero.");
            }
            else if (number < 0)
            {
                throw new ArgumentException("Number must no be negative.");
            } 
            #endregion

            string roman = "";

            foreach (var keyvalue in NumberRoman)
            {
                while (number >= keyvalue.Key)
                {
                    roman += keyvalue.Value;
                    number -= keyvalue.Key;
                }
            }
            return roman;
        }
    }
}
