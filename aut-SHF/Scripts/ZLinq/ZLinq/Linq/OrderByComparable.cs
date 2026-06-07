using System;
using System.Collections.Generic;

namespace ZLinq.Linq
{
	internal sealed class OrderByComparable<TSource, TKey> : IOrderByComparable<TSource> where TSource : notnull where TKey : notnull
	{
		private IComparer<TKey> comparer;

		public OrderByComparable(Func<TSource, TKey> keySelector, IComparer<TKey>? comparer, IOrderByComparable<TSource>? parent, bool descending)
		{
		}

		public IOrderByComparer GetComparer(ReadOnlySpan<TSource> source, IOrderByComparer? childComparer)
		{
			return null;
		}
	}
}
