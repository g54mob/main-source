using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class GameManager
{
	[NonSerialized]
	public float numTowns;

	public const int NumPriorities = 3;

	public LevelStat minigameFarming;

	public LevelStat minigameMining;

	public LevelStat minigameWater;

	public LevelStat minigameResearch;

	public LevelStat minigameDice;

	public LevelStat minigameWood;

	public long lastSaveTimestamp;

	public long worldCreationTimestamp;

	public long lastGlobalPerkResetTimestamp;

	public long lastRewardClaimTimestamp;

	public long lastTownPerkResetTimestamp;

	public int lastSaveVersion;

	public int randomRewardSeed;

	public static bool debugSimulation;

	public Town activeTown;

	public static Town TownBeingLoaded;

	public static Town TownBeingProcessed;

	public static bool WorldBeingLoaded;

	public List<Town> towns = new List<Town>();

	[NonSerialized]
	public ConsumableState[] consumableStates;

	public readonly Dictionary<ItemType, ItemState> globalInventory = new Dictionary<ItemType, ItemState>(new ItemEqualityComparer());

	public readonly Dictionary<QuestType, Quest> globalQuests = new Dictionary<QuestType, Quest>(new QuestEqualityComparer());

	public readonly Dictionary<BiomeType, BiomeState> biomeStates = new Dictionary<BiomeType, BiomeState>(new BiomeEqualityComparer());

	public readonly Dictionary<ItemType, FloatProperty> globalProductionStats = new Dictionary<ItemType, FloatProperty>(new ItemEqualityComparer());

	public readonly IntProperty completedResearchStat = new IntProperty();

	public readonly PropertyItem<float> cachedMaxTownLevel = new PropertyItem<float>();

	public readonly PropertyItem<double> cachedMaxTownXP = new PropertyItem<double>();

	public readonly Dictionary<PerkType, PerkState> globalPerks = new Dictionary<PerkType, PerkState>(new PerkEqualityComparer());

	public readonly Dictionary<RequirementId, Requirement> worldRequirementCache = new Dictionary<RequirementId, Requirement>();

	public readonly Dictionary<BiomeType, PropertyItem<float>> biomeLevels = new Dictionary<BiomeType, PropertyItem<float>>(new BiomeEqualityComparer());

	public readonly Dictionary<BiomeType, PropertyItem<double>> biomeXPCounters = new Dictionary<BiomeType, PropertyItem<double>>(new BiomeEqualityComparer());

	public readonly Dictionary<BuildingType, FloatProperty> buildingCounts = new Dictionary<BuildingType, FloatProperty>(new BuildingEqualityComparer());

	public readonly Dictionary<ResearchType, FloatProperty> globalResearchStats = new Dictionary<ResearchType, FloatProperty>(new ResearchEqualityComparer());

	public readonly List<GameModifier> appliedModifiers = new List<GameModifier>();

	private static GameManager instance;

	public string loadErrorMessage;

	public static bool everythingUnlocked;

	public static bool everythingDisplayed;

	public static bool creativeMode;

	public static bool freeMode;

	public int activeTownIndex;

	public static GameState GameState;

	public const bool requireBuildingForUnlockedCultivation = false;

	public const bool requireBuildingForUnlockedOutputs = false;

	public const bool requireMarketForUnlockedSaleHeaders = false;

	public const bool requireMarketForUnlockedSaleItems = false;

	public const bool requireSchoolForUnlockedResearch = false;

	public const bool useLegacySellXP = false;

	public const bool doesTownLevelIncreaseDemand = true;

	public const bool useGlobalFlagForRequiredItem = true;

	public const bool useProspectingInputs = false;

	public const bool useBanks = false;

	public const bool areMineralsInfinite = false;

	public const bool areCoinsInfinite = true;

	public const bool useLargerIcons = true;

	public const bool useHappinessCurrency = true;

	public const bool ignoreOutputCapacity = false;

	public const bool isMineralCapacityInfinite = false;

	public const bool useSimplifiedDisplay = true;

	public const bool requireResourcesForRecipeIngredients = false;

	public const bool automaticallyLevelUpTowns = true;

	public const bool isFarmingUnlockedByHarvesting = false;

	public const bool capDisplayedUnitProgress = true;

	public const bool enableMinigames = false;

	public const bool areBuildingsInstant = true;

	public const bool areBuildingCostsPaidUpfront = false;

	public const bool revertRailDepot = true;

	public const bool isTradingWithCapitalCity = true;

	public const bool useTownResets = false;

	public const bool arePrestigePointsGlobal = false;

	public const bool allowAutoRebalancing = true;

	public const bool useStaticRequesters = true;

	public const bool useWorkersPanel = false;

	public const bool useExplorationRecipe = false;

	public const bool useUpdatedPerkCosts = false;

	public const bool areWellsCultivation = true;

	public const bool useSolarCells = false;

	public const bool requireProducingBuilding = false;

	public const bool addPreviousLevelUpgradeRequirements = false;

	public const bool allowTradeRebalancing = false;

	public const bool isSandProspecting = true;

	public const bool sellingProducesXP = true;

	public const bool craftingProducesXP = true;

	public const bool usePauseRegion = false;

	public const bool allowGradualBuilding = true;

	public static bool DebugResetMethod;

	public static bool DebugRepeatSimulation;

	public const bool AllowOverflow = true;

	public const bool addCanvasElements = true;

	public static bool IsQuestAndAchievementProcessFrame;

	[NonSerialized]
	public bool hasOpenedExplorationPanel;

	[NonSerialized]
	public bool hasPerformedHarvest;

	[NonSerialized]
	public bool hasOpenedPerksPanel;

	[NonSerialized]
	public bool hasOpenedQuestCoinsPanel;

	[NonSerialized]
	public bool hasOpenedResearchPanel;

	[NonSerialized]
	public bool hasOpenedUpgradesPanel;

	[NonSerialized]
	public bool hasClaimedLevelRewards;

	[NonSerialized]
	public bool hasHarvestedResource;

	[NonSerialized]
	public bool isPromptingForHouse;

	[NonSerialized]
	public bool isPromptingForHarvesterHut;

	[NonSerialized]
	public bool hasCompletedHousePrompts;

	[NonSerialized]
	public bool hasCompletedHarvesterHutPrompts;

	private float numQuestCoinsAssigned;

	private float numPrestigePointsAssigned;

	private bool hasFlaggedExplore;

	public int numTownResets;

	public int numCompletedQuests;

	public int highestNumHousesPerTown;

	public int numResearchCompleted;

	public double numItemsCrafted;

	public double numCoinsEarned;

	public double maxTownXPRate;

	public double maxTreeHarvestRate;

	public int numInfiniteResearchCompleted;

	public int numTownsAtLevel10;

	public int numTownsAtLevel15;

	public int numTownsAtLevel20;

	public int numTownsAtLevel30;

	public int numTownsAtLevel40;

	public int numTownsAtLevel50;

	private int achievementTestIndex;

	private int numItemsAtMaxFulfillment;

	private int maxFulfillmentScore;

	private int numInventoryItemsUnlocked;

	private int numSellableItemsUnlocked;

	private int totalNumInventoryItems;

	private int totalNumSellableItems;

	private int townTestIndex;

	private float achievementTestCooldown;

	public double cumulativeXP;

	public CountableState timeTokenState;

	public CountableState questCoinState;

	public CountableState globalPrestigePointState;

	public EnergyTracker energyFarming;

	public EnergyTracker energyMining;

	public EnergyTracker energyWater;

	public EnergyTracker energyResearch;

	public EnergyTracker energyDice;

	public EnergyTracker energyWood;

	public bool isInitialized;

	public bool queueAutoSave;

	public bool isResearchMetadataStale;

	public bool isPanelAvailabilityStale;

	public bool isQuestAvailabilityStale;

	public bool isGlobalMetadataStale;

	public bool isQuestMetadataStale;

	public bool isGlobalItemCapacityStale;

	public bool hasProcessedItemSurplus;

	[NonSerialized]
	public bool isGlobalPerkValidityStale;

	[NonSerialized]
	public bool hasGlobalPerkAvailable;

	[NonSerialized]
	public int numQuestsReadyToClaim;

	[NonSerialized]
	public bool suppressPointerPanel;

	[NonSerialized]
	public ItemState[] globalInventoryCache;

	[NonSerialized]
	public readonly List<BiomeType> recentlyUnlockedBiomes = new List<BiomeType>();

	[NonSerialized]
	public readonly List<EntityLevel> recentlyUnlockedEntities = new List<EntityLevel>();

	[NonSerialized]
	public readonly List<EntityLevel> recentRewardResults = new List<EntityLevel>();

	[NonSerialized]
	public readonly Dictionary<UpgradeType, int> recentPurchasedUpgrades = new Dictionary<UpgradeType, int>(new UpgradeEqualityComparer());

	[NonSerialized]
	public readonly List<(EntityId, double)> levelUpRewards = new List<(EntityId, double)>();

	[NonSerialized]
	public readonly ItemList recentQuestRewards = new ItemList();

	[NonSerialized]
	public readonly Dictionary<ItemType, Town> specialtyCache = new Dictionary<ItemType, Town>(new ItemEqualityComparer());

	[NonSerialized]
	public Dictionary<NaturalResource, PropertyItem<bool>> globalResourceUnlockStates;

	public readonly Dictionary<ResearchType, int> offlineCompletedResearch = new Dictionary<ResearchType, int>(new ResearchEqualityComparer());

	[NonSerialized]
	public string overrideFileName;

	public int clickLevel;

	public double itemsGainedFromClicking;

	public double idleSecondsCollected;

	public int numRewardBoosts;

	public bool isUniversityMetadataStale;

	public bool isMonasteryMetadataStale;

	public bool isHarborMetadataStale;

	public bool isObservatoryMetadataStale;

	public bool isPyramidMetadataStale;

	public bool isBazaarMetadataStale;

	public bool isTreasureVaultMetadataStale;

	public bool isObeliskMetadataStale;

	public bool isGlobalUpgradePowerStale;

	public bool isBiomeAvailabilityStale;

	public bool isBuildingCountStale;

	public double wonderMultiplierUniversity;

	public double wonderMultiplierMonastery;

	public double wonderMultiplierHarbor;

	public float wonderMultiplierObservatory;

	public double wonderMultiplierPyramid;

	public float wonderMultiplierBazaar;

	public float wonderMultiplierTreasureVault;

	public float wonderMultiplierObelisk;

	public QuestType tutorialQuestType;

	public Quest primaryQuest;

	public Requirement primaryQuestRequirement;

	[NonSerialized]
	public bool isCreatingTown;

	public bool trackUnlocks;

	public int metadataSafetyCheckCount;

	public GameModifier gameModifierBiomes;

	public GameModifier gameModifierDifficulty;

	public GameModifier gameModifierPopulation;

	public bool isExtraIdle;

	public bool isExtraActive;

	public bool isTownStorageInfinite;

	public bool isTradingStorageInfinite;

	public bool isUsingExchangeTokens;

	public bool isLandInfinite;

	public bool isConsumptionInfinite;

	public bool arePerksPermanent;

	public bool isAutoAssignDefault;

	public bool isUnlockedBiomesMode;

	public static GameManager Instance => instance;

	public GameState gameState => GameState;

	private static MenuManager menu => MenuManager.Instance;

	public bool hasEarnedQuestCoin => questCoinState.currentCount > 0.0;

	public static void Init()
	{
		instance = new GameManager();
		instance.minigameFarming = new LevelStat(ItemType.UtilityMinigameExperiencePoint, 100f, 0.35f, 100f);
		instance.minigameFarming.localizationKey = "MinigameFarming";
		instance.minigameFarming.isRounded = true;
		instance.minigameWater = new LevelStat(ItemType.UtilityMinigameExperiencePoint, 100f, 0.35f, 100f);
		instance.minigameWater.localizationKey = "MinigameWater";
		instance.minigameWater.isRounded = true;
		instance.minigameMining = new LevelStat(ItemType.UtilityMinigameExperiencePoint, 100f, 0.35f, 100f);
		instance.minigameMining.localizationKey = "MinigameMining";
		instance.minigameMining.isRounded = true;
		instance.minigameResearch = new LevelStat(ItemType.UtilityMinigameExperiencePoint, 100f, 0.35f, 100f);
		instance.minigameResearch.localizationKey = "MinigameResearch";
		instance.minigameResearch.isRounded = true;
		instance.minigameDice = new LevelStat(ItemType.UtilityMinigameExperiencePoint, 100f, 0.35f, 100f);
		instance.minigameDice.localizationKey = "MinigameDice";
		instance.minigameDice.isRounded = true;
		instance.minigameWood = new LevelStat(ItemType.UtilityMinigameExperiencePoint, 100f, 0.35f, 100f);
		instance.minigameWood.localizationKey = "MinigameWood";
		instance.minigameWood.isRounded = true;
		instance.energyFarming = new EnergyTracker(ItemType.UtilityEnergyFarming);
		instance.energyDice = new EnergyTracker(ItemType.UtilityEnergyDice);
		instance.energyMining = new EnergyTracker(ItemType.UtilityEnergyMining);
		instance.energyResearch = new EnergyTracker(ItemType.UtilityEnergyResearch);
		instance.energyWater = new EnergyTracker(ItemType.UtilityEnergyWater);
		instance.energyWood = new EnergyTracker(ItemType.UtilityEnergyWood);
	}

	public void UpdateDynamicData()
	{
		if (isGlobalPerkValidityStale)
		{
			CalcGlobalPerkValidity();
		}
		foreach (Town town in towns)
		{
			town?.UpdateDynamicData();
		}
	}

	private void CalcGlobalPerkValidity()
	{
		foreach (PerkState value in globalPerks.Values)
		{
			value.CalcAddRemoveValidity();
		}
		isGlobalPerkValidityStale = false;
	}

	public void ConfirmTownIndex(int index)
	{
		while (towns.Count <= index)
		{
			towns.Add(null);
		}
	}

	public void Initialize()
	{
		timeTokenState = new CollectibleState(ItemType.TimeToken);
		questCoinState = new CollectibleState(ItemType.UtilityQuestCoin);
		questCoinState.maxCount = double.MaxValue;
		timeTokenState.maxCount = double.MaxValue;
		globalPrestigePointState = new CollectibleState(ItemType.UtilityPrestigePoint);
		globalResourceUnlockStates = new Dictionary<NaturalResource, PropertyItem<bool>>(new NaturalResourceEqualityComparer());
		instance.isInitialized = true;
	}

	public void InitializeGameStates()
	{
		WorldBeingLoaded = true;
		biomeStates.Clear();
		AddBiomeState(BiomeType.Plains);
		if (gameModifierBiomes != GameModifier.NoBiomes)
		{
			AddBiomeState(BiomeType.River);
			AddBiomeState(BiomeType.Forest);
			AddBiomeState(BiomeType.Mountains);
			AddBiomeState(BiomeType.Desert);
			AddBiomeState(BiomeType.Jungle);
			AddBiomeState(BiomeType.Snow);
			AddBiomeState(BiomeType.Magic);
		}
		globalResourceUnlockStates.Clear();
		foreach (NaturalResource key in Data.Instance.defaultNaturalResourceDefs.Keys)
		{
			globalResourceUnlockStates[key] = new PropertyItem<bool>();
		}
		globalInventory.Clear();
		foreach (EntityId item in Data.Instance.defaultDisplayCategories[BuildCategoryType.Item])
		{
			if (item.TryAsItem(out var i) && Crafting.cachedItemDefs.TryGetValue(i, out var value) && value.enabled)
			{
				AddGlobalInventory(i);
			}
		}
		globalInventoryCache = globalInventory.Values.ToArray();
		consumableStates = new ConsumableState[globalInventoryCache.Length];
		int num = 0;
		foreach (ItemState value2 in globalInventory.Values)
		{
			consumableStates[num] = value2;
			num++;
		}
		buildingCounts.Clear();
		globalResearchStats.Clear();
		foreach (ResearchType key2 in Crafting.researchCache.Keys)
		{
			globalResearchStats[key2] = new FloatProperty();
		}
		globalProductionStats.Clear();
		foreach (KeyValuePair<ItemType, ItemDef> cachedItemDef in Crafting.cachedItemDefs)
		{
			if (cachedItemDef.Value.enabled)
			{
				AddGlobalStat(cachedItemDef.Key);
			}
		}
		worldRequirementCache.Clear();
		globalPerks.Clear();
		foreach (PerkType globalPerk in Crafting.globalPerks)
		{
			AddGlobalPerk(globalPerk);
		}
		globalQuests.Clear();
		foreach (QuestDef value3 in Crafting.questCache.Values)
		{
			if (value3.questCategory == QuestCategory.MinigameUpgrades)
			{
				continue;
			}
			if (gameModifierBiomes == GameModifier.NoBiomes)
			{
				switch (value3.type)
				{
				case QuestType.SecondTownForTradingPost:
				case QuestType.MilestoneForestLevelForMountains:
				case QuestType.MilestoneDesertLevelForSnow:
				case QuestType.MilestoneMountainLevelForJungle:
				case QuestType.MilestoneJungleLevelForDesert:
				case QuestType.MilestoneSnowLevelForMagic:
				case QuestType.TradingPostForTradingPanel:
				case QuestType.MilestoneTownLevel15:
				case QuestType.TradingPostsForCaravan:
				case QuestType.IdleRewardsRiver:
				case QuestType.IdleRewardsForest:
				case QuestType.IdleRewardsMountians:
				case QuestType.IdleRewardsJungle:
				case QuestType.IdleRewardsDesert:
				case QuestType.IdleRewardsSnow:
				case QuestType.IdleRewardsMagic:
				case QuestType.MilestoneRiverLevelForForest:
					continue;
				}
			}
			if (isAutoAssignDefault)
			{
				if (value3.type == Quest.UnlockAutoBalance)
				{
					continue;
				}
				if (value3.type == QuestType.MilestoneTownLevel11)
				{
					value3.displayRequirement.Clear();
					value3.displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel9));
				}
			}
			Quest q = new Quest(value3, null);
			AddGlobalQuest(q);
		}
		CalcStaticStateMetadata();
		WorldBeingLoaded = false;
	}

	public void CalcStaticStateMetadata()
	{
		foreach (BiomeState value in biomeStates.Values)
		{
			value.StoreRequirementCache();
		}
		foreach (Quest value2 in globalQuests.Values)
		{
			value2.StoreRequirementCache();
		}
		foreach (KeyValuePair<PerkType, PerkState> globalPerk in globalPerks)
		{
			globalPerk.Value.StoreRequirementCache();
			globalPerk.Value.StoreItemStateCache();
		}
	}

	public void TestForGlobalQuestCompletion()
	{
		bool flag = false;
		numQuestsReadyToClaim = 0;
		foreach (Quest value in globalQuests.Values)
		{
			_ = value.type;
			if (value.availability != BuildObjectAvailability.Available || !value.IsReadyToClaim())
			{
				continue;
			}
			numQuestsReadyToClaim++;
			if (!value.hasTriggeredNotification)
			{
				value.hasTriggeredNotification = true;
				flag = true;
				Notification n = new Notification(TextDisplay.FormattedKeyValue("QuestComplete", TextDisplay.LabelForQuest(value.type)));
				MenuManager.Instance.PlayOrQueueTownLogNotification(n);
				MenuManager.Instance.SetQuestsStale();
				if (value.type == tutorialQuestType)
				{
					MenuManager.Instance.pointerDelayCounter = 0f;
				}
			}
		}
		if (flag)
		{
			SoundManager.PlayQuestReady();
		}
	}

	private void AddGlobalStat(ItemType t)
	{
		if (!globalProductionStats.ContainsKey(t))
		{
			globalProductionStats[t] = new FloatProperty();
		}
	}

	public void ResetGameMetadata()
	{
		minigameFarming.Reset();
		minigameMining.Reset();
		minigameResearch.Reset();
		minigameWater.Reset();
		minigameDice.Reset();
		minigameWood.Reset();
		primaryQuest = null;
		primaryQuestRequirement = null;
		hasProcessedItemSurplus = false;
		gameModifierBiomes = GameModifier.None;
		gameModifierDifficulty = GameModifier.None;
		gameModifierPopulation = GameModifier.None;
		suppressPointerPanel = false;
		isExtraIdle = false;
		isUnlockedBiomesMode = false;
		isExtraActive = false;
		isAutoAssignDefault = false;
		isTownStorageInfinite = false;
		isTradingStorageInfinite = false;
		isUsingExchangeTokens = false;
		isLandInfinite = false;
		isConsumptionInfinite = false;
		arePerksPermanent = false;
		if (null != menu)
		{
			menu.isHighlightingWorkerAssignment = false;
		}
		lastRewardClaimTimestamp = 0L;
		lastGlobalPerkResetTimestamp = 0L;
		lastTownPerkResetTimestamp = 0L;
		numRewardBoosts = 0;
		specialtyCache.Clear();
		clickLevel = 0;
		itemsGainedFromClicking = 0.0;
		idleSecondsCollected = 0.0;
		activeTown = null;
		towns.Clear();
		activeTownIndex = 0;
		completedResearchStat.value = 0;
		numTowns = 1f;
		numTownResets = 0;
		hasPerformedHarvest = false;
		hasCompletedHousePrompts = false;
		hasCompletedHarvesterHutPrompts = false;
		isPromptingForHouse = false;
		isPromptingForHarvesterHut = false;
		hasClaimedLevelRewards = false;
		isGlobalPerkValidityStale = true;
		hasOpenedPerksPanel = false;
		hasOpenedQuestCoinsPanel = false;
		hasOpenedResearchPanel = false;
		hasOpenedUpgradesPanel = false;
		numTownsAtLevel10 = 0;
		numTownsAtLevel15 = 0;
		numTownsAtLevel20 = 0;
		numTownsAtLevel30 = 0;
		numTownsAtLevel40 = 0;
		numTownsAtLevel50 = 0;
		appliedModifiers.Clear();
	}

	public void ResetGameState()
	{
		foreach (BiomeState value in biomeStates.Values)
		{
			value.Reset();
		}
		foreach (PropertyItem<bool> value2 in globalResourceUnlockStates.Values)
		{
			value2.InitializeValue(initialValue: false);
		}
		foreach (MinigamePanelParent minigamePanel in menu.minigamePanels)
		{
			minigamePanel.ResetMinigame();
		}
		timeTokenState.Reset();
		questCoinState.Reset();
		globalPrestigePointState.Reset();
		foreach (ItemState value3 in globalInventory.Values)
		{
			value3.Reset();
			value3.inputRequesters.Clear();
			value3.outputRequesters.Clear();
		}
		foreach (KeyValuePair<PerkType, PerkState> globalPerk in globalPerks)
		{
			globalPerk.Value.Reset();
		}
		foreach (KeyValuePair<QuestType, Quest> globalQuest in globalQuests)
		{
			globalQuest.Value.Reset();
		}
		foreach (FloatProperty value4 in globalProductionStats.Values)
		{
			value4.value = 0.0;
		}
		foreach (PropertyItem<float> value5 in biomeLevels.Values)
		{
			value5.InitializeValue(-1f);
		}
		foreach (PropertyItem<double> value6 in biomeXPCounters.Values)
		{
			value6.InitializeValue(0.0);
		}
		cachedMaxTownLevel.InitializeValue(0f);
		cachedMaxTownXP.InitializeValue(0.0);
		foreach (FloatProperty value7 in globalResearchStats.Values)
		{
			value7.value = 0.0;
		}
	}

	public void CalcNumTowns()
	{
		numTowns = 0f;
		foreach (Town town in towns)
		{
			if (town != null)
			{
				numTowns += 1f;
			}
		}
	}

	public void PrepareInitialTown(string townName)
	{
		Town town = new Town(BiomeType.Plains, 0);
		town.townName = townName;
		town.isCapitalCity = true;
		ConfirmTownIndex(0);
		towns[0] = town;
		town.townIndex = 0;
		activeTown = town;
		activeTownIndex = 0;
		activeTown.AssignDefaultTrades();
		town.CalcPostLoadMetadata();
		if (activeTown.buildings.TryGetValue(BuildingType.HarvesterHut, out var value))
		{
			value.AssignDefaultAutoAssign();
		}
	}

	public void AutoSave(bool showConfirmation = false)
	{
		queueAutoSave = false;
		FileManager.Save();
		if (showConfirmation)
		{
			MenuManager.Instance.ShowMessage("GameSaved".Localized());
		}
	}

	private void AddDependency(EntityId requiredEntity, EntityId unlockedEntity)
	{
	}

	public void PostProcessInitialMetadata()
	{
		foreach (Town town in towns)
		{
			town?.PostProcessInitialMetadata();
		}
		ProcessMetadataQueue();
		foreach (PerkState value in globalPerks.Values)
		{
			if (value.currentCount > 0.0)
			{
				hasOpenedQuestCoinsPanel = true;
			}
		}
		foreach (Quest value2 in globalQuests.Values)
		{
			if (value2.IsReadyToClaim())
			{
				value2.hasTriggeredNotification = true;
			}
		}
		if (questCoinState.numAvailable < 0.0)
		{
			double num = 0.0 - questCoinState.numAvailable;
			UnityEngine.Debug.Log("Negative quest coins points, granting an extra: " + num);
			questCoinState.currentCount += num;
			CalcUnassignedQuestCoins();
		}
		CalcGlobalResearchCompletedStat(alsoProcessTowns: true);
	}

	public void PostProcessLoad()
	{
		hasPerformedHarvest = IsGlobalQuestComplete(QuestType.WoodForHouse);
		if (worldCreationTimestamp == 0L)
		{
			worldCreationTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		}
		foreach (Town town in towns)
		{
			if (town == null)
			{
				continue;
			}
			town.PostProcessLoad();
			if (town.townLevel > 0)
			{
				switch (town.biomeType)
				{
				case BiomeType.River:
					ConfirmCompleteBiomeQuest(Quest.UnlockWorldPanel);
					break;
				case BiomeType.Forest:
					ConfirmCompleteBiomeQuest(QuestType.MilestoneRiverLevelForForest);
					break;
				case BiomeType.Mountains:
					ConfirmCompleteBiomeQuest(QuestType.MilestoneForestLevelForMountains);
					break;
				case BiomeType.Jungle:
					ConfirmCompleteBiomeQuest(QuestType.MilestoneMountainLevelForJungle);
					break;
				case BiomeType.Desert:
					ConfirmCompleteBiomeQuest(QuestType.MilestoneJungleLevelForDesert);
					break;
				case BiomeType.Snow:
					ConfirmCompleteBiomeQuest(QuestType.MilestoneDesertLevelForSnow);
					break;
				case BiomeType.Magic:
					ConfirmCompleteBiomeQuest(QuestType.MilestoneSnowLevelForMagic);
					break;
				}
			}
		}
		CompleteRecipeQuestIfItemAlreadyProduced(QuestType.SkillsForCloak, ItemType.Cloak);
		CompleteRecipeQuestIfItemAlreadyProduced(QuestType.SkillsForWarmCoat, ItemType.WarmCoat);
		CompleteRecipeQuestIfItemAlreadyProduced(QuestType.SkillsForCake, ItemType.Cake);
		CompleteRecipeQuestIfItemAlreadyProduced(QuestType.SkillsForShoe, ItemType.Shoe);
		CompleteRecipeQuestIfItemAlreadyProduced(QuestType.SkillsForDragonPunch, ItemType.DragonPunch);
		CompleteRecipeQuestIfItemAlreadyProduced(QuestType.SkillsForCopperRing, ItemType.CopperRing);
		CompleteRecipeQuestIfItemAlreadyProduced(QuestType.SkillsForFishOil, ItemType.FishOil);
		CompleteBuildingQuestIfBuildingAlreadyExists(QuestType.MilestoneHouses10, BuildingType.School);
		CompleteBuildingQuestIfBuildingAlreadyExists(QuestType.PaperForBookstore, BuildingType.Bookstore);
		CompleteBuildingQuestIfBuildingAlreadyExists(QuestType.WorkshopForHardwareStore, BuildingType.HardwareStore);
		CompleteBuildingQuestIfBuildingAlreadyExists(QuestType.TailorForClothingStore, BuildingType.ClothingStore);
		CompleteBuildingQuestIfBuildingAlreadyExists(QuestType.MedicineHutForHospital, BuildingType.Apothecary);
		CompleteBuildingQuestIfBuildingAlreadyExists(QuestType.JewelerForJewelryStore, BuildingType.JewelryStore);
		CompleteBuildingQuestIfBuildingAlreadyExists(QuestType.HarvestManaForArcaneEmporium, BuildingType.ArcaneStore);
		if (!IsGlobalQuestComplete(QuestType.HouseForHarvesterHut) && IsGlobalQuestComplete(QuestType.HarvesterHutForAssignWorkers))
		{
			instance.globalQuests[QuestType.HouseForHarvesterHut].SetAsComplete();
		}
		if (!IsGlobalQuestComplete(Quest.UnlockWorldPanel))
		{
			foreach (Town town2 in towns)
			{
				if (town2 != null && town2.biomeType != BiomeType.Plains && town2.cachedTownXPState.currentCount > 0.0)
				{
					if (instance.globalQuests.TryGetValue(Quest.UnlockWorldPanel, out var value))
					{
						value.SetAsComplete();
					}
					break;
				}
			}
		}
		if (lastSaveVersion < 25 && globalPerks.TryGetValue(PerkType.GlobalTradingCapacity, out var value2) && value2.currentCount > 1.0)
		{
			value2.currentCount = 1.0;
		}
	}

	private static void ConfirmCompleteBiomeQuest(QuestType t)
	{
		if (instance.globalQuests.TryGetValue(t, out var value) && value.availability != BuildObjectAvailability.Completed)
		{
			value.SetAsComplete();
		}
	}

	private void CompleteBuildingQuestIfBuildingAlreadyExists(QuestType questType, BuildingType testBuilding)
	{
		if (!globalQuests.TryGetValue(questType, out var value) || value.availability == BuildObjectAvailability.Completed)
		{
			return;
		}
		foreach (Town town in towns)
		{
			if (town != null && town.buildings.TryGetValue(testBuilding, out var value2) && value2.currentCount > 0.0)
			{
				value.SetAsComplete();
				break;
			}
		}
	}

	private void CompleteRecipeQuestIfItemAlreadyProduced(QuestType questType, ItemType t)
	{
		if (globalQuests.TryGetValue(questType, out var value) && value.availability != BuildObjectAvailability.Completed && globalProductionStats.TryGetValue(t, out var value2) && value2.value > 0.0)
		{
			value.SetAsComplete();
		}
	}

	public void FinalizeLoadedWorld()
	{
		PostProcessLoad();
		FinalizeLoadedTown();
		ApplyIdleTimeGain();
		PostProcessInitialMetadata();
		TimeManager.TriggerSimulation();
		menu.FinalizeWorldLoad();
		GameState = GameState.InGame;
		TimeManager.timeSinceAutosave = 0f;
	}

	public void FinalizeNewWorld()
	{
		foreach (MinigamePanelParent minigamePanel in menu.minigamePanels)
		{
			minigamePanel.ConfigureAsNewGame();
		}
		FinalizeLoadedTown();
		energyFarming.Fill();
		energyDice.Fill();
		energyMining.Fill();
		energyWater.Fill();
		energyResearch.Fill();
		energyWood.Fill();
		activeTown.FillResourcesToMax();
		menu.researchPanel.headerCollapseManager.SetMinimized(EntityId.FromGeneric(2).GetHashCode());
		menu.researchPanel.headerCollapseManager.SetMinimized(EntityId.FromGeneric(3).GetHashCode());
		menu.inventoryPanel.columnMode = 1;
		menu.FinalizeWorldLoad();
		MenuManager.Instance.navigationPanel.SelectPanel(MenuPanelType.All);
		GameState = GameState.InGame;
		TimeManager.timeSinceAutosave = 0f;
	}

	public void FinalizeLoadedTown()
	{
		menu.SetLoadedTownAsDisplayedTown();
		CalcBiomeLevels();
		CalcResearchLevels();
		CalcNumTowns();
		menu.combinedProductionPanel.ReloadItemFiltersForActiveTown();
		RefreshAllMetadata();
		CalcGlobalQuestFlags();
		ColorManager.activeBiomeColor = ColorManager.ColorForBiome(activeTown.biomeType);
		MenuManager.Instance.ApplyBiomeColors();
		CheckAllAchievements();
		menu.ApplyLoadedTownStateToMenus();
	}

	[Conditional("UNITY_EDITOR")]
	private void SelectDefaultEditorObjects()
	{
		if (overrideFileName == "screenshotMining")
		{
			menu.minigamePanelMining.Show();
		}
	}

	private void ApplyIdleTimeGain()
	{
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - lastSaveTimestamp;
		if (!isExtraActive)
		{
			ProcessTimeDiff((int)num);
			return;
		}
		Notification n = new Notification("WelcomeBack".Localized(), IconManager.Instance.friendFace64, null, null);
		menu.townStatsPanel.townLogItem.DisplayNotification(n);
	}

	public void ProcessTimeDiff(int totalDiff)
	{
		TimeManager.totalOfflineSeconds = totalDiff;
		float num = totalDiff;
		TimeManager.totalEarnedSeconds = Mathf.RoundToInt(num);
		idleSecondsCollected += num;
		num *= 0.25f;
		offlineCompletedResearch.Clear();
		Mathf.RoundToInt(num);
		EarnTimeTokenSeconds(totalDiff);
		MenuManager.Instance.rewardPanel.ShowTimeTokens(totalDiff);
		Notification n = new Notification("WelcomeBack".Localized(), IconManager.Instance.friendFace64, IconManager.Instance.productionTime, null);
		menu.townStatsPanel.townLogItem.DisplayNotification(n);
	}

	public void OnFastForwardCompleted()
	{
		menu.idleProgressPanel.SetReadyToConfirm();
		CheckAchievement(AchievementType.IdleTime1);
	}

	private void LogDiff(ItemType t, ItemList before, ItemList after)
	{
		before.Count(t);
		after.Count(t);
	}

	private void CalcEnergyCapacity()
	{
		CalcEnergyCapacity(energyFarming);
		CalcEnergyCapacity(energyWater);
		CalcEnergyCapacity(energyMining);
		CalcEnergyCapacity(energyResearch);
		CalcEnergyCapacity(energyDice);
		CalcEnergyCapacity(energyWood);
	}

	private void CalcEnergyCapacity(EnergyTracker tracker, LevelStat levelStat, UpgradeType amountUpgrade)
	{
		float num = 50f;
		if (amountUpgrade != UpgradeType.None)
		{
			num *= MultiplierForGlobalUpgrade(amountUpgrade);
		}
		tracker.maxCount = GameUtility.ExponentGrowth(num, levelStat.level, 0.1f);
	}

	private void CalcEnergyRegen(EnergyTracker tracker, LevelStat levelStat, UpgradeType amountUpgrade)
	{
		float initialValue = 0.032f;
		if (tracker == energyFarming)
		{
			initialValue = 0.1f;
		}
		if (amountUpgrade != UpgradeType.None)
		{
			initialValue = MultiplierForGlobalUpgrade(amountUpgrade);
		}
		tracker.energyPerSecond = GameUtility.ExponentGrowth(initialValue, levelStat.level, 0.1f);
	}

	private void CalcEnergyCapacity(EnergyTracker tracker)
	{
		if (tracker == energyFarming)
		{
			CalcEnergyCapacity(tracker, minigameFarming, UpgradeType.MinigameFarmingEnergyMax);
			CalcEnergyRegen(tracker, minigameFarming, UpgradeType.MinigameFarmingEnergyRate);
		}
		else if (tracker == energyMining)
		{
			CalcEnergyCapacity(tracker, minigameMining, UpgradeType.MinigameMiningEnergyMax);
			CalcEnergyRegen(tracker, minigameMining, UpgradeType.MinigameMiningEnergyRate);
		}
		else if (tracker == energyWater)
		{
			CalcEnergyCapacity(tracker, minigameWater, UpgradeType.MinigameWaterEnergyMax);
			CalcEnergyRegen(tracker, minigameWater, UpgradeType.MinigameWaterEnergyRate);
		}
		else if (tracker == energyResearch)
		{
			CalcEnergyCapacity(tracker, minigameResearch, UpgradeType.MinigameResearchEnergyMax);
			CalcEnergyRegen(tracker, minigameResearch, UpgradeType.MinigameResearchEnergyRate);
		}
		else if (tracker == energyDice)
		{
			CalcEnergyCapacity(tracker, minigameDice, UpgradeType.MinigameDiceEnergyMax);
			CalcEnergyRegen(tracker, minigameDice, UpgradeType.MinigameDiceEnergyRate);
		}
		else if (tracker == energyWood)
		{
			CalcEnergyCapacity(tracker, minigameWood, UpgradeType.MinigameWoodEnergyMax);
			CalcEnergyRegen(tracker, minigameWood, UpgradeType.MinigameWoodEnergyRate);
		}
		else
		{
			tracker.maxCount = 100.0;
			tracker.energyPerSecond = 1f;
		}
	}

	private void CalcGlobalQuestMetadata()
	{
		numCompletedQuests = 0;
		foreach (Quest value in globalQuests.Values)
		{
			if (value.availability == BuildObjectAvailability.Completed)
			{
				numCompletedQuests++;
			}
		}
	}

	private void CalcBiomeAvailability()
	{
		isBiomeAvailabilityStale = false;
		foreach (BiomeState value in biomeStates.Values)
		{
			if (value.isLocked && value.ShouldBeAvailable())
			{
				value.Unlock();
			}
		}
	}

	private void CalcGlobalPerkAvailability()
	{
		foreach (KeyValuePair<PerkType, PerkState> globalPerk in globalPerks)
		{
			globalPerk.Value.CalcAvailability();
		}
	}

	public void UnlockOutputsOfRecipe(RecipeState modifiedRecipe)
	{
		foreach (ItemRateData item in modifiedRecipe.input)
		{
			if (item.state is ItemState itemState)
			{
				itemState.UnlockItem();
			}
		}
		foreach (ItemRateData item2 in modifiedRecipe.output)
		{
			if (item2.state is ItemState itemState2)
			{
				if (modifiedRecipe.parentTown.marketItems.TryGetValue(itemState2.type, out var value))
				{
					modifiedRecipe.parentTown.CalcMarketAvailability(value);
				}
				if (modifiedRecipe.parentTown.trading.TryGetValue(itemState2.type, out var value2))
				{
					value2.Unlock();
				}
				itemState2.UnlockItem();
			}
		}
		menu.inventoryPanel.isTownLayoutStale = true;
		menu.inventoryPanelPopup.isTownLayoutStale = true;
		menu.coinPanel.isTownLayoutStale = true;
	}

	public void OnBuildingModified(Town town, BuildingType t)
	{
		town.CalcBuildingCount();
		town.SetStaleFlagsForModifiedLocalBuilding(t);
		CalcBuildingCount(t);
		if (Building.HasGlobalEffect(t))
		{
			foreach (Town town2 in towns)
			{
				town2?.SetStaleFlagsForModifiedBuilding(t);
			}
		}
		else
		{
			town.SetStaleFlagsForModifiedBuilding(t);
		}
		isQuestAvailabilityStale = true;
		isQuestMetadataStale = true;
		isPanelAvailabilityStale = true;
	}

	private void CalcResearchLevels()
	{
		foreach (ResearchType key in Crafting.researchCache.Keys)
		{
			if (!globalResearchStats.TryGetValue(key, out var value))
			{
				value = new FloatProperty();
				globalResearchStats[key] = value;
			}
			foreach (Town town in towns)
			{
				if (town != null)
				{
					int num = town.LevelOfResearch(key);
					if ((double)num > value.value)
					{
						value.value = num;
					}
				}
			}
		}
	}

	public void CalcBiomeXP()
	{
		cachedMaxTownXP.InitializeValue(0.0);
		foreach (Town town in towns)
		{
			if (town != null)
			{
				double num = town.cachedTownXPState.currentCount + town.spentXP + town.sacrificedXP;
				town.xpCountCache.ChangeValue(num);
				if (num > cachedMaxTownXP.value)
				{
					cachedMaxTownXP.ChangeValue(num);
				}
			}
		}
	}

	public void CalcBiomeLevels()
	{
		cachedMaxTownLevel.InitializeValue(0f);
		numTownsAtLevel10 = 0;
		numTownsAtLevel15 = 0;
		numTownsAtLevel20 = 0;
		numTownsAtLevel30 = 0;
		numTownsAtLevel40 = 0;
		numTownsAtLevel50 = 0;
		foreach (Town town in towns)
		{
			if (town == null)
			{
				continue;
			}
			float value = town.cachedLevelProgress.value;
			if (value > cachedMaxTownLevel.value)
			{
				cachedMaxTownLevel.ChangeValue(value);
			}
			if (town.townLevel >= 10)
			{
				numTownsAtLevel10++;
			}
			if (town.townLevel >= 15)
			{
				numTownsAtLevel15++;
			}
			if (town.townLevel >= 20)
			{
				numTownsAtLevel20++;
			}
			if (town.townLevel >= 30)
			{
				numTownsAtLevel30++;
			}
			if (town.townLevel >= 40)
			{
				numTownsAtLevel40++;
			}
			if (town.townLevel >= 50)
			{
				numTownsAtLevel50++;
			}
			if (!Crafting.biomeCache.TryGetValue(town.biomeType, out var value2))
			{
				continue;
			}
			foreach (ResearchType item in value2.autoCompletedResearch)
			{
				if (town.LevelOfResearch(item) == 0)
				{
					town.IncrementResearch(item);
				}
			}
		}
		Platform.Instance.SetStat(StatType.MaxTownLevel, Mathf.FloorToInt(cachedMaxTownLevel.value));
		Platform.Instance.SetStat(StatType.TownsAtLevel10, numTownsAtLevel10);
		Platform.Instance.SetStat(StatType.TownsAtLevel20, numTownsAtLevel20);
		Platform.Instance.SetStat(StatType.TownsAtLevel30, numTownsAtLevel30);
		Platform.Instance.SetStat(StatType.TownsAtLevel40, numTownsAtLevel40);
		Platform.Instance.SetStat(StatType.TownsAtLevel50, numTownsAtLevel50);
		Platform.Instance.SetStat(StatType.NumCities, numTownsAtLevel15);
	}

	public void CalcMetadata()
	{
		isGlobalMetadataStale = false;
		CalcTimeTokenMax();
		CalcGlobalPerkCosts();
		CalcGlobalPerkAvailability();
		CalcCumulativeXP();
		CalcGlobalQuestMetadata();
		CalcUnassignedQuestCoins();
		CalcGlobalItemCapacity();
		hasHarvestedResource = activeTown.HasHarvestedResource();
		CalcGlobalItemAvailability();
		CalcNumItemsUnlocked();
	}

	private void CalcGlobalUpgradePower()
	{
		isGlobalUpgradePowerStale = false;
	}

	private void CalcGlobalPerkCosts()
	{
		foreach (KeyValuePair<PerkType, PerkState> globalPerk in globalPerks)
		{
			globalPerk.Value.CalcCost();
		}
	}

	public void CalcGlobalItemCapacity()
	{
		isGlobalItemCapacityStale = false;
		questCoinState.maxCount = double.MaxValue;
		globalPrestigePointState.maxCount = double.MaxValue;
		foreach (KeyValuePair<ItemType, ItemState> item in globalInventory)
		{
			item.Value.CalcCapacity();
		}
	}

	private void CalcGlobalItemAvailability()
	{
		for (int i = 0; i < globalInventory.Count; i++)
		{
			ItemState itemState = globalInventoryCache[i];
			if (itemState.isLocked && itemState.ShouldBeGloballyUnlocked())
			{
				itemState.UnlockItem();
				if (gameState == GameState.InGame)
				{
					EntityId id = EntityId.FromItem(itemState.type);
					recentlyUnlockedEntities.Add(new EntityLevel(id, 0));
				}
			}
		}
	}

	public void CalcUnassignedQuestCoins()
	{
		questCoinState.numAvailable = questCoinState.currentCount;
		numQuestCoinsAssigned = 0f;
		foreach (PerkState value in globalPerks.Values)
		{
			float num = value.TotalCostToReachCurrentLevel();
			numQuestCoinsAssigned += num;
		}
		questCoinState.numAvailable -= numQuestCoinsAssigned;
		foreach (Town town in towns)
		{
			if (town != null)
			{
				questCoinState.numAvailable += town.MultiplierForPerk(PerkType.ExtraQuestCoins);
			}
		}
		isGlobalPerkValidityStale = true;
		hasGlobalPerkAvailable = false;
		foreach (PerkState value2 in globalPerks.Values)
		{
			if (value2.CanAffordPerk())
			{
				hasGlobalPerkAvailable = true;
				break;
			}
		}
	}

	private ItemState AddGlobalInventory(ItemType t)
	{
		ItemState itemState = new ItemState();
		globalInventory[t] = itemState;
		itemState.type = t;
		return itemState;
	}

	private void AddGlobalQuest(Quest q)
	{
		if (q.rewardItems == null || q.rewardItems.Count(ItemType.UtilityQuestCoin) <= 0.0)
		{
			UnityEngine.Debug.LogWarning("NO Quest coin reward on global quest " + q.type.ToString() + " group " + q.questGroup);
		}
		if (q.questGroup != QuestGroup.Minigame && q.questGroup != QuestGroup.Primary)
		{
			_ = q.questGroup;
			_ = 2;
		}
		globalQuests[q.type] = q;
	}

	private void AddBiomeState(BiomeType t)
	{
		BiomeState biomeState = new BiomeState(t);
		biomeState.Reset();
		biomeStates[t] = biomeState;
		biomeLevels[t] = new PropertyItem<float>();
		biomeXPCounters[t] = new PropertyItem<double>();
	}

	private void AddGlobalPerk(PerkType t)
	{
		if ((t != PerkType.GlobalTradingCapacity || !isTradingStorageInfinite) && (t != PerkType.IdleGain || !isExtraActive) && ((t != PerkType.GoodsConsumption && t != PerkType.SpecializationDemand) || !isConsumptionInfinite))
		{
			PerkState value = new PerkState(Crafting.perkDefCache[t]);
			globalPerks[t] = value;
		}
	}

	public static bool CanPlayerAfford(ItemCount itemCount)
	{
		return CanPlayerAfford(itemCount.itemType, itemCount.count);
	}

	public static bool CanPlayerAfford(ItemType itemType, double count)
	{
		if (creativeMode)
		{
			return true;
		}
		if (Instance.activeTown.inventory.TryGetValue(itemType, out var value))
		{
			return value.currentCount >= count;
		}
		return false;
	}

	public static bool CanPlayerAfford(ItemList cost)
	{
		if (creativeMode)
		{
			return true;
		}
		foreach (KeyValuePair<ItemType, double> item in cost.items)
		{
			if (!CanPlayerAfford(new ItemCount(item.Key, item.Value)))
			{
				return false;
			}
		}
		return true;
	}

	private double WonderMultiplier(BuildingType t, double bonusValue)
	{
		float num = GlobalNumBuildingsOfType(t);
		return 1.0 / (1.0 + (double)num * bonusValue);
	}

	public void ProcessMetadataQueue()
	{
		if (isResearchMetadataStale)
		{
			ProcessCompletedResearchMetadata();
		}
		if (isUniversityMetadataStale)
		{
			isUniversityMetadataStale = false;
			wonderMultiplierUniversity = WonderMultiplier(BuildingType.PlainsUniversity, 0.10000000149011612);
			foreach (Town town in towns)
			{
				town?.CalcUpgradeCosts();
			}
			menu.upgradesPanel.arePanelCostsStale = true;
		}
		if (isMonasteryMetadataStale)
		{
			isMonasteryMetadataStale = false;
			wonderMultiplierMonastery = WonderMultiplier(BuildingType.ForestMonastery, 0.10000000149011612);
			foreach (Town town2 in towns)
			{
				town2?.SetMetadataFlag(2);
			}
		}
		if (isHarborMetadataStale)
		{
			isHarborMetadataStale = false;
			wonderMultiplierHarbor = 1f + 0.25f * GlobalNumBuildingsOfType(BuildingType.RiverHarbor);
			foreach (Town town3 in towns)
			{
				town3?.SetMetadataFlag(16384);
			}
		}
		if (isObservatoryMetadataStale)
		{
			isObservatoryMetadataStale = false;
			wonderMultiplierObservatory = 1f + 0.02f * GlobalNumBuildingsOfType(BuildingType.MountainObservatory);
			foreach (Town town4 in towns)
			{
				town4?.SetMetadataFlag(4);
			}
		}
		if (isPyramidMetadataStale)
		{
			isPyramidMetadataStale = false;
			wonderMultiplierPyramid = WonderMultiplier(BuildingType.JunglePyramid, 0.05000000074505806);
			foreach (Town town5 in towns)
			{
				town5?.SetMetadataFlag(8);
			}
		}
		if (isBazaarMetadataStale)
		{
			isBazaarMetadataStale = false;
			wonderMultiplierBazaar = 1f + 0.1f * GlobalNumBuildingsOfType(BuildingType.DesertBazaar);
			foreach (Town town6 in towns)
			{
				town6?.SetMetadataFlag(2097152);
			}
		}
		if (isTreasureVaultMetadataStale)
		{
			isTreasureVaultMetadataStale = false;
			wonderMultiplierTreasureVault = 1f + 0.1f * GlobalNumBuildingsOfType(BuildingType.SnowTreasureVault);
			foreach (Town town7 in towns)
			{
				town7?.SetMetadataFlag(2097152);
			}
		}
		if (isObeliskMetadataStale)
		{
			isObeliskMetadataStale = false;
			wonderMultiplierObelisk = 1f + 0.1f * GlobalNumBuildingsOfType(BuildingType.MagicObelisk);
			foreach (Town town8 in towns)
			{
				town8?.SetMetadataFlag(2228224);
			}
		}
		if (isGlobalUpgradePowerStale)
		{
			CalcGlobalUpgradePower();
		}
		if (isBiomeAvailabilityStale)
		{
			CalcBiomeAvailability();
		}
		foreach (Town town9 in towns)
		{
			town9?.ProcessTownMetadataQueue();
		}
		if (isBuildingCountStale)
		{
			CalcAllBuildingCounts();
		}
		if (isGlobalMetadataStale)
		{
			CalcMetadata();
		}
		if (isPanelAvailabilityStale)
		{
			menu.CalcPanelAvailability();
		}
		if (isQuestAvailabilityStale)
		{
			CalcGlobalQuestAvailability();
		}
		if (isQuestMetadataStale)
		{
			ProcessQuestMetadata();
		}
		if (isGlobalItemCapacityStale)
		{
			CalcGlobalItemCapacity();
		}
		metadataSafetyCheckCount++;
		if (metadataSafetyCheckCount > 10)
		{
			foreach (Town town10 in towns)
			{
				if (town10 != null)
				{
					for (int i = 0; i <= 23; i++)
					{
						int flag = 1 << i;
						town10.IsMetadataStale(flag);
					}
				}
			}
		}
		else if (IsAnyMetadataStale())
		{
			ProcessMetadataQueue();
		}
		if (trackUnlocks)
		{
			trackUnlocks = false;
		}
	}

	private bool IsAnyMetadataStale()
	{
		foreach (Town town in towns)
		{
			if (town != null && town.metadataFlags > 0)
			{
				return true;
			}
		}
		return false;
	}

	public void RepeatSimulation()
	{
		foreach (Town town in towns)
		{
			if (town == null)
			{
				continue;
			}
			TimeManager.isTestingRepeatCapacity = true;
			while (true)
			{
				foreach (BuildingState value in town.buildings.Values)
				{
					if (value.constructionState.numWorkersAssigned > 0f)
					{
						value.constructionState.RepeatLastSimulation();
					}
				}
				foreach (ResearchState value2 in town.research.Values)
				{
					if (value2.numWorkersAssigned > 0f)
					{
						value2.RepeatLastSimulation();
					}
				}
				if (!TimeManager.isTestingRepeatCapacity)
				{
					break;
				}
				TimeManager.isTestingRepeatCapacity = false;
			}
		}
		foreach (Town town2 in towns)
		{
			if (town2 != null)
			{
				for (int i = 0; i < town2.consumableStates.Length; i++)
				{
					town2.consumableStates[i].RepeatLastSimulation();
				}
				int count = town2.allTownSkillList.Count;
				for (int j = 0; j < count; j++)
				{
					Skill skill = town2.allTownSkillList[j];
					skill.Increment(skill.lastSkillGained * (double)TimeManager.repeatSimulationsToRun);
				}
			}
		}
		for (int k = 0; k < consumableStates.Length; k++)
		{
			consumableStates[k].RepeatLastSimulation();
		}
		PerformSimulationSummary();
	}

	public void UpdateSimulation()
	{
		metadataSafetyCheckCount = 0;
		for (int i = 0; i < consumableStates.Length; i++)
		{
			ConsumableState obj = consumableStates[i];
			obj.ClearFrameRequestState();
			obj.CalcFrameAvailability();
		}
		foreach (Town town in towns)
		{
			town?.PreprocessSimulation();
		}
		RunSimulationPass(0);
		RunSimulationPass(1);
		RunSimulationPass(2);
		RunSimulationPass(3);
		RunSimulationPass(4);
	}

	public void PostProcessSimulation()
	{
		if (TimeManager.SimulationDelta > 0f)
		{
			for (int i = 0; i < consumableStates.Length; i++)
			{
				consumableStates[i].CalcFinalFrameStats();
			}
		}
		foreach (Town town in towns)
		{
			town?.PostProcessSimulation();
		}
		ProcessMetadataQueue();
		hasProcessedItemSurplus = true;
	}

	public void PerformSimulationSummary()
	{
		CalcBiomeXP();
		CalcCumulativeXP();
		if (!IsQuestAndAchievementProcessFrame)
		{
			return;
		}
		foreach (BuildingState value in activeTown.buildings.Values)
		{
			value.isUpgradeAvailabilityStale = true;
		}
		CalcBiomeLevels();
		TestForGlobalQuestCompletion();
		CalcPrimaryUpgradeQuest();
		if (townTestIndex < towns.Count)
		{
			Town town = towns[townTestIndex];
			if (town == activeTown)
			{
				town.TestForTownUpgradeUnlock();
			}
		}
		townTestIndex++;
		if (townTestIndex >= towns.Count)
		{
			townTestIndex = 0;
		}
		CheckSimulationAchievements();
	}

	public void CalcDisplayStats()
	{
		if (TimeManager.SimulationDelta > 0f)
		{
			for (int i = 0; i < consumableStates.Length; i++)
			{
				consumableStates[i].CalcDisplayStats();
			}
			activeTown.CalcDisplayStats();
		}
	}

	private void RunSimulationPass(int priorityIndex)
	{
		for (int i = 0; i < consumableStates.Length; i++)
		{
			consumableStates[i].PreparePassRequest(priorityIndex);
		}
		foreach (Town town in towns)
		{
			town?.PreparePassRequest(priorityIndex);
		}
		for (int j = 0; j < consumableStates.Length; j++)
		{
			consumableStates[j].CalcPassOutputRatio();
		}
		foreach (Town town2 in towns)
		{
			town2?.FinalizeOutputCalcInput(priorityIndex);
		}
		for (int k = 0; k < consumableStates.Length; k++)
		{
			consumableStates[k].CalcPassInputRatio();
		}
		foreach (Town town3 in towns)
		{
			town3?.FinalizeAndProduce(priorityIndex);
		}
	}

	public void MinigameLevelUp(MinigamePanelParent parent)
	{
		parent.levelStat.GainLevel();
		CalcEnergyCapacity(parent.energyTracker);
		parent.CalcMetadata();
		parent.ReloadLabels();
		menu.minigameSelectionPanel.ReloadLabels();
	}

	public void SetStaleFlagsForModifiedGlobalPerk(PerkType t)
	{
		CalcGlobalPerkCosts();
		CalcGlobalPerkAvailability();
		switch (t)
		{
		case PerkType.SkillGainSpeed:
			foreach (Town town in towns)
			{
				town?.CalcSkillSpeed();
			}
			break;
		case PerkType.GlobalMarketSpeed:
			foreach (Town town2 in towns)
			{
				town2?.SetMetadataFlag(2097152);
			}
			break;
		case PerkType.GlobalResearchSpeed:
			foreach (Town town3 in towns)
			{
				town3?.SetMetadataFlag(2);
			}
			break;
		case PerkType.GlobalTradingSpeed:
			foreach (Town town4 in towns)
			{
				town4?.SetMetadataFlag(16384);
			}
			break;
		case PerkType.ConstructionEfficiency:
			foreach (Town town5 in towns)
			{
				town5?.SetMetadataFlag(8);
			}
			break;
		case PerkType.UpgradeEfficiency:
			foreach (Town town6 in towns)
			{
				town6?.CalcUpgradeCosts();
			}
			menu.upgradesPanel.arePanelCostsStale = true;
			break;
		case PerkType.IdleGain:
			CalcTimeTokenMax();
			menu.navigationPanel.lastDisplayedTimeTokens = -2147483648.0;
			menu.timeTokensPanel.displayedTimeTokens = -2147483648.0;
			break;
		case PerkType.Specialization:
			menu.combinedProductionPanel.isItemAvailabilityStale = true;
			break;
		case PerkType.SpecializationCount:
			foreach (Town town7 in towns)
			{
				town7?.CalcMaxSpecialties();
			}
			menu.combinedProductionPanel.ReloadSpecialtyButtons();
			break;
		case PerkType.SpecializationValue:
			foreach (Town town8 in towns)
			{
				town8?.CalcSellSpeed();
			}
			menu.combinedProductionPanel.arePanelCostsStale = true;
			break;
		case PerkType.NaturalResourceCapacity:
			foreach (Town town9 in towns)
			{
				town9?.CalcNaturalResourceCapacity();
			}
			break;
		case PerkType.MoreStartingLand:
			foreach (Town town10 in towns)
			{
				if (town10 != null)
				{
					town10.SetMetadataFlag(4);
					town10.SetMetadataFlag(16);
				}
			}
			break;
		case PerkType.ResourceRegen:
			foreach (Town town11 in towns)
			{
				town11?.SetMetadataFlag(262144);
			}
			break;
		case PerkType.ResearchEfficiency:
			foreach (Town town12 in towns)
			{
				town12?.SetMetadataFlag(2);
			}
			break;
		default:
			SetAllTownMetadataStale();
			isGlobalMetadataStale = true;
			FlagAllBuildingDataStale();
			break;
		}
		menu.worldPerksPanel.UpdateStaticDisplayForListItem(t);
		menu.worldPerksPanel.areCountsStale = true;
		menu.worldPerksPanel.isHeaderDataStale = true;
		menu.townPerksPanel.UpdateStaticDisplayForListItem(t);
		menu.townPerksPanel.areCountsStale = true;
		menu.townPerksPanel.isHeaderDataStale = true;
		ProcessMetadataQueue();
	}

	public void OnUpgradePurchased(Upgrade upgrade, bool calcMetadata = true)
	{
		activeTown.Spend(upgrade.cachedCurrentCostItem, upgrade.cachedCurrentCostAmount);
		upgrade.numCompleted++;
		Town parentTown = upgrade.parentTown;
		if (parentTown == null)
		{
			return;
		}
		parentTown.SetMetadataFlag(8388608);
		switch (upgrade.type)
		{
		case UpgradeType.FurnaceProductivity:
			parentTown.ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.BurnCoal));
			break;
		case UpgradeType.UpgradeEfficiency:
			parentTown.CalcUpgradeCosts();
			break;
		case UpgradeType.TradingPostStorageCapacity:
			isGlobalItemCapacityStale = true;
			break;
		case UpgradeType.SolarPanelEffectiveness:
		case UpgradeType.OmniSolarPanelEffectiveness:
			parentTown.SetMetadataFlag(262144);
			break;
		default:
			if (upgrade.def.metadataFlagItemCapacity)
			{
				parentTown.SetMetadataFlag(512);
				parentTown.SetMetadataFlag(65536);
			}
			else if (upgrade.def.metadataFlagProductionCapacity)
			{
				parentTown.SetMetadataFlag(1048576);
			}
			else if (upgrade.def.metadataFlagStateSpeed)
			{
				parentTown.ProcessMetadataForEntity(upgrade.def.linkedEntity);
			}
			else if (upgrade.def.metadataFlagProductivity)
			{
				parentTown.ProcessMetadataForEntity(upgrade.def.linkedEntity);
			}
			else
			{
				parentTown.SetAllTownMetadataStale();
			}
			break;
		}
		upgrade.currentLevelAvailability = false;
		upgrade.CalcAvailability();
		upgrade.StoreCurrentLevelCost();
		if (calcMetadata)
		{
			parentTown.CalcUpgradeCount();
			if (isGlobalItemCapacityStale)
			{
				ProcessMetadataQueue();
			}
			else
			{
				parentTown.ProcessTownMetadataQueue();
			}
			if (upgrade.type == UpgradeType.UpgradeEfficiency)
			{
				menu.upgradesPanel.arePanelCostsStale = true;
			}
			else if (upgrade.type == UpgradeType.ConstructionEfficiency || upgrade.type == UpgradeType.MarketCostFood || upgrade.type == UpgradeType.MarketCostGeneral || upgrade.type == UpgradeType.MarketCostHardware || upgrade.type == UpgradeType.MarketCostBookstore || upgrade.type == UpgradeType.MarketCostClothing || upgrade.type == UpgradeType.MarketCostGourmet || upgrade.type == UpgradeType.MarketCostApothecary || upgrade.type == UpgradeType.MarketCostJewelry || upgrade.type == UpgradeType.MarketCostArcane)
			{
				menu.combinedProductionPanel.arePanelCostsStale = true;
			}
			menu.upgradesPanel.isTownLayoutStale = true;
			menu.FlagAllAvailabilityStale();
			FlagAllBuildingDataStale();
			if (upgrade.type == UpgradeType.LuckyPickaxe && null != menu.minigamePanelMining)
			{
				menu.minigamePanelMining.UpdateProtectionIcons();
			}
			queueAutoSave = true;
		}
	}

	public float MultiplierForGlobalUpgrade(UpgradeType t)
	{
		return 1f;
	}

	public float MultiplierForGlobalPerk(PerkType t)
	{
		return AdjustedMultiplierForPerkLevel(t, LevelOfGlobalPerk(t));
	}

	public static float MultiplierForResearch(ResearchType t, int level)
	{
		float num = Research.GrowthValueForResearch(t);
		if (t == ResearchType.ManaPowerTractors || t == ResearchType.ManaPowerChainsawTanks || t == ResearchType.ManaPowerCropHarvesters || t == ResearchType.ManaPowerHarvesterDrills || t == ResearchType.WoodProcessingSpeed || t == ResearchType.StoneProcessingSpeed || t == ResearchType.MetalProcessingSpeed || t == ResearchType.GrainProcessingSpeed)
		{
			return GameUtility.ExponentGrowth(1f, level, num);
		}
		return 1f + (float)level * num;
	}

	public static double MaxTimeTokensForPerkLevel(int testLevel)
	{
		double num = 1.0 + (double)testLevel * 0.5;
		if (num >= 6.0)
		{
			num = 6.0;
		}
		double num2 = 3600.0 * num * (double)(testLevel + 1);
		if (Instance.isExtraIdle)
		{
			num2 *= 4.0;
		}
		return num2 / 60.0;
	}

	public float AdjustedMultiplierForPerkLevel(PerkType t, int level)
	{
		float gameModifierMultiplier = 1f;
		if (gameModifierDifficulty == GameModifier.EasyMode)
		{
			switch (t)
			{
			case PerkType.CraftingSpeed:
			case PerkType.CultivationSpeed:
			case PerkType.MarketValue:
			case PerkType.ProspectingSpeed:
			case PerkType.MoreStartingLand:
			case PerkType.HarvestingSpeed:
			case PerkType.TownXPBoost:
			case PerkType.KnowledgeSpeed:
				gameModifierMultiplier = 2f;
				break;
			}
		}
		else if (gameModifierDifficulty == GameModifier.HardMode)
		{
			switch (t)
			{
			case PerkType.CraftingSpeed:
			case PerkType.CultivationSpeed:
			case PerkType.MarketValue:
			case PerkType.ProspectingSpeed:
			case PerkType.MoreStartingLand:
			case PerkType.HarvestingSpeed:
			case PerkType.TownXPBoost:
			case PerkType.KnowledgeSpeed:
				gameModifierMultiplier = 0.5f;
				break;
			}
		}
		return RawMultiplierForPerkLevel(t, level, gameModifierMultiplier);
	}

	public static float RawMultiplierForPerkLevel(PerkType t, int level, float gameModifierMultiplier)
	{
		if (t == PerkType.StorageBoost)
		{
			return (float)level * GameUtility.AsTruncatedFloat(Instance.ValuePerStorageBoostPerkLevel() * (double)gameModifierMultiplier);
		}
		if (!Crafting.perkDefCache.TryGetValue(t, out var value))
		{
			return 0f;
		}
		int num = level - 1;
		if (num < 0)
		{
			if (value.growthRateType == GrowthRateType.Linear)
			{
				return 0f;
			}
			return 1f;
		}
		if (value.effectArray != null)
		{
			float num2 = 1f;
			if (num < value.effectArray.Length)
			{
				num2 = value.effectArray[num];
			}
			if (value.growthRateType == GrowthRateType.Linear)
			{
				return num2 * gameModifierMultiplier;
			}
			if (GameUtility.NotEquals(1f, gameModifierMultiplier) && num2 > 1f)
			{
				float num3 = num2 - 1f;
				num3 *= gameModifierMultiplier;
				return 1f + num3;
			}
			return num2;
		}
		if (value.growthValue <= -1f)
		{
			return 0f;
		}
		GrowthRateType growthRateType = value.growthRateType;
		float growthValue = value.growthValue;
		return growthRateType switch
		{
			GrowthRateType.Linear => (float)level * growthValue, 
			GrowthRateType.Multiplicative => 1f + (float)level * growthValue, 
			_ => GameUtility.ExponentGrowth(1f, level, growthValue), 
		};
	}

	public static float DebugMultiplierForPerk(PerkType t, int level, GrowthRateType growthType)
	{
		float num = Perk.GrowthValueForPerk(t);
		return growthType switch
		{
			GrowthRateType.Linear => (float)level * num, 
			GrowthRateType.Multiplicative => 1f + (float)level * num, 
			_ => GameUtility.ExponentGrowth(1f, level, num), 
		};
	}

	public int LevelOfGlobalPerk(PerkType type)
	{
		if (globalPerks.TryGetValue(type, out var value))
		{
			return GameUtility.RoundToInt(value.currentCount);
		}
		return 0;
	}

	public int LevelOfGlobalUpgrade(UpgradeType type)
	{
		return 0;
	}

	public static bool IsGlobalQuestComplete(QuestType t)
	{
		if (t == Quest.UnlockAutoBalance && instance.isAutoAssignDefault)
		{
			return true;
		}
		if (t == QuestType.None)
		{
			return false;
		}
		if (everythingUnlocked)
		{
			return true;
		}
		if (instance.globalQuests.TryGetValue(t, out var value))
		{
			if (value.def.isDisabled)
			{
				return false;
			}
			return value.availability == BuildObjectAvailability.Completed;
		}
		return false;
	}

	public void OnResearchReadyToClaim(ResearchState rs)
	{
		float num = Mathf.Pow(rs.recipe.craftingTime, 0.85f);
		rs.parentTown.cachedTownXPState.AddManualCurrency(num);
		rs.parentTown.hasResearchToClaim = true;
		if (TimeManager.IsFastForwarding)
		{
			menu.idleProgressPanel.AddLogResearchComplete(rs);
			return;
		}
		menu.AnimateResearchComplete(rs, num, rs.parentTown);
		if (rs.parentTown == activeTown && !rs.appliedAutoClaim && !menu.researchPanel.IsVisible())
		{
			menu.navigationPanel.SetAlertForPanel(menu.researchPanel, nextState: true);
		}
	}

	public void BeginTrackingUnlocks()
	{
		trackUnlocks = true;
		recentRewardResults.Clear();
		recentQuestRewards.Clear();
		recentlyUnlockedEntities.Clear();
		recentlyUnlockedBiomes.Clear();
		levelUpRewards.Clear();
	}

	public void EndTrackingUnlocks()
	{
		trackUnlocks = false;
		if (recentQuestRewards.Contains(ItemType.UtilityVictory))
		{
			menu.victoryPanel.Show();
			PlayerPrefs.SetInt("hasCompletedGame", 1);
		}
		else if (levelUpRewards.Count > 0)
		{
			menu.levelUpRewardPanel.ResetRewards();
			foreach (var levelUpReward in levelUpRewards)
			{
				menu.levelUpRewardPanel.AddReward(levelUpReward.Item1, levelUpReward.Item2);
			}
			levelUpRewards.Clear();
			menu.levelUpRewardPanel.DisplayReward();
		}
		else if (recentlyUnlockedBiomes.Count > 0)
		{
			BiomeType biomeType = recentlyUnlockedBiomes[0];
			recentlyUnlockedBiomes.Remove(biomeType);
			MenuManager.Instance.biomeUnlockPanel.RevealBiome(biomeType);
			MenuManager.Instance.biomeUnlockPanel.dismissDelegate = EndTrackingUnlocks;
		}
		else if (recentlyUnlockedEntities.Count > 0 || recentRewardResults.Count > 0 || recentQuestRewards.items.Count > 0)
		{
			menu.rewardPanel.ShowRecentlyUnlocked();
		}
	}

	public void SetStaleFlagsForCompletedResearch(ResearchState state)
	{
		isQuestAvailabilityStale = true;
		if (state.type == ResearchType.InfiniteSkillGainSpeed)
		{
			state.parentTown.CalcSkillSpeed();
		}
		else if (state.type == ResearchType.EtherBonusManaPower)
		{
			state.parentTown.ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.PurifiedManaPower));
		}
		else if (state.type == ResearchType.EtherBonusFirePower)
		{
			state.parentTown.ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.PurifiedFirePower));
		}
		else if (state.type == ResearchType.EtherBonusWaterPower)
		{
			state.parentTown.ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.PurifiedWaterPower));
		}
		else if (state.type == ResearchType.EtherBonusEarthPower)
		{
			state.parentTown.ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.PurifiedEarthPower));
		}
		else if (state.type == ResearchType.EtherBonusAirPower)
		{
			state.parentTown.ProcessMetadataForEntity(EntityId.FromRecipe(RecipeType.PurifiedAirPower));
		}
		else if (state.recipe.metadataFlag == -1)
		{
			state.parentTown.SetAllTownMetadataStale();
		}
		else if (state.recipe.metadataFlag > 0)
		{
			state.parentTown.SetMetadataFlag(state.recipe.metadataFlag);
		}
		state.parentTown.SetMetadataFlag(65536);
		state.parentTown.SetMetadataFlag(8388608);
		if (globalResearchStats.TryGetValue(state.type, out var value) && (double)state.numCompleted > value.value)
		{
			value.value = state.numCompleted;
		}
		state.parentTown.CalcNumResearchCompleted();
		CalcGlobalResearchCompletedStat(alsoProcessTowns: false);
		if (state.parentTown == menu.researchPanel.displayedTown)
		{
			menu.researchPanel.isTownLayoutStale = true;
			isPanelAvailabilityStale = true;
		}
		if (trackUnlocks && (state.type == ResearchType.WoodProcessingSpeed || state.type == ResearchType.StoneProcessingSpeed || state.type == ResearchType.MetalProcessingSpeed || state.type == ResearchType.GrainProcessingSpeed || state.type == ResearchType.ManaPowerHarvesterDrills || state.type == ResearchType.ManaPowerChainsawTanks || state.type == ResearchType.ManaPowerCropHarvesters || state.type == ResearchType.ManaPowerTractors || state.type == ResearchType.EtherBonusManaPower || state.type == ResearchType.EtherBonusEarthPower || state.type == ResearchType.EtherBonusFirePower || state.type == ResearchType.EtherBonusWaterPower || state.type == ResearchType.EtherBonusAirPower || state.type == ResearchType.AppleFarming || state.type == ResearchType.PearFarming || state.type == ResearchType.BerryFarming || state.type == ResearchType.CottonFarming || state.type == ResearchType.HerbFarming || state.type == ResearchType.PotatoFarming || state.type == ResearchType.CarrotFarming || state.type == ResearchType.TomatoFarming || state.type == ResearchType.SugarFarming || state.type == ResearchType.CactusFarming || state.type == ResearchType.DragonfruitFarming || state.type == ResearchType.CoalMining || state.type == ResearchType.SilverMining || state.type == ResearchType.CopperMining || state.type == ResearchType.GoldMining || state.type == ResearchType.AmethystMining || state.type == ResearchType.SapphireMining || state.type == ResearchType.TopazMining || state.type == ResearchType.RubyMining || state.type == ResearchType.ManaMining || state.recipe.isInfiniteResearch))
		{
			recentRewardResults.Add(new EntityLevel(EntityId.FromResearch(state.type), state.numCompleted));
		}
	}

	private void CalcGlobalResearchCompletedStat(bool alsoProcessTowns)
	{
		int num = 0;
		foreach (Town town in towns)
		{
			if (town != null)
			{
				if (alsoProcessTowns)
				{
					town.CalcNumResearchCompleted();
				}
				num += town.completedResearchStat.value;
			}
		}
		completedResearchStat.value = num;
	}

	private void ProcessQuestMetadata()
	{
		isQuestMetadataStale = false;
		CheckAchievementsForQuests();
		CalcGlobalQuestFlags();
		CalcPrimaryUpgradeQuest();
	}

	public void ProcessCompletedResearchMetadata()
	{
		isResearchMetadataStale = false;
		queueAutoSave = true;
		CheckAchievementsForResearch();
	}

	public void CompleteAllQuests()
	{
		BeginTrackingUnlocks();
		foreach (KeyValuePair<QuestType, Quest> globalQuest in globalQuests)
		{
			Quest value = globalQuest.Value;
			if (value.completionRequirement == null || (value.availability == BuildObjectAvailability.Available && value.completionRequirement.IsMet()))
			{
				OnCompletedQuest(value);
			}
		}
		CalcMetadataForQuestCompletion();
		ProcessMetadataQueue();
		EndTrackingUnlocks();
	}

	public void OnCompletedQuest(Quest quest)
	{
		quest.SetAsComplete();
		_ = quest.type;
		_ = 1;
		if (quest.type == Quest.DisplayCategoryHeaders)
		{
			menu.combinedProductionPanel.SetTopLevelHeadersSuppressed(nextState: false);
			menu.combinedProductionPanel.isItemAvailabilityStale = true;
		}
		if (quest.type == Quest.FrequentProgressUpdates)
		{
			menu.townStatsPanel.useFrequentQuestUpdates = false;
		}
		if (quest.type == Quest.UnlockAutoBalance)
		{
			menu.FlagAllAutoAssignStale();
		}
		if (quest.type == Quest.UnlockPrioritization)
		{
			menu.FlagAllPriorityStale();
		}
		if (quest.type == QuestType.OmnitempleForAutoClaim)
		{
			menu.FlagAllAutoClaimStale();
		}
		isBiomeAvailabilityStale = true;
		foreach (EntityLevel explicitReward in quest.def.explicitRewards)
		{
			ItemType i;
			MenuPanelType p;
			if (explicitReward.entityId.TryAsBuilding(out var b))
			{
				if (activeTown.buildings.TryGetValue(b, out var value))
				{
					value.CalcAvailability();
				}
			}
			else if (explicitReward.entityId.TryAsItem(out i))
			{
				recentlyUnlockedEntities.Add(new EntityLevel(explicitReward.entityId, 0));
			}
			else if (explicitReward.entityId.TryAsMenuPanel(out p))
			{
				recentlyUnlockedEntities.Add(explicitReward);
			}
			else if (!recentlyUnlockedEntities.Contains(explicitReward))
			{
				recentlyUnlockedEntities.Add(explicitReward);
			}
		}
		if (quest.rewardItems == null)
		{
			return;
		}
		foreach (KeyValuePair<ItemType, double> item in quest.rewardItems.items)
		{
			recentQuestRewards.AddItem(item.Key, item.Value);
			ItemState value2;
			if (item.Key == ItemType.UtilityQuestCoin)
			{
				ModifyQuestCoins(GameUtility.AsFloat(item.Value));
			}
			else if (item.Key == ItemType.UtilityIdleRewardBoost)
			{
				numRewardBoosts++;
			}
			else if (activeTown.inventory.TryGetValue(item.Key, out value2))
			{
				value2.Add(item.Value);
			}
		}
	}

	public void CalcMetadataForQuestCompletion()
	{
		isQuestMetadataStale = true;
		isGlobalMetadataStale = true;
		isPanelAvailabilityStale = true;
		isQuestAvailabilityStale = true;
		menu.pointerDelayCounter = 0f;
		foreach (Town town in towns)
		{
			town?.SetMetadataFlag(65536);
		}
		menu.FlagAllAvailabilityStale();
		menu.SetQuestsStale();
		queueAutoSave = true;
	}

	public void CalcGlobalQuestFlags()
	{
		if (hasCompletedHousePrompts)
		{
			isPromptingForHouse = false;
			return;
		}
		if (hasCompletedHarvesterHutPrompts)
		{
			isPromptingForHarvesterHut = false;
			return;
		}
		tutorialQuestType = QuestType.None;
		if (!IsGlobalQuestComplete(QuestType.WoodForHouse))
		{
			tutorialQuestType = QuestType.WoodForHouse;
		}
		else if (!IsGlobalQuestComplete(QuestType.HouseForHarvesterHut))
		{
			tutorialQuestType = QuestType.HouseForHarvesterHut;
		}
		else if (!IsGlobalQuestComplete(QuestType.HarvesterHutForAssignWorkers))
		{
			tutorialQuestType = QuestType.HarvesterHutForAssignWorkers;
		}
		else if (!IsGlobalQuestComplete(QuestType.AssignWorkersForGeneralStore))
		{
			tutorialQuestType = QuestType.AssignWorkersForGeneralStore;
		}
		else if (!IsGlobalQuestComplete(QuestType.GeneralStoreForMarketPanel))
		{
			tutorialQuestType = QuestType.GeneralStoreForMarketPanel;
		}
		else if (!IsGlobalQuestComplete(QuestType.EarnCoinsForLumberMill))
		{
			tutorialQuestType = QuestType.EarnCoinsForLumberMill;
		}
		else if (!IsGlobalQuestComplete(QuestType.PlanksForGeneralStore))
		{
			tutorialQuestType = QuestType.PlanksForGeneralStore;
		}
		if (tutorialQuestType != QuestType.None && globalQuests.TryGetValue(tutorialQuestType, out var value))
		{
			isPromptingForHouse = value.IsActivelyPromptingForHouse();
			isPromptingForHarvesterHut = value.IsActivelyPromptingForHarvesterHut();
			return;
		}
		hasCompletedHousePrompts = true;
		isPromptingForHouse = false;
		hasCompletedHarvesterHutPrompts = true;
		isPromptingForHarvesterHut = false;
	}

	public void FlagAllBuildingDataStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menu.menuPanels)
		{
			if (menuPanel.Value is MenuListPanel menuListPanel)
			{
				menuListPanel.isBuildingDataStale = true;
			}
		}
		menu.FlagAllCostsStale();
		menu.worldPerksPanel.areCountsStale = true;
		menu.worldPerksPanel.isHeaderDataStale = true;
		menu.worldPerksPanel.areValuesStale = true;
		menu.worldPerksPanel.isCostInfoStale = true;
		menu.townPerksPanel.areCountsStale = true;
		menu.townPerksPanel.isHeaderDataStale = true;
		menu.townPerksPanel.areValuesStale = true;
		menu.townPerksPanel.isCostInfoStale = true;
	}

	public void TryAddUnlock(EntityId id, int level = 0)
	{
		if (id.type == EntityType.None || !trackUnlocks || id.type == EntityType.Item)
		{
			return;
		}
		if (id.type == EntityType.Biome)
		{
			recentlyUnlockedBiomes.Add(id.AsBiome);
			return;
		}
		EntityLevel item = new EntityLevel(id, level);
		if (!recentlyUnlockedEntities.Contains(item))
		{
			recentlyUnlockedEntities.Add(item);
		}
	}

	public void CalcAllBuildingCounts()
	{
		isBuildingCountStale = false;
		foreach (KeyValuePair<BuildingType, FloatProperty> buildingCount in buildingCounts)
		{
			CalcBuildingCount(buildingCount.Key);
		}
	}

	public void CalcBuildingCount(BuildingType buildingType)
	{
		if (buildingCounts.TryGetValue(buildingType, out var value))
		{
			value.value = 0.0;
			value.value = GlobalNumBuildingsOfType(buildingType);
		}
	}

	public void CalcGlobalQuestAvailability()
	{
		isQuestAvailabilityStale = false;
		foreach (KeyValuePair<QuestType, Quest> globalQuest in globalQuests)
		{
			CalcQuestAvailability(globalQuest.Value);
		}
	}

	public void CalcQuestAvailability(Quest q)
	{
		isQuestMetadataStale = true;
		if (q.availability == BuildObjectAvailability.Locked && (q.displayRequirement == null || q.displayRequirement.IsMet()))
		{
			q.availability = BuildObjectAvailability.Available;
			q.CalcRequirementActivity();
			OnDisplayedQuest(q.type);
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromQuest(q.type), 0));
			menu.SetQuestsStale();
		}
	}

	private void OnDisplayedQuest(QuestType t)
	{
		if (t == QuestType.AssignWorkersForGeneralStore && !isAutoAssignDefault)
		{
			menu.isHighlightingWorkerAssignment = true;
		}
	}

	public int NumWorkersAssigned()
	{
		return Mathf.RoundToInt(activeTown.harvesting[HarvestRecipeType.Tree].numWorkersAssigned);
	}

	public void ModifyQuestCoins(float amount)
	{
		bool num = CanAffordAnyPerks();
		questCoinState.currentCount += amount;
		CalcUnassignedQuestCoins();
		menu.worldPerksPanel.areCountsStale = true;
		menu.worldPerksPanel.isHeaderDataStale = true;
		MenuManager.Instance.navigationPanel.SetButtonVisibilityForPanel(MenuPanelType.Perks, isVisible: true);
		if (!num && CanAffordAnyPerks())
		{
			menu.worldPerksPanel.AddAlertState();
		}
		CheckAchievement(AchievementType.QuestCoins1);
	}

	private bool CanAffordAnyPerks()
	{
		if (questCoinState.currentCount < 10.0)
		{
			return false;
		}
		foreach (KeyValuePair<PerkType, PerkState> globalPerk in globalPerks)
		{
			if (globalPerk.Value.CanAffordPerk())
			{
				return true;
			}
		}
		return false;
	}

	public static double CostForEarningNextPrestigePoint(double currentNum)
	{
		return (GameUtility.Poly(currentNum, 0f, 1f, 0.05f, 0.007f) + 1.0) * 100000.0;
	}

	public static double CostForEarningNextClickLevel(int currentLvl)
	{
		if (currentLvl < 0)
		{
			return 0.0;
		}
		return GameUtility.TruncateToSignificantDigits(GameUtility.Poly(currentLvl, 0f, 1f, 0.1f, 0.01f) * 20f + 20f, 2);
	}

	public static double ExperienceCostForProgressingFromLevel(int lvl)
	{
		double num = 100.0 * Math.Pow(2.154, lvl) + 100.0 * Math.Pow(lvl, 2.0) + 200.0 * (double)lvl;
		num *= 5.0;
		num += 500.0;
		return GameUtility.TruncateToSignificantDigits(num, 2);
	}

	public void OnBuildingStatePauseChanged(AssignableState s)
	{
		foreach (StateManager potentialStateManager in activeTown.potentialStateManagers)
		{
			if (potentialStateManager.producingBuilding != null && potentialStateManager.producingBuilding.settings == s)
			{
				potentialStateManager.CalcAppliedPauseState();
			}
		}
	}

	public void OnTownNameChanged(string n)
	{
		activeTown.townName = n;
		menu.townStatsPanel.ReloadTownName();
		menu.worldPanel.isActiveTownStale = true;
	}

	public bool AllowQueuedWorkers()
	{
		return true;
	}

	public float ActiveTownLevelOfUpgrade(UpgradeType t)
	{
		return activeTown.upgrades[t].numCompleted;
	}

	public List<Skill> ActiveTownBuildingSkills(BuildingType t)
	{
		if (activeTown.skillsPerBuilding.TryGetValue(t, out var value))
		{
			return value;
		}
		return null;
	}

	public bool ActiveTownItemStateLocked(ItemType t)
	{
		return activeTown.inventory[t].isLocked;
	}

	public bool ActiveTownHarvestStateLocked(HarvestRecipeType t)
	{
		return activeTown.harvesting[t].isLocked;
	}

	public bool ActiveTownResourceStateLocked(NaturalResource t)
	{
		return activeTown.naturalResources[t].isLocked;
	}

	public double ActiveTownProductionCount(ItemType t)
	{
		return activeTown.inventory[t].townProductionStat.value;
	}

	public float ActiveTownResearchCompleted(ResearchType t)
	{
		if (activeTown.research.TryGetValue(t, out var value))
		{
			return value.numCompleted;
		}
		return 0f;
	}

	public double ActiveTownMarketSellCount(BuildingType t)
	{
		return activeTown.marketSellCounts[t].value;
	}

	public float GlobalNumBuildingsOfType(BuildingType t)
	{
		double num = 0.0;
		foreach (Town town in towns)
		{
			if (town != null)
			{
				num += (double)town.NumBuildingsOfType(t);
			}
		}
		return GameUtility.AsTruncatedFloat(num);
	}

	public FloatProperty GetOrCreateCachedBuildingCount(BuildingType t)
	{
		if (!buildingCounts.TryGetValue(t, out var value))
		{
			value = new FloatProperty();
			buildingCounts[t] = value;
		}
		return value;
	}

	public double NumBuildingsOfType(BuildingType t)
	{
		switch (t)
		{
		case BuildingType.None:
			return activeTown.totalBuildings;
		case BuildingType.Base:
			return numTowns;
		default:
		{
			if (activeTown.buildings.TryGetValue(t, out var value))
			{
				return GameUtility.AsFloat(value.currentCount);
			}
			return 0.0;
		}
		}
	}

	public Requirement GetCachedWorldRequirement(RequirementId id)
	{
		if (worldRequirementCache.TryGetValue(id, out var value))
		{
			return value;
		}
		value = Requirement.FromId(id);
		worldRequirementCache[id] = value;
		value.StoreItemStateCacheGlobal();
		return value;
	}

	public static BiomeType DefaultBiomeForIndex(int i)
	{
		return i switch
		{
			0 => BiomeType.Plains, 
			1 => BiomeType.River, 
			2 => BiomeType.Mountains, 
			3 => BiomeType.Desert, 
			4 => BiomeType.Jungle, 
			5 => BiomeType.Snow, 
			6 => BiomeType.Magic, 
			7 => BiomeType.Forest, 
			_ => BiomeType.Plains, 
		};
	}

	public Requirement DisplayedRequirementForQuest(QuestType t)
	{
		if (Crafting.questCache.TryGetValue(t, out var _) && globalQuests.TryGetValue(t, out var value2))
		{
			foreach (Requirement requirement in value2.completionRequirement.requirements)
			{
				if (requirement.IsVisible())
				{
					return requirement;
				}
			}
		}
		return null;
	}

	public void ResetGlobalPerks()
	{
		lastGlobalPerkResetTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		foreach (KeyValuePair<PerkType, PerkState> globalPerk in globalPerks)
		{
			globalPerk.Value.Reset();
		}
		RefreshAllMetadata();
	}

	public void SetAllTownMetadataStale()
	{
		foreach (Town town in towns)
		{
			town?.SetAllTownMetadataStale();
		}
	}

	public void RefreshAllMetadata()
	{
		isGlobalMetadataStale = true;
		isResearchMetadataStale = true;
		isQuestMetadataStale = true;
		isUniversityMetadataStale = true;
		isMonasteryMetadataStale = true;
		isHarborMetadataStale = true;
		isObservatoryMetadataStale = true;
		isPyramidMetadataStale = true;
		isBazaarMetadataStale = true;
		isTreasureVaultMetadataStale = true;
		isObeliskMetadataStale = true;
		isGlobalItemCapacityStale = true;
		isBuildingCountStale = true;
		isGlobalUpgradePowerStale = true;
		isBiomeAvailabilityStale = true;
		isPanelAvailabilityStale = true;
		isQuestAvailabilityStale = true;
		SetAllTownMetadataStale();
		FlagAllBuildingDataStale();
		MenuManager.Instance.FlagAllTownLinksStale();
		ProcessMetadataQueue();
	}

	public void ClaimRewards()
	{
		lastRewardClaimTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		SoundManager.PlayOpenTreasureChest();
		BeginTrackingUnlocks();
		recentQuestRewards.AddItem(ItemType.UtilityQuestCoin, 1.0);
		foreach (KeyValuePair<ItemType, double> item in recentQuestRewards.items)
		{
			if (item.Key == ItemType.UtilityQuestCoin)
			{
				ModifyQuestCoins(GameUtility.AsFloat(item.Value));
			}
		}
		EndTrackingUnlocks();
	}

	private void CalcCumulativeXP()
	{
		cumulativeXP = 0.0;
		foreach (Town town in towns)
		{
			if (town != null)
			{
				double num = 0.0;
				cumulativeXP += num + town.spentXP + town.cachedTownXPState.currentCount;
			}
		}
	}

	public void ShowRewardForCreatingBiome(BiomeType t)
	{
		BeginTrackingUnlocks();
		switch (t)
		{
		case BiomeType.Forest:
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromNaturalResource(NaturalResource.HerbBush), 0));
			break;
		case BiomeType.River:
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromNaturalResource(NaturalResource.FishSource), 0));
			break;
		case BiomeType.Mountains:
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromNaturalResource(NaturalResource.CarrotPlant), 0));
			break;
		case BiomeType.Snow:
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromNaturalResource(NaturalResource.PotatoPlant), 0));
			break;
		case BiomeType.Desert:
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromNaturalResource(NaturalResource.CactusFruitTree), 0));
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromNaturalResource(NaturalResource.Sand), 0));
			break;
		case BiomeType.Jungle:
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromNaturalResource(NaturalResource.DragonFruitTree), 0));
			break;
		case BiomeType.Magic:
			recentlyUnlockedEntities.Add(new EntityLevel(EntityId.FromNaturalResource(NaturalResource.ManaCrystal), 0));
			break;
		}
		EndTrackingUnlocks();
	}

	public float LevelOfBiome(BiomeType t)
	{
		if (biomeLevels.TryGetValue(t, out var value))
		{
			return value.value;
		}
		return -1f;
	}

	public bool IsGloballyLocked(EntityId id)
	{
		BuildingType b;
		RecipeType r;
		if (id.TryAsItem(out var i))
		{
			if (globalInventory.TryGetValue(i, out var value))
			{
				return value.isLocked;
			}
		}
		else if (id.TryAsBuilding(out b))
		{
			foreach (Town town in towns)
			{
				if (town != null && town.buildings.TryGetValue(b, out var value2))
				{
					return value2.availability != BuildObjectAvailability.Available;
				}
			}
		}
		else if (id.TryAsRecipe(out r))
		{
			foreach (Town town2 in towns)
			{
				if (town2 != null && town2.recipes.TryGetValue(r, out var value3))
				{
					return value3.isLocked;
				}
			}
		}
		return false;
	}

	public float SpecializationValueBonusPerPerkLevel()
	{
		return SpecializationValueBonusPerPerkLevel(LevelOfGlobalPerk(PerkType.SpecializationValue));
	}

	public float SpecializationValueBonusPerPerkLevel(int level)
	{
		return 2f * AdjustedMultiplierForPerkLevel(PerkType.SpecializationValue, level);
	}

	public float SpecializationDemandBonusPerPerkLevel()
	{
		return SpecializationDemandBonusPerPerkLevel(LevelOfGlobalPerk(PerkType.SpecializationDemand));
	}

	public float SpecializationDemandBonusPerPerkLevel(int level)
	{
		return 2f + AdjustedMultiplierForPerkLevel(PerkType.SpecializationDemand, level);
	}

	public int MaxNumSpecialtiesForPerkLevel()
	{
		return MaxNumSpecialtiesForPerkLevel(LevelOfGlobalPerk(PerkType.SpecializationCount));
	}

	public int MaxNumSpecialtiesForPerkLevel(int level)
	{
		return 1 + Mathf.RoundToInt(AdjustedMultiplierForPerkLevel(PerkType.SpecializationCount, level));
	}

	public void CheckTimedAchievements()
	{
		achievementTestCooldown -= Time.deltaTime;
		if (achievementTestCooldown <= 0f)
		{
			achievementTestCooldown += 0.5f;
			CheckAchievementsForProduction(achievementTestIndex);
			achievementTestIndex++;
			if (achievementTestIndex > 5)
			{
				achievementTestIndex = 0;
			}
		}
	}

	public void CalcNumItemsUnlocked()
	{
		numInventoryItemsUnlocked = 0;
		numSellableItemsUnlocked = 0;
		totalNumInventoryItems = 0;
		totalNumSellableItems = 0;
		foreach (ItemState value3 in globalInventory.Values)
		{
			if (Crafting.cachedItemDefs.TryGetValue(value3.type, out var value) && !value.enabled)
			{
				continue;
			}
			bool flag = false;
			totalNumInventoryItems++;
			if (Crafting.houseSellData.TryGetValue(value3.type, out var value2) && value2.derivedSellBuilding != BuildingType.None)
			{
				flag = true;
				totalNumSellableItems++;
			}
			if (!value3.isLocked)
			{
				numInventoryItemsUnlocked++;
				if (flag)
				{
					numSellableItemsUnlocked++;
				}
			}
		}
		Platform.Instance.SetStat(StatType.ItemsUnlocked, numInventoryItemsUnlocked);
	}

	public void CheckSimulationAchievements()
	{
		numItemsAtMaxFulfillment = 0;
		maxFulfillmentScore = 0;
		maxTreeHarvestRate = 0.0;
		maxTownXPRate = 0.0;
		foreach (Town town in towns)
		{
			if (town == null)
			{
				continue;
			}
			if (town.fulfillmentScore > maxFulfillmentScore)
			{
				maxFulfillmentScore = town.fulfillmentScore;
			}
			if (town.inventory.TryGetValue(ItemType.TownExperiencePoint, out var value))
			{
				double num = value.frameDelta / (double)TimeManager.SimulationDelta;
				if (num > maxTownXPRate)
				{
					maxTownXPRate = num;
				}
			}
			if (town.harvesting.TryGetValue(HarvestRecipeType.Tree, out var value2) && (double)value2.displayedRecipeUnitRate > maxTreeHarvestRate)
			{
				maxTreeHarvestRate = value2.displayedRecipeUnitRate;
			}
			int num2 = 0;
			foreach (SellState value3 in town.marketItems.Values)
			{
				if (value3.fulfillmentRatio >= 0.99f)
				{
					num2++;
				}
			}
			if (num2 > numItemsAtMaxFulfillment)
			{
				numItemsAtMaxFulfillment = num2;
			}
		}
		Platform.Instance.SetStat(StatType.MaxFulfillmentCount, numItemsAtMaxFulfillment);
		Platform.Instance.SetStat(StatType.MaxFulfillmentScore, maxFulfillmentScore);
		CheckAchievement(AchievementType.MaxFulfillment1);
		CheckAchievement(AchievementType.MaxFulfillment2);
		CheckAchievement(AchievementType.MaxFulfillment3);
		CheckAchievement(AchievementType.MaxFulfillment4);
		CheckAchievement(AchievementType.FulfillmentScore1);
		CheckAchievement(AchievementType.FulfillmentScore2);
		CheckAchievement(AchievementType.FulfillAll);
		CheckAchievement(AchievementType.HarvestTree);
		CheckAchievement(AchievementType.NumbersGoUp);
	}

	private void CheckAllAchievements()
	{
		CheckAchievementsForHouses();
		CheckAchievementsForQuests();
		CheckAchievementsForResearch();
		CheckTownLevelAchievements();
		CheckAchievementsForProduction(-1);
		CheckSimulationAchievements();
		CheckAchievement(AchievementType.QuestCoins1);
		Platform.Instance.SetStat(StatType.NumClickables, GameUtility.RoundToInt(itemsGainedFromClicking));
		CheckAchievement(AchievementType.Click1);
		CheckAchievement(AchievementType.Wells);
		CheckAchievement(AchievementType.IdleTime1);
	}

	public void CheckTownLevelAchievements()
	{
		CheckAchievement(AchievementType.TownLevelAny10);
		CheckAchievement(AchievementType.TownLevelAny20);
		CheckAchievement(AchievementType.TownLevelAny30);
		CheckAchievement(AchievementType.TownLevelAny40);
		CheckAchievement(AchievementType.TownLevelAll10);
		CheckAchievement(AchievementType.TownLevelAll20);
		CheckAchievement(AchievementType.TownLevelAll30);
		CheckAchievement(AchievementType.TownLevelAll40);
		CheckAchievement(AchievementType.TownLevelAll50);
		CheckAchievement(AchievementType.UnlockBiomePlains);
		CheckAchievement(AchievementType.UnlockBiomeForest);
		CheckAchievement(AchievementType.UnlockBiomeRiver);
		CheckAchievement(AchievementType.UnlockBiomeMountains);
		CheckAchievement(AchievementType.UnlockBiomeDesert);
		CheckAchievement(AchievementType.UnlockBiomeJungle);
		CheckAchievement(AchievementType.UnlockBiomeSnow);
		CheckAchievement(AchievementType.UnlockBiomeMagic);
		CheckAchievement(AchievementType.ThreeCities);
	}

	private void CheckAchievementsForResearch()
	{
		numResearchCompleted = 0;
		numInfiniteResearchCompleted = 0;
		foreach (Town town in towns)
		{
			if (town == null)
			{
				continue;
			}
			foreach (ResearchState value in town.research.Values)
			{
				numResearchCompleted += value.numCompleted;
				if (value.recipe.isInfiniteResearch)
				{
					numInfiniteResearchCompleted += value.numCompleted;
				}
			}
		}
		Platform.Instance.SetStat(StatType.ResearchCompleted, numResearchCompleted);
		Platform.Instance.SetStat(StatType.InfiniteResearchLevels, numInfiniteResearchCompleted);
		CheckAchievement(AchievementType.CompleteResearch1);
		CheckAchievement(AchievementType.CompleteResearch2);
		CheckAchievement(AchievementType.CompleteResearch3);
		CheckAchievement(AchievementType.CompleteResearch4);
		CheckAchievement(AchievementType.CompleteInfiniteResearch);
	}

	private void CheckAchievementsForHouses()
	{
		highestNumHousesPerTown = 0;
		foreach (Town town in towns)
		{
			if (town != null && town.buildings.TryGetValue(BuildingType.House, out var value))
			{
				int num = Convert.ToInt32(value.currentCount);
				if (num > highestNumHousesPerTown)
				{
					highestNumHousesPerTown = num;
				}
			}
		}
		Platform.Instance.SetStat(StatType.MaxTownHouses, highestNumHousesPerTown);
		CheckAchievement(AchievementType.BuildHouses1);
		CheckAchievement(AchievementType.BuildHouses2);
		CheckAchievement(AchievementType.BuildHouses3);
		CheckAchievement(AchievementType.BuildHouses4);
	}

	public void CheckAchievementsForQuests()
	{
		CalcGlobalQuestMetadata();
		CheckAchievement(AchievementType.Victory);
		CheckAchievement(AchievementType.Quests1);
	}

	public void CheckAchievementsForProduction(int filter)
	{
		if (filter < 0 || filter == 0)
		{
			CheckAchievement(AchievementType.MakePearJuice);
			CheckAchievement(AchievementType.MakeAppleJam);
			CheckAchievement(AchievementType.MakeSandwich);
			CheckAchievement(AchievementType.MakeCake);
		}
		if (filter < 0 || filter == 1)
		{
			CheckAchievement(AchievementType.MakeMagicHat);
			CheckAchievement(AchievementType.MakeWarmCoat);
			CheckAchievement(AchievementType.MakeCrown);
			CheckAchievement(AchievementType.MakeRailTile);
			double num = SecondsSinceWorldCreated();
			Platform.Instance.SetStat(StatType.WorldAgeDays, GameUtility.AsFloat(num / 86400.0));
			CheckAchievement(AchievementType.Playtime7);
			CheckAchievement(AchievementType.Playtime30);
		}
		if (filter < 0 || filter == 2)
		{
			CheckAchievement(AchievementType.MakeEgg);
			CheckAchievement(AchievementType.MakeBerries);
			CheckAchievement(AchievementType.MakeBook);
			CheckAchievement(AchievementType.MakeRefinedSugar);
			numCoinsEarned = CoinsEarned();
			Platform.Instance.SetStat(StatType.CoinsEarned, GameUtility.RoundToInt(numCoinsEarned));
			CheckAchievement(AchievementType.CollectCoins1);
			CheckAchievement(AchievementType.CollectCoins2);
			CheckAchievement(AchievementType.CollectCoins3);
			CheckAchievement(AchievementType.CollectCoins4);
			CheckAchievement(AchievementType.CollectCoins5);
		}
		if (filter < 0 || filter == 3)
		{
			CheckAchievement(AchievementType.MakeFire);
			CheckAchievement(AchievementType.MakeMagicPotion);
			numItemsCrafted = GloballyProduced(ItemType.None);
			Platform.Instance.SetStat(StatType.ItemsCrafted, GameUtility.RoundToInt(numItemsCrafted));
			CheckAchievement(AchievementType.CraftItems1);
			CheckAchievement(AchievementType.CraftItems2);
			CheckAchievement(AchievementType.CraftItems3);
			CheckAchievement(AchievementType.CraftItems4);
		}
		if (filter < 0 || filter == 4)
		{
			CheckAchievement(AchievementType.YellowCoin);
			CheckAchievement(AchievementType.RedCoin);
			CheckAchievement(AchievementType.BlueCoin);
			CheckAchievement(AchievementType.PurpleCoin);
			CheckAchievement(AchievementType.StarCoin);
			CheckAchievement(AchievementType.OmniCoin);
		}
	}

	public (double, double) CurrentAndMaxForAchievement(AchievementType t)
	{
		return t switch
		{
			AchievementType.QuestCoins1 => (questCoinState.currentCount, 50.0), 
			AchievementType.Victory => (IsGlobalQuestComplete(QuestType.MilestoneAnyTownLevel50) ? 1 : 0, 1.0), 
			AchievementType.Quests1 => (numCompletedQuests, 50.0), 
			AchievementType.BuildHouses1 => (highestNumHousesPerTown, 10.0), 
			AchievementType.BuildHouses2 => (highestNumHousesPerTown, 25.0), 
			AchievementType.BuildHouses3 => (highestNumHousesPerTown, 60.0), 
			AchievementType.BuildHouses4 => (highestNumHousesPerTown, 150.0), 
			AchievementType.UnlockBiomePlains => ((biomeLevels[BiomeType.Plains].value >= 0f) ? 1 : 0, 1.0), 
			AchievementType.UnlockBiomeForest => ((biomeLevels[BiomeType.Forest].value >= 0f) ? 1 : 0, 1.0), 
			AchievementType.UnlockBiomeRiver => ((biomeLevels[BiomeType.River].value >= 0f) ? 1 : 0, 1.0), 
			AchievementType.UnlockBiomeMountains => ((biomeLevels[BiomeType.Mountains].value >= 0f) ? 1 : 0, 1.0), 
			AchievementType.UnlockBiomeDesert => ((biomeLevels[BiomeType.Desert].value >= 0f) ? 1 : 0, 1.0), 
			AchievementType.UnlockBiomeJungle => ((biomeLevels[BiomeType.Jungle].value >= 0f) ? 1 : 0, 1.0), 
			AchievementType.UnlockBiomeSnow => ((biomeLevels[BiomeType.Snow].value >= 0f) ? 1 : 0, 1.0), 
			AchievementType.UnlockBiomeMagic => ((biomeLevels[BiomeType.Magic].value >= 0f) ? 1 : 0, 1.0), 
			AchievementType.TownLevelAny10 => (cachedMaxTownLevel.value, 10.0), 
			AchievementType.TownLevelAny20 => (cachedMaxTownLevel.value, 20.0), 
			AchievementType.TownLevelAny30 => (cachedMaxTownLevel.value, 30.0), 
			AchievementType.TownLevelAny40 => (cachedMaxTownLevel.value, 40.0), 
			AchievementType.TownLevelAll10 => (numTownsAtLevel10, 4.0), 
			AchievementType.TownLevelAll20 => (numTownsAtLevel20, 5.0), 
			AchievementType.TownLevelAll30 => (numTownsAtLevel30, 6.0), 
			AchievementType.TownLevelAll40 => (numTownsAtLevel40, 7.0), 
			AchievementType.TownLevelAll50 => (numTownsAtLevel50, 8.0), 
			AchievementType.ThreeCities => (numTownsAtLevel15, 3.0), 
			AchievementType.CompleteResearch1 => (numResearchCompleted, 10.0), 
			AchievementType.CompleteResearch2 => (numResearchCompleted, 25.0), 
			AchievementType.CompleteResearch3 => (numResearchCompleted, 50.0), 
			AchievementType.CompleteResearch4 => (numResearchCompleted, 100.0), 
			AchievementType.CompleteInfiniteResearch => (numInfiniteResearchCompleted, 100.0), 
			AchievementType.MakePearJuice => (GloballyProduced(ItemType.PearJuice), 1000.0), 
			AchievementType.MakeAppleJam => (GloballyProduced(ItemType.Jam), 1000.0), 
			AchievementType.MakeSandwich => (GloballyProduced(ItemType.Sandwich), 1000.0), 
			AchievementType.MakeCake => (GloballyProduced(ItemType.Cake), 1000.0), 
			AchievementType.MakeWarmCoat => (GloballyProduced(ItemType.WarmCoat), 1000.0), 
			AchievementType.MakeMagicHat => (GloballyProduced(ItemType.MagicHat), 1000.0), 
			AchievementType.MakeCrown => (GloballyProduced(ItemType.GoldCrown), 1000.0), 
			AchievementType.MakeRailTile => (GloballyProduced(ItemType.RailTile), 1000.0), 
			AchievementType.MakeEgg => (GloballyProduced(ItemType.Egg), 1000.0), 
			AchievementType.MakeBook => (GloballyProduced(ItemType.Book), 1000.0), 
			AchievementType.MakeBerries => (GloballyProduced(ItemType.Berries), 1000.0), 
			AchievementType.MakeRefinedSugar => (GloballyProduced(ItemType.RefinedSugar), 1000.0), 
			AchievementType.MakeFire => (GloballyProduced(ItemType.Fire), 1000.0), 
			AchievementType.MakeMagicPotion => (GloballyProduced(ItemType.MagicPotion), 1000.0), 
			AchievementType.CraftItems1 => (numItemsCrafted, 500.0), 
			AchievementType.CraftItems2 => (numItemsCrafted, 5000.0), 
			AchievementType.CraftItems3 => (numItemsCrafted, 50000.0), 
			AchievementType.CraftItems4 => (numItemsCrafted, 500000.0), 
			AchievementType.CollectCoins1 => (numCoinsEarned, 5000.0), 
			AchievementType.CollectCoins2 => (numCoinsEarned, 25000.0), 
			AchievementType.CollectCoins3 => (numCoinsEarned, 200000.0), 
			AchievementType.CollectCoins4 => (numCoinsEarned, 1000000.0), 
			AchievementType.CollectCoins5 => (numCoinsEarned, 1000000000.0), 
			AchievementType.YellowCoin => (HasEarned(ItemType.YellowCoin), 1.0), 
			AchievementType.RedCoin => (HasEarned(ItemType.RedCoin), 1.0), 
			AchievementType.BlueCoin => (HasEarned(ItemType.BlueCoin), 1.0), 
			AchievementType.PurpleCoin => (HasEarned(ItemType.PurpleCoin), 1.0), 
			AchievementType.StarCoin => (HasEarned(ItemType.Star), 1.0), 
			AchievementType.OmniCoin => (HasEarned(ItemType.OmniCoin), 1.0), 
			AchievementType.MaxFulfillment1 => (numItemsAtMaxFulfillment, 10.0), 
			AchievementType.MaxFulfillment2 => (numItemsAtMaxFulfillment, 25.0), 
			AchievementType.MaxFulfillment3 => (numItemsAtMaxFulfillment, 50.0), 
			AchievementType.MaxFulfillment4 => (numItemsAtMaxFulfillment, 100.0), 
			AchievementType.FulfillmentScore1 => (maxFulfillmentScore, 100.0), 
			AchievementType.FulfillmentScore2 => (maxFulfillmentScore, 400.0), 
			AchievementType.UnlockAll => (numInventoryItemsUnlocked, totalNumInventoryItems), 
			AchievementType.FulfillAll => (numItemsAtMaxFulfillment, totalNumSellableItems), 
			AchievementType.Click1 => (itemsGainedFromClicking, 1000.0), 
			AchievementType.Wells => (GlobalNumBuildingsOfType(BuildingType.Well), 10.0), 
			AchievementType.Playtime7 => (SecondsSinceWorldCreated() / 86400.0, 7.0), 
			AchievementType.Playtime30 => (SecondsSinceWorldCreated() / 86400.0, 30.0), 
			AchievementType.HarvestTree => (maxTreeHarvestRate, 1000.0), 
			AchievementType.NumbersGoUp => (maxTownXPRate, 1000000.0), 
			AchievementType.IdleTime1 => (idleSecondsCollected / 3600.0, 100.0), 
			_ => (0.0, 0.0), 
		};
	}

	private double SecondsSinceWorldCreated()
	{
		if (worldCreationTimestamp == 0L)
		{
			return 0.0;
		}
		return DateTimeOffset.UtcNow.ToUnixTimeSeconds() - worldCreationTimestamp;
	}

	private double CoinsEarned()
	{
		return 0.0 + GloballyProduced(ItemType.YellowCoin) + GloballyProduced(ItemType.RedCoin) + GloballyProduced(ItemType.BlueCoin) + GloballyProduced(ItemType.PurpleCoin) + GloballyProduced(ItemType.Star) + GloballyProduced(ItemType.OmniCoin);
	}

	private double HasEarned(ItemType itemType)
	{
		foreach (Town town in towns)
		{
			if (town != null && town.itemProductionStats.TryGetValue(itemType, out var value) && value.value > 0.0)
			{
				return 1.0;
			}
		}
		return 0.0;
	}

	private double GloballyProduced(ItemType itemType)
	{
		double num = 0.0;
		foreach (Town town in towns)
		{
			if (town == null)
			{
				continue;
			}
			FloatProperty value2;
			if (itemType == ItemType.None)
			{
				foreach (KeyValuePair<ItemType, FloatProperty> itemProductionStat in town.itemProductionStats)
				{
					if (Crafting.cachedItemDefs.TryGetValue(itemProductionStat.Key, out var value) && value.countsTowardsCrafting)
					{
						num += itemProductionStat.Value.value;
					}
				}
			}
			else if (town.itemProductionStats.TryGetValue(itemType, out value2))
			{
				num += value2.value;
			}
		}
		return num;
	}

	public bool DidEarnAchievement(AchievementType t)
	{
		(double, double) tuple = CurrentAndMaxForAchievement(t);
		if (tuple.Item2 > 0.0)
		{
			return tuple.Item1 >= tuple.Item2;
		}
		return false;
	}

	public void CheckAchievement(AchievementType t)
	{
	}

	public void ClearGameState()
	{
		recentlyUnlockedEntities.Clear();
		recentlyUnlockedBiomes.Clear();
		recentQuestRewards.Clear();
		recentRewardResults.Clear();
	}

	public void StoreRequirementCacheInTarget(List<RequirementId> cachedList, Town parentTown, List<Requirement> targetList)
	{
		if (cachedList == null)
		{
			return;
		}
		foreach (RequirementId cached in cachedList)
		{
			if (cached.isTargetingGlobalStat)
			{
				targetList.Add(GetCachedWorldRequirement(cached));
			}
			else if (parentTown != null)
			{
				targetList.Add(parentTown.GetCachedRequirement(cached));
			}
			else
			{
				targetList.Add(GetCachedWorldRequirement(cached));
			}
		}
	}

	public void EarnTimeTokenSeconds(double seconds)
	{
		double num = seconds / 60.0;
		timeTokenState.currentCount += num;
		if (timeTokenState.currentCount > timeTokenState.maxCount)
		{
			timeTokenState.currentCount = timeTokenState.maxCount;
		}
	}

	private void CalcTimeTokenMax()
	{
		timeTokenState.maxCount = MaxTimeTokensForPerkLevel(LevelOfGlobalPerk(PerkType.IdleGain));
	}

	public void SpendTimeTokens(double seconds)
	{
		double num = seconds / 60.0;
		timeTokenState.currentCount -= num;
		if (timeTokenState.currentCount < 0.0)
		{
			timeTokenState.currentCount = 0.0;
		}
	}

	public double DisplayedTimeTokens()
	{
		if (timeTokenState == null)
		{
			return 0.0;
		}
		double currentCount = timeTokenState.currentCount;
		if (currentCount < 0.01)
		{
			return 0.0;
		}
		if (currentCount >= timeTokenState.maxCount - 0.01)
		{
			return timeTokenState.maxCount;
		}
		return timeTokenState.currentCount;
	}

	public void CalcPrimaryUpgradeQuest()
	{
		foreach (Quest value in globalQuests.Values)
		{
			if (!value.IsReadyToClaim())
			{
				continue;
			}
			primaryQuest = value;
			using List<Requirement>.Enumerator enumerator2 = value.completionRequirement.requirements.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				Requirement current2 = enumerator2.Current;
				if (current2 != primaryQuestRequirement)
				{
					primaryQuestRequirement = current2;
				}
				return;
			}
		}
		foreach (Quest value2 in globalQuests.Values)
		{
			if (value2.availability != BuildObjectAvailability.Available)
			{
				continue;
			}
			primaryQuest = value2;
			Requirement requirement = null;
			foreach (Requirement requirement2 in value2.completionRequirement.requirements)
			{
				if (requirement == null || !requirement2.IsMet())
				{
					requirement = requirement2;
				}
			}
			if (requirement != primaryQuestRequirement)
			{
				primaryQuestRequirement = requirement;
			}
			break;
		}
	}

	public void ClaimQuestIndividually(Quest q, bool trackUnlocks = true)
	{
		if (trackUnlocks)
		{
			BeginTrackingUnlocks();
		}
		OnCompletedQuest(q);
		CalcMetadataForQuestCompletion();
		ProcessMetadataQueue();
		if (trackUnlocks)
		{
			EndTrackingUnlocks();
		}
	}

	public void LoadTownWithIndex(int townIndex)
	{
		if (townIndex >= 0 && townIndex < towns.Count)
		{
			Town town = towns[townIndex];
			if (town != null)
			{
				MenuManager.Instance.ClearSelections();
				activeTownIndex = townIndex;
				activeTown = towns[townIndex];
				FinalizeLoadedTown();
			}
		}
	}

	public void CycleTown(bool clockwise)
	{
		int num = (clockwise ? 1 : (-1));
		if (towns.Count < 2)
		{
			return;
		}
		int count = towns.Count;
		int num2 = 0;
		for (int i = 0; i < Data.BiomeIndex.Length; i++)
		{
			if (activeTownIndex == Data.BiomeIndex[i])
			{
				num2 = i;
				break;
			}
		}
		for (int j = 1; j < count; j++)
		{
			int num3 = num2 + j * num;
			if (num3 < 0)
			{
				num3 += count;
			}
			else if (num3 >= count)
			{
				num3 -= count;
			}
			int num4 = Data.BiomeIndex[num3];
			if (towns[num4] != null)
			{
				LoadTownWithIndex(num4);
				break;
			}
		}
	}

	public double ValuePerStorageBoostPerkLevel()
	{
		return 0.5;
	}

	public double ValuePerShrine()
	{
		return 0.1;
	}

	public double ValuePerRailDepot()
	{
		return 0.0;
	}

	public void IncrementAllStats()
	{
		foreach (ItemState value in globalInventory.Values)
		{
			value.IncrementStats();
		}
		foreach (Town town in towns)
		{
			town?.IncrementAllStats();
		}
	}

	public void ApplyModifierToGameState(GameModifier modifier)
	{
		if (!appliedModifiers.Contains(modifier))
		{
			appliedModifiers.Add(modifier);
			switch (modifier)
			{
			case GameModifier.ExtremeBiomes:
			case GameModifier.MildBiomes:
				gameModifierBiomes = modifier;
				break;
			case GameModifier.HardMode:
			case GameModifier.EasyMode:
				gameModifierDifficulty = modifier;
				break;
			case GameModifier.LowPopulation:
				gameModifierPopulation = modifier;
				break;
			case GameModifier.ExtraIdle:
				isExtraIdle = true;
				break;
			case GameModifier.ExtraActive:
				isExtraActive = true;
				break;
			case GameModifier.NoStorageLimits:
				isTownStorageInfinite = true;
				isTradingStorageInfinite = true;
				break;
			case GameModifier.ExchangeTokens:
				isUsingExchangeTokens = true;
				isTradingStorageInfinite = true;
				break;
			case GameModifier.InfiniteLand:
				isLandInfinite = true;
				break;
			case GameModifier.InfiniteConsumption:
				isConsumptionInfinite = true;
				break;
			case GameModifier.PermanentPerks:
				arePerksPermanent = true;
				break;
			case GameModifier.AutoAssignDefault:
				isAutoAssignDefault = true;
				break;
			case GameModifier.AllBiomesUnlocked:
				isUnlockedBiomesMode = true;
				break;
			case GameModifier.NoAutoAssign:
			case GameModifier.AllItemsUnlocked:
			case GameModifier.AllBuildingsUnlocked:
				break;
			}
		}
	}

	public static int RequiredTownLevelForGameModifier(GameModifier testModifier)
	{
		switch (testModifier)
		{
		case GameModifier.PermanentPerks:
		case GameModifier.LowPopulation:
		case GameModifier.ExchangeTokens:
		case GameModifier.AutoAssignDefault:
			return 25;
		case GameModifier.NoStorageLimits:
		case GameModifier.AllBiomesUnlocked:
		case GameModifier.InfiniteLand:
		case GameModifier.InfiniteConsumption:
			return 50;
		case GameModifier.ExtremeBiomes:
		case GameModifier.ExtraIdle:
		case GameModifier.ExtraActive:
		case GameModifier.MildBiomes:
		case GameModifier.HardMode:
		case GameModifier.EasyMode:
		case GameModifier.NoBiomes:
			return 0;
		default:
			return 0;
		}
	}

	public bool IsModifierAvailable(GameModifier testModifier)
	{
		return false;
	}
}
