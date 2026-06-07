using System;
using System.Collections;
using System.Collections.Generic;

namespace MiscUtil.Collections
{
	public sealed class RandomAccessQueue<T> : ICollection<T>, ICollection, IEnumerable<T>, IEnumerable, ICloneable
	{
		public const int DefaultCapacity = 16;

		private T[] buffer;

		private int start;

		private int count;

		private int version;

		private object syncRoot = new object();

		public int Count => count;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return buffer[(start + index) % Capacity];
			}
			set
			{
				if (index < 0 || index >= count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				version++;
				buffer[(start + index) % Capacity] = value;
			}
		}

		public int Capacity => buffer.Length;

		public object SyncRoot => syncRoot;

		public bool IsSynchronized => false;

		public bool IsReadOnly => false;

		public RandomAccessQueue(int capacity)
		{
			buffer = new T[Math.Max(capacity, 16)];
		}

		public RandomAccessQueue()
			: this(16)
		{
		}

		private RandomAccessQueue(T[] buffer, int count, int start)
		{
			this.buffer = (T[])buffer.Clone();
			this.count = count;
			this.start = start;
		}

		public void Clear()
		{
			start = 0;
			count = 0;
			((IList)buffer).Clear();
		}

		public void TrimToSize()
		{
			int num = Math.Max(Count, 16);
			if (Capacity != num)
			{
				Resize(num, -1);
			}
		}

		public void Enqueue(T value)
		{
			Enqueue(value, count);
		}

		public void Enqueue(T value, int index)
		{
			if (count == Capacity)
			{
				Resize(count * 2, index);
				count++;
			}
			else
			{
				count++;
				for (int num = count - 2; num >= index; num--)
				{
					this[num + 1] = this[num];
				}
			}
			this[index] = value;
		}

		public T Dequeue()
		{
			if (count == 0)
			{
				throw new InvalidOperationException("Dequeue called on an empty queue.");
			}
			T result = this[0];
			this[0] = default(T);
			start++;
			if (start == Capacity)
			{
				start = 0;
			}
			count--;
			return result;
		}

		public T RemoveAt(int index)
		{
			if (index < 0 || index >= count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (index == 0)
			{
				return Dequeue();
			}
			T result = this[index];
			if (index == count - 1)
			{
				this[index] = default(T);
				count--;
				return result;
			}
			_ = this[index];
			if (start + index >= Capacity)
			{
				Array.Copy(buffer, start + index - Capacity + 1, buffer, start + index - Capacity, count - index - 1);
				buffer[start + count - 1 - Capacity] = default(T);
			}
			else
			{
				Array.Copy(buffer, start, buffer, start + 1, index);
				buffer[start] = default(T);
				start++;
			}
			count--;
			version++;
			return result;
		}

		public void CopyTo(Array dest, int index)
		{
			if (dest == null)
			{
				throw new ArgumentNullException("dest");
			}
			if (!(dest is T[] dest2))
			{
				throw new ArgumentException($"Cannot copy elements of type {typeof(T).Name} to an array of type {dest.GetType().GetElementType().Name}");
			}
			CopyTo(dest2, index);
		}

		public int BinarySearch(T obj)
		{
			if (obj == null)
			{
				if (count == 0 || buffer[start] != null)
				{
					return -1;
				}
				return 0;
			}
			if (!(obj is IComparable comparable))
			{
				throw new ArgumentException("obj does not implement IComparable");
			}
			if (count == 0)
			{
				return -1;
			}
			int num = 0;
			int num2 = count - 1;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				T val = this[num3];
				int num4 = ((val == null) ? 1 : comparable.CompareTo(val));
				if (num4 == 0)
				{
					return num3;
				}
				if (num4 < 0)
				{
					num2 = num3 - 1;
				}
				if (num4 > 0)
				{
					num = num3 + 1;
				}
			}
			return ~num;
		}

		public int BinarySearch(T obj, IComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (count == 0)
			{
				return -1;
			}
			int num = 0;
			int num2 = count - 1;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				int num4 = comparer.Compare(obj, this[num3]);
				if (num4 == 0)
				{
					return num3;
				}
				if (num4 < 0)
				{
					num2 = num3 - 1;
				}
				if (num4 > 0)
				{
					num = num3 + 1;
				}
			}
			return ~num;
		}

		public int BinarySearch(T obj, Comparison<T> comparison)
		{
			return BinarySearch(obj, new ComparisonComparer<T>(comparison));
		}

		public IEnumerator<T> GetEnumerator()
		{
			int originalVersion = version;
			for (int i = 0; i < Count; i++)
			{
				yield return this[i];
				if (version != originalVersion)
				{
					throw new InvalidOperationException("Collection was modified after the enumerator was created");
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public RandomAccessQueue<T> Clone()
		{
			return new RandomAccessQueue<T>(buffer, count, start);
		}

		private void Resize(int newCapacity, int gapIndex)
		{
			T[] array = new T[newCapacity];
			if (gapIndex == -1)
			{
				int num;
				int length;
				if (buffer.Length - start >= count)
				{
					num = count;
					length = 0;
				}
				else
				{
					num = buffer.Length - start;
					length = count - num;
				}
				Array.Copy(buffer, start, array, 0, num);
				Array.Copy(buffer, 0, array, num, length);
			}
			else
			{
				int num2 = 0;
				int num3 = start;
				for (int i = 0; i < count; i++)
				{
					if (i == gapIndex)
					{
						num2++;
					}
					array[num2] = buffer[num3];
					num2++;
					num3++;
					if (num3 == buffer.Length)
					{
						num3 = 0;
					}
				}
			}
			buffer = array;
			start = 0;
		}

		public void Add(T item)
		{
			Enqueue(item);
		}

		public bool Contains(T item)
		{
			if (item == null)
			{
				for (int i = 0; i < Count; i++)
				{
					if (this[i] == null)
					{
						return true;
					}
				}
				return false;
			}
			IEqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
			for (int j = 0; j < Count; j++)
			{
				if (equalityComparer.Equals(this[j], item))
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(T[] dest, int index)
		{
			if (dest == null)
			{
				throw new ArgumentNullException("dest");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (dest.Length < index + Count)
			{
				throw new ArgumentException("Not enough space in array for contents of queue");
			}
			for (int i = 0; i < Count; i++)
			{
				dest[i + index] = this[i];
			}
		}

		public bool Remove(T item)
		{
			if (item == null)
			{
				for (int i = 0; i < Count; i++)
				{
					if (this[i] == null)
					{
						RemoveAt(i);
						return true;
					}
				}
				return false;
			}
			IEqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
			for (int j = 0; j < Count; j++)
			{
				if (equalityComparer.Equals(this[j], item))
				{
					RemoveAt(j);
					return true;
				}
			}
			return false;
		}
	}
}
