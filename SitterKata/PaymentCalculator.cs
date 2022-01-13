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
            //shift ends after midnight
            if (endTime < 17)
            {
                if (startTime > 17)
                {
                    return endTime * AfterMidnightPay;
                }
                else
                {
                    return (endTime - startTime) * AfterMidnightPay;
                } 
            }

            if(startTime >= bedTime)
            {
                return (endTime - startTime) * PostBedTimePay;
            }

            if (endTime >= bedTime)
            {
                return (bedTime - startTime) * PreBedTimePay + (endTime - bedTime) * PostBedTimePay;
            }
            else
            {
                return (endTime - startTime) * PreBedTimePay;
            }
        }
    }
}