using System.Collections;
using System.Collections.Generic;

namespace IntervalTree
{
	public class IntervalTree<TKey, TValue> : IIntervalTree<TKey, TValue>, IEnumerable<RangeValuePair<TKey, TValue>>, IEnumerable
	{
		private IntervalTreeNode<TKey, TValue> root;

		private List<RangeValuePair<TKey, TValue>> items;

		private readonly IComparer<TKey> comparer;

		private bool isInSync;

		public TKey Max => default(TKey);

		public TKey Min => default(TKey);

		public IEnumerable<TValue> Values => null;

		public int Count => 0;

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public IntervalTree()
		{
		}

		public IntervalTree(IComparer<TKey> comparer)
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

		public void Add(TKey from, TKey to, TValue value)
		{
		}

		public void Remove(TValue value)
		{
		}

		public void Remove(IEnumerable<TValue> items)
		{
		}

		public void Clear()
		{
		}

		public IEnumerator<RangeValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		private void Rebuild()
		{
		}
	}
}
