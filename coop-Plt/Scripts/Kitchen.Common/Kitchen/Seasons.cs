using System;
using System.Collections.Generic;
using KitchenData;

namespace Kitchen
{
	public static class Seasons
	{
		public static List<(Season, ((int, int), (int, int)))> Dates = new List<(Season, ((int, int), (int, int)))>
		{
			(Season.Halloween, ((10, 20), (11, 17))),
			(Season.Christmas, ((12, 10), (12, 31))),
			(Season.Christmas, ((1, 1), (1, 5)))
		};

		public static bool IsBetween(((int, int), (int, int)) dates)
		{
			return IsBetween(dates, DateTime.Now);
		}

		public static bool IsBetween(((int, int), (int, int)) dates, DateTime date)
		{
			int dayOfYear = date.DayOfYear;
			int dayOfYear2 = new DateTime(date.Year, dates.Item1.Item1, dates.Item1.Item2).DayOfYear;
			int dayOfYear3 = new DateTime(date.Year, dates.Item2.Item1, dates.Item2.Item2).DayOfYear;
			if (dayOfYear2 <= dayOfYear)
			{
				return dayOfYear <= dayOfYear3;
			}
			return false;
		}

		public static Season GetSeason()
		{
			return GetSeason(DateTime.Now);
		}

		public static Season GetSeason(DateTime date)
		{
			foreach (var date2 in Dates)
			{
				if (IsBetween(date2.Item2, date))
				{
					return date2.Item1;
				}
			}
			return Season.Normal;
		}
	}
}
