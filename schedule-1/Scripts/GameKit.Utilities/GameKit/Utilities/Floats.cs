using System;

namespace GameKit.Utilities
{
	public static class Floats
	{
		private static Random _random;

		public static float SetIfOverTolerance(this float source, float tolerance, float value)
		{
			return 0f;
		}

		public static float SetIfUnderTolerance(this float source, float tolerance, float value)
		{
			return 0f;
		}

		public static float TimeRemainingValue(this float endTime)
		{
			return 0f;
		}

		public static int TimeRemainingValue(this float endTime, bool useFloor = true)
		{
			return 0;
		}

		public static string TimeRemainingText(this float value, byte segments, bool emptyOnZero = false)
		{
			return null;
		}

		public static float RandomInclusiveRange(float minimum, float maximum)
		{
			return 0f;
		}

		public static float Random01()
		{
			return 0f;
		}

		public static bool Near(this float a, float b, float tolerance = 0.01f)
		{
			return false;
		}

		public static float Clamp(float value, float min, float max, ref bool clamped)
		{
			return 0f;
		}

		public static float Variance(this float source, float variance)
		{
			return 0f;
		}

		public static void Variance(this float source, float variance, ref float result)
		{
		}

		public static float PreciseSign(float value)
		{
			return 0f;
		}

		public static bool InRange(this float source, float rangeMin, float rangeMax)
		{
			return false;
		}

		public static float RandomlyFlip(this float value)
		{
			return 0f;
		}
	}
}
