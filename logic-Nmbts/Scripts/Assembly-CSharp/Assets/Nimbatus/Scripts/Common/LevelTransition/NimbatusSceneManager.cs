using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.Scripts.Common.LevelTransition
{
	public class NimbatusSceneManager : MonoBehaviour
	{
		private static NimbatusSceneManager _instance;

		public static int LoadingProgress;

		public static string NextSceneName;

		public static string BookmarkedScene;

		public static Dictionary<string, string> ReturnScenes = new Dictionary<string, string>();

		public static NimbatusSceneManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = UnityEngine.Object.FindObjectOfType<NimbatusSceneManager>();
				}
				if (_instance == null)
				{
					_instance = new GameObject().AddComponent<NimbatusSceneManager>();
				}
				return _instance;
			}
		}

		public static event Action OnBeforeSceneChange;

		public void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		public static void SetReturnScene(string scene, string returnScene)
		{
			if (ReturnScenes.ContainsKey(scene))
			{
				ReturnScenes[scene] = returnScene;
			}
			else
			{
				ReturnScenes.Add(scene, returnScene);
			}
		}

		public static string GetReturnScene()
		{
			string key = SceneManager.GetActiveScene().name;
			string value;
			if (ReturnScenes.TryGetValue(key, out value))
			{
				return value;
			}
			return "";
		}

		public static void BookmarkActiveScene()
		{
			BookmarkedScene = SceneManager.GetActiveScene().name;
		}

		public static void LoadScene(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				Debug.LogError("No return scene specified");
				return;
			}
			RuntimeGlobals.ResetToDefault();
			NextSceneName = name;
			AudioController.StopCategory("TravelEvents", 0.25f);
			Instance.LoadScene();
		}

		public static void GoToBookmarkedScene()
		{
			RuntimeGlobals.ResetToDefault();
			NextSceneName = BookmarkedScene;
			Instance.LoadScene();
		}

		public static void ReloadCurrentScene()
		{
			RuntimeGlobals.ResetToDefault();
			NextSceneName = SceneManager.GetActiveScene().name;
			Instance.LoadScene();
		}

		private void LoadScene()
		{
			Action onBeforeSceneChange = NimbatusSceneManager.OnBeforeSceneChange;
			if (onBeforeSceneChange != null)
			{
				onBeforeSceneChange();
			}
			RuntimeGlobals.IsGameLoading = true;
			SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);
			RuntimeGlobals.IsGameLoading = false;
		}
	}
}
