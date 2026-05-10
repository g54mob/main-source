using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SteamAchievement : ScriptableObject
{
	[Header("Common")]
	[SerializeField]
	private string achievementId;

	private bool isStarted;

	public string AchievementId => achievementId;

	public bool IsStarted
	{
		get
		{
			return isStarted;
		}
		private set
		{
			isStarted = value;
		}
	}

	public bool UnlockAchievement()
	{
		return false;
	}

	public bool IsUnlocked()
	{
		return false;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	public virtual void StartAchievement()
	{
		IsStarted = true;
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public virtual void EndAchievemet()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		isStarted = false;
	}

	protected virtual void OnStartGame()
	{
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (scene.buildIndex >= 3)
		{
			OnStartGame();
		}
	}
}
