using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
	public enum Type
	{
		UseSightStone = 0,
		UseStarStone = 1,
		UseKiStone = 2,
		UseXPStone = 3,
		UseOuroboros = 4,
		UseQuestStone = 5,
		UseFissureStone = 6,
		UseTriskelion = 7,
		UseMindStone = 8,
		UseMoondial = 9,
		PassRantingTree = 10,
		DysangelosHelp = 11,
		UpgradeItemStar = 12,
		CraftNewItem = 13,
		Craft100Items = 14,
		UpgradeItemToMax = 15,
		DefeatXyloalgia5 = 16,
		DefeatBolesh5 = 17,
		DefeatAngryShroom5 = 18,
		DefeatPallas5 = 19,
		DefeatGuardian5 = 20,
		DefeatHrimnir5 = 21,
		DefeatNagaraja5 = 22,
		DefeatDysangelos5 = 23,
		Defeat10000foes = 24,
		Collect1MillionRes = 25,
		GetBooklet = 26,
		CompleteBooklet = 27,
		Cyan5 = 28,
		UpgradeEnchantment = 29,
		CraftTranscendent = 30,
		AllPotions = 31,
		SkullGame = 32,
		TypeStonescript = 33,
		ShareStonescript = 34,
		AFKFarming = 35,
		MidnightFarmer = 36,
		ClearOneShopItem = 37,
		ClearShop = 38,
		OneShootBoss = 39,
		UnmakePallasArm = 40,
		MutateItem = 41,
		MaxPlayerLevel = 42,
		Yellow5 = 43,
		Import = 44,
		AllEpicQuests = 45,
		SelfUnmakeMirror = 46
	}

	private AAchievementStore achievementStore;

	private string[] counterKeys = new string[5] { "ITEMS_CRAFTED", "FOES_DEFEATED", "SKULL_GAMES", "STONESCRIPT_KEYS", "TRISKELION_USED" };

	private Dictionary<string, int> counters = new Dictionary<string, int>();

	private List<string> potionsUsed = new List<string>();

	private float lastArmor = -1f;

	private string oneShootBossContender;

	private int afkLoopCounter;

	private DateTime afkStartTime;

	private HashSet<string> _wants = new HashSet<string>();

	public static AchievementController singleton { get; private set; }

	public void ReportSightStoneUsed()
	{
		CompleteIfNeeded(Type.UseSightStone);
	}

	public void ReportStarStoneUsed()
	{
		CompleteIfNeeded(Type.UseStarStone);
	}

	public void ReportKiStoneUsed()
	{
		CompleteIfNeeded(Type.UseKiStone);
	}

	public void ReportXPStoneUsed()
	{
		CompleteIfNeeded(Type.UseXPStone);
	}

	public void ReportOuroborosHealed()
	{
		CompleteIfNeeded(Type.UseOuroboros);
	}

	public void ReportQuestStoneUsed()
	{
		if (Wants(Type.UseQuestStone))
		{
			if (lastArmor >= 0f && lastArmor < GameStates.Singleton.hero.Armor && GameStates.Singleton.hero.GetComponent<HeroAI>().targetEnemy != null)
			{
				CompleteIfNeeded(Type.UseQuestStone);
			}
			lastArmor = GameStates.Singleton.hero.Armor;
		}
	}

	public void ReportFissureStoneUsed()
	{
		CompleteIfNeeded(Type.UseFissureStone);
	}

	public void ReportTriskelionStoneUsed()
	{
		if (IncreaseCounter("TRISKELION_USED") >= 3)
		{
			CompleteIfNeeded(Type.UseTriskelion);
		}
	}

	public void ReportMindStoneUsed()
	{
		CompleteIfNeeded(Type.UseMindStone);
	}

	public void ReportMoondialUsed()
	{
		CompleteIfNeeded(Type.UseMoondial);
	}

	public void ReportPassingRantingTreeWithoutUnmaking()
	{
		CompleteIfNeeded(Type.PassRantingTree);
	}

	public void ReportDysangelosHelped()
	{
		CompleteIfNeeded(Type.DysangelosHelp);
	}

	public void ReportCraftedOnAnvil(ItemFactory.Result craftResult)
	{
		if (craftResult.outcome != ItemFactory.Result.Outcome.Boosted && craftResult.outcome != ItemFactory.Result.Outcome.Fused)
		{
			return;
		}
		if (IncreaseCounter("ITEMS_CRAFTED") >= 100)
		{
			CompleteIfNeeded(Type.Craft100Items);
		}
		if (craftResult.outcome == ItemFactory.Result.Outcome.Boosted)
		{
			CompleteIfNeeded(Type.UpgradeItemStar);
			if (Wants(Type.UpgradeItemToMax) && ItemFactory.GetLevelDisplayIntegerForItem(craftResult.resultingItem) == ItemFactory.MAX_DISPLAY_LEVEL)
			{
				CompleteIfNeeded(Type.UpgradeItemToMax);
			}
		}
		else if (craftResult.outcome == ItemFactory.Result.Outcome.Fused)
		{
			CompleteIfNeeded(Type.CraftNewItem);
		}
	}

	public void ReportXyloDefeated(Enemy enemy)
	{
		if (GameStates.Singleton.level.QuestData.level >= 5)
		{
			CompleteIfNeeded(Type.DefeatXyloalgia5);
			ReportLocationCompleted(GameStates.Singleton.level.QuestData);
		}
	}

	public void ReportBoleshDefeated(Enemy enemy)
	{
		if (GameStates.Singleton.level.QuestData.level >= 5)
		{
			CompleteIfNeeded(Type.DefeatBolesh5);
			ReportLocationCompleted(GameStates.Singleton.level.QuestData);
		}
	}

	public void ReportAngryShroomDefeated(Enemy enemy)
	{
		if (GameStates.Singleton.level.QuestData.level >= 5)
		{
			CompleteIfNeeded(Type.DefeatAngryShroom5);
			ReportLocationCompleted(GameStates.Singleton.level.QuestData);
		}
	}

	public void ReportPallasDefeated(Enemy enemy)
	{
		if (GameStates.Singleton.level.QuestData.level >= 5)
		{
			CompleteIfNeeded(Type.DefeatPallas5);
			ReportLocationCompleted(GameStates.Singleton.level.QuestData);
		}
	}

	public void ReportGuardianDefeated(Enemy enemy)
	{
		if (GameStates.Singleton.level.QuestData.level >= 5)
		{
			CompleteIfNeeded(Type.DefeatGuardian5);
			ReportLocationCompleted(GameStates.Singleton.level.QuestData);
		}
	}

	public void ReportHrimnirDefeated(Enemy enemy)
	{
		if (GameStates.Singleton.level.QuestData.level >= 5)
		{
			CompleteIfNeeded(Type.DefeatHrimnir5);
			ReportLocationCompleted(GameStates.Singleton.level.QuestData);
		}
	}

	public void ReportNagarajaDefeated(Enemy enemy)
	{
		if (GameStates.Singleton.level.QuestData.level >= 5)
		{
			CompleteIfNeeded(Type.DefeatNagaraja5);
			ReportLocationCompleted(GameStates.Singleton.level.QuestData);
		}
	}

	public void ReportDysangelosDefeated(Enemy enemy)
	{
		CompleteIfNeeded(Type.DefeatDysangelos5);
		ReportLocationCompleted(GameStates.Singleton.level.QuestData);
	}

	private void HandleCharacterGoingToTakeDamage(Character c, Damage dmg)
	{
		if (Wants(Type.OneShootBoss))
		{
			if (c.Hitpoints == c.MaxHitpoints && Mathf.Approximately(c.Armor, c.MaxArmor) && c.tags.Contains("boss"))
			{
				oneShootBossContender = c.id;
			}
			else
			{
				oneShootBossContender = null;
			}
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (c.id == oneShootBossContender && c.tags.Contains("boss") && c.Hitpoints <= 0)
		{
			CompleteIfNeeded(Type.OneShootBoss);
		}
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage damage)
	{
		if (reason == Character.DeathReason.DamageTaken && c is Enemy && IncreaseCounter("FOES_DEFEATED") >= 10000)
		{
			CompleteIfNeeded(Type.Defeat10000foes);
		}
	}

	public void ReportResourceChanged(Data.Resource resource, int newAmount)
	{
		if (newAmount >= 1000000)
		{
			CompleteIfNeeded(Type.Collect1MillionRes);
		}
	}

	public void ReportItemAcquired(Item item)
	{
		if (Wants(Type.GetBooklet) && item.id == "craft_book")
		{
			CompleteIfNeeded(Type.GetBooklet);
		}
	}

	public void ReportAllCraftRecipiesDiscovered()
	{
		CompleteIfNeeded(Type.CompleteBooklet);
	}

	public void ReportLocationCompleted(Data.Quest quest)
	{
		if (quest.level == 10)
		{
			CompleteIfNeeded(Type.Cyan5);
		}
		else if (quest.level == 15)
		{
			CompleteIfNeeded(Type.Yellow5);
		}
	}

	public void ReportEnchantmentUpgraded(ItemFactory.FuseResult result)
	{
		CompleteIfNeeded(Type.UpgradeEnchantment);
		if (result.resultPrimaryItem != null && result.resultPrimaryItem.GetRarityType() == ItemData.Rarity.Type.Transcendent)
		{
			CompleteIfNeeded(Type.CraftTranscendent);
		}
	}

	public void ReportPotionUsed(Potion potion)
	{
		if (Wants(Type.AllPotions))
		{
			string item = potion.type.ToString();
			if (!potionsUsed.Contains(item))
			{
				potionsUsed.Add(item);
			}
			if (potionsUsed.Count >= 10)
			{
				CompleteIfNeeded(Type.AllPotions);
			}
		}
	}

	public void ReportSkullGameCompleted()
	{
		if (IncreaseCounter("SKULL_GAMES") >= 5)
		{
			CompleteIfNeeded(Type.SkullGame);
		}
	}

	public void ReportStonescriptChanged()
	{
		if (Wants(Type.TypeStonescript) && IncreaseCounter("STONESCRIPT_KEYS") >= 30)
		{
			CompleteIfNeeded(Type.TypeStonescript);
		}
	}

	public void ReportStonescriptCopiedAll()
	{
		CompleteIfNeeded(Type.ShareStonescript);
	}

	public void ReportLocationStartedManually(Data.Quest quest)
	{
		afkLoopCounter = 0;
		afkStartTime = DateTime.Now;
	}

	public void ReportEquipmentChanged()
	{
		afkLoopCounter = -1;
	}

	public void ReportOuroborosTriggered(Data.Quest quest)
	{
		afkLoopCounter++;
		if (afkLoopCounter == 2)
		{
			CompleteIfNeeded(Type.AFKFarming);
		}
	}

	public void ReportLocationPausedManually()
	{
		if (afkLoopCounter >= 10)
		{
			DateTime now = DateTime.Now;
			if (now.Day != afkStartTime.Day || now.Month != afkStartTime.Month)
			{
				CompleteIfNeeded(Type.MidnightFarmer);
			}
		}
	}

	public void ReportOneShopItemCleared()
	{
		CompleteIfNeeded(Type.ClearOneShopItem);
	}

	public void ReportShopCleared()
	{
		CompleteIfNeeded(Type.ClearShop);
	}

	public void ReportInstaKilledFoe(Character c)
	{
		if (c.id.StartsWith("skeleton_boss_sword_arm"))
		{
			CompleteIfNeeded(Type.UnmakePallasArm);
		}
	}

	public void ReportItemMutated()
	{
		CompleteIfNeeded(Type.MutateItem);
	}

	public void ReportMaxPlayerLevelReached()
	{
		CompleteIfNeeded(Type.MaxPlayerLevel);
	}

	public void ReportImportTyped()
	{
		CompleteIfNeeded(Type.Import);
	}

	public void ReportAllEpicQuestsCompleted()
	{
		CompleteIfNeeded(Type.AllEpicQuests);
	}

	public void ReportSelfUnmakeMirror()
	{
		CompleteIfNeeded(Type.SelfUnmakeMirror);
	}

	private bool Wants(Type type)
	{
		return !_wants.Contains(type.ToString());
	}

	private void CompleteIfNeeded(Type type)
	{
		if (achievementStore == null)
		{
			Utils.LogError("Could not complete achievement " + type.ToString() + " because the store is null.");
		}
		else if (Wants(type))
		{
			if (achievementStore.UnlockAchievement(type))
			{
				_wants.Add(type.ToString());
				Utils.Log("Completed achievement: " + type);
			}
			else
			{
				Utils.LogError("Failed to unlock achievement " + type);
			}
		}
	}

	private int IncreaseCounter(string key)
	{
		if (counters.ContainsKey(key))
		{
			int num = counters[key];
			num++;
			counters[key] = num;
			return num;
		}
		counters.Add(key, 1);
		return 1;
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		for (int i = 0; i < counterKeys.Length; i++)
		{
			string key = counterKeys[i];
			if (counters.ContainsKey(key))
			{
				int property = counters[key];
				SlimJson.AddProperty(key, property);
			}
		}
		if (potionsUsed.Count > 0)
		{
			SlimJson.AddProperty("potions", potionsUsed.ToArray());
		}
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson == null)
		{
			return;
		}
		for (int i = 0; i < counterKeys.Length; i++)
		{
			string key = counterKeys[i];
			if (SlimJson.HasKey(sjson, key))
			{
				int value = SlimJson.ParseInt(sjson, key);
				counters.Add(key, value);
			}
		}
		string[] array = SlimJson.ParseArray(sjson, "potions");
		if (array != null)
		{
			potionsUsed.AddRange(array);
		}
	}

	public void ClearProgress()
	{
		counters.Clear();
		potionsUsed.Clear();
	}

	private void Start()
	{
		achievementStore = base.gameObject.AddComponent<SteamAchievementStore>();
		achievementStore.Init();
	}

	private void Awake()
	{
		singleton = this;
		Character.OnCharacterDied += HandleCharacterDied;
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}
}
