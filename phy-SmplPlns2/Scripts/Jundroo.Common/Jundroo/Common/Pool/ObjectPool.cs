using System;
using System.Collections.Generic;
using System.Threading;

namespace Jundroo.Common.Pool
{
	public sealed class ObjectPool<T> : IDisposable where T : class
	{
		private readonly Action<T> _actionOnDestroy;

		private readonly Action<T> _actionOnGet;

		private readonly Action<T> _actionOnRelease;

		private readonly Func<T> _createFunc;

		private readonly T[] _fastPool;

		private readonly object _lock = new object();

		private readonly int _maxCapacity;

		private readonly Stack<T> _pool;

		private int _disposed;

		public ObjectPool(Func<T> createFunc, Action<T> actionOnGet = null, Action<T> actionOnRelease = null, Action<T> actionOnDestroy = null, int defaultCapacity = 16, int maxCapacity = 1024, int fastPoolCapacity = 4)
		{
			if (createFunc == null)
			{
				throw new ArgumentNullException("createFunc");
			}
			if (defaultCapacity < 0)
			{
				throw new ArgumentOutOfRangeException("defaultCapacity");
			}
			if (maxCapacity < defaultCapacity)
			{
				throw new ArgumentOutOfRangeException("maxCapacity");
			}
			if (fastPoolCapacity < 0)
			{
				throw new ArgumentOutOfRangeException("fastPoolCapacity");
			}
			_createFunc = createFunc;
			_actionOnGet = actionOnGet;
			_actionOnRelease = actionOnRelease;
			_actionOnDestroy = actionOnDestroy;
			_maxCapacity = maxCapacity;
			_pool = new Stack<T>(defaultCapacity);
			_fastPool = new T[fastPoolCapacity];
		}

		public void Clear()
		{
			for (int i = 0; i < _fastPool.Length; i++)
			{
				T val = Interlocked.Exchange(ref _fastPool[i], null);
				if (val != null)
				{
					DestroyObject(val);
				}
			}
			lock (_lock)
			{
				while (_pool.Count > 0)
				{
					DestroyObject(_pool.Pop());
				}
			}
		}

		public void Dispose()
		{
			if (Interlocked.Exchange(ref _disposed, 1) == 0)
			{
				Clear();
			}
		}

		public T Get()
		{
			if (Volatile.Read(ref _disposed) != 0)
			{
				throw new ObjectDisposedException("ObjectPool");
			}
			T val = null;
			for (int i = 0; i < _fastPool.Length; i++)
			{
				val = Interlocked.Exchange(ref _fastPool[i], null);
				if (val != null)
				{
					break;
				}
			}
			if (val == null)
			{
				lock (_lock)
				{
					if (Volatile.Read(ref _disposed) != 0)
					{
						throw new ObjectDisposedException("ObjectPool");
					}
					if (_pool.Count > 0)
					{
						val = _pool.Pop();
					}
				}
			}
			if (val == null)
			{
				val = _createFunc();
			}
			_actionOnGet?.Invoke(val);
			return val;
		}

		public PooledObject<T> Get(out T obj)
		{
			return new PooledObject<T>(obj = Get(), this);
		}

		public void Release(T obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			_actionOnRelease?.Invoke(obj);
			if (Volatile.Read(ref _disposed) != 0)
			{
				DestroyObject(obj);
				return;
			}
			for (int i = 0; i < _fastPool.Length; i++)
			{
				if (Volatile.Read(ref _fastPool[i]) == null && Interlocked.CompareExchange(ref _fastPool[i], obj, null) == null)
				{
					return;
				}
			}
			lock (_lock)
			{
				if (Volatile.Read(ref _disposed) != 0)
				{
					DestroyObject(obj);
					return;
				}
				if (_pool.Count < _maxCapacity)
				{
					_pool.Push(obj);
					return;
				}
			}
			DestroyObject(obj);
		}

		private void DestroyObject(T obj)
		{
			_actionOnDestroy?.Invoke(obj);
		}
	}
}
