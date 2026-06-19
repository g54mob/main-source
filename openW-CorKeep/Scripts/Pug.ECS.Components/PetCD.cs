using Unity.Entities;
using Unity.NetCode;

[GhostComponent]
public struct PetCD : IComponentData, IQueryTypeParameter
{
	public float happyAnimDuration;

	public bool isFlying;

	[GhostField]
	public int inventoryAuxDataIndex;

	public int maxSkins;

	public PetType petType;

	public bool buffsOwner => petType == PetType.Buff;
}
