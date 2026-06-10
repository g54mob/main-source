using System;
using System.Collections;
using System.Collections.Generic;

namespace NSMedieval.Utils.Pool.Janitors
{
	public readonly struct PooledQueue<T> : IDisposable, IEnumerable<T>, IEnumerable
	{
		private readonly Queue<T> queue;

		public int Count => queue.Count;

		public PooledQueue(Queue<T> queue)
		{
			this.queue = queue;
		}

		public Queue<T>.Enumerator GetEnumerator()
		{
			return queue.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return queue.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return queue.GetEnumerator();
		}

		public void Dispose()
		{
			QueuePool<T>.Return(queue);
		}

		public void Enqueue(T obj)
		{
			queue.Enqueue(obj);
		}

		public T Dequeue()
		{
			return queue.Dequeue();
		}

		public T Peek()
		{
			return queue.Peek();
		}

		public void Clear()
		{
			queue.Clear();
		}

		public bool TryDequeue(out T obj)
		{
			return queue.TryDequeue(out obj);
		}
	}
}
