using System;
using System.Runtime.CompilerServices;

namespace External.Zalgo2462.VoronoiLib.Structures
{
	public class MinHeap<T> where T : IComparable<T>
	{
		private readonly T[] items;

		public int Capacity { get; }

		public int Count { get; private set; }

		public MinHeap(int capacity)
		{
			if (capacity < 2)
			{
				capacity = 2;
			}
			Capacity = capacity;
			items = new T[Capacity];
			Count = 0;
		}

		public bool Insert(T obj)
		{
			if (Count == Capacity)
			{
				return false;
			}
			items[Count] = obj;
			Count++;
			PercolateUp(Count - 1);
			return true;
		}

		public T Pop()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Min heap is empty");
			}
			if (Count == 1)
			{
				Count--;
				return items[Count];
			}
			T result = items[0];
			items[0] = items[Count - 1];
			Count--;
			PercolateDown(0);
			return result;
		}

		public T Peek()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Min heap is empty");
			}
			return items[0];
		}

		public bool Remove(T item)
		{
			int num = -1;
			for (int i = 0; i < Count; i++)
			{
				if (items[i].Equals(item))
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return false;
			}
			Count--;
			Swap(num, Count);
			if (LeftLessThanRight(num, (num - 1) / 2))
			{
				PercolateUp(num);
			}
			else
			{
				PercolateDown(num);
			}
			return true;
		}

		private void PercolateDown(int index)
		{
			while (true)
			{
				int num = 2 * index + 1;
				int num2 = 2 * index + 2;
				int num3 = index;
				if (num < Count && LeftLessThanRight(num, num3))
				{
					num3 = num;
				}
				if (num2 < Count && LeftLessThanRight(num2, num3))
				{
					num3 = num2;
				}
				if (num3 == index)
				{
					break;
				}
				Swap(index, num3);
				index = num3;
			}
		}

		private void PercolateUp(int index)
		{
			while (index < Count && index > 0)
			{
				int num = (index - 1) / 2;
				if (LeftLessThanRight(num, index))
				{
					break;
				}
				Swap(index, num);
				index = num;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool LeftLessThanRight(int left, int right)
		{
			ref readonly T reference = ref items[left];
			T other = items[right];
			return reference.CompareTo(other) < 0;
		}

		private void Swap(int left, int right)
		{
			T val = items[left];
			items[left] = items[right];
			items[right] = val;
		}
	}
}
