using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsMacros
{
	private static bool TRACK_STARTUP = true;

	private static string questLoadoutAtStart;

	private static Dictionary<string, int> submissionsDict = new Dictionary<string, int>();

	private static void MarkSubmitted(string submissionKey)
	{
		if (submissionsDict.ContainsKey(submissionKey))
		{
			submissionsDict[submissionKey] = DateTime.Now.Day;
		}
		else
		{
			submissionsDict.Add(submissionKey, DateTime.Now.Day);
		}
	}

	private static bool HasSubmitted(string submissionKey)
	{
		if (submissionsDict.ContainsKey(submissionKey))
		{
			return submissionsDict[submissionKey] == DateTime.Now.Day;
		}
		return false;
	}

	public static void LanguageScreenSeen()
	{
		if (SaveFiles.singleton.GetDirectory().Count == 0)
		{
			AnalyticsWrapper.AddEventParam("game_version", Features.VERSION.ToNumber());
			AnalyticsWrapper.AddEventParam("save_file_count", 0);
			AnalyticsWrapper.CustomEvent("language_seen");
		}
	}

	public static void LanguageSelected()
	{
		AnalyticsWrapper.AddEventParam("language", Te.id);
		AnalyticsWrapper.AddEventParam("game_version", Features.VERSION.ToNumber());
		AnalyticsWrapper.AddEventParam("save_file_count", SaveFiles.singleton.GetDirectory().Count);
		AnalyticsWrapper.CustomEvent("v3_language");
	}

	public static void LogoInit()
	{
		AnalyticsWrapper.CustomEvent("logo_init");
	}

	public static void TrackStartup()
	{
		if (TRACK_STARTUP)
		{
			try
			{
				AnalyticsWrapper.AddEventParam("operating_system", SystemInfo.operatingSystem);
				AnalyticsWrapper.AddEventParam("os_family", SystemInfo.operatingSystemFamily.ToString());
				AnalyticsWrapper.AddEventParam("resolution", Screen.width + "x" + Screen.height);
				AnalyticsWrapper.AddEventParam("device_model", SystemInfo.deviceModel);
				AnalyticsWrapper.AddEventParam("device_type", SystemInfo.deviceType.ToString());
				AnalyticsWrapper.AddEventParam("app_was_altered", Application.genuine ? "False" : "True");
				AnalyticsWrapper.AddEventParam("system_language", Application.systemLanguage.ToString());
				AnalyticsWrapper.AddEventParam("game_version", Features.VERSION.ToNumber());
				AnalyticsWrapper.AddEventParam("save_file_count", SaveFiles.singleton.GetDirectory().Count);
				AnalyticsWrapper.CustomEvent("v3_startup");
			}
			catch (Exception ex)
			{
				Utils.LogError("Failed to send analytics for startup. " + ex.Message);
			}
		}
	}

	public static void MainMenuInit()
	{
		AnalyticsWrapper.CustomEvent("main_menu_init");
	}

	public static void MainMenuPlayPressed()
	{
		AnalyticsWrapper.CustomEvent("v3_main_play");
	}

	public static void FtueDot()
	{
		AnalyticsWrapper.AddEventParam("game_version", Features.VERSION.ToNumber());
		AnalyticsWrapper.AddEventParam("language", Te.id);
		AnalyticsWrapper.AddEventParam("system_language", Application.systemLanguage.ToString());
		AnalyticsWrapper.AddEventParam("save_file_count", SaveFiles.singleton.GetDirectory().Count);
		AnalyticsWrapper.CustomEvent("v3_ftue_dot");
	}

	public static void FirstInteraction()
	{
		AnalyticsWrapper.CustomEvent("first_interaction");
	}

	public static void IntroCollecting()
	{
		AnalyticsWrapper.CustomEvent("intro_collecting");
	}

	public static void IntroSightStone()
	{
		AnalyticsWrapper.CustomEvent("intro_sightstone");
	}

	public static void IntroStarStone()
	{
		AnalyticsWrapper.CustomEvent("intro_starstone");
	}

	public static void IntroKiStone()
	{
		AnalyticsWrapper.CustomEvent("intro_kistone");
	}

	public static void IntroXPStone()
	{
		AnalyticsWrapper.CustomEvent("intro_xpstone");
	}

	public static void IntroOuroboros()
	{
		AnalyticsWrapper.CustomEvent("intro_ouroboros");
	}

	public static void IntroQuestStone()
	{
		AnalyticsWrapper.CustomEvent("intro_queststone");
	}

	public static void IntroFissureStone()
	{
		AnalyticsWrapper.CustomEvent("intro_fissurestone");
	}

	public static void IntroTriskelion()
	{
		AnalyticsWrapper.CustomEvent("intro_triskelion");
	}

	public static void IntroMindStone()
	{
		AnalyticsWrapper.CustomEvent("intro_mindstone");
	}

	public static void IntroMoondial()
	{
		AnalyticsWrapper.CustomEvent("intro_moondial");
	}

	public static void CrossDeadwoodRiver()
	{
		string text = "cross_river";
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void ExamineBronzeGate()
	{
		string text = "bronze_gate";
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void BronzeGateOpened()
	{
		AnalyticsWrapper.CustomEvent("bronze_gate_opened");
	}

	public static void PlaySkullGame()
	{
		string text = "skull_game";
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void SkullGameTreasure()
	{
		string text = "skull_game_treasure";
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void DailyQuestsUnlocked()
	{
		AnalyticsWrapper.CustomEvent("daily_quests_unlocked");
	}

	public static void BrewPotion()
	{
		string text = "brew_potion";
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void DailyQuestComplete()
	{
		AnalyticsWrapper.CustomEvent("daily_quest_complete");
	}

	public static void DailyQuestRewardCollected()
	{
		AnalyticsWrapper.CustomEvent("daily_quest_reward");
	}

	public static void EpicQuestUnlocked()
	{
		AnalyticsWrapper.CustomEvent("epic_unlocked");
	}

	public static void EpicQuestStarted(string questId)
	{
		string text = "start_" + questId;
		Utils.LogIfEditor("EpicQuestStarted: " + text);
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void EpicQuestCompleted(string questId)
	{
		string text = "compl_" + questId;
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void WeeklyQuestCompleted()
	{
		AnalyticsWrapper.CustomEvent("compl_weekly_quest");
	}

	public static void WeeklyQuestRewardCollected()
	{
		AnalyticsWrapper.CustomEvent("weekly_quest_reward");
	}

	public static void QuestStarted(string questId, int questLevel)
	{
		string text = "start_" + questId;
		if (questLevel > 0)
		{
			text = text + "_" + questLevel;
		}
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			Utils.LogIfEditor("QuestStarted: " + text + " questId: " + questId + " questLevel: " + questLevel);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void QuestCompleted(string questId, int questLevel, int time, int simpPower, int quasiNormTime)
	{
		string text = "compl_" + questId;
		if (questLevel > 0)
		{
			text = text + "_" + questLevel;
		}
		if (!HasSubmitted(text))
		{
			MarkSubmitted(text);
			try
			{
				AnalyticsWrapper.AddEventParam("time", time.ToString());
				AnalyticsWrapper.AddEventParam("simpPower", simpPower.ToString());
				AnalyticsWrapper.AddEventParam("quasiNormTime", quasiNormTime.ToString());
				AnalyticsWrapper.CustomEvent(text);
			}
			catch (Exception ex)
			{
				Utils.LogError("Failed to send analytics for quest completed. " + ex.Message);
			}
		}
	}

	public static void ReferralQuestUnlocked()
	{
		AnalyticsWrapper.CustomEvent("referral_quest_unlocked");
	}

	public static void ReferralQuestReward()
	{
		AnalyticsWrapper.CustomEvent("referral_quest_reward");
	}

	public static void ReferralKeyRedeemed()
	{
		AnalyticsWrapper.AddEventParam("char_level", XPController.singleton.currentLevel);
		AnalyticsWrapper.AddEventParam("total_loc_stars", QuestController.singleton.GetTotalStars());
		AnalyticsWrapper.AddEventParam("skull_game_count", UndeadCryptIntro.timesPlayed);
		AnalyticsWrapper.CustomEvent("referral_key_redeemed");
	}

	public static void Died(string questId, int questLevel, string killedBy)
	{
	}

	public static void SightstoneUsed(Data.Quest questData, string enemyId)
	{
	}

	public static void ItemCrafted(ItemFactory.Result craftResult, bool hasMadeBefore)
	{
	}

	public static void ItemCraftFailed(ItemFactory.Result craftResult)
	{
	}

	public static void ItemEquipped(Item item, string hand)
	{
		if (item.id == "dirty_sword")
		{
			AnalyticsWrapper.CustomEvent("equip_dirty_sword");
		}
	}

	public static void LevelUp(int newLevel)
	{
	}

	public static void OpenTreasure(TreasureItem treasure)
	{
	}

	public static void ItemDetails(Item item)
	{
	}

	public static void ShopOpened()
	{
		AnalyticsWrapper.CustomEvent("shop_opened");
	}

	public static void ShopPurchase(string itemName, decimal price)
	{
		string text = "shop_purchase";
		if (!HasSubmitted(text))
		{
			HasSubmitted(text);
			try
			{
				Analytics.Transaction(itemName, price, InAppPurchaseController.singleton.GetLocalizedCurrencyCode());
				AnalyticsWrapper.AddEventParam("item", itemName);
				AnalyticsWrapper.CustomEvent(text);
			}
			catch (Exception ex)
			{
				Utils.LogError("Failed to send analytics for shop purchase. " + ex.Message);
			}
		}
	}

	public static void SawCredits()
	{
	}

	public static void PressedDiscordButton()
	{
		AnalyticsWrapper.CustomEvent("discord_button");
	}

	public static void WatchedMushroomShop()
	{
		AnalyticsWrapper.CustomEvent("wte_watched_mushroom_shop");
	}

	public static void OfferedTreasureUpgrade()
	{
		AnalyticsWrapper.CustomEvent("wte_offered_treasure_upgrade");
	}

	public static void WatchedTreasureUpgrade()
	{
		AnalyticsWrapper.CustomEvent("wte_watched_treasure_upgrade");
	}

	public static void WatchedFastForward()
	{
		AnalyticsWrapper.CustomEvent("wte_watched_fast_forward");
	}

	public static void FailedToShowAd()
	{
		AnalyticsWrapper.CustomEvent("wte_failed_to_show_ad");
	}

	public static void ApproachedGilbert()
	{
		string text = "approached_gilbert";
		if (!HasSubmitted(text))
		{
			Utils.LogIfEditor("approached_gilbert sent.");
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void FirstEnemyEngaged()
	{
		string text = "first_enemy_engaged";
		if (!HasSubmitted(text))
		{
			Utils.LogIfEditor("first_enemey_engaged sent.");
			MarkSubmitted(text);
			AnalyticsWrapper.CustomEvent(text);
		}
	}

	public static void LocationLeaderboardFirstOpen()
	{
		Utils.LogIfEditor("LocationLeaderboardFirstOpen");
		AnalyticsWrapper.CustomEvent("location_leaderboard_first_open");
	}

	public static void LocationLeaderboardOpen()
	{
		Utils.LogIfEditor("LocationLeaderboardOpen");
		AnalyticsWrapper.CustomEvent("location_leaderboard_open");
	}

	public static void LocationLeaderboardSubmitOk()
	{
		Utils.LogIfEditor("LocationLeaderboardSubmitOk");
		AnalyticsWrapper.CustomEvent("location_leaderboard_submit_ok");
	}

	public static void LocationLeaderboardSubmitCancel()
	{
		Utils.LogIfEditor("LocationLeaderboardSubmitCancel");
		AnalyticsWrapper.CustomEvent("location_leaderboard_submit_cancel");
	}

	public static void RestartProgress()
	{
	}

	private static string GetLoadoutString()
	{
		Hero hero = GameStates.Singleton.hero;
		string text = "";
		if ((bool)hero.LeftHand)
		{
			text += hero.LeftHand.GetGroupId();
		}
		text += ",";
		if ((bool)hero.RightHand)
		{
			text += hero.RightHand.GetGroupId();
		}
		return text;
	}
}
