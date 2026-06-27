using UnityEngine;

namespace Restory.ObjectPools
{
	public static class GameObjectPoolEx
	{
		public static GameObject GetGameObject(this GameObjectPool pool, GameObject prefab, Transform parent = null)
		{
			return pool.Get(prefab, parent).gameObject;
		}

		public static T Get<T>(this GameObjectPool pool, T prefab, Transform parent = null) where T : Component
		{
			if (prefab == null)
			{
				return null;
			}
			return pool.Get(prefab.gameObject, parent).GetComponent<T>();
		}

		public static void Release(this GameObjectPool pool, GameObject instance)
		{
			if (instance.TryGetComponent<PoolableEntity>(out var component))
			{
				pool.Release(component);
				return;
			}
			Debug.LogWarning($"Attempt to Release GameObject {instance} " + "without PoolableEntity using pool");
			Object.Destroy(instance);
		}

		public static void Release<T>(this GameObjectPool pool, T instance) where T : Component
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
