using System;
using UnityEngine;

namespace IngameDebugConsole
{
	public class DynamicCircularBuffer<T>
	{
		private T[] array;

		private int startIndex;

		public int Count { get; private set; }

		public int Capacity => array.Length;

		public T this[int index]
		{
			get
			{
				return array[(startIndex + index) % array.Length];
			}
			set
			{
				array[(startIndex + index) % array.Length] = value;
			}
		}

		public DynamicCircularBuffer(int initialCapacity = 2)
		{
			array = new T[initialCapacity];
		}

		private void SetCapacity(int capacity)
		{
			T[] destinationArray = new T[capacity];
			if (Count > 0)
			{
				int num = Mathf.Min(Count, array.Length - startIndex);
				Array.Copy(array, startIndex, destinationArray, 0, num);
				if (num < Count)
				{
					Array.Copy(array, 0, destinationArray, num, Count - num);
				}
			}
			array = destinationArray;
			startIndex = 0;
		}

		public void AddFirst(T value)
		{
			if (array.Length == Count)
			{
				SetCapacity(Mathf.Max(array.Length * 2, 4));
			}
			startIndex = ((startIndex > 0) ? (startIndex - 1) : (array.Length - 1));
			array[startIndex] = value;
			Count++;
		}

		public void Add(T value)
		{
			if (array.Length == Count)
			{
				SetCapacity(Mathf.Max(array.Length * 2, 4));
			}
			this[Count++] = value;
		}

		public void AddRange(DynamicCircularBuffer<T> other)
		{
			if (other.Count != 0)
			{
				if (array.Length < Count + other.Count)
				{
					SetCapacity(Mathf.Max(array.Length * 2, Count + other.Count));
				}
				int num = (startIndex + Count) % array.Length;
				int num2 = Mathf.Min(other.Count, array.Length - num);
				int num3 = Mathf.Min(other.Count, other.array.Length - other.startIndex);
				Array.Copy(other.array, other.startIndex, array, num, Mathf.Min(num2, num3));
				if (num2 < num3)
				{
					Array.Copy(other.array, other.startIndex + num2, array, 0, num3 - num2);
				}
				else if (num2 > num3)
				{
					Array.Copy(other.array, 0, array, num + num3, num2 - num3);
				}
				int num4 = Mathf.Max(num2, num3);
				if (num4 < other.Count)
				{
					Array.Copy(other.array, num4 - num3, array, num4 - num2, other.Count - num4);
				}
				Count += other.Count;
			}
		}

		public T RemoveFirst()
		{
			T result = array[startIndex];
			array[startIndex] = default(T);
			if (++startIndex == array.Length)
			{
				startIndex = 0;
			}
			Count--;
			return result;
		}

		public T RemoveLast()
		{
			int num = (startIndex + Count - 1) % array.Length;
			T result = array[num];
			array[num] = default(T);
			Count--;
			return result;
		}

		public int RemoveAll(Predicate<T> shouldRemoveElement)
		{
			return RemoveAll<T>(shouldRemoveElement, null, null);
		}

		public int RemoveAll<Y>(Predicate<T> shouldRemoveElement, Action<T, int> onElementIndexChanged, DynamicCircularBuffer<Y> synchronizedBuffer)
		{
			Y[] array = synchronizedBuffer?.array;
			int num = Mathf.Min(Count, this.array.Length - startIndex);
			int num2 = 0;
			int i = startIndex;
			int num3 = startIndex;
			int num4;
			for (num4 = startIndex + num; i < num4; i++)
			{
				if (shouldRemoveElement(this.array[i]))
				{
					num2++;
					continue;
				}
				if (num2 > 0)
				{
					T val = this.array[i];
					this.array[num3] = val;
					if (array != null)
					{
						array[num3] = array[i];
					}
					onElementIndexChanged?.Invoke(val, num3 - startIndex);
				}
				num3++;
			}
			i = 0;
			num4 = Count - num;
			if (num3 < this.array.Length)
			{
				for (; i < num4; i++)
				{
					if (shouldRemoveElement(this.array[i]))
					{
						num2++;
						continue;
					}
					T val2 = this.array[i];
					this.array[num3] = val2;
					if (array != null)
					{
						array[num3] = array[i];
					}
					onElementIndexChanged?.Invoke(val2, num3 - startIndex);
					if (++num3 == this.array.Length)
					{
						i++;
						break;
					}
				}
			}
			if (num3 == this.array.Length)
			{
				num3 = 0;
				for (; i < num4; i++)
				{
					if (shouldRemoveElement(this.array[i]))
					{
						num2++;
						continue;
					}
					if (num2 > 0)
					{
						T val3 = this.array[i];
						this.array[num3] = val3;
						if (array != null)
						{
							array[num3] = array[i];
						}
						onElementIndexChanged?.Invoke(val3, num3 + num);
					}
					num3++;
				}
			}
			TrimEnd(num2);
			synchronizedBuffer?.TrimEnd(num2);
			return num2;
		}

		public void TrimStart(int trimCount, Action<T> perElementCallback = null)
		{
			TrimInternal(trimCount, startIndex, perElementCallback);
			startIndex = (startIndex + trimCount) % array.Length;
		}

		public void TrimEnd(int trimCount, Action<T> perElementCallback = null)
		{
			TrimInternal(trimCount, (startIndex + Count - trimCount) % array.Length, perElementCallback);
		}

		private void TrimInternal(int trimCount, int startIndex, Action<T> perElementCallback)
		{
			int num = Mathf.Min(trimCount, array.Length - startIndex);
			if (perElementCallback == null)
			{
				Array.Clear(array, startIndex, num);
				if (num < trimCount)
				{
					Array.Clear(array, 0, trimCount - num);
				}
			}
			else
			{
				int i = startIndex;
				for (int num2 = startIndex + num; i < num2; i++)
				{
					perElementCallback(array[i]);
					array[i] = default(T);
				}
				int j = 0;
				for (int num3 = trimCount - num; j < num3; j++)
				{
					perElementCallback(array[j]);
					array[j] = default(T);
				}
			}
			Count -= trimCount;
		}

		public void Clear()
		{
			int num = Mathf.Min(Count, array.Length - startIndex);
			Array.Clear(array, startIndex, num);
			if (num < Count)
			{
				Array.Clear(array, 0, Count - num);
			}
			startIndex = 0;
			Count = 0;
		}

		public int IndexOf(T value)
		{
			int num = Mathf.Min(Count, array.Length - startIndex);
			int num2 = Array.IndexOf(array, value, startIndex, num);
			if (num2 >= 0)
			{
				return num2 - startIndex;
			}
			if (num < Count)
			{
				num2 = Array.IndexOf(array, value, 0, Count - num);
				if (num2 >= 0)
				{
					return num2 + num;
				}
			}
			return -1;
		}

		public void ForEach(Action<T> action)
		{
			int num = Mathf.Min(Count, array.Length - startIndex);
			int i = startIndex;
			for (int num2 = startIndex + num; i < num2; i++)
			{
				action(array[i]);
			}
			int j = 0;
			for (int num3 = Count - num; j < num3; j++)
			{
				action(array[j]);
			}
		}
	}
}
