using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
			TKey[] array = ArrayPool<TKey>.Shared.Rent(source.Length);
			for (int i = 0; (uint)i < (uint)source.Length; i++)
			{
				array[i] = keySelector(source[i]);
			}
			keys = array;
			this.comparer = comparer;
			this.childComparer = childComparer;
			this.descending = descending;
		}

		public int Compare(int index1, int index2)
		{
			int num = comparer.Compare(keys[index1], keys[index2]);
			if (num != 0)
			{
				int num2 = ((num > 0) ? 1 : (-1));
				if (!descending)
				{
					return num2;
				}
				return -num2;
			}
			if (childComparer != null)
			{
				return childComparer.Compare(index1, index2);
			}
			if (index1 == index2)
			{
				return 0;
			}
			if (index1 >= index2)
			{
				return 1;
			}
			return -1;
		}

		public void Dispose()
		{
			if (keys != null)
			{
				ArrayPool<TKey>.Shared.Return(keys, RuntimeHelpers.IsReferenceOrContainsReferences<TKey>());
				keys = null;
				if (childComparer != null)
				{
					childComparer.Dispose();
					childComparer = null;
				}
			}
		}
	}
}
