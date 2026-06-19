using UnityEngine;

namespace Loxodon.Framework.ObjectPool
{
	public abstract class UnityMixedComponentFactoryBase<T> : IMixedObjectFactory<T> where T : Component
	{
		private class PooledUnityObject : MonoBehaviour, IPooledObject
		{
			internal IMixedObjectPool<T> pool;

			internal T target;

			internal string typeName;

			public void Free()
			{
				if (pool != null)
				{
					pool.Free(typeName, target);
				}
			}
		}

		public virtual T Create(IMixedObjectPool<T> pool, string typeName)
		{
			T val = Create(typeName);
			PooledUnityObject pooledUnityObject = val.gameObject.AddComponent<PooledUnityObject>();
			pooledUnityObject.pool = pool;
			pooledUnityObject.target = val;
			pooledUnityObject.typeName = typeName;
			return val;
		}

		protected abstract T Create(string typeName);

		public abstract void Reset(string typeName, T obj);

		public virtual void Destroy(string typeName, T obj)
		{
			Object.Destroy(obj.gameObject);
		}

		public virtual bool Validate(string typeName, T obj)
		{
			return true;
		}
	}
}
