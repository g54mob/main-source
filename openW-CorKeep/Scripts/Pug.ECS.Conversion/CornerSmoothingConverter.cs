using Pug.Conversion;
using Unity.Entities;
using Unity.Physics;

public class CornerSmoothingConverter : SingleAuthoringComponentConverter<CornerSmoothingAuthoring>
{
	protected override void Convert(CornerSmoothingAuthoring authoring)
	{
		BlobAssetReference<CornerSmoothingData> smoothingData = CreateAndAddSimpleBlobAsset(new CornerSmoothingData
		{
			experimentalWallSmoothingEnabled = authoring.experimentalWallSmoothingEnabled,
			wallMovementBlend = authoring.wallMovementBlend,
			cornerMovementBlend = authoring.cornerMovementBlend,
			forwardSensorDistVertical = authoring.forwardSensorDistVertical,
			forwardSensorDistHorizontal = authoring.forwardSensorDistHorizontal,
			forwardSensorSize = authoring.forwardSensorSize,
			escapeSensorSpreadVertical = authoring.escapeSensorSpreadVertical,
			escapeSensorSpreadHorizontal = authoring.escapeSensorSpreadHorizontal,
			escapeSensorSizeVertical = authoring.escapeSensorSizeVertical,
			escapeSensorSizeHorizontal = authoring.escapeSensorSizeHorizontal
		});
		TryGetActiveComponent<PlayerAuthoring>(authoring, out var component);
		AddComponentData(new CornerSmoothingCD
		{
			smoothingData = smoothingData,
			cornerMovementBlendMultiplier = 1f,
			collisionFilter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = component.collisionCollider.CollidesWith.Value
			},
			boatCollisionFilter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = ((component.collisionCollider.CollidesWith.Value & 0xFFFDFFFFu) | 0x40000)
			}
		});
	}
}
