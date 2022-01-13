using System;

namespace SitterKata
{
    public class PaymentCalculator
    {
        const int PreBedTimePay = 12;

        public int CalculateEarnings(int startTime, int endTime, int bedTime)
        {
            return (endTime - startTime) * PreBedTimePay;
        }
    }
}
