using System.Collections.Generic;

public class RecipeState : StateManager
{
	public RecipeType type;

	public Recipe recipe;

	public readonly List<Requirement> derivedRequirements = new List<Requirement>();

	public RecipeState()
	{
		Initialize();
	}

	public override void LoadModifiers()
	{
		base.LoadModifiers();
		if (Crafting.buildingCache.TryGetValue(recipe.producingBuildingType, out var value) && value.category == BuildingCategory.Research)
		{
			AddModifier(PerkType.KnowledgeSpeed);
			AddModifier(ResearchType.InfiniteKnowledgeSpeed, ModifierType.Speed);
		}
		else
		{
			AddModifier(PerkType.CraftingSpeed);
			AddModifier(ResearchType.InfiniteCraftingSpeed, ModifierType.Speed);
		}
		if (IsAffectedByFactoryv2())
		{
			AddModifier(BuildingType.Factory);
		}
		if (base.producingBuilding != null)
		{
			if (Crafting.buildingCache.TryGetValue(base.producingBuilding.type, out var value2))
			{
				foreach (UpgradeType productionSpeedUpgrade in value2.productionSpeedUpgrades)
				{
					AddModifier(productionSpeedUpgrade);
				}
				foreach (UpgradeType outputAmountUpgrade in value2.outputAmountUpgrades)
				{
					AddModifier(outputAmountUpgrade, ModifierType.OutputAmount);
				}
			}
			if (base.producingBuilding.type == BuildingType.Forge || base.producingBuilding.type == BuildingType.MagicForge)
			{
				AddModifier(BuildingType.Foundry);
			}
			switch (base.producingBuilding.type)
			{
			case BuildingType.OmniTemple:
				AddModifier(ResearchType.InfiniteOmniTempleProductivity, ModifierType.OutputAmount);
				break;
			case BuildingType.StoneMason:
				AddModifier(ResearchType.StoneProcessingSpeed, ModifierType.Speed);
				break;
			case BuildingType.GrainMill:
				AddModifier(ResearchType.GrainProcessingSpeed, ModifierType.Speed);
				break;
			case BuildingType.LumberMill:
				AddModifier(ResearchType.WoodProcessingSpeed, ModifierType.Speed);
				break;
			case BuildingType.Forge:
				AddModifier(ResearchType.MetalProcessingSpeed, ModifierType.Speed);
				break;
			case BuildingType.Bakery:
			case BuildingType.MedicineHut:
			case BuildingType.GourmetKitchen:
				AddModifier(BuildingType.MagicBoat);
				break;
			case BuildingType.Refinery:
			case BuildingType.Enchanter:
			case BuildingType.Jeweler:
				AddModifier(BuildingType.Airship);
				break;
			case BuildingType.WaterPump:
				AddModifier(UpgradeType.WaterPumpCountSpeed);
				break;
			case BuildingType.SteamBoiler:
				AddModifier(UpgradeType.SteamBoilerCountSpeed);
				break;
			case BuildingType.SteamPowerGenerator:
				AddModifier(UpgradeType.SteamPowerGeneratorCountSpeed);
				break;
			case BuildingType.Furnace:
				AddModifier(UpgradeType.FurnaceCountSpeed);
				break;
			case BuildingType.ManaTransmitter:
				AddModifier(UpgradeType.ExtractorCountSpeed);
				break;
			case BuildingType.ManaReactor:
				AddModifier(ResearchType.InfiniteManaReactorProductivity, ModifierType.OutputAmount);
				break;
			}
			if (type == RecipeType.MakePolishedStone)
			{
				AddModifier(ResearchType.StoneProcessingSpeed, ModifierType.Speed);
			}
		}
		foreach (EntityId productivityUpgrade in recipe.productivityUpgrades)
		{
			ResearchType i2;
			BuildingType b;
			if (productivityUpgrade.TryAsUpgrade(out var i))
			{
				AddModifier(i, ModifierType.OutputAmount);
			}
			else if (productivityUpgrade.TryAsResearch(out i2))
			{
				AddModifier(i2, ModifierType.OutputAmount);
			}
			else if (productivityUpgrade.TryAsBuilding(out b))
			{
				AddModifier(b, ModifierType.OutputAmount);
			}
		}
	}

	public void LoadRecipe(Recipe r)
	{
		type = r.type;
		recipe = r;
	}

	public bool IsAffectedByFactoryv2()
	{
		if (base.producingBuilding == null)
		{
			return false;
		}
		switch (base.producingBuilding.type)
		{
		case BuildingType.LumberMill:
		case BuildingType.GrainMill:
		case BuildingType.Pasture:
		case BuildingType.StoneMason:
		case BuildingType.Workshop:
		case BuildingType.MachineShop:
		case BuildingType.Tailor:
			return true;
		default:
			return false;
		}
	}

	public bool IsAffectedByFactory()
	{
		RecipeType recipeType = type;
		if ((uint)(recipeType - 54) <= 1u || recipeType == RecipeType.MakeCopperWire || recipeType == RecipeType.MakeQuartzFromStone)
		{
			return true;
		}
		foreach (ItemRateData item in output)
		{
			if (item.state.AsEntity().TryAsItem(out var i) && Crafting.cachedItemDefs.TryGetValue(i, out var value) && (value.specialty == Specialty.Clothing || value.specialty == Specialty.Tech || value.specialty == Specialty.PlantProducts || value.specialty == Specialty.Construction))
			{
				return true;
			}
		}
		return false;
	}

	protected override void CalcSpeed()
	{
		base.CalcSpeed();
	}

	public override void StoreItemStateCache()
	{
		base.StoreItemStateCache();
		GameManager.Instance.StoreRequirementCacheInTarget(recipe.requirements, parentTown, derivedRequirements);
		parentTown.AddIngredientRequirementsRecursive(recipe.inputs, derivedRequirements, type);
		StoreItemStateCacheRecipe(recipe);
		if (parentTown.buildings.TryGetValue(recipe.producingBuildingType, out var value))
		{
			SetProductionBuilding(value);
		}
	}

	protected override bool ShouldBeAvailable()
	{
		if (GameManager.everythingUnlocked)
		{
			return true;
		}
		if (base.producingBuilding == null)
		{
			return false;
		}
		if (base.producingBuilding.availability != BuildObjectAvailability.Available)
		{
			return false;
		}
		if (derivedRequirements != null)
		{
			foreach (Requirement derivedRequirement in derivedRequirements)
			{
				if (!derivedRequirement.IsMet())
				{
					return false;
				}
			}
		}
		return true;
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromRecipe(type);
	}

	public override EntityId SkillEntity()
	{
		return EntityId.FromRecipe(type);
	}

	protected override void OnBecameAvailableDuringGame()
	{
		base.OnBecameAvailableDuringGame();
		GameManager.Instance.UnlockOutputsOfRecipe(this);
	}

	public ItemType PrimaryOutputItem()
	{
		using (Dictionary<ItemType, double>.Enumerator enumerator = recipe.outputs.items.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current.Key;
			}
		}
		return ItemType.None;
	}

	public override string ToString()
	{
		return "Recipe " + recipe.type;
	}
}
