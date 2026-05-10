using System;

namespace MyBox
{
	public static class MyMath
	{
		public static void Swap<T>(ref T a, ref T b)
		{
		}

		public static float Clamp(this float value, float min, float max)
		{
			return 0f;
		}

		public static int Clamp(this int value, int min, int max)
		{
			return 0;
		}

		public static float Snap(this float val, float round)
		{
			return 0f;
		}

		public static float Round(this float val)
		{
			return 0f;
		}

		public static int RoundToInt(this float val)
		{
			return 0;
		}

		public static int Sign(IComparable x)
		{
			return 0;
		}

		public static bool Approximately(this float value, float compare)
		{
			return false;
		}

		public static bool InRange01(this float value)
		{
			return false;
		}

		public static bool InRange<T>(this T value, T closedLeft, T openRight)
		{
			return false;
		}

		public static bool InRange(this float value, RangedFloat range)
		{
			return false;
		}

		public static bool InRange(this int value, RangedInt range)
		{
			return false;
		}

		public static bool InRangeInclusive<T>(this T value, T closedLeft, T closedRight)
		{
			return false;
		}

		public static bool InRangeInclusive(this float value, RangedFloat range)
		{
			return false;
		}

		public static bool InRangeInclusive(this int value, RangedInt range)
		{
			return false;
		}

		public static float NotInRange(this float num, float min, float max)
		{
			return 0f;
		}

		public static int NotInRange(this int num, int min, int max)
		{
			return 0;
		}

		public static float ClosestPoint(this float num, float pointA, float pointB)
		{
			return 0f;
		}

		public static bool ClosestPointIsA(this float num, float pointA, float pointB)
		{
			return false;
		}
	}
}
