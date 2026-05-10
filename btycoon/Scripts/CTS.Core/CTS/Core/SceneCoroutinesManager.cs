using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;

namespace CTS.Core
{
	public static class SceneCoroutinesManager
	{
		private static Dictionary<int, SceneCoroutines> _initScenes = new Dictionary<int, SceneCoroutines>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
			SceneManager.sceneUnloaded += OnSceneUnloaded;
		}

		private static void OnSceneUnloaded(Scene scene)
		{
			try
			{
				_initScenes.Remove(scene.handle);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}

		public static Coroutine StartCoroutine(this Scene scene, IEnumerator routine)
		{
			return GetScenePlayer(scene).StartCoroutine(routine);
		}

		public static Coroutine StartCoroutine(this Scene scene, string methodName)
		{
			return GetScenePlayer(scene).StartCoroutine(methodName);
		}

		public static Coroutine StartCoroutine(this Scene scene, string methodName, [DefaultValue("null")] object value)
		{
			return GetScenePlayer(scene).StartCoroutine(methodName, value);
		}

		public static void StopCoroutine(this Scene scene, IEnumerator routine)
		{
			if (_initScenes.TryGetValue(scene.handle, out var value))
			{
				value.StopCoroutine(routine);
			}
		}

		public static void StopCoroutine(this Scene scene, string methodName)
		{
			if (_initScenes.TryGetValue(scene.handle, out var value))
			{
				value.StopCoroutine(methodName);
			}
		}

		public static void StopCoroutine(this Scene scene, Coroutine routine)
		{
			if (_initScenes.TryGetValue(scene.handle, out var value))
			{
				value.StopCoroutine(routine);
			}
		}

		public static void StopAllCoroutines(this Scene scene)
		{
			if (_initScenes.TryGetValue(scene.handle, out var value))
			{
				value.StopAllCoroutines();
			}
		}

		private static MonoBehaviour GetScenePlayer(Scene scene)
		{
			if (!scene.isLoaded)
			{
				throw new Exception("Cannot start a coroutine as the scene isn't loaded");
			}
			if (_initScenes.TryGetValue(scene.handle, out var value))
			{
				return value;
			}
			GameObject gameObject = new GameObject("Scene Coroutines");
			SceneManager.MoveGameObjectToScene(gameObject, scene);
			value = gameObject.AddComponent<SceneCoroutines>();
			_initScenes[scene.handle] = value;
			return value;
		}
	}
}
