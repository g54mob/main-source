using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS.Utilities
{
	public static class ObjectUtility
	{
		private static readonly Dictionary<int, Transform> _roots = new Dictionary<int, Transform>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
			SceneManager.sceneUnloaded += OnSceneUnloaded;
		}

		private static void OnSceneUnloaded(Scene scene)
		{
			_roots.Remove(scene.handle);
		}

		public static Transform GetInactiveRoot(this GameObject obj)
		{
			Scene scene = obj.scene;
			if (!_roots.TryGetValue(scene.handle, out var value))
			{
				value = new GameObject("Inactive Root").transform;
				_roots[scene.handle] = value;
			}
			value.gameObject.SetActive(value: false);
			return value;
		}

		public static Transform GetInactiveRoot(this Component component)
		{
			return component.gameObject.GetInactiveRoot();
		}
	}
}
