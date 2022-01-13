using System;

namespace SitterKata
{
    public class PaymentCalculator
    {
        const int PreBedTimePay = 12;
        const int PostBedTimePay = 8;
        const int AfterMidnightPay = 16;
        const int FivePM = 17;

        private int hoursBeforeBedTime = 0;
        private int hoursAfterBedTime = 0;
        private int hoursAfterMidNight = 0;

        public int CalculateEarnings(int startTime, int endTime, int bedTime)
        {
            if (startTime != endTime)
            {
                //shift ends after midnight
                if (endTime < FivePM)
                {
                    //we know hours after midnight will equal endTime
                    //because endTime is less than 5pm (17) in 24 hour clock
                    if (startTime >= FivePM)
                    {
                        hoursAfterMidNight = endTime;
                    }
                    //start time and end time are after midnight. get hours worked
                    else
                    {
                        hoursAfterMidNight = (endTime - startTime);
                    }
                }
                //handle cases where we know sitter worked after bedTime
                if (endTime > bedTime)
                {
                    //only worked after bedTime
                    if (startTime > bedTime)
                    {
                        hoursAfterBedTime = (endTime - startTime);
                    }
                    //worked before and after bedTime
                    else
                    {
                        hoursBeforeBedTime = (bedTime - startTime);
                        hoursAfterBedTime = (endTime - bedTime);
                    }
                }
                //get hours worked before bedTime
                else if (startTime >= FivePM)
                {
                    if (endTime >= FivePM)
                    {
                        hoursBeforeBedTime = (endTime - startTime);
                    }
                    //worked before and after bedTime
                    else
                    {
                        //prevent negative hours before bedtime
                        if (startTime < bedTime)
                        {
                            hoursBeforeBedTime = (bedTime - startTime);
                        }
                        //make sure to subtract the greater of bedTime, startTime from 24
                        hoursAfterBedTime = 24 - Math.Max(bedTime, startTime);
                    }
                }
            }
            //using each hours value and the rate, calculate pay
            return (hoursBeforeBedTime * PreBedTimePay) +
                (hoursAfterBedTime * PostBedTimePay) +
                (hoursAfterMidNight * AfterMidnightPay);
        }
    }
}