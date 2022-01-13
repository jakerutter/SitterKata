using System;

namespace SitterKata
{
    public class PaymentCalculator
    {
        const int PreBedTimePay = 12;
        const int PostBedTimePay = 8;
        const int AfterMidnightPay = 16;

        private int hoursBeforeBedTime = 0;
        private int hoursAfterBedTime = 0;
        private int hoursAfterMidNight = 0;

        public int CalculateEarnings(int startTime, int endTime, int bedTime)
        {
            //shift ends after midnight
            if (endTime < 17)
            {
                if (startTime > 17)
                {
                    hoursAfterMidNight = endTime;
                }
                else
                {
                    hoursAfterMidNight = (endTime - startTime);
                } 
            }

            if (endTime > bedTime)
            {
                if (startTime > bedTime)
                {
                    hoursAfterBedTime = (endTime - startTime);
                }
                else
                {
                    hoursBeforeBedTime = (bedTime - startTime);
                    hoursAfterBedTime = (endTime - bedTime);
                }
            }
            else if(startTime >= 17)
            {
                hoursBeforeBedTime = (endTime - startTime);
            }


            return (hoursBeforeBedTime * PreBedTimePay) +
                (hoursAfterBedTime * PostBedTimePay) +
                (hoursAfterMidNight * AfterMidnightPay);
        }
    }
}