using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kamgam.SettingsGenerator
{
	public static class FindComponentUtils
	{
		public static T FindComponentInAllLoadedScenes<T>(bool includeInactive, Predicate<Scene> scenePredicate = null)
		{
			List<T> list = FindComponentsInAllLoadedScenes<T>(includeInactive, scenePredicate);
			if (list.Count > 0)
			{
				return list[0];
			}
			return default(T);
		}

		public static List<T> FindComponentsInAllLoadedScenes<T>(bool includeInactive, Predicate<Scene> scenePredicate = null)
		{
			Scene[] array = new Scene[SceneManager.sceneCount];
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (scenePredicate == null || scenePredicate(sceneAt))
				{
					array[i] = SceneManager.GetSceneAt(i);
				}
			}
			return FindComponentsInScenes<T>(includeInactive, array);
		}

		public static List<T> FindComponentsInScenes<T>(bool includeInactive, params Scene[] scenes)
		{
			try
			{
				return (from g in scenes.Where((Scene s) => s.IsValid()).SelectMany((Scene s) => s.GetRootGameObjects())
					where includeInactive || g.activeInHierarchy
					select g).SelectMany((GameObject g) => g.GetComponentsInChildren<T>(includeInactive)).ToList();
			}
			catch (Exception)
			{
				return new List<T>();
			}
		}
	}
}
