using System;
using System.Collections.Generic;

namespace SuperTiled2Unity
{
	public static class EnumerableExtensions
	{
		public static bool IsEmpty<T>(this IEnumerable<T> array)
		{
			return false;
		}

		public static Dictionary<TKey, TElement> SafeToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer = null)
		{
			return null;
		}
	}
}
