using System.Collections.Generic;
using UnityEngine;

namespace FractureField.PoolManagers
{
	public class PoolManager : Singleton<PoolManager>
	{
		public bool LogStatus;

		private Dictionary<GameObject, ObjectPool<GameObject>> _prefabLookup;

		private Dictionary<GameObject, Transform> _prefabParentLookup;

		private Dictionary<GameObject, ObjectPool<GameObject>> _instanceLookup;

		private bool _dirty;

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		public void WarmPoolInternal(GameObject prefab, Transform parent, int size)
		{
		}

		public GameObject SpawnObjectInternal(GameObject prefab, Transform parent)
		{
			return null;
		}

		public GameObject SpawnObjectInternal(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
		{
			return null;
		}

		public void ReleaseObjectInternal(GameObject clone)
		{
		}

		private GameObject InstantiatePrefab(GameObject prefab)
		{
			return null;
		}

		public void PrintStatus()
		{
		}

		public static void WarmPool(GameObject prefab, Transform parent, int size)
		{
		}

		public static GameObject SpawnObject(GameObject prefab, Transform parent)
		{
			return null;
		}

		public static GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
		{
			return null;
		}

		public static void ReleaseObject(GameObject clone)
		{
		}
	}
}
