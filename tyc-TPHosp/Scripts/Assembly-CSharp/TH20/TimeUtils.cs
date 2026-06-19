#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine;

namespace TH20
{
	public static class TimeUtils
	{
		public static int SecondsInHour = 3600;

		public static int SecondsInDay = 86400;

		public static DateTime MinDateTimeUTC = new DateTime(0L, DateTimeKind.Utc);

		private static bool haveCheckedBrokenTimeZones = false;

		private static bool timeZonesAreBroken = false;

		public static float ProportionThroughDay01(double time)
		{
			int num = (int)(time / (double)SecondsInDay);
			return Mathf.Clamp01((float)((time - (double)(SecondsInDay * num)) / (double)SecondsInDay));
		}

		public static TimeParts TimePartsFromTime(double time)
		{
			TimeParts result = default(TimeParts);
			result.Days = (int)(time / (double)SecondsInDay);
			result.Hours = (int)(time / (double)SecondsInHour) % 24;
			result.Minutes = (int)(time / 60.0) % 60;
			result.Seconds = (int)time % 60;
			result.Remainder = time - (double)(result.Days * SecondsInDay + result.Hours * SecondsInHour + result.Minutes * 60 + result.Seconds);
			return result;
		}

		public static double TimeFromTimeParts(TimeParts timeParts)
		{
			return (double)(timeParts.Days * SecondsInDay + timeParts.Hours * SecondsInHour + timeParts.Minutes * 60 + timeParts.Seconds) + timeParts.Remainder;
		}

		public static void HoursAndMinutesFromTime(double time, out int hours, out int minutes)
		{
			hours = (int)(time / (double)SecondsInHour) % 24;
			minutes = (int)(time / 60.0) % 60;
		}

		public static string FormatTimeAsText(double time)
		{
			return ((int)(time / (double)SecondsInHour) % 24).ToString("00") + ":" + ((int)(time / 60.0) % 60).ToString("00");
		}

		public static DateTime FromUnixTime(uint unixTime)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);
		}

		private static void CheckForBrokenTimeZones()
		{
			if (!haveCheckedBrokenTimeZones)
			{
				try
				{
					_ = DateTime.Now;
				}
				catch (InvalidTimeZoneException ex)
				{
					Logging.Error("Broken time zone detected: {0}", ex);
					timeZonesAreBroken = true;
				}
				catch (TimeZoneNotFoundException ex2)
				{
					Logging.Error("Broken time zone detected: {0}", ex2);
					timeZonesAreBroken = true;
				}
				try
				{
					_ = DateTime.UtcNow;
				}
				catch (Exception ex3)
				{
					Logging.Error("Very broken time zone detected: {0}", ex3);
				}
				haveCheckedBrokenTimeZones = true;
			}
		}

		public static DateTime NowSafe()
		{
			CheckForBrokenTimeZones();
			if (timeZonesAreBroken)
			{
				return DateTime.UtcNow;
			}
			return DateTime.Now;
		}

		public static TimeZoneInfo LocalSafe()
		{
			CheckForBrokenTimeZones();
			if (timeZonesAreBroken)
			{
				return TimeZoneInfo.Utc;
			}
			return TimeZoneInfo.Local;
		}

		public static bool AreTimeZonesBroken()
		{
			CheckForBrokenTimeZones();
			return timeZonesAreBroken;
		}
	}
}
