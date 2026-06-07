using System;
using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Audio
{
	public static class Rando
	{
		private static D20 d20 = new D20();

		public static float m(int seed = -1)
		{
			if (seed != -1)
			{
				return new D20(seed).Roll();
			}
			return d20.Roll();
		}

		public static float Range(float min, float max, int seed = -1)
		{
			if (seed != -1)
			{
				return Mathf.Lerp(min, max, new D20(seed).Roll());
			}
			return Mathf.Lerp(min, max, d20.Roll());
		}

		public static double Range(double min, double max, int seed = -1)
		{
			if (seed != -1)
			{
				return Maf.Lerp(min, max, new D20(seed).Rand.NextDouble());
			}
			return Maf.Lerp(min, max, d20.Rand.NextDouble());
		}

		public static int Range(int min, int max, int seed = -1)
		{
			if (seed != -1)
			{
				return new D20(seed).Rand.Next(min, max);
			}
			return d20.Rand.Next(min, max);
		}

		public static T Pick<T>(List<T> list)
		{
			return list[d20.Rand.Next(list.Count)];
		}

		public static T Pick<T>(params T[] options)
		{
			return options[d20.Rand.Next(options.Length)];
		}

		public static T PickSeeded<T>(int seed, List<T> list)
		{
			return list[Range(0, list.Count, seed)];
		}

		public static T PickSeeded<T>(int seed, params T[] options)
		{
			return options[Range(0, options.Length, seed)];
		}

		public static int Index<T>(List<T> list, int seed = -1)
		{
			return Range(0, list.Count, seed);
		}

		public static T EnumValue<T>(int truncateFromEnd = 0, int seed = -1)
		{
			D20 d = ((seed == -1) ? d20 : new D20(seed));
			Array values = Enum.GetValues(typeof(T));
			return (T)values.GetValue(d.Rand.Next(values.Length - truncateFromEnd));
		}

		public static void Repeat(int times, Action<int> action)
		{
			List<int> list = Numbers(times);
			for (int i = 0; i < times; i++)
			{
				action(list[i]);
			}
		}

		public static bool FlipCoin(float chance = 0.5f)
		{
			return d20.Luck(chance);
		}

		public static List<int> Numbers(int numbers, int lowestInt = 0)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < numbers; i++)
			{
				list.Add(i + lowestInt);
			}
			return list.Shuffle();
		}

		public static float Random(this Vector2 v2, int seed = -1)
		{
			return Range(v2.x, v2.y, seed);
		}

		public static float Random(this Vector2Int v2, int seed = -1)
		{
			return Range(v2.x, v2.y, seed);
		}
	}
}
