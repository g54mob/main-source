using Unity.Entities;
using Unity.NetCode;

public struct ZigZagProjectileCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer timer;
}
