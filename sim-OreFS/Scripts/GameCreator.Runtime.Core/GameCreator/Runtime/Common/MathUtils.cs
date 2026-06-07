using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class MathUtils
	{
		public static double Lerp(double a, double b, double t)
		{
			return LerpUnclamped(a, b, Clamp01(t));
		}

		public static double LerpUnclamped(double a, double b, double t)
		{
			return a + (b - a) * t;
		}

		public static double Eerp(double a, double b, double t)
		{
			return EerpUnclamped(a, b, Clamp01(t));
		}

		public static double EerpUnclamped(double a, double b, double t)
		{
			return Math.Pow(a, 1.0 - t) * Math.Pow(b, t);
		}

		public static float Lerp(float a, float b, float c, float t)
		{
			if (!(t <= 0.5f))
			{
				return Mathf.Lerp(b, c, t * 2f - 1f);
			}
			return Mathf.Lerp(a, b, t * 2f);
		}

		public static double Lerp(double a, double b, double c, double t)
		{
			if (!(t <= 0.5))
			{
				return Lerp(b, c, t * 2.0 - 1.0);
			}
			return Lerp(a, b, t * 2.0);
		}

		public static int Max(int a, int b, int c)
		{
			return Math.Max(Math.Max(a, b), c);
		}

		public static int Max(int a, int b, int c, int d)
		{
			return Math.Max(Math.Max(a, b), Math.Max(c, d));
		}

		public static float Max(float a, float b, float c)
		{
			return Math.Max(Math.Max(a, b), c);
		}

		public static float Max(float a, float b, float c, float d)
		{
			return Math.Max(Math.Max(a, b), Math.Max(c, d));
		}

		public static int Min(int a, int b, int c)
		{
			return Math.Min(Math.Min(a, b), c);
		}

		public static int Min(int a, int b, int c, int d)
		{
			return Math.Min(Math.Min(a, b), Math.Min(c, d));
		}

		public static float Min(float a, float b, float c)
		{
			return Math.Min(Math.Min(a, b), c);
		}

		public static float Min(float a, float b, float c, float d)
		{
			return Math.Min(Math.Min(a, b), Math.Min(c, d));
		}

		public static double Clamp01(double value)
		{
			if (!(value < 0.0))
			{
				if (value > 1.0)
				{
					return 1.0;
				}
				return value;
			}
			return 0.0;
		}

		public static float ExponentialDecay(float current, float target, float decay, float deltaTime)
		{
			return target + (current - target) * Mathf.Exp((0f - decay) * deltaTime);
		}
	}
}
