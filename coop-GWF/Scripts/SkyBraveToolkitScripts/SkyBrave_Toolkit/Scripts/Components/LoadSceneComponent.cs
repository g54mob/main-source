using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class LoadSceneComponent : MonoBehaviour
	{
		public void ReLoadCurrentUnityScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		public void LoadNextUnityScene()
		{
			SceneManager.LoadScene(Mathf.Clamp(SceneManager.GetActiveScene().buildIndex + 1, 0, SceneManager.sceneCountInBuildSettings - 1));
		}

		public void LoadPreviousUnityScene()
		{
			SceneManager.LoadScene(Mathf.Clamp(SceneManager.GetActiveScene().buildIndex - 1, 0, SceneManager.sceneCountInBuildSettings - 1));
		}

		public void LoadUnitySceneWithName(string unitySceneName)
		{
			SceneManager.LoadScene(unitySceneName);
		}

		public Scene GetCurrentUnityScene()
		{
			return SceneManager.GetActiveScene();
		}
	}
}
