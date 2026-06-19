using Unity.Entities;
using Unity.Physics;

public struct SwapColliderInternalCD : IComponentData, IQueryTypeParameter
{
	public bool hasSwapped;

	public BlobAssetReference<Collider> colliderRef;
}
