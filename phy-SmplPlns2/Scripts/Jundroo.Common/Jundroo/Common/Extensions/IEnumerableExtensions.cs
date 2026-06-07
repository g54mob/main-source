using System;
using System.Collections.Generic;
using System.Linq;

namespace Jundroo.Common.Extensions
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> knownKeys = new HashSet<TKey>();
			foreach (TSource item in source)
			{
				if (knownKeys.Add(keySelector(item)))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<T> Foreach<T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (T item in items)
			{
				action(item);
			}
			return items;
		}

		public static IEnumerable<TSource> GetUniqueDuplicates<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer = null)
		{
			return from x in source.GroupBy((TSource x) => x, comparer ?? EqualityComparer<TSource>.Default)
				where x.Count() > 1
				select x.Key;
		}

		public static IEnumerable<TKey> GetUniqueDuplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IEqualityComparer<TKey> comparer = null)
		{
			return from x in source.GroupBy(selector, comparer ?? EqualityComparer<TKey>.Default)
				where x.Count() > 1
				select x.Key;
		}

		public static bool HasDuplicates<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer = null)
		{
			HashSet<TSource> hash = new HashSet<TSource>(comparer ?? EqualityComparer<TSource>.Default);
			return source.Any((TSource item) => !hash.Add(item));
		}

		public static bool HasDuplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector = null, IEqualityComparer<TKey> comparer = null)
		{
			HashSet<TKey> hash = new HashSet<TKey>(comparer ?? EqualityComparer<TKey>.Default);
			return source.Any((TSource item) => !hash.Add(selector(item)));
		}
	}
}
