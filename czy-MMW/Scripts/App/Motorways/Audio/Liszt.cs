using System;
using System.Collections.Generic;
using System.Linq;

namespace Motorways.Audio
{
	public static class Liszt
	{
		public static T SafeGet<T>(this List<T> list, int pointer)
		{
			if (!Diagnostics.Verify(list.Count > 0))
			{
				return default(T);
			}
			return list[Maf.FloorMod(pointer, list.Count)];
		}

		public static int SafeIndex<T>(this List<T> list, int pointer)
		{
			if (!Diagnostics.Verify(list.Count > 0))
			{
				return -1;
			}
			return Maf.FloorMod(pointer, list.Count);
		}

		public static List<T> Make<T>(int size, Func<T> func)
		{
			return (from x in Enumerable.Range(0, size)
				select func()).ToList();
		}

		public static List<T> Make<T>(int size, Func<int, T> func)
		{
			return Enumerable.Range(0, size).Select((int x, int index) => func(index)).ToList();
		}

		public static List<T> From<T>(params T[] options)
		{
			List<T> list = new List<T>();
			for (int i = 0; i < options.Length; i++)
			{
				list.Add(options[i]);
			}
			return list;
		}

		public static List<T> Edit<T>(this List<T> list, Func<T, int, T> func)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = func(list[i], i);
			}
			return list;
		}

		public static List<T> Edit<T>(this List<T> list, Func<T, T> func)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = func(list[i]);
			}
			return list;
		}

		public static List<T> Flatten<T>(params List<T>[] options)
		{
			List<T> list = new List<T>();
			for (int i = 0; i < options.Length; i++)
			{
				list = list.Concat(options[i]).ToList();
			}
			return list;
		}

		public static T Pick<T>(this List<T> list, int seed = -1)
		{
			return list[Rando.Index(list, seed)];
		}

		public static List<T> Shuffle<T>(this List<T> list, D20 d20 = null, int seed = -1)
		{
			D20 d21 = d20 ?? new D20(seed);
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int index = d21.Rand.Next(num + 1);
				T value = list[index];
				list[index] = list[num];
				list[num] = value;
			}
			return list;
		}

		public static List<T> Palindrome<T>(this List<T> list)
		{
			List<T> list2 = list.ToList();
			list2.Reverse();
			list2.RemoveAt(0);
			return list.Concat(list2).ToList();
		}

		public static List<T> Rotate<T>(this List<T> list, int delta)
		{
			if (delta == 0 || list.Count == 0)
			{
				return list;
			}
			int num = Maf.FloorMod(delta, list.Count);
			List<T> list2 = list.ToList();
			List<T> range = list2.GetRange(num, list.Count - num);
			list2.RemoveRange(num, list2.Count - num);
			return range.Concat(list2).ToList();
		}

		public static List<T> Whittle<T>(this List<T> list, int newCount, int seed = -1)
		{
			if (newCount >= list.Count)
			{
				return list;
			}
			while (list.Count > newCount)
			{
				list.RemoveAt(Rando.Index(list, seed));
			}
			return list;
		}
	}
}
