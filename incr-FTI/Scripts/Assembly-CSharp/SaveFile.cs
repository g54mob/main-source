using System;
using System.Collections.Generic;
using System.Globalization;
using FullSerializer;
using UnityEngine;

public class SaveFile
{
	private static Town targetTown;

	private static int targetTownIndex;

	private static bool hasLoadedPerks;

	private static float questRewardCount;

	public static float levelOfLegacyPerkEfficiency;

	public static int levelOfLegacyManaPowerDrillUpgrade;

	public static int levelOfLegacyManaPowerHarvesterUpgrade;

	public static int levelOfLegacyManaPowerTractorUpgrade;

	public static int levelOfLegacyManaPowerChainsawUpgrade;

	public static BuildingCategory queuedProductionPanelFilter;

	private static readonly fsData fsDataPlaceholder = new fsData(0L);

	private static GameManager gm => GameManager.Instance;

	public static string GameStateAsString()
	{
		FileManager.ConfigureProcessor();
		return fsJsonPrinter.CompressedJson(CurrentGameState());
	}

	public static void RestoreGameStateFromData(fsData data)
	{
		queuedProductionPanelFilter = BuildingCategory.None;
		questRewardCount = 0f;
		levelOfLegacyPerkEfficiency = 0f;
		levelOfLegacyManaPowerDrillUpgrade = 0;
		levelOfLegacyManaPowerHarvesterUpgrade = 0;
		levelOfLegacyManaPowerTractorUpgrade = 0;
		levelOfLegacyManaPowerChainsawUpgrade = 0;
		MenuManager.Instance.ResetMenuState();
		Crafting.LoadDefaults();
		if (data.TryAsDictionary(out var result))
		{
			gm.activeTownIndex = 0;
			TryLoadInt(result, "ActiveTownIndex", ref gm.activeTownIndex);
			TryLoadDouble(result, "ClickResources", ref gm.itemsGainedFromClicking);
			TryLoadDouble(result, "IdleTimeCollected", ref gm.idleSecondsCollected);
			TryLoadInt(result, "ClickLevel", ref gm.clickLevel);
			TryLoadInt(result, "RandomRewardSeed", ref gm.randomRewardSeed);
			TryLoadLong(result, "LastSaveDate", ref gm.lastSaveTimestamp);
			TryLoadLong(result, "LastPerkReset", ref gm.lastGlobalPerkResetTimestamp);
			TryLoadLong(result, "LastRewardClaim", ref gm.lastRewardClaimTimestamp);
			TryLoadLong(result, "WorldCreationTimestamp", ref gm.worldCreationTimestamp);
			TryLoadInt(result, "v", ref gm.lastSaveVersion);
			TryLoadBool(result, "hasClaimedReward", ref gm.hasClaimedLevelRewards);
			if (result.TryGetValue("gameModifiers", out var value) && value.TryAsList(out var result2))
			{
				foreach (fsData item in result2)
				{
					if (item.TryAsInt(out var i))
					{
						gm.ApplyModifierToGameState((GameModifier)i);
					}
				}
			}
			Crafting.LoadAllGameData();
			gm.InitializeGameStates();
			gm.ResetGameState();
			if (result.TryGetValue("Stats", out var value2) && value2.TryAsDictionary(out var result3))
			{
				LoadGlobalStatsFromDict(result3);
			}
			if (result.TryGetValue("perks", out var value3))
			{
				LoadPurchasedPerksFromData(value3, gm.globalPerks);
			}
			result.TryGetValue("Towns", out var _);
			if (result.TryGetValue("Towns", out var value5) && value5.TryAsList(out var result4))
			{
				gm.ConfirmTownIndex(result4.Count - 1);
				for (int j = 0; j < result4.Count; j++)
				{
					fsData fsData2 = result4[j];
					targetTownIndex = j;
					if (!fsData2.IsNull)
					{
						Town town = new Town(GameManager.DefaultBiomeForIndex(j), j);
						gm.towns[j] = town;
						targetTown = town;
						LoadTownFromData(fsData2);
						targetTown = null;
						town.isCapitalCity = j == 0;
					}
				}
			}
			if (result.TryGetValue("quests", out var value6))
			{
				LoadQuestsFromData(value6, gm.globalQuests);
			}
			if (result.TryGetValue("inventory", out var value7))
			{
				LoadInventoryFromData(value7, gm.globalInventory);
			}
			if (result.TryGetValue("Menu", out var value8))
			{
				LoadMenuFromData(value8);
			}
			if (result.TryGetValue("TimeTokens", out var value9) && value9.TryAsDouble(out var f))
			{
				gm.timeTokenState.currentCount = f;
			}
			if (result.TryGetValue("RewardBoosts", out var value10) && value10.TryAsInt(out var i2))
			{
				gm.numRewardBoosts = i2;
			}
			if (result.TryGetValue("QuestCoins", out var value11) && value11.TryAsDouble(out var f2))
			{
				gm.questCoinState.currentCount = f2;
			}
			else
			{
				gm.questCoinState.currentCount = questRewardCount;
			}
		}
		gm.activeTown = gm.towns[gm.activeTownIndex];
		if (gm.activeTown == null)
		{
			Debug.LogError("Null loaded town! index: " + gm.activeTownIndex);
		}
		GameManager.Instance.FinalizeLoadedWorld();
	}

	public static void LoadBuildingStatDictionary(Dictionary<string, fsData> source, string property, Dictionary<BuildingType, FloatProperty> target)
	{
		if (!source.TryGetValue(property, out var value) || !value.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsList(out var result2) || result2.Count < 2)
			{
				continue;
			}
			fsData data = result2[0];
			fsData data2 = result2[1];
			if (data.TryAsInt(out var i) && data2.TryAsDouble(out var f))
			{
				BuildingType key = (BuildingType)i;
				if (target.TryGetValue(key, out var value2))
				{
					value2.value = f;
				}
			}
		}
	}

	public static void LoadItemStatDictionary(Dictionary<string, fsData> source, string property, Dictionary<ItemType, FloatProperty> target)
	{
		if (!source.TryGetValue(property, out var value) || !value.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsList(out var result2) || result2.Count < 2)
			{
				continue;
			}
			fsData data = result2[0];
			fsData data2 = result2[1];
			if (data.TryAsInt(out var i) && data2.TryAsDouble(out var f))
			{
				ItemType key = (ItemType)i;
				if (target.TryGetValue(key, out var value2))
				{
					value2.value = f;
				}
			}
		}
	}

	public static void StoreStatDictionary<T>(Dictionary<string, fsData> target, string property, Dictionary<T, FloatProperty> source) where T : struct, IConvertible
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<T, FloatProperty> item in source)
		{
			List<fsData> list2 = new List<fsData>();
			int num = item.Key.ToInt32(CultureInfo.InvariantCulture);
			list2.Add(new fsData(num));
			list2.Add(new fsData(item.Value.value));
			list.Add(new fsData(list2));
		}
		target[property] = new fsData(list);
	}

	private static fsData GetGlobalStatData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		StoreStatDictionary(dictionary, "ItemProductionCounts", gm.globalProductionStats);
		return new fsData(dictionary);
	}

	public static void LoadTownFromData(fsData townData)
	{
		if (townData.TryAsDictionary(out var result))
		{
			if (result.TryGetValue("name", out var value) && value.TryAsString(out var s))
			{
				targetTown.townName = s;
			}
			if (result.TryGetValue("Stats", out var value2))
			{
				LoadTownStatsFromData(value2);
			}
			if (result.TryGetValue("Minimized", out var value3))
			{
				LoadTownMinimizationFromData(value3);
			}
			if (result.TryGetValue("inventory", out var value4))
			{
				LoadInventoryFromData(value4, targetTown.inventory);
			}
			if (result.TryGetValue("naturalResources", out var value5))
			{
				LoadNaturalResourcesFromData(value5);
			}
			if (result.TryGetValue("buildings", out var value6))
			{
				LoadBuildingsFromData(value6);
			}
			if (result.TryGetValue("completedUpgrades", out var value7))
			{
				LoadCompletedUpgradesFromData(value7);
			}
			if (result.TryGetValue("Harvesting", out var value8))
			{
				LoadHarvestingFromData(value8);
			}
			if (result.TryGetValue("Farming", out var value9))
			{
				LoadFarmingFromData(value9);
			}
			if (result.TryGetValue("Mining", out var value10))
			{
				LoadMiningFromData(value10);
			}
			if (result.TryGetValue("Crafting", out var value11))
			{
				LoadCraftingFromData(value11);
			}
			if (result.TryGetValue("Research", out var value12))
			{
				LoadResearchFromData(value12);
			}
			if (result.TryGetValue("Market", out var value13))
			{
				LoadMarketFromData(value13);
			}
			if (result.TryGetValue("Trading", out var value14))
			{
				LoadTradesFromData(value14);
			}
			if (result.TryGetValue("TradingConfig", out var value15))
			{
				LoadTradeConfigsFromData(value15);
			}
			if (result.TryGetValue("completedResearch", out var value16))
			{
				LoadCompletedResearchFromData(value16, targetTown.research);
			}
			if (result.TryGetValue("Skills", out var value17))
			{
				LoadSkillsDictionary(value17, targetTown.townSkills);
			}
			if (result.TryGetValue("localPerks", out var value18))
			{
				LoadPurchasedPerksFromData(value18, targetTown.townPerks);
			}
			if (result.TryGetValue("Menu", out var value19))
			{
				LoadMenuFromData(value19);
			}
			if (levelOfLegacyManaPowerChainsawUpgrade > 0)
			{
				targetTown.research[ResearchType.ManaPowerChainsawTanks].numCompleted = levelOfLegacyManaPowerChainsawUpgrade;
			}
			if (levelOfLegacyManaPowerDrillUpgrade > 0)
			{
				targetTown.research[ResearchType.ManaPowerHarvesterDrills].numCompleted = levelOfLegacyManaPowerDrillUpgrade;
			}
			if (levelOfLegacyManaPowerHarvesterUpgrade > 0)
			{
				targetTown.research[ResearchType.ManaPowerCropHarvesters].numCompleted = levelOfLegacyManaPowerHarvesterUpgrade;
			}
			if (levelOfLegacyManaPowerTractorUpgrade > 0)
			{
				targetTown.research[ResearchType.ManaPowerTractors].numCompleted = levelOfLegacyManaPowerTractorUpgrade;
			}
			targetTown.CalcPostLoadMetadata();
		}
	}

	private static void LoadMinigameDataFromDictionary(Dictionary<string, fsData> townDictionary)
	{
		MenuManager instance = MenuManager.Instance;
		if (townDictionary.TryGetValue("MinigameFarming", out var value))
		{
			instance.minigamePanelFarming.LoadFromData(value);
		}
		if (townDictionary.TryGetValue("MinigameWater", out var value2))
		{
			instance.minigamePanelWater.LoadFromData(value2);
		}
		if (townDictionary.TryGetValue("MinigameDice", out var value3))
		{
			instance.minigamePanelDice.LoadFromData(value3);
		}
		if (townDictionary.TryGetValue("MinigameResearch", out var value4))
		{
			instance.minigamePanelResearch.LoadFromData(value4);
		}
		if (townDictionary.TryGetValue("MinigameWood", out var value5))
		{
			instance.minigamePanelWood.LoadFromData(value5);
		}
		if (townDictionary.TryGetValue("MinigameMining", out var value6))
		{
			instance.minigamePanelMining.LoadFromData(value6);
		}
	}

	private static void LoadCompletedUpgradesFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsList(out var result2) || result2.Count < 2)
			{
				continue;
			}
			fsData data2 = result2[0];
			fsData data3 = result2[1];
			if (!data2.TryAsInt(out var i) || !data3.TryAsInt(out var i2))
			{
				continue;
			}
			UpgradeType upgradeType = (UpgradeType)i;
			if (targetTown != null)
			{
				_ = targetTown.upgrades;
			}
			if (targetTown.upgrades.TryGetValue(upgradeType, out var value))
			{
				value.numCompleted = i2;
				if (!value.def.isInfinite && value.numCompleted > value.MaxLevel())
				{
					value.numCompleted = value.MaxLevel();
				}
				continue;
			}
			switch (upgradeType)
			{
			case UpgradeType.ShrineSpeed_Legacy:
				targetTown.upgrades[UpgradeType.FireShrineSpeed].numCompleted = i2;
				targetTown.upgrades[UpgradeType.WaterShrineSpeed].numCompleted = i2;
				targetTown.upgrades[UpgradeType.EarthShrineSpeed].numCompleted = i2;
				targetTown.upgrades[UpgradeType.AirShrineSpeed].numCompleted = i2;
				break;
			case UpgradeType.ManaPowerDrills_Legacy:
				levelOfLegacyManaPowerDrillUpgrade = i2;
				break;
			case UpgradeType.ManaPowerTractors_Legacy:
				levelOfLegacyManaPowerTractorUpgrade = i2;
				break;
			case UpgradeType.ManaPowerCropHarvesters_Legacy:
				levelOfLegacyManaPowerHarvesterUpgrade = i2;
				break;
			case UpgradeType.ManaChainsawTanks_Legacy:
				levelOfLegacyManaPowerChainsawUpgrade = i2;
				break;
			}
		}
	}

	private static void LoadPurchasedPerksFromData(fsData data, Dictionary<PerkType, PerkState> target)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsList(out var result2) || result2.Count < 2)
			{
				continue;
			}
			fsData data2 = result2[0];
			fsData data3 = result2[1];
			if (!data2.TryAsInt(out var i) || !data3.TryAsDouble(out var f))
			{
				continue;
			}
			PerkType perkType = (PerkType)i;
			if (target.TryGetValue(perkType, out var value))
			{
				value.currentCount = (float)f;
				if (Crafting.perkDefCache.TryGetValue(perkType, out var value2) && value.currentCount > (double)value2.maxLevel)
				{
					value.currentCount = value2.maxLevel;
				}
			}
			else if (perkType == PerkType.UpgradeEfficiency)
			{
				levelOfLegacyPerkEfficiency = (float)f;
			}
		}
	}

	private static void LoadSkillsDictionary(fsData data, Dictionary<SkillType, Dictionary<EntityId, Skill>> target)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsDictionary(out var result2) && result2.TryGetValue("type", out var value) && value.TryAsInt(out var i))
			{
				SkillType skillType = (SkillType)i;
				if (result2.TryGetValue("value", out var value2))
				{
					LoadSkillsFromData(skillType, value2, target);
				}
			}
		}
	}

	private static void LoadSkillsFromData(SkillType skillType, fsData data, Dictionary<SkillType, Dictionary<EntityId, Skill>> target)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsList(out var result2) && result2.Count >= 2)
			{
				fsData data2 = result2[0];
				fsData data3 = result2[1];
				EntityId key = EntityFromData(data2);
				data3.TryAsDouble(out var f);
				if (skillType == SkillType.Harvesting)
				{
					key = new EntityId(key.intId, EntityType.HarvestRecipe);
				}
				if (target.TryGetValue(skillType, out var value) && value.TryGetValue(key, out var value2))
				{
					value2.experience.SetPoints((float)f);
					value2.experience.CalculateLevelFromPoints();
				}
			}
		}
	}

	private static void LoadCompletedResearchFromData(fsData data, Dictionary<ResearchType, ResearchState> target)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsList(out var result2) || result2.Count < 2)
			{
				continue;
			}
			fsData data2 = result2[0];
			fsData data3 = result2[1];
			if (!data2.TryAsInt(out var i) || !data3.TryAsInt(out var i2))
			{
				continue;
			}
			ResearchType researchType = (ResearchType)i;
			if (target.TryGetValue(researchType, out var value))
			{
				value.numCompleted = i2;
				continue;
			}
			switch (researchType)
			{
			case ResearchType.GrainProcessingSpeed1_Disabled:
				targetTown.IncrementResearch(ResearchType.GrainProcessingSpeed);
				continue;
			case ResearchType.GrainProcessingSpeed2_Disabled:
				targetTown.IncrementResearch(ResearchType.GrainProcessingSpeed);
				continue;
			case ResearchType.GrainProcessingSpeed3_Disabled:
				targetTown.IncrementResearch(ResearchType.GrainProcessingSpeed);
				continue;
			case ResearchType.WoodProcessingSpeed1:
				targetTown.IncrementResearch(ResearchType.WoodProcessingSpeed);
				continue;
			case ResearchType.WoodProcessingSpeed2:
				targetTown.IncrementResearch(ResearchType.WoodProcessingSpeed);
				continue;
			case ResearchType.WoodProcessingSpeed3:
				targetTown.IncrementResearch(ResearchType.WoodProcessingSpeed);
				continue;
			case ResearchType.StoneProcessingSpeed1:
				targetTown.IncrementResearch(ResearchType.StoneProcessingSpeed);
				continue;
			case ResearchType.StoneProcessingSpeed2:
				targetTown.IncrementResearch(ResearchType.StoneProcessingSpeed);
				continue;
			case ResearchType.StoneProcessingSpeed3:
				targetTown.IncrementResearch(ResearchType.StoneProcessingSpeed);
				continue;
			case ResearchType.AutomaticAssignment:
			{
				if (gm.globalQuests.TryGetValue(Quest.UnlockAutoBalance, out var value3))
				{
					value3.availability = BuildObjectAvailability.Completed;
				}
				continue;
			}
			case ResearchType.Prioritization_Disabled:
			{
				if (gm.globalQuests.TryGetValue(Quest.UnlockPrioritization, out var value2))
				{
					value2.availability = BuildObjectAvailability.Completed;
				}
				continue;
			}
			}
			int num = i / 100;
			int num2 = i % 100;
			ResearchType key = ResearchType.None;
			switch (num)
			{
			case 100:
				key = ResearchType.EtherBonusFirePower;
				break;
			case 101:
				key = ResearchType.EtherBonusWaterPower;
				break;
			case 102:
				key = ResearchType.EtherBonusEarthPower;
				break;
			case 103:
				key = ResearchType.EtherBonusAirPower;
				break;
			case 104:
				key = ResearchType.EtherBonusManaPower;
				break;
			}
			if (targetTown.research.TryGetValue(key, out var value4))
			{
				int num3 = num2 + 1;
				if (value4.numCompleted < num3)
				{
					value4.numCompleted = num3;
				}
			}
		}
	}

	private static void LoadMenuFromData(fsData data)
	{
		if (!data.TryAsDictionary(out var result))
		{
			return;
		}
		if (result.TryGetValue("Filter", out var value) && value.TryAsInt(out var i))
		{
			queuedProductionPanelFilter = (BuildingCategory)i;
		}
		bool b3 = default(bool);
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in MenuManager.Instance.menuPanels)
		{
			MenuPanel value2 = menuPanel.Value;
			if (value2.panelType == MenuPanelType.TownStats || !result.TryGetValue(value2.layoutPrefKey, out var value3) || !value3.TryAsDictionary(out var result2))
			{
				continue;
			}
			if (result2.TryGetValue("SelfMinimized", out var value4) && value4.TryAsBool(out var b))
			{
				if (value2 is InventoryPanel inventoryPanel)
				{
					inventoryPanel.isMinimized = b;
				}
				else if (value2 is QuestsPanel questsPanel)
				{
					questsPanel.isMinimized = b;
				}
			}
			if (value2 is MenuListPanel { headerCollapseManager: not null } menuListPanel && result2.TryGetValue("Minimized", out var value5) && value5.TryAsList(out var result3))
			{
				foreach (fsData item in result3)
				{
					if (item.TryAsInt(out var i2))
					{
						menuListPanel.headerCollapseManager.SetMinimized(i2);
					}
				}
			}
			if (result2.TryGetValue("IsVisible", out var value6) && value6.TryAsBool(out var b2) && value2.panelCategory == PanelCategory.LeftBottom && b2)
			{
				value2.Show();
			}
			if (result2.TryGetValue("al", out var value7) && value7.TryAsBool(out b3) && b3)
			{
				value2.alertStateSelf = true;
			}
			if (value2 is InventoryPanel inventoryPanel2)
			{
				if (result2.TryGetValue("NumColumns", out var value8) && value8.TryAsInt(out var i3) && i3 > 0)
				{
					inventoryPanel2.columnMode = i3;
				}
				else
				{
					inventoryPanel2.columnMode = 0;
				}
			}
		}
	}

	private static void LoadMarketFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsDictionary(out var result2) && result2.TryGetValue("type", out var value) && value.TryAsInt(out var i))
			{
				ItemType key = (ItemType)i;
				if (targetTown.marketItems.TryGetValue(key, out var value2))
				{
					LoadStateFromData(value2, result2);
				}
			}
		}
	}

	private static void LoadTradeConfigsFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		for (int i = 0; i < result.Count; i += 2)
		{
			fsData data2 = result[i];
			fsData data3 = result[i + 1];
			if (!data2.TryAsInt(out var i2))
			{
				continue;
			}
			Specialty key = (Specialty)i2;
			if (!targetTown.tradeSpecialtyConfigs.TryGetValue(key, out var value))
			{
				continue;
			}
			Dictionary<string, fsData> result2;
			if (data3.TryAsInt(out var i3))
			{
				value.tradingConfig.InitializeValue(ConvertedTradeMode(i3));
			}
			else if (data3.TryAsDictionary(out result2))
			{
				LoadProductionConfigFromData(value.productionLimit, result2);
				if (result2.TryGetValue("RepeatAssign", out var value2) && value2.TryAsInt(out var i4))
				{
					value.autoAssign.InitializeValue((OverrideState)i4);
				}
				if (result2.TryGetValue("AutoClaim", out var value3) && value3.TryAsInt(out var i5))
				{
					value.autoClaim.InitializeValue((OverrideState)i5);
				}
				TryLoadPriority(result2, "priority", value.priority);
				if (result2.TryGetValue("Paused", out var value4) && value4.TryAsInt(out var i6))
				{
					value.pause.InitializeValue((OverrideState)i6);
				}
				if (result2.TryGetValue("tm", out var value5) && value5.TryAsInt(out var i7))
				{
					value.tradingConfig.InitializeValue(ConvertedTradeMode(i7));
				}
			}
		}
	}

	private static TradeMode ConvertedTradeMode(int tradeModeInt)
	{
		TradeMode tradeMode = (TradeMode)tradeModeInt;
		if (tradeMode == TradeMode.AutoTradeGlobalFill || tradeMode == TradeMode.AutoTradeGlobalBalance)
		{
			tradeMode = TradeMode.Export;
		}
		return tradeMode;
	}

	private static void LoadTradesFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsDictionary(out var result2) && result2.TryGetValue("type", out var value) && value.TryAsInt(out var i))
			{
				ItemType key = (ItemType)i;
				if (targetTown.trading.TryGetValue(key, out var value2))
				{
					LoadStateFromData(value2, result2);
				}
			}
		}
	}

	private static void LoadResearchFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsDictionary(out var result2) && result2.TryGetValue("type", out var value) && value.TryAsInt(out var i))
			{
				ResearchType key = (ResearchType)i;
				if (targetTown.research.TryGetValue(key, out var value2))
				{
					LoadStateFromData(value2, result2);
				}
			}
		}
	}

	private static void LoadCraftingFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsDictionary(out var result2) && result2.TryGetValue("type", out var value) && value.TryAsInt(out var i))
			{
				RecipeType key = (RecipeType)i;
				if (targetTown.recipes.TryGetValue(key, out var value2))
				{
					LoadStateFromData(value2, result2);
				}
			}
		}
	}

	private static void LoadMiningFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsDictionary(out var result2) && result2.TryGetValue("type", out var value) && value.TryAsInt(out var i))
			{
				NaturalResource key = (NaturalResource)i;
				if (targetTown.miningItems.TryGetValue(key, out var value2))
				{
					LoadStateFromData(value2, result2);
				}
			}
		}
	}

	private static void LoadFarmingFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsDictionary(out var result2) && result2.TryGetValue("type", out var value) && value.TryAsInt(out var i))
			{
				NaturalResource key = (NaturalResource)i;
				if (targetTown.farmingItems.TryGetValue(key, out var value2))
				{
					LoadStateFromData(value2, result2);
				}
			}
		}
	}

	private static void LoadHarvestingFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (item.TryAsDictionary(out var result2) && result2.TryGetValue("type", out var value) && value.TryAsInt(out var i))
			{
				HarvestRecipeType key = (HarvestRecipeType)i;
				if (targetTown.harvesting.TryGetValue(key, out var value2))
				{
					LoadStateFromData(value2, result2);
				}
			}
		}
	}

	private static void LoadStateFromData(StateManager sm, Dictionary<string, fsData> dataDict)
	{
		if (dataDict.TryGetValue("workersAssigned", out var value) && value.TryAsDouble(out var f))
		{
			if (f < 0.0)
			{
				sm.numWorkersAssigned = 0f;
			}
			else
			{
				sm.numWorkersAssigned = GameUtility.AsTruncatedFloat(f);
			}
		}
		if (dataDict.TryGetValue("w", out var value2) && value2.TryAsInt(out var i))
		{
			sm.numWorkersAssigned = i;
		}
		if (dataDict.TryGetValue("priority", out var value3) && value3.TryAsInt(out var i2))
		{
			sm.localSettings.priority.InitializeValue((StatePriority)i2);
		}
		LoadProductionConfigFromData(sm.localSettings.productionLimit, dataDict);
		fsData fsData2 = null;
		if (dataDict.ContainsKey("pr"))
		{
			fsData2 = dataDict["pr"];
		}
		else if (dataDict.ContainsKey("progress"))
		{
			fsData2 = dataDict["progress"];
		}
		if (null != fsData2 && fsData2.TryAsDouble(out var f2))
		{
			sm.unitProgress = GameUtility.AsTruncatedFloat(f2);
			if (sm is ConstructionState constructionState)
			{
				sm.cumulativeUnitProgress = constructionState.parentBuildingState.currentCount + sm.unitProgress;
				sm.cumulativeUnitProgressPrev = sm.cumulativeUnitProgress;
			}
			else
			{
				sm.cumulativeUnitProgress = sm.unitProgress;
				sm.cumulativeUnitProgressPrev = sm.unitProgress;
			}
			if (sm.unitProgress >= 1.0 && sm is ResearchState researchState)
			{
				researchState.isReadyToClaim = true;
			}
		}
		if (dataDict.TryGetValue("mp", out var value4) && value4.TryAsDouble(out var f3))
		{
			sm.manualProgress = GameUtility.AsTruncatedFloat(f3);
		}
		if (dataDict.TryGetValue("RepeatAssign", out var value5))
		{
			int i3;
			if (value5.IsBool)
			{
				sm.localSettings.autoAssign.InitializeValue(OverrideState.On);
			}
			else if (value5.TryAsInt(out i3))
			{
				sm.localSettings.autoAssign.InitializeValue((OverrideState)i3);
			}
		}
		if (dataDict.TryGetValue("AutoClaim", out var value6) && value6.TryAsInt(out var i4))
		{
			sm.localSettings.autoClaim.InitializeValue((OverrideState)i4);
		}
		if (dataDict.TryGetValue("Paused", out var value7))
		{
			int i5;
			if (value7.IsBool)
			{
				sm.localSettings.pause.InitializeValue(OverrideState.On);
			}
			else if (value7.TryAsInt(out i5))
			{
				sm.localSettings.pause.InitializeValue((OverrideState)i5);
			}
		}
		if (sm is ConstructionState constructionState2 && dataDict.ContainsKey("costPaidFlag"))
		{
			constructionState2.isCostAlreadyPaid = true;
		}
		if (sm is SellState sellState && dataDict.ContainsKey("isSpecialty"))
		{
			sellState.isSpecialty = true;
			sellState.parentTown.numSpecialtiesActive++;
			gm.specialtyCache[sellState.itemType] = sellState.parentTown;
		}
		if (sm is TradingState tradingState)
		{
			if (dataDict.TryGetValue("tm", out var value8) && value8.TryAsInt(out var i6))
			{
				tradingState.localSettings.tradingConfig.InitializeValue(ConvertedTradeMode(i6));
			}
			else if (dataDict.ContainsKey("i"))
			{
				tradingState.localSettings.tradingConfig.InitializeValue(TradeMode.Import);
			}
			else
			{
				tradingState.localSettings.tradingConfig.InitializeValue(TradeMode.Export);
			}
			if (dataDict.TryGetValue("tma", out var value9) && value9.TryAsInt(out var i7))
			{
				TradeMode tradeMode = (TradeMode)Mathf.Abs(i7);
				if (tradeMode == TradeMode.None)
				{
					tradeMode = TradeMode.Off;
				}
				tradingState.activeTradeMode = tradeMode;
			}
		}
		if (dataDict.ContainsKey("al"))
		{
			sm.isInAlertState = true;
		}
	}

	private static void LoadProductionConfigFromData(ProductionConfig config, Dictionary<string, fsData> dataDict)
	{
		if (dataDict.TryGetValue("pt", out var value) && value.TryAsInt(out var i))
		{
			config.type = (ProductionLimitType)i;
		}
		else
		{
			config.type = ProductionLimitType.DefaultNone;
		}
		if (dataDict.TryGetValue("tr", out var value2) && value2.TryAsDouble(out var f))
		{
			config.targetRate = (float)f;
		}
		if (dataDict.TryGetValue("tdm", out var value3) && value3.TryAsDouble(out var f2))
		{
			config.targetDemandPercent = (float)f2;
		}
		else if (config.type == ProductionLimitType.MeetDemand)
		{
			config.targetDemandPercent = 1f;
		}
	}

	private static fsData CurrentGameState()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		gm.lastSaveTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		dictionary["ActiveTownIndex"] = new fsData(gm.activeTownIndex);
		dictionary["LastSaveDate"] = new fsData(gm.lastSaveTimestamp);
		dictionary["LastPerkReset"] = new fsData(gm.lastGlobalPerkResetTimestamp);
		dictionary["LastRewardClaim"] = new fsData(gm.lastRewardClaimTimestamp);
		dictionary["WorldCreationTimestamp"] = new fsData(gm.worldCreationTimestamp);
		dictionary["ClickLevel"] = new fsData(gm.clickLevel);
		dictionary["ClickResources"] = new fsData(gm.itemsGainedFromClicking);
		dictionary["IdleTimeCollected"] = new fsData(gm.idleSecondsCollected);
		dictionary["RandomRewardSeed"] = new fsData(gm.randomRewardSeed);
		dictionary["QuestCoins"] = new fsData(gm.questCoinState.currentCount);
		dictionary["TimeTokens"] = new fsData(gm.timeTokenState.currentCount);
		dictionary["RewardBoosts"] = new fsData(gm.numRewardBoosts);
		dictionary["Towns"] = TownListData();
		dictionary["quests"] = GetCompletedQuestData(gm.globalQuests);
		dictionary["inventory"] = GetInventoryData(gm.globalInventory);
		gm.lastSaveVersion = 27;
		dictionary["v"] = new fsData(gm.lastSaveVersion);
		dictionary["hasClaimedReward"] = new fsData(gm.hasClaimedLevelRewards);
		dictionary["gameModifiers"] = GetModifierData();
		dictionary["Menu"] = GetMenuData();
		dictionary["Stats"] = GetGlobalStatData();
		dictionary["perks"] = GetPerksData(gm.globalPerks);
		return new fsData(dictionary);
	}

	private static fsData DataFromSkill(Skill s)
	{
		return new fsData(new List<fsData>
		{
			DataFromEntity(s.skillId),
			new fsData(s.skillValueAccrued)
		});
	}

	private static fsData GetModifierData()
	{
		List<fsData> list = new List<fsData>();
		foreach (GameModifier appliedModifier in gm.appliedModifiers)
		{
			list.Add(new fsData((long)appliedModifier));
		}
		return new fsData(list);
	}

	public static fsData GetPerksData(Dictionary<PerkType, PerkState> source)
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<PerkType, PerkState> item in source)
		{
			if (item.Value.currentCount > 0.0)
			{
				List<fsData> list2 = new List<fsData>
				{
					new fsData((long)item.Key),
					new fsData(item.Value.currentCount)
				};
				list.Add(new fsData(list2));
			}
		}
		return new fsData(list);
	}

	private static fsData TownListData()
	{
		List<fsData> list = new List<fsData>();
		int num = gm.towns.Count - 1;
		for (int i = 0; i < gm.towns.Count; i++)
		{
			if (gm.towns[i] != null)
			{
				num = i;
			}
		}
		for (int j = 0; j <= num; j++)
		{
			Town town = gm.towns[j];
			if (town == null)
			{
				list.Add(fsData.Null);
				continue;
			}
			TownData.targetTown = town;
			fsData item = TownData.ActiveTownData();
			list.Add(item);
			TownData.targetTown = null;
		}
		return new fsData(list);
	}

	public static fsData GetInventoryData(Dictionary<ItemType, ItemState> source)
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<ItemType, ItemState> item in source)
		{
			if (item.Value.currentCount > 0.0)
			{
				list.Add(GetData(item.Value));
			}
		}
		return new fsData(list);
	}

	public static fsData GetSkillsData(Dictionary<SkillType, Dictionary<EntityId, Skill>> source)
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<SkillType, Dictionary<EntityId, Skill>> item2 in source)
		{
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
			SkillType key = item2.Key;
			Dictionary<EntityId, Skill> value = item2.Value;
			List<fsData> list2 = new List<fsData>();
			foreach (KeyValuePair<EntityId, Skill> item3 in value)
			{
				fsData item = DataFromSkill(item3.Value);
				list2.Add(item);
			}
			dictionary["type"] = new fsData((long)key);
			dictionary["value"] = new fsData(list2);
			list.Add(new fsData(dictionary));
		}
		return new fsData(list);
	}

	public static fsData GetCompletedQuestData(Dictionary<QuestType, Quest> source)
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<QuestType, Quest> item in source)
		{
			if (item.Value.availability == BuildObjectAvailability.Completed)
			{
				list.Add(new fsData((long)item.Key));
			}
		}
		return new fsData(list);
	}

	public static void LoadQuestsFromData(fsData data, Dictionary<QuestType, Quest> target)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsInt(out var i))
			{
				continue;
			}
			QuestType key = (QuestType)i;
			if (target.TryGetValue(key, out var value))
			{
				value.availability = BuildObjectAvailability.Completed;
				if (value.rewardItems != null)
				{
					float num = GameUtility.AsFloat(value.rewardItems.Count(ItemType.UtilityQuestCoin));
					questRewardCount += num;
				}
			}
		}
	}

	private static void LoadBuildingsFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsDictionary(out var result2) || !result2.TryGetValue("type", out var value) || !value.TryAsInt(out var i))
			{
				continue;
			}
			BuildingType key = (BuildingType)i;
			if (targetTown.buildings.TryGetValue(key, out var value2))
			{
				TryLoadDouble(result2, "count", ref value2.currentCount);
				_ = targetTown.debug;
				if (result2.ContainsKey("al"))
				{
					value2.constructionState.isInAlertState = true;
				}
				if (result2.TryGetValue("priority", out var value3) && value3.TryAsInt(out var i2))
				{
					value2.settings.priority.InitializeValue((StatePriority)i2);
				}
				LoadProductionConfigFromData(value2.settings.productionLimit, result2);
				if (result2.TryGetValue("RepeatAssign", out var value4) && value4.TryAsInt(out var i3))
				{
					value2.settings.autoAssign.InitializeValue((OverrideState)i3);
				}
				if (result2.TryGetValue("AutoClaim", out var value5) && value5.TryAsInt(out var i4))
				{
					value2.settings.autoClaim.InitializeValue((OverrideState)i4);
				}
				if (result2.TryGetValue("queue", out var value6) && value6.TryAsInt(out var i5))
				{
					value2.pendingConstructions = i5;
					value2.constructionState.isUnitProgressHardCapped = i5 <= 1;
				}
				if (result2.TryGetValue("construction", out var value7) && value7.TryAsDictionary(out var result3))
				{
					LoadStateFromData(value2.constructionState, result3);
				}
				if (result2.ContainsKey("Paused"))
				{
					value2.settings.pause.InitializeValue(OverrideState.On);
				}
			}
		}
	}

	private static void LoadNaturalResourcesFromData(fsData data)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsList(out var result2) || result2.Count < 2)
			{
				continue;
			}
			fsData obj = result2[0];
			fsData fsData2 = result2[1];
			NaturalResource key = (NaturalResource)obj.AsInt64;
			float num = (float)fsData2.AsDouble;
			if (targetTown.naturalResources.TryGetValue(key, out var value))
			{
				value.currentCount = num;
				if (result2.Count >= 3)
				{
					fsData data2 = result2[2];
					value.isInAlertState = data2.TryAsBool(out var b) && b;
				}
				if (result2.Count >= 4 && result2[3].TryAsDouble(out var f))
				{
					value.bonusCapacityToApply = f;
				}
				if (result2.Count >= 5 && result2[4].TryAsDouble(out var f2))
				{
					value.maxConsumePerSecond = f2;
				}
			}
		}
	}

	private static void LoadTownMinimizationFromData(fsData data)
	{
		if (!data.TryAsDictionary(out var result))
		{
			return;
		}
		foreach (KeyValuePair<string, fsData> item in result)
		{
			if (!int.TryParse(item.Key, out var result2))
			{
				continue;
			}
			BuildingCategory category = (BuildingCategory)result2;
			HeaderCollapseManager headerCollapseManager = targetTown.ConfirmedCollapseManager(category);
			if (!item.Value.TryAsList(out var result3))
			{
				continue;
			}
			foreach (fsData item2 in result3)
			{
				if (item2.TryAsInt(out var i))
				{
					headerCollapseManager.SetMinimized(i);
				}
			}
		}
	}

	private static void LoadTownStatsFromData(fsData data)
	{
		if (!data.TryAsDictionary(out var result))
		{
			return;
		}
		TryLoadIntProperty(result, "TownLevel", targetTown.townLevelCache);
		TryLoadInt(result, "TownResets", ref targetTown.numTownResets);
		TryLoadLong(result, "LastPerkReset", ref targetTown.lastTownPerkResetTimestamp);
		TryLoadDouble(result, "TownResetXP", ref targetTown.sacrificedXP);
		TryLoadDouble(result, "TownSpentXP", ref targetTown.spentXP);
		TryLoadInt(result, "RewardLevel", ref targetTown.lastClaimedRewardLevel);
		TryLoadPriority(result, "constructionPriority", targetTown.constructionSettings.priority);
		if (result.ContainsKey("constructionPause"))
		{
			targetTown.constructionSettings.pause.InitializeValue(OverrideState.On);
		}
		TryLoadLong(result, "LastSaveDate", ref gm.lastSaveTimestamp);
		if (result.ContainsKey("autoAssignHarvesting"))
		{
			targetTown.buildings[BuildingType.HarvesterHut].settings.autoAssign.InitializeValue(OverrideState.On);
		}
		if (result.TryGetValue("ts", out var value) && value.TryAsInt(out var i))
		{
			targetTown.specialty = (Specialty)i;
		}
		if (result.TryGetValue("WorldBiome", out var value2) && value2.TryAsInt(out var i2))
		{
			targetTown.biomeType = (BiomeType)i2;
			if (targetTown.biomeType == BiomeType.None)
			{
				targetTown.biomeType = BiomeType.Plains;
			}
		}
		else
		{
			targetTown.biomeType = GameManager.DefaultBiomeForIndex(targetTownIndex);
		}
		if (result.TryGetValue("TownPrestigePoints", out var value3) && value3.TryAsDouble(out var f))
		{
			targetTown.townPerkPointState.currentCount = (float)f;
		}
		if (result.TryGetValue("bpp", out var value4) && value4.TryAsDouble(out var f2))
		{
			targetTown.bonusPrestigePoints = f2;
		}
		if (result.TryGetValue("bl", out var value5) && value5.TryAsDouble(out var f3))
		{
			targetTown.bonusLand = f3;
		}
		if (result.TryGetValue("bw", out var value6) && value6.TryAsDouble(out var f4))
		{
			targetTown.bonusWorkers = f4;
		}
		if (targetTown.townLevel > 0)
		{
			targetTown.spentXP = 0.0;
			for (int j = 0; j < targetTown.townLevel; j++)
			{
				double num = GameManager.ExperienceCostForProgressingFromLevel(j);
				targetTown.spentXP += num;
			}
		}
		if (targetTown.sacrificedXP > 0.0)
		{
			targetTown.PostProcessTownLevel();
		}
		LoadItemStatDictionary(result, "ItemProductionCounts", targetTown.itemProductionStats);
		LoadBuildingStatDictionary(result, "MarketSellCounts", targetTown.marketSellCounts);
		LoadItemStatDictionary(result, "CoinSpendCounts", targetTown.coinSpendCounts);
	}

	private static void LoadGlobalStatsFromDict(Dictionary<string, fsData> statsDict)
	{
		LoadItemStatDictionary(statsDict, "ItemProductionCounts", gm.globalProductionStats);
	}

	private static void LoadInventoryFromData(fsData data, Dictionary<ItemType, ItemState> target)
	{
		if (!data.TryAsList(out var result))
		{
			return;
		}
		foreach (fsData item in result)
		{
			if (!item.TryAsList(out var result2) || result2.Count < 2)
			{
				continue;
			}
			fsData obj = result2[0];
			fsData fsData2 = result2[1];
			ItemType key = (ItemType)obj.AsInt64;
			double asDouble = fsData2.AsDouble;
			if (target.TryGetValue(key, out var value))
			{
				value.currentCount = asDouble;
				int count = result2.Count;
				if (count >= 3 && result2[2].TryAsDouble(out var f))
				{
					value.bonusCapacityToApply = f;
				}
				if (count >= 4 && result2[3].TryAsDouble(out var f2))
				{
					value.maxConsumePerSecond = f2;
				}
				if (count >= 5 && result2[4].TryAsDouble(out var f3))
				{
					value.lastFrameDemand = f3;
				}
				if (count >= 6 && result2[5].TryAsDouble(out var f4))
				{
					value.lastFrameSurplus = f4;
				}
			}
		}
	}

	private static void TryLoadDouble(Dictionary<string, fsData> dictionary, string key, ref double targetDouble)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsDouble(out var f))
		{
			targetDouble = f;
		}
	}

	private static void TryLoadFloat(Dictionary<string, fsData> dictionary, string key, ref float targetFloat)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsDouble(out var f))
		{
			targetFloat = (float)f;
		}
	}

	private static void TryLoadPriority(Dictionary<string, fsData> dictionary, string key, PropertyItem<StatePriority> targetPriority)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsInt(out var i))
		{
			targetPriority.InitializeValue((StatePriority)i);
		}
	}

	public static void LoadBool(Dictionary<string, fsData> dictionary, string key, out bool result)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsBool(out var b))
		{
			result = b;
		}
		else
		{
			result = false;
		}
	}

	public static void TryLoadIntOut(Dictionary<string, fsData> dictionary, string key, out int targetInt)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsInt(out var i))
		{
			targetInt = i;
		}
		else
		{
			targetInt = 0;
		}
	}

	public static void TryLoadFloatOut(Dictionary<string, fsData> dictionary, string key, out float targetFloat)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsDouble(out var f))
		{
			targetFloat = (float)f;
		}
		else
		{
			targetFloat = 0f;
		}
	}

	public static void TryLoadDoubleOut(Dictionary<string, fsData> dictionary, string key, out double targetDouble)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsDouble(out var f))
		{
			targetDouble = f;
		}
		else
		{
			targetDouble = 0.0;
		}
	}

	public static void TryLoadBool(fsData data, ref bool target)
	{
		if (data.TryAsBool(out var b))
		{
			target = b;
		}
	}

	public static void TryLoadInt(fsData data, ref int targetInt)
	{
		if (data.TryAsInt(out var i))
		{
			targetInt = i;
		}
	}

	public static void TryLoadBool(Dictionary<string, fsData> dictionary, string key, ref bool targetBool)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsBool(out var b))
		{
			targetBool = b;
		}
	}

	public static void TryLoadInt(Dictionary<string, fsData> dictionary, string key, ref int targetInt)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsInt(out var i))
		{
			targetInt = i;
		}
	}

	public static void TryLoadIntProperty(Dictionary<string, fsData> dictionary, string key, IntProperty targetInt)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsInt(out var i))
		{
			targetInt.value = i;
		}
	}

	public static void TryLoadLong(Dictionary<string, fsData> dictionary, string key, ref long targetLong)
	{
		if (dictionary.TryGetValue(key, out var value) && value.TryAsLong(out var i))
		{
			targetLong = i;
		}
	}

	public static EntityId EntityFromData(fsData data)
	{
		if (data.TryAsList(out var result) && result.Count >= 2 && result[0].TryAsInt(out var i) && result[1].TryAsInt(out var i2))
		{
			return new EntityId(i2, (EntityType)i);
		}
		return EntityId.None;
	}

	public static fsData DataFromEntity(EntityId id)
	{
		return new fsData(new List<fsData>
		{
			new fsData((long)id.type),
			new fsData(id.intId)
		});
	}

	public static fsData DataFromCoord(Coord c)
	{
		return new fsData(new List<fsData>
		{
			new fsData(c.x),
			new fsData(c.y)
		});
	}

	public static Coord CoordFromData(fsData data)
	{
		if (data.TryAsList(out var result) && result.Count >= 2)
		{
			return new Coord((int)result[0].AsInt64, (int)result[1].AsInt64);
		}
		return Coord.Zero;
	}

	private static fsData GetMenuData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		List<int> list = new List<int>();
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in MenuManager.Instance.menuPanels)
		{
			MenuPanel value = menuPanel.Value;
			string layoutPrefKey = value.layoutPrefKey;
			Dictionary<string, fsData> dictionary2 = new Dictionary<string, fsData>();
			if (value.IsVisible())
			{
				dictionary2["IsVisible"] = fsData.True;
			}
			if (value.alertStateSelf)
			{
				dictionary2["al"] = fsData.True;
			}
			if (value is MenuListPanel { headerCollapseManager: not null } menuListPanel)
			{
				list.Clear();
				menuListPanel.headerCollapseManager.LoadMinimizedHeaders(list);
				if (list.Count > 0)
				{
					List<fsData> list2 = new List<fsData>();
					foreach (int item in list)
					{
						list2.Add(new fsData(item));
					}
					dictionary2["Minimized"] = new fsData(list2);
				}
			}
			if (value is InventoryPanel { columnMode: >0 } inventoryPanel)
			{
				dictionary2["NumColumns"] = new fsData(inventoryPanel.columnMode);
			}
			if (value is InventoryPanel { isMinimized: not false })
			{
				dictionary2["SelfMinimized"] = fsData.True;
			}
			else if (value is QuestsPanel { isMinimized: not false })
			{
				dictionary2["SelfMinimized"] = fsData.True;
			}
			dictionary2["Rect"] = new fsData(value.GetLayoutString());
			dictionary[layoutPrefKey] = new fsData(dictionary2);
		}
		BuildingCategory categoryFilter = MenuManager.Instance.combinedProductionPanel.categoryFilter;
		if (categoryFilter != BuildingCategory.None)
		{
			dictionary["Filter"] = new fsData((long)categoryFilter);
		}
		return new fsData(dictionary);
	}

	public static fsData GetCompletedUpgradeData(Dictionary<UpgradeType, Upgrade> source)
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<UpgradeType, Upgrade> item in source)
		{
			if (item.Value.numCompleted >= 1)
			{
				List<fsData> list2 = new List<fsData>
				{
					new fsData((long)item.Key),
					new fsData(item.Value.numCompleted)
				};
				list.Add(new fsData(list2));
			}
		}
		return new fsData(list);
	}

	private static fsData GetData(ItemState s)
	{
		List<fsData> list = new List<fsData>();
		list.Add(new fsData((long)s.type));
		list.Add(new fsData(s.currentCount));
		list.Add(new fsData(s.bonusCapacityToApply));
		list.Add(new fsData(s.maxConsumePerSecond));
		if (s.shouldSaveDemandData)
		{
			list.Add(new fsData(s.lastFrameDemand));
		}
		else
		{
			list.Add(fsDataPlaceholder);
		}
		if (true)
		{
			list.Add(new fsData(s.lastFrameSurplus));
		}
		else
		{
			list.Add(fsDataPlaceholder);
		}
		return new fsData(list);
	}
}
