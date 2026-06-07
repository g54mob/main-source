using System;
using System.Collections;
using System.Collections.Generic;

namespace Animancer
{
	public class Key : Key.IListItem
	{
		public interface IListItem
		{
			Key Key { get; }
		}

		public class KeyedList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ICollection where T : class, IListItem
		{
			private const string SingleUse = "Each item can only be used in one KeyedList at a time.";

			private const string NotFound = "The specified item does not exist in this KeyedList.";

			private readonly List<T> Items;

			public int Count => Items.Count;

			public int Capacity
			{
				get
				{
					return Items.Capacity;
				}
				set
				{
					Items.Capacity = value;
				}
			}

			public T this[int index]
			{
				get
				{
					return Items[index];
				}
				set
				{
					Key key = value.Key;
					if (key._Index != -1)
					{
						throw new ArgumentException("Each item can only be used in one KeyedList at a time.");
					}
					Items[index].Key._Index = -1;
					key._Index = index;
					Items[index] = value;
				}
			}

			bool ICollection<T>.IsReadOnly => false;

			bool ICollection.IsSynchronized => ((ICollection)Items).IsSynchronized;

			object ICollection.SyncRoot => ((ICollection)Items).SyncRoot;

			public KeyedList()
			{
				Items = new List<T>();
			}

			public KeyedList(int capacity)
			{
				Items = new List<T>(capacity);
			}

			public bool Contains(T item)
			{
				if (item == null)
				{
					return false;
				}
				int index = item.Key._Index;
				if ((uint)index < (uint)Items.Count)
				{
					return Items[index] == item;
				}
				return false;
			}

			public int IndexOf(T item)
			{
				if (item == null)
				{
					return -1;
				}
				int index = item.Key._Index;
				if ((uint)index < (uint)Items.Count && Items[index] == item)
				{
					return index;
				}
				return -1;
			}

			public void Add(T item)
			{
				Key key = item.Key;
				if (key._Index != -1)
				{
					throw new ArgumentException("Each item can only be used in one KeyedList at a time.");
				}
				key._Index = Items.Count;
				Items.Add(item);
			}

			public void AddNew(T item)
			{
				if (!Contains(item))
				{
					Add(item);
				}
			}

			public void Insert(int index, T item)
			{
				for (int i = index; i < Items.Count; i++)
				{
					Items[i].Key._Index++;
				}
				item.Key._Index = index;
				Items.Insert(index, item);
			}

			public void RemoveAt(int index)
			{
				for (int i = index + 1; i < Items.Count; i++)
				{
					Items[i].Key._Index--;
				}
				Items[index].Key._Index = -1;
				Items.RemoveAt(index);
			}

			public void RemoveAtSwap(int index)
			{
				Items[index].Key._Index = -1;
				int num = Items.Count - 1;
				if (num > index)
				{
					T val = Items[num];
					val.Key._Index = index;
					Items[index] = val;
				}
				Items.RemoveAt(num);
			}

			public bool Remove(T item)
			{
				int index = item.Key._Index;
				if (index == -1)
				{
					return false;
				}
				if (Items[index] != item)
				{
					throw new ArgumentException("The specified item does not exist in this KeyedList.", "item");
				}
				RemoveAt(index);
				return true;
			}

			public bool RemoveSwap(T item)
			{
				int index = item.Key._Index;
				if (index == -1)
				{
					return false;
				}
				if (Items[index] != item)
				{
					throw new ArgumentException("The specified item does not exist in this KeyedList.", "item");
				}
				RemoveAtSwap(index);
				return true;
			}

			public void Clear()
			{
				for (int num = Items.Count - 1; num >= 0; num--)
				{
					Items[num].Key._Index = -1;
				}
				Items.Clear();
			}

			public void CopyTo(T[] array, int index)
			{
				Items.CopyTo(array, index);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				((ICollection)Items).CopyTo(array, index);
			}

			public List<T>.Enumerator GetEnumerator()
			{
				return Items.GetEnumerator();
			}

			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		public const int NotInList = -1;

		private int _Index = -1;

		Key IListItem.Key => this;

		public static int IndexOf(Key key)
		{
			return key._Index;
		}

		public static bool IsInList(Key key)
		{
			return key._Index != -1;
		}
	}
}
