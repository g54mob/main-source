using Steamworks;
using UnityEngine;

public class SteamAchievementsManager : MonoBehaviour
{
	public enum Achievement
	{
		TUTORIAL_COMPLETED = 0,
		FIRST_LEVEL = 1,
		MOUNTAIN_COMPLETED = 2,
		MOUNTAIN_SILVER = 3,
		MOUNTAIN_GOLD = 4,
		MOUNTAIN_TOTAL = 5,
		GROUP_EASY_COMPLETED = 6,
		GROUP_EASY_SILVER = 7,
		GROUP_EASY_GOLD = 8,
		GROUP_EASY_TOTAL = 9,
		GROUP_MEDIUM_COMPLETED = 10,
		GROUP_MEDIUM_SILVER = 11,
		GROUP_MEDIUM_GOLD = 12,
		GROUP_MEDIUM_TOTAL = 13,
		GROUP_HARD_COMPLETED = 14,
		GROUP_HARD_SILVER = 15,
		GROUP_HARD_GOLD = 16,
		GROUP_HARD_TOTAL = 17,
		GROUP_EXTREME_COMPLETED = 18,
		GROUP_EXTREME_SILVER = 19,
		GROUP_EXTREME_GOLD = 20,
		GROUP_EXTREME_TOTAL = 21,
		MAIN_CAMPAIGN_COMPLETED = 22,
		MAIN_CAMPAIGN_SILVER = 23,
		MAIN_CAMPAIGN_GOLD = 24,
		MAIN_CAMPAIGN_TOTAL = 25,
		LEVEL_SENT_WORKSHOP = 26,
		LEVEL_DOWNLOADED_WORKSHOP = 27,
		CONTRAPTION_SENT_WORKSHOP = 28,
		CONTRAPTION_DOWNLOADED_WORKSHOP = 29
	}

	private Callback<UserStatsReceived_t> userStatsReceivedCallback;

	private Callback<UserStatsStored_t> userStatsStoredCallback;

	private Callback<UserAchievementStored_t> userAchievementStoredCallback;

	private CGameID cGameID;

	private bool wasRequestedStats;

	public static SteamAchievementsManager Instance => Singleton<SteamAchievementsManager>.Instance;

	public static bool Exist => Singleton<SteamAchievementsManager>.Exist;

	private void Awake()
	{
		wasRequestedStats = false;
		if (SteamManager.Initialized)
		{
			cGameID = new CGameID(SteamUtils.GetAppID());
			userStatsReceivedCallback = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
			userStatsStoredCallback = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
			userAchievementStoredCallback = Callback<UserAchievementStored_t>.Create(OnUserAchievementsStored);
			SteamUserStats.RequestCurrentStats();
		}
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if ((ulong)cGameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				wasRequestedStats = true;
				Debug.Log("STEAM ACHIEVEMENTS: Received stats and achievements from Steam!");
			}
			else
			{
				Debug.Log($"STEAM ACHIEVEMENTS: Received stats failed, {pCallback.m_eResult}");
			}
		}
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)cGameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("STEAM ACHIEVEMENTS: Stats stored success!");
			}
			else
			{
				Debug.Log($"STEAM ACHIEVEMENTS: Stats stored failed, {pCallback.m_eResult}");
			}
		}
	}

	private void OnUserAchievementsStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)cGameID == pCallback.m_nGameID && pCallback.m_nMaxProgress == 0)
		{
			Debug.Log("STEAM ACHIEVEMENTS: Achievement " + pCallback.m_rgchAchievementName + " unlocked!");
		}
	}

	public void UnlockAchievement(Achievement achievement)
	{
		if (!wasRequestedStats)
		{
			Debug.Log($"STEAM ACHIEVEMENTS: Request {achievement} to unlock! But, Steam is offline or not initialized!");
			return;
		}
		Debug.Log($"STEAM ACHIEVEMENTS: Request {achievement} to unlock!");
		SteamUserStats.SetAchievement(achievement.ToString());
		SteamUserStats.StoreStats();
	}
}
