using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class ObjectTypeList
{
	public static ObjectType m_Total = ObjectType.Total;

	public static ObjectTypeList Instance;

	private static Dictionary<string, ObjectTypeInfo> m_SaveList;

	private static SubCategoryInfo[] m_SubCategories;

	public static List<ObjectSubCategory>[] m_SubCategoriesInCategories;

	public static List<ObjectType>[] m_ObjectsInSubCategories;

	private static int m_UniqueIDCounter;

	private static Dictionary<int, BaseClass> m_UniqueIDList;

	private static Dictionary<BaseClass, int> m_UniqueIDs;

	public static bool m_Loading;

	public static List<ObjectType> m_LoadObjectTable;

	public static Nothing m_NothingObject = null;

	public static HousingAny m_HousingAnyObject = null;

	public static int[] m_ObjectTypeOnGroundCounts = null;

	public static int[] m_ObjectTypeCounts = null;

	public static byte[] m_ObjectTypeExists = null;

	private static bool[] m_IngredientsRecursionTable;

	public static ObjectTypeInfo[] m_Objects { get; private set; }

	public ObjectTypeList()
	{
		if (Instance != null)
		{
			return;
		}
		Instance = this;
		int num = 0;
		if ((bool)ModManager.Instance)
		{
			num = ModManager.Instance.CustomCreations;
		}
		m_Total += num;
		m_Loading = false;
		m_LoadObjectTable = null;
		m_SubCategories = new SubCategoryInfo[49];
		m_Objects = new ObjectTypeInfo[(int)(m_Total + 1)];
		m_SaveList = new Dictionary<string, ObjectTypeInfo>();
		AddCategory(ObjectSubCategory.ToolsLevel1, ObjectCategory.Tools);
		AddCategory(ObjectSubCategory.ToolsLevel2, ObjectCategory.Tools);
		AddCategory(ObjectSubCategory.BotsHeads, ObjectCategory.Bots);
		AddCategory(ObjectSubCategory.BotsBodies, ObjectCategory.Bots);
		AddCategory(ObjectSubCategory.BotsDrives, ObjectCategory.Bots);
		AddCategory(ObjectSubCategory.BotsUpgrades, ObjectCategory.Bots);
		AddCategory(ObjectSubCategory.PartsWood, ObjectCategory.Parts);
		AddCategory(ObjectSubCategory.PartsStone, ObjectCategory.Parts);
		AddCategory(ObjectSubCategory.PartsClay, ObjectCategory.Parts);
		AddCategory(ObjectSubCategory.PartsMetal, ObjectCategory.Parts);
		AddCategory(ObjectSubCategory.FoodMushroom, ObjectCategory.Food);
		AddCategory(ObjectSubCategory.FoodPumpkin, ObjectCategory.Food);
		AddCategory(ObjectSubCategory.FoodBerry, ObjectCategory.Food);
		AddCategory(ObjectSubCategory.FoodApple, ObjectCategory.Food);
		AddCategory(ObjectSubCategory.FoodCereal, ObjectCategory.Food);
		AddCategory(ObjectSubCategory.FoodFish, ObjectCategory.Food);
		AddCategory(ObjectSubCategory.FoodCarrot, ObjectCategory.Food);
		AddCategory(ObjectSubCategory.FoodOther, ObjectCategory.Food);
		AddCategory(ObjectSubCategory.ClothingWool, ObjectCategory.Clothing);
		AddCategory(ObjectSubCategory.ClothingCotton, ObjectCategory.Clothing);
		AddCategory(ObjectSubCategory.ClothingRushes, ObjectCategory.Clothing);
		AddCategory(ObjectSubCategory.ClothingHeadwear, ObjectCategory.Clothing);
		AddCategory(ObjectSubCategory.ClothingOther, ObjectCategory.Clothing);
		AddCategory(ObjectSubCategory.LeisureDoll, ObjectCategory.Leisure);
		AddCategory(ObjectSubCategory.LeisureHorse, ObjectCategory.Leisure);
		AddCategory(ObjectSubCategory.LeisureOther, ObjectCategory.Leisure);
		AddCategory(ObjectSubCategory.Medicine, ObjectCategory.Medicine);
		AddCategory(ObjectSubCategory.Education, ObjectCategory.Education);
		AddCategory(ObjectSubCategory.Art, ObjectCategory.Art);
		AddCategory(ObjectSubCategory.WildlifeAnimals, ObjectCategory.Wildlife);
		AddCategory(ObjectSubCategory.WildlifeCrops, ObjectCategory.Wildlife);
		AddCategory(ObjectSubCategory.Misc, ObjectCategory.Misc);
		AddCategory(ObjectSubCategory.Vehicles, ObjectCategory.Vehicles);
		AddCategory(ObjectSubCategory.BuildingsWorkshop, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsStorage, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsSpecial, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsFood, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsWalls, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsFloors, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsTrains, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsAnimals, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsClothing, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsMisc, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.BuildingsDecoration, ObjectCategory.Buildings);
		AddCategory(ObjectSubCategory.Hidden, ObjectCategory.Hidden);
		AddCategory(ObjectSubCategory.Any, ObjectCategory.Any);
		AddCategory(ObjectSubCategory.Effects, ObjectCategory.Effects);
		AddCategory(ObjectSubCategory.Prizes, ObjectCategory.Prizes);
		AddCategory(ObjectSubCategory.BuildingsPrizes, ObjectCategory.Prizes);
		SetInfo(ObjectType.Nothing, "Nothing", "WorldObjects/Special/Nothing", "", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.Empty, "Empty", "", "", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.Plot, "Plot", "", "", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.FarmerPlayer, "FarmerPlayer", "WorldObjects/Other/FarmerPlayer", "Models/Other/FarmerPlayer", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.BasicWorker, "BasicWorker", "WorldObjects/Other/Worker", "", false, null, "Other/IconWorker", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.Worker, "Worker", "WorldObjects/Other/Worker", "", false, null, "Other/IconWorkerCustom", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.TutorBot, "TutorBot", "WorldObjects/Other/TutorBot", "Models/Other/TutorBot", false, null, "Other/IconWorker", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.Folk, "Folk", "WorldObjects/Other/Folk", "Models/Folk/Folk", false, null, "Other/IconFolk", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.ToolAxeStone, "ToolAxeStone", "WorldObjects/Tools/ToolAxeStone", "Models/Tools/ToolAxeStone", true, null, "Tools/IconToolAxeStone", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolShovelStone, "ToolShovelStone", "WorldObjects/Tools/ToolShovelStone", "Models/Tools/ToolShovelStone", true, null, "Tools/IconToolShovelStone", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolPickStone, "ToolPickStone", "WorldObjects/Tools/ToolPickStone", "Models/Tools/ToolPickStone", true, null, "Tools/IconToolPickStone", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolHoeStone, "ToolHoeStone", "WorldObjects/Tools/ToolHoeStone", "Models/Tools/ToolHoeStone", true, null, "Tools/IconToolHoeStone", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolScytheStone, "ToolScytheStone", "WorldObjects/Tools/ToolScytheStone", "Models/Tools/ToolScytheStone", true, null, "Tools/IconToolScytheStone", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolAxe, "ToolAxe", "WorldObjects/Tools/ToolAxe", "Models/Tools/ToolAxe", true, null, "Tools/IconToolAxe", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolShovel, "ToolShovel", "WorldObjects/Tools/ToolShovel", "Models/Tools/ToolShovel", true, null, "Tools/IconToolShovel", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolPick, "ToolPick", "WorldObjects/Tools/ToolPick", "Models/Tools/ToolPick", true, null, "Tools/IconToolPick", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolHoe, "ToolHoe", "WorldObjects/Tools/ToolHoe", "Models/Tools/ToolHoe", true, null, "Tools/IconToolHoe", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolScythe, "ToolScythe", "WorldObjects/Tools/ToolScythe", "Models/Tools/ToolScythe", true, null, "Tools/IconToolScythe", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolBucketCrude, "ToolBucketCrude", "WorldObjects/Tools/ToolBucketCrude", "Models/Tools/ToolBucketCrude", true, null, "Tools/IconToolBucketCrude", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolBucket, "ToolBucket", "WorldObjects/Tools/ToolBucket", "Models/Tools/ToolBucket", true, null, "Tools/IconToolBucket", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolBucketMetal, "ToolBucketMetal", "WorldObjects/Tools/ToolBucketMetal", "Models/Tools/ToolBucketMetal", true, null, "Tools/IconToolBucketMetal", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolMallet, "ToolMallet", "WorldObjects/Tools/ToolMallet", "Models/Tools/ToolMallet", true, null, "Tools/IconToolMallet", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolChiselCrude, "ToolChiselCrude", "WorldObjects/Tools/ToolChiselCrude", "Models/Tools/ToolChiselCrude", true, null, "Tools/IconToolChiselCrude", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolChisel, "ToolChisel", "WorldObjects/Tools/ToolChisel", "Models/Tools/ToolChisel", true, null, "Tools/IconToolChisel", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolFlailCrude, "ToolFlailCrude", "WorldObjects/Tools/ToolFlailCrude", "Models/Tools/ToolFlailCrude", true, null, "Tools/IconToolFlailCrude", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolFlail, "ToolFlail", "WorldObjects/Tools/ToolFlail", "Models/Tools/ToolFlail", true, null, "Tools/IconToolFlail", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolShears, "ToolShears", "WorldObjects/Tools/ToolShears", "Models/Tools/ToolShears", true, null, "Tools/IconToolShears", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolWateringCan, "ToolWateringCan", "WorldObjects/Tools/ToolWateringCan", "Models/Tools/ToolWateringCan", true, null, "Tools/IconToolWateringCan", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolFishingStick, "ToolFishingStick", "WorldObjects/Tools/ToolFishingStick", "Models/Tools/ToolFishingStick", true, null, "Tools/IconToolFishingStick", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolFishingRod, "ToolFishingRod", "WorldObjects/Tools/ToolFishingRod", "Models/Tools/ToolFishingRod", true, null, "Tools/IconToolFishingRod", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolFishingRodGood, "ToolFishingRodGood", "WorldObjects/Tools/ToolFishingRod", "Models/Tools/ToolFishingRodGood", true, null, "Tools/IconToolFishingRod", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolBroom, "ToolBroom", "WorldObjects/Tools/ToolBroom", "Models/Tools/ToolBroom", true, null, "Tools/IconToolBroom", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolPitchfork, "ToolPitchfork", "WorldObjects/Tools/ToolPitchfork", "Models/Tools/ToolPitchfork", true, null, "Tools/IconToolPitchfork", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolTorchCrude, "ToolTorchCrude", "WorldObjects/Tools/ToolTorchCrude", "Models/Tools/ToolTorchCrude", true, null, "Tools/IconToolTorchCrude", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolDredgerCrude, "ToolDredgerCrude", "WorldObjects/Tools/ToolDredgerCrude", "Models/Tools/ToolDredgerCrude", true, null, "Tools/IconToolDredgerCrude", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolNetCrude, "ToolNetCrude", "WorldObjects/Tools/ToolNetCrude", "Models/Tools/ToolNetCrude", true, null, "Tools/IconToolDredgerCrude", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.ToolNet, "ToolNet", "WorldObjects/Tools/ToolNet", "Models/Tools/ToolNet", true, null, "Tools/IconToolDredgerCrude", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.ToolBlade, "ToolBlade", "WorldObjects/Tools/ToolBlade", "Models/Tools/ToolBlade", true, null, "Tools/IconToolDredgerCrude", true, ObjectSubCategory.ToolsLevel2);
		SetInfo(ObjectType.Workbench, "Workbench", "WorldObjects/Buildings/Converters/Workbench", "Models/Buildings/Converters/Workbench", false, null, "Buildings/Converters/IconWorkbench", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.WorkerAssembler, "WorkerAssembler", "WorldObjects/Buildings/Converters/WorkerAssembler", "Models/Buildings/Converters/WorkerAssembler", false, null, "Buildings/Converters/IconWorkerAssembler", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.CogBench, "CogBench", "WorldObjects/Buildings/Converters/CogBench", "Models/Buildings/Converters/CogBench", false, null, "Buildings/Converters/IconCogBench", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.ChoppingBlock, "ChoppingBlock", "WorldObjects/Buildings/Converters/ChoppingBlock", "Models/Buildings/Converters/ChoppingBlock", false, null, "Buildings/Converters/IconChoppingBlock", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.BenchSaw, "BenchSaw", "WorldObjects/Buildings/Converters/BenchSaw", "Models/Buildings/Converters/BenchSaw", false, null, "Buildings/Converters/IconBenchSaw", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.BenchSaw2, "BenchSaw2", "WorldObjects/Buildings/Converters/BenchSaw2", "Models/Buildings/Converters/BenchSaw2", false, null, "Buildings/Converters/IconBenchSaw2", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.MasonryBench, "MasonryBench", "WorldObjects/Buildings/Converters/MasonryBench", "Models/Buildings/Converters/MasonryBench", false, null, "Buildings/Converters/IconMasonryBench", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.WorkbenchMk2, "WorkbenchMk2", "WorldObjects/Buildings/Converters/WorkbenchMk2", "Models/Buildings/Converters/WorkbenchMk2", false, null, "Buildings/Converters/IconWorkbenchMk2", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.WorkbenchStructural, "WorkbenchStructural", "WorldObjects/Buildings/Converters/WorkbenchStructural", "Models/Buildings/Converters/WorkbenchStructural", false, null, "Buildings/Converters/IconWorkbenchStructural", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.BasicMetalWorkbench, "BasicMetalWorkbench", "WorldObjects/Buildings/Converters/BasicMetalWorkbench", "Models/Buildings/Converters/BasicMetalWorkbench", false, null, "Buildings/Converters/IconBasicMetalWorkbench", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.MetalWorkbench, "MetalWorkbench", "WorldObjects/Buildings/Converters/MetalWorkbench", "Models/Buildings/Converters/MetalWorkbench", false, null, "Buildings/Converters/IconMetalWorkbench", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.WorkerWorkbenchMk1, "WorkerWorkbenchMk1", "WorldObjects/Buildings/Converters/WorkerWorkbenchMk1", "Models/Buildings/Converters/WorkerWorkbenchMk1", false, null, "Buildings/Converters/IconWorkerWorkbenchMk1", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.WorkerWorkbenchMk2, "WorkerWorkbenchMk2", "WorldObjects/Buildings/Converters/WorkerWorkbenchMk2", "Models/Buildings/Converters/WorkerWorkbenchMk2", false, null, "Buildings/Converters/IconWorkerWorkbenchMk2", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.WorkerWorkbenchMk3, "WorkerWorkbenchMk3", "WorldObjects/Buildings/Converters/WorkerWorkbenchMk3", "Models/Buildings/Converters/WorkerWorkbenchMk3", false, null, "Buildings/Converters/IconWorkerWorkbenchMk3", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.VehicleAssembler, "VehicleAssembler", "WorldObjects/Buildings/Converters/VehicleAssembler", "Models/Buildings/Converters/VehicleAssembler", false, null, "Buildings/Converters/IconVehicleAssembler", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.VehicleAssemblerGood, "VehicleAssemblerGood", "WorldObjects/Buildings/Converters/VehicleAssemblerGood", "Models/Buildings/Converters/VehicleAssemblerGood", false, null, "Buildings/Converters/IconVehicleAssembler", false, ObjectSubCategory.BuildingsWorkshop);
		SetInfo(ObjectType.StorageGeneric, "StorageGeneric", "WorldObjects/Buildings/Storage/StorageGeneric", "Models/Buildings/Storage/StorageGeneric", false, null, "Buildings/Storage/IconStorageGeneric", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StorageGenericMedium, "StorageGenericMedium", "WorldObjects/Buildings/Storage/StorageGenericMedium", "Models/Buildings/Storage/StorageGenericMedium", false, null, "Buildings/Storage/IconStorageGeneric", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StoragePalette, "StoragePalette", "WorldObjects/Buildings/Storage/StoragePalette", "Models/Buildings/Storage/StoragePalette", false, null, "Buildings/Storage/IconStoragePalette", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StoragePaletteMedium, "StoragePaletteMedium", "WorldObjects/Buildings/Storage/StoragePaletteMedium", "Models/Buildings/Storage/StoragePaletteMedium", false, null, "Buildings/Storage/IconStoragePalette", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StorageLiquid, "StorageLiquid", "WorldObjects/Buildings/Storage/StorageLiquid", "Models/Buildings/Storage/StorageLiquid", false, null, "Buildings/Storage/IconStorageLiquid", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StorageLiquidMedium, "StorageLiquidMedium", "WorldObjects/Buildings/Storage/StorageLiquidMedium", "Models/Buildings/Storage/StorageCask", false, null, "Buildings/Storage/IconStorageLiquid", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StorageWorker, "StorageWorker", "WorldObjects/Buildings/Storage/StorageWorker", "Models/Buildings/Storage/StorageWorker", false, null, "Buildings/Storage/IconStorageWorker", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StorageFertiliser, "StorageFertiliser", "WorldObjects/Buildings/Storage/StorageFertiliser", "Models/Buildings/Storage/StorageFertiliser", false, null, "Buildings/Storage/IconStorageFertiliser", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StorageSand, "StorageSand", "WorldObjects/Buildings/Storage/StorageSand", "Models/Buildings/Storage/StorageSand", false, null, "Buildings/Storage/IconStorageSand", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StorageSandMedium, "StorageSandMedium", "WorldObjects/Buildings/Storage/StorageSandMedium", "Models/Buildings/Storage/StorageSiloMedium", false, null, "Buildings/Storage/IconStorageSand", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.StorageSeedlings, "StorageSeedlings", "WorldObjects/Buildings/Storage/StorageSeedlings", "Models/Buildings/Storage/StorageSeedlings", false, null, "Buildings/Storage/IconStorageSeedlings", false, ObjectSubCategory.BuildingsStorage);
		SetInfo(ObjectType.FolkSeedPod, "FolkSeedPod", "WorldObjects/Buildings/Converters/FolkSeedPod", "Models/Buildings/Converters/FolkSeedPod", false, null, "Buildings/Converters/IconFolkSeedPod", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.FolkSeedRehydrator, "FolkSeedRehydrator", "WorldObjects/Buildings/Converters/FolkSeedRehydrator", "Models/Buildings/Converters/FolkSeedRehydrator", false, null, "Buildings/Converters/IconFolkSeedRehydrator", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.Hut, "Hut", "WorldObjects/Buildings/Hut", "Models/Buildings/Hut", false, null, "Buildings/IconHut", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.LogCabin, "LogCabin", "WorldObjects/Buildings/LogCabin", "Models/Buildings/LogCabin", false, null, "Buildings/IconLogCabin", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.StoneCottage, "StoneCottage", "WorldObjects/Buildings/StoneCottage", "Models/Buildings/StoneCottage", false, null, "Buildings/IconStoneCottage", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.BrickHut, "BrickHut", "WorldObjects/Buildings/BrickHut", "Models/Buildings/BrickHut", false, null, "Buildings/IconBrickHut", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.Mansion, "Mansion", "WorldObjects/Buildings/Mansion", "Models/Buildings/Mansion", false, null, "Buildings/IconMansion", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.Castle, "Castle", "WorldObjects/Buildings/Castle", "Models/Buildings/Castle", false, null, "Buildings/IconMansion", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.TranscendBuilding, "TranscendBuilding", "WorldObjects/Buildings/TranscendBuilding", "Models/Buildings/TranscendBuilding", false, null, "Buildings/IconCrudeAnimalBreedingStation", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.ResearchStationCrude, "ResearchStationCrude", "WorldObjects/Buildings/Research/ResearchStationCrude", "Models/Buildings/ResearchStationCrude", false, null, "Buildings/IconResearchStationCrude", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.ResearchStationCrude2, "ResearchStationCrude2", "WorldObjects/Buildings/Research/ResearchStationCrude2", "Models/Buildings/ResearchStationCrude", false, null, "Buildings/IconResearchStationCrude", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.ResearchStationCrude3, "ResearchStationCrude3", "WorldObjects/Buildings/Research/ResearchStationCrude3", "Models/Buildings/ResearchStationCrude", false, null, "Buildings/IconResearchStationCrude", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.ResearchStationCrude4, "ResearchStationCrude4", "WorldObjects/Buildings/Research/ResearchStationCrude4", "Models/Buildings/ResearchStationCrude", false, null, "Buildings/IconResearchStationCrude", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.ResearchStationCrude5, "ResearchStationCrude5", "WorldObjects/Buildings/Research/ResearchStationCrude5", "Models/Buildings/ResearchStationCrude", false, null, "Buildings/IconResearchStationCrude", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.ResearchStationCrude6, "ResearchStationCrude6", "WorldObjects/Buildings/Research/ResearchStationCrude6", "Models/Buildings/ResearchStationCrude", false, null, "Buildings/IconResearchStationCrude", false, ObjectSubCategory.BuildingsSpecial);
		SetInfo(ObjectType.ConverterFoundation, "ConverterFoundation", "WorldObjects/Buildings/Converters/ConverterFoundation", "", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.Transmitter, "Transmitter", "WorldObjects/Buildings/Transmitter", "Models/Buildings/Transmitter", false, null, "Buildings/IconTransmitter", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.CrudePlantBreedingStation, "CrudePlantBreedingStation", "WorldObjects/Buildings/Converters/CrudePlantBreedingStation", "Models/Buildings/Converters/CrudePlantBreedingStation", false, null, "Buildings/IconCrudePlantBreedingStation", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.CrudeAnimalBreedingStation, "CrudeAnimalBreedingStation", "WorldObjects/Buildings/Converters/CrudeAnimalBreedingStation", "Models/Buildings/Converters/CrudeAnimalBreedingStation", false, null, "Buildings/IconCrudeAnimalBreedingStation", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.PotCrude, "PotCrude", "WorldObjects/Buildings/Converters/PotCrude", "Models/Buildings/Converters/PotCrude", false, null, "Buildings/Converters/IconPotCrude", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.CookingPotCrude, "CookingPotCrude", "WorldObjects/Buildings/Converters/CookingPotCrude", "Models/Buildings/Converters/CookingPotCrude", false, null, "Buildings/Converters/IconCookingPotCrude", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.Cauldron, "Cauldron", "WorldObjects/Buildings/Converters/Cauldron", "Models/Buildings/Converters/Cauldron", false, null, "Buildings/Converters/IconCauldron", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.Quern, "Quern", "WorldObjects/Buildings/Converters/Quern", "Models/Buildings/Converters/Quern", false, null, "Buildings/Converters/IconQuern", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.Gristmill, "Gristmill", "WorldObjects/Buildings/Converters/Gristmill", "Models/Buildings/Converters/Gristmill", false, null, "Buildings/Converters/IconGristmill", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.ButterChurn, "ButterChurn", "WorldObjects/Buildings/Converters/ButterChurn", "Models/Buildings/Converters/ButterChurn", false, null, "Buildings/Converters/IconButterChurn", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.KitchenTable, "KitchenTable", "WorldObjects/Buildings/Converters/KitchenTable", "Models/Buildings/Converters/KitchenTable", false, null, "Buildings/Converters/IconKitchenTable", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.OvenCrude, "OvenCrude", "WorldObjects/Buildings/Converters/OvenCrude", "Models/Buildings/Converters/OvenCrude", false, null, "Buildings/Converters/IconOvenCrude", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.Oven, "Oven", "WorldObjects/Buildings/Converters/Oven", "Models/Buildings/Converters/Oven", false, null, "Buildings/Converters/IconOven", false, ObjectSubCategory.BuildingsFood);
		SetInfo(ObjectType.FlooringCrude, "FlooringCrude", "WorldObjects/Buildings/Floors/FlooringCrude", "Models/Buildings/Floors/FlooringCrudeWhole", true, null, "Buildings/Floors/IconFlooringCrude", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.Workshop, "Workshop", "WorldObjects/Buildings/Floors/Workshop", "Models/Buildings/Floors/WorkshopFloorWhole", true, null, "Buildings/Floors/IconWorkshopFloor", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.FlooringBrick, "FlooringBrick", "WorldObjects/Buildings/Floors/FlooringBrick", "Models/Buildings/Floors/FlooringBrickWhole", true, null, "Buildings/Floors/IconFlooringBrick", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.FlooringFlagstone, "FlooringFlagstone", "WorldObjects/Buildings/Floors/FlooringFlagstone", "Models/Buildings/Floors/FlooringFlagstoneWhole", true, null, "Buildings/Floors/IconFlooringFlagstone", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.FlooringParquet, "FlooringParquet", "WorldObjects/Buildings/Floors/FlooringParquet", "Models/Buildings/Floors/FlooringParquetWhole", true, null, "Buildings/Floors/IconFlooringFlagstone", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.SandPath, "SandPath", "WorldObjects/Buildings/Floors/SandPath", "Models/Buildings/Floors/SandPath", true, null, "Buildings/Floors/IconSandPath", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.StonePath, "StonePath", "WorldObjects/Buildings/Floors/StonePath", "Models/Buildings/Floors/StonePath", true, null, "Buildings/Floors/IconStonePath", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.RoadCrude, "RoadCrude", "WorldObjects/Buildings/Floors/RoadCrude", "Models/Buildings/Floors/RoadCrude", true, null, "Buildings/Floors/IconRoadCrude", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.RoadGood, "RoadGood", "WorldObjects/Buildings/Floors/RoadGood", "Models/Buildings/Floors/RoadGood", true, null, "Buildings/Floors/IconRoadCrude", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.Bridge, "Bridge", "WorldObjects/Buildings/Floors/Bridge", "Models/Buildings/Floors/Bridge", true, null, "Buildings/Floors/IconBridge", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.BridgeStone, "BridgeStone", "WorldObjects/Buildings/Floors/BridgeStone", "Models/Buildings/Floors/BridgeStone", true, null, "Buildings/Floors/IconBridge", false, ObjectSubCategory.BuildingsFloors);
		SetInfo(ObjectType.FencePost, "FencePost", "WorldObjects/Buildings/FencePost", "Models/Buildings/FencePost", true, null, "Buildings/IconFencePost", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.Gate, "Gate", "WorldObjects/Buildings/Gate", "Models/Buildings/Gate", false, null, "Buildings/IconGate", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.FencePicket, "FencePicket", "WorldObjects/Buildings/FencePicket", "Models/Buildings/FencePicket", true, null, "Buildings/IconFencePicket", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.GatePicket, "GatePicket", "WorldObjects/Buildings/GatePicket", "Models/Buildings/GatePicket", false, null, "Buildings/IconGatePicket", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.StoneWall, "StoneWall", "WorldObjects/Buildings/StoneWall", "Models/Buildings/Wall_Dry_Stone", true, null, "Buildings/IconStoneWall", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.BrickWall, "BrickWall", "WorldObjects/Buildings/BrickWall", "Models/Buildings/BrickWall", true, null, "Buildings/IconBrickWall", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.LogWall, "LogWall", "WorldObjects/Buildings/LogWall", "Models/Buildings/LogWall", true, null, "Buildings/IconLogWall", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.BlockWall, "BlockWall", "WorldObjects/Buildings/BlockWall", "Models/Buildings/BlockWall", true, null, "Buildings/IconBlockWall", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.BlockDoor, "BlockDoor", "WorldObjects/Buildings/Door", "Models/Buildings/BlockDoor", true, null, "Buildings/IconBlockDoor", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.StoneArch, "StoneArch", "WorldObjects/Buildings/StoneArch", "Models/Buildings/StoneArch", false, null, "Buildings/IconStoneArch", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.StoneArchDoor, "StoneArchDoor", "WorldObjects/Buildings/Door", "Models/Buildings/StoneArchDoor", false, null, "Buildings/IconStoneArchDoor", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.LogArch, "LogArch", "WorldObjects/Buildings/LogArch", "Models/Buildings/LogArch", false, null, "Buildings/IconLogArch", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.Door, "Door", "WorldObjects/Buildings/Door", "Models/Buildings/Door", false, null, "Buildings/IconDoor", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.Window, "Window", "WorldObjects/Buildings/Window", "Models/Buildings/Window", false, null, "Buildings/IconWindow", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.WindowStone, "WindowStone", "WorldObjects/Buildings/Window", "Models/Buildings/WindowStone", false, null, "Buildings/IconWindow", false, ObjectSubCategory.BuildingsWalls);
		SetInfo(ObjectType.TrainTrack, "TrainTrack", "WorldObjects/Buildings/Floors/TrainTrack", "Models/Buildings/Floors/TrainTrack", true, null, "Buildings/Floors/IconTrainTrack", false, ObjectSubCategory.BuildingsTrains);
		SetInfo(ObjectType.TrainTrackCurve, "TrainTrackCurve", "WorldObjects/Buildings/Floors/TrainTrackCurve", "Models/Buildings/Floors/TrainTrackCurve", false, null, "Buildings/Floors/IconTrainTrackCurve", false, ObjectSubCategory.BuildingsTrains);
		SetInfo(ObjectType.TrainTrackPointsLeft, "TrainTrackPointsLeft", "WorldObjects/Buildings/Floors/TrainTrackPointsLeft", "Models/Buildings/Floors/TrainTrackPointsLeft", false, null, "Buildings/Floors/IconTrainTrackCurve", false, ObjectSubCategory.BuildingsTrains);
		SetInfo(ObjectType.TrainTrackPointsRight, "TrainTrackPointsRight", "WorldObjects/Buildings/Floors/TrainTrackPointsRight", "Models/Buildings/Floors/TrainTrackPointsRight", false, null, "Buildings/Floors/IconTrainTrackCurve", false, ObjectSubCategory.BuildingsTrains);
		SetInfo(ObjectType.TrainTrackBuffer, "TrainTrackBuffer", "WorldObjects/Buildings/Floors/TrainTrackBuffer", "Models/Buildings/Floors/TrainTrackBuffer", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.TrainTrackBridge, "TrainTrackBridge", "WorldObjects/Buildings/Floors/TrainTrackBridge", "Models/Buildings/Floors/TrainTrackBridge", true, null, "Buildings/Floors/IconTrainTrack", false, ObjectSubCategory.BuildingsTrains);
		SetInfo(ObjectType.Trough, "Trough", "WorldObjects/Buildings/Trough", "Models/Buildings/Trough", false, null, "Buildings/IconTrough", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.MilkingShedCrude, "MilkingShedCrude", "WorldObjects/Buildings/MilkingShedCrude", "Models/Buildings/MilkingShedCrude", false, null, "Buildings/IconMilkingShedCrude", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.ShearingShedCrude, "ShearingShedCrude", "WorldObjects/Buildings/ShearingShedCrude", "Models/Buildings/ShearingShedCrude", false, null, "Buildings/IconShearingShedCrude", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.SilkwormStation, "SilkwormStation", "WorldObjects/Buildings/SilkwormStation", "Models/Buildings/SilkwormStation", false, null, "Buildings/IconShearingShedCrude", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.Barn, "Barn", "WorldObjects/Buildings/Converters/Barn", "Models/Buildings/Converters/Barn", false, null, "Buildings/Converters/IconBarn", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.ChickenCoop, "ChickenCoop", "WorldObjects/Buildings/Converters/ChickenCoop", "Models/Buildings/Converters/ChickenCoop", false, null, "Buildings/Converters/IconChickenCoop", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.Aquarium, "Aquarium", "WorldObjects/Buildings/Aquarium", "Models/Buildings/Aquarium", false, null, "Buildings/Converters/IconChickenCoop", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.StorageBeehiveCrude, "StorageBeehiveCrude", "WorldObjects/Buildings/Storage/StorageBeehiveCrude", "Models/Buildings/Storage/StorageBeehiveCrude", false, null, "Buildings/Storage/IconStorageBeehiveCrude", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.StorageBeehive, "StorageBeehive", "WorldObjects/Buildings/Storage/StorageBeehive", "Models/Buildings/Storage/StorageBeehive", false, null, "Buildings/Storage/IconStorageBeehive", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.HayBalerCrude, "HayBalerCrude", "WorldObjects/Buildings/Converters/HayBalerCrude", "Models/Buildings/Converters/HayBalerCrude", false, null, "Buildings/Converters/IconHayBalerCrude", false, ObjectSubCategory.BuildingsAnimals);
		SetInfo(ObjectType.SpinningWheel, "SpinningWheel", "WorldObjects/Buildings/Converters/SpinningWheel", "Models/Buildings/Converters/SpinningWheel", false, null, "Buildings/Converters/IconSpinningWheel", false, ObjectSubCategory.BuildingsClothing);
		SetInfo(ObjectType.SpinningJenny, "SpinningJenny", "WorldObjects/Buildings/Converters/SpinningJenny", "Models/Buildings/Converters/SpinningJenny", false, null, "Buildings/Converters/IconSpinningWheel", false, ObjectSubCategory.BuildingsClothing);
		SetInfo(ObjectType.LoomCrude, "LoomCrude", "WorldObjects/Buildings/Converters/LoomCrude", "Models/Buildings/Converters/LoomCrude", false, null, "Buildings/Converters/IconLoomCrude", false, ObjectSubCategory.BuildingsClothing);
		SetInfo(ObjectType.LoomGood, "LoomGood", "WorldObjects/Buildings/Converters/LoomGood", "Models/Buildings/Converters/LoomGood", false, null, "Buildings/Converters/IconLoomCrude", false, ObjectSubCategory.BuildingsClothing);
		SetInfo(ObjectType.RockingChair, "RockingChair", "WorldObjects/Buildings/Converters/RockingChair", "Models/Buildings/Converters/RockingChair", false, null, "Buildings/Converters/IconRockingChair", false, ObjectSubCategory.BuildingsClothing);
		SetInfo(ObjectType.SewingStation, "SewingStation", "WorldObjects/Buildings/Converters/SewingStation", "Models/Buildings/Converters/SewingStation", false, null, "Buildings/Converters/IconSewingStation", false, ObjectSubCategory.BuildingsClothing);
		SetInfo(ObjectType.HatMaker, "HatMaker", "WorldObjects/Buildings/Converters/HatMaker", "Models/Buildings/Converters/MillineryBench", false, null, "Buildings/Converters/IconMillineryBench", false, ObjectSubCategory.BuildingsClothing);
		SetInfo(ObjectType.ClayStationCrude, "ClayStationCrude", "WorldObjects/Buildings/Converters/ClayStationCrude", "Models/Buildings/Converters/ClayStationCrude", false, null, "Buildings/Converters/IconClayStationCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.ClayStation, "ClayStation", "WorldObjects/Buildings/Converters/ClayStation", "Models/Buildings/Converters/ClayStation", false, null, "Buildings/Converters/IconClayStation", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.ClayFurnace, "ClayFurnace", "WorldObjects/Buildings/Converters/ClayFurnace", "Models/Buildings/Converters/ClayFurnace", false, null, "Buildings/Converters/IconClayFurnace", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.Furnace, "Furnace", "WorldObjects/Buildings/Converters/Furnace", "Models/Buildings/Converters/Furnace", false, null, "Buildings/Converters/IconFurnace", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.KilnCrude, "KilnCrude", "WorldObjects/Buildings/Converters/KilnCrude", "Models/Buildings/Converters/KilnCrude", false, null, "Buildings/Converters/IconKilnCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.WheatHammer, "WheatHammer", "WorldObjects/Buildings/Converters/WheatHammer", "Models/Buildings/Converters/WheatHammer", false, null, "Buildings/Converters/IconWheatHammer", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.StringWinderCrude, "StringWinderCrude", "WorldObjects/Buildings/Converters/StringWinderCrude", "Models/Buildings/Converters/StringWinderCrude", false, null, "Buildings/Converters/IconStringWinderCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.MortarMixerCrude, "MortarMixerCrude", "WorldObjects/Buildings/Converters/MortarMixerCrude", "Models/Buildings/Converters/MortarMixerCrude", false, null, "Buildings/Converters/IconMortarMixerCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.MortarMixerGood, "MortarMixerGood", "WorldObjects/Buildings/Converters/MortarMixerGood", "Models/Buildings/Converters/MortarMixerGood", false, null, "Buildings/Converters/IconMortarMixerCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.ToyStationCrude, "ToyStationCrude", "WorldObjects/Buildings/Converters/ToyStationCrude", "Models/Buildings/Converters/ToyStationCrude", false, null, "Buildings/Converters/IconToyStationCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.MedicineStation, "MedicineStation", "WorldObjects/Buildings/Converters/MedicineStation", "Models/Buildings/Converters/MedicineStation", false, null, "Buildings/Converters/IconMedicineStationCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.PrintingPress, "PrintingPress", "WorldObjects/Buildings/Converters/PrintingPress", "Models/Buildings/Converters/PrintingPress", false, null, "Buildings/Converters/IconMedicineStationCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.PaperMill, "PaperMill", "WorldObjects/Buildings/Converters/PaperMill", "Models/Buildings/Converters/PaperMill", false, null, "Buildings/Converters/IconMedicineStationCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.Easel, "Easel", "WorldObjects/Buildings/Converters/Easel", "Models/Buildings/Converters/Easel", false, null, "Buildings/Converters/IconMedicineStationCrude", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.Windmill, "Windmill", "WorldObjects/Buildings/Windmill", "Models/Buildings/Windmill", false, null, "Buildings/IconWindmill", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.StationaryEngine, "StationaryEngine", "WorldObjects/Buildings/StationaryEngine", "Models/Buildings/StationarySteamEngine", false, null, "Buildings/IconStationaryEngine", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.BeltLinkage, "BeltLinkage", "WorldObjects/Buildings/BeltLinkage", "Models/Buildings/BeltLinkage", false, null, "Buildings/IconBeltLinkage", false, ObjectSubCategory.BuildingsMisc);
		SetInfo(ObjectType.TrainTrackStop, "TrainTrackStop", "WorldObjects/Buildings/TrainTrackStop", "Models/Buildings/TrainTrackStop", false, null, "Buildings/IconBeltLinkage", false, ObjectSubCategory.BuildingsTrains);
		SetInfo(ObjectType.TrainRefuellingStation, "TrainRefuellingStation", "WorldObjects/Buildings/TrainRefuellingStation", "Models/Buildings/TrainRefuellingStation", false, null, "Buildings/IconBeltLinkage", false, ObjectSubCategory.BuildingsTrains);
		SetInfo(ObjectType.Wardrobe, "Wardrobe", "WorldObjects/Buildings/Wonders/Wardrobe", "Models/Buildings/Wonders/Wardrobe", false, null, "Buildings/Wonders/IconStoneHeads", false, ObjectSubCategory.BuildingsDecoration);
		SetInfo(ObjectType.StoneHeads, "StoneHeads", "WorldObjects/Buildings/Wonders/StoneHeads", "Models/Buildings/Wonders/StoneHeads", false, null, "Buildings/Wonders/IconStoneHeads", false, ObjectSubCategory.BuildingsDecoration);
		SetInfo(ObjectType.Ziggurat, "Ziggurat", "WorldObjects/Buildings/Wonders/Ziggurat", "Models/Buildings/Wonders/Ziggurat", false, null, "Buildings/Wonders/IconZiggurat", false, ObjectSubCategory.BuildingsDecoration);
		SetInfo(ObjectType.GiantWaterWheel, "GiantWaterWheel", "WorldObjects/Buildings/Wonders/GiantWaterWheel", "Models/Buildings/Wonders/GiantWaterWheel", false, null, "Buildings/Wonders/IconGiantWaterWheel", false, ObjectSubCategory.BuildingsDecoration);
		SetInfo(ObjectType.SpacePort, "SpacePort", "WorldObjects/Buildings/Wonders/SpacePort", "Models/Buildings/Wonders/SpacePort", false, null, "Buildings/Wonders/IconGiantWaterWheel", false, ObjectSubCategory.BuildingsDecoration);
		SetInfo(ObjectType.Catapult, "Catapult", "WorldObjects/Buildings/Wonders/Catapult", "Models/Buildings/Wonders/Catapult", false, null, "Buildings/Wonders/IconGiantWaterWheel", false, ObjectSubCategory.BuildingsDecoration);
		SetInfo(ObjectType.BotServer, "BotServer", "WorldObjects/Buildings/Wonders/BotServer", "Models/Buildings/Wonders/BotServer", false, null, "Buildings/Wonders/IconBotServer", false, ObjectSubCategory.BuildingsDecoration);
		SetInfo(ObjectType.StoneHenge, "StoneHenge", "WorldObjects/Buildings/Wonders/StoneHenge", "Models/Buildings/Wonders/StoneHenge", false, null, "Buildings/Wonders/IconStoneHenge", false, ObjectSubCategory.BuildingsDecoration);
		SetInfo(ObjectType.Canoe, "Canoe", "WorldObjects/Vehicles/Canoe", "Models/Vehicles/DugoutCanoe", false, null, "Vehicles/IconDugoutCanoe", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.Carriage, "Carriage", "WorldObjects/Vehicles/Carriage", "Models/Vehicles/Carriage", false, null, "Vehicles/IconCarriage", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.CarriageLiquid, "CarriageLiquid", "WorldObjects/Vehicles/CarriageLiquid", "Models/Vehicles/CarriageLiquid", false, null, "Vehicles/IconCarriage", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.CarriageTrain, "CarriageTrain", "WorldObjects/Vehicles/CarriageTrain", "Models/Vehicles/CarriageTrain", false, null, "Vehicles/IconCarriage", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.WheelBarrow, "WheelBarrow", "WorldObjects/Vehicles/WheelBarrow", "Models/Vehicles/WheelBarrow", false, null, "Vehicles/IconWheelBarrow", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.Cart, "Cart", "WorldObjects/Vehicles/Cart", "Models/Vehicles/Cart", false, null, "Vehicles/IconCart", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.CartLiquid, "CartLiquid", "WorldObjects/Vehicles/CartLiquid", "Models/Vehicles/CartLiquid", false, null, "Vehicles/IconCart", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.Minecart, "Minecart", "WorldObjects/Vehicles/Minecart", "Models/Vehicles/Minecart", false, null, "Vehicles/IconMinecart", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.Train, "Train", "WorldObjects/Vehicles/Train", "Models/Vehicles/Train", false, null, "Vehicles/IconTrain", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.CraneCrude, "CraneCrude", "WorldObjects/Vehicles/CraneCrude", "Models/Vehicles/CraneCrude", false, null, "Vehicles/IconCraneCrude", false, ObjectSubCategory.Vehicles);
		SetInfo(ObjectType.Weed, "Weed", "WorldObjects/Crops/Weed", "Models/Crops/Weed", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Grass, "Grass", "WorldObjects/Crops/Grass", "Models/Crops/Grass", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.CropWheat, "CropWheat", "WorldObjects/Crops/CropWheat", "Models/Crops/CropWheat", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.CropCotton, "CropCotton", "WorldObjects/Crops/CropCotton", "Models/Crops/CropCotton", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.CropCarrot, "CropCarrot", "WorldObjects/Crops/CropCarrot", "Models/Crops/CropCarrotCultivated", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.TreeCoconut, "TreeCoconut", "WorldObjects/Crops/TreeCoconut", "Models/Crops/TreePalm", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.TreePine, "TreePine", "WorldObjects/Crops/TreePine", "Models/Crops/TreePine", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.TreeApple, "TreeApple", "WorldObjects/Crops/TreeApple", "Models/Crops/TreeApple", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.TreeMulberry, "TreeMulberry", "WorldObjects/Crops/TreeMulberry", "Models/Crops/TreeMulberry", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.TreeStump, "TreeStump", "WorldObjects/Crops/TreeStump", "Models/Crops/TreeStump", true, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.CropPumpkin, "CropPumpkin", "WorldObjects/Crops/CropPumpkin", "Models/Crops/CropPumpkin", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Bush, "Bush", "WorldObjects/Crops/Bush", "Models/Crops/Bush", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Hedge, "Hedge", "WorldObjects/Crops/Hedge", "Models/Crops/Hedge", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Mushroom, "Mushroom", "WorldObjects/Crops/Mushroom", "Models/Crops/Mushroom", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerWild, "FlowerWild", "WorldObjects/Crops/FlowerWild", "Models/Crops/Flower01", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Bullrushes, "Bullrushes", "WorldObjects/Crops/Bullrushes", "Models/Crops/Bullrushes", true, null, "", false, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.AnimalCow, "AnimalCow", "WorldObjects/Animals/AnimalCow", "Models/Animals/AnimalCow", false, null, "Animals/IconAnimalCow", false, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.AnimalSheep, "AnimalSheep", "WorldObjects/Animals/AnimalSheep", "Models/Animals/AnimalSheep", false, null, "Animals/IconAnimalSheep", false, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.AnimalCowHighland, "AnimalCowHighland", "WorldObjects/Animals/AnimalCow", "Models/Animals/AnimalCowHighland", false, null, "Animals/IconAnimalCow", false, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.AnimalAlpaca, "AnimalAlpaca", "WorldObjects/Animals/AnimalSheep", "Models/Animals/AnimalAlpaca", false, null, "Animals/IconAnimalSheep", false, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.AnimalChicken, "AnimalChicken", "WorldObjects/Animals/AnimalChicken", "Models/Animals/AnimalChicken", false, null, "Animals/IconAnimalChicken", false, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.AnimalBird, "AnimalBird", "WorldObjects/Animals/AnimalBird", "Models/Animals/AnimalBird", false, null, "Animals/IconAnimalBird", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.AnimalBee, "AnimalBee", "WorldObjects/Animals/AnimalBee", "Models/Animals/AnimalBee", false, null, "Animals/IconAnimalBee", false, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.AnimalLeech, "AnimalLeech", "WorldObjects/Animals/AnimalLeech", "Models/Animals/AnimalLeech", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.AnimalSilkworm, "AnimalSilkworm", "WorldObjects/Animals/AnimalSilkworm", "Models/Animals/AnimalSilkworm", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.AnimalSilkmoth, "AnimalSilkmoth", "WorldObjects/Animals/AnimalSilkmoth", "Models/Animals/AnimalSilkmoth", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishBait, "FishBait", "WorldObjects/Fish/FishBait", "Models/Fish/FishBait", false, null, "Fish/IconFishBait", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishSalmon, "FishSalmon", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishSalmon", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishCatFish, "FishCatFish", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishCatFish", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishCarp, "FishCarp", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishCarp", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishMahiMahi, "FishMahiMahi", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishMahiMahi", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishGar, "FishGar", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishGar", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishOrangeRoughy, "FishOrangeRoughy", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishRoughy", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishMonkfish, "FishMonkfish", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishMonkfish", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishPerch, "FishPerch", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishPerch", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.FishMarlin, "FishMarlin", "WorldObjects/Fish/FishSalmon", "Models/Fish/FishMarlin", false, null, "Fish/IconFishSalmon", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.Log, "Log", "WorldObjects/Parts/Wood/Log", "Models/Parts/Wood/Log", true, null, "Parts/Wood/IconLog", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.Plank, "Plank", "WorldObjects/Parts/Wood/Plank", "Models/Parts/Wood/Plank", true, null, "Parts/Wood/IconPlank", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.Pole, "Pole", "WorldObjects/Parts/Wood/Pole", "Models/Parts/Wood/Pole", true, null, "Parts/Wood/IconPole", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.CogCrude, "CogCrude", "WorldObjects/Parts/Wood/CogCrude", "Models/Parts/Wood/CogCrude", true, null, "Parts/Wood/IconCogCrude", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.Cog, "Cog", "WorldObjects/Parts/Wood/Cog", "Models/Parts/Wood/Cog", true, null, "Parts/Wood/IconCog", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.Axle, "Axle", "WorldObjects/Parts/Wood/Axle", "Models/Parts/Wood/Axle", true, null, "Parts/Wood/IconAxle", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.WheelCrude, "WheelCrude", "WorldObjects/Parts/Wood/WheelCrude", "Models/Parts/Wood/WheelCrude", true, null, "Parts/Wood/IconWheelCrude", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.Wheel, "Wheel", "WorldObjects/Parts/Wood/Wheel", "Models/Parts/Wood/Wheel", true, null, "Parts/Wood/IconWheel", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.Crank, "Crank", "WorldObjects/Parts/Wood/Crank", "Models/Parts/Wood/Crank", true, null, "Parts/Wood/IconCrank", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.FixingPeg, "FixingPeg", "WorldObjects/Parts/Wood/FixingPeg", "Models/Parts/Wood/FixingPeg", true, null, "Parts/Wood/IconFixingPeg", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.FrameBox, "FrameBox", "WorldObjects/Parts/Wood/FrameBox", "Models/Parts/Wood/FrameBox", true, null, "Parts/Wood/IconFrameBox", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.FrameSquare, "FrameSquare", "WorldObjects/Parts/Wood/FrameSquare", "Models/Parts/Wood/FrameSquare", true, null, "Parts/Wood/IconFrameSquare", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.FrameTriangle, "FrameTriangle", "WorldObjects/Parts/Wood/FrameTriangle", "Models/Parts/Wood/FrameTriangle", true, null, "Parts/Wood/IconFrameTriangle", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.FrameWindow, "FrameWindow", "WorldObjects/Parts/Wood/FrameWindow", "Models/Parts/Wood/FrameWindow", true, null, "Parts/Wood/IconFrameWindow", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.FrameDoor, "FrameDoor", "WorldObjects/Parts/Wood/FrameDoor", "Models/Parts/Wood/FrameDoor", true, null, "Parts/Wood/IconFrameDoor", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.Panel, "Panel", "WorldObjects/Parts/Wood/Panel", "Models/Parts/Wood/Panel", true, null, "Parts/Wood/IconPanel", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.WoodenBeam, "WoodenBeam", "WorldObjects/Holdable", "Models/Parts/Wood/WoodenBeam", true, null, "Parts/Wood/IconPanel", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.IronOre, "IronOre", "WorldObjects/Parts/Metal/IronOre", "Models/Parts/Metal/IronOre", true, null, "Parts/Metal/IconIronOre", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.IronCrude, "IronCrude", "WorldObjects/Parts/Metal/IronCrude", "Models/Parts/Metal/IronCrude", true, null, "Parts/Metal/IconIronCrude", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.MetalPoleCrude, "MetalPoleCrude", "WorldObjects/Parts/Metal/MetalPoleCrude", "Models/Parts/Metal/MetalPoleCrude", true, null, "Parts/Metal/IconMetalPoleCrude", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.MetalPlateCrude, "MetalPlateCrude", "WorldObjects/Holdable", "Models/Parts/Metal/MetalPlateCrude", true, null, "Parts/Metal/IconMetalPlateCrude", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.MetalCog, "MetalCog", "WorldObjects/Parts/Metal/MetalCog", "Models/Parts/Metal/MetalCog", true, null, "Parts/Metal/IconMetalCog", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.MetalWheel, "MetalWheel", "WorldObjects/Holdable", "Models/Parts/Metal/MetalWheel", true, null, "Parts/Metal/IconMetalCog", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.MetalAxle, "MetalAxle", "WorldObjects/Holdable", "Models/Parts/Metal/MetalAxle", true, null, "Parts/Metal/IconMetalCog", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.Flywheel, "Flywheel", "WorldObjects/Parts/Metal/Flywheel", "Models/Parts/Metal/Flywheel", true, null, "Parts/Metal/IconFlywheel", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.ConnectingRod, "ConnectingRod", "WorldObjects/Parts/Metal/ConnectingRod", "Models/Parts/Metal/ConnectingRod", true, null, "Parts/Metal/IconConnectingRod", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.Piston, "Piston", "WorldObjects/Parts/Metal/Piston", "Models/Parts/Metal/Piston", true, null, "Parts/Metal/IconPiston", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.MetalGirder, "MetalGirder", "WorldObjects/Holdable", "Models/Parts/Metal/MetalGirder", true, null, "Parts/Metal/IconPiston", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.Boiler, "Boiler", "WorldObjects/Parts/Metal/Boiler", "Models/Parts/Metal/Boiler", true, null, "Parts/Metal/IconBoiler", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.Firebox, "Firebox", "WorldObjects/Holdable", "Models/Parts/Metal/Firebox", true, null, "Parts/Metal/IconBoiler", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.Rivets, "Rivets", "WorldObjects/Holdable", "Models/Parts/Metal/Rivets", true, null, "Parts/Metal/IconBoiler", true, ObjectSubCategory.PartsMetal);
		SetInfo(ObjectType.Rock, "Rock", "WorldObjects/Other/Rock", "Models/Other/Rock", true, null, "Other/IconRock", true, ObjectSubCategory.PartsStone);
		SetInfo(ObjectType.RockSharp, "RockSharp", "WorldObjects/Parts/Stone/RockSharp", "Models/Parts/Stone/RockSharp", false, null, "Parts/Stone/IconRockSharp", true, ObjectSubCategory.ToolsLevel1);
		SetInfo(ObjectType.StoneBlockCrude, "StoneBlockCrude", "WorldObjects/Parts/Stone/StoneBlockCrude", "Models/Parts/Stone/StoneBlockCrude", false, null, "Parts/Stone/IconStoneBlockCrude", true, ObjectSubCategory.PartsStone);
		SetInfo(ObjectType.StoneBlock, "StoneBlock", "WorldObjects/Parts/Stone/StoneBlock", "Models/Parts/Stone/StoneBlock", false, null, "Parts/Stone/IconStoneBlock", true, ObjectSubCategory.PartsStone);
		SetInfo(ObjectType.Fireplace, "Fireplace", "WorldObjects/Parts/Stone/Fireplace", "Models/Parts/Stone/Fireplace", true, null, "Parts/Stone/IconFireplace", true, ObjectSubCategory.PartsStone);
		SetInfo(ObjectType.Chimney, "Chimney", "WorldObjects/Parts/Stone/Chimney", "Models/Parts/Stone/Chimney", true, null, "Parts/Stone/IconChimney", true, ObjectSubCategory.PartsStone);
		SetInfo(ObjectType.Millstone, "Millstone", "WorldObjects/Parts/Stone/Millstone", "Models/Parts/Stone/Millstone", true, null, "Parts/Stone/IconMillstone", true, ObjectSubCategory.PartsStone);
		SetInfo(ObjectType.Clay, "Clay", "WorldObjects/Other/Clay", "Models/Other/Clay", true, null, "Other/IconClay", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.PotClayRaw, "PotClayRaw", "WorldObjects/Other/PotClayRaw", "Models/Other/PotClayRaw", true, null, "Other/IconPotClayRaw", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.PotClay, "PotClay", "WorldObjects/Other/PotClay", "Models/Other/PotClay", true, null, "Other/IconPotClay", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.LargeBowlClayRaw, "LargeBowlClayRaw", "WorldObjects/Holdable", "Models/Other/LargeBowlClayRaw", true, null, "Other/IconLargeBowlClayRaw", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.LargeBowlClay, "LargeBowlClay", "WorldObjects/Holdable", "Models/Other/LargeBowlClay", true, null, "Other/IconLargeBowlClay", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.JarClayRaw, "JarClayRaw", "WorldObjects/Other/PotClayRaw", "Models/Other/JarClayRaw", true, null, "Other/IconJarClayRaw", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.JarClay, "JarClay", "WorldObjects/Other/PotClay", "Models/Other/JarClay", true, null, "Other/IconJarClay", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.BricksCrudeRaw, "BricksCrudeRaw", "WorldObjects/Parts/Stone/BricksCrudeRaw", "Models/Parts/Stone/BricksCrudeRaw", true, null, "Parts/Stone/IconBricksCrudeRaw", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.BricksCrude, "BricksCrude", "WorldObjects/Parts/Stone/BricksCrude", "Models/Parts/Stone/BricksCrude", true, null, "Parts/Stone/IconBricksCrude", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.RoofTilesRaw, "RoofTilesRaw", "WorldObjects/Holdable", "Models/Parts/Stone/RoofTilesRaw", true, null, "Other/IconRoofTilesRaw", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.RoofTiles, "RoofTiles", "WorldObjects/Holdable", "Models/Parts/Stone/RoofTiles", true, null, "Other/IconRoofTiles", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.FlowerPotRaw, "FlowerPotRaw", "WorldObjects/Other/FlowerPotRaw", "Models/Other/FlowerPotRaw", true, null, "Other/IconFlowerPotRaw", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.FlowerPot, "FlowerPot", "WorldObjects/Other/FlowerPot", "Models/Other/FlowerPot", true, null, "Other/IconFlowerPot", true, ObjectSubCategory.PartsClay);
		SetInfo(ObjectType.GnomeRaw, "GnomeRaw", "WorldObjects/Other/Decoration", "Models/Other/GnomeRaw", true, null, "Other/IconHayBale", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Gnome, "Gnome", "WorldObjects/Other/Decoration", "Models/Other/Gnome", true, null, "Other/IconHayBale", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Gnome2, "Gnome2", "WorldObjects/Other/Decoration", "Models/Other/Gnome2", true, null, "Other/IconHayBale", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Gnome3, "Gnome3", "WorldObjects/Other/Decoration", "Models/Other/Gnome3", true, null, "Other/IconHayBale", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Gnome4, "Gnome4", "WorldObjects/Other/Decoration", "Models/Other/Gnome4", true, null, "Other/IconHayBale", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Gnome5, "Gnome5", "WorldObjects/Other/Decoration", "Models/Other/Gnome5", true, null, "Other/IconHayBale", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Gnome6, "Gnome6", "WorldObjects/Other/Decoration", "Models/Other/Gnome6", true, null, "Other/IconHayBale", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Wool, "Wool", "WorldObjects/Other/Wool", "Models/Other/Wool", true, null, "Other/IconWool", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.Fleece, "Fleece", "WorldObjects/Other/Fleece", "Models/Other/Fleece", true, null, "Other/IconFleece", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.Blanket, "Blanket", "WorldObjects/Parts/Clothes/Blanket", "Models/Parts/Clothes/Blanket", true, null, "Parts/Clothes/IconBlanket", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.Buttons, "Buttons", "WorldObjects/Parts/Clothes/Buttons", "Models/Parts/Clothes/Buttons", true, null, "Parts/Clothes/IconButtons", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.Thread, "Thread", "WorldObjects/Parts/Clothes/Thread", "Models/Parts/Clothes/Thread", true, null, "Parts/Clothes/IconThread", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.CottonLint, "CottonLint", "WorldObjects/Holdable", "Models/Parts/Clothes/CottonLint", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.CottonThread, "CottonThread", "WorldObjects/Holdable", "Models/Parts/Clothes/CottonThread", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.CottonCloth, "CottonCloth", "WorldObjects/Holdable", "Models/Parts/Clothes/CottonCloth", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.BullrushesFibre, "BullrushesFibre", "WorldObjects/Holdable", "Models/Parts/Clothes/BullrushesFibre", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.BullrushesThread, "BullrushesThread", "WorldObjects/Holdable", "Models/Parts/Clothes/BullrushesThread", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.BullrushesCloth, "BullrushesCloth", "WorldObjects/Holdable", "Models/Parts/Clothes/BullrushesCloth", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.SilkRaw, "SilkRaw", "WorldObjects/Holdable", "Models/Parts/Clothes/SilkRaw", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.SilkThread, "SilkThread", "WorldObjects/Holdable", "Models/Parts/Clothes/SilkThread", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.SilkCloth, "SilkCloth", "WorldObjects/Holdable", "Models/Parts/Clothes/SilkCloth", true, null, "Other/IconHayBale", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.WheatSeed, "WheatSeed", "WorldObjects/Other/WheatSeed", "Models/Other/WheatSeed", true, null, "Other/IconWheatSeed", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.CarrotSeed, "CarrotSeed", "WorldObjects/Holdable", "Models/Other/CarrotSeeds", true, null, "Other/IconCarrotSeed", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.MilkPorridge, "MilkPorridge", "WorldObjects/Food/MilkPorridge", "Models/Food/MilkPorridge", true, null, "Food/IconMilkPorridge", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.FruitPorridge, "FruitPorridge", "WorldObjects/Food/FruitPorridge", "Models/Food/FruitPorridge", true, null, "Food/IconFruitPorridge", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.HoneyPorridge, "HoneyPorridge", "WorldObjects/Food/HoneyPorridge", "Models/Food/HoneyPorridge", true, null, "Food/IconHoneyPorridge", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.AppleBerryPieRaw, "AppleBerryPieRaw", "WorldObjects/Holdable", "Models/Other/AppleBerryPieRaw", true, null, "Other/IconAppleBerryPieRaw", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.AppleBerryPie, "AppleBerryPie", "WorldObjects/Food/Food", "Models/Food/AppleBerryPie", true, null, "Food/IconAppleBerryPie", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.PumpkinMushroomPieRaw, "PumpkinMushroomPieRaw", "WorldObjects/Holdable", "Models/Other/PumpkinMushroomPieRaw", true, null, "Other/IconPumpkinMushroomPieRaw", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinMushroomPie, "PumpkinMushroomPie", "WorldObjects/Food/Food", "Models/Food/PumpkinMushroomPie", true, null, "Food/IconPumpkinMushroomPie", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.MushroomDug, "MushroomDug", "WorldObjects/Food/Food", "Models/Food/MushroomDug", true, null, "Food/IconMushroomDug", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.MushroomHerb, "MushroomHerb", "WorldObjects/Food/Food", "Models/Food/MushroomHerb", true, null, "Food/IconMushroomHerb", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.MushroomSoup, "MushroomSoup", "WorldObjects/Food/Food", "Models/Food/MushroomSoup", true, null, "Food/IconMushroomSoup", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.MushroomStew, "MushroomStew", "WorldObjects/Food/Food", "Models/Food/MushroomStew", true, null, "Food/IconMushroomStew", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.MushroomPieRaw, "MushroomPieRaw", "WorldObjects/Holdable", "Models/Other/MushroomPieRaw", true, null, "Food/IconMushroomPieRaw", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.MushroomPie, "MushroomPie", "WorldObjects/Food/Food", "Models/Food/MushroomPie", true, null, "Food/IconMushroomPie", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.MushroomPuddingRaw, "MushroomPuddingRaw", "WorldObjects/Holdable", "Models/Food/MushroomPuddingRaw", true, null, "Food/IconMushroomPieRaw", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.MushroomPudding, "MushroomPudding", "WorldObjects/Food/Food", "Models/Food/MushroomPudding", true, null, "Food/IconMushroomPie", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.MushroomBurger, "MushroomBurger", "WorldObjects/Food/Food", "Models/Food/MushroomBurger", true, null, "Food/IconMushroomPie", true, ObjectSubCategory.FoodMushroom);
		SetInfo(ObjectType.Berries, "Berries", "WorldObjects/Food/Food", "Models/Food/Berries", true, null, "Food/IconBerries", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.BerriesSpice, "BerriesSpice", "WorldObjects/Food/Food", "Models/Food/BerriesSpice", true, null, "Food/IconBerriesSpice", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.BerriesStew, "BerriesStew", "WorldObjects/Food/Food", "Models/Food/BerriesStew", true, null, "Food/IconBerriesStew", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.BerriesJam, "BerriesJam", "WorldObjects/Food/Food", "Models/Food/BerriesJam", true, null, "Food/IconBerriesJam", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.BerriesPieRaw, "BerriesPieRaw", "WorldObjects/Holdable", "Models/Other/BerriesPieRaw", true, null, "Food/IconBerriesPieRaw", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.BerriesPie, "BerriesPie", "WorldObjects/Food/Food", "Models/Food/BerriesPie", true, null, "Food/IconBerriesPie", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.BerriesCakeRaw, "BerriesCakeRaw", "WorldObjects/Food/Food", "Models/Food/BerriesCakeRaw", true, null, "Food/IconBerriesPie", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.BerriesCake, "BerriesCake", "WorldObjects/Food/Food", "Models/Food/BerriesCake", true, null, "Food/IconBerriesPie", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.BerryDanish, "BerryDanish", "WorldObjects/Food/Food", "Models/Food/BerryDanish", true, null, "Food/IconBerriesPie", true, ObjectSubCategory.FoodBerry);
		SetInfo(ObjectType.Porridge, "Porridge", "WorldObjects/Food/Food", "Models/Food/Porridge", true, null, "Food/IconPorridge", true, ObjectSubCategory.FoodCereal);
		SetInfo(ObjectType.BreadCrude, "BreadCrude", "WorldObjects/Food/Food", "Models/Food/BreadCrude", true, null, "Food/IconBreadCrude", true, ObjectSubCategory.FoodCereal);
		SetInfo(ObjectType.Bread, "Bread", "WorldObjects/Food/Food", "Models/Food/Bread", true, null, "Food/IconBread", true, ObjectSubCategory.FoodCereal);
		SetInfo(ObjectType.BreadButtered, "BreadButtered", "WorldObjects/Food/Food", "Models/Food/BreadButtered", true, null, "Food/IconBreadButtered", true, ObjectSubCategory.FoodCereal);
		SetInfo(ObjectType.BreadPuddingRaw, "BreadPuddingRaw", "WorldObjects/Food/Food", "Models/Food/BreadPuddingRaw", true, null, "Food/IconBreadButtered", true, ObjectSubCategory.FoodCereal);
		SetInfo(ObjectType.BreadPudding, "BreadPudding", "WorldObjects/Food/Food", "Models/Food/BreadPudding", true, null, "Food/IconBreadButtered", true, ObjectSubCategory.FoodCereal);
		SetInfo(ObjectType.CreamBrioche, "CreamBrioche", "WorldObjects/Food/Food", "Models/Food/CreamBrioche", true, null, "Food/IconBreadButtered", true, ObjectSubCategory.FoodCereal);
		SetInfo(ObjectType.PumpkinRaw, "PumpkinRaw", "WorldObjects/Food/PumpkinRaw", "Models/Food/PumpkinRaw", true, null, "Food/IconPumpkinRaw", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinSeeds, "PumpkinSeeds", "WorldObjects/Other/PumpkinSeeds", "Models/Other/PumpkinSeeds", true, null, "Other/IconPumpkinSeeds", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinHerb, "PumpkinHerb", "WorldObjects/Food/Food", "Models/Food/PumpkinHerb", true, null, "Food/IconPumpkinHerb", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinSoup, "PumpkinSoup", "WorldObjects/Food/PumpkinSoup", "Models/Food/PumpkinSoup", true, null, "Food/IconPumpkinSoup", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinStew, "PumpkinStew", "WorldObjects/Food/Food", "Models/Food/PumpkinStew", true, null, "Food/IconPumpkinStew", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinPieRaw, "PumpkinPieRaw", "WorldObjects/Other/PumpkinPieRaw", "Models/Other/PumpkinPieRaw", true, null, "Other/IconPumpkinPieRaw", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinPie, "PumpkinPie", "WorldObjects/Food/PumpkinPie", "Models/Food/PumpkinPie", true, null, "Food/IconPumpkinPie", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinCakeRaw, "PumpkinCakeRaw", "WorldObjects/Holdable", "Models/Food/PumpkinCakeRaw", true, null, "Food/IconPumpkinPie", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinCake, "PumpkinCake", "WorldObjects/Food/Food", "Models/Food/PumpkinCake", true, null, "Food/IconPumpkinPie", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.PumpkinBurger, "PumpkinBurger", "WorldObjects/Food/Food", "Models/Food/PumpkinBurger", true, null, "Food/IconPumpkinPie", true, ObjectSubCategory.FoodPumpkin);
		SetInfo(ObjectType.Apple, "Apple", "WorldObjects/Food/Apple", "Models/Food/Apple", true, null, "Food/IconApple", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.AppleSpice, "AppleSpice", "WorldObjects/Food/Food", "Models/Food/AppleSpice", true, null, "Food/IconApple", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.AppleStew, "AppleStew", "WorldObjects/Food/Food", "Models/Food/AppleStew", true, null, "Food/IconApple", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.AppleJam, "AppleJam", "WorldObjects/Food/Food", "Models/Food/AppleJam", true, null, "Food/IconApple", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.ApplePieRaw, "ApplePieRaw", "WorldObjects/Other/ApplePieRaw", "Models/Other/ApplePieRaw", true, null, "Other/IconApplePieRaw", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.ApplePie, "ApplePie", "WorldObjects/Food/ApplePie", "Models/Food/ApplePie", true, null, "Food/IconApplePie", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.AppleCakeRaw, "AppleCakeRaw", "WorldObjects/Food/Food", "Models/Food/AppleCakeRaw", true, null, "Food/IconApplePie", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.AppleCake, "AppleCake", "WorldObjects/Food/Food", "Models/Food/AppleCake", true, null, "Food/IconApplePie", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.AppleDanish, "AppleDanish", "WorldObjects/Food/Food", "Models/Food/AppleDanish", true, null, "Food/IconApplePie", true, ObjectSubCategory.FoodApple);
		SetInfo(ObjectType.FishRaw, "FishRaw", "WorldObjects/Food/Food", "Models/Food/FishRaw", true, null, "Food/IconFishRaw", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.FishHerb, "FishHerb", "WorldObjects/Food/Food", "Models/Food/FishHerb", true, null, "Food/IconFishHerb", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.FishSoup, "FishSoup", "WorldObjects/Food/Food", "Models/Food/FishSoup", true, null, "Food/IconFishSoup", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.FishStew, "FishStew", "WorldObjects/Food/Food", "Models/Food/FishStew", true, null, "Food/IconFishStew", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.FishPieRaw, "FishPieRaw", "WorldObjects/Holdable", "Models/Other/FishPieRaw", true, null, "Food/IconFishPieRaw", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.FishPie, "FishPie", "WorldObjects/Food/Food", "Models/Food/FishPie", true, null, "Food/IconFishPie", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.FishCakeRaw, "FishCakeRaw", "WorldObjects/Holdable", "Models/Food/FishCakeRaw", true, null, "Food/IconFishPie", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.FishCake, "FishCake", "WorldObjects/Food/Food", "Models/Food/FishCake", true, null, "Food/IconFishPie", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.FishBurger, "FishBurger", "WorldObjects/Food/Food", "Models/Food/FishBurger", true, null, "Food/IconFishPie", true, ObjectSubCategory.FoodFish);
		SetInfo(ObjectType.Carrot, "Carrot", "WorldObjects/Food/Food", "Models/Food/Carrot", true, null, "Other/IconCarrot", true, ObjectSubCategory.FoodCarrot);
		SetInfo(ObjectType.CarrotSalad, "CarrotSalad", "WorldObjects/Food/Food", "Models/Food/CarrotSalad", true, null, "Other/IconCarrot", true, ObjectSubCategory.FoodCarrot);
		SetInfo(ObjectType.CarrotStirFry, "CarrotStirFry", "WorldObjects/Food/Food", "Models/Food/CarrotStirFry", true, null, "Other/IconCarrot", true, ObjectSubCategory.FoodCarrot);
		SetInfo(ObjectType.CarrotHoney, "CarrotHoney", "WorldObjects/Food/Food", "Models/Food/CarrotHoney", true, null, "Other/IconCarrot", true, ObjectSubCategory.FoodCarrot);
		SetInfo(ObjectType.CarrotCurry, "CarrotCurry", "WorldObjects/Food/Food", "Models/Food/CarrotCurry", true, null, "Other/IconCarrot", true, ObjectSubCategory.FoodCarrot);
		SetInfo(ObjectType.CarrotCakeRaw, "CarrotCakeRaw", "WorldObjects/Holdable", "Models/Food/CarrotCakeRaw", true, null, "Other/IconCarrot", true, ObjectSubCategory.FoodCarrot);
		SetInfo(ObjectType.CarrotCake, "CarrotCake", "WorldObjects/Food/Food", "Models/Food/CarrotCake", true, null, "Other/IconCarrot", true, ObjectSubCategory.FoodCarrot);
		SetInfo(ObjectType.CarrotBurger, "CarrotBurger", "WorldObjects/Food/Food", "Models/Food/CarrotBurger", true, null, "Other/IconCarrot", true, ObjectSubCategory.FoodCarrot);
		SetInfo(ObjectType.Water, "Water", "WorldObjects/Food/Water", "", true, null, "Food/IconWater", false, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.WeedDug, "WeedDug", "WorldObjects/Other/WeedDug", "Models/Other/WeedDug", true, null, "Other/IconWeedDug", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.Egg, "Egg", "WorldObjects/Food/Egg", "Models/Food/Egg", true, null, "Food/IconEgg", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.Milk, "Milk", "WorldObjects/Food/Milk", "", true, null, "Food/IconMilk", false, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.Honey, "Honey", "WorldObjects/Special/Honey", "", true, null, "Other/IconHoney", false, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.Butter, "Butter", "WorldObjects/Other/Butter", "Models/Other/Butter", true, null, "Other/IconButter", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.Pumpkin, "Pumpkin", "WorldObjects/Other/Pumpkin", "Models/Other/Pumpkin", true, null, "Other/IconPumpkin", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Manure, "Manure", "WorldObjects/Other/Manure", "Models/Other/Manure", true, null, "Other/IconManure", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.TreeSeed, "TreeSeed", "WorldObjects/Other/TreeSeed", "Models/Other/TreeSeed", true, null, "Other/IconTreeSeed", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.MulberrySeed, "MulberrySeed", "WorldObjects/Other/TreeSeed", "Models/Other/MulberrySeed", true, null, "Other/IconTreeSeed", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Coconut, "Coconut", "WorldObjects/Holdable", "Models/Other/Coconut", true, null, "Food/IconCoconut", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Seedling, "Seedling", "WorldObjects/Other/Seedling", "Models/Other/Seedling", true, null, "Other/IconSeedling", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.SeedlingMulberry, "SeedlingMulberry", "WorldObjects/Other/Seedling", "Models/Other/SeedlingMulberry", true, null, "Other/IconSeedling", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Stick, "Stick", "WorldObjects/Other/Stick", "Models/Other/Stick", true, null, "Other/IconStick", true, ObjectSubCategory.PartsWood);
		SetInfo(ObjectType.GrassCut, "GrassCut", "WorldObjects/Other/GrassCut", "Models/Other/GrassCut", true, null, "Other/IconGrassCut", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Turf, "Turf", "WorldObjects/Other/Turf", "Models/Other/Turf", true, null, "Other/IconTurf", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Wheat, "Wheat", "WorldObjects/Other/Wheat", "Models/Other/Wheat", true, null, "Other/IconWheat", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Fertiliser, "Fertiliser", "WorldObjects/Other/Fertiliser", "Models/Other/Fertiliser", true, null, "Other/IconFertiliser", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Coal, "Coal", "WorldObjects/Other/Coal", "Models/Other/Coal", true, null, "Other/IconCoal", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Boulder, "Boulder", "WorldObjects/Other/Boulder", "Models/Other/Boulder", true, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.TallBoulder, "TallBoulder", "WorldObjects/Other/TallBoulder", "Models/Other/TallBoulder", true, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.Charcoal, "Charcoal", "WorldObjects/Other/Charcoal", "Models/Other/Charcoal", true, null, "Other/IconCharcoal", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Straw, "Straw", "WorldObjects/Other/Straw", "Models/Other/Straw", true, null, "Other/IconStraw", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Dough, "Dough", "WorldObjects/Other/Dough", "Models/Other/Dough", true, null, "Other/IconDough", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.DoughGood, "DoughGood", "WorldObjects/Holdable", "Models/Other/DoughGood", true, null, "Other/IconDough", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.Pastry, "Pastry", "WorldObjects/Other/Pastry", "Models/Other/Pastry", true, null, "Other/IconPastry", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.CakeBatter, "CakeBatter", "WorldObjects/Other/CakeBatter", "Models/Other/CakeBatter", true, null, "Other/IconCakeBatter", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.NaanRaw, "NaanRaw", "WorldObjects/Holdable", "Models/Other/NaanRaw", true, null, "Other/IconNaan", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.Naan, "Naan", "WorldObjects/Holdable", "Models/Food/Naan", true, null, "Other/IconNaan", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.FlowerSeeds01, "FlowerSeeds01", "WorldObjects/Other/FlowerSeeds01", "Models/Other/FlowerSeeds01", true, null, "Other/IconFlowerSeeds", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerSeeds02, "FlowerSeeds02", "WorldObjects/Other/FlowerSeeds02", "Models/Other/FlowerSeeds02", true, null, "Other/IconFlowerSeeds", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerSeeds03, "FlowerSeeds03", "WorldObjects/Other/FlowerSeeds03", "Models/Other/FlowerSeeds03", true, null, "Other/IconFlowerSeeds", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerSeeds04, "FlowerSeeds04", "WorldObjects/Other/FlowerSeeds04", "Models/Other/FlowerSeeds04", true, null, "Other/IconFlowerSeeds", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerSeeds05, "FlowerSeeds05", "WorldObjects/Other/FlowerSeeds05", "Models/Other/FlowerSeeds05", true, null, "Other/IconFlowerSeeds", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerSeeds06, "FlowerSeeds06", "WorldObjects/Other/FlowerSeeds06", "Models/Other/FlowerSeeds06", true, null, "Other/IconFlowerSeeds", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerSeeds07, "FlowerSeeds07", "WorldObjects/Other/FlowerSeeds07", "Models/Other/FlowerSeeds07", true, null, "Other/IconFlowerSeeds", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerBunch01, "FlowerBunch01", "WorldObjects/Other/FlowerBunch01", "Models/Other/FlowerBunch01", true, null, "Other/IconFlowerBunch", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerBunch02, "FlowerBunch02", "WorldObjects/Other/FlowerBunch02", "Models/Other/FlowerBunch02", true, null, "Other/IconFlowerBunch", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerBunch03, "FlowerBunch03", "WorldObjects/Other/FlowerBunch03", "Models/Other/FlowerBunch03", true, null, "Other/IconFlowerBunch", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerBunch04, "FlowerBunch04", "WorldObjects/Other/FlowerBunch04", "Models/Other/FlowerBunch04", true, null, "Other/IconFlowerBunch", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerBunch05, "FlowerBunch05", "WorldObjects/Other/FlowerBunch05", "Models/Other/FlowerBunch05", true, null, "Other/IconFlowerBunch", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerBunch06, "FlowerBunch06", "WorldObjects/Other/FlowerBunch06", "Models/Other/FlowerBunch06", true, null, "Other/IconFlowerBunch", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.FlowerBunch07, "FlowerBunch07", "WorldObjects/Other/FlowerBunch07", "Models/Other/FlowerBunch07", true, null, "Other/IconFlowerBunch", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.Sign, "Sign", "WorldObjects/Other/Sign", "Models/Other/Sign", true, null, "Other/IconSign", false, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Sign2, "Sign2", "WorldObjects/Other/Sign2", "Models/Other/Sign2", true, null, "Other/IconSign2", false, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Billboard, "Billboard", "WorldObjects/Other/Billboard", "Models/Other/Billboard", true, null, "Other/IconBillboard", false, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Sign3, "Sign3", "WorldObjects/Other/Sign3", "Models/Other/Sign3", true, null, "Other/IconSign2", false, ObjectSubCategory.Misc);
		SetInfo(ObjectType.StringBall, "StringBall", "WorldObjects/Other/StringBall", "Models/Other/StringBall", true, null, "Other/IconStringBall", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FlourCrude, "FlourCrude", "WorldObjects/Other/FlourCrude", "Models/Other/FlourCrude", true, null, "Other/IconFlourCrude", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.Flour, "Flour", "WorldObjects/Other/Flour", "Models/Other/Flour", true, null, "Other/IconFlour", true, ObjectSubCategory.FoodOther);
		SetInfo(ObjectType.FolkSeed, "FolkSeed", "WorldObjects/Other/FolkSeed", "Models/Other/FolkSeed", true, null, "Other/IconFolkSeed", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FolkHeart, "FolkHeart", "WorldObjects/Special/FolkHeart", "Models/Special/FolkHeart", true, null, "Special/IconFolkHeart", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FolkHeart2, "FolkHeart2", "WorldObjects/Special/FolkHeart2", "Models/Special/FolkHeart2", true, null, "Special/IconFolkHeart2", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FolkHeart3, "FolkHeart3", "WorldObjects/Special/FolkHeart3", "Models/Special/FolkHeart3", true, null, "Special/IconFolkHeart3", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FolkHeart4, "FolkHeart4", "WorldObjects/Special/FolkHeart4", "Models/Special/FolkHeart4", true, null, "Special/IconFolkHeart4", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FolkHeart5, "FolkHeart5", "WorldObjects/Special/FolkHeart5", "Models/Special/FolkHeart5", true, null, "Special/IconFolkHeart5", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FolkHeart6, "FolkHeart6", "WorldObjects/Special/FolkHeart6", "Models/Special/FolkHeart6", true, null, "Special/IconFolkHeart6", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FolkHeart7, "FolkHeart7", "WorldObjects/Special/FolkHeart7", "Models/Special/FolkHeart7", true, null, "Special/IconFolkHeart7", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.BeesNest, "BeesNest", "WorldObjects/Other/BeesNest", "Models/Other/BeesNest", true, null, "Other/IconBeesNest", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.HayBale, "HayBale", "WorldObjects/Other/HayBale", "Models/Other/HayBale", true, null, "Other/IconHayBale", true, ObjectSubCategory.WildlifeAnimals);
		SetInfo(ObjectType.Scarecrow, "Scarecrow", "WorldObjects/Other/Scarecrow", "Models/Other/Scarecrow", true, null, "Other/IconScarecrow", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.CottonSeeds, "CottonSeeds", "WorldObjects/Holdable", "Models/Other/CottonSeeds", true, null, "Other/IconHayBale", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.CottonBall, "CottonBall", "WorldObjects/Holdable", "Models/Other/CottonBall", true, null, "Other/IconHayBale", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.BullrushesSeeds, "BullrushesSeeds", "WorldObjects/Holdable", "Models/Other/BullrushesSeeds", true, null, "Other/IconHayBale", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.BullrushesStems, "BullrushesStems", "WorldObjects/Holdable", "Models/Other/BullrushesStems", true, null, "Other/IconHayBale", true, ObjectSubCategory.WildlifeCrops);
		SetInfo(ObjectType.CertificateReward, "CertificateReward", "WorldObjects/Special/CertificateReward", "Models/Special/CertificateReward", true, null, "Special/IconDataStorageCrude", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.DataStorageCrude, "DataStorageCrude", "WorldObjects/Special/DataStorageCrude", "Models/Special/Data_Storage_Crude", true, null, "Special/IconDataStorageCrude", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.StringLine, "StringLine", "WorldObjects/Special/StringLine", "", true, null, "", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.AreaIndicatorAnchor, "AreaIndicatorAnchor", "WorldObjects/Special/AreaIndicatorAnchor", "Models/Special/AreaIndicatorAnchor", true, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.MechanicalBelt, "MechanicalBelt", "WorldObjects/Special/MechanicalBelt", "", true, null, "", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.MechanicalRod, "MechanicalRod", "WorldObjects/Special/MechanicalRod", "Models/Special/MechanicalRod", true, null, "", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.SoilHolePile, "SoilHolePile", "WorldObjects/Special/SoilHolePile", "Models/Special/SoilHolePile", true, null, "", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.TurfPile, "TurfPile", "WorldObjects/Special/TurfPile", "Models/Other/Turf", true, null, "", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.Arc, "Arc", "WorldObjects/Special/Arc", "", true, null, "", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.UpgradePlayerInventoryCrude, "UpgradePlayerInventoryCrude", "WorldObjects/Upgrades/UpgradePlayerInventoryCrude", "Models/Upgrades/UpgradePlayerInventoryCrude", true, null, "Upgrades/IconUpgradePlayerInventoryCrude", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.UpgradePlayerInventoryGood, "UpgradePlayerInventoryGood", "WorldObjects/Upgrades/UpgradePlayerInventoryGood", "Models/Upgrades/UpgradePlayerInventoryGood", true, null, "Upgrades/IconUpgradePlayerInventoryGood", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.UpgradePlayerInventorySuper, "UpgradePlayerInventorySuper", "WorldObjects/Upgrades/UpgradePlayerInventorySuper", "Models/Upgrades/UpgradePlayerInventorySuper", true, null, "Upgrades/IconUpgradePlayerInventorySuper", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.UpgradePlayerMovementCrude, "UpgradePlayerMovementCrude", "WorldObjects/Upgrades/UpgradePlayerMovement", "Models/Upgrades/UpgradePlayerMovementCrude", true, null, "Upgrades/IconUpgradePlayerMovementCrude", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.UpgradePlayerMovementGood, "UpgradePlayerMovementGood", "WorldObjects/Upgrades/UpgradePlayerMovement", "Models/Upgrades/UpgradePlayerMovementGood", true, null, "Upgrades/IconUpgradePlayerMovementGood", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.UpgradePlayerMovementSuper, "UpgradePlayerMovementSuper", "WorldObjects/Upgrades/UpgradePlayerMovement", "Models/Upgrades/UpgradePlayerMovementSuper", true, null, "Upgrades/IconUpgradePlayerMovementSuper", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.UpgradeWorkerInventoryCrude, "UpgradeWorkerInventoryCrude", "WorldObjects/Upgrades/UpgradeWorkerInventoryCrude", "Models/Upgrades/UpgradeWorkerInventoryCrude", true, null, "Upgrades/IconUpgradeWorkerInventoryCrude", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerInventoryGood, "UpgradeWorkerInventoryGood", "WorldObjects/Upgrades/UpgradeWorkerInventoryGood", "Models/Upgrades/UpgradeWorkerInventoryGood", true, null, "Upgrades/IconUpgradeWorkerInventoryGood", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerInventorySuper, "UpgradeWorkerInventorySuper", "WorldObjects/Upgrades/UpgradeWorkerInventorySuper", "Models/Upgrades/UpgradeWorkerInventorySuper", true, null, "Upgrades/IconUpgradeWorkerInventorySuper", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerMemoryCrude, "UpgradeWorkerMemoryCrude", "WorldObjects/Upgrades/UpgradeWorkerMemoryCrude", "Models/Upgrades/UpgradeWorkerMemoryCrude", true, null, "Upgrades/IconUpgradeWorkerMemoryCrude", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerMemoryGood, "UpgradeWorkerMemoryGood", "WorldObjects/Upgrades/UpgradeWorkerMemoryGood", "Models/Upgrades/UpgradeWorkerMemoryGood", true, null, "Upgrades/IconUpgradeWorkerMemoryGood", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerMemorySuper, "UpgradeWorkerMemorySuper", "WorldObjects/Upgrades/UpgradeWorkerMemorySuper", "Models/Upgrades/UpgradeWorkerMemorySuper", true, null, "Upgrades/IconUpgradeWorkerMemorySuper", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerSearchCrude, "UpgradeWorkerSearchCrude", "WorldObjects/Upgrades/UpgradeWorkerSearchCrude", "Models/Upgrades/UpgradeWorkerSearchCrude", true, null, "Upgrades/IconUpgradeWorkerSearchCrude", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerSearchGood, "UpgradeWorkerSearchGood", "WorldObjects/Upgrades/UpgradeWorkerSearchGood", "Models/Upgrades/UpgradeWorkerSearchGood", true, null, "Upgrades/IconUpgradeWorkerSearchGood", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerSearchSuper, "UpgradeWorkerSearchSuper", "WorldObjects/Upgrades/UpgradeWorkerSearchSuper", "Models/Upgrades/UpgradeWorkerSearchSuper", true, null, "Upgrades/IconUpgradeWorkerSearchSuper", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerCarryCrude, "UpgradeWorkerCarryCrude", "WorldObjects/Upgrades/UpgradeWorkerCarryCrude", "Models/Upgrades/UpgradeWorkerCarryCrude", true, null, "Upgrades/IconUpgradeWorkerCarryCrude", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerCarryGood, "UpgradeWorkerCarryGood", "WorldObjects/Upgrades/UpgradeWorkerCarryGood", "Models/Upgrades/UpgradeWorkerCarryGood", true, null, "Upgrades/IconUpgradeWorkerCarryGood", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerCarrySuper, "UpgradeWorkerCarrySuper", "WorldObjects/Upgrades/UpgradeWorkerCarrySuper", "Models/Upgrades/UpgradeWorkerCarrySuper", true, null, "Upgrades/IconUpgradeWorkerCarrySuper", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerMovementCrude, "UpgradeWorkerMovementCrude", "WorldObjects/Upgrades/UpgradeWorkerMovementCrude", "Models/Upgrades/UpgradeWorkerMovementCrude", true, null, "Upgrades/IconUpgradeWorkerMovementCrude", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerMovementGood, "UpgradeWorkerMovementGood", "WorldObjects/Upgrades/UpgradeWorkerMovementGood", "Models/Upgrades/UpgradeWorkerMovementGood", true, null, "Upgrades/IconUpgradeWorkerMovementGood", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerMovementSuper, "UpgradeWorkerMovementSuper", "WorldObjects/Upgrades/UpgradeWorkerMovementSuper", "Models/Upgrades/UpgradeWorkerMovementSuper", true, null, "Upgrades/IconUpgradeWorkerMovementSuper", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerEnergyCrude, "UpgradeWorkerEnergyCrude", "WorldObjects/Upgrades/UpgradeWorkerEnergyCrude", "Models/Upgrades/UpgradeWorkerEnergyCrude", true, null, "Upgrades/IconUpgradeWorkerEnergyCrude", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerEnergyGood, "UpgradeWorkerEnergyGood", "WorldObjects/Upgrades/UpgradeWorkerEnergyGood", "Models/Upgrades/UpgradeWorkerEnergyGood", true, null, "Upgrades/IconUpgradeWorkerEnergyGood", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.UpgradeWorkerEnergySuper, "UpgradeWorkerEnergySuper", "WorldObjects/Upgrades/UpgradeWorkerEnergySuper", "Models/Upgrades/UpgradeWorkerEnergySuper", true, null, "Upgrades/IconUpgradeWorkerEnergySuper", true, ObjectSubCategory.BotsUpgrades);
		SetInfo(ObjectType.HatChullo, "HatChullo", "WorldObjects/Clothes/Hats/HatChullo", "Models/Clothes/Hats/HatChullo", true, null, "Clothes/Hats/IconHatChullo", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatFarmerCap, "HatFarmerCap", "WorldObjects/Clothes/Hats/HatFarmerCap", "Models/Clothes/Hats/HatFarmerCap", true, null, "Clothes/Hats/IconHatFarmerCap", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatCap, "HatCap", "WorldObjects/Clothes/Hats/HatCap", "Models/Clothes/Hats/HatCap", true, null, "Clothes/Hats/IconHatCap", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatFarmer, "HatFarmer", "WorldObjects/Clothes/Hats/HatFarmer", "Models/Clothes/Hats/HatFarmer", true, null, "Clothes/Hats/IconHatFarmer", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatWig01, "HatWig01", "WorldObjects/Clothes/Hats/HatWig01", "Models/Clothes/Hats/HatWig01", true, null, "Clothes/Hats/IconHatWig01", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatBeret, "HatBeret", "WorldObjects/Clothes/Hats/HatBeret", "Models/Clothes/Hats/HatBeret", true, null, "Clothes/Hats/IconHatBeret", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatSugegasa, "HatSugegasa", "WorldObjects/Clothes/Hats/HatSugegasa", "Models/Clothes/Hats/HatSugegasa", true, null, "Clothes/Hats/IconHatSugegasa", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatKnittedBeanie, "HatKnittedBeanie", "WorldObjects/Clothes/Hats/HatKnittedBeanie", "Models/Clothes/Hats/HatKnittedBeanie", true, null, "Clothes/Hats/IconHatKnittedBeanie", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatFez, "HatFez", "WorldObjects/Clothes/Hats/HatFez", "Models/Clothes/Hats/HatFez", true, null, "Clothes/Hats/IconHatFez", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatChef, "HatChef", "WorldObjects/Clothes/Hats/HatChef", "Models/Clothes/Hats/HatChef", true, null, "Clothes/Hats/IconHatChef", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatAdventurer, "HatAdventurer", "WorldObjects/Clothes/Hats/HatAdventurer", "Models/Clothes/Hats/HatAdventurer", true, null, "Clothes/Hats/IconHatAdventurer", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatMushroom, "HatMushroom", "WorldObjects/Clothes/Hats/HatMushroom", "Models/Clothes/Hats/HatMushroom", true, null, "Clothes/Hats/IconHatMushroom", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatLumberjack, "HatLumberjack", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatLumberjack", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatBaseballShow, "HatBaseballShow", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatBaseballShow", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatCrown, "HatCrown", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatCrown", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatMortarboard, "HatMortarboard", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatMortarboard", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatSouwester, "HatSouwester", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatSouwester", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatTree, "HatTree", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatTree", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatMadHatter, "HatMadHatter", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatMadHatter", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatCloche, "HatCloche", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatCloche", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatAcorn, "HatAcorn", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatAcorn", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatSanta, "HatSanta", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatSanta", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatWally, "HatWally", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatWally", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatParty, "HatParty", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatParty", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatViking, "HatViking", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatViking", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatBox, "HatBox", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatBox", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatTrain, "HatTrain", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatTrain", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatSailor, "HatSailor", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatSailor", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatMiner, "HatMiner", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatMiner", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatFox, "HatFox", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatFox", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatDinosaur, "HatDinosaur", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatDinosaur", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatAntlers, "HatAntlers", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatAntlers", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatBunny, "HatBunny", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatBunny", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.HatDuck, "HatDuck", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatDuck", true, null, "Clothes/Hats/IconHatGuyFawkes", true, ObjectSubCategory.ClothingHeadwear);
		SetInfo(ObjectType.TopPoncho, "TopPoncho", "WorldObjects/Clothes/Tops/TopPoncho", "Models/Clothes/Tops/TopPoncho", true, null, "Clothes/Tops/IconTopPoncho", true, ObjectSubCategory.ClothingWool);
		SetInfo(ObjectType.TopJumper, "TopJumper", "WorldObjects/Clothes/Tops/TopJumper", "Models/Clothes/Tops/TopJumper", true, null, "Clothes/Tops/IconTopJumper", true, ObjectSubCategory.ClothingWool);
		SetInfo(ObjectType.TopJacket, "TopJacket", "WorldObjects/Clothes/Tops/TopJacket", "Models/Clothes/Tops/TopJacket", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.ClothingWool);
		SetInfo(ObjectType.TopBlazer, "TopBlazer", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopBlazerCravat", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.ClothingWool);
		SetInfo(ObjectType.TopTuxedo, "TopTuxedo", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopTuxedo", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.ClothingWool);
		SetInfo(ObjectType.TopTunic, "TopTunic", "WorldObjects/Clothes/Tops/TopTunic", "Models/Clothes/Tops/TopTunic", true, null, "Clothes/Tops/IconTopTunic", true, ObjectSubCategory.ClothingCotton);
		SetInfo(ObjectType.TopDress, "TopDress", "WorldObjects/Clothes/Tops/TopDress", "Models/Clothes/Tops/TopDress", true, null, "Clothes/Tops/IconTopDress", true, ObjectSubCategory.ClothingCotton);
		SetInfo(ObjectType.TopShirt, "TopShirt", "WorldObjects/Clothes/Tops/TopShirt", "Models/Clothes/Tops/TopShirt", true, null, "Clothes/Tops/IconTopShirt", true, ObjectSubCategory.ClothingCotton);
		SetInfo(ObjectType.TopShirtTie, "TopShirtTie", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopShirtTie", true, null, "Clothes/Tops/IconTopShirt", true, ObjectSubCategory.ClothingCotton);
		SetInfo(ObjectType.TopGown, "TopGown", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopGown", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.ClothingCotton);
		SetInfo(ObjectType.TopToga, "TopToga", "WorldObjects/Clothes/Tops/TopToga", "Models/Clothes/Tops/TopToga", true, null, "Clothes/Tops/IconTopToga", true, ObjectSubCategory.ClothingRushes);
		SetInfo(ObjectType.TopRobe, "TopRobe", "WorldObjects/Clothes/Tops/TopRobe", "Models/Clothes/Tops/TopRobe", true, null, "Clothes/Tops/IconTopRobe", true, ObjectSubCategory.ClothingRushes);
		SetInfo(ObjectType.TopCoat, "TopCoat", "WorldObjects/Clothes/Tops/TopCoat", "Models/Clothes/Tops/TopCoat", true, null, "Clothes/Tops/IconTopCoat", true, ObjectSubCategory.ClothingRushes);
		SetInfo(ObjectType.TopCoatScarf, "TopCoatScarf", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopCoatScarf", true, null, "Clothes/Tops/IconTopCoat", true, ObjectSubCategory.ClothingRushes);
		SetInfo(ObjectType.TopSuit, "TopSuit", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopSuit", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.ClothingRushes);
		SetInfo(ObjectType.TopDungarees, "TopDungarees", "WorldObjects/Clothes/Tops/TopDungarees", "Models/Clothes/Tops/TopDungarees", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopLumberjack, "TopLumberjack", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopLumberjack", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopTShirtShow, "TopTShirtShow", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopTShirtShow", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopAdventurer, "TopAdventurer", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopAdventurer", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopMac, "TopMac", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopMac", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopPlumber, "TopPlumber", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopPlumber", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopTree, "TopTree", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopTree", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopDungareesClown, "TopDungareesClown", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopDungareesClown", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopJumper02, "TopJumper02", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopJumper2", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopApron, "TopApron", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopApron", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopSanta, "TopSanta", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopSanta", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopWally, "TopWally", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopWally", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopTShirt02, "TopTShirt02", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopTShirt02", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopFox, "TopFox", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopFox", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopDinosaur, "TopDinosaur", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopDinosaur", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopBunny, "TopBunny", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopBunny", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.TopDuck, "TopDuck", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopDuck", true, null, "Clothes/Tops/IconTopDungarees", true, ObjectSubCategory.ClothingOther);
		SetInfo(ObjectType.Doll, "Doll", "WorldObjects/Toys/Doll", "Models/Toys/Doll", true, null, "Instruments/IconDoll", true, ObjectSubCategory.LeisureDoll);
		SetInfo(ObjectType.JackInTheBox, "JackInTheBox", "WorldObjects/Toys/JackInTheBox", "Models/Toys/JackInTheBox", true, null, "Instruments/IconJackInTheBox", true, ObjectSubCategory.LeisureDoll);
		SetInfo(ObjectType.DollHouse, "DollHouse", "WorldObjects/Toys/Toy", "Models/Toys/ToyDollHouse", true, null, "Instruments/IconDoll", true, ObjectSubCategory.LeisureDoll);
		SetInfo(ObjectType.Spaceship, "Spaceship", "WorldObjects/Toys/Toy", "Models/Toys/ToySpaceship", true, null, "Instruments/IconDoll", true, ObjectSubCategory.LeisureDoll);
		SetInfo(ObjectType.ToyHorse, "ToyHorse", "WorldObjects/Toys/ToyHorse", "Models/Toys/ToyHorse", true, null, "Instruments/IconToyHorse", true, ObjectSubCategory.LeisureHorse);
		SetInfo(ObjectType.ToyHorseCart, "ToyHorseCart", "WorldObjects/Toys/ToyHorseCart", "Models/Toys/ToyHorseCart", true, null, "Instruments/IconToyHorseCart", true, ObjectSubCategory.LeisureHorse);
		SetInfo(ObjectType.ToyHorseCarriage, "ToyHorseCarriage", "WorldObjects/Toys/Toy", "Models/Toys/ToyHorseStagecoach", true, null, "Instruments/IconToyHorseCart", true, ObjectSubCategory.LeisureHorse);
		SetInfo(ObjectType.ToyTrain, "ToyTrain", "WorldObjects/Toys/Toy", "Models/Toys/ToyTrain", true, null, "Instruments/IconToyHorseCart", true, ObjectSubCategory.LeisureHorse);
		SetInfo(ObjectType.MedicineLeeches, "MedicineLeeches", "WorldObjects/Medicine/Medicine", "Models/Medicine/MedicineLeeches", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Medicine);
		SetInfo(ObjectType.MedicineFlowers, "MedicineFlowers", "WorldObjects/Medicine/Medicine", "Models/Medicine/MedicineFlowers", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Medicine);
		SetInfo(ObjectType.MedicinePills, "MedicinePills", "WorldObjects/Medicine/Medicine", "Models/Medicine/MedicinePills", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Medicine);
		SetInfo(ObjectType.EducationBook1, "EducationBook1", "WorldObjects/Education/Education", "Models/Education/EducationBook1", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Education);
		SetInfo(ObjectType.EducationEncyclopedia, "EducationEncyclopedia", "WorldObjects/Education/Education", "Models/Education/EducationBook2", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Education);
		SetInfo(ObjectType.ArtPortrait, "ArtPortrait", "WorldObjects/Art/Art", "Models/Art/ArtPortrait", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Art);
		SetInfo(ObjectType.ArtStillLife, "ArtStillLife", "WorldObjects/Art/Art", "Models/Art/ArtStillLife", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Art);
		SetInfo(ObjectType.ArtAbstract, "ArtAbstract", "WorldObjects/Art/Art", "Models/Art/ArtAbstract", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Art);
		SetInfo(ObjectType.Canvas, "Canvas", "WorldObjects/Other/Canvas", "Models/Other/Canvas", true, null, "Other/IconHayBale", true, ObjectSubCategory.Art);
		SetInfo(ObjectType.PaintRed, "PaintRed", "WorldObjects/Holdable", "Models/Other/PaintRed", true, null, "Other/IconHayBale", true, ObjectSubCategory.Art);
		SetInfo(ObjectType.PaintYellow, "PaintYellow", "WorldObjects/Holdable", "Models/Other/PaintYellow", true, null, "Other/IconHayBale", true, ObjectSubCategory.Art);
		SetInfo(ObjectType.PaintBlue, "PaintBlue", "WorldObjects/Holdable", "Models/Other/PaintBlue", true, null, "Other/IconHayBale", true, ObjectSubCategory.Art);
		SetInfo(ObjectType.Paper, "Paper", "WorldObjects/Holdable", "Models/Other/Paper", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Ink, "Ink", "WorldObjects/Holdable", "Models/Other/Ink", true, null, "Instruments/IconMedicineHorse", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Dirt, "Dirt", "WorldObjects/Other/Dirt", "Models/Other/Dirt", true, null, "", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.WorkerFrameMk0, "WorkerFrameMk0", "WorldObjects/WorkerParts/WorkerFrameMk0", "Models/WorkerParts/WorkerFrameMk0", true, null, "WorkerParts/IconWorkerFrameMk0", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.WorkerHeadMk0, "WorkerHeadMk0", "WorldObjects/WorkerParts/WorkerHeadMk0", "Models/WorkerParts/WorkerHeadMk0", true, null, "WorkerParts/IconWorkerHeadMk0", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.WorkerDriveMk0, "WorkerDriveMk0", "WorldObjects/WorkerParts/WorkerDriveMk0", "Models/WorkerParts/WorkerDriveMk0", true, null, "WorkerParts/IconWorkerDriveMk0", true, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.WorkerFrameMk1, "WorkerFrameMk1", "WorldObjects/WorkerParts/WorkerFrameMk1", "Models/WorkerParts/WorkerFrameMk1", true, null, "WorkerParts/IconWorkerFrameMk1", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk1, "WorkerHeadMk1", "WorldObjects/WorkerParts/WorkerHeadMk1", "Models/WorkerParts/WorkerHeadMk1", true, null, "WorkerParts/IconWorkerHeadMk1", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk1, "WorkerDriveMk1", "WorldObjects/WorkerParts/WorkerDriveMk1", "Models/WorkerParts/WorkerDriveMk1", true, null, "WorkerParts/IconWorkerDriveMk1", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk1Variant1, "WorkerFrameMk1Variant1", "WorldObjects/WorkerParts/WorkerFrameMk1Variant1", "Models/WorkerParts/WorkerFrameMk1Variant1", true, null, "WorkerParts/IconWorkerFrameMk1Variant1", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk1Variant1, "WorkerHeadMk1Variant1", "WorldObjects/WorkerParts/WorkerHeadMk1Variant1", "Models/WorkerParts/WorkerHeadMk1Variant1", true, null, "WorkerParts/IconWorkerHeadMk1Variant1", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk1Variant1, "WorkerDriveMk1Variant1", "WorldObjects/WorkerParts/WorkerDriveMk1Variant1", "Models/WorkerParts/WorkerDriveMk1Variant1", true, null, "WorkerParts/IconWorkerDriveMk1Variant1", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk1Variant2, "WorkerFrameMk1Variant2", "WorldObjects/WorkerParts/WorkerFrameMk1Variant2", "Models/WorkerParts/WorkerFrameMk1Variant2", true, null, "WorkerParts/IconWorkerFrameMk1Variant2", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk1Variant2, "WorkerHeadMk1Variant2", "WorldObjects/WorkerParts/WorkerHeadMk1Variant2", "Models/WorkerParts/WorkerHeadMk1Variant2", true, null, "WorkerParts/IconWorkerHeadMk1Variant2", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk1Variant2, "WorkerDriveMk1Variant2", "WorldObjects/WorkerParts/WorkerDriveMk1Variant2", "Models/WorkerParts/WorkerDriveMk1Variant2", true, null, "WorkerParts/IconWorkerDriveMk1Variant2", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk1Variant3, "WorkerFrameMk1Variant3", "WorldObjects/WorkerParts/WorkerFrameMk1Variant3", "Models/WorkerParts/WorkerFrameMk1Variant3", true, null, "WorkerParts/IconWorkerFrameMk1Variant3", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk1Variant3, "WorkerHeadMk1Variant3", "WorldObjects/WorkerParts/WorkerHeadMk1Variant3", "Models/WorkerParts/WorkerHeadMk1Variant3", true, null, "WorkerParts/IconWorkerHeadMk1Variant3", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk1Variant3, "WorkerDriveMk1Variant3", "WorldObjects/WorkerParts/WorkerDriveMk1Variant3", "Models/WorkerParts/WorkerDriveMk1Variant3", true, null, "WorkerParts/IconWorkerDriveMk1Variant3", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk1Variant4, "WorkerFrameMk1Variant4", "WorldObjects/WorkerParts/WorkerFrameMk1Variant4", "Models/WorkerParts/WorkerFrameMk1Variant4", true, null, "WorkerParts/IconWorkerFrameMk1Variant4", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk1Variant4, "WorkerHeadMk1Variant4", "WorldObjects/WorkerParts/WorkerHeadMk1Variant4", "Models/WorkerParts/WorkerHeadMk1Variant4", true, null, "WorkerParts/IconWorkerHeadMk1Variant4", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk1Variant4, "WorkerDriveMk1Variant4", "WorldObjects/WorkerParts/WorkerDriveMk1Variant4", "Models/WorkerParts/WorkerDriveMk1Variant4", true, null, "WorkerParts/IconWorkerDriveMk1Variant4", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk2, "WorkerFrameMk2", "WorldObjects/WorkerParts/WorkerFrameMk2", "Models/WorkerParts/WorkerFrameMk2", true, null, "WorkerParts/IconWorkerFrameMk2", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk2, "WorkerHeadMk2", "WorldObjects/WorkerParts/WorkerHeadMk2", "Models/WorkerParts/WorkerHeadMk2", true, null, "WorkerParts/IconWorkerHeadMk2", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk2, "WorkerDriveMk2", "WorldObjects/WorkerParts/WorkerDriveMk2", "Models/WorkerParts/WorkerDriveMk2", true, null, "WorkerParts/IconWorkerDriveMk2", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk2Variant1, "WorkerFrameMk2Variant1", "WorldObjects/WorkerParts/WorkerFrameMk2Variant1", "Models/WorkerParts/WorkerFrameMk2Variant1", true, null, "WorkerParts/IconWorkerFrameMk2Variant1", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk2Variant1, "WorkerHeadMk2Variant1", "WorldObjects/WorkerParts/WorkerHeadMk2Variant1", "Models/WorkerParts/WorkerHeadMk2Variant1", true, null, "WorkerParts/IconWorkerHeadMk2Variant1", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk2Variant1, "WorkerDriveMk2Variant1", "WorldObjects/WorkerParts/WorkerDriveMk2Variant1", "Models/WorkerParts/WorkerDriveMk2Variant1", true, null, "WorkerParts/IconWorkerDriveMk2Variant1", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk2Variant2, "WorkerFrameMk2Variant2", "WorldObjects/WorkerParts/WorkerFrameMk2Variant2", "Models/WorkerParts/WorkerFrameMk2Variant2", true, null, "WorkerParts/IconWorkerFrameMk2Variant2", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk2Variant2, "WorkerHeadMk2Variant2", "WorldObjects/WorkerParts/WorkerHeadMk2Variant2", "Models/WorkerParts/WorkerHeadMk2Variant2", true, null, "WorkerParts/IconWorkerHeadMk2Variant2", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk2Variant2, "WorkerDriveMk2Variant2", "WorldObjects/WorkerParts/WorkerDriveMk2Variant2", "Models/WorkerParts/WorkerDriveMk2Variant2", true, null, "WorkerParts/IconWorkerDriveMk2Variant2", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk2Variant3, "WorkerFrameMk2Variant3", "WorldObjects/WorkerParts/WorkerFrameMk2Variant3", "Models/WorkerParts/WorkerFrameMk2Variant3", true, null, "WorkerParts/IconWorkerFrameMk2Variant3", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk2Variant3, "WorkerHeadMk2Variant3", "WorldObjects/WorkerParts/WorkerHeadMk2Variant3", "Models/WorkerParts/WorkerHeadMk2Variant3", true, null, "WorkerParts/IconWorkerHeadMk2Variant3", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk2Variant3, "WorkerDriveMk2Variant3", "WorldObjects/WorkerParts/WorkerDriveMk2Variant3", "Models/WorkerParts/WorkerDriveMk2Variant3", true, null, "WorkerParts/IconWorkerDriveMk2Variant3", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk2Variant4, "WorkerFrameMk2Variant4", "WorldObjects/WorkerParts/WorkerFrameMk2Variant4", "Models/WorkerParts/WorkerFrameMk2Variant4", true, null, "WorkerParts/IconWorkerFrameMk2Variant4", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk2Variant4, "WorkerHeadMk2Variant4", "WorldObjects/WorkerParts/WorkerHeadMk2Variant4", "Models/WorkerParts/WorkerHeadMk2Variant4", true, null, "WorkerParts/IconWorkerHeadMk2Variant4", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk2Variant4, "WorkerDriveMk2Variant4", "WorldObjects/WorkerParts/WorkerDriveMk2Variant4", "Models/WorkerParts/WorkerDriveMk2Variant4", true, null, "WorkerParts/IconWorkerDriveMk2Variant4", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk3, "WorkerFrameMk3", "WorldObjects/WorkerParts/WorkerFrameMk3", "Models/WorkerParts/WorkerFrameMk3", true, null, "WorkerParts/IconWorkerFrameMk3", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk3, "WorkerHeadMk3", "WorldObjects/WorkerParts/WorkerHeadMk3", "Models/WorkerParts/WorkerHeadMk3", true, null, "WorkerParts/IconWorkerHeadMk3", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk3, "WorkerDriveMk3", "WorldObjects/WorkerParts/WorkerDriveMk3", "Models/WorkerParts/WorkerDriveMk3", true, null, "WorkerParts/IconWorkerDriveMk3", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk3Variant1, "WorkerFrameMk3Variant1", "WorldObjects/WorkerParts/WorkerFrameMk3Variant1", "Models/WorkerParts/WorkerFrameMk3Variant1", true, null, "WorkerParts/IconWorkerFrameMk3Variant1", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk3Variant1, "WorkerHeadMk3Variant1", "WorldObjects/WorkerParts/WorkerHeadMk3Variant1", "Models/WorkerParts/WorkerHeadMk3Variant1", true, null, "WorkerParts/IconWorkerHeadMk3Variant1", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk3Variant1, "WorkerDriveMk3Variant1", "WorldObjects/WorkerParts/WorkerDriveMk3Variant1", "Models/WorkerParts/WorkerDriveMk3Variant1", true, null, "WorkerParts/IconWorkerDriveMk3Variant1", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk3Variant2, "WorkerFrameMk3Variant2", "WorldObjects/WorkerParts/WorkerFrameMk3Variant2", "Models/WorkerParts/WorkerFrameMk3Variant2", true, null, "WorkerParts/IconWorkerFrameMk3Variant2", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk3Variant2, "WorkerHeadMk3Variant2", "WorldObjects/WorkerParts/WorkerHeadMk3Variant2", "Models/WorkerParts/WorkerHeadMk3Variant2", true, null, "WorkerParts/IconWorkerHeadMk3Variant2", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk3Variant2, "WorkerDriveMk3Variant2", "WorldObjects/WorkerParts/WorkerDriveMk3Variant2", "Models/WorkerParts/WorkerDriveMk3Variant2", true, null, "WorkerParts/IconWorkerDriveMk3Variant2", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk3Variant3, "WorkerFrameMk3Variant3", "WorldObjects/WorkerParts/WorkerFrameMk3Variant3", "Models/WorkerParts/WorkerFrameMk3Variant3", true, null, "WorkerParts/IconWorkerFrameMk3Variant3", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk3Variant3, "WorkerHeadMk3Variant3", "WorldObjects/WorkerParts/WorkerHeadMk3Variant3", "Models/WorkerParts/WorkerHeadMk3Variant3", true, null, "WorkerParts/IconWorkerHeadMk3Variant3", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk3Variant3, "WorkerDriveMk3Variant3", "WorldObjects/WorkerParts/WorkerDriveMk3Variant3", "Models/WorkerParts/WorkerDriveMk3Variant3", true, null, "WorkerParts/IconWorkerDriveMk3Variant3", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.WorkerFrameMk3Variant4, "WorkerFrameMk3Variant4", "WorldObjects/WorkerParts/WorkerFrameMk3Variant4", "Models/WorkerParts/WorkerFrameMk3Variant4", true, null, "WorkerParts/IconWorkerFrameMk3Variant4", true, ObjectSubCategory.BotsBodies);
		SetInfo(ObjectType.WorkerHeadMk3Variant4, "WorkerHeadMk3Variant4", "WorldObjects/WorkerParts/WorkerHeadMk3Variant4", "Models/WorkerParts/WorkerHeadMk3Variant4", true, null, "WorkerParts/IconWorkerHeadMk3Variant4", true, ObjectSubCategory.BotsHeads);
		SetInfo(ObjectType.WorkerDriveMk3Variant4, "WorkerDriveMk3Variant4", "WorldObjects/WorkerParts/WorkerDriveMk3Variant4", "Models/WorkerParts/WorkerDriveMk3Variant4", true, null, "WorkerParts/IconWorkerDriveMk3Variant4", true, ObjectSubCategory.BotsDrives);
		SetInfo(ObjectType.SeaWater, "SeaWater", "WorldObjects/Special/SeaWater", "", true, null, "Other/IconSeaWater", false, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Sand, "Sand", "WorldObjects/Special/Sand", "Models/Special/Sand", true, null, "Other/IconSand", false, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Soil, "Soil", "WorldObjects/Special/Soil", "", true, null, "Other/IconSoil", false, ObjectSubCategory.Misc);
		SetInfo(ObjectType.Mortar, "Mortar", "WorldObjects/Special/Mortar", "Models/Special/Mortar", true, null, "Other/IconMortar", true, ObjectSubCategory.Misc);
		SetInfo(ObjectType.FishAny, "FishAny", "", "", false, null, "IconFishAny", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.HatAny, "HatAny", "", "", false, null, "Clothes/Hats/IconHat", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.TopAny, "TopAny", "", "", false, null, "Clothes/Tops/IconTop", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.WorkerFrameAny, "WorkerFrameAny", "", "", false, null, "WorkerParts/IconWorkerFrameAny", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.WorkerHeadAny, "WorkerHeadAny", "", "", false, null, "WorkerParts/IconWorkerHeadAny", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.WorkerDriveAny, "WorkerDriveAny", "", "", false, null, "WorkerParts/IconWorkerDriveAny", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.Fuel, "Fuel", "", "", false, null, "Other/IconFuel", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.HouseAny, "HouseAny", "WorldObjects/Buildings/HousingAny", "", false, null, "IconHouseAny", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.JunkAny, "JunkAny", "", "", false, null, "IconJunkAny", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.HeartAny, "HeartAny", "", "", false, null, "IconHeartAny", false, ObjectSubCategory.Any);
		SetInfo(ObjectType.TileSelectEffect, "TileSelectEffect", "WorldObjects/Effects/TileSelectEffect", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.DigShadow, "DigShadow", "WorldObjects/Effects/DigShadow", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.BlockSoil, "BlockSoil", "WorldObjects/Effects/BlockSoil", "Models/Effects/BlockSoil", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.MusicalNote, "MusicalNote", "WorldObjects/Effects/MusicalNote", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.LoveHeart, "LoveHeart", "WorldObjects/Effects/LoveHeart", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.XPPlus1, "XPPlus1", "WorldObjects/Effects/XPPlus1", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.NewIcon, "NewIcon", "WorldObjects/Effects/NewIcon", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.WallFloorIcon, "WallFloorIcon", "WorldObjects/Effects/WallFloorIcon", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.Emoticon, "Emoticon", "WorldObjects/Effects/Emoticon", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.WorkerLookAt, "WorkerLookAt", "WorldObjects/Effects/WorkerLookAt", "Models/Effects/WorkerLookAt", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.PlotUncover, "PlotUncover", "WorldObjects/Effects/PlotUncover", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.SandPile, "SandPile", "WorldObjects/Effects/SandPile", "Models/Effects/SandPile", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.StopActive, "StopActive", "WorldObjects/Effects/StopActive", "", false, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.FishingJunkFresh, "FishingJunkFresh", "WorldObjects/Effects/FishingJunk", "Models/Effects/FishingJunkFresh", false, null, "Fish/IconFishingJunk", true, ObjectSubCategory.Effects);
		SetInfo(ObjectType.FishingJunkSalt, "FishingJunkSalt", "WorldObjects/Effects/FishingJunk", "Models/Effects/FishingJunkSalt", false, null, "Fish/IconFishingJunk", true, ObjectSubCategory.Effects);
		SetInfo(ObjectType.TranscendEffect, "TranscendEffect", "WorldObjects/Effects/TranscendEffect", "", true, null, "", false, ObjectSubCategory.Effects);
		SetInfo(ObjectType.Rocket, "Rocket", "WorldObjects/Animations/Rocket", "Models/Animations/Rocket/Rocket", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.RocketAnimation, "RocketAnimation", "WorldObjects/Animations/RocketAnimation", "", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.SpacePortRocket, "SpacePortRocket", "WorldObjects/Animations/SpacePortRocket", "Models/Animations/Rocket/Rocket", false, null, "", false, ObjectSubCategory.Hidden);
		SetInfo(ObjectType.UpgradePlayerWhistleCrude, "UpgradePlayerWhistleCrude", "WorldObjects/Upgrades/UpgradePlayerWhistleCrude", "Models/Upgrades/UpgradePlayerWhistleCrude", true, null, "Upgrades/IconUpgradePlayerWhistleCrude", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.UpgradePlayerWhistleGood, "UpgradePlayerWhistleGood", "WorldObjects/Upgrades/UpgradePlayerWhistleGood", "Models/Upgrades/UpgradePlayerWhistleGood", true, null, "Upgrades/IconUpgradePlayerWhistleGood", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.UpgradePlayerWhistleSuper, "UpgradePlayerWhistleSuper", "WorldObjects/Upgrades/UpgradePlayerWhistleSuper", "Models/Upgrades/UpgradePlayerWhistleSuper", true, null, "Upgrades/IconUpgradePlayerWhistleSuper", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.Castanets, "Castanets", "WorldObjects/Instruments/Instrument", "Models/Instruments/InstrumentCastanets", true, null, "", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.Guiro, "Guiro", "WorldObjects/Instruments/Instrument", "Models/Instruments/InstrumentGuiro", true, null, "", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.Maracas, "Maracas", "WorldObjects/Instruments/Instrument", "Models/Instruments/InstrumentMaraca", true, null, "", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.Guitar, "Guitar", "WorldObjects/Instruments/Instrument", "Models/Instruments/InstrumentGuitar", true, null, "", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.Triangle, "Triangle", "WorldObjects/Instruments/Instrument", "Models/Instruments/InstrumentTriangle", true, null, "", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.Cowbell, "Cowbell", "WorldObjects/Instruments/Instrument", "Models/Instruments/InstrumentCowbell", true, null, "", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.JawHarp, "JawHarp", "WorldObjects/Instruments/Instrument", "Models/Instruments/InstrumentJawHarp", true, null, "", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.AnimalPetDog, "AnimalPetDog", "WorldObjects/Animals/AnimalPetDog", "Models/Animals/AnimalDog", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.AnimalPetDog2, "AnimalPetDog2", "WorldObjects/Animals/AnimalPetDog", "Models/Animals/AnimalDog2", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatFrog, "HatFrog", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatFrog", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.TopFrog, "TopFrog", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopFrog", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatPanda, "HatPanda", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatPanda", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.TopPanda, "TopPanda", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopPanda", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatPenguin, "HatPenguin", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatPenguin", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.TopPenguin, "TopPenguin", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopPenguin", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatBearskin, "HatBearskin", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatBearskin", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatCaptain, "HatCaptain", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatCaptain", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatCowboy, "HatCowboy", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatCowboy", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatBoater, "HatBoater", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatBoater", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatCatintheHat, "HatCatintheHat", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatCatintheHat", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatDrumMajor, "HatDrumMajor", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatDrumMajor", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatGat, "HatGat", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatGat", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatFedora, "HatFedora", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatFedora", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatSombrero, "HatSombrero", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatSombrero", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatSmurf, "HatSmurf", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatSmurf", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatTrafficCone, "HatTrafficCone", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatTrafficCone", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.HatWig02, "HatWig02", "WorldObjects/Clothes/Hats/Hat", "Models/Clothes/Hats/HatWig02", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.TopRoyalGuard, "TopRoyalGuard", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopRoyalGuard", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.TopSuit02, "TopSuit02", "WorldObjects/Clothes/Tops/Top", "Models/Clothes/Tops/TopSuit02", true, null, "Clothes/Tops/IconTopJacket", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.TrojanRabbit, "TrojanRabbit", "WorldObjects/Vehicles/TrojanRabbit", "Models/Vehicles/TrojanRabbit", false, null, "Vehicles/IconCart", false, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.WorkerFrameROB, "WorkerFrameROB", "WorldObjects/WorkerParts/WorkerFrameROB", "Models/WorkerParts/WorkerFrameROB", true, null, "WorkerParts/IconWorkerFrameROB", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.WorkerHeadROB, "WorkerHeadROB", "WorldObjects/WorkerParts/WorkerHeadROB", "Models/WorkerParts/WorkerHeadROB", true, null, "WorkerParts/IconWorkerHeadROB", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.WorkerDriveROB, "WorkerDriveROB", "WorldObjects/WorkerParts/WorkerDriveROB", "Models/WorkerParts/WorkerDriveROB", true, null, "WorkerParts/IconWorkerDriveROB", true, ObjectSubCategory.Prizes);
		SetInfo(ObjectType.FlooringChequer, "FlooringChequer", "WorldObjects/Buildings/Floors/FlooringChequer", "Models/Buildings/Floors/FlooringChequerWhole", true, null, "Buildings/Floors/IconFlooringCrude", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.BrickArchway, "BrickArchway", "WorldObjects/Buildings/Decoration", "Models/Buildings/Decoration/BrickArchway", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.BrickArchwayDoor, "BrickArchwayDoor", "WorldObjects/Buildings/Door", "Models/Buildings/Decoration/BrickArchDoor", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.HedgeArchway, "HedgeArchway", "WorldObjects/Buildings/Decoration", "Models/Buildings/Decoration/HedgeArchway", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.Sandcastle, "Sandcastle", "WorldObjects/Buildings/Decoration", "Models/Buildings/Decoration/Sandcastle", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.CastleWall, "CastleWall", "WorldObjects/Buildings/Decoration", "Models/Buildings/Decoration/CastleWall", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.CastlePlainTower, "CastlePlainTower", "WorldObjects/Buildings/Decoration", "Models/Buildings/Decoration/CastlePlainTower", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.CastleFancyTower, "CastleFancyTower", "WorldObjects/Buildings/Decoration", "Models/Buildings/Decoration/CastleFancyTower", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.CastleGate, "CastleGate", "WorldObjects/Buildings/Decoration", "Models/Buildings/Decoration/CastleGate", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.CastleDrawbridge, "CastleDrawbridge", "WorldObjects/Buildings/Floors/CastleDrawbridge", "Models/Buildings/Decoration/CastleDrawbridge", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.StreetLamp, "StreetLamp", "WorldObjects/Buildings/BuildingLight", "Models/Buildings/StreetLamp", false, null, "Fish/IconFishSalmon", false, ObjectSubCategory.BuildingsPrizes);
		SetInfo(ObjectType.AquariumGood, "AquariumGood", "WorldObjects/Buildings/AquariumGood", "Models/Buildings/AquariumGood", false, null, "Buildings/Converters/IconChickenCoop", false, ObjectSubCategory.BuildingsPrizes);
		if ((bool)ModManager.Instance)
		{
			for (int i = 0; i < num; i++)
			{
				ObjectType objectType = (ObjectType)(673 + i);
				string UniqueName = "";
				string PrefabLocation = "";
				ObjectSubCategory SubCat = ObjectSubCategory.BuildingsWorkshop;
				bool CanStack = false;
				if (ModManager.Instance.GetCustomClassData(objectType, out UniqueName, out PrefabLocation, out SubCat, out CanStack))
				{
					SetInfo(objectType, UniqueName, PrefabLocation, UniqueName, false, null, UniqueName, CanStack, SubCat);
				}
			}
		}
		SetInfo(m_Total, "Total", "", "", false, null, "", false, ObjectSubCategory.Hidden);
		VerifyIcons();
		SetupSubCategories();
		SetupCategories();
	}

	private void SetupSubCategories()
	{
		int num = 49;
		m_ObjectsInSubCategories = new List<ObjectType>[num];
		for (int i = 0; i < num; i++)
		{
			m_ObjectsInSubCategories[i] = new List<ObjectType>();
		}
		for (int j = 0; j < (int)m_Total; j++)
		{
			ObjectType objectType = (ObjectType)j;
			ObjectSubCategory subCategoryFromType = GetSubCategoryFromType(objectType);
			m_ObjectsInSubCategories[(int)subCategoryFromType].Add(objectType);
		}
	}

	private void SetupCategories()
	{
		int num = 17;
		m_SubCategoriesInCategories = new List<ObjectSubCategory>[num];
		for (int i = 0; i < num; i++)
		{
			m_SubCategoriesInCategories[i] = new List<ObjectSubCategory>();
		}
		for (int j = 0; j < (int)m_Total; j++)
		{
			ObjectType newType = (ObjectType)j;
			ObjectSubCategory subCategoryFromType = GetSubCategoryFromType(newType);
			ObjectCategory categoryFromType = GetCategoryFromType(newType);
			m_SubCategoriesInCategories[(int)categoryFromType].Add(subCategoryFromType);
		}
	}

	public void Reset()
	{
		if (m_ObjectTypeOnGroundCounts == null)
		{
			m_ObjectTypeCounts = new int[(int)m_Total];
			m_ObjectTypeOnGroundCounts = new int[(int)m_Total];
			m_ObjectTypeExists = new byte[(int)m_Total];
		}
		for (int i = 0; i < (int)m_Total; i++)
		{
			m_ObjectTypeCounts[i] = 0;
			m_ObjectTypeOnGroundCounts[i] = 0;
			m_ObjectTypeExists[i] = 0;
		}
		m_UniqueIDCounter = 1;
		m_UniqueIDList = new Dictionary<int, BaseClass>();
		m_UniqueIDs = new Dictionary<BaseClass, int>();
		m_NothingObject = CreateObjectFromIdentifier(ObjectType.Nothing, default(Vector3), Quaternion.identity).GetComponent<Nothing>();
		m_HousingAnyObject = CreateObjectFromIdentifier(ObjectType.HouseAny, default(Vector3), Quaternion.identity).GetComponent<HousingAny>();
	}

	private void AddCategory(ObjectSubCategory NewSubCategory, ObjectCategory NewCategory)
	{
		SubCategoryInfo subCategoryInfo = new SubCategoryInfo(NewCategory);
		m_SubCategories[(int)NewSubCategory] = subCategoryInfo;
	}

	private void SetInfo(ObjectType Identifier, string SaveName, string PrefabName, string ModelName, bool Reusable, IngredientRequirement[] Ingredients, string IconName, bool Stackable, ObjectSubCategory SubCategory)
	{
		if (Ingredients == null)
		{
			Ingredients = new IngredientRequirement[1]
			{
				new IngredientRequirement(Identifier, 1)
			};
		}
		ObjectTypeInfo objectTypeInfo = new ObjectTypeInfo(Identifier, SaveName, PrefabName, ModelName, Reusable, null, IconName, Stackable, false, 0f, 0f, 0, SubCategory);
		m_Objects[(int)Identifier] = objectTypeInfo;
		m_SaveList.Add(SaveName, objectTypeInfo);
	}

	public void SetIngredients(ObjectType Identifier, IngredientRequirement[] Ingredients)
	{
		int count = m_Objects[(int)Identifier].m_Ingredients.Count;
		m_Objects[(int)Identifier].m_Ingredients.Add(new IngredientRequirement[Ingredients.Length]);
		Ingredients.CopyTo(m_Objects[(int)Identifier].m_Ingredients[count], 0);
	}

	private void VerifyIcons()
	{
	}

	public void RegisterClasses()
	{
		Reset();
		ObjectTypeInfo[] objects = m_Objects;
		foreach (ObjectTypeInfo objectTypeInfo in objects)
		{
			string prefabName = objectTypeInfo.m_PrefabName;
			if (prefabName != "")
			{
				BaseClass component = InstantiationManager.Instance.CreateObject(objectTypeInfo.m_Type, prefabName, objectTypeInfo.m_ModelName, default(Vector3), Quaternion.identity).GetComponent<BaseClass>();
				component.RegisterClass();
				component.transform.localScale = new Vector3(1f, 1f, 1f);
				if ((bool)component.GetComponent<Building>())
				{
					UnityEngine.Object.DestroyImmediate(component.GetComponent<Building>().m_AccessModel);
				}
				if ((bool)component.GetComponent<Converter>())
				{
					UnityEngine.Object.DestroyImmediate(component.GetComponent<Converter>().m_SpawnModel);
				}
				Bounds bounds = ObjectUtils.ObjectBoundsFromVertices(component.gameObject);
				float y = bounds.size.y;
				m_Objects[(int)objectTypeInfo.m_Type].m_Height = y;
				if (Hat.GetIsTypeHat(objectTypeInfo.m_Type))
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_Offset = 0f - bounds.min.y;
				}
				m_Objects[(int)objectTypeInfo.m_Type].m_Weight = VariableManager.Instance.GetVariableAsInt(objectTypeInfo.m_Type, "Weight", false);
				Layers layers = (Layers)component.gameObject.layer;
				if (layers == Layers.Misc && bounds.size.magnitude < 3f)
				{
					layers = Layers.MiscSmall;
				}
				m_Objects[(int)objectTypeInfo.m_Type].m_Layer = layers;
				m_Objects[(int)objectTypeInfo.m_Type].m_Building = component.GetComponent<Building>() != null;
				m_Objects[(int)objectTypeInfo.m_Type].m_Parent = GetObjectParent(objectTypeInfo.m_Type);
				m_Objects[(int)objectTypeInfo.m_Type].m_Tier = VariableManager.Instance.GetVariableAsInt(objectTypeInfo.m_Type, "Tier", false);
				m_Objects[(int)objectTypeInfo.m_Type].m_Holdable = component.GetComponent<Holdable>() != null;
				ObjectUseType useType = ObjectUseType.Total;
				if (Food.GetIsTypeFood(objectTypeInfo.m_Type))
				{
					useType = ObjectUseType.Food;
				}
				else if (Clothing.GetIsTypeClothing(objectTypeInfo.m_Type))
				{
					useType = ObjectUseType.Clothing;
				}
				if (Toy.GetIsTypeToy(objectTypeInfo.m_Type))
				{
					useType = ObjectUseType.Toy;
				}
				if (Medicine.GetIsTypeMedicine(objectTypeInfo.m_Type))
				{
					useType = ObjectUseType.Medicine;
				}
				if (Education.GetIsTypeEducation(objectTypeInfo.m_Type))
				{
					useType = ObjectUseType.Education;
				}
				if (Art.GetIsTypeArt(objectTypeInfo.m_Type))
				{
					useType = ObjectUseType.Art;
				}
				m_Objects[(int)objectTypeInfo.m_Type].m_UseType = useType;
				if (StorageTypeManager.m_StoragePaletteInformation.ContainsKey(objectTypeInfo.m_Type))
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StoragePalette;
				}
				else if (objectTypeInfo.m_Type == ObjectType.Worker)
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StorageWorker;
				}
				else if (objectTypeInfo.m_Type == ObjectType.Seedling || objectTypeInfo.m_Type == ObjectType.SeedlingMulberry)
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StorageSeedlings;
				}
				else if (objectTypeInfo.m_Type == ObjectType.FolkSeed)
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.FolkSeedPod;
				}
				else if (objectTypeInfo.m_Type == ObjectType.BeesNest)
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StorageBeehiveCrude;
				}
				else if (objectTypeInfo.m_Type == ObjectType.Manure)
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StorageFertiliser;
				}
				else if (StorageLiquid.IsObjectTypeAcceptibleStatic(objectTypeInfo.m_Type))
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StorageLiquid;
				}
				else if (StorageSand.IsObjectTypeAcceptibleStatic(objectTypeInfo.m_Type))
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StorageSand;
				}
				else if (StorageTypeManager.m_StorageGenericInformation.ContainsKey(objectTypeInfo.m_Type))
				{
					if (m_Objects[(int)objectTypeInfo.m_Type].m_Tier >= 5)
					{
						m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StorageGenericMedium;
					}
					else
					{
						m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = ObjectType.StorageGeneric;
					}
				}
				else
				{
					m_Objects[(int)objectTypeInfo.m_Type].m_StorageType = m_Total;
				}
				UnityEngine.Object.Destroy(component.gameObject);
			}
			ObjectSubCategory subCategoryFromType = GetSubCategoryFromType(objectTypeInfo.m_Type);
			if (GetIsBuilding(objectTypeInfo.m_Type) || subCategoryFromType == ObjectSubCategory.Hidden || subCategoryFromType == ObjectSubCategory.Prizes || subCategoryFromType == ObjectSubCategory.Effects || (subCategoryFromType == ObjectSubCategory.Any && objectTypeInfo.m_Type != ObjectType.HeartAny))
			{
				m_Objects[(int)objectTypeInfo.m_Type].m_MissionUsable = false;
			}
		}
		m_Objects[112].m_Height = GetHeight(ObjectType.Door);
	}

	public void SetupParents()
	{
		ObjectTypeInfo[] objects = m_Objects;
		foreach (ObjectTypeInfo objectTypeInfo in objects)
		{
			if (objectTypeInfo.m_PrefabName != "" || objectTypeInfo.m_Type == ObjectType.Plot)
			{
				m_Objects[(int)objectTypeInfo.m_Type].m_Parent = GetObjectParent(objectTypeInfo.m_Type);
			}
		}
	}

	private Transform GetObjectParent(ObjectType NewType)
	{
		Transform result = null;
		if ((bool)MapManager.Instance)
		{
			if (MyTree.GetIsTree(NewType) || NewType == ObjectType.TreeStump || NewType == ObjectType.SoilHolePile)
			{
				result = MapManager.Instance.m_TreesRootTransform;
			}
			else if (NewType == ObjectType.CropWheat || NewType == ObjectType.Grass || NewType == ObjectType.Weed || NewType == ObjectType.CropPumpkin || NewType == ObjectType.Bullrushes || NewType == ObjectType.CropCarrot)
			{
				result = MapManager.Instance.m_CropsRootTransform;
			}
			else if (Flora.GetIsTypeFlora(NewType) || Boulder.GetIsTypeBoulder(NewType) || NewType == ObjectType.Manure || NewType == ObjectType.Log || NewType == ObjectType.TreeSeed || NewType == ObjectType.IronOre || NewType == ObjectType.Clay || NewType == ObjectType.Coconut || NewType == ObjectType.MulberrySeed)
			{
				result = MapManager.Instance.m_MiscRootTransform;
			}
			else if (NewType == ObjectType.Plot)
			{
				result = MapManager.Instance.m_PlotRootTransform;
			}
			else if (Animal.GetIsTypeAnimal(NewType))
			{
				result = MapManager.Instance.m_AnimalsRootTransform;
			}
			else
			{
				switch (NewType)
				{
				case ObjectType.Rock:
				case ObjectType.Stick:
					result = MapManager.Instance.m_SticksRocksRootTransform;
					break;
				case ObjectType.Folk:
					result = MapManager.Instance.m_FolksRootTransform;
					break;
				default:
					result = ((!Effect2D.GetIsTypeEffect2D(NewType)) ? ((!GetIsBuilding(NewType)) ? MapManager.Instance.m_ObjectsRootTransform : MapManager.Instance.m_BuildingsRootTransform) : HudManager.Instance.m_EffectsRootTransform);
					break;
				}
			}
		}
		return result;
	}

	public void Save(JSONNode Node)
	{
		JSONArray jSONArray = (JSONArray)(Node["ObjectTypes"] = new JSONArray());
		for (int i = 0; i < (int)m_Total; i++)
		{
			jSONArray[i] = GetSaveNameFromIdentifier((ObjectType)i);
		}
	}

	public void Load(JSONNode Node)
	{
		JSONArray asArray = Node["ObjectTypes"].AsArray;
		m_LoadObjectTable = new List<ObjectType>();
		for (int i = 0; i < asArray.Count; i++)
		{
			string objectSaveName = OldFileUtils.GetObjectSaveName(asArray[i].Value);
			ObjectType identifierFromSaveName = Instance.GetIdentifierFromSaveName(objectSaveName, false);
			if (identifierFromSaveName != m_Total)
			{
				m_LoadObjectTable.Add(identifierFromSaveName);
			}
		}
	}

	private BaseClass CreateObjectFromInfo(ObjectTypeInfo Info, Vector3 Position, Quaternion Rotation, int UID)
	{
		BaseClass baseClass = null;
		baseClass = (Info.m_Reusable ? InstantiationManager.Instance.GetReusableObject(Info.m_Type, Position, Rotation) : InstantiationManager.Instance.CreateObject(Info.m_Type, Info.m_PrefabName, Info.m_ModelName, Position, Rotation).GetComponent<BaseClass>());
		if (UID != -1)
		{
			baseClass.m_UniqueID = UID;
		}
		baseClass.Restart();
		return baseClass;
	}

	public BaseClass CreateObjectFromIdentifier(ObjectType Identifier, Vector3 Position, Quaternion Rotation, int UID = -1)
	{
		return CreateObjectFromInfo(m_Objects[(int)Identifier], Position, Rotation, UID);
	}

	public BaseClass CreateObjectFromSaveName(JSONNode NewNode, Vector3 Position, Quaternion Rotation)
	{
		string asString = JSONUtils.GetAsString(NewNode, "ID", "");
		if (OldFileUtils.CheckCullObjects(asString))
		{
			return null;
		}
		int asInt = JSONUtils.GetAsInt(NewNode, "UID", -1);
		BaseClass result = null;
		asString = OldFileUtils.GetObjectSaveName(asString);
		ObjectTypeInfo value;
		if (m_SaveList.TryGetValue(asString, out value))
		{
			result = CreateObjectFromInfo(value, Position, Rotation, asInt);
		}
		else
		{
			Debug.Log("ObjectTypeList.CreateObjectFromSaveName : Ignoring Unknown object type " + asString);
		}
		return result;
	}

	public string GetSaveNameFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_SaveName;
	}

	public string GetHumanReadableNameFromIdentifier(ObjectType Identifier)
	{
		string saveNameFromIdentifier = GetSaveNameFromIdentifier(Identifier);
		if (Identifier >= ObjectType.Total && ModManager.Instance.m_ModStrings.ContainsKey(Identifier))
		{
			return ModManager.Instance.m_ModStrings[Identifier];
		}
		if (!TextManager.Instance.DoesExist(saveNameFromIdentifier))
		{
			return "";
		}
		if (FolkHeart.GetIsFolkHeart(Identifier))
		{
			int variableAsInt = VariableManager.Instance.GetVariableAsInt(Identifier, "Value");
			if (variableAsInt == 1)
			{
				return TextManager.Instance.Get("FolkHeart");
			}
			string text = TextManager.Instance.Get("FolkHeart1");
			return text + string.Format("{0:N0}", variableAsInt);
		}
		return TextManager.Instance.Get(saveNameFromIdentifier);
	}

	public string GetDescriptionFromIdentifier(ObjectType Identifier)
	{
		string tag = GetSaveNameFromIdentifier(Identifier) + "Description";
		if (!TextManager.Instance.DoesExist(tag))
		{
			return "";
		}
		return TextManager.Instance.Get(tag);
	}

	public string GetHumanReadableNameFromString(string OldName)
	{
		return OldName;
	}

	public string GetPrefabFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_PrefabName;
	}

	public string GetModelNameFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_ModelName;
	}

	public bool GetReusableFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_Reusable;
	}

	public string GetIconNameFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_IconName;
	}

	public bool GetStackableFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_Stackable;
	}

	public Layers GetLayerFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_Layer;
	}

	public ObjectType GetIdentifierFromSaveName(string SaveName, bool Check = true)
	{
		if (SaveName == "")
		{
			return m_Total;
		}
		ObjectTypeInfo value;
		if (m_SaveList.TryGetValue(SaveName, out value))
		{
			return value.m_Type;
		}
		ObjectType result = ObjectType.Nothing;
		if (Enum.TryParse<ObjectType>(SaveName, out result) && result >= ObjectType.Total)
		{
			return result;
		}
		if (Check)
		{
			ErrorMessage.LogError("Couldn't find SaveName Type " + SaveName);
		}
		else
		{
			Debug.Log("Couldn't find SaveName Type " + SaveName);
		}
		return m_Total;
	}

	public IngredientRequirement[] GetIngredientsFromIdentifier(ObjectType Identifier, int Stage = 0)
	{
		if (m_Objects[(int)Identifier].m_Ingredients.Count == 0)
		{
			ObjectType converterForObject = VariableManager.Instance.GetConverterForObject(Identifier);
			if (converterForObject != m_Total)
			{
				ConverterResults resultsForBuilding = VariableManager.Instance.GetResultsForBuilding(converterForObject);
				for (int i = 0; i < resultsForBuilding.m_Results.Count; i++)
				{
					if (resultsForBuilding.m_Results[i][0].m_Type == Identifier)
					{
						return resultsForBuilding.m_Requirements[i].ToArray();
					}
				}
			}
			return new IngredientRequirement[0];
		}
		return m_Objects[(int)Identifier].m_Ingredients[Stage];
	}

	public int GetIngredientsStagesFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_Ingredients.Count;
	}

	public Transform GetParentFromIdentifier(ObjectType Identifier)
	{
		return m_Objects[(int)Identifier].m_Parent;
	}

	public void ResetUniqueIDCounter()
	{
		m_UniqueIDCounter = 1;
	}

	public void SetLoading(bool Loading)
	{
		m_Loading = Loading;
		if (Loading)
		{
			m_UniqueIDCounter = 1;
			m_UniqueIDList = new Dictionary<int, BaseClass>();
			m_UniqueIDs = new Dictionary<BaseClass, int>();
		}
	}

	public int AddActionable(BaseClass NewBaseClass)
	{
		if (m_Loading && NewBaseClass.m_TypeIdentifier != ObjectType.Plot && NewBaseClass.m_TypeIdentifier != ObjectType.Nothing)
		{
			return -1;
		}
		if (NewBaseClass.m_UniqueID != -1)
		{
			Debug.Log("AddActionable : Object already has a UID " + NewBaseClass.m_UniqueID);
			if (!m_UniqueIDs.ContainsKey(NewBaseClass))
			{
				m_UniqueIDList.Add(NewBaseClass.m_UniqueID, NewBaseClass);
				m_UniqueIDs.Add(NewBaseClass, NewBaseClass.m_UniqueID);
				m_ObjectTypeCounts[(int)NewBaseClass.m_TypeIdentifier]++;
				m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier]++;
				m_ObjectTypeExists[(int)NewBaseClass.m_TypeIdentifier] = 1;
			}
			return NewBaseClass.m_UniqueID;
		}
		if (!m_UniqueIDs.ContainsKey(NewBaseClass))
		{
			m_UniqueIDList.Add(m_UniqueIDCounter, NewBaseClass);
			m_UniqueIDs.Add(NewBaseClass, m_UniqueIDCounter);
			m_UniqueIDCounter++;
			m_ObjectTypeCounts[(int)NewBaseClass.m_TypeIdentifier]++;
			m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier]++;
			m_ObjectTypeExists[(int)NewBaseClass.m_TypeIdentifier] = 1;
			return m_UniqueIDCounter - 1;
		}
		if (NewBaseClass.m_UniqueID == -1)
		{
			m_UniqueIDList.Add(m_UniqueIDCounter, NewBaseClass);
			m_UniqueIDs.Add(NewBaseClass, m_UniqueIDCounter);
			m_UniqueIDCounter++;
			m_ObjectTypeCounts[(int)NewBaseClass.m_TypeIdentifier]++;
			m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier]++;
			m_ObjectTypeExists[(int)NewBaseClass.m_TypeIdentifier] = 1;
			return m_UniqueIDCounter - 1;
		}
		return NewBaseClass.m_UniqueID;
	}

	public void RemoveActionable(BaseClass NewBaseClass)
	{
		m_ObjectTypeCounts[(int)NewBaseClass.m_TypeIdentifier]--;
		m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier]--;
		if (m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier] == 0)
		{
			m_ObjectTypeExists[(int)NewBaseClass.m_TypeIdentifier] = 0;
		}
		m_UniqueIDList.Remove(NewBaseClass.m_UniqueID);
		m_UniqueIDs.Remove(NewBaseClass);
	}

	public void ChangeActionable(BaseClass NewBaseClass, int NewID)
	{
		if (m_UniqueIDList.ContainsKey(NewID))
		{
			NewBaseClass.m_UniqueID = m_UniqueIDCounter;
			m_UniqueIDList.Add(m_UniqueIDCounter, NewBaseClass);
			m_UniqueIDs.Add(NewBaseClass, m_UniqueIDCounter);
			m_UniqueIDCounter++;
			m_ObjectTypeCounts[(int)NewBaseClass.m_TypeIdentifier]++;
			m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier]++;
			m_ObjectTypeExists[(int)NewBaseClass.m_TypeIdentifier] = 1;
			return;
		}
		m_UniqueIDList.Add(NewID, NewBaseClass);
		m_UniqueIDs.Add(NewBaseClass, NewID);
		NewBaseClass.m_UniqueID = NewID;
		m_ObjectTypeCounts[(int)NewBaseClass.m_TypeIdentifier]++;
		m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier]++;
		m_ObjectTypeExists[(int)NewBaseClass.m_TypeIdentifier] = 1;
		if (NewID >= m_UniqueIDCounter)
		{
			m_UniqueIDCounter = NewID + 1;
		}
	}

	public void SetUniqueIDCounter(int UniqueIDCounter)
	{
		m_UniqueIDCounter = UniqueIDCounter;
	}

	public BaseClass GetObjectFromUniqueID(int ID, bool ErrorCheck = true)
	{
		BaseClass value = null;
		if (!m_UniqueIDList.TryGetValue(ID, out value) && ErrorCheck)
		{
			ErrorMessage.LogError("Couldn't find an object with Unique ID " + ID);
		}
		return value;
	}

	public void ActionableOnGround(BaseClass NewBaseClass, bool Savable)
	{
		if (Savable)
		{
			m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier]++;
		}
		else
		{
			m_ObjectTypeOnGroundCounts[(int)NewBaseClass.m_TypeIdentifier]--;
		}
	}

	public bool GetCanDropInto(ObjectType NewType)
	{
		if (NewType == ObjectType.Bush || MyTree.GetIsTree(NewType) || NewType == ObjectType.TreeStump)
		{
			return false;
		}
		return true;
	}

	public bool GetIsAnimateAdd(BaseClass NewObject)
	{
		if (NewObject == null || ToolFillable.GetIsTypeFillable(NewObject.m_TypeIdentifier))
		{
			return false;
		}
		return true;
	}

	public bool GetIsBuilding(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_Building;
	}

	public bool GetIsHoldable(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_Holdable;
	}

	public float GetHeight(ObjectType NewType)
	{
		if (NewType >= ObjectType.Total)
		{
			Vector3 ModelTranslation;
			Vector3 ModelRotation;
			Vector3 ModelScale;
			ModManager.Instance.GetCustomModelTransform(NewType, out ModelTranslation, out ModelRotation, out ModelScale);
			return m_Objects[(int)NewType].m_Height * ModelScale.y;
		}
		return m_Objects[(int)NewType].m_Height;
	}

	public float GetYOffset(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_Offset;
	}

	public int GetWeight(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_Weight;
	}

	public void SetTypeSleep(ObjectType NewType)
	{
		m_Objects[(int)NewType].m_Sleepy = true;
	}

	public bool GetIsSleepy(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_Sleepy;
	}

	public ObjectType GetStorageType(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_StorageType;
	}

	public ObjectType SetStorageType(ObjectType NewType, ObjectType NewStorage)
	{
		return m_Objects[(int)NewType].m_StorageType = NewStorage;
	}

	public int GetTier(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_Tier;
	}

	public ObjectCategory GetCategoryFromType(ObjectType NewType)
	{
		ObjectSubCategory subCategory = m_Objects[(int)NewType].m_SubCategory;
		if ((int)subCategory >= m_SubCategories.Length)
		{
			return ObjectCategory.Misc;
		}
		if (m_SubCategories[(int)subCategory] == null)
		{
			return ObjectCategory.Total;
		}
		return m_SubCategories[(int)subCategory].m_Category;
	}

	public string GetCategoryName(ObjectCategory NewCategory)
	{
		return "ObjectCategory" + NewCategory;
	}

	public string GetCategorySprite(ObjectCategory NewCategory)
	{
		string categoryName = GetCategoryName(NewCategory);
		return "ObjectCategories/" + categoryName;
	}

	public ObjectSubCategory GetSubCategoryFromType(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_SubCategory;
	}

	public string GetSubCategoryName(ObjectSubCategory NewSubCategory)
	{
		return "ObjectSubCategory" + NewSubCategory;
	}

	public string GetSubCategorySprite(ObjectSubCategory NewSubCategory)
	{
		string subCategoryName = GetSubCategoryName(NewSubCategory);
		return "ObjectSubCategories/" + subCategoryName;
	}

	public ObjectCategory GetCategoryFromSubCategory(ObjectSubCategory NewSubCategory)
	{
		if (m_SubCategories[(int)NewSubCategory] == null)
		{
			return ObjectCategory.Total;
		}
		return m_SubCategories[(int)NewSubCategory].m_Category;
	}

	public List<ObjectType> GetObjectsInSubCategories(ObjectSubCategory NewSubCategory)
	{
		return m_ObjectsInSubCategories[(int)NewSubCategory];
	}

	public List<ObjectSubCategory> GetSubCategoriesInCategories(ObjectCategory NewCategory)
	{
		return m_SubCategoriesInCategories[(int)NewCategory];
	}

	public ObjectUseType GetUseTypeFromType(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_UseType;
	}

	public string GetUseNameFromType(ObjectType NewType)
	{
		ObjectUseType useTypeFromType = GetUseTypeFromType(NewType);
		if (useTypeFromType == ObjectUseType.Total)
		{
			return "";
		}
		string text = TextManager.Instance.Get("UseType" + useTypeFromType);
		return "(" + text + ")";
	}

	public static string GetIDName(ObjectType NewType)
	{
		if (NewType == m_Total)
		{
			return "Total";
		}
		return NewType.ToString();
	}

	public bool GetInifinteRecursionFromType(ObjectType NewType)
	{
		return m_Objects[(int)NewType].m_InfinteRecusion;
	}

	public bool GetMissionUsableFromType(ObjectType NewType)
	{
		if (VariableManager.Instance.GetVariableAsInt(NewType, "DisableMission", false) != 0)
		{
			return false;
		}
		bool result = m_Objects[(int)NewType].m_MissionUsable;
		if (NewType == ObjectType.MulberrySeed)
		{
			result = !QuestManager.Instance.m_ObjectsLocked.ContainsKey(ObjectType.TreeMulberry);
		}
		if (Fish.GetIsTypeFish(NewType) && NewType != ObjectType.FishSalmon)
		{
			result = !QuestManager.Instance.m_ObjectsLocked.ContainsKey(ObjectType.ToolFishingRod);
		}
		if (NewType == ObjectType.CottonSeeds || NewType == ObjectType.CottonBall || NewType == ObjectType.CottonLint)
		{
			result = !QuestManager.Instance.m_ObjectsLocked.ContainsKey(ObjectType.CottonThread);
		}
		if (NewType == ObjectType.BullrushesSeeds || NewType == ObjectType.BullrushesStems || NewType == ObjectType.BullrushesFibre)
		{
			result = !QuestManager.Instance.m_ObjectsLocked.ContainsKey(ObjectType.BullrushesThread);
		}
		return result;
	}

	public void UpdateObjectTypeListOverBounds(out int ID)
	{
		ObjectTypeInfo[] array = new ObjectTypeInfo[m_Objects.Length];
		m_Objects.CopyTo(array, 0);
		m_Objects = new ObjectTypeInfo[array.Length + 1];
		array.CopyTo(m_Objects, 0);
		ID = m_Objects.Length;
	}

	private bool CheckRecipeForRecursion(ObjectType Identifier)
	{
		if (m_IngredientsRecursionTable[(int)Identifier])
		{
			return true;
		}
		m_IngredientsRecursionTable[(int)Identifier] = true;
		foreach (IngredientRequirement[] ingredient in m_Objects[(int)Identifier].m_Ingredients)
		{
			for (int i = 0; i < ingredient.Length; i++)
			{
				if (CheckRecipeForRecursion(ingredient[i].m_Type))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void ReplaceIngredients(ObjectType Identifier, IngredientRequirement[] Ingredients)
	{
		m_IngredientsRecursionTable = new bool[(int)m_Total];
		for (int i = 0; i < Ingredients.Length; i++)
		{
			if (CheckRecipeForRecursion(Ingredients[i].m_Type))
			{
				m_Objects[(int)Identifier].m_InfinteRecusion = true;
				break;
			}
		}
		m_Objects[(int)Identifier].m_Ingredients.Clear();
		SetIngredients(Identifier, Ingredients);
	}

	public void DisableCustomItem(ObjectType Identifier)
	{
		if (m_Objects[(int)Identifier] != null)
		{
			m_Objects[(int)Identifier].m_SubCategory = ObjectSubCategory.Hidden;
		}
	}

	public void EnableCustomItem(ObjectType Identifier, ObjectSubCategory NewCategory)
	{
		m_Objects[(int)Identifier].m_SubCategory = NewCategory;
	}

	public void UpdateBootVars(ObjectType Identifier)
	{
		m_Objects[(int)Identifier].m_Tier = VariableManager.Instance.GetVariableAsInt(Identifier, "Tier", false);
	}
}
