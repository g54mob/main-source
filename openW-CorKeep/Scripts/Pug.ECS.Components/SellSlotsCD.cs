using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct SellSlotsCD : IComponentData, IQueryTypeParameter
{
	public int startIndex;

	public int sizeX;

	public int sizeY;
}
