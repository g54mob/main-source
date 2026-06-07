using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class Bag<T> : IBag<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IEnumerable<KeyValuePair<T, int>>, IEquatable<Bag<T>>
	{
		private readonly Dictionary<T, int> data;

		public int this[T item]
		{
			get
			{
				int value;
				if (data.TryGetValue(item, out value))
				{
					return value;
				}
				return 0;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public int Count { get; private set; }

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public Bag()
		{
			data = new Dictionary<T, int>();
		}

		public Bag(int capacity)
		{
			data = new Dictionary<T, int>(capacity);
		}

		public Bag(IEqualityComparer<T> comparer)
		{
			Guard.ArgumentNotNull(comparer, "comparer");
			data = new Dictionary<T, int>(comparer);
		}

		public Bag(int capacity, IEqualityComparer<T> comparer)
		{
			Guard.ArgumentNotNull(comparer, "comparer");
			data = new Dictionary<T, int>(capacity, comparer);
		}

		private Bag(IDictionary<T, int> dictionary)
		{
			data = new Dictionary<T, int>(dictionary);
			foreach (KeyValuePair<T, int> datum in data)
			{
				Count += datum.Value;
			}
		}

		public bool RemoveAll(T item)
		{
			int value;
			if (data.TryGetValue(item, out value))
			{
				RemoveItem(item, value, value);
				return true;
			}
			return false;
		}

		public bool Remove(T item, int maximum)
		{
			if (maximum <= 0)
			{
				throw new ArgumentOutOfRangeException("maximum");
			}
			int value;
			if (data.TryGetValue(item, out value))
			{
				RemoveItem(item, maximum, value);
				return true;
			}
			return false;
		}

		protected virtual void RemoveItem(T item, int maximum, int itemCount)
		{
			if (maximum >= itemCount)
			{
				Count -= itemCount;
				data.Remove(item);
			}
			else
			{
				Count -= maximum;
				data[item] = itemCount - maximum;
			}
		}

		public void Add(T item, int amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException("amount", "You can only add 1 or more items.");
			}
			AddItem(item, amount);
		}

		protected virtual void AddItem(T item, int amount)
		{
			int value;
			if (data.TryGetValue(item, out value))
			{
				data[item] = value + amount;
			}
			else
			{
				data.Add(item, amount);
			}
			Count += amount;
		}

		public IEnumerator<KeyValuePair<T, int>> GetCountEnumerator()
		{
			return data.GetEnumerator();
		}

		public Bag<T> Union(Bag<T> bag)
		{
			return UnionInternal(bag);
		}

		public Bag<T> Subtract(Bag<T> bag)
		{
			return SubtractInternal(bag);
		}

		public Bag<T> Intersection(Bag<T> bag)
		{
			return IntersectionInternal(bag);
		}

		private Bag<T> IntersectionInternal(IBag<T> bag)
		{
			Guard.ArgumentNotNull(bag, "bag");
			Bag<T> bag2 = new Bag<T>();
			using (IEnumerator<KeyValuePair<T, int>> enumerator = bag.GetCountEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<T, int> current = enumerator.Current;
					int value;
					if (data.TryGetValue(current.Key, out value))
					{
						bag2.Add(current.Key, Math.Min(current.Value, value));
					}
				}
				return bag2;
			}
		}

		private Bag<T> UnionInternal(IBag<T> bag)
		{
			Guard.ArgumentNotNull(bag, "bag");
			Bag<T> bag2 = new Bag<T>();
			foreach (KeyValuePair<T, int> datum in data)
			{
				bag2.Add(datum.Key, datum.Value);
			}
			using (IEnumerator<KeyValuePair<T, int>> enumerator2 = bag.GetCountEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					KeyValuePair<T, int> current2 = enumerator2.Current;
					bag2.Add(current2.Key, current2.Value);
				}
				return bag2;
			}
		}

		private Bag<T> SubtractInternal(IBag<T> bag)
		{
			Guard.ArgumentNotNull(bag, "bag");
			Bag<T> bag2 = new Bag<T>(data);
			using (IEnumerator<KeyValuePair<T, int>> enumerator = bag.GetCountEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<T, int> current = enumerator.Current;
					int value;
					if (bag2.data.TryGetValue(current.Key, out value))
					{
						if (value - current.Value <= 0)
						{
							bag2.RemoveAll(current.Key);
						}
						else
						{
							bag2.Remove(current.Key, current.Value);
						}
					}
				}
				return bag2;
			}
		}

		public static Bag<T> operator +(Bag<T> left, Bag<T> right)
		{
			return left.Union(right);
		}

		public static Bag<T> operator -(Bag<T> left, Bag<T> right)
		{
			return left.Subtract(right);
		}

		public static Bag<T> operator *(Bag<T> left, Bag<T> right)
		{
			return left.Intersection(right);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			int num = arrayIndex;
			foreach (KeyValuePair<T, int> datum in data)
			{
				int value = datum.Value;
				T key = datum.Key;
				for (int i = 0; i < value; i++)
				{
					array.SetValue(key, num++);
				}
			}
		}

		public void Add(T item)
		{
			AddItem(item, 1);
		}

		public bool Remove(T item)
		{
			int value;
			if (data.TryGetValue(item, out value))
			{
				RemoveItem(item, 1, value);
				return true;
			}
			return false;
		}

		public bool Contains(T item)
		{
			return data.ContainsKey(item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (KeyValuePair<T, int> datum in data)
			{
				yield return datum.Key;
			}
		}

		IEnumerator<KeyValuePair<T, int>> IEnumerable<KeyValuePair<T, int>>.GetEnumerator()
		{
			foreach (KeyValuePair<T, int> datum in data)
			{
				yield return datum;
			}
		}

		public void Clear()
		{
			ClearItems();
		}

		protected virtual void ClearItems()
		{
			data.Clear();
			Count = 0;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IBag<T> IBag<T>.Intersection(IBag<T> bag)
		{
			return IntersectionInternal(bag);
		}

		IBag<T> IBag<T>.Subtract(IBag<T> bag)
		{
			return SubtractInternal(bag);
		}

		IBag<T> IBag<T>.Union(IBag<T> bag)
		{
			return Union((Bag<T>)bag);
		}

		public bool Equals(Bag<T> other)
		{
			if (other == null)
			{
				return false;
			}
			if (Count != other.Count)
			{
				return false;
			}
			foreach (KeyValuePair<T, int> datum in data)
			{
				if (!other.Contains(datum.Key))
				{
					return false;
				}
				if (other[datum.Key] != datum.Value)
				{
					return false;
				}
			}
			return true;
		}
	}
}
