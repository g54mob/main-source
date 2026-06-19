using Unity.Entities;
using Unity.NetCode;

public struct MinionOrbitPosCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public float smoothIndex;

	[GhostField]
	public int index;
}
