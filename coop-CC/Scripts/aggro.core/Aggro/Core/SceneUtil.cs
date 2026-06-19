using System.Collections.Generic;
using System.IO;
using Aggro.Util;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Aggro.Core
{
	public static class SceneUtil
	{
		private static List<GameObject> _gameObjects = new List<GameObject>();

		private static Dictionary<string, Scene> _loadedScenes = new Dictionary<string, Scene>();

		public static T FindObjectOfType<T>(Scene scene, bool includeInactive = false)
		{
			try
			{
				scene.GetRootGameObjects(_gameObjects);
				for (int i = 0; i < _gameObjects.Count; i++)
				{
					T componentInChildren = _gameObjects[i].GetComponentInChildren<T>(includeInactive);
					if (componentInChildren != null)
					{
						return componentInChildren;
					}
				}
				return default(T);
			}
			finally
			{
				_gameObjects.Clear();
			}
		}

		public static T[] FindObjectsOfType<T>(Scene scene, bool includeInactive = false)
		{
			List<T> list = new List<T>();
			try
			{
				scene.GetRootGameObjects(_gameObjects);
				for (int i = 0; i < _gameObjects.Count; i++)
				{
					GameObject gameObject = _gameObjects[i];
					if (gameObject.activeSelf)
					{
						list.AddRange(gameObject.GetComponentsInChildren<T>(includeInactive));
					}
				}
			}
			finally
			{
				_gameObjects.Clear();
			}
			return list.ToArray();
		}

		public static bool IsSceneLoaded(string sceneName)
		{
			for (int i = 0; i < SceneManager.loadedSceneCount; i++)
			{
				if (SceneManager.GetSceneAt(i).name == sceneName)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsSceneLoaded(AssetReferenceScene sceneRef)
		{
			Scene scene;
			return TryGetLoadedScene(sceneRef, out scene);
		}

		public static bool TryGetLoadedScene(AssetReferenceScene sceneRef, out Scene scene)
		{
			if (!AssetsUtil.IsAssetReferenceValid(sceneRef))
			{
				scene = default(Scene);
				return false;
			}
			_loadedScenes.Clear();
			for (int i = 0; i < SceneManager.loadedSceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				_loadedScenes[sceneAt.name] = sceneAt;
			}
			foreach (IResourceLocator resourceLocator in Addressables.ResourceLocators)
			{
				if (!resourceLocator.Locate(sceneRef.RuntimeKey, typeof(SceneInstance), out var locations))
				{
					continue;
				}
				foreach (IResourceLocation item in locations)
				{
					if (_loadedScenes.TryGetValue(Path.GetFileNameWithoutExtension(item.InternalId), out scene))
					{
						return true;
					}
				}
			}
			scene = default(Scene);
			return false;
		}
	}
}
