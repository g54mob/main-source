using System.Collections.Generic;

namespace System
{
	internal static class MemoryExtensionsPolyfill
	{
		public static void Sort<T>(this Span<T> span)
		{
		}

		public static void Sort<T, TComparer>(this Span<T> span, TComparer comparer) where TComparer : IComparer<T>
		{
		}

		public static void Sort<TKey, TValue, TComparer>(this Span<TKey> keys, Span<TValue> items, TComparer comparer) where TComparer : IComparer<TKey?>?
		{
		}
	}
}
