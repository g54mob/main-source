using System.Collections;
using System.Collections.Generic;

namespace IntervalTree
{
	public interface IIntervalTree<TKey, TValue> : IEnumerable<RangeValuePair<TKey, TValue>>, IEnumerable
	{
		IEnumerable<TValue> Values { get; }

		int Count { get; }

		IEnumerable<TValue> Query(TKey value);

		IEnumerable<TValue> Query(TKey from, TKey to);

		void Add(TKey from, TKey to, TValue value);

		void Remove(TValue item);

		void Remove(IEnumerable<TValue> items);

		void Clear();
	}
}
