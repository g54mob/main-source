using Unity.Entities;
using Unity.Physics;

[InternalBufferCapacity(4)]
public struct PhysicsRotations : IBufferElementData
{
	public BlobAssetReference<Collider> Value;
}
