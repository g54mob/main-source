using System.Collections.Generic;
using UnityEngine;

namespace Gh
{
	public class PrefabObjectPool
	{
		private List<GameObject> _pool;

		private GameObject _prefab;

		public PrefabObjectPool(GameObject prefab, int startingPoolSize = 30, bool initilizeWithObjects = false, Transform parent = null)
		{
		}

		public T GetPoolObject<T>() where T : Component
		{
			return null;
		}

		public GameObject GetPoolObject()
		{
			return null;
		}

		private GameObject CreateNewObject()
		{
			return null;
		}
	}
}
