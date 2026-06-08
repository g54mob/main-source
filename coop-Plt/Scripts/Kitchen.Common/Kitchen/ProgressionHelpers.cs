using UnityEngine;

namespace Kitchen
{
	public static class ProgressionHelpers
	{
		public static float HourLength => 25f;

		public static float GetDayLength(int day)
		{
			return 100 + day / 3 * 25;
		}

		public static (int, int) ExpBreakdownForDay(int day)
		{
			int num = Mathf.FloorToInt((float)(day - 1) / 3f) * 3;
			return (day, 4 * num);
		}

		public static int ExpRewardForDay(int day)
		{
			return 0;
		}

		public static int ExpRequiredForLevel(int level)
		{
			return 100 * (int)Mathf.Pow(level + 1, 1.3f);
		}

		public static void AdvanceByExp(this ref SPlayerLevel current, int exp)
		{
			current.ExpProgress += exp;
			while (current.ExpProgress >= ExpRequiredForLevel(current.Level))
			{
				current.ExpProgress -= ExpRequiredForLevel(current.Level);
				current.Level++;
			}
		}

		public static float GetProgressPercent(this SPlayerLevel current)
		{
			return GetProgressPercent(current.Level, current.ExpProgress);
		}

		public static float GetProgressPercent(int level, int exp)
		{
			return (float)exp / (float)ExpRequiredForLevel(level);
		}
	}
}
