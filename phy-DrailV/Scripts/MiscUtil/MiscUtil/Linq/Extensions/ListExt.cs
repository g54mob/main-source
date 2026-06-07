using System;
using System.Collections.Generic;
using MiscUtil.Collections;
using MiscUtil.Collections.Extensions;

namespace MiscUtil.Linq.Extensions
{
	public static class ListExt
	{
		public static void Sort<T, TValue>(this List<T> source, Func<T, TValue> selector, IComparer<TValue> comparer, bool descending)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (comparer == null)
			{
				comparer = Comparer<TValue>.Default;
			}
			IComparer<T> comparer2 = new ProjectionComparer<T, TValue>(selector, comparer);
			if (descending)
			{
				comparer2 = comparer2.Reverse();
			}
			source.Sort(comparer2);
		}

		public static void Sort<T, TValue>(this List<T> source, Func<T, TValue> selector)
		{
			source.Sort(selector, null, descending: false);
		}
	}
}
