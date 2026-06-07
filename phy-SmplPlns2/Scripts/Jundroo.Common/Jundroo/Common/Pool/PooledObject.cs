using System;

namespace Jundroo.Common.Pool
{
	public struct PooledObject<T> : IDisposable where T : class
	{
		private ObjectPool<T> _pool;

		private T _value;

		public T Value => _value ?? throw new ObjectDisposedException("PooledObject");

		public PooledObject(T value, ObjectPool<T> pool)
		{
			_value = value;
			_pool = pool;
		}

		public void Dispose()
		{
			ObjectPool<T> pool = _pool;
			T value = _value;
			if (pool != null && value != null)
			{
				_pool = null;
				_value = null;
				pool.Release(value);
			}
		}
	}
}
