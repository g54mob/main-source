using Unity.Entities;

public struct SeasonalLootCD : IComponentData, IQueryTypeParameter
{
	public bool requirementToDropFulfilled;

	public BlobAssetReference<BlobArray<SeasonalLootInfo>> lootBlob;
}
