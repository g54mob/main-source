using UnityEngine;

namespace Loxodon.Framework.ObjectPool
{
	public abstract class UnityMixedGameObjectFactoryBase : IMixedObjectFactory<GameObject>
	{
		private class PooledUnityObject : MonoBehaviour, IPooledObject
		{
			internal IMixedObjectPool<GameObject> pool;

			internal GameObject target;

			internal string typeName;

			public void Free()
			{
				if (pool != null)
				{
					pool.Free(typeName, target);
				}
			}
		}

		public virtual GameObject Create(IMixedObjectPool<GameObject> pool, string typeName)
		{
			GameObject gameObject = Create(typeName);
			PooledUnityObject pooledUnityObject = gameObject.gameObject.AddComponent<PooledUnityObject>();
			pooledUnityObject.pool = pool;
			pooledUnityObject.target = gameObject;
			pooledUnityObject.typeName = typeName;
			return gameObject;
		}

		protected abstract GameObject Create(string typeName);

		public abstract void Reset(string typeName, GameObject obj);

		public virtual void Destroy(string typeName, GameObject obj)
		{
			Object.Destroy(obj);
		}

		public virtual bool Validate(string typeName, GameObject obj)
		{
			return true;
		}
	}
}
