using System;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

public class SteamIntegration : MonoBehaviour
{
	private PlayerProgress progress;

	private bool steamInitialized = true;

	public static SteamIntegration Instance { get; private set; }

	private void Start()
	{
		Instance = this;
		try
		{
			if (!SteamClient.IsValid)
			{
				SteamClient.Init(2744010u);
				steamInitialized = true;
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Steam инициализация не удалась: " + ex.Message);
			steamInitialized = false;
		}
		progress = AllServices.Container.Single<IPersistentProgressService>().Progress;
	}

	public void UnlockAchievement(string achievementID, int achievementNumber)
	{
		if (!steamInitialized)
		{
			Debug.LogWarning("Steam не инициализирован, ачивка не может быть разблокирована.");
		}
		else
		{
			if (progress.AchievementList.Contains(achievementNumber))
			{
				return;
			}
			try
			{
				Achievement achievement = new Achievement(achievementID);
				Debug.Log(achievement.State + achievement.Name);
				if (!achievement.State)
				{
					if (achievement.Trigger())
					{
						progress.AchievementList.Add(achievementNumber);
						Debug.Log("Achievement Unlocked: " + achievementID);
					}
					else
					{
						Debug.LogError("Ошибка: не удалось разблокировать ачивку " + achievementID);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Ошибка при разблокировке ачивки " + achievementID + ": " + ex.Message);
			}
		}
	}

	public void UnlockLevelAchievement(int levelNumber)
	{
		if (!steamInitialized)
		{
			Debug.LogWarning("Steam не инициализирован, ачивка не может быть разблокирована.");
		}
		else
		{
			if (progress.AchievementList.Contains(levelNumber))
			{
				return;
			}
			string text = "ACHIEVEMENT_LEVEL_" + levelNumber;
			try
			{
				Achievement achievement = new Achievement(text);
				if (!achievement.State)
				{
					if (achievement.Trigger())
					{
						progress.AchievementList.Add(levelNumber);
						Debug.Log("Achievement Unlocked: " + text);
					}
					else
					{
						Debug.LogError("Ошибка: не удалось разблокировать ачивку " + text);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Ошибка при разблокировке ачивки " + text + ": " + ex.Message);
			}
		}
	}

	private void OnApplicationQuit()
	{
		SteamClient.Shutdown();
	}
}
