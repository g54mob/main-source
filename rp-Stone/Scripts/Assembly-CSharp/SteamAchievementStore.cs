using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class SteamAchievementStore : AAchievementStore
{
	private Dictionary<AchievementController.Type, string> idMap = new Dictionary<AchievementController.Type, string>();

	private bool failedToUnlock;

	protected Callback<UserStatsReceived_t> requestCurrentStatsEvent;

	public override void Init()
	{
		InitSteamAchievements();
		idMap.Add(AchievementController.Type.UseSightStone, "NEW_ACHIEVEMENT_42_0");
		idMap.Add(AchievementController.Type.UseStarStone, "NEW_ACHIEVEMENT_42_1");
		idMap.Add(AchievementController.Type.UseKiStone, "NEW_ACHIEVEMENT_42_2");
		idMap.Add(AchievementController.Type.UseXPStone, "NEW_ACHIEVEMENT_42_3");
		idMap.Add(AchievementController.Type.UseOuroboros, "NEW_ACHIEVEMENT_42_4");
		idMap.Add(AchievementController.Type.UseQuestStone, "NEW_ACHIEVEMENT_42_5");
		idMap.Add(AchievementController.Type.UseFissureStone, "NEW_ACHIEVEMENT_42_6");
		idMap.Add(AchievementController.Type.UseTriskelion, "NEW_ACHIEVEMENT_42_7");
		idMap.Add(AchievementController.Type.UseMindStone, "NEW_ACHIEVEMENT_42_8");
		idMap.Add(AchievementController.Type.UseMoondial, "NEW_ACHIEVEMENT_42_9");
		idMap.Add(AchievementController.Type.PassRantingTree, "NEW_ACHIEVEMENT_42_10");
		idMap.Add(AchievementController.Type.DysangelosHelp, "NEW_ACHIEVEMENT_42_11");
		idMap.Add(AchievementController.Type.UpgradeItemStar, "NEW_ACHIEVEMENT_42_12");
		idMap.Add(AchievementController.Type.CraftNewItem, "NEW_ACHIEVEMENT_42_13");
		idMap.Add(AchievementController.Type.Craft100Items, "NEW_ACHIEVEMENT_42_14");
		idMap.Add(AchievementController.Type.UpgradeItemToMax, "NEW_ACHIEVEMENT_42_15");
		idMap.Add(AchievementController.Type.DefeatXyloalgia5, "NEW_ACHIEVEMENT_42_16");
		idMap.Add(AchievementController.Type.DefeatBolesh5, "NEW_ACHIEVEMENT_42_17");
		idMap.Add(AchievementController.Type.DefeatAngryShroom5, "NEW_ACHIEVEMENT_42_18");
		idMap.Add(AchievementController.Type.DefeatPallas5, "NEW_ACHIEVEMENT_42_19");
		idMap.Add(AchievementController.Type.DefeatGuardian5, "NEW_ACHIEVEMENT_42_20");
		idMap.Add(AchievementController.Type.DefeatHrimnir5, "NEW_ACHIEVEMENT_42_21");
		idMap.Add(AchievementController.Type.DefeatNagaraja5, "NEW_ACHIEVEMENT_42_22");
		idMap.Add(AchievementController.Type.DefeatDysangelos5, "NEW_ACHIEVEMENT_42_23");
		idMap.Add(AchievementController.Type.Defeat10000foes, "NEW_ACHIEVEMENT_42_24");
		idMap.Add(AchievementController.Type.Collect1MillionRes, "NEW_ACHIEVEMENT_42_25");
		idMap.Add(AchievementController.Type.GetBooklet, "NEW_ACHIEVEMENT_42_26");
		idMap.Add(AchievementController.Type.CompleteBooklet, "NEW_ACHIEVEMENT_42_27");
		idMap.Add(AchievementController.Type.Cyan5, "NEW_ACHIEVEMENT_42_28");
		idMap.Add(AchievementController.Type.UpgradeEnchantment, "NEW_ACHIEVEMENT_42_29");
		idMap.Add(AchievementController.Type.CraftTranscendent, "NEW_ACHIEVEMENT_42_30");
		idMap.Add(AchievementController.Type.AllPotions, "NEW_ACHIEVEMENT_42_31");
		idMap.Add(AchievementController.Type.SkullGame, "NEW_ACHIEVEMENT_43_0");
		idMap.Add(AchievementController.Type.TypeStonescript, "NEW_ACHIEVEMENT_43_1");
		idMap.Add(AchievementController.Type.ShareStonescript, "NEW_ACHIEVEMENT_43_2");
		idMap.Add(AchievementController.Type.AFKFarming, "NEW_ACHIEVEMENT_43_3");
		idMap.Add(AchievementController.Type.MidnightFarmer, "NEW_ACHIEVEMENT_43_4");
		idMap.Add(AchievementController.Type.ClearOneShopItem, "NEW_ACHIEVEMENT_43_12");
		idMap.Add(AchievementController.Type.ClearShop, "NEW_ACHIEVEMENT_43_5");
		idMap.Add(AchievementController.Type.OneShootBoss, "NEW_ACHIEVEMENT_43_6");
		idMap.Add(AchievementController.Type.UnmakePallasArm, "NEW_ACHIEVEMENT_43_7");
		idMap.Add(AchievementController.Type.MutateItem, "NEW_ACHIEVEMENT_43_8");
		idMap.Add(AchievementController.Type.MaxPlayerLevel, "NEW_ACHIEVEMENT_43_9");
		idMap.Add(AchievementController.Type.Yellow5, "NEW_ACHIEVEMENT_43_10");
		idMap.Add(AchievementController.Type.Import, "NEW_ACHIEVEMENT_43_11");
		idMap.Add(AchievementController.Type.AllEpicQuests, "NEW_ACHIEVEMENT_43_13");
		idMap.Add(AchievementController.Type.SelfUnmakeMirror, "NEW_ACHIEVEMENT_43_14");
	}

	public override bool UnlockAchievement(AchievementController.Type type)
	{
		bool flag = false;
		if (!SteamManager.Initialized)
		{
			if (!failedToUnlock)
			{
				Utils.LogError("Failed to unlock achievement " + type.ToString() + " because steam is not initialized. Further achievement errors will not be logged.");
				failedToUnlock = true;
				GameplayActionMessages.SetMessage(" Failing to unlock achievements. Try restarting Steam.", Color.red, 9f);
			}
		}
		else if (!idMap.ContainsKey(type))
		{
			Utils.LogError("Failed to unlock achievement " + type.ToString() + " because there is no Steam mapping for it.");
		}
		else
		{
			string text = idMap[type];
			Utils.Log("Attempting to unlock Steam achievement " + text);
			flag = SteamUserStats.SetAchievement(text);
			if (flag)
			{
				SteamUserStats.StoreStats();
			}
		}
		return flag;
	}

	public override void ClearAll()
	{
		if (SteamManager.Initialized)
		{
			Utils.Log("Clearing all achievements");
			{
				foreach (KeyValuePair<AchievementController.Type, string> item in idMap)
				{
					SteamUserStats.ClearAchievement(item.Value);
				}
				return;
			}
		}
		Utils.LogError("Could not clear achievements. Steamworks is not initialized.");
	}

	private void Update()
	{
	}

	private void InitSteamAchievements()
	{
		if (SteamManager.Initialized)
		{
			requestCurrentStatsEvent = Callback<UserStatsReceived_t>.Create(HandleCurrentStats);
			if (!SteamUserStats.RequestCurrentStats())
			{
				Utils.LogError("Failed to initialize Steam achievements.");
			}
		}
		else
		{
			Utils.LogError("Steam not initialized for achievements.");
		}
	}

	private void HandleCurrentStats(UserStatsReceived_t param)
	{
		CSteamID steamIDUser = param.m_steamIDUser;
		Utils.Log("Steam Stats reveived for user " + steamIDUser.ToString() + ". Result = " + param.m_eResult);
	}
}
