using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyBox
{
	[Serializable]
	public class SceneReference : ISerializationCallbackReceiver
	{
		public class SceneLoadException : Exception
		{
			public SceneLoadException(string message)
				: base(message)
			{
			}
		}

		[Tooltip("The name of the referenced scene. This may be used at runtime to load the scene.")]
		public string SceneName;

		[SerializeField]
		private int sceneIndex = -1;

		[SerializeField]
		private bool sceneEnabled;

		public bool IsAssigned => !string.IsNullOrEmpty(SceneName);

		public void LoadScene(LoadSceneMode mode = LoadSceneMode.Single)
		{
			ValidateScene();
			SceneManager.LoadScene(SceneName, mode);
		}

		public AsyncOperation LoadSceneAsync(LoadSceneMode mode = LoadSceneMode.Single)
		{
			ValidateScene();
			return SceneManager.LoadSceneAsync(SceneName, mode);
		}

		public AsyncOperation UnloadSceneAsync()
		{
			ValidateScene();
			return SceneManager.UnloadSceneAsync(SceneName);
		}

		public bool SetActive()
		{
			return SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
		}

		private void ValidateScene()
		{
			if (string.IsNullOrEmpty(SceneName))
			{
				throw new SceneLoadException("No scene specified.");
			}
			if (sceneIndex < 0)
			{
				throw new SceneLoadException("Scene " + SceneName + " is not in the build settings");
			}
			if (!sceneEnabled)
			{
				throw new SceneLoadException("Scene " + SceneName + " is not enabled in the build settings");
			}
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
