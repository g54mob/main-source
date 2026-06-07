using System.Collections.Generic;
using UnityEngine;

namespace ClockStone
{
	public static class ObjectPoolController
	{
		internal class ObjectPool
		{
			private List<PoolableObject> _pool;

			private GameObject _prefab;

			private PoolableObject _poolableObjectComponent;

			private Transform _poolParent;

			internal Transform poolParent => null;

			public ObjectPool(GameObject prefab)
			{
			}

			private void _ValidatePooledObjectDataContainer()
			{
			}

			private void _ValidatePoolParentDummy()
			{
			}

			internal void Remove(PoolableObject poolObj)
			{
			}

			internal int GetObjectCount()
			{
				return 0;
			}

			internal GameObject GetPooledInstance(Vector3? position, Quaternion? rotation, bool activateObject, Transform parent = null)
			{
				return null;
			}

			internal PoolableObject PreloadInstance(bool preloadActive)
			{
				return null;
			}

			private PoolableObject _NewPooledInstance(Vector3? position, Quaternion? rotation, bool createActive, bool addToPool)
			{
				return null;
			}

			internal int _SetAllAvailable()
			{
				return 0;
			}

			internal void CallMethodOnObject(GameObject obj, string method, bool includeChildren, bool includeInactive, bool useReflection)
			{
			}
		}

		internal static int _globalSerialNumber;

		internal static bool _isDuringInstantiate;

		private static Dictionary<int, ObjectPool> _pools;

		public static bool isDuringPreload { get; private set; }

		public static GameObject Instantiate(GameObject prefab, Transform parent = null)
		{
			return null;
		}

		public static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion quaternion, Transform parent = null)
		{
			return null;
		}

		public static GameObject InstantiateWithoutPool(GameObject prefab, Transform parent = null)
		{
			return null;
		}

		public static GameObject InstantiateWithoutPool(GameObject prefab, Vector3 position, Quaternion quaternion, Transform parent = null)
		{
			return null;
		}

		private static GameObject _InstantiateGameObject(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
		{
			return null;
		}

		public static void Destroy(GameObject obj)
		{
		}

		public static void DestroyImmediate(GameObject obj)
		{
		}

		public static void Preload(GameObject prefab)
		{
		}

		internal static ObjectPool _GetPool(PoolableObject prefabPoolComponent)
		{
			return null;
		}

		private static void _DetachChildrenAndDestroy(Transform transform, bool destroyImmediate)
		{
		}
	}
}
