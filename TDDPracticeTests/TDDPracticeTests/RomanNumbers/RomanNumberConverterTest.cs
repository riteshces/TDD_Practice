using FluentAssertions;

namespace TDDPracticeTests.RomanNumbers
{
    public class RomanNumberConverterTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ConvertToRomanNumber_Should_Return_Roman_Numericals_When_Pass_Number(int number, string romanNumber)
        {
            //Act
            string result = NumberConverter.ConvertToRomanNumber(number);

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(romanNumber);
        }


        public static readonly IEnumerable<object[]> TestData = new[]
{
    new object[] { 1, "I" },
    new object[] { 2, "II" },
    new object[] { 3, "III" },
    new object[] { 4, "IV" },
    new object[] { 5, "V" },
    new object[] { 6, "VI" },
    new object[] { 7, "VII" },
    new object[] { 8, "VIII" },
    new object[] { 9, "IX" },
    new object[] { 10, "X" },
    new object[] { 12, "XII" },
    new object[] { 21, "XXI" },
    new object[] { 25, "XXV" },
    new object[] { 28, "XXVIII" },
    new object[] { 40, "XL" },
    new object[] { 49, "XLIX" },
    new object[] { 50, "L" },
    new object[] { 100, "C" },
    new object[] { 500, "D" },
    new object[] { 819, "DCCCXIX" },
    new object[] { 857, "DCCCLVII" },
    new object[] { 900, "CM" },
    new object[] { 1000, "M" }
};



        [Theory]
        [InlineData(0, "Number must no be zero.")]
        [InlineData(-1, "Number must no be negative.")]
        public void ConvertToRomanNumber_Should_Throw_Error_When_Convert_Zero_To_Roman_Numericals(int number, string expectedMessage)
        {
            //Act
            Action result = () => NumberConverter.ConvertToRomanNumber(number);

            //Assert
            result.Should().Throw<ArgumentException>().WithMessage(expectedMessage);
        }

    }
}
