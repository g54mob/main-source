using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class ListExtensions
	{
		public static T RandomItemSeed<T>(this List<T> list, int seed)
		{
			System.Random random = new System.Random(seed);
			if (list.Count == 0)
			{
				return default(T);
			}
			return list[random.Next(0, list.Count)];
		}

		public static T RandomItem<T>(this List<T> list)
		{
			System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
			return list.RandomItem(random);
		}

		public static T RandomItemProbability<T>(this List<T> list, Func<T, float> probabilityFunc, int seed)
		{
			return list.RandomItemProbability((T a, int i) => probabilityFunc(a), seed);
		}

		public static T RandomItemProbability<T>(this List<T> list, Func<T, float> probabilityFunc, System.Random rng)
		{
			return list.RandomItemProbability((T a, int i) => probabilityFunc(a), rng);
		}

		public static T RandomItemProbability<T>(this List<T> list, Func<T, int, float> probabilityFunc, int seed)
		{
			return list.RandomItemProbability(probabilityFunc, new System.Random(seed));
		}

		public static T RandomItemProbability<T>(this List<T> list, Func<T, int, float> probabilityFunc, System.Random rng)
		{
			float num = 0f;
			for (int i = 0; i < list.Count; i++)
			{
				if (probabilityFunc(list[i], i) > 0f)
				{
					num += probabilityFunc(list[i], i);
				}
			}
			float num2 = (float)rng.Next(Mathf.FloorToInt(num * 100000f)) / 100000f;
			float num3 = 0f;
			for (int j = 0; j < list.Count; j++)
			{
				num3 += ((probabilityFunc(list[j], j) > 0f) ? probabilityFunc(list[j], j) : 0f);
				if (num2 <= num3)
				{
					return list[j];
				}
			}
			return list.RandomItem(rng);
		}

		public static T RandomItem<T, TX>(this List<TX> list)
		{
			System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
			return list.RandomItem<T, TX>(random);
		}

		public static T RandomItemPositionSeed<T, TX>(this List<TX> list, Vector3 position)
		{
			System.Random random = new System.Random((int)(position.y * position.x));
			return list.RandomItem<T, TX>(random);
		}

		public static T RandomItemSeed<T, TX>(this List<TX> list, int seed)
		{
			System.Random random = new System.Random(seed);
			if (list.Count == 0)
			{
				return default(T);
			}
			return list.OfType<T>().ToList()[random.Next(0, list.Count)];
		}

		public static T RandomItem<T, TX>(this List<TX> list, System.Random random)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			return list.OfType<T>().ToArray()[random.Next(0, list.Count)];
		}

		public static T RandomItem<T>(this List<T> list, System.Random random)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			return list[random.Next(0, list.Count)];
		}

		public static IList<T> Shuffle<T>(this IList<T> list, System.Random rng)
		{
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int index = rng.Next(num + 1);
				T value = list[index];
				list[index] = list[num];
				list[num] = value;
			}
			return list;
		}
	}
}
