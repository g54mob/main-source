using System;
using UnityEngine;

public class TimeKeeper
{
	private static DateTime startTime;

	public static void SetStartTime()
	{
		startTime = DateTime.Now;
	}

	public static double GetMinutesPlayed()
	{
		double totalMinutes = (DateTime.Now - startTime).TotalMinutes;
		Debug.Log($"Minutes played = {totalMinutes}");
		return totalMinutes;
	}
}
