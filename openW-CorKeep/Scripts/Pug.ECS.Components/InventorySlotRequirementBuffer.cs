using Unity.Collections;
using Unity.Entities;

[InternalBufferCapacity(0)]
public struct InventorySlotRequirementBuffer : IBufferElementData
{
	public bool requirementAppliesToAllSlots;

	public int inventoryIndex;

	public int slotIndex;

	public bool dontShowAnyHint;

	public bool showInfoText;

	public ulong acceptsObjectsWithTags;

	public FixedList32Bytes<ObjectID> acceptsObjectIds;

	public bool denyLegendaryRarity;
}
