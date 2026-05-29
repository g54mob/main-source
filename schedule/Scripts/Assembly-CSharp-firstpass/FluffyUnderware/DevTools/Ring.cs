using System.Collections;
using System.Collections.Generic;

namespace FluffyUnderware.DevTools
{
	public class Ring<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private readonly List<T> mList;

		private int mIndex;

		public int Size { get; private set; }

		public T this[int index]
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

		public Ring(int size)
		{
		}

		public void Add(T item)
		{
		}

		public void Clear()
		{
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public void Insert(int index, T item)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		public bool Contains(T item)
		{
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		public bool Remove(T item)
		{
			return false;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}
	}
}
