using System;

namespace NSEipix
{
	public static class DateTimeExtension
	{
		private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static DateTime FromUnixTimeSeconds(this long unixTime)
		{
			DateTime epoch = Epoch;
			return epoch.AddSeconds(unixTime);
		}

		public static long ToUnixTimeSeconds(this DateTime date)
		{
			return Convert.ToInt64((date.ToUniversalTime() - Epoch).TotalSeconds);
		}

		public static DateTime FromUnixTimeMilliseconds(this long unixTime)
		{
			DateTime epoch = Epoch;
			return epoch.AddMilliseconds(unixTime);
		}

		public static long ToUnixTimeMilliseconds(this DateTime date)
		{
			return Convert.ToInt64((date.ToUniversalTime() - Epoch).TotalMilliseconds);
		}

		public static int DaysBetween(this DateTime date, DateTime lastDay)
		{
			return (int)(date.Date - lastDay.Date).TotalDays;
		}

		public static TimeSpan TimeToNextDay(this DateTime from)
		{
			return from.Date.AddDays(1.0) - from;
		}

		public static long Milisecounds()
		{
			return (long)(DateTime.UtcNow - Epoch).TotalMilliseconds;
		}
	}
}
