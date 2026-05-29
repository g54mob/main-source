using System.Collections;
using System.Collections.Generic;

namespace cakeslice
{
	public class LinkedSet<T> : IEnumerable<T>, IEnumerable
	{
		private LinkedList<T> list;

		private Dictionary<T, LinkedListNode<T>> dictionary;

		public int Count => 0;

		public LinkedSet()
		{
		}

		public LinkedSet(IEqualityComparer<T> comparer)
		{
		}

		public bool Add(T t)
		{
			return false;
		}

		public bool Remove(T t)
		{
			return false;
		}

		public void Clear()
		{
		}

		public bool Contains(T t)
		{
			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
