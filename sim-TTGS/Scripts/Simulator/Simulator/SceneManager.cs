using System;
using System.Collections;
using Dhs5.Utility.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Simulator
{
	public class SceneManager : TransientManager<SceneManager>
	{
		public enum Map
		{
			MENUS = 0,
			WORLD = 1,
			PREVIEW3D = 2
		}

		[Header("Scenes")]
		[SerializeField]
		private SceneReference m_menusScene;

		[SerializeField]
		private SceneReference m_worldScene;

		[SerializeField]
		private SceneReference m_preview3DScene;

		public bool IsMenusSceneLoaded => m_menusScene.IsLoaded;

		public bool IsWorldSceneLoaded => m_worldScene.IsLoaded;

		public static bool IsLoadingScene { get; private set; }

		public static bool IsUnloadingScene { get; private set; }

		public static bool IsReloadingScene { get; private set; }

		private Map LoadingMap { get; set; }

		public static event Action<Map> SceneLoaded;

		public static event Action<Map> SceneUnloaded;

		protected override void OnEnable()
		{
			base.OnEnable();
			LoadingScreen.CompletedShow += OnLoadingScreenCompleteShow;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			LoadingScreen.CompletedShow -= OnLoadingScreenCompleteShow;
		}

		public void LoadScene(Map map)
		{
			IsLoadingScene = true;
			LoadingMap = map;
			if (LoadingScreen.IsDisplayed)
			{
				StartLoadScene(GetMapBuildIndex(map));
			}
			else
			{
				TransientManager<LoadingScreen>.Instance.Show();
			}
		}

		public bool UnloadScene(Map map)
		{
			if (!UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(GetMapBuildIndex(map)).isLoaded)
			{
				return false;
			}
			IsUnloadingScene = true;
			LoadingMap = map;
			if (LoadingScreen.IsDisplayed)
			{
				StartUnloadScene(GetMapBuildIndex(map));
			}
			else
			{
				TransientManager<LoadingScreen>.Instance.Show();
			}
			return true;
		}

		public void ReloadScene(Map map)
		{
			if (UnloadScene(map))
			{
				IsReloadingScene = true;
			}
		}

		private void StartLoadScene(int buildIndex)
		{
			StartCoroutine(LoadScene(buildIndex));
		}

		private void StartUnloadScene(int buildIndex)
		{
			StartCoroutine(UnloadScene(buildIndex));
		}

		private IEnumerator LoadScene(int buildIndex)
		{
			AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
			while (!op.isDone)
			{
				yield return null;
			}
			SceneManager.SceneLoaded?.Invoke(LoadingMap);
			if (LoadingMap == Map.WORLD)
			{
				UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(GetMapBuildIndex(LoadingMap)));
			}
			IsLoadingScene = false;
		}

		private IEnumerator UnloadScene(int buildIndex)
		{
			AsyncOperation op = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(buildIndex);
			while (!op.isDone)
			{
				yield return null;
			}
			SceneManager.SceneUnloaded?.Invoke(LoadingMap);
			if (IsReloadingScene)
			{
				LoadScene(LoadingMap);
				IsReloadingScene = false;
			}
			IsUnloadingScene = false;
		}

		private void OnLoadingScreenCompleteShow()
		{
			if (IsLoadingScene)
			{
				StartLoadScene(GetMapBuildIndex(LoadingMap));
			}
			else if (IsUnloadingScene)
			{
				StartUnloadScene(GetMapBuildIndex(LoadingMap));
			}
		}

		private int GetMapBuildIndex(Map map)
		{
			return map switch
			{
				Map.MENUS => m_menusScene.SceneIndex, 
				Map.WORLD => m_worldScene.SceneIndex, 
				Map.PREVIEW3D => m_preview3DScene.SceneIndex, 
				_ => -1, 
			};
		}
	}
}
