using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_calculator
{
    public class StringCalculator
    {
        public int Add(string userInput)
        {
            int calculatedValue = 0;
            List<int> intList = new List<int>();

            //Split the string based on the separators
            var multiArraySeparatedNumbers = userInput.Split(new [] { "//", "#", ",", "\\n", "***", "!", "[", "]", "r", "h", "*" }, StringSplitOptions.None);

            foreach (var number in multiArraySeparatedNumbers)
            {
                int parsedInteger = 0;

                //Try parsing the string to an integer.
                if (!int.TryParse(number, out parsedInteger))
                {
                    //Convert the unparsed string to 0
                    //Console.WriteLine("Input " + number + " is not a valid integer number converting it to zero");
                    parsedInteger = 0;
                }
                //Check if the comma separated input value is a negative number
                if (parsedInteger < 0)
                    throw new ArgumentException("Negative numbers are not allowed in the input string " + parsedInteger);

                //If the comma separated integer value is greater than 1000, make it invalid and reset to zero
                if(parsedInteger > 1000)
                    parsedInteger = 0;
                intList.Add(parsedInteger);
                calculatedValue += parsedInteger;
            }

            Console.WriteLine("Calculated Numbers: " + string.Join(" + ", intList.ToArray()) + " = " + calculatedValue);

            //Return the calculated value
            return calculatedValue;
        }
    }
}
