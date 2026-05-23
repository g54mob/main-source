using System;
using System.Collections.Generic;

namespace ZLinq.Linq
{
	internal sealed class OrderByComparer<TSource, TKey> : IOrderByComparer, IComparer<int>, IDisposable
	{
		private TKey[] keys;

		private IComparer<TKey> comparer;

		private IOrderByComparer? childComparer;

		private bool descending;

		public OrderByComparer(ReadOnlySpan<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, IOrderByComparer? childComparer, bool descending)
		{
		}

		public int Compare(int index1, int index2)
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
