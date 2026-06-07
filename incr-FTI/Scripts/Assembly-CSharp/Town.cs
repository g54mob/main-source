using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class Town
{
	public readonly Dictionary<RecipeType, RecipeState> recipes = new Dictionary<RecipeType, RecipeState>(new RecipeEqualityComparer());

	[NonSerialized]
	public ConsumableState[] consumableStates;

	[NonSerialized]
	public ItemState[] inventoryCache;

	[NonSerialized]
	public ResourceState[] naturalResourceCache;

	[NonSerialized]
	public RecipeState[] recipeCache;

	public readonly Dictionary<ItemType, ItemState> inventory = new Dictionary<ItemType, ItemState>(new ItemEqualityComparer());

	public readonly Dictionary<NaturalResource, ResourceState> naturalResources = new Dictionary<NaturalResource, ResourceState>(new NaturalResourceEqualityComparer());

	private readonly Dictionary<BuildingType, PassiveStateModifier> passiveIncome = new Dictionary<BuildingType, PassiveStateModifier>(new BuildingEqualityComparer());

	private readonly Dictionary<NaturalResource, PassiveStateModifier> passiveResourceRegen = new Dictionary<NaturalResource, PassiveStateModifier>(new NaturalResourceEqualityComparer());

	private readonly List<PassiveStateModifier> passiveResourceRegenList = new List<PassiveStateModifier>();

	private int passiveRegenListCount;

	public readonly Dictionary<BuildingType, BuildingState> buildings = new Dictionary<BuildingType, BuildingState>(new BuildingEqualityComparer());

	public readonly Dictionary<ItemType, SellState> marketItems = new Dictionary<ItemType, SellState>(new ItemEqualityComparer());

	public readonly Dictionary<NaturalResource, FarmingState> farmingItems = new Dictionary<NaturalResource, FarmingState>(new NaturalResourceEqualityComparer());

	public readonly Dictionary<NaturalResource, MiningState> miningItems = new Dictionary<NaturalResource, MiningState>(new NaturalResourceEqualityComparer());

	public readonly Dictionary<ResearchType, ResearchState> research = new Dictionary<ResearchType, ResearchState>(new ResearchEqualityComparer());

	public readonly Dictionary<HarvestRecipeType, HarvestState> harvesting = new Dictionary<HarvestRecipeType, HarvestState>(new HarvestRecipeEqualityComparer());

	public readonly Dictionary<UpgradeType, Upgrade> upgrades = new Dictionary<UpgradeType, Upgrade>(new UpgradeEqualityComparer());

	public readonly Dictionary<SkillType, Dictionary<EntityId, Skill>> townSkills = new Dictionary<SkillType, Dictionary<EntityId, Skill>>(new SkillTypeComparer());

	public readonly Dictionary<BuildingType, List<Skill>> skillsPerBuilding = new Dictionary<BuildingType, List<Skill>>(new BuildingEqualityComparer());

	public readonly Dictionary<Specialty, TradeSpecialtyConfig> tradeSpecialtyConfigs = new Dictionary<Specialty, TradeSpecialtyConfig>(new SpecialtyEqualityComparer());

	public readonly Dictionary<BuildingCategory, HeaderCollapseManager> categoryCollapseManagers = new Dictionary<BuildingCategory, HeaderCollapseManager>();

	public readonly Dictionary<ItemType, FloatProperty> itemProductionStats = new Dictionary<ItemType, FloatProperty>(new ItemEqualityComparer());

	public readonly Dictionary<BuildingType, FloatProperty> marketSellCounts = new Dictionary<BuildingType, FloatProperty>(new BuildingEqualityComparer());

	public readonly Dictionary<ItemType, FloatProperty> coinSpendCounts = new Dictionary<ItemType, FloatProperty>(new ItemEqualityComparer());

	public readonly Dictionary<RequirementId, Requirement> townRequirementCache = new Dictionary<RequirementId, Requirement>();

	public readonly Dictionary<SkillType, FloatProperty> townSkillStats = new Dictionary<SkillType, FloatProperty>(new SkillTypeComparer());

	public readonly List<Skill> allTownSkillList = new List<Skill>();

	public readonly IntProperty completedResearchStat = new IntProperty();

	[NonSerialized]
	public readonly List<LogEntry> logEntries = new List<LogEntry>(100);

	[NonSerialized]
	public readonly List<int> newLogs = new List<int>(100);

	public readonly List<StateManager> activeStateManagers = new List<StateManager>(100);

	public readonly List<StateManager> availableStateManagers = new List<StateManager>(100);

	public readonly List<StateManager> potentialStateManagers = new List<StateManager>(100);

	public readonly List<StateManager> highestPriorityStateManagers = new List<StateManager>(100);

	public readonly List<StateManager> highPriorityStateManagers = new List<StateManager>(100);

	public readonly List<StateManager> medPriorityStateManagers = new List<StateManager>(100);

	public readonly List<StateManager> lowPriorityStateManagers = new List<StateManager>(100);

	public readonly List<StateManager> lowestPriorityStateManagers = new List<StateManager>(100);

	public readonly List<StateManager> highestPriorityAutoAssign = new List<StateManager>(100);

	public readonly List<StateManager> highPriorityAutoAssign = new List<StateManager>(100);

	public readonly List<StateManager> medPriorityAutoAssign = new List<StateManager>(100);

	public readonly List<StateManager> lowPriorityAutoAssign = new List<StateManager>(100);

	public readonly List<StateManager> lowestPriorityAutoAssign = new List<StateManager>(100);

	public readonly Dictionary<ItemType, TradingState> trading = new Dictionary<ItemType, TradingState>(new ItemEqualityComparer());

	public readonly Dictionary<PerkType, PerkState> townPerks = new Dictionary<PerkType, PerkState>(new PerkEqualityComparer());

	public long lastTownPerkResetTimestamp;

	[NonSerialized]
	public float happinessAverage;

	[NonSerialized]
	public float happinessMax;

	[NonSerialized]
	public int fulfillmentScore;

	[NonSerialized]
	public int fulfillmentTier;

	[NonSerialized]
	public double housingPlots;

	[NonSerialized]
	public double unusedHousingPlots;

	[NonSerialized]
	public float totalBuildings;

	[NonSerialized]
	public bool hasTownPerkAvailable;

	[NonSerialized]
	public bool hasUpgradeToClaim;

	[NonSerialized]
	public bool hasResearchToClaim;

	[NonSerialized]
	public int numSpecialtiesActive;

	[NonSerialized]
	public int maxNumSpecialties;

	public Specialty specialty;

	public int townIndex;

	public BiomeType biomeType;

	public bool debug;

	[NonSerialized]
	public string townName;

	public IntProperty townLevelCache = new IntProperty();

	public PropertyItem<float> cachedLevelProgress;

	public PropertyItem<double> xpCountCache;

	public int pendingPrestigeCoins;

	public int numTownResets;

	public double sacrificedXP;

	public double spentXP;

	public float happinessMultiplier;

	public float numWorkersAssignedToBuildings;

	public float storageBoostMultiplier;

	private float numPrestigePointsAssigned;

	[NonSerialized]
	public float biomeLandMultiplier;

	public bool isCapitalCity;

	[NonSerialized]
	public float maxHappinessLevelReached;

	[NonSerialized]
	public float cachedTotalUpgradeLevels;

	[NonSerialized]
	public double numHouses;

	[NonSerialized]
	public double levelUpCost;

	[NonSerialized]
	public double prestigeLevelUpCost;

	[NonSerialized]
	public double prestigePrevLevelCost;

	private bool isRunningStateManagerLoop;

	public WorkerState workerState;

	public CountableState townPerkPointState;

	public CountableState landState;

	public CountableState cachedHouseState;

	public ItemState cachedTownXPState;

	public readonly Dictionary<BuildingState, BuildingRateData> combinedBuildingProductionData = new Dictionary<BuildingState, BuildingRateData>();

	public readonly Dictionary<BuildingState, BuildingRateData> combinedBuildingConsumptionData = new Dictionary<BuildingState, BuildingRateData>();

	private readonly List<StateManager> deactivationQueue = new List<StateManager>();

	private readonly List<BuildingType> completedBuildingQueue = new List<BuildingType>();

	public int metadataFlags;

	public const int metadataFlagBiomeEffect = 1;

	public const int metadataFlagResearchCost = 2;

	public const int metadataFlagLandCapacity = 4;

	public const int metadataFlagBuildingCosts = 8;

	public const int metadataFlagResourceCapacity = 16;

	public const int metadataFlagWorkerData = 32;

	public const int metadataFlagHousingPlotData = 64;

	public const int metadataFlagPopulationData = 128;

	public const int metadataFlagMarketDemand = 256;

	public const int metadataFlagItemCapacity = 512;

	public const int metadataFlagObsoleteRecipes = 1024;

	public const int metadataFlagActiveStateManagers = 2048;

	public const int metadataFlagPriorities = 4096;

	public const int metadataFlagPause = 8192;

	public const int metadataFlagTradingSpeed = 16384;

	public const int metadataFlagInitial = 32768;

	public const int metadataFlagGenericStateAvailability = 65536;

	public const int metadataFlagGenericStateSpeed = 131072;

	public const int metadataFlagPassiveIncome = 262144;

	public const int metadataFlagAutoAssign = 524288;

	public const int metadataFlagProductionCapacity = 1048576;

	public const int metadataFlagSellSpeedAndValues = 2097152;

	public const int metadataFlagBuildingCapacity = 4194304;

	public const int metadataFlagClaimFlags = 8388608;

	public const int maxMetaDataFlag = 23;

	public const int metadataFlagXPValue = 2228224;

	public readonly List<BuildingState> numWorkersChangedMetadataQueue = new List<BuildingState>(10);

	public bool suppressUnlockNotifications;

	public readonly AssignableState constructionSettings = new AssignableState();

	public double bonusPrestigePoints;

	public double bonusLand;

	public double bonusWorkers;

	private int optimalWorkerCountdown;

	public bool isTownPerkValidityStale;

	public int lastClaimedRewardLevel;

	private int townInitValue;

	private static MenuManager menu => MenuManager.Instance;

	private static GameManager gm => GameManager.Instance;

	public double population => workerState.currentCount;

	public int townLevel => townLevelCache.value;

	public bool hasRewardToClaim => lastClaimedRewardLevel < townLevelCache.value;

	public double cumulativeXP => spentXP + cachedTownXPState.currentCount;

	public Town(BiomeType biome, int index)
	{
		biomeType = biome;
		townIndex = index;
		Init();
		xpCountCache = gm.biomeXPCounters[biome];
		cachedLevelProgress = gm.biomeLevels[biome];
		InitializeGameStates();
		ResetTownState();
	}

	public void Init()
	{
		townInitValue = 0;
	}

	public void CalcStateManagers()
	{
		ClearMetadataFlag(2048);
		SetMetadataFlag(4096);
		activeStateManagers.Clear();
		availableStateManagers.Clear();
		foreach (TradingState value in trading.Values)
		{
			if (value.numWorkersAssigned > 0f)
			{
				activeStateManagers.Add(value);
				availableStateManagers.Add(value);
			}
			else if (!value.isLocked)
			{
				availableStateManagers.Add(value);
			}
		}
		foreach (FarmingState value2 in farmingItems.Values)
		{
			if (value2.numWorkersAssigned > 0f)
			{
				activeStateManagers.Add(value2);
				availableStateManagers.Add(value2);
			}
			else if (!value2.isLocked)
			{
				availableStateManagers.Add(value2);
			}
		}
		foreach (MiningState value3 in miningItems.Values)
		{
			if (value3.numWorkersAssigned > 0f)
			{
				activeStateManagers.Add(value3);
				availableStateManagers.Add(value3);
			}
			else if (!value3.isLocked)
			{
				availableStateManagers.Add(value3);
			}
		}
		foreach (HarvestState value4 in harvesting.Values)
		{
			if (value4.numWorkersAssigned > 0f)
			{
				activeStateManagers.Add(value4);
				availableStateManagers.Add(value4);
			}
			else if (!value4.isLocked)
			{
				availableStateManagers.Add(value4);
			}
		}
		for (int i = 0; i < recipeCache.Length; i++)
		{
			RecipeState recipeState = recipeCache[i];
			if (recipeState.numWorkersAssigned > 0f)
			{
				activeStateManagers.Add(recipeState);
				availableStateManagers.Add(recipeState);
			}
			else if (!recipeState.isLocked)
			{
				availableStateManagers.Add(recipeState);
			}
		}
		foreach (BuildingState value5 in buildings.Values)
		{
			if (value5.constructionState.numWorkersAssigned > 0f)
			{
				activeStateManagers.Add(value5.constructionState);
				availableStateManagers.Add(value5.constructionState);
			}
			else if (value5.availability == BuildObjectAvailability.Available)
			{
				availableStateManagers.Add(value5.constructionState);
			}
		}
		foreach (ResearchState value6 in research.Values)
		{
			if (value6.numWorkersAssigned > 0f)
			{
				activeStateManagers.Add(value6);
				availableStateManagers.Add(value6);
			}
			else if (value6.availability == BuildObjectAvailability.Available)
			{
				availableStateManagers.Add(value6);
			}
		}
		foreach (SellState value7 in marketItems.Values)
		{
			if (value7.numWorkersAssigned > 0f)
			{
				activeStateManagers.Add(value7);
				availableStateManagers.Add(value7);
			}
			else if (!value7.isLocked)
			{
				availableStateManagers.Add(value7);
			}
		}
	}

	public void CalcAllAutoClaim()
	{
		foreach (ResearchState value in research.Values)
		{
			value.CalcAppliedAutoClaim();
		}
	}

	[Conditional("UNITY_EDITOR")]
	public void LogIfActive(string s)
	{
		_ = gm.activeTown;
	}

	public void CalcAllAutoAssign()
	{
		ClearMetadataFlag(524288);
		highestPriorityAutoAssign.Clear();
		highPriorityAutoAssign.Clear();
		medPriorityAutoAssign.Clear();
		lowPriorityAutoAssign.Clear();
		lowestPriorityAutoAssign.Clear();
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			potentialStateManager.CalcAppliedAutoAssign();
		}
		foreach (StateManager potentialStateManager2 in potentialStateManagers)
		{
			if (potentialStateManager2.AcceptsWorkers() && potentialStateManager2.appliedAutoAssign)
			{
				if (potentialStateManager2.appliedPriority == StatePriority.Highest)
				{
					highestPriorityAutoAssign.Add(potentialStateManager2);
				}
				else if (potentialStateManager2.appliedPriority == StatePriority.High)
				{
					highPriorityAutoAssign.Add(potentialStateManager2);
				}
				else if (potentialStateManager2.appliedPriority == StatePriority.Low)
				{
					lowPriorityAutoAssign.Add(potentialStateManager2);
				}
				else if (potentialStateManager2.appliedPriority == StatePriority.Lowest)
				{
					lowestPriorityAutoAssign.Add(potentialStateManager2);
				}
				else
				{
					lowPriorityAutoAssign.Add(potentialStateManager2);
				}
			}
		}
	}

	public void OnTradeModeChangedBuilding(BuildingState s)
	{
		foreach (TradingState value in trading.Values)
		{
			if (value.producingBuilding == s && value.CalcAppliedTradeMode() && value.CalcActiveTradeMode())
			{
				value.StoreItemStateCache();
				value.PerformCalcSpeed();
				if (value.parentTown == GameManager.Instance.activeTown)
				{
					MenuManager.Instance.combinedProductionPanel.UpdateIfVisible(value);
				}
			}
		}
	}

	public void OnProductionLimitChangedBuilding(CountableState countableState)
	{
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			if (potentialStateManager.producingBuilding == countableState)
			{
				potentialStateManager.CalcAppliedProductionLimit();
			}
		}
	}

	public void OnProductionLimitChangedSpecialty(AssignableState modifiedSettings)
	{
		foreach (TradingState value in trading.Values)
		{
			if (value.localSettings.parentSettings == modifiedSettings)
			{
				value.CalcAppliedProductionLimit();
			}
		}
	}

	public void OnTradeModeChangedSpecialty(Specialty s)
	{
		foreach (TradingState value in trading.Values)
		{
			if (value.cachedTradingSpecialty == s && value.CalcAppliedTradeMode() && value.CalcActiveTradeMode())
			{
				if (value.appliedAutoAssign)
				{
					value.AutoAssignNumWorkers(0f);
				}
				value.StoreItemStateCache();
				value.PerformCalcSpeed();
				if (value.parentTown == GameManager.Instance.activeTown)
				{
					MenuManager.Instance.combinedProductionPanel.UpdateIfVisible(value);
				}
			}
		}
	}

	public void CalcAllPause()
	{
		ClearMetadataFlag(8192);
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			potentialStateManager.CalcAppliedPauseState();
		}
	}

	public void CalcAllProductionLimits()
	{
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			potentialStateManager.CalcAppliedProductionLimit();
		}
	}

	public void OnPriorityChanged(object changedObject)
	{
		if (changedObject is StateManager stateManager)
		{
			RemoveFromAllPriorityLists(stateManager);
			RemoveFromAllAutoAssignLists(stateManager);
			stateManager.CalcAppliedPriority();
			if (stateManager.numWorkersAssigned > 0f)
			{
				stateManager.parentTown.AddToAppliedPriorityList(stateManager);
			}
			stateManager.parentTown.AddToAutoAssignPriorityList(stateManager);
			return;
		}
		if (changedObject == constructionSettings)
		{
			foreach (BuildingState value in buildings.Values)
			{
				OnPriorityChanged(value.constructionState);
			}
			return;
		}
		if (changedObject is BuildingState buildingState)
		{
			{
				foreach (StateManager potentialStateManager in potentialStateManagers)
				{
					if (potentialStateManager.producingBuilding == buildingState)
					{
						OnPriorityChanged(potentialStateManager);
					}
				}
				return;
			}
		}
		if (!(changedObject is TradeSpecialtyConfig tradeSpecialtyConfig))
		{
			return;
		}
		foreach (TradingState value2 in trading.Values)
		{
			if (value2.localSettings.parentSettings == tradeSpecialtyConfig)
			{
				OnPriorityChanged(value2);
			}
		}
	}

	public void CalcAllPriorities()
	{
		ClearMetadataFlag(4096);
		SetMetadataFlag(524288);
		highestPriorityStateManagers.Clear();
		highPriorityStateManagers.Clear();
		medPriorityStateManagers.Clear();
		lowPriorityStateManagers.Clear();
		lowestPriorityStateManagers.Clear();
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			potentialStateManager.CalcAppliedPriority();
		}
		foreach (StateManager activeStateManager in activeStateManagers)
		{
			if (activeStateManager.appliedPriority == StatePriority.Highest)
			{
				highestPriorityStateManagers.Add(activeStateManager);
			}
			else if (activeStateManager.appliedPriority == StatePriority.High)
			{
				highPriorityStateManagers.Add(activeStateManager);
			}
			else if (activeStateManager.appliedPriority == StatePriority.Low)
			{
				lowPriorityStateManagers.Add(activeStateManager);
			}
			else if (activeStateManager.appliedPriority == StatePriority.Lowest)
			{
				lowestPriorityStateManagers.Add(activeStateManager);
			}
			else
			{
				medPriorityStateManagers.Add(activeStateManager);
			}
		}
	}

	public void DeactivateState(StateManager sm)
	{
		sm.numWorkersAssigned = 0f;
		if (isRunningStateManagerLoop)
		{
			deactivationQueue.Add(sm);
			return;
		}
		activeStateManagers.Remove(sm);
		RemoveFromAllPriorityLists(sm);
		RemoveFromAllAutoAssignLists(sm);
		if (sm.producingBuilding != null)
		{
			CalcUnassignedBuildings(sm.producingBuilding);
			if (sm.parentTown == gm.activeTown)
			{
				sm.parentTown.OnBuildingModifiedInActiveTown(sm.producingBuilding.type);
			}
		}
	}

	public void RemoveFromAllAutoAssignLists(StateManager sm)
	{
		highestPriorityAutoAssign.Remove(sm);
		highPriorityAutoAssign.Remove(sm);
		medPriorityAutoAssign.Remove(sm);
		lowPriorityAutoAssign.Remove(sm);
		lowestPriorityAutoAssign.Remove(sm);
	}

	public void AddToAutoAssignPriorityList(StateManager sm)
	{
		if (sm.appliedAutoAssign)
		{
			switch (sm.appliedPriority)
			{
			case StatePriority.Highest:
				highestPriorityAutoAssign.Add(sm);
				break;
			case StatePriority.High:
				highPriorityAutoAssign.Add(sm);
				break;
			case StatePriority.Low:
				lowPriorityAutoAssign.Add(sm);
				break;
			case StatePriority.Lowest:
				lowestPriorityAutoAssign.Add(sm);
				break;
			default:
				medPriorityAutoAssign.Add(sm);
				break;
			}
		}
	}

	public void RemoveFromAllPriorityLists(StateManager sm)
	{
		highestPriorityStateManagers.Remove(sm);
		highPriorityStateManagers.Remove(sm);
		medPriorityStateManagers.Remove(sm);
		lowPriorityStateManagers.Remove(sm);
		lowestPriorityStateManagers.Remove(sm);
	}

	public void AddToAppliedPriorityList(StateManager sm)
	{
		switch (sm.appliedPriority)
		{
		case StatePriority.Highest:
			highestPriorityStateManagers.Add(sm);
			break;
		case StatePriority.High:
			highPriorityStateManagers.Add(sm);
			break;
		case StatePriority.Low:
			lowPriorityStateManagers.Add(sm);
			break;
		case StatePriority.Lowest:
			lowestPriorityStateManagers.Add(sm);
			break;
		default:
			medPriorityStateManagers.Add(sm);
			break;
		}
	}

	public void PreprocessSimulation()
	{
		isRunningStateManagerLoop = true;
		completedBuildingQueue.Clear();
		for (int i = 0; i < consumableStates.Length; i++)
		{
			consumableStates[i].ClearFrameRequestState();
		}
		for (int j = 0; j < availableStateManagers.Count; j++)
		{
			availableStateManagers[j].ResetProduction();
		}
		for (int k = 0; k < consumableStates.Length; k++)
		{
			consumableStates[k].CalcFrameAvailability();
		}
		for (int l = 0; l < passiveRegenListCount; l++)
		{
			passiveResourceRegenList[l].ApplyDelta();
		}
	}

	public void PostProcessSimulation()
	{
		if (TimeManager.SimulationDelta > 0f)
		{
			for (int i = 0; i < consumableStates.Length; i++)
			{
				ConsumableState obj = consumableStates[i];
				obj.CalcFinalFrameStats();
				_ = obj.debug;
			}
		}
		CalcTradeModeSwitchFlags();
		CalcHappiness();
		CalcSkillStats();
		isRunningStateManagerLoop = false;
		for (int j = 0; j < deactivationQueue.Count; j++)
		{
			StateManager sm = deactivationQueue[j];
			DeactivateState(sm);
		}
		deactivationQueue.Clear();
		if (GameManager.IsQuestAndAchievementProcessFrame)
		{
			SetMetadataFlag(8388608);
		}
		if (completedBuildingQueue.Count > 0)
		{
			for (int k = 0; k < completedBuildingQueue.Count; k++)
			{
				BuildingType t = completedBuildingQueue[k];
				ProcessBuildingCountChanged(t);
				if (this == gm.activeTown)
				{
					OnBuildingModifiedInActiveTown(t);
				}
			}
			completedBuildingQueue.Clear();
		}
		cachedLevelProgress.ChangeValue(LevelWithProgress());
		if (cachedTownXPState.currentCount >= levelUpCost)
		{
			spentXP += levelUpCost;
			cachedTownXPState.Subtract(levelUpCost);
			LevelUpTown();
		}
		CalcOptimalWorkers();
		if (this == gm.activeTown && numWorkersChangedMetadataQueue.Count > 0)
		{
			menu.researchPanel.isBuildingDataStale = true;
		}
		foreach (BuildingState item in numWorkersChangedMetadataQueue)
		{
			CalcUnassignedBuildings(item);
			item.CacheRemovalState(UserInput.activeGlobalIncrement);
		}
		numWorkersChangedMetadataQueue.Clear();
		if (cumulativeXP >= prestigeLevelUpCost)
		{
			CalcTownLevelMetadata();
		}
	}

	private void CalcOptimalWorkers()
	{
		if (optimalWorkerCountdown > 0)
		{
			optimalWorkerCountdown--;
			return;
		}
		optimalWorkerCountdown = 0;
		int count = highestPriorityAutoAssign.Count;
		for (int i = 0; i < count; i++)
		{
			highestPriorityAutoAssign[i].CalcOptimalWorkers();
		}
		count = highPriorityAutoAssign.Count;
		for (int j = 0; j < count; j++)
		{
			highPriorityAutoAssign[j].CalcOptimalWorkers();
		}
		count = medPriorityAutoAssign.Count;
		for (int k = 0; k < count; k++)
		{
			medPriorityAutoAssign[k].CalcOptimalWorkers();
		}
		count = lowPriorityAutoAssign.Count;
		for (int l = 0; l < count; l++)
		{
			lowPriorityAutoAssign[l].CalcOptimalWorkers();
		}
		count = lowestPriorityAutoAssign.Count;
		for (int m = 0; m < count; m++)
		{
			lowestPriorityAutoAssign[m].CalcOptimalWorkers();
		}
	}

	public void TestForTownUpgradeUnlock()
	{
		foreach (Upgrade value in upgrades.Values)
		{
			if (value.displayAvailability == BuildObjectAvailability.Locked)
			{
				value.CalcAvailability();
			}
			else if (value.displayAvailability == BuildObjectAvailability.Available && !value.currentLevelAvailability)
			{
				value.CalcAvailability();
			}
		}
	}

	private void CalcTradeModeSwitchFlags()
	{
		if (TimeManager.SimulationDelta <= 0f)
		{
			return;
		}
		foreach (TradingState value in trading.Values)
		{
			_ = value.localItemState.frameLocalProduced;
			_ = value.localItemState.frameLocalConsumed;
			_ = value.debugAutoTrade;
			if (value.appliedTradeMode != TradeMode.AutoTradeLocalBalance && value.appliedTradeMode != TradeMode.AutoTradeGlobalBalance && value.appliedTradeMode != TradeMode.AutoTradeLocalFill && value.appliedTradeMode != TradeMode.AutoTradeGlobalFill)
			{
				continue;
			}
			bool num = value.autoTradeCooldown <= 0;
			if (value.autoTradeCooldown > 0)
			{
				value.autoTradeCooldown--;
			}
			if (num && value.CalcActiveTradeMode())
			{
				if (value.appliedAutoAssign)
				{
					value.AutoAssignNumWorkers(0f);
				}
				value.StoreItemStateCache();
				value.PerformCalcSpeed();
				if (value.parentTown == GameManager.Instance.activeTown)
				{
					MenuManager.Instance.combinedProductionPanel.UpdateIfVisible(value);
				}
			}
		}
	}

	private void CalcHappiness()
	{
		happinessAverage = 0f;
		happinessMax = 0f;
		float num = 0f;
		float num2 = 0f;
		happinessMultiplier = 1f;
		fulfillmentScore = 0;
		fulfillmentTier = 0;
		bool flag = this == gm.activeTown;
		if (flag)
		{
			foreach (BuildingState value in buildings.Values)
			{
				value.happinessTotal = 0.0;
				value.happinessCount = 0.0;
			}
		}
		foreach (SellState value2 in marketItems.Values)
		{
			if (value2.isLocked || !(value2.happinessRate > 0f))
			{
				continue;
			}
			double actualSalesPerSecond = value2.actualSalesPerSecond;
			value2.fulfillmentRatio = GameUtility.AsTruncatedFloat(actualSalesPerSecond / (double)value2.happinessRate);
			value2.happinessQuintile = GameUtility.HappinessQuintileForSupplyRate(value2.fulfillmentRatio);
			value2.fulfillmentScore = GameUtility.BonusForHappinessQuintile(value2.happinessQuintile);
			fulfillmentScore += value2.fulfillmentScore;
			happinessMax += value2.happinessRate;
			if (actualSalesPerSecond > (double)value2.happinessRate)
			{
				num += 1f;
				if (flag)
				{
					value2.producingBuilding.happinessTotal += 1.0;
				}
			}
			else
			{
				num += value2.fulfillmentRatio;
				if (flag)
				{
					value2.producingBuilding.happinessTotal += value2.fulfillmentRatio;
				}
			}
			if (flag)
			{
				value2.producingBuilding.happinessCount += 1.0;
			}
			num2 += 1f;
		}
		if (num2 <= 0f)
		{
			happinessAverage = 0f;
		}
		else
		{
			happinessAverage = num / num2;
			fulfillmentTier = fulfillmentScore / 10;
			happinessMultiplier += (float)fulfillmentTier * 0.04f;
		}
		double postProcessMultiplier = cachedTownXPState.postProcessMultiplier;
		cachedTownXPState.postProcessMultiplier = happinessMultiplier;
		if (!GameUtility.NotEquals(cachedTownXPState.postProcessMultiplier, postProcessMultiplier))
		{
			return;
		}
		foreach (SellState value3 in marketItems.Values)
		{
			value3.RecalcXP();
		}
		foreach (HarvestState value4 in harvesting.Values)
		{
			value4.RecalcXP();
		}
		foreach (MiningState value5 in miningItems.Values)
		{
			value5.RecalcXP();
		}
		foreach (FarmingState value6 in farmingItems.Values)
		{
			value6.RecalcXP();
		}
		foreach (RecipeState value7 in recipes.Values)
		{
			value7.RecalcXP();
		}
	}

	public void AddSkill(Skill s)
	{
		allTownSkillList.Add(s);
		if (!townSkills.TryGetValue(s.skillType, out var value))
		{
			value = new Dictionary<EntityId, Skill>();
			townSkills[s.skillType] = value;
		}
		value[s.skillId] = s;
	}

	public void PreparePassRequest(int priorityIndex)
	{
		for (int i = 0; i < consumableStates.Length; i++)
		{
			consumableStates[i].PreparePassRequest(priorityIndex);
		}
		List<StateManager> list = StatesForPriority(priorityIndex);
		int count = list.Count;
		for (int j = 0; j < count; j++)
		{
			list[j].CalcPotentialWorkPerSimulationPass();
		}
		for (int k = 0; k < count; k++)
		{
			StateManager stateManager = list[k];
			stateManager.ApplyMaxOutput();
			stateManager.RequestOutputCapacity();
		}
		for (int l = 0; l < consumableStates.Length; l++)
		{
			consumableStates[l].CalcPassOutputRatio();
		}
	}

	public void FinalizeOutputCalcInput(int priorityIndex)
	{
		List<StateManager> list = StatesForPriority(priorityIndex);
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			list[i].FinalizeOutputRatio();
		}
		for (int j = 0; j < count; j++)
		{
			list[j].RequestInputSupply();
		}
		for (int k = 0; k < consumableStates.Length; k++)
		{
			consumableStates[k].CalcPassInputRatio();
		}
	}

	public List<StateManager> StatesForPriority(int priorityIndex)
	{
		return priorityIndex switch
		{
			0 => highestPriorityStateManagers, 
			1 => highPriorityStateManagers, 
			2 => medPriorityStateManagers, 
			3 => lowPriorityStateManagers, 
			4 => lowestPriorityStateManagers, 
			_ => null, 
		};
	}

	public void FinalizeAndProduce(int priorityIndex)
	{
		List<StateManager> list = StatesForPriority(priorityIndex);
		_ = GameManager.debugSimulation;
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			list[i].FinalizeInputRatio();
		}
		for (int j = 0; j < count; j++)
		{
			list[j].Produce();
		}
	}

	public void ResetTownState(bool isFullReset = true)
	{
		if (isFullReset)
		{
			townName = null;
			townPerkPointState.currentCount = 0.0;
			numTownResets = 0;
			isCapitalCity = false;
			foreach (KeyValuePair<PerkType, PerkState> townPerk in townPerks)
			{
				townPerk.Value.Reset();
			}
			workerState.Reset();
			storageBoostMultiplier = 0f;
			lastTownPerkResetTimestamp = 0L;
			bonusPrestigePoints = 0.0;
			constructionSettings.Reset();
			categoryCollapseManagers.Clear();
			logEntries.Clear();
		}
		hasResearchToClaim = false;
		hasUpgradeToClaim = false;
		numSpecialtiesActive = 0;
		isTownPerkValidityStale = true;
		townLevelCache.value = 0;
		spentXP = 0.0;
		pendingPrestigeCoins = 0;
		townPerkPointState.currentCount = 0.0;
		completedResearchStat.value = 0;
		if (1 == 0)
		{
			foreach (FloatProperty value in coinSpendCounts.Values)
			{
				value.value = 0.0;
			}
			foreach (FloatProperty value2 in itemProductionStats.Values)
			{
				value2.value = 0.0;
			}
			foreach (FloatProperty value3 in marketSellCounts.Values)
			{
				value3.value = 0.0;
			}
		}
		foreach (KeyValuePair<ItemType, TradingState> item in trading)
		{
			item.Value.Reset();
		}
		landState.Reset();
		foreach (ItemState value4 in inventory.Values)
		{
			value4.Reset();
		}
		foreach (ResourceState value5 in naturalResources.Values)
		{
			value5.Reset();
		}
		foreach (RecipeState value6 in recipes.Values)
		{
			value6.Reset();
		}
		foreach (KeyValuePair<NaturalResource, FarmingState> farmingItem in farmingItems)
		{
			farmingItem.Value.Reset();
		}
		foreach (KeyValuePair<NaturalResource, MiningState> miningItem in miningItems)
		{
			miningItem.Value.Reset();
		}
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			building.Value.Reset();
			building.Value.availability = BuildObjectAvailability.Locked;
		}
		foreach (KeyValuePair<HarvestRecipeType, HarvestState> item2 in harvesting)
		{
			item2.Value.Reset();
		}
		foreach (KeyValuePair<ItemType, SellState> marketItem in marketItems)
		{
			marketItem.Value.Reset();
		}
		foreach (KeyValuePair<ResearchType, ResearchState> item3 in research)
		{
			item3.Value.Reset();
		}
		foreach (Upgrade value7 in upgrades.Values)
		{
			value7.Reset();
		}
		foreach (KeyValuePair<SkillType, Dictionary<EntityId, Skill>> townSkill in townSkills)
		{
			foreach (KeyValuePair<EntityId, Skill> item4 in townSkill.Value)
			{
				item4.Value.Reset();
			}
		}
		foreach (TradeSpecialtyConfig value8 in tradeSpecialtyConfigs.Values)
		{
			value8.Reset();
		}
	}

	private void InitializeSettingLinks()
	{
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			if (potentialStateManager is TradingState tradingState && tradeSpecialtyConfigs.TryGetValue(tradingState.cachedTradingSpecialty, out var value))
			{
				tradingState.localSettings.parentSettings = value;
				if (value.parentSettings == null)
				{
					value.parentSettings = tradingState.producingBuilding.settings;
				}
			}
			else if (potentialStateManager is ConstructionState constructionState)
			{
				constructionState.localSettings.parentSettings = constructionSettings;
			}
			else if (potentialStateManager.producingBuilding != null)
			{
				potentialStateManager.localSettings.parentSettings = potentialStateManager.producingBuilding.settings;
			}
		}
	}

	private void CalcStaticStateMetadata()
	{
		LogInitValue(10);
		potentialStateManagers.Clear();
		CalcBuildingCraftingSkills();
		foreach (KeyValuePair<PerkType, PerkState> townPerk in townPerks)
		{
			townPerk.Value.StoreItemStateCache();
		}
		for (int i = 0; i < naturalResourceCache.Length; i++)
		{
			naturalResourceCache[i].StoreItemStateCache();
		}
		foreach (PerkState value9 in townPerks.Values)
		{
			value9.StoreRequirementCache();
		}
		for (int j = 0; j < recipeCache.Length; j++)
		{
			RecipeState recipeState = recipeCache[j];
			potentialStateManagers.Add(recipeState);
			recipeState.StoreItemStateCache();
		}
		foreach (KeyValuePair<ResearchType, ResearchState> item in research)
		{
			ResearchState value = item.Value;
			potentialStateManagers.Add(value);
			value.StoreItemStateCache();
		}
		foreach (KeyValuePair<NaturalResource, FarmingState> farmingItem in farmingItems)
		{
			FarmingState value2 = farmingItem.Value;
			value2.StoreItemStateCache();
			potentialStateManagers.Add(value2);
		}
		foreach (KeyValuePair<NaturalResource, MiningState> miningItem in miningItems)
		{
			MiningState value3 = miningItem.Value;
			value3.StoreItemStateCache();
			potentialStateManagers.Add(value3);
		}
		foreach (KeyValuePair<UpgradeType, Upgrade> upgrade in upgrades)
		{
			upgrade.Value.StoreRequirements();
		}
		foreach (KeyValuePair<HarvestRecipeType, HarvestState> item2 in harvesting)
		{
			HarvestState value4 = item2.Value;
			value4.StoreItemStateCache();
			potentialStateManagers.Add(value4);
		}
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			BuildingState value5 = building.Value;
			potentialStateManagers.Add(value5.constructionState);
			value5.StoreItemStateCache();
		}
		foreach (KeyValuePair<ItemType, SellState> marketItem in marketItems)
		{
			SellState value6 = marketItem.Value;
			value6.StoreItemStateCache();
			potentialStateManagers.Add(value6);
		}
		foreach (KeyValuePair<ItemType, FloatProperty> coinSpendCount in coinSpendCounts)
		{
			if (inventory.TryGetValue(coinSpendCount.Key, out var value7))
			{
				value7.spendStats.Add(coinSpendCount.Value);
			}
		}
		foreach (KeyValuePair<ItemType, TradingState> item3 in trading)
		{
			TradingState value8 = item3.Value;
			value8.StoreItemStateCache();
			potentialStateManagers.Add(value8);
		}
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			potentialStateManager.LoadModifiers();
		}
		foreach (PassiveStateModifier passiveResourceRegen in passiveResourceRegenList)
		{
			passiveResourceRegen.LoadModifiers(this);
		}
	}

	public bool IsResourceImpossible(NaturalResource r)
	{
		if (Crafting.naturalResourceCache.TryGetValue(r, out var value) && value.exclusiveBiome != BiomeType.None && value.exclusiveBiome != biomeType)
		{
			return true;
		}
		return false;
	}

	private bool IsImpossibleInTown(List<Requirement> reqs)
	{
		foreach (Requirement req in reqs)
		{
			if (req is RequiredBiome requiredBiome && requiredBiome.biomeType != biomeType)
			{
				return true;
			}
		}
		return false;
	}

	private void AddBuildingSkill(BuildingType t, Skill s)
	{
		if (!skillsPerBuilding.TryGetValue(t, out var value))
		{
			value = new List<Skill>();
			skillsPerBuilding[t] = value;
		}
		value.Add(s);
	}

	public void OnBuildingModifiedInActiveTown(BuildingType t)
	{
		if (t == BuildingType.FireTemple || t == BuildingType.ManaTemple || t == BuildingType.WaterTemple || t == BuildingType.AirTemple || t == BuildingType.EarthTemple || t == BuildingType.Packager)
		{
			menu.combinedProductionPanel.arePanelCostsStale = true;
		}
	}

	public void ProcessBuildingCountChanged(BuildingType t)
	{
		if (buildings.TryGetValue(t, out var value))
		{
			CalcUnassignedBuildings(value);
		}
	}

	public void ProcessTownMetadataQueue()
	{
		if (metadataFlags == 0)
		{
			return;
		}
		if (IsMetadataStale(32768))
		{
			ClearMetadataFlag(32768);
			CalcAllAutoClaim();
			CalcUpgradeCount();
			CalcBuildingCount();
			CalcSkillStats();
			CalcSkillSpeed();
			CalcMaxSpecialties();
			CalcTownLevelMetadata();
			CalcTownPerkCosts();
			CalcAllProductionLimits();
			CalcUnassignedPerkPoints();
		}
		if (IsMetadataStale(1) && Crafting.biomeCache.TryGetValue(biomeType, out var value))
		{
			ApplyBiomeEffects(value);
		}
		if (IsMetadataStale(4))
		{
			CalcLandCapacity();
			SetMetadataFlag(16);
			SetMetadataFlag(64);
		}
		if (IsMetadataStale(512) || IsMetadataStale(16))
		{
			storageBoostMultiplier = 0f;
		}
		if (IsMetadataStale(16))
		{
			CalcNaturalResourceCapacity();
		}
		if (IsMetadataStale(128))
		{
			SetMetadataFlag(32);
			CalcPopulation();
		}
		if (IsMetadataStale(32))
		{
			CalcUnassignedWorkers();
		}
		if (IsMetadataStale(64))
		{
			CalcUnusedHousingPlots();
		}
		if (IsMetadataStale(256))
		{
			CalcMarketDemand();
		}
		if (IsMetadataStale(512))
		{
			CalcAllItemCapacity();
		}
		if (IsMetadataStale(4194304))
		{
			CalcAllBuildingCapacity();
		}
		if (IsMetadataStale(2048))
		{
			CalcStateManagers();
		}
		if (IsMetadataStale(8192))
		{
			CalcAllPause();
		}
		if (IsMetadataStale(4096))
		{
			CalcAllPriorities();
		}
		if (IsMetadataStale(262144))
		{
			ClearMetadataFlag(262144);
			CalcPassiveResourceRegen();
		}
		if (IsMetadataStale(8))
		{
			CalcBuildingCosts();
		}
		if (IsMetadataStale(65536))
		{
			ClearMetadataFlag(65536);
			CalcResourceAvailability();
			CalcHarvestAvailability();
			CalcBuildingAvailability();
			CalcPerkAvailability();
			CalcRecipeAvailability();
			CalcItemAvailability();
			CalcMarketAvailability();
			CalcResearchAvailability();
			CalcUpgradeAvailability();
			CalcFarmingAvailability();
			CalcMiningAvailability();
			CalcTradingAvailability();
			if (this == gm.activeTown)
			{
				menu.FlagAllAvailabilityStale();
			}
		}
		if (IsMetadataStale(131072))
		{
			ClearMetadataFlag(131072);
			CalcRecipeSpeed();
			CalcHarvestSpeed();
			CalcFarmingSpeed();
			CalcMiningSpeed();
			if (this == gm.activeTown)
			{
				menu.combinedProductionPanel.arePanelCostsStale = true;
			}
		}
		if (IsMetadataStale(2097152))
		{
			CalcSellSpeed();
		}
		if (IsMetadataStale(1048576))
		{
			CalcAllAvailableProductionCapacity();
		}
		if (IsMetadataStale(524288))
		{
			CalcAllAutoAssign();
		}
		if (IsMetadataStale(16384))
		{
			CalcTradingSpeed();
		}
		if (IsMetadataStale(2))
		{
			CalcResearchSpeed();
		}
		if (IsMetadataStale(8388608))
		{
			CalcHasUpgradeToClaim();
			CalcHasResearchToClaim();
			ClearMetadataFlag(8388608);
		}
		ClearMetadataFlag(1024);
	}

	public void RefreshAllTownMetadata()
	{
		SetAllTownMetadataStale();
		ProcessTownMetadataQueue();
	}

	public void SetAllTownMetadataStale()
	{
		for (int i = 0; i <= 23; i++)
		{
			int num = 1 << i;
			metadataFlags |= num;
		}
	}

	public void SetStaleFlagsForModifiedLocalBuilding(BuildingType t)
	{
		BuildingDef cachedBuildingDef = Crafting.GetCachedBuildingDef(t);
		if (cachedBuildingDef.storageAmount > 0)
		{
			SetMetadataFlag(512);
			SetMetadataFlag(16);
		}
		if (cachedBuildingDef.workerHousingProvided > 0)
		{
			SetMetadataFlag(128);
			SetMetadataFlag(64);
		}
		if (cachedBuildingDef.landRequired > 0)
		{
			SetMetadataFlag(4);
		}
		if (cachedBuildingDef.workersRequired > 0)
		{
			SetMetadataFlag(32);
		}
		SetMetadataFlag(65536);
	}

	public void SetStaleFlagsForModifiedBuilding(BuildingType t)
	{
		switch (t)
		{
		case BuildingType.Packager:
			SetMetadataFlag(16384);
			break;
		case BuildingType.FloatingIsland:
			SetMetadataFlag(4);
			break;
		case BuildingType.House:
			SetMetadataFlag(256);
			break;
		case BuildingType.Caravan:
			SetMetadataFlag(16384);
			break;
		case BuildingType.TradingPost:
			SetMetadataFlag(16384);
			gm.isGlobalItemCapacityStale = true;
			break;
		case BuildingType.RailDepot:
			gm.isGlobalItemCapacityStale = true;
			break;
		case BuildingType.PlainsUniversity:
			gm.isUniversityMetadataStale = true;
			break;
		case BuildingType.RiverHarbor:
			gm.isHarborMetadataStale = true;
			break;
		case BuildingType.ForestMonastery:
			gm.isMonasteryMetadataStale = true;
			break;
		case BuildingType.MountainObservatory:
			gm.isObservatoryMetadataStale = true;
			break;
		case BuildingType.JunglePyramid:
			SetMetadataFlag(8);
			gm.isPyramidMetadataStale = true;
			break;
		case BuildingType.DesertBazaar:
			SetMetadataFlag(2097152);
			gm.isBazaarMetadataStale = true;
			break;
		case BuildingType.SnowTreasureVault:
			SetMetadataFlag(2097152);
			gm.isTreasureVaultMetadataStale = true;
			break;
		case BuildingType.MagicObelisk:
			SetMetadataFlag(2228224);
			gm.isObeliskMetadataStale = true;
			break;
		case BuildingType.MagicRailTile:
			SetMetadataFlag(131072);
			SetMetadataFlag(16384);
			break;
		case BuildingType.Factory:
		case BuildingType.Airship:
		case BuildingType.Chute:
		case BuildingType.MagicBoat:
		case BuildingType.Minecart:
		case BuildingType.MagicConveyorBelt:
		case BuildingType.Tractor:
		case BuildingType.Foundry:
			SetMetadataFlag(131072);
			break;
		case BuildingType.ManaTemple:
			ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.SmeltPurifiedMana));
			break;
		case BuildingType.FireTemple:
			ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.SmeltPurifiedFire));
			break;
		case BuildingType.WaterTemple:
			ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.SmeltPurifiedWater));
			break;
		case BuildingType.EarthTemple:
			ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.SmeltPurifiedEarth));
			break;
		case BuildingType.AirTemple:
			ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.SmeltPurifiedAir));
			break;
		}
	}

	private void CalcBiomeUnavailability()
	{
		ClearMetadataFlag(1024);
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			if (potentialStateManager.isLocked && potentialStateManager.numWorkersAssigned > 0f)
			{
				potentialStateManager.numWorkersAssigned = 0f;
				SetMetadataFlag(2048);
				SetMetadataFlag(1048576);
			}
		}
	}

	public void CalcMaxSpecialties()
	{
		maxNumSpecialties = GameManager.Instance.MaxNumSpecialtiesForPerkLevel();
	}

	private void CalcTownPerkCosts()
	{
		foreach (KeyValuePair<PerkType, PerkState> townPerk in townPerks)
		{
			townPerk.Value.CalcCost();
		}
	}

	private void CalcRecipeSpeed()
	{
		for (int i = 0; i < recipeCache.Length; i++)
		{
			recipeCache[i].PerformCalcSpeed();
		}
	}

	private void CalcResearchSpeed()
	{
		ClearMetadataFlag(2);
		foreach (KeyValuePair<ResearchType, ResearchState> item in research)
		{
			item.Value.PerformCalcSpeed();
		}
		if (this == gm.activeTown)
		{
			menu.researchPanel.arePanelCostsStale = true;
		}
	}

	private void CalcConstructionSpeed()
	{
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			building.Value.constructionState.PerformCalcSpeed();
		}
	}

	public void CalcSellSpeed()
	{
		ClearMetadataFlag(2097152);
		foreach (KeyValuePair<ItemType, SellState> marketItem in marketItems)
		{
			marketItem.Value.PerformCalcSpeed();
		}
		if (this == gm.activeTown)
		{
			menu.combinedProductionPanel.arePanelCostsStale = true;
		}
	}

	public void CalcRecipeAttributesForBuilding(BuildingType t)
	{
		if (!buildings.TryGetValue(t, out var value))
		{
			return;
		}
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			if (potentialStateManager.producingBuilding == value)
			{
				potentialStateManager.PerformCalcSpeed();
			}
		}
	}

	public void ProcessMetadataForEntity(EntityId id)
	{
		if (id.TryAsBuilding(out var b))
		{
			CalcRecipeAttributesForBuilding(b);
			return;
		}
		StateManager stateManager = StateForEntity(id);
		if (stateManager == null)
		{
			return;
		}
		stateManager.PerformCalcSpeed();
		if (this == gm.activeTown)
		{
			MenuPanel menuPanel = MenuManager.Instance.MenuPanelForState(stateManager);
			if (null != menuPanel && menuPanel is MenuListPanel menuListPanel)
			{
				menuListPanel.arePanelCostsStale = true;
			}
		}
	}

	public void CalcSkillSpeed()
	{
		foreach (KeyValuePair<SkillType, Dictionary<EntityId, Skill>> townSkill in townSkills)
		{
			foreach (KeyValuePair<EntityId, Skill> item in townSkill.Value)
			{
				item.Value.CalcSkillGainRate();
			}
		}
	}

	public int LevelOfResearch(ResearchType t)
	{
		if (research.TryGetValue(t, out var value))
		{
			return value.numCompleted;
		}
		return 0;
	}

	public float NumBuildingsOfType(BuildingType t)
	{
		switch (t)
		{
		case BuildingType.None:
			return totalBuildings;
		case BuildingType.Base:
			return GameManager.Instance.numTowns;
		default:
		{
			if (buildings.TryGetValue(t, out var value))
			{
				return GameUtility.AsFloat(value.currentCount);
			}
			return 0f;
		}
		}
	}

	public void CalcResearchAvailability()
	{
		foreach (KeyValuePair<ResearchType, ResearchState> item in research)
		{
			ResearchState value = item.Value;
			if (false)
			{
				foreach (Requirement derivedRequirement in value.derivedRequirements)
				{
					_ = derivedRequirement;
				}
			}
			BuildObjectAvailability buildObjectAvailability = value.availability;
			if (buildObjectAvailability == BuildObjectAvailability.Disabled)
			{
				buildObjectAvailability = BuildObjectAvailability.Disabled;
			}
			else if (GameManager.everythingUnlocked)
			{
				buildObjectAvailability = BuildObjectAvailability.Available;
			}
			else if (value.availability == BuildObjectAvailability.Completed)
			{
				buildObjectAvailability = BuildObjectAvailability.Completed;
			}
			else if (value.numCompleted >= value.recipe.maxLevel)
			{
				foreach (Requirement derivedRequirement2 in value.derivedRequirements)
				{
					if (derivedRequirement2.IsImpossible())
					{
						buildObjectAvailability = BuildObjectAvailability.Disabled;
						break;
					}
				}
				if (buildObjectAvailability != BuildObjectAvailability.Disabled)
				{
					buildObjectAvailability = BuildObjectAvailability.Completed;
				}
			}
			else if (value.derivedRequirements == null)
			{
				buildObjectAvailability = BuildObjectAvailability.Available;
			}
			else if (value.availability == BuildObjectAvailability.Locked || value.availability == BuildObjectAvailability.Available)
			{
				bool flag = true;
				foreach (Requirement derivedRequirement3 in value.derivedRequirements)
				{
					if (derivedRequirement3.IsImpossible())
					{
						flag = false;
						buildObjectAvailability = BuildObjectAvailability.Disabled;
						break;
					}
					if (!derivedRequirement3.IsMet())
					{
						flag = false;
						buildObjectAvailability = BuildObjectAvailability.Locked;
					}
				}
				if (flag)
				{
					buildObjectAvailability = BuildObjectAvailability.Available;
				}
			}
			if ((buildObjectAvailability == BuildObjectAvailability.Available || buildObjectAvailability == BuildObjectAvailability.Locked) && value.permanentUnlockRequirements != null && value.permanentUnlockRequirements.Count > 0)
			{
				bool flag2 = true;
				foreach (Requirement permanentUnlockRequirement in value.permanentUnlockRequirements)
				{
					if (!permanentUnlockRequirement.IsMet())
					{
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					buildObjectAvailability = BuildObjectAvailability.Completed;
					value.numCompleted = 1;
				}
			}
			if (value.availability != buildObjectAvailability)
			{
				value.availability = buildObjectAvailability;
				if (value.availability == BuildObjectAvailability.Available)
				{
					value.Unlock();
				}
			}
		}
		menu.researchPanel.isItemAvailabilityStale = true;
	}

	private void CalcMinigameAvailability()
	{
		foreach (MinigamePanelParent minigamePanel in menu.minigamePanels)
		{
			minigamePanel.CalcPanelAvailability();
		}
	}

	private void CalcMiningAvailability()
	{
		foreach (KeyValuePair<NaturalResource, MiningState> miningItem in miningItems)
		{
			miningItem.Value.CalcAvailability();
		}
	}

	private void CalcFarmingAvailability()
	{
		foreach (KeyValuePair<NaturalResource, FarmingState> farmingItem in farmingItems)
		{
			farmingItem.Value.CalcAvailability();
		}
	}

	public void CalcUpgradeAvailability()
	{
		foreach (KeyValuePair<UpgradeType, Upgrade> upgrade in upgrades)
		{
			upgrade.Value.CalcAvailability();
		}
		menu.upgradesPanel.isItemAvailabilityStale = true;
	}

	private void CalcRecipeAvailability()
	{
		for (int i = 0; i < recipeCache.Length; i++)
		{
			RecipeState recipeState = recipeCache[i];
			if (recipeState.isLocked)
			{
				recipeState.CalcAvailability();
			}
		}
	}

	public bool HasHarvestedSeveralResources()
	{
		double num = 0.0;
		if (inventory.TryGetValue(ItemType.Wood, out var value))
		{
			num += value.globalProductionStat.value;
		}
		if (inventory.TryGetValue(ItemType.Stone, out var value2))
		{
			num += value2.globalProductionStat.value;
		}
		return num >= 4.0;
	}

	public bool HasHarvestedResource()
	{
		if (inventory.TryGetValue(ItemType.Wood, out var value) && value.globalProductionStat.value >= 1.0)
		{
			return true;
		}
		if (inventory.TryGetValue(ItemType.Stone, out var value2) && value2.globalProductionStat.value >= 1.0)
		{
			return true;
		}
		return false;
	}

	public void CalcHasUpgradeToClaim()
	{
		foreach (Upgrade value in upgrades.Values)
		{
			if (value.IsReadyToPurchase())
			{
				hasUpgradeToClaim = true;
				return;
			}
		}
		hasUpgradeToClaim = false;
	}

	public void CalcHasResearchToClaim()
	{
		foreach (ResearchState value in research.Values)
		{
			if (value.IsAvailable() && value.isReadyToClaim)
			{
				hasResearchToClaim = true;
				return;
			}
		}
		hasResearchToClaim = false;
	}

	private void CalcTownPerkAvailability()
	{
		foreach (PerkState value in townPerks.Values)
		{
			if (value.CanAffordPerk())
			{
				hasTownPerkAvailable = true;
				return;
			}
		}
		hasTownPerkAvailable = false;
	}

	public void PostProcessTownLevel()
	{
		double currentCount = sacrificedXP + spentXP + cachedTownXPState.currentCount;
		cachedTownXPState.currentCount = currentCount;
		sacrificedXP = 0.0;
		spentXP = 0.0;
		townLevelCache.value = 0;
		while (cachedTownXPState.currentCount >= levelUpCost)
		{
			townLevelCache.Add(1);
			spentXP += levelUpCost;
			cachedTownXPState.Subtract(levelUpCost);
			levelUpCost = GameManager.ExperienceCostForProgressingFromLevel(townLevel);
		}
	}

	public void CalcTownLevelMetadata()
	{
		levelUpCost = GameManager.ExperienceCostForProgressingFromLevel(townLevel);
	}

	public void SetTownLevel(int level)
	{
		gm.recentlyUnlockedEntities.Clear();
		townLevelCache.value = level;
		RefreshAllTownMetadata();
		gm.isPanelAvailabilityStale = true;
		gm.CalcBiomeLevels();
		gm.CheckTownLevelAchievements();
		gm.ProcessMetadataQueue();
		menu.FlagAllAvailabilityStale();
		menu.worldPanel.isActiveTownStale = true;
	}

	public void LevelUpTown()
	{
		SetTownLevel(townLevel + 1);
		if (TimeManager.IsFastForwarding)
		{
			menu.idleProgressPanel.AddLogLevelUp(this);
		}
		else
		{
			_ = gm.activeTown;
		}
		AddLog(new LogEntry(EntityId.FromItem(ItemType.TownExperiencePoint), townLevel, townIndex));
		gm.isQuestAvailabilityStale = true;
		SetMetadataFlag(4194304);
		SetMetadataFlag(128);
		SetMetadataFlag(4);
		CalcPerkAvailability();
		gm.recentlyUnlockedEntities.Clear();
		if (this == gm.activeTown)
		{
			menu.townStatsPanel.isTownLevelStale = true;
		}
	}

	private void AddSellable(ItemType t)
	{
		if (Crafting.houseSellData.TryGetValue(t, out var value))
		{
			SellState sellState = new SellState();
			marketItems[t] = sellState;
			sellState.parentTown = this;
			sellState.LoadItem(value);
		}
	}

	private void AddBuilding(BuildingType t)
	{
		if (!Crafting.buildingCache.TryGetValue(t, out var value) || IsImpossibleInTown(value.requirements))
		{
			return;
		}
		if (t == BuildingType.RailDepot)
		{
			if (gm.isTradingStorageInfinite)
			{
				return;
			}
		}
		else if (value.category == BuildingCategory.Storage && gm.isTownStorageInfinite)
		{
			return;
		}
		BuildingState buildingState = new BuildingState(value, this);
		buildings[t] = buildingState;
		(buildingState.constructionState = new ConstructionState(buildingState)).parentTown = this;
	}

	private void AddRecipe(RecipeType t)
	{
		Recipe recipe = Crafting.GetRecipe(t);
		if (!IsImpossibleInTown(recipe.requirements))
		{
			RecipeState recipeState = new RecipeState();
			recipes[t] = recipeState;
			recipeState.parentTown = this;
			recipeState.LoadRecipe(recipe);
			recipeState.AddSkill(SkillType.Crafting);
		}
	}

	private void AddResearch(Research r)
	{
		if (gm.isTownStorageInfinite)
		{
			switch (r.type)
			{
			case ResearchType.Warehouse:
			case ResearchType.Crystalarium:
			case ResearchType.Treasury:
			case ResearchType.CropSilo:
			case ResearchType.OreSilo:
			case ResearchType.Pantry:
			case ResearchType.Reservoir:
			case ResearchType.Barrel:
			case ResearchType.EtherStorage:
			case ResearchType.OmnistoneStorage:
				return;
			}
		}
		if (gm.isTradingStorageInfinite && r.type == ResearchType.RailDepot)
		{
			return;
		}
		foreach (List<RequirementId> item in r.requirementFixedCache)
		{
			if (IsImpossibleInTown(item))
			{
				return;
			}
		}
		ResearchState researchState = new ResearchState();
		research[r.type] = researchState;
		researchState.parentTown = this;
		researchState.LoadResearch(r);
	}

	public TradingState AddTrade(ItemType t, Skill s)
	{
		TradingState tradingState = new TradingState();
		trading[t] = tradingState;
		tradingState.itemType = t;
		tradingState.parentTown = this;
		return tradingState;
	}

	private void AddItemState(ItemType t)
	{
		ItemState itemState = new ItemState();
		inventory[t] = itemState;
		itemState.type = t;
		itemState.townProductionStat = new FloatProperty();
		itemProductionStats[t] = itemState.townProductionStat;
		itemState.parentTown = this;
		if (gm.globalProductionStats.TryGetValue(t, out var value))
		{
			itemState.globalProductionStat = value;
		}
	}

	public void CalcUnassignedPerkPoints()
	{
		townPerkPointState.numAvailable = townPerkPointState.currentCount + bonusPrestigePoints;
		numPrestigePointsAssigned = 0f;
		foreach (PerkState value in townPerks.Values)
		{
			float num = value.TotalCostToReachCurrentLevel();
			numPrestigePointsAssigned += num;
		}
		townPerkPointState.numAvailable -= numPrestigePointsAssigned;
		isTownPerkValidityStale = true;
		CalcTownPerkAvailability();
	}

	public void UpdateDynamicData()
	{
		if (isTownPerkValidityStale)
		{
			CalcTownPerkValidity();
		}
	}

	private void CalcTownPerkValidity()
	{
		foreach (PerkState value in townPerks.Values)
		{
			value.CalcAddRemoveValidity();
		}
		isTownPerkValidityStale = false;
	}

	public void CalcUnassignedWorkers()
	{
		ClearMetadataFlag(32);
		workerState.numAvailable = workerState.currentCount;
		numWorkersAssignedToBuildings = 0f;
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			float num = GameUtility.AsFloat(building.Value.buildingDef.workersRequired);
			if (num > 0f)
			{
				float num2 = GameUtility.AsFloat(building.Value.currentCount + (double)building.Value.pendingConstructions);
				numWorkersAssignedToBuildings += num2 * num;
			}
		}
		workerState.numAvailable -= numWorkersAssignedToBuildings;
		if (this == gm.activeTown)
		{
			menu.combinedProductionPanel.isHouseCountStale = true;
		}
	}

	public bool IsMetadataStale(int flag)
	{
		return (metadataFlags & flag) > 0;
	}

	public void SetMetadataFlag(int flag)
	{
		metadataFlags |= flag;
	}

	private void ClearMetadataFlag(int flag)
	{
		metadataFlags &= ~flag;
	}

	public void CalcUnusedHousingPlots()
	{
		ClearMetadataFlag(64);
		landState.currentCount = landState.maxCount;
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			int landRequired = building.Value.buildingDef.landRequired;
			if (landRequired > 0)
			{
				double num = building.Value.currentCount + (double)building.Value.pendingConstructions;
				landState.currentCount -= num * (double)landRequired;
			}
		}
		landState.numAvailable = landState.currentCount;
		housingPlots = landState.maxCount;
		unusedHousingPlots = landState.currentCount;
	}

	private void SetBuildingCount(BuildingType t, double count)
	{
		if (buildings.TryGetValue(t, out var value))
		{
			value.currentCount = count;
		}
	}

	public void PrepareSecondaryTown()
	{
		SetBuildingCount(BuildingType.House, 3.0);
		SetBuildingCount(BuildingType.HarvesterHut, 2.0);
		SetBuildingCount(BuildingType.LumberMill, 1.0);
		SetBuildingCount(BuildingType.Market, 1.0);
		SetBuildingCount(BuildingType.GeneralGoods, 1.0);
		IncrementResearch(ResearchType.Warehouse);
		if (biomeType == BiomeType.Mountains)
		{
			SetBuildingCount(BuildingType.TradingPost, 3.0);
		}
		if (biomeType == BiomeType.Jungle)
		{
			SetBuildingCount(BuildingType.TradingPost, 3.0);
		}
		if (biomeType == BiomeType.Desert)
		{
			SetBuildingCount(BuildingType.TradingPost, 4.0);
		}
		if (biomeType == BiomeType.Snow)
		{
			SetBuildingCount(BuildingType.TradingPost, 4.0);
		}
		if (biomeType == BiomeType.Magic)
		{
			IncrementResearch(ResearchType.Hearth);
			SetBuildingCount(BuildingType.TradingPost, 5.0);
		}
	}

	public void FillResourcesToMax()
	{
		for (int i = 0; i < naturalResourceCache.Length; i++)
		{
			ResourceState resourceState = naturalResourceCache[i];
			if (gm.isTownStorageInfinite)
			{
				resourceState.currentCount = 5000.0;
			}
			else
			{
				resourceState.currentCount = resourceState.maxCount;
			}
		}
	}

	public void InitializeGameStates()
	{
		LogInitValue(1);
		SetMetadataFlag(1024);
		GameManager.TownBeingLoaded = this;
		workerState = new WorkerState();
		workerState.parentTown = this;
		landState = new CollectibleState(ItemType.UtilityLand);
		townPerkPointState = new CollectibleState(ItemType.UtilityPrestigePoint);
		townPerkPointState.maxCount = 3.4028234663852886E+38;
		townPerkPointState.debugFlag = true;
		AddItemState(ItemType.YellowCoin);
		AddItemState(ItemType.RedCoin);
		AddItemState(ItemType.BlueCoin);
		AddItemState(ItemType.PurpleCoin);
		AddItemState(ItemType.ExchangeToken);
		AddItemState(ItemType.Star);
		AddItemState(ItemType.OmniCoin);
		AddItemState(ItemType.TownExperiencePoint);
		cachedTownXPState = inventory[ItemType.TownExperiencePoint];
		marketSellCounts[BuildingType.Market] = new FloatProperty();
		marketSellCounts[BuildingType.GeneralGoods] = new FloatProperty();
		marketSellCounts[BuildingType.HardwareStore] = new FloatProperty();
		marketSellCounts[BuildingType.Bookstore] = new FloatProperty();
		marketSellCounts[BuildingType.ClothingStore] = new FloatProperty();
		marketSellCounts[BuildingType.Apothecary] = new FloatProperty();
		marketSellCounts[BuildingType.JewelryStore] = new FloatProperty();
		marketSellCounts[BuildingType.ArcaneStore] = new FloatProperty();
		marketSellCounts[BuildingType.FancyFoods] = new FloatProperty();
		townSkillStats[SkillType.Crafting] = new FloatProperty();
		townSkillStats[SkillType.Cultivation] = new FloatProperty();
		townSkillStats[SkillType.Harvesting] = new FloatProperty();
		townSkillStats[SkillType.Prospecting] = new FloatProperty();
		townSkillStats[SkillType.Trading] = new FloatProperty();
		foreach (EntityId item in Data.Instance.defaultDisplayCategories[BuildCategoryType.Item])
		{
			if (item.TryAsItem(out var i) && Crafting.cachedItemDefs.TryGetValue(i, out var value) && value.enabled)
			{
				AddItemState(i);
				if (value.tradeBuilding != BuildingType.None)
				{
					AddTrade(i, null);
				}
			}
		}
		foreach (Specialty tradingSpecialty in Crafting.tradingSpecialties)
		{
			TradeSpecialtyConfig tradeSpecialtyConfig = new TradeSpecialtyConfig();
			tradeSpecialtyConfig.specialty = tradingSpecialty;
			tradeSpecialtyConfig.parentTown = this;
			tradeSpecialtyConfigs[tradingSpecialty] = tradeSpecialtyConfig;
		}
		foreach (TradingState value2 in trading.Values)
		{
			tradeSpecialtyConfigs.ContainsKey(value2.cachedTradingSpecialty);
		}
		foreach (KeyValuePair<NaturalResource, NaturalResourceDef> item2 in Crafting.naturalResourceCache)
		{
			AddResourceState(item2.Value);
		}
		foreach (NaturalResourceDef value3 in Crafting.naturalResourceCache.Values)
		{
			if (value3.regenFactor > 0f)
			{
				AddPassiveResourceRegen(value3.type);
			}
		}
		foreach (KeyValuePair<RecipeType, Recipe> item3 in Crafting.recipeCache)
		{
			if (item3.Value.category == RecipeCategory.DefaultItem)
			{
				AddRecipe(item3.Key);
			}
		}
		foreach (KeyValuePair<HarvestRecipeType, HarvestDef> item4 in Crafting.harvestRecipeCache)
		{
			AddHarvesting(item4.Value);
		}
		foreach (KeyValuePair<BuildingType, BuildingDef> item5 in Crafting.buildingCache)
		{
			AddBuilding(item5.Key);
		}
		cachedHouseState = buildings[BuildingType.House];
		foreach (KeyValuePair<ItemType, HouseSellData> houseSellDatum in Crafting.houseSellData)
		{
			if (houseSellDatum.Value.derivedSellBuilding != BuildingType.None)
			{
				AddSellable(houseSellDatum.Key);
			}
		}
		foreach (KeyValuePair<NaturalResource, FarmingRecipe> item6 in Crafting.farmingRecipeCache)
		{
			AddFarmable(item6.Key);
		}
		foreach (KeyValuePair<NaturalResource, FarmingRecipe> item7 in Crafting.prospectingRecipeCache)
		{
			AddMining(item7.Key);
		}
		coinSpendCounts[ItemType.YellowCoin] = new FloatProperty();
		coinSpendCounts[ItemType.RedCoin] = new FloatProperty();
		coinSpendCounts[ItemType.BlueCoin] = new FloatProperty();
		coinSpendCounts[ItemType.PurpleCoin] = new FloatProperty();
		coinSpendCounts[ItemType.OmniCoin] = new FloatProperty();
		foreach (UpgradeDef value4 in Crafting.upgradeCache.Values)
		{
			if (!IsImpossibleInTown(value4.displayRequirements) && (!gm.isTownStorageInfinite || !Crafting.storageUpgrades.Contains(value4.type)) && (value4.levels.Count < 1 || !IsImpossibleInTown(value4.levels[0].unlockRequirements)))
			{
				Upgrade u = new Upgrade(value4, this);
				AddUpgrade(u);
			}
		}
		Data.Instance.LoadUpgradeLocalizationKeys();
		foreach (PerkType townPerk in Crafting.townPerks)
		{
			AddTownPerk(townPerk);
		}
		foreach (KeyValuePair<ResearchType, Research> item8 in Crafting.researchCache)
		{
			AddResearch(item8.Value);
		}
		inventoryCache = inventory.Values.ToArray();
		naturalResourceCache = naturalResources.Values.ToArray();
		recipeCache = recipes.Values.ToArray();
		consumableStates = new ConsumableState[inventoryCache.Length + naturalResourceCache.Length];
		int num = 0;
		ItemState[] array = inventoryCache;
		foreach (ItemState itemState in array)
		{
			consumableStates[num] = itemState;
			num++;
		}
		ResourceState[] array2 = naturalResourceCache;
		foreach (ResourceState resourceState in array2)
		{
			consumableStates[num] = resourceState;
			num++;
		}
		CalcStaticStateMetadata();
		GameManager.TownBeingLoaded = null;
	}

	private void ApplyBiomeEffects(Biome b)
	{
		ClearMetadataFlag(1);
		SetMetadataFlag(131072);
		if (this == gm.activeTown)
		{
			menu.FlagAllCostsStale();
		}
		biomeLandMultiplier = 1f;
		foreach (ResourceState value9 in naturalResources.Values)
		{
			value9.biomeCapacityMultiplier = 1f;
		}
		foreach (PassiveStateModifier passiveResourceRegen in passiveResourceRegenList)
		{
			passiveResourceRegen.productionModifiers?.RemoveAll((ProductionModifier x) => x is ProductionModifierBiome);
		}
		foreach (PassiveStateModifier value10 in passiveIncome.Values)
		{
			value10.productionModifiers?.RemoveAll((ProductionModifier x) => x is ProductionModifierBiome);
		}
		foreach (StateManager potentialStateManager in potentialStateManagers)
		{
			potentialStateManager.productionSpeedModifiers?.RemoveAll((ProductionModifier x) => x is ProductionModifierBiome);
			potentialStateManager.productionAmountModifiers?.RemoveAll((ProductionModifier x) => x is ProductionModifierBiome);
		}
		foreach (BiomeModifier entityModifier in b.entityModifiers)
		{
			if (entityModifier.isNegativeEffect)
			{
				float num = (1f - entityModifier.baselineMultiplier) * MultiplierForPerk(PerkType.RemoveBiomeNegatives);
				entityModifier.multiplier = 1f - num;
			}
			else
			{
				entityModifier.multiplier = entityModifier.baselineMultiplier;
			}
			switch (entityModifier.effect)
			{
			case BiomeModifierType.ResourceRegen:
			{
				if (entityModifier.target.TryAsNaturalResource(out var i) && this.passiveResourceRegen.TryGetValue(i, out var value3))
				{
					value3.AddModifier(b.type, entityModifier);
				}
				SetMetadataFlag(262144);
				break;
			}
			case BiomeModifierType.UniqueResource:
			{
				if (entityModifier.target.TryAsNaturalResource(out var i5) && farmingItems.TryGetValue(i5, out var value8))
				{
					value8.AddBiomeModifier(b.type, entityModifier);
				}
				break;
			}
			case BiomeModifierType.BuildingEffectiveness:
			{
				if (entityModifier.target.TryAsBuilding(out var b5) && passiveIncome.TryGetValue(b5, out var value6))
				{
					value6.AddModifier(b.type, entityModifier);
				}
				break;
			}
			case BiomeModifierType.RecipeProductivity:
			case BiomeModifierType.CraftingSpeed:
			{
				if (entityModifier.target.TryAsRecipe(out var r))
				{
					if (recipes.TryGetValue(r, out var value2))
					{
						value2.AddBiomeModifier(b.type, entityModifier);
					}
				}
				else
				{
					if (!entityModifier.target.TryAsBuilding(out var b3))
					{
						break;
					}
					foreach (RecipeState value11 in recipes.Values)
					{
						if (value11.producingBuilding != null && value11.producingBuilding.type == b3)
						{
							value11.AddBiomeModifier(b.type, entityModifier);
						}
					}
				}
				break;
			}
			case BiomeModifierType.CultivationProductivity:
			{
				if (entityModifier.target.TryAsNaturalResource(out var i4))
				{
					if (farmingItems.TryGetValue(i4, out var value7))
					{
						value7.AddBiomeModifier(b.type, entityModifier);
					}
				}
				else
				{
					if (!entityModifier.target.TryAsBuilding(out var b6))
					{
						break;
					}
					foreach (FarmingState value12 in farmingItems.Values)
					{
						if (value12.producingBuilding != null && value12.producingBuilding.type == b6)
						{
							value12.AddBiomeModifier(b.type, entityModifier);
						}
					}
				}
				break;
			}
			case BiomeModifierType.ProspectingProductivity:
			{
				if (entityModifier.target.TryAsNaturalResource(out var i2))
				{
					if (miningItems.TryGetValue(i2, out var value4))
					{
						value4.AddBiomeModifier(b.type, entityModifier);
					}
				}
				else
				{
					if (!entityModifier.target.TryAsBuilding(out var b4))
					{
						break;
					}
					foreach (MiningState value13 in miningItems.Values)
					{
						if (value13.producingBuilding != null && value13.producingBuilding.type == b4)
						{
							value13.AddBiomeModifier(b.type, entityModifier);
						}
					}
				}
				break;
			}
			case BiomeModifierType.Land:
				biomeLandMultiplier = entityModifier.multiplier;
				SetMetadataFlag(4);
				break;
			case BiomeModifierType.ResourceCapacity:
			{
				if (entityModifier.target.TryAsNaturalResource(out var i3) && naturalResources.TryGetValue(i3, out var value5))
				{
					value5.biomeCapacityMultiplier = entityModifier.multiplier;
				}
				SetMetadataFlag(16);
				break;
			}
			case BiomeModifierType.MarketDemand:
			{
				if (entityModifier.target.TryAsBuilding(out var b2) && buildings.TryGetValue(b2, out var value))
				{
					foreach (StateManager dependentState in value.dependentStates)
					{
						if (dependentState is SellState sellState)
						{
							sellState.biomeModifierDemand = entityModifier.multiplier;
						}
					}
				}
				SetMetadataFlag(256);
				break;
			}
			}
		}
	}

	private void PostProcessBiomeChange()
	{
	}

	private ItemState AddPermanentTownInventory(ItemType t)
	{
		return new ItemState
		{
			type = t,
			townProductionStat = new FloatProperty(),
			parentTown = this
		};
	}

	public bool IsImpossibleInTown(BuildingType t)
	{
		if (Crafting.buildingCache.TryGetValue(t, out var value))
		{
			return IsImpossibleInTown(value.requirements);
		}
		return true;
	}

	public bool IsImpossibleInTown(List<RequirementId> requirements)
	{
		if (requirements != null)
		{
			foreach (RequirementId requirement in requirements)
			{
				if (requirement.entityId.TryAsBiome(out var t))
				{
					if (requirement.type == RequirementType.Biome && t != biomeType)
					{
						return true;
					}
					if (requirement.type == RequirementType.ExcludedBiome && t == biomeType)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void AddTownPerk(PerkType t)
	{
		Perk perk = Crafting.perkDefCache[t];
		if (!IsImpossibleInTown(perk.requirements) && (t != PerkType.RemoveBiomeNegatives || gm.gameModifierBiomes == GameModifier.None) && (t != PerkType.StorageBoost || !gm.isTownStorageInfinite) && ((t != PerkType.BooksDemand && t != PerkType.ClothingDemand && t != PerkType.ConstructionDemand && t != PerkType.JewelryDemand && t != PerkType.MagicDemand && t != PerkType.HardwareDemand && t != PerkType.MedicineDemand && t != PerkType.GourmetFoodsDemand && t != PerkType.TownOmnistoneDemand) || !gm.isConsumptionInfinite))
		{
			PerkState perkState = new PerkState(perk);
			perkState.parentTown = this;
			townPerks[t] = perkState;
		}
	}

	private void CalcPassiveResourceRegen()
	{
		foreach (KeyValuePair<NaturalResource, PassiveStateModifier> item in passiveResourceRegen)
		{
			float baselineRate = 0f;
			if (naturalResources.TryGetValue(item.Key, out var value))
			{
				float num = 4f;
				baselineRate = value.def.regenFactor * num;
			}
			item.Value.SetBaselineRate(baselineRate);
		}
	}

	private void CalcMarketDemand()
	{
		ClearMetadataFlag(256);
		numHouses = NumBuildingsOfType(BuildingType.House);
		foreach (SellState value in marketItems.Values)
		{
			value.CalcDemand();
		}
	}

	public void Spend(ItemList cost)
	{
		foreach (KeyValuePair<ItemType, double> item in cost.items)
		{
			if (inventory.TryGetValue(item.Key, out var value))
			{
				value.Subtract(item.Value);
			}
			if (coinSpendCounts.TryGetValue(item.Key, out var value2))
			{
				value2.Add(item.Value);
			}
		}
	}

	public void Spend(ItemState itemState, double amount)
	{
		itemState.Subtract(amount);
		if (coinSpendCounts.TryGetValue(itemState.type, out var value))
		{
			value.Add(amount);
		}
	}

	public void EarnItem(ItemType t, double count)
	{
		if (inventory.TryGetValue(t, out var value))
		{
			if (value.currentCount > value.maxCount)
			{
				double amount = value.maxCount - value.currentCount;
				value.Add(amount);
				value.currentCount = value.maxCount;
			}
			else
			{
				value.Add(count);
			}
		}
	}

	private void AddUpgrade(Upgrade u)
	{
		upgrades[u.type] = u;
	}

	private void AddFarmable(NaturalResource t)
	{
		if (Crafting.farmingRecipeCache.TryGetValue(t, out var value) && naturalResources.TryGetValue(t, out var value2) && !IsImpossibleInTown(value2.def.requirements) && !IsImpossibleInTown(value2.def.cultivationBuilding))
		{
			FarmingState farmingState = new FarmingState();
			farmingItems[t] = farmingState;
			farmingState.parentTown = this;
			farmingState.LoadFarming(value, value2);
			farmingState.AddSkill(SkillType.Cultivation);
		}
	}

	private void AddMining(NaturalResource t)
	{
		if (Crafting.prospectingRecipeCache.TryGetValue(t, out var value) && naturalResources.TryGetValue(t, out var value2) && !IsImpossibleInTown(value2.def.requirements) && !IsImpossibleInTown(value2.def.cultivationBuilding))
		{
			MiningState miningState = new MiningState();
			miningItems[t] = miningState;
			miningState.parentTown = this;
			miningState.LoadMining(value, value2);
			miningState.AddSkill(SkillType.Prospecting);
		}
	}

	private void AddHarvesting(HarvestDef t)
	{
		if (!Crafting.naturalResourceCache.TryGetValue(t.resourceType, out var value) || !IsImpossibleInTown(value.requirements))
		{
			HarvestState harvestState = new HarvestState();
			harvesting[t.type] = harvestState;
			harvestState.parentTown = this;
			harvestState.LoadHarvestRecipe(t);
			harvestState.AddSkill(SkillType.Harvesting);
		}
	}

	private void AddPassiveResourceRegen(NaturalResource t)
	{
		if (naturalResources.TryGetValue(t, out var value))
		{
			PassiveStateModifier passiveStateModifier = new PassiveStateModifier(value);
			passiveResourceRegen[t] = passiveStateModifier;
			passiveResourceRegenList.Add(passiveStateModifier);
			passiveRegenListCount = passiveResourceRegenList.Count;
		}
	}

	private void AddPassiveIncome(BuildingType b, ItemType t)
	{
		if (inventory.TryGetValue(t, out var value))
		{
			PassiveStateModifier passiveStateModifier = new PassiveStateModifier(value);
			passiveStateModifier.tooltipEntity = EntityId.FromBuilding(b);
			passiveIncome[b] = passiveStateModifier;
		}
	}

	private void AddPassiveIncome(BuildingType b, NaturalResource t)
	{
		if (naturalResources.TryGetValue(t, out var value))
		{
			PassiveStateModifier passiveStateModifier = new PassiveStateModifier(value);
			passiveStateModifier.tooltipEntity = EntityId.FromBuilding(b);
			passiveIncome[b] = passiveStateModifier;
		}
	}

	private void AddResourceState(NaturalResourceDef resourceDef)
	{
		if ((resourceDef.exclusiveBiome == BiomeType.None || resourceDef.exclusiveBiome == biomeType) && !IsImpossibleInTown(resourceDef.requirements))
		{
			NaturalResource type = resourceDef.type;
			ResourceState resourceState = new ResourceState(resourceDef);
			naturalResources[type] = resourceState;
			resourceState.type = type;
			resourceState.parentTown = this;
		}
	}

	public void CalcUnassignedBuildings(BuildingState state)
	{
		state.CalcCapacity();
		state.numAvailable = state.totalProductionCapacity;
		foreach (StateManager dependentState in state.dependentStates)
		{
			state.numAvailable -= dependentState.numWorkersAssigned;
		}
	}

	private void CalcAllAvailableProductionCapacity()
	{
		ClearMetadataFlag(1048576);
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			building.Value.CalcCapacity();
			building.Value.numAvailable = building.Value.totalProductionCapacity;
		}
		foreach (StateManager activeStateManager in activeStateManagers)
		{
			if (activeStateManager.producingBuilding != null)
			{
				activeStateManager.producingBuilding.numAvailable -= activeStateManager.numWorkersAssigned;
			}
		}
	}

	public void CalcPostLoadMetadata()
	{
		LogInitValue(100);
		CalcTownLevelMetadata();
		cachedLevelProgress.ChangeValue(LevelWithProgress());
		foreach (ResourceState value in naturalResources.Values)
		{
			value.CalcBiomeUnlock();
		}
		foreach (TradingState value2 in trading.Values)
		{
			value2.cachedTradingSpecialty = DerivedTradingSpecialty(value2.itemType);
		}
		InitializeSettingLinks();
		CalcPostLoadTradingMetadata();
		CalcDynamicResearchAttributes();
	}

	public void CalcPostLoadTradingMetadata()
	{
		foreach (TradingState value in trading.Values)
		{
			value.CalcAppliedTradeMode();
			value.CalcActiveTradeMode();
			value.StoreItemStateCache();
		}
	}

	private void CalcDynamicResearchAttributes()
	{
		foreach (ResearchState value in research.Values)
		{
			value.StoreLeveledAttributes();
		}
	}

	private void CalcBuildingCosts()
	{
		ClearMetadataFlag(8);
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			building.Value.StoreNextConstructionCost();
		}
		if (this == gm.activeTown)
		{
			menu.combinedProductionPanel.arePanelCostsStale = true;
		}
	}

	public void CalcUpgradeCount()
	{
		cachedTotalUpgradeLevels = 0f;
		foreach (KeyValuePair<UpgradeType, Upgrade> upgrade in upgrades)
		{
			cachedTotalUpgradeLevels += LevelOfTownUpgrade(upgrade.Key);
		}
	}

	public void CalcBuildingCount()
	{
		totalBuildings = 0f;
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			totalBuildings += GameUtility.AsFloat(building.Value.currentCount);
		}
	}

	private void CalcHarvestSpeed()
	{
		foreach (KeyValuePair<HarvestRecipeType, HarvestState> item in harvesting)
		{
			item.Value.PerformCalcSpeed();
		}
	}

	private void CalcTradingSpeed()
	{
		ClearMetadataFlag(16384);
		foreach (KeyValuePair<ItemType, TradingState> item in trading)
		{
			item.Value.PerformCalcSpeed();
		}
	}

	private void CalcFarmingSpeed()
	{
		foreach (KeyValuePair<NaturalResource, FarmingState> farmingItem in farmingItems)
		{
			farmingItem.Value.PerformCalcSpeed();
		}
	}

	private void CalcMiningSpeed()
	{
		foreach (KeyValuePair<NaturalResource, MiningState> miningItem in miningItems)
		{
			miningItem.Value.PerformCalcSpeed();
		}
	}

	public float ValueForBuilding(BuildingType t)
	{
		return NumBuildingsOfType(t) * ValuePerBuilding(t);
	}

	public float MultiplierForBuilding(BuildingType t)
	{
		switch (t)
		{
		case BuildingType.SteamTrain:
		{
			float num = 0f;
			foreach (Town town in gm.towns)
			{
				if (town != null)
				{
					float num2 = town.NumBuildingsOfType(t) * town.BonusForBuilding(t);
					num += num2;
				}
			}
			return 1f + num;
		}
		case BuildingType.RiverHarbor:
			return GameUtility.AsTruncatedFloat(gm.wonderMultiplierHarbor);
		case BuildingType.MagicObelisk:
			return GameUtility.AsTruncatedFloat(gm.wonderMultiplierObelisk);
		case BuildingType.DesertBazaar:
			return GameUtility.AsTruncatedFloat(gm.wonderMultiplierBazaar);
		case BuildingType.SnowTreasureVault:
			return GameUtility.AsTruncatedFloat(gm.wonderMultiplierTreasureVault);
		default:
			return 1f + NumBuildingsOfType(t) * BonusForBuilding(t);
		}
	}

	public float MultiplierForResearch(ResearchType t)
	{
		if (research.TryGetValue(t, out var value))
		{
			return GameManager.MultiplierForResearch(value.type, value.numCompleted);
		}
		return 1f;
	}

	public float MultiplierForUpgrade(UpgradeType t)
	{
		if (upgrades.TryGetValue(t, out var value))
		{
			return value.GetMultiplier();
		}
		return 1f;
	}

	public float MultiplierForUpgrade(UpgradeType t, int level)
	{
		if (upgrades.TryGetValue(t, out var value))
		{
			return value.GetMultiplierForLevel(level);
		}
		return 1f;
	}

	public float ValuePerBuilding(BuildingType t)
	{
		return t switch
		{
			BuildingType.FloatingIsland => 20f, 
			BuildingType.Well => 2f * MultiplierForUpgrade(UpgradeType.WellEffectiveness), 
			_ => 0f, 
		};
	}

	public float BonusForBuilding(BuildingType t)
	{
		return t switch
		{
			BuildingType.Chute => 0.05f, 
			BuildingType.Tractor => 0.05f * MultiplierForResearch(ResearchType.ManaPowerTractors), 
			BuildingType.Factory => 0.05f * MultiplierForBuilding(BuildingType.MagicConveyorBelt), 
			BuildingType.Foundry => 0.25f, 
			BuildingType.Packager => 0.1f, 
			BuildingType.Airship => 0.25f, 
			BuildingType.MagicBoat => 0.25f, 
			BuildingType.MagicRailTile => 0.25f, 
			BuildingType.MagicConveyorBelt => 0.25f, 
			BuildingType.Minecart => 0.05f * MultiplierForBuilding(BuildingType.MagicRailTile), 
			BuildingType.SteamTrain => 0.05f * MultiplierForBuilding(BuildingType.MagicRailTile), 
			BuildingType.ManaTemple => 0.1f * MultiplierForUpgrade(UpgradeType.TempleEffectivenessMana), 
			BuildingType.FireTemple => 0.1f * MultiplierForUpgrade(UpgradeType.TempleEffectivenessFire), 
			BuildingType.WaterTemple => 0.1f * MultiplierForUpgrade(UpgradeType.TempleEffectivenessWater), 
			BuildingType.EarthTemple => 0.1f * MultiplierForUpgrade(UpgradeType.TempleEffectivenessEarth), 
			BuildingType.AirTemple => 0.1f * MultiplierForUpgrade(UpgradeType.TempleEffectivenessAir), 
			BuildingType.Caravan => 0.1f, 
			_ => 0f, 
		};
	}

	public void CalcPopulation()
	{
		ClearMetadataFlag(128);
		int housingPerkLevel = LevelOfPerk(PerkType.HousingCapacity);
		workerState.currentCount = PopulationForHousingCapacityPerkLevel(housingPerkLevel);
		workerState.currentCount += PopulationForCurrentTownLevel(townLevel);
		menu.townStatsPanel.isItemAvailabilityStale = true;
	}

	public double PopulationForCurrentTownLevel(int level)
	{
		return 0.0;
	}

	public double PopulationForHousingCapacityPerkLevel(int housingPerkLevel)
	{
		double num = 0.0;
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			float num2 = building.Value.HousingProvidedAtCount(GameUtility.AsFloat(building.Value.currentCount), housingPerkLevel);
			num += (double)num2;
		}
		return num + bonusWorkers;
	}

	public int LevelOfTownUpgrade(UpgradeType type)
	{
		if (upgrades.TryGetValue(type, out var value))
		{
			return value.numCompleted;
		}
		return 0;
	}

	public void CalcNaturalResourceCapacity()
	{
		ClearMetadataFlag(16);
		SetMetadataFlag(262144);
		foreach (ResourceState value in naturalResources.Values)
		{
			value.CalcCapacity();
		}
	}

	public float TownLevelResourceCapacityMultiplier()
	{
		return GameUtility.Poly(townLevel, 1f, 0.15f, 0.1f);
	}

	public float MultiplierForPerk(PerkType t)
	{
		if (Perk.IsGlobal(t))
		{
			return gm.MultiplierForGlobalPerk(t);
		}
		return gm.AdjustedMultiplierForPerkLevel(t, LevelOfPerk(t));
	}

	public int LevelOfPerk(PerkType type)
	{
		if (townPerks.TryGetValue(type, out var value))
		{
			return Mathf.RoundToInt(GameUtility.AsFloat(value.currentCount));
		}
		return gm.LevelOfGlobalPerk(type);
	}

	private void CalcResourceAvailability()
	{
		for (int i = 0; i < naturalResourceCache.Length; i++)
		{
			naturalResourceCache[i].CalcAvailability();
		}
	}

	public void CalcTradingAvailability()
	{
		foreach (KeyValuePair<ItemType, TradingState> item in trading)
		{
			item.Value.CalcAvailability();
		}
	}

	private void CalcHarvestAvailability()
	{
		foreach (KeyValuePair<HarvestRecipeType, HarvestState> item in harvesting)
		{
			item.Value.CalcAvailability();
		}
	}

	private void CalcPerkAvailability()
	{
		foreach (KeyValuePair<PerkType, PerkState> townPerk in townPerks)
		{
			townPerk.Value.CalcAvailability();
		}
	}

	private void CalcBuildingAvailability()
	{
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			building.Value.CalcAvailability();
		}
	}

	public void CalcMarketAvailability()
	{
		foreach (KeyValuePair<ItemType, SellState> marketItem in marketItems)
		{
			if (marketItem.Value.isLocked)
			{
				SellState value = marketItem.Value;
				CalcMarketAvailability(value);
			}
		}
	}

	public void CalcMarketAvailability(SellState m)
	{
		if ((m.IsTradeable() || IsProducedByAvailableRecipe(m.itemType) || IsProducedByAvailableNaturalResource(m.itemType)) && m.ShouldBeUnlocked())
		{
			m.Unlock();
		}
	}

	private void CalcItemAvailability()
	{
		for (int i = 0; i < inventoryCache.Length; i++)
		{
			ItemState itemState = inventoryCache[i];
			if (itemState.isLocked && itemState.ShouldBeUnlocked())
			{
				itemState.UnlockItem();
			}
		}
	}

	private bool IsProducedByAvailableNaturalResource(ItemType t)
	{
		foreach (KeyValuePair<HarvestRecipeType, HarvestState> item in harvesting)
		{
			if (!item.Value.isLocked && item.Value.harvestedItemState.type == t)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsProducedByAvailableRecipe(ItemType t)
	{
		for (int i = 0; i < recipeCache.Length; i++)
		{
			RecipeState recipeState = recipeCache[i];
			if (recipeState.isLocked)
			{
				continue;
			}
			foreach (ItemRateData item in recipeState.output)
			{
				if (item.state.AsEntity().TryAsItem(out var i2) && i2 == t)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void CalcBuildingCraftingSkills()
	{
		Dictionary<EntityId, Skill> dictionary = townSkills[SkillType.Crafting];
		Dictionary<EntityId, Skill> dictionary2 = townSkills[SkillType.Cultivation];
		Dictionary<EntityId, Skill> dictionary3 = townSkills[SkillType.Harvesting];
		Dictionary<EntityId, Skill> value;
		bool flag = townSkills.TryGetValue(SkillType.Prospecting, out value);
		foreach (KeyValuePair<BuildingType, BuildingState> building in buildings)
		{
			BuildingType key = building.Key;
			if (Crafting.cachedBuildingRecipes.TryGetValue(building.Key, out var value2))
			{
				foreach (RecipeType item in value2)
				{
					EntityId key2 = EntityId.FromRecipe(item);
					if (dictionary.TryGetValue(key2, out var value3))
					{
						AddBuildingSkill(key, value3);
					}
				}
			}
			foreach (HarvestDef value7 in Crafting.harvestRecipeCache.Values)
			{
				if (value7.producingBuildingType == building.Key)
				{
					EntityId key3 = EntityId.FromHarvestRecipe(value7.type);
					if (dictionary3.TryGetValue(key3, out var value4))
					{
						AddBuildingSkill(key, value4);
					}
				}
			}
			List<NaturalResource> list = Crafting.NaturalResourcesFarmedByBuilding(key);
			if (list == null)
			{
				continue;
			}
			foreach (NaturalResource item2 in list)
			{
				EntityId key4 = EntityId.FromNaturalResource(item2);
				if (dictionary2.TryGetValue(key4, out var value5))
				{
					AddBuildingSkill(key, value5);
				}
				if (flag && value.TryGetValue(key4, out var value6))
				{
					AddBuildingSkill(key, value6);
				}
			}
		}
	}

	public void CalcUpgradeCosts()
	{
		foreach (Upgrade value in upgrades.Values)
		{
			value.StoreCurrentLevelCost();
		}
	}

	public void PostProcessLoad()
	{
		bool flag = false;
		foreach (Upgrade value26 in upgrades.Values)
		{
			value26.StoreCurrentLevelCost();
			if (!flag && value26.numCompleted > 0)
			{
				if (gm.globalQuests.TryGetValue(QuestType.ResearchForUpgrades, out var value))
				{
					value.availability = BuildObjectAvailability.Completed;
				}
				flag = true;
			}
		}
		if (SaveFile.levelOfLegacyPerkEfficiency > 0f && upgrades.TryGetValue(UpgradeType.UpgradeEfficiency, out var value2))
		{
			value2.numCompleted = Mathf.RoundToInt(SaveFile.levelOfLegacyPerkEfficiency);
		}
		if (biomeType != BiomeType.River)
		{
			if (buildings.TryGetValue(BuildingType.Fishery, out var value3))
			{
				value3.currentCount = 0.0;
			}
			if (research.TryGetValue(ResearchType.Fishery, out var value4))
			{
				value4.numCompleted = 0;
			}
		}
		if (NumBuildingsOfType(BuildingType.Reservoir) > 0f && !IsCompleted(ResearchType.Reservoir))
		{
			IncrementResearch(ResearchType.Reservoir);
		}
		if (NumBuildingsOfType(BuildingType.Barrel) > 0f && !IsCompleted(ResearchType.Barrel))
		{
			IncrementResearch(ResearchType.Barrel);
		}
		if (NumBuildingsOfType(BuildingType.Market) > 0f && !GameManager.IsGlobalQuestComplete(QuestType.GrainForFoodMarket) && gm.globalQuests.TryGetValue(QuestType.GrainForFoodMarket, out var value5))
		{
			value5.availability = BuildObjectAvailability.Completed;
		}
		if (NumBuildingsOfType(BuildingType.Stockpile) > 0f && !GameManager.IsGlobalQuestComplete(QuestType.HarvestItemsForStockpile) && gm.globalQuests.TryGetValue(QuestType.HarvestItemsForStockpile, out var value6))
		{
			value6.availability = BuildObjectAvailability.Completed;
		}
		if (gm.lastSaveVersion < 1)
		{
			int num = 0;
			foreach (KeyValuePair<PerkType, PerkState> townPerk in townPerks)
			{
				num += TryRevertPerk(townPerk.Key);
			}
			if (num > 0)
			{
				bonusPrestigePoints = num;
			}
		}
		if (gm.lastSaveVersion < 2)
		{
			int numCompleted = LevelOfTownUpgrade(UpgradeType.HouseCapacity);
			if (upgrades.TryGetValue(UpgradeType.HarvesterHutProficiency, out var value7))
			{
				value7.SetNumCompleted(numCompleted);
				float num2 = 0f;
				foreach (HarvestState value27 in harvesting.Values)
				{
					num2 += value27.numWorkersAssigned;
				}
				float num3 = (float)Data.DefaultHarvesterHutCapacity + MultiplierForUpgrade(UpgradeType.HarvesterHutProficiency);
				if (num3 > 0f)
				{
					float f = num2 / num3;
					buildings[BuildingType.HarvesterHut].currentCount = Mathf.Ceil(f);
					UnityEngine.Debug.Log("Migrating from game version " + gm.lastSaveVersion + " added harvester huts " + buildings[BuildingType.HarvesterHut].currentCount + " cap required " + num2 + " cap per building " + num3);
				}
			}
		}
		if (gm.lastSaveVersion < 3 && buildings.TryGetValue(BuildingType.HarvesterHut, out var value8))
		{
			value8.currentCount = Math.Ceiling(value8.currentCount);
		}
		if (gm.lastSaveVersion < 4 && buildings.TryGetValue(BuildingType.ChainsawTank, out var value9) && value9.currentCount > 0.0 && harvesting.TryGetValue(HarvestRecipeType.ChainsawTree, out var value10))
		{
			value9.CalcCapacity();
			value10.numWorkersAssigned = GameUtility.AsFloat(value9.totalProductionCapacity);
		}
		if (gm.lastSaveVersion < 6 && buildings.TryGetValue(BuildingType.FishingBoat, out var value11) && value11.currentCount > 0.0 && harvesting.TryGetValue(HarvestRecipeType.FishSource, out var value12))
		{
			value11.CalcCapacity();
			value12.numWorkersAssigned = GameUtility.AsFloat(value11.totalProductionCapacity);
		}
		if (gm.lastSaveVersion < 8 && marketItems.TryGetValue(ItemType.Omnistone, out var value13) && value13.numWorkersAssigned > 0f)
		{
			if (LevelOfTownUpgrade(UpgradeType.MarketConsumptionJewelryStore) > 0)
			{
				upgrades[UpgradeType.MarketConsumptionArcaneGoods].SetNumCompleted(LevelOfTownUpgrade(UpgradeType.MarketConsumptionJewelryStore));
			}
			if (LevelOfTownUpgrade(UpgradeType.JewelryStoreCapacity) > 0)
			{
				upgrades[UpgradeType.ArcaneStoreCapacity].SetNumCompleted(LevelOfTownUpgrade(UpgradeType.JewelryStoreCapacity));
			}
			if (LevelOfTownUpgrade(UpgradeType.OmniCapacityJewelryStore) > 0)
			{
				upgrades[UpgradeType.OmniCapacityArcaneStore].SetNumCompleted(LevelOfTownUpgrade(UpgradeType.OmniCapacityJewelryStore));
			}
			if (buildings.TryGetValue(BuildingType.ArcaneStore, out var value14))
			{
				int num4 = value14.WorkerCapacityPerBuilding();
				if ((float)num4 > 0f)
				{
					float num5 = Mathf.Ceil(value13.numWorkersAssigned / (float)num4);
					value14.currentCount = num5;
				}
			}
		}
		if (gm.lastSaveVersion < 9 && buildings.TryGetValue(BuildingType.ClothingStore, out var _))
		{
			AddBuildingsToMatchAssignedProduction(BuildingType.ClothingStore);
		}
		if (gm.lastSaveVersion < 10 && buildings.TryGetValue(BuildingType.Well, out var value16))
		{
			value16.CalcCapacity();
			if (farmingItems.TryGetValue(NaturalResource.WaterSource, out var value17))
			{
				value17.numWorkersAssigned = GameUtility.RoundToFloat(value16.totalProductionCapacity);
			}
		}
		if (gm.lastSaveVersion < 13)
		{
			int num6 = LevelOfTownUpgrade(UpgradeType.TempleEffectivenessMana);
			if (num6 > 0)
			{
				upgrades[UpgradeType.TempleEffectivenessFire].numCompleted = num6;
				upgrades[UpgradeType.TempleEffectivenessWater].numCompleted = num6;
				upgrades[UpgradeType.TempleEffectivenessEarth].numCompleted = num6;
				upgrades[UpgradeType.TempleEffectivenessAir].numCompleted = num6;
			}
		}
		if (gm.lastSaveVersion < 14)
		{
			if (!IsCompleted(ResearchType.MagicClothing) && (itemProductionStats[ItemType.MagicShirt].value > 0.0 || itemProductionStats[ItemType.MagicCloak].value > 0.0 || itemProductionStats[ItemType.MagicPants].value > 0.0 || itemProductionStats[ItemType.MagicHat].value > 0.0 || itemProductionStats[ItemType.MagicBoots].value > 0.0))
			{
				IncrementResearch(ResearchType.MagicClothing);
			}
			if (!IsCompleted(ResearchType.MagicJewelry) && (itemProductionStats[ItemType.MagicRing].value > 0.0 || itemProductionStats[ItemType.EnchantedFireRing].value > 0.0 || itemProductionStats[ItemType.EnchantedWaterRing].value > 0.0 || itemProductionStats[ItemType.EnchantedEarthNecklace].value > 0.0 || itemProductionStats[ItemType.EnchantedAirCrown].value > 0.0))
			{
				IncrementResearch(ResearchType.MagicJewelry);
			}
			CompleteQuestIfProduced(QuestType.SkillsForMagicRing, ItemType.MagicRing);
		}
		if (gm.lastSaveVersion < 20)
		{
			AddBuildingsToMatchAssignedProduction(BuildingType.HardwareStore);
		}
		if (gm.lastSaveVersion < 16)
		{
			CompleteQuestIfProduced(QuestType.PlanksForRefinedPlank, ItemType.RefinedPlank);
			CompleteQuestIfProduced(QuestType.FlourForAnimalFeed, ItemType.AnimalFeed);
			CompleteQuestIfProduced(QuestType.StoneBricksForRefinedStoneBricks, ItemType.RefinedStoneBrick);
			CompleteQuestIfProduced(QuestType.WoodAxeForPickaxe, ItemType.Pickaxe);
			CompleteQuestIfProduced(QuestType.IronIngotForWoodAxe, ItemType.WoodAxe);
			CompleteQuestIfProduced(QuestType.SkillsForRubyRing, ItemType.RubyRing);
			CompleteQuestIfProduced(QuestType.SkillsForSapphireRing, ItemType.SapphireRing);
			CompleteQuestIfProduced(QuestType.SkillsForAmethystNecklace, ItemType.AmethystNecklace);
			CompleteQuestIfProduced(QuestType.SkillsForTopazCrown, ItemType.TopazCrown);
			CompleteQuestIfProduced(QuestType.SkillsForNails, ItemType.Nails);
			CompleteQuestIfProduced(QuestType.SugarForRefinedSugar, ItemType.RefinedSugar);
			CompleteQuestIfProduced(QuestType.SkillsForCactusJam, ItemType.CactusJam);
		}
		if (gm.lastSaveVersion < 17)
		{
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestAmethyst, ItemType.PurpleAmethyst);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestSapphire, ItemType.BlueSapphire);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestAmethyst, ItemType.PurpleAmethyst);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestTopaz, ItemType.YellowTopaz);
		}
		if (gm.lastSaveVersion < 18)
		{
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestWater, ItemType.Water);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestIron, ItemType.IronOre);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestCoal, ItemType.Coal);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestCopper, ItemType.CopperOre);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestSilver, ItemType.SilverOre);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestGold, ItemType.GoldOre);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestCoal, ItemType.Coal);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestIron, ItemType.IronOre);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestCotton, ItemType.Cotton);
			CompleteQuestIfProduced(Quest.ResourceUnlockQuestApples, ItemType.Apple);
		}
		if (gm.lastSaveVersion < 19 && LevelOfResearch(ResearchType.GemMine) > 0)
		{
			CompleteResearchIfProduced(ResearchType.ManaMining, ItemType.Mana);
		}
		if (gm.lastSaveVersion < 21)
		{
			lastClaimedRewardLevel = townLevel;
		}
		if (gm.lastSaveVersion < 22)
		{
			if (buildings.TryGetValue(BuildingType.Aqueduct, out var value18) && harvesting.TryGetValue(HarvestRecipeType.AqueductHarvestWater, out var value19))
			{
				value18.CalcCapacity();
				value19.numWorkersAssigned = GameUtility.AsTruncatedFloat(value18.totalProductionCapacity);
				value18.numAvailable = 0.0;
			}
			if (buildings.TryGetValue(BuildingType.WaterWheel, out var value20) && recipes.TryGetValue(RecipeType.WaterWheelPower, out var value21))
			{
				value20.CalcCapacity();
				value21.numWorkersAssigned = GameUtility.AsTruncatedFloat(value20.totalProductionCapacity);
				value20.numAvailable = 0.0;
			}
			if (buildings.TryGetValue(BuildingType.SolarPanel, out var value22) && recipes.TryGetValue(RecipeType.SolarPanelPower, out var value23))
			{
				value22.CalcCapacity();
				value23.numWorkersAssigned = GameUtility.AsTruncatedFloat(value22.totalProductionCapacity);
				value22.numAvailable = 0.0;
			}
		}
		if (gm.lastSaveVersion < 23 && buildings.TryGetValue(BuildingType.ManaPipeline, out var value24))
		{
			value24.CalcCapacity();
			int num7 = value24.WorkerCapacityPerBuilding();
			double num8 = 0.0;
			foreach (TradingState value28 in trading.Values)
			{
				if (value28.producingBuilding == value24)
				{
					num8 += (double)value28.numWorkersAssigned;
				}
			}
			double num9 = num8 - value24.totalProductionCapacity;
			if (num9 > 0.0)
			{
				double num10 = Math.Ceiling(num9 / (double)num7);
				value24.currentCount += num10;
			}
			if (num8 > 0.0)
			{
				IncrementResearch(ResearchType.ManaPipe);
			}
		}
		if (gm.lastSaveVersion < 24)
		{
			CompleteQuestIfProduced(QuestType.ManaPipeForManaPipeline, BuildingType.ManaPipeline);
			if (buildings.TryGetValue(BuildingType.OmniPipeline, out var value25))
			{
				value25.CalcCapacity();
				int num11 = value25.WorkerCapacityPerBuilding();
				double num12 = 0.0;
				foreach (TradingState value29 in trading.Values)
				{
					if (value29.producingBuilding == value25)
					{
						num12 += (double)value29.numWorkersAssigned;
					}
				}
				double num13 = num12 - value25.totalProductionCapacity;
				if (num13 > 0.0)
				{
					double num14 = Math.Ceiling(num13 / (double)num11);
					value25.currentCount += num14;
				}
				if (num12 > 0.0)
				{
					IncrementResearch(ResearchType.OmniPipe);
				}
			}
			CompleteQuestIfProduced(QuestType.OmniPipeForOmniPipeline, BuildingType.OmniPipeline);
			CompleteQuestIfProduced(QuestType.CopperWireForPowerLines, BuildingType.PowerLine);
		}
		_ = gm.lastSaveVersion;
		_ = 25;
		if (gm.lastSaveVersion < 26)
		{
			CompleteQuestIfProduced(QuestType.SkillsForReinforcedPlank, ItemType.ReinforcedPlank);
			CompleteQuestIfProduced(QuestType.CopperSkillForWire, ItemType.CopperWire);
			CompleteQuestIfProduced(QuestType.SkillsForPaper, ItemType.Paper);
			CompleteQuestIfProduced(QuestType.RefinedStoneBricksForQuartz, ItemType.Quartz);
			CompleteQuestIfProduced(QuestType.HarvestCottonForTailorResearch, BuildingType.Tailor);
			CompleteQuestIfProduced(QuestType.SkillsForSteamPipe, ItemType.SteamPipe);
		}
		if (gm.lastSaveVersion < 27)
		{
			CompleteResearchIfProduced(ResearchType.MagicJewelry, ItemType.MagicRing);
			CompleteResearchIfProduced(ResearchType.MagicJewelry, ItemType.EnchantedFireRing);
			CompleteResearchIfProduced(ResearchType.MagicJewelry, ItemType.EnchantedEarthNecklace);
			CompleteResearchIfProduced(ResearchType.MagicJewelry, ItemType.EnchantedWaterRing);
			CompleteResearchIfProduced(ResearchType.MagicJewelry, ItemType.EnchantedAirCrown);
		}
		if (NumBuildingsOfType(BuildingType.GrainMill) > 0f && !IsCompleted(ResearchType.FoodMill))
		{
			IncrementResearch(ResearchType.FoodMill);
		}
		if (NumBuildingsOfType(BuildingType.StoneMason) > 0f && !IsCompleted(ResearchType.StoneMason))
		{
			IncrementResearch(ResearchType.StoneMason);
		}
		if (NumBuildingsOfType(BuildingType.Quarry) > 0f && !IsCompleted(ResearchType.Quarry))
		{
			IncrementResearch(ResearchType.Quarry);
		}
		if (NumBuildingsOfType(BuildingType.Forester) > 0f && !IsCompleted(ResearchType.Forestry))
		{
			IncrementResearch(ResearchType.Forestry);
		}
		if (IsCompleted(ResearchType.Pasture) && !IsCompleted(ResearchType.Farming))
		{
			IncrementResearch(ResearchType.Farming);
		}
		if (!IsCompleted(ResearchType.RefinedSugar_Disabled) && itemProductionStats[ItemType.RefinedSugar].value > 0.0)
		{
			IncrementResearch(ResearchType.RefinedSugar_Disabled);
		}
		if (HasFarmingSkill(NaturalResource.BerryBush) && !IsCompleted(ResearchType.BerryFarming))
		{
			IncrementResearch(ResearchType.BerryFarming);
		}
		if (HasFarmingSkill(NaturalResource.CarrotPlant) && !IsCompleted(ResearchType.CarrotFarming))
		{
			IncrementResearch(ResearchType.CarrotFarming);
		}
		if (HasFarmingSkill(NaturalResource.PotatoPlant) && !IsCompleted(ResearchType.PotatoFarming))
		{
			IncrementResearch(ResearchType.PotatoFarming);
		}
		if (HasFarmingSkill(NaturalResource.CottonPlant) && !IsCompleted(ResearchType.CottonFarming))
		{
			IncrementResearch(ResearchType.CottonFarming);
		}
		if (HasFarmingSkill(NaturalResource.TomatoPlant) && !IsCompleted(ResearchType.TomatoFarming))
		{
			IncrementResearch(ResearchType.TomatoFarming);
		}
		if (HasFarmingSkill(NaturalResource.AppleTree) && !IsCompleted(ResearchType.AppleFarming))
		{
			IncrementResearch(ResearchType.AppleFarming);
		}
		if (HasFarmingSkill(NaturalResource.PearTree) && !IsCompleted(ResearchType.PearFarming))
		{
			IncrementResearch(ResearchType.PearFarming);
		}
		if (HasFarmingSkill(NaturalResource.DragonFruitTree) && !IsCompleted(ResearchType.DragonfruitFarming))
		{
			IncrementResearch(ResearchType.DragonfruitFarming);
		}
		if (HasFarmingSkill(NaturalResource.CactusFruitTree) && !IsCompleted(ResearchType.CactusFarming))
		{
			IncrementResearch(ResearchType.CactusFarming);
		}
		if (HasFarmingSkill(NaturalResource.HerbBush) && !IsCompleted(ResearchType.HerbFarming))
		{
			IncrementResearch(ResearchType.HerbFarming);
		}
		if (HasFarmingSkill(NaturalResource.SugarCane) && !IsCompleted(ResearchType.SugarFarming))
		{
			IncrementResearch(ResearchType.SugarFarming);
		}
	}

	private void AddBuildingsToMatchAssignedProduction(BuildingType t)
	{
		if (!buildings.TryGetValue(t, out var value))
		{
			return;
		}
		int num = value.WorkerCapacityPerBuilding();
		value.CalcCapacity();
		float num2 = 0f;
		foreach (StateManager dependentState in value.dependentStates)
		{
			num2 += dependentState.numWorkersAssigned;
		}
		double num3 = value.totalProductionCapacity - (double)num2;
		if (num3 < 0.0)
		{
			float num4 = 0f - GameUtility.AsFloat(num3);
			UnityEngine.Debug.Log("Found negative capacity at store: " + t.ToString() + ":" + value.numAvailable);
			if ((float)num > 0f)
			{
				float num5 = Mathf.Ceil(num4 / (float)num);
				value.currentCount += num5;
			}
		}
	}

	private bool HasFarmingSkill(NaturalResource r)
	{
		if (farmingItems.TryGetValue(r, out var value))
		{
			return value.skill.level > 0;
		}
		return false;
	}

	public void PostProcessInitialMetadata()
	{
		if (gm.lastSaveVersion < 7 && workerState.numAvailable < 0.0)
		{
			bonusWorkers += 0.0 - workerState.numAvailable;
			SetMetadataFlag(32);
		}
		if (gm.lastSaveVersion < 8 && landState.numAvailable < 0.0)
		{
			bonusLand += 0.0 - landState.numAvailable;
			SetMetadataFlag(4);
		}
		if (gm.lastSaveVersion < 12)
		{
			DeriveTradingStates();
		}
		if (!gm.hasOpenedPerksPanel)
		{
			foreach (PerkState value in townPerks.Values)
			{
				if (value.currentCount > 0.0)
				{
					gm.hasOpenedPerksPanel = true;
					break;
				}
			}
		}
		if (!gm.hasOpenedResearchPanel)
		{
			foreach (ResearchState value2 in research.Values)
			{
				if (value2.availability == BuildObjectAvailability.Completed || value2.numWorkersAssigned > 0f)
				{
					gm.hasOpenedResearchPanel = true;
					break;
				}
			}
		}
		if (!gm.hasOpenedUpgradesPanel)
		{
			foreach (Upgrade value3 in upgrades.Values)
			{
				if (value3.numCompleted > 0)
				{
					gm.hasOpenedUpgradesPanel = true;
					break;
				}
			}
		}
		if (townPerkPointState.numAvailable < 0.0)
		{
			double num = 0.0 - townPerkPointState.numAvailable;
			UnityEngine.Debug.Log("Negative town perk points, granting an extra: " + num);
			townPerkPointState.currentCount += num;
			CalcUnassignedPerkPoints();
		}
		CalcBiomeUnavailability();
	}

	public void DeriveTradingStates()
	{
		foreach (KeyValuePair<Specialty, TradeSpecialtyConfig> tradeSpecialtyConfig in tradeSpecialtyConfigs)
		{
			Specialty key = tradeSpecialtyConfig.Key;
			TradeSpecialtyConfig value = tradeSpecialtyConfig.Value;
			TradeMode tradeMode = TradeMode.None;
			bool flag = true;
			foreach (TradingState value2 in trading.Values)
			{
				if (key == value2.cachedTradingSpecialty && !value2.isLocked)
				{
					if (flag)
					{
						flag = false;
						tradeMode = value2.localTradeMode;
					}
					else if (tradeMode != value2.localTradeMode)
					{
						tradeMode = TradeMode.None;
						break;
					}
				}
			}
			if (tradeMode != TradeMode.None)
			{
				value.tradingConfig.InitializeValue(tradeMode);
				foreach (TradingState value3 in trading.Values)
				{
					if (!value3.isLocked && value3.cachedTradingSpecialty == key)
					{
						value3.localSettings.tradingConfig.InitializeValue(TradeMode.None);
						value3.CalcAppliedTradeMode();
						value3.CalcActiveTradeMode();
					}
				}
			}
			MenuManager.Instance.combinedProductionPanel.isTradeModeStale = true;
		}
	}

	private void CompleteQuestIfProduced(QuestType q, BuildingType t)
	{
		if (!gm.globalQuests.TryGetValue(q, out var value) || value.availability == BuildObjectAvailability.Completed)
		{
			return;
		}
		foreach (Town town in gm.towns)
		{
			if (town != null && town.buildings.TryGetValue(t, out var value2) && value2.currentCount > 0.0)
			{
				value.availability = BuildObjectAvailability.Completed;
			}
		}
	}

	private void CompleteQuestIfProduced(QuestType q, ItemType t)
	{
		if (gm.globalQuests.TryGetValue(q, out var value) && value.availability != BuildObjectAvailability.Completed)
		{
			UnityEngine.Debug.Log("PostProcess: Test quest " + q.ToString() + " with item " + t.ToString() + " count " + itemProductionStats[t].value);
			if (itemProductionStats[t].value > 0.0)
			{
				value.availability = BuildObjectAvailability.Completed;
				UnityEngine.Debug.Log("PostProcess: Completing quest " + q.ToString() + " due to item already produced: " + t);
			}
		}
	}

	private void CompleteResearchIfProduced(ResearchType r, ItemType t)
	{
		if (research.TryGetValue(r, out var value) && value.numCompleted <= 0)
		{
			UnityEngine.Debug.Log("PostProcess: Test research " + r.ToString() + " with item " + t.ToString() + " count " + itemProductionStats[t].value);
			if (itemProductionStats[t].value > 0.0)
			{
				IncrementResearch(r);
				UnityEngine.Debug.Log("PostProcess: Completing research " + r.ToString() + " due to item already produced: " + t);
			}
		}
	}

	public void IncrementResearch(ResearchType t)
	{
		if (research.TryGetValue(t, out var value))
		{
			value.numCompleted++;
			if (value.numCompleted >= value.recipe.maxLevel)
			{
				value.availability = BuildObjectAvailability.Completed;
				value.parentTown.availableStateManagers.Remove(value);
			}
			else if (gm.gameState == GameState.InGame)
			{
				value.StoreLeveledAttributes();
			}
		}
	}

	public void CalcAllItemCapacity()
	{
		ClearMetadataFlag(512);
		foreach (KeyValuePair<ItemType, ItemState> item in inventory)
		{
			CalcItemCapacity(item.Key);
		}
	}

	public double StorageByBuildingType(BuildingType t)
	{
		if (!Data.IsBuildingEnabledDefault(t))
		{
			return 0.0;
		}
		if (buildings.TryGetValue(t, out var value))
		{
			return value.StorageProvidedPerBuilding() * NumBuildingsOfType(t);
		}
		return 0.0;
	}

	private void CalcLandCapacity()
	{
		float num = LandCapacityForLevel(lastClaimedRewardLevel);
		landState.maxCount = num;
		menu.townStatsPanel.isItemAvailabilityStale = true;
		ClearMetadataFlag(4);
		SetMetadataFlag(262144);
		isTownPerkValidityStale = true;
		gm.isGlobalPerkValidityStale = true;
	}

	private void CalcAllBuildingCapacity()
	{
		ClearMetadataFlag(4194304);
		foreach (BuildingState value in buildings.Values)
		{
			value.AssignMaxCapacity();
		}
	}

	private void CalcItemCapacity(ItemType t)
	{
		if (!inventory.TryGetValue(t, out var value) || !Crafting.cachedItemDefs.TryGetValue(t, out var _))
		{
			UnityEngine.Debug.LogError("Can't calc item capacity for " + t.ToString() + ", not in inventory or cached item defs");
		}
		else
		{
			value.CalcCapacity();
		}
	}

	public bool IsCompleted(ResearchType type)
	{
		if (research.TryGetValue(type, out var value))
		{
			return value.numCompleted > 0;
		}
		return false;
	}

	public float BaselineLandFromTownLevel(int lvl)
	{
		return GameUtility.Poly(lvl, 0f, 9f, 1f);
	}

	public static float LandMultiplierForTownLevel(int lvl)
	{
		return 1f + (float)lvl * 0.5f;
	}

	public float LandCapacityForLevel(int lvl)
	{
		int startingLandPerkLevel = GameManager.Instance.LevelOfGlobalPerk(PerkType.MoreStartingLand);
		int landCapacityPerkLevel = LevelOfPerk(PerkType.LandCapacity);
		return LandCapacityForLevel(lvl, startingLandPerkLevel, landCapacityPerkLevel);
	}

	public float DefaultStartingLand()
	{
		if (GameManager.Instance.gameModifierDifficulty == GameModifier.EasyMode)
		{
			return 50f;
		}
		if (GameManager.Instance.gameModifierDifficulty == GameModifier.HardMode)
		{
			return 20f;
		}
		return 25f;
	}

	public float LandCapacityForLevel(int lvl, int startingLandPerkLevel, int landCapacityPerkLevel)
	{
		float num = DefaultStartingLand() + gm.AdjustedMultiplierForPerkLevel(PerkType.MoreStartingLand, startingLandPerkLevel) + MultiplierForUpgrade(UpgradeType.Exploration);
		num *= LandMultiplierForTownLevel(lvl);
		num *= gm.AdjustedMultiplierForPerkLevel(PerkType.LandCapacity, landCapacityPerkLevel);
		num *= biomeLandMultiplier;
		num *= gm.wonderMultiplierObservatory;
		num += ValueForBuilding(BuildingType.FloatingIsland);
		num += GameUtility.AsFloat(bonusLand);
		if (num < 2.1474836E+09f)
		{
			return Mathf.RoundToInt(num);
		}
		return GameUtility.RoundToIntOrSigDigits(num);
	}

	public float DemandBonusForBuilding(BuildingType t)
	{
		UpgradeType upgradeType = DemandUpgradeForBuilding(t);
		if (upgradeType != UpgradeType.None)
		{
			return MultiplierForUpgrade(upgradeType);
		}
		return 0f;
	}

	public UpgradeType DemandUpgradeForBuilding(BuildingType t)
	{
		return t switch
		{
			BuildingType.Market => UpgradeType.MarketConsumptionFood, 
			BuildingType.GeneralGoods => UpgradeType.MarketConsumptionGeneralGoods, 
			BuildingType.ClothingStore => UpgradeType.MarketConsumptionClothing, 
			BuildingType.Apothecary => UpgradeType.MarketConsumptionMedicine, 
			BuildingType.FancyFoods => UpgradeType.MarketConsumptionGourmetFood, 
			BuildingType.JewelryStore => UpgradeType.MarketConsumptionJewelryStore, 
			BuildingType.ArcaneStore => UpgradeType.MarketConsumptionArcaneGoods, 
			BuildingType.HardwareStore => UpgradeType.MarketConsumptionHardwareStore, 
			BuildingType.Bookstore => UpgradeType.MarketConsumptionBookstore, 
			_ => UpgradeType.None, 
		};
	}

	public void OnBuildingCreated(BuildingType t, bool isGradual)
	{
		if (isGradual)
		{
			completedBuildingQueue.Add(t);
		}
		else
		{
			ProcessBuildingCountChanged(t);
			if (this == gm.activeTown)
			{
				OnBuildingModifiedInActiveTown(t);
			}
		}
		gm.OnBuildingModified(this, t);
		if (!isGradual)
		{
			gm.ProcessMetadataQueue();
		}
		AddLog(new LogEntry(EntityId.FromBuilding(t), 0, townIndex));
		if (gm.activeTown == this && !TimeManager.IsFastForwarding)
		{
			menu.queuedNotificationEntitiy = EntityId.FromBuilding(t);
		}
	}

	public void SetStaleFlagsForModifiedTownPerk(PerkType t)
	{
		switch (t)
		{
		case PerkType.SkillGainSpeed:
			CalcSkillSpeed();
			break;
		case PerkType.UpgradeEfficiency:
			menu.upgradesPanel.arePanelCostsStale = true;
			break;
		case PerkType.RemoveBiomeNegatives:
			SetMetadataFlag(1);
			break;
		case PerkType.StorageBoost:
			SetMetadataFlag(512);
			SetMetadataFlag(16);
			menu.isTooltipStale = true;
			break;
		case PerkType.CraftingSpeed:
		case PerkType.CultivationSpeed:
		case PerkType.ProspectingSpeed:
		case PerkType.HarvestingSpeed:
		case PerkType.KnowledgeSpeed:
			SetMetadataFlag(131072);
			break;
		case PerkType.ResearchSpeed:
			SetMetadataFlag(2);
			break;
		case PerkType.TownTradingSpeed:
			SetMetadataFlag(16384);
			break;
		case PerkType.ConstructionCost:
		case PerkType.ConstructionSpeed:
			SetMetadataFlag(8);
			break;
		case PerkType.MarketValue:
		case PerkType.SpecializationValue:
			SetMetadataFlag(2097152);
			break;
		case PerkType.LandCapacity:
			SetMetadataFlag(4);
			break;
		case PerkType.TownXPBoost:
			SetMetadataFlag(2228224);
			break;
		case PerkType.SpecializationDemand:
		case PerkType.GourmetFoodsDemand:
		case PerkType.BooksDemand:
		case PerkType.ConstructionDemand:
		case PerkType.HardwareDemand:
		case PerkType.JewelryDemand:
		case PerkType.ClothingDemand:
		case PerkType.MedicineDemand:
		case PerkType.MagicDemand:
		case PerkType.TownOmnistoneDemand:
			SetMetadataFlag(256);
			break;
		case PerkType.GourmetFoodsStoreSpeed:
		case PerkType.BookStoreSpeed:
		case PerkType.ConstructionStoreSpeed:
		case PerkType.HardwareStoreSpeed:
		case PerkType.JewelryStoreSpeed:
		case PerkType.ClothingStoreSpeed:
		case PerkType.MedicineStoreSpeed:
		case PerkType.MagicStoreSpeed:
			SetMetadataFlag(2097152);
			break;
		}
		gm.FlagAllBuildingDataStale();
		ProcessTownMetadataQueue();
		menu.worldPerksPanel.UpdateStaticDisplayForListItem(t);
		menu.worldPerksPanel.areCountsStale = true;
		menu.worldPerksPanel.isHeaderDataStale = true;
		menu.townPerksPanel.UpdateStaticDisplayForListItem(t);
		menu.townPerksPanel.areCountsStale = true;
		menu.townPerksPanel.isHeaderDataStale = true;
	}

	public Requirement GetCachedRequirement(RequirementId id)
	{
		if (id.isTargetingGlobalStat)
		{
			return gm.GetCachedWorldRequirement(id);
		}
		if (townRequirementCache.TryGetValue(id, out var value))
		{
			return value;
		}
		value = GetTownRequirement(id);
		townRequirementCache[id] = value;
		return value;
	}

	private Requirement GetTownRequirement(RequirementId id)
	{
		Requirement requirement = Requirement.FromId(id);
		requirement.StoreItemStateCache(this);
		return requirement;
	}

	public void AddIngredientRequirementsRecursive(ItemList inputs, List<Requirement> targetList, RecipeType debugRecipeType = RecipeType.None)
	{
		foreach (KeyValuePair<ItemType, double> item in inputs.items)
		{
			if (Crafting.derivedItemBuildingSources.TryGetValue(item.Key, out var value))
			{
				if (value.Count > 1)
				{
					continue;
				}
				foreach (BuildingType item2 in value)
				{
					if (!buildings.TryGetValue(item2, out var value2))
					{
						continue;
					}
					foreach (Requirement requirement in value2.unlockRequirements.requirements)
					{
						if (!targetList.Contains(requirement))
						{
							targetList.Add(requirement);
						}
					}
				}
			}
			if (0 == 0)
			{
				continue;
			}
			bool flag = true;
			if (!Crafting.derivedItemRecipeSources.TryGetValue(item.Key, out var value3) || value3.Count > 1)
			{
				continue;
			}
			foreach (RecipeType item3 in value3)
			{
				if (!recipes.TryGetValue(item3, out var value4))
				{
					continue;
				}
				foreach (RequirementId requirement2 in value4.recipe.requirements)
				{
					Requirement cachedRequirement = GetCachedRequirement(requirement2);
					if (targetList.Contains(cachedRequirement))
					{
					}
				}
				if (!flag)
				{
					AddIngredientRequirementsRecursive(value4.recipe.inputs, targetList);
				}
			}
		}
	}

	public void ResetTownPerks()
	{
		lastTownPerkResetTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		foreach (KeyValuePair<PerkType, PerkState> townPerk in townPerks)
		{
			townPerk.Value.Reset();
		}
		gm.RefreshAllMetadata();
	}

	public override string ToString()
	{
		return "Town " + townName + " " + biomeType;
	}

	public bool AllowPriority()
	{
		return GameManager.IsGlobalQuestComplete(Quest.UnlockPrioritization);
	}

	public static void CalcCombinedItemRateData(ConsumableState consumableState, Dictionary<BuildingState, BuildingRateData> target, List<ItemRateData> source)
	{
		foreach (BuildingRateData value2 in target.Values)
		{
			value2.ResetProduction();
			value2.state = consumableState;
			value2.displayedPotentialRate = 0.0;
			value2.displayedPercentPotential = 0f;
		}
		foreach (ItemRateData item in source)
		{
			BuildingState buildingState = null;
			if (item.parentState != null)
			{
				buildingState = item.parentState.producingBuilding;
			}
			if (buildingState != null)
			{
				if (!target.TryGetValue(buildingState, out var value))
				{
					value = (target[buildingState] = new BuildingRateData(consumableState, buildingState.type));
				}
				item.CalcDisplayedRates();
				value.displayedPotentialRate += item.displayedPotentialRate;
				value.actualFrameDelta += item.actualFrameDelta;
			}
		}
		foreach (BuildingRateData value3 in target.Values)
		{
			if (GameUtility.IsNotZero(value3.displayedPotentialRate) && GameUtility.IsNotZero(TimeManager.SimulationDelta))
			{
				double num = value3.actualFrameDelta / (double)TimeManager.SimulationDelta;
				value3.displayedPercentPotential = GameUtility.AsTruncatedFloat(num / value3.displayedPotentialRate);
			}
		}
	}

	public void CalcCombinedConsumptionData(ConsumableState cState)
	{
		CalcCombinedItemRateData(cState, combinedBuildingConsumptionData, cState.inputRequesters);
	}

	public void CalcCombinedProductionData(ConsumableState cState)
	{
		foreach (BuildingRateData value2 in combinedBuildingProductionData.Values)
		{
			value2.ResetProduction();
			value2.state = cState;
			value2.displayedPotentialRate = 0.0;
			value2.displayedPercentPotential = 0f;
		}
		foreach (ItemRateData outputRequester in cState.outputRequesters)
		{
			BuildingState buildingState = null;
			if (outputRequester.parentState != null)
			{
				buildingState = outputRequester.parentState.producingBuilding;
			}
			if (buildingState != null)
			{
				if (!combinedBuildingProductionData.TryGetValue(buildingState, out var value))
				{
					value = new BuildingRateData(cState, buildingState.type);
					combinedBuildingProductionData[buildingState] = value;
				}
				outputRequester.CalcDisplayedRates();
				value.displayedPotentialRate += outputRequester.displayedPotentialRate;
				value.actualFrameDelta += outputRequester.actualFrameDelta;
			}
		}
		foreach (BuildingRateData value3 in combinedBuildingProductionData.Values)
		{
			if (GameUtility.IsNotZero(value3.displayedPotentialRate) && GameUtility.IsNotZero(TimeManager.SimulationDelta))
			{
				double num = value3.actualFrameDelta / (double)TimeManager.SimulationDelta;
				value3.displayedPercentPotential = GameUtility.AsTruncatedFloat(num / value3.displayedPotentialRate);
			}
		}
	}

	private void CalcSkillStats()
	{
		foreach (KeyValuePair<SkillType, FloatProperty> townSkillStat in townSkillStats)
		{
			FloatProperty value = townSkillStat.Value;
			value.value = 0.0;
			if (!townSkills.TryGetValue(townSkillStat.Key, out var value2))
			{
				continue;
			}
			foreach (Skill value3 in value2.Values)
			{
				value.value += value3.experience.points;
			}
		}
	}

	public void AssignDefaultTrades()
	{
		foreach (TradeSpecialtyConfig value in tradeSpecialtyConfigs.Values)
		{
			if (value.specialty == Specialty.UniqueImport)
			{
				value.tradingConfig.InitializeValue(TradeMode.Import);
			}
			else if (value.specialty == Specialty.UniqueExport)
			{
				value.tradingConfig.InitializeValue(TradeMode.Export);
			}
			else
			{
				value.tradingConfig.InitializeValue(TradeMode.AutoTradeLocalBalance);
			}
		}
		foreach (TradingState value2 in trading.Values)
		{
			if (value2.producingBuilding != null && value2.producingBuilding.type != BuildingType.TradingPost && value2.producingBuilding.type != BuildingType.ManaPipeline)
			{
				value2.localSettings.tradingConfig.InitializeValue(TradeMode.AutoTradeLocalBalance);
			}
		}
	}

	public int TryRevertPerk(PerkType t)
	{
		if (townPerks.TryGetValue(t, out var value))
		{
			if (value.currentCount <= 0.0)
			{
				return 0;
			}
			float initialValue = 2f;
			int num = Convert.ToInt32(value.currentCount);
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				float num4 = GameUtility.ExponentGrowth(initialValue, i, 0.25f);
				if (num4 < 2.1474836E+09f)
				{
					num4 = Mathf.CeilToInt(num4);
				}
				int num5 = Convert.ToInt32(value.CostForUpgradingFromLevel(i));
				num2 += Convert.ToInt32(num4);
				num3 += num5;
			}
			return num3 - num2;
		}
		return 0;
	}

	public bool CanProspectItem(ItemType t)
	{
		NaturalResource key = Item.NaturalResourceFromItem(t);
		if (miningItems.TryGetValue(key, out var value))
		{
			return !value.isLocked;
		}
		return false;
	}

	public bool CanCultivateItem(ItemType t)
	{
		NaturalResource key = Item.NaturalResourceFromItem(t);
		if (farmingItems.TryGetValue(key, out var value))
		{
			return !value.isLocked;
		}
		return false;
	}

	private void LogInitValue(int next)
	{
		_ = townInitValue;
		townInitValue = next;
	}

	public void CalcDisplayStats()
	{
		for (int i = 0; i < consumableStates.Length; i++)
		{
			consumableStates[i].CalcDisplayStats();
		}
	}

	public float LevelWithProgress()
	{
		GameUtility.IsNearlyZero(levelUpCost);
		float num = GameUtility.AsTruncatedFloat(cachedTownXPState.currentCount / levelUpCost);
		return (float)townLevel + num;
	}

	public StateManager StateForEntity(EntityId id)
	{
		NaturalResource i;
		NaturalResource i2;
		HarvestRecipeType i3;
		RecipeType r;
		RecipeState value5;
		if (id.TryAsBuilding(out var b))
		{
			if (buildings.TryGetValue(b, out var value))
			{
				return value.constructionState;
			}
		}
		else if (id.TryAsFarming(out i))
		{
			if (farmingItems.TryGetValue(i, out var value2))
			{
				return value2;
			}
		}
		else if (id.TryAsMining(out i2))
		{
			if (miningItems.TryGetValue(i2, out var value3))
			{
				return value3;
			}
		}
		else if (id.TryAsHarvestRecipe(out i3))
		{
			if (harvesting.TryGetValue(i3, out var value4))
			{
				return value4;
			}
		}
		else if (id.TryAsRecipe(out r) && recipes.TryGetValue(r, out value5))
		{
			return value5;
		}
		return null;
	}

	public double WonderCapacity()
	{
		if (townLevel < 35)
		{
			return 0.0;
		}
		int num = townLevel - 35;
		int[] wonderCapacity = Data.WonderCapacity;
		if (num >= wonderCapacity.Length)
		{
			return double.MaxValue;
		}
		return wonderCapacity[num];
	}

	public Specialty DerivedTradingSpecialty(ItemType itemType)
	{
		if (Crafting.cachedItemDefs.TryGetValue(itemType, out var value))
		{
			Specialty result = value.specialty;
			switch (itemType)
			{
			case ItemType.PurifiedMana:
			case ItemType.PurifiedFire:
			case ItemType.PurifiedWater:
			case ItemType.PurifiedEarth:
			case ItemType.PurifiedAir:
				return Specialty.ElementalCrystals;
			case ItemType.ManaPower:
			case ItemType.UtilityElementalFirePower:
			case ItemType.UtilityElementalWaterPower:
			case ItemType.UtilityElementalAirPower:
			case ItemType.UtilityElementalEarthPower:
				return Specialty.ElementalPower;
			default:
				if (value.tradeBuilding != BuildingType.TradingPost)
				{
					return Specialty.None;
				}
				if (itemType != ItemType.Quartz)
				{
					NaturalResource naturalResource = Item.NaturalResourceFromItem(value.type);
					if (naturalResource != NaturalResource.None && Crafting.naturalResourceCache.TryGetValue(naturalResource, out var value2) && value2.exclusiveBiome != BiomeType.None)
					{
						if (value2.exclusiveBiome == biomeType)
						{
							return Specialty.UniqueExport;
						}
						return Specialty.UniqueImport;
					}
				}
				return result;
			}
		}
		return Specialty.None;
	}

	public static double PerkPointsForReachingLevel(int level)
	{
		float num = GameUtility.Poly(level, 1f, 1f, 0.05f, 0.01f);
		double a = num;
		if (num >= 100f)
		{
			a = Math.Round(num * 0.1f);
			return a * 10.0;
		}
		if (num >= 50f)
		{
			a = Math.Round(num * 0.2f);
			return a * 5.0;
		}
		if (num >= 10f)
		{
			a = Math.Round(num * 0.5f);
			return a * 2.0;
		}
		return Math.Round(a);
	}

	private double QuestCoinsForReachingLevel(int level)
	{
		switch (level)
		{
		case 5:
			return 5.0;
		case 10:
			return 10.0;
		case 15:
			return 20.0;
		case 20:
			return 30.0;
		case 25:
			return 40.0;
		case 30:
			return 60.0;
		case 35:
			return 80.0;
		case 40:
			return 100.0;
		case 45:
			return 150.0;
		case 50:
			return 200.0;
		default:
			if (level > 50)
			{
				return 50.0;
			}
			return 0.0;
		}
	}

	private void LoadRewardsForReachingLevel(int level)
	{
		double num = PerkPointsForReachingLevel(level);
		townPerkPointState.currentCount += num;
		EntityId item = EntityId.FromItem(ItemType.UtilityPrestigePoint);
		gm.levelUpRewards.Add((item, GameUtility.AsTruncatedInt(num)));
		double num2 = QuestCoinsForReachingLevel(level);
		if (num2 > 0.0)
		{
			gm.questCoinState.currentCount += num2;
			EntityId item2 = EntityId.FromItem(ItemType.UtilityQuestCoin);
			gm.levelUpRewards.Add((item2, GameUtility.AsTruncatedInt(num2)));
		}
		float num3 = LandCapacityForLevel(level);
		float num4 = LandCapacityForLevel(level - 1);
		EntityId item3 = EntityId.FromItem(ItemType.UtilityLand);
		gm.levelUpRewards.Add((item3, GameUtility.AsTruncatedInt(num3 - num4)));
		ItemType t = ItemType.YellowCoin;
		double num5 = (double)(level * 50) + Math.Pow(level, 2.0) * 50.0 + Math.Pow(level, 3.0) * 50.0;
		EntityId item4 = EntityId.FromItem(t);
		gm.levelUpRewards.Add((item4, GameUtility.AsTruncatedInt(num5)));
		EarnItem(t, num5);
		if (num2 <= 0.0 && inventory.TryGetValue(ItemType.RedCoin, out var value) && !value.isLocked)
		{
			ItemType t2 = ItemType.RedCoin;
			double num6 = (double)(level * 25) + Math.Pow(level, 2.0) * 25.0 + Math.Pow(level, 3.0) * 25.0;
			EntityId item5 = EntityId.FromItem(t2);
			gm.levelUpRewards.Add((item5, GameUtility.AsTruncatedInt(num6)));
			EarnItem(t2, num6);
		}
	}

	public void DebugRewards()
	{
		gm.BeginTrackingUnlocks();
		lastClaimedRewardLevel = 5;
		int num = 10;
		menu.levelUpRewardPanel.startLevel = lastClaimedRewardLevel;
		menu.levelUpRewardPanel.levelToDisplay = num;
		while (lastClaimedRewardLevel < num)
		{
			lastClaimedRewardLevel++;
			LoadRewardsForReachingLevel(lastClaimedRewardLevel);
		}
		gm.EndTrackingUnlocks();
	}

	public void ClaimLevelRewards()
	{
		gm.BeginTrackingUnlocks();
		gm.hasClaimedLevelRewards = true;
		menu.levelUpRewardPanel.startLevel = lastClaimedRewardLevel;
		menu.levelUpRewardPanel.levelToDisplay = townLevel;
		while (lastClaimedRewardLevel < townLevel)
		{
			lastClaimedRewardLevel++;
			LoadRewardsForReachingLevel(lastClaimedRewardLevel);
		}
		gm.EndTrackingUnlocks();
		SetMetadataFlag(4);
		CalcUnassignedPerkPoints();
		gm.CalcUnassignedQuestCoins();
		menu.worldPerksPanel.isHeaderDataStale = true;
		if (this == gm.activeTown)
		{
			menu.townPerksPanel.isHeaderDataStale = true;
		}
	}

	public HeaderCollapseManager ConfirmedCollapseManager(BuildingCategory category)
	{
		if (!categoryCollapseManagers.TryGetValue(category, out var value))
		{
			value = ((category != BuildingCategory.Trading) ? new HeaderCollapseManager() : MenuManager.Instance.tradingHeaderCollapseManager);
			categoryCollapseManagers[category] = value;
		}
		return value;
	}

	public void CalcNumResearchCompleted()
	{
		int num = 0;
		foreach (ResearchState value in research.Values)
		{
			num += value.numCompleted;
		}
		completedResearchStat.value = num;
	}

	public void AddLog(LogEntry e)
	{
		logEntries.Insert(0, e);
		newLogs.Add(e.logIndex);
		if (menu.logPanel.displayedTown == this)
		{
			menu.logPanel.isTownLayoutStale = true;
		}
		int num = 100;
		int num2 = logEntries.Count - num;
		if (num2 > 0)
		{
			logEntries.RemoveRange(num - 1, num2);
		}
	}

	public void PurchaseAllUpgradesInList(List<Upgrade> upgradeList)
	{
		gm.recentPurchasedUpgrades.Clear();
		foreach (ItemType upgradeCoinType in Crafting.upgradeCoinTypes)
		{
			int num = 0;
			Upgrade upgrade;
			do
			{
				upgrade = null;
				foreach (Upgrade upgrade2 in upgradeList)
				{
					if (upgrade2.displayAvailability == BuildObjectAvailability.Available && upgrade2.currentLevelAvailability && upgrade2.cachedCurrentCostItem.type == upgradeCoinType && (upgrade == null || !(upgrade2.cachedCurrentCostAmount > upgrade.cachedCurrentCostAmount)) && upgrade2.CanAffordCurrentLevel())
					{
						upgrade = upgrade2;
					}
				}
				if (upgrade != null)
				{
					gm.recentPurchasedUpgrades[upgrade.type] = upgrade.numCompleted + 1;
					GameManager.Instance.OnUpgradePurchased(upgrade, calcMetadata: false);
				}
				num++;
			}
			while (num <= 1000 && upgrade != null);
		}
		CalcUpgradeCount();
		if (gm.isGlobalItemCapacityStale)
		{
			gm.ProcessMetadataQueue();
		}
		else
		{
			ProcessTownMetadataQueue();
		}
		MenuManager.Instance.FlagAllAvailabilityStale();
		gm.FlagAllBuildingDataStale();
		MenuManager.Instance.rewardPanel.ShowRecentUpgradePurchases();
	}

	public void RepeatSimulation(List<StateManager> states)
	{
		int count = states.Count;
		for (int i = 0; i < count; i++)
		{
			states[count].Produce();
		}
	}

	public void IncrementAllStats()
	{
		foreach (ResourceState value in naturalResources.Values)
		{
			value.IncrementStats();
		}
		foreach (ItemState value2 in inventory.Values)
		{
			value2.IncrementStats();
		}
	}
}
