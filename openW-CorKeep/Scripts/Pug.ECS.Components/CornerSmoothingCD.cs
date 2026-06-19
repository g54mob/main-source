using Unity.Entities;
using Unity.NetCode;
using Unity.Physics;

[GhostComponent(SendTypeOptimization = GhostSendType.OnlyPredictedClients)]
public struct CornerSmoothingCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<CornerSmoothingData> smoothingData;

	[GhostField]
	public float cornerMovementBlendMultiplier;

	public CollisionFilter collisionFilter;

	public CollisionFilter boatCollisionFilter;
}
