using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Comparers;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class Curve<TKey, TValue> : IList<Association<TKey, TValue>>, ICollection<Association<TKey, TValue>>, IEnumerable<Association<TKey, TValue>>, IEnumerable, IList, ICollection where TKey : IComparable
	{
		private readonly AssociationKeyComparer<TKey, TValue> comparerToUse;

		private readonly List<Association<TKey, TValue>> data;

		public IComparer<TKey> Comparer
		{
			get
			{
				return comparerToUse;
			}
		}

		public int Capacity
		{
			get
			{
				return data.Capacity;
			}
			set
			{
				data.Capacity = value;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public Association<TKey, TValue> this[TKey key]
		{
			get
			{
				int num = IndexOf(key);
				if (num < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				return this[num];
			}
			set
			{
				Association<TKey, TValue> association = this[key];
				if (association.Key.Equals(value.Key))
				{
					association.Value = value.Value;
					return;
				}
				throw new ArgumentException();
			}
		}

		public TKey[] Keys
		{
			get
			{
				TKey[] array = new TKey[Count];
				for (int i = 0; i < Count; i++)
				{
					array[i] = data[i].Key;
				}
				return array;
			}
		}

		public TValue[] Values
		{
			get
			{
				TValue[] array = new TValue[Count];
				for (int i = 0; i < Count; i++)
				{
					array[i] = data[i].Value;
				}
				return array;
			}
		}

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

		public object SyncRoot
		{
			get
			{
				return data;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		public Association<TKey, TValue> this[int index]
		{
			get
			{
				return data[index];
			}
			set
			{
				data[index] = value;
			}
		}

		public int Count
		{
			get
			{
				return data.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		Association<TKey, TValue> IList<Association<TKey, TValue>>.this[int index]
		{
			get
			{
				return data[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public Curve()
		{
			data = new List<Association<TKey, TValue>>();
			comparerToUse = AssociationKeyComparer<TKey, TValue>.DefaultComparer;
		}

		public Curve(IComparer<TKey> comparer)
		{
			data = new List<Association<TKey, TValue>>();
			comparerToUse = new AssociationKeyComparer<TKey, TValue>(comparer);
		}

		public Curve(int capacity)
		{
			data = new List<Association<TKey, TValue>>(capacity);
			comparerToUse = AssociationKeyComparer<TKey, TValue>.DefaultComparer;
		}

		public Curve(int capacity, IComparer<TKey> comparer)
		{
			data = new List<Association<TKey, TValue>>(capacity);
			comparerToUse = new AssociationKeyComparer<TKey, TValue>(comparer);
		}

		public Curve(IEnumerable<Association<TKey, TValue>> collection)
			: this()
		{
			foreach (Association<TKey, TValue> item in collection)
			{
				Add(item);
			}
		}

		public Curve(IEnumerable<KeyValuePair<TKey, TValue>> collection)
			: this()
		{
			foreach (KeyValuePair<TKey, TValue> item in collection)
			{
				Add(new Association<TKey, TValue>(item));
			}
		}

		public TValue GetValue(TKey key)
		{
			int num = IndexOf(key);
			if (num < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			return data[num].Value;
		}

		void IList.Remove(object value)
		{
			Association<TKey, TValue> association = value as Association<TKey, TValue>;
			if (association != null)
			{
				Remove(association);
			}
			else if (value is KeyValuePair<TKey, TValue>)
			{
				KeyValuePair<TKey, TValue> keyValuePair = (KeyValuePair<TKey, TValue>)value;
				int num = IndexOf(keyValuePair.Key);
				if (num >= 0 && this[num].Value.Equals(keyValuePair.Value))
				{
					RemoveAt(num);
				}
			}
			else
			{
				if (!(value is TKey))
				{
					throw new ArgumentException();
				}
				Remove((TKey)value);
			}
		}

		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			data.ToArray().CopyTo(array, arrayIndex);
		}

		int IList.Add(object value)
		{
			return AddSetItem((Association<TKey, TValue>)value);
		}

		bool IList.Contains(object value)
		{
			return Contains((Association<TKey, TValue>)value);
		}

		int IList.IndexOf(object value)
		{
			return IndexOf((Association<TKey, TValue>)value);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		public void RemoveAt(int index)
		{
			data.RemoveAt(index);
		}

		public void CopyTo(Association<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection)this).CopyTo((Array)array, arrayIndex);
		}

		public void Add(Association<TKey, TValue> item)
		{
			AddSetItem(item);
		}

		private int AddSetItem(Association<TKey, TValue> item)
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
				data.Insert(num, item);
			}
			else
			{
				data[num] = item;
			}
			return num;
		}

		public bool Remove(Association<TKey, TValue> item)
		{
			return data.Remove(item);
		}

		public bool Contains(Association<TKey, TValue> item)
		{
			return data.Contains(item);
		}

		public bool Contains(TKey key, TValue value)
		{
			return data.Contains(new Association<TKey, TValue>(key, value));
		}

		public IEnumerator<Association<TKey, TValue>> GetEnumerator()
		{
			return data.GetEnumerator();
		}

		public void Clear()
		{
			data.Clear();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int IndexOf(Association<TKey, TValue> item)
		{
			return data.BinarySearch(item, comparerToUse);
		}

		void IList<Association<TKey, TValue>>.Insert(int index, Association<TKey, TValue> item)
		{
			throw new NotSupportedException();
		}

		protected TKey GetKeyForItem(Association<TKey, TValue> item)
		{
			return item.Key;
		}

		public bool ContainsKey(TKey key)
		{
			return IndexOf(key) >= 0;
		}

		public void Add(TKey key, TValue value)
		{
			Add(new Association<TKey, TValue>(key, value));
		}

		public bool Remove(TKey key)
		{
			int num = IndexOf(key);
			if (num < 0)
			{
				return false;
			}
			RemoveAt(num);
			return true;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int num = IndexOf(key);
			bool num2 = num >= 0;
			if (num2)
			{
				value = this[num].Value;
				return num2;
			}
			value = default(TValue);
			return num2;
		}

		protected Association<TKey, TValue> GetDefaultAssociationForKey(TKey key)
		{
			return new Association<TKey, TValue>(key, default(TValue));
		}

		protected int IndexOf(TKey key)
		{
			return IndexOf(GetDefaultAssociationForKey(key));
		}
	}
}
