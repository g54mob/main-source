using System.Collections.Generic;
using System.Threading;

namespace DepthFirstScheduler
{
	public class MonitorQueue<T>
	{
		private int _count;

		private Queue<T> _queue = new Queue<T>();

		public int Count => _count;

		public T Dequeue()
		{
			lock (_queue)
			{
				while (_count <= 0)
				{
					Monitor.Wait(_queue);
				}
				_count--;
				return _queue.Dequeue();
			}
		}

		public void Enqueue(T data)
		{
			lock (_queue)
			{
				_queue.Enqueue(data);
				_count++;
				Monitor.Pulse(_queue);
			}
		}
	}
}
