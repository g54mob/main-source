using Unity.Entities;
using Unity.NetCode;

[InventoryAuxDataComponent]
[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct BreedToggleCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool breedingDisabled;
}
