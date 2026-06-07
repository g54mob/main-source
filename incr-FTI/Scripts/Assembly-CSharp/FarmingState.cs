using System.Collections.Generic;

public class FarmingState : StateManager
{
	public ResourceState resource;

	public FarmingRecipe recipe;

	private float numberOfOutputsProduced;

	public readonly List<Requirement> requirements = new List<Requirement>();

	public FarmingState()
	{
		Initialize();
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromFarming(resource.type);
	}

	public override EntityId SkillEntity()
	{
		return EntityId.FromNaturalResource(resource.type);
	}

	public void LoadFarming(FarmingRecipe sourceRecipe, ResourceState resourceState)
	{
		recipe = sourceRecipe;
		resource = resourceState;
		numberOfOutputsProduced = sourceRecipe.primaryOutputAmount;
		if (resource.type == NaturalResource.FishSource)
		{
			baseProductionRate = 0.25f;
		}
		else if (resource.type == NaturalResource.WaterSource)
		{
			baseProductionRate = 1f;
		}
		else
		{
			baseProductionRate = 0.1f;
		}
	}

	public override void StoreItemStateCache()
	{
		base.StoreItemStateCache();
		GameManager.Instance.StoreRequirementCacheInTarget(recipe.requirements, parentTown, requirements);
		foreach (KeyValuePair<ItemType, double> item in recipe.inputs.items)
		{
			if (parentTown.inventory.TryGetValue(item.Key, out var value))
			{
				AddInput(value, item.Value, baseProductionRate);
			}
		}
		primaryOutput = new ItemRateData(resource, numberOfOutputsProduced, baseProductionRate, this);
		AddOutput(primaryOutput);
		double num = 1.0;
		if (Crafting.naturalResourceCache.TryGetValue(resource.type, out var value2))
		{
			num = value2.xpValuePerResource;
			if (parentTown.buildings.TryGetValue(value2.cultivationBuilding, out var value3))
			{
				SetProductionBuilding(value3);
			}
		}
		double baseAmount = num * (double)numberOfOutputsProduced;
		ItemState cachedTownXPState = parentTown.cachedTownXPState;
		AddOutput(cachedTownXPState, baseAmount, baseProductionRate, isRounded: true);
	}

	public override void LoadModifiers()
	{
		base.LoadModifiers();
		AddModifier(PerkType.CultivationSpeed, ModifierType.Speed);
		AddModifier(ResearchType.InfiniteCultivationSpeed, ModifierType.Speed);
		if (resource.type != NaturalResource.FishSource)
		{
			AddModifier(BuildingType.Tractor);
		}
		switch (recipe.resource)
		{
		case NaturalResource.AppleTree:
			AddModifier(ResearchType.AppleFarming, ModifierType.Speed);
			break;
		case NaturalResource.PearTree:
			AddModifier(ResearchType.PearFarming, ModifierType.Speed);
			break;
		case NaturalResource.BerryBush:
			AddModifier(ResearchType.BerryFarming, ModifierType.Speed);
			break;
		case NaturalResource.CottonPlant:
			AddModifier(ResearchType.CottonFarming, ModifierType.Speed);
			break;
		case NaturalResource.HerbBush:
			AddModifier(ResearchType.HerbFarming, ModifierType.Speed);
			break;
		case NaturalResource.PotatoPlant:
			AddModifier(ResearchType.PotatoFarming, ModifierType.Speed);
			break;
		case NaturalResource.CarrotPlant:
			AddModifier(ResearchType.CarrotFarming, ModifierType.Speed);
			break;
		case NaturalResource.TomatoPlant:
			AddModifier(ResearchType.TomatoFarming, ModifierType.Speed);
			break;
		case NaturalResource.SugarCane:
			AddModifier(ResearchType.SugarFarming, ModifierType.Speed);
			break;
		case NaturalResource.CactusFruitTree:
			AddModifier(ResearchType.CactusFarming, ModifierType.Speed);
			break;
		case NaturalResource.DragonFruitTree:
			AddModifier(ResearchType.DragonfruitFarming, ModifierType.Speed);
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
		if (Data.Instance.cultivationSpeedUpgrades.TryGetValue(resource.type, out var value2))
		{
			AddModifier(value2);
		}
	}

	protected override void CalcSpeed()
	{
		base.CalcSpeed();
		foreach (UpgradeType outputUpgrade in recipe.outputUpgrades)
		{
			outputAmountMultiplier *= parentTown.MultiplierForUpgrade(outputUpgrade);
		}
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
		return "Farming " + resource;
	}
}
