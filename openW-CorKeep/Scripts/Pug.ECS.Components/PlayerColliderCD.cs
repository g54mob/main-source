using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

public struct PlayerColliderCD : IComponentData, IQueryTypeParameter
{
	public float capsuleRadius;

	public float capsuleHeight;

	public float3 capsuleCenterOffset;

	public BlobAssetReference<Collider> defaultCollider;

	public BlobAssetReference<Collider> boatRidingCollider;
}
