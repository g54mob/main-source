using System.Collections;
using System.Collections.Generic;

namespace Libs
{
	public class FixedQueue<T> : IEnumerable<T>, IEnumerable
	{
		public readonly Queue<T> queue;

		public int Count => 0;

		public int Capacity { get; private set; }

		public FixedQueue(int capacity)
		{
		}

		public FixedQueue(int capacity, T fillValue)
		{
		}

		public bool Enqueue(T item)
		{
			return false;
		}

		public T Dequeue()
		{
			return default(T);
		}

		public T Peek()
		{
			return default(T);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
