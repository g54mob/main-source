using Unity.Entities;

[AssumeReadOnly]
public struct LootTableBankCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<LootTableBankBlob> Value;
}
