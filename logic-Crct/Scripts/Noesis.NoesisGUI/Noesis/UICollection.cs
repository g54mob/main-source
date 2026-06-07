using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class UICollection<T> : BaseUICollection, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		public new struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private UICollection<T> _collection;

			private int _index;

			object IEnumerator.Current => null;

			public T Current => default(T);

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}

			public Enumerator(UICollection<T> c)
			{
				_collection = null;
				_index = 0;
			}
		}

		public new T this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

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

		protected UICollection()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal UICollection(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(UICollection<T> obj)
		{
			return default(HandleRef);
		}

		public void Add(T item)
		{
		}

		public void AddRange(IEnumerable<T> range)
		{
		}

		public bool Contains(T item)
		{
			return false;
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

		public void CopyTo(T[] array, int arrayIndex)
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

		public new Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}
	}
}
