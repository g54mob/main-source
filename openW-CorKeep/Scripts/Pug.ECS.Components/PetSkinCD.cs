using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
[InventoryAuxDataComponent]
public struct PetSkinCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int skinIndex;
}
