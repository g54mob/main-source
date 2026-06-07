using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sirenix.Utilities
{
	[Serializable]
	public sealed class ImmutableList : IImmutableList<object>, IImmutableList, IList, IEnumerable, ICollection, IList<object>, ICollection<object>, IEnumerable<object>
	{
		[SerializeField]
		private IList innerList;

		public int Count => 0;

		public bool IsFixedSize => false;

		public bool IsReadOnly => false;

		public bool IsSynchronized => false;

		public object SyncRoot => null;

		object IList.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		object IList<object>.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object Item => null;

		public ImmutableList(IList innerList)
		{
		}

		public bool Contains(object value)
		{
			return false;
		}

		public void CopyTo(object[] array, int arrayIndex)
		{
		}

		public void CopyTo(Array array, int index)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			return null;
		}

		int IList.Add(object value)
		{
			return 0;
		}

		void IList.Clear()
		{
		}

		void IList.Insert(int index, object value)
		{
		}

		void IList.Remove(object value)
		{
		}

		void IList.RemoveAt(int index)
		{
		}

		public int IndexOf(object value)
		{
			return 0;
		}

		void IList<object>.RemoveAt(int index)
		{
		}

		void IList<object>.Insert(int index, object item)
		{
		}

		void ICollection<object>.Add(object item)
		{
		}

		void ICollection<object>.Clear()
		{
		}

		bool ICollection<object>.Remove(object item)
		{
			return false;
		}
	}
	[Serializable]
	public sealed class ImmutableList<T> : IImmutableList<T>, IImmutableList, IList, IEnumerable, ICollection, IList<T>, ICollection<T>, IEnumerable<T>
	{
		[SerializeField]
		private IList<T> innerList;

		public int Count => 0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		public bool IsReadOnly => false;

		object IList.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		T IList<T>.Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public T Item => default(T);

		public ImmutableList(IList<T> innerList)
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

		void ICollection.CopyTo(Array array, int index)
		{
		}

		void ICollection<T>.Add(T item)
		{
		}

		void ICollection<T>.Clear()
		{
		}

		bool ICollection<T>.Remove(T item)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		int IList.Add(object value)
		{
			return 0;
		}

		void IList.Clear()
		{
		}

		bool IList.Contains(object value)
		{
			return false;
		}

		int IList.IndexOf(object value)
		{
			return 0;
		}

		void IList.Insert(int index, object value)
		{
		}

		void IList.Remove(object value)
		{
		}

		void IList<T>.Insert(int index, T item)
		{
		}

		void IList.RemoveAt(int index)
		{
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		void IList<T>.RemoveAt(int index)
		{
		}
	}
	[Serializable]
	public sealed class ImmutableList<TList, TElement> : IImmutableList<TElement>, IImmutableList, IList, IEnumerable, ICollection, IList<TElement>, ICollection<TElement>, IEnumerable<TElement> where TList : IList<TElement>
	{
		private TList innerList;

		public int Count => 0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		public bool IsReadOnly => false;

		object IList.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		TElement IList<TElement>.Item
		{
			get
			{
				return default(TElement);
			}
			set
			{
			}
		}

		public TElement Item => default(TElement);

		public ImmutableList(TList innerList)
		{
		}

		public bool Contains(TElement item)
		{
			return false;
		}

		public void CopyTo(TElement[] array, int arrayIndex)
		{
		}

		public IEnumerator<TElement> GetEnumerator()
		{
			return null;
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		void ICollection<TElement>.Add(TElement item)
		{
		}

		void ICollection<TElement>.Clear()
		{
		}

		bool ICollection<TElement>.Remove(TElement item)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		int IList.Add(object value)
		{
			return 0;
		}

		void IList.Clear()
		{
		}

		bool IList.Contains(object value)
		{
			return false;
		}

		int IList.IndexOf(object value)
		{
			return 0;
		}

		void IList.Insert(int index, object value)
		{
		}

		void IList.Remove(object value)
		{
		}

		void IList<TElement>.Insert(int index, TElement item)
		{
		}

		void IList.RemoveAt(int index)
		{
		}

		public int IndexOf(TElement item)
		{
			return 0;
		}

		void IList<TElement>.RemoveAt(int index)
		{
		}
	}
}
