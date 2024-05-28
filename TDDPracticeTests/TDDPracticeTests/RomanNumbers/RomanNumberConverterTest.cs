using FluentAssertions;

namespace TDDPracticeTests.RomanNumbers
{
    public class RomanNumberConverterTest
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(12, "XII")]
        [InlineData(21, "XXI")]
        [InlineData(25, "XXV")]
        [InlineData(28, "XXVIII")]
        [InlineData(40, "XL")]
        [InlineData(49, "XLIX")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(819, "DCCCXIX")]
        [InlineData(857, "DCCCLVII")]
        [InlineData(900, "CM")]
        [InlineData(1000, "M")]
        public void Return_Roman_Numericals_When_Pass_Number(int number, string romanNumber)
        {
            //Act
            string result = new NumberConverter().ConvertToRomanNumber(number);

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(romanNumber);
        }
    }
}
