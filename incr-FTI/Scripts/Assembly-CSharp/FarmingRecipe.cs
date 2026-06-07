using System.Collections.Generic;

public class FarmingRecipe
{
	public readonly NaturalResource resource;

	public readonly ItemList inputs = new ItemList();

	public readonly List<UpgradeType> outputUpgrades = new List<UpgradeType>();

	public readonly List<RequirementId> requirements;

	public BuildingType producingBuildingType;

	public float primaryOutputAmount;

	public FarmingRecipe(NaturalResource r)
	{
		resource = r;
		requirements = new List<RequirementId>();
		LoadDefaultRecipe();
		LoadRequirements();
		primaryOutputAmount = 1f;
	}

	public static FarmingRecipe GetCopy(FarmingRecipe other)
	{
		return new FarmingRecipe(other.resource);
	}

	private void LoadRequirements()
	{
		if (Crafting.naturalResourceCache != null && Crafting.naturalResourceCache.TryGetValue(resource, out var value))
		{
			requirements.Add(new RequirementId(resource));
			if (value.exclusiveBiome != BiomeType.None)
			{
				requirements.Add(new RequirementId(value.exclusiveBiome));
			}
			producingBuildingType = value.cultivationBuilding;
		}
	}

	private void LoadDefaultRecipe()
	{
		switch (resource)
		{
		case NaturalResource.Tree:
			inputs.AddItem(ItemType.Water, 0.10000000149011612);
			break;
		case NaturalResource.AppleTree:
			inputs.AddItem(ItemType.Water, 0.5);
			break;
		case NaturalResource.DragonFruitTree:
			inputs.AddItem(ItemType.Water, 0.5);
			break;
		case NaturalResource.PearTree:
			inputs.AddItem(ItemType.Water, 0.5);
			break;
		case NaturalResource.FishSource:
			inputs.AddItem(ItemType.FishFood, 0.25);
			break;
		case NaturalResource.Wheat:
			inputs.AddItem(ItemType.Water, 0.25);
			break;
		case NaturalResource.BerryBush:
			inputs.AddItem(ItemType.Water, 0.5);
			break;
		case NaturalResource.CarrotPlant:
			inputs.AddItem(ItemType.Water, 0.25);
			break;
		case NaturalResource.CottonPlant:
			inputs.AddItem(ItemType.Water, 0.5);
			break;
		case NaturalResource.HerbBush:
			inputs.AddItem(ItemType.Water, 0.5);
			break;
		case NaturalResource.PotatoPlant:
			inputs.AddItem(ItemType.Water, 0.25);
			break;
		case NaturalResource.SugarCane:
			inputs.AddItem(ItemType.Water, 0.5);
			break;
		case NaturalResource.TomatoPlant:
			inputs.AddItem(ItemType.Water, 0.25);
			break;
		case NaturalResource.CactusFruitTree:
			inputs.AddItem(ItemType.Water, 0.05000000074505806);
			break;
		case NaturalResource.Rock:
		case NaturalResource.IronOre:
		case NaturalResource.CoalOre:
		case NaturalResource.CopperOre:
		case NaturalResource.GoldOre:
		case NaturalResource.WaterSource:
		case NaturalResource.ManaCrystal:
		case NaturalResource.Ruby:
		case NaturalResource.Topaz:
		case NaturalResource.Sapphire:
		case NaturalResource.Amethyst:
		case NaturalResource.SilverOre:
			break;
		}
	}
}
