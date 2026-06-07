using System;
using System.Collections.Generic;
using System.Threading;

namespace MessagePipe.Internal
{
	internal sealed class FreeList<T> : IDisposable where T : class
	{
		private const int InitialCapacity = 4;

		private const int MinShrinkStart = 8;

		private T[] values;

		private int count;

		private FastQueue<int> freeIndex;

		private bool isDisposed;

		private readonly object gate = new object();

		public FreeList()
		{
			Initialize();
		}

		public T[] GetValues()
		{
			return values;
		}

		public int GetCount()
		{
			lock (gate)
			{
				return count;
			}
		}

		public int Add(T value)
		{
			lock (gate)
			{
				if (isDisposed)
				{
					throw new ObjectDisposedException("FreeList");
				}
				if (freeIndex.Count != 0)
				{
					int num = freeIndex.Dequeue();
					values[num] = value;
					count++;
					return num;
				}
				T[] array = new T[values.Length * 2];
				Array.Copy(values, 0, array, 0, values.Length);
				freeIndex.EnsureNewCapacity(array.Length);
				for (int i = values.Length; i < array.Length; i++)
				{
					freeIndex.Enqueue(i);
				}
				int result = freeIndex.Dequeue();
				array[values.Length] = value;
				count++;
				Volatile.Write(ref values, array);
				return result;
			}
		}

		public void Remove(int index, bool shrinkWhenEmpty)
		{
			lock (gate)
			{
				if (!isDisposed)
				{
					ref T reference = ref values[index];
					if (reference == null)
					{
						throw new KeyNotFoundException($"key index {index} is not found.");
					}
					reference = null;
					freeIndex.Enqueue(index);
					count--;
					if (shrinkWhenEmpty && count == 0 && values.Length > 8)
					{
						Initialize();
					}
				}
			}
		}

		public bool TryDispose(out int clearedCount)
		{
			lock (gate)
			{
				if (isDisposed)
				{
					clearedCount = 0;
					return false;
				}
				clearedCount = count;
				Dispose();
				return true;
			}
		}

		public void Dispose()
		{
			lock (gate)
			{
				if (!isDisposed)
				{
					isDisposed = true;
					freeIndex = null;
					values = Array.Empty<T>();
					count = 0;
				}
			}
		}

		private void Initialize()
		{
			freeIndex = new FastQueue<int>(4);
			for (int i = 0; i < 4; i++)
			{
				freeIndex.Enqueue(i);
			}
			count = 0;
			T[] value = new T[4];
			Volatile.Write(ref values, value);
		}
	}
}
