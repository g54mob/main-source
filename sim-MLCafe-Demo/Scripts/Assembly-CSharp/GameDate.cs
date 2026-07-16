using System;
using UnityEngine;

[Serializable]
public struct GameDate
{
	public int day;

	[Range(1f, 4f)]
	public byte week;

	[Range(1f, 12f)]
	public byte month;

	public byte year;

	public static GameDate Create(byte y, byte m, byte w, byte d)
	{
		return new GameDate
		{
			year = y,
			month = m,
			week = w,
			day = d
		};
	}

	public byte GetDayInMonth()
	{
		return (byte)(day + (week - 1) * 7);
	}

	public void NextDay()
	{
		day++;
	}

	public bool FirstDayOfWeek()
	{
		return day == 1;
	}

	public bool FirstDayOfTheMonth()
	{
		if (day == 1)
		{
			return week == 1;
		}
		return false;
	}

	public static bool IsSameDate(GameDate a, GameDate b)
	{
		if (a.year == b.year && a.month == b.month && a.week == b.week)
		{
			return a.day == b.day;
		}
		return false;
	}

	public static bool IsPastTheDate(GameDate currentTime, GameDate target)
	{
		bool num = currentTime.day > target.day;
		bool flag = currentTime.week > target.week;
		bool flag2 = currentTime.month > target.month;
		bool flag3 = currentTime.year > target.year;
		if (num && !flag && !flag2 && !flag3)
		{
			return true;
		}
		if (flag || flag2 || flag3)
		{
			return true;
		}
		return false;
	}

	public static bool IsDateBetweenMonths(GameDate current, GameDate from, GameDate to)
	{
		if (current.month >= from.month && current.month <= to.month)
		{
			return true;
		}
		return false;
	}

	public static bool IsDateBetweenExactDates(GameDate current, GameDate from, GameDate to)
	{
		if (current.year >= from.year && current.year <= to.year && current.month >= from.month && current.month <= to.month && current.week >= from.week && current.week <= to.week && current.day >= from.day)
		{
			return current.day <= to.day;
		}
		return false;
	}
}
