using Unity.Entities;
using Unity.NetCode;

public struct VelocityAffectorCD : IComponentData, IQueryTypeParameter
{
	public int priority;

	public bool requiresElectricity;

	[GhostField]
	public int lastIndex;

	public BlobAssetReference<BlobArray<VelocityAffectorMoveOptionElementData>> moveOptions;
}
