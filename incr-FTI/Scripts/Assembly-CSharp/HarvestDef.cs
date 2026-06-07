using System.Collections.Generic;

public class HarvestDef
{
	public readonly HarvestRecipeType type;

	public readonly NaturalResource resourceType;

	public readonly ItemType harvestedItemType;

	public BuildingType producingBuildingType;

	public readonly Recipe recipe;

	public readonly UpgradeType outputUpgrade;

	public float primaryInputMultiplier;

	public float primaryOutputMultiplier;

	public readonly List<RequirementId> requirements;

	public HarvestDef(HarvestRecipeType t)
	{
		recipe = new Recipe(RecipeType.None);
		recipe.craftingTime = 4f;
		type = t;
		producingBuildingType = BuildingType.HarvesterHut;
		primaryInputMultiplier = 1f;
		primaryOutputMultiplier = 1f;
		requirements = new List<RequirementId>();
		switch (type)
		{
		case HarvestRecipeType.Tree:
			resourceType = NaturalResource.Tree;
			recipe.craftingTime = 2.5f;
			break;
		case HarvestRecipeType.AppleTree:
			resourceType = NaturalResource.AppleTree;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.PearTree:
			resourceType = NaturalResource.PearTree;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.Wheat:
			resourceType = NaturalResource.Wheat;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.FishSource:
			resourceType = NaturalResource.FishSource;
			producingBuildingType = BuildingType.FishingBoat;
			outputUpgrade = UpgradeType.FishingBoatYield;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.FishingBoatNet:
			resourceType = NaturalResource.FishSource;
			recipe.inputs.AddItem(ItemType.FishingNet, 1.0);
			producingBuildingType = BuildingType.FishingBoat;
			outputUpgrade = UpgradeType.FishingBoatYield;
			primaryOutputMultiplier = 4f;
			recipe.craftingTime = 4f;
			requirements.Add(new RequirementId(ResearchType.FishingNet));
			break;
		case HarvestRecipeType.FishingBoatMagicNet:
			resourceType = NaturalResource.FishSource;
			recipe.inputs.AddItem(ItemType.MagicFishingNet, 1.0);
			producingBuildingType = BuildingType.FishingBoat;
			outputUpgrade = UpgradeType.FishingBoatYield;
			primaryOutputMultiplier = 10f;
			recipe.craftingTime = 4f;
			requirements.Add(new RequirementId(ResearchType.MagicFishingNet));
			break;
		case HarvestRecipeType.HerbBush:
			resourceType = NaturalResource.HerbBush;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.BerryBush:
			resourceType = NaturalResource.BerryBush;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.CarrotPlant:
			resourceType = NaturalResource.CarrotPlant;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.PotatoPlant:
			resourceType = NaturalResource.PotatoPlant;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.TomatoPlant:
			resourceType = NaturalResource.TomatoPlant;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.CottonPlant:
			resourceType = NaturalResource.CottonPlant;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.SugarCane:
			resourceType = NaturalResource.SugarCane;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.DragonFruitTree:
			resourceType = NaturalResource.DragonFruitTree;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.CactusFruitTree:
			resourceType = NaturalResource.CactusFruitTree;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.HarvestSand:
			resourceType = NaturalResource.Sand;
			recipe.craftingTime = 1f;
			break;
		case HarvestRecipeType.WaterSource:
			resourceType = NaturalResource.WaterSource;
			recipe.craftingTime = 4f;
			break;
		case HarvestRecipeType.Rock:
			recipe.craftingTime = 4f;
			resourceType = NaturalResource.Rock;
			break;
		case HarvestRecipeType.IronOre:
			resourceType = NaturalResource.IronOre;
			recipe.craftingTime = 5f;
			break;
		case HarvestRecipeType.CopperOre:
			resourceType = NaturalResource.CopperOre;
			recipe.craftingTime = 5f;
			break;
		case HarvestRecipeType.CoalOre:
			resourceType = NaturalResource.CoalOre;
			recipe.craftingTime = 5f;
			break;
		case HarvestRecipeType.GoldOre:
			resourceType = NaturalResource.GoldOre;
			recipe.craftingTime = 6f;
			outputUpgrade = UpgradeType.PickaxeMiningYield;
			break;
		case HarvestRecipeType.SilverOre:
			resourceType = NaturalResource.SilverOre;
			recipe.craftingTime = 6f;
			outputUpgrade = UpgradeType.PickaxeMiningYield;
			break;
		case HarvestRecipeType.Ruby:
			resourceType = NaturalResource.Ruby;
			recipe.craftingTime = 8f;
			outputUpgrade = UpgradeType.PickaxeMiningYield;
			break;
		case HarvestRecipeType.Sapphire:
			resourceType = NaturalResource.Sapphire;
			recipe.craftingTime = 8f;
			outputUpgrade = UpgradeType.PickaxeMiningYield;
			break;
		case HarvestRecipeType.Topaz:
			resourceType = NaturalResource.Topaz;
			recipe.craftingTime = 8f;
			outputUpgrade = UpgradeType.PickaxeMiningYield;
			break;
		case HarvestRecipeType.Amethyst:
			resourceType = NaturalResource.Amethyst;
			recipe.craftingTime = 8f;
			outputUpgrade = UpgradeType.PickaxeMiningYield;
			break;
		case HarvestRecipeType.ManaCrystal:
			resourceType = NaturalResource.ManaCrystal;
			recipe.craftingTime = 10f;
			outputUpgrade = UpgradeType.PickaxeMiningYield;
			break;
		case HarvestRecipeType.ChainsawTree:
			resourceType = NaturalResource.Tree;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.ChainsawTank;
			recipe.craftingTime = 4f;
			outputUpgrade = UpgradeType.ChainsawTankYield;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterApple:
			resourceType = NaturalResource.AppleTree;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterBerries:
			resourceType = NaturalResource.BerryBush;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterCarrot:
			resourceType = NaturalResource.CarrotPlant;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterCotton:
			resourceType = NaturalResource.CottonPlant;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterGrain:
			resourceType = NaturalResource.Wheat;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterHerb:
			resourceType = NaturalResource.HerbBush;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterPear:
			resourceType = NaturalResource.PearTree;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterPotato:
			resourceType = NaturalResource.PotatoPlant;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterSugar:
			resourceType = NaturalResource.SugarCane;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterTomato:
			resourceType = NaturalResource.TomatoPlant;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterCactusFruit:
			resourceType = NaturalResource.CactusFruitTree;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.CropHarvesterDragonFruit:
			resourceType = NaturalResource.DragonFruitTree;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.CropHarvester;
			outputUpgrade = UpgradeType.CropHarvesterYield;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.DrillRock:
			resourceType = NaturalResource.Rock;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 4f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.AqueductHarvestWater:
			resourceType = NaturalResource.WaterSource;
			producingBuildingType = BuildingType.Aqueduct;
			recipe.craftingTime = 4f;
			primaryOutputMultiplier = 5f;
			primaryInputMultiplier = 5f;
			break;
		case HarvestRecipeType.DrillAmethyst:
			resourceType = NaturalResource.Amethyst;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 8f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 4f;
			primaryInputMultiplier = 4f;
			break;
		case HarvestRecipeType.DrillSapphire:
			resourceType = NaturalResource.Sapphire;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 8f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 4f;
			primaryInputMultiplier = 4f;
			break;
		case HarvestRecipeType.DrillRuby:
			resourceType = NaturalResource.Ruby;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 8f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 4f;
			primaryInputMultiplier = 4f;
			break;
		case HarvestRecipeType.DrillTopaz:
			resourceType = NaturalResource.Topaz;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 8f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 4f;
			primaryInputMultiplier = 4f;
			break;
		case HarvestRecipeType.DrillIron:
			resourceType = NaturalResource.IronOre;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 5f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.DrillCoal:
			resourceType = NaturalResource.CoalOre;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 5f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.DrillCopper:
			resourceType = NaturalResource.CopperOre;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 5f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.DrillSilver:
			resourceType = NaturalResource.SilverOre;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 6f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.DrillGold:
			resourceType = NaturalResource.GoldOre;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 6f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		case HarvestRecipeType.DrillMana:
			resourceType = NaturalResource.ManaCrystal;
			recipe.inputs.AddItem(ItemType.Power, 1.0);
			producingBuildingType = BuildingType.HarvesterDrill;
			recipe.craftingTime = 10f;
			outputUpgrade = UpgradeType.HarvesterDrillYield;
			primaryOutputMultiplier = 10f;
			primaryInputMultiplier = 10f;
			break;
		}
		requirements.Add(new RequirementId(resourceType));
		if (Crafting.naturalResourceCache.TryGetValue(resourceType, out var value) && value.exclusiveBiome != BiomeType.None)
		{
			requirements.Add(new RequirementId(value.exclusiveBiome));
		}
		harvestedItemType = Item.ItemFromNaturalResource(resourceType);
		recipe.outputs.AddItem(harvestedItemType, primaryOutputMultiplier);
	}
}
