using System;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public static class AstarMath
	{
		private static Unity.Mathematics.Random GlobalRandom = Unity.Mathematics.Random.CreateFromIndex(0u);

		private static object GlobalRandomLock = new object();

		public static float ThreadSafeRandomFloat()
		{
			lock (GlobalRandomLock)
			{
				return GlobalRandom.NextFloat();
			}
		}

		public static float2 ThreadSafeRandomFloat2()
		{
			lock (GlobalRandomLock)
			{
				return GlobalRandom.NextFloat2();
			}
		}

		public static long SaturatingConvertFloatToLong(float v)
		{
			if (!(v > 9.223372E+18f))
			{
				return (long)v;
			}
			return long.MaxValue;
		}

		public static float MapTo(float startMin, float startMax, float targetMin, float targetMax, float value)
		{
			return Mathf.Lerp(targetMin, targetMax, Mathf.InverseLerp(startMin, startMax, value));
		}

		private static int Bit(int a, int b)
		{
			return (a >> b) & 1;
		}

		public static Color IntToColor(int i, float a)
		{
			int num = Bit(i, 2) + Bit(i, 3) * 2 + 1;
			int num2 = Bit(i, 1) + Bit(i, 4) * 2 + 1;
			int num3 = Bit(i, 0) + Bit(i, 5) * 2 + 1;
			return new Color((float)num * 0.25f, (float)num2 * 0.25f, (float)num3 * 0.25f, a);
		}

		public static Color HSVToRGB(float h, float s, float v)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = s * v;
			float num5 = h / 60f;
			float num6 = num4 * (1f - Math.Abs(num5 % 2f - 1f));
			if (num5 < 1f)
			{
				num = num4;
				num2 = num6;
			}
			else if (num5 < 2f)
			{
				num = num6;
				num2 = num4;
			}
			else if (num5 < 3f)
			{
				num2 = num4;
				num3 = num6;
			}
			else if (num5 < 4f)
			{
				num2 = num6;
				num3 = num4;
			}
			else if (num5 < 5f)
			{
				num = num6;
				num3 = num4;
			}
			else if (num5 < 6f)
			{
				num = num4;
				num3 = num6;
			}
			float num7 = v - num4;
			num += num7;
			num2 += num7;
			num3 += num7;
			return new Color(num, num2, num3);
		}

		public static float DeltaAngle(float angle1, float angle2)
		{
			float num = (angle2 - angle1 + MathF.PI) % (MathF.PI * 2f) - MathF.PI;
			return math.select(num, num + MathF.PI * 2f, num < -MathF.PI);
		}
	}
}
