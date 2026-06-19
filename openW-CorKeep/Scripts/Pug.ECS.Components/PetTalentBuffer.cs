using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
[InventoryAuxDataComponent]
[InternalBufferCapacity(9)]
public struct PetTalentBuffer : IBufferElementData
{
	[GhostField]
	public PetTalent petTalentID;

	[GhostField]
	public int points;
}
