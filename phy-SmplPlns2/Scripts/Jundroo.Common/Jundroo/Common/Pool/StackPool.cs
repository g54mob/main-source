using System.Collections.Generic;

namespace Jundroo.Common.Pool
{
	public class StackPool<T>
	{
		private static readonly ObjectPool<Stack<T>> _sharedPool = new ObjectPool<Stack<T>>(() => new Stack<T>(), null, delegate(Stack<T> x)
		{
			x.Clear();
		});

		public static Stack<T> Get()
		{
			return _sharedPool.Get();
		}

		public static PooledObject<Stack<T>> Get(out Stack<T> value)
		{
			return _sharedPool.Get(out value);
		}

		public static void Release(Stack<T> value)
		{
			_sharedPool.Release(value);
		}
	}
}
