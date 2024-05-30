using FluentAssertions;
using Xunit.Abstractions;

namespace TestCasesProject.CalculatorCaseStudy
{

    public class CalculatorTests 
    {
        private readonly ITestOutputHelper _output;
        public CalculatorTests(ITestOutputHelper output)
        {
            _output = output;
        }


        //dispose all running instances
        //public void Dispose()
        //{
        //}

        [Theory]
        [MemberData(nameof(TestData))]
        public void Return_Sum_Of_Numbers(string numbers, int expectedResult)
        {
            //Act
            int result = Calculator.Add(numbers);

            //Assert
            _output.WriteLine("Return sum of number is executed successfully.");
            result.Should().NotBe(0).And.BePositive().And.Be(expectedResult, "because they have same values");
        }

        public static IEnumerable<object[]> TestData => new[]
        {
            new object[]{ "1,2", 3 },
            new object[]{ "7,2", 9 },
            new object[]{ "1,2,5", 8 },
            new object[]{ "7,2,9,2", 20 },
            new object[]{ "7\n,2,9,2", 20 },
            new object[]{ "//;\n1;2", 3 },
            new object[]{"//~;\n1~;2~;3", 6}
        };

        [Theory]
        [InlineData("1,\n2")]
        public void Return_Exception_If_Numbers_Have_Comma_With_New_Line(string numbers)
        {
            //Act
            Action action = () => Calculator.Add(numbers);

            //Assert
            action.Should().ThrowExactly<ArgumentException>().WithMessage("Wrong input.");
        }


        [Theory]
        [InlineData("-1,2", "-1")]
        public void Return_Exception_If_Numbers_Contains_Negative_Number(string numbers, string expectedNegativeNumbers)
        {
            //Act
            Action action = () => Calculator.Add(numbers);

            //Assert
            action.Should().ThrowExactly<ArgumentException>().WithMessage("Negatives not allowed (" + expectedNegativeNumbers + ")");
        }

        [Fact]
        public void Return_Null_Argument_Exception_When_Numbers_Should_Null()
        {
            //Act
            Action action = () => Calculator.Add(null);

            //Assert
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'Numbers must not be empty.')");
        }
    }
}
