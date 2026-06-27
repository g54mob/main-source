using System;
using System.Globalization;
using FluentAssertions.Common;

namespace FluentAssertions.Formatting
{
	public class DateTimeOffsetValueFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			if (value is DateTime || value is DateTimeOffset)
			{
				return true;
			}
			return false;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			bool flag = false;
			DateTimeOffset dateTime2;
			if (value is DateTime dateTime)
			{
				dateTime2 = dateTime.ToDateTimeOffset();
			}
			else
			{
				dateTime2 = (DateTimeOffset)value;
				flag = true;
			}
			formattedGraph.AddFragment("<");
			bool flag2 = HasDate(dateTime2);
			if (flag2)
			{
				formattedGraph.AddFragment(dateTime2.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			}
			bool flag3 = HasTime(dateTime2);
			if (flag3)
			{
				if (flag2)
				{
					formattedGraph.AddFragment(" ");
				}
				if (HasNanoSeconds(dateTime2))
				{
					formattedGraph.AddFragment(dateTime2.ToString("HH:mm:ss.fffffff", CultureInfo.InvariantCulture));
				}
				else if (HasMicroSeconds(dateTime2))
				{
					formattedGraph.AddFragment(dateTime2.ToString("HH:mm:ss.ffffff", CultureInfo.InvariantCulture));
				}
				else if (HasMilliSeconds(dateTime2))
				{
					formattedGraph.AddFragment(dateTime2.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture));
				}
				else
				{
					formattedGraph.AddFragment(dateTime2.ToString("HH:mm:ss", CultureInfo.InvariantCulture));
				}
			}
			if (dateTime2.Offset > TimeSpan.Zero)
			{
				formattedGraph.AddFragment(" +");
				formatChild("offset", dateTime2.Offset, formattedGraph);
			}
			else if (dateTime2.Offset < TimeSpan.Zero)
			{
				formattedGraph.AddFragment(" ");
				formatChild("offset", dateTime2.Offset, formattedGraph);
			}
			else if (flag && (flag2 || flag3))
			{
				formattedGraph.AddFragment(" +0h");
			}
			if (!flag2 && !flag3)
			{
				formattedGraph.AddFragment("0001-01-01 00:00:00.000");
			}
			formattedGraph.AddFragment(">");
		}

		private static bool HasTime(DateTimeOffset dateTime)
		{
			if (dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0 && !HasMilliSeconds(dateTime) && !HasMicroSeconds(dateTime))
			{
				return HasNanoSeconds(dateTime);
			}
			return true;
		}

		private static bool HasDate(DateTimeOffset dateTime)
		{
			if (dateTime.Day == 1 && dateTime.Month == 1)
			{
				return dateTime.Year != 1;
			}
			return true;
		}

		private static bool HasMilliSeconds(DateTimeOffset dateTime)
		{
			return dateTime.Millisecond > 0;
		}

		private static bool HasMicroSeconds(DateTimeOffset dateTime)
		{
			return dateTime.Ticks % TimeSpan.FromMilliseconds(1.0).Ticks > 0;
		}

		private static bool HasNanoSeconds(DateTimeOffset dateTime)
		{
			return dateTime.Ticks % (TimeSpan.FromMilliseconds(1.0).Ticks / 1000) > 0;
		}
	}
}
