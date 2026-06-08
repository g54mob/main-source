using System;

namespace MLAPI.Collections
{
	public sealed class FixedQueue<T>
	{
		private readonly T[] queue;

		private int queueCount;

		private int queueStart;

		public int Count => queueCount;

		public T this[int index] => queue[(queueStart + index) % queue.Length];

		public FixedQueue(int maxSize)
		{
			queue = new T[maxSize];
			queueStart = 0;
		}

		public bool Enqueue(T t)
		{
			queue[(queueStart + queueCount) % queue.Length] = t;
			if (++queueCount > queue.Length)
			{
				queueCount--;
				return true;
			}
			return false;
		}

		public T Dequeue()
		{
			if (--queueCount == -1)
			{
				throw new IndexOutOfRangeException("Cannot dequeue empty queue!");
			}
			T result = queue[queueStart];
			queueStart = (queueStart + 1) % queue.Length;
			return result;
		}

		public T ElementAt(int index)
		{
			return queue[(queueStart + index) % queue.Length];
		}
	}
}
