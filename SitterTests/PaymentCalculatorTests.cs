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

        [Theory]
        [InlineData(0, 2, 20, 32)]
        [InlineData(0, 3, 17, 48)]
        [InlineData(0, 4, 19, 64)]
        public void BabysitterWorksMultipleHoursAfterMidnightAndReceives16DollarsPerHour(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Fact]
        public void BabysitterWorksZeroHoursBeforeBedtimeAndReceives0Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 17, endTime = 17, bedTime = 19;

            Assert.Equal(0, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Fact]
        public void BabysitterWorksZeroHoursAfterAfterBedtimeAndBeforeMidnightAndReceives0Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 18, endTime = 18, bedTime = 17;

            Assert.Equal(0, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Fact]
        public void BabysitterWorksZeroHoursAfterMidnightAndReceives0Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 1, endTime = 1, bedTime = 17;

            Assert.Equal(0, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Fact]
        public void BabysitterWorksOneHourBeforeAndOneHourAfterBedtimeAndReceives20Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 18, endTime = 20, bedTime = 19;

            Assert.Equal(20, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Fact]
        public void BabysitterWorksTwoHoursBeforeAndTwoHoursAfterBedtimeAndReceives40Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 17, endTime = 21, bedTime = 19;

            Assert.Equal(40, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Theory]
        [InlineData(17, 4, 21, 136)]
        [InlineData(17, 4, 22, 140)]
        [InlineData(17, 4, 19, 128)]
        public void BabysitterWorksAllPermittedHoursWithVariousBedTimes(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Theory]
        [InlineData(17, 4, 17, 120)]
        [InlineData(17, 4, 24, 148)]
        public void BabysitterWorksAllPermittedHoursWithVariousBedTimesEdgeCases(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Fact]
        public void BabysitterWorksOneHourAfterBedtimeAndBeforeMidnightAndOneHourAfterMidnightAndEarns24Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 23, endTime = 1, bedTime = 22;

            Assert.Equal(24, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Fact]
        public void BabysitterWorksToHoursAfterBedtimeAndBeforeMidnightAndTwoHoursAfterMidnightAndEarns48Dollars()
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            int startTime = 22, endTime = 2, bedTime = 22;

            Assert.Equal(48, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Theory]
        [InlineData(22, 24, 22, 16)]
        [InlineData(24, 2, 22, 32)]
        [InlineData(22, 24, 23, 20)]
        public void BabysitterWorksUpToOrAfterMidnightEdgeCaseAndIsPayedCorrectly(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Theory]
        [InlineData(6, 20, 19, -1)]  //Before 5pm
        [InlineData(25, 24, 22, -1)] //Over 24 hours
        [InlineData(-1, 24, 23, -1)] //Negative value
        public void BabysitterPassesInvalidStartTimeAndGetsNegativeOne(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Theory]
        [InlineData(17, 6, 19, -1)]  //Before 5pm
        [InlineData(17, 25, 19, -1)] //Over 24 hours
        [InlineData(17, -1, 19, -1)] //Negative value
        public void BabysitterPassesInvalidEndTimeAndGetsNegativeOne(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }

        [Theory]
        [InlineData(17, 24, 1, -1)]  //After midnight
        [InlineData(17, 24, 16, -1)] //Before 5pm
        [InlineData(17, 24, 25, -1)] //Over 24 hours
        [InlineData(17, 24, -1, -1)] //Negative value
        public void BabysitterPassesInvalidBedTimeAndGetsNegativeOne(int startTime, int endTime, int bedTime, int expected)
        {
            PaymentCalculator paymentCalc = new PaymentCalculator();

            Assert.Equal(expected, paymentCalc.CalculateEarnings(startTime, endTime, bedTime));
        }
    }
}