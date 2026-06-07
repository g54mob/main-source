using System;
using System.Collections;
using System.Collections.Generic;
using Gh.Tk;

namespace Utils
{
	[Serializable]
	public class RollingList<T> : IPersistable, IEnumerable<T>, IEnumerable
	{
		private List<T> _list;

		private int _maxSize;

		private RollingList()
		{
		}

		public RollingList(int maxSize)
		{
		}

		public void Add(T item)
		{
		}

		public IEnumerable<T> GetItems()
		{
			return null;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void Clear()
		{
		}
	}
}
