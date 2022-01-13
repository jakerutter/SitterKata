using System;

namespace SitterKata
{
    public class PaymentCalculator
    {
        const int PreBedTimePay = 12;
        const int PostBedTimePay = 8;
        const int AfterMidnightPay = 16;

        public int CalculateEarnings(int startTime, int endTime, int bedTime)
        {

            if (endTime < 17)
            {
                return endTime * AfterMidnightPay;
            }

            if(startTime >= bedTime)
            {
                return (endTime - startTime) * PostBedTimePay;
            }

            return (endTime - startTime) * PreBedTimePay;
        }
    }
}
