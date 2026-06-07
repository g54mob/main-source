public class RequiredHarvestRecipe : Requirement
{
	public readonly HarvestRecipeType harvestRecipeType;

	private HarvestState cachedHarvestState;

	public RequiredHarvestRecipe(HarvestRecipeType type)
	{
		harvestRecipeType = type;
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredHarvestRecipe(harvestRecipeType);
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		if (town.harvesting.TryGetValue(harvestRecipeType, out var value))
		{
			cachedHarvestState = value;
		}
	}

	public override bool IsMet()
	{
		if (cachedHarvestState != null)
		{
			return !cachedHarvestState.isLocked;
		}
		return false;
	}

	public override string ToString()
	{
		return "Required Harvest " + harvestRecipeType;
	}
}
