using System;

namespace ZLinq.Internal
{
	internal struct ValueQueue<T> : IDisposable where T : notnull
	{
		private T[] items;

		private int head;

		private int tail;

		private int size;

		public int Count => 0;

		public ValueQueue(int capacity)
		{
			items = null;
			head = 0;
			tail = 0;
			size = 0;
		}

		public void Enqueue(T item)
		{
		}

		public T Dequeue()
		{
			return default(T);
		}

		private static void Throw()
		{
		}

		private void Grow()
		{
		}

		public void Dispose()
		{
		}
	}
}
