using System.Collections.Generic;

namespace IntervalTree
{
	internal class IntervalTreeNode<TKey, TValue> : IComparer<RangeValuePair<TKey, TValue>>
	{
		private readonly TKey center;

		private readonly IntervalTreeNode<TKey, TValue> leftNode;

		private readonly IntervalTreeNode<TKey, TValue> rightNode;

		private readonly RangeValuePair<TKey, TValue>[] items;

		private readonly IComparer<TKey> comparer;

		public TKey Max => default(TKey);

		public TKey Min => default(TKey);

		public IntervalTreeNode(IComparer<TKey> comparer)
		{
		}

		public IntervalTreeNode(IList<RangeValuePair<TKey, TValue>> items, IComparer<TKey> comparer)
		{
		}

		public IEnumerable<TValue> Query(TKey value)
		{
			return null;
		}

		public IEnumerable<TValue> Query(TKey from, TKey to)
		{
			return null;
		}

		int IComparer<RangeValuePair<TKey, TValue>>.Compare(RangeValuePair<TKey, TValue> x, RangeValuePair<TKey, TValue> y)
		{
			return 0;
		}
	}
}
