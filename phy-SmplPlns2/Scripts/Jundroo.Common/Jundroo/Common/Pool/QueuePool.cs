using System.Collections.Generic;

namespace Jundroo.Common.Pool
{
	public class QueuePool<T>
	{
		private static readonly ObjectPool<Queue<T>> _sharedPool = new ObjectPool<Queue<T>>(() => new Queue<T>(), null, delegate(Queue<T> x)
		{
			x.Clear();
		});

		public static Queue<T> Get()
		{
			return _sharedPool.Get();
		}

		public static PooledObject<Queue<T>> Get(out Queue<T> value)
		{
			return _sharedPool.Get(out value);
		}

		public static void Release(Queue<T> value)
		{
			_sharedPool.Release(value);
		}
	}
}
