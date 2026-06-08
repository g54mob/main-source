using System.Collections.Concurrent;

namespace HandlebarsDotNet.Pools
{
	internal class InternalObjectPool<T, TPolicy> where T : class where TPolicy : IInternalObjectPoolPolicy<T>
	{
		private readonly TPolicy _policy;

		private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();

		public InternalObjectPool(TPolicy policy)
		{
			_policy = policy;
			for (int i = 0; i < 5; i++)
			{
				Return(_policy.Create());
			}
		}

		public T Get()
		{
			if (_queue.TryDequeue(out var result))
			{
				return result;
			}
			return _policy.Create();
		}

		public void Return(T obj)
		{
			if (_policy.Return(obj))
			{
				_queue.Enqueue(obj);
			}
		}
	}
}
