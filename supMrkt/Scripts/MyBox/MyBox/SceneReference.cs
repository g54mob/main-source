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
			{
			}
		}

		[Tooltip("The name of the referenced scene. This may be used at runtime to load the scene.")]
		public string SceneName;

		[SerializeField]
		private int sceneIndex;

		[SerializeField]
		private bool sceneEnabled;

		public bool IsAssigned => false;

		public void LoadScene(LoadSceneMode mode = LoadSceneMode.Single)
		{
		}

		public AsyncOperation LoadSceneAsync(LoadSceneMode mode = LoadSceneMode.Single)
		{
			return null;
		}

		public AsyncOperation UnloadSceneAsync()
		{
			return null;
		}

		public bool SetActive()
		{
			return false;
		}

		private void ValidateScene()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
