using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dhs5.Utility.Scenes
{
	[Serializable]
	public class SceneReference
	{
		[SerializeField]
		private int m_sceneIndex;

		[SerializeField]
		private string m_sceneName;

		[SerializeField]
		private string m_scenePath;

		public int SceneIndex => m_sceneIndex;

		public string SceneName => m_sceneName;

		public string ScenePath => m_scenePath;

		public bool IsLoaded
		{
			get
			{
				Scene sceneByBuildIndex = SceneManager.GetSceneByBuildIndex(SceneIndex);
				if (sceneByBuildIndex.IsValid())
				{
					return sceneByBuildIndex.isLoaded;
				}
				return false;
			}
		}

		public bool LoadScene(LoadSceneMode mode = LoadSceneMode.Single)
		{
			if (SceneIndex > -1)
			{
				SceneManager.LoadScene(SceneIndex, mode);
				return true;
			}
			return false;
		}

		public bool UnloadScene(UnloadSceneOptions options = UnloadSceneOptions.None)
		{
			Scene sceneByName = SceneManager.GetSceneByName(SceneName);
			if (sceneByName.IsValid())
			{
				SceneManager.UnloadSceneAsync(sceneByName, options);
				return true;
			}
			return false;
		}
	}
}
