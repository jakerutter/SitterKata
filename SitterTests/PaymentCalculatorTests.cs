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

            Assert.Equal(12, paymentCalc.CalculateEarnings());
        }
    }
}
