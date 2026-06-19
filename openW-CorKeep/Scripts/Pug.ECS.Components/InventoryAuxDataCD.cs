using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
public struct InventoryAuxDataCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int Index;
}
