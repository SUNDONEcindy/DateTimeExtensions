using System.Collections.Generic;
using DateTimeExtensions.Common;

// Albanian Holidays 

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("sq-AL")]

    public class SQ_ALHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public SQ_ALHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(SummerDay); // Dita e Veres in Albanian
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianOrthodoxHolidays.Easter);
            this.InnerHolidays.Add(NewruzDay); // Dita e Nevruzit Shia Muslim
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(MotherTheresaDay); // St. Theresa Day
            this.InnerHolidays.Add(AlphabetDay);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(LiberationDay);
            this.InnerHolidays.Add(NationalYouthDay);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(NewYearHoliday2); // second day of new year is a holiday in Albanian

        }
        private static Holiday newYearHoliday2;
        public static Holiday NewYearHoliday2
        {
            get
            {
                if (newYearHoliday2 == null)
                {
                    newYearHoliday2 = new FixedHoliday("NewYearHoliday2", 1, 2);
                }
                return newYearHoliday2;
            }
        }

        private static Holiday summerDay;
        public static Holiday SummerDay
        {
            get
            {
                if (summerDay == null)
                {
                    summerDay = new FixedHoliday("SummerDay", 3, 14);
                }
                return summerDay;
            }


        }

        // This is a Shia Muslim Holiday 
        private static Holiday newruzDay;
        public static Holiday NewruzDay
        {
            get
            {
                if (newruzDay == null)
                {
                    newruzDay = new FixedHoliday("NevruzDay", 3, 22);
                }
                return newruzDay;
            }
        }

        // Saint Theresa or known as Mother Theresa
        private static Holiday motherTheresaDay;
        public static Holiday MotherTheresaDay
        {
            get
            {
                if (motherTheresaDay == null)
                {
                    motherTheresaDay = new FixedHoliday("MotherTheresaDay", 9, 5);
                }
                return motherTheresaDay;
            }
        }

        private static Holiday alphabetDay;
        public static Holiday AlphabetDay
        {
            get
            {
                if (alphabetDay == null)
                {
                    alphabetDay = new FixedHoliday("AlphabetDay", 11, 22);
                }
                return alphabetDay;
            }


        }

        private static Holiday independenceDay;
        public static Holiday IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new FixedHoliday("IndipedenceDay", 11, 28);

                }
                return independenceDay;
            }
        }

        private static Holiday liberationDay;
        public static Holiday LiberationDay
        {
            get
            {
                if (liberationDay == null)
                {
                    liberationDay = new FixedHoliday("LiberationDay", 11, 29);
                }
                return liberationDay;
            }
        }

        private static Holiday nationalYouthDay;

        public static Holiday NationalYouthDay
        {
            get
            {
                if (nationalYouthDay == null)
                {
                    nationalYouthDay = new FixedHoliday("NationalYouthDay", 12, 8);
                }
                return nationalYouthDay;
            }
        }


        public IEnumerable<Holiday> GetHolidays()
        {
            return this.InnerHolidays;
        }
    
    }
}
