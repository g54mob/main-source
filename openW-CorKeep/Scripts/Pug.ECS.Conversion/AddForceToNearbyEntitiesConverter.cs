using Pug.Conversion;
using Unity.Entities;

public class AddForceToNearbyEntitiesConverter : SingleAuthoringComponentConverter<AddForceToNearbyEntitiesAuthoring>
{
	protected override void Convert(AddForceToNearbyEntitiesAuthoring authoring)
	{
		BlobAssetReference<BlobCurve> blobAsset = BlobCurve.Create(authoring.activeForceMultiplierCurve);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		AddComponentData(new AddForceToNearbyEntitiesCD
		{
			radiusSq = authoring.radius * authoring.radius,
			force = authoring.force,
			activeForceMultiplierCurve = blobAsset,
			checkLineOfSight = authoring.checkLineOfSight,
			forceDuringActivation = authoring.forceDuringActivation,
			activationDelay = authoring.activationDelay,
			activeDuration = authoring.activeDuration,
			inactiveDuration = authoring.inactiveDuration
		});
	}
}
