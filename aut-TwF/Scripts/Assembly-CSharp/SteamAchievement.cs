using Steamworks;
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
		if (SteamManager.Initialized && isStarted)
		{
			if (!IsUnlocked())
			{
				SteamUserStats.SetAchievement(achievementId);
				SteamUserStats.StoreStats();
				return true;
			}
			EndAchievemet();
		}
		return false;
	}

	public bool IsUnlocked()
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetAchievement(achievementId, out var pbAchieved);
			return pbAchieved;
		}
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
