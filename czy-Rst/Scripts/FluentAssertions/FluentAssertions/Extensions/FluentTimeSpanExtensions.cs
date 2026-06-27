using System;

namespace FluentAssertions.Extensions
{
	public static class FluentTimeSpanExtensions
	{
		public const long TicksPerMicrosecond = 10L;

		public const double TicksPerNanosecond = 0.01;

		public static TimeSpan Ticks(this int ticks)
		{
			return TimeSpan.FromTicks(ticks);
		}

		public static TimeSpan Ticks(this long ticks)
		{
			return TimeSpan.FromTicks(ticks);
		}

		public static int Nanoseconds(this TimeSpan self)
		{
			return (int)((double)(self.Ticks % 10) * 100.0);
		}

		public static TimeSpan Nanoseconds(this int nanoseconds)
		{
			return ((long)Math.Round((double)nanoseconds * 0.01)).Ticks();
		}

		public static TimeSpan Nanoseconds(this long nanoseconds)
		{
			return ((long)Math.Round((double)nanoseconds * 0.01)).Ticks();
		}

		public static double TotalNanoseconds(this TimeSpan self)
		{
			return (double)self.Ticks * 100.0;
		}

		public static int Microseconds(this TimeSpan self)
		{
			return (int)((double)(self.Ticks % 10000) * 0.1);
		}

		public static TimeSpan Microseconds(this int microseconds)
		{
			return ((long)microseconds * 10L).Ticks();
		}

		public static TimeSpan Microseconds(this long microseconds)
		{
			return (microseconds * 10).Ticks();
		}

		public static double TotalMicroseconds(this TimeSpan self)
		{
			return (double)self.Ticks * 0.1;
		}

		public static TimeSpan Milliseconds(this int milliseconds)
		{
			return TimeSpan.FromMilliseconds(milliseconds);
		}

		public static TimeSpan Milliseconds(this double milliseconds)
		{
			return TimeSpan.FromMilliseconds(milliseconds);
		}

		public static TimeSpan Seconds(this int seconds)
		{
			return TimeSpan.FromSeconds(seconds);
		}

		public static TimeSpan Seconds(this double seconds)
		{
			return TimeSpan.FromSeconds(seconds);
		}

		public static TimeSpan Seconds(this int seconds, TimeSpan offset)
		{
			return TimeSpan.FromSeconds(seconds).Add(offset);
		}

		public static TimeSpan Minutes(this int minutes)
		{
			return TimeSpan.FromMinutes(minutes);
		}

		public static TimeSpan Minutes(this double minutes)
		{
			return TimeSpan.FromMinutes(minutes);
		}

		public static TimeSpan Minutes(this int minutes, TimeSpan offset)
		{
			return TimeSpan.FromMinutes(minutes).Add(offset);
		}

		public static TimeSpan Hours(this int hours)
		{
			return TimeSpan.FromHours(hours);
		}

		public static TimeSpan Hours(this double hours)
		{
			return TimeSpan.FromHours(hours);
		}

		public static TimeSpan Hours(this int hours, TimeSpan offset)
		{
			return TimeSpan.FromHours(hours).Add(offset);
		}

		public static TimeSpan Days(this int days)
		{
			return TimeSpan.FromDays(days);
		}

		public static TimeSpan Days(this double days)
		{
			return TimeSpan.FromDays(days);
		}

		public static TimeSpan Days(this int days, TimeSpan offset)
		{
			return TimeSpan.FromDays(days).Add(offset);
		}

		public static TimeSpan And(this TimeSpan sourceTime, TimeSpan offset)
		{
			return sourceTime.Add(offset);
		}
	}
}
