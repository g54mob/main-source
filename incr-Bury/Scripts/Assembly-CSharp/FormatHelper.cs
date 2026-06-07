using UnityEngine;

public class FormatHelper
{
	public static string SecondsToMinuteString(float totalSeconds)
	{
		int num = Mathf.FloorToInt(totalSeconds / 60f);
		int num2 = Mathf.FloorToInt(totalSeconds % 60f);
		return $"{num:00}:{num2:00}";
	}

	public static string FormatTimeSmart(float seconds)
	{
		seconds = Mathf.Max(0f, seconds);
		int num = Mathf.FloorToInt(seconds / 3600f);
		int num2 = Mathf.FloorToInt(seconds % 3600f / 60f);
		int num3 = Mathf.FloorToInt(seconds % 60f);
		if (num > 0)
		{
			return $"{num}:{num2:00}:{num3:00}";
		}
		return $"{num2}:{num3:00}";
	}

	public static string FormatNumberWithCommmas(int _val)
	{
		return _val.ToString("N0");
	}

	public static string FormatNumberWithCommmas(long _val)
	{
		return _val.ToString("N0");
	}

	public static string FormatTimeSmartWithMs(float seconds)
	{
		seconds = Mathf.Max(0f, seconds);
		int num = Mathf.FloorToInt(seconds / 3600f);
		int num2 = Mathf.FloorToInt(seconds % 3600f / 60f);
		int num3 = Mathf.FloorToInt(seconds % 60f);
		int num4 = Mathf.FloorToInt((seconds - Mathf.Floor(seconds)) * 100f);
		if (num > 0)
		{
			return $"{num}:{num2:00}:{num3:00}.{num4:00}";
		}
		return $"{num2}:{num3:00}.{num4:00}";
	}
}
