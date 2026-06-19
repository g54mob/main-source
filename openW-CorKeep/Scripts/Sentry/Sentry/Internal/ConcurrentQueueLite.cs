using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Sentry.Internal
{
	internal class ConcurrentQueueLite<T>
	{
		private readonly List<T> _queue = new List<T>();

		public int Count
		{
			get
			{
				lock (_queue)
				{
					return _queue.Count;
				}
			}
		}

		public bool IsEmpty => Count == 0;

		public void Enqueue(T item)
		{
			lock (_queue)
			{
				_queue.Add(item);
			}
		}

		public bool TryDequeue([NotNullWhen(true)] out T? item)
		{
			lock (_queue)
			{
				if (_queue.Count > 0)
				{
					item = _queue[0];
					_queue.RemoveAt(0);
					return true;
				}
			}
			item = default(T);
			return false;
		}

		public void Clear()
		{
			lock (_queue)
			{
				_queue.Clear();
			}
		}

		public bool TryPeek([NotNullWhen(true)] out T? item)
		{
			lock (_queue)
			{
				if (_queue.Count > 0)
				{
					item = _queue[0];
					return true;
				}
			}
			item = default(T);
			return false;
		}

		public T[] ToArray()
		{
			lock (_queue)
			{
				return _queue.ToArray();
			}
		}
	}
}
