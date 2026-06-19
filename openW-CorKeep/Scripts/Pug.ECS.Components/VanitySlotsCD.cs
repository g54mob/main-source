using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct VanitySlotsCD : IComponentData, IQueryTypeParameter
{
	public int helmVanitySlotIndex;

	public int breastVanitySlotIndex;

	public int pantsVanitySlotIndex;
}
