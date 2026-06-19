using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sentry.Internal
{
	internal struct GrowableArray<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
	{
		public struct GrowableArrayEnumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int cur;

			private int end;

			private T[] array;

			object IEnumerator.Current => Current;

			public T Current
			{
				get
				{
					if (cur < 0 || cur >= end)
					{
						throw new InvalidOperationException();
					}
					return array[cur];
				}
			}

			public bool MoveNext()
			{
				cur++;
				return cur < end;
			}

			public void Reset()
			{
				cur = -1;
			}

			public void Dispose()
			{
			}

			internal GrowableArrayEnumerator(GrowableArray<T> growableArray)
			{
				cur = -1;
				end = growableArray.arrayLength;
				array = growableArray.array;
			}
		}

		private T[] array;

		private int arrayLength;

		public T this[int index]
		{
			get
			{
				return array[index];
			}
			set
			{
				array[index] = value;
			}
		}

		public int Count => arrayLength;

		public bool Empty => arrayLength == 0;

		public bool EmptyCapacity => array == null;

		public T[] UnderlyingArray => array;

		public GrowableArray(int initialSize)
		{
			array = new T[initialSize];
			arrayLength = 0;
		}

		public void Reserve(int size)
		{
			if (arrayLength < size)
			{
				Realloc(size);
			}
		}

		public void Clear()
		{
			arrayLength = 0;
		}

		public void Add(T item)
		{
			if (arrayLength >= array.Length)
			{
				Realloc(0);
			}
			array[arrayLength++] = item;
		}

		public void AddRange(IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				Add(item);
			}
		}

		public void Insert(int index, T item)
		{
			if ((uint)index > (uint)arrayLength)
			{
				throw new IndexOutOfRangeException();
			}
			if (arrayLength >= array.Length)
			{
				Realloc(0);
			}
			int num = arrayLength;
			while (index < num)
			{
				array[num] = array[num - 1];
				num--;
			}
			array[index] = item;
			arrayLength++;
		}

		public void RemoveRange(int index, int count)
		{
			if (count != 0)
			{
				if (count < 0)
				{
					throw new ArgumentException("count can't be negative");
				}
				if ((uint)index >= (uint)arrayLength)
				{
					throw new IndexOutOfRangeException();
				}
				for (int i = index + count; i < arrayLength; i++)
				{
					array[index++] = array[i];
				}
				arrayLength = index;
			}
		}

		public void Trim(int maxWaste)
		{
			if (array.Length > arrayLength + maxWaste)
			{
				if (arrayLength == 0)
				{
					array = new T[0];
					return;
				}
				T[] destinationArray = new T[arrayLength];
				Array.Copy(array, destinationArray, arrayLength);
				array = destinationArray;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("GrowableArray(Count=").Append(Count).Append(", [")
				.AppendLine();
			for (int i = 0; i < Count; i++)
			{
				StringBuilder stringBuilder2 = stringBuilder.Append("  ");
				T val = this[i];
				stringBuilder2.Append((val != null) ? val.ToString() : null).AppendLine();
			}
			stringBuilder.Append("  ])");
			return stringBuilder.ToString();
		}

		public GrowableArray<T1> Foreach<T1>(Func<T, T1> func)
		{
			GrowableArray<T1> result = new GrowableArray<T1>(Count);
			for (int i = 0; i < Count; i++)
			{
				result[i] = func(array[i]);
			}
			return result;
		}

		public bool Search<Key>(Key key, int startIndex, Func<Key, T, int> compare, ref int index)
		{
			for (int i = startIndex; i < arrayLength; i++)
			{
				if (compare(key, array[i]) == 0)
				{
					index = i;
					return true;
				}
			}
			return false;
		}

		private void Realloc(int minSize)
		{
			long num = (long)array.Length * 3L / 2 + 8;
			if (num > int.MaxValue)
			{
				if (array.Length == int.MaxValue)
				{
					throw new NotSupportedException("Array cannot have more than int.MaxValue elements.");
				}
				num = 2147483647L;
			}
			if (minSize < num)
			{
				minSize = (int)num;
			}
			Array.Resize(ref array, minSize);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new GrowableArrayEnumerator(this);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new GrowableArrayEnumerator(this);
		}
	}
}
