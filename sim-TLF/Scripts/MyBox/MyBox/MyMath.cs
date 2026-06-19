using System;
using JetBrains.Annotations;
using UnityEngine;

namespace MyBox
{
	[PublicAPI]
	public static class MyMath
	{
		public static void Swap<T>(ref T a, ref T b)
		{
			T val = b;
			T val2 = a;
			a = val;
			b = val2;
		}

		public static float Clamp(this float value, float min, float max)
		{
			return Mathf.Clamp(value, min, max);
		}

		public static int Clamp(this int value, int min, int max)
		{
			return Mathf.Clamp(value, min, max);
		}

		public static float Snap(this float val, float round)
		{
			return round * Mathf.Round(val / round);
		}

		public static float Round(this float val)
		{
			return Mathf.Round(val);
		}

		public static int RoundToInt(this float val)
		{
			return Mathf.RoundToInt(val);
		}

		public static int Sign(IComparable x)
		{
			return x.CompareTo(0);
		}

		public static bool Approximately(this float value, float compare)
		{
			return Mathf.Approximately(value, compare);
		}

		public static float RemapTo01(this float value, float min, float max)
		{
			return (value - min) * 1f / (max - min);
		}

		public static float RemapTo01(this float value, MinMaxFloat minMax)
		{
			return value.RemapTo01(minMax.Min, minMax.Max);
		}

		public static float Remap(this float value, float leftMin, float leftMax, float rightMin, float rightMax)
		{
			return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
		}

		public static bool InRange01(this float value)
		{
			return value.InRange(0f, 1f);
		}

		public static bool InRange<T>(this T value, T closedLeft, T openRight) where T : IComparable
		{
			if (value.CompareTo(closedLeft) >= 0)
			{
				return value.CompareTo(openRight) < 0;
			}
			return false;
		}

		public static bool InRange(this float value, RangedFloat range)
		{
			return value.InRange(range.Min, range.Max);
		}

		public static bool InRange(this int value, RangedInt range)
		{
			return value.InRange(range.Min, range.Max);
		}

		public static bool InRangeInclusive<T>(this T value, T closedLeft, T closedRight) where T : IComparable
		{
			if (value.CompareTo(closedLeft) >= 0)
			{
				return value.CompareTo(closedRight) <= 0;
			}
			return false;
		}

		public static bool InRangeInclusive(this float value, RangedFloat range)
		{
			return value.InRangeInclusive(range.Min, range.Max);
		}

		public static bool InRangeInclusive(this int value, RangedInt range)
		{
			return value.InRangeInclusive(range.Min, range.Max);
		}

		public static float NotInRange(this float num, float min, float max)
		{
			if (min > max)
			{
				float num2 = max;
				float num3 = min;
				min = num2;
				max = num3;
			}
			if (num < min || num > max)
			{
				return num;
			}
			float num4 = (max - min) / 2f;
			if (num > min)
			{
				if (!(num + num4 < max))
				{
					return max;
				}
				return min;
			}
			if (!(num - num4 > min))
			{
				return min;
			}
			return max;
		}

		public static int NotInRange(this int num, int min, int max)
		{
			return (int)((float)num).NotInRange((float)min, (float)max);
		}

		public static float ClosestPoint(this float num, float pointA, float pointB)
		{
			if (pointA > pointB)
			{
				float num2 = pointB;
				float num3 = pointA;
				pointA = num2;
				pointB = num3;
			}
			float num4 = (pointB - pointA) / 2f;
			if (!(num.NotInRange(pointA, pointB) + num4 >= pointB))
			{
				return pointA;
			}
			return pointB;
		}

		public static bool ClosestPointIsA(this float num, float pointA, float pointB)
		{
			return Mathf.Approximately(num.ClosestPoint(pointA, pointB), pointA);
		}
	}
}
