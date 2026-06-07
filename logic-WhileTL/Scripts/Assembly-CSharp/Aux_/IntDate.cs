using System;

namespace Aux
{
	public struct IntDate : IComparable
	{
		public int year;

		public int month;

		public int day;

		public int hour;

		public int minute;

		public int second;

		public void Set(DateTime d)
		{
			year = d.Year;
			month = d.Month;
			day = d.Day;
			hour = d.Hour;
			minute = d.Minute;
			second = d.Second;
		}

		public void Set()
		{
			Set(DateTime.Now);
		}

		public DateTime Get()
		{
			return new DateTime(year, month, day, hour, minute, second);
		}

		public string AsString()
		{
			return Get().ToString();
		}

		public int CompareTo(object obj)
		{
			IntDate intDate = (IntDate)obj;
			int num = year.CompareTo(intDate.year);
			if (num != 0)
			{
				return num;
			}
			num = month.CompareTo(intDate.month);
			if (num != 0)
			{
				return num;
			}
			num = day.CompareTo(intDate.day);
			if (num != 0)
			{
				return num;
			}
			num = hour.CompareTo(intDate.hour);
			if (num != 0)
			{
				return num;
			}
			num = minute.CompareTo(intDate.minute);
			if (num != 0)
			{
				return num;
			}
			num = second.CompareTo(intDate.second);
			if (num != 0)
			{
				return num;
			}
			return 0;
		}

		public static bool operator <(IntDate a, IntDate b)
		{
			return a.CompareTo(b) < 0;
		}

		public static bool operator >(IntDate a, IntDate b)
		{
			return !(a < b);
		}
	}
}
