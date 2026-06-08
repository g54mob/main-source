using System;
using System.Collections;
using System.Collections.Generic;

namespace LaundryBear
{
	public class Pool<T>
	{
		public class PooledObject
		{
			private T m_source;

			internal Action<PooledObject> m_returnToPool;

			public T Value => m_source;

			public PooledObject(T source, Action<PooledObject> returnDelegate)
			{
				m_source = source;
				m_returnToPool = returnDelegate;
			}

			internal void AssignReturnDelegate(Action<PooledObject> returnDelegate)
			{
				m_returnToPool = returnDelegate;
			}

			public void Release()
			{
				m_returnToPool(this);
			}

			public static implicit operator T(PooledObject pooledObject)
			{
				return pooledObject.m_source;
			}
		}

		private Func<T> m_creator;

		private Func<T[], IEnumerator> m_creatorAsync;

		private Action<T> m_reset;

		private Stack<PooledObject> m_pooledObjects;

		private List<PooledObject> m_allPoolCreatedObjects;

		public Pool(int initialCount, Func<T> creator, Func<T[], IEnumerator> creatorAsync, Action<T> reset)
		{
			m_creator = creator;
			m_creatorAsync = creatorAsync;
			m_reset = reset;
			m_pooledObjects = new Stack<PooledObject>(initialCount);
			m_allPoolCreatedObjects = new List<PooledObject>(initialCount);
			for (int i = 0; i < initialCount; i++)
			{
				PooledObject item = new PooledObject(creator(), ReturnToPool);
				m_pooledObjects.Push(item);
				m_allPoolCreatedObjects.Add(item);
			}
		}

		public IEnumerator GrowPoolAsync(int count)
		{
			T[] newPooledObjects = new T[count];
			yield return m_creatorAsync(newPooledObjects);
			for (int i = 0; i < newPooledObjects.Length; i++)
			{
				PooledObject item = new PooledObject(newPooledObjects[i], ReturnToPool);
				m_pooledObjects.Push(item);
				m_allPoolCreatedObjects.Add(item);
			}
		}

		public void GrowPool(int count)
		{
			T[] array = new T[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = m_creator();
			}
			for (int j = 0; j < array.Length; j++)
			{
				PooledObject item = new PooledObject(array[j], ReturnToPool);
				m_pooledObjects.Push(item);
				m_allPoolCreatedObjects.Add(item);
			}
		}

		public PooledObject GetObject()
		{
			if (m_pooledObjects.Count == 0)
			{
				m_pooledObjects.Push(new PooledObject(m_creator(), ReturnToPool));
			}
			return m_pooledObjects.Pop();
		}

		private void ReturnToPool(PooledObject source)
		{
			m_reset(source);
			m_pooledObjects.Push(source);
		}

		public IEnumerator InvokeOnAllObjectsAsync(Func<T, IEnumerator> processor)
		{
			foreach (PooledObject allPoolCreatedObject in m_allPoolCreatedObjects)
			{
				yield return processor(allPoolCreatedObject);
			}
		}

		public void InvokeOnAllObjects(Action<T> processor)
		{
			foreach (PooledObject allPoolCreatedObject in m_allPoolCreatedObjects)
			{
				processor(allPoolCreatedObject);
			}
		}
	}
}
