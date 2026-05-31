using System;
using UnityEngine;

[Serializable]
public class DeviceDataTime
{
	[Header("Time")]
	public int hour;

	public int minute;

	[Header("Date")]
	public int day;

	public int month;

	public int year;

	public int lastTimeMinute;

	public static readonly int[] daysInMonths;

	public void FunCheckTimeGlobal()
	{
	}

	private void UpdateTimeAndDate()
	{
	}

	private int GetDaysInMonth(int year, int month)
	{
		return 0;
	}

	private bool IsLeapYear(int year)
	{
		return false;
	}

	public string SaveToString()
	{
		return null;
	}

	public static DeviceDataTime LoadFromString(string data)
	{
		return null;
	}
}
