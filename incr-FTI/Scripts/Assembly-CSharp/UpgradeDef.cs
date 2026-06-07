using System.Collections.Generic;
using UnityEngine;

public class UpgradeDef
{
	public readonly UpgradeType type;

	public EntityId linkedEntity;

	public readonly List<EntityId> popupParentEntity = new List<EntityId>();

	public string linkedModifierKey;

	public bool isInfinite;

	public List<UpgradeLevelDef> levels = new List<UpgradeLevelDef>();

	public UpgradeMetadataTarget metadataTarget;

	public readonly List<RequirementId> displayRequirements = new List<RequirementId>();

	public bool metadataFlagItemCapacity
	{
		get
		{
			return metadataTarget == UpgradeMetadataTarget.ItemCapacity;
		}
		set
		{
			metadataTarget = UpgradeMetadataTarget.ItemCapacity;
		}
	}

	public bool metadataFlagProductionCapacity
	{
		get
		{
			return metadataTarget == UpgradeMetadataTarget.ProductionCapacity;
		}
		set
		{
			metadataTarget = UpgradeMetadataTarget.ProductionCapacity;
		}
	}

	public bool metadataFlagStateSpeed
	{
		get
		{
			return metadataTarget == UpgradeMetadataTarget.ProductionSpeed;
		}
		set
		{
			metadataTarget = UpgradeMetadataTarget.ProductionSpeed;
		}
	}

	public bool metadataFlagProductivity
	{
		get
		{
			return metadataTarget == UpgradeMetadataTarget.Productivity;
		}
		set
		{
			metadataTarget = UpgradeMetadataTarget.Productivity;
		}
	}

	public UpgradeDef(UpgradeType t)
	{
		type = t;
		ConfigureForType();
		ConfigureLevelDefs();
	}

	private void AddLink(string key, BuildingType t)
	{
		linkedEntity = EntityId.FromBuilding(t);
		linkedModifierKey = key;
		switch (key)
		{
		case "ProductionCapacity":
			metadataFlagProductionCapacity = true;
			break;
		case "StorageCapacity":
			metadataFlagItemCapacity = true;
			break;
		case "MarketCapacity":
			metadataFlagProductionCapacity = true;
			break;
		case "SpeedBoost":
			metadataFlagStateSpeed = true;
			break;
		}
	}

	public void AddCoinSources(ItemType t)
	{
		List<BuildingType> list = Crafting.SourcesOfItem(t);
		if (list == null)
		{
			return;
		}
		foreach (BuildingType item in list)
		{
			popupParentEntity.Add(EntityId.FromBuilding(item));
		}
	}

	private void AddLink(string key, ItemType t)
	{
		linkedEntity = EntityId.FromItem(t);
		linkedModifierKey = key;
	}

	public void AddDisplayReq(RequirementId r)
	{
		displayRequirements.Add(r);
	}

	private void ConfigureForType()
	{
		EntityId entityId = DerivedLinkedEntity();
		if (entityId.type != EntityType.None)
		{
			linkedEntity = entityId;
		}
		switch (type)
		{
		case UpgradeType.MarketConsumptionFood:
			AddLink("GoodsConsumption", BuildingType.Market);
			break;
		case UpgradeType.MarketConsumptionGeneralGoods:
			AddLink("GoodsConsumption", BuildingType.GeneralGoods);
			break;
		case UpgradeType.MarketConsumptionMedicine:
			AddLink("GoodsConsumption", BuildingType.Apothecary);
			break;
		case UpgradeType.MarketConsumptionJewelryStore:
			AddLink("GoodsConsumption", BuildingType.JewelryStore);
			break;
		case UpgradeType.MarketConsumptionArcaneGoods:
			AddLink("GoodsConsumption", BuildingType.ArcaneStore);
			break;
		case UpgradeType.MarketConsumptionGourmetFood:
			AddLink("GoodsConsumption", BuildingType.FancyFoods);
			break;
		case UpgradeType.MarketConsumptionClothing:
			AddLink("GoodsConsumption", BuildingType.ClothingStore);
			break;
		case UpgradeType.MarketConsumptionHardwareStore:
			AddLink("GoodsConsumption", BuildingType.HardwareStore);
			break;
		case UpgradeType.MarketConsumptionBookstore:
			AddLink("GoodsConsumption", BuildingType.Bookstore);
			break;
		case UpgradeType.WaterPumpCountSpeed:
			AddLink("SpeedBoost", BuildingType.WaterPump);
			break;
		case UpgradeType.SteamBoilerCountSpeed:
			AddLink("SpeedBoost", BuildingType.SteamBoiler);
			break;
		case UpgradeType.SteamPowerGeneratorCountSpeed:
			AddLink("SpeedBoost", BuildingType.SteamPowerGenerator);
			break;
		case UpgradeType.ExtractorCountSpeed:
			AddLink("SpeedBoost", BuildingType.ManaTransmitter);
			break;
		case UpgradeType.FurnaceCountSpeed:
			AddLink("SpeedBoost", BuildingType.Furnace);
			break;
		case UpgradeType.FurnaceSpeed:
			AddLink("SpeedBoost", BuildingType.Furnace);
			break;
		case UpgradeType.HarvesterHutProficiency:
			AddLink("ProductionCapacity", BuildingType.HarvesterHut);
			break;
		case UpgradeType.FishingBoatProficiency:
			AddLink("ProductionCapacity", BuildingType.FishingBoat);
			break;
		case UpgradeType.CropHarvesterProficiency:
			AddLink("ProductionCapacity", BuildingType.CropHarvester);
			break;
		case UpgradeType.ChainsawTankProficiency:
			AddLink("ProductionCapacity", BuildingType.ChainsawTank);
			break;
		case UpgradeType.HarvesterDrillProficiency:
			AddLink("ProductionCapacity", BuildingType.HarvesterDrill);
			break;
		case UpgradeType.StoneMasonProficiency:
			AddLink("ProductionCapacity", BuildingType.StoneMason);
			break;
		case UpgradeType.TailorProficiency:
			AddLink("ProductionCapacity", BuildingType.Tailor);
			break;
		case UpgradeType.WorkshopProficiency:
			AddLink("ProductionCapacity", BuildingType.Workshop);
			break;
		case UpgradeType.GrainMillProficiency:
			AddLink("ProductionCapacity", BuildingType.GrainMill);
			break;
		case UpgradeType.ForgeProficiency:
			AddLink("ProductionCapacity", BuildingType.Forge);
			break;
		case UpgradeType.BakeryProficiency:
			AddLink("ProductionCapacity", BuildingType.Bakery);
			break;
		case UpgradeType.MachineShopProficiency:
			AddLink("ProductionCapacity", BuildingType.MachineShop);
			break;
		case UpgradeType.MedicineHutProficiency:
			AddLink("ProductionCapacity", BuildingType.MedicineHut);
			break;
		case UpgradeType.LumberMillProficiency:
			AddLink("ProductionCapacity", BuildingType.LumberMill);
			break;
		case UpgradeType.FarmingProficiency:
			AddLink("ProductionCapacity", BuildingType.Farm);
			break;
		case UpgradeType.MineProficiency:
			AddLink("ProductionCapacity", BuildingType.Mine);
			break;
		case UpgradeType.ForesterProficiency:
			AddLink("ProductionCapacity", BuildingType.Forester);
			break;
		case UpgradeType.FisheryProficiency:
			AddLink("ProductionCapacity", BuildingType.Fishery);
			break;
		case UpgradeType.EnchantedForgeProficiency:
			AddLink("ProductionCapacity", BuildingType.MagicForge);
			break;
		case UpgradeType.EnchanterProficiency:
			AddLink("ProductionCapacity", BuildingType.Enchanter);
			break;
		case UpgradeType.QuarryProficiency:
			AddLink("ProductionCapacity", BuildingType.Quarry);
			break;
		case UpgradeType.GemMineProficiency:
			AddLink("ProductionCapacity", BuildingType.GemMine);
			break;
		case UpgradeType.ExtractorProficiency:
			AddLink("ProductionCapacity", BuildingType.ManaTransmitter);
			break;
		case UpgradeType.RefineryProficiency:
			AddLink("ProductionCapacity", BuildingType.Refinery);
			break;
		case UpgradeType.JewelerProficiency:
			AddLink("ProductionCapacity", BuildingType.Jeweler);
			break;
		case UpgradeType.PastureProficiency:
			AddLink("ProductionCapacity", BuildingType.Pasture);
			break;
		case UpgradeType.GourmetKitchenProficiency:
			AddLink("ProductionCapacity", BuildingType.GourmetKitchen);
			break;
		case UpgradeType.StudyProficiency:
			AddLink("ProductionCapacity", BuildingType.GeneralLab);
			break;
		case UpgradeType.TechLabProficiency:
			AddLink("ProductionCapacity", BuildingType.TechLab);
			break;
		case UpgradeType.MagicLabProficiency:
			AddLink("ProductionCapacity", BuildingType.MagicLab);
			break;
		case UpgradeType.TradingPostWorkersPerBuilding:
			AddLink("ProductionCapacity", BuildingType.TradingPost);
			break;
		case UpgradeType.FireShrineSpeed:
			AddLink("SpeedBoost", BuildingType.FireShrine);
			break;
		case UpgradeType.WaterShrineSpeed:
			AddLink("SpeedBoost", BuildingType.WaterShrine);
			break;
		case UpgradeType.EarthShrineSpeed:
			AddLink("SpeedBoost", BuildingType.EarthShrine);
			break;
		case UpgradeType.AirShrineSpeed:
			AddLink("SpeedBoost", BuildingType.AirShrine);
			break;
		case UpgradeType.TempleEffectivenessMana:
			AddLink("Effectiveness", BuildingType.ManaTemple);
			break;
		case UpgradeType.TempleEffectivenessFire:
			AddLink("Effectiveness", BuildingType.FireTemple);
			break;
		case UpgradeType.TempleEffectivenessWater:
			AddLink("Effectiveness", BuildingType.WaterTemple);
			break;
		case UpgradeType.TempleEffectivenessEarth:
			AddLink("Effectiveness", BuildingType.EarthTemple);
			break;
		case UpgradeType.TempleEffectivenessAir:
			AddLink("Effectiveness", BuildingType.AirTemple);
			break;
		case UpgradeType.SellValueYellowCoin:
			AddLink("SellValue", ItemType.YellowCoin);
			break;
		case UpgradeType.SellValueRedCoin:
			popupParentEntity.Add(EntityId.FromBuilding(BuildingType.HardwareStore));
			AddLink("SellValue", ItemType.RedCoin);
			break;
		case UpgradeType.SellValueBlueCoin:
			AddLink("SellValue", ItemType.BlueCoin);
			break;
		case UpgradeType.SellValuePurpleCoin:
			AddLink("SellValue", ItemType.PurpleCoin);
			break;
		case UpgradeType.SellSpeedYellowCoin:
			linkedEntity = EntityId.FromItem(ItemType.YellowCoin);
			break;
		case UpgradeType.SellSpeedRedCoin:
			linkedEntity = EntityId.FromItem(ItemType.RedCoin);
			break;
		case UpgradeType.SellSpeedBlueCoin:
			linkedEntity = EntityId.FromItem(ItemType.BlueCoin);
			break;
		case UpgradeType.SellSpeedPurpleCoin:
			linkedEntity = EntityId.FromItem(ItemType.PurpleCoin);
			break;
		case UpgradeType.StockpileCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Stockpile);
			break;
		case UpgradeType.BarrelCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Barrel);
			break;
		case UpgradeType.WarehouseCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Warehouse);
			break;
		case UpgradeType.CropSiloCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.CropSilo);
			break;
		case UpgradeType.OreSiloCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.OreSilo);
			break;
		case UpgradeType.FurnaceStorageCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Furnace);
			break;
		case UpgradeType.SteamBoilerStorageCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.SteamBoiler);
			break;
		case UpgradeType.PantryCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Pantry);
			break;
		case UpgradeType.LibraryCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Library);
			break;
		case UpgradeType.TreasuryCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Treasury);
			break;
		case UpgradeType.BatteryCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Battery);
			break;
		case UpgradeType.ManaBatteryCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.ManaBattery);
			break;
		case UpgradeType.EtherStorageCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.EtherStorage);
			break;
		case UpgradeType.OmnistoneStorageCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.OmnistoneStorage);
			break;
		case UpgradeType.CrystalariumCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Crystalarium);
			break;
		case UpgradeType.ReservoirCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.Reservoir);
			break;
		case UpgradeType.TradingPostStorageCapacity:
			metadataFlagItemCapacity = true;
			AddLink("StorageCapacity", BuildingType.TradingPost);
			break;
		case UpgradeType.OmniSolarPanelEffectiveness:
			AddLink("Effectiveness", BuildingType.SolarPanel);
			isInfinite = true;
			break;
		case UpgradeType.FoodMarketCapacity:
			AddLink("MarketCapacity", BuildingType.Market);
			break;
		case UpgradeType.GeneralGoodsCapacity:
			AddLink("MarketCapacity", BuildingType.GeneralGoods);
			break;
		case UpgradeType.ApothecaryCapacity:
			AddLink("MarketCapacity", BuildingType.Apothecary);
			break;
		case UpgradeType.JewelryStoreCapacity:
			AddLink("MarketCapacity", BuildingType.JewelryStore);
			break;
		case UpgradeType.ArcaneStoreCapacity:
			AddLink("MarketCapacity", BuildingType.ArcaneStore);
			break;
		case UpgradeType.FancyFoodsCapacity:
			AddLink("MarketCapacity", BuildingType.FancyFoods);
			break;
		case UpgradeType.ClothingStoreCapacity:
			AddLink("MarketCapacity", BuildingType.ClothingStore);
			break;
		case UpgradeType.HardwareStoreCapacity:
			AddLink("MarketCapacity", BuildingType.HardwareStore);
			break;
		case UpgradeType.BookstoreCapacity:
			AddLink("MarketCapacity", BuildingType.Bookstore);
			break;
		case UpgradeType.OmniCapacityFoodMarket:
			AddLink("MarketCapacity", BuildingType.Market);
			isInfinite = true;
			break;
		case UpgradeType.OmniCapacityGeneralStore:
			AddLink("MarketCapacity", BuildingType.GeneralGoods);
			isInfinite = true;
			break;
		case UpgradeType.OmniCapacityHardwareStore:
			AddLink("MarketCapacity", BuildingType.HardwareStore);
			isInfinite = true;
			break;
		case UpgradeType.OmniCapacityBookstore:
			AddLink("MarketCapacity", BuildingType.Bookstore);
			isInfinite = true;
			break;
		case UpgradeType.OmniCapacityClothingStore:
			AddLink("MarketCapacity", BuildingType.ClothingStore);
			isInfinite = true;
			break;
		case UpgradeType.OmniCapacityGourmetFoods:
			AddLink("MarketCapacity", BuildingType.FancyFoods);
			isInfinite = true;
			break;
		case UpgradeType.OmniCapacityApothecary:
			AddLink("MarketCapacity", BuildingType.Apothecary);
			isInfinite = true;
			break;
		case UpgradeType.OmniCapacityJewelryStore:
			AddLink("MarketCapacity", BuildingType.JewelryStore);
			isInfinite = true;
			break;
		case UpgradeType.OmniCapacityArcaneStore:
			AddLink("MarketCapacity", BuildingType.ArcaneStore);
			isInfinite = true;
			break;
		case UpgradeType.MarketCostFood:
			AddLink("ConstructionEfficiency", BuildingType.Market);
			break;
		case UpgradeType.MarketCostGeneral:
			AddLink("ConstructionEfficiency", BuildingType.GeneralGoods);
			break;
		case UpgradeType.MarketCostHardware:
			AddLink("ConstructionEfficiency", BuildingType.HardwareStore);
			break;
		case UpgradeType.MarketCostBookstore:
			AddLink("ConstructionEfficiency", BuildingType.Bookstore);
			break;
		case UpgradeType.MarketCostClothing:
			AddLink("ConstructionEfficiency", BuildingType.ClothingStore);
			break;
		case UpgradeType.MarketCostApothecary:
			AddLink("ConstructionEfficiency", BuildingType.Apothecary);
			break;
		case UpgradeType.MarketCostGourmet:
			AddLink("ConstructionEfficiency", BuildingType.FancyFoods);
			break;
		case UpgradeType.MarketCostJewelry:
			AddLink("ConstructionEfficiency", BuildingType.JewelryStore);
			break;
		case UpgradeType.MarketCostArcane:
			AddLink("ConstructionEfficiency", BuildingType.ArcaneStore);
			break;
		case UpgradeType.Supermarket:
			linkedEntity = EntityId.FromBuilding(BuildingType.Market);
			break;
		case UpgradeType.SellSpeedOmniCoin:
			linkedEntity = EntityId.FromItem(ItemType.OmniCoin);
			break;
		case UpgradeType.YellowCoinXP:
			linkedEntity = EntityId.FromItem(ItemType.YellowCoin);
			break;
		case UpgradeType.RedCoinXP:
			linkedEntity = EntityId.FromItem(ItemType.RedCoin);
			break;
		case UpgradeType.BlueCoinXP:
			linkedEntity = EntityId.FromItem(ItemType.BlueCoin);
			break;
		case UpgradeType.PurpleCoinXP:
			linkedEntity = EntityId.FromItem(ItemType.PurpleCoin);
			break;
		case UpgradeType.OmniCoinXP:
			linkedEntity = EntityId.FromItem(ItemType.OmniCoin);
			break;
		case UpgradeType.OmniResearchSpeed:
			linkedEntity = EntityId.FromBuilding(BuildingType.School);
			isInfinite = true;
			break;
		case UpgradeType.OmniSpeedLumberMill:
		case UpgradeType.OmniSpeedGrainMill:
		case UpgradeType.OmniSpeedWorkshop:
		case UpgradeType.OmniSpeedTailor:
		case UpgradeType.OmniSpeedStoneMason:
		case UpgradeType.OmniSpeedPasture:
		case UpgradeType.OmniSpeedForge:
		case UpgradeType.OmniSpeedBakery:
		case UpgradeType.OmniSpeedGourmetKitchen:
		case UpgradeType.OmniSpeedJeweler:
		case UpgradeType.OmniSpeedMachineShop:
		case UpgradeType.OmniSpeedMedicineHut:
		case UpgradeType.OmniSpeedEnchantedForge:
		case UpgradeType.OmniSpeedExtractor:
		case UpgradeType.OmniSpeedEnchanter:
		case UpgradeType.OmniSpeedRefinery:
		case UpgradeType.OmniSpeedManaReactor:
		case UpgradeType.OmniSpeedFarm:
		case UpgradeType.OmniSpeedForester:
		case UpgradeType.OmniSpeedQuarry:
		case UpgradeType.OmniSpeedMine:
		case UpgradeType.OmniSpeedGemMine:
		case UpgradeType.OmniSpeedFishery:
		case UpgradeType.OmniSpeedStudy:
		case UpgradeType.OmniSpeedTechLab:
		case UpgradeType.OmniSpeedMagicLab:
		case UpgradeType.OmniSpeedOmniTemple:
		case UpgradeType.OmniSpeedHarvesterHut:
		case UpgradeType.OmniSpeedFishingBoat:
		case UpgradeType.OmniSpeedChainsawTank:
		case UpgradeType.OmniSpeedHarvesterDrill:
		case UpgradeType.OmniSpeedCropHarvester:
		case UpgradeType.OmniSpeedFireShrine:
		case UpgradeType.OmniSpeedWaterShrine:
		case UpgradeType.OmniSpeedEarthShrine:
		case UpgradeType.OmniSpeedAirShrine:
		case UpgradeType.OmniSpeedFurnace:
		case UpgradeType.OmniSpeedWaterPump:
		case UpgradeType.OmniSpeedSteamBoiler:
		case UpgradeType.OmniSpeedSteamPowerGenerator:
		case UpgradeType.OmniSpeedAqueduct:
		case UpgradeType.OmniSpeedWell:
			metadataFlagStateSpeed = true;
			linkedModifierKey = "OmnistoneBoost";
			isInfinite = true;
			break;
		case UpgradeType.OmniProductivityLumberMill:
		case UpgradeType.OmniProductivityGrainMill:
		case UpgradeType.OmniProductivityWorkshop:
		case UpgradeType.OmniProductivityTailor:
		case UpgradeType.OmniProductivityStoneMason:
		case UpgradeType.OmniProductivityPasture:
		case UpgradeType.OmniProductivityForge:
		case UpgradeType.OmniProductivityBakery:
		case UpgradeType.OmniProductivityGourmetKitchen:
		case UpgradeType.OmniProductivityJeweler:
		case UpgradeType.OmniProductivityMachineShop:
		case UpgradeType.OmniProductivityMedicineHut:
		case UpgradeType.OmniProductivityEnchantedForge:
		case UpgradeType.OmniProductivityExtractor:
		case UpgradeType.OmniProductivityEnchanter:
		case UpgradeType.OmniProductivityRefinery:
		case UpgradeType.OmniProductivityManaReactor:
		case UpgradeType.OmniProductivityFarm:
		case UpgradeType.OmniProductivityForester:
		case UpgradeType.OmniProductivityQuarry:
		case UpgradeType.OmniProductivityMine:
		case UpgradeType.OmniProductivityGemMine:
		case UpgradeType.OmniProductivityFishery:
		case UpgradeType.OmniProductivityStudy:
		case UpgradeType.OmniProductivityTechLab:
		case UpgradeType.OmniProductivityMagicLab:
		case UpgradeType.OmniProductivityOmniTemple:
			metadataFlagProductivity = true;
			linkedModifierKey = "Productivity";
			isInfinite = true;
			break;
		case UpgradeType.FishFarmingSpeed:
		case UpgradeType.FishHarvestingSpeed:
		case (UpgradeType)58:
		case (UpgradeType)64:
		case UpgradeType.ConstructionEfficiency:
		case UpgradeType.ManaPowerDrills_Legacy:
		case UpgradeType.ManaPowerCropHarvesters_Legacy:
		case (UpgradeType)81:
		case (UpgradeType)85:
		case UpgradeType.SilverProspectingSpeed:
		case (UpgradeType)87:
		case (UpgradeType)88:
		case (UpgradeType)89:
		case (UpgradeType)90:
		case (UpgradeType)91:
		case UpgradeType.HouseCost:
		case (UpgradeType)97:
		case UpgradeType.HouseCapacity:
		case UpgradeType.BuildingConstructionSpeedGrowth:
		case UpgradeType.PickaxeMiningYield:
		case (UpgradeType)135:
		case UpgradeType.AqueductEffectiveness:
		case (UpgradeType)142:
		case UpgradeType.RockProspectingSpeed:
		case UpgradeType.SilverHarvestingSpeed:
		case UpgradeType.MinigameMiningYield:
		case UpgradeType.MinigameMiningEnergyMax:
		case UpgradeType.MinigameMiningEnergyRate:
		case UpgradeType.MinigameFarmingYield:
		case UpgradeType.MinigameFarmingEnergyMax:
		case UpgradeType.MinigameFarmingEnergyRate:
		case UpgradeType.MinigameDiceYield:
		case UpgradeType.MinigameDiceEnergyMax:
		case UpgradeType.MinigameDiceEnergyRate:
		case UpgradeType.MinigameResearchYield:
		case UpgradeType.MinigameResearchEnergyMax:
		case UpgradeType.MinigameResearchEnergyRate:
		case UpgradeType.MinigameWaterYield:
		case UpgradeType.MinigameWaterEnergyMax:
		case UpgradeType.MinigameWaterEnergyRate:
		case UpgradeType.MinigameWoodYield:
		case UpgradeType.MinigameWoodEnergyMax:
		case UpgradeType.MinigameWoodEnergyRate:
		case UpgradeType.FurnaceProductivity:
		case (UpgradeType)170:
		case UpgradeType.LuckyPickaxe:
		case (UpgradeType)173:
		case UpgradeType.FuelEfficiency:
		case UpgradeType.Exploration:
		case UpgradeType.WellEffectiveness:
		case UpgradeType.WaterWheelEffectiveness:
		case UpgradeType.ShrineSpeed_Legacy:
		case UpgradeType.WaterHarvestingSpeed:
		case UpgradeType.ManaChainsawTanks_Legacy:
		case UpgradeType.ManaPowerTractors_Legacy:
		case (UpgradeType)246:
		case (UpgradeType)247:
		case (UpgradeType)248:
		case (UpgradeType)249:
		case (UpgradeType)250:
		case (UpgradeType)251:
		case (UpgradeType)252:
		case (UpgradeType)253:
		case (UpgradeType)254:
		case (UpgradeType)255:
		case (UpgradeType)264:
		case (UpgradeType)265:
		case (UpgradeType)266:
		case (UpgradeType)267:
		case (UpgradeType)268:
		case (UpgradeType)269:
		case (UpgradeType)270:
		case (UpgradeType)271:
		case (UpgradeType)272:
		case (UpgradeType)273:
		case (UpgradeType)274:
		case (UpgradeType)275:
		case (UpgradeType)276:
		case (UpgradeType)277:
		case (UpgradeType)278:
		case (UpgradeType)279:
		case (UpgradeType)280:
		case (UpgradeType)281:
		case (UpgradeType)282:
		case UpgradeType.ChainsawTankYield:
		case UpgradeType.HarvesterDrillYield:
		case UpgradeType.CropHarvesterYield:
		case UpgradeType.FishingBoatYield:
		case UpgradeType.FishingNetHarvestingSpeed:
		case UpgradeType.FishingMagicNetHarvestingSpeed:
		case UpgradeType.SolarPanelEffectiveness:
		case UpgradeType.SandHarvestingSpeed:
		case UpgradeType.UpgradeEfficiency:
		case (UpgradeType)331:
		case UpgradeType.PowerLineSpeed:
		case UpgradeType.ManaPipeSpeed:
		case UpgradeType.SteamPipeSpeed:
		case UpgradeType.OmniPipeSpeed:
		case UpgradeType.MagmaPipeSpeed:
			break;
		}
	}

	private EntityId DerivedLinkedEntity()
	{
		return type switch
		{
			UpgradeType.OmniSpeedLumberMill => EntityId.FromBuilding(BuildingType.LumberMill), 
			UpgradeType.OmniSpeedGrainMill => EntityId.FromBuilding(BuildingType.GrainMill), 
			UpgradeType.OmniSpeedWorkshop => EntityId.FromBuilding(BuildingType.Workshop), 
			UpgradeType.OmniSpeedTailor => EntityId.FromBuilding(BuildingType.Tailor), 
			UpgradeType.OmniSpeedStoneMason => EntityId.FromBuilding(BuildingType.StoneMason), 
			UpgradeType.OmniSpeedPasture => EntityId.FromBuilding(BuildingType.Pasture), 
			UpgradeType.OmniSpeedForge => EntityId.FromBuilding(BuildingType.Forge), 
			UpgradeType.OmniSpeedBakery => EntityId.FromBuilding(BuildingType.Bakery), 
			UpgradeType.OmniSpeedGourmetKitchen => EntityId.FromBuilding(BuildingType.GourmetKitchen), 
			UpgradeType.OmniSpeedJeweler => EntityId.FromBuilding(BuildingType.Jeweler), 
			UpgradeType.OmniSpeedMachineShop => EntityId.FromBuilding(BuildingType.MachineShop), 
			UpgradeType.OmniSpeedMedicineHut => EntityId.FromBuilding(BuildingType.MedicineHut), 
			UpgradeType.OmniSpeedEnchantedForge => EntityId.FromBuilding(BuildingType.MagicForge), 
			UpgradeType.OmniSpeedExtractor => EntityId.FromBuilding(BuildingType.ManaTransmitter), 
			UpgradeType.OmniSpeedEnchanter => EntityId.FromBuilding(BuildingType.Enchanter), 
			UpgradeType.OmniSpeedRefinery => EntityId.FromBuilding(BuildingType.Refinery), 
			UpgradeType.OmniSpeedManaReactor => EntityId.FromBuilding(BuildingType.ManaReactor), 
			UpgradeType.OmniSpeedFarm => EntityId.FromBuilding(BuildingType.Farm), 
			UpgradeType.OmniSpeedForester => EntityId.FromBuilding(BuildingType.Forester), 
			UpgradeType.OmniSpeedWell => EntityId.FromBuilding(BuildingType.Well), 
			UpgradeType.OmniSpeedQuarry => EntityId.FromBuilding(BuildingType.Quarry), 
			UpgradeType.OmniSpeedMine => EntityId.FromBuilding(BuildingType.Mine), 
			UpgradeType.OmniSpeedGemMine => EntityId.FromBuilding(BuildingType.GemMine), 
			UpgradeType.OmniSpeedFishery => EntityId.FromBuilding(BuildingType.Fishery), 
			UpgradeType.OmniSpeedStudy => EntityId.FromBuilding(BuildingType.GeneralLab), 
			UpgradeType.OmniSpeedTechLab => EntityId.FromBuilding(BuildingType.TechLab), 
			UpgradeType.OmniSpeedMagicLab => EntityId.FromBuilding(BuildingType.MagicLab), 
			UpgradeType.OmniSpeedOmniTemple => EntityId.FromBuilding(BuildingType.OmniTemple), 
			UpgradeType.OmniSpeedHarvesterHut => EntityId.FromBuilding(BuildingType.HarvesterHut), 
			UpgradeType.OmniSpeedFishingBoat => EntityId.FromBuilding(BuildingType.FishingBoat), 
			UpgradeType.OmniSpeedChainsawTank => EntityId.FromBuilding(BuildingType.ChainsawTank), 
			UpgradeType.OmniSpeedHarvesterDrill => EntityId.FromBuilding(BuildingType.HarvesterDrill), 
			UpgradeType.OmniSpeedAqueduct => EntityId.FromBuilding(BuildingType.Aqueduct), 
			UpgradeType.OmniSpeedCropHarvester => EntityId.FromBuilding(BuildingType.CropHarvester), 
			UpgradeType.OmniSpeedFireShrine => EntityId.FromBuilding(BuildingType.FireShrine), 
			UpgradeType.OmniSpeedWaterShrine => EntityId.FromBuilding(BuildingType.WaterShrine), 
			UpgradeType.OmniSpeedEarthShrine => EntityId.FromBuilding(BuildingType.EarthShrine), 
			UpgradeType.OmniSpeedAirShrine => EntityId.FromBuilding(BuildingType.AirShrine), 
			UpgradeType.OmniSpeedFurnace => EntityId.FromBuilding(BuildingType.Furnace), 
			UpgradeType.OmniSpeedWaterPump => EntityId.FromBuilding(BuildingType.WaterPump), 
			UpgradeType.OmniSpeedSteamBoiler => EntityId.FromBuilding(BuildingType.SteamBoiler), 
			UpgradeType.OmniSpeedSteamPowerGenerator => EntityId.FromBuilding(BuildingType.SteamPowerGenerator), 
			UpgradeType.OmniProductivityLumberMill => EntityId.FromBuilding(BuildingType.LumberMill), 
			UpgradeType.OmniProductivityGrainMill => EntityId.FromBuilding(BuildingType.GrainMill), 
			UpgradeType.OmniProductivityWorkshop => EntityId.FromBuilding(BuildingType.Workshop), 
			UpgradeType.OmniProductivityTailor => EntityId.FromBuilding(BuildingType.Tailor), 
			UpgradeType.OmniProductivityStoneMason => EntityId.FromBuilding(BuildingType.StoneMason), 
			UpgradeType.OmniProductivityPasture => EntityId.FromBuilding(BuildingType.Pasture), 
			UpgradeType.OmniProductivityForge => EntityId.FromBuilding(BuildingType.Forge), 
			UpgradeType.OmniProductivityBakery => EntityId.FromBuilding(BuildingType.Bakery), 
			UpgradeType.OmniProductivityGourmetKitchen => EntityId.FromBuilding(BuildingType.GourmetKitchen), 
			UpgradeType.OmniProductivityJeweler => EntityId.FromBuilding(BuildingType.Jeweler), 
			UpgradeType.OmniProductivityMachineShop => EntityId.FromBuilding(BuildingType.MachineShop), 
			UpgradeType.OmniProductivityMedicineHut => EntityId.FromBuilding(BuildingType.MedicineHut), 
			UpgradeType.OmniProductivityEnchantedForge => EntityId.FromBuilding(BuildingType.MagicForge), 
			UpgradeType.OmniProductivityExtractor => EntityId.FromBuilding(BuildingType.ManaTransmitter), 
			UpgradeType.OmniProductivityEnchanter => EntityId.FromBuilding(BuildingType.Enchanter), 
			UpgradeType.OmniProductivityRefinery => EntityId.FromBuilding(BuildingType.Refinery), 
			UpgradeType.OmniProductivityManaReactor => EntityId.FromBuilding(BuildingType.ManaReactor), 
			UpgradeType.OmniProductivityFarm => EntityId.FromBuilding(BuildingType.Farm), 
			UpgradeType.OmniProductivityForester => EntityId.FromBuilding(BuildingType.Forester), 
			UpgradeType.OmniProductivityQuarry => EntityId.FromBuilding(BuildingType.Quarry), 
			UpgradeType.OmniProductivityMine => EntityId.FromBuilding(BuildingType.Mine), 
			UpgradeType.OmniProductivityGemMine => EntityId.FromBuilding(BuildingType.GemMine), 
			UpgradeType.OmniProductivityFishery => EntityId.FromBuilding(BuildingType.Fishery), 
			UpgradeType.OmniProductivityStudy => EntityId.FromBuilding(BuildingType.GeneralLab), 
			UpgradeType.OmniProductivityTechLab => EntityId.FromBuilding(BuildingType.TechLab), 
			UpgradeType.OmniProductivityMagicLab => EntityId.FromBuilding(BuildingType.MagicLab), 
			UpgradeType.OmniProductivityOmniTemple => EntityId.FromBuilding(BuildingType.OmniTemple), 
			UpgradeType.OmniResearchSpeed => EntityId.FromBuilding(BuildingType.School), 
			UpgradeType.ManaPowerDrills_Legacy => EntityId.FromBuilding(BuildingType.HarvesterDrill), 
			UpgradeType.HarvesterDrillYield => EntityId.FromBuilding(BuildingType.HarvesterDrill), 
			UpgradeType.ManaChainsawTanks_Legacy => EntityId.FromBuilding(BuildingType.ChainsawTank), 
			UpgradeType.ChainsawTankYield => EntityId.FromBuilding(BuildingType.ChainsawTank), 
			UpgradeType.CropHarvesterYield => EntityId.FromBuilding(BuildingType.CropHarvester), 
			UpgradeType.ManaPowerCropHarvesters_Legacy => EntityId.FromBuilding(BuildingType.CropHarvester), 
			UpgradeType.FishingBoatYield => EntityId.FromBuilding(BuildingType.FishingBoat), 
			UpgradeType.ManaPowerTractors_Legacy => EntityId.FromBuilding(BuildingType.Tractor), 
			UpgradeType.AqueductEffectiveness => EntityId.FromBuilding(BuildingType.Aqueduct), 
			UpgradeType.WellEffectiveness => EntityId.FromBuilding(BuildingType.Well), 
			UpgradeType.WaterWheelEffectiveness => EntityId.FromBuilding(BuildingType.WaterWheel), 
			UpgradeType.SolarPanelEffectiveness => EntityId.FromBuilding(BuildingType.SolarPanel), 
			UpgradeType.PowerLineSpeed => EntityId.FromBuilding(BuildingType.PowerLine), 
			UpgradeType.SteamPipeSpeed => EntityId.FromBuilding(BuildingType.SteamPipeline), 
			UpgradeType.MagmaPipeSpeed => EntityId.FromBuilding(BuildingType.MagmaPipeline), 
			UpgradeType.ManaPipeSpeed => EntityId.FromBuilding(BuildingType.ManaPipeline), 
			UpgradeType.OmniPipeSpeed => EntityId.FromBuilding(BuildingType.OmniPipeline), 
			_ => EntityId.None, 
		};
	}

	public void ConfigureLevelDefs()
	{
		foreach (KeyValuePair<NaturalResource, UpgradeType> cultivationSpeedUpgrade in Data.Instance.cultivationSpeedUpgrades)
		{
			if (cultivationSpeedUpgrade.Value == type)
			{
				if (cultivationSpeedUpgrade.Key == NaturalResource.Tree)
				{
					ConfigureSkillUpgrade(3, 5000.0);
				}
				else
				{
					ConfigureSkillUpgrade(3);
				}
				if (Crafting.naturalResourceCache.TryGetValue(cultivationSpeedUpgrade.Key, out var value) && value.exclusiveBiome != BiomeType.None)
				{
					displayRequirements.Add(new RequirementId(value.exclusiveBiome));
				}
				return;
			}
		}
		if (Data.Instance.prospectingSpeedUpgrades != null)
		{
			foreach (KeyValuePair<NaturalResource, UpgradeType> prospectingSpeedUpgrade in Data.Instance.prospectingSpeedUpgrades)
			{
				if (prospectingSpeedUpgrade.Value == type)
				{
					if (Crafting.naturalResourceCache.TryGetValue(prospectingSpeedUpgrade.Key, out var value2) && value2.exclusiveBiome != BiomeType.None)
					{
						displayRequirements.Add(new RequirementId(value2.exclusiveBiome));
					}
					double startingValue = 15000.0;
					switch (type)
					{
					case UpgradeType.SilverProspectingSpeed:
						startingValue = 100000.0;
						break;
					case UpgradeType.GoldProspectingSpeed:
						startingValue = GameUtility.Millions(1);
						break;
					case UpgradeType.GemRedProspectingSpeed:
						startingValue = GameUtility.Millions(10);
						break;
					case UpgradeType.GemYellowProspectingSpeed:
						startingValue = GameUtility.Millions(10);
						break;
					case UpgradeType.GemAquaProspectingSpeed:
						startingValue = GameUtility.Millions(10);
						break;
					case UpgradeType.GemPurpleProspectingSpeed:
						startingValue = GameUtility.Millions(10);
						break;
					case UpgradeType.ManaProspectingSpeed:
						startingValue = GameUtility.Millions(100);
						break;
					}
					ConfigureSkillUpgrade(3, startingValue);
					return;
				}
			}
		}
		foreach (KeyValuePair<HarvestRecipeType, UpgradeType> harvestingSpeedUpgrade in Data.Instance.harvestingSpeedUpgrades)
		{
			if (harvestingSpeedUpgrade.Value == type)
			{
				switch (type)
				{
				case UpgradeType.TreeHarvestingSpeed:
					ConfigureSkillUpgrade(3, 2000.0);
					break;
				case UpgradeType.SandHarvestingSpeed:
					ConfigureSkillUpgrade(3, 2500.0);
					break;
				case UpgradeType.RockHarvestingSpeed:
					ConfigureSkillUpgrade(3, 2500.0);
					break;
				case UpgradeType.GrainHarvestingSpeed:
					ConfigureSkillUpgrade(3, 3000.0);
					break;
				case UpgradeType.BerryHarvestingSpeed:
					ConfigureSkillUpgrade(3, 3500.0);
					break;
				case UpgradeType.CottonHarvestingSpeed:
					ConfigureSkillUpgrade(3, 4000.0);
					break;
				case UpgradeType.AppleHarvestingSpeed:
					ConfigureSkillUpgrade(3, 4500.0);
					break;
				case UpgradeType.FishHarvestingSpeed:
					ConfigureSkillUpgrade(3, 5000.0);
					break;
				case UpgradeType.WaterHarvestingSpeed:
					ConfigureSkillUpgrade(3, 3000.0);
					break;
				case UpgradeType.HerbHarvestingSpeed:
					ConfigureSkillUpgrade(3, 5500.0);
					break;
				case UpgradeType.FishingNetHarvestingSpeed:
					ConfigureSkillUpgrade(3, 20000.0);
					break;
				case UpgradeType.FishingMagicNetHarvestingSpeed:
					ConfigureSkillUpgrade(3, 100000.0);
					break;
				default:
					ConfigureSkillUpgrade(3, 10000.0);
					break;
				}
				AddHarvestRequirement(harvestingSpeedUpgrade.Key);
				return;
			}
		}
		switch (type)
		{
		case UpgradeType.MarketConsumptionFood:
		{
			for (int num80 = 0; num80 < 10; num80++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(800000.0, num80));
			}
			break;
		}
		case UpgradeType.MarketConsumptionHardwareStore:
		{
			AddBuildingReqs(BuildingType.HardwareStore);
			for (int num98 = 0; num98 < 10; num98++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(1000000.0, num98));
			}
			break;
		}
		case UpgradeType.MarketConsumptionBookstore:
		{
			AddBuildingReqs(BuildingType.Bookstore);
			for (int num32 = 0; num32 < 10; num32++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledValue(1000000.0, num32));
			}
			break;
		}
		case UpgradeType.MarketConsumptionMedicine:
		{
			AddBuildingReqs(BuildingType.Apothecary);
			for (int num106 = 0; num106 < 10; num106++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(1500000.0, num106));
			}
			break;
		}
		case UpgradeType.MarketConsumptionGeneralGoods:
		{
			AddBuildingReqs(BuildingType.GeneralGoods);
			for (int num24 = 0; num24 < 10; num24++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(1200000.0, num24));
			}
			break;
		}
		case UpgradeType.MarketConsumptionClothing:
		{
			AddBuildingReqs(BuildingType.ClothingStore);
			for (int num9 = 0; num9 < 10; num9++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(1200000.0, num9));
			}
			break;
		}
		case UpgradeType.MarketConsumptionJewelryStore:
		{
			AddBuildingReqs(BuildingType.JewelryStore);
			for (int num102 = 0; num102 < 10; num102++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(2500000.0, num102));
			}
			break;
		}
		case UpgradeType.MarketConsumptionArcaneGoods:
		{
			AddBuildingReqs(BuildingType.ArcaneStore);
			for (int num88 = 0; num88 < 10; num88++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(2000000.0, num88));
			}
			break;
		}
		case UpgradeType.MarketConsumptionGourmetFood:
		{
			AddBuildingReqs(BuildingType.FancyFoods);
			for (int num72 = 0; num72 < 10; num72++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(2000000.0, num72));
			}
			break;
		}
		case UpgradeType.PickaxeMiningYield:
			AddLevelWithCost(ItemType.RedCoin, 500000.0, new RequirementId(ItemType.Pickaxe, 50000.0, global: true));
			AddLevelWithCost(ItemType.RedCoin, 5000000.0, new RequirementId(ItemType.Pickaxe, 100000.0, global: true));
			AddBuildingReqs(BuildingType.GemMine);
			break;
		case UpgradeType.ChainsawTankYield:
			AddLevelWithCost(ItemType.RedCoin, 500000.0, RequirementId.BuildingSkills(BuildingType.ChainsawTank, 15));
			AddLevelWithCost(ItemType.RedCoin, 5000000.0, RequirementId.BuildingSkills(BuildingType.ChainsawTank, 30));
			AddBuildingReqs(BuildingType.ChainsawTank);
			break;
		case UpgradeType.HarvesterDrillYield:
			AddLevelWithCost(ItemType.RedCoin, 600000.0, RequirementId.BuildingSkills(BuildingType.HarvesterDrill, 40));
			AddLevelWithCost(ItemType.RedCoin, 6000000.0, RequirementId.BuildingSkills(BuildingType.HarvesterDrill, 80));
			AddBuildingReqs(BuildingType.HarvesterDrill);
			break;
		case UpgradeType.CropHarvesterYield:
			AddLevelWithCost(ItemType.RedCoin, 700000.0, RequirementId.BuildingSkills(BuildingType.CropHarvester, 20));
			AddLevelWithCost(ItemType.RedCoin, 7000000.0, RequirementId.BuildingSkills(BuildingType.CropHarvester, 40));
			AddBuildingReqs(BuildingType.CropHarvester);
			break;
		case UpgradeType.FishingBoatYield:
			AddLevelWithCost(ItemType.RedCoin, 40000.0, RequirementId.BuildingSkills(BuildingType.FishingBoat, 20));
			AddLevelWithCost(ItemType.RedCoin, 400000.0, RequirementId.BuildingSkills(BuildingType.FishingBoat, 40));
			AddDisplayReq(new RequirementId(BiomeType.River));
			break;
		case UpgradeType.OmniSpeedLumberMill:
		case UpgradeType.OmniSpeedGrainMill:
		case UpgradeType.OmniSpeedWorkshop:
		case UpgradeType.OmniSpeedTailor:
		case UpgradeType.OmniSpeedStoneMason:
		case UpgradeType.OmniSpeedPasture:
		case UpgradeType.OmniSpeedForge:
		case UpgradeType.OmniSpeedBakery:
		case UpgradeType.OmniSpeedGourmetKitchen:
		case UpgradeType.OmniSpeedJeweler:
		case UpgradeType.OmniSpeedMachineShop:
		case UpgradeType.OmniSpeedMedicineHut:
		case UpgradeType.OmniSpeedEnchantedForge:
		case UpgradeType.OmniSpeedExtractor:
		case UpgradeType.OmniSpeedEnchanter:
		case UpgradeType.OmniSpeedRefinery:
		case UpgradeType.OmniSpeedManaReactor:
		case UpgradeType.OmniSpeedFarm:
		case UpgradeType.OmniSpeedForester:
		case UpgradeType.OmniSpeedQuarry:
		case UpgradeType.OmniSpeedMine:
		case UpgradeType.OmniSpeedGemMine:
		case UpgradeType.OmniSpeedFishery:
		case UpgradeType.OmniSpeedStudy:
		case UpgradeType.OmniSpeedTechLab:
		case UpgradeType.OmniSpeedMagicLab:
		case UpgradeType.OmniSpeedOmniTemple:
		case UpgradeType.OmniSpeedHarvesterHut:
		case UpgradeType.OmniSpeedFishingBoat:
		case UpgradeType.OmniSpeedChainsawTank:
		case UpgradeType.OmniSpeedHarvesterDrill:
		case UpgradeType.OmniSpeedCropHarvester:
		case UpgradeType.OmniSpeedFireShrine:
		case UpgradeType.OmniSpeedWaterShrine:
		case UpgradeType.OmniSpeedEarthShrine:
		case UpgradeType.OmniSpeedAirShrine:
		case UpgradeType.OmniSpeedFurnace:
		case UpgradeType.OmniSpeedWaterPump:
		case UpgradeType.OmniSpeedSteamBoiler:
		case UpgradeType.OmniSpeedSteamPowerGenerator:
		case UpgradeType.OmniSpeedAqueduct:
		case UpgradeType.OmniSpeedWell:
			AddLevelWithCost(ItemType.OmniCoin, GameUtility.ScaledValue(500.0, 0));
			AddDisplayReq(new RequirementId(ResearchType.OmnistoneUpgrades));
			if (type == UpgradeType.OmniSpeedFishery || type == UpgradeType.OmniSpeedFishingBoat)
			{
				AddDisplayReq(new RequirementId(BiomeType.River));
			}
			break;
		case UpgradeType.OmniProductivityLumberMill:
		case UpgradeType.OmniProductivityGrainMill:
		case UpgradeType.OmniProductivityWorkshop:
		case UpgradeType.OmniProductivityTailor:
		case UpgradeType.OmniProductivityStoneMason:
		case UpgradeType.OmniProductivityPasture:
		case UpgradeType.OmniProductivityForge:
		case UpgradeType.OmniProductivityBakery:
		case UpgradeType.OmniProductivityGourmetKitchen:
		case UpgradeType.OmniProductivityJeweler:
		case UpgradeType.OmniProductivityMachineShop:
		case UpgradeType.OmniProductivityMedicineHut:
		case UpgradeType.OmniProductivityEnchantedForge:
		case UpgradeType.OmniProductivityExtractor:
		case UpgradeType.OmniProductivityEnchanter:
		case UpgradeType.OmniProductivityRefinery:
		case UpgradeType.OmniProductivityManaReactor:
		case UpgradeType.OmniProductivityFarm:
		case UpgradeType.OmniProductivityForester:
		case UpgradeType.OmniProductivityQuarry:
		case UpgradeType.OmniProductivityMine:
		case UpgradeType.OmniProductivityGemMine:
		case UpgradeType.OmniProductivityFishery:
		case UpgradeType.OmniProductivityStudy:
		case UpgradeType.OmniProductivityTechLab:
		case UpgradeType.OmniProductivityMagicLab:
		case UpgradeType.OmniProductivityOmniTemple:
		case UpgradeType.OmniCapacityFoodMarket:
		case UpgradeType.OmniCapacityGeneralStore:
		case UpgradeType.OmniCapacityHardwareStore:
		case UpgradeType.OmniCapacityBookstore:
		case UpgradeType.OmniCapacityClothingStore:
		case UpgradeType.OmniCapacityGourmetFoods:
		case UpgradeType.OmniCapacityApothecary:
		case UpgradeType.OmniCapacityJewelryStore:
		case UpgradeType.OmniCapacityArcaneStore:
		case UpgradeType.OmniSolarPanelEffectiveness:
			AddLevelWithCost(ItemType.OmniCoin, GameUtility.ScaledValue(50000.0, 0));
			AddDisplayReq(new RequirementId(ResearchType.OmnistoneUpgrades));
			if (type == UpgradeType.OmniSpeedFishery || type == UpgradeType.OmniProductivityFishery)
			{
				AddDisplayReq(new RequirementId(BiomeType.River));
			}
			if (type == UpgradeType.OmniSolarPanelEffectiveness)
			{
				AddDisplayReq(new RequirementId(BiomeType.Desert));
			}
			break;
		case UpgradeType.OmniResearchSpeed:
			AddLevelWithCost(ItemType.OmniCoin, GameUtility.ScaledValue(500.0, 0));
			AddDisplayReq(new RequirementId(ResearchType.OmnistoneUpgrades));
			break;
		case UpgradeType.StoneMasonProficiency:
		{
			for (int num84 = 0; num84 < 5; num84++)
			{
				AddLevelWithCost(ItemType.RedCoin, 20000f * Mathf.Pow(10f, num84));
			}
			break;
		}
		case UpgradeType.HarvesterHutProficiency:
		{
			for (int num76 = 0; num76 < 5; num76++)
			{
				AddLevelWithCost(ItemType.RedCoin, 10000f * Mathf.Pow(10f, num76));
			}
			break;
		}
		case UpgradeType.FishingBoatProficiency:
		{
			for (int num65 = 0; num65 < 5; num65++)
			{
				AddLevelWithCost(ItemType.RedCoin, 10000f * Mathf.Pow(10f, num65));
			}
			AddDisplayReq(new RequirementId(BiomeType.River));
			break;
		}
		case UpgradeType.CropHarvesterProficiency:
		{
			for (int num58 = 0; num58 < 5; num58++)
			{
				AddLevelWithCost(ItemType.RedCoin, 30000f * Mathf.Pow(10f, num58));
			}
			break;
		}
		case UpgradeType.ChainsawTankProficiency:
		{
			for (int num50 = 0; num50 < 5; num50++)
			{
				AddLevelWithCost(ItemType.RedCoin, 40000f * Mathf.Pow(10f, num50));
			}
			break;
		}
		case UpgradeType.HarvesterDrillProficiency:
		{
			for (int num43 = 0; num43 < 5; num43++)
			{
				AddLevelWithCost(ItemType.RedCoin, 50000f * Mathf.Pow(10f, num43));
			}
			break;
		}
		case UpgradeType.TailorProficiency:
		{
			for (int num36 = 0; num36 < 5; num36++)
			{
				AddLevelWithCost(ItemType.RedCoin, 50000f * Mathf.Pow(10f, num36));
			}
			break;
		}
		case UpgradeType.WorkshopProficiency:
		{
			for (int num28 = 0; num28 < 5; num28++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(30000.0, num28));
			}
			break;
		}
		case UpgradeType.GrainMillProficiency:
		{
			for (int num20 = 0; num20 < 5; num20++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(40000.0, num20));
			}
			break;
		}
		case UpgradeType.ForgeProficiency:
		{
			for (int num13 = 0; num13 < 10; num13++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledTenValue(100000.0, num13));
			}
			break;
		}
		case UpgradeType.EnchantedForgeProficiency:
		{
			for (int num5 = 0; num5 < 5; num5++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(200000.0, num5));
			}
			break;
		}
		case UpgradeType.WaterPumpCountSpeed:
			AddLevels(10, ItemType.RedCoin, 50000.0);
			break;
		case UpgradeType.FurnaceCountSpeed:
			AddLevels(10, ItemType.RedCoin, 50000.0);
			break;
		case UpgradeType.SteamBoilerCountSpeed:
			AddLevels(10, ItemType.RedCoin, 100000.0);
			break;
		case UpgradeType.SteamPowerGeneratorCountSpeed:
			AddLevels(10, ItemType.RedCoin, 200000.0);
			break;
		case UpgradeType.ExtractorCountSpeed:
		{
			for (int num104 = 0; num104 < 10; num104++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(500000.0, num104));
			}
			break;
		}
		case UpgradeType.ExtractorProficiency:
		{
			for (int num100 = 0; num100 < 5; num100++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledHundredValue(500000.0, num100));
			}
			break;
		}
		case UpgradeType.FireShrineSpeed:
		{
			AddBuildingReqs(BuildingType.FireShrine);
			AddLevels(5, ItemType.PurpleCoin, GameUtility.Billions(1));
			for (int num96 = 0; num96 < levels.Count; num96++)
			{
				levels[num96].AddRequirement(new RequirementId(BuildingType.FireShrine, (num96 + 1) * 10));
			}
			break;
		}
		case UpgradeType.WaterShrineSpeed:
		{
			AddBuildingReqs(BuildingType.WaterShrine);
			AddLevels(5, ItemType.PurpleCoin, GameUtility.Billions(1));
			for (int num93 = 0; num93 < levels.Count; num93++)
			{
				levels[num93].AddRequirement(new RequirementId(BuildingType.WaterShrine, (num93 + 1) * 10));
			}
			break;
		}
		case UpgradeType.EarthShrineSpeed:
		{
			AddBuildingReqs(BuildingType.EarthShrine);
			AddLevels(5, ItemType.PurpleCoin, GameUtility.Billions(1));
			for (int num90 = 0; num90 < levels.Count; num90++)
			{
				levels[num90].AddRequirement(new RequirementId(BuildingType.EarthShrine, (num90 + 1) * 10));
			}
			break;
		}
		case UpgradeType.AirShrineSpeed:
		{
			AddBuildingReqs(BuildingType.AirShrine);
			AddLevels(5, ItemType.PurpleCoin, GameUtility.Billions(1));
			for (int num86 = 0; num86 < levels.Count; num86++)
			{
				levels[num86].AddRequirement(new RequirementId(BuildingType.AirShrine, (num86 + 1) * 10));
			}
			break;
		}
		case UpgradeType.TempleEffectivenessMana:
		{
			AddBuildingReqs(BuildingType.ManaTemple);
			AddLevels(5, ItemType.PurpleCoin, GameUtility.Billions(1));
			for (int num82 = 0; num82 < levels.Count; num82++)
			{
				levels[num82].AddRequirement(new RequirementId(BuildingType.ManaTemple, (num82 + 1) * 10));
			}
			break;
		}
		case UpgradeType.TempleEffectivenessFire:
		{
			AddBuildingReqs(BuildingType.FireTemple);
			AddLevels(5, ItemType.PurpleCoin, 10000.0);
			for (int num78 = 0; num78 < levels.Count; num78++)
			{
				levels[num78].AddRequirement(new RequirementId(BuildingType.FireTemple, (num78 + 1) * 10));
			}
			break;
		}
		case UpgradeType.TempleEffectivenessWater:
		{
			AddBuildingReqs(BuildingType.WaterTemple);
			AddLevels(5, ItemType.PurpleCoin, 10000.0);
			for (int num74 = 0; num74 < levels.Count; num74++)
			{
				levels[num74].AddRequirement(new RequirementId(BuildingType.WaterTemple, (num74 + 1) * 10));
			}
			break;
		}
		case UpgradeType.TempleEffectivenessEarth:
		{
			AddBuildingReqs(BuildingType.EarthTemple);
			AddLevels(5, ItemType.PurpleCoin, 10000.0);
			for (int num70 = 0; num70 < levels.Count; num70++)
			{
				levels[num70].AddRequirement(new RequirementId(BuildingType.EarthTemple, (num70 + 1) * 10));
			}
			break;
		}
		case UpgradeType.TempleEffectivenessAir:
		{
			AddBuildingReqs(BuildingType.AirTemple);
			AddLevels(5, ItemType.PurpleCoin, 10000.0);
			for (int num67 = 0; num67 < levels.Count; num67++)
			{
				levels[num67].AddRequirement(new RequirementId(BuildingType.AirTemple, (num67 + 1) * 10));
			}
			break;
		}
		case UpgradeType.JewelerProficiency:
		{
			for (int num63 = 0; num63 < 5; num63++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledHundredValue(500000.0, num63));
			}
			break;
		}
		case UpgradeType.QuarryProficiency:
		{
			for (int num60 = 0; num60 < 5; num60++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledHundredValue(50000.0, num60));
			}
			break;
		}
		case UpgradeType.MineProficiency:
		{
			for (int num55 = 0; num55 < 5; num55++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledHundredValue(50000.0, num55));
			}
			break;
		}
		case UpgradeType.GemMineProficiency:
		{
			for (int num52 = 0; num52 < 5; num52++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledHundredValue(500000.0, num52));
			}
			break;
		}
		case UpgradeType.RefineryProficiency:
		{
			for (int num48 = 0; num48 < 5; num48++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledHundredValue(500000.0, num48));
			}
			break;
		}
		case UpgradeType.EnchanterProficiency:
		{
			for (int num45 = 0; num45 < 5; num45++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledHundredValue(500000.0, num45));
			}
			break;
		}
		case UpgradeType.PastureProficiency:
		{
			for (int num41 = 0; num41 < 5; num41++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledHundredValue(75000.0, num41));
			}
			break;
		}
		case UpgradeType.GourmetKitchenProficiency:
		{
			for (int num38 = 0; num38 < 5; num38++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledHundredValue(GameUtility.Millions(1), num38));
			}
			break;
		}
		case UpgradeType.StudyProficiency:
		{
			for (int num34 = 0; num34 < 5; num34++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledHundredValue(25000.0, num34));
			}
			break;
		}
		case UpgradeType.TechLabProficiency:
		{
			for (int num30 = 0; num30 < 5; num30++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledHundredValue(GameUtility.Millions(1), num30));
			}
			break;
		}
		case UpgradeType.MagicLabProficiency:
		{
			for (int num26 = 0; num26 < 5; num26++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledHundredValue(GameUtility.Millions(1), num26));
			}
			break;
		}
		case UpgradeType.BakeryProficiency:
		{
			for (int num22 = 0; num22 < 5; num22++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledHundredValue(75000.0, num22));
			}
			break;
		}
		case UpgradeType.MachineShopProficiency:
		{
			for (int num18 = 0; num18 < 5; num18++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledHundredValue(500000.0, num18));
			}
			break;
		}
		case UpgradeType.MedicineHutProficiency:
		{
			for (int num15 = 0; num15 < 5; num15++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledHundredValue(250000.0, num15));
			}
			break;
		}
		case UpgradeType.LumberMillProficiency:
		{
			for (int num11 = 0; num11 < 5; num11++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledHundredValue(10000.0, num11));
			}
			break;
		}
		case UpgradeType.FarmingProficiency:
		{
			for (int num7 = 0; num7 < 5; num7++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledHundredValue(70000.0, num7));
			}
			break;
		}
		case UpgradeType.FisheryProficiency:
		{
			for (int num3 = 0; num3 < 5; num3++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledHundredValue(90000.0, num3));
			}
			break;
		}
		case UpgradeType.ForesterProficiency:
		{
			for (int n = 0; n < 5; n++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledHundredValue(80000.0, n));
			}
			break;
		}
		case UpgradeType.FurnaceSpeed:
			AddDisplayReq(new RequirementId(ResearchType.ImprovedFurnace));
			AddLevelWithCost(ItemType.RedCoin, 250000.0);
			AddLevelWithCost(ItemType.RedCoin, 2500000.0);
			AddLevelWithCost(ItemType.RedCoin, 25000000.0);
			AddDisplayReq(new RequirementId(ResearchType.Furnace));
			break;
		case UpgradeType.FuelEfficiency:
		{
			AddDisplayReq(new RequirementId(ResearchType.FuelEfficiency));
			for (int j = 0; j < 5; j++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledHundredValue(GameUtility.Millions(1), j));
			}
			break;
		}
		case UpgradeType.FurnaceProductivity:
		{
			AddDisplayReq(new RequirementId(ResearchType.ImprovedFurnace));
			for (int num107 = 0; num107 < 3; num107++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledTenValue(GameUtility.Millions(1), num107));
			}
			AddDisplayReq(new RequirementId(ResearchType.Furnace));
			break;
		}
		case UpgradeType.BuildingConstructionSpeedGrowth:
		{
			for (int num105 = 0; num105 < 8; num105++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledValue(500.0, num105));
			}
			break;
		}
		case UpgradeType.HouseCapacity:
		{
			popupParentEntity.Add(EntityId.FromBuilding(BuildingType.House));
			for (int num103 = 0; num103 < 9; num103++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(5000.0, num103));
			}
			break;
		}
		case UpgradeType.SellValueYellowCoin:
		{
			for (int num101 = 0; num101 < 5; num101++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(5000000.0, num101));
			}
			break;
		}
		case UpgradeType.SellValueRedCoin:
		{
			for (int num99 = 0; num99 < 5; num99++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledValue(2000000.0, num99));
			}
			break;
		}
		case UpgradeType.SellValueBlueCoin:
		{
			for (int num97 = 0; num97 < 5; num97++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledValue(1000000.0, num97));
			}
			break;
		}
		case UpgradeType.SellValuePurpleCoin:
		{
			for (int num95 = 0; num95 < 5; num95++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledValue(500000.0, num95));
			}
			break;
		}
		case UpgradeType.Exploration:
		{
			for (int num94 = 0; num94 < 10; num94++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(10000.0, num94));
			}
			break;
		}
		case UpgradeType.ResearchSpeed:
		{
			popupParentEntity.Add(EntityId.FromBuilding(BuildingType.School));
			for (int num92 = 0; num92 < 10; num92++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(50000.0, num92));
			}
			break;
		}
		case UpgradeType.SkillEffectCrafting:
		{
			for (int num91 = 0; num91 < 3; num91++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(8000.0, num91));
			}
			break;
		}
		case UpgradeType.SkillEffectCultivation:
		{
			for (int num89 = 0; num89 < 3; num89++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(10000.0, num89));
			}
			break;
		}
		case UpgradeType.SkillEffectHarvesting:
		{
			for (int num87 = 0; num87 < 3; num87++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(5000.0, num87));
			}
			break;
		}
		case UpgradeType.SkillEffectProspecting:
		{
			for (int num85 = 0; num85 < 3; num85++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(5000.0, num85));
			}
			break;
		}
		case UpgradeType.FoodMarketCapacity:
		{
			for (int num83 = 0; num83 < 10; num83++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(20000.0, num83));
			}
			break;
		}
		case UpgradeType.HardwareStoreCapacity:
		{
			for (int num81 = 0; num81 < 10; num81++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(20000.0, num81));
			}
			break;
		}
		case UpgradeType.BookstoreCapacity:
		{
			for (int num79 = 0; num79 < 10; num79++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(10000.0, num79));
			}
			break;
		}
		case UpgradeType.GeneralGoodsCapacity:
		{
			for (int num77 = 0; num77 < 10; num77++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(20000.0, num77));
			}
			break;
		}
		case UpgradeType.ClothingStoreCapacity:
		{
			for (int num75 = 0; num75 < 10; num75++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(20000.0, num75));
			}
			break;
		}
		case UpgradeType.ApothecaryCapacity:
		{
			for (int num73 = 0; num73 < 10; num73++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledTenValue(100000.0, num73));
			}
			break;
		}
		case UpgradeType.ArcaneStoreCapacity:
		{
			for (int num71 = 0; num71 < 10; num71++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(100000.0, num71));
			}
			break;
		}
		case UpgradeType.JewelryStoreCapacity:
		{
			for (int num69 = 0; num69 < 10; num69++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledTenValue(50000.0, num69));
			}
			break;
		}
		case UpgradeType.FancyFoodsCapacity:
		{
			for (int num68 = 0; num68 < 4; num68++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledHundredValue(500000.0, num68));
			}
			break;
		}
		case UpgradeType.TradingPostWorkersPerBuilding:
		{
			for (int num66 = 0; num66 < 10; num66++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(5000000.0, num66));
			}
			break;
		}
		case UpgradeType.Supermarket:
			AddLevelWithCost(ItemType.YellowCoin, GameUtility.Billions(100), RequirementId.MarketSellCount(BuildingType.Market, GameUtility.Millions(10)));
			break;
		case UpgradeType.SellSpeedYellowCoin:
		{
			AddDisplayReq(new RequirementId(ResearchType.CashRegisters));
			for (int num64 = 0; num64 < 6; num64++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(GameUtility.Billions(1), num64));
				double count4 = GameUtility.ScaledTenValue(GameUtility.Billions(1), num64);
				levels[num64].AddRequirement(new RequirementId(ItemType.YellowCoin, count4, global: false));
			}
			break;
		}
		case UpgradeType.SellSpeedRedCoin:
		{
			AddDisplayReq(new RequirementId(ResearchType.CashRegisters));
			for (int num62 = 0; num62 < 6; num62++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(GameUtility.Billions(1), num62));
				double count3 = GameUtility.ScaledTenValue(GameUtility.Millions(100), num62);
				levels[num62].AddRequirement(new RequirementId(ItemType.RedCoin, count3, global: false));
			}
			break;
		}
		case UpgradeType.SellSpeedBlueCoin:
		{
			AddDisplayReq(new RequirementId(ResearchType.CashRegisters));
			for (int num61 = 0; num61 < 6; num61++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(GameUtility.Billions(1), num61));
				double count2 = GameUtility.ScaledTenValue(GameUtility.Millions(10), num61);
				levels[num61].AddRequirement(new RequirementId(ItemType.BlueCoin, count2, global: false));
			}
			break;
		}
		case UpgradeType.SellSpeedPurpleCoin:
		{
			AddDisplayReq(new RequirementId(ResearchType.CashRegisters));
			for (int num59 = 0; num59 < 6; num59++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledValue(GameUtility.Billions(1), num59));
				double count = GameUtility.ScaledTenValue(GameUtility.Millions(1), num59);
				levels[num59].AddRequirement(new RequirementId(ItemType.PurpleCoin, count, global: false));
			}
			break;
		}
		case UpgradeType.SellSpeedOmniCoin:
		{
			AddDisplayReq(new RequirementId(ResearchType.CashRegisters));
			AddDisplayReq(new RequirementId(ResearchType.OmnistoneUpgrades));
			for (int num56 = 0; num56 < 4; num56++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(1000000.0, num56));
				float num57 = GameUtility.AsFloat(GameUtility.ScaledValue(1000.0, num56));
				levels[num56].AddRequirement(new RequirementId(ItemType.OmniCoin, num57, global: false));
			}
			break;
		}
		case UpgradeType.YellowCoinXP:
		{
			AddDisplayReq(new RequirementId(QuestType.UnlockYellowCoinXP));
			for (int num54 = 0; num54 < 10; num54++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(GameUtility.Millions(1), num54));
			}
			break;
		}
		case UpgradeType.RedCoinXP:
		{
			AddDisplayReq(new RequirementId(QuestType.UnlockRedCoinXP));
			for (int num53 = 0; num53 < 10; num53++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(500000.0, num53));
			}
			break;
		}
		case UpgradeType.BlueCoinXP:
		{
			AddDisplayReq(new RequirementId(QuestType.UnlockBlueCoinXP));
			for (int num51 = 0; num51 < 10; num51++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledTenValue(200000.0, num51));
			}
			break;
		}
		case UpgradeType.PurpleCoinXP:
		{
			AddDisplayReq(new RequirementId(QuestType.UnlockPurpleCoinXP));
			AddDisplayReq(new RequirementId(QuestType.HarvestManaForArcaneEmporium));
			for (int num49 = 0; num49 < 10; num49++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(100000.0, num49));
			}
			break;
		}
		case UpgradeType.OmniCoinXP:
		{
			AddDisplayReq(new RequirementId(QuestType.UnlockOmniCoinXP));
			for (int num47 = 0; num47 < 10; num47++)
			{
				AddLevelWithCost(ItemType.OmniCoin, GameUtility.ScaledTenValue(10000.0, num47));
			}
			break;
		}
		case UpgradeType.HouseCost:
			AddLevelWithCost(ItemType.RedCoin, 10000.0);
			AddLevelWithCost(ItemType.RedCoin, 50000.0);
			AddLevelWithCost(ItemType.RedCoin, 250000.0);
			AddLevelWithCost(ItemType.RedCoin, 1250000.0);
			AddLevelWithCost(ItemType.RedCoin, 6250000.0);
			break;
		case UpgradeType.AqueductEffectiveness:
		{
			for (int num46 = 0; num46 < 5; num46++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledTenValue(10000.0, num46));
			}
			break;
		}
		case UpgradeType.WellEffectiveness:
		{
			for (int num44 = 0; num44 < 5; num44++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(100000.0, num44));
			}
			break;
		}
		case UpgradeType.PowerLineSpeed:
		{
			for (int num42 = 0; num42 < 10; num42++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(GameUtility.Millions(1), num42));
			}
			break;
		}
		case UpgradeType.SteamPipeSpeed:
		{
			for (int num40 = 0; num40 < 10; num40++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(GameUtility.Millions(1), num40));
			}
			break;
		}
		case UpgradeType.MagmaPipeSpeed:
		{
			for (int num39 = 0; num39 < 10; num39++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(GameUtility.Millions(10), num39));
			}
			break;
		}
		case UpgradeType.ManaPipeSpeed:
		{
			for (int num37 = 0; num37 < 10; num37++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledTenValue(GameUtility.Millions(10), num37));
			}
			break;
		}
		case UpgradeType.OmniPipeSpeed:
		{
			for (int num35 = 0; num35 < 10; num35++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(GameUtility.Millions(100), num35));
			}
			break;
		}
		case UpgradeType.WaterWheelEffectiveness:
		{
			for (int num33 = 0; num33 < 5; num33++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(25000.0, num33));
			}
			break;
		}
		case UpgradeType.SolarPanelEffectiveness:
		{
			for (int num31 = 0; num31 < 5; num31++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(100000.0, num31));
			}
			break;
		}
		case UpgradeType.SkillGainSpeed:
		{
			for (int num29 = 0; num29 < 10; num29++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(1000.0, num29));
			}
			break;
		}
		case UpgradeType.BarrelCapacity:
		{
			for (int num27 = 0; num27 < 10; num27++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(10000.0, num27));
			}
			break;
		}
		case UpgradeType.StockpileCapacity:
		{
			for (int num25 = 0; num25 < 10; num25++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(1000.0, num25));
			}
			break;
		}
		case UpgradeType.WarehouseCapacity:
		{
			for (int num23 = 0; num23 < 10; num23++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(100000.0, num23));
			}
			break;
		}
		case UpgradeType.CropSiloCapacity:
		{
			for (int num21 = 0; num21 < 10; num21++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(50000.0, num21));
			}
			break;
		}
		case UpgradeType.SteamBoilerStorageCapacity:
		{
			for (int num19 = 0; num19 < 10; num19++)
			{
				AddLevelWithCost(ItemType.BlueCoin, GameUtility.ScaledTenValue(100000.0, num19));
			}
			break;
		}
		case UpgradeType.FurnaceStorageCapacity:
		{
			for (int num17 = 0; num17 < 10; num17++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(10000.0, num17));
			}
			break;
		}
		case UpgradeType.UpgradeEfficiency:
		{
			for (int num16 = 0; num16 < 25; num16++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(10000.0, num16));
			}
			break;
		}
		case UpgradeType.MarketCostFood:
		case UpgradeType.MarketCostGeneral:
		case UpgradeType.MarketCostHardware:
		case UpgradeType.MarketCostBookstore:
		case UpgradeType.MarketCostClothing:
		case UpgradeType.MarketCostGourmet:
		case UpgradeType.MarketCostApothecary:
		case UpgradeType.MarketCostJewelry:
		case UpgradeType.MarketCostArcane:
		{
			for (int num14 = 0; num14 < 5; num14++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(GameUtility.Millions(10), num14));
			}
			break;
		}
		case UpgradeType.ConstructionEfficiency:
		{
			for (int num12 = 0; num12 < 25; num12++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledValue(10000.0, num12));
			}
			break;
		}
		case UpgradeType.OreSiloCapacity:
		{
			for (int num10 = 0; num10 < 10; num10++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(10000.0, num10));
			}
			break;
		}
		case UpgradeType.PantryCapacity:
		{
			for (int num8 = 0; num8 < 10; num8++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(50000.0, num8));
			}
			break;
		}
		case UpgradeType.TreasuryCapacity:
			AddLevels(10, ItemType.BlueCoin, 5000.0);
			break;
		case UpgradeType.OmnistoneStorageCapacity:
		{
			for (int num6 = 0; num6 < 10; num6++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(50000.0, num6));
			}
			break;
		}
		case UpgradeType.BatteryCapacity:
		{
			for (int num4 = 0; num4 < 10; num4++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(1000000.0, num4));
			}
			break;
		}
		case UpgradeType.LibraryCapacity:
		{
			for (int num2 = 0; num2 < 10; num2++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(100000.0, num2));
			}
			break;
		}
		case UpgradeType.ManaBatteryCapacity:
		{
			for (int num = 0; num < 10; num++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(50000.0, num));
			}
			break;
		}
		case UpgradeType.CrystalariumCapacity:
		{
			for (int m = 0; m < 10; m++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(40000.0, m));
			}
			break;
		}
		case UpgradeType.TradingPostStorageCapacity:
		{
			for (int l = 0; l < 10; l++)
			{
				AddLevelWithCost(ItemType.YellowCoin, GameUtility.ScaledTenValue(5000000.0, l));
			}
			break;
		}
		case UpgradeType.ReservoirCapacity:
		{
			for (int k = 0; k < 10; k++)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledTenValue(4000.0, k));
			}
			break;
		}
		case UpgradeType.EtherStorageCapacity:
		{
			for (int i = 0; i < 10; i++)
			{
				AddLevelWithCost(ItemType.PurpleCoin, GameUtility.ScaledTenValue(50000.0, i));
			}
			break;
		}
		case (UpgradeType)8:
		case (UpgradeType)9:
		case UpgradeType.CoalProspectingSpeed:
		case UpgradeType.IronProspectingSpeed:
		case UpgradeType.CopperProspectingSpeed:
		case UpgradeType.GoldProspectingSpeed:
		case UpgradeType.ManaProspectingSpeed:
		case UpgradeType.GemRedProspectingSpeed:
		case UpgradeType.GemYellowProspectingSpeed:
		case UpgradeType.GemAquaProspectingSpeed:
		case UpgradeType.GemPurpleProspectingSpeed:
		case UpgradeType.GrainFarmingSpeed:
		case UpgradeType.CottonFarmingSpeed:
		case UpgradeType.HerbFarmingSpeed:
		case UpgradeType.PotatoFarmingSpeed:
		case UpgradeType.TomatoFarmingSpeed:
		case UpgradeType.SugarFarmingSpeed:
		case UpgradeType.AppleFarmingSpeed:
		case UpgradeType.PearFarmingSpeed:
		case UpgradeType.BerryFarmingSpeed:
		case UpgradeType.CactusFarmingSpeed:
		case UpgradeType.DragonFarmingSpeed:
		case UpgradeType.CarrotFarmingSpeed:
		case UpgradeType.TreeFarmingSpeed:
		case UpgradeType.RockHarvestingSpeed:
		case UpgradeType.CoalHarvestingSpeed:
		case UpgradeType.IronHarvestingSpeed:
		case UpgradeType.CopperHarvestingSpeed:
		case UpgradeType.GoldHarvestingSpeed:
		case UpgradeType.ManaHarvestingSpeed:
		case UpgradeType.GemRedHarvestingSpeed:
		case UpgradeType.GemYellowHarvestingSpeed:
		case UpgradeType.GemAquaHarvestingSpeed:
		case UpgradeType.GemPurpleHarvestingSpeed:
		case UpgradeType.GrainHarvestingSpeed:
		case UpgradeType.CottonHarvestingSpeed:
		case UpgradeType.HerbHarvestingSpeed:
		case UpgradeType.PotatoHarvestingSpeed:
		case UpgradeType.TomatoHarvestingSpeed:
		case UpgradeType.SugarHarvestingSpeed:
		case UpgradeType.AppleHarvestingSpeed:
		case UpgradeType.PearHarvestingSpeed:
		case UpgradeType.BerryHarvestingSpeed:
		case UpgradeType.CactusHarvestingSpeed:
		case UpgradeType.DragonHarvestingSpeed:
		case UpgradeType.CarrotHarvestingSpeed:
		case UpgradeType.TreeHarvestingSpeed:
		case UpgradeType.FishFarmingSpeed:
		case UpgradeType.FishHarvestingSpeed:
		case (UpgradeType)58:
		case (UpgradeType)64:
		case UpgradeType.ManaPowerDrills_Legacy:
		case UpgradeType.ManaPowerCropHarvesters_Legacy:
		case (UpgradeType)81:
		case (UpgradeType)85:
		case UpgradeType.SilverProspectingSpeed:
		case (UpgradeType)87:
		case (UpgradeType)88:
		case (UpgradeType)89:
		case (UpgradeType)90:
		case (UpgradeType)91:
		case (UpgradeType)97:
		case (UpgradeType)135:
		case (UpgradeType)142:
		case UpgradeType.RockProspectingSpeed:
		case UpgradeType.SilverHarvestingSpeed:
		case UpgradeType.MinigameMiningYield:
		case UpgradeType.MinigameMiningEnergyMax:
		case UpgradeType.MinigameMiningEnergyRate:
		case UpgradeType.MinigameFarmingYield:
		case UpgradeType.MinigameFarmingEnergyMax:
		case UpgradeType.MinigameFarmingEnergyRate:
		case UpgradeType.MinigameDiceYield:
		case UpgradeType.MinigameDiceEnergyMax:
		case UpgradeType.MinigameDiceEnergyRate:
		case UpgradeType.MinigameResearchYield:
		case UpgradeType.MinigameResearchEnergyMax:
		case UpgradeType.MinigameResearchEnergyRate:
		case UpgradeType.MinigameWaterYield:
		case UpgradeType.MinigameWaterEnergyMax:
		case UpgradeType.MinigameWaterEnergyRate:
		case UpgradeType.MinigameWoodYield:
		case UpgradeType.MinigameWoodEnergyMax:
		case UpgradeType.MinigameWoodEnergyRate:
		case (UpgradeType)170:
		case UpgradeType.LuckyPickaxe:
		case (UpgradeType)173:
		case UpgradeType.ShrineSpeed_Legacy:
		case UpgradeType.WaterHarvestingSpeed:
		case UpgradeType.ManaChainsawTanks_Legacy:
		case UpgradeType.ManaPowerTractors_Legacy:
		case (UpgradeType)246:
		case (UpgradeType)247:
		case (UpgradeType)248:
		case (UpgradeType)249:
		case (UpgradeType)250:
		case (UpgradeType)251:
		case (UpgradeType)252:
		case (UpgradeType)253:
		case (UpgradeType)254:
		case (UpgradeType)255:
		case (UpgradeType)264:
		case (UpgradeType)265:
		case (UpgradeType)266:
		case (UpgradeType)267:
		case (UpgradeType)268:
		case (UpgradeType)269:
		case (UpgradeType)270:
		case (UpgradeType)271:
		case (UpgradeType)272:
		case (UpgradeType)273:
		case (UpgradeType)274:
		case (UpgradeType)275:
		case (UpgradeType)276:
		case (UpgradeType)277:
		case (UpgradeType)278:
		case (UpgradeType)279:
		case (UpgradeType)280:
		case (UpgradeType)281:
		case (UpgradeType)282:
		case UpgradeType.FishingNetHarvestingSpeed:
		case UpgradeType.FishingMagicNetHarvestingSpeed:
		case UpgradeType.SandHarvestingSpeed:
		case (UpgradeType)331:
			break;
		}
	}

	private void AddBuildingReqs(BuildingType t)
	{
		foreach (RequirementId requirement in Crafting.buildingCache[t].requirements)
		{
			AddDisplayReq(requirement);
		}
	}

	private void ConfigureSkillUpgrade(int numLevels, double startingValue = 15000.0)
	{
		for (int i = 0; i < numLevels; i++)
		{
			double amount = GameUtility.ScaledTenValue(startingValue, i);
			AddLevel().AddCost(ItemType.RedCoin, amount);
		}
	}

	private void AddLevels(int numLevels, ItemType coinType, double valueToScale)
	{
		for (int i = 0; i < numLevels; i++)
		{
			AddLevelWithCost(coinType, GameUtility.ScaledValue(valueToScale, i));
		}
	}

	private void AddLevelWithCost(ItemType coinCost, double costAmount)
	{
		AddLevel().AddCost(coinCost, costAmount);
	}

	private void AddLevelWithCost(ItemType coinCost, double costAmount, RequirementId req)
	{
		UpgradeLevelDef upgradeLevelDef = AddLevel();
		upgradeLevelDef.AddCost(coinCost, costAmount);
		upgradeLevelDef.unlockRequirements.Add(req);
	}

	private UpgradeLevelDef AddLevel()
	{
		UpgradeLevelDef upgradeLevelDef = new UpgradeLevelDef(type);
		levels.Add(upgradeLevelDef);
		return upgradeLevelDef;
	}

	private void ConfigureUpgradesWithRequiredQuest(QuestType t)
	{
		for (int i = 0; i < 5; i++)
		{
			if (i == 0)
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledValue(3000.0, i), new RequirementId(t));
			}
			else
			{
				AddLevelWithCost(ItemType.RedCoin, GameUtility.ScaledValue(3000.0, i));
			}
		}
	}

	private static RequirementId DynamicResearch(DynamicResearchType t, int index)
	{
		return new RequirementId(Research.DynamicResearch(t, index));
	}

	public void AddHarvestRequirement(HarvestRecipeType t)
	{
		if (Crafting.harvestRecipeCache.TryGetValue(t, out var value) && Crafting.naturalResourceCache.TryGetValue(value.resourceType, out var value2) && value2.exclusiveBiome != BiomeType.None)
		{
			displayRequirements.Add(new RequirementId(value2.exclusiveBiome));
		}
	}
}
