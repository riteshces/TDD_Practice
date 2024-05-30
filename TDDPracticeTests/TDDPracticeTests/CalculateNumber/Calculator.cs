namespace TestCasesProject.CalculatorCaseStudy
{
    public static class Calculator
    {
        public static int Add(string numbers)
        {
            int result = 0;
            string delimiter = "," , negativeNumbers="";

            if(string.IsNullOrEmpty(numbers))
            {
                throw new ArgumentNullException("Numbers must not be empty.");
            }
            

            if (numbers.StartsWith("//"))
            {
                int newlineIndex = numbers.IndexOf("\n");
                delimiter = numbers.Substring(2, newlineIndex - 2);
                numbers = numbers.Replace("//" + delimiter + "\n", "");
            }

            if (numbers.Contains(delimiter+"\n"))
            {
                throw new ArgumentException("Wrong input.");
            }
            else
            {
                numbers.Replace("\n", delimiter);
            }

            var inputNumbers = numbers.Split(delimiter);
            foreach (var inputNumber in inputNumbers)
            {
                if(Convert.ToInt32(inputNumber) <0)
                {
                    negativeNumbers += inputNumber;
                }
                result += Convert.ToInt32(inputNumber);
            }

            if(negativeNumbers.Length>0)
            {
                throw new ArgumentException("Negatives not allowed ("+negativeNumbers+")");
            }
            return result;
        }
    }
}
