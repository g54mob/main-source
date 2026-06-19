using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
public struct WallBossHeadRefCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity headEntity;
}
