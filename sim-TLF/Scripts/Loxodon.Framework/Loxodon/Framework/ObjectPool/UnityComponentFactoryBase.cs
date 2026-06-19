using UnityEngine;

namespace Loxodon.Framework.ObjectPool
{
	public abstract class UnityComponentFactoryBase<T> : IObjectFactory<T> where T : Component
	{
		public virtual T Create(IObjectPool<T> pool)
		{
			T val = Create();
			PooledUnityObject pooledUnityObject = val.gameObject.AddComponent<PooledUnityObject>();
			pooledUnityObject.pool = pool;
			pooledUnityObject.target = val;
			return val;
		}

		protected abstract T Create();

		public abstract void Reset(T obj);

		public virtual void Destroy(T obj)
		{
			Object.Destroy(obj.gameObject);
		}

		public virtual bool Validate(T obj)
		{
			return true;
		}
	}
}
