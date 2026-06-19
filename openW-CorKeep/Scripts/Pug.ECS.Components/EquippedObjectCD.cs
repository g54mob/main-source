using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct EquippedObjectCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int equippedSlotIndex;

	[GhostField]
	public ContainedObjectsBuffer containedObject;

	public Entity equipmentPrefab;

	public bool isBroken;
}
