﻿using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("pl-PL")]
    public class PL_PLHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public PL_PLHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);

            this.InnerHolidays.Add(ChristianHolidays.Epiphany);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);

            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);

            this.InnerHolidays.Add(May3rdConstitutionDay);

            this.InnerHolidays.Add(ChristianHolidays.Pentecost);
            this.InnerHolidays.Add(ChristianHolidays.CorpusChristi);
            this.InnerHolidays.Add(ChristianHolidays.Assumption);
            this.InnerHolidays.Add(ChristianHolidays.AllSaints);

            this.InnerHolidays.Add(NationalIndependenceDay);

            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
            this.InnerHolidays.Add(ChristmasEveFrom2025);
        }

        private static Holiday may3rdConstitutionDay;

        public static Holiday May3rdConstitutionDay
        {
            get
            {
                if (may3rdConstitutionDay == null)
                {
                    may3rdConstitutionDay = new FixedHoliday("May 3rd Constitution Day", 5, 3);
                }
                return may3rdConstitutionDay;
            }
        }

        private static Holiday nationalIndependenceDay;

        public static Holiday NationalIndependenceDay
        {
            get
            {
                if (nationalIndependenceDay == null)
                {
                    nationalIndependenceDay = new FixedHoliday("National Independence Day", 11, 11);
                }
                return nationalIndependenceDay;
            }
        }

        private static Holiday christmasEveFrom2025;
        public static Holiday ChristmasEveFrom2025
        {
            get
            {
                if (christmasEveFrom2025 == null)
                {
                    christmasEveFrom2025 = new YearDependantHoliday(year => year >= 2025, new FixedHoliday("Christmas Eve", 12, 24));
                }
                return christmasEveFrom2025;
            }
        }
    }
}