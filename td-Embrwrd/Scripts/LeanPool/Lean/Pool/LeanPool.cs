using System.Collections.Generic;
using UnityEngine;

namespace Lean.Pool
{
	public static class LeanPool
	{
		public const string HelpUrlPrefix = "https://carloswilkes.com/Documentation/LeanCommon#LeanPool#";

		public const string ComponentPathPrefix = "Lean/Pool/Lean ";

		public static Dictionary<GameObject, LeanGameObjectPool> Links;

		public static T Spawn<T>(T prefab, Transform parent, bool worldPositionStays = false) where T : Component
		{
			return null;
		}

		public static T Spawn<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component
		{
			return null;
		}

		public static T Spawn<T>(T prefab) where T : Component
		{
			return null;
		}

		public static GameObject Spawn(GameObject prefab, Transform parent, bool worldPositionStays = false)
		{
			return null;
		}

		public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return null;
		}

		public static GameObject Spawn(GameObject prefab)
		{
			return null;
		}

		private static GameObject Spawn(GameObject prefab, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			return null;
		}

		public static void DespawnAll()
		{
		}

		public static void Despawn(Component clone, float delay = 0f)
		{
		}

		public static void Despawn(GameObject clone, float delay = 0f)
		{
		}

		public static void Detach(Component clone, bool detachFromPool = true)
		{
		}

		public static void Detach(GameObject clone, bool detachFromPool)
		{
		}
	}
}
