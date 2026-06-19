using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct ImmunityZoneCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public float radius;

	public float radiusSq;

	[GhostField]
	public bool removeImmunityZone;

	[GhostField]
	public int2 offset;

	[GhostField]
	public bool useRectangularBounds;

	[GhostField]
	public int rectangularWidth;

	[GhostField]
	public int rectangularHeight;
}
