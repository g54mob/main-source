using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

public class TownData : MonoBehaviour
{
	public static Town targetTown;

	private static GameManager gm => GameManager.Instance;

	public static fsData ActiveTownData()
	{
		return new fsData(new Dictionary<string, fsData>
		{
			["inventory"] = SaveFile.GetInventoryData(targetTown.inventory),
			["naturalResources"] = GetNaturalResourceData(targetTown),
			["buildings"] = GetBuildingData(),
			["Harvesting"] = GetHarvestingData(),
			["Farming"] = GetFarmingData(),
			["Mining"] = GetMiningData(),
			["Trading"] = GetTradingData(),
			["TradingConfig"] = GetTradingConfigData(),
			["Crafting"] = GetCraftingData(),
			["Research"] = GetResearchData(),
			["Market"] = GetMarketData(),
			["completedUpgrades"] = SaveFile.GetCompletedUpgradeData(targetTown.upgrades),
			["completedResearch"] = GetCompletedResearchData(),
			["Skills"] = SaveFile.GetSkillsData(targetTown.townSkills),
			["localPerks"] = SaveFile.GetPerksData(targetTown.townPerks),
			["Stats"] = GetTownStatsData(),
			["Minimized"] = GetTownMenuData(),
			["name"] = new fsData(targetTown.townName)
		});
	}

	private static fsData GetHarvestingData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<HarvestRecipeType, HarvestState> item in targetTown.harvesting)
		{
			list.Add(GetDataFromState(item.Value));
		}
		return new fsData(list);
	}

	private static fsData GetTownMenuData()
	{
		List<int> list = new List<int>();
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		foreach (KeyValuePair<BuildingCategory, HeaderCollapseManager> categoryCollapseManager in targetTown.categoryCollapseManagers)
		{
			list.Clear();
			categoryCollapseManager.Value.LoadMinimizedHeaders(list);
			if (list.Count <= 0)
			{
				continue;
			}
			List<fsData> list2 = new List<fsData>();
			foreach (int item in list)
			{
				list2.Add(new fsData(item));
			}
			string key = ((int)categoryCollapseManager.Key).ToString();
			dictionary[key] = new fsData(list2);
		}
		return new fsData(dictionary);
	}

	private static fsData GetTownStatsData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		dictionary["TownLevel"] = new fsData(targetTown.townLevel);
		dictionary["RewardLevel"] = new fsData(targetTown.lastClaimedRewardLevel);
		dictionary["TownResets"] = new fsData(targetTown.numTownResets);
		dictionary["LastPerkReset"] = new fsData(targetTown.lastTownPerkResetTimestamp);
		dictionary["TownPrestigePoints"] = new fsData(targetTown.townPerkPointState.currentCount);
		if (targetTown.bonusPrestigePoints > 0.0)
		{
			dictionary["bpp"] = new fsData(targetTown.bonusPrestigePoints);
		}
		if (targetTown.bonusLand > 0.0)
		{
			dictionary["bl"] = new fsData(targetTown.bonusLand);
		}
		if (targetTown.bonusWorkers > 0.0)
		{
			dictionary["bw"] = new fsData(targetTown.bonusWorkers);
		}
		dictionary["TownResetXP"] = new fsData(targetTown.sacrificedXP);
		dictionary["TownSpentXP"] = new fsData(targetTown.spentXP);
		dictionary["WorldBiome"] = new fsData((long)targetTown.biomeType);
		dictionary["ts"] = new fsData((long)targetTown.specialty);
		if (targetTown.constructionSettings.priority.value != StatePriority.None)
		{
			dictionary["constructionPriority"] = new fsData((long)targetTown.constructionSettings.priority.value);
		}
		if (targetTown.constructionSettings.pause.value == OverrideState.On)
		{
			dictionary["constructionPause"] = fsData.True;
		}
		if (targetTown.workerState.settings.autoAssign.value == OverrideState.On)
		{
			dictionary["autoAssignHarvesting"] = fsData.True;
		}
		SaveFile.StoreStatDictionary(dictionary, "MarketSellCounts", targetTown.marketSellCounts);
		SaveFile.StoreStatDictionary(dictionary, "ItemProductionCounts", targetTown.itemProductionStats);
		SaveFile.StoreStatDictionary(dictionary, "CoinSpendCounts", targetTown.coinSpendCounts);
		return new fsData(dictionary);
	}

	private static fsData GetFarmingData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<NaturalResource, FarmingState> farmingItem in targetTown.farmingItems)
		{
			list.Add(GetDataFromState(farmingItem.Value));
		}
		return new fsData(list);
	}

	private static fsData GetTradingConfigData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<Specialty, TradeSpecialtyConfig> tradeSpecialtyConfig in targetTown.tradeSpecialtyConfigs)
		{
			TradeSpecialtyConfig value = tradeSpecialtyConfig.Value;
			list.Add(new fsData((long)tradeSpecialtyConfig.Key));
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
			if (value.priority.value != StatePriority.None)
			{
				dictionary["priority"] = new fsData((long)value.priority.value);
			}
			if (value.pause.value != OverrideState.None)
			{
				dictionary["Paused"] = new fsData((long)value.pause.value);
			}
			if (value.autoAssign.value != OverrideState.None)
			{
				dictionary["RepeatAssign"] = new fsData((long)value.autoAssign.value);
			}
			if (value.autoClaim.value != OverrideState.None)
			{
				dictionary["AutoClaim"] = new fsData((long)value.autoClaim.value);
			}
			GetDataFromProductionConfig(value.productionLimit, dictionary);
			if (value.tradingConfig.value != TradeMode.None)
			{
				dictionary["tm"] = new fsData((long)value.tradingConfig.value);
			}
			list.Add(new fsData(dictionary));
		}
		return new fsData(list);
	}

	private static fsData GetTradingData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<ItemType, TradingState> item in targetTown.trading)
		{
			list.Add(GetDataFromState(item.Value));
		}
		return new fsData(list);
	}

	private static fsData GetMiningData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<NaturalResource, MiningState> miningItem in targetTown.miningItems)
		{
			list.Add(GetDataFromState(miningItem.Value));
		}
		return new fsData(list);
	}

	private static fsData GetCraftingData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<RecipeType, RecipeState> recipe in targetTown.recipes)
		{
			if (!recipe.Value.isLocked)
			{
				list.Add(GetDataFromState(recipe.Value));
			}
		}
		return new fsData(list);
	}

	private static fsData GetResearchData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<ResearchType, ResearchState> item in targetTown.research)
		{
			fsData dataFromState = GetDataFromState(item.Value);
			if (null != dataFromState)
			{
				list.Add(dataFromState);
			}
		}
		return new fsData(list);
	}

	private static fsData GetMarketData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<ItemType, SellState> marketItem in targetTown.marketItems)
		{
			list.Add(GetDataFromState(marketItem.Value));
		}
		return new fsData(list);
	}

	private static fsData GetDataFromState(StateManager sm)
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		dictionary["w"] = new fsData(Mathf.RoundToInt(sm.numWorkersAssigned));
		if (sm is ConstructionState || sm is ResearchState)
		{
			dictionary["pr"] = new fsData(sm.unitProgress);
		}
		if (sm.localSettings.priority.value != StatePriority.None)
		{
			dictionary["priority"] = new fsData((long)sm.localSettings.priority.value);
		}
		if (sm.isInAlertState)
		{
			dictionary["al"] = fsData.True;
		}
		if (sm.localAutoAssign != OverrideState.None)
		{
			dictionary["RepeatAssign"] = new fsData((long)sm.localAutoAssign);
		}
		if (sm.localAutoClaim != OverrideState.None)
		{
			dictionary["AutoClaim"] = new fsData((long)sm.localAutoClaim);
		}
		if (sm.localSettings.pause.value != OverrideState.None)
		{
			dictionary["Paused"] = new fsData((long)sm.localSettings.pause.value);
		}
		if (sm.manualProgress > 0f)
		{
			dictionary["mp"] = new fsData(sm.manualProgress);
		}
		GetDataFromProductionConfig(sm.localSettings.productionLimit, dictionary);
		if (sm is FarmingState farmingState)
		{
			dictionary["type"] = new fsData((long)farmingState.resource.type);
		}
		else if (sm is RecipeState recipeState)
		{
			dictionary["type"] = new fsData((long)recipeState.type);
		}
		else if (sm is HarvestState harvestState)
		{
			dictionary["type"] = new fsData((long)harvestState.type);
		}
		else if (sm is SellState sellState)
		{
			dictionary["type"] = new fsData((long)sellState.itemType);
			if (sellState.isSpecialty)
			{
				dictionary["isSpecialty"] = fsData.True;
			}
		}
		else if (sm is TradingState tradingState)
		{
			dictionary["type"] = new fsData((long)tradingState.itemType);
			dictionary["tm"] = new fsData((long)tradingState.localTradeMode);
			if (tradingState.appliedTradeMode == TradeMode.AutoTradeLocalBalance || tradingState.appliedTradeMode == TradeMode.AutoTradeGlobalBalance || tradingState.appliedTradeMode == TradeMode.AutoTradeLocalFill || tradingState.appliedTradeMode == TradeMode.AutoTradeGlobalFill)
			{
				int activeTradeMode = (int)tradingState.activeTradeMode;
				dictionary["tma"] = new fsData(activeTradeMode);
			}
		}
		else if (sm is ResearchState researchState)
		{
			dictionary["type"] = new fsData((long)researchState.type);
		}
		else if (sm is MiningState miningState)
		{
			dictionary["type"] = new fsData((long)miningState.resource.type);
		}
		else if (sm is ConstructionState { isCostAlreadyPaid: not false })
		{
			dictionary["costPaidFlag"] = fsData.True;
		}
		return new fsData(dictionary);
	}

	private static fsData GetCompletedResearchData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<ResearchType, ResearchState> item in targetTown.research)
		{
			ResearchState value = item.Value;
			if (value.numCompleted >= 1)
			{
				List<fsData> list2 = new List<fsData>
				{
					new fsData((long)item.Key),
					new fsData(value.numCompleted),
					new fsData(item.Key.ToString())
				};
				list.Add(new fsData(list2));
			}
		}
		return new fsData(list);
	}

	private static fsData GetBuildingData()
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<BuildingType, BuildingState> building in targetTown.buildings)
		{
			if (building.Value.availability == BuildObjectAvailability.Available)
			{
				list.Add(GetDataFromBuilding(building.Value));
			}
		}
		return new fsData(list);
	}

	private static fsData GetNaturalResourceData(Town t)
	{
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<NaturalResource, ResourceState> naturalResource in t.naturalResources)
		{
			if (naturalResource.Value.currentCount > 0.0 || naturalResource.Value.isInAlertState)
			{
				list.Add(GetDataFromResource(naturalResource.Value));
			}
		}
		return new fsData(list);
	}

	private static fsData GetDataFromResource(ResourceState s)
	{
		List<fsData> list = new List<fsData>();
		list.Add(new fsData((long)s.type));
		list.Add(new fsData(s.currentCount));
		if (s.isInAlertState)
		{
			list.Add(fsData.True);
		}
		else
		{
			list.Add(fsData.False);
		}
		list.Add(new fsData(s.bonusCapacityToApply));
		list.Add(new fsData(s.maxConsumePerSecond));
		return new fsData(list);
	}

	private static fsData GetDataFromBuilding(BuildingState s)
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		dictionary["type"] = new fsData((long)s.type);
		dictionary["count"] = new fsData(s.currentCount);
		if (s.constructionState.isInAlertState)
		{
			dictionary["al"] = fsData.True;
		}
		if (s.settings.pause.value == OverrideState.On)
		{
			dictionary["Paused"] = fsData.True;
		}
		if (s.pendingConstructions > 0)
		{
			dictionary["queue"] = new fsData(s.pendingConstructions);
		}
		GetDataFromProductionConfig(s.settings.productionLimit, dictionary);
		if (s.settings.craftingGroupPriority != StatePriority.None)
		{
			dictionary["priority"] = new fsData((long)s.settings.craftingGroupPriority);
		}
		if (s.settings.autoAssign.value != OverrideState.None)
		{
			dictionary["RepeatAssign"] = new fsData((long)s.settings.autoAssign.value);
		}
		if (s.settings.autoClaim.value != OverrideState.None)
		{
			dictionary["AutoClaim"] = new fsData((long)s.settings.autoClaim.value);
		}
		ConstructionState constructionState = s.constructionState;
		if (constructionState.numWorkersAssigned > 0f || constructionState.localSettings.HasValues() || constructionState.isInAlertState || constructionState.localAutoAssign != OverrideState.None || constructionState.isCostAlreadyPaid || constructionState.unitProgress > 0.0)
		{
			dictionary["construction"] = GetDataFromState(s.constructionState);
		}
		return new fsData(dictionary);
	}

	private static void GetDataFromProductionConfig(ProductionConfig config, Dictionary<string, fsData> dict)
	{
		if (config.type != ProductionLimitType.DefaultNone)
		{
			dict["pt"] = new fsData((long)config.type);
		}
		if (GameUtility.IsNotZero(config.targetRate))
		{
			dict["tr"] = new fsData(config.targetRate);
		}
		if (GameUtility.IsNotZero(config.targetDemandPercent))
		{
			dict["tdm"] = new fsData(config.targetDemandPercent);
		}
	}
}
