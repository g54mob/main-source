using System;
using System.Collections.Concurrent;

namespace PajamaLlama
{
	public class ObjectPool<T>
	{
		private readonly ConcurrentBag<T> _objects;

		private readonly Func<T> _objectGenerator;

		private readonly int _capacity;

		public int Count { get; private set; }

		public ObjectPool(Func<T> objectGenerator, int capacity = 0)
		{
			_objectGenerator = objectGenerator ?? throw new ArgumentNullException("objectGenerator");
			_objects = new ConcurrentBag<T>();
			_capacity = capacity;
		}

		public T Get()
		{
			if (_objects.TryTake(out var result))
			{
				return result;
			}
			if (_capacity <= 0 || Count < _capacity)
			{
				Count++;
				return _objectGenerator();
			}
			return default(T);
		}

		public bool TryGet(out T instance)
		{
			instance = Get();
			return instance != null;
		}

		public bool CanGet()
		{
			if (0 >= _objects.Count && _capacity > 0)
			{
				return Count < _capacity;
			}
			return true;
		}

		public void Return(T item)
		{
			if (item != null)
			{
				_objects.Add(item);
			}
		}
	}
}
