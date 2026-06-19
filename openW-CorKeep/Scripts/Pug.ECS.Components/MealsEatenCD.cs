using Unity.Entities;
using Unity.NetCode;

[InventoryAuxDataComponent]
[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MealsEatenCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int Value;
}
