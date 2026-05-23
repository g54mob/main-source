public static class ResourceCostSaveDataExtensions
{
	public static ResourceCostSaveData ToSaveData(this ResourceCost resourceCost)
	{
		if (resourceCost == null || resourceCost.GetAllCosts().Count == 0)
		{
			return null;
		}
		return new ResourceCostSaveData(resourceCost);
	}
}
