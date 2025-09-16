using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-GT")]
    public class ES_GTHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_GTHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.MaundyThursday); // Jueves Santo
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday); // Viernes Santo
            this.InnerHolidays.Add(ChristianHolidays.EasterSaturday); // Sábado de Gloria
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay); // Día del Trabajo
            this.InnerHolidays.Add(MothersDay);
            this.InnerHolidays.Add(ChristianHolidays.Assumption); // Feriado Ciudad Capital Guatemala
            this.InnerHolidays.Add(ChristianHolidays.DayOfTheDead);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.ChristmasEve);
            this.InnerHolidays.Add(GlobalHolidays.NewYearsEve);
            this.InnerHolidays.Add(IndependenceDay); // Día de la Independencia
            this.InnerHolidays.Add(RevolutionDay); // Día de la Revolución
            this.InnerHolidays.Add(ArmyDay); // Día del Ejército
            this.InnerHolidays.Add(AllSaintsDay); // Día de Todos los Santos
        }

        private static Holiday _mothersDay;

        private static Holiday _independenceDay;

        private static Holiday _revolutionDay;

        private static Holiday _armyDay;

        private static Holiday _allSaintsDay;

        public static Holiday MothersDay
        {
            get
            {
                if (_mothersDay == null)
                {
                    _mothersDay = new FixedHoliday("Día de la Madre", 5, 10);
                }

                return _mothersDay;
            }
        }

        public static Holiday IndependenceDay
        {
            get
            {
                if (_independenceDay == null)
                {
                    _independenceDay = new FixedHoliday("Día de la Independencia", 9, 15);
                }

                return _independenceDay;
            }
        }

        public static Holiday RevolutionDay
        {
            get
            {
                if (_revolutionDay == null)
                {
                    _revolutionDay = new FixedHoliday("Día de la Revolución", 10, 20);
                }

                return _revolutionDay;
            }
        }

        public static Holiday ArmyDay
        {
            get
            {
                if (_armyDay == null)
                {
                    _armyDay = new FixedHoliday("Día del Ejercito", 6, 30);
                }

                return _armyDay;
            }
        }

        public static Holiday AllSaintsDay
        {
            get
            {
                if (_allSaintsDay == null)
                {
                    _allSaintsDay = new FixedHoliday("Día de Todos los Santos", 11, 1);
                }

                return _allSaintsDay;
            }
        }
    }
}