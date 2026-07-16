using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct GameTime
{
	[Range(0f, 60f)]
	public byte minute;

	[Range(0f, 24f)]
	public byte hour;

	public void Tick(byte tickAmount, byte maxMinutesAmount, byte maxHoursAmount, GameDate gameDate, UnityEvent OnTimeTickFinished = null)
	{
		minute += tickAmount;
		if (minute >= maxMinutesAmount)
		{
			minute = 0;
			hour++;
		}
		if (hour >= maxHoursAmount)
		{
			hour = 0;
			gameDate.NextDay();
		}
		OnTimeTickFinished?.Invoke();
	}

	public bool ReachedEndOfDay(byte endHour, byte startHour)
	{
		if (endHour < startHour)
		{
			if (hour >= endHour && hour < startHour)
			{
				return true;
			}
		}
		else if (hour >= endHour)
		{
			return true;
		}
		return false;
	}

	public static bool IsSameTime(GameTime a, GameTime b)
	{
		if (a.hour == b.hour)
		{
			return a.minute == b.minute;
		}
		return false;
	}

	public static bool IsPastTime(GameTime current, GameTime compare)
	{
		if (current.hour <= compare.hour)
		{
			if (current.hour == compare.hour)
			{
				return current.minute > compare.minute;
			}
			return false;
		}
		return true;
	}

	public static GameTime Time(byte hour)
	{
		return new GameTime
		{
			hour = hour,
			minute = 0
		};
	}

	public string GetTimeFormatted(bool englishFormat = false)
	{
		if (englishFormat)
		{
			return ((hour > 12) ? (hour - 12) : hour) + ":" + ((minute == 0) ? "00" : ((object)minute))?.ToString() + " " + ((hour <= 12) ? "am" : "pm");
		}
		return hour + ":" + ((minute == 0) ? "00" : ((object)minute));
	}
}
