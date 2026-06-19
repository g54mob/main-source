using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct BouncingProjectileCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int2 prevBounceTile;

	[GhostField]
	public int bounceCount;

	[GhostField]
	public int maxBounceCount;
}
