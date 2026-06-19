using System;
using System.Threading;

namespace Loxodon.Framework.ObjectPool
{
	public class ObjectPool<T> : IObjectPool<T>, IObjectPool, IDisposable where T : class
	{
		private struct Entry
		{
			public T value;
		}

		private readonly Entry[] entries;

		private int maxSize;

		private int initialSize;

		protected readonly IObjectFactory<T> factory;

		private bool disposed;

		public int MaxSize => maxSize;

		public int InitialSize => initialSize;

		public ObjectPool(IObjectFactory<T> factory)
			: this(factory, 0, Environment.ProcessorCount * 2)
		{
		}

		public ObjectPool(IObjectFactory<T> factory, int maxSize)
			: this(factory, 0, maxSize)
		{
		}

		public ObjectPool(IObjectFactory<T> factory, int initialSize, int maxSize)
		{
			this.factory = factory;
			this.initialSize = initialSize;
			this.maxSize = maxSize;
			entries = new Entry[maxSize];
			if (maxSize < initialSize)
			{
				throw new ArgumentException("the maxSize must be greater than or equal to the initialSize");
			}
			for (int i = 0; i < initialSize; i++)
			{
				entries[i].value = factory.Create(this);
			}
		}

		public virtual T Allocate()
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			T val = null;
			for (int i = 0; i < entries.Length; i++)
			{
				val = entries[i].value;
				if (val != null && Interlocked.CompareExchange(ref entries[i].value, null, val) == val)
				{
					return val;
				}
			}
			return factory.Create(this);
		}

		public virtual void Free(T obj)
		{
			if (obj == null)
			{
				return;
			}
			if (disposed || !factory.Validate(obj))
			{
				factory.Destroy(obj);
				return;
			}
			factory.Reset(obj);
			for (int i = 0; i < entries.Length; i++)
			{
				if (Interlocked.CompareExchange(ref entries[i].value, obj, null) == null)
				{
					return;
				}
			}
			factory.Destroy(obj);
		}

		object IObjectPool.Allocate()
		{
			return Allocate();
		}

		void IObjectPool.Free(object obj)
		{
			Free((T)obj);
		}

		protected virtual void Clear()
		{
			for (int i = 0; i < entries.Length; i++)
			{
				T val = Interlocked.Exchange(ref entries[i].value, null);
				if (val != null)
				{
					factory.Destroy(val);
				}
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				Clear();
				disposed = true;
			}
		}

		~ObjectPool()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
