using System;
using System.Collections.Generic;

namespace ModApi.Common.Extensions
{
	public static class IReadOnlyListExtensions
	{
		public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			for (int i = 0; i < source.Count; i++)
			{
				if (predicate(source[i]))
				{
					return source[i];
				}
			}
			throw new InvalidOperationException("No element satisfies the condition in predicate");
		}

		public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			for (int i = 0; i < source.Count; i++)
			{
				if (predicate(source[i]))
				{
					return source[i];
				}
			}
			return default(TSource);
		}
	}
}
