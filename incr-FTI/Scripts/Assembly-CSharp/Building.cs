using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
	public const bool useWonders = false;

	private static GameManager gm => GameManager.Instance;

	public static EntityId ToId(BuildingType b)
	{
		return new EntityId((int)b, EntityType.Building);
	}

	public static bool IsEnabled(BuildingType t)
	{
		return Crafting.GetCachedBuildingDef(t).enabled;
	}

	public static void LoadDefaultRequirementsForBuilding(BuildingType type, List<RequirementId> result)
	{
		switch (type)
		{
		case BuildingType.House:
			result.Add(new RequirementId(QuestType.WoodForHouse));
			break;
		case BuildingType.LumberMill:
			result.Add(new RequirementId(QuestType.EarnCoinsForLumberMill, global: true));
			break;
		case BuildingType.Market:
			result.Add(new RequirementId(QuestType.GrainForFoodMarket, global: true));
			break;
		case BuildingType.GeneralGoods:
			result.Add(new RequirementId(QuestType.AssignWorkersForGeneralStore, global: true));
			break;
		case BuildingType.HardwareStore:
			result.Add(new RequirementId(QuestType.WorkshopForHardwareStore));
			break;
		case BuildingType.Bookstore:
			result.Add(new RequirementId(QuestType.PaperForBookstore));
			break;
		case BuildingType.ClothingStore:
			result.Add(new RequirementId(QuestType.TailorForClothingStore));
			break;
		case BuildingType.Apothecary:
			result.Add(new RequirementId(QuestType.MedicineHutForHospital));
			break;
		case BuildingType.JewelryStore:
			result.Add(new RequirementId(QuestType.JewelerForJewelryStore));
			break;
		case BuildingType.FancyFoods:
			result.Add(new RequirementId(QuestType.GourmetKitchenForFancyFoodsStore));
			break;
		case BuildingType.ArcaneStore:
			result.Add(new RequirementId(QuestType.HarvestManaForArcaneEmporium));
			break;
		case BuildingType.GrainMill:
			result.Add(new RequirementId(ResearchType.FoodMill));
			break;
		case BuildingType.School:
			result.Add(new RequirementId(QuestType.HousesForSchool, global: true));
			break;
		case BuildingType.GeneralLab:
			result.Add(new RequirementId(ResearchType.GeneralLab));
			break;
		case BuildingType.TechLab:
			result.Add(new RequirementId(ResearchType.TechLab));
			break;
		case BuildingType.MagicLab:
			result.Add(new RequirementId(ResearchType.MagicLab));
			break;
		case BuildingType.Workshop:
			result.Add(new RequirementId(ResearchType.Workshop));
			break;
		case BuildingType.Tailor:
			result.Add(new RequirementId(ResearchType.Tailor));
			break;
		case BuildingType.Bakery:
			result.Add(new RequirementId(ResearchType.Bakery));
			break;
		case BuildingType.GourmetKitchen:
			result.Add(new RequirementId(ResearchType.GourmetKitchen));
			break;
		case BuildingType.Jeweler:
			result.Add(new RequirementId(ResearchType.Jewelry));
			break;
		case BuildingType.Farm:
			result.Add(new RequirementId(ResearchType.Farming));
			break;
		case BuildingType.Pasture:
			result.Add(new RequirementId(ResearchType.Pasture));
			break;
		case BuildingType.Fishery:
			result.Add(new RequirementId(ResearchType.Fishery));
			result.Add(new RequirementId(BiomeType.River));
			break;
		case BuildingType.Forester:
			result.Add(new RequirementId(ResearchType.Forestry));
			break;
		case BuildingType.Forge:
			result.Add(new RequirementId(ResearchType.Forge));
			break;
		case BuildingType.Hearth:
			result.Add(new RequirementId(ResearchType.Hearth));
			break;
		case BuildingType.Chute:
			result.Add(new RequirementId(ResearchType.Chute));
			break;
		case BuildingType.WaterWheel:
			result.Add(new RequirementId(ResearchType.WaterPower));
			break;
		case BuildingType.SolarPanel:
			result.Add(new RequirementId(ResearchType.SolarPower));
			result.Add(new RequirementId(BiomeType.Desert));
			break;
		case BuildingType.PlainsUniversity:
			result.Add(new RequirementId(QuestType.TownLevelForPlainsUniversity));
			result.Add(new RequirementId(BiomeType.Plains));
			break;
		case BuildingType.ForestMonastery:
			result.Add(new RequirementId(QuestType.TownLevelForForestMonastery));
			result.Add(new RequirementId(BiomeType.Forest));
			break;
		case BuildingType.RiverHarbor:
			result.Add(new RequirementId(QuestType.TownLevelForRiverHarbor));
			result.Add(new RequirementId(BiomeType.River));
			break;
		case BuildingType.MountainObservatory:
			result.Add(new RequirementId(QuestType.TownLevelForMountainObservatory));
			result.Add(new RequirementId(BiomeType.Mountains));
			break;
		case BuildingType.JunglePyramid:
			result.Add(new RequirementId(QuestType.TownLevelForJunglePyramid));
			result.Add(new RequirementId(BiomeType.Jungle));
			break;
		case BuildingType.DesertBazaar:
			result.Add(new RequirementId(QuestType.TownLevelForDesertBazaar));
			result.Add(new RequirementId(BiomeType.Desert));
			break;
		case BuildingType.SnowTreasureVault:
			result.Add(new RequirementId(QuestType.TownLevelForSnowTreasureVault));
			result.Add(new RequirementId(BiomeType.Snow));
			break;
		case BuildingType.MagicObelisk:
			result.Add(new RequirementId(QuestType.TownLevelForMagicObelisk));
			result.Add(new RequirementId(BiomeType.Magic));
			break;
		case BuildingType.PowerLine:
			result.Add(new RequirementId(QuestType.CopperWireForPowerLines));
			break;
		case BuildingType.HarvesterDrill:
			result.Add(new RequirementId(ResearchType.HarvesterDrill));
			break;
		case BuildingType.ChainsawTank:
			result.Add(new RequirementId(ResearchType.ChainsawTank));
			break;
		case BuildingType.FishingBoat:
			result.Add(new RequirementId(BiomeType.River));
			break;
		case BuildingType.FloatingIsland:
			result.Add(new RequirementId(ResearchType.FloatingIsland));
			result.Add(new RequirementId(BiomeType.Magic));
			break;
		case BuildingType.CropHarvester:
			result.Add(new RequirementId(ResearchType.CropHarvester));
			break;
		case BuildingType.Tractor:
			result.Add(new RequirementId(ResearchType.Tractor));
			break;
		case BuildingType.Minecart:
			result.Add(new RequirementId(ResearchType.Minecart));
			break;
		case BuildingType.SteamTrain:
			result.Add(new RequirementId(ResearchType.SteamTrainEngine));
			break;
		case BuildingType.Caravan:
			result.Add(new RequirementId(QuestType.TradingPostsForCaravan));
			break;
		case BuildingType.ManaPipeline:
			result.Add(new RequirementId(QuestType.ManaPipeForManaPipeline));
			break;
		case BuildingType.SteamPipeline:
			result.Add(new RequirementId(QuestType.SteamPipeForSteamPipeline));
			break;
		case BuildingType.MagmaPipeline:
			result.Add(new RequirementId(QuestType.MagmaPipeForMagmaPipeline));
			break;
		case BuildingType.OmniPipeline:
			result.Add(new RequirementId(QuestType.OmniPipeForOmniPipeline));
			break;
		case BuildingType.Aqueduct:
			result.Add(new RequirementId(ResearchType.Aqueduct));
			break;
		case BuildingType.Furnace:
			result.Add(new RequirementId(ResearchType.Furnace));
			break;
		case BuildingType.MedicineHut:
			result.Add(new RequirementId(ResearchType.MedicineBasic));
			break;
		case BuildingType.CropSilo:
			result.Add(new RequirementId(ResearchType.CropSilo));
			break;
		case BuildingType.OreSilo:
			result.Add(new RequirementId(ResearchType.OreSilo));
			break;
		case BuildingType.Treasury:
			result.Add(new RequirementId(ResearchType.Treasury));
			break;
		case BuildingType.EtherStorage:
			result.Add(new RequirementId(ResearchType.EtherStorage));
			break;
		case BuildingType.OmnistoneStorage:
			result.Add(new RequirementId(ResearchType.OmnistoneStorage));
			break;
		case BuildingType.Battery:
			result.Add(new RequirementId(ResearchType.Battery));
			break;
		case BuildingType.Library:
			result.Add(new RequirementId(ResearchType.Library));
			break;
		case BuildingType.Reservoir:
			result.Add(new RequirementId(ResearchType.Reservoir));
			break;
		case BuildingType.ManaBattery:
			result.Add(new RequirementId(ResearchType.ManaBattery));
			break;
		case BuildingType.Crystalarium:
			result.Add(new RequirementId(ResearchType.Crystalarium));
			break;
		case BuildingType.StoneMason:
			result.Add(new RequirementId(ResearchType.StoneMason));
			break;
		case BuildingType.Well:
			result.Add(new RequirementId(ResearchType.Well));
			break;
		case BuildingType.Warehouse:
			result.Add(new RequirementId(ResearchType.Warehouse));
			break;
		case BuildingType.RailDepot:
			result.Add(new RequirementId(ResearchType.RailDepot));
			break;
		case BuildingType.Crate:
			result.Add(new RequirementId(ResearchType.Workshop));
			break;
		case BuildingType.Pantry:
			result.Add(new RequirementId(ResearchType.Pantry));
			break;
		case BuildingType.Stockpile:
			result.Add(new RequirementId(QuestType.HarvestItemsForStockpile));
			break;
		case BuildingType.Barrel:
			result.Add(new RequirementId(ResearchType.Barrel));
			break;
		case BuildingType.MagicForge:
			result.Add(new RequirementId(ResearchType.MagicForge));
			break;
		case BuildingType.Enchanter:
			result.Add(new RequirementId(ResearchType.Enchanting));
			break;
		case BuildingType.Incinerator:
			result.Add(new RequirementId(ResearchType.Forge));
			break;
		case BuildingType.Factory:
			result.Add(new RequirementId(ResearchType.Factory));
			break;
		case BuildingType.Foundry:
			result.Add(new RequirementId(ResearchType.Foundry));
			break;
		case BuildingType.Packager:
			result.Add(new RequirementId(ResearchType.Packager));
			break;
		case BuildingType.Refinery:
			result.Add(new RequirementId(ResearchType.ManaRefinery));
			break;
		case BuildingType.GemMine:
			result.Add(new RequirementId(ResearchType.GemMine));
			break;
		case BuildingType.Mine:
			result.Add(new RequirementId(ResearchType.Mining));
			break;
		case BuildingType.Quarry:
			result.Add(new RequirementId(ResearchType.Quarry));
			break;
		case BuildingType.SteamBoiler:
			result.Add(new RequirementId(ResearchType.SteamBoiler));
			break;
		case BuildingType.MachineShop:
			result.Add(new RequirementId(ResearchType.Machinery));
			break;
		case BuildingType.Airship:
			result.Add(new RequirementId(ResearchType.Airship));
			break;
		case BuildingType.MagicBoat:
			result.Add(new RequirementId(ResearchType.MagicBoat));
			break;
		case BuildingType.MagicRailTile:
			result.Add(new RequirementId(ResearchType.MagicRail));
			break;
		case BuildingType.MagicConveyorBelt:
			result.Add(new RequirementId(ResearchType.MagicConveyorBelt));
			break;
		case BuildingType.ManaTransmitter:
			result.Add(new RequirementId(ResearchType.ManaTransmitter));
			break;
		case BuildingType.Diffuser:
			result.Add(new RequirementId(ResearchType.ManaTransmitter));
			break;
		case BuildingType.Recharger:
			result.Add(new RequirementId(ResearchType.ManaRecharger));
			break;
		case BuildingType.MegaRecharger:
			result.Add(new RequirementId(ResearchType.MegaRecharger));
			break;
		case BuildingType.ManaTemple:
			result.Add(new RequirementId(ResearchType.BuildManaTemple));
			break;
		case BuildingType.FireTemple:
			result.Add(new RequirementId(ResearchType.BuildFireTemple));
			break;
		case BuildingType.WaterTemple:
			result.Add(new RequirementId(ResearchType.BuildWaterTemple));
			break;
		case BuildingType.AirTemple:
			result.Add(new RequirementId(ResearchType.BuildAirTemple));
			break;
		case BuildingType.EarthTemple:
			result.Add(new RequirementId(ResearchType.BuildEarthTemple));
			break;
		case BuildingType.FireShrine:
			result.Add(new RequirementId(ResearchType.FireShrine));
			break;
		case BuildingType.WaterShrine:
			result.Add(new RequirementId(ResearchType.WaterShrine));
			break;
		case BuildingType.EarthShrine:
			result.Add(new RequirementId(ResearchType.EarthShrine));
			break;
		case BuildingType.SteamPowerGenerator:
			result.Add(new RequirementId(ResearchType.SteamPowerGenerator));
			break;
		case BuildingType.WaterPump:
			result.Add(new RequirementId(ResearchType.WaterPump));
			break;
		case BuildingType.AirShrine:
			result.Add(new RequirementId(ResearchType.AirShrine));
			break;
		case BuildingType.ManaReactor:
			result.Add(new RequirementId(ResearchType.ManaReactor));
			break;
		case BuildingType.OmniTemple:
			result.Add(new RequirementId(ResearchType.BuildOmniTemple));
			break;
		case BuildingType.Void:
			result.Add(new RequirementId(ResearchType.MagicForge));
			break;
		case BuildingType.TradingPost:
			result.Add(new RequirementId(QuestType.SecondTownForTradingPost, global: true));
			break;
		case BuildingType.Lodge:
		case (BuildingType)4:
		case BuildingType.Base:
		case (BuildingType)6:
		case (BuildingType)12:
		case BuildingType.Construction:
		case BuildingType.Infuser:
		case BuildingType.MagicSchool:
		case BuildingType.ManaGrower:
		case BuildingType.Hut:
		case BuildingType.Mansion:
		case BuildingType.Palace:
		case BuildingType.Bank:
		case (BuildingType)74:
		case (BuildingType)75:
		case (BuildingType)76:
		case (BuildingType)94:
		case (BuildingType)96:
		case BuildingType.HarvesterHut:
			break;
		}
	}

	public static BuildingCategory GetCategory(BuildingType t)
	{
		if (Crafting.buildingCache.TryGetValue(t, out var value))
		{
			return value.category;
		}
		return BuildingCategory.None;
	}

	public static StorageType StorageTypeForBuilding(BuildingType t)
	{
		return t switch
		{
			BuildingType.Pantry => StorageType.Pantry, 
			BuildingType.Stockpile => StorageType.Stockpile, 
			BuildingType.Warehouse => StorageType.Warehouse, 
			BuildingType.CropSilo => StorageType.CropSilo, 
			BuildingType.OreSilo => StorageType.OreSilo, 
			BuildingType.Treasury => StorageType.Treasury, 
			BuildingType.EtherStorage => StorageType.Ether, 
			BuildingType.ManaBattery => StorageType.ManaBattery, 
			BuildingType.OmnistoneStorage => StorageType.Omnistone, 
			BuildingType.Crystalarium => StorageType.Crystal, 
			BuildingType.Battery => StorageType.Energy, 
			BuildingType.Library => StorageType.Library, 
			BuildingType.Reservoir => StorageType.Reservoir, 
			BuildingType.Barrel => StorageType.Barrel, 
			BuildingType.Furnace => StorageType.Fire, 
			BuildingType.Hearth => StorageType.Fire, 
			BuildingType.Mine => StorageType.Mine, 
			BuildingType.Quarry => StorageType.Quarry, 
			BuildingType.GemMine => StorageType.GemMine, 
			BuildingType.Farm => StorageType.Farm, 
			BuildingType.Forester => StorageType.Forester, 
			BuildingType.Fishery => StorageType.Fishery, 
			_ => StorageType.None, 
		};
	}

	public static int MaxSkillsPerBuilding(BuildingType t)
	{
		return Crafting.cachedBuildingRecipes[t].Count;
	}

	public static bool HasGlobalEffect(BuildingType t)
	{
		if (t == BuildingType.SteamTrain || (uint)(t - 114) <= 7u)
		{
			return true;
		}
		return false;
	}
}
