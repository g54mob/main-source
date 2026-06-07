using System;
using System.Collections.Generic;
using UnityEngine;

public class Crafting
{
	public static Dictionary<HarvestRecipeType, HarvestDef> harvestRecipeCache;

	public static Dictionary<NaturalResource, NaturalResourceDef> naturalResourceCache;

	public static Dictionary<RecipeType, Recipe> recipeCache;

	public static Dictionary<NaturalResource, FarmingRecipe> farmingRecipeCache;

	public static Dictionary<NaturalResource, FarmingRecipe> prospectingRecipeCache;

	public static Dictionary<ResearchType, Research> researchCache;

	public static Dictionary<QuestType, QuestDef> questCache;

	private static List<QuestType> disabledQuests;

	public static Dictionary<UpgradeType, UpgradeDef> upgradeCache;

	public static List<UpgradeType> storageUpgrades;

	public static Dictionary<ItemType, ItemDef> cachedItemDefs;

	public static Dictionary<RecipeType, List<ItemList>> upgradeLevels;

	public static Dictionary<BiomeType, Biome> biomeCache;

	public static Dictionary<ItemType, List<BuildingType>> derivedItemBuildingSources;

	public static Dictionary<ItemType, List<EntityId>> derivedItemConsumption;

	public static Dictionary<EntityId, List<BuildingType>> cachedStorageByEntity;

	public static Dictionary<ItemType, List<RecipeType>> derivedItemRecipeSources;

	public static Dictionary<BuildingType, List<RecipeType>> cachedBuildingRecipes;

	public static Dictionary<BuildingType, List<ItemType>> cachedBuildingItemsProduced;

	public static Dictionary<BuildingType, List<EntityId>> cachedStorageByBuilding;

	public static Dictionary<BuildingType, List<NaturalResource>> cachedBuildingResources;

	public static Dictionary<BuildingType, BuildingDef> buildingCache;

	public static List<BuildingType> marketTypes;

	public static List<PerkType> townPerks = new List<PerkType>();

	public static List<PerkType> globalPerks = new List<PerkType>();

	public static Dictionary<PerkType, Perk> perkDefCache = new Dictionary<PerkType, Perk>(new PerkEqualityComparer());

	public static List<BuildingType> harvestingBuildings;

	public static List<BuildingType> cultivationBuildings;

	public static List<ItemType> upgradeCoinTypes = new List<ItemType>();

	public static List<BuildingType> researchTypes;

	public static List<BuildingType> buildingsThatRequireCurrency;

	public static List<Specialty> tradingSpecialties;

	public static Dictionary<ItemType, float> itemXpValues;

	public static Dictionary<RecipeType, float> recipeXpValues;

	public static List<ItemType> physicalItemTypes;

	public static Dictionary<ItemType, HouseSellData> houseSellData;

	public static Dictionary<ItemType, SatisfactionCategory> satisfactionCategoryData;

	public static List<ItemType> workerItemTypes;

	public static List<ItemType> satisfactionCategories;

	public static List<ItemType> marketSellCategories;

	public static HashSet<ItemType> naturalResources;

	public static HashSet<ItemType> naturalResourceFilters;

	public static Dictionary<ItemType, HashSet<ItemType>> itemFilterMap;

	public static Dictionary<ItemType, HashSet<ItemType>> itemFilterMapPhysical;

	public static Dictionary<ItemType, HashSet<ItemType>> itemFilterMapRecursive;

	public static bool AreCostsInitialized;

	public static float researchSpeedMultiplier;

	public static float researchCostMultiplier;

	public static float happinessDecayMultiplier;

	public static float consumptionSpeedMultiplier;

	public static float globalProductionMultiplier;

	public static int maxHouseLevel;

	public static int maxBaseLevel;

	public static int maxTechLevel;

	public static int maxPopulationLevel;

	private static bool autoRemoveObsolete = false;

	public static void Init()
	{
		naturalResourceCache = new Dictionary<NaturalResource, NaturalResourceDef>(new NaturalResourceEqualityComparer());
		harvestRecipeCache = new Dictionary<HarvestRecipeType, HarvestDef>(new HarvestRecipeEqualityComparer());
		recipeCache = new Dictionary<RecipeType, Recipe>(new RecipeEqualityComparer());
		farmingRecipeCache = new Dictionary<NaturalResource, FarmingRecipe>(new NaturalResourceEqualityComparer());
		prospectingRecipeCache = new Dictionary<NaturalResource, FarmingRecipe>(new NaturalResourceEqualityComparer());
		researchCache = new Dictionary<ResearchType, Research>(new ResearchEqualityComparer());
		questCache = new Dictionary<QuestType, QuestDef>(new QuestEqualityComparer());
		disabledQuests = new List<QuestType>();
		upgradeCache = new Dictionary<UpgradeType, UpgradeDef>(new UpgradeEqualityComparer());
		storageUpgrades = new List<UpgradeType>();
		cachedBuildingRecipes = new Dictionary<BuildingType, List<RecipeType>>(new BuildingEqualityComparer());
		cachedBuildingItemsProduced = new Dictionary<BuildingType, List<ItemType>>(new BuildingEqualityComparer());
		cachedBuildingResources = new Dictionary<BuildingType, List<NaturalResource>>(new BuildingEqualityComparer());
		buildingCache = new Dictionary<BuildingType, BuildingDef>(new BuildingEqualityComparer());
		marketTypes = new List<BuildingType>();
		harvestingBuildings = new List<BuildingType>();
		cultivationBuildings = new List<BuildingType>();
		researchTypes = new List<BuildingType>();
		upgradeLevels = new Dictionary<RecipeType, List<ItemList>>();
		buildingsThatRequireCurrency = new List<BuildingType>();
		biomeCache = new Dictionary<BiomeType, Biome>(new BiomeEqualityComparer());
		cachedItemDefs = new Dictionary<ItemType, ItemDef>(GameUtility.SharedEqualityComparer);
		physicalItemTypes = new List<ItemType>();
		derivedItemBuildingSources = new Dictionary<ItemType, List<BuildingType>>(GameUtility.SharedEqualityComparer);
		derivedItemConsumption = new Dictionary<ItemType, List<EntityId>>(GameUtility.SharedEqualityComparer);
		cachedStorageByEntity = new Dictionary<EntityId, List<BuildingType>>();
		cachedStorageByBuilding = new Dictionary<BuildingType, List<EntityId>>(new BuildingEqualityComparer());
		derivedItemRecipeSources = new Dictionary<ItemType, List<RecipeType>>(GameUtility.SharedEqualityComparer);
		workerItemTypes = new List<ItemType>();
		itemFilterMap = new Dictionary<ItemType, HashSet<ItemType>>(GameUtility.SharedEqualityComparer);
		itemFilterMapPhysical = new Dictionary<ItemType, HashSet<ItemType>>(GameUtility.SharedEqualityComparer);
		itemFilterMapRecursive = new Dictionary<ItemType, HashSet<ItemType>>(GameUtility.SharedEqualityComparer);
		naturalResources = GameUtility.ItemHashSet();
		naturalResourceFilters = GameUtility.ItemHashSet();
		tradingSpecialties = new List<Specialty>();
		houseSellData = new Dictionary<ItemType, HouseSellData>(GameUtility.SharedEqualityComparer);
		satisfactionCategoryData = new Dictionary<ItemType, SatisfactionCategory>(GameUtility.SharedEqualityComparer);
		satisfactionCategories = new List<ItemType>();
		marketSellCategories = new List<ItemType>();
	}

	public static void LoadAllGameData()
	{
		ApplyGameModifiers();
		LoadDerivedData();
		DeriveRequirements();
		DeriveRewards();
	}

	public static void LoadDefaults()
	{
		researchSpeedMultiplier = 1f;
		researchCostMultiplier = 1f;
		happinessDecayMultiplier = 1f;
		consumptionSpeedMultiplier = 1f;
		globalProductionMultiplier = 1f;
		upgradeCoinTypes.Clear();
		upgradeCoinTypes.Add(ItemType.YellowCoin);
		upgradeCoinTypes.Add(ItemType.RedCoin);
		upgradeCoinTypes.Add(ItemType.BlueCoin);
		upgradeCoinTypes.Add(ItemType.PurpleCoin);
		upgradeCoinTypes.Add(ItemType.OmniCoin);
		globalPerks.Clear();
		globalPerks.Add(PerkType.ClickPower);
		globalPerks.Add(PerkType.IdleGain);
		globalPerks.Add(PerkType.MoreStartingLand);
		globalPerks.Add(PerkType.GlobalXPBoost);
		globalPerks.Add(PerkType.HousingCapacity);
		globalPerks.Add(PerkType.GlobalMarketSpeed);
		globalPerks.Add(PerkType.GoodsConsumption);
		globalPerks.Add(PerkType.SkillGainSpeed);
		globalPerks.Add(PerkType.ResourceRegen);
		globalPerks.Add(PerkType.NaturalResourceCapacity);
		globalPerks.Add(PerkType.GlobalResearchSpeed);
		globalPerks.Add(PerkType.ResearchEfficiency);
		globalPerks.Add(PerkType.GlobalTradingSpeed);
		globalPerks.Add(PerkType.GlobalTradingCapacity);
		globalPerks.Add(PerkType.Specialization);
		globalPerks.Add(PerkType.SpecializationCount);
		globalPerks.Add(PerkType.SpecializationValue);
		globalPerks.Add(PerkType.SpecializationDemand);
		globalPerks.Add(PerkType.ConstructionEfficiency);
		perkDefCache.Clear();
		foreach (PerkType globalPerk in globalPerks)
		{
			perkDefCache[globalPerk] = new Perk(globalPerk);
		}
		List<PerkType> obj = new List<PerkType>
		{
			PerkType.HarvestingSpeed,
			PerkType.CraftingSpeed,
			PerkType.CultivationSpeed,
			PerkType.ProspectingSpeed,
			PerkType.KnowledgeSpeed,
			PerkType.ResearchSpeed,
			PerkType.ConstructionSpeed,
			PerkType.ConstructionCost,
			PerkType.MarketValue,
			PerkType.LandCapacity,
			PerkType.TownTradingSpeed,
			PerkType.GourmetFoodsStoreSpeed,
			PerkType.BookStoreSpeed,
			PerkType.ConstructionStoreSpeed,
			PerkType.HardwareStoreSpeed,
			PerkType.JewelryStoreSpeed,
			PerkType.ClothingStoreSpeed,
			PerkType.MedicineStoreSpeed,
			PerkType.MagicStoreSpeed,
			PerkType.GourmetFoodsDemand,
			PerkType.BooksDemand,
			PerkType.ConstructionDemand,
			PerkType.HardwareDemand,
			PerkType.JewelryDemand,
			PerkType.ClothingDemand,
			PerkType.MedicineDemand,
			PerkType.MagicDemand,
			PerkType.TownOmnistoneDemand,
			PerkType.StorageBoost,
			PerkType.ExtraQuestCoins,
			PerkType.RemoveBiomeNegatives,
			PerkType.TownXPBoost
		};
		townPerks.Clear();
		foreach (PerkType item in obj)
		{
			if (item != PerkType.MinigameXPGainSpeed && item != PerkType.None && !Perk.IsMega(item) && !Perk.IsGlobal(item))
			{
				townPerks.Add(item);
				perkDefCache[item] = new Perk(item);
			}
		}
		storageUpgrades.Clear();
		buildingCache.Clear();
		if (Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Building, out var value))
		{
			foreach (EntityId item2 in value)
			{
				if (item2.TryAsBuilding(out var b) && Data.Instance.defaultBuildingDefs.TryGetValue(b, out var value2) && value2.enabled)
				{
					BuildingDef buildingDef = new BuildingDef(b);
					buildingDef.LoadDefault();
					buildingCache[b] = buildingDef;
					storageUpgrades.AddRange(buildingDef.storageCapacityUpgrades);
				}
			}
		}
		naturalResourceCache.Clear();
		foreach (KeyValuePair<NaturalResource, NaturalResourceDef> defaultNaturalResourceDef in Data.Instance.defaultNaturalResourceDefs)
		{
			if (!defaultNaturalResourceDef.Value.enabled)
			{
				Debug.LogError("resource disabled " + defaultNaturalResourceDef.Key);
				continue;
			}
			NaturalResourceDef naturalResourceDef = new NaturalResourceDef(defaultNaturalResourceDef.Key);
			naturalResourceDef.CopyFrom(defaultNaturalResourceDef.Value);
			naturalResourceDef.LoadRequirements();
			naturalResourceCache[defaultNaturalResourceDef.Key] = naturalResourceDef;
		}
		harvestRecipeCache.Clear();
		if (Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Harvesting, out var value3))
		{
			foreach (EntityId item3 in value3)
			{
				if (item3.TryAsHarvestRecipe(out var i))
				{
					HarvestDef value4 = new HarvestDef(i);
					harvestRecipeCache[i] = value4;
				}
			}
		}
		cachedBuildingResources.Clear();
		foreach (KeyValuePair<NaturalResource, NaturalResourceDef> item4 in naturalResourceCache)
		{
			BuildingType cultivationBuilding = item4.Value.cultivationBuilding;
			if (cultivationBuilding != BuildingType.None)
			{
				if (!cachedBuildingResources.TryGetValue(cultivationBuilding, out var value5))
				{
					value5 = new List<NaturalResource>();
					cachedBuildingResources[cultivationBuilding] = value5;
				}
				value5.Add(item4.Key);
			}
		}
		recipeCache.Clear();
		if (Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Recipe, out var value6))
		{
			foreach (EntityId item5 in value6)
			{
				RecipeType asRecipe = item5.AsRecipe;
				if (Data.Instance.defaultRecipeDefs.TryGetValue(asRecipe, out var value7))
				{
					Recipe copy = Recipe.GetCopy(value7);
					if (copy.enabled)
					{
						recipeCache.Add(asRecipe, copy);
					}
				}
			}
		}
		farmingRecipeCache.Clear();
		foreach (KeyValuePair<NaturalResource, FarmingRecipe> defaultFarmingRecipe in Data.Instance.defaultFarmingRecipes)
		{
			FarmingRecipe copy2 = FarmingRecipe.GetCopy(defaultFarmingRecipe.Value);
			farmingRecipeCache.Add(defaultFarmingRecipe.Key, copy2);
		}
		prospectingRecipeCache.Clear();
		foreach (KeyValuePair<NaturalResource, FarmingRecipe> defaultProspectingRecipe in Data.Instance.defaultProspectingRecipes)
		{
			FarmingRecipe copy3 = FarmingRecipe.GetCopy(defaultProspectingRecipe.Value);
			prospectingRecipeCache.Add(defaultProspectingRecipe.Key, copy3);
		}
		biomeCache.Clear();
		foreach (BiomeType value15 in Enum.GetValues(typeof(BiomeType)))
		{
			if (value15 != BiomeType.None)
			{
				Biome value8 = new Biome(value15);
				biomeCache[value15] = value8;
			}
		}
		researchCache.Clear();
		if (Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Research, out var value9))
		{
			foreach (EntityId item6 in value9)
			{
				Research research = new Research(item6.AsResearch);
				research.LoadDefaultResearch();
				if (research.enabled)
				{
					researchCache[research.type] = research;
				}
			}
		}
		upgradeCache.Clear();
		if (Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Upgrades, out var value10))
		{
			foreach (EntityId item7 in value10)
			{
				UpgradeType asUpgrade = item7.AsUpgrade;
				if (Upgrade.IsEnabled(asUpgrade))
				{
					upgradeCache[asUpgrade] = new UpgradeDef(asUpgrade);
				}
			}
		}
		cachedBuildingRecipes.Clear();
		foreach (KeyValuePair<BuildingType, List<RecipeType>> defaultBuildingRecipe in Data.Instance.defaultBuildingRecipes)
		{
			List<RecipeType> list = new List<RecipeType>();
			foreach (RecipeType item8 in defaultBuildingRecipe.Value)
			{
				if (Data.IsRecipeEnabledDefault(item8))
				{
					list.Add(item8);
					if (recipeCache.TryGetValue(item8, out var value11))
					{
						value11.producingBuildingType = defaultBuildingRecipe.Key;
					}
				}
			}
			cachedBuildingRecipes[defaultBuildingRecipe.Key] = list;
		}
		foreach (KeyValuePair<BuildingType, List<RecipeType>> cachedBuildingRecipe in cachedBuildingRecipes)
		{
			BuildingType key = cachedBuildingRecipe.Key;
			foreach (RecipeType item9 in cachedBuildingRecipe.Value)
			{
				if (!recipeCache.TryGetValue(item9, out var value12))
				{
					continue;
				}
				foreach (KeyValuePair<ItemType, double> item10 in value12.outputs.items)
				{
					if (!cachedBuildingItemsProduced.TryGetValue(key, out var value13))
					{
						value13 = new List<ItemType>();
						cachedBuildingItemsProduced[key] = value13;
						value13.Add(item10.Key);
					}
					else if (!value13.Contains(item10.Key))
					{
						value13.Add(item10.Key);
					}
				}
			}
		}
		LoadDefaultUpgradeRequirements();
		questCache.Clear();
		if (Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Quests, out var value14))
		{
			foreach (EntityId item11 in value14)
			{
				QuestType asQuest = item11.AsQuest;
				QuestDef questDef = new QuestDef(asQuest);
				questDef.LoadDefault();
				if (questDef.isDisabled)
				{
					disabledQuests.Add(asQuest);
				}
				else
				{
					questCache[asQuest] = questDef;
				}
			}
		}
		foreach (QuestCategory value16 in Enum.GetValues(typeof(QuestCategory)))
		{
			if (value16 == QuestCategory.None)
			{
				continue;
			}
			foreach (QuestDef item12 in Quest.DynamicTownQuestsFromCategory(value16))
			{
				questCache[item12.type] = item12;
			}
		}
		cachedItemDefs.Clear();
		foreach (KeyValuePair<ItemType, ItemDef> defaultItemDef in Data.Instance.defaultItemDefs)
		{
			cachedItemDefs[defaultItemDef.Key] = defaultItemDef.Value.DeepCopy();
		}
		houseSellData.Clear();
		foreach (KeyValuePair<ItemType, HouseSellData> houseSellDatum in Data.Instance.houseSellData)
		{
			if (Data.IsItemEnabledDefault(houseSellDatum.Key))
			{
				houseSellData[houseSellDatum.Key] = houseSellDatum.Value.DeepCopy();
			}
		}
		tradingSpecialties.Add(Specialty.UniqueExport);
		tradingSpecialties.Add(Specialty.UniqueImport);
		tradingSpecialties.Add(Specialty.Crops);
		tradingSpecialties.Add(Specialty.Minerals);
		tradingSpecialties.Add(Specialty.Construction);
		tradingSpecialties.Add(Specialty.AnimalProducts);
		tradingSpecialties.Add(Specialty.PlantProducts);
		tradingSpecialties.Add(Specialty.Gourmet);
		tradingSpecialties.Add(Specialty.Clothing);
		tradingSpecialties.Add(Specialty.Jewelry);
		tradingSpecialties.Add(Specialty.Metal);
		tradingSpecialties.Add(Specialty.Knowledge);
		tradingSpecialties.Add(Specialty.Medicine);
		tradingSpecialties.Add(Specialty.Tech);
		tradingSpecialties.Add(Specialty.Magic);
		tradingSpecialties.Add(Specialty.Enchanting);
		tradingSpecialties.Add(Specialty.ElementalCrystals);
		tradingSpecialties.Add(Specialty.ElementalPower);
		maxBaseLevel = 10;
		maxHouseLevel = 10;
		maxTechLevel = 10;
		maxPopulationLevel = Data.MaxPopulationLevel;
		upgradeLevels.Clear();
		AreCostsInitialized = true;
	}

	private static void SetResourceExclusive(NaturalResource t, BiomeType b)
	{
		if (naturalResourceCache.TryGetValue(t, out var value))
		{
			value.requirements.Add(new RequirementId(b));
			value.exclusiveBiome = b;
		}
		EntityId resourceEntity = EntityId.FromNaturalResource(t);
		foreach (Biome value4 in biomeCache.Values)
		{
			value4.entityModifiers.RemoveAll((BiomeModifier x) => x.target.Equals(resourceEntity));
		}
		if (biomeCache.TryGetValue(b, out var value2))
		{
			BiomeModifier item = new BiomeModifier(resourceEntity, BiomeModifierType.UniqueResource, 1f);
			value2.entityModifiers.Add(item);
		}
		if (Data.Instance.resourceResearch.TryGetValue(t, out var value3))
		{
			SetResearchExclusive(value3, b, isExclusion: false);
		}
	}

	private static void SetBuildingImpossible(BuildingType t, BiomeType b)
	{
		if (buildingCache.TryGetValue(t, out var value))
		{
			value.requirements.Add(RequirementId.ExcludeFromBiome(b));
		}
		SetRelatedItemsExclusive(t, b, isExclusion: true);
		if (biomeCache.TryGetValue(b, out var value2))
		{
			EntityId buildingEntity = EntityId.FromBuilding(t);
			value2.entityModifiers.RemoveAll((BiomeModifier x) => x.target.Equals(buildingEntity));
			BiomeModifier item = new BiomeModifier(buildingEntity, BiomeModifierType.Excluded, 1f);
			value2.entityModifiers.Add(item);
		}
	}

	private static void SetRelatedItemsExclusive(BuildingType t, BiomeType b, bool isExclusion)
	{
		switch (t)
		{
		case BuildingType.Jeweler:
			SetResearchExclusive(ResearchType.Jewelry, b, isExclusion);
			SetResearchExclusive(ResearchType.GemJewelry, b, isExclusion);
			break;
		case BuildingType.GourmetKitchen:
			SetResearchExclusive(ResearchType.GourmetKitchen, b, isExclusion);
			break;
		case BuildingType.SolarPanel:
			SetResearchExclusive(ResearchType.SolarPower, b, isExclusion);
			break;
		case BuildingType.WaterWheel:
			SetResearchExclusive(ResearchType.WaterPower, b, isExclusion);
			break;
		case BuildingType.WaterPump:
			SetResearchExclusive(ResearchType.WaterPump, b, isExclusion);
			break;
		case BuildingType.HarvesterDrill:
			SetResearchExclusive(ResearchType.HarvesterDrill, b, isExclusion);
			break;
		case BuildingType.ChainsawTank:
			SetResearchExclusive(ResearchType.ChainsawTank, b, isExclusion);
			break;
		case BuildingType.ManaTransmitter:
			SetResearchExclusive(ResearchType.ManaTransmitter, b, isExclusion);
			SetResearchExclusive(ResearchType.EtherBonusManaPower, b, isExclusion);
			SetResearchExclusive(ResearchType.EtherBonusFirePower, b, isExclusion);
			SetResearchExclusive(ResearchType.EtherBonusWaterPower, b, isExclusion);
			SetResearchExclusive(ResearchType.EtherBonusEarthPower, b, isExclusion);
			SetResearchExclusive(ResearchType.EtherBonusAirPower, b, isExclusion);
			break;
		case BuildingType.Enchanter:
			SetResearchExclusive(ResearchType.Enchanting, b, isExclusion);
			SetResearchExclusive(ResearchType.MagicJewelry, b, isExclusion);
			break;
		case BuildingType.MedicineHut:
			SetResearchExclusive(ResearchType.MedicineBasic, b, isExclusion);
			SetResearchExclusive(ResearchType.MedicineIntermediate, b, isExclusion);
			SetResearchExclusive(ResearchType.MedicineAdvanced, b, isExclusion);
			SetResearchExclusive(ResearchType.MagicMedicine, b, isExclusion);
			break;
		case BuildingType.GemMine:
			SetResearchExclusive(ResearchType.GemMine, b, isExclusion);
			break;
		case BuildingType.Quarry:
			SetResearchExclusive(ResearchType.Quarry, b, isExclusion);
			break;
		case BuildingType.Forester:
			SetResearchExclusive(ResearchType.Forestry, b, isExclusion);
			break;
		case BuildingType.Pasture:
			SetResearchExclusive(ResearchType.Pasture, b, isExclusion);
			break;
		default:
			_ = 2;
			break;
		case BuildingType.Well:
		case BuildingType.GrainMill:
		case BuildingType.Bakery:
		case BuildingType.Forge:
		case BuildingType.StoneMason:
		case BuildingType.Mine:
			break;
		}
		EntityId entityId = EntityId.FromBuilding(t);
		foreach (UpgradeDef value in upgradeCache.Values)
		{
			if (value.linkedEntity.Equals(entityId) || value.popupParentEntity.Contains(entityId))
			{
				if (isExclusion)
				{
					value.AddDisplayReq(RequirementId.ExcludeFromBiome(b));
				}
				else
				{
					value.AddDisplayReq(new RequirementId(b));
				}
			}
		}
	}

	private static void SetRecipeExclusive(RecipeType t, BiomeType b)
	{
		if (recipeCache.TryGetValue(t, out var value))
		{
			value.requirements.Add(new RequirementId(b));
		}
		foreach (Biome value2 in biomeCache.Values)
		{
			EntityId recipeEntity = EntityId.FromRecipe(t);
			value2.entityModifiers.RemoveAll((BiomeModifier x) => x.target.Equals(recipeEntity));
			if (value2.type == b)
			{
				BiomeModifier item = new BiomeModifier(recipeEntity, BiomeModifierType.UniqueRecipe, 1f);
				value2.entityModifiers.Add(item);
			}
		}
	}

	private static void SetResearchExclusive(ResearchType t, BiomeType b, bool isExclusion)
	{
		if (researchCache.TryGetValue(t, out var value))
		{
			if (isExclusion)
			{
				value.AddRequirement(RequirementId.ExcludeFromBiome(b));
			}
			else
			{
				value.AddRequirement(new RequirementId(b));
			}
		}
	}

	private static void SetBuildingExclusive(BuildingType t, BiomeType b)
	{
		if (buildingCache.TryGetValue(t, out var value))
		{
			value.requirements.Add(new RequirementId(b));
		}
		SetRelatedItemsExclusive(t, b, isExclusion: false);
		foreach (Biome value2 in biomeCache.Values)
		{
			EntityId buildingEntity = EntityId.FromBuilding(t);
			value2.entityModifiers.RemoveAll((BiomeModifier x) => x.target.Equals(buildingEntity));
			if (value2.type == b)
			{
				BiomeModifier item = new BiomeModifier(buildingEntity, BiomeModifierType.UniqueBuilding, 1f);
				value2.entityModifiers.Add(item);
			}
		}
	}

	public static void ApplyGameModifiers()
	{
		GameManager instance = GameManager.Instance;
		if (instance.gameModifierBiomes == GameModifier.ExtremeBiomes)
		{
			SetBuildingExclusive(BuildingType.GourmetKitchen, BiomeType.Plains);
			SetResourceExclusive(NaturalResource.CopperOre, BiomeType.Plains);
			SetBuildingImpossible(BuildingType.GemMine, BiomeType.Plains);
			SetBuildingExclusive(BuildingType.WaterWheel, BiomeType.River);
			SetResourceExclusive(NaturalResource.GoldOre, BiomeType.River);
			SetBuildingImpossible(BuildingType.Mine, BiomeType.River);
			SetBuildingExclusive(BuildingType.MedicineHut, BiomeType.Forest);
			SetResourceExclusive(NaturalResource.SilverOre, BiomeType.Forest);
			SetBuildingImpossible(BuildingType.Quarry, BiomeType.Forest);
			biomeCache[BiomeType.Mountains].entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Pasture), BiomeModifierType.RecipeProductivity, 0.5f, isNegative: true));
			SetBuildingExclusive(BuildingType.HarvesterDrill, BiomeType.Mountains);
			SetBuildingImpossible(BuildingType.Forester, BiomeType.Mountains);
			SetBuildingImpossible(BuildingType.Pasture, BiomeType.Mountains);
			SetBuildingExclusive(BuildingType.Jeweler, BiomeType.Jungle);
			SetBuildingExclusive(BuildingType.ChainsawTank, BiomeType.Jungle);
			SetBuildingImpossible(BuildingType.StoneMason, BiomeType.Jungle);
			SetBuildingImpossible(BuildingType.GrainMill, BiomeType.Jungle);
			SetBuildingImpossible(BuildingType.Well, BiomeType.Desert);
			SetBuildingImpossible(BuildingType.WaterPump, BiomeType.Desert);
			SetRecipeExclusive(RecipeType.FarmWool, BiomeType.Snow);
			SetBuildingExclusive(BuildingType.WaterPump, BiomeType.Snow);
			SetBuildingImpossible(BuildingType.Forge, BiomeType.Snow);
			SetBuildingImpossible(BuildingType.Bakery, BiomeType.Snow);
			SetBuildingExclusive(BuildingType.Enchanter, BiomeType.Magic);
			SetBuildingExclusive(BuildingType.ManaTransmitter, BiomeType.Magic);
			SetBuildingImpossible(BuildingType.Forester, BiomeType.Magic);
			SetBuildingImpossible(BuildingType.Farm, BiomeType.Magic);
			foreach (Biome value3 in biomeCache.Values)
			{
				foreach (BiomeModifier entityModifier in value3.entityModifiers)
				{
					if ((entityModifier.effect == BiomeModifierType.BuildingEffectiveness || entityModifier.effect == BiomeModifierType.RecipeProductivity || entityModifier.effect == BiomeModifierType.CultivationProductivity || entityModifier.effect == BiomeModifierType.ProspectingProductivity || entityModifier.effect == BiomeModifierType.ResourceRegen) && entityModifier.baselineMultiplier > 1f)
					{
						entityModifier.baselineMultiplier *= 2f;
					}
				}
			}
		}
		else if (instance.gameModifierBiomes == GameModifier.MildBiomes)
		{
			foreach (Biome value4 in biomeCache.Values)
			{
				value4.entityModifiers.RemoveAll((BiomeModifier x) => x.effect == BiomeModifierType.BuildingEffectiveness || x.effect == BiomeModifierType.CultivationProductivity || x.effect == BiomeModifierType.ProspectingProductivity || x.effect == BiomeModifierType.RecipeProductivity || x.effect == BiomeModifierType.ResourceRegen || x.effect == BiomeModifierType.Land || x.effect == BiomeModifierType.MarketDemand);
			}
		}
		else if (instance.gameModifierBiomes == GameModifier.NoBiomes)
		{
			foreach (BuildingDef value5 in buildingCache.Values)
			{
				value5.requirements.RemoveAll((RequirementId x) => x.type == RequirementType.Biome);
			}
			foreach (Research value6 in researchCache.Values)
			{
				foreach (List<RequirementId> item in value6.requirementFixedCache)
				{
					item.RemoveAll((RequirementId x) => x.type == RequirementType.Biome);
				}
			}
			foreach (NaturalResourceDef value7 in naturalResourceCache.Values)
			{
				value7.requirements.RemoveAll((RequirementId x) => x.type == RequirementType.Biome);
			}
			foreach (FarmingRecipe value8 in farmingRecipeCache.Values)
			{
				value8.requirements.RemoveAll((RequirementId x) => x.type == RequirementType.Biome);
			}
			foreach (FarmingRecipe value9 in prospectingRecipeCache.Values)
			{
				value9.requirements.RemoveAll((RequirementId x) => x.type == RequirementType.Biome);
			}
			foreach (Perk value10 in perkDefCache.Values)
			{
				value10.requirements.RemoveAll((RequirementId x) => x.type == RequirementType.Biome);
			}
			foreach (Recipe value11 in recipeCache.Values)
			{
				value11.requirements.RemoveAll((RequirementId x) => x.type == RequirementType.Biome);
			}
			foreach (UpgradeDef value12 in upgradeCache.Values)
			{
				value12.displayRequirements.RemoveAll((RequirementId x) => x.type == RequirementType.Biome);
			}
			if (biomeCache.TryGetValue(BiomeType.Plains, out var value))
			{
				value.entityModifiers.Clear();
			}
		}
		if (instance.gameModifierPopulation == GameModifier.LowPopulation && buildingCache.TryGetValue(BuildingType.House, out var value2))
		{
			value2.workerHousingProvided = 2;
		}
		if (instance.isTownStorageInfinite)
		{
			foreach (BuildingDef value13 in buildingCache.Values)
			{
				value13.storageAmount = 0;
			}
		}
		if (!instance.isLandInfinite)
		{
			return;
		}
		foreach (BuildingDef value14 in buildingCache.Values)
		{
			value14.landRequired = 0;
		}
		foreach (Biome value15 in biomeCache.Values)
		{
			value15.entityModifiers.RemoveAll((BiomeModifier x) => x.effect == BiomeModifierType.Land);
		}
	}

	private static void LoadDefaultUpgradeRequirements()
	{
		foreach (KeyValuePair<BuildingType, UpgradeType> marketCapacityUpgrade in Data.Instance.marketCapacityUpgrades)
		{
			BuildingType key = marketCapacityUpgrade.Key;
			UpgradeType value = marketCapacityUpgrade.Value;
			if (upgradeCache.TryGetValue(value, out var value2))
			{
				value2.metadataFlagProductionCapacity = true;
				GameUtility.CopyBuildingRequirements(key, value2.displayRequirements);
				for (int i = 0; i < value2.levels.Count; i++)
				{
					UpgradeLevelDef upgradeLevelDef = value2.levels[i];
					int num = 5 + i * 5;
					upgradeLevelDef.AddRequirement(new RequirementId(key, num));
				}
			}
		}
		foreach (KeyValuePair<HarvestRecipeType, UpgradeType> harvestingSpeedUpgrade in Data.Instance.harvestingSpeedUpgrades)
		{
			if (!upgradeCache.TryGetValue(harvestingSpeedUpgrade.Value, out var value3))
			{
				continue;
			}
			value3.metadataFlagStateSpeed = true;
			UpgradeType value4 = harvestingSpeedUpgrade.Value;
			HarvestDef harvestDef = harvestRecipeCache[harvestingSpeedUpgrade.Key];
			if (harvestDef.producingBuildingType != BuildingType.None)
			{
				value3.popupParentEntity.Add(EntityId.FromBuilding(harvestDef.producingBuildingType));
			}
			EntityId id = EntityId.FromHarvestRecipe(harvestingSpeedUpgrade.Key);
			for (int j = 0; j < value3.levels.Count; j++)
			{
				UpgradeLevelDef upgradeLevelDef2 = value3.levels[j];
				int num2 = 0;
				switch (j)
				{
				case 0:
					num2 = 15;
					break;
				case 1:
					num2 = 30;
					break;
				case 2:
					num2 = 60;
					break;
				}
				switch (value4)
				{
				case UpgradeType.FishingNetHarvestingSpeed:
					num2 += 15;
					break;
				case UpgradeType.FishingMagicNetHarvestingSpeed:
					num2 += 30;
					break;
				}
				upgradeLevelDef2.AddRequirement(new RequirementId(SkillType.Harvesting, id, num2));
			}
		}
		foreach (KeyValuePair<NaturalResource, UpgradeType> prospectingSpeedUpgrade in Data.Instance.prospectingSpeedUpgrades)
		{
			if (!upgradeCache.TryGetValue(prospectingSpeedUpgrade.Value, out var value5))
			{
				continue;
			}
			value5.metadataFlagStateSpeed = true;
			NaturalResource key2 = prospectingSpeedUpgrade.Key;
			if (naturalResourceCache.TryGetValue(key2, out var value6) && value6.cultivationBuilding != BuildingType.None)
			{
				value5.popupParentEntity.Add(EntityId.FromBuilding(value6.cultivationBuilding));
			}
			EntityId id2 = EntityId.FromNaturalResource(key2);
			for (int k = 0; k < value5.levels.Count; k++)
			{
				UpgradeLevelDef upgradeLevelDef3 = value5.levels[k];
				int level = 0;
				switch (k)
				{
				case 0:
					level = 15;
					break;
				case 1:
					level = 30;
					break;
				case 2:
					level = 60;
					break;
				}
				upgradeLevelDef3.AddRequirement(new RequirementId(SkillType.Prospecting, id2, level));
			}
		}
		foreach (KeyValuePair<NaturalResource, UpgradeType> cultivationSpeedUpgrade in Data.Instance.cultivationSpeedUpgrades)
		{
			if (!upgradeCache.TryGetValue(cultivationSpeedUpgrade.Value, out var value7))
			{
				continue;
			}
			value7.metadataFlagStateSpeed = true;
			NaturalResource key3 = cultivationSpeedUpgrade.Key;
			if (naturalResourceCache.TryGetValue(key3, out var value8) && value8.cultivationBuilding != BuildingType.None)
			{
				value7.popupParentEntity.Add(EntityId.FromBuilding(value8.cultivationBuilding));
			}
			EntityId id3 = EntityId.FromNaturalResource(key3);
			for (int l = 0; l < value7.levels.Count; l++)
			{
				UpgradeLevelDef upgradeLevelDef4 = value7.levels[l];
				int level2 = 0;
				switch (l)
				{
				case 0:
					level2 = 15;
					break;
				case 1:
					level2 = 30;
					break;
				case 2:
					level2 = 60;
					break;
				}
				upgradeLevelDef4.AddRequirement(new RequirementId(SkillType.Cultivation, id3, level2));
			}
		}
		foreach (KeyValuePair<BuildingType, UpgradeType> productionCapacityUpgrade in Data.Instance.productionCapacityUpgrades)
		{
			BuildingType key4 = productionCapacityUpgrade.Key;
			if (upgradeCache.TryGetValue(productionCapacityUpgrade.Value, out var value9))
			{
				value9.metadataFlagProductionCapacity = true;
				GameUtility.CopyBuildingRequirements(key4, value9.displayRequirements);
				for (int m = 0; m < value9.levels.Count; m++)
				{
					UpgradeLevelDef upgradeLevelDef5 = value9.levels[m];
					upgradeLevelDef5.AddRequirement(new RequirementId(key4, 10 + m * 10));
				}
			}
		}
		foreach (KeyValuePair<BuildingType, UpgradeType> storageUpgrade in Data.Instance.storageUpgrades)
		{
			BuildingType key5 = storageUpgrade.Key;
			UpgradeType value10 = storageUpgrade.Value;
			if (upgradeCache.TryGetValue(value10, out var value11))
			{
				value11.metadataFlagItemCapacity = true;
				GameUtility.CopyBuildingRequirements(key5, value11.displayRequirements);
				for (int n = 0; n < value11.levels.Count; n++)
				{
					UpgradeLevelDef upgradeLevelDef6 = value11.levels[n];
					int num3 = 5;
					int num4 = 5;
					upgradeLevelDef6.AddRequirement(new RequirementId(key5, num3 + num4 * n));
				}
			}
		}
		AddDynamicSupportBuildingUpgradeQuests(BuildingType.Aqueduct, UpgradeType.AqueductEffectiveness);
		AddDynamicSupportBuildingUpgradeQuests(BuildingType.Well, UpgradeType.WellEffectiveness);
		AddDynamicSupportBuildingUpgradeQuests(BuildingType.WaterWheel, UpgradeType.WaterWheelEffectiveness);
		AddDynamicSupportBuildingUpgradeQuests(BuildingType.SolarPanel, UpgradeType.SolarPanelEffectiveness);
		AddDynamicPipelineUpgradeQuests(BuildingType.SteamPipeline, UpgradeType.SteamPipeSpeed);
		AddDynamicPipelineUpgradeQuests(BuildingType.ManaPipeline, UpgradeType.ManaPipeSpeed);
		AddDynamicPipelineUpgradeQuests(BuildingType.OmniPipeline, UpgradeType.OmniPipeSpeed);
		AddDynamicPipelineUpgradeQuests(BuildingType.PowerLine, UpgradeType.PowerLineSpeed);
		AddDynamicPipelineUpgradeQuests(BuildingType.MagmaPipeline, UpgradeType.MagmaPipeSpeed);
		AddDynamicSkillEffectQuests(SkillType.Crafting, UpgradeType.SkillEffectCrafting);
		AddDynamicSkillEffectQuests(SkillType.Cultivation, UpgradeType.SkillEffectCultivation);
		AddDynamicSkillEffectQuests(SkillType.Harvesting, UpgradeType.SkillEffectHarvesting);
		AddDynamicSkillEffectQuests(SkillType.Prospecting, UpgradeType.SkillEffectProspecting);
		AddDynamicSoldGoodsQuests(UpgradeType.SellValueYellowCoin, ItemType.YellowCoin);
		AddDynamicSoldGoodsQuests(UpgradeType.SellValueRedCoin, ItemType.RedCoin);
		AddDynamicSoldGoodsQuests(UpgradeType.SellValueBlueCoin, ItemType.BlueCoin);
		AddDynamicSoldGoodsQuests(UpgradeType.SellValuePurpleCoin, ItemType.PurpleCoin);
		AddDynamicBuildingCountQuests(UpgradeType.WaterPumpCountSpeed, BuildingType.WaterPump);
		AddDynamicBuildingCountQuests(UpgradeType.SteamBoilerCountSpeed, BuildingType.SteamBoiler);
		AddDynamicBuildingCountQuests(UpgradeType.ExtractorCountSpeed, BuildingType.ManaTransmitter);
		AddDynamicBuildingCountQuests(UpgradeType.FurnaceCountSpeed, BuildingType.Furnace);
		AddDynamicBuildingCountQuests(UpgradeType.SteamPowerGeneratorCountSpeed, BuildingType.SteamPowerGenerator);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionFood, BuildingType.Market, 0);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionGeneralGoods, BuildingType.GeneralGoods, 1);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionMedicine, BuildingType.Apothecary, 3);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionJewelryStore, BuildingType.JewelryStore, 4);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionGourmetFood, BuildingType.FancyFoods, 3);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionClothing, BuildingType.ClothingStore, 2);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionHardwareStore, BuildingType.HardwareStore, 2);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionBookstore, BuildingType.Bookstore, 2);
		AddDynamicMarketConsumptionSpeedQuests(UpgradeType.MarketConsumptionArcaneGoods, BuildingType.ArcaneStore, 4);
		if (upgradeCache.TryGetValue(UpgradeType.Exploration, out var value12))
		{
			value12.levels[0].AddRequirement(RequirementId.RequiredPopulation(100));
			value12.levels[1].AddRequirement(RequirementId.RequiredPopulation(150));
			value12.levels[2].AddRequirement(RequirementId.RequiredPopulation(200));
			value12.levels[3].AddRequirement(RequirementId.RequiredPopulation(250));
			value12.levels[4].AddRequirement(RequirementId.RequiredPopulation(300));
			value12.levels[5].AddRequirement(RequirementId.RequiredPopulation(400));
			value12.levels[6].AddRequirement(RequirementId.RequiredPopulation(500));
			value12.levels[7].AddRequirement(RequirementId.RequiredPopulation(600));
			value12.levels[8].AddRequirement(RequirementId.RequiredPopulation(800));
			value12.levels[9].AddRequirement(RequirementId.RequiredPopulation(1000));
		}
		if (upgradeCache.TryGetValue(UpgradeType.ConstructionEfficiency, out var value13))
		{
			for (int num5 = 0; num5 < value13.levels.Count; num5++)
			{
				int num6 = 100 + num5 * 100;
				value13.levels[num5].AddRequirement(new RequirementId(RequirementType.MinBuildingCount, EntityId.None, num6, 0, global: false));
			}
		}
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostFood, BiomeType.None);
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostGeneral, BiomeType.River);
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostHardware, BiomeType.Mountains);
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostBookstore, BiomeType.Forest);
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostClothing, BiomeType.Snow);
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostGourmet, BiomeType.Plains);
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostApothecary, BiomeType.Jungle);
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostJewelry, BiomeType.Desert);
		ConfigureMarketCostUpgrade(UpgradeType.MarketCostArcane, BiomeType.Magic);
		if (upgradeCache.TryGetValue(UpgradeType.UpgradeEfficiency, out var value14))
		{
			int[] array = new int[25]
			{
				10, 25, 50, 75, 100, 150, 200, 250, 300, 350,
				400, 450, 500, 550, 600, 650, 700, 750, 800, 900,
				1000, 1100, 1200, 1300, 1500
			};
			for (int num7 = 0; num7 < value14.levels.Count; num7++)
			{
				int num8 = array[num7];
				value14.levels[num7].AddRequirement(new RequirementId(RequirementType.TotalUpgradeCount, EntityId.None, num8, 0, global: false));
			}
		}
		if (upgradeCache.TryGetValue(UpgradeType.BuildingConstructionSpeedGrowth, out var value15))
		{
			for (int num9 = 0; num9 < value15.levels.Count; num9++)
			{
				UpgradeLevelDef upgradeLevelDef7 = value15.levels[num9];
				int num10 = 50;
				int num11 = 50 + num9 * num10;
				upgradeLevelDef7.AddRequirement(new RequirementId(BuildingType.None, num11));
			}
		}
		if (upgradeCache.TryGetValue(UpgradeType.ResearchSpeed, out var value16))
		{
			for (int num12 = 0; num12 < value16.levels.Count; num12++)
			{
				UpgradeLevelDef upgradeLevelDef8 = value16.levels[num12];
				int count = 20 + num12 * 10;
				upgradeLevelDef8.AddRequirement(RequirementId.ResearchCount(count, global: true));
			}
		}
		if (upgradeCache.TryGetValue(UpgradeType.HouseCapacity, out var value17))
		{
			for (int num13 = 0; num13 < value17.levels.Count; num13++)
			{
				UpgradeLevelDef upgradeLevelDef9 = value17.levels[num13];
				int num14 = 20 + num13 * 5;
				upgradeLevelDef9.AddRequirement(new RequirementId(BuildingType.House, num14));
			}
		}
		if (upgradeCache.TryGetValue(UpgradeType.SkillGainSpeed, out var value18))
		{
			for (int num15 = 0; num15 < value18.levels.Count; num15++)
			{
				if (num15 != 0)
				{
					UpgradeLevelDef upgradeLevelDef10 = value18.levels[num15];
					int level3 = 6 + num15 * 4;
					int numSkills = 5 + num15 * 5;
					upgradeLevelDef10.AddRequirement(new RequirementId(SkillType.None, numSkills, level3));
				}
			}
		}
		if (!upgradeCache.TryGetValue(UpgradeType.HouseCost, out var value19))
		{
			return;
		}
		for (int num16 = 0; num16 < value19.levels.Count; num16++)
		{
			UpgradeLevelDef upgradeLevelDef11 = value19.levels[num16];
			int num17 = 0;
			switch (num16)
			{
			case 0:
				num17 = 10000;
				break;
			case 1:
				num17 = 32000;
				break;
			case 2:
				num17 = 100000;
				break;
			case 3:
				num17 = 320000;
				break;
			case 4:
				num17 = 1000000;
				break;
			}
			upgradeLevelDef11.AddRequirement(new RequirementId(ItemType.Plank, num17, global: false));
		}
	}

	private static void ConfigureMarketCostUpgrade(UpgradeType u, BiomeType b)
	{
		if (upgradeCache.TryGetValue(u, out var value))
		{
			value.AddDisplayReq(new RequirementId(ResearchType.MarketCostUpgrades));
			for (int i = 0; i < value.levels.Count; i++)
			{
				int requiredLevel = 25 + i * 5;
				value.levels[i].AddRequirement(RequirementId.RequiredTownLevelGlobal(requiredLevel, b));
			}
		}
	}

	private static void AddDynamicMarketConsumptionSpeedQuests(UpgradeType upgradeType, BuildingType buildingType, int townLevelOffset)
	{
		if (upgradeCache.TryGetValue(upgradeType, out var value))
		{
			value.AddDisplayReq(new RequirementId(ResearchType.Advertising));
			for (int i = 0; i < value.levels.Count; i++)
			{
				UpgradeLevelDef upgradeLevelDef = value.levels[i];
				double value2 = GameUtility.ScaledValue(1000.0, i);
				RequirementId r = RequirementId.MarketSellCount(requiredCount: GameUtility.TruncateToSignificantDigits(value2, 2), t: buildingType);
				upgradeLevelDef.AddRequirement(r);
			}
		}
		else
		{
			Debug.LogError("Did not find cached upgrade for " + upgradeType.ToString() + " " + buildingType);
		}
	}

	private static void AddDynamicBuildingCountQuests(UpgradeType upgradeType, BuildingType buildingType)
	{
		if (upgradeCache.TryGetValue(upgradeType, out var value))
		{
			GameUtility.CopyBuildingRequirements(buildingType, value.displayRequirements);
			int num = 5;
			int num2 = 5;
			for (int i = 0; i < value.levels.Count; i++)
			{
				value.levels[i].AddRequirement(new RequirementId(buildingType, num + num2 * i));
			}
		}
		else
		{
			Debug.LogError("Did not find cached upgrade for " + upgradeType.ToString() + " " + buildingType);
		}
	}

	private static void AddDynamicSoldGoodsQuests(UpgradeType upgradeType, ItemType coinType)
	{
		if (upgradeCache.TryGetValue(upgradeType, out var value))
		{
			value.AddDisplayReq(new RequirementId(ResearchType.Economics));
			float num = 500000f;
			switch (coinType)
			{
			case ItemType.YellowCoin:
				num = 1000000f;
				break;
			case ItemType.RedCoin:
				num = 500000f;
				break;
			case ItemType.BlueCoin:
				num = 100000f;
				break;
			case ItemType.PurpleCoin:
				num = 50000f;
				break;
			}
			for (int i = 0; i < value.levels.Count; i++)
			{
				UpgradeLevelDef upgradeLevelDef = value.levels[i];
				double count = GameUtility.ScaledTenValue(num, i);
				upgradeLevelDef.AddRequirement(new RequirementId(coinType, count, global: false));
			}
		}
	}

	private static void AddDynamicSkillEffectQuests(SkillType skillType, UpgradeType upgradeType)
	{
		if (!upgradeCache.TryGetValue(upgradeType, out var value))
		{
			return;
		}
		for (int i = 0; i < value.levels.Count; i++)
		{
			UpgradeLevelDef upgradeLevelDef = value.levels[i];
			double targetXP = 100.0;
			switch (skillType)
			{
			case SkillType.Crafting:
				targetXP = GameUtility.ScaledTenValue(100000.0, i);
				break;
			case SkillType.Harvesting:
				targetXP = GameUtility.ScaledTenValue(100000.0, i);
				break;
			case SkillType.Prospecting:
				targetXP = GameUtility.ScaledTenValue(25000.0, i);
				break;
			case SkillType.Cultivation:
				targetXP = GameUtility.ScaledTenValue(25000.0, i);
				break;
			}
			upgradeLevelDef.AddRequirement(new RequirementId(skillType, targetXP));
		}
	}

	private static void AddDynamicPipelineUpgradeQuests(BuildingType buildingType, UpgradeType upgradeType)
	{
		if (upgradeCache.TryGetValue(upgradeType, out var value))
		{
			double[] array = new double[10] { 10.0, 20.0, 40.0, 60.0, 80.0, 100.0, 125.0, 150.0, 200.0, 250.0 };
			GameUtility.CopyBuildingRequirements(buildingType, value.displayRequirements);
			for (int i = 0; i < value.levels.Count; i++)
			{
				UpgradeLevelDef upgradeLevelDef = value.levels[i];
				double num = 0.0;
				num = ((i <= array.Length) ? array[i] : array[^1]);
				upgradeLevelDef.AddRequirement(new RequirementId(buildingType, num));
			}
		}
	}

	private static void AddDynamicSupportBuildingUpgradeQuests(BuildingType buildingType, UpgradeType upgradeType)
	{
		if (upgradeCache.TryGetValue(upgradeType, out var value))
		{
			GameUtility.CopyBuildingRequirements(buildingType, value.displayRequirements);
			for (int i = 0; i < value.levels.Count; i++)
			{
				UpgradeLevelDef upgradeLevelDef = value.levels[i];
				int num = 10;
				int num2 = 10;
				upgradeLevelDef.AddRequirement(new RequirementId(buildingType, num + num2 * i));
			}
		}
	}

	public static Recipe GetRecipe(RecipeType recipeType)
	{
		if (recipeType == RecipeType.None)
		{
			return null;
		}
		if (recipeCache.TryGetValue(recipeType, out var value))
		{
			return value;
		}
		Debug.LogError("Unable to find cached recipe " + recipeType);
		return null;
	}

	public static ItemList GetCachedBuildingCost(BuildingType t)
	{
		return GetCachedBuildingDef(t).cost;
	}

	public static ItemList GetCachedRecipeCost(RecipeType r)
	{
		return GetRecipe(r).inputs;
	}

	public static ItemList GetCachedNaturalResourceCost(NaturalResource r)
	{
		return Data.emptyItemList;
	}

	public static void CheckForErrors()
	{
		foreach (UpgradeDef value4 in upgradeCache.Values)
		{
			_ = value4.metadataTarget;
		}
		foreach (QuestType value5 in Enum.GetValues(typeof(QuestType)))
		{
			if (value5 != QuestType.None && !disabledQuests.Contains(value5))
			{
				questCache.ContainsKey(value5);
			}
		}
		foreach (UpgradeType value6 in Enum.GetValues(typeof(UpgradeType)))
		{
			if (value6 != UpgradeType.None && Upgrade.IsEnabled(value6))
			{
				upgradeCache.ContainsKey(value6);
			}
		}
		if (Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Research, out var value))
		{
			foreach (ResearchType value7 in Enum.GetValues(typeof(ResearchType)))
			{
				if (value7 != ResearchType.None)
				{
					EntityId item = EntityId.FromResearch(value7);
					if (!value.Contains(item))
					{
						Research research = new Research(value7);
						research.LoadDefaultResearch();
						_ = research.enabled;
					}
				}
			}
			foreach (EntityId item4 in value)
			{
				Research research2 = new Research(item4.AsResearch);
				research2.LoadDefaultResearch();
				_ = research2.enabled;
			}
		}
		if (Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Recipe, out var value2))
		{
			foreach (EntityId item5 in value2)
			{
				if (item5.TryAsRecipe(out var r))
				{
					Data.Instance.defaultRecipeDefs.ContainsKey(r);
				}
			}
			foreach (KeyValuePair<RecipeType, Recipe> defaultRecipeDef in Data.Instance.defaultRecipeDefs)
			{
				if (defaultRecipeDef.Value.enabled)
				{
					EntityId item2 = EntityId.FromRecipe(defaultRecipeDef.Key);
					value2.Contains(item2);
				}
			}
		}
		if (!Data.Instance.defaultDisplayCategories.TryGetValue(BuildCategoryType.Building, out var value3))
		{
			return;
		}
		foreach (KeyValuePair<BuildingType, BuildingDef> defaultBuildingDef in Data.Instance.defaultBuildingDefs)
		{
			if (defaultBuildingDef.Value.enabled)
			{
				EntityId item3 = EntityId.FromBuilding(defaultBuildingDef.Key);
				value3.Contains(item3);
			}
		}
	}

	public static void DeriveRequirements()
	{
		foreach (KeyValuePair<RecipeType, Recipe> item in recipeCache)
		{
			item.Value.DeriveRequirements();
		}
	}

	public static void DeriveRewards()
	{
		foreach (NaturalResourceDef value in naturalResourceCache.Values)
		{
			EntityId entity = EntityId.FromNaturalResource(value.type);
			foreach (RequirementId requirement in value.requirements)
			{
				TryAddRewardFromRequirement(requirement, entity);
			}
		}
		foreach (Recipe value2 in recipeCache.Values)
		{
			EntityId entity2 = EntityId.FromRecipe(value2.type);
			foreach (RequirementId requirement2 in value2.requirements)
			{
				TryAddRewardFromRequirement(requirement2, entity2);
			}
		}
		foreach (Research value3 in researchCache.Values)
		{
			EntityId entity3 = EntityId.FromResearch(value3.type);
			int num = 0;
			foreach (List<RequirementId> item in value3.requirementFixedCache)
			{
				foreach (RequirementId item2 in item)
				{
					TryAddRewardFromRequirement(item2, entity3, num);
				}
				num++;
			}
		}
		foreach (FarmingRecipe value4 in farmingRecipeCache.Values)
		{
			EntityId entity4 = EntityId.FromFarming(value4.resource);
			foreach (RequirementId requirement3 in value4.requirements)
			{
				TryAddRewardFromRequirement(requirement3, entity4);
			}
		}
		foreach (FarmingRecipe value5 in prospectingRecipeCache.Values)
		{
			EntityId entity5 = EntityId.FromMining(value5.resource);
			foreach (RequirementId requirement4 in value5.requirements)
			{
				TryAddRewardFromRequirement(requirement4, entity5);
			}
		}
		foreach (QuestDef value6 in questCache.Values)
		{
			EntityId entity6 = EntityId.FromQuest(value6.type);
			foreach (RequirementId item3 in value6.displayRequirement)
			{
				TryAddRewardFromRequirement(item3, entity6);
			}
		}
		foreach (UpgradeDef value7 in upgradeCache.Values)
		{
			EntityId entity7 = EntityId.FromUpgrade(value7.type);
			foreach (RequirementId displayRequirement in value7.displayRequirements)
			{
				TryAddRewardFromRequirement(displayRequirement, entity7);
			}
			for (int i = 0; i < value7.levels.Count; i++)
			{
				foreach (RequirementId unlockRequirement in value7.levels[i].unlockRequirements)
				{
					TryAddRewardFromRequirement(unlockRequirement, entity7, i + 1);
				}
			}
		}
		foreach (HarvestDef value8 in harvestRecipeCache.Values)
		{
			EntityId entity8 = EntityId.FromHarvestRecipe(value8.type);
			foreach (RequirementId requirement5 in value8.requirements)
			{
				TryAddRewardFromRequirement(requirement5, entity8);
			}
		}
		foreach (BuildingDef value9 in buildingCache.Values)
		{
			EntityId entity9 = EntityId.FromBuilding(value9.type);
			foreach (RequirementId requirement6 in value9.requirements)
			{
				TryAddRewardFromRequirement(requirement6, entity9);
			}
		}
	}

	public static void TryAddRewardFromRequirement(RequirementId r, EntityId entity, int level = 0)
	{
		NaturalResourceDef value3;
		if (r.type == RequirementType.Research)
		{
			if (researchCache.TryGetValue(r.entityId.AsResearch, out var value))
			{
				value.reward.Add(new EntityLevel(entity, level));
			}
		}
		else if (r.type == RequirementType.Quest)
		{
			QuestType asQuest = r.entityId.AsQuest;
			if (questCache.TryGetValue(asQuest, out var value2))
			{
				EntityLevel item = new EntityLevel(entity, level);
				if (!value2.derivedRewards.Contains(item))
				{
					value2.derivedRewards.Add(item);
				}
			}
		}
		else if (r.type == RequirementType.NaturalResource && naturalResourceCache.TryGetValue(r.entityId.AsNaturalResource, out value3))
		{
			value3.reward.Add(new EntityLevel(entity, level));
		}
	}

	public static float DerivedItemXP(ItemType t)
	{
		if (itemXpValues.TryGetValue(t, out var value))
		{
			return value;
		}
		List<RecipeType> value2;
		if (Item.MatchesFilterCache(t, ItemType.FilterNaturalResource))
		{
			value = 1f;
		}
		else if (derivedItemRecipeSources.TryGetValue(t, out value2))
		{
			float num = float.MaxValue;
			foreach (RecipeType item in value2)
			{
				float num2 = DerivedRecipeExp(item);
				if (num2 < num)
				{
					num = num2;
				}
			}
			value = ((!(num < float.MaxValue)) ? 0f : num);
		}
		else
		{
			value = 0f;
		}
		itemXpValues[t] = value;
		return value;
	}

	private static float BonusForProducingBuilding(RecipeType r)
	{
		foreach (KeyValuePair<BuildingType, List<RecipeType>> cachedBuildingRecipe in cachedBuildingRecipes)
		{
			if (cachedBuildingRecipe.Value.Contains(r))
			{
				switch (cachedBuildingRecipe.Key)
				{
				case BuildingType.Forge:
					return 1f;
				case BuildingType.MedicineHut:
					return 1f;
				case BuildingType.MachineShop:
					return 2f;
				case BuildingType.MagicForge:
					return 2f;
				case BuildingType.Enchanter:
					return 3f;
				case BuildingType.Refinery:
					return 3f;
				case BuildingType.GourmetKitchen:
					return 3f;
				case BuildingType.Jeweler:
					return 4f;
				case BuildingType.ManaReactor:
					return 5f;
				}
			}
		}
		return 0f;
	}

	public static float DerivedRecipeExp(RecipeType r)
	{
		if (recipeXpValues.TryGetValue(r, out var value))
		{
			if (value < 0f)
			{
				return 1f;
			}
			return value;
		}
		recipeXpValues[r] = -1f;
		value = 0f;
		if (recipeCache.TryGetValue(r, out var value2))
		{
			foreach (KeyValuePair<ItemType, double> item in value2.inputs.items)
			{
				float num = DerivedItemXP(item.Key);
				if (GameUtility.IsNearlyZero(num))
				{
					if (item.Value > 2.0)
					{
						num = 1f;
					}
				}
				else
				{
					num *= GameUtility.AsFloat(item.Value);
				}
				value += num;
			}
			value += 1f;
		}
		float num2 = BonusForProducingBuilding(r);
		if (num2 > 0f)
		{
			value += num2;
		}
		recipeXpValues[r] = value;
		return value;
	}

	public static void DeriveRecipeExp()
	{
		if (recipeXpValues == null)
		{
			recipeXpValues = new Dictionary<RecipeType, float>(new RecipeEqualityComparer());
		}
		else
		{
			recipeXpValues.Clear();
		}
		if (itemXpValues == null)
		{
			itemXpValues = new Dictionary<ItemType, float>(new ItemEqualityComparer());
		}
		else
		{
			itemXpValues.Clear();
		}
		recipeXpValues[RecipeType.BurnWood] = 0f;
		recipeXpValues[RecipeType.BurnCoal] = 0f;
		recipeXpValues[RecipeType.GenerateSteam] = 0f;
		recipeXpValues[RecipeType.SteamPower] = 0f;
		recipeXpValues[RecipeType.SolarPanelPower] = 0f;
		recipeXpValues[RecipeType.WaterWheelPower] = 0f;
		recipeXpValues[RecipeType.PumpWater] = 0f;
		itemXpValues[ItemType.Fire] = 0.5f;
		itemXpValues[ItemType.Steam] = 0.5f;
		itemXpValues[ItemType.Water] = 0.5f;
		itemXpValues[ItemType.Power] = 0.5f;
		itemXpValues[ItemType.ManaPower] = 4f;
		itemXpValues[ItemType.IronOre] = 1.25f;
		itemXpValues[ItemType.Coal] = 1.25f;
		itemXpValues[ItemType.CopperOre] = 1.25f;
		itemXpValues[ItemType.SilverOre] = 1.5f;
		itemXpValues[ItemType.GoldOre] = 2f;
		itemXpValues[ItemType.Fish] = 1f;
		itemXpValues[ItemType.RedRuby] = 3f;
		itemXpValues[ItemType.YellowTopaz] = 3f;
		itemXpValues[ItemType.BlueSapphire] = 3f;
		itemXpValues[ItemType.PurpleAmethyst] = 3f;
		itemXpValues[ItemType.Mana] = 4f;
		itemXpValues[ItemType.Star] = 4000f;
		foreach (KeyValuePair<RecipeType, Recipe> item in recipeCache)
		{
			DerivedRecipeExp(item.Key);
		}
		foreach (EntityId item2 in Data.Instance.defaultDisplayCategories[BuildCategoryType.Item])
		{
			if (item2.TryAsItem(out var i) && !itemXpValues.ContainsKey(i) && derivedItemRecipeSources.ContainsKey(i))
			{
				DerivedItemXP(i);
			}
		}
		foreach (KeyValuePair<RecipeType, Recipe> item3 in recipeCache)
		{
			if (recipeXpValues.TryGetValue(item3.Key, out var value))
			{
				item3.Value.xpValue = Mathf.CeilToInt(value);
			}
		}
	}

	private static void AddStoragePair(EntityId id, BuildingType b)
	{
		if (!cachedStorageByBuilding.TryGetValue(b, out var value))
		{
			value = new List<EntityId>();
			cachedStorageByBuilding[b] = value;
		}
		value.Add(id);
		if (!cachedStorageByEntity.TryGetValue(id, out var value2))
		{
			value2 = new List<BuildingType>();
			cachedStorageByEntity[id] = value2;
		}
		value2.Add(b);
	}

	public static void LoadDerivedData()
	{
		TextDisplay.ClearLocalizationCache();
		researchTypes.Clear();
		marketTypes.Clear();
		foreach (KeyValuePair<BuildingType, BuildingDef> item in buildingCache)
		{
			List<RecipeType> list = PotentialRecipeTypesForBuilding(item.Key);
			if (item.Value.enabled)
			{
				list.RemoveAll((RecipeType x) => GetRecipe(x) == null || !GetRecipe(x).enabled);
			}
			else
			{
				list.Clear();
			}
			if (item.Value.isMarket)
			{
				marketTypes.Add(item.Key);
			}
			researchTypes.Add(BuildingType.School);
		}
		harvestingBuildings.Clear();
		cultivationBuildings.Clear();
		foreach (KeyValuePair<NaturalResource, NaturalResourceDef> item2 in naturalResourceCache)
		{
			BuildingType cultivationBuilding = item2.Value.cultivationBuilding;
			if (!cultivationBuildings.Contains(cultivationBuilding))
			{
				cultivationBuildings.Add(cultivationBuilding);
			}
		}
		itemFilterMap.Clear();
		workerItemTypes.Clear();
		naturalResources.Clear();
		naturalResourceFilters.Clear();
		physicalItemTypes.Clear();
		derivedItemBuildingSources.Clear();
		derivedItemConsumption.Clear();
		derivedItemRecipeSources.Clear();
		cachedStorageByBuilding.Clear();
		cachedStorageByEntity.Clear();
		foreach (HouseSellData value3 in houseSellData.Values)
		{
			if (buildingCache.TryGetValue(value3.derivedSellBuilding, out var value) && value.storageAmount > 0)
			{
				AddStoragePair(EntityId.FromItem(value3.itemType), value3.derivedSellBuilding);
			}
		}
		foreach (ItemDef value4 in cachedItemDefs.Values)
		{
			if (value4.phase == MatterPhase.Solid)
			{
				AddStoragePair(EntityId.FromItem(value4.type), BuildingType.Crate);
			}
		}
		foreach (BuildingDef value5 in buildingCache.Values)
		{
			StorageType storageType = Building.StorageTypeForBuilding(value5.type);
			if (value5.storageAmount <= 0 || storageType == StorageType.None)
			{
				continue;
			}
			foreach (ItemDef value6 in cachedItemDefs.Values)
			{
				if (value6.storageType == storageType && value6.enabled)
				{
					AddStoragePair(EntityId.FromItem(value6.type), value5.type);
				}
			}
		}
		foreach (NaturalResourceDef value7 in naturalResourceCache.Values)
		{
			if (buildingCache.TryGetValue(value7.cultivationBuilding, out var value2) && value2.storageAmount > 0)
			{
				AddStoragePair(EntityId.FromNaturalResource(value7.type), value7.cultivationBuilding);
			}
		}
		AddStoragePair(EntityId.FromItem(ItemType.Steam), BuildingType.SteamBoiler);
		AddStoragePair(EntityId.FromItem(ItemType.Power), BuildingType.SteamPowerGenerator);
		AddStoragePair(EntityId.FromItem(ItemType.Water), BuildingType.Barrel);
		AddStoragePair(EntityId.FromItem(ItemType.Water), BuildingType.WaterShrine);
		AddStoragePair(EntityId.FromItem(ItemType.Fire), BuildingType.FireShrine);
		AddStoragePair(EntityId.FromItem(ItemType.Steam), BuildingType.AirShrine);
		AddStoragePair(EntityId.FromItem(ItemType.Power), BuildingType.EarthShrine);
		foreach (KeyValuePair<ItemType, ItemDef> cachedItemDef in cachedItemDefs)
		{
			ItemType key = cachedItemDef.Key;
			if (key == ItemType.None || !cachedItemDef.Value.enabled || Item.IsDynamicConsumptionFilter(key))
			{
				continue;
			}
			if (Item.IsFilter(key))
			{
				itemFilterMap[key] = GameUtility.ItemHashSet();
			}
			else if (Item.IsWorkerUnit(key))
			{
				workerItemTypes.Add(key);
			}
			else if (!Item.IsCurrency(key) && Item.IsDefaultPhysicalItem(key))
			{
				physicalItemTypes.Add(key);
				if (Item.MatchesFilter(key, ItemType.FilterNaturalResource))
				{
					naturalResources.Add(key);
				}
				LoadProductionSources(key);
			}
		}
		LoadCoinMarketSources(ItemType.YellowCoin);
		LoadCoinMarketSources(ItemType.RedCoin);
		LoadCoinMarketSources(ItemType.BlueCoin);
		LoadCoinMarketSources(ItemType.PurpleCoin);
		LoadCoinMarketSources(ItemType.OmniCoin);
		upgradeCache[UpgradeType.SellValueYellowCoin].AddCoinSources(ItemType.YellowCoin);
		upgradeCache[UpgradeType.SellValueRedCoin].AddCoinSources(ItemType.RedCoin);
		upgradeCache[UpgradeType.SellValueBlueCoin].AddCoinSources(ItemType.BlueCoin);
		upgradeCache[UpgradeType.SellValuePurpleCoin].AddCoinSources(ItemType.PurpleCoin);
		upgradeCache[UpgradeType.SellSpeedYellowCoin].AddCoinSources(ItemType.YellowCoin);
		upgradeCache[UpgradeType.SellSpeedRedCoin].AddCoinSources(ItemType.RedCoin);
		upgradeCache[UpgradeType.SellSpeedBlueCoin].AddCoinSources(ItemType.BlueCoin);
		upgradeCache[UpgradeType.SellSpeedPurpleCoin].AddCoinSources(ItemType.PurpleCoin);
		upgradeCache[UpgradeType.SellSpeedOmniCoin].AddCoinSources(ItemType.OmniCoin);
		LoadProductionSources(ItemType.UtilityRegenerateResources);
		LoadProductionSources(ItemType.UtilityRotationalPower);
		LoadProductionSources(ItemType.ManaPower);
		LoadProductionSources(ItemType.UtilityElementalFirePower);
		LoadProductionSources(ItemType.UtilityElementalWaterPower);
		LoadProductionSources(ItemType.UtilityElementalAirPower);
		LoadProductionSources(ItemType.UtilityElementalEarthPower);
		foreach (ItemType naturalResource in naturalResources)
		{
			naturalResourceFilters.Add(naturalResource);
		}
		foreach (KeyValuePair<ItemType, HashSet<ItemType>> item3 in itemFilterMap)
		{
			bool flag = false;
			foreach (KeyValuePair<ItemType, ItemDef> cachedItemDef2 in cachedItemDefs)
			{
				ItemType key2 = cachedItemDef2.Key;
				if (key2 != item3.Key && key2 != ItemType.None)
				{
					if (Item.MatchesFilter(key2, item3.Key))
					{
						item3.Value.Add(key2);
					}
					if (naturalResources.Contains(key2))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				naturalResourceFilters.Add(item3.Key);
			}
		}
		foreach (KeyValuePair<ItemType, HashSet<ItemType>> item4 in itemFilterMap)
		{
			UpdateMappingsForKey(item4.Key);
		}
		LoadDynamicMarketFilters();
		foreach (KeyValuePair<BuildingType, BuildingDef> item5 in buildingCache)
		{
			item5.Value.CalcDerivedData();
		}
		DeriveRecipeExp();
	}

	private static bool IsPossibleToCraft(ItemType t)
	{
		if (derivedItemBuildingSources.TryGetValue(t, out var value))
		{
			if (value == null)
			{
				return false;
			}
			foreach (BuildingType item in value)
			{
				if (Building.IsEnabled(item))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void LoadDynamicMarketFilters()
	{
		satisfactionCategoryData.Clear();
		satisfactionCategories.Clear();
		marketSellCategories.Clear();
		HashSet<ItemType> value = GameUtility.ItemHashSet();
		itemFilterMap[ItemType.FilterSellable] = value;
		foreach (KeyValuePair<ItemType, HouseSellData> houseSellDatum in houseSellData)
		{
			ProcessHouseSellData(houseSellDatum.Value);
		}
		UpdateMappingsForKey(ItemType.FilterSellable);
		foreach (ItemType marketSellCategory in marketSellCategories)
		{
			UpdateMappingsForKey(marketSellCategory);
		}
		foreach (ItemType satisfactionCategory in satisfactionCategories)
		{
			UpdateMappingsForKey(satisfactionCategory);
		}
	}

	private static void ProcessHouseSellData(HouseSellData d)
	{
		if (d.isSellable)
		{
			ItemType itemType = d.itemType;
			if (Data.IsItemEnabledDefault(itemType))
			{
				itemFilterMap[ItemType.FilterSellable].Add(itemType);
			}
		}
	}

	private static void AddSellCategory(ItemType sellCategory)
	{
		marketSellCategories.Add(sellCategory);
		if (sellCategory != ItemType.None)
		{
			itemFilterMap[ItemType.FilterSellable].Add(sellCategory);
			itemFilterMap[sellCategory] = GameUtility.ItemHashSet();
		}
	}

	public static HashSet<ItemType> PhysicalItemsInRecursiveFilter(ItemType filter)
	{
		if (itemFilterMapPhysical.TryGetValue(filter, out var value))
		{
			return value;
		}
		return GameUtility.Instance.emptyItemHashSet;
	}

	public static HashSet<ItemType> ItemsAndFiltersInFilter(ItemType filter)
	{
		if (itemFilterMap.TryGetValue(filter, out var value))
		{
			return value;
		}
		return GameUtility.ItemHashSet();
	}

	public static HashSet<ItemType> ItemsAndFiltersInRecursiveFilter(ItemType filter)
	{
		if (itemFilterMapRecursive.TryGetValue(filter, out var value))
		{
			return value;
		}
		return null;
	}

	private static void LoadPhysicalItemsInFilterRecursive(ItemType filter, HashSet<ItemType> targetList, HashSet<ItemType> checkedList, bool includeFilters)
	{
		foreach (ItemType item in ItemsAndFiltersInFilter(filter))
		{
			if (!cachedItemDefs.ContainsKey(item))
			{
				Debug.LogError("No cached key for " + item.ToString() + " filter " + filter);
			}
			if (!Item.IsEnabled(item))
			{
				continue;
			}
			if (Item.IsFilter(item))
			{
				if (includeFilters)
				{
					targetList.Add(item);
				}
				if (!checkedList.Contains(item))
				{
					checkedList.Add(item);
					LoadPhysicalItemsInFilterRecursive(item, targetList, checkedList, includeFilters);
				}
			}
			else
			{
				targetList.Add(item);
			}
		}
	}

	private static void UpdateMappingsForKey(ItemType mappingKey)
	{
		HashSet<ItemType> hashSet = GameUtility.ItemHashSet();
		HashSet<ItemType> hashSet2 = GameUtility.ItemHashSet();
		itemFilterMapPhysical[mappingKey] = hashSet;
		LoadPhysicalItemsInFilterRecursive(mappingKey, hashSet, hashSet2, includeFilters: false);
		hashSet2.Clear();
		HashSet<ItemType> hashSet3 = GameUtility.ItemHashSet();
		itemFilterMapRecursive[mappingKey] = hashSet3;
		LoadPhysicalItemsInFilterRecursive(mappingKey, hashSet3, hashSet2, includeFilters: true);
	}

	private static void LoadCoinMarketSources(ItemType coinType)
	{
		if (!derivedItemBuildingSources.TryGetValue(coinType, out var value))
		{
			value = new List<BuildingType>();
			derivedItemBuildingSources[coinType] = value;
		}
		foreach (HouseSellData value2 in houseSellData.Values)
		{
			if (value2.coinType == coinType && !value.Contains(value2.derivedSellBuilding) && value2.derivedSellBuilding != BuildingType.None)
			{
				value.Add(value2.derivedSellBuilding);
			}
		}
	}

	private static void LoadProductionSources(ItemType itemType)
	{
		List<BuildingType> list = new List<BuildingType>();
		derivedItemBuildingSources[itemType] = list;
		List<EntityId> list2 = new List<EntityId>();
		derivedItemConsumption[itemType] = list2;
		foreach (KeyValuePair<BuildingType, BuildingDef> item4 in buildingCache)
		{
			if (item4.Value.enabled && IsBuildingProducerOf(item4.Key, itemType))
			{
				list.Add(item4.Key);
			}
		}
		foreach (HarvestDef value2 in harvestRecipeCache.Values)
		{
			if (value2.recipe.inputs.Contains(itemType))
			{
				EntityId item = EntityId.FromBuilding(value2.producingBuildingType);
				if (!list2.Contains(item))
				{
					list2.Add(item);
				}
			}
			if (value2.recipe.outputs.Contains(itemType) && !list.Contains(value2.producingBuildingType))
			{
				list.Add(value2.producingBuildingType);
			}
		}
		foreach (FarmingRecipe value3 in farmingRecipeCache.Values)
		{
			if (value3.inputs.Contains(itemType))
			{
				EntityId item2 = EntityId.FromBuilding(value3.producingBuildingType);
				if (!list2.Contains(item2))
				{
					list2.Add(item2);
				}
			}
		}
		foreach (FarmingRecipe value4 in prospectingRecipeCache.Values)
		{
			if (value4.inputs.Contains(itemType))
			{
				EntityId item3 = EntityId.FromBuilding(value4.producingBuildingType);
				if (!list2.Contains(item3))
				{
					list2.Add(item3);
				}
			}
		}
		foreach (KeyValuePair<RecipeType, Recipe> item5 in recipeCache)
		{
			if (item5.Value.inputs.Contains(itemType))
			{
				list2.Add(EntityId.FromRecipe(item5.Key));
			}
			if (item5.Value.outputs.Contains(itemType))
			{
				if (!derivedItemRecipeSources.TryGetValue(itemType, out var value))
				{
					value = new List<RecipeType>();
					derivedItemRecipeSources[itemType] = value;
				}
				value.Add(item5.Key);
			}
		}
	}

	private static bool IsBuildingProducerOf(BuildingType buildingType, ItemType itemType)
	{
		foreach (RecipeType item in PotentialRecipeTypesForBuilding(buildingType))
		{
			Recipe recipe = GetRecipe(item);
			if (recipe == null || recipe.category == RecipeCategory.Trade)
			{
				continue;
			}
			foreach (KeyValuePair<ItemType, double> item2 in recipe.outputs.items)
			{
				ItemType key = item2.Key;
				if (key != ItemType.FilterPackable && key != ItemType.FilterChargedElement && key != ItemType.FilterDepletedElement && key != ItemType.FilterPurifiedElement && Item.MatchesFilter(itemType, key))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static List<NaturalResource> NaturalResourcesFarmedByBuilding(BuildingType type)
	{
		if (cachedBuildingResources.TryGetValue(type, out var value))
		{
			return value;
		}
		return null;
	}

	public static List<RecipeType> PotentialRecipeTypesForBuilding(BuildingType type)
	{
		if (cachedBuildingRecipes.TryGetValue(type, out var value))
		{
			return value;
		}
		Debug.LogError("! No cached recipe entry for building " + type);
		value = new List<RecipeType>();
		cachedBuildingRecipes[type] = value;
		return value;
	}

	public static BuildingDef GetCachedBuildingDef(BuildingType buildingType)
	{
		if (buildingCache.TryGetValue(buildingType, out var value))
		{
			return value;
		}
		Debug.LogError("NO cached def for " + buildingType.ToString() + ", check IsBuildingEnabledDefault");
		return new BuildingDef(BuildingType.None)
		{
			enabled = false
		};
	}

	public static ItemDef GetCachedItemDef(ItemType t)
	{
		if (cachedItemDefs.TryGetValue(t, out var value))
		{
			return value;
		}
		Debug.LogError("NO cached def for " + t);
		return new ItemDef(ItemType.None)
		{
			enabled = false
		};
	}

	public static HouseSellData GetOrCreateSellData(ItemType t)
	{
		if (houseSellData.TryGetValue(t, out var value))
		{
			return value;
		}
		value = new HouseSellData();
		value.AssignItem(t);
		houseSellData[t] = value;
		return value;
	}

	public static void SetUpgradeLimit(RecipeType upgradeRecipeType, int maxLevel)
	{
		if (!upgradeLevels.TryGetValue(upgradeRecipeType, out var value))
		{
			return;
		}
		if (maxLevel <= 1)
		{
			value.Clear();
			return;
		}
		int num = maxLevel - 1;
		int num2 = value.Count - num;
		if (num2 > 0)
		{
			value.RemoveRange(num, num2);
		}
	}

	public static int NumResourcesCultivatedBy(BuildingType t)
	{
		int num = 0;
		foreach (KeyValuePair<NaturalResource, NaturalResourceDef> item in naturalResourceCache)
		{
			if (item.Value.cultivationBuilding == t)
			{
				num++;
			}
		}
		return num;
	}

	public static List<BuildingType> SourcesOfItem(ItemType t)
	{
		if (derivedItemBuildingSources.TryGetValue(t, out var value))
		{
			return value;
		}
		return null;
	}

	public static List<RequirementId> RequirementsForEntity(EntityId id)
	{
		switch (id.type)
		{
		case EntityType.Building:
		{
			if (buildingCache.TryGetValue(id.AsBuilding, out var value4))
			{
				return value4.requirements;
			}
			break;
		}
		case EntityType.NaturalResource:
		{
			if (naturalResourceCache.TryGetValue(id.AsNaturalResource, out var value8))
			{
				return value8.requirements;
			}
			break;
		}
		case EntityType.Mining:
		{
			if (prospectingRecipeCache.TryGetValue(id.AsMining, out var value10))
			{
				return value10.requirements;
			}
			break;
		}
		case EntityType.Farming:
		{
			if (farmingRecipeCache.TryGetValue(id.AsFarming, out var value6))
			{
				return value6.requirements;
			}
			break;
		}
		case EntityType.HarvestRecipe:
		{
			if (harvestRecipeCache.TryGetValue(id.AsHarvestRecipe, out var value2))
			{
				return value2.requirements;
			}
			break;
		}
		case EntityType.Recipe:
		{
			if (recipeCache.TryGetValue(id.AsRecipe, out var value9))
			{
				return value9.requirements;
			}
			break;
		}
		case EntityType.Research:
		{
			if (researchCache.TryGetValue(id.AsResearch, out var value7))
			{
				return value7.RequirementsForLevel(0);
			}
			break;
		}
		case EntityType.Upgrade:
		{
			if (upgradeCache.TryGetValue(id.AsUpgrade, out var value5))
			{
				return value5.displayRequirements;
			}
			break;
		}
		case EntityType.Quest:
		{
			if (questCache.TryGetValue(id.AsQuest, out var value3))
			{
				return value3.displayRequirement;
			}
			break;
		}
		case EntityType.Perk:
		{
			if (perkDefCache.TryGetValue(id.AsPerk, out var value))
			{
				return value.requirements;
			}
			break;
		}
		}
		return null;
	}

	public static double SpecifiedXPValue(ItemType t)
	{
		if (cachedItemDefs.TryGetValue(t, out var value) && value.xpValue > 0.0)
		{
			return value.xpValue;
		}
		return 1.0;
	}
}
