using Unity.Entities;
using Unity.NetCode;

public struct PetOwnerCD : IComponentData, IQueryTypeParameter
{
	public int SlotIndex;

	[GhostField]
	public Entity PetEntity;

	public bool AllowPetToSpawn;
}
