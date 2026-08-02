using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class SteamAchievementManager : Singleton<SteamAchievementManager>
{
	[Serializable]
	public struct AchievementEntry
	{
		public SteamAchievement Achievement;

		public string ApiKey;
	}

	[SerializeField]
	private List<AchievementEntry> achievementEntries = new List<AchievementEntry>();

	private Dictionary<SteamAchievement, string> achievementKeys;

	private bool isSteamStatsReady;

	private CGameID gameID;

	protected Callback<UserStatsReceived_t> userStatsReceived;

	protected Callback<UserStatsStored_t> userStatsStored;

	protected Callback<UserAchievementStored_t> userAchievementStored;

	private Queue<string> achievementQueue = new Queue<string>();

	private bool isProcessingQueue;

	private void Start()
	{
		achievementKeys = new Dictionary<SteamAchievement, string>();
		foreach (AchievementEntry achievementEntry in achievementEntries)
		{
			achievementKeys[achievementEntry.Achievement] = achievementEntry.ApiKey;
		}
		if (!SteamManager.Initialized)
		{
			Debug.LogWarning("[SteamAchievementManager] SteamManager is not initialized.");
			return;
		}
		gameID = new CGameID(SteamUtils.GetAppID());
		userStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
		userStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
		userAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);
		RequestStats();
	}

	private void RequestStats()
	{
		if (SteamManager.Initialized && SteamUserStats.RequestUserStats(SteamUser.GetSteamID()) == SteamAPICall_t.Invalid)
		{
			Debug.LogWarning("[SteamAchievementManager] Failed to request Steam user stats.");
		}
	}

	public void UnlockAchievement(SteamAchievement achievement)
	{
		if (achievementKeys.TryGetValue(achievement, out var value))
		{
			UnlockAchievement(value);
		}
		else
		{
			Debug.LogWarning($"[SteamAchievementManager] No API key defined for: {achievement}");
		}
	}

	public bool IsAchievementUnlocked(SteamAchievement achievement)
	{
		if (achievementKeys.TryGetValue(achievement, out var value))
		{
			return IsAchievementUnlocked(value);
		}
		return false;
	}

	public void UnlockAchievement(string achievementName)
	{
		if (string.IsNullOrEmpty(achievementName))
		{
			Debug.LogWarning("[SteamAchievementManager] Achievement name is null or empty.");
			return;
		}
		if (!SteamManager.Initialized)
		{
			Debug.LogWarning("[SteamAchievementManager] Steam not initialized. Cannot unlock: " + achievementName);
			return;
		}
		achievementQueue.Enqueue(achievementName);
		if (!isProcessingQueue)
		{
			StartCoroutine(ProcessAchievementQueue());
		}
	}

	private IEnumerator ProcessAchievementQueue()
	{
		isProcessingQueue = true;
		while (achievementQueue.Count > 0)
		{
			string text = achievementQueue.Dequeue();
			try
			{
				if (IsAchievementUnlocked(text))
				{
					Debug.Log("[SteamAchievementManager] '" + text + "' already unlocked, skipping.");
					continue;
				}
				if (SteamUserStats.SetAchievement(text))
				{
					if (SteamUserStats.StoreStats())
					{
						Debug.Log("[SteamAchievementManager] '" + text + "' unlocked successfully!");
					}
					else
					{
						Debug.LogWarning("[SteamAchievementManager] '" + text + "' set but StoreStats failed.");
					}
				}
				else
				{
					Debug.LogWarning("[SteamAchievementManager] Failed to set achievement: " + text);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("[SteamAchievementManager] Error unlocking '" + text + "': " + ex.Message);
			}
			yield return new WaitForSeconds(0.1f);
		}
		isProcessingQueue = false;
	}

	public bool IsAchievementUnlocked(string achievementName)
	{
		if (string.IsNullOrEmpty(achievementName) || !SteamManager.Initialized)
		{
			return false;
		}
		try
		{
			if (!SteamUserStats.GetAchievement(achievementName, out var pbAchieved))
			{
				Debug.LogWarning("[SteamAchievementManager] Failed to get status for: " + achievementName);
				return false;
			}
			return pbAchieved;
		}
		catch (Exception ex)
		{
			Debug.LogError("[SteamAchievementManager] Error checking '" + achievementName + "': " + ex.Message);
			return false;
		}
	}

	public void ResetAllAchievements()
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.ResetAllStats(bAchievementsToo: true);
			SteamUserStats.StoreStats();
			Debug.Log("[SteamAchievementManager] All achievements reset.");
		}
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if ((ulong)gameID == pCallback.m_nGameID)
		{
			if (pCallback.m_eResult == EResult.k_EResultOK)
			{
				Debug.Log("[SteamAchievementManager] Stats and achievements received from Steam.");
				isSteamStatsReady = true;
			}
			else
			{
				Debug.LogWarning($"[SteamAchievementManager] RequestStats failed: {pCallback.m_eResult}");
			}
		}
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)gameID == pCallback.m_nGameID)
		{
			if (pCallback.m_eResult == EResult.k_EResultOK)
			{
				Debug.Log("[SteamAchievementManager] StoreStats success.");
			}
			else if (pCallback.m_eResult == EResult.k_EResultInvalidParam)
			{
				Debug.LogWarning("[SteamAchievementManager] StoreStats - some stats failed validation. Re-requesting...");
				OnUserStatsReceived(new UserStatsReceived_t
				{
					m_eResult = EResult.k_EResultOK,
					m_nGameID = (ulong)gameID
				});
			}
			else
			{
				Debug.LogWarning($"[SteamAchievementManager] StoreStats failed: {pCallback.m_eResult}");
			}
		}
	}

	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)gameID == pCallback.m_nGameID)
		{
			if (pCallback.m_nMaxProgress == 0)
			{
				Debug.Log("[SteamAchievementManager] Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
			}
			else
			{
				Debug.Log($"[SteamAchievementManager] Achievement '{pCallback.m_rgchAchievementName}' progress: {pCallback.m_nCurProgress}/{pCallback.m_nMaxProgress}");
			}
		}
	}
}
