using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	public class ListBase<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
	{
		internal readonly List<T> innerList;

		public int Capacity
		{
			get
			{
				return innerList.Capacity;
			}
			set
			{
				innerList.Capacity = value;
			}
		}

		public int Count
		{
			get
			{
				return innerList.Count;
			}
		}

		public T this[int index]
		{
			get
			{
				return innerList[index];
			}
			set
			{
				SetItem(index, value);
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return ((ICollection)innerList).IsSynchronized;
			}
		}

		public object SyncRoot
		{
			get
			{
				return ((ICollection)innerList).SyncRoot;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return ((IList)innerList).IsFixedSize;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((IList)innerList).IsReadOnly;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return innerList[index];
			}
			set
			{
				VerifyValueType(value);
				SetItem(index, (T)value);
			}
		}

		public ListBase()
		{
			innerList = new List<T>();
		}

		public ListBase(IEnumerable<T> collection)
		{
			innerList = new List<T>(collection);
		}

		public ListBase(int capacity)
		{
			innerList = new List<T>(capacity);
		}

		public void Add(T item)
		{
			InsertItem(Count, item);
		}

		protected virtual void InsertItem(int index, T item)
		{
			innerList.Insert(index, item);
		}

		public void AddRange(IEnumerable<T> collection)
		{
			AddRangeItems(collection);
		}

		protected virtual void AddRangeItems(IEnumerable<T> collection)
		{
			innerList.AddRange(collection);
		}

		public ReadOnlyCollection<T> AsReadOnly()
		{
			return new ReadOnlyCollection<T>(this);
		}

		public int BinarySearch(T item)
		{
			return innerList.BinarySearch(item);
		}

		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return innerList.BinarySearch(item, comparer);
		}

		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			return innerList.BinarySearch(index, count, item, comparer);
		}

		public void Clear()
		{
			ClearItems();
		}

		protected virtual void ClearItems()
		{
			innerList.Clear();
		}

		public bool Contains(T item)
		{
			return innerList.Contains(item);
		}

		public IList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			return innerList.ConvertAll(converter);
		}

		public void CopyTo(T[] array)
		{
			innerList.CopyTo(array);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			innerList.CopyTo(array, arrayIndex);
		}

		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			innerList.CopyTo(index, array, arrayIndex, count);
		}

		public void ForEach(Action<T> action)
		{
			innerList.ForEach(action);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return innerList.GetEnumerator();
		}

		public IList<T> GetRange(int index, int count)
		{
			return innerList.GetRange(index, count);
		}

		public int IndexOf(T item)
		{
			return innerList.IndexOf(item);
		}

		public int IndexOf(T item, int index)
		{
			return innerList.IndexOf(item, index);
		}

		public int IndexOf(T item, int index, int count)
		{
			return innerList.IndexOf(item, index, count);
		}

		public void Insert(int index, T item)
		{
			InsertItem(index, item);
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
			InsertRangeItems(index, collection);
		}

		protected virtual void InsertRangeItems(int index, IEnumerable<T> collection)
		{
			innerList.InsertRange(index, collection);
		}

		public int LastIndexOf(T item)
		{
			return innerList.LastIndexOf(item);
		}

		public int LastIndexOf(T item, int index)
		{
			return innerList.LastIndexOf(item, index);
		}

		public int LastIndexOf(T item, int index, int count)
		{
			return innerList.LastIndexOf(item, index, count);
		}

		public bool Remove(T item)
		{
			int num = innerList.IndexOf(item);
			if (num < 0)
			{
				return false;
			}
			RemoveItem(num, item);
			return true;
		}

		protected virtual void RemoveItem(int index, T item)
		{
			innerList.RemoveAt(index);
		}

		public int RemoveAll(Predicate<T> match)
		{
			Guard.ArgumentNotNull(match, "match");
			int num = 0;
			int num2 = 0;
			while (num2 < Count)
			{
				T val = this[num2];
				if (match(val))
				{
					RemoveItem(num2, val);
					num++;
				}
				else
				{
					num2++;
				}
			}
			return num;
		}

		public void RemoveAt(int index)
		{
			T item = innerList[index];
			RemoveItem(index, item);
		}

		public void RemoveRange(int index, int count)
		{
			RemoveRangeItems(index, count);
		}

		protected virtual void RemoveRangeItems(int index, int count)
		{
			innerList.RemoveRange(index, count);
		}

		public void Reverse()
		{
			innerList.Reverse();
		}

		public void Reverse(int index, int count)
		{
			innerList.Reverse(index, count);
		}

		protected virtual void SetItem(int index, T item)
		{
			innerList[index] = item;
		}

		public void Sort()
		{
			innerList.Sort();
		}

		public void Sort(IComparer<T> comparer)
		{
			innerList.Sort(comparer);
		}

		public void Sort(Comparison<T> comparison)
		{
			innerList.Sort(comparison);
		}

		public void Sort(int index, int count, IComparer<T> comparer)
		{
			innerList.Sort(index, count, comparer);
		}

		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			((ICollection)innerList).CopyTo(array, arrayIndex);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return innerList.GetEnumerator();
		}

		int IList.Add(object item)
		{
			VerifyValueType(item);
			Add((T)item);
			return Count - 1;
		}

		bool IList.Contains(object item)
		{
			return ((IList)innerList).Contains(item);
		}

		int IList.IndexOf(object item)
		{
			if (IsCompatibleObject(item))
			{
				return IndexOf((T)item);
			}
			return -1;
		}

		void IList.Insert(int index, object item)
		{
			VerifyValueType(item);
			InsertItem(index, (T)item);
		}

		void IList.Remove(object item)
		{
			if (IsCompatibleObject(item))
			{
				Remove((T)item);
			}
		}

		public T[] ToArray()
		{
			return innerList.ToArray();
		}

		public void TrimExcess()
		{
			innerList.TrimExcess();
		}

		private static void VerifyValueType(object value)
		{
			if (!IsCompatibleObject(value))
			{
				throw new ArgumentException("InvalidType");
			}
		}

		private static bool IsCompatibleObject(object value)
		{
			if (!(value is T))
			{
				if (value == null)
				{
					return !typeof(T).IsValueType;
				}
				return false;
			}
			return true;
		}
	}
}
