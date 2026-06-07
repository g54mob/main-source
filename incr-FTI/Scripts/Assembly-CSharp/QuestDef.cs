using System.Collections.Generic;

public class QuestDef
{
	public QuestType type;

	public QuestGroup questGroup;

	public QuestCategory questCategory;

	private int idOffset;

	private int level;

	public List<RequirementId> completionRequirement = new List<RequirementId>();

	public List<RequirementId> displayRequirement = new List<RequirementId>();

	public readonly List<EntityLevel> explicitRewards = new List<EntityLevel>();

	public readonly List<EntityLevel> derivedRewards = new List<EntityLevel>();

	public ItemList rewardItems;

	public static int DynamicQuestIdOffset = 10000;

	public static int DynamicQuestLevelOffset = 100;

	private const int idOffsetMinigameWood = 0;

	private const int idOffsetMinigameMining = 1;

	private const int idOffsetMinigameFarming = 2;

	private const int idOffsetMinigameWater = 3;

	private const int idOffsetMinigameDice = 4;

	private const int idOffsetMinigameResearch = 5;

	public EntityId localizationEntity;

	public bool isDisabled;

	public bool isPermanentResearchUnlock;

	private const bool useLocalizationEntity = false;

	public QuestDef(QuestType t)
	{
		type = t;
		LoadDefaultQuest();
	}

	public QuestDef(QuestCategory questCategory, int idOffset, int level = 0)
	{
		type = Quest.DynamicQuestTypeFor(questCategory, idOffset, level);
		this.questCategory = questCategory;
		this.idOffset = idOffset;
		this.level = level;
		questGroup = GroupForDynamicCategory(questCategory);
	}

	public void LoadDefault()
	{
	}

	public static QuestGroup GroupForDynamicCategory(QuestCategory category)
	{
		return category switch
		{
			QuestCategory.MinigameUpgrades => QuestGroup.Minigame, 
			QuestCategory.MiningSkillUpgrades => QuestGroup.Upgrade, 
			QuestCategory.FarmingSkillUpgrades => QuestGroup.Upgrade, 
			QuestCategory.HarvestingSkillUpgrades => QuestGroup.Upgrade, 
			QuestCategory.BuildingConstructionSpeed => QuestGroup.Upgrade, 
			QuestCategory.ResearchSpeed => QuestGroup.Upgrade, 
			QuestCategory.HousingCost => QuestGroup.Upgrade, 
			QuestCategory.MarketConsumptionSpeed => QuestGroup.Upgrade, 
			QuestCategory.BuildingCounts => QuestGroup.Upgrade, 
			QuestCategory.SoldGoods => QuestGroup.Upgrade, 
			QuestCategory.SupportBuildingUpgrades => QuestGroup.Upgrade, 
			QuestCategory.StorageUpgrades => QuestGroup.Upgrade, 
			QuestCategory.SkillEffectUpgrades => QuestGroup.Upgrade, 
			QuestCategory.MarketCapacity => QuestGroup.Upgrade, 
			QuestCategory.SellSpeed => QuestGroup.Upgrade, 
			QuestCategory.BuildingProficiency => QuestGroup.Upgrade, 
			QuestCategory.SkillGainSpeed => QuestGroup.Upgrade, 
			QuestCategory.HousingCapacity => QuestGroup.Upgrade, 
			_ => QuestGroup.None, 
		};
	}

	public void LoadDefaultQuest()
	{
		switch (type)
		{
		case QuestType.WoodForHouse:
			completionRequirement.Add(new RequirementId(ItemType.Wood, 10.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.HouseForHarvesterHut:
			displayRequirement.Add(new RequirementId(QuestType.WoodForHouse));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.House));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.HarvesterHutForAssignWorkers:
			displayRequirement.Add(new RequirementId(QuestType.HouseForHarvesterHut));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.HarvesterHut));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.AssignWorkersForGeneralStore:
			displayRequirement.Add(new RequirementId(QuestType.HarvesterHutForAssignWorkers));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.HarvesterHut, 5.0));
			completionRequirement.Add(new RequirementId(RequirementType.WorkerAssignCount, Quest.NumWorkersToAssign));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.GeneralStoreForMarketPanel:
			displayRequirement.Add(new RequirementId(QuestType.AssignWorkersForGeneralStore));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.GeneralGoods));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.EarnCoinsForLumberMill:
			displayRequirement.Add(new RequirementId(QuestType.GeneralStoreForMarketPanel));
			completionRequirement.Add(new RequirementId(ItemType.YellowCoin, 200.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.LumberMillForCrafting:
			displayRequirement.Add(new RequirementId(QuestType.EarnCoinsForLumberMill));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.LumberMill));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.PlanksForGeneralStore:
			displayRequirement.Add(new RequirementId(QuestType.LumberMillForCrafting));
			completionRequirement.Add(new RequirementId(ItemType.Plank, 200.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneHouses10:
			displayRequirement.Add(new RequirementId(QuestType.GeneralStoreForMarketPanel));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.House, 10.0));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.HousesForSchool:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneHouses10));
			displayRequirement.Add(new RequirementId(QuestType.LumberMillForCrafting));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.House, 15.0));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.GrainForFoodMarket:
			displayRequirement.Add(new RequirementId(Quest.ResourceUnlockQuestGrain));
			completionRequirement.Add(new RequirementId(ItemType.Grain, 50.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.HarvestItemsForStockpile:
			displayRequirement.Add(new RequirementId(Quest.ResourceUnlockQuestRock));
			displayRequirement.Add(new RequirementId(QuestType.GeneralStoreForMarketPanel));
			completionRequirement.Add(new RequirementId(ItemType.Stone, 100.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.SchoolForResearchPanel:
			displayRequirement.Add(new RequirementId(QuestType.HousesForSchool));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.School));
			AddExplicitReward(EntityId.FromMenuPanel(MenuPanelType.Research));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.EarnRedCoins:
			displayRequirement.Add(new RequirementId(QuestType.SchoolForResearchPanel));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Workshop));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.HardwareStore));
			completionRequirement.Add(new RequirementId(ItemType.RedCoin, 500.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.PaperForBookstore:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForPaper));
			completionRequirement.Add(new RequirementId(ItemType.Paper, 500.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.WorkshopForHardwareStore:
			displayRequirement.Add(new RequirementId(ResearchType.Workshop));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Workshop));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TailorForClothingStore:
			displayRequirement.Add(new RequirementId(ResearchType.Tailor));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Tailor));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MedicineHutForHospital:
			displayRequirement.Add(new RequirementId(ResearchType.MedicineBasic));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.MedicineHut));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.JewelerForJewelryStore:
			displayRequirement.Add(new RequirementId(ResearchType.Jewelry));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Jeweler));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.HarvestManaForArcaneEmporium:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Magic, 0));
			completionRequirement.Add(new RequirementId(ItemType.Mana, 100.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 4f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.EarnBlueCoins:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Forest, 0));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.MedicineHut));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Apothecary));
			completionRequirement.Add(new RequirementId(ItemType.BlueCoin, 250.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.EarnPurpleCoins:
			displayRequirement.Add(new RequirementId(QuestType.HarvestManaForArcaneEmporium));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.ArcaneStore, 10.0));
			completionRequirement.Add(new RequirementId(ItemType.PurpleCoin, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.EarnOmniCoins:
			displayRequirement.Add(new RequirementId(ResearchType.BuildOmniTemple));
			completionRequirement.Add(new RequirementId(ItemType.OmniCoin, 100.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel2:
			displayRequirement.Add(new RequirementId(QuestType.LumberMillForCrafting));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(2));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel3:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel2));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(3));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel4:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel3));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(4));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel5:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel4));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(5));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel6:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel5));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(6));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel7:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel6));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(7));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			AddExplicitReward(EntityId.FromItem(ItemType.UtilityPrioritization));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel8:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel7));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(8));
			AddRewardItem(ItemType.UtilityQuestCoin, 4f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel9:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel8));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(9));
			AddRewardItem(ItemType.UtilityQuestCoin, 4f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel10:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel9));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(10));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			AddExplicitReward(EntityId.FromItem(ItemType.UtilityAutoAssign));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel11:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel10));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(11));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel12:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel11));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(12));
			AddRewardItem(ItemType.UtilityQuestCoin, 6f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel13:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel12));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(13));
			AddRewardItem(ItemType.UtilityQuestCoin, 6f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel14:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel13));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(14));
			AddRewardItem(ItemType.UtilityQuestCoin, 6f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneTownLevel15:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel14));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(15));
			AddRewardItem(ItemType.UtilityQuestCoin, 8f);
			AddExplicitReward(EntityId.FromMenuPanel(MenuPanelType.World));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneRiverLevelForForest:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.River, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(20, BiomeType.River));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			AddExplicitReward(EntityId.FromBiome(BiomeType.Forest));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneForestLevelForMountains:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Forest, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(20, BiomeType.Forest));
			AddRewardItem(ItemType.UtilityQuestCoin, 15f);
			AddExplicitReward(EntityId.FromBiome(BiomeType.Mountains));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneMountainLevelForJungle:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Mountains, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(20, BiomeType.Mountains));
			AddRewardItem(ItemType.UtilityQuestCoin, 15f);
			AddExplicitReward(EntityId.FromBiome(BiomeType.Jungle));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneJungleLevelForDesert:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Jungle, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(20, BiomeType.Jungle));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			AddExplicitReward(EntityId.FromBiome(BiomeType.Desert));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneDesertLevelForSnow:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Desert, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(20, BiomeType.Desert));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			AddExplicitReward(EntityId.FromBiome(BiomeType.Snow));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneSnowLevelForMagic:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Snow, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(20, BiomeType.Snow));
			AddRewardItem(ItemType.UtilityQuestCoin, 50f);
			AddExplicitReward(EntityId.FromBiome(BiomeType.Magic));
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.IdleRewardsPlains:
			displayRequirement.Add(new RequirementId(Quest.UnlockWorldPanel));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(20, BiomeType.Plains));
			AddRewardItem(ItemType.UtilityIdleRewardBoost, 1f);
			AddRewardItem(ItemType.UtilityQuestCoin, 4f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.IdleRewardsRiver:
			displayRequirement.Add(RequirementId.RequiredTownLevelGlobal(0, BiomeType.River));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(22, BiomeType.River));
			AddRewardItem(ItemType.UtilityIdleRewardBoost, 1f);
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.IdleRewardsForest:
			displayRequirement.Add(RequirementId.RequiredTownLevelGlobal(0, BiomeType.Forest));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(22, BiomeType.Forest));
			AddRewardItem(ItemType.UtilityIdleRewardBoost, 1f);
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.IdleRewardsMountians:
			displayRequirement.Add(RequirementId.RequiredTownLevelGlobal(0, BiomeType.Mountains));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(25, BiomeType.Mountains));
			AddRewardItem(ItemType.UtilityIdleRewardBoost, 1f);
			AddRewardItem(ItemType.UtilityQuestCoin, 6f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.IdleRewardsJungle:
			displayRequirement.Add(RequirementId.RequiredTownLevelGlobal(0, BiomeType.Jungle));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(25, BiomeType.Jungle));
			AddRewardItem(ItemType.UtilityIdleRewardBoost, 1f);
			AddRewardItem(ItemType.UtilityQuestCoin, 6f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.IdleRewardsSnow:
			displayRequirement.Add(RequirementId.RequiredTownLevelGlobal(0, BiomeType.Snow));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(28, BiomeType.Snow));
			AddRewardItem(ItemType.UtilityIdleRewardBoost, 1f);
			AddRewardItem(ItemType.UtilityQuestCoin, 8f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.IdleRewardsDesert:
			displayRequirement.Add(RequirementId.RequiredTownLevelGlobal(0, BiomeType.Desert));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(28, BiomeType.Desert));
			AddRewardItem(ItemType.UtilityIdleRewardBoost, 1f);
			AddRewardItem(ItemType.UtilityQuestCoin, 8f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.IdleRewardsMagic:
			displayRequirement.Add(RequirementId.RequiredTownLevelGlobal(0, BiomeType.Magic));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(30, BiomeType.Magic));
			AddRewardItem(ItemType.UtilityIdleRewardBoost, 1f);
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TownLevelForPlainsUniversity:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneTownLevel15));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(35, BiomeType.Plains));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TownLevelForForestMonastery:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneForestLevelForMountains));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(35, BiomeType.Forest));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TownLevelForRiverHarbor:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneRiverLevelForForest));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(35, BiomeType.River));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TownLevelForMountainObservatory:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneMountainLevel10));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(35, BiomeType.Mountains));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TownLevelForJunglePyramid:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneJungleLevelForDesert));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(35, BiomeType.Jungle));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TownLevelForDesertBazaar:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneDesertLevel10));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(35, BiomeType.Desert));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TownLevelForSnowTreasureVault:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneSnowLevel10));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(35, BiomeType.Snow));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TownLevelForMagicObelisk:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Magic, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(35, BiomeType.Magic));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneJungleLevel10:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Jungle, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(10, BiomeType.Jungle));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneAnyTownLevel40:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Magic, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(40));
			AddRewardItem(ItemType.UtilityQuestCoin, 100f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneAnyTownLevel50:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Magic, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(50));
			AddRewardItem(ItemType.UtilityQuestCoin, 1000f);
			AddRewardItem(ItemType.UtilityVictory, 0f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneMountainLevel10:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Mountains, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(10, BiomeType.Mountains));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneDesertLevel10:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Desert, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(10, BiomeType.Desert));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBuildSolarPanel:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Desert, 0));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.SolarPanel));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneSnowLevel10:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Snow, 0));
			completionRequirement.Add(RequirementId.RequiredTownLevelGlobal(10, BiomeType.Snow));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.UnlockYellowCoinXP:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneMountainLevel10));
			completionRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Mountains, 20));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.UnlockRedCoinXP:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneDesertLevel10));
			completionRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Desert, 22));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.UnlockBlueCoinXP:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneSnowLevel10));
			completionRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Snow, 24));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.UnlockPurpleCoinXP:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneJungleLevel10));
			displayRequirement.Add(new RequirementId(QuestType.HarvestManaForArcaneEmporium));
			completionRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Jungle, 28));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.UnlockOmniCoinXP:
			displayRequirement.Add(new RequirementId(QuestType.EarnOmniCoins));
			completionRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Magic, 30));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.OmnitempleForAutoClaim:
			displayRequirement.Add(new RequirementId(ResearchType.BuildOmniTemple));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.OmniTemple));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			AddExplicitReward(EntityId.FromItem(ItemType.UtilityAutoClaim));
			break;
		case QuestType.DiscoverBerries:
			ConfigureResourceDiscoveryQuest(NaturalResource.BerryBush, BiomeType.Forest, 5);
			break;
		case QuestType.DiscoverPear:
			ConfigureResourceDiscoveryQuest(NaturalResource.PearTree, BiomeType.Forest, 7);
			break;
		case QuestType.DiscoverSugar:
			ConfigureResourceDiscoveryQuest(NaturalResource.SugarCane, BiomeType.River, 5);
			break;
		case QuestType.DiscoverTomato:
			ConfigureResourceDiscoveryQuest(NaturalResource.TomatoPlant, BiomeType.River, 7);
			break;
		case QuestType.MilestoneBuildFoodMill:
			displayRequirement.Add(new RequirementId(ResearchType.FoodMill));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.GrainMill));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBuildStoneMason:
			displayRequirement.Add(new RequirementId(ResearchType.StoneMason));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.StoneMason));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.FlourForAnimalFeed:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildFoodMill));
			completionRequirement.Add(new RequirementId(ItemType.Flour, 2000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.StoneBricksForRefinedStoneBricks:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildStoneMason));
			completionRequirement.Add(new RequirementId(ItemType.StoneSlab, 5000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.RefinedStoneBricksForQuartz:
			displayRequirement.Add(new RequirementId(QuestType.StoneBricksForRefinedStoneBricks));
			completionRequirement.Add(new RequirementId(ItemType.RefinedStoneBrick, 50000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBuildForester:
			displayRequirement.Add(new RequirementId(ResearchType.Forestry));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Forester));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBuildFarm:
			displayRequirement.Add(new RequirementId(ResearchType.Farming));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Farm));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBuildMine:
			displayRequirement.Add(new RequirementId(ResearchType.Mining));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Mine));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.QuarryForProspectingPanel:
			displayRequirement.Add(new RequirementId(ResearchType.Quarry));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Quarry));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.PlanksForRefinedPlank:
			displayRequirement.Add(new RequirementId(QuestType.PlanksForGeneralStore));
			completionRequirement.Add(new RequirementId(ItemType.Plank, 2500.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.SkillsForPaper:
			displayRequirement.Add(new RequirementId(NaturalResource.WaterSource));
			completionRequirement.Add(new RequirementId(ItemType.RefinedPlank, 1000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.IronIngotForWoodAxe:
			displayRequirement.Add(new RequirementId(ResearchType.Forge));
			completionRequirement.Add(new RequirementId(ItemType.IronIngot, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.WoodAxeForPickaxe:
			displayRequirement.Add(new RequirementId(QuestType.IronIngotForWoodAxe));
			displayRequirement.Add(new RequirementId(QuestType.PlanksForRefinedPlank));
			completionRequirement.Add(new RequirementId(ItemType.WoodAxe, 25000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.RefinedPlank, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForMagicShirt:
			displayRequirement.Add(new RequirementId(ResearchType.MagicClothing));
			completionRequirement.Add(new RequirementId(ItemType.Outfit, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.PurifiedMana, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForRubyRing:
			displayRequirement.Add(new RequirementId(Quest.ResourceUnlockQuestRuby));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForGoldJewelry));
			displayRequirement.Add(new RequirementId(ResearchType.GemJewelry));
			completionRequirement.Add(new RequirementId(ItemType.RedRuby, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.GoldRing, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForSapphireRing:
			displayRequirement.Add(new RequirementId(Quest.ResourceUnlockQuestSapphire));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForSilverJewelry));
			displayRequirement.Add(new RequirementId(ResearchType.GemJewelry));
			completionRequirement.Add(new RequirementId(ItemType.BlueSapphire, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.SilverRing, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForAmethystNecklace:
			displayRequirement.Add(new RequirementId(Quest.ResourceUnlockQuestAmethyst));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForSilverJewelry));
			displayRequirement.Add(new RequirementId(ResearchType.GemJewelry));
			completionRequirement.Add(new RequirementId(ItemType.PurpleAmethyst, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.SilverChain, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForTopazCrown:
			displayRequirement.Add(new RequirementId(Quest.ResourceUnlockQuestTopaz));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForGoldJewelry));
			displayRequirement.Add(new RequirementId(ResearchType.GemJewelry));
			completionRequirement.Add(new RequirementId(ItemType.YellowTopaz, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.GoldCrown, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForMagicRing:
			displayRequirement.Add(new RequirementId(ResearchType.MagicJewelry));
			completionRequirement.Add(new RequirementId(ItemType.PolishedStoneRing, 20000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.PurifiedMana, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForFireRing:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForRubyRing));
			displayRequirement.Add(new RequirementId(ResearchType.PurifiedFirePower));
			displayRequirement.Add(new RequirementId(ResearchType.MagicJewelry));
			completionRequirement.Add(new RequirementId(ItemType.RubyRing, 20000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.PurifiedFire, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForWaterRing:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForSapphireRing));
			displayRequirement.Add(new RequirementId(ResearchType.PurifiedWaterPower));
			displayRequirement.Add(new RequirementId(ResearchType.MagicJewelry));
			completionRequirement.Add(new RequirementId(ItemType.SapphireRing, 20000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.PurifiedWater, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForEnchantedNecklace:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForAmethystNecklace));
			displayRequirement.Add(new RequirementId(ResearchType.PurifiedEarthPower));
			displayRequirement.Add(new RequirementId(ResearchType.MagicJewelry));
			completionRequirement.Add(new RequirementId(ItemType.AmethystNecklace, 20000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.PurifiedEarth, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForEnchantedCrown:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForTopazCrown));
			displayRequirement.Add(new RequirementId(ResearchType.PurifiedAirPower));
			displayRequirement.Add(new RequirementId(ResearchType.MagicJewelry));
			completionRequirement.Add(new RequirementId(ItemType.TopazCrown, 20000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.PurifiedAir, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForMagicCloak:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForCloak));
			displayRequirement.Add(new RequirementId(ResearchType.MagicClothing));
			displayRequirement.Add(new RequirementId(ResearchType.PurifiedFirePower));
			completionRequirement.Add(new RequirementId(ItemType.Cloak, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.UtilityElementalFirePower, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForMagicPants:
			displayRequirement.Add(new RequirementId(QuestType.ShirtSkillForPants));
			displayRequirement.Add(new RequirementId(QuestType.BeefSkillForLeather));
			displayRequirement.Add(new RequirementId(ResearchType.MagicClothing));
			displayRequirement.Add(new RequirementId(ResearchType.PurifiedWaterPower));
			completionRequirement.Add(new RequirementId(ItemType.Pants, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.UtilityElementalWaterPower, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForMagicBoots:
			displayRequirement.Add(new RequirementId(QuestType.ShoeSkillForBoots));
			displayRequirement.Add(new RequirementId(ResearchType.MagicClothing));
			displayRequirement.Add(new RequirementId(ResearchType.PurifiedEarthPower));
			completionRequirement.Add(new RequirementId(ItemType.Boots, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.UtilityElementalEarthPower, 20000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForMagicHat:
			displayRequirement.Add(new RequirementId(QuestType.WoolClothSkillForHat));
			displayRequirement.Add(new RequirementId(QuestType.BeefSkillForLeather));
			displayRequirement.Add(new RequirementId(ResearchType.MagicClothing));
			displayRequirement.Add(new RequirementId(ResearchType.PurifiedAirPower));
			completionRequirement.Add(new RequirementId(ItemType.Hat, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.UtilityElementalAirPower, 50000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForSilverJewelry:
			displayRequirement.Add(new RequirementId(ResearchType.Jewelry));
			displayRequirement.Add(new RequirementId(NaturalResource.SilverOre));
			completionRequirement.Add(new RequirementId(ItemType.SilverIngot, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForGoldJewelry:
			displayRequirement.Add(new RequirementId(ResearchType.Jewelry));
			displayRequirement.Add(new RequirementId(NaturalResource.GoldOre));
			completionRequirement.Add(new RequirementId(ItemType.GoldIngot, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.HarvestCottonForTailorResearch:
			displayRequirement.Add(new RequirementId(NaturalResource.CottonPlant));
			displayRequirement.Add(new RequirementId(QuestType.SchoolForResearchPanel));
			completionRequirement.Add(new RequirementId(ItemType.Cotton, 5000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBuildHearth:
			displayRequirement.Add(new RequirementId(ResearchType.StoneMason));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Hearth));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBuildBakery:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildHearth));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Bakery));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBuildPasture:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildFarm));
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildFoodMill));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Pasture));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneCooking:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildBakery));
			displayRequirement.Add(new RequirementId(Quest.UnlockWorldPanel));
			completionRequirement.Add(new RequirementId(ItemType.Bread, 1000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.CookedBeef, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.FishCooked, 800.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.CookedChicken, 600.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.GourmetKitchenForFancyFoodsStore:
			displayRequirement.Add(new RequirementId(QuestType.SugarForRefinedSugar));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.GourmetKitchen));
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneJamGourmet:
			displayRequirement.Add(new RequirementId(QuestType.AppleJuiceSkillsForJam));
			displayRequirement.Add(new RequirementId(QuestType.PearJuiceSkillsForJam));
			displayRequirement.Add(new RequirementId(QuestType.BerryJuiceSkillsForJam));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForCactusJam));
			completionRequirement.Add(new RequirementId(ItemType.Jam, 25000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.BerryJam, 25000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.PearJam, 25000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.CactusJam, 25000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneStewGourmet:
			displayRequirement.Add(new RequirementId(QuestType.GourmetKitchenForFancyFoodsStore));
			displayRequirement.Add(new RequirementId(QuestType.CookedBeefSkillsForBeefStew));
			displayRequirement.Add(new RequirementId(QuestType.CookedFishSkillsForFishStew));
			completionRequirement.Add(new RequirementId(ItemType.VeggieStew, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.FishStew, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.MeatStew, 500.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneDessertGourmet:
			displayRequirement.Add(new RequirementId(QuestType.CakeSkillsForBerryCake));
			completionRequirement.Add(new RequirementId(ItemType.Cake, 1000000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.BerryCake, 10000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneBasicJewelry:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForCopperRing));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForSilverJewelry));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForGoldJewelry));
			completionRequirement.Add(new RequirementId(ItemType.CopperRing, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.SilverRing, 30000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.GoldRing, 10000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 4f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneGemJewelry:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForRubyRing));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForSapphireRing));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForAmethystNecklace));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForTopazCrown));
			completionRequirement.Add(new RequirementId(ItemType.RubyRing, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.SapphireRing, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.AmethystNecklace, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.TopazCrown, 500.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 8f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneMagicJewelry:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForFireRing));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForWaterRing));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForEnchantedNecklace));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForEnchantedCrown));
			completionRequirement.Add(new RequirementId(ItemType.EnchantedFireRing, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.EnchantedWaterRing, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.EnchantedEarthNecklace, 500.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.EnchantedAirCrown, 500.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneSpellbooks:
			displayRequirement.Add(new RequirementId(ResearchType.Enchanting));
			displayRequirement.Add(new RequirementId(ResearchType.ManaTransmitter));
			completionRequirement.Add(new RequirementId(ItemType.EnchantedBookRed, 100.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.EnchantedBookYellow, 100.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.EnchantedBookBlue, 100.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.EnchantedBookPurple, 100.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.CopperSkillForWire:
			displayRequirement.Add(new RequirementId(ResearchType.Machinery));
			displayRequirement.Add(new RequirementId(NaturalResource.CopperOre));
			completionRequirement.Add(new RequirementId(ItemType.CopperIngot, 50000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.AppleJuiceSkillsForJam:
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			displayRequirement.Add(new RequirementId(QuestType.SugarForRefinedSugar));
			completionRequirement.Add(new RequirementId(ItemType.FruitJuice, 10000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.RefinedSugar, 5000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.PearJuiceSkillsForJam:
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			displayRequirement.Add(new RequirementId(QuestType.SugarForRefinedSugar));
			completionRequirement.Add(new RequirementId(ItemType.PearJuice, 10000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.RefinedSugar, 5000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.BerryJuiceSkillsForJam:
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			displayRequirement.Add(new RequirementId(QuestType.SugarForRefinedSugar));
			completionRequirement.Add(new RequirementId(ItemType.BerryJuice, 10000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.RefinedSugar, 5000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Recipe;
			break;
		case QuestType.SkillsForCactusJam:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Desert, 0));
			displayRequirement.Add(new RequirementId(QuestType.SugarForRefinedSugar));
			completionRequirement.Add(new RequirementId(ItemType.CactusFruit, 100000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.SkillsForDragonPunch:
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			displayRequirement.Add(new RequirementId(NaturalResource.BerryBush));
			displayRequirement.Add(new RequirementId(NaturalResource.AppleTree));
			displayRequirement.Add(new RequirementId(NaturalResource.DragonFruitTree));
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Jungle, 0));
			completionRequirement.Add(new RequirementId(ItemType.DragonFruit, 5000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.BerryJuice, 25000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.FruitJuice, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			break;
		case QuestType.SkillsForCake:
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			completionRequirement.Add(new RequirementId(ItemType.Flour, 100000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.RefinedSugar, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Butter, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.CakeSkillsForBerryCake:
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			displayRequirement.Add(new RequirementId(NaturalResource.BerryBush));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForCake));
			displayRequirement.Add(new RequirementId(QuestType.AppleJuiceSkillsForJam));
			completionRequirement.Add(new RequirementId(ItemType.RefinedSugar, 100000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Jam, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Berries, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Cake, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			break;
		case QuestType.CookedFishSkillsForFishStew:
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.River, 0));
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			displayRequirement.Add(new RequirementId(QuestType.MilkSkillForButter));
			completionRequirement.Add(new RequirementId(ItemType.FishCooked, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Butter, 20000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			break;
		case QuestType.CookedBeefSkillsForBeefStew:
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Snow, 0));
			displayRequirement.Add(RequirementId.BiomeTownLevel(BiomeType.Mountains, 0));
			completionRequirement.Add(new RequirementId(ItemType.CookedBeef, 50000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			break;
		case QuestType.CookedChickenSkillsForSandwich:
			displayRequirement.Add(new RequirementId(ResearchType.GourmetKitchen));
			completionRequirement.Add(new RequirementId(ItemType.Bread, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.CookedChicken, 25000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Cheese, 10000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			break;
		case QuestType.MilkSkillForButter:
			displayRequirement.Add(new RequirementId(QuestType.MilkSkillForBeef));
			completionRequirement.Add(new RequirementId(ItemType.Milk, 50000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.CottonClothSkillForShirt:
			displayRequirement.Add(new RequirementId(QuestType.TailorForClothingStore));
			completionRequirement.Add(new RequirementId(ItemType.CottonCloth, 10000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.ShirtSkillForPants:
			displayRequirement.Add(new RequirementId(QuestType.CottonClothSkillForShirt));
			completionRequirement.Add(new RequirementId(ItemType.Outfit, 10000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.SkillsForCopperRing:
			displayRequirement.Add(new RequirementId(NaturalResource.CopperOre));
			displayRequirement.Add(new RequirementId(ResearchType.Jewelry));
			completionRequirement.Add(new RequirementId(ItemType.CopperIngot, 50000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.SkillsForFishOil:
			displayRequirement.Add(new RequirementId(NaturalResource.FishSource));
			displayRequirement.Add(new RequirementId(ResearchType.MedicineBasic));
			completionRequirement.Add(new RequirementId(ItemType.Fish, 50000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.SkillsForShoe:
			displayRequirement.Add(new RequirementId(ResearchType.Tailor));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForNails));
			displayRequirement.Add(new RequirementId(QuestType.BeefSkillForLeather));
			completionRequirement.Add(new RequirementId(ItemType.Leather, 50000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Nails, 50000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.SkillsForNails:
			displayRequirement.Add(new RequirementId(ResearchType.Forge));
			completionRequirement.Add(new RequirementId(ItemType.IronIngot, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.SkillsForReinforcedPlank:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForNails));
			completionRequirement.Add(new RequirementId(ItemType.Nails, 10000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			break;
		case QuestType.SkillsForSteamPipe:
			displayRequirement.Add(new RequirementId(BuildingType.MachineShop));
			completionRequirement.Add(new RequirementId(ItemType.IronWheel, 10000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 3f);
			break;
		case QuestType.SugarForRefinedSugar:
			displayRequirement.Add(new RequirementId(ResearchType.FoodMill));
			displayRequirement.Add(new RequirementId(QuestType.DiscoverSugar));
			completionRequirement.Add(new RequirementId(ItemType.Sugar, 10000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.ShoeSkillForBoots:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForShoe));
			completionRequirement.Add(new RequirementId(ItemType.Shoe, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.WoolClothSkillForHat:
			displayRequirement.Add(new RequirementId(QuestType.WoolSkillForWoolCloth));
			completionRequirement.Add(new RequirementId(ItemType.WoolCloth, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.SkillsForWarmCoat:
			displayRequirement.Add(new RequirementId(QuestType.WoolSkillForWoolCloth));
			displayRequirement.Add(new RequirementId(QuestType.BeefSkillForLeather));
			displayRequirement.Add(new RequirementId(ResearchType.Tailor));
			completionRequirement.Add(new RequirementId(ItemType.WoolCloth, 10000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Leather, 8000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.SkillsForCloak:
			displayRequirement.Add(new RequirementId(QuestType.BeefSkillForLeather));
			displayRequirement.Add(new RequirementId(ResearchType.Tailor));
			completionRequirement.Add(new RequirementId(ItemType.CottonCloth, 25000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Leather, 10000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.PaperSkillsForBook:
			displayRequirement.Add(new RequirementId(QuestType.SkillsForPaper));
			completionRequirement.Add(new RequirementId(ItemType.Paper, 5000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.WoolSkillForWoolCloth:
			displayRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Pasture));
			completionRequirement.Add(new RequirementId(ItemType.Wool, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.EggSkillForChicken:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildPasture));
			completionRequirement.Add(new RequirementId(ItemType.Egg, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.MilkSkillForBeef:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildPasture));
			completionRequirement.Add(new RequirementId(ItemType.Milk, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.BeefSkillForLeather:
			displayRequirement.Add(new RequirementId(QuestType.MilkSkillForBeef));
			displayRequirement.Add(new RequirementId(QuestType.MilestoneBuildPasture));
			completionRequirement.Add(new RequirementId(ItemType.RawBeef, 25000.0, global: true));
			questGroup = QuestGroup.Recipe;
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			break;
		case QuestType.ResearchForUpgrades:
			displayRequirement.Add(new RequirementId(QuestType.SchoolForResearchPanel));
			completionRequirement.Add(RequirementId.ResearchCount(5, global: true));
			AddExplicitReward(EntityId.FromMenuPanel(MenuPanelType.Upgrades));
			questGroup = QuestGroup.Primary;
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			break;
		case QuestType.MilestoneUpgrades10:
			displayRequirement.Add(new RequirementId(QuestType.ResearchForUpgrades));
			completionRequirement.Add(new RequirementId(RequirementType.TotalUpgradeCount, 10.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneStarCoins100:
			displayRequirement.Add(new RequirementId(ResearchType.BuildOmniTemple));
			completionRequirement.Add(new RequirementId(ItemType.Star, 100.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 10f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneStarCoins1000:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneStarCoins100));
			completionRequirement.Add(new RequirementId(ItemType.Star, 1000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 15f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneStarCoins10000:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneStarCoins1000));
			completionRequirement.Add(new RequirementId(ItemType.Star, 10000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 20f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MilestoneStarCoins100000:
			displayRequirement.Add(new RequirementId(QuestType.MilestoneStarCoins10000));
			completionRequirement.Add(new RequirementId(ItemType.Star, 100000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 25f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.SecondTownForTradingPost:
			displayRequirement.Add(new RequirementId(Quest.UnlockWorldPanel));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.Base, 2.0));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TradingPostForTradingPanel:
			displayRequirement.Add(new RequirementId(QuestType.SecondTownForTradingPost));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.TradingPost));
			AddRewardItem(ItemType.UtilityQuestCoin, 1f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.TradingPostsForCaravan:
			displayRequirement.Add(new RequirementId(QuestType.TradingPostForTradingPanel));
			completionRequirement.Add(RequirementId.RequiredGlobalBuildingCount(BuildingType.TradingPost, 50.0));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.SteamPipeForSteamPipeline:
			displayRequirement.Add(new RequirementId(QuestType.TradingPostForTradingPanel));
			displayRequirement.Add(new RequirementId(QuestType.SkillsForSteamPipe));
			displayRequirement.Add(new RequirementId(ResearchType.SteamBoiler));
			completionRequirement.Add(new RequirementId(ItemType.SteamPipe, 25000.0, global: true));
			completionRequirement.Add(new RequirementId(ItemType.Steam, 25000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.MagmaPipeForMagmaPipeline:
			displayRequirement.Add(new RequirementId(QuestType.TradingPostForTradingPanel));
			displayRequirement.Add(new RequirementId(ResearchType.MagmaPipe));
			completionRequirement.Add(new RequirementId(ItemType.MagmaPipe, 25000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 4f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.CopperWireForPowerLines:
			displayRequirement.Add(new RequirementId(QuestType.TradingPostForTradingPanel));
			displayRequirement.Add(new RequirementId(QuestType.CopperSkillForWire));
			completionRequirement.Add(new RequirementId(ItemType.CopperWire, 25000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 2f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.ManaPipeForManaPipeline:
			displayRequirement.Add(new RequirementId(QuestType.TradingPostForTradingPanel));
			displayRequirement.Add(new RequirementId(ResearchType.ManaPipe));
			completionRequirement.Add(new RequirementId(ItemType.ManaPipe, 25000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 5f);
			questGroup = QuestGroup.Primary;
			break;
		case QuestType.OmniPipeForOmniPipeline:
			displayRequirement.Add(new RequirementId(QuestType.TradingPostForTradingPanel));
			displayRequirement.Add(new RequirementId(ResearchType.OmniPipe));
			completionRequirement.Add(new RequirementId(ItemType.OmniPipe, 25000.0, global: true));
			AddRewardItem(ItemType.UtilityQuestCoin, 25f);
			questGroup = QuestGroup.Primary;
			break;
		case (QuestType)4:
		case (QuestType)5:
		case (QuestType)6:
		case (QuestType)11:
		case (QuestType)12:
		case (QuestType)13:
		case (QuestType)14:
		case (QuestType)15:
		case (QuestType)16:
		case (QuestType)17:
		case (QuestType)18:
		case (QuestType)19:
		case (QuestType)20:
		case (QuestType)21:
		case (QuestType)22:
		case (QuestType)23:
		case (QuestType)24:
		case (QuestType)25:
		case (QuestType)29:
		case (QuestType)30:
		case (QuestType)31:
		case (QuestType)32:
		case (QuestType)33:
		case (QuestType)34:
		case (QuestType)35:
		case (QuestType)36:
		case (QuestType)39:
		case (QuestType)40:
		case (QuestType)41:
		case (QuestType)43:
		case (QuestType)44:
		case (QuestType)45:
		case (QuestType)46:
		case (QuestType)47:
		case (QuestType)50:
		case (QuestType)51:
		case (QuestType)52:
		case (QuestType)53:
		case (QuestType)54:
		case (QuestType)55:
		case (QuestType)63:
		case QuestType.MilestoneRefinedItemSkill:
		case (QuestType)65:
		case (QuestType)66:
		case (QuestType)67:
		case (QuestType)68:
		case (QuestType)69:
		case (QuestType)70:
		case (QuestType)71:
		case (QuestType)72:
		case (QuestType)73:
		case (QuestType)76:
		case (QuestType)77:
		case (QuestType)78:
		case (QuestType)81:
		case (QuestType)82:
		case (QuestType)83:
		case (QuestType)84:
		case (QuestType)85:
		case (QuestType)86:
		case (QuestType)87:
		case (QuestType)88:
		case (QuestType)89:
		case (QuestType)90:
		case (QuestType)96:
		case (QuestType)97:
		case (QuestType)98:
		case (QuestType)99:
		case (QuestType)100:
		case (QuestType)101:
		case (QuestType)102:
		case (QuestType)103:
		case (QuestType)104:
		case (QuestType)105:
		case (QuestType)106:
		case (QuestType)107:
		case (QuestType)112:
		case (QuestType)113:
		case (QuestType)114:
		case (QuestType)116:
		case (QuestType)117:
		case (QuestType)118:
		case (QuestType)119:
		case (QuestType)120:
		case (QuestType)121:
		case (QuestType)122:
		case (QuestType)124:
		case (QuestType)126:
		case (QuestType)127:
		case (QuestType)130:
		case (QuestType)131:
		case (QuestType)132:
		case (QuestType)133:
		case (QuestType)134:
		case (QuestType)135:
		case (QuestType)136:
		case (QuestType)137:
		case (QuestType)138:
		case (QuestType)139:
		case (QuestType)140:
		case (QuestType)141:
		case (QuestType)142:
		case (QuestType)143:
		case (QuestType)144:
		case (QuestType)145:
		case (QuestType)146:
		case (QuestType)147:
		case (QuestType)148:
		case (QuestType)149:
		case (QuestType)150:
		case (QuestType)151:
		case (QuestType)154:
		case (QuestType)156:
		case (QuestType)157:
		case (QuestType)158:
		case (QuestType)159:
		case (QuestType)182:
		case (QuestType)183:
		case (QuestType)188:
		case (QuestType)198:
		case (QuestType)199:
		case (QuestType)202:
		case (QuestType)203:
		case (QuestType)204:
		case (QuestType)207:
		case (QuestType)208:
		case (QuestType)209:
		case (QuestType)215:
		case (QuestType)216:
		case (QuestType)217:
		case (QuestType)218:
		case (QuestType)220:
		case (QuestType)221:
		case (QuestType)222:
		case (QuestType)223:
		case (QuestType)224:
		case (QuestType)225:
		case (QuestType)227:
		case (QuestType)238:
		case (QuestType)246:
		case (QuestType)247:
		case (QuestType)250:
		case (QuestType)251:
		case (QuestType)252:
		case (QuestType)253:
		case (QuestType)254:
		case (QuestType)255:
		case (QuestType)256:
		case (QuestType)257:
		case (QuestType)264:
			break;
		}
	}

	private void AddExplicitReward(EntityId t)
	{
		explicitRewards.Add(new EntityLevel(t, 0));
		derivedRewards.Add(new EntityLevel(t, 0));
	}

	public void AddRewardItem(ItemType t, float amount)
	{
		if (t != ItemType.TownExperiencePoint)
		{
			if (rewardItems == null)
			{
				rewardItems = new ItemList();
			}
			rewardItems.AddItem(t, amount);
		}
	}

	public void ConfigureMinigameLevelQuest(MenuPanelType panelType, int idOffset, int index)
	{
		if (index > 0)
		{
			QuestType t = Quest.DynamicQuestTypeFor(QuestCategory.MinigameUpgrades, idOffset, index - 1);
			displayRequirement.Add(new RequirementId(t));
		}
		int num = (index + 1) * 5;
		completionRequirement.Add(new RequirementId(panelType, num));
		AddRewardItem(ItemType.UtilityQuestCoin, index + 1);
		questGroup = QuestGroup.Minigame;
	}

	private void ConfigureResourceDiscoveryQuest(NaturalResource r, BiomeType b, int townLevel)
	{
		displayRequirement.Add(RequirementId.BiomeTownLevel(b, 0));
		completionRequirement.Add(RequirementId.BiomeTownLevel(b, townLevel));
		AddRewardItem(ItemType.UtilityQuestCoin, 1f);
		questGroup = QuestGroup.Primary;
	}
}
