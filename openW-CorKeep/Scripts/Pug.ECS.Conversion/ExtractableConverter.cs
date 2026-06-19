using Pug.Conversion;
using Unity.Entities;

public class ExtractableConverter : SingleAuthoringComponentConverter<ExtractableAuthoring>
{
	protected override void Convert(ExtractableAuthoring authoring)
	{
		ExtractableData data = new ExtractableData
		{
			extractableType = ExtractableType.SpecificObject,
			craftingTimeOverride = authoring.craftingTimeOverride
		};
		BlobAssetReference<BlobArray<ExtractedObjectOutputElementData>> extractedObjectOutputArray = CreateAndAddSimpleBlobArrayAsset(authoring.extractedObject, (ExtractableAuthoring.ExtractableOutput extractedObjectOutput) => new ExtractedObjectOutputElementData
		{
			objectID = extractedObjectOutput.objectID,
			variation = extractedObjectOutput.variation,
			minMaxRandomAmountOverride = extractedObjectOutput.minMaxRandomAmountOverride
		});
		AddComponentData(new ExtractableCD
		{
			extractableData = CreateAndAddSimpleBlobAsset(data),
			extractedObjectOutputArray = extractedObjectOutputArray
		});
	}
}
