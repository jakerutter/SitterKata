using System;
using SitterKata;
using Xunit;

namespace SitterTests
{
    public class PaymentCalculatorTests
    {
        [Fact]
        public void BabysitterWorksOneHourBeforeBedtimeAndReceives12Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 17, endTime = 18, bedTime = 21;

            Assert.Equal(12, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Theory]
        [InlineData(17, 19, 20, 24)]
        [InlineData(17, 20, 21, 36)]
        [InlineData(17, 21, 23, 48)]
        public void BabysitterWorksMultipleHoursBeforeBedtimeAndReceives12DollarsPerHour(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();
            
            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }
    }
}
