using UnityEngine;
using UnityEngine.SceneManagement;

namespace Libs
{
	public static class GameObjectExtension
	{
		public static void MoveScene(this GameObject gameObject, Scene scene)
		{
		}

		public static void MoveScene(this GameObject gameObject, string SceneName)
		{
		}

		public static void MoveActiveScene(this GameObject gameObject)
		{
		}

		public static void DestroyOnLoad(this GameObject gameObject)
		{
		}

		public static void MoveCanvas(this GameObject gameObject, string SceneName, Canvas canvas)
		{
		}

		public static void RemoveComponent<T>(this GameObject self) where T : Component
		{
		}

		public static void RemoveComponent<T>(this Component self) where T : Component
		{
		}

		public static string GetFullPath(this GameObject gameObject)
		{
			return null;
		}

		public static T AddComponent<T>(this Object uo) where T : Component
		{
			return null;
		}

		public static GameObject GameObject(this Object uo)
		{
			return null;
		}
	}
}
