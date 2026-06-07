using UnityEngine;

namespace Mirror
{
	public static class Utils
	{
		public static uint GetTrueRandomUInt()
		{
			return 0u;
		}

		public static bool IsPrefab(GameObject obj)
		{
			return false;
		}

		public static bool IsSceneObjectWithPrefabParent(GameObject gameObject, out GameObject prefab)
		{
			prefab = null;
			return false;
		}
	}
}
