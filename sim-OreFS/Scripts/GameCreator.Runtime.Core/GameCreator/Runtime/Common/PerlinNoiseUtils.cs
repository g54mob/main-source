using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class PerlinNoiseUtils
	{
		private static readonly float SCALAR;

		private static readonly int[] PERMUTATIONS;

		static PerlinNoiseUtils()
		{
			SCALAR = Mathf.Sqrt(2f);
			PERMUTATIONS = new int[512];
			int[] array = new int[256];
			for (int i = 0; i < 256; i++)
			{
				array[i] = i;
			}
			System.Random random = new System.Random();
			for (int num = array.Length - 1; num > 0; num--)
			{
				int num2 = random.Next(num + 1);
				ref int reference = ref array[num];
				ref int reference2 = ref array[num2];
				int num3 = array[num2];
				int num4 = array[num];
				reference = num3;
				reference2 = num4;
			}
			for (int j = 0; j < 256; j++)
			{
				PERMUTATIONS[j] = (PERMUTATIONS[j + 256] = array[j]);
			}
		}

		public static float Get(float x, float y)
		{
			bool num = Mathf.Abs(x - Mathf.Floor(x)) < float.Epsilon || Mathf.Abs(x - Mathf.Ceil(x)) < float.Epsilon;
			bool flag = Mathf.Abs(y - Mathf.Floor(y)) < float.Epsilon || Mathf.Abs(y - Mathf.Ceil(y)) < float.Epsilon;
			if (num && flag)
			{
				return 0f;
			}
			int num2 = Mathf.FloorToInt(x) & 0xFF;
			int num3 = Mathf.FloorToInt(y) & 0xFF;
			float num4 = x - Mathf.Floor(x);
			float num5 = y - Mathf.Floor(y);
			float t = Fade(num4);
			float t2 = Fade(num5);
			int num6 = PERMUTATIONS[num2] + num3;
			int num7 = PERMUTATIONS[num2] + num3 + 1;
			int num8 = PERMUTATIONS[num2 + 1] + num3;
			int num9 = PERMUTATIONS[num2 + 1] + num3 + 1;
			float a = Gradient(PERMUTATIONS[num6], num4, num5);
			float b = Gradient(PERMUTATIONS[num8], num4 - 1f, num5);
			float a2 = Gradient(PERMUTATIONS[num7], num4, num5 - 1f);
			float b2 = Gradient(PERMUTATIONS[num9], num4 - 1f, num5 - 1f);
			float a3 = Lerp(a, b, t);
			float b3 = Lerp(a2, b2, t);
			return Lerp(a3, b3, t2) * SCALAR;
		}

		private static float Fade(float t)
		{
			return t * t * t * (t * (t * 6f - 15f) + 10f);
		}

		private static float Lerp(float a, float b, float t)
		{
			return a + t * (b - a);
		}

		private static float Gradient(int hash, float x, float y)
		{
			int num = hash & 7;
			float num2 = ((num < 4) ? x : y);
			float num3 = ((num < 4) ? y : x);
			return (((num & 1) == 0) ? num2 : (0f - num2)) + (((num & 2) == 0) ? num3 : (0f - num3));
		}
	}
}
