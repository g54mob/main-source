using Pug.Conversion;
using Unity.Entities;

public class GroundBouncableProjectileConverter : SingleAuthoringComponentConverter<GroundBouncableProjectileAuthoring>
{
	protected override void Convert(GroundBouncableProjectileAuthoring authoring)
	{
		BlobAssetReference<BlobCurve> blobAsset = BlobCurve.Create(authoring.verticalCurve);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		GroundBouncableProjectileCD component = new GroundBouncableProjectileCD
		{
			verticalCurve = blobAsset
		};
		AddComponentData(component);
	}
}
