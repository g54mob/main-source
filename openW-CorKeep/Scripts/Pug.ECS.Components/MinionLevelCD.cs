using Unity.Entities;
using Unity.NetCode;

public struct MinionLevelCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int value;
}
