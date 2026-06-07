using System.Collections.Generic;

public class NaturalResourceDef
{
	public readonly NaturalResource type;

	public bool enabled;

	public ItemType itemProvided;

	public float capacityPerLand;

	public float growthAmount;

	public float regenFactor;

	public BuildingType cultivationBuilding;

	public BiomeType exclusiveBiome;

	public double xpValuePerResource;

	public readonly List<RequirementId> requirements = new List<RequirementId>();

	public readonly List<EntityLevel> reward = new List<EntityLevel>();

	public NaturalResourceDef(NaturalResource type)
	{
		this.type = type;
		enabled = true;
	}

	public bool IsInfiniteSupply()
	{
		return false;
	}

	public bool IsRockResource()
	{
		BuildingType buildingType = cultivationBuilding;
		if (buildingType == BuildingType.Mine || (uint)(buildingType - 86) <= 1u)
		{
			return true;
		}
		return false;
	}

	public void CopyFrom(NaturalResourceDef other)
	{
		enabled = other.enabled;
		itemProvided = other.itemProvided;
		capacityPerLand = other.capacityPerLand;
		regenFactor = other.regenFactor;
		growthAmount = other.growthAmount;
		cultivationBuilding = other.cultivationBuilding;
		exclusiveBiome = other.exclusiveBiome;
		xpValuePerResource = other.xpValuePerResource;
	}

	public void LoadRequirements()
	{
		switch (type)
		{
		case NaturalResource.Rock:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestRock));
			break;
		case NaturalResource.Wheat:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestGrain));
			break;
		case NaturalResource.WaterSource:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestWater));
			break;
		case NaturalResource.AppleTree:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestApples));
			break;
		case NaturalResource.CottonPlant:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestCotton));
			break;
		case NaturalResource.BerryBush:
			requirements.Add(new RequirementId(QuestType.DiscoverBerries));
			break;
		case NaturalResource.PotatoPlant:
			requirements.Add(new RequirementId(BiomeType.Snow));
			break;
		case NaturalResource.TomatoPlant:
			requirements.Add(new RequirementId(QuestType.DiscoverTomato));
			break;
		case NaturalResource.SugarCane:
			requirements.Add(new RequirementId(QuestType.DiscoverSugar));
			break;
		case NaturalResource.PearTree:
			requirements.Add(new RequirementId(QuestType.DiscoverPear));
			break;
		case NaturalResource.IronOre:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestIron));
			break;
		case NaturalResource.CoalOre:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestCoal));
			break;
		case NaturalResource.CopperOre:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestCopper));
			break;
		case NaturalResource.SilverOre:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestSilver));
			break;
		case NaturalResource.GoldOre:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestGold));
			break;
		case NaturalResource.Ruby:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestRuby));
			break;
		case NaturalResource.Sapphire:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestSapphire));
			break;
		case NaturalResource.Amethyst:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestAmethyst));
			break;
		case NaturalResource.Topaz:
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestTopaz));
			break;
		}
		if (exclusiveBiome != BiomeType.None)
		{
			requirements.Add(new RequirementId(exclusiveBiome));
		}
	}
}
