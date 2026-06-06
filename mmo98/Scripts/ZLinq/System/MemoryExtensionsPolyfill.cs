using System.Collections.Generic;

namespace System
{
	internal static class MemoryExtensionsPolyfill
	{
		public static void Sort<T>(this Span<T> span)
		{
			span.Sort<T, IComparer<T>>(null);
		}

		public static void Sort<T, TComparer>(this Span<T> span, TComparer comparer) where TComparer : IComparer<T>?
		{
			if (span.Length > 1)
			{
				ArraySortHelper<T>.Sort(span, comparer);
			}
		}

		public static void Sort<TKey, TValue, TComparer>(this Span<TKey> keys, Span<TValue> items, TComparer comparer) where TComparer : IComparer<TKey>?
		{
			if (keys.Length != items.Length)
			{
				throw new ArgumentException("keys and items must be same length");
			}
			if (keys.Length > 1)
			{
				ArraySortHelper<TKey, TValue>.Sort(keys, items, comparer);
			}
		}
	}
}
