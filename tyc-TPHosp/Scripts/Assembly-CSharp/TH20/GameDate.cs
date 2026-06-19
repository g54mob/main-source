using System;

namespace TH20
{
	public class GameDate : IComparable<GameDate>
	{
		private static readonly int[] DaysInMonth = new int[12]
		{
			31, 28, 31, 30, 31, 30, 31, 31, 30, 31,
			30, 31
		};

		public readonly int Year;

		public readonly int Month;

		public readonly int Day;

		public readonly int Hour;

		public readonly int Minute;

		public GameDate(int year, int month, int day)
		{
			Year = year;
			Month = month;
			Day = day;
			Hour = 0;
			Minute = 0;
		}

		public GameDate(int year, int month, int day, int hour, int minute)
		{
			Year = year;
			Month = month;
			Day = day;
			Hour = hour;
			Minute = minute;
		}

		public int CompareTo(GameDate other)
		{
			return this.AsTotalDays().CompareTo(other.AsTotalDays());
		}

		public override bool Equals(object obj)
		{
			if (obj is GameDate)
			{
				return this == (GameDate)obj;
			}
			return false;
		}

		public string ToString(bool showTime)
		{
			if (showTime)
			{
				return ToString();
			}
			return $"{Year:0000}-{Month:00}-{Day:00}";
		}

		public override string ToString()
		{
			return $"{Year:0000}-{Month:00}-{Day:00} {Hour:00}:{Minute:00}";
		}

		public override int GetHashCode()
		{
			return Year.GetHashCode() ^ Month.GetHashCode() ^ Day.GetHashCode() ^ Hour.GetHashCode() ^ Minute.GetHashCode();
		}

		public static bool operator ==(GameDate x, GameDate y)
		{
			if (x.Year == y.Year && x.Month == y.Month && x.Day == y.Day && x.Hour == y.Hour)
			{
				return x.Minute == y.Minute;
			}
			return false;
		}

		public static bool operator !=(GameDate x, GameDate y)
		{
			return !(x == y);
		}

		public static int GetDaysInMonth(int month)
		{
			return DaysInMonth[month];
		}

		public static string GetMonthShortName(int month)
		{
			return GameDateUtils.MonthCountToShortName(month);
		}

		public static string GetMonthShortNameUppercase(int month)
		{
			return GameDateUtils.MonthCountToShortName(month).ToUpper();
		}
	}
}
