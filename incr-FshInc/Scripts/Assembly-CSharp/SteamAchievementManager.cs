using System;
using Steamworks;
using UnityEngine;

public class SteamAchievementManager : MonoBehaviour
{
	public static SteamAchievementManager Instance;

	private const string ACH_FIRST_FISH = "CATCH_FIRST_FISH";

	private const string ACH_TEN_FISH = "CATCH_10_FISH";

	private const string ACH_DID_YOU_SEE_THAT = "DID_YOU_SEE_THAT";

	private const string ACH_YOU_JUST_BLANKED = "YOU_JUST_BLANKED";

	private const string ACH_CATCH_25_FISH = "CATCH_25_FISH";

	private const string ACH_CATCH_1000_FISH = "NEW_ACHIEVEMENT_1_3";

	private const string ACH_CATCH_COMMON = "CATCH_COMMON";

	private const string ACH_CATCH_UNCOMMON = "CATCH_UNCOMMON";

	private const string ACH_CATCH_RARE = "CATCH_RARE";

	private const string ACH_CATCH_EPIC = "CATCH_EPIC";

	private const string ACH_CATCH_LEGENDARY = "CATCH_LEGENDARY";

	private const string ACH_NOT_A_FISH = "NOT_A_FISH";

	private const string ACH_KRAKEN_SLAYER = "KRAKEN_SLAYER";

	private const string ACH_DOUBLE_CATCH = "FIRST_DOUBLE_CATCH";

	private const string ACH_TRIPLE_CATCH = "FIRST_TRIPLE_CATCH";

	private const string ACH_CLOSE_CALL = "CLOSE_CALL";

	private const string PP_TOTAL_FISH_CAUGHT = "TotalFishCaught";

	private const string PP_ACH_FIRST_FISH_UNLOCKED = "AchFirstFishUnlocked";

	private const string PP_ACH_TEN_FISH_UNLOCKED = "AchTenFishUnlocked";

	private const string PP_ACH_DID_YOU_SEE_THAT_UNLOCKED = "AchDidYouSeeThatUnlocked";

	private const string PP_ACH_YOU_JUST_BLANKED_UNLOCKED = "AchYouJustBlankedUnlocked";

	private const string PP_ACH_CATCH_25_FISH_UNLOCKED = "AchCatch25FishUnlocked";

	private const string PP_ACH_CATCH_1000_FISH_UNLOCKED = "AchCatch1000FishUnlocked";

	private const string PP_ACH_CATCH_COMMON_UNLOCKED = "AchCatchCommonUnlocked";

	private const string PP_ACH_CATCH_UNCOMMON_UNLOCKED = "AchCatchUncommonUnlocked";

	private const string PP_ACH_CATCH_RARE_UNLOCKED = "AchCatchRareUnlocked";

	private const string PP_ACH_CATCH_EPIC_UNLOCKED = "AchCatchEpicUnlocked";

	private const string PP_ACH_CATCH_LEGENDARY_UNLOCKED = "AchCatchLegendaryUnlocked";

	private const string PP_ACH_NOT_A_FISH_UNLOCKED = "AchNotAFishUnlocked";

	private const string PP_ACH_KRAKEN_SLAYER_UNLOCKED = "AchKrakenSlayerUnlocked";

	private const string PP_ACH_DOUBLE_CATCH_UNLOCKED = "AchDoubleCatchUnlocked";

	private const string PP_ACH_TRIPLE_CATCH_UNLOCKED = "AchTripleCatchUnlocked";

	private const string PP_ACH_CLOSE_CALL_UNLOCKED = "AchCloseCallUnlocked";

	private int totalFishCaught;

	private bool steamInitialized;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			InitializeSteam();
			LoadProgress();
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void InitializeSteam()
	{
		try
		{
			if (SteamAPI.Init())
			{
				steamInitialized = true;
				Debug.Log("SteamAPI Initialized Successfully!");
			}
			else
			{
				Debug.LogError("SteamAPI failed to initialize.");
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Error initializing SteamAPI: " + ex.Message);
		}
	}

	private void LoadProgress()
	{
		totalFishCaught = PlayerPrefs.GetInt("TotalFishCaught", 0);
	}

	private void SaveProgress()
	{
		PlayerPrefs.SetInt("TotalFishCaught", totalFishCaught);
		PlayerPrefs.Save();
	}

	public void ResetProgress()
	{
		totalFishCaught = 0;
		SaveProgress();
		PlayerPrefs.DeleteKey("AchFirstFishUnlocked");
		PlayerPrefs.DeleteKey("AchTenFishUnlocked");
		PlayerPrefs.DeleteKey("AchDidYouSeeThatUnlocked");
		PlayerPrefs.DeleteKey("AchYouJustBlankedUnlocked");
		PlayerPrefs.DeleteKey("AchCatch25FishUnlocked");
		PlayerPrefs.DeleteKey("AchCatch1000FishUnlocked");
		PlayerPrefs.DeleteKey("AchCatchCommonUnlocked");
		PlayerPrefs.DeleteKey("AchCatchUncommonUnlocked");
		PlayerPrefs.DeleteKey("AchCatchRareUnlocked");
		PlayerPrefs.DeleteKey("AchCatchEpicUnlocked");
		PlayerPrefs.DeleteKey("AchCatchLegendaryUnlocked");
		PlayerPrefs.DeleteKey("AchNotAFishUnlocked");
		PlayerPrefs.DeleteKey("AchKrakenSlayerUnlocked");
		PlayerPrefs.DeleteKey("AchDoubleCatchUnlocked");
		PlayerPrefs.DeleteKey("AchTripleCatchUnlocked");
		PlayerPrefs.DeleteKey("AchCloseCallUnlocked");
		PlayerPrefs.Save();
		Debug.Log("[SteamAchievementManager] All local progress reset.");
	}

	public void ResetSteamSideProgress()
	{
		if (!steamInitialized)
		{
			Debug.LogWarning("[SteamAchievementManager] Steam not initialized, cannot reset Steam-side progress.");
			return;
		}
		SteamUserStats.ResetAllStats(bAchievementsToo: true);
		SteamUserStats.ClearAchievement("CATCH_FIRST_FISH");
		SteamUserStats.ClearAchievement("CATCH_10_FISH");
		SteamUserStats.ClearAchievement("DID_YOU_SEE_THAT");
		SteamUserStats.ClearAchievement("YOU_JUST_BLANKED");
		SteamUserStats.ClearAchievement("CATCH_25_FISH");
		SteamUserStats.ClearAchievement("NEW_ACHIEVEMENT_1_3");
		SteamUserStats.ClearAchievement("NOT_A_FISH");
		SteamUserStats.ClearAchievement("KRAKEN_SLAYER");
		SteamUserStats.ClearAchievement("FIRST_DOUBLE_CATCH");
		SteamUserStats.ClearAchievement("FIRST_TRIPLE_CATCH");
		SteamUserStats.ClearAchievement("CATCH_COMMON");
		SteamUserStats.ClearAchievement("CATCH_UNCOMMON");
		SteamUserStats.ClearAchievement("CATCH_RARE");
		SteamUserStats.ClearAchievement("CATCH_EPIC");
		SteamUserStats.ClearAchievement("CATCH_LEGENDARY");
		SteamUserStats.StoreStats();
		Debug.Log("[SteamAchievementManager] Steam-side stats and achievements reset.");
	}

	public void NotifyFishCaught(CaughtFish fish)
	{
		int num = (fish.isTripleCatch ? 3 : ((!fish.isDoubleCatch) ? 1 : 2));
		totalFishCaught += num;
		SaveProgress();
		if (steamInitialized)
		{
			SteamUserStats.SetStat("fish_caught", totalFishCaught);
			SteamUserStats.StoreStats();
			if (PlayerPrefs.GetInt("AchFirstFishUnlocked", 0) == 0 && UnlockAchievement("CATCH_FIRST_FISH"))
			{
				PlayerPrefs.SetInt("AchFirstFishUnlocked", 1);
				PlayerPrefs.Save();
			}
			if (totalFishCaught >= 10 && PlayerPrefs.GetInt("AchTenFishUnlocked", 0) == 0 && UnlockAchievement("CATCH_10_FISH"))
			{
				PlayerPrefs.SetInt("AchTenFishUnlocked", 1);
				PlayerPrefs.Save();
			}
			if (totalFishCaught >= 25 && PlayerPrefs.GetInt("AchCatch25FishUnlocked", 0) == 0 && UnlockAchievement("CATCH_25_FISH"))
			{
				PlayerPrefs.SetInt("AchCatch25FishUnlocked", 1);
				PlayerPrefs.Save();
			}
			if (totalFishCaught >= 1000 && PlayerPrefs.GetInt("AchCatch1000FishUnlocked", 0) == 0 && UnlockAchievement("NEW_ACHIEVEMENT_1_3"))
			{
				PlayerPrefs.SetInt("AchCatch1000FishUnlocked", 1);
				PlayerPrefs.Save();
			}
			CheckCollectionAchievements();
		}
	}

	private void CheckCollectionAchievements()
	{
		if (FishLogManager.Instance == null)
		{
			return;
		}
		bool conditionMet = true;
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		foreach (Fish item in FishLogManager.Instance.allFish)
		{
			if (FishLogManager.Instance.GetTotalCatchCountForSpecies(item.speciesName) <= 0)
			{
				conditionMet = false;
				flag = false;
				flag2 = false;
				flag3 = false;
				flag4 = false;
				break;
			}
			if (flag && !HasCaughtRarityOrBetter(item, FishRarity.Uncommon))
			{
				flag = false;
			}
			if (flag2 && !HasCaughtRarityOrBetter(item, FishRarity.Rare))
			{
				flag2 = false;
			}
			if (flag3 && !HasCaughtRarityOrBetter(item, FishRarity.Epic))
			{
				flag3 = false;
			}
			if (flag4 && FishLogManager.Instance.GetCatchCount(item.speciesName, FishRarity.Legendary.ToString()) <= 0)
			{
				flag4 = false;
			}
		}
		TryUnlock("CATCH_COMMON", "AchCatchCommonUnlocked", conditionMet);
		TryUnlock("CATCH_UNCOMMON", "AchCatchUncommonUnlocked", flag);
		TryUnlock("CATCH_RARE", "AchCatchRareUnlocked", flag2);
		TryUnlock("CATCH_EPIC", "AchCatchEpicUnlocked", flag3);
		TryUnlock("CATCH_LEGENDARY", "AchCatchLegendaryUnlocked", flag4);
	}

	private bool HasCaughtRarityOrBetter(Fish species, FishRarity minRarity)
	{
		foreach (RarityData availableRarity in species.availableRarities)
		{
			if (availableRarity.rarity >= minRarity && FishLogManager.Instance.GetCatchCount(species.speciesName, availableRarity.rarity.ToString()) > 0)
			{
				return true;
			}
		}
		return false;
	}

	private void TryUnlock(string achID, string ppKey, bool conditionMet)
	{
		if (conditionMet && PlayerPrefs.GetInt(ppKey, 0) == 0 && UnlockAchievement(achID))
		{
			PlayerPrefs.SetInt(ppKey, 1);
			PlayerPrefs.Save();
		}
	}

	public void NotifyTripEnded(int catchCount)
	{
		if (steamInitialized && catchCount == 0 && PlayerPrefs.GetInt("AchYouJustBlankedUnlocked", 0) == 0 && UnlockAchievement("YOU_JUST_BLANKED"))
		{
			PlayerPrefs.SetInt("AchYouJustBlankedUnlocked", 1);
			PlayerPrefs.Save();
		}
	}

	public void NotifyBirdSpotted()
	{
		if (steamInitialized && PlayerPrefs.GetInt("AchDidYouSeeThatUnlocked", 0) == 0 && UnlockAchievement("DID_YOU_SEE_THAT"))
		{
			PlayerPrefs.SetInt("AchDidYouSeeThatUnlocked", 1);
			PlayerPrefs.Save();
		}
	}

	public void NotifyKrakenDefeated()
	{
		if (steamInitialized && PlayerPrefs.GetInt("AchKrakenSlayerUnlocked", 0) == 0 && UnlockAchievement("KRAKEN_SLAYER"))
		{
			PlayerPrefs.SetInt("AchKrakenSlayerUnlocked", 1);
			PlayerPrefs.Save();
		}
	}

	public void NotifyDoubleCatch()
	{
		if (steamInitialized && PlayerPrefs.GetInt("AchDoubleCatchUnlocked", 0) == 0 && UnlockAchievement("FIRST_DOUBLE_CATCH"))
		{
			PlayerPrefs.SetInt("AchDoubleCatchUnlocked", 1);
			PlayerPrefs.Save();
		}
	}

	public void NotifyTripleCatch()
	{
		if (steamInitialized && PlayerPrefs.GetInt("AchTripleCatchUnlocked", 0) == 0 && UnlockAchievement("FIRST_TRIPLE_CATCH"))
		{
			PlayerPrefs.SetInt("AchTripleCatchUnlocked", 1);
			PlayerPrefs.Save();
		}
	}

	public void NotifyCloseCall()
	{
		if (steamInitialized && PlayerPrefs.GetInt("AchCloseCallUnlocked", 0) == 0 && UnlockAchievement("CLOSE_CALL"))
		{
			PlayerPrefs.SetInt("AchCloseCallUnlocked", 1);
			PlayerPrefs.Save();
		}
	}

	public void NotifyCritterPoked()
	{
		if (steamInitialized && PlayerPrefs.GetInt("AchNotAFishUnlocked", 0) == 0 && UnlockAchievement("NOT_A_FISH"))
		{
			PlayerPrefs.SetInt("AchNotAFishUnlocked", 1);
			PlayerPrefs.Save();
		}
	}

	private bool UnlockAchievement(string achievementApiName)
	{
		if (!steamInitialized)
		{
			Debug.LogWarning("Steam not initialized, cannot unlock achievement yet.");
			return false;
		}
		try
		{
			SteamUserStats.GetAchievement(achievementApiName, out var pbAchieved);
			if (!pbAchieved)
			{
				if (SteamUserStats.SetAchievement(achievementApiName))
				{
					SteamUserStats.StoreStats();
					Debug.Log("Steam Achievement Unlocked: " + achievementApiName);
					return true;
				}
				Debug.LogError("SteamUserStats.SetAchievement failed for " + achievementApiName);
				return false;
			}
			Debug.Log("Steam Achievement '" + achievementApiName + "' was already unlocked.");
			if (PlayerPrefs.GetInt("Ach" + achievementApiName + "Unlocked", 0) == 0)
			{
				PlayerPrefs.SetInt("Ach" + achievementApiName + "Unlocked", 1);
				PlayerPrefs.Save();
			}
			return true;
		}
		catch (Exception ex)
		{
			Debug.LogError("Error unlocking Steam achievement " + achievementApiName + ": " + ex.Message);
			return false;
		}
	}

	private void OnDestroy()
	{
		if (steamInitialized && Instance == this)
		{
			SteamAPI.Shutdown();
			Debug.Log("SteamAPI Shutdown.");
		}
	}

	private void Update()
	{
		if (steamInitialized)
		{
			SteamAPI.RunCallbacks();
		}
	}
}
