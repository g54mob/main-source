using System;
using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public static class Maf
	{
		public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
		{
			smoothTime = Mathf.Max(0.0001f, smoothTime);
			float num = 2f / smoothTime;
			float num2 = num * deltaTime;
			float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
			float value = current - target;
			float num4 = target;
			float num5 = maxSpeed * smoothTime;
			value = Mathf.Clamp(value, 0f - num5, num5);
			target = current - value;
			float num6 = (currentVelocity + num * value) * deltaTime;
			currentVelocity = (currentVelocity - num * num6) * num3;
			float num7 = target + (value + num6) * num3;
			if (num4 - current > 0f == num7 > num4)
			{
				num7 = num4;
				currentVelocity = (num7 - num4) / deltaTime;
			}
			return num7;
		}

		public static double Clamp(double value, double min, double max)
		{
			return Math.Max(min, Math.Min(value, max));
		}

		public static float Deviate(float val, float percent)
		{
			return val + val * percent;
		}

		public static float MoveTowards(float current, float target, float maxDelta)
		{
			if (Mathf.Abs(target - current) <= maxDelta)
			{
				return target;
			}
			return current + Mathf.Sign(target - current) * maxDelta;
		}

		public static void Repeat(int times, Action<int> action, bool countDown = false)
		{
			if (countDown)
			{
				for (int num = times - 1; num >= 0; num--)
				{
					action(num);
				}
			}
			else
			{
				for (int i = 0; i < times; i++)
				{
					action(i);
				}
			}
		}

		public static void Repeat(int times, Action action)
		{
			for (int i = 0; i < times; i++)
			{
				action();
			}
		}

		public static float Reflect(float x, float ceil)
		{
			if (!(x > ceil))
			{
				return x;
			}
			return 1f - ceil - (x - ceil);
		}

		public static int FloorMod(int x, int m)
		{
			return (x % m + m) % m;
		}

		public static float FloorMod(float x, float m)
		{
			return (x % m + m) % m;
		}

		public static float Normalize(float f, float a, float b, bool clamp = true)
		{
			float num = (f - a) / (b - a);
			if (clamp)
			{
				num = Mathf.Clamp(num, 0f, 1f);
			}
			return num;
		}

		public static float Map(float f, float fromA, float fromB, float toA, float toB)
		{
			return Mathf.Lerp(toA, toB, Normalize(f, fromA, fromB));
		}

		public static int[] ToPalindrome(int[] array)
		{
			if (array.Length < 3)
			{
				return array;
			}
			int num = array.Length;
			int[] array2 = new int[num * 2 - 2];
			array.CopyTo(array2, 0);
			for (int i = 0; i < array2.Length - num; i++)
			{
				array2[i + num] = array[num - i - 2];
			}
			return array2;
		}

		public static double Lerp(double a, double b, double norm)
		{
			return a * (1.0 - norm) + b * norm;
		}

		public static float VolCurve(float f)
		{
			float num = 31.622776f;
			return (Mathf.Pow(num, f) - 1f) / (num - 1f);
		}

		public static List<bool> Bjorklund(int hits, int steps, bool startOnTrue = false, bool reverse = false)
		{
			List<bool> pattern = new List<bool>();
			if (steps == 0)
			{
				return pattern;
			}
			if (hits == 0)
			{
				for (int i = 0; i < steps; i++)
				{
					pattern.Add(item: false);
				}
				return pattern;
			}
			if (hits >= steps)
			{
				for (int i = 0; i < steps; i++)
				{
					pattern.Add(item: true);
				}
				return pattern;
			}
			List<int> counts = new List<int>();
			List<int> remainders = new List<int> { hits };
			int num = steps - hits;
			int num2 = 0;
			do
			{
				counts.Add((int)Mathf.Floor(num / remainders[num2]));
				remainders.Add(num % remainders[num2]);
				num = remainders[num2];
				num2++;
			}
			while (remainders[num2] > 1);
			counts.Add(num);
			int r = 0;
			Action<int> build = null;
			build = delegate(int lvl)
			{
				r++;
				if (lvl > -1)
				{
					for (int j = 0; j < counts[lvl]; j++)
					{
						build(lvl - 1);
					}
					if (remainders[lvl] != 0)
					{
						build(lvl - 2);
					}
				}
				else
				{
					switch (lvl)
					{
					case -1:
						pattern.Add(item: false);
						break;
					case -2:
						pattern.Add(item: true);
						break;
					}
				}
			};
			build(num2);
			if (startOnTrue)
			{
				while (!pattern[0])
				{
					bool item = pattern[pattern.Count - 1];
					pattern.RemoveAt(pattern.Count - 1);
					pattern.Insert(0, item);
				}
			}
			if (reverse)
			{
				pattern.Reverse();
			}
			return pattern;
		}

		public static bool IsWithin(float x, int min, int max)
		{
			if (x >= (float)min && x <= (float)max)
			{
				return true;
			}
			return false;
		}
	}
}
