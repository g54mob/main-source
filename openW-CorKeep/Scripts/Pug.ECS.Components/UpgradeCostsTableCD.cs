using Unity.Entities;

public struct UpgradeCostsTableCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<UpgradeCostsTableBlob> Value;

	public ref BlobArray<UpgradeCostBlob> GetUpgradeCost(int level)
	{
		if (Value.Value.upgradeCostsByLevel.Length > level)
		{
			return ref Value.Value.upgradeCostsByLevel[level].upgradeCosts;
		}
		return ref Value.Value.upgradeCostsByLevel[Value.Value.upgradeCostsByLevel.Length - 1].upgradeCosts;
	}
}
