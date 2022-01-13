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

        [Fact]
        public void BabysitterWorksOneHourAfterBedtimeAndBeforeMidnightAndReceives8Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 20, endTime = 21, bedTime = 19;

            Assert.Equal(8, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Theory]
        [InlineData(17, 19, 17, 16)]
        [InlineData(18, 22, 17, 32)]
        [InlineData(20, 23, 19, 24)]
        public void BabysitterWorksMultipleHoursAfterBedtimeAndBeforeMidnightAndReceives8DollarsPerHour(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Fact]
        public void BabysitterWorksOneHourAfterMidnightAndReceives16Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 0, endTime = 1, bedTime = 18;

            Assert.Equal(16, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

    }
}
