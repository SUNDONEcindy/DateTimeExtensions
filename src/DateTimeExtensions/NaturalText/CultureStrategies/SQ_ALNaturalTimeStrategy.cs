using DateTimeExtensions.Common;
using System;

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    [Locale("sq-AL")]
    public class SQ_ALNaturalTimeStrategy : NaturalTimeStrategyBase
    {
        protected override string YearText => "vit";
        protected override string MonthText => "muaj";
        protected override string DayText => "ditë";
        protected override string HourText => "orë";
        protected override string MinuteText => "minutë";
        protected override string SecondText => "sekondë";

        protected override string Pluralize(string text, int value)
        {
            if (value == 1)
            {
                // Singular forms
                switch (text.ToLowerInvariant())
                {
                    case "vit":
                        return "një vit";
                    case "muaj":
                        return "një muaj";
                    case "ditë":
                        return "një ditë";
                    case "orë":
                        return "një orë";
                    case "minutë":
                        return "një minutë";
                    case "sekondë":
                        return "një sekondë";
                    default:
                        return text;
                }
            }
            else
            {
                // Plural forms
                switch (text.ToLowerInvariant())
                {
                    case "vit":
                        return "vite";
                    case "muaj":
                        return "muaj";
                    case "ditë":
                        return "ditë";
                    case "orë":
                        return "orë";
                    case "minutë":
                        return "minuta";
                    case "sekondë":
                        return "sekonda";
                    default:
                        return text;
                }
            }
        }
    }
}