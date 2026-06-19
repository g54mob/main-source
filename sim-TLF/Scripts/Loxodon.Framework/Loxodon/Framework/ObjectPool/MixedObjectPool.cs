using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Loxodon.Framework.ObjectPool
{
	public class MixedObjectPool<T> : IMixedObjectPool<T>, IDisposable where T : class
	{
		private const int DEFAULT_MAX_SIZE_PER_TYPE = 8;

		private readonly ConcurrentDictionary<string, List<T>> entries;

		private readonly ConcurrentDictionary<string, int> typeSize;

		private readonly IMixedObjectFactory<T> factory;

		private readonly object _lock = new object();

		private int defaultMaxSizePerType;

		private bool disposed;

		public MixedObjectPool(IMixedObjectFactory<T> factory)
			: this(factory, 8)
		{
		}

		public MixedObjectPool(IMixedObjectFactory<T> factory, int defaultMaxSizePerType)
		{
			this.factory = factory;
			this.defaultMaxSizePerType = defaultMaxSizePerType;
			if (defaultMaxSizePerType <= 0)
			{
				throw new ArgumentException("the maxSize must be greater than 0");
			}
			entries = new ConcurrentDictionary<string, List<T>>();
			typeSize = new ConcurrentDictionary<string, int>();
		}

		public int GetMaxSize(string typeName)
		{
			if (typeSize.TryGetValue(typeName, out var value))
			{
				return value;
			}
			return defaultMaxSizePerType;
		}

		public void SetMaxSize(string typeName, int value)
		{
			typeSize.AddOrUpdate(typeName, value, (string key, int oldValue) => value);
		}

		public T Allocate(string typeName)
		{
			if (disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			lock (_lock)
			{
				if (entries.TryGetValue(typeName, out var value) && value.Count > 0)
				{
					T result = value[0];
					value.RemoveAt(0);
					return result;
				}
			}
			return factory.Create(this, typeName);
		}

		public void Free(string typeName, T obj)
		{
			if (obj == null)
			{
				return;
			}
			if (disposed || !factory.Validate(typeName, obj))
			{
				factory.Destroy(typeName, obj);
				return;
			}
			lock (_lock)
			{
				int maxSize = GetMaxSize(typeName);
				List<T> orAdd = entries.GetOrAdd(typeName, (string n) => new List<T>());
				if (orAdd.Count >= maxSize)
				{
					factory.Destroy(typeName, obj);
					return;
				}
				factory.Reset(typeName, obj);
				orAdd.Add(obj);
			}
		}

		protected virtual void Clear()
		{
			lock (_lock)
			{
				foreach (KeyValuePair<string, List<T>> entry in entries)
				{
					string typeName = entry.Key;
					List<T> value = entry.Value;
					if (value != null && value.Count > 0)
					{
						value.ForEach(delegate(T e)
						{
							factory.Destroy(typeName, e);
						});
						value.Clear();
					}
				}
				entries.Clear();
				typeSize.Clear();
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

		~MixedObjectPool()
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
