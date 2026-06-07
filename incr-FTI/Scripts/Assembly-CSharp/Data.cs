using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Data
{
	private static Data instance = null;

	public Dictionary<ItemType, SatisfactionCategory> houseSatisfactionData;

	public List<ItemType> houseSatisfactionCategories;

	public List<ResearchType> civicsResearch;

	public Dictionary<StructureType, StructureDef> defaultStructureDefs;

	public Dictionary<BuildingType, BuildingDef> defaultBuildingDefs;

	public Dictionary<NaturalResource, NaturalResourceDef> defaultNaturalResourceDefs;

	public Dictionary<RecipeType, Recipe> defaultRecipeDefs;

	public Dictionary<NaturalResource, FarmingRecipe> defaultFarmingRecipes;

	public Dictionary<NaturalResource, FarmingRecipe> defaultProspectingRecipes;

	public Dictionary<NaturalResource, ResearchType> resourceResearch;

	public readonly Dictionary<ItemType, ItemDef> defaultItemDefs;

	public Dictionary<BuildingType, List<RecipeType>> defaultBuildingRecipes;

	public Dictionary<ItemType, int[]> satisfactionCategoryMaxHappiness;

	public List<VictoryConditions> housingLevelConditions;

	public List<CapacityUpgrade> coinCapacityData;

	public Dictionary<BuildCategoryType, List<EntityId>> defaultDisplayCategories;

	public Dictionary<ItemType, HouseSellData> houseSellData;

	public List<ItemType> defaultWorkerItemTypes;

	public List<ExplorationResult> explorationResults;

	public List<EntityType> entityTypeHierarchy;

	public Dictionary<NaturalResource, UpgradeType> cultivationSpeedUpgrades;

	public Dictionary<NaturalResource, UpgradeType> prospectingSpeedUpgrades;

	public Dictionary<HarvestRecipeType, UpgradeType> harvestingSpeedUpgrades;

	public Dictionary<BuildingType, UpgradeType> productionCapacityUpgrades;

	public Dictionary<BuildingType, UpgradeType> marketCapacityUpgrades;

	public Dictionary<BuildingType, UpgradeType> storageUpgrades;

	public const int maxTowns = 8;

	public Dictionary<int, VictoryConditions> victoryConditions;

	public List<HappinessRange> happinessRewards;

	public List<BuildingType> houseBuildingTypes;

	public readonly List<ItemType> coins = new List<ItemType>();

	public const long PerkResetInterval = 72000L;

	public const long RewardClaimInterval = 72000L;

	public const int MinQuestCoinsForPerksPanel = 10;

	public const int MinimumResetLevel = 0;

	public const float PerkRewardGrowthFactor = 1.25f;

	public const int TownLevelForApples = 5;

	public const int TownLevelForCotton = 7;

	public const int TownLevelForBerries = 4;

	public const int TownLevelForGrain = 3;

	public const int TownLevelForUniqueCrops = 3;

	public const int CultivationLevelForResearchUnlock = 10;

	public const float idleProgressMultiplier = 0.25f;

	public const float initialTownExpTarget = 100f;

	public const float TownExpCostGrowthRate = 0.3f;

	public const float townExpTargetGrowth = 150f;

	public const float initialHappinessTarget = 100f;

	public const float HappinessCostGrowthRate = 0.25f;

	public const float happinessTargetGrowth = 150f;

	public const float initialSkillTarget = 100f;

	public const float SkillExpCostGrowthRate = 0.3f;

	public const float skillTargetGrowth = 100f;

	public const float DefaultConstructionTimeGrowthRate = 0.05f;

	public const float ConstructionHouseTimeGrowthRate = 0.025f;

	public const float ResourceCapacityPerTownLevel = 0.5f;

	public const int MaxBaseLevel = 10;

	public const int MaxHouseLevel = 10;

	public const int MaxTechLevel = 10;

	public const float HappinessQuintileThreshold0 = 0.1f;

	public const float HappinessQuintileThreshold1 = 0.5f;

	public const float HappinessQuintileThreshold2 = 0.75f;

	public const float HappinessQuintileThreshold3 = 0.99f;

	public const int levelThatUnlocksWonders = 35;

	public const int NumConstructionSpeedUpgrades = 8;

	public const int NumConstructionEfficiencyUpgrades = 8;

	public const int NumMinigameUpgrades = 5;

	public const int NumSellValueUpgrades = 5;

	public const int MaxHotbarNum = 20;

	public const int HotbarItemsPerRow = 10;

	public static int NumHotbarRows = 2;

	public static int DefaultChunkSize = 64;

	public static int LinkResourceRangeFarm = 5;

	public static int LinkResourceRangeForester = 6;

	public static int LinkResourceRangeMine = 6;

	public static int LinkRangeShrine = 7;

	public static int LinkResourceRangeFishery = 8;

	public static int LinkResourceRangeWaterPump = 5;

	public static int LinkResourceMaxRadius = 12;

	public static int LinkResourceMaxRadiusSqr = LinkResourceMaxRadius * LinkResourceMaxRadius;

	public const float ConsumptionBonusCapacityPerUpgradeLevel = 0.1f;

	public const float BonusPerSellValueLevel = 0.5f;

	public const float ExtraLandPerPerkLevel = 10f;

	public const int ExtraLandPerExplorationLevel = 5;

	public const float HappinessDecay = -0.5f;

	public const float HappinessDecayPerHouseLevel = -0.04f;

	public const float ProductivityBoostPerEtherUpgrade = 0.5f;

	public const float SpeedBoostPerChute = 0.05f;

	public const float SpeedBoostPerMine = 0.2f;

	public const float SpeedBoostPerHarvester = 0.05f;

	public const float SpeedBoostPerChainsawTank = 0.05f;

	public const float SpeedBoostPerFishingBoat = 0.05f;

	public const float SpeedBoostPerTractor = 0.05f;

	public const float SpeedBoostPerCropHarvester = 0.05f;

	public const float SpeedBoostPerMinecart = 0.05f;

	public const float PowerPerTemple = 0.1f;

	public const float SpeedBoostPerTrain = 0.05f;

	public const float MultiplierPerUniversity = 0.1f;

	public const float MultiplierPerMonastery = 0.1f;

	public const float MultiplierPerPyramid = 0.05f;

	public const float MultiplierPerHarbor = 0.25f;

	public const float MultiplierPerObservatory = 0.02f;

	public const float MultiplierPerBazaar = 0.1f;

	public const float MultiplierPerTreasureVault = 0.1f;

	public const float MultiplierPerObelisk = 0.1f;

	public const float SpeedBoostPerPackager = 0.05f;

	public const float ProductivityPerPackager = 0.1f;

	public const float SpeedBoostPerClothBelt = 0.05f;

	public const float SpeedBoostPerManaPipe = 0.05f;

	public const float SpeedBoostPerMetalBelt = 0.1f;

	public const float SpeedBoostPerMagicBelt = 0.2f;

	public const float BoostPerFoundry = 0.25f;

	public const float BoostPerAirship = 0.25f;

	public const float BoostPerMagicBoat = 0.25f;

	public const float BoostPerMagicRail = 0.25f;

	public const float BoostPerMagicConveyorBelt = 0.25f;

	public const float BoostPerWell = 2f;

	public const float BoostPerCaravan = 0.1f;

	public const float RecipeBoostPerSkillLevel = 0.1f;

	public const float FarmingBoostPerSkillLevel = 0.1f;

	public const float MiningBoostPerSkillLevel = 0.1f;

	public const float HarvestingBoostPerSkillLevel = 0.1f;

	public const float PowerIncomePerWaterWheel = 0.5f;

	public const float PowerIncomePerSolarPanel = 100f;

	public const float BonusPerMiningUpgradeLevel = 1f;

	public const double WonderCost = 1000000000.0;

	public const float SecondsPerTimeToken = 60f;

	public const float DefaultBuildingCostGrowthFactor = 0.3f;

	public const float DecreasedBuildingCostGrowthFactor = 0.27f;

	public const float SolarPanelGrowthFactor = 0.22f;

	public const float WonderCostGrowthFactor = 0.4f;

	public const float HarvesterHutCostGrowthFactor = 0.25f;

	public const float StorageBuildingCostGrowthFactor = 0.22f;

	public const float HouseCostGrowthFactor = 0.4f;

	public const int DefaultAndStructureLayer = 0;

	public const int IgnoreRaycastLayer = 2;

	public const int AgentLayer = 8;

	public const int BuildingLayer = 9;

	public const int WaterLayer = 10;

	public const int OverlayGridLayer = 11;

	public const int PipeLayer = 12;

	public const int SelectionGridLayer = 13;

	public static int UILayer = 5;

	public static int MarketMaxBlockRadius = 28;

	public static int MarketMaxBlockRadiusSqr = MarketMaxBlockRadius * MarketMaxBlockRadius + 4;

	public static int MarketMaxBlockRadiusSqrFilter = (MarketMaxBlockRadius + 3) * (MarketMaxBlockRadius + 3);

	public static float HighPriorityConsumptionMultiplier = 10f;

	public static int MarketMaxPathLength = 0;

	public static int MarketMaxHeightDiff = 12;

	public static int BaseMaxPathLength = 0;

	public static int BaseMaxHeightDiff = 12;

	public static int HouseMaxRadius = 2;

	public static int HouseMaxBlockDistance = 3;

	public const int MaxAirshipTransferDocked = 25;

	public const int MaxAirshipTransferUndocked = 2;

	public const int MaxTrainTransferStation = 100;

	public const int MaxTrainTransferNonStation = 10;

	public const int NumFoodMarketCapacityUpgrades = 10;

	public const float DefaultTradeTime = 0.1f;

	public readonly float[] xpCosts;

	public readonly int[] slotCapacityPerBaseLevel;

	public readonly int[] xpRequiredPerHouseLevel;

	public readonly int[] linkedHouseLevelsRequiredPerBaseLevel;

	public readonly int[] maxHousesPerHousingHappinessLevel;

	public readonly int[] maxHousesPerResearchLevel;

	public readonly int[] maxBasesPerResearchLevel;

	public readonly int[] populationProvidedPerHouseLevel;

	public readonly int[] happinessRequiredPerHousingLevel;

	public readonly int[] explorationBonus;

	public static readonly int[] BiomeIndex = new int[8] { 0, 1, 7, 2, 4, 3, 5, 6 };

	public static readonly int[] WonderCapacity = new int[15]
	{
		5, 12, 22, 32, 45, 60, 75, 95, 120, 150,
		180, 220, 260, 300, 350
	};

	public static readonly int[] costArrayTiered_2_100_25 = new int[25]
	{
		2, 3, 4, 5, 6, 8, 10, 12, 14, 16,
		18, 21, 24, 27, 30, 35, 40, 45, 50, 60,
		70, 80, 90, 100, 125
	};

	public static readonly int[] costArrayTownPerks_2_150_25 = new int[25]
	{
		2, 4, 6, 8, 10, 15, 20, 25, 30, 35,
		40, 45, 50, 55, 60, 70, 75, 80, 85, 90,
		100, 110, 120, 135, 150
	};

	public static readonly int[] costArray_2_100_25 = new int[25]
	{
		2, 3, 4, 5, 6, 7, 8, 9, 10, 12,
		14, 16, 18, 20, 24, 28, 33, 38, 44, 50,
		60, 70, 80, 90, 100
	};

	public static readonly int[] costArray_2_300_25 = new int[25]
	{
		2, 4, 6, 8, 10, 15, 20, 25, 30, 40,
		50, 60, 70, 80, 90, 100, 120, 140, 160, 180,
		200, 225, 250, 275, 300
	};

	public static readonly int[] costArray_5_100_15 = new int[15]
	{
		5, 6, 8, 10, 12, 14, 17, 20, 24, 30,
		38, 50, 64, 80, 100
	};

	public static readonly int[] costArray_5_300_25 = new int[25]
	{
		5, 6, 7, 8, 9, 10, 12, 14, 17, 20,
		24, 28, 34, 40, 50, 60, 72, 84, 100, 120,
		145, 175, 210, 250, 300
	};

	public static readonly int[] costArray_100_2000_25 = new int[25]
	{
		100, 150, 200, 250, 300, 350, 400, 450, 500, 550,
		600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500,
		1600, 1700, 1800, 1900, 2000
	};

	public static readonly float[] effectArray_1_100_25 = new float[25]
	{
		1f, 2f, 3f, 4f, 6f, 8f, 10f, 12f, 14f, 16f,
		18f, 20f, 23f, 26f, 30f, 34f, 38f, 42f, 46f, 50f,
		60f, 70f, 80f, 90f, 100f
	};

	public static readonly float[] effectArray_1_500_25 = new float[25]
	{
		1f, 2f, 3f, 4f, 5f, 10f, 15f, 20f, 25f, 30f,
		50f, 60f, 70f, 80f, 90f, 125f, 150f, 175f, 200f, 225f,
		300f, 350f, 400f, 450f, 500f
	};

	public static readonly float[] effectArray_ClickPower = new float[25]
	{
		1f, 2f, 4f, 8f, 12f, 20f, 30f, 50f, 80f, 150f,
		250f, 400f, 700f, 1200f, 2000f, 3000f, 5000f, 8000f, 12000f, 20000f,
		30000f, 50000f, 80000f, 150000f, 250000f
	};

	public static readonly float[] effectArray_1_5000_40 = new float[40]
	{
		1f, 2f, 3f, 4f, 5f, 10f, 15f, 20f, 25f, 30f,
		50f, 60f, 70f, 80f, 90f, 125f, 150f, 175f, 200f, 225f,
		300f, 350f, 400f, 450f, 500f, 600f, 700f, 800f, 900f, 1000f,
		1200f, 1400f, 1600f, 1800f, 2000f, 2500f, 3000f, 3500f, 4000f, 5000f
	};

	public static readonly float[] effectArray_1_1000_25 = new float[25]
	{
		1f, 2f, 3f, 4f, 5f, 10f, 15f, 20f, 25f, 30f,
		50f, 60f, 70f, 80f, 90f, 125f, 150f, 175f, 200f, 225f,
		300f, 450f, 600f, 800f, 1000f
	};

	public readonly Specialty[] specialties;

	public static readonly float[] efficiencyPerkDecay15 = new float[15]
	{
		0.8f, 0.64f, 0.5f, 0.4f, 0.32f, 0.26f, 0.2f, 0.16f, 0.13f, 0.1f,
		0.08f, 0.06f, 0.04f, 0.02f, 0.01f
	};

	public static float ForesterProductionBonusPerNearbyTree = 0f;

	public static float MineProductionBonusPerNearbyMineral = 0.05f;

	public static int FarmedResourceFactor = 4;

	public static float CropYieldBonusFactor = 0.5f;

	public static float FarmWaterBonusRate = 1f;

	public static float FarmFertilizerBonusRate = 1f;

	public static float FarmWaterDepletionRate = 0.03f;

	public static float FarmFertilizerDepletionRate = 0.01f;

	public static float MineShaftPickaxeDepletionRate = 0.004f;

	public static float EarthManaGrowthDepletionRate = 0.1f;

	public static float EarthManaGrowthBonusRate = 4f;

	public static float MineShaftPickaxeBonusRate = 5f;

	public static float AbsorbWaterSpeedFull = 1f;

	public static int AbsorbWaterMaxTiles = 40;

	public const float TrainTransferDuration = 0.5f;

	public const int AffinityGrowth = 20;

	public const int AffinityDecayFast = 20;

	public const int AffinityDecaySlow = 10;

	public const int AffinityGrowthMax = 1000;

	public static float ResearchBonusRecharger = 0.5f;

	public static float ResearchBonusTemple = 0.5f;

	public static float ResearchBonusShrine = 0.5f;

	public static float PastureUpgradeBonus = 0.5f;

	public static float GrainMillUpgradeBonus = 0.5f;

	public static float HouseUpgradeBonus = 0.1f;

	public static float OmnistoneUpgradeBonus = 0.5f;

	public static float OmnistoneUpgradeAdditionalBonus = 0.2f;

	public static float GlobalProductionBonus = 0.25f;

	public static float HouseProximityBonus = 0.05f;

	public static float MarketDecayPerHouse = 0.0035f;

	public static float MarketDecayScalePerUpgrade = 0.002f;

	public static float MarketUpgradeBonus = 1f;

	public static float StaticMarketDecayBase = 0.05f;

	public static float StaticMarketDecayScale = 0.5f;

	public static float FisheryBonusPerWaterTile = 0.01f;

	public static float NearbyFishingMaxTiles = 100f;

	public static float ManaMoveSpeed = 8f;

	public static float ManaMoveSpeedBonus = 0.2f;

	public static float OmniPipeMoveSpeed = 4f;

	public static float WaterPipeSpeed = 6f;

	public static float SteamPipeSpeed = 8f;

	public static float OmniPipeMoveSpeedBonus = 0.2f;

	public static float ManaTransferRate = 4f;

	public static float TeleporterProgressPerManaItem = 0.5f;

	public static float ConveyorBeltWoodenSpeed = 0.75f;

	public static float ConveyorBeltClothSpeed = 1.25f;

	public static float ConveyorBeltMetalSpeed = 2f;

	public static float ConveyorBeltMagicSpeed = 4f;

	public static float BeltMoveSpeedBonus = 0.2f;

	public static int HouseMaxResearchBonus = 5;

	public const float ChargeUnitsInManaPowerBar = 10f;

	public static float ChargeUnitsConsumedPerUnit = 0.1f;

	public static int MaxElementalBoosters = 2;

	public static int MaxSteamBoosters = 2;

	public static float ElementalBoosterBonusRate = 2f;

	public static float ManaBoosterDepletionRate = 0.5f;

	public static float SteamBoosterBonusRate = 2f;

	public static float SteamBoosterDepletionRate = 1f;

	public static float YellowCoinBoosterBonusRate = 1f;

	public static float RedCoinBoosterBonusRate = 1f;

	public static float BlueCoinBoosterBonusRate = 1f;

	public static float PurpleCoinBoosterBonusRate = 1f;

	public static float YellowCoinBoosterDepletionRate = 0.5f;

	public static float RedCoinBoosterDepletionRate = 0.25f;

	public static float BlueCoinBoosterDepletionRate = 0.2f;

	public static float PurpleCoinBoosterDepletionRate = 0.1f;

	public static float AirManaDepletionRate = 0.15f;

	public static float EarthManaDepletionRate = 0.15f;

	public static float WaterManaConsumedPerWaterUnit = 0.2f;

	public static float FireManaConsumedPerFuelUnit = 0.1f;

	public static float ManaProgressProvidedByPipeItem = 0.25f;

	public static float SpeedOfFillingConsumerSteamBars = 0.5f;

	public static float SpeedOfDepletingProducerSteamBars = 0.25f;

	public static int rngMin = 10000;

	public static int rngMax = 80000;

	public static string AutosaveName = "_Autosave";

	public static int MaxSuggestionDistance = 40;

	public static int MaxChuteSuggestionDistance = 10;

	public static int ExpandableInventoryCapacity = 20;

	public static ItemList emptyItemList;

	private static int TradeRecipeIndex;

	public static int DefaultHarvesterHutCapacity = 2;

	public static int MaxPopulationLevel => Instance.housingLevelConditions.Count;

	public static Data Instance => instance;

	public Data()
	{
		instance = this;
		emptyItemList = new ItemList();
		emptyItemList.isLocked = true;
		slotCapacityPerBaseLevel = new int[10] { 200, 400, 600, 800, 1000, 2000, 3000, 4000, 5000, 10000 };
		xpRequiredPerHouseLevel = new int[9] { 20, 100, 350, 800, 1500, 2500, 5000, 10000, 20000 };
		maxHousesPerResearchLevel = new int[6] { 0, 2, 6, 10, 14, 20 };
		maxBasesPerResearchLevel = new int[6] { 1, 2, 3, 4, 5, 6 };
		populationProvidedPerHouseLevel = new int[10] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 12 };
		happinessRequiredPerHousingLevel = new int[17]
		{
			8, 26, 60, 120, 200, 330, 520, 750, 1050, 1400,
			1800, 2250, 2800, 3410, 4080, 4810, 5600
		};
		maxHousesPerHousingHappinessLevel = new int[18]
		{
			4, 8, 12, 16, 22, 30, 40, 50, 60, 70,
			80, 90, 100, 110, 120, 130, 140, 150
		};
		explorationBonus = new int[12]
		{
			0, 5, 12, 21, 34, 49, 68, 89, 114, 151,
			172, 205
		};
		coins.Add(ItemType.YellowCoin);
		coins.Add(ItemType.RedCoin);
		coins.Add(ItemType.BlueCoin);
		coins.Add(ItemType.PurpleCoin);
		coins.Add(ItemType.OmniCoin);
		coins.Add(ItemType.Star);
		coins.Add(ItemType.ExchangeToken);
		entityTypeHierarchy = new List<EntityType>
		{
			EntityType.MenuPanel,
			EntityType.Building,
			EntityType.NaturalResource,
			EntityType.HarvestRecipe,
			EntityType.Farming,
			EntityType.Mining,
			EntityType.Recipe,
			EntityType.Research,
			EntityType.Upgrade,
			EntityType.Biome,
			EntityType.Item,
			EntityType.Quest,
			EntityType.Perk
		};
		specialties = new Specialty[14]
		{
			Specialty.PlantProducts,
			Specialty.AnimalProducts,
			Specialty.Construction,
			Specialty.Clothing,
			Specialty.Gourmet,
			Specialty.Metal,
			Specialty.Jewelry,
			Specialty.Tech,
			Specialty.Medicine,
			Specialty.Knowledge,
			Specialty.Magic,
			Specialty.Enchanting,
			Specialty.ElementalCrystals,
			Specialty.ElementalPower
		};
		houseBuildingTypes = new List<BuildingType>
		{
			BuildingType.Hut,
			BuildingType.Lodge,
			BuildingType.House,
			BuildingType.Mansion,
			BuildingType.Palace
		};
		linkedHouseLevelsRequiredPerBaseLevel = new int[9] { 8, 24, 48, 80, 120, 180, 260, 360, 500 };
		defaultItemDefs = new Dictionary<ItemType, ItemDef>(GameUtility.SharedEqualityComparer);
		LoadItemDefs();
		LoadHouseSellCategories();
		LoadHouseSellDataEverything();
		LoadObjectDefs();
		LoadNaturalResourceDefs();
		LoadRecipeDefaults();
		foreach (KeyValuePair<RecipeType, Recipe> defaultRecipeDef in defaultRecipeDefs)
		{
			defaultRecipeDef.Value.FinalizeMetadata();
		}
		LoadFarmingRecipeDefaults();
		LoadProspectingRecipeDefaults();
		LoadResourceResearchDefaults();
		LoadBuildingRecipeDefaults();
		LoadResearchRecipes();
		LoadHappinessRewards();
		LoadDisplayCategories();
		LoadHousingLevelConditions();
		LoadExplorationResults();
		LoadCoinCapacityData();
		LoadFarmingUpgrades();
		LoadMiningUpgrades();
		LoadWorkersPerBuildingUpgrades();
		LoadHarvestingUpgrades();
	}

	private void LoadItemDefs()
	{
		defaultWorkerItemTypes = new List<ItemType>();
		foreach (ItemType value in Enum.GetValues(typeof(ItemType)))
		{
			if (value != ItemType.None && IsItemEnabledDefault(value))
			{
				ItemDef itemDef = new ItemDef(value);
				itemDef.phase = MatterPhase.Solid;
				defaultItemDefs[value] = itemDef;
				itemDef.countsTowardsCrafting = !Item.IsCurrency(value) && Item.NaturalResourceFromItem(value) == NaturalResource.None;
				itemDef.sprite = IconManager.DefaultSpriteForItem(value);
				if (Item.IsWorkerUnit(value))
				{
					defaultWorkerItemTypes.Add(value);
				}
				itemDef.ConfigureForType();
			}
		}
		ItemDef itemDef2 = defaultItemDefs[ItemType.Wood];
		itemDef2.phase = MatterPhase.Solid;
		itemDef2.isLooseBulk = true;
		itemDef2.storageType = StorageType.Stockpile;
		ItemDef itemDef3 = defaultItemDefs[ItemType.RefinedSugar];
		itemDef3.phase = MatterPhase.Solid;
		itemDef3.isLooseBulk = true;
		itemDef3.storageType = StorageType.Pantry;
		ItemDef itemDef4 = defaultItemDefs[ItemType.DragonFruit];
		itemDef4.phase = MatterPhase.Solid;
		itemDef4.isLooseBulk = true;
		itemDef4.storageType = StorageType.CropSilo;
		ItemDef itemDef5 = defaultItemDefs[ItemType.CactusFruit];
		itemDef5.phase = MatterPhase.Solid;
		itemDef5.isLooseBulk = true;
		itemDef5.storageType = StorageType.CropSilo;
		ItemDef itemDef6 = defaultItemDefs[ItemType.IronOre];
		itemDef6.phase = MatterPhase.Solid;
		itemDef6.isLooseBulk = true;
		itemDef6.isRockResource = true;
		itemDef6.storageType = StorageType.OreSilo;
		ItemDef itemDef7 = defaultItemDefs[ItemType.GoldOre];
		itemDef7.phase = MatterPhase.Solid;
		itemDef7.isLooseBulk = true;
		itemDef7.isRockResource = true;
		itemDef7.storageType = StorageType.OreSilo;
		ItemDef itemDef8 = defaultItemDefs[ItemType.SilverOre];
		itemDef8.phase = MatterPhase.Solid;
		itemDef8.isLooseBulk = true;
		itemDef8.isRockResource = true;
		itemDef8.storageType = StorageType.OreSilo;
		ItemDef itemDef9 = defaultItemDefs[ItemType.Stone];
		itemDef9.phase = MatterPhase.Solid;
		itemDef9.isLooseBulk = true;
		itemDef9.isRockResource = true;
		itemDef9.storageType = StorageType.Stockpile;
		ItemDef itemDef10 = defaultItemDefs[ItemType.Coal];
		itemDef10.phase = MatterPhase.Solid;
		itemDef10.isLooseBulk = true;
		itemDef10.isRockResource = true;
		itemDef10.storageType = StorageType.OreSilo;
		ItemDef itemDef11 = defaultItemDefs[ItemType.AnimalFeed];
		itemDef11.phase = MatterPhase.Solid;
		itemDef11.isLooseBulk = true;
		itemDef11.storageType = StorageType.CropSilo;
		ItemDef itemDef12 = defaultItemDefs[ItemType.Flour];
		itemDef12.phase = MatterPhase.Solid;
		itemDef12.isLooseBulk = true;
		itemDef12.storageType = StorageType.Warehouse;
		ItemDef itemDef13 = defaultItemDefs[ItemType.Fertilizer];
		itemDef13.phase = MatterPhase.Solid;
		itemDef13.isLooseBulk = true;
		itemDef13.storageType = StorageType.Warehouse;
		ItemDef itemDef14 = defaultItemDefs[ItemType.Mana];
		itemDef14.phase = MatterPhase.Solid;
		itemDef14.isLooseBulk = true;
		itemDef14.isRockResource = true;
		itemDef14.storageType = StorageType.OreSilo;
		ItemDef itemDef15 = defaultItemDefs[ItemType.RedRuby];
		itemDef15.phase = MatterPhase.Solid;
		itemDef15.isLooseBulk = true;
		itemDef15.isRockResource = true;
		itemDef15.storageType = StorageType.OreSilo;
		ItemDef itemDef16 = defaultItemDefs[ItemType.YellowTopaz];
		itemDef16.phase = MatterPhase.Solid;
		itemDef16.isLooseBulk = true;
		itemDef16.isRockResource = true;
		itemDef16.storageType = StorageType.OreSilo;
		ItemDef itemDef17 = defaultItemDefs[ItemType.BlueSapphire];
		itemDef17.phase = MatterPhase.Solid;
		itemDef17.isLooseBulk = true;
		itemDef17.isRockResource = true;
		itemDef17.storageType = StorageType.OreSilo;
		ItemDef itemDef18 = defaultItemDefs[ItemType.PurpleAmethyst];
		itemDef18.phase = MatterPhase.Solid;
		itemDef18.isLooseBulk = true;
		itemDef18.isRockResource = true;
		itemDef18.storageType = StorageType.OreSilo;
		ItemDef itemDef19 = defaultItemDefs[ItemType.Plank];
		itemDef19.phase = MatterPhase.Solid;
		itemDef19.storageType = StorageType.Stockpile;
		itemDef19.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef20 = defaultItemDefs[ItemType.StoneSlab];
		itemDef20.phase = MatterPhase.Solid;
		itemDef20.storageType = StorageType.Stockpile;
		itemDef20.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef21 = defaultItemDefs[ItemType.WoodWheel];
		itemDef21.phase = MatterPhase.Solid;
		itemDef21.storageType = StorageType.Warehouse;
		itemDef21.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef22 = defaultItemDefs[ItemType.IronWheel];
		itemDef22.phase = MatterPhase.Solid;
		itemDef22.storageType = StorageType.Warehouse;
		itemDef22.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef23 = defaultItemDefs[ItemType.Nails];
		itemDef23.phase = MatterPhase.Solid;
		itemDef23.storageType = StorageType.Stockpile;
		itemDef23.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef24 = defaultItemDefs[ItemType.WoodAxe];
		itemDef24.phase = MatterPhase.Solid;
		itemDef24.storageType = StorageType.Warehouse;
		ItemDef itemDef25 = defaultItemDefs[ItemType.Pickaxe];
		itemDef25.phase = MatterPhase.Solid;
		itemDef25.storageType = StorageType.Warehouse;
		ItemDef itemDef26 = defaultItemDefs[ItemType.Shovel];
		itemDef26.phase = MatterPhase.Solid;
		itemDef26.storageType = StorageType.Warehouse;
		ItemDef itemDef27 = defaultItemDefs[ItemType.Wool];
		itemDef27.phase = MatterPhase.Solid;
		itemDef27.storageType = StorageType.Warehouse;
		ItemDef itemDef28 = defaultItemDefs[ItemType.CottonCloth];
		itemDef28.phase = MatterPhase.Solid;
		itemDef28.storageType = StorageType.Warehouse;
		itemDef28.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef29 = defaultItemDefs[ItemType.WoolCloth];
		itemDef29.phase = MatterPhase.Solid;
		itemDef29.storageType = StorageType.Warehouse;
		itemDef29.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef30 = defaultItemDefs[ItemType.Outfit];
		itemDef30.phase = MatterPhase.Solid;
		itemDef30.storageType = StorageType.Warehouse;
		ItemDef itemDef31 = defaultItemDefs[ItemType.Pants];
		itemDef31.phase = MatterPhase.Solid;
		itemDef31.storageType = StorageType.Warehouse;
		ItemDef itemDef32 = defaultItemDefs[ItemType.Cloak];
		itemDef32.phase = MatterPhase.Solid;
		itemDef32.storageType = StorageType.Warehouse;
		ItemDef itemDef33 = defaultItemDefs[ItemType.MagicCloak];
		itemDef33.phase = MatterPhase.Solid;
		itemDef33.storageType = StorageType.Warehouse;
		ItemDef itemDef34 = defaultItemDefs[ItemType.Shoe];
		itemDef34.phase = MatterPhase.Solid;
		itemDef34.storageType = StorageType.Warehouse;
		ItemDef itemDef35 = defaultItemDefs[ItemType.WarmCoat];
		itemDef35.phase = MatterPhase.Solid;
		itemDef35.storageType = StorageType.Warehouse;
		ItemDef itemDef36 = defaultItemDefs[ItemType.MagicShirt];
		itemDef36.phase = MatterPhase.Solid;
		itemDef36.storageType = StorageType.Warehouse;
		ItemDef itemDef37 = defaultItemDefs[ItemType.EnchantedAirCrown];
		itemDef37.phase = MatterPhase.Solid;
		itemDef37.storageType = StorageType.Treasury;
		ItemDef itemDef38 = defaultItemDefs[ItemType.EnchantedFireRing];
		itemDef38.phase = MatterPhase.Solid;
		itemDef38.storageType = StorageType.Treasury;
		ItemDef itemDef39 = defaultItemDefs[ItemType.EnchantedWaterRing];
		itemDef39.phase = MatterPhase.Solid;
		itemDef39.storageType = StorageType.Treasury;
		ItemDef itemDef40 = defaultItemDefs[ItemType.EnchantedEarthNecklace];
		itemDef40.phase = MatterPhase.Solid;
		itemDef40.storageType = StorageType.Treasury;
		ItemDef itemDef41 = defaultItemDefs[ItemType.PolishedStone];
		itemDef41.phase = MatterPhase.Solid;
		itemDef41.storageType = StorageType.Treasury;
		itemDef41.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef42 = defaultItemDefs[ItemType.CopperRing];
		itemDef42.phase = MatterPhase.Solid;
		itemDef42.storageType = StorageType.Treasury;
		itemDef42.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef43 = defaultItemDefs[ItemType.GoldRing];
		itemDef43.phase = MatterPhase.Solid;
		itemDef43.storageType = StorageType.Treasury;
		itemDef43.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef44 = defaultItemDefs[ItemType.SilverRing];
		itemDef44.phase = MatterPhase.Solid;
		itemDef44.storageType = StorageType.Treasury;
		itemDef44.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef45 = defaultItemDefs[ItemType.GoldCrown];
		itemDef45.phase = MatterPhase.Solid;
		itemDef45.storageType = StorageType.Treasury;
		itemDef45.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef46 = defaultItemDefs[ItemType.PolishedStoneRing];
		itemDef46.phase = MatterPhase.Solid;
		itemDef46.storageType = StorageType.Treasury;
		itemDef46.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef47 = defaultItemDefs[ItemType.RubyRing];
		itemDef47.phase = MatterPhase.Solid;
		itemDef47.storageType = StorageType.Treasury;
		itemDef47.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef48 = defaultItemDefs[ItemType.AmethystNecklace];
		itemDef48.phase = MatterPhase.Solid;
		itemDef48.storageType = StorageType.Treasury;
		itemDef48.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef49 = defaultItemDefs[ItemType.TopazCrown];
		itemDef49.phase = MatterPhase.Solid;
		itemDef49.storageType = StorageType.Treasury;
		itemDef49.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef50 = defaultItemDefs[ItemType.SapphireRing];
		itemDef50.phase = MatterPhase.Solid;
		itemDef50.storageType = StorageType.Treasury;
		itemDef50.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef51 = defaultItemDefs[ItemType.SilverChain];
		itemDef51.phase = MatterPhase.Solid;
		itemDef51.storageType = StorageType.Treasury;
		itemDef51.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef52 = defaultItemDefs[ItemType.MagicPlank];
		itemDef52.phase = MatterPhase.Solid;
		itemDef52.storageType = StorageType.Stockpile;
		itemDef52.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef53 = defaultItemDefs[ItemType.Gear];
		itemDef53.phase = MatterPhase.Solid;
		itemDef53.storageType = StorageType.Warehouse;
		itemDef53.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef54 = defaultItemDefs[ItemType.IronIngot];
		itemDef54.phase = MatterPhase.Solid;
		itemDef54.storageType = StorageType.Stockpile;
		itemDef54.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef55 = defaultItemDefs[ItemType.GoldIngot];
		itemDef55.phase = MatterPhase.Solid;
		itemDef55.storageType = StorageType.Warehouse;
		itemDef55.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef56 = defaultItemDefs[ItemType.SilverIngot];
		itemDef56.phase = MatterPhase.Solid;
		itemDef56.storageType = StorageType.Warehouse;
		itemDef56.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef57 = defaultItemDefs[ItemType.ReinforcedPlank];
		itemDef57.phase = MatterPhase.Solid;
		itemDef57.storageType = StorageType.Stockpile;
		itemDef57.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef58 = defaultItemDefs[ItemType.MagicStoneBrick];
		itemDef58.phase = MatterPhase.Solid;
		itemDef58.storageType = StorageType.Stockpile;
		itemDef58.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef59 = defaultItemDefs[ItemType.Omnistone];
		itemDef59.phase = MatterPhase.Solid;
		itemDef59.storageType = StorageType.Warehouse;
		ItemDef itemDef60 = defaultItemDefs[ItemType.MetalConveyorBelt];
		itemDef60.phase = MatterPhase.Solid;
		itemDef60.storageType = StorageType.Warehouse;
		ItemDef itemDef61 = defaultItemDefs[ItemType.ClothConveyorBelt];
		itemDef61.phase = MatterPhase.Solid;
		itemDef61.storageType = StorageType.Warehouse;
		ItemDef itemDef62 = defaultItemDefs[ItemType.MagicConveyorBelt];
		itemDef62.phase = MatterPhase.Solid;
		itemDef62.storageType = StorageType.Warehouse;
		ItemDef itemDef63 = defaultItemDefs[ItemType.ConveyorBeltWooden];
		itemDef63.phase = MatterPhase.Solid;
		itemDef63.storageType = StorageType.Warehouse;
		itemDef63.enabled = false;
		ItemDef itemDef64 = defaultItemDefs[ItemType.RailTile];
		itemDef64.phase = MatterPhase.Solid;
		itemDef64.storageType = StorageType.Warehouse;
		ItemDef itemDef65 = defaultItemDefs[ItemType.RailTileMagic];
		itemDef65.phase = MatterPhase.Solid;
		itemDef65.storageType = StorageType.Warehouse;
		ItemDef itemDef66 = defaultItemDefs[ItemType.RailTilePowered];
		itemDef66.phase = MatterPhase.Solid;
		itemDef66.storageType = StorageType.Warehouse;
		itemDef66.enabled = false;
		ItemDef itemDef67 = defaultItemDefs[ItemType.RailTileWood];
		itemDef67.phase = MatterPhase.Solid;
		itemDef67.storageType = StorageType.Warehouse;
		itemDef67.enabled = false;
		ItemDef itemDef68 = defaultItemDefs[ItemType.SteamPipe];
		itemDef68.phase = MatterPhase.Solid;
		itemDef68.storageType = StorageType.Warehouse;
		itemDef68.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef69 = defaultItemDefs[ItemType.MagmaPipe];
		itemDef69.phase = MatterPhase.Solid;
		itemDef69.storageType = StorageType.Warehouse;
		itemDef69.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef70 = defaultItemDefs[ItemType.ManaPipe];
		itemDef70.phase = MatterPhase.Solid;
		itemDef70.storageType = StorageType.Warehouse;
		itemDef70.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef71 = defaultItemDefs[ItemType.OmniPipe];
		itemDef71.phase = MatterPhase.Solid;
		itemDef71.storageType = StorageType.Warehouse;
		itemDef71.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef72 = defaultItemDefs[ItemType.Bread];
		itemDef72.phase = MatterPhase.Solid;
		itemDef72.storageType = StorageType.Pantry;
		itemDef72.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef73 = defaultItemDefs[ItemType.Jam];
		itemDef73.phase = MatterPhase.Solid;
		itemDef73.storageType = StorageType.Pantry;
		itemDef73.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef74 = defaultItemDefs[ItemType.Butter];
		itemDef74.phase = MatterPhase.Solid;
		itemDef74.storageType = StorageType.Pantry;
		itemDef74.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef75 = defaultItemDefs[ItemType.Cheese];
		itemDef75.phase = MatterPhase.Solid;
		itemDef75.storageType = StorageType.Pantry;
		itemDef75.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef76 = defaultItemDefs[ItemType.Cake];
		itemDef76.phase = MatterPhase.Solid;
		itemDef76.storageType = StorageType.Pantry;
		ItemDef itemDef77 = defaultItemDefs[ItemType.BerryCake];
		itemDef77.phase = MatterPhase.Solid;
		itemDef77.storageType = StorageType.Pantry;
		ItemDef itemDef78 = defaultItemDefs[ItemType.ApplePie];
		itemDef78.phase = MatterPhase.Solid;
		itemDef78.storageType = StorageType.Pantry;
		ItemDef itemDef79 = defaultItemDefs[ItemType.FishStew];
		itemDef79.phase = MatterPhase.Solid;
		itemDef79.storageType = StorageType.Pantry;
		ItemDef itemDef80 = defaultItemDefs[ItemType.MeatStew];
		itemDef80.phase = MatterPhase.Solid;
		itemDef80.storageType = StorageType.Pantry;
		ItemDef itemDef81 = defaultItemDefs[ItemType.VeggieStew];
		itemDef81.phase = MatterPhase.Solid;
		itemDef81.storageType = StorageType.Pantry;
		ItemDef itemDef82 = defaultItemDefs[ItemType.Sandwich];
		itemDef82.phase = MatterPhase.Solid;
		itemDef82.storageType = StorageType.Pantry;
		ItemDef itemDef83 = defaultItemDefs[ItemType.Egg];
		itemDef83.phase = MatterPhase.Solid;
		itemDef83.storageType = StorageType.Pantry;
		ItemDef itemDef84 = defaultItemDefs[ItemType.Fish];
		itemDef84.phase = MatterPhase.Solid;
		itemDef84.storageType = StorageType.Pantry;
		ItemDef itemDef85 = defaultItemDefs[ItemType.FishCooked];
		itemDef85.phase = MatterPhase.Solid;
		itemDef85.storageType = StorageType.Pantry;
		itemDef85.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef86 = defaultItemDefs[ItemType.CookedChicken];
		itemDef86.phase = MatterPhase.Solid;
		itemDef86.storageType = StorageType.Pantry;
		itemDef86.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef87 = defaultItemDefs[ItemType.RawChicken];
		itemDef87.phase = MatterPhase.Solid;
		itemDef87.storageType = StorageType.Pantry;
		ItemDef itemDef88 = defaultItemDefs[ItemType.CookedBeef];
		itemDef88.phase = MatterPhase.Solid;
		itemDef88.storageType = StorageType.Pantry;
		itemDef88.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef89 = defaultItemDefs[ItemType.RawBeef];
		itemDef89.phase = MatterPhase.Solid;
		itemDef89.storageType = StorageType.Pantry;
		defaultItemDefs[ItemType.Water].phase = MatterPhase.Liquid;
		defaultItemDefs[ItemType.Milk].phase = MatterPhase.Liquid;
		defaultItemDefs[ItemType.FishOil].phase = MatterPhase.Liquid;
		ItemDef itemDef90 = defaultItemDefs[ItemType.FruitJuice];
		itemDef90.phase = MatterPhase.Liquid;
		itemDef90.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef91 = defaultItemDefs[ItemType.PearJuice];
		itemDef91.phase = MatterPhase.Liquid;
		itemDef91.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef92 = defaultItemDefs[ItemType.StealthPotion];
		itemDef92.phase = MatterPhase.Liquid;
		itemDef92.storageType = StorageType.Warehouse;
		ItemDef itemDef93 = defaultItemDefs[ItemType.Antidote];
		itemDef93.phase = MatterPhase.Liquid;
		itemDef93.storageType = StorageType.Warehouse;
		itemDef93.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef94 = defaultItemDefs[ItemType.Remedy];
		itemDef94.phase = MatterPhase.Liquid;
		itemDef94.storageType = StorageType.Warehouse;
		itemDef94.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef95 = defaultItemDefs[ItemType.Power];
		itemDef95.phase = MatterPhase.Energy;
		itemDef95.storageType = StorageType.Energy;
		itemDef95.tradeBuilding = BuildingType.PowerLine;
		SetAsBook(ItemType.ResearchTomeNature1);
		SetAsBook(ItemType.ResearchTomeNature2);
		SetAsBook(ItemType.ResearchTomeNature3);
		SetAsBook(ItemType.ResearchTomeMagic1);
		SetAsBook(ItemType.ResearchTomeMagic2);
		SetAsBook(ItemType.ResearchTomeMagic3);
		SetAsBook(ItemType.ResearchTomeIndustry1);
		SetAsBook(ItemType.ResearchTomeIndustry2);
		SetAsBook(ItemType.ResearchTomeIndustry3);
		SetAsBook(ItemType.ResearchTomeAir1);
		SetAsBook(ItemType.ResearchTomeAir2);
		SetAsBook(ItemType.ResearchTomeAir3);
		SetAsBook(ItemType.ResearchTomeFire1);
		SetAsBook(ItemType.ResearchTomeFire2);
		SetAsBook(ItemType.ResearchTomeFire3);
		SetAsBook(ItemType.ResearchTomeWater1);
		SetAsBook(ItemType.ResearchTomeWater2);
		SetAsBook(ItemType.ResearchTomeWater3);
		SetAsBook(ItemType.ResearchTomeEarth1);
		SetAsBook(ItemType.ResearchTomeEarth2);
		SetAsBook(ItemType.ResearchTomeEarth3);
		SetAsBook(ItemType.EnchantedBookBlue);
		SetAsBook(ItemType.EnchantedBookPurple);
		SetAsBook(ItemType.EnchantedBookRed);
		SetAsBook(ItemType.EnchantedBookYellow);
		ItemDef itemDef96 = defaultItemDefs[ItemType.HealthPotion];
		itemDef96.phase = MatterPhase.Liquid;
		itemDef96.storageType = StorageType.Warehouse;
		itemDef96.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef97 = defaultItemDefs[ItemType.Leather];
		itemDef97.phase = MatterPhase.Solid;
		itemDef97.storageType = StorageType.Warehouse;
		itemDef97.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef98 = defaultItemDefs[ItemType.Bandage];
		itemDef98.phase = MatterPhase.Solid;
		itemDef98.storageType = StorageType.Warehouse;
		itemDef98.tradeBuilding = BuildingType.TradingPost;
		itemDef98.enabled = false;
		ItemDef itemDef99 = defaultItemDefs[ItemType.Poultice];
		itemDef99.phase = MatterPhase.Solid;
		itemDef99.storageType = StorageType.Warehouse;
		itemDef99.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef100 = defaultItemDefs[ItemType.Ointment];
		itemDef100.phase = MatterPhase.Solid;
		itemDef100.storageType = StorageType.Warehouse;
		itemDef100.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef101 = defaultItemDefs[ItemType.MedicalWrap];
		itemDef101.phase = MatterPhase.Solid;
		itemDef101.storageType = StorageType.Warehouse;
		ItemDef itemDef102 = defaultItemDefs[ItemType.FishOil];
		itemDef102.phase = MatterPhase.Liquid;
		itemDef102.storageType = StorageType.Warehouse;
		itemDef102.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef103 = defaultItemDefs[ItemType.Remedy];
		itemDef103.phase = MatterPhase.Liquid;
		itemDef103.storageType = StorageType.Warehouse;
		itemDef103.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef104 = defaultItemDefs[ItemType.Antidote];
		itemDef104.phase = MatterPhase.Liquid;
		itemDef104.storageType = StorageType.Warehouse;
		itemDef104.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef105 = defaultItemDefs[ItemType.StealthPotion];
		itemDef105.phase = MatterPhase.Liquid;
		itemDef105.storageType = StorageType.Warehouse;
		ItemDef itemDef106 = defaultItemDefs[ItemType.BerryJam];
		itemDef106.phase = MatterPhase.Solid;
		itemDef106.storageType = StorageType.Pantry;
		itemDef106.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef107 = defaultItemDefs[ItemType.PearJam];
		itemDef107.phase = MatterPhase.Solid;
		itemDef107.storageType = StorageType.Pantry;
		itemDef107.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef108 = defaultItemDefs[ItemType.CactusJam];
		itemDef108.phase = MatterPhase.Solid;
		itemDef108.storageType = StorageType.Pantry;
		itemDef108.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef109 = defaultItemDefs[ItemType.PearJuice];
		itemDef109.phase = MatterPhase.Liquid;
		itemDef109.storageType = StorageType.Barrel;
		itemDef109.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef110 = defaultItemDefs[ItemType.BerryJuice];
		itemDef110.phase = MatterPhase.Liquid;
		itemDef110.storageType = StorageType.Barrel;
		itemDef110.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef111 = defaultItemDefs[ItemType.DragonPunch];
		itemDef111.phase = MatterPhase.Liquid;
		itemDef111.storageType = StorageType.Barrel;
		itemDef111.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef112 = defaultItemDefs[ItemType.CopperOre];
		itemDef112.phase = MatterPhase.Solid;
		itemDef112.isRockResource = true;
		itemDef112.storageType = StorageType.OreSilo;
		ItemDef itemDef113 = defaultItemDefs[ItemType.ManaEther];
		itemDef113.phase = MatterPhase.Liquid;
		itemDef113.storageType = StorageType.Ether;
		itemDef113.tradeBuilding = BuildingType.None;
		ItemDef itemDef114 = defaultItemDefs[ItemType.FireEther];
		itemDef114.phase = MatterPhase.Liquid;
		itemDef114.storageType = StorageType.Ether;
		itemDef114.tradeBuilding = BuildingType.None;
		ItemDef itemDef115 = defaultItemDefs[ItemType.WaterEther];
		itemDef115.phase = MatterPhase.Liquid;
		itemDef115.storageType = StorageType.Ether;
		itemDef115.tradeBuilding = BuildingType.None;
		ItemDef itemDef116 = defaultItemDefs[ItemType.EarthEther];
		itemDef116.phase = MatterPhase.Liquid;
		itemDef116.storageType = StorageType.Ether;
		itemDef116.tradeBuilding = BuildingType.None;
		ItemDef itemDef117 = defaultItemDefs[ItemType.AirEther];
		itemDef117.phase = MatterPhase.Liquid;
		itemDef117.storageType = StorageType.Ether;
		itemDef117.tradeBuilding = BuildingType.None;
		ItemDef itemDef118 = defaultItemDefs[ItemType.RefinedStoneBrick];
		itemDef118.phase = MatterPhase.Solid;
		itemDef118.storageType = StorageType.Stockpile;
		ItemDef itemDef119 = defaultItemDefs[ItemType.RefinedPlank];
		itemDef119.phase = MatterPhase.Solid;
		itemDef119.storageType = StorageType.Stockpile;
		itemDef119.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef120 = defaultItemDefs[ItemType.Steam];
		itemDef120.phase = MatterPhase.Gas;
		itemDef120.storageType = StorageType.PressureTank;
		itemDef120.tradeBuilding = BuildingType.SteamPipeline;
		ItemDef itemDef121 = defaultItemDefs[ItemType.PurifiedFire];
		itemDef121.phase = MatterPhase.Solid;
		itemDef121.storageType = StorageType.Crystal;
		itemDef121.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef122 = defaultItemDefs[ItemType.PurifiedWater];
		itemDef122.phase = MatterPhase.Solid;
		itemDef122.storageType = StorageType.Crystal;
		itemDef122.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef123 = defaultItemDefs[ItemType.PurifiedEarth];
		itemDef123.phase = MatterPhase.Solid;
		itemDef123.storageType = StorageType.Crystal;
		itemDef123.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef124 = defaultItemDefs[ItemType.PurifiedAir];
		itemDef124.phase = MatterPhase.Solid;
		itemDef124.storageType = StorageType.Crystal;
		itemDef124.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef125 = defaultItemDefs[ItemType.DepletedFire];
		itemDef125.phase = MatterPhase.Solid;
		itemDef125.storageType = StorageType.Crystal;
		itemDef125.enabled = false;
		ItemDef itemDef126 = defaultItemDefs[ItemType.DepletedWater];
		itemDef126.phase = MatterPhase.Solid;
		itemDef126.storageType = StorageType.Crystal;
		itemDef126.enabled = false;
		ItemDef itemDef127 = defaultItemDefs[ItemType.DepletedEarth];
		itemDef127.phase = MatterPhase.Solid;
		itemDef127.storageType = StorageType.Crystal;
		itemDef127.enabled = false;
		ItemDef itemDef128 = defaultItemDefs[ItemType.PurifiedMana];
		itemDef128.phase = MatterPhase.Solid;
		itemDef128.storageType = StorageType.Crystal;
		itemDef128.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef129 = defaultItemDefs[ItemType.DepletedMana];
		itemDef129.phase = MatterPhase.Solid;
		itemDef129.storageType = StorageType.Crystal;
		itemDef129.enabled = false;
		ItemDef itemDef130 = defaultItemDefs[ItemType.DepletedAir];
		itemDef130.phase = MatterPhase.Solid;
		itemDef130.storageType = StorageType.Crystal;
		itemDef130.enabled = false;
		ItemDef itemDef131 = defaultItemDefs[ItemType.Omnistone];
		itemDef131.phase = MatterPhase.Solid;
		itemDef131.storageType = StorageType.Omnistone;
		itemDef131.tradeBuilding = BuildingType.OmniPipeline;
		ItemDef itemDef132 = defaultItemDefs[ItemType.WaterPipe];
		itemDef132.phase = MatterPhase.Solid;
		itemDef132.storageType = StorageType.Warehouse;
		itemDef132.enabled = false;
		ItemDef itemDef133 = defaultItemDefs[ItemType.Magma];
		itemDef133.phase = MatterPhase.Liquid;
		itemDef133.storageType = StorageType.Specialty;
		itemDef133.tradeBuilding = BuildingType.None;
		itemDef133.enabled = false;
		ItemDef itemDef134 = defaultItemDefs[ItemType.Fire];
		itemDef134.phase = MatterPhase.Liquid;
		itemDef134.storageType = StorageType.Fire;
		itemDef134.tradeBuilding = BuildingType.MagmaPipeline;
		ItemDef itemDef135 = defaultItemDefs[ItemType.CopperIngot];
		itemDef135.phase = MatterPhase.Solid;
		itemDef135.storageType = StorageType.Stockpile;
		itemDef135.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef136 = defaultItemDefs[ItemType.CopperWire];
		itemDef136.phase = MatterPhase.Solid;
		itemDef136.storageType = StorageType.Warehouse;
		itemDef136.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef137 = defaultItemDefs[ItemType.Steel];
		itemDef137.phase = MatterPhase.Solid;
		itemDef137.storageType = StorageType.Stockpile;
		itemDef137.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef138 = defaultItemDefs[ItemType.GlassPanel];
		itemDef138.phase = MatterPhase.Solid;
		itemDef138.storageType = StorageType.Warehouse;
		itemDef138.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef139 = defaultItemDefs[ItemType.SolarCell];
		itemDef139.phase = MatterPhase.Solid;
		itemDef139.storageType = StorageType.Warehouse;
		itemDef139.tradeBuilding = BuildingType.TradingPost;
		itemDef139.enabled = false;
		ItemDef itemDef140 = defaultItemDefs[ItemType.Quartz];
		itemDef140.phase = MatterPhase.Solid;
		itemDef140.storageType = StorageType.OreSilo;
		itemDef140.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef141 = defaultItemDefs[ItemType.FishFood];
		itemDef141.phase = MatterPhase.Solid;
		itemDef141.storageType = StorageType.CropSilo;
		itemDef141.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef142 = defaultItemDefs[ItemType.FishingNet];
		itemDef142.phase = MatterPhase.Solid;
		itemDef142.storageType = StorageType.Warehouse;
		itemDef142.tradeBuilding = BuildingType.None;
		ItemDef itemDef143 = defaultItemDefs[ItemType.MagicFishingNet];
		itemDef143.phase = MatterPhase.Solid;
		itemDef143.storageType = StorageType.Warehouse;
		itemDef143.tradeBuilding = BuildingType.None;
		ItemDef itemDef144 = defaultItemDefs[ItemType.MagicPotion];
		itemDef144.phase = MatterPhase.Liquid;
		itemDef144.storageType = StorageType.Warehouse;
		itemDef144.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef145 = defaultItemDefs[ItemType.AttackPotion];
		itemDef145.phase = MatterPhase.Liquid;
		itemDef145.storageType = StorageType.Warehouse;
		ItemDef itemDef146 = defaultItemDefs[ItemType.SpeedPotion];
		itemDef146.phase = MatterPhase.Liquid;
		itemDef146.storageType = StorageType.Warehouse;
		ItemDef itemDef147 = defaultItemDefs[ItemType.MagicPants];
		itemDef147.phase = MatterPhase.Solid;
		itemDef147.storageType = StorageType.Warehouse;
		ItemDef itemDef148 = defaultItemDefs[ItemType.Boots];
		itemDef148.phase = MatterPhase.Solid;
		itemDef148.storageType = StorageType.Warehouse;
		itemDef148.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef149 = defaultItemDefs[ItemType.MagicBoots];
		itemDef149.phase = MatterPhase.Solid;
		itemDef149.storageType = StorageType.Warehouse;
		itemDef149.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef150 = defaultItemDefs[ItemType.Hat];
		itemDef150.phase = MatterPhase.Solid;
		itemDef150.storageType = StorageType.Warehouse;
		itemDef150.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef151 = defaultItemDefs[ItemType.MagicHat];
		itemDef151.phase = MatterPhase.Solid;
		itemDef151.storageType = StorageType.Warehouse;
		itemDef151.tradeBuilding = BuildingType.TradingPost;
		ItemDef itemDef152 = defaultItemDefs[ItemType.MagicRing];
		itemDef152.phase = MatterPhase.Solid;
		itemDef152.storageType = StorageType.Treasury;
		ItemDef itemDef153 = defaultItemDefs[ItemType.MagicBoatComponent];
		itemDef153.phase = MatterPhase.Solid;
		itemDef153.storageType = StorageType.Warehouse;
		ItemDef itemDef154 = defaultItemDefs[ItemType.AirshipComponent];
		itemDef154.phase = MatterPhase.Solid;
		itemDef154.storageType = StorageType.Warehouse;
		ItemDef itemDef155 = defaultItemDefs[ItemType.ManaPower];
		itemDef155.phase = MatterPhase.Energy;
		itemDef155.storageType = StorageType.ManaBattery;
		itemDef155.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef156 = defaultItemDefs[ItemType.UtilityElementalFirePower];
		itemDef156.phase = MatterPhase.Energy;
		itemDef156.storageType = StorageType.ManaBattery;
		itemDef156.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef157 = defaultItemDefs[ItemType.UtilityElementalWaterPower];
		itemDef157.phase = MatterPhase.Energy;
		itemDef157.storageType = StorageType.ManaBattery;
		itemDef157.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef158 = defaultItemDefs[ItemType.UtilityElementalEarthPower];
		itemDef158.phase = MatterPhase.Energy;
		itemDef158.storageType = StorageType.ManaBattery;
		itemDef158.tradeBuilding = BuildingType.ManaPipeline;
		ItemDef itemDef159 = defaultItemDefs[ItemType.UtilityElementalAirPower];
		itemDef159.phase = MatterPhase.Energy;
		itemDef159.storageType = StorageType.ManaBattery;
		itemDef159.tradeBuilding = BuildingType.ManaPipeline;
		foreach (KeyValuePair<ItemType, ItemDef> defaultItemDef in defaultItemDefs)
		{
			if (Item.IsDefaultPhysicalItem(defaultItemDef.Key) && defaultItemDef.Value.storageType == StorageType.None)
			{
				Debug.LogError("No storage for " + defaultItemDef.Key);
			}
		}
	}

	private void SetAsBook(ItemType t)
	{
		if (defaultItemDefs.TryGetValue(t, out var value))
		{
			value.phase = MatterPhase.Solid;
			value.storageType = StorageType.Library;
		}
	}

	private void LoadResearchRecipes()
	{
		civicsResearch = new List<ResearchType>();
		civicsResearch.Add(ResearchType.Civics1_Disabled);
		civicsResearch.Add(ResearchType.Civics2_Disabled);
		civicsResearch.Add(ResearchType.Civics3);
		civicsResearch.Add(ResearchType.Civics4);
		civicsResearch.Add(ResearchType.Civics5);
	}

	private void LoadHouseSellCategories()
	{
		satisfactionCategoryMaxHappiness = new Dictionary<ItemType, int[]>();
		satisfactionCategoryMaxHappiness[ItemType.FilterCategoryHouseLiquids] = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategoryBasicFood] = new int[10] { 3, 4, 4, 5, 5, 6, 6, 6, 6, 6 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategoryGeneralHardware] = new int[10] { 1, 2, 2, 3, 3, 3, 3, 3, 3, 4 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategoryGeneralClothing] = new int[10] { 1, 1, 2, 3, 3, 3, 3, 3, 3, 3 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategoryMedicineBasic] = new int[10] { 1, 1, 2, 2, 3, 3, 3, 3, 3, 3 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategoryKnowledgeBasic] = new int[10] { 0, 1, 2, 2, 2, 3, 3, 3, 3, 3 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategorySpecialtyGourmet] = new int[10] { 0, 0, 0, 1, 2, 3, 4, 4, 4, 6 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategoryMedicineMagic] = new int[10] { 0, 0, 0, 0, 1, 2, 2, 3, 4, 6 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategoryKnowledgeMagic] = new int[10] { 0, 0, 0, 0, 1, 2, 2, 3, 4, 6 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategorySpecialtyJewelry] = new int[10] { 0, 0, 0, 0, 0, 0, 2, 4, 6, 6 };
		satisfactionCategoryMaxHappiness[ItemType.FilterCategorySpecialtyMagic] = new int[10] { 0, 0, 0, 0, 0, 0, 2, 4, 6, 8 };
		houseSatisfactionData = new Dictionary<ItemType, SatisfactionCategory>();
		foreach (KeyValuePair<ItemType, SatisfactionCategory> houseSatisfactionDatum in houseSatisfactionData)
		{
			if (Instance.satisfactionCategoryMaxHappiness.TryGetValue(houseSatisfactionDatum.Key, out var value))
			{
				houseSatisfactionDatum.Value.maxHappiness = new int[value.Length];
				for (int i = 0; i < value.Length; i++)
				{
					houseSatisfactionDatum.Value.maxHappiness[i] = value[i];
				}
				continue;
			}
			houseSatisfactionDatum.Value.maxHappiness = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		}
		houseSatisfactionCategories = new List<ItemType>();
		foreach (KeyValuePair<ItemType, SatisfactionCategory> houseSatisfactionDatum2 in houseSatisfactionData)
		{
			houseSatisfactionCategories.Add(houseSatisfactionDatum2.Key);
		}
	}

	private void LoadHouseSellDataEverything()
	{
		houseSellData = new Dictionary<ItemType, HouseSellData>(GameUtility.SharedEqualityComparer);
		houseSellData[ItemType.Stone] = new HouseSellData(ItemType.YellowCoin, 1, 1, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.StoneSlab] = new HouseSellData(ItemType.YellowCoin, 4, 2, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.RefinedStoneBrick] = new HouseSellData(ItemType.YellowCoin, 8, 3, BuildingType.GeneralGoods, 2);
		houseSellData[ItemType.Wood] = new HouseSellData(ItemType.YellowCoin, 1, 1, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.Plank] = new HouseSellData(ItemType.YellowCoin, 3, 1, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.RefinedPlank] = new HouseSellData(ItemType.YellowCoin, 8, 2, BuildingType.GeneralGoods, 2);
		houseSellData[ItemType.Coal] = new HouseSellData(ItemType.YellowCoin, 2, 1, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.Cotton] = new HouseSellData(ItemType.YellowCoin, 1, 1, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.ReinforcedPlank] = new HouseSellData(ItemType.YellowCoin, 36, 4, BuildingType.GeneralGoods, 2);
		houseSellData[ItemType.MagicPlank] = new HouseSellData(ItemType.PurpleCoin, 2, 4, BuildingType.GeneralGoods, 2);
		houseSellData[ItemType.MagicStoneBrick] = new HouseSellData(ItemType.PurpleCoin, 3, 4, BuildingType.GeneralGoods, 2);
		houseSellData[ItemType.Fertilizer] = new HouseSellData(ItemType.YellowCoin, 3, 2, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.AnimalFeed] = new HouseSellData(ItemType.YellowCoin, 2, 2, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.FishFood] = new HouseSellData(ItemType.YellowCoin, 3, 2, BuildingType.GeneralGoods, 1);
		houseSellData[ItemType.Grain] = new HouseSellData(ItemType.YellowCoin, 1, 1, BuildingType.Market, 1);
		houseSellData[ItemType.Flour] = new HouseSellData(ItemType.YellowCoin, 4, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Bread] = new HouseSellData(ItemType.YellowCoin, 12, 3, BuildingType.Market, 2);
		houseSellData[ItemType.Water] = new HouseSellData(ItemType.YellowCoin, 1, 1, BuildingType.Market, 1);
		houseSellData[ItemType.Egg] = new HouseSellData(ItemType.YellowCoin, 2, 1, BuildingType.Market, 1);
		houseSellData[ItemType.Fish] = new HouseSellData(ItemType.YellowCoin, 2, 1, BuildingType.Market, 1);
		houseSellData[ItemType.FishCooked] = new HouseSellData(ItemType.YellowCoin, 4, 3, BuildingType.Market, 2);
		houseSellData[ItemType.RawChicken] = new HouseSellData(ItemType.YellowCoin, 5, 1, BuildingType.Market, 1);
		houseSellData[ItemType.CookedChicken] = new HouseSellData(ItemType.YellowCoin, 8, 3, BuildingType.Market, 2);
		houseSellData[ItemType.RawBeef] = new HouseSellData(ItemType.YellowCoin, 7, 2, BuildingType.Market, 1);
		houseSellData[ItemType.CookedBeef] = new HouseSellData(ItemType.YellowCoin, 14, 4, BuildingType.Market, 2);
		houseSellData[ItemType.Carrot] = new HouseSellData(ItemType.YellowCoin, 1, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Potato] = new HouseSellData(ItemType.YellowCoin, 1, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Tomato] = new HouseSellData(ItemType.YellowCoin, 1, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Apple] = new HouseSellData(ItemType.YellowCoin, 2, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Pear] = new HouseSellData(ItemType.YellowCoin, 2, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Berries] = new HouseSellData(ItemType.YellowCoin, 2, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Herb] = new HouseSellData(ItemType.YellowCoin, 2, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Sugar] = new HouseSellData(ItemType.YellowCoin, 1, 2, BuildingType.Market, 1);
		houseSellData[ItemType.RefinedSugar] = new HouseSellData(ItemType.YellowCoin, 3, 3, BuildingType.Market, 1);
		houseSellData[ItemType.CactusFruit] = new HouseSellData(ItemType.YellowCoin, 4, 2, BuildingType.Market, 1);
		houseSellData[ItemType.DragonFruit] = new HouseSellData(ItemType.YellowCoin, 5, 2, BuildingType.Market, 1);
		houseSellData[ItemType.FruitJuice] = new HouseSellData(ItemType.YellowCoin, 6, 3, BuildingType.Market, 1);
		houseSellData[ItemType.PearJuice] = new HouseSellData(ItemType.YellowCoin, 6, 3, BuildingType.Market, 1);
		houseSellData[ItemType.BerryJuice] = new HouseSellData(ItemType.YellowCoin, 6, 3, BuildingType.Market, 1);
		houseSellData[ItemType.Milk] = new HouseSellData(ItemType.YellowCoin, 6, 2, BuildingType.Market, 1);
		houseSellData[ItemType.Butter] = new HouseSellData(ItemType.YellowCoin, 14, 5, BuildingType.Market, 2);
		houseSellData[ItemType.Paper] = new HouseSellData(ItemType.YellowCoin, 2, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.Book] = new HouseSellData(ItemType.YellowCoin, 6, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.ResearchTomeGeneral] = new HouseSellData(ItemType.YellowCoin, 6, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.ResearchTomeIndustry1] = new HouseSellData(ItemType.RedCoin, 18, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.ResearchTomeIndustry2] = new HouseSellData(ItemType.RedCoin, 40, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.ResearchTomeIndustry3] = new HouseSellData(ItemType.RedCoin, 90, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.ResearchTomeMagic1] = new HouseSellData(ItemType.BlueCoin, 20, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.ResearchTomeMagic2] = new HouseSellData(ItemType.BlueCoin, 40, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.ResearchTomeMagic3] = new HouseSellData(ItemType.BlueCoin, 90, 2, BuildingType.Bookstore, 1);
		houseSellData[ItemType.EnchantedBook] = new HouseSellData(ItemType.PurpleCoin, 5, 4, BuildingType.Bookstore, 2);
		houseSellData[ItemType.EnchantedBookRed] = new HouseSellData(ItemType.PurpleCoin, 15, 5, BuildingType.Bookstore, 3);
		houseSellData[ItemType.EnchantedBookYellow] = new HouseSellData(ItemType.PurpleCoin, 15, 5, BuildingType.Bookstore, 3);
		houseSellData[ItemType.EnchantedBookBlue] = new HouseSellData(ItemType.PurpleCoin, 15, 5, BuildingType.Bookstore, 3);
		houseSellData[ItemType.EnchantedBookPurple] = new HouseSellData(ItemType.PurpleCoin, 15, 5, BuildingType.Bookstore, 3);
		houseSellData[ItemType.Cheese] = new HouseSellData(ItemType.YellowCoin, 24, 5, BuildingType.FancyFoods, 2);
		houseSellData[ItemType.Jam] = new HouseSellData(ItemType.YellowCoin, 12, 5, BuildingType.FancyFoods, 2);
		houseSellData[ItemType.PearJam] = new HouseSellData(ItemType.YellowCoin, 12, 5, BuildingType.FancyFoods, 2);
		houseSellData[ItemType.BerryJam] = new HouseSellData(ItemType.YellowCoin, 12, 5, BuildingType.FancyFoods, 2);
		houseSellData[ItemType.CactusJam] = new HouseSellData(ItemType.YellowCoin, 25, 5, BuildingType.FancyFoods, 2);
		houseSellData[ItemType.DragonPunch] = new HouseSellData(ItemType.YellowCoin, 20, 5, BuildingType.FancyFoods, 3);
		houseSellData[ItemType.VeggieStew] = new HouseSellData(ItemType.YellowCoin, 20, 5, BuildingType.FancyFoods, 3);
		houseSellData[ItemType.FishStew] = new HouseSellData(ItemType.YellowCoin, 25, 5, BuildingType.FancyFoods, 3);
		houseSellData[ItemType.MeatStew] = new HouseSellData(ItemType.YellowCoin, 35, 5, BuildingType.FancyFoods, 3);
		houseSellData[ItemType.Sandwich] = new HouseSellData(ItemType.YellowCoin, 40, 5, BuildingType.FancyFoods, 3);
		houseSellData[ItemType.ApplePie] = new HouseSellData(ItemType.YellowCoin, 50, 5, BuildingType.FancyFoods, 3);
		houseSellData[ItemType.Cake] = new HouseSellData(ItemType.YellowCoin, 50, 4, BuildingType.FancyFoods, 3);
		houseSellData[ItemType.BerryCake] = new HouseSellData(ItemType.YellowCoin, 120, 5, BuildingType.FancyFoods, 5);
		houseSellData[ItemType.WoodWheel] = new HouseSellData(ItemType.RedCoin, 7, 1, BuildingType.HardwareStore, 1);
		houseSellData[ItemType.IronIngot] = new HouseSellData(ItemType.RedCoin, 3, 1, BuildingType.HardwareStore, 1);
		houseSellData[ItemType.CopperIngot] = new HouseSellData(ItemType.RedCoin, 3, 1, BuildingType.HardwareStore, 1);
		houseSellData[ItemType.SilverIngot] = new HouseSellData(ItemType.BlueCoin, 4, 4, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.GoldIngot] = new HouseSellData(ItemType.BlueCoin, 4, 4, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.Gear] = new HouseSellData(ItemType.RedCoin, 5, 2, BuildingType.HardwareStore, 1);
		houseSellData[ItemType.IronWheel] = new HouseSellData(ItemType.RedCoin, 10, 2, BuildingType.HardwareStore, 1);
		houseSellData[ItemType.Nails] = new HouseSellData(ItemType.RedCoin, 2, 2, BuildingType.HardwareStore, 1);
		houseSellData[ItemType.Shovel] = new HouseSellData(ItemType.RedCoin, 4, 1, BuildingType.HardwareStore, 1);
		houseSellData[ItemType.WoodAxe] = new HouseSellData(ItemType.RedCoin, 8, 2, BuildingType.HardwareStore, 1);
		houseSellData[ItemType.Pickaxe] = new HouseSellData(ItemType.RedCoin, 12, 2, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.CopperWire] = new HouseSellData(ItemType.RedCoin, 6, 2, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.Steel] = new HouseSellData(ItemType.RedCoin, 25, 5, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.GlassPanel] = new HouseSellData(ItemType.RedCoin, 5, 4, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.ClothConveyorBelt] = new HouseSellData(ItemType.RedCoin, 10, 4, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.MetalConveyorBelt] = new HouseSellData(ItemType.RedCoin, 30, 4, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.MagicConveyorBelt] = new HouseSellData(ItemType.PurpleCoin, 10, 5, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.RailTile] = new HouseSellData(ItemType.RedCoin, 20, 4, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.RailTileMagic] = new HouseSellData(ItemType.PurpleCoin, 6, 5, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.SteamPipe] = new HouseSellData(ItemType.RedCoin, 6, 2, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.MagmaPipe] = new HouseSellData(ItemType.RedCoin, 25, 4, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.ManaPipe] = new HouseSellData(ItemType.PurpleCoin, 2, 5, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.MagicBoatComponent] = new HouseSellData(ItemType.PurpleCoin, 6, 5, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.AirshipComponent] = new HouseSellData(ItemType.PurpleCoin, 10, 5, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.OmniPipe] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.HardwareStore, 2);
		houseSellData[ItemType.Wool] = new HouseSellData(ItemType.RedCoin, 3, 2, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.CottonCloth] = new HouseSellData(ItemType.RedCoin, 2, 2, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.WoolCloth] = new HouseSellData(ItemType.RedCoin, 4, 2, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.Leather] = new HouseSellData(ItemType.RedCoin, 5, 2, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.Outfit] = new HouseSellData(ItemType.RedCoin, 5, 4, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.Pants] = new HouseSellData(ItemType.RedCoin, 7, 4, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.Hat] = new HouseSellData(ItemType.RedCoin, 5, 4, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.Boots] = new HouseSellData(ItemType.RedCoin, 13, 4, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.Shoe] = new HouseSellData(ItemType.RedCoin, 12, 4, BuildingType.ClothingStore, 1);
		houseSellData[ItemType.Cloak] = new HouseSellData(ItemType.RedCoin, 20, 5, BuildingType.ClothingStore, 2);
		houseSellData[ItemType.WarmCoat] = new HouseSellData(ItemType.RedCoin, 24, 5, BuildingType.ClothingStore, 2);
		houseSellData[ItemType.Poultice] = new HouseSellData(ItemType.BlueCoin, 2, 4, BuildingType.Apothecary, 1);
		houseSellData[ItemType.MedicalWrap] = new HouseSellData(ItemType.BlueCoin, 16, 5, BuildingType.Apothecary, 3);
		houseSellData[ItemType.FishOil] = new HouseSellData(ItemType.BlueCoin, 1, 2, BuildingType.Apothecary, 1);
		houseSellData[ItemType.Ointment] = new HouseSellData(ItemType.BlueCoin, 4, 5, BuildingType.Apothecary, 1);
		houseSellData[ItemType.Remedy] = new HouseSellData(ItemType.BlueCoin, 2, 2, BuildingType.Apothecary, 1);
		houseSellData[ItemType.ProteinShake] = new HouseSellData(ItemType.BlueCoin, 2, 5, BuildingType.Apothecary, 1);
		houseSellData[ItemType.Antidote] = new HouseSellData(ItemType.BlueCoin, 5, 4, BuildingType.Apothecary, 2);
		houseSellData[ItemType.MagicPotion] = new HouseSellData(ItemType.PurpleCoin, 8, 4, BuildingType.Apothecary, 3);
		houseSellData[ItemType.AttackPotion] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.Apothecary, 3);
		houseSellData[ItemType.HealthPotion] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.Apothecary, 3);
		houseSellData[ItemType.StealthPotion] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.Apothecary, 3);
		houseSellData[ItemType.SpeedPotion] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.Apothecary, 3);
		houseSellData[ItemType.MagicShirt] = new HouseSellData(ItemType.PurpleCoin, 6, 5, BuildingType.ClothingStore, 3);
		houseSellData[ItemType.MagicPants] = new HouseSellData(ItemType.PurpleCoin, 8, 5, BuildingType.ClothingStore, 3);
		houseSellData[ItemType.MagicBoots] = new HouseSellData(ItemType.PurpleCoin, 8, 5, BuildingType.ClothingStore, 3);
		houseSellData[ItemType.MagicHat] = new HouseSellData(ItemType.PurpleCoin, 8, 5, BuildingType.ClothingStore, 3);
		houseSellData[ItemType.MagicCloak] = new HouseSellData(ItemType.PurpleCoin, 10, 5, BuildingType.ClothingStore, 3);
		houseSellData[ItemType.PolishedStone] = new HouseSellData(ItemType.BlueCoin, 2, 2, BuildingType.JewelryStore, 2);
		houseSellData[ItemType.CopperRing] = new HouseSellData(ItemType.BlueCoin, 2, 4, BuildingType.JewelryStore, 2);
		houseSellData[ItemType.SilverRing] = new HouseSellData(ItemType.BlueCoin, 6, 5, BuildingType.JewelryStore, 3);
		houseSellData[ItemType.GoldRing] = new HouseSellData(ItemType.BlueCoin, 6, 5, BuildingType.JewelryStore, 3);
		houseSellData[ItemType.SilverChain] = new HouseSellData(ItemType.BlueCoin, 10, 5, BuildingType.JewelryStore, 3);
		houseSellData[ItemType.GoldCrown] = new HouseSellData(ItemType.BlueCoin, 10, 5, BuildingType.JewelryStore, 3);
		houseSellData[ItemType.RedRuby] = new HouseSellData(ItemType.BlueCoin, 2, 5, BuildingType.JewelryStore, 3);
		houseSellData[ItemType.BlueSapphire] = new HouseSellData(ItemType.BlueCoin, 2, 5, BuildingType.JewelryStore, 3);
		houseSellData[ItemType.PurpleAmethyst] = new HouseSellData(ItemType.BlueCoin, 2, 5, BuildingType.JewelryStore, 3);
		houseSellData[ItemType.YellowTopaz] = new HouseSellData(ItemType.BlueCoin, 2, 5, BuildingType.JewelryStore, 3);
		houseSellData[ItemType.PolishedStoneRing] = new HouseSellData(ItemType.BlueCoin, 10, 4, BuildingType.JewelryStore, 2);
		houseSellData[ItemType.RubyRing] = new HouseSellData(ItemType.BlueCoin, 18, 5, BuildingType.JewelryStore, 4);
		houseSellData[ItemType.SapphireRing] = new HouseSellData(ItemType.BlueCoin, 18, 5, BuildingType.JewelryStore, 4);
		houseSellData[ItemType.AmethystNecklace] = new HouseSellData(ItemType.BlueCoin, 20, 5, BuildingType.JewelryStore, 4);
		houseSellData[ItemType.TopazCrown] = new HouseSellData(ItemType.BlueCoin, 20, 5, BuildingType.JewelryStore, 4);
		houseSellData[ItemType.MagicRing] = new HouseSellData(ItemType.PurpleCoin, 10, 4, BuildingType.JewelryStore, 4);
		houseSellData[ItemType.EnchantedFireRing] = new HouseSellData(ItemType.PurpleCoin, 22, 5, BuildingType.JewelryStore, 5);
		houseSellData[ItemType.EnchantedAirCrown] = new HouseSellData(ItemType.PurpleCoin, 25, 5, BuildingType.JewelryStore, 5);
		houseSellData[ItemType.EnchantedWaterRing] = new HouseSellData(ItemType.PurpleCoin, 22, 5, BuildingType.JewelryStore, 5);
		houseSellData[ItemType.EnchantedEarthNecklace] = new HouseSellData(ItemType.PurpleCoin, 24, 5, BuildingType.JewelryStore, 5);
		houseSellData[ItemType.Mana] = new HouseSellData(ItemType.PurpleCoin, 1, 1, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.PurifiedMana] = new HouseSellData(ItemType.PurpleCoin, 3, 2, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.PurifiedFire] = new HouseSellData(ItemType.PurpleCoin, 5, 4, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.PurifiedWater] = new HouseSellData(ItemType.PurpleCoin, 5, 4, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.PurifiedEarth] = new HouseSellData(ItemType.PurpleCoin, 5, 4, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.PurifiedAir] = new HouseSellData(ItemType.PurpleCoin, 5, 4, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.IronOre] = new HouseSellData(ItemType.YellowCoin, 2, 0, BuildingType.None, 0);
		houseSellData[ItemType.CopperOre] = new HouseSellData(ItemType.YellowCoin, 2, 0, BuildingType.None, 0);
		houseSellData[ItemType.SilverOre] = new HouseSellData(ItemType.YellowCoin, 3, 0, BuildingType.None, 0);
		houseSellData[ItemType.GoldOre] = new HouseSellData(ItemType.YellowCoin, 4, 0, BuildingType.None, 0);
		houseSellData[ItemType.ManaEther] = new HouseSellData(ItemType.PurpleCoin, 15, 4, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.FireEther] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.WaterEther] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.EarthEther] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.AirEther] = new HouseSellData(ItemType.PurpleCoin, 20, 5, BuildingType.ArcaneStore, 0);
		houseSellData[ItemType.Omnistone] = new HouseSellData(ItemType.OmniCoin, 1, 5, BuildingType.ArcaneStore, 10);
		foreach (KeyValuePair<ItemType, HouseSellData> houseSellDatum in houseSellData)
		{
			houseSellDatum.Value.AssignItem(houseSellDatum.Key);
		}
	}

	private void AddHappinessRange(int minInclusive, float bonus)
	{
		int count = happinessRewards.Count;
		if (count > 0)
		{
			happinessRewards[count - 1].maxHappinessExclusive = minInclusive;
		}
		happinessRewards.Add(new HappinessRange(minInclusive, bonus));
	}

	private void LoadHappinessRewards()
	{
		happinessRewards = new List<HappinessRange>(50);
		AddHappinessRange(0, 0f);
		AddHappinessRange(8, 0.1f);
		AddHappinessRange(26, 0.2f);
		AddHappinessRange(60, 0.3f);
		AddHappinessRange(120, 0.4f);
		AddHappinessRange(200, 0.5f);
		AddHappinessRange(330, 0.65f);
		AddHappinessRange(520, 0.8f);
		AddHappinessRange(750, 1f);
		AddHappinessRange(1050, 1.2f);
		AddHappinessRange(1400, 1.4f);
		AddHappinessRange(1800, 1.6f);
		AddHappinessRange(2250, 1.8f);
		AddHappinessRange(2800, 2f);
		AddHappinessRange(3410, 2.2f);
		AddHappinessRange(4080, 2.4f);
		AddHappinessRange(4810, 2.6f);
		AddHappinessRange(5600, 2.8f);
		for (int i = 1; i <= 20; i++)
		{
			AddHappinessRange(5600 + i * 1000, 3f + (float)i * 0.2f);
		}
	}

	private NaturalResourceDef AddDef(NaturalResource t)
	{
		NaturalResourceDef naturalResourceDef = new NaturalResourceDef(t);
		naturalResourceDef.itemProvided = Item.ItemFromNaturalResource(t);
		defaultNaturalResourceDefs[t] = naturalResourceDef;
		naturalResourceDef.xpValuePerResource = 1.0;
		return naturalResourceDef;
	}

	private void LoadNaturalResourceDefs()
	{
		defaultNaturalResourceDefs = new Dictionary<NaturalResource, NaturalResourceDef>(new NaturalResourceEqualityComparer());
		NaturalResourceDef naturalResourceDef = AddDef(NaturalResource.Tree);
		naturalResourceDef.capacityPerLand = 30f;
		naturalResourceDef.growthAmount = 75f;
		naturalResourceDef.regenFactor = 3f;
		naturalResourceDef.cultivationBuilding = BuildingType.Forester;
		NaturalResourceDef naturalResourceDef2 = AddDef(NaturalResource.Wheat);
		naturalResourceDef2.capacityPerLand = 20f;
		naturalResourceDef2.growthAmount = 75f;
		naturalResourceDef2.regenFactor = 0.25f;
		naturalResourceDef2.cultivationBuilding = BuildingType.Farm;
		NaturalResourceDef naturalResourceDef3 = AddDef(NaturalResource.CottonPlant);
		naturalResourceDef3.capacityPerLand = 9f;
		naturalResourceDef3.growthAmount = 75f;
		naturalResourceDef3.regenFactor = 0.25f;
		naturalResourceDef3.cultivationBuilding = BuildingType.Farm;
		naturalResourceDef3.exclusiveBiome = BiomeType.Plains;
		NaturalResourceDef naturalResourceDef4 = AddDef(NaturalResource.BerryBush);
		naturalResourceDef4.capacityPerLand = 5f;
		naturalResourceDef4.growthAmount = 25f;
		naturalResourceDef4.regenFactor = 0.2f;
		naturalResourceDef4.cultivationBuilding = BuildingType.Farm;
		naturalResourceDef4.exclusiveBiome = BiomeType.Forest;
		NaturalResourceDef naturalResourceDef5 = AddDef(NaturalResource.PotatoPlant);
		naturalResourceDef5.capacityPerLand = 5f;
		naturalResourceDef5.growthAmount = 40f;
		naturalResourceDef5.regenFactor = 0.2f;
		naturalResourceDef5.cultivationBuilding = BuildingType.Farm;
		naturalResourceDef5.exclusiveBiome = BiomeType.Snow;
		NaturalResourceDef naturalResourceDef6 = AddDef(NaturalResource.AppleTree);
		naturalResourceDef6.capacityPerLand = 7f;
		naturalResourceDef6.growthAmount = 25f;
		naturalResourceDef6.regenFactor = 0.15f;
		naturalResourceDef6.cultivationBuilding = BuildingType.Forester;
		naturalResourceDef6.exclusiveBiome = BiomeType.Plains;
		NaturalResourceDef naturalResourceDef7 = AddDef(NaturalResource.HerbBush);
		naturalResourceDef7.capacityPerLand = 10f;
		naturalResourceDef7.growthAmount = 50f;
		naturalResourceDef7.regenFactor = 0.25f;
		naturalResourceDef7.cultivationBuilding = BuildingType.Farm;
		naturalResourceDef7.exclusiveBiome = BiomeType.Forest;
		NaturalResourceDef naturalResourceDef8 = AddDef(NaturalResource.SugarCane);
		naturalResourceDef8.capacityPerLand = 12f;
		naturalResourceDef8.growthAmount = 10f;
		naturalResourceDef8.regenFactor = 0.25f;
		naturalResourceDef8.cultivationBuilding = BuildingType.Farm;
		naturalResourceDef8.exclusiveBiome = BiomeType.River;
		NaturalResourceDef naturalResourceDef9 = AddDef(NaturalResource.TomatoPlant);
		naturalResourceDef9.capacityPerLand = 6f;
		naturalResourceDef9.growthAmount = 50f;
		naturalResourceDef9.regenFactor = 0.2f;
		naturalResourceDef9.cultivationBuilding = BuildingType.Farm;
		naturalResourceDef9.exclusiveBiome = BiomeType.River;
		NaturalResourceDef naturalResourceDef10 = AddDef(NaturalResource.PearTree);
		naturalResourceDef10.capacityPerLand = 7f;
		naturalResourceDef10.growthAmount = 25f;
		naturalResourceDef10.regenFactor = 0.15f;
		naturalResourceDef10.cultivationBuilding = BuildingType.Forester;
		naturalResourceDef10.exclusiveBiome = BiomeType.Forest;
		NaturalResourceDef naturalResourceDef11 = AddDef(NaturalResource.CarrotPlant);
		naturalResourceDef11.capacityPerLand = 6f;
		naturalResourceDef11.growthAmount = 50f;
		naturalResourceDef11.regenFactor = 0.2f;
		naturalResourceDef11.cultivationBuilding = BuildingType.Farm;
		naturalResourceDef11.exclusiveBiome = BiomeType.Mountains;
		NaturalResourceDef naturalResourceDef12 = AddDef(NaturalResource.CactusFruitTree);
		naturalResourceDef12.capacityPerLand = 5f;
		naturalResourceDef12.growthAmount = 50f;
		naturalResourceDef12.regenFactor = 0.2f;
		naturalResourceDef12.cultivationBuilding = BuildingType.Farm;
		naturalResourceDef12.exclusiveBiome = BiomeType.Desert;
		NaturalResourceDef naturalResourceDef13 = AddDef(NaturalResource.Sand);
		naturalResourceDef13.capacityPerLand = 20f;
		naturalResourceDef13.growthAmount = 50f;
		naturalResourceDef13.regenFactor = 1f;
		naturalResourceDef13.cultivationBuilding = BuildingType.Quarry;
		naturalResourceDef13.exclusiveBiome = BiomeType.Desert;
		NaturalResourceDef naturalResourceDef14 = AddDef(NaturalResource.DragonFruitTree);
		naturalResourceDef14.capacityPerLand = 4f;
		naturalResourceDef14.growthAmount = 50f;
		naturalResourceDef14.regenFactor = 0.2f;
		naturalResourceDef14.cultivationBuilding = BuildingType.Forester;
		naturalResourceDef14.exclusiveBiome = BiomeType.Jungle;
		NaturalResourceDef naturalResourceDef15 = AddDef(NaturalResource.FishSource);
		naturalResourceDef15.capacityPerLand = 10f;
		naturalResourceDef15.growthAmount = 50f;
		naturalResourceDef15.regenFactor = 0.2f;
		naturalResourceDef15.cultivationBuilding = BuildingType.Fishery;
		naturalResourceDef15.exclusiveBiome = BiomeType.River;
		NaturalResourceDef naturalResourceDef16 = AddDef(NaturalResource.WaterSource);
		naturalResourceDef16.capacityPerLand = 50f;
		naturalResourceDef16.growthAmount = 25f;
		naturalResourceDef16.regenFactor = 0.5f;
		naturalResourceDef16.cultivationBuilding = BuildingType.Well;
		NaturalResourceDef naturalResourceDef17 = AddDef(NaturalResource.Rock);
		naturalResourceDef17.capacityPerLand = 400f;
		naturalResourceDef17.growthAmount = 150f;
		naturalResourceDef17.regenFactor = 0.2f;
		naturalResourceDef17.cultivationBuilding = BuildingType.Quarry;
		NaturalResourceDef naturalResourceDef18 = AddDef(NaturalResource.IronOre);
		naturalResourceDef18.capacityPerLand = 10f;
		naturalResourceDef18.growthAmount = 100f;
		naturalResourceDef18.regenFactor = 0.025f;
		naturalResourceDef18.cultivationBuilding = BuildingType.Mine;
		NaturalResourceDef naturalResourceDef19 = AddDef(NaturalResource.CopperOre);
		naturalResourceDef19.capacityPerLand = 8f;
		naturalResourceDef19.growthAmount = 100f;
		naturalResourceDef19.regenFactor = 0.025f;
		naturalResourceDef19.cultivationBuilding = BuildingType.Mine;
		NaturalResourceDef naturalResourceDef20 = AddDef(NaturalResource.CoalOre);
		naturalResourceDef20.capacityPerLand = 40f;
		naturalResourceDef20.growthAmount = 25f;
		naturalResourceDef20.regenFactor = 0.025f;
		naturalResourceDef20.cultivationBuilding = BuildingType.Mine;
		NaturalResourceDef naturalResourceDef21 = AddDef(NaturalResource.SilverOre);
		naturalResourceDef21.capacityPerLand = 6f;
		naturalResourceDef21.growthAmount = 50f;
		naturalResourceDef21.regenFactor = 0.025f;
		naturalResourceDef21.cultivationBuilding = BuildingType.GemMine;
		naturalResourceDef21.xpValuePerResource = 2.0;
		NaturalResourceDef naturalResourceDef22 = AddDef(NaturalResource.GoldOre);
		naturalResourceDef22.capacityPerLand = 5f;
		naturalResourceDef22.growthAmount = 25f;
		naturalResourceDef22.regenFactor = 0.01f;
		naturalResourceDef22.cultivationBuilding = BuildingType.GemMine;
		naturalResourceDef22.xpValuePerResource = 3.0;
		NaturalResourceDef naturalResourceDef23 = AddDef(NaturalResource.Ruby);
		naturalResourceDef23.capacityPerLand = 10f;
		naturalResourceDef23.growthAmount = 50f;
		naturalResourceDef23.regenFactor = 0.01f;
		naturalResourceDef23.cultivationBuilding = BuildingType.GemMine;
		naturalResourceDef23.exclusiveBiome = BiomeType.Desert;
		naturalResourceDef23.xpValuePerResource = 3.0;
		NaturalResourceDef naturalResourceDef24 = AddDef(NaturalResource.Topaz);
		naturalResourceDef24.capacityPerLand = 10f;
		naturalResourceDef24.growthAmount = 50f;
		naturalResourceDef24.regenFactor = 0.01f;
		naturalResourceDef24.cultivationBuilding = BuildingType.GemMine;
		naturalResourceDef24.exclusiveBiome = BiomeType.Mountains;
		naturalResourceDef24.xpValuePerResource = 3.0;
		NaturalResourceDef naturalResourceDef25 = AddDef(NaturalResource.Sapphire);
		naturalResourceDef25.capacityPerLand = 10f;
		naturalResourceDef25.growthAmount = 50f;
		naturalResourceDef25.regenFactor = 0.01f;
		naturalResourceDef25.cultivationBuilding = BuildingType.GemMine;
		naturalResourceDef25.exclusiveBiome = BiomeType.Snow;
		naturalResourceDef25.xpValuePerResource = 3.0;
		NaturalResourceDef naturalResourceDef26 = AddDef(NaturalResource.Amethyst);
		naturalResourceDef26.capacityPerLand = 10f;
		naturalResourceDef26.growthAmount = 50f;
		naturalResourceDef26.regenFactor = 0.01f;
		naturalResourceDef26.cultivationBuilding = BuildingType.GemMine;
		naturalResourceDef26.exclusiveBiome = BiomeType.Jungle;
		naturalResourceDef26.xpValuePerResource = 3.0;
		NaturalResourceDef naturalResourceDef27 = AddDef(NaturalResource.ManaCrystal);
		naturalResourceDef27.capacityPerLand = 25f;
		naturalResourceDef27.growthAmount = 50f;
		naturalResourceDef27.regenFactor = 0.25f;
		naturalResourceDef27.cultivationBuilding = BuildingType.GemMine;
		naturalResourceDef27.exclusiveBiome = BiomeType.Magic;
		naturalResourceDef27.xpValuePerResource = 3.0;
	}

	private void LoadResourceResearchDefaults()
	{
		resourceResearch = new Dictionary<NaturalResource, ResearchType>(new NaturalResourceEqualityComparer());
		resourceResearch[NaturalResource.AppleTree] = ResearchType.AppleFarming;
		resourceResearch[NaturalResource.PearTree] = ResearchType.PearFarming;
		resourceResearch[NaturalResource.BerryBush] = ResearchType.BerryFarming;
		resourceResearch[NaturalResource.CottonPlant] = ResearchType.CottonFarming;
		resourceResearch[NaturalResource.HerbBush] = ResearchType.HerbFarming;
		resourceResearch[NaturalResource.PotatoPlant] = ResearchType.PotatoFarming;
		resourceResearch[NaturalResource.CarrotPlant] = ResearchType.CarrotFarming;
		resourceResearch[NaturalResource.TomatoPlant] = ResearchType.TomatoFarming;
		resourceResearch[NaturalResource.SugarCane] = ResearchType.SugarFarming;
		resourceResearch[NaturalResource.CactusFruitTree] = ResearchType.CactusFarming;
		resourceResearch[NaturalResource.DragonFruitTree] = ResearchType.DragonfruitFarming;
		resourceResearch[NaturalResource.CoalOre] = ResearchType.CoalMining;
		resourceResearch[NaturalResource.SilverOre] = ResearchType.SilverMining;
		resourceResearch[NaturalResource.CopperOre] = ResearchType.CopperMining;
		resourceResearch[NaturalResource.GoldOre] = ResearchType.GoldMining;
		resourceResearch[NaturalResource.Amethyst] = ResearchType.AmethystMining;
		resourceResearch[NaturalResource.Sapphire] = ResearchType.SapphireMining;
		resourceResearch[NaturalResource.Topaz] = ResearchType.TopazMining;
		resourceResearch[NaturalResource.Ruby] = ResearchType.RubyMining;
		resourceResearch[NaturalResource.ManaCrystal] = ResearchType.ManaMining;
	}

	private void LoadProspectingRecipeDefaults()
	{
		defaultProspectingRecipes = new Dictionary<NaturalResource, FarmingRecipe>(new NaturalResourceEqualityComparer());
		AddProspecting(NaturalResource.Rock);
		AddProspecting(NaturalResource.Sand);
		AddProspecting(NaturalResource.CoalOre);
		AddProspecting(NaturalResource.IronOre);
		AddProspecting(NaturalResource.CopperOre);
		AddProspecting(NaturalResource.SilverOre);
		AddProspecting(NaturalResource.GoldOre);
		AddProspecting(NaturalResource.Amethyst);
		AddProspecting(NaturalResource.Sapphire);
		AddProspecting(NaturalResource.Topaz);
		AddProspecting(NaturalResource.Ruby);
		AddProspecting(NaturalResource.ManaCrystal);
	}

	private void LoadFarmingRecipeDefaults()
	{
		defaultFarmingRecipes = new Dictionary<NaturalResource, FarmingRecipe>(new NaturalResourceEqualityComparer());
		AddFarmable(NaturalResource.WaterSource);
		AddFarmable(NaturalResource.Wheat);
		AddFarmable(NaturalResource.CottonPlant);
		AddFarmable(NaturalResource.AppleTree);
		AddFarmable(NaturalResource.PearTree);
		AddFarmable(NaturalResource.HerbBush);
		AddFarmable(NaturalResource.BerryBush);
		AddFarmable(NaturalResource.CarrotPlant);
		AddFarmable(NaturalResource.PotatoPlant);
		AddFarmable(NaturalResource.TomatoPlant);
		AddFarmable(NaturalResource.SugarCane);
		AddFarmable(NaturalResource.DragonFruitTree);
		AddFarmable(NaturalResource.CactusFruitTree);
		AddFarmable(NaturalResource.Tree);
		AddFarmable(NaturalResource.FishSource);
	}

	private void AddProspecting(NaturalResource r)
	{
		FarmingRecipe value = new FarmingRecipe(r);
		defaultProspectingRecipes[r] = value;
	}

	private void AddFarmable(NaturalResource r)
	{
		FarmingRecipe value = new FarmingRecipe(r);
		defaultFarmingRecipes[r] = value;
	}

	private void LoadRecipeDefaults()
	{
		TradeRecipeIndex = 10000;
		defaultRecipeDefs = new Dictionary<RecipeType, Recipe>(new RecipeEqualityComparer());
		foreach (RecipeType value in Enum.GetValues(typeof(RecipeType)))
		{
			if (value != RecipeType.None && (int)value < TradeRecipeIndex)
			{
				Recipe recipe = Recipe.Default(value);
				if (recipe.enabled)
				{
					defaultRecipeDefs.Add(value, recipe);
				}
			}
		}
	}

	private void LoadBuildingRecipeDefaults()
	{
		defaultBuildingRecipes = new Dictionary<BuildingType, List<RecipeType>>(new BuildingEqualityComparer());
		foreach (BuildingType value2 in Enum.GetValues(typeof(BuildingType)))
		{
			List<RecipeType> list = DefaultPotentialRecipeTypesForBuilding(value2);
			List<RecipeType> list2 = new List<RecipeType>(list.Count);
			defaultBuildingRecipes[value2] = list2;
			foreach (RecipeType item in list)
			{
				if (defaultRecipeDefs.TryGetValue(item, out var value) && value.enabled)
				{
					list2.Add(item);
				}
			}
		}
	}

	public static bool IsPermanentlyDisabled(StructureType t)
	{
		if ((uint)(t - 45) <= 3u || (uint)(t - 59) <= 4u)
		{
			return true;
		}
		return false;
	}

	private void LoadObjectDefs()
	{
		defaultStructureDefs = new Dictionary<StructureType, StructureDef>(new StructureEqualityComparer());
		defaultBuildingDefs = new Dictionary<BuildingType, BuildingDef>(new BuildingEqualityComparer());
		foreach (BuildingType value in Enum.GetValues(typeof(BuildingType)))
		{
			if (value != BuildingType.None)
			{
				BuildingDef buildingDef = new BuildingDef(value);
				buildingDef.enabled = IsBuildingEnabledDefault(value);
				buildingDef.bonusPerWorker = 0;
				buildingDef.category = BuildingCategory.Production;
				buildingDef.costGrowthFactor = 0.3f;
				buildingDef.landRequired = 1;
				defaultBuildingDefs.Add(value, buildingDef);
				buildingDef.CalculateMetadata();
				buildingDef.ConfigureForType();
			}
		}
		GetBuildingDef(BuildingType.Void).enabled = false;
	}

	public BuildingDef GetBuildingDef(BuildingType buildingType)
	{
		if (defaultBuildingDefs.TryGetValue(buildingType, out var value))
		{
			return value;
		}
		Debug.LogError("NO default def for " + buildingType);
		return new BuildingDef(BuildingType.None);
	}

	public static bool IsItemConveyorEnabledDefault(ItemType t)
	{
		return true;
	}

	public static bool IsRecipeEnabledDefault(RecipeType t)
	{
		return instance.defaultRecipeDefs.ContainsKey(t);
	}

	public static bool IsStructureEnabledDefault(StructureType t)
	{
		if (instance.defaultStructureDefs.TryGetValue(t, out var value))
		{
			return value.enabled;
		}
		return false;
	}

	public static bool IsResearchEnabledDefault(ResearchType t)
	{
		return true;
	}

	public static bool IsBuildingEnabledDefault(BuildingType t)
	{
		switch (t)
		{
		case BuildingType.Lodge:
		case BuildingType.Base:
		case BuildingType.Crate:
		case BuildingType.Construction:
		case BuildingType.Infuser:
		case BuildingType.Diffuser:
		case BuildingType.MagicSchool:
		case BuildingType.ManaGrower:
		case BuildingType.Recharger:
		case BuildingType.Incinerator:
		case BuildingType.Void:
		case BuildingType.MegaRecharger:
		case BuildingType.Hut:
		case BuildingType.Mansion:
		case BuildingType.Palace:
			return false;
		case BuildingType.Bank:
			return false;
		default:
			return true;
		}
	}

	public static bool IsResearchEnabled(RecipeType type)
	{
		return Crafting.GetRecipe(type)?.enabled ?? false;
	}

	public static HashSet<ItemType> PhysicalItemsInFilter(ItemType filter)
	{
		if (Crafting.itemFilterMapPhysical.TryGetValue(filter, out var value))
		{
			return value;
		}
		return GameUtility.ItemHashSet();
	}

	private static List<RecipeType> DefaultPotentialRecipeTypesForBuilding(BuildingType type)
	{
		List<RecipeType> list = new List<RecipeType>();
		switch (type)
		{
		case BuildingType.Hearth:
			list.Add(RecipeType.BurnWood);
			break;
		case BuildingType.Furnace:
			list.Add(RecipeType.BurnCoal);
			break;
		case BuildingType.Forge:
			list.Add(RecipeType.MakeIronIngot);
			list.Add(RecipeType.MakeCopperIngot);
			list.Add(RecipeType.MakeNails);
			list.Add(RecipeType.MakeSteel);
			list.Add(RecipeType.MakeGoldIngot);
			list.Add(RecipeType.SmeltSilverIngot);
			list.Add(RecipeType.MakeGlass);
			break;
		case BuildingType.ManaTransmitter:
			list.Add(RecipeType.PurifiedManaPower);
			list.Add(RecipeType.PurifiedFirePower);
			list.Add(RecipeType.PurifiedWaterPower);
			list.Add(RecipeType.PurifiedEarthPower);
			list.Add(RecipeType.PurifiedAirPower);
			break;
		case BuildingType.GeneralLab:
			list.Add(RecipeType.GeneralResearchFromPaper);
			list.Add(RecipeType.GeneralResearchFromBook);
			list.Add(RecipeType.GeneralResearchFromEnchantedBook);
			break;
		case BuildingType.TechLab:
			list.Add(RecipeType.MakeTomeIndustry1);
			list.Add(RecipeType.MakeTomeIndustry2);
			list.Add(RecipeType.MakeTomeIndustry3);
			break;
		case BuildingType.MagicLab:
			list.Add(RecipeType.MakeTomeMagic1);
			list.Add(RecipeType.MakeTomeMagic2);
			list.Add(RecipeType.MakeTomeMagic3);
			break;
		case BuildingType.MagicForge:
			list.Add(RecipeType.SmeltPurifiedMana);
			list.Add(RecipeType.SmeltPurifiedFire);
			list.Add(RecipeType.SmeltPurifiedWater);
			list.Add(RecipeType.SmeltPurifiedEarth);
			list.Add(RecipeType.SmeltPurifiedAir);
			break;
		case BuildingType.Refinery:
			list.Add(RecipeType.MakeEther);
			list.Add(RecipeType.MakeFireEther);
			list.Add(RecipeType.MakeWaterEther);
			list.Add(RecipeType.MakeEarthEther);
			list.Add(RecipeType.MakeAirEther);
			break;
		case BuildingType.SteamBoiler:
			list.Add(RecipeType.GenerateSteam);
			break;
		case BuildingType.FireShrine:
			list.Add(RecipeType.GenerateShrineFire);
			break;
		case BuildingType.WaterShrine:
			list.Add(RecipeType.GenerateShrineWater);
			break;
		case BuildingType.EarthShrine:
			list.Add(RecipeType.GenerateShrinePower);
			break;
		case BuildingType.AirShrine:
			list.Add(RecipeType.GenerateShrineSteam);
			break;
		case BuildingType.SteamPowerGenerator:
			list.Add(RecipeType.SteamPower);
			break;
		case BuildingType.WaterWheel:
			list.Add(RecipeType.WaterWheelPower);
			break;
		case BuildingType.SolarPanel:
			list.Add(RecipeType.SolarPanelPower);
			break;
		case BuildingType.WaterPump:
			list.Add(RecipeType.PumpWater);
			break;
		case BuildingType.MachineShop:
			list.Add(RecipeType.MakeGear);
			list.Add(RecipeType.MakeIronWheel);
			list.Add(RecipeType.MakeSteamPipe);
			list.Add(RecipeType.MakeCopperWire);
			list.Add(RecipeType.MakeRailTile);
			list.Add(RecipeType.MakeRailTilePowered);
			list.Add(RecipeType.MakeRailTilePoweredFromScratch);
			list.Add(RecipeType.MakeConveyorBelt);
			list.Add(RecipeType.MakeSolarCell);
			list.Add(RecipeType.MakeMagmaPipe);
			list.Add(RecipeType.MakeManaPipe);
			list.Add(RecipeType.MakeOmniPipe);
			list.Add(RecipeType.MakeRailTileMagic);
			list.Add(RecipeType.MakeMagicBoatComponent);
			list.Add(RecipeType.MakeMagicConveyorBelt);
			list.Add(RecipeType.MakeAirshipComponent);
			break;
		case BuildingType.ManaReactor:
			list.Add(RecipeType.MakeOmniStone);
			break;
		case BuildingType.MedicineHut:
			list.Add(RecipeType.MakeBandage);
			list.Add(RecipeType.MakePoultice);
			list.Add(RecipeType.MakeMedicalWrap);
			list.Add(RecipeType.MakeRemedy);
			list.Add(RecipeType.MakeFishOil);
			list.Add(RecipeType.MakeOintment);
			list.Add(RecipeType.MakeAntidote);
			list.Add(RecipeType.MakeMagicPotion);
			list.Add(RecipeType.MakeAttackPotion);
			list.Add(RecipeType.MakeStealthPotion);
			list.Add(RecipeType.MakeHealthPotion);
			list.Add(RecipeType.MakeSpeedPotion);
			break;
		case BuildingType.Bakery:
			list.Add(RecipeType.BakeBread);
			list.Add(RecipeType.MakeCookedBeef);
			list.Add(RecipeType.MakeCookedChicken);
			list.Add(RecipeType.MakeCookedFish);
			list.Add(RecipeType.MakeAppleJuice);
			list.Add(RecipeType.MakePearJuice);
			list.Add(RecipeType.MakeBerryJuice);
			list.Add(RecipeType.MakeButter);
			list.Add(RecipeType.BakePotatoBread);
			break;
		case BuildingType.Jeweler:
			list.Add(RecipeType.MakePolishedStone);
			list.Add(RecipeType.MakeCopperRing);
			list.Add(RecipeType.MakeSilverRing);
			list.Add(RecipeType.MakeGoldRing);
			list.Add(RecipeType.MakeSilverChain);
			list.Add(RecipeType.MakeGoldCrown);
			list.Add(RecipeType.MakePolishedStoneRing);
			list.Add(RecipeType.MakeRubyRing);
			list.Add(RecipeType.MakeSapphireRing);
			list.Add(RecipeType.MakeAmethystNecklace);
			list.Add(RecipeType.MakeTopazCrown);
			break;
		case BuildingType.GourmetKitchen:
			list.Add(RecipeType.MakeAppleJam);
			list.Add(RecipeType.MakePearJam);
			list.Add(RecipeType.MakeBerryJam);
			list.Add(RecipeType.MakeDragonPunch);
			list.Add(RecipeType.MakeCactusJam);
			list.Add(RecipeType.MakeCheese);
			list.Add(RecipeType.MakeVeggieStew);
			list.Add(RecipeType.MakeFishStew);
			list.Add(RecipeType.MakeMeatStew);
			list.Add(RecipeType.MakeSandwich);
			list.Add(RecipeType.MakeApplePie);
			list.Add(RecipeType.MakeCake);
			list.Add(RecipeType.MakeBerryCake);
			list.Add(RecipeType.MakeProteinShake);
			break;
		case BuildingType.Enchanter:
			list.Add(RecipeType.MakeMagicPlank);
			list.Add(RecipeType.MakeMagicStoneBrick);
			list.Add(RecipeType.MakeMagicFishingNet);
			list.Add(RecipeType.MakeEnchantedBook);
			list.Add(RecipeType.MakeEnchantedBookRed);
			list.Add(RecipeType.MakeEnchantedBookYellow);
			list.Add(RecipeType.MakeEnchantedBookBlue);
			list.Add(RecipeType.MakeEnchantedBookPurple);
			list.Add(RecipeType.MakeMagicRing);
			list.Add(RecipeType.MakeFireRing);
			list.Add(RecipeType.MakeWaterRing);
			list.Add(RecipeType.MakeEarthNecklace);
			list.Add(RecipeType.MakeAirCrown);
			break;
		case BuildingType.Incinerator:
			list.Add(RecipeType.Incinerate);
			break;
		case BuildingType.Void:
			list.Add(RecipeType.VoidItem);
			break;
		case BuildingType.StoneMason:
			list.Add(RecipeType.MakeStoneBrick);
			list.Add(RecipeType.MakeRefinedStoneBrick);
			list.Add(RecipeType.MakeQuartzFromStone);
			break;
		case BuildingType.LumberMill:
			list.Add(RecipeType.MakePlank);
			list.Add(RecipeType.MakeRefinedPlank);
			list.Add(RecipeType.MakePaper);
			list.Add(RecipeType.MakeWaterPipe);
			break;
		case BuildingType.GrainMill:
			list.Add(RecipeType.GrindFlour);
			list.Add(RecipeType.GrindAnimalFeed);
			list.Add(RecipeType.RefineSugar);
			list.Add(RecipeType.MakeAnimalFeedCarrots);
			list.Add(RecipeType.MakeAnimalFeedPotatoes);
			list.Add(RecipeType.MakeFishBait);
			break;
		case BuildingType.Farm:
			list.Add(RecipeType.ApplyWater);
			list.Add(RecipeType.ApplyFertilizer);
			list.Add(RecipeType.FarmGrain);
			list.Add(RecipeType.FarmHerbs);
			list.Add(RecipeType.FarmSugar);
			list.Add(RecipeType.FarmBerries);
			list.Add(RecipeType.FarmCarrots);
			list.Add(RecipeType.FarmPotatoes);
			list.Add(RecipeType.FarmTomatoes);
			list.Add(RecipeType.FarmCotton);
			list.Add(RecipeType.FarmCactusFruit);
			break;
		case BuildingType.Forester:
			list.Add(RecipeType.ProduceWood);
			list.Add(RecipeType.FarmApples);
			list.Add(RecipeType.FarmPears);
			list.Add(RecipeType.FarmDragonFruit);
			break;
		case BuildingType.Well:
			list.Add(RecipeType.DrawWater);
			break;
		case BuildingType.Tailor:
			list.Add(RecipeType.MakeCottonCloth);
			list.Add(RecipeType.MakeWoolCloth);
			list.Add(RecipeType.MakeShirt);
			list.Add(RecipeType.MakePants);
			list.Add(RecipeType.MakeCloak);
			list.Add(RecipeType.MakeWarmCoat);
			list.Add(RecipeType.MakeShoe);
			list.Add(RecipeType.MakeBoots);
			list.Add(RecipeType.MakeHat);
			list.Add(RecipeType.MakeMagicShirt);
			list.Add(RecipeType.MakeMagicCloak);
			list.Add(RecipeType.MakeMagicPants);
			list.Add(RecipeType.MakeMagicBoots);
			list.Add(RecipeType.MakeMagicHat);
			break;
		case BuildingType.Workshop:
			list.Add(RecipeType.MakeWoodWheel);
			list.Add(RecipeType.MakeBook);
			list.Add(RecipeType.MakeConveyorBeltWooden);
			list.Add(RecipeType.MakeConveyorBeltCloth);
			list.Add(RecipeType.MakeRailTileWooden);
			list.Add(RecipeType.MakeReinforcedPlank);
			list.Add(RecipeType.MakeStoneAxe);
			list.Add(RecipeType.MakeShovel);
			list.Add(RecipeType.MakeWoodAxe);
			list.Add(RecipeType.MakePickaxe);
			list.Add(RecipeType.MakeFishingNet);
			break;
		case BuildingType.Pasture:
			list.Add(RecipeType.FarmEgg);
			list.Add(RecipeType.FarmChicken);
			list.Add(RecipeType.FarmFertilizer);
			list.Add(RecipeType.FarmWool);
			list.Add(RecipeType.FarmLeather);
			list.Add(RecipeType.MakeRawBeef);
			list.Add(RecipeType.MakeMilk);
			break;
		case BuildingType.OmniTemple:
			list.Add(RecipeType.OmniTemple1);
			list.Add(RecipeType.OmniTemple2);
			list.Add(RecipeType.OmniTemple3);
			list.Add(RecipeType.OmniTemple4);
			list.Add(RecipeType.OmniTemple5);
			list.Add(RecipeType.OmniTemple6);
			list.Add(RecipeType.OmniTemple7);
			list.Add(RecipeType.OmniTemple8);
			list.Add(RecipeType.OmniTemple9);
			break;
		}
		return list;
	}

	public static string PrintedList<T>(ICollection<T> list)
	{
		if (list == null)
		{
			return "null";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Count:" + list.Count + " ");
		bool flag = true;
		foreach (T item in list)
		{
			if (!flag)
			{
				stringBuilder.Append(",");
			}
			if (item == null)
			{
				stringBuilder.Append("[NULL]");
			}
			else
			{
				stringBuilder.Append(item.ToString());
			}
			flag = false;
		}
		return stringBuilder.ToString();
	}

	public void LoadUpgradeLocalizationKeys()
	{
		foreach (KeyValuePair<HarvestRecipeType, UpgradeType> harvestingSpeedUpgrade in harvestingSpeedUpgrades)
		{
			LinkUpgradeLocalization(harvestingSpeedUpgrade.Value, EntityId.FromHarvestRecipe(harvestingSpeedUpgrade.Key), "HarvestingSpeed");
		}
		foreach (KeyValuePair<NaturalResource, UpgradeType> prospectingSpeedUpgrade in prospectingSpeedUpgrades)
		{
			LinkUpgradeLocalization(prospectingSpeedUpgrade.Value, EntityId.FromMining(prospectingSpeedUpgrade.Key), "ProspectingSpeed");
		}
		foreach (KeyValuePair<NaturalResource, UpgradeType> cultivationSpeedUpgrade in cultivationSpeedUpgrades)
		{
			LinkUpgradeLocalization(cultivationSpeedUpgrade.Value, EntityId.FromFarming(cultivationSpeedUpgrade.Key), "CultivationSpeed");
		}
		LinkUpgradeLocalization(UpgradeType.FurnaceProductivity, EntityId.FromBuilding(BuildingType.Furnace), "Productivity");
	}

	private static void LinkUpgradeLocalization(UpgradeType t, EntityId entity, string modifierKey)
	{
		if (Crafting.upgradeCache.TryGetValue(t, out var value))
		{
			value.linkedEntity = entity;
			value.linkedModifierKey = modifierKey;
		}
	}

	private void LoadWorkersPerBuildingUpgrades()
	{
		productionCapacityUpgrades = new Dictionary<BuildingType, UpgradeType>(new BuildingEqualityComparer());
		productionCapacityUpgrades[BuildingType.StoneMason] = UpgradeType.StoneMasonProficiency;
		productionCapacityUpgrades[BuildingType.Tailor] = UpgradeType.TailorProficiency;
		productionCapacityUpgrades[BuildingType.Workshop] = UpgradeType.WorkshopProficiency;
		productionCapacityUpgrades[BuildingType.GrainMill] = UpgradeType.GrainMillProficiency;
		productionCapacityUpgrades[BuildingType.Forge] = UpgradeType.ForgeProficiency;
		productionCapacityUpgrades[BuildingType.Bakery] = UpgradeType.BakeryProficiency;
		productionCapacityUpgrades[BuildingType.MachineShop] = UpgradeType.MachineShopProficiency;
		productionCapacityUpgrades[BuildingType.MedicineHut] = UpgradeType.MedicineHutProficiency;
		productionCapacityUpgrades[BuildingType.LumberMill] = UpgradeType.LumberMillProficiency;
		productionCapacityUpgrades[BuildingType.Farm] = UpgradeType.FarmingProficiency;
		productionCapacityUpgrades[BuildingType.Mine] = UpgradeType.MineProficiency;
		productionCapacityUpgrades[BuildingType.Forester] = UpgradeType.ForesterProficiency;
		productionCapacityUpgrades[BuildingType.Fishery] = UpgradeType.FisheryProficiency;
		productionCapacityUpgrades[BuildingType.MagicForge] = UpgradeType.EnchantedForgeProficiency;
		productionCapacityUpgrades[BuildingType.Enchanter] = UpgradeType.EnchanterProficiency;
		productionCapacityUpgrades[BuildingType.Quarry] = UpgradeType.QuarryProficiency;
		productionCapacityUpgrades[BuildingType.GemMine] = UpgradeType.GemMineProficiency;
		productionCapacityUpgrades[BuildingType.ManaTransmitter] = UpgradeType.ExtractorProficiency;
		productionCapacityUpgrades[BuildingType.Refinery] = UpgradeType.RefineryProficiency;
		productionCapacityUpgrades[BuildingType.Jeweler] = UpgradeType.JewelerProficiency;
		productionCapacityUpgrades[BuildingType.Pasture] = UpgradeType.PastureProficiency;
		productionCapacityUpgrades[BuildingType.GourmetKitchen] = UpgradeType.GourmetKitchenProficiency;
		productionCapacityUpgrades[BuildingType.GeneralLab] = UpgradeType.StudyProficiency;
		productionCapacityUpgrades[BuildingType.TechLab] = UpgradeType.TechLabProficiency;
		productionCapacityUpgrades[BuildingType.MagicLab] = UpgradeType.MagicLabProficiency;
		productionCapacityUpgrades[BuildingType.HarvesterHut] = UpgradeType.HarvesterHutProficiency;
		productionCapacityUpgrades[BuildingType.FishingBoat] = UpgradeType.FishingBoatProficiency;
		productionCapacityUpgrades[BuildingType.CropHarvester] = UpgradeType.CropHarvesterProficiency;
		productionCapacityUpgrades[BuildingType.ChainsawTank] = UpgradeType.ChainsawTankProficiency;
		productionCapacityUpgrades[BuildingType.HarvesterDrill] = UpgradeType.HarvesterDrillProficiency;
		productionCapacityUpgrades[BuildingType.TradingPost] = UpgradeType.TradingPostWorkersPerBuilding;
		marketCapacityUpgrades = new Dictionary<BuildingType, UpgradeType>(new BuildingEqualityComparer());
		marketCapacityUpgrades[BuildingType.Market] = UpgradeType.FoodMarketCapacity;
		marketCapacityUpgrades[BuildingType.HardwareStore] = UpgradeType.HardwareStoreCapacity;
		marketCapacityUpgrades[BuildingType.Bookstore] = UpgradeType.BookstoreCapacity;
		marketCapacityUpgrades[BuildingType.GeneralGoods] = UpgradeType.GeneralGoodsCapacity;
		marketCapacityUpgrades[BuildingType.ClothingStore] = UpgradeType.ClothingStoreCapacity;
		marketCapacityUpgrades[BuildingType.Apothecary] = UpgradeType.ApothecaryCapacity;
		marketCapacityUpgrades[BuildingType.JewelryStore] = UpgradeType.JewelryStoreCapacity;
		marketCapacityUpgrades[BuildingType.ArcaneStore] = UpgradeType.ArcaneStoreCapacity;
		marketCapacityUpgrades[BuildingType.FancyFoods] = UpgradeType.FancyFoodsCapacity;
		storageUpgrades = new Dictionary<BuildingType, UpgradeType>(new BuildingEqualityComparer());
		storageUpgrades[BuildingType.Stockpile] = UpgradeType.StockpileCapacity;
		storageUpgrades[BuildingType.Warehouse] = UpgradeType.WarehouseCapacity;
		storageUpgrades[BuildingType.CropSilo] = UpgradeType.CropSiloCapacity;
		storageUpgrades[BuildingType.OreSilo] = UpgradeType.OreSiloCapacity;
		storageUpgrades[BuildingType.Pantry] = UpgradeType.PantryCapacity;
		storageUpgrades[BuildingType.Library] = UpgradeType.LibraryCapacity;
		storageUpgrades[BuildingType.Treasury] = UpgradeType.TreasuryCapacity;
		storageUpgrades[BuildingType.Battery] = UpgradeType.BatteryCapacity;
		storageUpgrades[BuildingType.ManaBattery] = UpgradeType.ManaBatteryCapacity;
		storageUpgrades[BuildingType.EtherStorage] = UpgradeType.EtherStorageCapacity;
		storageUpgrades[BuildingType.OmnistoneStorage] = UpgradeType.OmnistoneStorageCapacity;
		storageUpgrades[BuildingType.Crystalarium] = UpgradeType.CrystalariumCapacity;
		storageUpgrades[BuildingType.Reservoir] = UpgradeType.ReservoirCapacity;
		storageUpgrades[BuildingType.Furnace] = UpgradeType.FurnaceStorageCapacity;
		storageUpgrades[BuildingType.SteamBoiler] = UpgradeType.SteamBoilerStorageCapacity;
		storageUpgrades[BuildingType.Barrel] = UpgradeType.BarrelCapacity;
		storageUpgrades[BuildingType.TradingPost] = UpgradeType.TradingPostStorageCapacity;
	}

	private void LoadHarvestingUpgrades()
	{
		harvestingSpeedUpgrades = new Dictionary<HarvestRecipeType, UpgradeType>(new HarvestRecipeEqualityComparer());
		harvestingSpeedUpgrades[HarvestRecipeType.Rock] = UpgradeType.RockHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.IronOre] = UpgradeType.IronHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.CoalOre] = UpgradeType.CoalHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.GoldOre] = UpgradeType.GoldHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.SilverOre] = UpgradeType.SilverHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.CopperOre] = UpgradeType.CopperHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.ManaCrystal] = UpgradeType.ManaHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.Ruby] = UpgradeType.GemRedHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.Topaz] = UpgradeType.GemYellowHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.Sapphire] = UpgradeType.GemAquaHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.Amethyst] = UpgradeType.GemPurpleHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.Wheat] = UpgradeType.GrainHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.CottonPlant] = UpgradeType.CottonHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.HerbBush] = UpgradeType.HerbHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.PotatoPlant] = UpgradeType.PotatoHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.TomatoPlant] = UpgradeType.TomatoHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.SugarCane] = UpgradeType.SugarHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.AppleTree] = UpgradeType.AppleHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.PearTree] = UpgradeType.PearHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.BerryBush] = UpgradeType.BerryHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.CactusFruitTree] = UpgradeType.CactusHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.DragonFruitTree] = UpgradeType.DragonHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.CarrotPlant] = UpgradeType.CarrotHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.Tree] = UpgradeType.TreeHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.FishSource] = UpgradeType.FishHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.WaterSource] = UpgradeType.WaterHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.FishingBoatNet] = UpgradeType.FishingNetHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.FishingBoatMagicNet] = UpgradeType.FishingMagicNetHarvestingSpeed;
		harvestingSpeedUpgrades[HarvestRecipeType.HarvestSand] = UpgradeType.SandHarvestingSpeed;
	}

	private void LoadMiningUpgrades()
	{
		prospectingSpeedUpgrades = new Dictionary<NaturalResource, UpgradeType>(new NaturalResourceEqualityComparer());
		prospectingSpeedUpgrades[NaturalResource.Rock] = UpgradeType.RockProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.IronOre] = UpgradeType.IronProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.CoalOre] = UpgradeType.CoalProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.GoldOre] = UpgradeType.GoldProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.SilverOre] = UpgradeType.SilverProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.CopperOre] = UpgradeType.CopperProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.ManaCrystal] = UpgradeType.ManaProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.Ruby] = UpgradeType.GemRedProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.Topaz] = UpgradeType.GemYellowProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.Sapphire] = UpgradeType.GemAquaProspectingSpeed;
		prospectingSpeedUpgrades[NaturalResource.Amethyst] = UpgradeType.GemPurpleProspectingSpeed;
	}

	private void LoadFarmingUpgrades()
	{
		cultivationSpeedUpgrades = new Dictionary<NaturalResource, UpgradeType>(new NaturalResourceEqualityComparer());
		cultivationSpeedUpgrades[NaturalResource.Wheat] = UpgradeType.GrainFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.CottonPlant] = UpgradeType.CottonFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.HerbBush] = UpgradeType.HerbFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.PotatoPlant] = UpgradeType.PotatoFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.TomatoPlant] = UpgradeType.TomatoFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.SugarCane] = UpgradeType.SugarFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.AppleTree] = UpgradeType.AppleFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.PearTree] = UpgradeType.PearFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.BerryBush] = UpgradeType.BerryFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.CactusFruitTree] = UpgradeType.CactusFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.DragonFruitTree] = UpgradeType.DragonFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.CarrotPlant] = UpgradeType.CarrotFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.Tree] = UpgradeType.TreeFarmingSpeed;
		cultivationSpeedUpgrades[NaturalResource.FishSource] = UpgradeType.FishFarmingSpeed;
	}

	private void LoadCoinCapacityData()
	{
		coinCapacityData = new List<CapacityUpgrade>();
		coinCapacityData.Add(new CapacityUpgrade(500f, (ItemType.YellowCoin, 50f)));
		coinCapacityData.Add(new CapacityUpgrade(2000f, (ItemType.YellowCoin, 250f)));
		coinCapacityData.Add(new CapacityUpgrade(5000f, (ItemType.YellowCoin, 1000f)));
	}

	private void LoadExplorationResults()
	{
		explorationResults = new List<ExplorationResult>();
		ExplorationResult explorationResult = AddExplorationResult();
		explorationResult.housingPlots = 6;
		explorationResult.resources[NaturalResource.Tree] = 100f;
		explorationResult.resources[NaturalResource.Rock] = 350f;
		ExplorationResult explorationResult2 = AddExplorationResult();
		explorationResult2.cost.AddItem(ItemType.YellowCoin, 10.0);
		explorationResult2.housingPlots = 4;
		explorationResult2.resources[NaturalResource.Tree] = 150f;
		explorationResult2.resources[NaturalResource.Rock] = 600f;
		explorationResult2.resources[NaturalResource.Wheat] = 75f;
		ExplorationResult explorationResult3 = AddExplorationResult();
		explorationResult3.cost.AddItem(ItemType.YellowCoin, 150.0);
		explorationResult3.housingPlots = 4;
		explorationResult3.resources[NaturalResource.Tree] = 250f;
		explorationResult3.resources[NaturalResource.Rock] = 500f;
		explorationResult3.resources[NaturalResource.Wheat] = 75f;
		explorationResult3.resources[NaturalResource.CottonPlant] = 75f;
		explorationResult3.resources[NaturalResource.BerryBush] = 25f;
		explorationResult3.resources[NaturalResource.WaterSource] = 50f;
		ExplorationResult explorationResult4 = AddExplorationResult();
		explorationResult4.cost.AddItem(ItemType.YellowCoin, 500.0);
		explorationResult4.housingPlots = 4;
		explorationResult4.resources[NaturalResource.Tree] = 500f;
		explorationResult4.resources[NaturalResource.Rock] = 500f;
		explorationResult4.resources[NaturalResource.Wheat] = 75f;
		explorationResult4.resources[NaturalResource.CottonPlant] = 100f;
		explorationResult4.resources[NaturalResource.PotatoPlant] = 100f;
		explorationResult4.resources[NaturalResource.IronOre] = 100f;
		ExplorationResult explorationResult5 = AddExplorationResult();
		explorationResult5.cost.AddItem(ItemType.YellowCoin, 2000.0);
		explorationResult5.housingPlots = 4;
		explorationResult5.resources[NaturalResource.Tree] = 500f;
		explorationResult5.resources[NaturalResource.Rock] = 500f;
		explorationResult5.resources[NaturalResource.Wheat] = 75f;
		explorationResult5.resources[NaturalResource.WaterSource] = 100f;
		explorationResult5.resources[NaturalResource.FishSource] = 100f;
		explorationResult5.resources[NaturalResource.AppleTree] = 50f;
		explorationResult5.resources[NaturalResource.HerbBush] = 100f;
		explorationResult5.resources[NaturalResource.CoalOre] = 400f;
		explorationResult5.resources[NaturalResource.IronOre] = 100f;
		ExplorationResult explorationResult6 = AddExplorationResult();
		explorationResult6.cost.AddItem(ItemType.YellowCoin, 3500.0);
		explorationResult6.housingPlots = 4;
		explorationResult6.resources[NaturalResource.Tree] = 500f;
		explorationResult6.resources[NaturalResource.Rock] = 500f;
		explorationResult6.resources[NaturalResource.Wheat] = 75f;
		explorationResult6.resources[NaturalResource.WaterSource] = 100f;
		explorationResult6.resources[NaturalResource.AppleTree] = 50f;
		explorationResult6.resources[NaturalResource.HerbBush] = 100f;
		explorationResult6.resources[NaturalResource.CoalOre] = 400f;
		explorationResult6.resources[NaturalResource.IronOre] = 100f;
		explorationResult6.resources[NaturalResource.SugarCane] = 100f;
		explorationResult6.resources[NaturalResource.TomatoPlant] = 50f;
		explorationResult6.resources[NaturalResource.PearTree] = 25f;
		ExplorationResult explorationResult7 = AddExplorationResult();
		explorationResult7.cost.AddItem(ItemType.YellowCoin, 5000.0);
		explorationResult7.housingPlots = 4;
		explorationResult7.resources[NaturalResource.ManaCrystal] = 100f;
	}

	private ExplorationResult AddExplorationResult()
	{
		ExplorationResult explorationResult = new ExplorationResult();
		explorationResults.Add(explorationResult);
		return explorationResult;
	}

	private void LoadHousingLevelConditions()
	{
		housingLevelConditions = new List<VictoryConditions>();
		int[] array = happinessRequiredPerHousingLevel;
		foreach (int happinessRequirement in array)
		{
			VictoryConditions victoryConditions = new VictoryConditions();
			housingLevelConditions.Add(victoryConditions);
			victoryConditions.SetHappinessRequirement(happinessRequirement);
		}
	}

	public static bool TryParse<T>(string stringToParse, out T result)
	{
		if (Enum.IsDefined(typeof(T), stringToParse))
		{
			result = (T)Enum.Parse(typeof(T), stringToParse);
			return true;
		}
		Debug.LogWarning("Unable to parse " + stringToParse + " into type " + typeof(T));
		result = default(T);
		return false;
	}

	public static int CostForTerrainPurchase(int numRevealed)
	{
		return 500;
	}

	public static bool IsItemEnabledDefault(ItemType itemType)
	{
		switch (itemType)
		{
		case ItemType.ProteinShake:
		case ItemType.GemOrange:
		case ItemType.GemGreen:
		case ItemType.GemBlue:
		case ItemType.GemPink:
		case ItemType.GrainSeeds:
		case ItemType.TreeSeeds:
		case ItemType.ManaSeeds:
		case ItemType.StoneAxe:
		case ItemType.ResearchTomeAgriculture1:
		case ItemType.ResearchTomeAgriculture2:
		case ItemType.ResearchTomeAgriculture3:
		case ItemType.ResearchTomeNature1:
		case ItemType.ResearchTomeNature2:
		case ItemType.ResearchTomeNature3:
		case ItemType.ResearchTomeFire1:
		case ItemType.ResearchTomeFire2:
		case ItemType.ResearchTomeFire3:
		case ItemType.ResearchTomeWater1:
		case ItemType.ResearchTomeWater2:
		case ItemType.ResearchTomeWater3:
		case ItemType.ResearchTomeEarth1:
		case ItemType.ResearchTomeEarth2:
		case ItemType.ResearchTomeEarth3:
		case ItemType.ResearchTomeAir1:
		case ItemType.ResearchTomeAir2:
		case ItemType.ResearchTomeAir3:
		case ItemType.FilterWorkerFood:
		case ItemType.FilterFarmSeeds:
		case ItemType.FilterTreeSeeds:
		case ItemType.FilterManaSeeds:
		case ItemType.FilterHouseFood:
		case ItemType.FilterHouseShelter:
		case ItemType.FilterHouseClothing:
		case ItemType.FilterHouseMedicine:
		case ItemType.FilterHouseLuxury:
			return false;
		default:
			return true;
		}
	}

	public static ItemList DefaultCostForBuilding(BuildingType type)
	{
		ItemList itemList = new ItemList();
		switch (type)
		{
		case BuildingType.Base:
			itemList.AddItem(ItemType.Plank, 40.0);
			itemList.AddItem(ItemType.StoneSlab, 40.0);
			itemList.AddItem(ItemType.RedCoin, 500.0);
			break;
		case BuildingType.Hut:
			itemList.AddItem(ItemType.Wood, 4.0);
			itemList.AddItem(ItemType.Stone, 4.0);
			break;
		case BuildingType.Lodge:
			itemList.AddItem(ItemType.Plank, 10.0);
			itemList.AddItem(ItemType.YellowCoin, 10.0);
			break;
		case BuildingType.House:
			itemList.AddItem(ItemType.Wood, 4.0);
			itemList.AddItem(ItemType.Stone, 4.0);
			itemList.AddItem(ItemType.YellowCoin, 100.0);
			break;
		case BuildingType.Mansion:
			itemList.AddItem(ItemType.ReinforcedPlank, 100.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 100.0);
			itemList.AddItem(ItemType.YellowCoin, 5000.0);
			break;
		case BuildingType.Palace:
			itemList.AddItem(ItemType.Steel, 2000.0);
			itemList.AddItem(ItemType.MagicPlank, 2000.0);
			itemList.AddItem(ItemType.YellowCoin, 50000.0);
			break;
		case BuildingType.HarvesterHut:
			itemList.AddItem(ItemType.Wood, 4.0);
			itemList.AddItem(ItemType.YellowCoin, 1.0);
			break;
		case BuildingType.Crate:
			itemList.AddItem(ItemType.Plank, 4.0);
			break;
		case BuildingType.Bank:
			itemList.AddItem(ItemType.StoneSlab, 10.0);
			break;
		case BuildingType.Pantry:
			itemList.AddItem(ItemType.Plank, 100.0);
			itemList.AddItem(ItemType.YellowCoin, 1000.0);
			break;
		case BuildingType.Stockpile:
			itemList.AddItem(ItemType.YellowCoin, 25.0);
			break;
		case BuildingType.Barrel:
			itemList.AddItem(ItemType.RefinedPlank, 10.0);
			itemList.AddItem(ItemType.YellowCoin, 20.0);
			break;
		case BuildingType.TradingPost:
			itemList.AddItem(ItemType.YellowCoin, 100.0);
			break;
		case BuildingType.Airship:
			itemList.AddItem(ItemType.AirshipComponent, 1000.0);
			itemList.AddItem(ItemType.PurpleCoin, 100000.0);
			break;
		case BuildingType.MagicBoat:
			itemList.AddItem(ItemType.MagicBoatComponent, 1000.0);
			itemList.AddItem(ItemType.PurpleCoin, 100000.0);
			break;
		case BuildingType.MagicConveyorBelt:
			itemList.AddItem(ItemType.MagicConveyorBelt, 100.0);
			itemList.AddItem(ItemType.PurpleCoin, 10000.0);
			break;
		case BuildingType.MagicRailTile:
			itemList.AddItem(ItemType.RailTileMagic, 100.0);
			itemList.AddItem(ItemType.PurpleCoin, 10000.0);
			break;
		case BuildingType.Forge:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.StoneSlab, 200.0);
			itemList.AddItem(ItemType.YellowCoin, 10000.0);
			break;
		case BuildingType.Hearth:
			itemList.AddItem(ItemType.StoneSlab, 100.0);
			itemList.AddItem(ItemType.YellowCoin, 200.0);
			break;
		case BuildingType.Chute:
			itemList.AddItem(ItemType.RefinedPlank, 500.0);
			itemList.AddItem(ItemType.YellowCoin, 500.0);
			break;
		case BuildingType.WaterWheel:
			itemList.AddItem(ItemType.ReinforcedPlank, 100.0);
			itemList.AddItem(ItemType.YellowCoin, 500.0);
			break;
		case BuildingType.PowerLine:
			itemList.AddItem(ItemType.CopperWire, 1000.0);
			itemList.AddItem(ItemType.RedCoin, 1000.0);
			break;
		case BuildingType.ManaPipeline:
			itemList.AddItem(ItemType.ManaPipe, 100.0);
			itemList.AddItem(ItemType.BlueCoin, 5000.0);
			break;
		case BuildingType.SteamPipeline:
			itemList.AddItem(ItemType.SteamPipe, 100.0);
			itemList.AddItem(ItemType.RedCoin, 2500.0);
			break;
		case BuildingType.MagmaPipeline:
			itemList.AddItem(ItemType.MagmaPipe, 100.0);
			itemList.AddItem(ItemType.RedCoin, 5000.0);
			break;
		case BuildingType.OmniPipeline:
			itemList.AddItem(ItemType.OmniPipe, 100.0);
			itemList.AddItem(ItemType.PurpleCoin, 20000.0);
			break;
		case BuildingType.SolarPanel:
			itemList.AddItem(ItemType.CopperWire, 400.0);
			itemList.AddItem(ItemType.GlassPanel, 200.0);
			itemList.AddItem(ItemType.Steel, 100.0);
			itemList.AddItem(ItemType.RedCoin, 5000.0);
			break;
		case BuildingType.CropHarvester:
			itemList.AddItem(ItemType.Gear, 500.0);
			itemList.AddItem(ItemType.IronWheel, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.Tractor:
			itemList.AddItem(ItemType.Gear, 500.0);
			itemList.AddItem(ItemType.IronWheel, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.Minecart:
			itemList.AddItem(ItemType.IronWheel, 500.0);
			itemList.AddItem(ItemType.RailTile, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 10000.0);
			break;
		case BuildingType.SteamTrain:
			itemList.AddItem(ItemType.IronWheel, 2000.0);
			itemList.AddItem(ItemType.RailTile, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 20000.0);
			break;
		case BuildingType.Caravan:
			itemList.AddItem(ItemType.YellowCoin, 1000.0);
			break;
		case BuildingType.HarvesterDrill:
			itemList.AddItem(ItemType.Gear, 500.0);
			itemList.AddItem(ItemType.IronIngot, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.FishingBoat:
			itemList.AddItem(ItemType.RefinedPlank, 50.0);
			itemList.AddItem(ItemType.YellowCoin, 500.0);
			break;
		case BuildingType.FloatingIsland:
			itemList.AddItem(ItemType.MagicStoneBrick, 50000.0);
			itemList.AddItem(ItemType.PurpleCoin, 100000.0);
			break;
		case BuildingType.ChainsawTank:
			itemList.AddItem(ItemType.Gear, 500.0);
			itemList.AddItem(ItemType.IronIngot, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.Aqueduct:
			itemList.AddItem(ItemType.RefinedStoneBrick, 1000.0);
			itemList.AddItem(ItemType.YellowCoin, 1000.0);
			break;
		case BuildingType.Furnace:
			itemList.AddItem(ItemType.IronIngot, 50.0);
			itemList.AddItem(ItemType.RedCoin, 200.0);
			break;
		case BuildingType.Tailor:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.StoneSlab, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 2000.0);
			break;
		case BuildingType.MedicineHut:
			itemList.AddItem(ItemType.RefinedPlank, 1000.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 1000.0);
			itemList.AddItem(ItemType.YellowCoin, 5000.0);
			break;
		case BuildingType.GeneralLab:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.StoneSlab, 200.0);
			itemList.AddItem(ItemType.YellowCoin, 4000.0);
			break;
		case BuildingType.MagicLab:
			itemList.AddItem(ItemType.PurifiedMana, 200.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 10000.0);
			itemList.AddItem(ItemType.PurpleCoin, 5000.0);
			break;
		case BuildingType.TechLab:
			itemList.AddItem(ItemType.RefinedPlank, 200.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 2000.0);
			itemList.AddItem(ItemType.RedCoin, 20000.0);
			break;
		case BuildingType.Factory:
			itemList.AddItem(ItemType.MetalConveyorBelt, 300.0);
			itemList.AddItem(ItemType.ReinforcedPlank, 300.0);
			itemList.AddItem(ItemType.YellowCoin, 100000.0);
			break;
		case BuildingType.Foundry:
			itemList.AddItem(ItemType.Steel, 1000.0);
			itemList.AddItem(ItemType.RedCoin, 200000.0);
			break;
		case BuildingType.Packager:
			itemList.AddItem(ItemType.MetalConveyorBelt, 300.0);
			itemList.AddItem(ItemType.ReinforcedPlank, 300.0);
			itemList.AddItem(ItemType.YellowCoin, 100000.0);
			break;
		case BuildingType.Refinery:
			itemList.AddItem(ItemType.MagicPlank, 5000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 5000.0);
			itemList.AddItem(ItemType.PurpleCoin, 100000.0);
			break;
		case BuildingType.MagicForge:
			itemList.AddItem(ItemType.Steel, 4000.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 4000.0);
			itemList.AddItem(ItemType.BlueCoin, 100000.0);
			break;
		case BuildingType.SteamBoiler:
			itemList.AddItem(ItemType.IronIngot, 200.0);
			itemList.AddItem(ItemType.SteamPipe, 200.0);
			itemList.AddItem(ItemType.YellowCoin, 100000.0);
			break;
		case BuildingType.SteamPowerGenerator:
			itemList.AddItem(ItemType.IronWheel, 100.0);
			itemList.AddItem(ItemType.IronIngot, 100.0);
			itemList.AddItem(ItemType.SteamPipe, 100.0);
			itemList.AddItem(ItemType.RedCoin, 20000.0);
			break;
		case BuildingType.MachineShop:
			itemList.AddItem(ItemType.ReinforcedPlank, 200.0);
			itemList.AddItem(ItemType.IronIngot, 4000.0);
			itemList.AddItem(ItemType.YellowCoin, 30000.0);
			break;
		case BuildingType.Farm:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.Stone, 200.0);
			itemList.AddItem(ItemType.YellowCoin, 500.0);
			break;
		case BuildingType.Forester:
			itemList.AddItem(ItemType.Plank, 100.0);
			itemList.AddItem(ItemType.Stone, 200.0);
			itemList.AddItem(ItemType.YellowCoin, 600.0);
			break;
		case BuildingType.Pasture:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.Stone, 300.0);
			itemList.AddItem(ItemType.YellowCoin, 1000.0);
			break;
		case BuildingType.Fishery:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.StoneSlab, 200.0);
			itemList.AddItem(ItemType.YellowCoin, 1000.0);
			break;
		case BuildingType.WaterPump:
			itemList.AddItem(ItemType.IronIngot, 500.0);
			itemList.AddItem(ItemType.IronWheel, 500.0);
			itemList.AddItem(ItemType.RedCoin, 5000.0);
			break;
		case BuildingType.LumberMill:
			itemList.AddItem(ItemType.Wood, 20.0);
			itemList.AddItem(ItemType.Stone, 10.0);
			itemList.AddItem(ItemType.YellowCoin, 10.0);
			break;
		case BuildingType.Market:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.Stone, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 20.0);
			break;
		case BuildingType.GeneralGoods:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.Stone, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 30.0);
			break;
		case BuildingType.HardwareStore:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.Stone, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 30.0);
			break;
		case BuildingType.Bookstore:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.Stone, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 30.0);
			break;
		case BuildingType.ClothingStore:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.StoneSlab, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 30.0);
			break;
		case BuildingType.FancyFoods:
			itemList.AddItem(ItemType.RefinedPlank, 50.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 50.0);
			itemList.AddItem(ItemType.YellowCoin, 5000.0);
			break;
		case BuildingType.Apothecary:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.StoneSlab, 200.0);
			itemList.AddItem(ItemType.RedCoin, 2000.0);
			break;
		case BuildingType.JewelryStore:
			itemList.AddItem(ItemType.RefinedPlank, 500.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 500.0);
			itemList.AddItem(ItemType.RedCoin, 1000.0);
			break;
		case BuildingType.ArcaneStore:
			itemList.AddItem(ItemType.RefinedPlank, 500.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 1000.0);
			break;
		case BuildingType.Quarry:
			itemList.AddItem(ItemType.Plank, 10.0);
			itemList.AddItem(ItemType.YellowCoin, 20.0);
			break;
		case BuildingType.Mine:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.Shovel, 100.0);
			itemList.AddItem(ItemType.YellowCoin, 2000.0);
			break;
		case BuildingType.GemMine:
			itemList.AddItem(ItemType.ReinforcedPlank, 2000.0);
			itemList.AddItem(ItemType.Pickaxe, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.Well:
			itemList.AddItem(ItemType.Plank, 10.0);
			itemList.AddItem(ItemType.StoneSlab, 10.0);
			itemList.AddItem(ItemType.YellowCoin, 250.0);
			break;
		case BuildingType.GrainMill:
			itemList.AddItem(ItemType.Wood, 20.0);
			itemList.AddItem(ItemType.Stone, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 20.0);
			break;
		case BuildingType.Workshop:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.Stone, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 50.0);
			break;
		case BuildingType.Bakery:
			itemList.AddItem(ItemType.RefinedPlank, 50.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 50.0);
			itemList.AddItem(ItemType.YellowCoin, 2000.0);
			break;
		case BuildingType.GourmetKitchen:
			itemList.AddItem(ItemType.RefinedPlank, 2000.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 2000.0);
			itemList.AddItem(ItemType.YellowCoin, 20000.0);
			break;
		case BuildingType.Jeweler:
			itemList.AddItem(ItemType.RefinedPlank, 2000.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 2000.0);
			itemList.AddItem(ItemType.RedCoin, 25000.0);
			break;
		case BuildingType.StoneMason:
			itemList.AddItem(ItemType.Wood, 20.0);
			itemList.AddItem(ItemType.Stone, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 30.0);
			break;
		case BuildingType.Recharger:
			itemList.AddItem(ItemType.MagicStoneBrick, 50.0);
			itemList.AddItem(ItemType.PurpleCoin, 25.0);
			break;
		case BuildingType.MegaRecharger:
			itemList.AddItem(ItemType.MagicStoneBrick, 100.0);
			itemList.AddItem(ItemType.YellowCoin, 250.0);
			break;
		case BuildingType.Warehouse:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.StoneSlab, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 30.0);
			break;
		case BuildingType.RailDepot:
			itemList.AddItem(ItemType.RefinedPlank, 1000.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 1000.0);
			itemList.AddItem(ItemType.YellowCoin, 50000.0);
			break;
		case BuildingType.CropSilo:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.StoneSlab, 200.0);
			itemList.AddItem(ItemType.YellowCoin, 500.0);
			break;
		case BuildingType.OreSilo:
			itemList.AddItem(ItemType.IronIngot, 200.0);
			itemList.AddItem(ItemType.RedCoin, 500.0);
			break;
		case BuildingType.Treasury:
			itemList.AddItem(ItemType.PolishedStone, 1000.0);
			itemList.AddItem(ItemType.BlueCoin, 5000.0);
			break;
		case BuildingType.EtherStorage:
			itemList.AddItem(ItemType.MagicPlank, 2000.0);
			itemList.AddItem(ItemType.PurpleCoin, 20000.0);
			break;
		case BuildingType.OmnistoneStorage:
			itemList.AddItem(ItemType.Omnistone, 1000.0);
			itemList.AddItem(ItemType.PurpleCoin, 50000.0);
			break;
		case BuildingType.Library:
			itemList.AddItem(ItemType.Plank, 200.0);
			itemList.AddItem(ItemType.StoneSlab, 200.0);
			itemList.AddItem(ItemType.YellowCoin, 500.0);
			break;
		case BuildingType.Reservoir:
			itemList.AddItem(ItemType.Shovel, 100.0);
			itemList.AddItem(ItemType.YellowCoin, 1000.0);
			break;
		case BuildingType.ManaBattery:
			itemList.AddItem(ItemType.CopperIngot, 10000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 2000.0);
			itemList.AddItem(ItemType.PurifiedMana, 2000.0);
			itemList.AddItem(ItemType.PurpleCoin, 10000.0);
			break;
		case BuildingType.Crystalarium:
			itemList.AddItem(ItemType.MagicStoneBrick, 5000.0);
			itemList.AddItem(ItemType.MagicPlank, 5000.0);
			itemList.AddItem(ItemType.PurpleCoin, 5000.0);
			break;
		case BuildingType.Battery:
			itemList.AddItem(ItemType.CopperWire, 5000.0);
			itemList.AddItem(ItemType.RedCoin, 10000.0);
			break;
		case BuildingType.Enchanter:
			itemList.AddItem(ItemType.PurifiedMana, 3000.0);
			itemList.AddItem(ItemType.RefinedPlank, 3000.0);
			itemList.AddItem(ItemType.PurpleCoin, 10000.0);
			break;
		case BuildingType.Incinerator:
			itemList.AddItem(ItemType.IronIngot, 20.0);
			itemList.AddItem(ItemType.StoneSlab, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 100.0);
			break;
		case BuildingType.ManaReactor:
			itemList.AddItem(ItemType.MagicPlank, 25000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 25000.0);
			itemList.AddItem(ItemType.PurpleCoin, GameUtility.Millions(1));
			break;
		case BuildingType.School:
			itemList.AddItem(ItemType.Plank, 20.0);
			itemList.AddItem(ItemType.StoneSlab, 20.0);
			itemList.AddItem(ItemType.YellowCoin, 100.0);
			break;
		case BuildingType.ManaTransmitter:
			itemList.AddItem(ItemType.PurifiedMana, 200.0);
			itemList.AddItem(ItemType.RefinedStoneBrick, 500.0);
			itemList.AddItem(ItemType.BlueCoin, 500.0);
			break;
		case BuildingType.Diffuser:
			itemList.AddItem(ItemType.MagicStoneBrick, 10.0);
			itemList.AddItem(ItemType.YellowCoin, 200.0);
			break;
		case BuildingType.Void:
			itemList.AddItem(ItemType.ReinforcedPlank, 10.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 100.0);
			itemList.AddItem(ItemType.YellowCoin, 1000.0);
			break;
		case BuildingType.FireShrine:
			itemList.AddItem(ItemType.PurifiedFire, 1000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 5000.0);
			itemList.AddItem(ItemType.PurpleCoin, 30000.0);
			break;
		case BuildingType.WaterShrine:
			itemList.AddItem(ItemType.PurifiedWater, 1000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 500.0);
			itemList.AddItem(ItemType.PurpleCoin, 30000.0);
			break;
		case BuildingType.EarthShrine:
			itemList.AddItem(ItemType.PurifiedEarth, 1000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 5000.0);
			itemList.AddItem(ItemType.PurpleCoin, 30000.0);
			break;
		case BuildingType.AirShrine:
			itemList.AddItem(ItemType.PurifiedAir, 1000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 5000.0);
			itemList.AddItem(ItemType.PurpleCoin, 30000.0);
			break;
		case BuildingType.ManaTemple:
			itemList.AddItem(ItemType.PurifiedMana, 20000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 2000.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.FireTemple:
			itemList.AddItem(ItemType.PurifiedFire, 20000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 2000.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.WaterTemple:
			itemList.AddItem(ItemType.PurifiedWater, 20000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 2000.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.EarthTemple:
			itemList.AddItem(ItemType.PurifiedEarth, 20000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 2000.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.AirTemple:
			itemList.AddItem(ItemType.PurifiedAir, 20000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 2000.0);
			itemList.AddItem(ItemType.BlueCoin, 50000.0);
			break;
		case BuildingType.OmniTemple:
			itemList.AddItem(ItemType.Omnistone, 2000.0);
			itemList.AddItem(ItemType.MagicStoneBrick, 5000.0);
			itemList.AddItem(ItemType.PurpleCoin, 1000000.0);
			break;
		case BuildingType.PlainsUniversity:
			itemList.AddItem(ItemType.PurpleCoin, 1000000000.0);
			break;
		case BuildingType.ForestMonastery:
			itemList.AddItem(ItemType.PurpleCoin, 1000000000.0);
			break;
		case BuildingType.RiverHarbor:
			itemList.AddItem(ItemType.PurpleCoin, 1000000000.0);
			break;
		case BuildingType.MountainObservatory:
			itemList.AddItem(ItemType.PurpleCoin, 1000000000.0);
			break;
		case BuildingType.JunglePyramid:
			itemList.AddItem(ItemType.PurpleCoin, 1000000000.0);
			break;
		case BuildingType.DesertBazaar:
			itemList.AddItem(ItemType.PurpleCoin, 1000000000.0);
			break;
		case BuildingType.SnowTreasureVault:
			itemList.AddItem(ItemType.PurpleCoin, 1000000000.0);
			break;
		case BuildingType.MagicObelisk:
			itemList.AddItem(ItemType.PurpleCoin, 1000000000.0);
			break;
		}
		return itemList;
	}

	private void LoadDisplayCategories()
	{
		defaultDisplayCategories = new Dictionary<BuildCategoryType, List<EntityId>>(new BuildCategoryComparer());
		List<BuildingType> obj = new List<BuildingType>
		{
			BuildingType.Base,
			BuildingType.House,
			BuildingType.School,
			BuildingType.LumberMill,
			BuildingType.GrainMill,
			BuildingType.Workshop,
			BuildingType.HarvesterHut,
			BuildingType.Aqueduct,
			BuildingType.FishingBoat,
			BuildingType.HarvesterDrill,
			BuildingType.ChainsawTank,
			BuildingType.CropHarvester,
			BuildingType.Market,
			BuildingType.GeneralGoods,
			BuildingType.HardwareStore,
			BuildingType.Bookstore,
			BuildingType.ClothingStore,
			BuildingType.FancyFoods,
			BuildingType.Apothecary,
			BuildingType.JewelryStore,
			BuildingType.ArcaneStore,
			BuildingType.TradingPost,
			BuildingType.PowerLine,
			BuildingType.SteamPipeline,
			BuildingType.MagmaPipeline,
			BuildingType.ManaPipeline,
			BuildingType.OmniPipeline,
			BuildingType.Caravan,
			BuildingType.SteamTrain,
			BuildingType.Tailor,
			BuildingType.StoneMason,
			BuildingType.Pasture,
			BuildingType.Bakery,
			BuildingType.GourmetKitchen,
			BuildingType.Forge,
			BuildingType.MachineShop,
			BuildingType.Jeweler,
			BuildingType.MedicineHut,
			BuildingType.GeneralLab,
			BuildingType.TechLab,
			BuildingType.MagicLab,
			BuildingType.Hearth,
			BuildingType.Furnace,
			BuildingType.WaterWheel,
			BuildingType.SolarPanel,
			BuildingType.WaterPump,
			BuildingType.SteamBoiler,
			BuildingType.SteamPowerGenerator,
			BuildingType.FireShrine,
			BuildingType.WaterShrine,
			BuildingType.AirShrine,
			BuildingType.EarthShrine,
			BuildingType.Crate,
			BuildingType.Barrel,
			BuildingType.Reservoir,
			BuildingType.Stockpile,
			BuildingType.Warehouse,
			BuildingType.CropSilo,
			BuildingType.OreSilo,
			BuildingType.RailDepot,
			BuildingType.Library,
			BuildingType.Bank,
			BuildingType.Pantry,
			BuildingType.Treasury,
			BuildingType.Battery,
			BuildingType.ManaBattery,
			BuildingType.Crystalarium,
			BuildingType.EtherStorage,
			BuildingType.OmnistoneStorage,
			BuildingType.MagicForge,
			BuildingType.ManaTransmitter,
			BuildingType.Enchanter,
			BuildingType.Refinery,
			BuildingType.Recharger,
			BuildingType.MegaRecharger,
			BuildingType.Void,
			BuildingType.ManaReactor,
			BuildingType.OmniTemple,
			BuildingType.Forester,
			BuildingType.Farm,
			BuildingType.Fishery,
			BuildingType.Quarry,
			BuildingType.Mine,
			BuildingType.GemMine,
			BuildingType.Well,
			BuildingType.Chute,
			BuildingType.Factory,
			BuildingType.Foundry,
			BuildingType.Tractor,
			BuildingType.Minecart,
			BuildingType.Packager,
			BuildingType.MagicRailTile,
			BuildingType.MagicConveyorBelt,
			BuildingType.MagicBoat,
			BuildingType.Airship,
			BuildingType.FloatingIsland,
			BuildingType.ManaTemple,
			BuildingType.FireTemple,
			BuildingType.WaterTemple,
			BuildingType.AirTemple,
			BuildingType.EarthTemple,
			BuildingType.PlainsUniversity,
			BuildingType.ForestMonastery,
			BuildingType.RiverHarbor,
			BuildingType.MountainObservatory,
			BuildingType.JunglePyramid,
			BuildingType.DesertBazaar,
			BuildingType.SnowTreasureVault,
			BuildingType.MagicObelisk
		};
		List<EntityId> list = new List<EntityId>();
		foreach (BuildingType item in obj)
		{
			if (IsBuildingEnabledDefault(item))
			{
				list.Add(Building.ToId(item));
			}
		}
		defaultDisplayCategories[BuildCategoryType.Building] = list;
		List<HarvestRecipeType> obj2 = new List<HarvestRecipeType>
		{
			HarvestRecipeType.Tree,
			HarvestRecipeType.HarvestSand,
			HarvestRecipeType.Wheat,
			HarvestRecipeType.BerryBush,
			HarvestRecipeType.HerbBush,
			HarvestRecipeType.AppleTree,
			HarvestRecipeType.PearTree,
			HarvestRecipeType.WaterSource,
			HarvestRecipeType.CarrotPlant,
			HarvestRecipeType.PotatoPlant,
			HarvestRecipeType.TomatoPlant,
			HarvestRecipeType.CottonPlant,
			HarvestRecipeType.SugarCane,
			HarvestRecipeType.DragonFruitTree,
			HarvestRecipeType.CactusFruitTree,
			HarvestRecipeType.Rock,
			HarvestRecipeType.IronOre,
			HarvestRecipeType.CoalOre,
			HarvestRecipeType.CopperOre,
			HarvestRecipeType.SilverOre,
			HarvestRecipeType.GoldOre,
			HarvestRecipeType.Ruby,
			HarvestRecipeType.Topaz,
			HarvestRecipeType.Sapphire,
			HarvestRecipeType.Amethyst,
			HarvestRecipeType.ManaCrystal,
			HarvestRecipeType.AqueductHarvestWater,
			HarvestRecipeType.FishSource,
			HarvestRecipeType.FishingBoatNet,
			HarvestRecipeType.FishingBoatMagicNet,
			HarvestRecipeType.ChainsawTree,
			HarvestRecipeType.CropHarvesterGrain,
			HarvestRecipeType.CropHarvesterBerries,
			HarvestRecipeType.CropHarvesterHerb,
			HarvestRecipeType.CropHarvesterApple,
			HarvestRecipeType.CropHarvesterPear,
			HarvestRecipeType.CropHarvesterCarrot,
			HarvestRecipeType.CropHarvesterPotato,
			HarvestRecipeType.CropHarvesterTomato,
			HarvestRecipeType.CropHarvesterCotton,
			HarvestRecipeType.CropHarvesterSugar,
			HarvestRecipeType.CropHarvesterDragonFruit,
			HarvestRecipeType.CropHarvesterCactusFruit,
			HarvestRecipeType.DrillRock,
			HarvestRecipeType.DrillIron,
			HarvestRecipeType.DrillCoal,
			HarvestRecipeType.DrillCopper,
			HarvestRecipeType.DrillSilver,
			HarvestRecipeType.DrillGold,
			HarvestRecipeType.DrillRuby,
			HarvestRecipeType.DrillTopaz,
			HarvestRecipeType.DrillAmethyst,
			HarvestRecipeType.DrillSapphire,
			HarvestRecipeType.DrillMana
		};
		List<EntityId> list2 = new List<EntityId>();
		foreach (HarvestRecipeType item2 in obj2)
		{
			list2.Add(EntityId.FromHarvestRecipe(item2));
		}
		defaultDisplayCategories[BuildCategoryType.Harvesting] = list2;
		List<QuestType> obj3 = new List<QuestType>
		{
			QuestType.WoodForHouse,
			QuestType.HouseForHarvesterHut,
			QuestType.HarvesterHutForAssignWorkers,
			QuestType.AssignWorkersForGeneralStore,
			QuestType.SchoolForResearchPanel,
			QuestType.PlanksForGeneralStore,
			QuestType.WorkshopForHardwareStore,
			QuestType.MilestoneBuildSolarPanel,
			QuestType.MilestoneTownLevel2,
			QuestType.MilestoneTownLevel3,
			QuestType.MilestoneTownLevel4,
			QuestType.MilestoneTownLevel5,
			QuestType.MilestoneTownLevel6,
			QuestType.MilestoneTownLevel7,
			QuestType.MilestoneTownLevel8,
			QuestType.MilestoneTownLevel9,
			QuestType.MilestoneTownLevel10,
			QuestType.MilestoneTownLevel11,
			QuestType.MilestoneTownLevel12,
			QuestType.MilestoneTownLevel13,
			QuestType.MilestoneTownLevel14,
			QuestType.MilestoneTownLevel15,
			QuestType.DiscoverSugar,
			QuestType.DiscoverTomato,
			QuestType.MilestoneRiverLevelForForest,
			QuestType.DiscoverBerries,
			QuestType.DiscoverPear,
			QuestType.MilestoneForestLevelForMountains,
			QuestType.MilestoneMountainLevel10,
			QuestType.MilestoneMountainLevelForJungle,
			QuestType.MilestoneDesertLevel10,
			QuestType.MilestoneDesertLevelForSnow,
			QuestType.MilestoneJungleLevel10,
			QuestType.MilestoneJungleLevelForDesert,
			QuestType.MilestoneSnowLevel10,
			QuestType.MilestoneSnowLevelForMagic,
			QuestType.OmnitempleForAutoClaim,
			QuestType.TownLevelForPlainsUniversity,
			QuestType.TownLevelForForestMonastery,
			QuestType.TownLevelForRiverHarbor,
			QuestType.TownLevelForMountainObservatory,
			QuestType.TownLevelForJunglePyramid,
			QuestType.TownLevelForDesertBazaar,
			QuestType.TownLevelForSnowTreasureVault,
			QuestType.TownLevelForMagicObelisk,
			QuestType.MilestoneAnyTownLevel40,
			QuestType.MilestoneAnyTownLevel50,
			QuestType.SecondTownForTradingPost,
			QuestType.PaperForBookstore,
			QuestType.MedicineHutForHospital,
			QuestType.TailorForClothingStore,
			QuestType.JewelerForJewelryStore,
			QuestType.HarvestManaForArcaneEmporium,
			QuestType.EarnCoinsForLumberMill,
			QuestType.MilestoneHouses10,
			QuestType.HousesForSchool,
			QuestType.GeneralStoreForMarketPanel,
			QuestType.TradingPostForTradingPanel,
			QuestType.TradingPostsForCaravan,
			QuestType.SteamPipeForSteamPipeline,
			QuestType.CopperWireForPowerLines,
			QuestType.MagmaPipeForMagmaPipeline,
			QuestType.ManaPipeForManaPipeline,
			QuestType.OmniPipeForOmniPipeline,
			QuestType.LumberMillForCrafting,
			QuestType.QuarryForProspectingPanel,
			QuestType.PlanksForRefinedPlank,
			QuestType.SkillsForPaper,
			QuestType.FlourForAnimalFeed,
			QuestType.StoneBricksForRefinedStoneBricks,
			QuestType.RefinedStoneBricksForQuartz,
			QuestType.WoolSkillForWoolCloth,
			QuestType.CottonClothSkillForShirt,
			QuestType.IronIngotForWoodAxe,
			QuestType.WoodAxeForPickaxe,
			QuestType.SkillsForCloak,
			QuestType.SkillsForWarmCoat,
			QuestType.PaperSkillsForBook,
			QuestType.EggSkillForChicken,
			QuestType.MilkSkillForBeef,
			QuestType.BeefSkillForLeather,
			QuestType.MilkSkillForButter,
			QuestType.ShirtSkillForPants,
			QuestType.SkillsForShoe,
			QuestType.SugarForRefinedSugar,
			QuestType.AppleJuiceSkillsForJam,
			QuestType.PearJuiceSkillsForJam,
			QuestType.BerryJuiceSkillsForJam,
			QuestType.SkillsForCactusJam,
			QuestType.SkillsForFishOil,
			QuestType.SkillsForCake,
			QuestType.CakeSkillsForBerryCake,
			QuestType.SkillsForDragonPunch,
			QuestType.CookedFishSkillsForFishStew,
			QuestType.CookedBeefSkillsForBeefStew,
			QuestType.CookedChickenSkillsForSandwich,
			QuestType.SkillsForNails,
			QuestType.SkillsForReinforcedPlank,
			QuestType.SkillsForSteamPipe,
			QuestType.SkillsForCopperRing,
			QuestType.SkillsForSilverJewelry,
			QuestType.SkillsForGoldJewelry,
			QuestType.CopperSkillForWire,
			QuestType.SkillsForRubyRing,
			QuestType.SkillsForSapphireRing,
			QuestType.SkillsForAmethystNecklace,
			QuestType.SkillsForTopazCrown,
			QuestType.WoolClothSkillForHat,
			QuestType.ShoeSkillForBoots,
			QuestType.SkillsForMagicShirt,
			QuestType.SkillsForMagicCloak,
			QuestType.SkillsForMagicPants,
			QuestType.SkillsForMagicBoots,
			QuestType.SkillsForMagicHat,
			QuestType.SkillsForMagicRing,
			QuestType.SkillsForFireRing,
			QuestType.SkillsForWaterRing,
			QuestType.SkillsForEnchantedNecklace,
			QuestType.SkillsForEnchantedCrown,
			QuestType.ResearchForUpgrades,
			QuestType.EarnRedCoins,
			QuestType.EarnBlueCoins,
			QuestType.EarnPurpleCoins,
			QuestType.EarnOmniCoins,
			QuestType.GrainForFoodMarket,
			QuestType.HarvestItemsForStockpile,
			QuestType.HarvestCottonForTailorResearch,
			QuestType.MilestoneBuildForester,
			QuestType.MilestoneBuildFarm,
			QuestType.MilestoneBuildFoodMill,
			QuestType.MilestoneBuildStoneMason,
			QuestType.MilestoneBuildMine,
			QuestType.MilestoneBuildHearth,
			QuestType.MilestoneBuildBakery,
			QuestType.MilestoneBuildPasture,
			QuestType.GourmetKitchenForFancyFoodsStore,
			QuestType.MilestoneUpgrades10,
			QuestType.MilestoneStarCoins100,
			QuestType.MilestoneStarCoins1000,
			QuestType.MilestoneStarCoins10000,
			QuestType.MilestoneStarCoins100000,
			QuestType.MilestoneCooking,
			QuestType.MilestoneJamGourmet,
			QuestType.MilestoneStewGourmet,
			QuestType.MilestoneDessertGourmet,
			QuestType.MilestoneBasicJewelry,
			QuestType.MilestoneGemJewelry,
			QuestType.MilestoneMagicJewelry,
			QuestType.MilestoneSpellbooks,
			QuestType.UnlockYellowCoinXP,
			QuestType.UnlockRedCoinXP,
			QuestType.UnlockBlueCoinXP,
			QuestType.UnlockPurpleCoinXP,
			QuestType.UnlockOmniCoinXP,
			QuestType.IdleRewardsPlains,
			QuestType.IdleRewardsRiver,
			QuestType.IdleRewardsForest,
			QuestType.IdleRewardsMountians,
			QuestType.IdleRewardsJungle,
			QuestType.IdleRewardsDesert,
			QuestType.IdleRewardsSnow,
			QuestType.IdleRewardsMagic
		};
		List<EntityId> list3 = new List<EntityId>();
		foreach (QuestType item3 in obj3)
		{
			list3.Add(EntityId.FromQuest(item3));
		}
		defaultDisplayCategories[BuildCategoryType.Quests] = list3;
		List<UpgradeType> obj4 = new List<UpgradeType>
		{
			UpgradeType.UpgradeEfficiency,
			UpgradeType.Exploration,
			UpgradeType.HouseCapacity,
			UpgradeType.HouseCost,
			UpgradeType.ResearchSpeed,
			UpgradeType.ConstructionEfficiency,
			UpgradeType.MarketCostFood,
			UpgradeType.MarketCostGeneral,
			UpgradeType.MarketCostHardware,
			UpgradeType.MarketCostBookstore,
			UpgradeType.MarketCostClothing,
			UpgradeType.MarketCostGourmet,
			UpgradeType.MarketCostApothecary,
			UpgradeType.MarketCostJewelry,
			UpgradeType.MarketCostArcane,
			UpgradeType.SkillGainSpeed,
			UpgradeType.SkillEffectCrafting,
			UpgradeType.SkillEffectHarvesting,
			UpgradeType.SkillEffectCultivation,
			UpgradeType.SkillEffectProspecting,
			UpgradeType.IronProspectingSpeed,
			UpgradeType.CoalProspectingSpeed,
			UpgradeType.CopperProspectingSpeed,
			UpgradeType.GoldProspectingSpeed,
			UpgradeType.ManaProspectingSpeed,
			UpgradeType.GemRedProspectingSpeed,
			UpgradeType.GemYellowProspectingSpeed,
			UpgradeType.GemAquaProspectingSpeed,
			UpgradeType.GemPurpleProspectingSpeed,
			UpgradeType.SilverProspectingSpeed,
			UpgradeType.RockProspectingSpeed,
			UpgradeType.GrainFarmingSpeed,
			UpgradeType.CottonFarmingSpeed,
			UpgradeType.HerbFarmingSpeed,
			UpgradeType.PotatoFarmingSpeed,
			UpgradeType.TomatoFarmingSpeed,
			UpgradeType.SugarFarmingSpeed,
			UpgradeType.AppleFarmingSpeed,
			UpgradeType.PearFarmingSpeed,
			UpgradeType.BerryFarmingSpeed,
			UpgradeType.CactusFarmingSpeed,
			UpgradeType.DragonFarmingSpeed,
			UpgradeType.CarrotFarmingSpeed,
			UpgradeType.TreeFarmingSpeed,
			UpgradeType.FishFarmingSpeed,
			UpgradeType.SandHarvestingSpeed,
			UpgradeType.RockHarvestingSpeed,
			UpgradeType.CoalHarvestingSpeed,
			UpgradeType.IronHarvestingSpeed,
			UpgradeType.CopperHarvestingSpeed,
			UpgradeType.GoldHarvestingSpeed,
			UpgradeType.ManaHarvestingSpeed,
			UpgradeType.GemRedHarvestingSpeed,
			UpgradeType.GemYellowHarvestingSpeed,
			UpgradeType.GemAquaHarvestingSpeed,
			UpgradeType.GemPurpleHarvestingSpeed,
			UpgradeType.GrainHarvestingSpeed,
			UpgradeType.CottonHarvestingSpeed,
			UpgradeType.HerbHarvestingSpeed,
			UpgradeType.PotatoHarvestingSpeed,
			UpgradeType.TomatoHarvestingSpeed,
			UpgradeType.SugarHarvestingSpeed,
			UpgradeType.AppleHarvestingSpeed,
			UpgradeType.PearHarvestingSpeed,
			UpgradeType.BerryHarvestingSpeed,
			UpgradeType.CactusHarvestingSpeed,
			UpgradeType.DragonHarvestingSpeed,
			UpgradeType.CarrotHarvestingSpeed,
			UpgradeType.TreeHarvestingSpeed,
			UpgradeType.SilverHarvestingSpeed,
			UpgradeType.FishHarvestingSpeed,
			UpgradeType.FishingNetHarvestingSpeed,
			UpgradeType.FishingMagicNetHarvestingSpeed,
			UpgradeType.WaterHarvestingSpeed,
			UpgradeType.FoodMarketCapacity,
			UpgradeType.GeneralGoodsCapacity,
			UpgradeType.ApothecaryCapacity,
			UpgradeType.JewelryStoreCapacity,
			UpgradeType.ArcaneStoreCapacity,
			UpgradeType.FancyFoodsCapacity,
			UpgradeType.TradingPostWorkersPerBuilding,
			UpgradeType.HarvesterHutProficiency,
			UpgradeType.FishingBoatProficiency,
			UpgradeType.CropHarvesterProficiency,
			UpgradeType.ChainsawTankProficiency,
			UpgradeType.HarvesterDrillProficiency,
			UpgradeType.StoneMasonProficiency,
			UpgradeType.TailorProficiency,
			UpgradeType.WorkshopProficiency,
			UpgradeType.GrainMillProficiency,
			UpgradeType.ForgeProficiency,
			UpgradeType.BakeryProficiency,
			UpgradeType.MachineShopProficiency,
			UpgradeType.MedicineHutProficiency,
			UpgradeType.LumberMillProficiency,
			UpgradeType.MineProficiency,
			UpgradeType.FarmingProficiency,
			UpgradeType.FisheryProficiency,
			UpgradeType.ForesterProficiency,
			UpgradeType.EnchantedForgeProficiency,
			UpgradeType.EnchanterProficiency,
			UpgradeType.ExtractorProficiency,
			UpgradeType.RefineryProficiency,
			UpgradeType.JewelerProficiency,
			UpgradeType.QuarryProficiency,
			UpgradeType.GemMineProficiency,
			UpgradeType.GourmetKitchenProficiency,
			UpgradeType.PastureProficiency,
			UpgradeType.StudyProficiency,
			UpgradeType.TechLabProficiency,
			UpgradeType.MagicLabProficiency,
			UpgradeType.PickaxeMiningYield,
			UpgradeType.ChainsawTankYield,
			UpgradeType.HarvesterDrillYield,
			UpgradeType.CropHarvesterYield,
			UpgradeType.FishingBoatYield,
			UpgradeType.FurnaceSpeed,
			UpgradeType.FurnaceProductivity,
			UpgradeType.FuelEfficiency,
			UpgradeType.WaterPumpCountSpeed,
			UpgradeType.SteamBoilerCountSpeed,
			UpgradeType.SteamPowerGeneratorCountSpeed,
			UpgradeType.FurnaceCountSpeed,
			UpgradeType.ExtractorCountSpeed,
			UpgradeType.MarketConsumptionFood,
			UpgradeType.MarketConsumptionGeneralGoods,
			UpgradeType.MarketConsumptionMedicine,
			UpgradeType.MarketConsumptionJewelryStore,
			UpgradeType.MarketConsumptionArcaneGoods,
			UpgradeType.MarketConsumptionGourmetFood,
			UpgradeType.MarketConsumptionClothing,
			UpgradeType.MarketConsumptionHardwareStore,
			UpgradeType.MarketConsumptionBookstore,
			UpgradeType.SellValueYellowCoin,
			UpgradeType.SellValueRedCoin,
			UpgradeType.SellValueBlueCoin,
			UpgradeType.SellValuePurpleCoin,
			UpgradeType.SellSpeedYellowCoin,
			UpgradeType.SellSpeedRedCoin,
			UpgradeType.SellSpeedBlueCoin,
			UpgradeType.SellSpeedPurpleCoin,
			UpgradeType.SellSpeedOmniCoin,
			UpgradeType.Supermarket,
			UpgradeType.YellowCoinXP,
			UpgradeType.RedCoinXP,
			UpgradeType.BlueCoinXP,
			UpgradeType.PurpleCoinXP,
			UpgradeType.OmniCoinXP,
			UpgradeType.WarehouseCapacity,
			UpgradeType.EtherStorageCapacity,
			UpgradeType.ManaBatteryCapacity,
			UpgradeType.LibraryCapacity,
			UpgradeType.BatteryCapacity,
			UpgradeType.ClothingStoreCapacity,
			UpgradeType.CropSiloCapacity,
			UpgradeType.OreSiloCapacity,
			UpgradeType.FurnaceStorageCapacity,
			UpgradeType.SteamBoilerStorageCapacity,
			UpgradeType.PantryCapacity,
			UpgradeType.TreasuryCapacity,
			UpgradeType.StockpileCapacity,
			UpgradeType.BarrelCapacity,
			UpgradeType.CrystalariumCapacity,
			UpgradeType.ReservoirCapacity,
			UpgradeType.TradingPostStorageCapacity,
			UpgradeType.HardwareStoreCapacity,
			UpgradeType.BookstoreCapacity,
			UpgradeType.FireShrineSpeed,
			UpgradeType.WaterShrineSpeed,
			UpgradeType.EarthShrineSpeed,
			UpgradeType.AirShrineSpeed,
			UpgradeType.WellEffectiveness,
			UpgradeType.AqueductEffectiveness,
			UpgradeType.WaterWheelEffectiveness,
			UpgradeType.SolarPanelEffectiveness,
			UpgradeType.TempleEffectivenessMana,
			UpgradeType.TempleEffectivenessFire,
			UpgradeType.TempleEffectivenessWater,
			UpgradeType.TempleEffectivenessEarth,
			UpgradeType.TempleEffectivenessAir,
			UpgradeType.PowerLineSpeed,
			UpgradeType.SteamPipeSpeed,
			UpgradeType.MagmaPipeSpeed,
			UpgradeType.ManaPipeSpeed,
			UpgradeType.OmniPipeSpeed,
			UpgradeType.OmnistoneStorageCapacity,
			UpgradeType.OmniSpeedFarm,
			UpgradeType.OmniSpeedForester,
			UpgradeType.OmniSpeedWell,
			UpgradeType.OmniSpeedQuarry,
			UpgradeType.OmniSpeedMine,
			UpgradeType.OmniSpeedGemMine,
			UpgradeType.OmniSpeedFishery,
			UpgradeType.OmniSpeedLumberMill,
			UpgradeType.OmniSpeedGrainMill,
			UpgradeType.OmniSpeedWorkshop,
			UpgradeType.OmniSpeedTailor,
			UpgradeType.OmniSpeedStoneMason,
			UpgradeType.OmniSpeedPasture,
			UpgradeType.OmniSpeedForge,
			UpgradeType.OmniSpeedBakery,
			UpgradeType.OmniSpeedStudy,
			UpgradeType.OmniSpeedTechLab,
			UpgradeType.OmniSpeedMagicLab,
			UpgradeType.OmniSpeedGourmetKitchen,
			UpgradeType.OmniSpeedJeweler,
			UpgradeType.OmniSpeedMachineShop,
			UpgradeType.OmniSpeedMedicineHut,
			UpgradeType.OmniSpeedEnchantedForge,
			UpgradeType.OmniSpeedExtractor,
			UpgradeType.OmniSpeedEnchanter,
			UpgradeType.OmniSpeedRefinery,
			UpgradeType.OmniSpeedManaReactor,
			UpgradeType.OmniSpeedOmniTemple,
			UpgradeType.OmniSpeedHarvesterHut,
			UpgradeType.OmniSpeedFishingBoat,
			UpgradeType.OmniSpeedChainsawTank,
			UpgradeType.OmniSpeedHarvesterDrill,
			UpgradeType.OmniSpeedCropHarvester,
			UpgradeType.OmniSpeedAqueduct,
			UpgradeType.OmniSpeedFireShrine,
			UpgradeType.OmniSpeedWaterShrine,
			UpgradeType.OmniSpeedEarthShrine,
			UpgradeType.OmniSpeedAirShrine,
			UpgradeType.OmniSpeedFurnace,
			UpgradeType.OmniSpeedWaterPump,
			UpgradeType.OmniSpeedSteamBoiler,
			UpgradeType.OmniSpeedSteamPowerGenerator,
			UpgradeType.OmniProductivityFarm,
			UpgradeType.OmniProductivityForester,
			UpgradeType.OmniProductivityQuarry,
			UpgradeType.OmniProductivityMine,
			UpgradeType.OmniProductivityGemMine,
			UpgradeType.OmniProductivityFishery,
			UpgradeType.OmniProductivityLumberMill,
			UpgradeType.OmniProductivityGrainMill,
			UpgradeType.OmniProductivityWorkshop,
			UpgradeType.OmniProductivityTailor,
			UpgradeType.OmniProductivityStoneMason,
			UpgradeType.OmniProductivityPasture,
			UpgradeType.OmniProductivityForge,
			UpgradeType.OmniProductivityBakery,
			UpgradeType.OmniProductivityStudy,
			UpgradeType.OmniProductivityTechLab,
			UpgradeType.OmniProductivityMagicLab,
			UpgradeType.OmniProductivityGourmetKitchen,
			UpgradeType.OmniProductivityJeweler,
			UpgradeType.OmniProductivityMachineShop,
			UpgradeType.OmniProductivityMedicineHut,
			UpgradeType.OmniProductivityEnchantedForge,
			UpgradeType.OmniProductivityExtractor,
			UpgradeType.OmniProductivityEnchanter,
			UpgradeType.OmniProductivityRefinery,
			UpgradeType.OmniProductivityManaReactor,
			UpgradeType.OmniProductivityOmniTemple,
			UpgradeType.OmniResearchSpeed,
			UpgradeType.OmniCapacityFoodMarket,
			UpgradeType.OmniCapacityGeneralStore,
			UpgradeType.OmniCapacityHardwareStore,
			UpgradeType.OmniCapacityBookstore,
			UpgradeType.OmniCapacityClothingStore,
			UpgradeType.OmniCapacityGourmetFoods,
			UpgradeType.OmniCapacityApothecary,
			UpgradeType.OmniCapacityJewelryStore,
			UpgradeType.OmniCapacityArcaneStore,
			UpgradeType.OmniSolarPanelEffectiveness
		};
		List<EntityId> list4 = new List<EntityId>();
		foreach (UpgradeType item4 in obj4)
		{
			list4.Add(EntityId.FromUpgrade(item4));
		}
		defaultDisplayCategories[BuildCategoryType.Upgrades] = list4;
		List<ResearchType> obj5 = new List<ResearchType>
		{
			ResearchType.Workshop,
			ResearchType.StoneMason,
			ResearchType.Quarry,
			ResearchType.FoodMill,
			ResearchType.Farming,
			ResearchType.Forestry,
			ResearchType.Hearth,
			ResearchType.Fishery,
			ResearchType.Bakery,
			ResearchType.Well,
			ResearchType.Tailor,
			ResearchType.PearFarming,
			ResearchType.AppleFarming,
			ResearchType.BerryFarming,
			ResearchType.CottonFarming,
			ResearchType.HerbFarming,
			ResearchType.PotatoFarming,
			ResearchType.CarrotFarming,
			ResearchType.TomatoFarming,
			ResearchType.SugarFarming,
			ResearchType.CactusFarming,
			ResearchType.DragonfruitFarming,
			ResearchType.Pasture,
			ResearchType.GeneralLab,
			ResearchType.Forge,
			ResearchType.Furnace,
			ResearchType.Mining,
			ResearchType.Glassmaking,
			ResearchType.FishingNet,
			ResearchType.GourmetKitchen,
			ResearchType.MedicineBasic,
			ResearchType.MedicineIntermediate,
			ResearchType.MedicineAdvanced,
			ResearchType.Jewelry,
			ResearchType.CoalMining,
			ResearchType.CopperMining,
			ResearchType.Chute,
			ResearchType.Aqueduct,
			ResearchType.Advertising,
			ResearchType.TechLab,
			ResearchType.WaterPower,
			ResearchType.ClothConveyorBelt,
			ResearchType.GemMine,
			ResearchType.GemJewelry,
			ResearchType.Economics,
			ResearchType.Machinery,
			ResearchType.WaterPump,
			ResearchType.MetalRailway,
			ResearchType.Minecart,
			ResearchType.CropHarvester,
			ResearchType.Tractor,
			ResearchType.CashRegisters,
			ResearchType.IndustryTomeIntermediate,
			ResearchType.SteamBoiler,
			ResearchType.SteamPowerGenerator,
			ResearchType.SilverMining,
			ResearchType.GoldMining,
			ResearchType.RubyMining,
			ResearchType.SapphireMining,
			ResearchType.AmethystMining,
			ResearchType.TopazMining,
			ResearchType.ManaMining,
			ResearchType.MetalConveyorBelt,
			ResearchType.Steel,
			ResearchType.SolarPower,
			ResearchType.SteamTrainEngine,
			ResearchType.RailDepot,
			ResearchType.HarvesterDrill,
			ResearchType.ChainsawTank,
			ResearchType.ImprovedFurnace,
			ResearchType.FuelEfficiency,
			ResearchType.IndustryTomeAdvanced,
			ResearchType.Factory,
			ResearchType.Packager,
			ResearchType.Foundry,
			ResearchType.MagmaPipe,
			ResearchType.MagicForge,
			ResearchType.MagicLab,
			ResearchType.MagicFishingNet,
			ResearchType.FloatingIsland,
			ResearchType.ManaTransmitter,
			ResearchType.Enchanting,
			ResearchType.MagicTomeIntermediate,
			ResearchType.FirePurification,
			ResearchType.WaterPurification,
			ResearchType.EarthPurification,
			ResearchType.AirPurification,
			ResearchType.PurifiedFirePower,
			ResearchType.PurifiedWaterPower,
			ResearchType.PurifiedEarthPower,
			ResearchType.PurifiedAirPower,
			ResearchType.MagicClothing,
			ResearchType.MagicJewelry,
			ResearchType.MagicTech,
			ResearchType.MagicMedicine,
			ResearchType.ManaPipe,
			ResearchType.MagicRail,
			ResearchType.MagicConveyorBelt,
			ResearchType.MagicBoat,
			ResearchType.Airship,
			ResearchType.ManaPowerHarvesterDrills,
			ResearchType.ManaPowerChainsawTanks,
			ResearchType.ManaPowerCropHarvesters,
			ResearchType.ManaPowerTractors,
			ResearchType.ManaRefinery,
			ResearchType.MagicTomeAdvanced,
			ResearchType.FireShrine,
			ResearchType.WaterShrine,
			ResearchType.EarthShrine,
			ResearchType.AirShrine,
			ResearchType.FireEther,
			ResearchType.WaterEther,
			ResearchType.EarthEther,
			ResearchType.AirEther,
			ResearchType.BuildManaTemple,
			ResearchType.BuildFireTemple,
			ResearchType.BuildWaterTemple,
			ResearchType.BuildEarthTemple,
			ResearchType.BuildAirTemple,
			ResearchType.ManaReactor,
			ResearchType.OmniPipe,
			ResearchType.BuildOmniTemple,
			ResearchType.GrainProcessingSpeed,
			ResearchType.StoneProcessingSpeed,
			ResearchType.WoodProcessingSpeed,
			ResearchType.MetalProcessingSpeed,
			ResearchType.EtherBonusManaPower,
			ResearchType.EtherBonusFirePower,
			ResearchType.EtherBonusWaterPower,
			ResearchType.EtherBonusEarthPower,
			ResearchType.EtherBonusAirPower,
			ResearchType.MarketCostUpgrades,
			ResearchType.OmnistoneUpgrades,
			ResearchType.Reservoir,
			ResearchType.Barrel,
			ResearchType.Library,
			ResearchType.Pantry,
			ResearchType.CropSilo,
			ResearchType.OreSilo,
			ResearchType.Warehouse,
			ResearchType.Treasury,
			ResearchType.Battery,
			ResearchType.Crystalarium,
			ResearchType.ManaBattery,
			ResearchType.EtherStorage,
			ResearchType.OmnistoneStorage,
			ResearchType.InfiniteNaturalResourceCapacity,
			ResearchType.InfiniteCultivationSpeed,
			ResearchType.InfiniteOmnistoneValue,
			ResearchType.InfiniteResourceRegeneration,
			ResearchType.InfiniteCraftingSpeed,
			ResearchType.InfiniteKnowledgeSpeed,
			ResearchType.InfiniteSkillGainSpeed,
			ResearchType.InfiniteProspectingSpeed,
			ResearchType.InfiniteManaReactorProductivity,
			ResearchType.InfiniteGoodsConsumption,
			ResearchType.InfiniteMarketSellSpeed,
			ResearchType.InfiniteOmniTempleProductivity
		};
		List<EntityId> list5 = new List<EntityId>();
		foreach (ResearchType item5 in obj5)
		{
			if (IsResearchEnabledDefault(item5))
			{
				list5.Add(EntityId.FromResearch(item5));
			}
		}
		defaultDisplayCategories[BuildCategoryType.Research] = list5;
		List<RecipeType> list6 = new List<RecipeType>
		{
			RecipeType.MakePlank,
			RecipeType.MakeRefinedPlank,
			RecipeType.MakeStoneBrick,
			RecipeType.MakeRefinedStoneBrick,
			RecipeType.MakeQuartzFromStone,
			RecipeType.GrindFlour,
			RecipeType.GrindAnimalFeed,
			RecipeType.RefineSugar,
			RecipeType.MakeWoodWheel,
			RecipeType.MakeFishingNet,
			RecipeType.MakeMagicFishingNet,
			RecipeType.MakeWoodAxe,
			RecipeType.MakeShovel,
			RecipeType.MakePickaxe,
			RecipeType.MakeReinforcedPlank,
			RecipeType.FarmEgg,
			RecipeType.FarmChicken,
			RecipeType.FarmWool,
			RecipeType.FarmLeather,
			RecipeType.FarmFertilizer,
			RecipeType.MakeRawBeef,
			RecipeType.MakeMilk,
			RecipeType.MakeFishBait,
			RecipeType.MakePaper,
			RecipeType.MakeBook,
			RecipeType.BurnWood,
			RecipeType.BurnCoal,
			RecipeType.MakeIronWheel,
			RecipeType.MakeIronIngot,
			RecipeType.MakeNails,
			RecipeType.MakeCopperIngot,
			RecipeType.MakeGlass,
			RecipeType.MakeGoldIngot,
			RecipeType.SmeltSilverIngot,
			RecipeType.MakeGear,
			RecipeType.MakeCopperWire,
			RecipeType.MakeSteel,
			RecipeType.MakeConveyorBeltCloth,
			RecipeType.MakeConveyorBelt,
			RecipeType.MakeMagicConveyorBelt,
			RecipeType.MakeRailTile,
			RecipeType.MakeRailTileMagic,
			RecipeType.MakeSteamPipe,
			RecipeType.MakeMagmaPipe,
			RecipeType.MakeCottonCloth,
			RecipeType.MakeWoolCloth,
			RecipeType.MakeShirt,
			RecipeType.MakeHat,
			RecipeType.MakeShoe,
			RecipeType.MakeBoots,
			RecipeType.MakePants,
			RecipeType.MakeWarmCoat,
			RecipeType.MakeCloak,
			RecipeType.MakePoultice,
			RecipeType.MakeFishOil,
			RecipeType.MakeOintment,
			RecipeType.MakeRemedy,
			RecipeType.MakeAntidote,
			RecipeType.MakeMedicalWrap,
			RecipeType.BakeBread,
			RecipeType.MakeAppleJuice,
			RecipeType.MakePearJuice,
			RecipeType.MakeBerryJuice,
			RecipeType.MakeDragonPunch,
			RecipeType.MakeAppleJam,
			RecipeType.MakePearJam,
			RecipeType.MakeBerryJam,
			RecipeType.MakeCactusJam,
			RecipeType.MakeCookedBeef,
			RecipeType.MakeCookedFish,
			RecipeType.MakeCookedChicken,
			RecipeType.MakeButter,
			RecipeType.MakeCheese,
			RecipeType.MakeCake,
			RecipeType.MakeBerryCake,
			RecipeType.MakeSandwich,
			RecipeType.MakeApplePie,
			RecipeType.MakeMeatStew,
			RecipeType.MakeFishStew,
			RecipeType.MakeVeggieStew,
			RecipeType.MakePolishedStone,
			RecipeType.MakeCopperRing,
			RecipeType.MakeGoldRing,
			RecipeType.MakeSilverRing,
			RecipeType.MakeSilverChain,
			RecipeType.MakeGoldCrown,
			RecipeType.MakePolishedStoneRing,
			RecipeType.MakeRubyRing,
			RecipeType.MakeSapphireRing,
			RecipeType.MakeAmethystNecklace,
			RecipeType.MakeTopazCrown,
			RecipeType.SmeltPurifiedMana,
			RecipeType.SmeltPurifiedFire,
			RecipeType.SmeltPurifiedWater,
			RecipeType.SmeltPurifiedEarth,
			RecipeType.SmeltPurifiedAir,
			RecipeType.PurifiedManaPower,
			RecipeType.PurifiedFirePower,
			RecipeType.PurifiedWaterPower,
			RecipeType.PurifiedEarthPower,
			RecipeType.PurifiedAirPower,
			RecipeType.MakeMagicStoneBrick,
			RecipeType.MakeMagicPlank,
			RecipeType.MakeMagicBoatComponent,
			RecipeType.MakeAirshipComponent,
			RecipeType.MakeManaPipe,
			RecipeType.MakeOmniPipe,
			RecipeType.MakeMagicPotion,
			RecipeType.MakeAttackPotion,
			RecipeType.MakeSpeedPotion,
			RecipeType.MakeHealthPotion,
			RecipeType.MakeStealthPotion,
			RecipeType.MakeMagicRing,
			RecipeType.MakeFireRing,
			RecipeType.MakeWaterRing,
			RecipeType.MakeEarthNecklace,
			RecipeType.MakeAirCrown,
			RecipeType.MakeEnchantedBook,
			RecipeType.MakeEnchantedBookRed,
			RecipeType.MakeEnchantedBookYellow,
			RecipeType.MakeEnchantedBookBlue,
			RecipeType.MakeEnchantedBookPurple,
			RecipeType.MakeMagicPants,
			RecipeType.MakeMagicBoots,
			RecipeType.MakeMagicHat,
			RecipeType.MakeMagicShirt,
			RecipeType.MakeMagicCloak,
			RecipeType.MakeEther,
			RecipeType.MakeFireEther,
			RecipeType.MakeWaterEther,
			RecipeType.MakeEarthEther,
			RecipeType.MakeAirEther,
			RecipeType.MakeOmniStone,
			RecipeType.OmniTemple1,
			RecipeType.OmniTemple2,
			RecipeType.OmniTemple3,
			RecipeType.OmniTemple4,
			RecipeType.OmniTemple5,
			RecipeType.OmniTemple6,
			RecipeType.OmniTemple7,
			RecipeType.OmniTemple8,
			RecipeType.OmniTemple9,
			RecipeType.MakeTomeIndustry1,
			RecipeType.MakeTomeIndustry2,
			RecipeType.MakeTomeIndustry3,
			RecipeType.MakeTomeMagic1,
			RecipeType.MakeTomeMagic2,
			RecipeType.MakeTomeMagic3,
			RecipeType.GeneralResearchFromPaper,
			RecipeType.GeneralResearchFromBook,
			RecipeType.GeneralResearchFromEnchantedBook,
			RecipeType.GenerateShrineWater,
			RecipeType.GenerateShrineFire,
			RecipeType.GenerateShrinePower,
			RecipeType.GenerateShrineSteam,
			RecipeType.GenerateSteam,
			RecipeType.WaterWheelPower,
			RecipeType.SteamPower,
			RecipeType.SolarPanelPower,
			RecipeType.PumpWater
		};
		List<EntityId> list7 = new List<EntityId>();
		foreach (RecipeType item6 in list6)
		{
			if (defaultRecipeDefs.TryGetValue(item6, out var value) && value.enabled)
			{
				list7.Add(EntityId.FromRecipe(item6));
			}
		}
		defaultDisplayCategories[BuildCategoryType.Recipe] = list7;
		List<EntityId> list8 = new List<EntityId>();
		List<ItemType> list9 = new List<ItemType>
		{
			ItemType.Wood,
			ItemType.Grain,
			ItemType.Sugar,
			ItemType.Apple,
			ItemType.Berries,
			ItemType.Carrot,
			ItemType.Cotton,
			ItemType.Tomato,
			ItemType.Pear,
			ItemType.Potato,
			ItemType.Herb,
			ItemType.CactusFruit,
			ItemType.DragonFruit,
			ItemType.Water,
			ItemType.Magma,
			ItemType.Stone,
			ItemType.Coal,
			ItemType.IronOre,
			ItemType.CopperOre,
			ItemType.SilverOre,
			ItemType.GoldOre,
			ItemType.Plank,
			ItemType.RefinedPlank,
			ItemType.ReinforcedPlank,
			ItemType.MagicPlank,
			ItemType.StoneSlab,
			ItemType.RefinedStoneBrick,
			ItemType.MagicStoneBrick,
			ItemType.IronIngot,
			ItemType.CopperIngot,
			ItemType.SilverIngot,
			ItemType.GoldIngot,
			ItemType.Fire,
			ItemType.Steam,
			ItemType.Power,
			ItemType.Flour,
			ItemType.Bread,
			ItemType.RefinedSugar,
			ItemType.FruitJuice,
			ItemType.PearJuice,
			ItemType.BerryJuice,
			ItemType.DragonPunch,
			ItemType.Jam,
			ItemType.PearJam,
			ItemType.BerryJam,
			ItemType.CactusJam,
			ItemType.Fertilizer,
			ItemType.AnimalFeed,
			ItemType.FishFood,
			ItemType.FishingNet,
			ItemType.MagicFishingNet,
			ItemType.Egg,
			ItemType.Milk,
			ItemType.CookedChicken,
			ItemType.RawChicken,
			ItemType.RawBeef,
			ItemType.CookedBeef,
			ItemType.Leather,
			ItemType.Fish,
			ItemType.FishCooked,
			ItemType.Butter,
			ItemType.Cheese,
			ItemType.Cake,
			ItemType.BerryCake,
			ItemType.ApplePie,
			ItemType.FishStew,
			ItemType.MeatStew,
			ItemType.VeggieStew,
			ItemType.Sandwich,
			ItemType.Wool,
			ItemType.CottonCloth,
			ItemType.WoolCloth,
			ItemType.Outfit,
			ItemType.Pants,
			ItemType.Cloak,
			ItemType.MagicCloak,
			ItemType.Shoe,
			ItemType.WarmCoat,
			ItemType.MagicShirt,
			ItemType.ConveyorBeltWooden,
			ItemType.MetalConveyorBelt,
			ItemType.ClothConveyorBelt,
			ItemType.MagicConveyorBelt,
			ItemType.RailTileWood,
			ItemType.RailTile,
			ItemType.RailTilePowered,
			ItemType.RailTileMagic,
			ItemType.SteamPipe,
			ItemType.MagmaPipe,
			ItemType.ManaPipe,
			ItemType.OmniPipe,
			ItemType.WoodWheel,
			ItemType.IronWheel,
			ItemType.Gear,
			ItemType.Nails,
			ItemType.StoneAxe,
			ItemType.Shovel,
			ItemType.WoodAxe,
			ItemType.Pickaxe,
			ItemType.Bandage,
			ItemType.Poultice,
			ItemType.Ointment,
			ItemType.MedicalWrap,
			ItemType.ProteinShake,
			ItemType.FishOil,
			ItemType.Remedy,
			ItemType.HealthPotion,
			ItemType.Antidote,
			ItemType.StealthPotion,
			ItemType.Paper,
			ItemType.Book,
			ItemType.ResearchTomeGeneral,
			ItemType.EnchantedBook,
			ItemType.ResearchTomeIndustry1,
			ItemType.ResearchTomeIndustry2,
			ItemType.ResearchTomeIndustry3,
			ItemType.ResearchTomeMagic1,
			ItemType.ResearchTomeMagic2,
			ItemType.ResearchTomeMagic3,
			ItemType.EnchantedBookRed,
			ItemType.EnchantedBookYellow,
			ItemType.EnchantedBookBlue,
			ItemType.EnchantedBookPurple,
			ItemType.PolishedStone,
			ItemType.CopperRing,
			ItemType.SilverRing,
			ItemType.GoldRing,
			ItemType.SilverChain,
			ItemType.GoldCrown,
			ItemType.PolishedStoneRing,
			ItemType.RubyRing,
			ItemType.SapphireRing,
			ItemType.AmethystNecklace,
			ItemType.TopazCrown,
			ItemType.MagicRing,
			ItemType.EnchantedAirCrown,
			ItemType.EnchantedFireRing,
			ItemType.EnchantedWaterRing,
			ItemType.EnchantedEarthNecklace,
			ItemType.Mana,
			ItemType.RedRuby,
			ItemType.YellowTopaz,
			ItemType.BlueSapphire,
			ItemType.PurpleAmethyst,
			ItemType.PurifiedMana,
			ItemType.PurifiedFire,
			ItemType.PurifiedWater,
			ItemType.PurifiedEarth,
			ItemType.PurifiedAir,
			ItemType.DepletedMana,
			ItemType.DepletedFire,
			ItemType.DepletedWater,
			ItemType.DepletedEarth,
			ItemType.DepletedAir,
			ItemType.ManaPower,
			ItemType.UtilityElementalFirePower,
			ItemType.UtilityElementalWaterPower,
			ItemType.UtilityElementalEarthPower,
			ItemType.UtilityElementalAirPower,
			ItemType.ManaEther,
			ItemType.FireEther,
			ItemType.WaterEther,
			ItemType.EarthEther,
			ItemType.AirEther,
			ItemType.Omnistone
		};
		foreach (KeyValuePair<ItemType, ItemDef> defaultItemDef in defaultItemDefs)
		{
			if (Item.IsDefaultPhysicalItem(defaultItemDef.Key) && !list9.Contains(defaultItemDef.Key))
			{
				list9.Add(defaultItemDef.Key);
			}
		}
		foreach (ItemType item7 in list9)
		{
			if (IsItemEnabledDefault(item7))
			{
				list8.Add(new EntityId((int)item7, EntityType.Item));
			}
		}
		defaultDisplayCategories[BuildCategoryType.Item] = list8;
		List<EntityId> list10 = new List<EntityId>();
		list10.Add(EntityId.FromNaturalResource(ItemType.Wood));
		list10.Add(EntityId.FromNaturalResource(ItemType.Grain));
		list10.Add(EntityId.FromNaturalResource(ItemType.Herb));
		list10.Add(EntityId.FromNaturalResource(ItemType.Sugar));
		list10.Add(EntityId.FromNaturalResource(ItemType.Apple));
		list10.Add(EntityId.FromNaturalResource(ItemType.Berries));
		list10.Add(EntityId.FromNaturalResource(ItemType.Carrot));
		list10.Add(EntityId.FromNaturalResource(ItemType.Potato));
		list10.Add(EntityId.FromNaturalResource(ItemType.Pear));
		list10.Add(EntityId.FromNaturalResource(ItemType.Tomato));
		list10.Add(EntityId.FromNaturalResource(ItemType.Cotton));
		list10.Add(EntityId.FromNaturalResource(ItemType.DragonFruit));
		list10.Add(EntityId.FromNaturalResource(ItemType.CactusFruit));
		list10.Add(EntityId.FromNaturalResource(ItemType.Fish));
		list10.Add(EntityId.FromNaturalResource(ItemType.Stone));
		list10.Add(EntityId.FromNaturalResource(ItemType.IronOre));
		list10.Add(EntityId.FromNaturalResource(ItemType.Coal));
		list10.Add(EntityId.FromNaturalResource(ItemType.CopperOre));
		list10.Add(EntityId.FromNaturalResource(ItemType.Water));
		list10.Add(EntityId.FromNaturalResource(ItemType.SilverOre));
		list10.Add(EntityId.FromNaturalResource(ItemType.GoldOre));
		list10.Add(EntityId.FromNaturalResource(ItemType.RedRuby));
		list10.Add(EntityId.FromNaturalResource(ItemType.YellowTopaz));
		list10.Add(EntityId.FromNaturalResource(ItemType.BlueSapphire));
		list10.Add(EntityId.FromNaturalResource(ItemType.PurpleAmethyst));
		list10.Add(EntityId.FromNaturalResource(ItemType.Mana));
		defaultDisplayCategories[BuildCategoryType.Resources] = list10;
	}
}
