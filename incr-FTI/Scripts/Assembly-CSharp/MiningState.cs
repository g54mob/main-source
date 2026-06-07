using System.Collections.Generic;

public class MiningState : StateManager
{
	public ResourceState resource;

	public FarmingRecipe def;

	public readonly List<Requirement> requirements = new List<Requirement>();

	public MiningState()
	{
		Initialize();
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromMining(resource.type);
	}

	public override EntityId SkillEntity()
	{
		return EntityId.FromNaturalResource(resource.type);
	}

	public void LoadMining(FarmingRecipe sourceRecipe, ResourceState resourceState)
	{
		def = sourceRecipe;
		resource = resourceState;
	}

	public override void StoreItemStateCache()
	{
		base.StoreItemStateCache();
		GameManager.Instance.StoreRequirementCacheInTarget(def.requirements, parentTown, requirements);
		baseProductionRate = 0.1f;
		double num = 1.0;
		primaryOutput = new ItemRateData(resource, num, baseProductionRate, this);
		AddOutput(primaryOutput);
		double num2 = 1.0;
		BuildingType key;
		if (Crafting.naturalResourceCache.TryGetValue(resource.type, out var value))
		{
			key = value.cultivationBuilding;
			num2 = value.xpValuePerResource;
		}
		else
		{
			key = BuildingType.Mine;
		}
		if (parentTown.buildings.TryGetValue(key, out var value2))
		{
			SetProductionBuilding(value2);
		}
		double baseAmount = num2 * num;
		ItemState cachedTownXPState = parentTown.cachedTownXPState;
		AddOutput(cachedTownXPState, baseAmount, baseProductionRate, isRounded: true);
	}

	private void TryAddInput(ItemType t, float itemsConsumedPerOutput)
	{
		if (parentTown.inventory.TryGetValue(t, out var value))
		{
			AddInput(value, itemsConsumedPerOutput, baseProductionRate);
		}
	}

	public override void LoadModifiers()
	{
		base.LoadModifiers();
		AddModifier(PerkType.ProspectingSpeed, ModifierType.Speed);
		AddModifier(ResearchType.InfiniteProspectingSpeed, ModifierType.Speed);
		AddModifier(BuildingType.Minecart);
		switch (def.resource)
		{
		case NaturalResource.CoalOre:
			AddModifier(ResearchType.CoalMining, ModifierType.Speed);
			break;
		case NaturalResource.SilverOre:
			AddModifier(ResearchType.SilverMining, ModifierType.Speed);
			break;
		case NaturalResource.CopperOre:
			AddModifier(ResearchType.CopperMining, ModifierType.Speed);
			break;
		case NaturalResource.GoldOre:
			AddModifier(ResearchType.GoldMining, ModifierType.Speed);
			break;
		case NaturalResource.Amethyst:
			AddModifier(ResearchType.AmethystMining, ModifierType.Speed);
			break;
		case NaturalResource.Sapphire:
			AddModifier(ResearchType.SapphireMining, ModifierType.Speed);
			break;
		case NaturalResource.Topaz:
			AddModifier(ResearchType.TopazMining, ModifierType.Speed);
			break;
		case NaturalResource.Ruby:
			AddModifier(ResearchType.RubyMining, ModifierType.Speed);
			break;
		case NaturalResource.ManaCrystal:
			AddModifier(ResearchType.ManaMining, ModifierType.Speed);
			break;
		}
		if (base.producingBuilding != null && Crafting.buildingCache.TryGetValue(base.producingBuilding.type, out var value))
		{
			foreach (UpgradeType productionSpeedUpgrade in value.productionSpeedUpgrades)
			{
				AddModifier(productionSpeedUpgrade);
			}
			foreach (UpgradeType outputAmountUpgrade in value.outputAmountUpgrades)
			{
				AddModifier(outputAmountUpgrade, ModifierType.OutputAmount);
			}
		}
		if (Data.Instance.prospectingSpeedUpgrades.TryGetValue(resource.type, out var value2))
		{
			AddModifier(value2);
		}
	}

	protected override void CalcSpeed()
	{
		base.CalcSpeed();
	}

	protected override bool ShouldBeAvailable()
	{
		if (GameManager.everythingUnlocked)
		{
			return true;
		}
		if (requirements != null)
		{
			foreach (Requirement requirement in requirements)
			{
				if (!requirement.IsMet())
				{
					return false;
				}
			}
		}
		if (parentTown.naturalResources.TryGetValue(resource.type, out var value) && (value.maxCount > 0.0 || value.isInputSupplyInfinite))
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return "Prospect " + resource.type;
	}
}
