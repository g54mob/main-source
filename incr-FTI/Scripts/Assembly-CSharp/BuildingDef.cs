using System.Collections.Generic;

public class BuildingDef
{
	public readonly BuildingType type;

	public int bonusPerWorker;

	public bool enabled;

	public int storageAmount;

	public int workerHousingProvided;

	public int landRequired;

	public int workersRequired;

	public float constructionTime;

	public bool isMarket;

	public bool isWonder;

	public bool assignDefaultOnCreate;

	public readonly ItemList cost;

	public int[] maxCountPerTechLevel;

	public int[] maxCountPerHappinessLevel;

	public int[] maxCountPerResearchLevel;

	public int[] populationProvided;

	public readonly List<RequirementId> requirements;

	public float costGrowthFactor;

	public List<UpgradeType> growthCostUpgrades = new List<UpgradeType>();

	public List<UpgradeType> flatCostUpgrades = new List<UpgradeType>();

	public List<UpgradeType> productionSpeedUpgrades = new List<UpgradeType>();

	public List<UpgradeType> outputAmountUpgrades = new List<UpgradeType>();

	public List<UpgradeType> storageCapacityUpgrades = new List<UpgradeType>();

	public BuildingCategory category;

	public bool hasPhysicalOutputItem;

	public int blockHeight;

	public const int DefaultNumWorkers = 1;

	public BuildingDef(BuildingType t)
	{
		type = t;
		enabled = true;
		cost = new ItemList();
		requirements = new List<RequirementId>();
	}

	public void CalculateMetadata()
	{
	}

	public void Clear()
	{
		cost.Clear();
		maxCountPerTechLevel = null;
		maxCountPerResearchLevel = null;
		maxCountPerHappinessLevel = null;
		populationProvided = null;
		growthCostUpgrades.Clear();
		flatCostUpgrades.Clear();
		productionSpeedUpgrades.Clear();
		outputAmountUpgrades.Clear();
	}

	public void LoadDefault()
	{
		Clear();
		if (Data.Instance.defaultBuildingDefs.TryGetValue(type, out var value))
		{
			enabled = value.enabled;
			bonusPerWorker = value.bonusPerWorker;
			storageAmount = value.storageAmount;
			workerHousingProvided = value.workerHousingProvided;
			assignDefaultOnCreate = value.assignDefaultOnCreate;
			isMarket = value.isMarket;
			isWonder = value.isWonder;
			costGrowthFactor = value.costGrowthFactor;
			category = value.category;
			constructionTime = value.constructionTime;
			landRequired = value.landRequired;
			workersRequired = value.workersRequired;
			GameUtility.CopyDefList(value.growthCostUpgrades, ref growthCostUpgrades);
			GameUtility.CopyDefList(value.flatCostUpgrades, ref flatCostUpgrades);
			GameUtility.CopyDefList(value.productionSpeedUpgrades, ref productionSpeedUpgrades);
			GameUtility.CopyDefList(value.outputAmountUpgrades, ref outputAmountUpgrades);
			GameUtility.CopyDefList(value.storageCapacityUpgrades, ref storageCapacityUpgrades);
			if (value.maxCountPerTechLevel != null)
			{
				maxCountPerTechLevel = GameUtility.ClonedArray(value.maxCountPerTechLevel);
			}
			if (value.maxCountPerResearchLevel != null)
			{
				maxCountPerResearchLevel = GameUtility.ClonedArray(value.maxCountPerResearchLevel);
			}
			if (value.maxCountPerHappinessLevel != null)
			{
				maxCountPerHappinessLevel = GameUtility.ClonedArray(value.maxCountPerHappinessLevel);
			}
			if (value.populationProvided != null)
			{
				populationProvided = GameUtility.ClonedArray(value.populationProvided);
			}
			cost.AddList(Data.DefaultCostForBuilding(type));
		}
		requirements.Clear();
		Building.LoadDefaultRequirementsForBuilding(type, requirements);
		CalculateMetadata();
	}

	private static int DefaultConstructionTime(BuildingType t)
	{
		switch (t)
		{
		case BuildingType.House:
			return 3;
		case BuildingType.HarvesterHut:
			return 3;
		case BuildingType.Crate:
			return 4;
		case BuildingType.Chute:
			return 4;
		case BuildingType.CropSilo:
			return 4;
		case BuildingType.OreSilo:
			return 4;
		case BuildingType.Barrel:
			return 4;
		case BuildingType.Pantry:
			return 4;
		case BuildingType.Stockpile:
			return 4;
		case BuildingType.Warehouse:
			return 4;
		case BuildingType.GeneralGoods:
			return 4;
		case BuildingType.Library:
			return 5;
		case BuildingType.ClothingStore:
			return 4;
		case BuildingType.Apothecary:
			return 4;
		case BuildingType.Market:
			return 4;
		case BuildingType.HardwareStore:
			return 4;
		case BuildingType.Bookstore:
			return 4;
		case BuildingType.StoneMason:
			return 4;
		case BuildingType.School:
			return 4;
		case BuildingType.FancyFoods:
			return 6;
		case BuildingType.JewelryStore:
			return 6;
		case BuildingType.ArcaneStore:
			return 6;
		case BuildingType.Reservoir:
			return 5;
		case BuildingType.Battery:
			return 20;
		case BuildingType.ManaBattery:
			return 20;
		case BuildingType.Crystalarium:
			return 20;
		case BuildingType.Treasury:
			return 20;
		case BuildingType.EtherStorage:
			return 20;
		case BuildingType.OmnistoneStorage:
			return 20;
		case BuildingType.LumberMill:
			return 4;
		case BuildingType.GrainMill:
			return 5;
		case BuildingType.Workshop:
			return 5;
		case BuildingType.Bakery:
			return 6;
		case BuildingType.Hearth:
			return 6;
		case BuildingType.Furnace:
			return 6;
		case BuildingType.Well:
			return 4;
		case BuildingType.Farm:
			return 10;
		case BuildingType.Forester:
			return 10;
		case BuildingType.Pasture:
			return 10;
		case BuildingType.Fishery:
			return 10;
		case BuildingType.Quarry:
			return 4;
		case BuildingType.Mine:
			return 8;
		case BuildingType.GemMine:
			return 20;
		case BuildingType.RailDepot:
			return 10;
		case BuildingType.Jeweler:
			return 10;
		case BuildingType.GourmetKitchen:
			return 10;
		case BuildingType.Forge:
			return 10;
		case BuildingType.MedicineHut:
			return 10;
		case BuildingType.SteamPowerGenerator:
			return 10;
		case BuildingType.Tailor:
			return 10;
		case BuildingType.WaterPump:
			return 10;
		case BuildingType.MachineShop:
			return 15;
		case BuildingType.GeneralLab:
			return 10;
		case BuildingType.TechLab:
			return 15;
		case BuildingType.MagicLab:
			return 30;
		case BuildingType.Aqueduct:
			return 20;
		case BuildingType.WaterWheel:
			return 20;
		case BuildingType.SolarPanel:
			return 5;
		case BuildingType.PowerLine:
			return 5;
		case BuildingType.SteamTrain:
			return 20;
		case BuildingType.Caravan:
			return 4;
		case BuildingType.Minecart:
			return 25;
		case BuildingType.Factory:
			return 20;
		case BuildingType.Foundry:
			return 20;
		case BuildingType.Packager:
			return 20;
		case BuildingType.Airship:
			return 40;
		case BuildingType.MagicBoat:
			return 40;
		case BuildingType.MagicConveyorBelt:
			return 40;
		case BuildingType.MagicRailTile:
			return 40;
		case BuildingType.HarvesterDrill:
			return 30;
		case BuildingType.ChainsawTank:
			return 30;
		case BuildingType.FishingBoat:
			return 10;
		case BuildingType.FloatingIsland:
			return 30;
		case BuildingType.CropHarvester:
			return 30;
		case BuildingType.Tractor:
			return 30;
		case BuildingType.TradingPost:
			return 10;
		case BuildingType.SteamBoiler:
			return 20;
		case BuildingType.FireShrine:
			return 30;
		case BuildingType.WaterShrine:
			return 30;
		case BuildingType.EarthShrine:
			return 30;
		case BuildingType.AirShrine:
			return 30;
		case BuildingType.ManaTemple:
			return 60;
		case BuildingType.FireTemple:
			return 60;
		case BuildingType.WaterTemple:
			return 60;
		case BuildingType.EarthTemple:
			return 60;
		case BuildingType.AirTemple:
			return 60;
		case BuildingType.ManaPipeline:
			return 20;
		case BuildingType.SteamPipeline:
			return 20;
		case BuildingType.MagmaPipeline:
			return 20;
		case BuildingType.OmniPipeline:
			return 20;
		case BuildingType.ManaTransmitter:
			return 30;
		case BuildingType.MagicForge:
			return 30;
		case BuildingType.Enchanter:
			return 40;
		case BuildingType.Refinery:
			return 40;
		case BuildingType.ManaReactor:
			return 60;
		case BuildingType.OmniTemple:
			return 300;
		case BuildingType.PlainsUniversity:
		case BuildingType.ForestMonastery:
		case BuildingType.RiverHarbor:
		case BuildingType.MountainObservatory:
		case BuildingType.JunglePyramid:
		case BuildingType.DesertBazaar:
		case BuildingType.SnowTreasureVault:
		case BuildingType.MagicObelisk:
			return 36000;
		default:
			Data.IsBuildingEnabledDefault(t);
			return 5;
		}
	}

	public void CalcDerivedData()
	{
	}

	public void ConfigureForType()
	{
		constructionTime = DefaultConstructionTime(type);
		switch (type)
		{
		case BuildingType.GrainMill:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedGrainMill);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityGrainMill);
			workersRequired = 1;
			break;
		case BuildingType.Warehouse:
			storageAmount = 100;
			costGrowthFactor = 0.22f;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.WarehouseCapacity);
			break;
		case BuildingType.RailDepot:
			storageAmount = 10000;
			costGrowthFactor = 0.22f;
			category = BuildingCategory.Storage;
			landRequired = 4;
			break;
		case BuildingType.Reservoir:
			costGrowthFactor = 0.22f;
			storageAmount = 500;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.ReservoirCapacity);
			break;
		case BuildingType.Farm:
			bonusPerWorker = 100;
			storageAmount = 500;
			category = BuildingCategory.Cultivation;
			landRequired = 2;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedFarm);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityFarm);
			workersRequired = 1;
			break;
		case BuildingType.Forester:
			costGrowthFactor = 0.22f;
			landRequired = 2;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedForester);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityForester);
			bonusPerWorker = 100;
			storageAmount = 500;
			category = BuildingCategory.Cultivation;
			workersRequired = 1;
			break;
		case BuildingType.Fishery:
			bonusPerWorker = 100;
			category = BuildingCategory.Cultivation;
			storageAmount = 250;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedFishery);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityFishery);
			workersRequired = 1;
			break;
		case BuildingType.Well:
			storageAmount = 200;
			category = BuildingCategory.Cultivation;
			productionSpeedUpgrades.Add(UpgradeType.WellEffectiveness);
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedWell);
			break;
		case BuildingType.Quarry:
			costGrowthFactor = 0.27f;
			category = BuildingCategory.Prospecting;
			storageAmount = 500;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedQuarry);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityQuarry);
			workersRequired = 1;
			break;
		case BuildingType.GemMine:
			costGrowthFactor = 0.27f;
			category = BuildingCategory.Prospecting;
			storageAmount = 250;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedGemMine);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityGemMine);
			workersRequired = 1;
			break;
		case BuildingType.Mine:
			bonusPerWorker = 100;
			costGrowthFactor = 0.27f;
			category = BuildingCategory.Prospecting;
			storageAmount = 500;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedMine);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityMine);
			workersRequired = 1;
			break;
		case BuildingType.Market:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostFood);
			break;
		case BuildingType.GeneralGoods:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostGeneral);
			break;
		case BuildingType.HardwareStore:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostHardware);
			break;
		case BuildingType.Bookstore:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostBookstore);
			break;
		case BuildingType.ClothingStore:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostClothing);
			break;
		case BuildingType.Apothecary:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostApothecary);
			break;
		case BuildingType.JewelryStore:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostJewelry);
			break;
		case BuildingType.ArcaneStore:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostArcane);
			break;
		case BuildingType.FancyFoods:
			isMarket = true;
			storageAmount = 50;
			category = BuildingCategory.Markets;
			workersRequired = 1;
			flatCostUpgrades.Add(UpgradeType.MarketCostGourmet);
			break;
		case BuildingType.Chute:
			category = BuildingCategory.Housing;
			break;
		case BuildingType.Factory:
			category = BuildingCategory.Housing;
			workersRequired = 1;
			break;
		case BuildingType.Foundry:
			category = BuildingCategory.Housing;
			workersRequired = 4;
			break;
		case BuildingType.Packager:
			category = BuildingCategory.Housing;
			workersRequired = 1;
			break;
		case BuildingType.Aqueduct:
			category = BuildingCategory.Harvesting;
			landRequired = 1;
			workersRequired = 0;
			productionSpeedUpgrades.Add(UpgradeType.AqueductEffectiveness);
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedAqueduct);
			break;
		case BuildingType.WaterWheel:
			category = BuildingCategory.Production;
			landRequired = 1;
			workersRequired = 0;
			productionSpeedUpgrades.Add(UpgradeType.WaterWheelEffectiveness);
			break;
		case BuildingType.PlainsUniversity:
		case BuildingType.ForestMonastery:
		case BuildingType.RiverHarbor:
		case BuildingType.MountainObservatory:
		case BuildingType.JunglePyramid:
		case BuildingType.DesertBazaar:
		case BuildingType.SnowTreasureVault:
		case BuildingType.MagicObelisk:
			category = BuildingCategory.Housing;
			isWonder = true;
			workersRequired = 10;
			landRequired = 10;
			costGrowthFactor = 0.4f;
			break;
		case BuildingType.SolarPanel:
			category = BuildingCategory.Production;
			workersRequired = 0;
			landRequired = 4;
			costGrowthFactor = 0.22f;
			productionSpeedUpgrades.Add(UpgradeType.SolarPanelEffectiveness);
			productionSpeedUpgrades.Add(UpgradeType.OmniSolarPanelEffectiveness);
			break;
		case BuildingType.PowerLine:
			category = BuildingCategory.Trading;
			workersRequired = 0;
			landRequired = 1;
			break;
		case BuildingType.ManaPipeline:
			category = BuildingCategory.Trading;
			workersRequired = 0;
			landRequired = 1;
			break;
		case BuildingType.SteamPipeline:
			category = BuildingCategory.Trading;
			workersRequired = 0;
			landRequired = 1;
			break;
		case BuildingType.MagmaPipeline:
			category = BuildingCategory.Trading;
			workersRequired = 0;
			landRequired = 1;
			break;
		case BuildingType.OmniPipeline:
			category = BuildingCategory.Trading;
			workersRequired = 0;
			landRequired = 1;
			break;
		case BuildingType.ManaTemple:
			category = BuildingCategory.Housing;
			landRequired = 2;
			workersRequired = 1;
			break;
		case BuildingType.FireTemple:
			category = BuildingCategory.Housing;
			landRequired = 2;
			workersRequired = 1;
			break;
		case BuildingType.WaterTemple:
			category = BuildingCategory.Housing;
			landRequired = 2;
			workersRequired = 1;
			break;
		case BuildingType.EarthTemple:
			category = BuildingCategory.Housing;
			landRequired = 2;
			workersRequired = 1;
			landRequired = 2;
			workersRequired = 1;
			break;
		case BuildingType.AirTemple:
			category = BuildingCategory.Housing;
			landRequired = 2;
			workersRequired = 1;
			break;
		case BuildingType.CropHarvester:
			category = BuildingCategory.Harvesting;
			landRequired = 0;
			workersRequired = 1;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedCropHarvester);
			break;
		case BuildingType.Tractor:
			category = BuildingCategory.Housing;
			landRequired = 0;
			workersRequired = 1;
			break;
		case BuildingType.Minecart:
			category = BuildingCategory.Housing;
			landRequired = 0;
			workersRequired = 1;
			break;
		case BuildingType.Caravan:
			category = BuildingCategory.Housing;
			landRequired = 0;
			workersRequired = 2;
			break;
		case BuildingType.SteamTrain:
			category = BuildingCategory.Housing;
			landRequired = 1;
			workersRequired = 1;
			break;
		case BuildingType.HarvesterDrill:
			category = BuildingCategory.Harvesting;
			landRequired = 0;
			workersRequired = 1;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedHarvesterDrill);
			break;
		case BuildingType.FishingBoat:
			category = BuildingCategory.Harvesting;
			landRequired = 0;
			workersRequired = 1;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedFishingBoat);
			break;
		case BuildingType.FloatingIsland:
			category = BuildingCategory.Housing;
			landRequired = 0;
			workersRequired = 0;
			break;
		case BuildingType.ChainsawTank:
			category = BuildingCategory.Harvesting;
			landRequired = 0;
			workersRequired = 1;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedChainsawTank);
			break;
		case BuildingType.Airship:
			category = BuildingCategory.Housing;
			landRequired = 0;
			workersRequired = 2;
			break;
		case BuildingType.MagicBoat:
			category = BuildingCategory.Housing;
			landRequired = 0;
			workersRequired = 1;
			break;
		case BuildingType.MagicRailTile:
			category = BuildingCategory.Housing;
			landRequired = 1;
			workersRequired = 0;
			break;
		case BuildingType.MagicConveyorBelt:
			category = BuildingCategory.Housing;
			landRequired = 1;
			workersRequired = 0;
			break;
		case BuildingType.SteamBoiler:
			storageAmount = 250;
			category = BuildingCategory.Production;
			storageCapacityUpgrades.Add(UpgradeType.SteamBoilerStorageCapacity);
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedSteamBoiler);
			break;
		case BuildingType.FireShrine:
			productionSpeedUpgrades.Add(UpgradeType.FireShrineSpeed);
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedFireShrine);
			storageAmount = 500;
			break;
		case BuildingType.WaterShrine:
			productionSpeedUpgrades.Add(UpgradeType.WaterShrineSpeed);
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedWaterShrine);
			storageAmount = 500;
			break;
		case BuildingType.EarthShrine:
			productionSpeedUpgrades.Add(UpgradeType.EarthShrineSpeed);
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedEarthShrine);
			storageAmount = 500;
			break;
		case BuildingType.AirShrine:
			productionSpeedUpgrades.Add(UpgradeType.AirShrineSpeed);
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedAirShrine);
			storageAmount = 500;
			break;
		case BuildingType.GeneralLab:
			category = BuildingCategory.Research;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedStudy);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityStudy);
			workersRequired = 1;
			break;
		case BuildingType.TechLab:
			category = BuildingCategory.Research;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedTechLab);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityTechLab);
			workersRequired = 1;
			break;
		case BuildingType.MagicLab:
			category = BuildingCategory.Research;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedMagicLab);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityMagicLab);
			workersRequired = 1;
			break;
		case BuildingType.OmniTemple:
			category = BuildingCategory.Research;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedOmniTemple);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityOmniTemple);
			workersRequired = 1;
			landRequired = 10;
			break;
		case BuildingType.TradingPost:
			category = BuildingCategory.Trading;
			storageAmount = 200;
			storageCapacityUpgrades.Add(UpgradeType.TradingPostStorageCapacity);
			workersRequired = 1;
			break;
		case BuildingType.Base:
			populationProvided = new int[1] { 4 };
			maxCountPerResearchLevel = GameUtility.ClonedArray(Data.Instance.maxBasesPerResearchLevel);
			break;
		case BuildingType.Enchanter:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedEnchanter);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityEnchanter);
			workersRequired = 1;
			break;
		case BuildingType.MachineShop:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedMachineShop);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityMachineShop);
			workersRequired = 1;
			break;
		case BuildingType.MedicineHut:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedMedicineHut);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityMedicineHut);
			workersRequired = 1;
			break;
		case BuildingType.House:
			workerHousingProvided = 3;
			costGrowthFactor = 0.4f;
			growthCostUpgrades.Add(UpgradeType.HouseCost);
			category = BuildingCategory.Housing;
			break;
		case BuildingType.HarvesterHut:
			costGrowthFactor = 0.25f;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedHarvesterHut);
			category = BuildingCategory.Harvesting;
			workersRequired = 1;
			break;
		case BuildingType.ManaReactor:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedManaReactor);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityManaReactor);
			workersRequired = 1;
			break;
		case BuildingType.Treasury:
			costGrowthFactor = 0.22f;
			storageAmount = 100;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.TreasuryCapacity);
			break;
		case BuildingType.EtherStorage:
			costGrowthFactor = 0.22f;
			storageAmount = 200;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.EtherStorageCapacity);
			break;
		case BuildingType.OmnistoneStorage:
			costGrowthFactor = 0.27f;
			storageAmount = 1000;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.OmnistoneStorageCapacity);
			break;
		case BuildingType.Battery:
			costGrowthFactor = 0.22f;
			storageAmount = 200;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.BatteryCapacity);
			break;
		case BuildingType.Library:
			costGrowthFactor = 0.22f;
			storageAmount = 500;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.LibraryCapacity);
			break;
		case BuildingType.ManaBattery:
			costGrowthFactor = 0.22f;
			storageAmount = 500;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.ManaBatteryCapacity);
			break;
		case BuildingType.Crystalarium:
			costGrowthFactor = 0.22f;
			storageAmount = 500;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.CrystalariumCapacity);
			break;
		case BuildingType.SteamPowerGenerator:
			storageAmount = 200;
			category = BuildingCategory.Production;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedSteamPowerGenerator);
			break;
		case BuildingType.CropSilo:
			costGrowthFactor = 0.22f;
			storageAmount = 100;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.CropSiloCapacity);
			break;
		case BuildingType.OreSilo:
			costGrowthFactor = 0.22f;
			storageAmount = 100;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.OreSiloCapacity);
			break;
		case BuildingType.Furnace:
			storageAmount = 500;
			productionSpeedUpgrades.Add(UpgradeType.FurnaceSpeed);
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedFurnace);
			category = BuildingCategory.Production;
			storageCapacityUpgrades.Add(UpgradeType.FurnaceStorageCapacity);
			break;
		case BuildingType.Hearth:
			storageAmount = 100;
			category = BuildingCategory.Production;
			break;
		case BuildingType.WaterPump:
			category = BuildingCategory.Production;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedWaterPump);
			break;
		case BuildingType.Crate:
			storageAmount = 10;
			enabled = false;
			category = BuildingCategory.Storage;
			break;
		case BuildingType.Bank:
			storageAmount = 500;
			costGrowthFactor = 0.22f;
			enabled = false;
			break;
		case BuildingType.Pantry:
			storageAmount = 100;
			costGrowthFactor = 0.22f;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.PantryCapacity);
			break;
		case BuildingType.Stockpile:
			storageAmount = 50;
			costGrowthFactor = 0.22f;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.StockpileCapacity);
			break;
		case BuildingType.Barrel:
			storageAmount = 100;
			category = BuildingCategory.Storage;
			storageCapacityUpgrades.Add(UpgradeType.BarrelCapacity);
			break;
		case BuildingType.Tailor:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedTailor);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityTailor);
			workersRequired = 1;
			break;
		case BuildingType.Bakery:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedBakery);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityBakery);
			workersRequired = 1;
			break;
		case BuildingType.GourmetKitchen:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedGourmetKitchen);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityGourmetKitchen);
			workersRequired = 1;
			break;
		case BuildingType.Jeweler:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedJeweler);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityJeweler);
			workersRequired = 1;
			break;
		case BuildingType.Pasture:
			costGrowthFactor = 0.27f;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedPasture);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityPasture);
			workersRequired = 1;
			break;
		case BuildingType.Forge:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedForge);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityForge);
			workersRequired = 1;
			break;
		case BuildingType.MagicForge:
			storageAmount = 50;
			costGrowthFactor = 0.27f;
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedEnchantedForge);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityEnchantedForge);
			category = BuildingCategory.Production;
			workersRequired = 1;
			break;
		case BuildingType.ManaTransmitter:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedExtractor);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityExtractor);
			workersRequired = 1;
			break;
		case BuildingType.Refinery:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedRefinery);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityRefinery);
			workersRequired = 1;
			break;
		case BuildingType.StoneMason:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedStoneMason);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityStoneMason);
			workersRequired = 1;
			break;
		case BuildingType.School:
			category = BuildingCategory.Housing;
			workersRequired = 1;
			break;
		case BuildingType.LumberMill:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedLumberMill);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityLumberMill);
			category = BuildingCategory.Production;
			workersRequired = 1;
			break;
		case BuildingType.Workshop:
			productionSpeedUpgrades.Add(UpgradeType.OmniSpeedWorkshop);
			outputAmountUpgrades.Add(UpgradeType.OmniProductivityWorkshop);
			workersRequired = 1;
			break;
		case (BuildingType)4:
		case (BuildingType)6:
		case (BuildingType)12:
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
		case (BuildingType)74:
		case (BuildingType)75:
		case (BuildingType)76:
		case (BuildingType)94:
		case (BuildingType)96:
			break;
		}
	}
}
