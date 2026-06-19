using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
public struct WallBossHeadCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity mainEntity;
}
