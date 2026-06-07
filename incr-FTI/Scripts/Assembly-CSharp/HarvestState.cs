using System.Collections.Generic;

public class HarvestState : StateManager
{
	public HarvestRecipeType type;

	public HarvestDef def;

	public ResourceState resource;

	public ItemState harvestedItemState;

	public readonly List<Requirement> cachedRequirements = new List<Requirement>();

	public HarvestState()
	{
		Initialize();
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromHarvestRecipe(type);
	}

	public override EntityId SkillEntity()
	{
		return EntityId.FromHarvestRecipe(type);
	}

	public void LoadHarvestRecipe(HarvestDef source)
	{
		def = source;
		type = source.type;
	}

	public override void StoreItemStateCache()
	{
		base.StoreItemStateCache();
		GameManager.Instance.StoreRequirementCacheInTarget(def.requirements, parentTown, cachedRequirements);
		StoreItemStateCacheRecipe(def.recipe);
		if (parentTown.naturalResources.TryGetValue(def.resourceType, out var value))
		{
			resource = value;
			AddInput(resource, def.primaryInputMultiplier, baseProductionRate);
		}
		if (parentTown.inventory.TryGetValue(def.harvestedItemType, out var value2))
		{
			harvestedItemState = value2;
		}
		if (parentTown.buildings.TryGetValue(def.producingBuildingType, out var value3))
		{
			SetProductionBuilding(value3);
		}
	}

	public override void LoadModifiers()
	{
		base.LoadModifiers();
		if (def.producingBuildingType == BuildingType.CropHarvester)
		{
			AddModifier(ResearchType.ManaPowerCropHarvesters, ModifierType.Speed);
		}
		else if (def.producingBuildingType == BuildingType.HarvesterDrill)
		{
			AddModifier(ResearchType.ManaPowerHarvesterDrills, ModifierType.Speed);
		}
		else if (def.producingBuildingType == BuildingType.ChainsawTank)
		{
			AddModifier(ResearchType.ManaPowerChainsawTanks, ModifierType.Speed);
		}
		if (Crafting.buildingCache.TryGetValue(def.producingBuildingType, out var value))
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
		AddModifier(BuildingType.Chute);
		AddModifier(PerkType.HarvestingSpeed);
		if (Data.Instance.harvestingSpeedUpgrades.TryGetValue(type, out var value2))
		{
			AddModifier(value2);
		}
	}

	protected override void CalcSpeed()
	{
		base.CalcSpeed();
		if (def.outputUpgrade != UpgradeType.None)
		{
			outputAmountMultiplier = parentTown.MultiplierForUpgrade(def.outputUpgrade);
		}
	}

	public override string ToString()
	{
		return "HarvestState " + type.ToString() + " workers:" + numWorkersAssigned;
	}

	protected override bool ShouldBeAvailable()
	{
		if (GameManager.everythingUnlocked)
		{
			return true;
		}
		if (cachedRequirements != null)
		{
			foreach (Requirement cachedRequirement in cachedRequirements)
			{
				if (!cachedRequirement.IsMet())
				{
					return false;
				}
			}
		}
		return !resource.isLocked;
	}
}
