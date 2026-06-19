using Inventory;
using PlayerEquipment;
using Unity.Entities;

public class EquipGearSlot : EquipmentSlot
{
	private const float SWAP_COOLDOWN = 1f;

	protected override EquipmentSlotType slotType => EquipmentSlotType.EquipGearSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		bool isBroken = equipmentUpdateAspect.equippedObjectCD.ValueRO.isBroken;
		if (!secondInteractHeld || isBroken)
		{
			return false;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		if (equipmentUpdateLookupData.objectDataLookup.TryGetComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
		{
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(componentData.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
			int equippedSlotIndex = equipmentUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex;
			int num = -1;
			switch (entityObjectInfo.objectType)
			{
			case ObjectType.Helm:
				num = equipmentUpdateAspect.equipmentCD.ValueRO.helmSlotIndex;
				break;
			case ObjectType.BreastArmor:
				num = equipmentUpdateAspect.equipmentCD.ValueRO.breastSlotIndex;
				break;
			case ObjectType.PantsArmor:
				num = equipmentUpdateAspect.equipmentCD.ValueRO.pantsSlotIndex;
				break;
			case ObjectType.Necklace:
				num = equipmentUpdateAspect.equipmentCD.ValueRO.necklaceSlotIndex;
				break;
			case ObjectType.Lantern:
				num = equipmentUpdateAspect.equipmentCD.ValueRO.lanternIndex;
				break;
			case ObjectType.Pet:
				num = equipmentUpdateAspect.petOwnerCD.ValueRO.SlotIndex;
				break;
			case ObjectType.Bag:
				num = equipmentUpdateAspect.equipmentCD.ValueRO.bagIndex;
				break;
			case ObjectType.Offhand:
				num = equipmentUpdateAspect.equipmentCD.ValueRO.offHandIndex;
				break;
			case ObjectType.Pouch:
			{
				num = equipmentUpdateAspect.equipmentCD.ValueRO.pouch1Index;
				equipmentUpdateLookupData.containedObjectsBufferLookup.TryGetBuffer(equipmentUpdateAspect.entity, out var bufferData2);
				for (int i = 0; i < 4; i++)
				{
					int pouchSlotIndex = equipmentUpdateAspect.equipmentCD.ValueRO.GetPouchSlotIndex(i);
					if (bufferData2[pouchSlotIndex].objectID == ObjectID.None)
					{
						num = pouchSlotIndex;
						break;
					}
				}
				break;
			}
			case ObjectType.Ring:
			{
				equipmentUpdateLookupData.containedObjectsBufferLookup.TryGetBuffer(equipmentUpdateAspect.entity, out var bufferData);
				int ring1SlotIndex = equipmentUpdateAspect.equipmentCD.ValueRO.ring1SlotIndex;
				int ring2SlotIndex = equipmentUpdateAspect.equipmentCD.ValueRO.ring2SlotIndex;
				bool num2 = bufferData[ring1SlotIndex].objectID == ObjectID.None;
				bool flag = bufferData[ring2SlotIndex].objectID == ObjectID.None;
				num = ((!num2) ? ((!flag && bufferData[ring1SlotIndex].objectID != componentData.objectID) ? ring1SlotIndex : ring2SlotIndex) : ring1SlotIndex);
				break;
			}
			}
			if (num == -1)
			{
				return false;
			}
			Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
			if (equipmentUpdateLookupData.cooldownLookup.HasComponent(equipmentPrefab))
			{
				float cooldownTime = 1f;
				if (equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity))
				{
					cooldownTime = 0.15f;
				}
				EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect.equippedObjectCD.ValueRO, ref equipmentUpdateAspect.playerAttackCooldownCD.ValueRW, equipmentUpdateAspect.syncedSharedCooldownTimers, equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate, in equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.cooldownLookup, cooldownTime);
			}
			equipmentUpdateLookupData.inventoryUpdateBuffer[equipmentUpdateSharedData.inventoryUpdateBufferEntity].Add(new InventoryChangeBuffer
			{
				inventoryChangeData = Create.Swap(equipmentUpdateAspect.entity, equipmentUpdateAspect.entity, equippedSlotIndex, num)
			});
			return true;
		}
		return false;
	}
}
