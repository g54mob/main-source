using Unity.Entities;

[TypeManager.ForcedMemoryOrdering(2837500352478684416uL)]
[TypeManager.OverrideTypeHash(10566025800295907343uL)]
public struct WorldGenerationParametersSerializedCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<BlobByteArray> PackedJsonData;
}
