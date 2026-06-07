using UnityEngine.SceneManagement;

public static class DevSceneUtil
{
	public static bool IsDevScene()
	{
		return SceneManager.GetActiveScene().name.EndsWith("DevScene");
	}

	public static bool IsGameScene()
	{
		return SceneManager.GetActiveScene().name.StartsWith("game_");
	}
}
