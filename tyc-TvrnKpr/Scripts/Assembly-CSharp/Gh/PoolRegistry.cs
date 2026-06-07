using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh
{
	public class PoolRegistry : SingletonMonoBehaviour<PoolRegistry>
	{
		[Serializable]
		public class PreRegisteredPool
		{
			public GameObject prefab;

			public int startingPoolSize;

			public bool initilizeWithObjects;
		}

		private static Dictionary<GameObject, PrefabObjectPool> _pools;

		public Transform placeholderParent;

		public List<PreRegisteredPool> preRegisteredPools;

		public static Transform PlaceholderParent => null;

		public static bool HasPool(GameObject prefab)
		{
			return false;
		}

		public static PrefabObjectPool GetPool(GameObject prefab)
		{
			return null;
		}

		public static bool TryGetPool(GameObject prefab, out PrefabObjectPool pool)
		{
			pool = null;
			return false;
		}

		public static void HandBackObjects(IEnumerable<GameObject> objs)
		{
		}

		public static void HandBackObjects(IEnumerable<MonoBehaviour> objs)
		{
		}

		public static void HandBackObject(GameObject obj)
		{
		}

		public override void Awake()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
