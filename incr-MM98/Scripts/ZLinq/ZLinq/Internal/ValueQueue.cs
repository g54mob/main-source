using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal struct ValueQueue<T> : IDisposable
	{
		private T[] items;

		private int head;

		private int tail;

		private int size;

		public int Count => size;

		public ValueQueue(int capacity)
		{
			items = ArrayPool<T>.Shared.Rent(capacity);
			head = 0;
			tail = 0;
			size = 0;
		}

		public void Enqueue(T item)
		{
			if (items.Length == size)
			{
				Grow();
			}
			items[tail] = item;
			tail = (tail + 1) % items.Length;
			size++;
		}

		public T Dequeue()
		{
			if (size == 0)
			{
				Throw();
			}
			T result = items[head];
			items[head] = default(T);
			head = (head + 1) % items.Length;
			size--;
			return result;
		}

		private static void Throw()
		{
			throw new InvalidOperationException("Queue is empty.");
		}

		private void Grow()
		{
			T[] destinationArray = ArrayPool<T>.Shared.Rent(items.Length * 2);
			if (size > 0)
			{
				if (head < tail)
				{
					Array.Copy(items, head, destinationArray, 0, size);
				}
				else
				{
					Array.Copy(items, head, destinationArray, 0, items.Length - head);
					Array.Copy(items, 0, destinationArray, items.Length - head, tail);
				}
			}
			ArrayPool<T>.Shared.Return(items, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
			items = destinationArray;
			head = 0;
			tail = size;
		}

		public void Dispose()
		{
			if (items != null)
			{
				ArrayPool<T>.Shared.Return(items, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
				items = null;
			}
		}
	}
}
