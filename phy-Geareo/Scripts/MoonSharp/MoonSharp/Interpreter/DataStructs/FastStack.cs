using System.Collections;
using System.Collections.Generic;

namespace MoonSharp.Interpreter.DataStructs
{
	internal class FastStack<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private T[] m_Storage;

		private int m_HeadIdx;

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

		T IList<T>.this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		int ICollection<T>.Count => 0;

		bool ICollection<T>.IsReadOnly => false;

		public FastStack(int maxCapacity)
		{
		}

		public T Push(T item)
		{
			return default(T);
		}

		public void Expand(int size)
		{
		}

		private void Zero(int from, int to)
		{
		}

		private void Zero(int index)
		{
		}

		public T Peek(int idxofs = 0)
		{
			return default(T);
		}

		public void Set(int idxofs, T item)
		{
		}

		public void CropAtCount(int p)
		{
		}

		public void RemoveLast(int cnt = 1)
		{
		}

		public T Pop()
		{
			return default(T);
		}

		public void Clear()
		{
		}

		int IList<T>.IndexOf(T item)
		{
			return 0;
		}

		void IList<T>.Insert(int index, T item)
		{
		}

		void IList<T>.RemoveAt(int index)
		{
		}

		void ICollection<T>.Add(T item)
		{
		}

		void ICollection<T>.Clear()
		{
		}

		bool ICollection<T>.Contains(T item)
		{
			return false;
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
		}

		bool ICollection<T>.Remove(T item)
		{
			return false;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
