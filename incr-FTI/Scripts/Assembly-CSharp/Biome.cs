using System.Collections.Generic;

public class Biome
{
	public readonly BiomeType type;

	private readonly Dictionary<NaturalResource, BiomeResourceDef> resourceDefs = new Dictionary<NaturalResource, BiomeResourceDef>(new NaturalResourceEqualityComparer());

	private static BiomeResourceDef Unavailable;

	public readonly List<BiomeModifier> entityModifiers = new List<BiomeModifier>();

	public readonly List<ResearchType> autoCompletedResearch = new List<ResearchType>();

	public static BiomeResourceDef GetBiomeDef(NaturalResource t, BiomeType b)
	{
		if (Crafting.biomeCache.TryGetValue(b, out var value) && value.resourceDefs.TryGetValue(t, out var value2))
		{
			return value2;
		}
		return null;
	}

	public Biome(BiomeType t)
	{
		type = t;
		LoadBiomeDetails();
	}

	private void LoadDefaultBiome()
	{
		resourceDefs[NaturalResource.BerryBush] = GetDef();
		resourceDefs[NaturalResource.CottonPlant] = GetDef();
		resourceDefs[NaturalResource.AppleTree] = GetDef();
		resourceDefs[NaturalResource.HerbBush] = GetDef();
		resourceDefs[NaturalResource.PotatoPlant] = GetDef();
		resourceDefs[NaturalResource.CarrotPlant] = GetDef();
		resourceDefs[NaturalResource.PearTree] = GetDef();
		resourceDefs[NaturalResource.TomatoPlant] = GetDef();
		resourceDefs[NaturalResource.SugarCane] = GetDef();
		resourceDefs[NaturalResource.Tree] = GetDef();
		resourceDefs[NaturalResource.Wheat] = GetDef();
		resourceDefs[NaturalResource.WaterSource] = GetDef();
		resourceDefs[NaturalResource.FishSource] = GetDef();
		resourceDefs[NaturalResource.CactusFruitTree] = GetDef();
		resourceDefs[NaturalResource.DragonFruitTree] = GetDef();
		resourceDefs[NaturalResource.Sand] = GetDef();
		foreach (KeyValuePair<NaturalResource, NaturalResourceDef> item in Crafting.naturalResourceCache)
		{
			if (item.Value.IsRockResource())
			{
				resourceDefs[item.Key] = GetDef();
			}
		}
	}

	private void LoadBiomeDetails()
	{
		LoadDefaultBiome();
		switch (type)
		{
		case BiomeType.Plains:
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.Wheat), BiomeModifierType.CultivationProductivity, 1.5f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromItem(ItemType.UtilityLand), BiomeModifierType.Land, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.CottonPlant), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.AppleTree), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Bakery), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.GourmetKitchen), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.GemMine), BiomeModifierType.ProspectingProductivity, 0.5f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.FancyFoods), BiomeModifierType.MarketDemand, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.PlainsUniversity), BiomeModifierType.UniqueBuilding, 1f));
			break;
		case BiomeType.River:
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.TomatoPlant), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.SugarCane), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.FishSource), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.FishingBoat), BiomeModifierType.UniqueBuilding, 1f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Quarry), BiomeModifierType.ProspectingProductivity, 0.75f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Mine), BiomeModifierType.ProspectingProductivity, 0.5f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.WaterSource), BiomeModifierType.ResourceRegen, 3f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Pasture), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.GeneralGoods), BiomeModifierType.MarketDemand, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.RiverHarbor), BiomeModifierType.UniqueBuilding, 1f));
			break;
		case BiomeType.Forest:
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Quarry), BiomeModifierType.ProspectingProductivity, 0.75f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Mine), BiomeModifierType.ProspectingProductivity, 0.5f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.Tree), BiomeModifierType.ResourceRegen, 5f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.LumberMill), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.MedicineHut), BiomeModifierType.RecipeProductivity, 4f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.HerbBush), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.PearTree), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.BerryBush), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Bookstore), BiomeModifierType.MarketDemand, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.ForestMonastery), BiomeModifierType.UniqueBuilding, 1f));
			break;
		case BiomeType.Desert:
			entityModifiers.Add(new BiomeModifier(EntityId.FromItem(ItemType.UtilityLand), BiomeModifierType.Land, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.WaterSource), BiomeModifierType.ResourceRegen, 0.1f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Forge), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Well), BiomeModifierType.CultivationProductivity, 0.1f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.CactusFruitTree), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.Ruby), BiomeModifierType.UniqueResource, 5f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.Sand), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.SolarPanel), BiomeModifierType.UniqueBuilding, 1f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.JewelryStore), BiomeModifierType.MarketDemand, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.DesertBazaar), BiomeModifierType.UniqueBuilding, 1f));
			break;
		case BiomeType.Mountains:
			entityModifiers.Add(new BiomeModifier(EntityId.FromItem(ItemType.UtilityLand), BiomeModifierType.Land, 0.75f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.CarrotPlant), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Quarry), BiomeModifierType.ProspectingProductivity, 5f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Mine), BiomeModifierType.ProspectingProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.MachineShop), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.Topaz), BiomeModifierType.UniqueResource, 5f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Forester), BiomeModifierType.CultivationProductivity, 0.5f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.HardwareStore), BiomeModifierType.MarketDemand, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.MountainObservatory), BiomeModifierType.UniqueBuilding, 1f));
			break;
		case BiomeType.Jungle:
			entityModifiers.Add(new BiomeModifier(EntityId.FromItem(ItemType.UtilityLand), BiomeModifierType.Land, 0.75f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Forester), BiomeModifierType.CultivationProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Pasture), BiomeModifierType.RecipeProductivity, 0.5f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Jeweler), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.DragonFruitTree), BiomeModifierType.UniqueResource, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.Amethyst), BiomeModifierType.UniqueResource, 5f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Apothecary), BiomeModifierType.MarketDemand, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.JunglePyramid), BiomeModifierType.UniqueBuilding, 1f));
			break;
		case BiomeType.Snow:
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.PotatoPlant), BiomeModifierType.UniqueResource, 4f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Forge), BiomeModifierType.RecipeProductivity, 0.25f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromRecipe(RecipeType.FarmWool), BiomeModifierType.RecipeProductivity, 3f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Farm), BiomeModifierType.CultivationProductivity, 0.5f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Tailor), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.Sapphire), BiomeModifierType.UniqueResource, 5f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.ClothingStore), BiomeModifierType.MarketDemand, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.SnowTreasureVault), BiomeModifierType.UniqueBuilding, 1f));
			break;
		case BiomeType.Magic:
			entityModifiers.Add(new BiomeModifier(EntityId.FromItem(ItemType.UtilityLand), BiomeModifierType.Land, 0.5f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Farm), BiomeModifierType.CultivationProductivity, 0.75f, isNegative: true));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.Enchanter), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.MagicForge), BiomeModifierType.RecipeProductivity, 2f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromNaturalResource(NaturalResource.ManaCrystal), BiomeModifierType.UniqueResource, 5f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.FloatingIsland), BiomeModifierType.UniqueBuilding, 1f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.ArcaneStore), BiomeModifierType.MarketDemand, 1.25f));
			entityModifiers.Add(new BiomeModifier(EntityId.FromBuilding(BuildingType.MagicObelisk), BiomeModifierType.UniqueBuilding, 1f));
			break;
		}
	}

	private BiomeResourceDef GetDef()
	{
		return new BiomeResourceDef
		{
			isAvailable = true
		};
	}
}
