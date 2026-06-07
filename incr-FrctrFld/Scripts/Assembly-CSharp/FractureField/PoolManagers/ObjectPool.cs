using System;
using System.Collections.Generic;

namespace FractureField.PoolManagers
{
	public class ObjectPool<T>
	{
		private List<ObjectPoolContainer<T>> list;

		private Dictionary<T, ObjectPoolContainer<T>> lookup;

		private Func<T> factoryFunc;

		private int lastIndex;

		public int Count => 0;

		public int CountUsedItems => 0;

		public ObjectPool(Func<T> factoryFunc, int initialSize)
		{
		}

		private void Warm(int capacity)
		{
		}

		private ObjectPoolContainer<T> CreateContainer()
		{
			return null;
		}

		public T GetItem()
		{
			return default(T);
		}

		public void ReleaseItem(object item)
		{
		}

		public void ReleaseItem(T item)
		{
		}
	}
}
