using System;

namespace SitterKata
{
    public class PaymentCalculator
    {
        const int PreBedTimePay = 12;
        const int PostBedTimePay = 8;

        public int CalculateEarnings(int startTime, int endTime, int bedTime)
        {
            if(startTime > bedTime)
            {
                return PostBedTimePay;
            }

            return (endTime - startTime) * PreBedTimePay;
        }
    }
}
