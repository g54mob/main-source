using System;
using System.Collections;
using System.Collections.Generic;

namespace Libs
{
	[Obsolete("use FixedQueue")]
	public class RingBuffer<T> : IEnumerable<T>, IEnumerable
	{
		private readonly Queue<T> _queue;

		public int Count => 0;

		public int MaxCapacity { get; private set; }

		public T this[int index] => default(T);

		public RingBuffer(int maxCapacity)
		{
		}

		public RingBuffer(IEnumerable<T> collection)
		{
		}

		public void Add(T item)
		{
		}

		public T Pop()
		{
			return default(T);
		}

		public T First()
		{
			return default(T);
		}

		public bool Contains(T item)
		{
			return false;
		}

		public T[] ToArray()
		{
			return null;
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
