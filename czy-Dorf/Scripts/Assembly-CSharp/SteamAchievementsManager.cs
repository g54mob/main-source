using Steamworks;
using UnityEngine;

public class SteamAchievementsManager : MonoBehaviour
{
	[SerializeField]
	private RewardLibrary rewardLibrary;

	[SerializeField]
	private bool unlockLocallyUnlockedAchievementsOnStart;

	private void Start()
	{
		rewardLibrary.OnRewardUnlocked += UnlockSteamAchievement;
		if (!unlockLocallyUnlockedAchievementsOnStart)
		{
			return;
		}
		foreach (SessionQuestReward allReward in rewardLibrary.allRewards)
		{
			if (allReward.state == RewardState.Completed)
			{
				UnlockSteamAchievement(allReward.id);
			}
		}
	}

	private void UnlockSteamAchievement(string id)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Steam Manager not initialized");
			return;
		}
		SteamUserStats.GetAchievement(id, out var pbAchieved);
		if (!pbAchieved)
		{
			SteamUserStats.SetAchievement(id);
			SteamUserStats.StoreStats();
		}
	}

	private void SetSteamStat(string statId, int value)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Steam Manager not initialized");
			return;
		}
		SteamUserStats.SetStat(statId, value);
		SteamUserStats.StoreStats();
	}

	private void TestUnlockAchievement(string id)
	{
		UnlockSteamAchievement(id);
	}

	private void TestLockAchievement(string id)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Steam Manager not initialized");
			return;
		}
		SteamUserStats.GetAchievement(id, out var pbAchieved);
		if (pbAchieved)
		{
			SteamUserStats.ClearAchievement(id);
			SteamUserStats.StoreStats();
		}
		Debug.Log("LOCK ACHIEVEMENT " + id + " achieved? " + pbAchieved);
	}

	private void TestLockAllAchievements()
	{
		foreach (SessionQuestReward allReward in rewardLibrary.allRewards)
		{
			SteamUserStats.GetAchievement(allReward.id, out var pbAchieved);
			if (pbAchieved)
			{
				SteamUserStats.ClearAchievement(allReward.id);
				SteamUserStats.StoreStats();
			}
			Debug.Log("LOCK ACHIEVEMENT " + allReward.id + " achieved? " + pbAchieved);
		}
	}

	private void OnDestroy()
	{
		rewardLibrary.OnRewardUnlocked -= UnlockSteamAchievement;
	}
}
