using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryAuthoring : MonoBehaviour
{
	public int sizeX;

	public int sizeY;

	public int maxExtraSize;

	public bool canOnlyContainOneItemPerSlot;

	public bool objectsGetLockedInPlace;

	public bool cantAddObjectsToInventory;

	[FormerlySerializedAs("canBeUsedInNearbyCrafting")]
	public bool autoTransferEnabled;

	public List<SlotRequirement> slotRequirements;

	[FormerlySerializedAs("itemsInChest")]
	[ArrayElementTitle("objectID")]
	public List<ObjectData> itemsInInventory;

	public LootTableID addLootFromTable;

	private void OnValidate()
	{
		if (sizeX * sizeY + maxExtraSize == 1 && slotRequirements.Count > 0 && !slotRequirements[0].requirementAppliesToAllSlots)
		{
			slotRequirements[0].requirementAppliesToAllSlots = true;
			Debug.Log("requirementAppliesToAllSlots will be true when there's only one slot in the inventory.");
		}
		for (int i = 0; i < slotRequirements.Count; i++)
		{
			SlotRequirement slotRequirement = slotRequirements[i];
			if (slotRequirement.acceptsObjectIds.Count > 7)
			{
				slotRequirement.acceptsObjectIds.RemoveRange(7, slotRequirement.acceptsObjectIds.Count - 7);
				Debug.Log("Can't have more than 7 object id's as requirement on a slot. You should probably use object tags instead.");
			}
			if (slotRequirement.acceptsObjectIds.Count > 0 && slotRequirement.acceptsObjectsWithTags.Count > 0)
			{
				slotRequirement.acceptsObjectsWithTags = new List<ObjectCategoryTag>();
				Debug.Log("You can't have requirements on both object id's and tags. Removing tags requirements.");
			}
			if (slotRequirement.requirementAppliesToAllSlots && slotRequirements.Count > 1)
			{
				Debug.Log("Can't have requirements that applies to all slots while also having individual requirements per slot.");
				slotRequirement.requirementAppliesToAllSlots = false;
			}
			if (slotRequirements.Count > sizeX * sizeY + maxExtraSize)
			{
				Debug.Log("Can't have more requirements than amount of slots.");
				int num = sizeX * sizeY + maxExtraSize;
				slotRequirements.RemoveRange(num, slotRequirements.Count - num);
				break;
			}
		}
	}

	public static bool HasNonSupportedInventoryOverride(InventoryAuthoring overriddenInventoryAuthoring, InventoryAuthoring prefabInventoryAuthoring)
	{
		if (overriddenInventoryAuthoring.slotRequirements.Count != prefabInventoryAuthoring.slotRequirements.Count)
		{
			return true;
		}
		for (int i = 0; i < overriddenInventoryAuthoring.slotRequirements.Count; i++)
		{
			SlotRequirement slotRequirement = overriddenInventoryAuthoring.slotRequirements[i];
			SlotRequirement other = prefabInventoryAuthoring.slotRequirements[i];
			if (!slotRequirement.Equals(other))
			{
				return true;
			}
		}
		if (overriddenInventoryAuthoring.sizeX == prefabInventoryAuthoring.sizeX && overriddenInventoryAuthoring.sizeY == prefabInventoryAuthoring.sizeY && overriddenInventoryAuthoring.maxExtraSize == prefabInventoryAuthoring.maxExtraSize && overriddenInventoryAuthoring.canOnlyContainOneItemPerSlot == prefabInventoryAuthoring.canOnlyContainOneItemPerSlot && overriddenInventoryAuthoring.objectsGetLockedInPlace == prefabInventoryAuthoring.objectsGetLockedInPlace)
		{
			return overriddenInventoryAuthoring.cantAddObjectsToInventory != prefabInventoryAuthoring.cantAddObjectsToInventory;
		}
		return true;
	}

	public static bool HasLootTableOverride(InventoryAuthoring inventoryAuthoring, InventoryAuthoring prefabInventoryAuthoring)
	{
		return inventoryAuthoring.addLootFromTable != prefabInventoryAuthoring.addLootFromTable;
	}

	public static bool HasLootItemOverride(InventoryAuthoring inventoryAuthoring, InventoryAuthoring prefabInventoryAuthoring)
	{
		if (inventoryAuthoring.itemsInInventory.Count != prefabInventoryAuthoring.itemsInInventory.Count)
		{
			return true;
		}
		for (int i = 0; i < inventoryAuthoring.itemsInInventory.Count; i++)
		{
			ObjectData objectData = inventoryAuthoring.itemsInInventory[i];
			ObjectData objectData2 = prefabInventoryAuthoring.itemsInInventory[i];
			if (objectData.objectID != objectData2.objectID || objectData.amount != objectData2.amount || objectData.variation != objectData2.variation)
			{
				return true;
			}
		}
		return false;
	}
}
