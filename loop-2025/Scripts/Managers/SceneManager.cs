// SceneManagerEx.cs
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GptDeepResearch
{
	/// <summary>
	/// Simple singleton scene manager for Unity 2020.3.
	/// </summary>
	public static class SceneManager
	{
		/// <summary>
		/// Load the next scene in Build Settings. Wraps around to first.
		/// </summary>
		public static void LoadNextScene()
		{
			int current = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
			int total = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
			int next = (current + 1) % total;
			UnityEngine.SceneManagement.SceneManager.LoadScene(next);
		}

		/// <summary>
		/// Load by build index.
		/// </summary>
		public static void LoadScene(int buildIndex)
		{
			if (buildIndex >= 0 && buildIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
				UnityEngine.SceneManagement.SceneManager.LoadScene(buildIndex);
			else
				Debug.LogWarning($"Invalid buildIndex: {buildIndex}");
		}

		/// <summary>
		/// Reload the current scene.
		/// </summary>
		public static void ReloadCurrentScene()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
		}
	}
}
