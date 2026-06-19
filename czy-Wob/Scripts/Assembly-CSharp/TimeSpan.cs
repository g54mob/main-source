using System;
using UnityEngine;

[Serializable]
public class TimeSpan
{
	[SerializeField]
	private float seconds;

	[SerializeField]
	private int minutes;

	[SerializeField]
	private int hours;

	[SerializeField]
	private int days;

	[SerializeField]
	private int months;

	[SerializeField]
	private int years;

	public TimeSpan(float seconds = 0f, int minutes = 0, int hours = 0, int days = 0, int months = 0, int years = 0)
	{
		this.seconds = seconds;
		this.minutes = minutes;
		this.hours = hours;
		this.days = days;
		this.months = months;
		this.years = years;
		ResolveTime();
	}

	public float GetSeconds()
	{
		return seconds;
	}

	public int GetMinutes()
	{
		return minutes;
	}

	public int GetHours()
	{
		return hours;
	}

	public int GetDays()
	{
		return days;
	}

	public int GetMonths()
	{
		return months;
	}

	public int GetYears()
	{
		return years;
	}

	public float GetPercentageOfDay()
	{
		float num = hours;
		float num2 = minutes;
		float num3 = seconds;
		num2 += num3 / 60f;
		return (num + num2 / 60f) / 24f;
	}

	public void AddTime(float seconds = 0f, int minutes = 0, int hours = 0, int days = 0, int months = 0, int years = 0)
	{
		this.seconds += seconds;
		this.minutes += minutes;
		this.hours += hours;
		this.days += days;
		this.months += months;
		this.years += years;
		ResolveTime();
	}

	public float GetTotalSeconds()
	{
		return (((((float)(years * 12) + (float)months) * 30f + (float)days) * 24f + (float)hours) * 60f + (float)minutes) * 60f + seconds;
	}

	public float GetTotalMinutes()
	{
		return GetTotalSeconds() / 60f;
	}

	public float GetTotalHours()
	{
		return GetTotalMinutes() / 60f;
	}

	public float GetTotalDays()
	{
		return GetTotalHours() / 24f;
	}

	public float GetTotalMonths()
	{
		return GetTotalDays() / 30f;
	}

	public float GetTotalYears()
	{
		return GetTotalMonths() / 12f;
	}

	public float GetTotalRealWorldSeconds()
	{
		return GetTotalSeconds() / GlobalClock.standardTimescale;
	}

	private void ResolveTime()
	{
		while (seconds >= 60f)
		{
			seconds -= 60f;
			minutes++;
		}
		while (minutes >= 60)
		{
			minutes -= 60;
			hours++;
		}
		while (hours >= 24)
		{
			hours -= 24;
			days++;
		}
		while (days > 30)
		{
			days -= 30;
			months++;
		}
		while (months > 12)
		{
			months -= 12;
			years++;
		}
	}

	public TimeSpan GetCopy()
	{
		return new TimeSpan(seconds, minutes, hours, days, months, years);
	}

	public static TimeSpan operator +(TimeSpan a, TimeSpan b)
	{
		return new TimeSpan(a.seconds + b.seconds, a.minutes + b.minutes, a.hours + b.hours, a.days + b.days, a.months + b.months, a.years + b.years);
	}

	public static TimeSpan operator -(TimeSpan a, TimeSpan b)
	{
		return new TimeSpan(a.seconds - b.seconds, a.minutes - b.minutes, a.hours - b.hours, a.days - b.days, a.months - b.months, a.years - b.years);
	}

	public void UpdateFromExistingTimespan(TimeSpan b)
	{
		seconds = b.seconds;
		minutes = b.minutes;
		hours = b.hours;
		days = b.days;
		months = b.months;
		years = b.years;
	}

	public override int GetHashCode()
	{
		int.TryParse("seconds", out var result);
		int.TryParse("minutes", out var result2);
		int.TryParse("hours", out var result3);
		int.TryParse("days", out var result4);
		int.TryParse("months", out var result5);
		int.TryParse("years", out var result6);
		return (Mathf.RoundToInt(seconds * 1000f) ^ result) + (minutes ^ result2) + (hours ^ result3) + (days ^ result4) + (months ^ result5) + (years ^ result6);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		TimeSpan timeSpan = (TimeSpan)obj;
		if (timeSpan == null)
		{
			return false;
		}
		return this == timeSpan;
	}

	public static bool operator ==(TimeSpan a, TimeSpan b)
	{
		if (a.seconds == b.seconds && a.minutes == b.minutes && a.hours == b.hours && a.days == b.days && a.months == b.months && a.years == b.years)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(TimeSpan a, TimeSpan b)
	{
		return !(a == b);
	}

	public static bool operator >(TimeSpan a, TimeSpan b)
	{
		if (a.years != b.years)
		{
			return a.years > b.years;
		}
		if (a.months != b.months)
		{
			return a.months > b.months;
		}
		if (a.days != b.days)
		{
			return a.days > b.days;
		}
		if (a.hours != b.hours)
		{
			return a.hours > b.hours;
		}
		if (a.minutes != b.minutes)
		{
			return a.minutes > b.minutes;
		}
		return a.seconds > b.seconds;
	}

	public static bool operator <(TimeSpan a, TimeSpan b)
	{
		return !(a > b);
	}

	public static bool operator >=(TimeSpan a, TimeSpan b)
	{
		if (a > b || a == b)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(TimeSpan a, TimeSpan b)
	{
		if (a < b || a == b)
		{
			return true;
		}
		return false;
	}
}
