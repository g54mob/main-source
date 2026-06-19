using Unity.Entities;
using Unity.NetCode;

public struct MinionOwnerCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int minionCount;

	[GhostField]
	public TickTimer orbitTimer;

	[GhostField]
	public float smoothCount;
}
