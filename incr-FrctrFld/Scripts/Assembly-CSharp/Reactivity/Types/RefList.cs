using System;
using System.Collections.Generic;

namespace Reactivity.Types
{
	public class RefList<T> : List<T>
	{
		private RList<T> _rList;

		public RefList()
		{
		}

		public RefList(List<T> list)
		{
		}

		public void SetRef(RList<T> rList)
		{
		}

		public new void Add(T item)
		{
		}

		public new void AddRange(IEnumerable<T> collection)
		{
		}

		public new bool Remove(T item)
		{
			return false;
		}

		public new void RemoveAt(int index)
		{
		}

		public new int RemoveAll(Predicate<T> match)
		{
			return 0;
		}

		public new void Clear()
		{
		}
	}
}
