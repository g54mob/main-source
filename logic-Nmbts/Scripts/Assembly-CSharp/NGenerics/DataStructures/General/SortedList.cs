using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class SortedList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
	{
		private readonly List<T> data;

		private readonly IComparer<T> comparerToUse;

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public IComparer<T> Comparer
		{
			get
			{
				return comparerToUse;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public int Count
		{
			get
			{
				return data.Count;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				return data;
			}
		}

		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		public T this[int index]
		{
			get
			{
				return data[index];
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		bool IList.IsFixedSize
		{
			get
			{
				return false;
			}
		}

		T IList<T>.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public SortedList()
		{
			data = new List<T>();
			comparerToUse = Comparer<T>.Default;
		}

		public SortedList(IComparer<T> comparer)
		{
			data = new List<T>();
			comparerToUse = comparer;
		}

		public SortedList(int capacity)
		{
			data = new List<T>(capacity);
			comparerToUse = Comparer<T>.Default;
		}

		public SortedList(int capacity, IComparer<T> comparer)
		{
			data = new List<T>(capacity);
			comparerToUse = comparer;
		}

		public SortedList(IEnumerable<T> collection)
		{
			data = new List<T>();
			comparerToUse = Comparer<T>.Default;
			foreach (T item in collection)
			{
				Add(item);
			}
		}

		void IList.Remove(object value)
		{
			Remove((T)value);
		}

		public virtual void RemoveAt(int index)
		{
			data.RemoveAt(index);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			for (int i = 0; i < data.Count; i++)
			{
				array.SetValue(data[i], arrayIndex++);
			}
		}

		public void Add(T item)
		{
			AddItem(item);
		}

		protected virtual int AddItem(T item)
		{
			if (data.Count == 0)
			{
				data.Add(item);
				return 0;
			}
			int num = data.BinarySearch(item, comparerToUse);
			if (num < 0)
			{
				num = ~num;
			}
			data.Insert(num, item);
			return num;
		}

		public virtual bool Remove(T item)
		{
			return data.Remove(item);
		}

		public bool Contains(T item)
		{
			return data.Contains(item);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			CopyTo((T[])array, index);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return data.GetEnumerator();
		}

		public void AddRange(IEnumerable<T> collection)
		{
			Guard.ArgumentNotNull(collection, "collection");
			foreach (T item in collection)
			{
				AddItem(item);
			}
		}

		int IList.Add(object value)
		{
			return AddItem((T)value);
		}

		bool IList.Contains(object value)
		{
			return Contains((T)value);
		}

		public virtual void Clear()
		{
			data.Clear();
		}

		int IList.IndexOf(object value)
		{
			return IndexOf((T)value);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int IndexOf(T item)
		{
			return data.IndexOf(item);
		}

		void IList<T>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}
	}
}
