using Unity.Entities;

public struct ExtractableCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<ExtractableData> extractableData;

	public BlobAssetReference<BlobArray<ExtractedObjectOutputElementData>> extractedObjectOutputArray;
}
