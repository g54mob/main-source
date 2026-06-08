using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.Pooling
{
	public class ObjectPool : MonoBehaviour
	{
		private Dictionary<object, List<PoolObject>> pools;

		private static ObjectPool _global;

		public static ObjectPool global => null;

		private static ObjectPool LoadGlobal()
		{
			return null;
		}

		public T Spawn<T>(object key, T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : PoolObject
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		public void Pool(object key, PoolObject obj)
		{
		}

		public void Destroy(object key, PoolObject obj)
		{
		}

		public T Spawn<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : PoolObject
		{
			return null;
		}

		public T Spawn<T>(T prefab, Vector3 position, Quaternion rotation) where T : PoolObject
		{
			return null;
		}

		public T Spawn<T>(T prefab, Transform parent) where T : PoolObject
		{
			return null;
		}

		public T Spawn<T>(T prefab) where T : PoolObject
		{
			return null;
		}

		public virtual T GetInstance<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : PoolObject
		{
			return null;
		}

		public virtual void UpdateInstance<T>(T instance, Vector3 position, Quaternion rotation, Transform parent) where T : PoolObject
		{
		}
	}
}
