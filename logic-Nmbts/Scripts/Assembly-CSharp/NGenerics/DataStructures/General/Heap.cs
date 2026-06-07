using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class Heap<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IHeap<T>
	{
		private const string heapIsEmpty = "The heap is empty.";

		private readonly List<T> data;

		private readonly IComparer<T> comparerToUse;

		private readonly HeapType thisType;

		public T Root
		{
			get
			{
				if (Count == 0)
				{
					throw new InvalidOperationException("The heap is empty.");
				}
				return data[1];
			}
		}

		public HeapType Type
		{
			get
			{
				return thisType;
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
				return data.Count - 1;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public Heap(HeapType type)
			: this(type, (IComparer<T>)Comparer<T>.Default)
		{
		}

		public Heap(HeapType type, int capacity)
			: this(type, capacity, (IComparer<T>)Comparer<T>.Default)
		{
		}

		public Heap(HeapType type, Comparison<T> comparer)
			: this(type, (IComparer<T>)new ComparisonComparer<T>(comparer))
		{
		}

		public Heap(HeapType type, int capacity, Comparison<T> comparer)
			: this(type, capacity, (IComparer<T>)new ComparisonComparer<T>(comparer))
		{
		}

		public Heap(HeapType type, IComparer<T> comparer)
		{
			Guard.ArgumentNotNull(comparer, "comparer");
			if (type != HeapType.Minimum && type != HeapType.Maximum)
			{
				throw new ArgumentOutOfRangeException("type");
			}
			thisType = type;
			data = new List<T> { default(T) };
			IComparer<T> comparer3;
			if (type != HeapType.Minimum)
			{
				IComparer<T> comparer2 = new ReverseComparer<T>(comparer);
				comparer3 = comparer2;
			}
			else
			{
				comparer3 = comparer;
			}
			comparerToUse = comparer3;
		}

		public Heap(HeapType type, int capacity, IComparer<T> comparer)
		{
			Guard.ArgumentNotNull(comparer, "comparer");
			if (type != HeapType.Minimum && type != HeapType.Maximum)
			{
				throw new ArgumentOutOfRangeException("type");
			}
			thisType = type;
			data = new List<T>(capacity) { default(T) };
			IComparer<T> comparer3;
			if (type != HeapType.Minimum)
			{
				IComparer<T> comparer2 = new ReverseComparer<T>(comparer);
				comparer3 = comparer2;
			}
			else
			{
				comparer3 = comparer;
			}
			comparerToUse = comparer3;
		}

		public T RemoveRoot()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("The heap is empty.");
			}
			T val = data[1];
			RemoveRootItem(val);
			return val;
		}

		protected virtual void RemoveRootItem(T item)
		{
			T val = data[Count];
			data.RemoveAt(Count);
			if (Count <= 0)
			{
				return;
			}
			int num = 1;
			while (num * 2 < data.Count)
			{
				int num2 = num * 2;
				if (num2 + 1 < data.Count && comparerToUse.Compare(data[num2 + 1], data[num2]) < 0)
				{
					num2++;
				}
				if (comparerToUse.Compare(val, data[num2]) <= 0)
				{
					break;
				}
				data[num] = data[num2];
				num = num2;
			}
			data[num] = val;
		}

		public bool Contains(T item)
		{
			return data.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			for (int i = 1; i < data.Count; i++)
			{
				array[arrayIndex++] = data[i];
			}
		}

		public void Add(T item)
		{
			AddItem(item);
		}

		protected virtual void AddItem(T item)
		{
			data.Add(default(T));
			int num = data.Count - 1;
			while (num > 1 && comparerToUse.Compare(data[num / 2], item) > 0)
			{
				data[num] = data[num / 2];
				num /= 2;
			}
			data[num] = item;
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 1; i < data.Count; i++)
			{
				yield return data[i];
			}
		}

		public void Clear()
		{
			ClearItems();
		}

		protected virtual void ClearItems()
		{
			data.RemoveRange(1, data.Count - 1);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
