using System;
using System.Globalization;

namespace Jundroo.Common.Utils
{
	public static class DateTimeUtility
	{
		public static string RelativeDate(this DateTime dt)
		{
			TimeSpan timeSpan = new TimeSpan(DateTime.UtcNow.Ticks - dt.Ticks);
			double num = System.Math.Abs(timeSpan.TotalSeconds);
			if (num < 60.0)
			{
				return "seconds ago";
			}
			if (num < 120.0)
			{
				return "a minute ago";
			}
			if (num < 2700.0)
			{
				return timeSpan.Minutes + " minutes ago";
			}
			if (num < 5400.0)
			{
				return "an hour ago";
			}
			if (num < 86400.0)
			{
				return timeSpan.Hours + " hours ago";
			}
			if (num < 172800.0)
			{
				return "yesterday";
			}
			if (num < 2592000.0)
			{
				return timeSpan.Days + " days ago";
			}
			if (num < 31104000.0)
			{
				int num2 = Convert.ToInt32(System.Math.Floor((double)timeSpan.Days / 30.0));
				if (num2 > 1)
				{
					return num2 + " months ago";
				}
				return "one month ago";
			}
			double num3 = (double)timeSpan.Days / 365.0;
			if (!(num3 <= 1.1))
			{
				return num3.ToString("n1", CultureInfo.InvariantCulture) + " years ago";
			}
			return "one year ago";
		}
	}
}
