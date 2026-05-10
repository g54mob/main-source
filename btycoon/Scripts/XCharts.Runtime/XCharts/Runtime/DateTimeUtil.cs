using System;
using System.Collections.Generic;

namespace XCharts.Runtime
{
	public static class DateTimeUtil
	{
		private static readonly DateTime k_DateTime1970 = new DateTime(1970, 1, 1);

		public static readonly int ONE_SECOND = 1;

		public static readonly int ONE_MINUTE = ONE_SECOND * 60;

		public static readonly int ONE_HOUR = ONE_MINUTE * 60;

		public static readonly int ONE_DAY = ONE_HOUR * 24;

		public static readonly int ONE_MONTH = ONE_DAY * 30;

		public static readonly int ONE_YEAR = ONE_DAY * 365;

		public static readonly int MIN_TIME_SPLIT_NUMBER = 4;

		private static string s_YearDateFormatter = "yyyy";

		private static string s_HourDateFormatter = "HH:mm";

		private static string s_MinuteDateFormatter = "HH:mm";

		private static string s_SecondDateFormatter = "HH:mm:ss";

		public static int GetTimestamp()
		{
			return (int)(DateTime.Now - k_DateTime1970).TotalSeconds;
		}

		public static int GetTimestamp(DateTime time)
		{
			return (int)(time - k_DateTime1970).TotalSeconds;
		}

		public static DateTime GetDateTime(int timestamp)
		{
			long ticks = (long)timestamp * 10000000L;
			return k_DateTime1970.Add(new TimeSpan(ticks));
		}

		internal static string GetDateTimeFormatString(DateTime dateTime, double range)
		{
			string empty = string.Empty;
			if (range >= (double)(ONE_YEAR * MIN_TIME_SPLIT_NUMBER))
			{
				return dateTime.ToString(s_YearDateFormatter);
			}
			if (range >= (double)(ONE_MONTH * MIN_TIME_SPLIT_NUMBER))
			{
				return (dateTime.Month == 1) ? dateTime.ToString(s_YearDateFormatter) : XCSettings.lang.GetMonthAbbr(dateTime.Month);
			}
			if (range >= (double)(ONE_DAY * MIN_TIME_SPLIT_NUMBER))
			{
				return (dateTime.Day == 1) ? XCSettings.lang.GetMonthAbbr(dateTime.Month) : XCSettings.lang.GetDay(dateTime.Day);
			}
			if (range >= (double)(ONE_HOUR * MIN_TIME_SPLIT_NUMBER))
			{
				return dateTime.ToString(s_HourDateFormatter);
			}
			if (range >= (double)(ONE_MINUTE * MIN_TIME_SPLIT_NUMBER))
			{
				return dateTime.ToString(s_MinuteDateFormatter);
			}
			return dateTime.ToString(s_SecondDateFormatter);
		}

		internal static float UpdateTimeAxisDateTimeList(List<double> list, int minTimestamp, int maxTimestamp, int splitNumber)
		{
			list.Clear();
			int num = maxTimestamp - minTimestamp;
			if (num <= 0)
			{
				return 0f;
			}
			if (splitNumber <= 0)
			{
				splitNumber = 1;
			}
			DateTime dateTime = GetDateTime(minTimestamp);
			DateTime dateTime2 = GetDateTime(maxTimestamp);
			int num2 = 0;
			if (num >= ONE_YEAR * MIN_TIME_SPLIT_NUMBER)
			{
				int num3 = Math.Max(num / (splitNumber * ONE_YEAR), 1);
				DateTime time = new DateTime(dateTime.Year + 1, 1, 1);
				num2 = num3 * 365 * 24 * 3600;
				while (time.Ticks < dateTime2.Ticks)
				{
					list.Add(GetTimestamp(time));
					time = time.AddYears(num3);
				}
			}
			else if (num >= ONE_MONTH * MIN_TIME_SPLIT_NUMBER)
			{
				int num4 = Math.Max(num / (splitNumber * ONE_MONTH), 1);
				DateTime time2 = new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1);
				num2 = num4 * 30 * 24 * 3600;
				while (time2.Ticks < dateTime2.Ticks)
				{
					list.Add(GetTimestamp(time2));
					time2 = time2.AddMonths(num4);
				}
			}
			else if (num >= ONE_DAY * MIN_TIME_SPLIT_NUMBER)
			{
				num2 = GetTickSecond(num, splitNumber, ONE_DAY);
				int startTimestamp = minTimestamp - minTimestamp % num2 + num2;
				AddTickTimestamp(list, startTimestamp, maxTimestamp, num2);
			}
			else if (num >= ONE_HOUR * MIN_TIME_SPLIT_NUMBER)
			{
				num2 = GetTickSecond(num, splitNumber, ONE_HOUR);
				int startTimestamp2 = minTimestamp - minTimestamp % num2 + num2;
				AddTickTimestamp(list, startTimestamp2, maxTimestamp, num2);
			}
			else if (num >= ONE_MINUTE * MIN_TIME_SPLIT_NUMBER)
			{
				num2 = GetTickSecond(num, splitNumber, ONE_MINUTE);
				int startTimestamp3 = minTimestamp - minTimestamp % num2 + num2;
				AddTickTimestamp(list, startTimestamp3, maxTimestamp, num2);
			}
			else
			{
				num2 = GetTickSecond(num, splitNumber, ONE_SECOND);
				int startTimestamp4 = minTimestamp - minTimestamp % num2 + num2;
				AddTickTimestamp(list, startTimestamp4, maxTimestamp, num2);
			}
			return num2;
		}

		private static int GetTickSecond(int range, int splitNumber, int tickSecond)
		{
			int num = 0;
			if (splitNumber > 0)
			{
				num = Math.Max(range / (splitNumber * tickSecond), 1);
			}
			else
			{
				num = 1;
				int num2 = tickSecond;
				while (range / num2 > 8)
				{
					num++;
					num2 = num * tickSecond;
				}
			}
			return num * tickSecond;
		}

		private static void AddTickTimestamp(List<double> list, int startTimestamp, int maxTimestamp, int tickSecond)
		{
			while (startTimestamp <= maxTimestamp)
			{
				list.Add(startTimestamp);
				startTimestamp += tickSecond;
			}
		}
	}
}
