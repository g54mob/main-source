using System;
using System.Collections.Generic;

namespace OUSystems.Basics.DataStructures.Collections
{
	public static class EnumerableExtensions
	{
		public static TSource FindMaximum<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector) where TKey : IComparable<TKey>
		{
			return default(TSource);
		}
	}
}
