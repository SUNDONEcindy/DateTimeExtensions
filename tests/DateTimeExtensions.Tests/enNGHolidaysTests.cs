// using System;
// using System.Linq;
// using DateTimeExtensions.WorkingDays;
// using DateTimeExtensions.WorkingDays.CultureStrategies;
// using NUnit.Framework;

// namespace DateTimeExtensions.Tests
// {
//     [TestFixture]
//     public class EnNGHolidaysTests
//     {
//         private readonly WorkingDayCultureInfo workingDayCultureInfo = new("en-NG");

//         [Test]
//         public void Can_Get_Strategy()
//         {
//             var strategy = workingDayCultureInfo.LocateHolidayStrategy(workingDayCultureInfo.Name, null);
//             Assert.That(strategy.GetType(), Is.EqualTo(typeof(EN_NGHolidayStrategy)));
//         }

//         [Test]
//         public void Assert_Holidays_Count()
//         {
//             var holidays = workingDayCultureInfo.Holidays;
//             Assert.That(holidays.Count(), Is.EqualTo(8));
//         }

//         [Test]
//         public void Assert_DemocracyDayHoliday_On_Sunday_Observed_On_Monday()
//         {
//             // 12-06-2022 Democracy day on a Sunday
//             var mondayAfterDemocracyDay = new DateTime(2022, 06, 13);
//             Assert.Multiple(() =>
//             {
//                 Assert.That(mondayAfterDemocracyDay.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
//                 Assert.That(mondayAfterDemocracyDay.IsWorkingDay(workingDayCultureInfo), Is.False);
//             });
//         }

//         [Test]
//         public void Assert_IndependenceDayHolidays_On_Sunday_Observed_On_Monday()
//         {
//             // 12-06-2022 Independence day on a Sunday
//             var mondayAfterIndependenceDay = new DateTime(2028, 10, 02);
//             Assert.Multiple(() =>
//             {
//                 Assert.That(mondayAfterIndependenceDay.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
//                 Assert.That(mondayAfterIndependenceDay.IsWorkingDay(workingDayCultureInfo), Is.False);
//             });
//         }

//         [Test]
//         public void Christmas_2033_Sunday_Is_Observed_Monday()
//         {
//             // Holiday's falling on Sunday are observed on the following monday.
//             // Christmas on a sunday should not be a holiday.
//             var christmasSunday = new DateTime(2033, 12, 25);
//             var christmasObserved = christmasSunday.AddDays(1);
//             Assert.That(christmasObserved.IsHoliday(workingDayCultureInfo), Is.True);
//         }

//         [Test]
//         public void Christmas_Sunday_Not_a_Holiday()
//         {
//             // Holiday's falling on Sunday are observed on the following monday.
//             // Christmas on a sunday should not be a holiday.
//             var christmasSunday = new DateTime(2022, 12, 25);
//             Assert.That(christmasSunday.IsWorkingDay(workingDayCultureInfo), Is.False);
//         }
//     }
// }

using System;
using System.Linq;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class EN_NGHolidayStrategyTests
    {
        private readonly WorkingDayCultureInfo workingDayCultureInfo = new("en-NG");

        [Test]
        public void StrategyResolution_Returns_EN_NGHolidayStrategy()
        {
            var strategy = workingDayCultureInfo.LocateHolidayStrategy(workingDayCultureInfo.Name, null);
            Assert.That(strategy, Is.TypeOf<EN_NGHolidayStrategy>());
        }

        [Test]
        public void Holidays_Collection_Count_Is_8()
        {
            var holidays = workingDayCultureInfo.Holidays;
            Assert.That(holidays.Count(), Is.EqualTo(8));
        }

        [Test]
        public void Christmas_On_Sunday_2022_And_BoxingDay_Collision_Behaviour()
        {
            // 2022: Christmas (25 Dec) is Sunday, Boxing Day (26 Dec) is Monday.
            // Verify both dates are present as holidays and final mapping for Dec 26 is Boxing Day.
            var year = 2022;
            var christmas = new DateTime(year, 12, 25);
            var boxingDay = new DateTime(year, 12, 26);

            var holidaysMap = new DateTime(year, 1, 1).AllYearHolidays(workingDayCultureInfo);

            Assert.Multiple(() =>
            {
                Assert.That(christmas.DayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
                Assert.That(holidaysMap.ContainsKey(christmas), Is.True, "Christmas (original date) should be present.");
                Assert.That(holidaysMap.ContainsKey(boxingDay), Is.True, "Boxing Day / observed slot should be present.");

                // According to current strategy implementation Boxing Day should be the entry for Dec 26.
                Assert.That(holidaysMap[christmas].Name, Is.EqualTo("Christmas"));
                Assert.That(holidaysMap[boxingDay].Name, Is.EqualTo("Boxing Day"));

                // Both dates should be treated as non-working (holidays / weekend)
                Assert.That(christmas.IsWorkingDay(workingDayCultureInfo), Is.False);
                Assert.That(boxingDay.IsWorkingDay(workingDayCultureInfo), Is.False);
            });
        }

        [Test]
        public void Christmas_Sunday_2033_Is_Observed_On_Monday_2033()
        {
            // Verify a case where Christmas is on Sunday and the following Monday is considered a holiday.
            var christmasSunday = new DateTime(2033, 12, 25);
            var observed = christmasSunday.AddDays(1);

            Assert.Multiple(() =>
            {
                Assert.That(christmasSunday.DayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
                Assert.That(observed.IsHoliday(workingDayCultureInfo), Is.True, "Following Monday should be observed as a holiday.");
            });
        }

        [Test]
        public void Assert_DemocracyDayHoliday_On_Sunday_Observed_On_Monday()
        {
            // 12-06-2022 Democracy day on a Sunday
            var mondayAfterDemocracyDay = new DateTime(2022, 06, 13);
            Assert.Multiple(() =>
            {
                Assert.That(mondayAfterDemocracyDay.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
                Assert.That(mondayAfterDemocracyDay.IsWorkingDay(workingDayCultureInfo), Is.False);
            });
        }

        [Test]
        public void Assert_IndependenceDayHolidays_On_Sunday_Observed_On_Monday()
        {
            // 12-06-2022 Independence day on a Sunday
            var mondayAfterIndependenceDay = new DateTime(2028, 10, 02);
            Assert.Multiple(() =>
            {
                Assert.That(mondayAfterIndependenceDay.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
                Assert.That(mondayAfterIndependenceDay.IsWorkingDay(workingDayCultureInfo), Is.False);
            });
        }
    }
}
