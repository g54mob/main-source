using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
	public static string ActiveSceneName => SceneManager.GetActiveScene().name;

	public static string PreviousSceneName { get; private set; }

	public static string StartSceneName => "Scene";

	public static void Load(string sceneName)
	{
		PreviousSceneName = ActiveSceneName;
		SceneManager.LoadScene(sceneName);
	}

	public static AsyncOperation StartAsyncLoad(string sceneName)
	{
		return SceneManager.LoadSceneAsync(sceneName);
	}

	public static void CompleteAsyncLoad(AsyncOperation asyncOp)
	{
		PreviousSceneName = ActiveSceneName;
		asyncOp.allowSceneActivation = true;
	}
}
