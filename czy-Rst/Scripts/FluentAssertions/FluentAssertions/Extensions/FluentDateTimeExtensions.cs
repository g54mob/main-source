using System;
using System.Diagnostics;
using FluentAssertions.Common;

namespace FluentAssertions.Extensions
{
	[DebuggerNonUserCode]
	public static class FluentDateTimeExtensions
	{
		public static DateTime January(this int day, int year)
		{
			return new DateTime(year, 1, day);
		}

		public static DateTime February(this int day, int year)
		{
			return new DateTime(year, 2, day);
		}

		public static DateTime March(this int day, int year)
		{
			return new DateTime(year, 3, day);
		}

		public static DateTime April(this int day, int year)
		{
			return new DateTime(year, 4, day);
		}

		public static DateTime May(this int day, int year)
		{
			return new DateTime(year, 5, day);
		}

		public static DateTime June(this int day, int year)
		{
			return new DateTime(year, 6, day);
		}

		public static DateTime July(this int day, int year)
		{
			return new DateTime(year, 7, day);
		}

		public static DateTime August(this int day, int year)
		{
			return new DateTime(year, 8, day);
		}

		public static DateTime September(this int day, int year)
		{
			return new DateTime(year, 9, day);
		}

		public static DateTime October(this int day, int year)
		{
			return new DateTime(year, 10, day);
		}

		public static DateTime November(this int day, int year)
		{
			return new DateTime(year, 11, day);
		}

		public static DateTime December(this int day, int year)
		{
			return new DateTime(year, 12, day);
		}

		public static DateTime At(this DateTime date, TimeSpan time)
		{
			return date.Date + time;
		}

		public static DateTime At(this DateTime date, int hours, int minutes, int seconds = 0, int milliseconds = 0, int microseconds = 0, int nanoseconds = 0)
		{
			if ((microseconds < 0 || microseconds > 999) ? true : false)
			{
				throw new ArgumentOutOfRangeException("microseconds", "Valid values are between 0 and 999");
			}
			if ((nanoseconds < 0 || nanoseconds > 999) ? true : false)
			{
				throw new ArgumentOutOfRangeException("nanoseconds", "Valid values are between 0 and 999");
			}
			DateTime result = new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds, milliseconds, date.Kind);
			if (microseconds != 0)
			{
				result += microseconds.Microseconds();
			}
			if (nanoseconds != 0)
			{
				result += nanoseconds.Nanoseconds();
			}
			return result;
		}

		public static DateTimeOffset At(this DateTimeOffset date, int hours, int minutes, int seconds = 0, int milliseconds = 0, int microseconds = 0, int nanoseconds = 0)
		{
			if ((microseconds < 0 || microseconds > 999) ? true : false)
			{
				throw new ArgumentOutOfRangeException("microseconds", "Valid values are between 0 and 999");
			}
			if ((nanoseconds < 0 || nanoseconds > 999) ? true : false)
			{
				throw new ArgumentOutOfRangeException("nanoseconds", "Valid values are between 0 and 999");
			}
			DateTimeOffset result = new DateTimeOffset(date.Year, date.Month, date.Day, hours, minutes, seconds, milliseconds, date.Offset);
			if (microseconds != 0)
			{
				result += microseconds.Microseconds();
			}
			if (nanoseconds != 0)
			{
				result += nanoseconds.Nanoseconds();
			}
			return result;
		}

		public static DateTime AsUtc(this DateTime dateTime)
		{
			return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
		}

		public static DateTime AsLocal(this DateTime dateTime)
		{
			return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
		}

		public static DateTime Before(this TimeSpan timeDifference, DateTime sourceDateTime)
		{
			return sourceDateTime - timeDifference;
		}

		public static DateTime After(this TimeSpan timeDifference, DateTime sourceDateTime)
		{
			return sourceDateTime + timeDifference;
		}

		public static int Nanosecond(this DateTime self)
		{
			return self.Ticks.Ticks().Nanoseconds();
		}

		public static int Nanosecond(this DateTimeOffset self)
		{
			return self.Ticks.Ticks().Nanoseconds();
		}

		public static DateTime AddNanoseconds(this DateTime self, long nanoseconds)
		{
			return self + nanoseconds.Nanoseconds();
		}

		public static DateTimeOffset AddNanoseconds(this DateTimeOffset self, long nanoseconds)
		{
			return self + nanoseconds.Nanoseconds();
		}

		public static int Microsecond(this DateTime self)
		{
			return self.Ticks.Ticks().Microseconds();
		}

		public static int Microsecond(this DateTimeOffset self)
		{
			return self.Ticks.Ticks().Microseconds();
		}

		public static DateTime AddMicroseconds(this DateTime self, long microseconds)
		{
			return self + microseconds.Microseconds();
		}

		public static DateTimeOffset AddMicroseconds(this DateTimeOffset self, long microseconds)
		{
			return self + microseconds.Microseconds();
		}

		public static DateTimeOffset WithOffset(this DateTime self, TimeSpan offset)
		{
			return self.ToDateTimeOffset(offset);
		}
	}
}
