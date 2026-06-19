using UnityEngine;

namespace Loxodon.Framework.ObjectPool
{
	public abstract class UnityGameObjectFactoryBase : IObjectFactory<GameObject>
	{
		private class PooledUnityObject : MonoBehaviour, IPooledObject
		{
			internal IObjectPool<GameObject> pool;

			public void Free()
			{
				if (pool != null)
				{
					pool.Free(base.gameObject);
				}
			}
		}

		public virtual GameObject Create(IObjectPool<GameObject> pool)
		{
			GameObject gameObject = Create();
			gameObject.AddComponent<PooledUnityObject>().pool = pool;
			return gameObject;
		}

		protected abstract GameObject Create();

		public abstract void Reset(GameObject obj);

		public virtual void Destroy(GameObject obj)
		{
			Object.Destroy(obj);
		}

		public virtual bool Validate(GameObject obj)
		{
			return true;
		}
	}
}
