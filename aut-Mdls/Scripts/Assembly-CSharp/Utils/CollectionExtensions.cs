using System;
using System.Collections.Generic;

namespace Utils
{
	public static class CollectionExtensions
	{
		public static bool IsNullOrEmpty<T>(this T[] array)
		{
			if (array != null)
			{
				return array.Length == 0;
			}
			return true;
		}

		public static bool IsNullOrEmpty<T>(this IReadOnlyCollection<T> list)
		{
			if (list != null)
			{
				return list.Count == 0;
			}
			return true;
		}

		public static bool ForWrapped<T>(this IReadOnlyList<T> elements, int startAtIndex, Func<T, int, bool> predicate, out int endIndex)
		{
			if (elements.IsNullOrEmpty())
			{
				endIndex = -1;
				return false;
			}
			startAtIndex %= elements.Count;
			for (int i = startAtIndex; i < elements.Count; i++)
			{
				if (!predicate(elements[i], i))
				{
					endIndex = i;
					return true;
				}
			}
			for (int j = 0; j < startAtIndex; j++)
			{
				if (!predicate(elements[j], j))
				{
					endIndex = j;
					return true;
				}
			}
			endIndex = -1;
			return false;
		}
	}
}
