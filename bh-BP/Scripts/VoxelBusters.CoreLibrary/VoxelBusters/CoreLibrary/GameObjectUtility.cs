using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public static class GameObjectUtility
	{
		public static GameObject Instantiate(GameObject prefab, Transform parent = null)
		{
			return null;
		}

		public static GameObject Instantiate(GameObject prefab, Action<GameObject> onBeforeAwake)
		{
			return null;
		}

		public static GameObject CreateChild(string childName, Transform parent)
		{
			return null;
		}

		public static GameObject CreateChild(string childName, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent)
		{
			return null;
		}

		public static GameObject CreateGameObject(string name, Action<GameObject> onBeforeActive = null)
		{
			return null;
		}

		public static T CreateGameObjectWithComponent<T>(string name, Action<T> onBeforeAwake = null) where T : Component
		{
			return null;
		}

		public static void SetActive(this GameObject[] gameObjects, bool value)
		{
		}
	}
}
