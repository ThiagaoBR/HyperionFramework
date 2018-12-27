using System;

namespace System
{
    /// <summary>
    /// Datetime Helper extensions
    /// </summary>
    /// <example>https://github.com/robvolk/Helpers.Net/blob/master/Src/Helpers.Net/DateTimeExtensions.cs</example>
    public static class DateTimeExtensions
    {
        public static string toStringFormat(this DateTime date, string format = "ddd MMM dd")
        {
            return date.ToString(format);
        }

        public static DateTime ToLocalTime(this DateTime utcTime, string timezone)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);
        }

        public static TimeSpan Elapsed(this DateTime date)
        {
            return DateTime.Now - date;
        }

        public static TimeSpan UtcElapsed(this DateTime date)
        {
            return DateTime.UtcNow - date;
        }

        public static string ToElapsedString(this TimeSpan elapsed)
        {
            Func<double, string, string> message = (unit, word) =>
            {
                var wholeUnit = Convert.ToInt32(unit);
                return string.Format("{0} {1}{2}", wholeUnit, word, wholeUnit.Plural());
            };

            if (elapsed.TotalSeconds < 60)
                return message(elapsed.TotalSeconds, "second");
            else if (elapsed.TotalMinutes < 60)
                return message(elapsed.TotalMinutes, "minute");
            else if (elapsed.TotalHours < 24)
                return message(elapsed.TotalHours, "hour");
            else if (elapsed.TotalDays < 30)
                return message(elapsed.TotalDays, "day");
            else if (elapsed.TotalDays < 365)
                return message(elapsed.TotalDays / 30, "month"); // assume 30 days in a month
            else
                return message(elapsed.TotalDays / 365, "year");
        }

        /// <summary>
        /// Returns "s" if the number is not equal to one. 
        /// </summary>
        public static string Plural(this int i)
        {
            return i == 1 ? string.Empty : "s";
        }

        /// <summary>
        /// Returns "s" if the number is not equal to one. 
        /// </summary>
        public static string Plural(this short i)
        {
            return i == 1 ? string.Empty : "s";
        }

    }
}
