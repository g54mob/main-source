using UnityEngine;

namespace Restory.ObjectPools
{
	public static class ConcreteGameObjectPoolEx
	{
		public static GameObject GetGameObject(this ConcreteGameObjectPool pool, Transform parent = null)
		{
			return pool.Get(parent).gameObject;
		}

		public static T Get<T>(this ConcreteGameObjectPool pool, Transform parent = null) where T : Component
		{
			return pool.Get(parent).GetComponent<T>();
		}

		public static void Release(this ConcreteGameObjectPool pool, GameObject instance)
		{
			if ((bool)instance)
			{
				if (instance.TryGetComponent<PoolableEntity>(out var component))
				{
					pool.Release(component);
					return;
				}
				Debug.LogWarning($"Attempt to Release GameObject {instance} " + "without PoolableEntity using pool");
				Object.Destroy(instance);
			}
		}

		public static void Release<T>(this ConcreteGameObjectPool pool, T instance) where T : Component
		{
			if ((bool)instance)
			{
				if (instance.TryGetComponent<PoolableEntity>(out var component))
				{
					pool.Release(component);
					return;
				}
				Debug.LogWarning($"Attempt to Release GameObject {instance} " + "without PoolableEntity using pool");
				Object.Destroy(instance);
			}
		}
	}
}
