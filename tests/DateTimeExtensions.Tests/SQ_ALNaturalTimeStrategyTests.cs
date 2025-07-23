using System;
using DateTimeExtensions.NaturalText;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class SQ_ALNaturalTimeTests
    {
        private NaturalTextCultureInfo al_ci = new NaturalTextCultureInfo("sq-AL");
        private DateTime fromTime = new DateTime(2024, 5, 8, 9, 41, 0);

        [Test]
        public void can_translate_to_natural_text_al()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, false, al_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 orë", naturalText);
        }

        [Test]
        public void can_translate_to_natural_text_rounded_al()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, al_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 orë", naturalText); 
        }

        [Test]
        public void can_translate_to_exact_natural_text_full_al()
        {
            var toTime = fromTime
                .AddSeconds(6)
                .AddMinutes(5)
                .AddHours(4)
                .AddDays(3)
                .AddMonths(2)
                .AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, al_ci);

            Assert.NotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 vite, 2 muaj, 3 ditë, 4 orë, 5 minuta, 6 sekonda", naturalText);
        }

        [Test]
        public void can_pluralize_years_al()
        {
            var toTime_plural = fromTime.AddYears(2);
            var toTime_single = fromTime.AddYears(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, al_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, al_ci);

            Assert.AreEqual("2 vite", naturalText_plural); 
            Assert.AreEqual("1 vit", naturalText_single);   
        }

        [Test]
        public void can_pluralize_months_al()
        {
            var toTime_plural = fromTime.AddMonths(2);
            var toTime_single = fromTime.AddMonths(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, al_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, al_ci);

            Assert.AreEqual("2 muaj", naturalText_plural); 
            Assert.AreEqual("1 muaj", naturalText_single); 
        }

        [Test]
        public void can_pluralize_days_al()
        {
            var toTime_plural = fromTime.AddDays(2);
            var toTime_single = fromTime.AddDays(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, al_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, al_ci);

            Assert.AreEqual("2 ditë", naturalText_plural);
            Assert.AreEqual("1 ditë", naturalText_single); 
        }
    }
}