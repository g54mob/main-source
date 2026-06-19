using Unity.Entities;

public struct UpgradeCostsTableBlob
{
	public BlobArray<UpgradeCostPerLevelBlob> upgradeCostsByLevel;
}
