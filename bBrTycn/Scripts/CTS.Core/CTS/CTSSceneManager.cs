using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	public static class CTSSceneManager
	{
		public static bool BeingDestroyed { get; private set; }

		public static event Action<Scene> OnSceneUnloading;

		public static AsyncOperation LoadSceneAsync(int sceneIndex, LoadSceneMode? mode = null)
		{
			if (mode == LoadSceneMode.Additive)
			{
				return SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
			}
			CTSSceneManager.OnSceneUnloading?.Invoke(SceneManager.GetActiveScene());
			SceneManager.sceneLoaded += OnSceneLoaded;
			return SceneManager.LoadSceneAsync(sceneIndex);
		}

		public static AsyncOperation UnloadSceneAsync(Scene scene)
		{
			return SceneManager.UnloadSceneAsync(scene);
		}

		private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
			BeingDestroyed = false;
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
			BeingDestroyed = false;
			OnSceneUnloading += OnSceneBeingUnloaded;
			Application.quitting += OnApplicationQuitting;
		}

		private static void OnApplicationQuitting()
		{
			BeingDestroyed = true;
			OnSceneUnloading -= OnSceneBeingUnloaded;
			Application.quitting -= OnApplicationQuitting;
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		private static void OnSceneBeingUnloaded(Scene scene)
		{
			BeingDestroyed = true;
		}
	}
}
