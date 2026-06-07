using System.Collections.Generic;

public class Research
{
	private const bool requireUnlockedInputs = false;

	public ResearchType type;

	public readonly List<List<RequirementId>> requirementFixedCache = new List<List<RequirementId>>();

	private readonly List<ItemList> levelInputs = new List<ItemList>();

	public readonly List<EntityLevel> reward = new List<EntityLevel>();

	public float craftingTime;

	public int maxLevel;

	public float costScaleValue;

	public float timeScaleValue;

	public bool enabled;

	public float maxWorkers;

	public DynamicResearchType dynamicType;

	public int dynamicIndex;

	public EntityId localizationEntity;

	public string overrideLocalizationKey;

	public int overrideLocalizationLevel;

	public int metadataFlag;

	private const float craftingTime1 = 120f;

	private const float craftingTime2 = 300f;

	private const float craftingTime3 = 600f;

	private const float craftingTime4 = 1800f;

	private const float craftingTime5 = 7200f;

	private const float craftingTime6 = 28800f;

	private const float craftingTime7 = 86400f;

	private const float craftingTime8 = 432000f;

	private const float craftingTime9 = 1728000f;

	private const float craftingTime9a = 3456000f;

	private const float craftingTime10 = 5184000f;

	private const float starCoinAmount = 1000f;

	private const float InfiniteResearchCostTomeGeneral = 10000f;

	private const float InfiniteResearchCostTomeIndustry = 5000f;

	private const float InfiniteResearchCostTomeMagic = 2500f;

	private const float InfiniteResearchCostYellow = 40000f;

	private const float InfiniteResearchCostRed = 30000f;

	private const float InfiniteResearchCostBlue = 20000f;

	private const float InfiniteResearchCostPurple = 10000f;

	private const bool useBooksInInfinite = false;

	private static GameManager gm => GameManager.Instance;

	public bool isInfiniteResearch => maxLevel == int.MaxValue;

	public bool isLeveledResearch => maxLevel > 1;

	public bool isLevelCostSpecified => levelInputs.Count > 1;

	public Research(ResearchType t)
	{
		type = t;
	}

	public void LoadDefaultResearch()
	{
		enabled = true;
		maxLevel = 1;
		timeScaleValue = 1f;
		costScaleValue = 3.16f;
		switch (type)
		{
		case ResearchType.Workshop:
			AddInput(ItemType.Plank, 100.0);
			AddInput(ItemType.YellowCoin, 1000.0);
			craftingTime = 30f;
			AddRequirement(new RequirementId(ItemType.Wood));
			localizationEntity = EntityId.FromBuilding(BuildingType.Workshop);
			break;
		case ResearchType.StoneMason:
			AddInput(ItemType.Stone, 200.0);
			AddInput(ItemType.YellowCoin, 2000.0);
			craftingTime = 45f;
			AddRequirement(new RequirementId(ItemType.Stone));
			overrideLocalizationKey = "ItemLabelKnowledgeStonework";
			break;
		case ResearchType.Quarry:
			AddInput(ItemType.Plank, 100.0);
			AddInput(ItemType.YellowCoin, 3000.0);
			craftingTime = 120f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Quarry);
			break;
		case ResearchType.Well:
			AddInput(ItemType.StoneSlab, 100.0);
			AddInput(ItemType.YellowCoin, 2000.0);
			AddRequirement(new RequirementId(ResearchType.StoneMason));
			AddRequirement(new RequirementId(NaturalResource.WaterSource));
			craftingTime = 120f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Well);
			break;
		case ResearchType.Warehouse:
			AddInput(ItemType.Plank, 500.0);
			AddInput(ItemType.StoneSlab, 500.0);
			AddInput(ItemType.StoneSlab, 500.0);
			AddInput(ItemType.YellowCoin, 1000.0);
			craftingTime = 120f;
			AddRequirement(new RequirementId(ResearchType.StoneMason));
			localizationEntity = EntityId.FromBuilding(BuildingType.Warehouse);
			break;
		case ResearchType.Barrel:
			AddInput(ItemType.RefinedPlank, 250.0);
			AddInput(ItemType.YellowCoin, 500.0);
			AddRequirement(new RequirementId(ResearchType.Workshop));
			craftingTime = 300f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Barrel);
			break;
		case ResearchType.Hearth:
			AddInput(ItemType.StoneSlab, 200.0);
			AddInput(ItemType.YellowCoin, 5000.0);
			AddRequirement(new RequirementId(ResearchType.StoneMason));
			craftingTime = 300f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Hearth);
			break;
		case ResearchType.GeneralLab:
			AddInput(ItemType.Paper, 500.0);
			AddInput(ItemType.RedCoin, 5000.0);
			AddRequirement(new RequirementId(QuestType.SkillsForPaper));
			craftingTime = 1800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.GeneralLab);
			break;
		case ResearchType.Jewelry:
			AddInput(ItemType.Quartz, 5000.0);
			AddInput(ItemType.ResearchTomeGeneral, 2500.0);
			AddInput(ItemType.YellowCoin, 200000.0);
			AddRequirement(new RequirementId(ResearchType.Glassmaking));
			craftingTime = 7200f;
			overrideLocalizationKey = "Jewelry";
			break;
		case ResearchType.Tailor:
			AddInput(ItemType.Cotton, 500.0);
			AddInput(ItemType.YellowCoin, 10000.0);
			AddRequirement(new RequirementId(ResearchType.Workshop));
			AddRequirement(new RequirementId(ItemType.Cotton));
			craftingTime = 600f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Tailor);
			break;
		case ResearchType.FishingNet:
			AddInput(ItemType.CottonCloth, 5000.0);
			AddInput(ItemType.ResearchTomeGeneral, 5000.0);
			AddInput(ItemType.RedCoin, 2000.0);
			craftingTime = 1800f;
			localizationEntity = EntityId.FromItem(ItemType.FishingNet);
			AddRequirement(new RequirementId(BiomeType.River));
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			break;
		case ResearchType.CropSilo:
			AddInput(ItemType.Plank, 2000.0);
			AddInput(ItemType.ResearchTomeGeneral, 5000.0);
			AddInput(ItemType.YellowCoin, 50000.0);
			craftingTime = 1800f;
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			localizationEntity = EntityId.FromBuilding(BuildingType.CropSilo);
			break;
		case ResearchType.Pantry:
			AddInput(ItemType.ResearchTomeGeneral, 1000.0);
			AddInput(ItemType.YellowCoin, 3000.0);
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			craftingTime = 1800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Pantry);
			break;
		case ResearchType.GemJewelry:
			AddInput(ItemType.CopperRing, 2000.0);
			AddInput(ItemType.PolishedStone, 2000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 25000.0);
			AddInput(ItemType.BlueCoin, 1000000.0);
			AddRequirement(new RequirementId(ResearchType.Jewelry));
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddRequirement(RequirementId.FullGame());
			overrideLocalizationKey = "GemJewelry";
			craftingTime = 86400f;
			break;
		case ResearchType.MagicForge:
			AddInput(ItemType.Mana, 1000.0);
			AddInput(ItemType.Fire, 1000.0);
			AddInput(ItemType.ResearchTomeGeneral, 20000.0);
			AddInput(ItemType.PurpleCoin, 10000.0);
			AddRequirement(RequirementId.BiomeTownLevel(BiomeType.Magic, 0));
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			AddRequirement(new RequirementId(QuestType.HarvestManaForArcaneEmporium));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.MagicForge);
			break;
		case ResearchType.MagicLab:
			AddInput(ItemType.PurifiedMana, 100000.0);
			AddInput(ItemType.ResearchTomeGeneral, 500000.0);
			AddInput(ItemType.PurpleCoin, 100000.0);
			AddRequirement(new RequirementId(ItemType.PurifiedMana));
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.MagicLab);
			break;
		case ResearchType.ManaTransmitter:
			AddInput(ItemType.Power, 20000.0);
			AddInput(ItemType.ResearchTomeMagic1, 25000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Millions(10));
			AddRequirement(new RequirementId(ResearchType.MagicLab));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.ManaTransmitter);
			break;
		case ResearchType.Enchanting:
			AddInput(ItemType.ManaPower, 40000.0);
			AddInput(ItemType.ResearchTomeMagic1, 100000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Millions(100));
			AddRequirement(new RequirementId(ResearchType.MagicLab));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			overrideLocalizationKey = "Enchanting";
			break;
		case ResearchType.MarketCostUpgrades:
			AddInput(ItemType.ResearchTomeMagic1, GameUtility.Millions(1));
			AddInput(ItemType.PurpleCoin, GameUtility.Millions(100));
			AddRequirement(new RequirementId(ResearchType.MagicLab));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			overrideLocalizationKey = "ConstructionCost";
			break;
		case ResearchType.Crystalarium:
			AddInput(ItemType.MagicPlank, 10000.0);
			AddInput(ItemType.MagicStoneBrick, 10000.0);
			AddInput(ItemType.ResearchTomeMagic1, GameUtility.Millions(1));
			AddInput(ItemType.PurpleCoin, GameUtility.Millions(100));
			AddRequirement(new RequirementId(ResearchType.Enchanting));
			localizationEntity = EntityId.FromBuilding(BuildingType.Crystalarium);
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			break;
		case ResearchType.FloatingIsland:
			AddInput(ItemType.MagicStoneBrick, 4000.0);
			AddInput(ItemType.ResearchTomeMagic1, GameUtility.Millions(1));
			AddInput(ItemType.PurpleCoin, GameUtility.Millions(100));
			AddRequirement(new RequirementId(ResearchType.Enchanting));
			AddRequirement(new RequirementId(BiomeType.Magic));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.FloatingIsland);
			break;
		case ResearchType.MagicTomeIntermediate:
			AddInput(ItemType.MagicPlank, 20000.0);
			AddInput(ItemType.MagicStoneBrick, 20000.0);
			AddInput(ItemType.ResearchTomeMagic1, GameUtility.Millions(1));
			AddInput(ItemType.PurpleCoin, GameUtility.Millions(100));
			AddRequirement(new RequirementId(ResearchType.MagicLab));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.ResearchTomeMagic2);
			break;
		case ResearchType.MagicClothing:
			AddInput(ItemType.Outfit, 30000.0);
			AddInput(ItemType.ResearchTomeMagic2, 30000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.Tailor));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			overrideLocalizationKey = "MagicClothing";
			break;
		case ResearchType.MagicMedicine:
			AddInput(ItemType.ManaPower, 10000.0);
			AddInput(ItemType.Remedy, 3000.0);
			AddInput(ItemType.ResearchTomeMagic2, 30000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.MedicineAdvanced));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			overrideLocalizationKey = "MagicMedicine";
			craftingTime = 432000f;
			break;
		case ResearchType.MagicJewelry:
			AddInput(ItemType.PolishedStoneRing, 4000.0);
			AddInput(ItemType.ResearchTomeMagic2, 30000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			overrideLocalizationKey = "MagicJewelry";
			craftingTime = 432000f;
			break;
		case ResearchType.MagicTech:
			AddInput(ItemType.SteamPipe, 3000.0);
			AddInput(ItemType.ResearchTomeMagic2, 30000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			overrideLocalizationKey = "MagicTech";
			craftingTime = 432000f;
			break;
		case ResearchType.ManaPowerHarvesterDrills:
			AddInput(ItemType.ManaPower, 1000.0);
			AddInput(ItemType.ResearchTomeMagic2, 1000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(new RequirementId(ResearchType.HarvesterDrill));
			AddRequirement(RequirementId.FullGame());
			AddInput(ItemType.ManaPower, 10000.0, 1);
			AddInput(ItemType.ResearchTomeMagic3, 10000.0, 1);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10), 1);
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced), 1);
			AddRequirement(RequirementId.FullGame(), 1);
			AddInput(ItemType.ManaPower, 100000.0, 2);
			AddInput(ItemType.ResearchTomeMagic3, 100000.0, 2);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(100), 2);
			AddRequirement(RequirementId.FullGame(), 2);
			maxLevel = 3;
			craftingTime = 432000f;
			metadataFlag = 131072;
			break;
		case ResearchType.ManaPowerTractors:
			AddInput(ItemType.ManaPower, 1000.0);
			AddInput(ItemType.ResearchTomeMagic2, 1000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(new RequirementId(ResearchType.Tractor));
			AddRequirement(RequirementId.FullGame());
			AddInput(ItemType.ManaPower, 10000.0, 1);
			AddInput(ItemType.ResearchTomeMagic3, 10000.0, 1);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10), 1);
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced), 1);
			AddRequirement(RequirementId.FullGame(), 1);
			AddInput(ItemType.ManaPower, 100000.0, 2);
			AddInput(ItemType.ResearchTomeMagic3, 100000.0, 2);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(100), 2);
			AddRequirement(RequirementId.FullGame(), 2);
			maxLevel = 3;
			craftingTime = 432000f;
			metadataFlag = 131072;
			break;
		case ResearchType.ManaPowerCropHarvesters:
			AddInput(ItemType.ManaPower, 1000.0);
			AddInput(ItemType.ResearchTomeMagic2, 1000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(new RequirementId(ResearchType.CropHarvester));
			AddRequirement(RequirementId.FullGame());
			AddInput(ItemType.ManaPower, 10000.0, 1);
			AddInput(ItemType.ResearchTomeMagic3, 10000.0, 1);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10), 1);
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced), 1);
			AddRequirement(RequirementId.FullGame(), 1);
			AddInput(ItemType.ManaPower, 100000.0, 2);
			AddInput(ItemType.ResearchTomeMagic3, 100000.0, 2);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(100), 2);
			AddRequirement(RequirementId.FullGame(), 2);
			maxLevel = 3;
			craftingTime = 432000f;
			metadataFlag = 131072;
			break;
		case ResearchType.ManaPowerChainsawTanks:
			AddInput(ItemType.ManaPower, 1000.0);
			AddInput(ItemType.ResearchTomeMagic2, 1000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(new RequirementId(ResearchType.ChainsawTank));
			AddRequirement(RequirementId.FullGame());
			AddInput(ItemType.ManaPower, 10000.0, 1);
			AddInput(ItemType.ResearchTomeMagic3, 10000.0, 1);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10), 1);
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced), 1);
			AddRequirement(RequirementId.FullGame(), 1);
			AddInput(ItemType.ManaPower, 100000.0, 2);
			AddInput(ItemType.ResearchTomeMagic3, 100000.0, 2);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(100), 2);
			AddRequirement(RequirementId.FullGame(), 2);
			maxLevel = 3;
			craftingTime = 432000f;
			metadataFlag = 131072;
			break;
		case ResearchType.ManaBattery:
			AddInput(ItemType.PurifiedMana, 2000.0);
			AddInput(ItemType.ResearchTomeMagic2, 4000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(new RequirementId(ResearchType.Battery));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.ManaBattery);
			break;
		case ResearchType.ManaPipe:
			AddInput(ItemType.SteamPipe, 100000.0);
			AddInput(ItemType.ResearchTomeMagic2, 40000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.ManaPipe);
			break;
		case ResearchType.ManaRefinery:
			AddInput(ItemType.ManaPower, 400000.0);
			AddInput(ItemType.ResearchTomeMagic2, 40000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(50));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 1728000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Refinery);
			break;
		case ResearchType.MagicTomeAdvanced:
			AddInput(ItemType.ManaEther, 20000.0);
			AddInput(ItemType.ResearchTomeMagic2, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(80));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 1728000f;
			localizationEntity = EntityId.FromItem(ItemType.ResearchTomeMagic3);
			break;
		case ResearchType.AppleFarming:
			ConfigureFarmingResearch(NaturalResource.AppleTree, 500f, 200f);
			break;
		case ResearchType.CottonFarming:
			ConfigureFarmingResearch(NaturalResource.CottonPlant, 500f, 200f);
			break;
		case ResearchType.BerryFarming:
			ConfigureFarmingResearch(NaturalResource.BerryBush, 1000f, 400f);
			break;
		case ResearchType.HerbFarming:
			ConfigureFarmingResearch(NaturalResource.HerbBush, 1000f, 400f);
			break;
		case ResearchType.PearFarming:
			ConfigureFarmingResearch(NaturalResource.PearTree, 1000f, 400f);
			break;
		case ResearchType.PotatoFarming:
			ConfigureFarmingResearch(NaturalResource.PotatoPlant, 3000f, 600f);
			AddRequirement(RequirementId.FullGame());
			break;
		case ResearchType.CarrotFarming:
			ConfigureFarmingResearch(NaturalResource.CarrotPlant, 3000f, 600f);
			AddRequirement(RequirementId.FullGame());
			break;
		case ResearchType.TomatoFarming:
			ConfigureFarmingResearch(NaturalResource.TomatoPlant, 1000f, 400f);
			break;
		case ResearchType.SugarFarming:
			ConfigureFarmingResearch(NaturalResource.SugarCane, 1000f, 400f);
			break;
		case ResearchType.CactusFarming:
			ConfigureFarmingResearch(NaturalResource.CactusFruitTree, 5000f, 1000f);
			AddRequirement(RequirementId.FullGame());
			break;
		case ResearchType.DragonfruitFarming:
			ConfigureFarmingResearch(NaturalResource.DragonFruitTree, 5000f, 1000f);
			AddRequirement(RequirementId.FullGame());
			break;
		case ResearchType.Forge:
			AddInput(ItemType.IronOre, 2000.0);
			AddInput(ItemType.Fire, 1000.0);
			AddInput(ItemType.ResearchTomeGeneral, 1000.0);
			AddInput(ItemType.YellowCoin, 20000.0);
			craftingTime = 7200f;
			AddRequirement(new RequirementId(ResearchType.Hearth));
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			AddRequirement(new RequirementId(NaturalResource.IronOre));
			localizationEntity = EntityId.FromBuilding(BuildingType.Forge);
			break;
		case ResearchType.Furnace:
			AddInput(ItemType.Coal, 2000.0);
			AddInput(ItemType.Fire, 2000.0);
			AddInput(ItemType.ResearchTomeGeneral, 10000.0);
			AddInput(ItemType.YellowCoin, 50000.0);
			AddRequirement(new RequirementId(ResearchType.Forge));
			craftingTime = 600f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Furnace);
			break;
		case ResearchType.Aqueduct:
			AddInput(ItemType.ResearchTomeGeneral, 1000.0);
			AddInput(ItemType.RefinedStoneBrick, 500.0);
			AddInput(ItemType.YellowCoin, 50000.0);
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			craftingTime = 1800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Aqueduct);
			break;
		case ResearchType.Chute:
			AddInput(ItemType.RefinedPlank, 500.0);
			AddInput(ItemType.ResearchTomeGeneral, 1000.0);
			AddInput(ItemType.RedCoin, 2000.0);
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			craftingTime = 600f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Chute);
			break;
		case ResearchType.Mining:
			AddInput(ItemType.Shovel, 5000.0);
			AddInput(ItemType.ResearchTomeGeneral, 2500.0);
			AddInput(ItemType.YellowCoin, 100000.0);
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			AddRequirement(new RequirementId(NaturalResource.IronOre));
			craftingTime = 1800f;
			overrideLocalizationKey = "ItemLabelKnowledgeMining";
			break;
		case ResearchType.Advertising:
			AddInput(ItemType.ResearchTomeGeneral, 50000.0);
			AddInput(ItemType.RedCoin, 200000.0);
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			craftingTime = 7200f;
			overrideLocalizationKey = "Advertising";
			break;
		case ResearchType.Economics:
			AddInput(ItemType.ResearchTomeIndustry1, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(1));
			AddRequirement(new RequirementId(ResearchType.Advertising));
			AddRequirement(new RequirementId(ResearchType.TechLab));
			craftingTime = 7200f;
			overrideLocalizationKey = "Economics";
			break;
		case ResearchType.CoalMining:
			AddInput(ItemType.Shovel, 1000.0);
			AddInput(ItemType.ResearchTomeGeneral, 10000.0);
			AddInput(ItemType.YellowCoin, 35000.0);
			AddRequirement(new RequirementId(ResearchType.Mining));
			AddRequirement(new RequirementId(NaturalResource.CoalOre));
			craftingTime = 1800f;
			localizationEntity = EntityId.FromMining(NaturalResource.CoalOre);
			metadataFlag = 131072;
			break;
		case ResearchType.Farming:
			AddInput(ItemType.Grain, 50.0);
			AddInput(ItemType.Water, 100.0);
			AddInput(ItemType.YellowCoin, 2000.0);
			AddRequirement(new RequirementId(NaturalResource.WaterSource));
			AddRequirement(new RequirementId(NaturalResource.Wheat));
			craftingTime = 300f;
			overrideLocalizationKey = "ItemLabelKnowledgeFarming";
			break;
		case ResearchType.FoodMill:
			AddInput(ItemType.Grain, 500.0);
			AddInput(ItemType.YellowCoin, 5000.0);
			craftingTime = 300f;
			AddRequirement(new RequirementId(ResearchType.Farming));
			localizationEntity = EntityId.FromBuilding(BuildingType.GrainMill);
			break;
		case ResearchType.Pasture:
			AddInput(ItemType.AnimalFeed, 1000.0);
			AddInput(ItemType.YellowCoin, 15000.0);
			AddRequirement(new RequirementId(ResearchType.FoodMill));
			craftingTime = 600f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Pasture);
			break;
		case ResearchType.Fishery:
			AddInput(ItemType.FishFood, 200.0);
			AddInput(ItemType.YellowCoin, 1500.0);
			craftingTime = 1800f;
			AddRequirement(new RequirementId(BiomeType.River));
			AddRequirement(new RequirementId(ResearchType.FoodMill));
			localizationEntity = EntityId.FromBuilding(BuildingType.Fishery);
			break;
		case ResearchType.Forestry:
			AddInput(ItemType.Wood, 50.0);
			AddInput(ItemType.Water, 100.0);
			AddInput(ItemType.YellowCoin, 4000.0);
			AddRequirement(new RequirementId(NaturalResource.WaterSource));
			craftingTime = 300f;
			overrideLocalizationKey = "ItemLabelKnowledgeForestry";
			break;
		case ResearchType.OreSilo:
			AddInput(ItemType.IronIngot, 2000.0);
			AddInput(ItemType.ResearchTomeGeneral, 10000.0);
			AddInput(ItemType.YellowCoin, 100000.0);
			craftingTime = 1800f;
			AddRequirement(new RequirementId(ResearchType.Forge));
			localizationEntity = EntityId.FromBuilding(BuildingType.OreSilo);
			break;
		case ResearchType.Treasury:
			AddInput(ItemType.PolishedStone, 100.0);
			AddInput(ItemType.ResearchTomeGeneral, 10000.0);
			AddInput(ItemType.BlueCoin, 100000.0);
			AddRequirement(new RequirementId(ResearchType.Glassmaking));
			AddRequirement(new RequirementId(QuestType.JewelerForJewelryStore));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Treasury);
			break;
		case ResearchType.Library:
			AddInput(ItemType.Book, 1000.0);
			AddInput(ItemType.YellowCoin, 80000.0);
			AddRequirement(new RequirementId(QuestType.PaperSkillsForBook));
			craftingTime = 1800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Library);
			break;
		case ResearchType.Reservoir:
			AddInput(ItemType.Water, 200.0);
			AddInput(ItemType.StoneSlab, 400.0);
			AddInput(ItemType.YellowCoin, 25000.0);
			AddRequirement(new RequirementId(ResearchType.Well));
			craftingTime = 7200f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Reservoir);
			break;
		case ResearchType.ClothConveyorBelt:
			AddInput(ItemType.CottonCloth, 10000.0);
			AddInput(ItemType.RedCoin, 20000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 1000.0);
			AddRequirement(new RequirementId(ResearchType.TechLab));
			craftingTime = 7200f;
			localizationEntity = EntityId.FromItem(ItemType.ClothConveyorBelt);
			break;
		case ResearchType.Bakery:
			AddInput(ItemType.Flour, 500.0);
			AddInput(ItemType.Fire, 1000.0);
			AddInput(ItemType.YellowCoin, 20000.0);
			AddRequirement(new RequirementId(ResearchType.Hearth));
			AddRequirement(new RequirementId(ResearchType.FoodMill));
			craftingTime = 600f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Bakery);
			break;
		case ResearchType.CopperMining:
			AddInput(ItemType.Shovel, 1000.0);
			AddInput(ItemType.ResearchTomeGeneral, 10000.0);
			AddInput(ItemType.RedCoin, 50000.0);
			AddRequirement(new RequirementId(ResearchType.Mining));
			AddRequirement(new RequirementId(NaturalResource.CopperOre));
			localizationEntity = EntityId.FromMining(NaturalResource.CopperOre);
			craftingTime = 7200f;
			metadataFlag = 131072;
			break;
		case ResearchType.GemMine:
			AddInput(ItemType.Pickaxe, 2500.0);
			AddInput(ItemType.RedCoin, 1000000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 4000.0);
			AddRequirement(new RequirementId(ResearchType.Mining));
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromBuilding(BuildingType.GemMine);
			break;
		case ResearchType.SilverMining:
			AddInput(ItemType.Pickaxe, 4000.0);
			AddInput(ItemType.RedCoin, 1500000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 5000.0);
			AddRequirement(new RequirementId(ResearchType.GemMine));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(new RequirementId(NaturalResource.SilverOre));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromMining(NaturalResource.SilverOre);
			craftingTime = 7200f;
			metadataFlag = 131072;
			break;
		case ResearchType.GoldMining:
			AddInput(ItemType.Pickaxe, 5000.0);
			AddInput(ItemType.RedCoin, 3000000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 7500.0);
			AddRequirement(new RequirementId(ResearchType.GemMine));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(new RequirementId(NaturalResource.GoldOre));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromMining(NaturalResource.GoldOre);
			craftingTime = 7200f;
			metadataFlag = 131072;
			break;
		case ResearchType.RubyMining:
			AddInput(ItemType.Pickaxe, 5000.0);
			AddInput(ItemType.RedCoin, 2000000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 10000.0);
			AddRequirement(new RequirementId(ResearchType.GemMine));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(new RequirementId(BiomeType.Desert));
			AddRequirement(new RequirementId(NaturalResource.Ruby));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromMining(NaturalResource.Ruby);
			craftingTime = 7200f;
			metadataFlag = 131072;
			break;
		case ResearchType.SapphireMining:
			AddInput(ItemType.Pickaxe, 5000.0);
			AddInput(ItemType.RedCoin, 2000000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 10000.0);
			AddRequirement(new RequirementId(ResearchType.GemMine));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(new RequirementId(BiomeType.Snow));
			AddRequirement(new RequirementId(NaturalResource.Sapphire));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromMining(NaturalResource.Sapphire);
			craftingTime = 7200f;
			metadataFlag = 131072;
			break;
		case ResearchType.AmethystMining:
			AddInput(ItemType.Pickaxe, 5000.0);
			AddInput(ItemType.RedCoin, 2000000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 10000.0);
			AddRequirement(new RequirementId(ResearchType.GemMine));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(new RequirementId(BiomeType.Jungle));
			AddRequirement(new RequirementId(NaturalResource.Amethyst));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromMining(NaturalResource.Amethyst);
			craftingTime = 7200f;
			metadataFlag = 131072;
			break;
		case ResearchType.TopazMining:
			AddInput(ItemType.Pickaxe, 5000.0);
			AddInput(ItemType.RedCoin, 2000000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 10000.0);
			AddRequirement(new RequirementId(ResearchType.GemMine));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(new RequirementId(BiomeType.Mountains));
			AddRequirement(new RequirementId(NaturalResource.Topaz));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromMining(NaturalResource.Topaz);
			craftingTime = 7200f;
			metadataFlag = 131072;
			break;
		case ResearchType.ManaMining:
			AddInput(ItemType.Pickaxe, 25000.0);
			AddInput(ItemType.PurpleCoin, 100000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 100000.0);
			AddRequirement(new RequirementId(ResearchType.GemMine));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(new RequirementId(BiomeType.Magic));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 28800f;
			localizationEntity = EntityId.FromMining(NaturalResource.ManaCrystal);
			metadataFlag = 131072;
			break;
		case ResearchType.Glassmaking:
			AddInput(ItemType.Quartz, 2000.0);
			AddInput(ItemType.Fire, 2000.0);
			AddInput(ItemType.ResearchTomeGeneral, 10000.0);
			AddInput(ItemType.RedCoin, 40000.0);
			AddRequirement(new RequirementId(ResearchType.Forge));
			craftingTime = 7200f;
			overrideLocalizationKey = "Glassmaking";
			break;
		case ResearchType.TechLab:
			AddInput(ItemType.ResearchTomeGeneral, 100000.0);
			AddInput(ItemType.IronIngot, 1000.0);
			AddInput(ItemType.RedCoin, 300000.0);
			AddRequirement(new RequirementId(ResearchType.Forge));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.TechLab);
			break;
		case ResearchType.WaterPower:
			AddInput(ItemType.ReinforcedPlank, 10000.0);
			AddInput(ItemType.RedCoin, 2000000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 10000.0);
			AddRequirement(new RequirementId(ResearchType.TechLab));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.WaterWheel);
			break;
		case ResearchType.SolarPower:
			AddInput(ItemType.CopperWire, 10000.0);
			AddInput(ItemType.GlassPanel, 10000.0);
			AddInput(ItemType.Power, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(50));
			AddInput(ItemType.ResearchTomeIndustry2, 1000.0);
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddRequirement(new RequirementId(ResearchType.Glassmaking));
			AddRequirement(new RequirementId(BiomeType.Desert));
			craftingTime = 86400f;
			localizationEntity = EntityId.FromBuilding(BuildingType.SolarPanel);
			break;
		case ResearchType.Machinery:
			AddInput(ItemType.IronIngot, 10000.0);
			AddInput(ItemType.Power, 250.0);
			AddInput(ItemType.ResearchTomeIndustry1, 20000.0);
			AddInput(ItemType.RedCoin, 50000.0);
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 7200f;
			overrideLocalizationKey = "ItemLabelKnowledgeMachinery";
			break;
		case ResearchType.CashRegisters:
			AddInput(ItemType.ResearchTomeIndustry1, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(2));
			AddRequirement(new RequirementId(ResearchType.Economics));
			AddRequirement(new RequirementId(ResearchType.Machinery));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			overrideLocalizationKey = "SellSpeed";
			break;
		case ResearchType.WaterPump:
			AddInput(ItemType.IronWheel, 1000.0);
			AddInput(ItemType.RedCoin, 100000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 10000.0);
			AddRequirement(new RequirementId(ResearchType.Machinery));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.WaterPump);
			break;
		case ResearchType.CropHarvester:
			AddInput(ItemType.Gear, 1000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(4));
			AddInput(ItemType.ResearchTomeIndustry1, 25000.0);
			AddRequirement(new RequirementId(ResearchType.Machinery));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromBuilding(BuildingType.CropHarvester);
			break;
		case ResearchType.Tractor:
			AddInput(ItemType.Gear, 1000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(4));
			AddInput(ItemType.ResearchTomeIndustry1, 2500.0);
			AddRequirement(new RequirementId(ResearchType.Machinery));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Tractor);
			break;
		case ResearchType.HarvesterDrill:
			AddInput(ItemType.Gear, 1000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(4));
			AddInput(ItemType.ResearchTomeIndustry2, 2500.0);
			AddRequirement(new RequirementId(ResearchType.Machinery));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromBuilding(BuildingType.HarvesterDrill);
			break;
		case ResearchType.ChainsawTank:
			AddInput(ItemType.Gear, 1000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(4));
			AddInput(ItemType.ResearchTomeIndustry2, 2500.0);
			AddRequirement(new RequirementId(ResearchType.Machinery));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromBuilding(BuildingType.ChainsawTank);
			break;
		case ResearchType.Battery:
			AddInput(ItemType.CopperWire, 1000.0);
			AddInput(ItemType.Power, 2000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(2));
			AddRequirement(new RequirementId(ResearchType.Machinery));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Battery);
			break;
		case ResearchType.SteamBoiler:
			AddInput(ItemType.SteamPipe, 200.0);
			AddInput(ItemType.ResearchTomeIndustry2, 500.0);
			AddInput(ItemType.RedCoin, 35000.0);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.SteamBoiler);
			break;
		case ResearchType.SteamPowerGenerator:
			AddInput(ItemType.Steam, 100.0);
			AddInput(ItemType.ResearchTomeIndustry2, 10000.0);
			AddInput(ItemType.RedCoin, 250000.0);
			craftingTime = 28800f;
			AddRequirement(new RequirementId(ResearchType.SteamBoiler));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromBuilding(BuildingType.SteamPowerGenerator);
			break;
		case ResearchType.MetalConveyorBelt:
			AddInput(ItemType.Gear, 1000.0);
			AddInput(ItemType.ClothConveyorBelt, 500.0);
			AddInput(ItemType.ResearchTomeIndustry2, 1000.0);
			AddInput(ItemType.RedCoin, 200000.0);
			AddRequirement(new RequirementId(ResearchType.ClothConveyorBelt));
			AddRequirement(new RequirementId(ResearchType.Machinery));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 28800f;
			localizationEntity = EntityId.FromItem(ItemType.MetalConveyorBelt);
			break;
		case ResearchType.IndustryTomeIntermediate:
			AddInput(ItemType.IronWheel, 1000.0);
			AddInput(ItemType.SteamPipe, 1000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 25000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(1));
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromItem(ItemType.ResearchTomeIndustry2);
			break;
		case ResearchType.Steel:
			AddInput(ItemType.IronIngot, 2000.0);
			AddInput(ItemType.Fire, 2000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 2000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(3));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(new RequirementId(ResearchType.Furnace));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 28800f;
			localizationEntity = EntityId.FromItem(ItemType.Steel);
			break;
		case ResearchType.ImprovedFurnace:
			AddInput(ItemType.Steel, 20000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 5000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(5));
			AddRequirement(new RequirementId(ResearchType.Steel));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromUpgrade(UpgradeType.FurnaceSpeed);
			metadataFlag = 131072;
			break;
		case ResearchType.FuelEfficiency:
			AddInput(ItemType.Coal, 5000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 2500.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(5));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromUpgrade(UpgradeType.FuelEfficiency);
			metadataFlag = 131072;
			break;
		case ResearchType.IndustryTomeAdvanced:
			AddInput(ItemType.RailTile, 5000.0);
			AddInput(ItemType.MetalConveyorBelt, 5000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.ResearchTomeIndustry3);
			break;
		case ResearchType.Foundry:
			AddInput(ItemType.Steel, 2500.0);
			AddInput(ItemType.ResearchTomeIndustry3, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Billions(25));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeAdvanced));
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Foundry);
			break;
		case ResearchType.MedicineBasic:
			AddInput(ItemType.ResearchTomeGeneral, 10000.0);
			AddInput(ItemType.Herb, 500.0);
			AddInput(ItemType.RedCoin, 100000.0);
			craftingTime = 28800f;
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			AddRequirement(new RequirementId(NaturalResource.HerbBush));
			overrideLocalizationKey = "ItemLabelKnowledgeMedicineBasic";
			break;
		case ResearchType.MetalRailway:
			AddInput(ItemType.ReinforcedPlank, 2000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(60));
			AddRequirement(new RequirementId(ResearchType.Machinery));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromItem(ItemType.RailTile);
			break;
		case ResearchType.Minecart:
			AddInput(ItemType.RailTile, 2000.0);
			AddInput(ItemType.ResearchTomeIndustry1, 1500.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(5));
			AddRequirement(new RequirementId(ResearchType.MetalRailway));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Minecart);
			break;
		case ResearchType.SteamTrainEngine:
			AddInput(ItemType.RailTile, 3000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 5000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(150));
			AddRequirement(new RequirementId(ResearchType.MetalRailway));
			AddRequirement(new RequirementId(ResearchType.SteamPowerGenerator));
			AddRequirement(new RequirementId(QuestType.TradingPostForTradingPanel));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.SteamTrain);
			break;
		case ResearchType.RailDepot:
			AddInput(ItemType.RailTile, 5000.0);
			AddInput(ItemType.ResearchTomeIndustry2, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(200));
			craftingTime = 28800f;
			AddRequirement(new RequirementId(ResearchType.SteamTrainEngine));
			localizationEntity = EntityId.FromBuilding(BuildingType.RailDepot);
			break;
		case ResearchType.GourmetKitchen:
			AddInput(ItemType.RefinedSugar, 10000.0);
			AddInput(ItemType.Butter, 10000.0);
			AddInput(ItemType.Bread, 10000.0);
			AddInput(ItemType.ResearchTomeGeneral, 50000.0);
			AddInput(ItemType.YellowCoin, GameUtility.Millions(5));
			AddRequirement(new RequirementId(ResearchType.Bakery));
			AddRequirement(new RequirementId(ResearchType.GeneralLab));
			AddRequirement(new RequirementId(ItemType.RefinedSugar));
			AddRequirement(new RequirementId(ItemType.Butter));
			AddRequirement(new RequirementId(ItemType.Bread));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.GourmetKitchen);
			break;
		case ResearchType.MedicineIntermediate:
			AddInput(ItemType.Remedy, 1000.0);
			AddInput(ItemType.FishOil, 1000.0);
			AddInput(ItemType.ResearchTomeGeneral, 50000.0);
			AddInput(ItemType.BlueCoin, GameUtility.Millions(10));
			craftingTime = 86400f;
			AddRequirement(new RequirementId(ResearchType.MedicineBasic));
			overrideLocalizationKey = "ItemLabelKnowledgeMedicine";
			break;
		case ResearchType.GrainProcessingSpeed:
			AddInput(ItemType.ResearchTomeIndustry1, 2500.0);
			AddInput(ItemType.Flour, 5000.0);
			AddInput(ItemType.RedCoin, 100000.0);
			AddRequirement(new RequirementId(ResearchType.FoodMill));
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddInput(ItemType.ResearchTomeIndustry2, 2500.0, 1);
			AddInput(ItemType.Flour, 5000.0, 1);
			AddInput(ItemType.RedCoin, GameUtility.Millions(5), 1);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate), 1);
			AddInput(ItemType.ResearchTomeIndustry3, 2500.0, 2);
			AddInput(ItemType.Bread, 5000.0, 2);
			AddInput(ItemType.RedCoin, GameUtility.Millions(100), 2);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeAdvanced), 2);
			craftingTime = 7200f;
			overrideLocalizationKey = "GrainProcessingSpeed";
			maxLevel = 3;
			metadataFlag = 131072;
			break;
		case ResearchType.StoneProcessingSpeed:
			AddInput(ItemType.ResearchTomeIndustry1, 2500.0);
			AddInput(ItemType.RefinedStoneBrick, 5000.0);
			AddInput(ItemType.RedCoin, 100000.0);
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddInput(ItemType.ResearchTomeIndustry2, 2500.0, 1);
			AddInput(ItemType.RefinedStoneBrick, 5000.0, 1);
			AddInput(ItemType.RedCoin, GameUtility.Millions(5), 1);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate), 1);
			AddInput(ItemType.ResearchTomeIndustry3, 2500.0, 2);
			AddInput(ItemType.RefinedStoneBrick, 5000.0, 2);
			AddInput(ItemType.RedCoin, GameUtility.Millions(100), 2);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeAdvanced), 2);
			craftingTime = 7200f;
			overrideLocalizationKey = "StoneProcessingSpeed";
			maxLevel = 3;
			metadataFlag = 131072;
			break;
		case ResearchType.WoodProcessingSpeed:
			AddInput(ItemType.ResearchTomeIndustry1, 2500.0);
			AddInput(ItemType.RefinedPlank, 5000.0);
			AddInput(ItemType.RedCoin, 100000.0);
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddInput(ItemType.ResearchTomeIndustry2, 2500.0, 1);
			AddInput(ItemType.RefinedPlank, 5000.0, 1);
			AddInput(ItemType.RedCoin, GameUtility.Millions(5), 1);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate), 1);
			AddInput(ItemType.ResearchTomeIndustry3, 2500.0, 2);
			AddInput(ItemType.RefinedPlank, 5000.0, 2);
			AddInput(ItemType.RedCoin, GameUtility.Millions(100), 2);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeAdvanced), 2);
			craftingTime = 7200f;
			overrideLocalizationKey = "WoodProcessingSpeed";
			maxLevel = 3;
			metadataFlag = 131072;
			break;
		case ResearchType.MetalProcessingSpeed:
			AddInput(ItemType.ResearchTomeIndustry1, 2500.0);
			AddInput(ItemType.IronIngot, 5000.0);
			AddInput(ItemType.RedCoin, 100000.0);
			AddRequirement(new RequirementId(ResearchType.TechLab));
			AddInput(ItemType.ResearchTomeIndustry2, 2500.0, 1);
			AddInput(ItemType.IronIngot, 5000.0, 1);
			AddInput(ItemType.RedCoin, GameUtility.Millions(5), 1);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeIntermediate), 1);
			AddInput(ItemType.ResearchTomeIndustry3, 2500.0, 2);
			AddInput(ItemType.IronIngot, 5000.0, 2);
			AddInput(ItemType.RedCoin, GameUtility.Millions(100), 2);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeAdvanced), 2);
			craftingTime = 7200f;
			overrideLocalizationKey = "MetalProcessingSpeed";
			maxLevel = 3;
			metadataFlag = 131072;
			break;
		case ResearchType.MedicineAdvanced:
			AddInput(ItemType.Antidote, 5000.0);
			AddInput(ItemType.Ointment, 3000.0);
			AddInput(ItemType.ResearchTomeGeneral, 500000.0);
			AddInput(ItemType.BlueCoin, GameUtility.Millions(100));
			craftingTime = 432000f;
			AddRequirement(new RequirementId(ResearchType.MedicineIntermediate));
			AddRequirement(RequirementId.FullGame());
			overrideLocalizationKey = "ItemLabelKnowledgeMedicineAdvanced";
			break;
		case ResearchType.Factory:
			AddInput(ItemType.MetalConveyorBelt, 2500.0);
			AddInput(ItemType.ResearchTomeIndustry3, 10000.0);
			AddInput(ItemType.RedCoin, 2000000.0);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeAdvanced));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Factory);
			break;
		case ResearchType.Packager:
			AddInput(ItemType.MetalConveyorBelt, 2500.0);
			AddInput(ItemType.ResearchTomeIndustry3, 10000.0);
			AddInput(ItemType.RedCoin, 2000000.0);
			AddRequirement(new RequirementId(ResearchType.IndustryTomeAdvanced));
			AddRequirement(new RequirementId(QuestType.TradingPostForTradingPanel));
			craftingTime = 28800f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Packager);
			break;
		case ResearchType.MagmaPipe:
			AddInput(ItemType.Steel, 10000.0);
			AddInput(ItemType.ResearchTomeIndustry3, 25000.0);
			AddInput(ItemType.RedCoin, GameUtility.Millions(5));
			AddRequirement(new RequirementId(ResearchType.IndustryTomeAdvanced));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 28800f;
			localizationEntity = EntityId.FromItem(ItemType.MagmaPipe);
			break;
		case ResearchType.PurifiedFirePower:
			AddInput(ItemType.PurifiedFire, 20000.0);
			AddInput(ItemType.ResearchTomeMagic2, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(50));
			AddRequirement(new RequirementId(ResearchType.FirePurification));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.UtilityElementalFirePower);
			break;
		case ResearchType.PurifiedWaterPower:
			AddInput(ItemType.PurifiedWater, 20000.0);
			AddInput(ItemType.ResearchTomeMagic2, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(50));
			AddRequirement(new RequirementId(ResearchType.WaterPurification));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.UtilityElementalWaterPower);
			break;
		case ResearchType.PurifiedEarthPower:
			AddInput(ItemType.PurifiedEarth, 20000.0);
			AddInput(ItemType.ResearchTomeMagic2, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(50));
			AddRequirement(new RequirementId(ResearchType.EarthPurification));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.UtilityElementalEarthPower);
			break;
		case ResearchType.PurifiedAirPower:
			AddInput(ItemType.PurifiedAir, 20000.0);
			AddInput(ItemType.ResearchTomeMagic2, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(50));
			AddRequirement(new RequirementId(ResearchType.AirPurification));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.UtilityElementalAirPower);
			break;
		case ResearchType.FireShrine:
			AddInput(ItemType.UtilityElementalFirePower, 200000.0);
			AddInput(ItemType.ResearchTomeMagic3, 5000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.PurifiedFirePower));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.FireShrine);
			break;
		case ResearchType.WaterShrine:
			AddInput(ItemType.UtilityElementalWaterPower, 200000.0);
			AddInput(ItemType.ResearchTomeMagic3, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.PurifiedWaterPower));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.WaterShrine);
			break;
		case ResearchType.EarthShrine:
			AddInput(ItemType.UtilityElementalEarthPower, 200000.0);
			AddInput(ItemType.ResearchTomeMagic3, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.PurifiedEarthPower));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.EarthShrine);
			break;
		case ResearchType.AirShrine:
			AddInput(ItemType.UtilityElementalAirPower, 200000.0);
			AddInput(ItemType.ResearchTomeMagic3, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.PurifiedAirPower));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.AirShrine);
			break;
		case ResearchType.FireEther:
			AddInput(ItemType.ManaEther, 250000.0);
			AddInput(ItemType.UtilityElementalFirePower, GameUtility.Millions(1));
			AddInput(ItemType.ResearchTomeMagic3, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(100));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(new RequirementId(ResearchType.ManaRefinery));
			AddRequirement(new RequirementId(ResearchType.PurifiedFirePower));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.FireEther);
			break;
		case ResearchType.WaterEther:
			AddInput(ItemType.ManaEther, 250000.0);
			AddInput(ItemType.UtilityElementalWaterPower, GameUtility.Millions(1));
			AddInput(ItemType.ResearchTomeMagic3, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(100));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(new RequirementId(ResearchType.ManaRefinery));
			AddRequirement(new RequirementId(ResearchType.PurifiedWaterPower));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.WaterEther);
			break;
		case ResearchType.EarthEther:
			AddInput(ItemType.ManaEther, 250000.0);
			AddInput(ItemType.UtilityElementalEarthPower, GameUtility.Millions(1));
			AddInput(ItemType.ResearchTomeMagic3, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(100));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(new RequirementId(ResearchType.ManaRefinery));
			AddRequirement(new RequirementId(ResearchType.PurifiedEarthPower));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.EarthEther);
			break;
		case ResearchType.AirEther:
			AddInput(ItemType.ManaEther, 250000.0);
			AddInput(ItemType.UtilityElementalAirPower, GameUtility.Millions(1));
			AddInput(ItemType.ResearchTomeMagic3, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(100));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(new RequirementId(ResearchType.ManaRefinery));
			AddRequirement(new RequirementId(ResearchType.PurifiedAirPower));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.AirEther);
			break;
		case ResearchType.EtherStorage:
			AddInput(ItemType.ManaEther, 100.0);
			AddInput(ItemType.ResearchTomeMagic2, 2500.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(25));
			AddRequirement(new RequirementId(ResearchType.ManaRefinery));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			localizationEntity = EntityId.FromBuilding(BuildingType.EtherStorage);
			break;
		case ResearchType.OmnistoneStorage:
			AddInput(ItemType.Omnistone, 10000.0);
			AddInput(ItemType.MagicPlank, 5000.0);
			AddInput(ItemType.ResearchTomeMagic3, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.ManaReactor));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.OmnistoneStorage);
			break;
		case ResearchType.EtherBonusManaPower:
			AddInput(ItemType.ManaEther, 10000.0);
			AddInput(ItemType.ResearchTomeMagic2, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.ManaRefinery));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			maxLevel = 5;
			metadataFlag = 131072;
			break;
		case ResearchType.EtherBonusFirePower:
			AddInput(ItemType.FireEther, 10000.0);
			AddInput(ItemType.ResearchTomeMagic3, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.FireEther));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			maxLevel = 5;
			metadataFlag = 131072;
			break;
		case ResearchType.EtherBonusWaterPower:
			AddInput(ItemType.WaterEther, 10000.0);
			AddInput(ItemType.ResearchTomeMagic3, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.WaterEther));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			maxLevel = 5;
			metadataFlag = 131072;
			break;
		case ResearchType.EtherBonusEarthPower:
			AddInput(ItemType.EarthEther, 10000.0);
			AddInput(ItemType.ResearchTomeMagic3, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.EarthEther));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			maxLevel = 5;
			metadataFlag = 131072;
			break;
		case ResearchType.EtherBonusAirPower:
			AddInput(ItemType.AirEther, 10000.0);
			AddInput(ItemType.ResearchTomeMagic3, 50000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.AirEther));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 86400f;
			maxLevel = 5;
			metadataFlag = 131072;
			break;
		case ResearchType.OmnistoneUpgrades:
			AddInput(ItemType.Omnistone, 100000.0);
			AddInput(ItemType.ResearchTomeMagic3, 50000.0);
			AddInput(ItemType.BlueCoin, GameUtility.Billions(100));
			AddRequirement(new RequirementId(ResearchType.ManaReactor));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 1728000f;
			overrideLocalizationKey = "OmnistoneUpgrades";
			break;
		case ResearchType.FirePurification:
			AddInput(ItemType.RedRuby, 25000.0);
			AddInput(ItemType.ResearchTomeMagic2, 10000.0);
			AddInput(ItemType.RedCoin, GameUtility.Billions(5));
			AddRequirement(new RequirementId(NaturalResource.Ruby));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.PurifiedFire);
			break;
		case ResearchType.WaterPurification:
			AddInput(ItemType.BlueSapphire, 25000.0);
			AddInput(ItemType.ResearchTomeMagic2, 10000.0);
			AddInput(ItemType.BlueCoin, GameUtility.Billions(5));
			AddRequirement(new RequirementId(NaturalResource.Sapphire));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.PurifiedWater);
			break;
		case ResearchType.EarthPurification:
			AddInput(ItemType.PurpleAmethyst, 25000.0);
			AddInput(ItemType.ResearchTomeMagic2, 10000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(5));
			AddRequirement(new RequirementId(NaturalResource.Amethyst));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromItem(ItemType.PurifiedEarth);
			craftingTime = 432000f;
			break;
		case ResearchType.AirPurification:
			AddInput(ItemType.YellowTopaz, 25000.0);
			AddInput(ItemType.ResearchTomeMagic2, 10000.0);
			AddInput(ItemType.YellowCoin, GameUtility.Billions(5));
			AddRequirement(new RequirementId(NaturalResource.Topaz));
			AddRequirement(new RequirementId(ResearchType.MagicTomeIntermediate));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromItem(ItemType.PurifiedAir);
			craftingTime = 432000f;
			break;
		case ResearchType.MagicFishingNet:
			AddInput(ItemType.FishingNet, 50000.0);
			AddInput(ItemType.PurifiedWater, 5000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Millions(25));
			craftingTime = 432000f;
			localizationEntity = EntityId.FromItem(ItemType.MagicFishingNet);
			AddRequirement(new RequirementId(BiomeType.River));
			AddRequirement(new RequirementId(ResearchType.WaterPurification));
			AddRequirement(new RequirementId(ResearchType.FishingNet));
			break;
		case ResearchType.BuildManaTemple:
			AddInput(ItemType.ManaEther, 400000.0);
			AddInput(ItemType.ResearchTomeMagic3, 150000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(150));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 1728000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.ManaTemple);
			break;
		case ResearchType.BuildFireTemple:
			AddInput(ItemType.FireEther, 400000.0);
			AddInput(ItemType.ResearchTomeMagic3, 200000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(200));
			AddRequirement(new RequirementId(ResearchType.FireShrine));
			AddRequirement(new RequirementId(ResearchType.FireEther));
			AddRequirement(new RequirementId(ResearchType.BuildManaTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 3456000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.FireTemple);
			break;
		case ResearchType.BuildWaterTemple:
			AddInput(ItemType.WaterEther, 400000.0);
			AddInput(ItemType.ResearchTomeMagic3, 200000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(200));
			AddRequirement(new RequirementId(ResearchType.WaterShrine));
			AddRequirement(new RequirementId(ResearchType.WaterEther));
			AddRequirement(new RequirementId(ResearchType.BuildManaTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 3456000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.WaterTemple);
			break;
		case ResearchType.BuildEarthTemple:
			AddInput(ItemType.EarthEther, 400000.0);
			AddInput(ItemType.ResearchTomeMagic3, 200000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(200));
			AddRequirement(new RequirementId(ResearchType.EarthShrine));
			AddRequirement(new RequirementId(ResearchType.EarthEther));
			AddRequirement(new RequirementId(ResearchType.BuildManaTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 3456000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.EarthTemple);
			break;
		case ResearchType.BuildAirTemple:
			AddInput(ItemType.AirEther, 400000.0);
			AddInput(ItemType.ResearchTomeMagic3, 200000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(200));
			AddRequirement(new RequirementId(ResearchType.AirShrine));
			AddRequirement(new RequirementId(ResearchType.AirEther));
			AddRequirement(new RequirementId(ResearchType.BuildManaTemple));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromBuilding(BuildingType.AirTemple);
			craftingTime = 3456000f;
			break;
		case ResearchType.MagicRail:
			AddInput(ItemType.PurifiedFire, 2500.0);
			AddInput(ItemType.ResearchTomeMagic2, 40000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(new RequirementId(ResearchType.MetalRailway));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.MagicRailTile);
			break;
		case ResearchType.MagicBoat:
			AddInput(ItemType.PurifiedWater, 2500.0);
			AddInput(ItemType.ResearchTomeMagic2, 40000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.MagicBoat);
			break;
		case ResearchType.MagicConveyorBelt:
			AddInput(ItemType.PurifiedEarth, 2500.0);
			AddInput(ItemType.ResearchTomeMagic2, 40000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(new RequirementId(ResearchType.MetalConveyorBelt));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.MagicConveyorBelt);
			break;
		case ResearchType.Airship:
			AddInput(ItemType.PurifiedAir, 2500.0);
			AddInput(ItemType.ResearchTomeMagic2, 40000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(10));
			AddRequirement(new RequirementId(ResearchType.MagicTech));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 432000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.Airship);
			break;
		case ResearchType.ManaReactor:
			AddInput(ItemType.FireEther, GameUtility.Millions(1));
			AddInput(ItemType.WaterEther, GameUtility.Millions(1));
			AddInput(ItemType.EarthEther, GameUtility.Millions(1));
			AddInput(ItemType.AirEther, GameUtility.Millions(1));
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(500));
			AddRequirement(new RequirementId(ResearchType.FireEther));
			AddRequirement(new RequirementId(ResearchType.WaterEther));
			AddRequirement(new RequirementId(ResearchType.EarthEther));
			AddRequirement(new RequirementId(ResearchType.AirEther));
			AddRequirement(new RequirementId(ResearchType.MagicTomeAdvanced));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 1728000f;
			localizationEntity = EntityId.FromBuilding(BuildingType.ManaReactor);
			break;
		case ResearchType.OmniPipe:
			AddInput(ItemType.Omnistone, 50000.0);
			AddInput(ItemType.ManaPipe, 200000.0);
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(750));
			AddRequirement(new RequirementId(ResearchType.ManaReactor));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 1728000f;
			localizationEntity = EntityId.FromItem(ItemType.OmniPipe);
			break;
		case ResearchType.BuildOmniTemple:
			AddInput(ItemType.Omnistone, 100000.0);
			AddInput(ItemType.ResearchTomeMagic3, GameUtility.Millions(1));
			AddInput(ItemType.PurpleCoin, GameUtility.Billions(1000));
			craftingTime = 5184000f;
			AddRequirement(new RequirementId(ResearchType.ManaReactor));
			AddRequirement(new RequirementId(ResearchType.BuildManaTemple));
			AddRequirement(new RequirementId(ResearchType.BuildFireTemple));
			AddRequirement(new RequirementId(ResearchType.BuildWaterTemple));
			AddRequirement(new RequirementId(ResearchType.BuildEarthTemple));
			AddRequirement(new RequirementId(ResearchType.BuildAirTemple));
			AddRequirement(RequirementId.FullGame());
			localizationEntity = EntityId.FromBuilding(BuildingType.OmniTemple);
			break;
		case ResearchType.InfiniteCraftingSpeed:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.RedCoin, 30000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "CraftingSpeed";
			metadataFlag = 131072;
			break;
		case ResearchType.InfiniteCultivationSpeed:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.YellowCoin, 40000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "CultivationSpeed";
			metadataFlag = 131072;
			break;
		case ResearchType.InfiniteProspectingSpeed:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.BlueCoin, 20000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "ProspectingSpeed";
			metadataFlag = 131072;
			break;
		case ResearchType.InfiniteResourceRegeneration:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.RedCoin, 30000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "ResourceRegen";
			metadataFlag = 262144;
			break;
		case ResearchType.InfiniteNaturalResourceCapacity:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.YellowCoin, 40000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "NaturalResourceCapacity";
			metadataFlag = 16;
			break;
		case ResearchType.InfiniteGoodsConsumption:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.PurpleCoin, 10000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "GoodsConsumption";
			metadataFlag = 256;
			break;
		case ResearchType.InfiniteKnowledgeSpeed:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.RedCoin, 30000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "KnowledgeSpeed";
			metadataFlag = 131072;
			break;
		case ResearchType.InfiniteMarketSellSpeed:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.PurpleCoin, 10000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "MarketSellSpeed";
			metadataFlag = 2097152;
			break;
		case ResearchType.InfiniteSkillGainSpeed:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.BlueCoin, 20000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "SkillGainSpeed";
			break;
		case ResearchType.InfiniteManaReactorProductivity:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.BlueCoin, 20000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			overrideLocalizationKey = "ManaReactorProductivity";
			localizationEntity = EntityId.FromBuilding(BuildingType.ManaReactor);
			metadataFlag = 131072;
			break;
		case ResearchType.InfiniteOmniTempleProductivity:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.PurpleCoin, 10000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			localizationEntity = EntityId.FromBuilding(BuildingType.OmniTemple);
			metadataFlag = 131072;
			break;
		case ResearchType.InfiniteOmnistoneValue:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.YellowCoin, 40000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			metadataFlag = 2097152;
			break;
		case ResearchType.FireTempleSpeed_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsFire, 10000.0);
			AddInput(ItemType.RedCoin, 30000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.WaterTempleSpeed_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsWater, 10000.0);
			AddInput(ItemType.BlueCoin, 20000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.EarthTempleSpeed_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsEarth, 10000.0);
			AddInput(ItemType.PurpleCoin, 10000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.AirTempleSpeed_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsAir, 10000.0);
			AddInput(ItemType.YellowCoin, 40000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.FireShrineSpeed_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsFire, 10000.0);
			AddInput(ItemType.RedCoin, 30000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.WaterShrineSpeed_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsWater, 10000.0);
			AddInput(ItemType.BlueCoin, 20000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.EarthShrineSpeed_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsEarth, 10000.0);
			AddInput(ItemType.PurpleCoin, 10000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.AirShrineSpeed_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsAir, 10000.0);
			AddInput(ItemType.YellowCoin, 40000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.OmniUpgradePower_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsMagic, 10000.0);
			AddInput(ItemType.PurpleCoin, 10000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.CropYield_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchPointsNature, 10000.0);
			AddInput(ItemType.RedCoin, 30000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		case ResearchType.InfiniteHouseMax_Disabled:
			AddInput(ItemType.Star, 1000.0);
			AddInput(ItemType.ResearchTomeGeneral, 10000.0);
			AddInput(ItemType.YellowCoin, 40000.0);
			AddRequirement(new RequirementId(ResearchType.BuildOmniTemple));
			AddRequirement(RequirementId.FullGame());
			craftingTime = 5184000f;
			maxLevel = int.MaxValue;
			enabled = false;
			break;
		default:
			enabled = false;
			break;
		}
		CalcMaxWorkers();
	}

	public void CalcMaxWorkers()
	{
		if (isInfiniteResearch)
		{
			maxWorkers = float.MaxValue;
		}
		else if (craftingTime >= 1728000f)
		{
			maxWorkers = 5f;
		}
		else if (craftingTime >= 432000f)
		{
			maxWorkers = 5f;
		}
		else if (craftingTime >= 86400f)
		{
			maxWorkers = 4f;
		}
		else if (craftingTime >= 28800f)
		{
			maxWorkers = 4f;
		}
		else if (craftingTime >= 7200f)
		{
			maxWorkers = 3f;
		}
		else if (craftingTime >= 1800f)
		{
			maxWorkers = 3f;
		}
		else if (craftingTime >= 600f)
		{
			maxWorkers = 2f;
		}
		else if (craftingTime >= 300f)
		{
			maxWorkers = 2f;
		}
		else
		{
			maxWorkers = 2f;
		}
		if (type == ResearchType.Forge)
		{
			maxWorkers = 10f;
		}
	}

	public List<RequirementId> RequirementsForLevel(int level)
	{
		if (requirementFixedCache.Count == 0)
		{
			return null;
		}
		if (level < requirementFixedCache.Count)
		{
			return requirementFixedCache[level];
		}
		return requirementFixedCache[requirementFixedCache.Count - 1];
	}

	public ItemList InputsForLevel(int level)
	{
		if (levelInputs.Count == 0)
		{
			return GameUtility.GetFreshItemList();
		}
		if (level < levelInputs.Count)
		{
			return levelInputs[level];
		}
		return levelInputs[levelInputs.Count - 1];
	}

	public void AddRequirement(RequirementId id)
	{
		int num = 0;
		while (requirementFixedCache.Count <= num)
		{
			requirementFixedCache.Add(new List<RequirementId>());
		}
		requirementFixedCache[num].Add(id);
	}

	public void AddRequirement(RequirementId id, int level)
	{
		while (requirementFixedCache.Count <= level)
		{
			requirementFixedCache.Add(new List<RequirementId>());
		}
		requirementFixedCache[level].Add(id);
	}

	private void AddInput(ItemType itemType, double count, int level = 0)
	{
		while (levelInputs.Count <= level)
		{
			levelInputs.Add(new ItemList());
		}
		levelInputs[level].AddItem(itemType, count);
	}

	private void ConfigureFarmingResearch(NaturalResource t, float coinCost, float cropCost)
	{
		ItemType itemType = Item.ItemFromNaturalResource(t);
		AddInput(itemType, cropCost);
		AddInput(ItemType.YellowCoin, coinCost);
		AddRequirement(new RequirementId(t));
		localizationEntity = EntityId.FromFarming(t);
		craftingTime = 300f;
		metadataFlag = 131072;
		if (Crafting.naturalResourceCache.TryGetValue(t, out var value))
		{
			if (value.exclusiveBiome != BiomeType.None)
			{
				AddRequirement(new RequirementId(value.exclusiveBiome));
			}
			if (value.cultivationBuilding == BuildingType.Forester)
			{
				AddRequirement(new RequirementId(ResearchType.Forestry));
			}
			else if (value.cultivationBuilding == BuildingType.Farm)
			{
				AddRequirement(new RequirementId(ResearchType.Farming));
			}
		}
	}

	public static List<Requirement> RequirementsForStructure(StructureType type)
	{
		return new List<Requirement>();
	}

	private void AddCultivationRequirement(ResearchType cultivationResearch)
	{
		AddRequirement(new RequirementId(cultivationResearch));
	}

	public static ResearchType DynamicResearch(DynamicResearchType baseType, int index)
	{
		return (ResearchType)(baseType + index);
	}

	public bool TryGetLocalizedOutput(out string s)
	{
		if (localizationEntity.type != EntityType.None)
		{
			s = ResearchState.GetLocalizedEntity(localizationEntity, overrideLocalizationLevel);
			return true;
		}
		if (overrideLocalizationKey != null)
		{
			s = TextDisplay.Text(overrideLocalizationKey);
			if (overrideLocalizationLevel > 0)
			{
				s = string.Format(TextDisplay.KeyValueFormatSpaced, s, TextDisplay.GetFormattedLevelAbbreviation(overrideLocalizationLevel));
			}
			return true;
		}
		s = null;
		return false;
	}

	public static float GrowthValueForResearch(ResearchType t)
	{
		switch (t)
		{
		case ResearchType.InfiniteCraftingSpeed:
			return 0.25f;
		case ResearchType.InfiniteProspectingSpeed:
			return 0.25f;
		case ResearchType.InfiniteCultivationSpeed:
			return 0.25f;
		case ResearchType.InfiniteNaturalResourceCapacity:
			return 0.5f;
		case ResearchType.InfiniteGoodsConsumption:
			return 0.5f;
		case ResearchType.InfiniteKnowledgeSpeed:
			return 0.25f;
		case ResearchType.InfiniteOmniTempleProductivity:
			return 0.2f;
		case ResearchType.InfiniteOmnistoneValue:
			return 0.1f;
		case ResearchType.InfiniteManaReactorProductivity:
			return 0.2f;
		case ResearchType.InfiniteResourceRegeneration:
			return 0.25f;
		case ResearchType.InfiniteMarketSellSpeed:
			return 0.25f;
		case ResearchType.InfiniteSkillGainSpeed:
			return 0.5f;
		case ResearchType.EtherBonusManaPower:
		case ResearchType.EtherBonusFirePower:
		case ResearchType.EtherBonusWaterPower:
		case ResearchType.EtherBonusEarthPower:
		case ResearchType.EtherBonusAirPower:
			return 0.5f;
		case ResearchType.ManaPowerHarvesterDrills:
		case ResearchType.GrainProcessingSpeed:
		case ResearchType.WoodProcessingSpeed:
		case ResearchType.StoneProcessingSpeed:
		case ResearchType.MetalProcessingSpeed:
		case ResearchType.ManaPowerChainsawTanks:
		case ResearchType.ManaPowerCropHarvesters:
		case ResearchType.ManaPowerTractors:
			return 1f;
		case ResearchType.CopperMining:
		case ResearchType.ManaMining:
		case ResearchType.GoldMining:
		case ResearchType.PearFarming:
		case ResearchType.AppleFarming:
		case ResearchType.BerryFarming:
		case ResearchType.CottonFarming:
		case ResearchType.HerbFarming:
		case ResearchType.PotatoFarming:
		case ResearchType.CarrotFarming:
		case ResearchType.TomatoFarming:
		case ResearchType.SugarFarming:
		case ResearchType.CactusFarming:
		case ResearchType.DragonfruitFarming:
		case ResearchType.CoalMining:
		case ResearchType.SilverMining:
		case ResearchType.RubyMining:
		case ResearchType.SapphireMining:
		case ResearchType.AmethystMining:
		case ResearchType.TopazMining:
			return 4f;
		default:
			return 0f;
		}
	}

	public static EntityId DerivedLinkedEntity(ResearchType t)
	{
		return t switch
		{
			ResearchType.EtherBonusManaPower => EntityId.FromItem(ItemType.ManaPower), 
			ResearchType.EtherBonusFirePower => EntityId.FromItem(ItemType.UtilityElementalFirePower), 
			ResearchType.EtherBonusWaterPower => EntityId.FromItem(ItemType.UtilityElementalWaterPower), 
			ResearchType.EtherBonusAirPower => EntityId.FromItem(ItemType.UtilityElementalAirPower), 
			ResearchType.EtherBonusEarthPower => EntityId.FromItem(ItemType.UtilityElementalEarthPower), 
			_ => EntityId.None, 
		};
	}

	public static string GetLabel(ResearchType type, int numCompleted)
	{
		if (Crafting.researchCache.TryGetValue(type, out var value) && value.isLeveledResearch)
		{
			int level = numCompleted;
			if (numCompleted < value.maxLevel)
			{
				level = numCompleted + 1;
			}
			return TextDisplay.LabelForResearchLevel(type, level);
		}
		return TextDisplay.LabelForResearch(type);
	}
}
