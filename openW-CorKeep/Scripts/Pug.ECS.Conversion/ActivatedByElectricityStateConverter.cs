using Pug.Conversion;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

public class ActivatedByElectricityStateConverter : SingleAuthoringComponentConverter<ActivatedByElectricityStateAuthoring>
{
	protected override void Convert(ActivatedByElectricityStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		AddComponentData(new ActivatedByElectricityStateCD
		{
			activationTime = authoring.activationTime,
			deactivationTime = authoring.deactivationTime,
			changeVariationOnActivate = authoring.changeVariationOnActivate,
			variationToChangeTo = authoring.variationToChangeTo
		});
		if (authoring.changeColliderToTriggerWhenActivated)
		{
			Material material = Material.Default;
			material.CollisionResponse = CollisionResponsePolicy.None;
			BlobAssetReference<Collider> blobAsset = BoxCollider.Create(new BoxGeometry
			{
				Size = 1f,
				Orientation = quaternion.identity
			}, new CollisionFilter
			{
				BelongsTo = authoring.triggerBelongsTo.Value,
				CollidesWith = authoring.triggerCollidesWith.Value
			}, material);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			EnsureHasComponent<SwapColliderCD>();
			AddComponentData(new SwapColliderInternalCD
			{
				colliderRef = blobAsset
			});
		}
	}
}
