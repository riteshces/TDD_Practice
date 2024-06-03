using FluentAssertions;
using Xunit.Abstractions;

namespace TestCasesProject.CalculatorCaseStudy
{

    public class CalculatorTests : IDisposable
    {
        //dispose all running instances
        public void Dispose()
        {
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Add_Should_Calculate_Sum_Of_Numbers_Correctly(string numbers, int expectedResult)
        {
            //Act
            int result = Calculator.Add(numbers);

            //Assert
            result.Should().NotBe(0);
            result.Should().BePositive();
            result.Should().Be(expectedResult);
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

        [Fact]
        public void Add_Should_Throw_Exception_If_Numbers_Have_Comma_With_New_Line()
        {
            //arrange
            string numbers = "1,\n2";

            //Act
            Action action = () => Calculator.Add(numbers);

            //Assert
            action.Should().ThrowExactly<ArgumentException>().WithMessage("Wrong input.");
        }

        [Fact]
        public void Add_Should_Throw_Exception_If_Numbers_Contains_Negative_Number()
        {
            //Arrange
            string numbers = "-1,2";
            string expectedNegativeNumbers = "-1";

            //Act
            Action action = () => Calculator.Add(numbers);

            //Assert
            action.Should().ThrowExactly<ArgumentException>().WithMessage($"Negatives not allowed {expectedNegativeNumbers}");
        }

        [Fact]
        public void Add_Should_Throw_Null_Argument_Exception_If_Numbers_Null()
        {
            //Act
            Action action = () => Calculator.Add(null);

            //Assert
            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'Numbers must not be empty.')");
        }
    }
}
