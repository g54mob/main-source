using System;
using System.Globalization;
using System.Xml;

namespace Newtonsoft.Json.Bson.Utilities
{
	internal static class DateTimeUtils
	{
		internal static readonly long InitialJavaScriptDateTicks;

		private const string IsoDateFormat = "yyyy-MM-ddTHH:mm:ss.FFFFFFFK";

		private const int DaysPer100Years = 36524;

		private const int DaysPer400Years = 146097;

		private const int DaysPer4Years = 1461;

		private const int DaysPerYear = 365;

		private const long TicksPerDay = 864000000000L;

		private static readonly int[] DaysToMonth365;

		private static readonly int[] DaysToMonth366;

		static DateTimeUtils()
		{
		}

		public static TimeSpan GetUtcOffset(this DateTime d)
		{
			return default(TimeSpan);
		}

		public static XmlDateTimeSerializationMode ToSerializationMode(DateTimeKind kind)
		{
			return default(XmlDateTimeSerializationMode);
		}

		internal static DateTime EnsureDateTime(DateTime value, DateTimeZoneHandling timeZone)
		{
			return default(DateTime);
		}

		private static DateTime SwitchToLocalTime(DateTime value)
		{
			return default(DateTime);
		}

		private static DateTime SwitchToUtcTime(DateTime value)
		{
			return default(DateTime);
		}

		private static long ToUniversalTicks(DateTime dateTime)
		{
			return 0L;
		}

		private static long ToUniversalTicks(DateTime dateTime, TimeSpan offset)
		{
			return 0L;
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, TimeSpan offset)
		{
			return 0L;
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime)
		{
			return 0L;
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, bool convertToUtc)
		{
			return 0L;
		}

		private static long UniversialTicksToJavaScriptTicks(long universialTicks)
		{
			return 0L;
		}

		internal static DateTime ConvertJavaScriptTicksToDateTime(long javaScriptTicks)
		{
			return default(DateTime);
		}

		internal static bool TryParseDateTimeIso(string text, DateTimeZoneHandling dateTimeZoneHandling, out DateTime dt)
		{
			dt = default(DateTime);
			return false;
		}

		private static DateTime CreateDateTime(DateTimeParser dateTimeParser)
		{
			return default(DateTime);
		}

		internal static bool TryParseDateTime(string s, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out DateTime dt)
		{
			dt = default(DateTime);
			return false;
		}

		private static bool TryParseMicrosoftDate(string text, out long ticks, out TimeSpan offset, out DateTimeKind kind)
		{
			ticks = default(long);
			offset = default(TimeSpan);
			kind = default(DateTimeKind);
			return false;
		}

		private static bool TryParseDateTimeMicrosoft(string text, DateTimeZoneHandling dateTimeZoneHandling, out DateTime dt)
		{
			dt = default(DateTime);
			return false;
		}

		private static bool TryParseDateTimeExact(string text, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out DateTime dt)
		{
			dt = default(DateTime);
			return false;
		}

		private static bool TryReadOffset(string offsetText, int startIndex, out TimeSpan offset)
		{
			offset = default(TimeSpan);
			return false;
		}
	}
}
