using System;
using System.Collections.Generic;

namespace Kitchen
{
	public static class ListExtensions
	{
		public static bool IsEqual<T>(this List<T> list1, List<T> list2) where T : IEquatable<T>
		{
			if (list1 == null)
			{
				return list2 == null;
			}
			if (list2 == null)
			{
				return false;
			}
			if (list1.Count != list2.Count)
			{
				return false;
			}
			for (int i = 0; i < list1.Count; i++)
			{
				if (!list1[i].Equals(list2[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static int GetCurrentIndex<T>(this List<T> options, T current, Func<T, T, bool> is_equal)
		{
			for (int i = 0; i < options.Count; i++)
			{
				if (is_equal(options[i], current))
				{
					return i;
				}
			}
			return -1;
		}

		public static List<T> MakeCopy<T>(this List<T> source, List<T> dest)
		{
			dest.Clear();
			foreach (T item in source)
			{
				dest.Add(item);
			}
			return dest;
		}

		public static void Fill<T>(this List<T> input, int count, T val = default(T))
		{
			input.Clear();
			for (int i = 0; i < count; i++)
			{
				input.Add(val);
			}
		}

		public static void StripDuplicates<T>(this List<T> input)
		{
			HashSet<T> hashSet = new HashSet<T>();
			for (int i = 0; i < input.Count; i++)
			{
				if (!hashSet.Add(input[i]))
				{
					input.RemoveAt(i--);
				}
			}
		}
	}
}
