using System;
using System.Collections;
using System.Collections.Generic;

namespace Os.Utils
{
	public struct PooledList<T> : IDisposable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		public List<T> list;

		public T Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public int Count => 0;

		public bool IsReadOnly => false;

		public PooledList(int capacity)
		{
			list = null;
		}

		public void Dispose()
		{
		}

		public void Add(T item)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public void Insert(int index, T item)
		{
		}

		public bool Remove(T item)
		{
			return false;
		}

		public void RemoveAt(int index)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
