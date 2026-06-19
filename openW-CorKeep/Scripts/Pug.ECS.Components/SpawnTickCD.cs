using Unity.Entities;
using Unity.NetCode;

public struct SpawnTickCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public NetworkTick Value;
}
