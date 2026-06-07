using System.Collections.Generic;

public class Upgrade
{
	public readonly UpgradeType type;

	public readonly List<UpgradeLevel> levels = new List<UpgradeLevel>();

	public bool isInAlertState;

	public readonly UpgradeDef def;

	private static readonly ItemList reusableCostList = new ItemList();

	public int numCompleted;

	private readonly GrowthRateType growthRateType;

	public float growthValue;

	public readonly Town parentTown;

	public BuildObjectAvailability displayAvailability;

	public bool currentLevelAvailability;

	public ItemState cachedCurrentCostItem;

	public double cachedCurrentCostAmount;

	public List<Requirement> displayRequirements = new List<Requirement>();

	public BuildObjectAvailability derivedAvailability
	{
		get
		{
			if (displayAvailability != BuildObjectAvailability.Available || currentLevelAvailability)
			{
				return displayAvailability;
			}
			return BuildObjectAvailability.InProgress;
		}
	}

	public Upgrade(UpgradeDef upgradeDef, Town town)
	{
		def = upgradeDef;
		parentTown = town;
		type = def.type;
		growthRateType = GrowthTypeForUpgrade(type);
		growthValue = BonusForUpgrade(type);
		int num = 0;
		foreach (UpgradeLevelDef level in def.levels)
		{
			UpgradeLevel item = new UpgradeLevel(this, level, num);
			levels.Add(item);
			num++;
		}
	}

	public void Reset()
	{
		numCompleted = 0;
		isInAlertState = false;
		cachedCurrentCostAmount = 0.0;
		cachedCurrentCostItem = null;
		displayAvailability = BuildObjectAvailability.None;
		currentLevelAvailability = false;
	}

	public void SetNumCompleted(int next)
	{
		numCompleted = next;
		CalcAvailability();
		StoreCurrentLevelCost();
	}

	public IEnumerable<Requirement> CurrentLevelRequirements()
	{
		int num = numCompleted;
		if (num < 0 || num >= levels.Count)
		{
			return null;
		}
		return levels[num].ConfirmedRequirements();
	}

	public bool CanAffordCurrentLevel()
	{
		if (cachedCurrentCostItem == null)
		{
			return false;
		}
		return cachedCurrentCostItem.currentCount >= cachedCurrentCostAmount;
	}

	public void StoreCurrentLevelCost()
	{
		ItemList itemList = CostFromCurrentLevel(numCompleted);
		cachedCurrentCostItem = null;
		using (Dictionary<ItemType, double>.Enumerator enumerator = itemList.items.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<ItemType, double> current = enumerator.Current;
				if (parentTown.inventory.TryGetValue(current.Key, out var value))
				{
					cachedCurrentCostItem = value;
				}
				cachedCurrentCostAmount = current.Value;
				return;
			}
		}
		_ = cachedCurrentCostItem;
	}

	public ItemList CostFromCurrentLevel(int currentLevel)
	{
		reusableCostList.Clear();
		double wonderMultiplierUniversity = GameManager.Instance.wonderMultiplierUniversity;
		if (currentLevel < levels.Count)
		{
			foreach (KeyValuePair<ItemType, double> item in levels[currentLevel].def.levelCosts.items)
			{
				float num = parentTown.MultiplierForUpgrade(UpgradeType.UpgradeEfficiency);
				double count = GameUtility.TruncateToSignificantDigits(item.Value * (double)num * wonderMultiplierUniversity, 2);
				reusableCostList.AddItem(item.Key, count);
			}
			return reusableCostList;
		}
		if (levels.Count >= 1)
		{
			foreach (KeyValuePair<ItemType, double> item2 in levels[0].def.levelCosts.items)
			{
				double num2 = GameUtility.ScaledValue(item2.Value, currentLevel);
				float num3 = parentTown.MultiplierForUpgrade(UpgradeType.UpgradeEfficiency);
				double count2 = GameUtility.TruncateToSignificantDigits(num2 * (double)num3 * wonderMultiplierUniversity, 2);
				reusableCostList.AddItem(item2.Key, count2);
			}
			return reusableCostList;
		}
		return ItemList.Zero;
	}

	public static GrowthRateType GrowthTypeForUpgrade(UpgradeType t)
	{
		switch (t)
		{
		case UpgradeType.FoodMarketCapacity:
		case UpgradeType.GeneralGoodsCapacity:
		case UpgradeType.ApothecaryCapacity:
		case UpgradeType.JewelryStoreCapacity:
		case UpgradeType.FancyFoodsCapacity:
		case UpgradeType.StoneMasonProficiency:
		case UpgradeType.TailorProficiency:
		case UpgradeType.WorkshopProficiency:
		case UpgradeType.GrainMillProficiency:
		case UpgradeType.ForgeProficiency:
		case UpgradeType.BakeryProficiency:
		case UpgradeType.MachineShopProficiency:
		case UpgradeType.MedicineHutProficiency:
		case UpgradeType.LumberMillProficiency:
		case UpgradeType.MineProficiency:
		case UpgradeType.FarmingProficiency:
		case UpgradeType.FisheryProficiency:
		case UpgradeType.ForesterProficiency:
		case UpgradeType.EnchantedForgeProficiency:
		case UpgradeType.EnchanterProficiency:
		case UpgradeType.QuarryProficiency:
		case UpgradeType.GemMineProficiency:
		case UpgradeType.ExtractorProficiency:
		case UpgradeType.RefineryProficiency:
		case UpgradeType.JewelerProficiency:
		case UpgradeType.ClothingStoreCapacity:
		case UpgradeType.PastureProficiency:
		case UpgradeType.HardwareStoreCapacity:
		case UpgradeType.Exploration:
		case UpgradeType.GourmetKitchenProficiency:
		case UpgradeType.BookstoreCapacity:
		case UpgradeType.StudyProficiency:
		case UpgradeType.TechLabProficiency:
		case UpgradeType.MagicLabProficiency:
		case UpgradeType.TradingPostWorkersPerBuilding:
		case UpgradeType.OmniCapacityFoodMarket:
		case UpgradeType.OmniCapacityGeneralStore:
		case UpgradeType.OmniCapacityHardwareStore:
		case UpgradeType.OmniCapacityBookstore:
		case UpgradeType.OmniCapacityClothingStore:
		case UpgradeType.OmniCapacityGourmetFoods:
		case UpgradeType.OmniCapacityApothecary:
		case UpgradeType.OmniCapacityJewelryStore:
		case UpgradeType.HarvesterHutProficiency:
		case UpgradeType.FishingBoatProficiency:
		case UpgradeType.CropHarvesterProficiency:
		case UpgradeType.ChainsawTankProficiency:
		case UpgradeType.HarvesterDrillProficiency:
		case UpgradeType.ArcaneStoreCapacity:
		case UpgradeType.OmniCapacityArcaneStore:
			return GrowthRateType.Linear;
		case UpgradeType.SkillEffectCrafting:
		case UpgradeType.SkillEffectHarvesting:
		case UpgradeType.SkillEffectCultivation:
		case UpgradeType.SkillEffectProspecting:
		case UpgradeType.HouseCapacity:
		case UpgradeType.SellValueYellowCoin:
		case UpgradeType.SellValueRedCoin:
		case UpgradeType.SellValueBlueCoin:
		case UpgradeType.SellValuePurpleCoin:
		case UpgradeType.MarketConsumptionFood:
		case UpgradeType.MarketConsumptionGeneralGoods:
		case UpgradeType.MarketConsumptionMedicine:
		case UpgradeType.MarketConsumptionJewelryStore:
		case UpgradeType.MarketConsumptionGourmetFood:
		case UpgradeType.PickaxeMiningYield:
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
		case UpgradeType.MarketConsumptionClothing:
		case UpgradeType.AqueductEffectiveness:
		case UpgradeType.FurnaceProductivity:
		case UpgradeType.SellSpeedYellowCoin:
		case UpgradeType.SellSpeedRedCoin:
		case UpgradeType.SellSpeedBlueCoin:
		case UpgradeType.SellSpeedPurpleCoin:
		case UpgradeType.MarketConsumptionHardwareStore:
		case UpgradeType.MarketConsumptionBookstore:
		case UpgradeType.WellEffectiveness:
		case UpgradeType.WaterWheelEffectiveness:
		case UpgradeType.OmniSpeedFarm:
		case UpgradeType.OmniSpeedForester:
		case UpgradeType.OmniSpeedQuarry:
		case UpgradeType.OmniSpeedMine:
		case UpgradeType.OmniSpeedGemMine:
		case UpgradeType.OmniSpeedFishery:
		case UpgradeType.Supermarket:
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
		case UpgradeType.OmniSpeedStudy:
		case UpgradeType.OmniProductivityStudy:
		case UpgradeType.OmniSpeedTechLab:
		case UpgradeType.OmniProductivityTechLab:
		case UpgradeType.OmniSpeedMagicLab:
		case UpgradeType.OmniProductivityMagicLab:
		case UpgradeType.OmniSpeedOmniTemple:
		case UpgradeType.OmniProductivityOmniTemple:
		case UpgradeType.YellowCoinXP:
		case UpgradeType.RedCoinXP:
		case UpgradeType.BlueCoinXP:
		case UpgradeType.PurpleCoinXP:
		case UpgradeType.OmniCoinXP:
		case UpgradeType.SellSpeedOmniCoin:
		case UpgradeType.ChainsawTankYield:
		case UpgradeType.HarvesterDrillYield:
		case UpgradeType.CropHarvesterYield:
		case UpgradeType.FishingBoatYield:
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
		case UpgradeType.MarketConsumptionArcaneGoods:
		case UpgradeType.OmniSolarPanelEffectiveness:
		case UpgradeType.OmniSpeedAqueduct:
		case UpgradeType.OmniSpeedWell:
			return GrowthRateType.Multiplicative;
		case UpgradeType.PowerLineSpeed:
		case UpgradeType.ManaPipeSpeed:
		case UpgradeType.SteamPipeSpeed:
		case UpgradeType.OmniPipeSpeed:
		case UpgradeType.MagmaPipeSpeed:
			return GrowthRateType.Exponential;
		case UpgradeType.WarehouseCapacity:
		case UpgradeType.ConstructionEfficiency:
		case UpgradeType.EtherStorageCapacity:
		case UpgradeType.ManaBatteryCapacity:
		case UpgradeType.OmnistoneStorageCapacity:
		case UpgradeType.LibraryCapacity:
		case UpgradeType.BatteryCapacity:
		case UpgradeType.CropSiloCapacity:
		case UpgradeType.OreSiloCapacity:
		case UpgradeType.PantryCapacity:
		case UpgradeType.TreasuryCapacity:
		case UpgradeType.StockpileCapacity:
		case UpgradeType.CrystalariumCapacity:
		case UpgradeType.ReservoirCapacity:
		case UpgradeType.FurnaceStorageCapacity:
		case UpgradeType.SteamBoilerStorageCapacity:
		case UpgradeType.BarrelCapacity:
		case UpgradeType.TradingPostStorageCapacity:
		case UpgradeType.SolarPanelEffectiveness:
		case UpgradeType.UpgradeEfficiency:
		case UpgradeType.MarketCostFood:
		case UpgradeType.MarketCostGeneral:
		case UpgradeType.MarketCostHardware:
		case UpgradeType.MarketCostBookstore:
		case UpgradeType.MarketCostClothing:
		case UpgradeType.MarketCostGourmet:
		case UpgradeType.MarketCostApothecary:
		case UpgradeType.MarketCostJewelry:
		case UpgradeType.MarketCostArcane:
			return GrowthRateType.Exponential;
		default:
			return GrowthRateType.Exponential;
		}
	}

	public static float ExplorationBonus(int level)
	{
		return level * 5;
	}

	public static float BonusForUpgrade(UpgradeType t)
	{
		switch (t)
		{
		case UpgradeType.ConstructionEfficiency:
			return -0.025f;
		case UpgradeType.MarketCostFood:
		case UpgradeType.MarketCostGeneral:
		case UpgradeType.MarketCostHardware:
		case UpgradeType.MarketCostBookstore:
		case UpgradeType.MarketCostClothing:
		case UpgradeType.MarketCostGourmet:
		case UpgradeType.MarketCostApothecary:
		case UpgradeType.MarketCostJewelry:
		case UpgradeType.MarketCostArcane:
			return -0.8f;
		case UpgradeType.UpgradeEfficiency:
			return -0.2f;
		case UpgradeType.SkillGainSpeed:
			return 0.25f;
		case UpgradeType.HouseCapacity:
			return 0.3f;
		case UpgradeType.ResearchSpeed:
			return 0.25f;
		case UpgradeType.OmniResearchSpeed:
			return 0.1f;
		case UpgradeType.WaterPumpCountSpeed:
			return 0.2f;
		case UpgradeType.SteamBoilerCountSpeed:
			return 0.2f;
		case UpgradeType.SteamPowerGeneratorCountSpeed:
			return 0.2f;
		case UpgradeType.ExtractorCountSpeed:
			return 0.2f;
		case UpgradeType.FurnaceCountSpeed:
			return 0.2f;
		case UpgradeType.Exploration:
			return 5f;
		case UpgradeType.FireShrineSpeed:
			return 0.5f;
		case UpgradeType.WaterShrineSpeed:
			return 0.5f;
		case UpgradeType.EarthShrineSpeed:
			return 0.5f;
		case UpgradeType.AirShrineSpeed:
			return 0.5f;
		case UpgradeType.ShrineSpeed_Legacy:
			return 0.5f;
		case UpgradeType.TempleEffectivenessMana:
		case UpgradeType.TempleEffectivenessFire:
		case UpgradeType.TempleEffectivenessWater:
		case UpgradeType.TempleEffectivenessEarth:
		case UpgradeType.TempleEffectivenessAir:
			return 0.5f;
		case UpgradeType.FurnaceSpeed:
			return 0.5f;
		case UpgradeType.RockProspectingSpeed:
			return 1f;
		case UpgradeType.IronProspectingSpeed:
			return 1f;
		case UpgradeType.CoalProspectingSpeed:
			return 1f;
		case UpgradeType.GoldProspectingSpeed:
			return 1f;
		case UpgradeType.SilverProspectingSpeed:
			return 1f;
		case UpgradeType.CopperProspectingSpeed:
			return 1f;
		case UpgradeType.ManaProspectingSpeed:
			return 1f;
		case UpgradeType.GemRedProspectingSpeed:
			return 1f;
		case UpgradeType.GemYellowProspectingSpeed:
			return 1f;
		case UpgradeType.GemAquaProspectingSpeed:
			return 1f;
		case UpgradeType.GemPurpleProspectingSpeed:
			return 1f;
		case UpgradeType.SandHarvestingSpeed:
			return 1f;
		case UpgradeType.RockHarvestingSpeed:
			return 1f;
		case UpgradeType.IronHarvestingSpeed:
			return 1f;
		case UpgradeType.CoalHarvestingSpeed:
			return 1f;
		case UpgradeType.GoldHarvestingSpeed:
			return 1f;
		case UpgradeType.SilverHarvestingSpeed:
			return 1f;
		case UpgradeType.CopperHarvestingSpeed:
			return 1f;
		case UpgradeType.ManaHarvestingSpeed:
			return 1f;
		case UpgradeType.GemRedHarvestingSpeed:
			return 1f;
		case UpgradeType.GemYellowHarvestingSpeed:
			return 1f;
		case UpgradeType.GemAquaHarvestingSpeed:
			return 1f;
		case UpgradeType.GemPurpleHarvestingSpeed:
			return 1f;
		case UpgradeType.MinigameDiceYield:
			return 1f;
		case UpgradeType.MinigameFarmingYield:
			return 1f;
		case UpgradeType.MinigameMiningYield:
			return 1f;
		case UpgradeType.MinigameResearchYield:
			return 1f;
		case UpgradeType.MinigameWaterYield:
			return 1f;
		case UpgradeType.MinigameWoodYield:
			return 1f;
		case UpgradeType.GrainHarvestingSpeed:
			return 1f;
		case UpgradeType.CottonHarvestingSpeed:
			return 1f;
		case UpgradeType.HerbHarvestingSpeed:
			return 1f;
		case UpgradeType.PotatoHarvestingSpeed:
			return 1f;
		case UpgradeType.TomatoHarvestingSpeed:
			return 1f;
		case UpgradeType.SugarHarvestingSpeed:
			return 1f;
		case UpgradeType.AppleHarvestingSpeed:
			return 1f;
		case UpgradeType.PearHarvestingSpeed:
			return 1f;
		case UpgradeType.BerryHarvestingSpeed:
			return 1f;
		case UpgradeType.CactusHarvestingSpeed:
			return 1f;
		case UpgradeType.DragonHarvestingSpeed:
			return 1f;
		case UpgradeType.CarrotHarvestingSpeed:
			return 1f;
		case UpgradeType.TreeHarvestingSpeed:
			return 1f;
		case UpgradeType.FishHarvestingSpeed:
			return 1f;
		case UpgradeType.FishingNetHarvestingSpeed:
			return 1f;
		case UpgradeType.FishingMagicNetHarvestingSpeed:
			return 1f;
		case UpgradeType.WaterHarvestingSpeed:
			return 1f;
		case UpgradeType.GrainFarmingSpeed:
			return 1f;
		case UpgradeType.CottonFarmingSpeed:
			return 1f;
		case UpgradeType.HerbFarmingSpeed:
			return 1f;
		case UpgradeType.PotatoFarmingSpeed:
			return 1f;
		case UpgradeType.TomatoFarmingSpeed:
			return 1f;
		case UpgradeType.SugarFarmingSpeed:
			return 1f;
		case UpgradeType.AppleFarmingSpeed:
			return 1f;
		case UpgradeType.PearFarmingSpeed:
			return 1f;
		case UpgradeType.BerryFarmingSpeed:
			return 1f;
		case UpgradeType.CactusFarmingSpeed:
			return 1f;
		case UpgradeType.DragonFarmingSpeed:
			return 1f;
		case UpgradeType.CarrotFarmingSpeed:
			return 1f;
		case UpgradeType.TreeFarmingSpeed:
			return 1f;
		case UpgradeType.FishFarmingSpeed:
			return 1f;
		case UpgradeType.FoodMarketCapacity:
		case UpgradeType.GeneralGoodsCapacity:
		case UpgradeType.ApothecaryCapacity:
		case UpgradeType.JewelryStoreCapacity:
		case UpgradeType.FancyFoodsCapacity:
		case UpgradeType.StoneMasonProficiency:
		case UpgradeType.TailorProficiency:
		case UpgradeType.WorkshopProficiency:
		case UpgradeType.GrainMillProficiency:
		case UpgradeType.ForgeProficiency:
		case UpgradeType.BakeryProficiency:
		case UpgradeType.MachineShopProficiency:
		case UpgradeType.MedicineHutProficiency:
		case UpgradeType.LumberMillProficiency:
		case UpgradeType.MineProficiency:
		case UpgradeType.FarmingProficiency:
		case UpgradeType.FisheryProficiency:
		case UpgradeType.ForesterProficiency:
		case UpgradeType.EnchantedForgeProficiency:
		case UpgradeType.EnchanterProficiency:
		case UpgradeType.QuarryProficiency:
		case UpgradeType.GemMineProficiency:
		case UpgradeType.ExtractorProficiency:
		case UpgradeType.RefineryProficiency:
		case UpgradeType.JewelerProficiency:
		case UpgradeType.ClothingStoreCapacity:
		case UpgradeType.PastureProficiency:
		case UpgradeType.HardwareStoreCapacity:
		case UpgradeType.GourmetKitchenProficiency:
		case UpgradeType.BookstoreCapacity:
		case UpgradeType.StudyProficiency:
		case UpgradeType.TechLabProficiency:
		case UpgradeType.MagicLabProficiency:
		case UpgradeType.OmniCapacityFoodMarket:
		case UpgradeType.OmniCapacityGeneralStore:
		case UpgradeType.OmniCapacityHardwareStore:
		case UpgradeType.OmniCapacityBookstore:
		case UpgradeType.OmniCapacityClothingStore:
		case UpgradeType.OmniCapacityGourmetFoods:
		case UpgradeType.OmniCapacityApothecary:
		case UpgradeType.OmniCapacityJewelryStore:
		case UpgradeType.HarvesterHutProficiency:
		case UpgradeType.FishingBoatProficiency:
		case UpgradeType.CropHarvesterProficiency:
		case UpgradeType.ChainsawTankProficiency:
		case UpgradeType.HarvesterDrillProficiency:
		case UpgradeType.ArcaneStoreCapacity:
		case UpgradeType.OmniCapacityArcaneStore:
			return 1f;
		case UpgradeType.TradingPostWorkersPerBuilding:
			return 2f;
		case UpgradeType.SkillEffectCrafting:
		case UpgradeType.SkillEffectHarvesting:
		case UpgradeType.SkillEffectCultivation:
		case UpgradeType.SkillEffectProspecting:
			return 0.2f;
		case UpgradeType.SellValueYellowCoin:
		case UpgradeType.SellValueRedCoin:
		case UpgradeType.SellValueBlueCoin:
		case UpgradeType.SellValuePurpleCoin:
			return 0.5f;
		case UpgradeType.SellSpeedYellowCoin:
		case UpgradeType.SellSpeedRedCoin:
		case UpgradeType.SellSpeedBlueCoin:
		case UpgradeType.SellSpeedPurpleCoin:
		case UpgradeType.SellSpeedOmniCoin:
			return 0.5f;
		case UpgradeType.YellowCoinXP:
		case UpgradeType.RedCoinXP:
		case UpgradeType.BlueCoinXP:
		case UpgradeType.PurpleCoinXP:
		case UpgradeType.OmniCoinXP:
			return 0.25f;
		case UpgradeType.Supermarket:
			return 2f;
		case UpgradeType.WarehouseCapacity:
			return 1f;
		case UpgradeType.LibraryCapacity:
			return 1f;
		case UpgradeType.OreSiloCapacity:
			return 1f;
		case UpgradeType.FurnaceStorageCapacity:
			return 1f;
		case UpgradeType.SteamBoilerStorageCapacity:
			return 1f;
		case UpgradeType.CropSiloCapacity:
			return 1f;
		case UpgradeType.PantryCapacity:
			return 1f;
		case UpgradeType.TreasuryCapacity:
			return 1f;
		case UpgradeType.BatteryCapacity:
			return 1f;
		case UpgradeType.EtherStorageCapacity:
			return 1f;
		case UpgradeType.ManaBatteryCapacity:
			return 1f;
		case UpgradeType.CrystalariumCapacity:
			return 1f;
		case UpgradeType.ReservoirCapacity:
			return 1f;
		case UpgradeType.TradingPostStorageCapacity:
			return 0.2f;
		case UpgradeType.OmnistoneStorageCapacity:
			return 1f;
		case UpgradeType.StockpileCapacity:
			return 1f;
		case UpgradeType.BarrelCapacity:
			return 1f;
		case UpgradeType.AqueductEffectiveness:
			return 0.5f;
		case UpgradeType.WellEffectiveness:
			return 0.5f;
		case UpgradeType.WaterWheelEffectiveness:
			return 0.5f;
		case UpgradeType.SolarPanelEffectiveness:
			return 1f;
		case UpgradeType.OmniSolarPanelEffectiveness:
			return 1f;
		case UpgradeType.PowerLineSpeed:
		case UpgradeType.ManaPipeSpeed:
		case UpgradeType.SteamPipeSpeed:
		case UpgradeType.OmniPipeSpeed:
		case UpgradeType.MagmaPipeSpeed:
			return 1f;
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
			return 0.25f;
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
			return 0.1f;
		case UpgradeType.FurnaceProductivity:
			return 0.25f;
		case UpgradeType.PickaxeMiningYield:
			return 0.5f;
		case UpgradeType.ChainsawTankYield:
			return 0.5f;
		case UpgradeType.HarvesterDrillYield:
			return 0.5f;
		case UpgradeType.CropHarvesterYield:
			return 0.5f;
		case UpgradeType.FishingBoatYield:
			return 0.5f;
		case UpgradeType.HouseCost:
			return -0.05f;
		case UpgradeType.BuildingConstructionSpeedGrowth:
			return -0.1f;
		case UpgradeType.FuelEfficiency:
			return -0.1f;
		case UpgradeType.MarketConsumptionFood:
		case UpgradeType.MarketConsumptionGeneralGoods:
		case UpgradeType.MarketConsumptionMedicine:
		case UpgradeType.MarketConsumptionJewelryStore:
		case UpgradeType.MarketConsumptionGourmetFood:
		case UpgradeType.MarketConsumptionClothing:
		case UpgradeType.MarketConsumptionHardwareStore:
		case UpgradeType.MarketConsumptionBookstore:
		case UpgradeType.MarketConsumptionArcaneGoods:
			return 0.25f;
		case UpgradeType.MinigameMiningEnergyMax:
		case UpgradeType.MinigameFarmingEnergyMax:
		case UpgradeType.MinigameDiceEnergyMax:
		case UpgradeType.MinigameResearchEnergyMax:
		case UpgradeType.MinigameWaterEnergyMax:
		case UpgradeType.MinigameWoodEnergyMax:
			return 0.2f;
		case UpgradeType.MinigameMiningEnergyRate:
		case UpgradeType.MinigameFarmingEnergyRate:
		case UpgradeType.MinigameDiceEnergyRate:
		case UpgradeType.MinigameResearchEnergyRate:
		case UpgradeType.MinigameWaterEnergyRate:
		case UpgradeType.MinigameWoodEnergyRate:
			return 0.2f;
		default:
			return 0f;
		}
	}

	public float GetMultiplierForLevel(int level)
	{
		if (growthValue <= -1f)
		{
			return 0f;
		}
		if (type == UpgradeType.Exploration)
		{
			return ExplorationBonus(level);
		}
		if (growthRateType == GrowthRateType.Linear)
		{
			return (float)level * growthValue;
		}
		if (growthRateType == GrowthRateType.Multiplicative)
		{
			return 1f + (float)level * growthValue;
		}
		return GameUtility.ExponentGrowth(1f, level, growthValue);
	}

	public float GetMultiplier()
	{
		return GetMultiplierForLevel(numCompleted);
	}

	public static bool IsEnabled(UpgradeType t)
	{
		switch (t)
		{
		case UpgradeType.ManaPowerDrills_Legacy:
		case UpgradeType.ManaPowerCropHarvesters_Legacy:
		case UpgradeType.BuildingConstructionSpeedGrowth:
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
		case UpgradeType.LuckyPickaxe:
		case UpgradeType.ShrineSpeed_Legacy:
		case UpgradeType.ManaChainsawTanks_Legacy:
		case UpgradeType.ManaPowerTractors_Legacy:
			return false;
		default:
			return true;
		}
	}

	public override string ToString()
	{
		return "Upgrade " + type.ToString() + " in town " + parentTown.townName;
	}

	public int MaxLevel()
	{
		if (def.isInfinite)
		{
			return int.MaxValue;
		}
		return levels.Count;
	}

	public void CalcAvailability()
	{
		int index = numCompleted;
		if (displayAvailability == BuildObjectAvailability.Disabled)
		{
			currentLevelAvailability = false;
			return;
		}
		if (displayAvailability == BuildObjectAvailability.Completed)
		{
			currentLevelAvailability = false;
			return;
		}
		if (numCompleted >= MaxLevel())
		{
			displayAvailability = BuildObjectAvailability.Completed;
			currentLevelAvailability = false;
			return;
		}
		if (displayAvailability != BuildObjectAvailability.Available)
		{
			bool flag = true;
			for (int i = 0; i < displayRequirements.Count; i++)
			{
				Requirement requirement = displayRequirements[i];
				if (requirement.IsImpossible())
				{
					currentLevelAvailability = false;
					displayAvailability = BuildObjectAvailability.Disabled;
					break;
				}
				if (!requirement.IsMet() && !GameManager.everythingUnlocked)
				{
					flag = false;
				}
			}
			if (!flag)
			{
				currentLevelAvailability = false;
				displayAvailability = BuildObjectAvailability.Locked;
				return;
			}
			displayAvailability = BuildObjectAvailability.Available;
		}
		if (def.isInfinite)
		{
			currentLevelAvailability = true;
			return;
		}
		UpgradeLevel upgradeLevel = levels[index];
		List<Requirement> list = upgradeLevel.ConfirmedRequirements();
		for (int j = 0; j < list.Count; j++)
		{
			if (!list[j].IsMet() && !GameManager.everythingUnlocked)
			{
				currentLevelAvailability = false;
				return;
			}
		}
		bool num = !currentLevelAvailability;
		currentLevelAvailability = true;
		if (num)
		{
			upgradeLevel.Unlock();
		}
	}

	public void StoreRequirements()
	{
		foreach (RequirementId displayRequirement in def.displayRequirements)
		{
			Requirement cachedRequirement = parentTown.GetCachedRequirement(displayRequirement);
			if (cachedRequirement != null && !displayRequirements.Contains(cachedRequirement))
			{
				displayRequirements.Add(cachedRequirement);
			}
		}
	}

	public bool IsReadyToPurchase()
	{
		if (displayAvailability != BuildObjectAvailability.Available)
		{
			return false;
		}
		if (!currentLevelAvailability)
		{
			return false;
		}
		return CanAffordCurrentLevel();
	}
}
