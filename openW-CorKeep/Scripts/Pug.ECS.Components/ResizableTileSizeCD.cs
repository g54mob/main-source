using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ResizableTileSizeCD : IComponentData, IQueryTypeParameter
{
	public bool StartOnSmallestSize;
}
