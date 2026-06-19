using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct SnakeSegmentCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int groupIndex;

	[GhostField]
	public int index;
}
