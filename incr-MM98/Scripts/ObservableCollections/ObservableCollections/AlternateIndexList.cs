using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

namespace ObservableCollections
{
	public class AlternateIndexList<T> : IEnumerable<T>, IEnumerable
	{
		private class InsertIterator : IEnumerable<IndexedValue>, IEnumerable, IEnumerator<IndexedValue>, IEnumerator, IDisposable
		{
			private IEnumerator<T> iter;

			private IndexedValue current;

			public int ConsumedCount { get; private set; }

			public IndexedValue Current => current;

			object IEnumerator.Current => Current;

			public InsertIterator(int startingIndex, IEnumerable<T> values)
			{
				_003CstartingIndex_003EP = startingIndex;
				iter = values.GetEnumerator();
				base._002Ector();
			}

			public void Dispose()
			{
				iter.Dispose();
			}

			public bool MoveNext()
			{
				if (iter.MoveNext())
				{
					ConsumedCount++;
					current = new IndexedValue(_003CstartingIndex_003EP++, iter.Current);
					return true;
				}
				return false;
			}

			public void Reset()
			{
			}

			public IEnumerator<IndexedValue> GetEnumerator()
			{
				return this;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private struct IndexedValue : IComparable<IndexedValue>
		{
			public int AlternateIndex;

			public T Value;

			public IndexedValue(int alternateIndex, T value)
			{
				AlternateIndex = alternateIndex;
				Value = value;
			}

			public static implicit operator IndexedValue(int alternateIndex)
			{
				return new IndexedValue(alternateIndex, default(T));
			}

			public int CompareTo(IndexedValue other)
			{
				return AlternateIndex.CompareTo(other.AlternateIndex);
			}

			public override string ToString()
			{
				return (AlternateIndex, Value).ToString();
			}
		}

		private List<IndexedValue> list;

		public T this[int index]
		{
			get
			{
				return list[index].Value;
			}
			set
			{
				CollectionsMarshal.AsSpan(list)[index].Value = value;
			}
		}

		public int Count => list.Count;

		public AlternateIndexList()
		{
			list = new List<IndexedValue>();
		}

		public AlternateIndexList(IEnumerable<(int OrderedAlternateIndex, T Value)> values)
		{
			list = values.Select<(int, T), IndexedValue>(((int OrderedAlternateIndex, T Value) x) => new IndexedValue(x.OrderedAlternateIndex, x.Value)).ToList();
		}

		public void UpdateAlternateIndex(int startIndex, int incr)
		{
			Span<IndexedValue> span = CollectionsMarshal.AsSpan(list);
			for (int i = startIndex; i < span.Length; i++)
			{
				span[i].AlternateIndex += incr;
			}
		}

		public int GetAlternateIndex(int index)
		{
			return list[index].AlternateIndex;
		}

		public int Insert(int alternateIndex, T value)
		{
			int num = list.BinarySearch(alternateIndex);
			if (num < 0)
			{
				num = ~num;
			}
			list.Insert(num, new IndexedValue(alternateIndex, value));
			UpdateAlternateIndex(num + 1, 1);
			return num;
		}

		public int InsertRange(int startingAlternateIndex, IEnumerable<T> values)
		{
			int num = list.BinarySearch(startingAlternateIndex);
			if (num < 0)
			{
				num = ~num;
			}
			using InsertIterator insertIterator = new InsertIterator(startingAlternateIndex, values);
			list.InsertRange(num, insertIterator);
			UpdateAlternateIndex(num + insertIterator.ConsumedCount, insertIterator.ConsumedCount);
			return num;
		}

		public int Remove(T value)
		{
			int num = list.FindIndex((IndexedValue x) => EqualityComparer<T>.Default.Equals(x.Value, value));
			if (num != -1)
			{
				list.RemoveAt(num);
				UpdateAlternateIndex(num, -1);
			}
			return num;
		}

		public int RemoveAt(int alternateIndex)
		{
			int num = list.BinarySearch(alternateIndex);
			if (num >= 0)
			{
				list.RemoveAt(num);
				UpdateAlternateIndex(num, -1);
				return num;
			}
			throw new InvalidOperationException("Index was not found. AlternateIndex:" + alternateIndex);
		}

		public int RemoveRange(int alternateIndex, int count)
		{
			int num = list.BinarySearch(alternateIndex);
			if (num < 0)
			{
				num = ~num;
			}
			list.RemoveRange(num, count);
			UpdateAlternateIndex(num, -count);
			return num;
		}

		public bool TryGetAtAlternateIndex(int alternateIndex, [MaybeNullWhen(true)] out T value)
		{
			int num = list.BinarySearch(alternateIndex);
			if (num < 0)
			{
				value = default(T);
				return false;
			}
			value = list[num].Value;
			return true;
		}

		public bool TrySetAtAlternateIndex(int alternateIndex, T value, out int setIndex)
		{
			setIndex = list.BinarySearch(alternateIndex);
			if (setIndex < 0)
			{
				return false;
			}
			CollectionsMarshal.AsSpan(list)[setIndex].Value = value;
			return true;
		}

		public bool TryReplaceAlternateIndex(int getAlternateIndex, int setAlternateIndex)
		{
			int num = list.BinarySearch(getAlternateIndex);
			if (num < 0)
			{
				return false;
			}
			CollectionsMarshal.AsSpan(list)[num].AlternateIndex = setAlternateIndex;
			list.Sort();
			return true;
		}

		public bool TryReplaceByValue(T searchValue, T replaceValue, out int replacedIndex)
		{
			replacedIndex = list.FindIndex((IndexedValue x) => EqualityComparer<T>.Default.Equals(x.Value, searchValue));
			if (replacedIndex != -1)
			{
				CollectionsMarshal.AsSpan(list)[replacedIndex].Value = replaceValue;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			list.Clear();
		}

		public void Clear(IEnumerable<(int OrderedAlternateIndex, T Value)> values)
		{
			list.Clear();
			list.AddRange(values.Select<(int, T), IndexedValue>(((int OrderedAlternateIndex, T Value) x) => new IndexedValue(x.OrderedAlternateIndex, x.Value)));
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (IndexedValue item in list)
			{
				yield return item.Value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerable<(int AlternateIndex, T Value)> GetIndexedValues()
		{
			foreach (IndexedValue item in list)
			{
				yield return (AlternateIndex: item.AlternateIndex, Value: item.Value);
			}
		}
	}
}
