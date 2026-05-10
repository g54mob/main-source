using System;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class MathUtil
	{
		public static double Abs(double d)
		{
			if (!(d > 0.0))
			{
				return 0.0 - d;
			}
			return d;
		}

		public static double Clamp(double d, double min, double max)
		{
			if (d >= min && d <= max)
			{
				return d;
			}
			if (d < min)
			{
				return min;
			}
			return max;
		}

		public static bool Approximately(double a, double b)
		{
			return Math.Abs(b - a) < Math.Max(9.999999974752427E-07 * Math.Max(Math.Abs(a), Math.Abs(b)), Mathf.Epsilon * 8f);
		}

		public static double Clamp01(double value)
		{
			if (value < 0.0)
			{
				return 0.0;
			}
			if (value > 1.0)
			{
				return 1.0;
			}
			return value;
		}

		public static double Lerp(double a, double b, double t)
		{
			return a + (b - a) * Clamp01(t);
		}

		public static bool IsInteger(double value)
		{
			if (value == 0.0)
			{
				return true;
			}
			if (value >= -1.0 && value <= 1.0)
			{
				return false;
			}
			return Math.Abs(value % 1.0) <= 4.94E-322;
		}

		public static int GetPrecision(double value)
		{
			if (IsInteger(value))
			{
				return 0;
			}
			int num = 1;
			double value2 = value * (double)Mathf.Pow(10f, num);
			while (!IsInteger(value2) && num < 38)
			{
				num++;
				value2 = value * (double)Mathf.Pow(10f, num);
			}
			return num;
		}
	}
}
