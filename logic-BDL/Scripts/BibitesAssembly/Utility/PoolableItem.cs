using UnityEngine;

namespace Utility
{
	public abstract class PoolableItem<T> : MonoBehaviour where T : PoolableItem<T>
	{
		public IItemPool<T> pool;

		public void InitPoolableItem(IItemPool<T> parentPool)
		{
			pool = parentPool;
			Initialize();
		}

		public virtual void Initialize()
		{
		}

		public void ReturnToPool()
		{
			pool?.ReturnItem(this as T);
		}

		public void ReturnToPoolDelayed()
		{
			pool?.ReturnItemDelayed(this as T);
		}

		public virtual void WakeUp()
		{
			base.gameObject.SetActive(value: true);
		}

		public virtual void Retire()
		{
			base.gameObject.SetActive(value: false);
		}

		public virtual void Destroy()
		{
			Object.Destroy(base.gameObject);
		}
	}
}
