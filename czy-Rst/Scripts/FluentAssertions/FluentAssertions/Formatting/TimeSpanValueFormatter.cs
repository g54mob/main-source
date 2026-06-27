using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FluentAssertions.Formatting
{
	public class TimeSpanValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			return value is TimeSpan;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			TimeSpan timeSpan = (TimeSpan)value;
			if (timeSpan == TimeSpan.MinValue)
			{
				formattedGraph.AddFragment("min time span");
				return;
			}
			if (timeSpan == TimeSpan.MaxValue)
			{
				formattedGraph.AddFragment("max time span");
				return;
			}
			List<string> nonZeroFragments = GetNonZeroFragments(timeSpan);
			if (nonZeroFragments.Count == 0)
			{
				formattedGraph.AddFragment("default");
			}
			string text = ((timeSpan.Ticks >= 0) ? string.Empty : "-");
			if (nonZeroFragments.Count == 1)
			{
				formattedGraph.AddFragment(text + nonZeroFragments.Single());
			}
			else
			{
				formattedGraph.AddFragment(text + nonZeroFragments.JoinUsingWritingStyle());
			}
		}

		private static List<string> GetNonZeroFragments(TimeSpan timeSpan)
		{
			TimeSpan timeSpan2 = timeSpan.Duration();
			List<string> list = new List<string>();
			AddDaysIfNotZero(timeSpan2, list);
			AddHoursIfNotZero(timeSpan2, list);
			AddMinutesIfNotZero(timeSpan2, list);
			AddSecondsIfNotZero(timeSpan2, list);
			AddMilliSecondsIfNotZero(timeSpan2, list);
			AddMicrosecondsIfNotZero(timeSpan2, list);
			return list;
		}

		private static void AddMicrosecondsIfNotZero(TimeSpan timeSpan, List<string> fragments)
		{
			long num = timeSpan.Ticks % 10000;
			if (num > 0)
			{
				fragments.Add(((double)num * 0.1).ToString("0.0", CultureInfo.InvariantCulture) + "µs");
			}
		}

		private static void AddSecondsIfNotZero(TimeSpan timeSpan, List<string> fragments)
		{
			if (timeSpan.Seconds > 0)
			{
				string text = timeSpan.Seconds.ToString(CultureInfo.InvariantCulture);
				fragments.Add(text + "s");
			}
		}

		private static void AddMilliSecondsIfNotZero(TimeSpan timeSpan, List<string> fragments)
		{
			if (timeSpan.Milliseconds > 0)
			{
				string text = timeSpan.Milliseconds.ToString(CultureInfo.InvariantCulture);
				fragments.Add(text + "ms");
			}
		}

		private static void AddMinutesIfNotZero(TimeSpan timeSpan, List<string> fragments)
		{
			if (timeSpan.Minutes > 0)
			{
				fragments.Add(timeSpan.Minutes.ToString(CultureInfo.InvariantCulture) + "m");
			}
		}

		private static void AddHoursIfNotZero(TimeSpan timeSpan, List<string> fragments)
		{
			if (timeSpan.Hours > 0)
			{
				fragments.Add(timeSpan.Hours.ToString(CultureInfo.InvariantCulture) + "h");
			}
		}

		private static void AddDaysIfNotZero(TimeSpan timeSpan, List<string> fragments)
		{
			if (timeSpan.Days > 0)
			{
				fragments.Add(timeSpan.Days.ToString(CultureInfo.InvariantCulture) + "d");
			}
		}
	}
}
