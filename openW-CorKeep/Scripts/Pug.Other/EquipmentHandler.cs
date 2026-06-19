using System;
using System.Collections.Immutable;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class EquipmentHandler
{
	public readonly InventoryHandler helmInventoryHandler;

	public readonly InventoryHandler breastInventoryHandler;

	public readonly InventoryHandler pantsInventoryHandler;

	public readonly InventoryHandler necklaceInventoryHandler;

	public readonly InventoryHandler ring1InventoryHandler;

	public readonly InventoryHandler ring2InventoryHandler;

	public readonly InventoryHandler offHandInventoryHandler;

	public readonly InventoryHandler bagInventoryHandler;

	public readonly InventoryHandler petInventoryHandler;

	public readonly InventoryHandler lanternInventoryHandler;

	public readonly ImmutableArray<InventoryHandler> pouchInventoryHandlers;

	public readonly ImmutableArray<InventoryHandler> pouchInventorySlotsHandlers;

	private EntityMonoBehaviour entityMonoBehaviour;

	private Entity ownerEntity => entityMonoBehaviour.entity;

	private World world => entityMonoBehaviour.world;

	public EquipmentHandler(EntityMonoBehaviour entityMonoBehaviour, World world)
	{
		this.entityMonoBehaviour = entityMonoBehaviour;
		int value = EntityUtility.GetComponentData<ActiveEquipmentPresetCD>(ownerEntity, world).Value;
		EquipmentCD activeEquipment = GetActiveEquipment(value);
		PetOwnerCD componentData = EntityUtility.GetComponentData<PetOwnerCD>(ownerEntity, world);
		helmInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.helmSlotIndex, 1, 1);
		breastInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.breastSlotIndex, 1, 1);
		pantsInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.pantsSlotIndex, 1, 1);
		necklaceInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.necklaceSlotIndex, 1, 1);
		ring1InventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.ring1SlotIndex, 1, 1);
		ring2InventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.ring2SlotIndex, 1, 1);
		offHandInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.offHandIndex, 1, 1);
		bagInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.bagIndex, 1, 1);
		petInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, componentData.SlotIndex, 1, 1);
		lanternInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, activeEquipment.lanternIndex, 1, 1);
		InventoryHandler[] array = new InventoryHandler[4];
		for (int i = 0; i < 4; i++)
		{
			int pouchSlotIndex = activeEquipment.GetPouchSlotIndex(i);
			array[i] = new InventoryHandler(entityMonoBehaviour, world, pouchSlotIndex, 1, 1);
		}
		pouchInventoryHandlers = ImmutableArray.Create(array);
		InventoryHandler[] array2 = new InventoryHandler[4];
		for (int j = 0; j < 4; j++)
		{
			array2[j] = new InventoryHandler(entityMonoBehaviour, world, isBuyInventory: false, j + 1);
		}
		pouchInventorySlotsHandlers = ImmutableArray.Create(array2);
	}

	private EquipmentCD GetActiveEquipment(int activePreset)
	{
		DynamicBuffer<EquipmentPresetsBuffer> buffer = EntityUtility.GetBuffer<EquipmentPresetsBuffer>(ownerEntity, world);
		return buffer[math.clamp(activePreset, 0, buffer.Length)].equipment;
	}

	public void UpdateEquipmentPreset(int presetIndex)
	{
		EquipmentCD activeEquipment = GetActiveEquipment(presetIndex);
		helmInventoryHandler.SetStartPosInBuffer(activeEquipment.helmSlotIndex);
		breastInventoryHandler.SetStartPosInBuffer(activeEquipment.breastSlotIndex);
		pantsInventoryHandler.SetStartPosInBuffer(activeEquipment.pantsSlotIndex);
		necklaceInventoryHandler.SetStartPosInBuffer(activeEquipment.necklaceSlotIndex);
		ring1InventoryHandler.SetStartPosInBuffer(activeEquipment.ring1SlotIndex);
		ring2InventoryHandler.SetStartPosInBuffer(activeEquipment.ring2SlotIndex);
		offHandInventoryHandler.SetStartPosInBuffer(activeEquipment.offHandIndex);
	}

	public void FixAnyIssues()
	{
		ObjectDataCD objectData = offHandInventoryHandler.GetObjectData(0);
		PlayerController player = Manager.main.player;
		if (objectData.objectID != ObjectID.None && player != null)
		{
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectData.objectID);
			if (objectInfo != null && objectInfo.objectType == ObjectType.Lantern)
			{
				offHandInventoryHandler.MoveAllToOrDrop(player, 0, lanternInventoryHandler, entityMonoBehaviour.RenderPosition);
			}
		}
	}

	public bool HasNonBrokenGearPieceEquipped(ObjectID objectID)
	{
		if ((!helmInventoryHandler.HasObject(0, objectID) || PlayerController.ItemIsBroken(helmInventoryHandler.GetObjectData(0))) && (!breastInventoryHandler.HasObject(0, objectID) || PlayerController.ItemIsBroken(breastInventoryHandler.GetObjectData(0))) && (!pantsInventoryHandler.HasObject(0, objectID) || PlayerController.ItemIsBroken(pantsInventoryHandler.GetObjectData(0))) && !necklaceInventoryHandler.HasObject(0, objectID) && !ring1InventoryHandler.HasObject(0, objectID) && !ring2InventoryHandler.HasObject(0, objectID) && (!offHandInventoryHandler.HasObject(0, objectID) || PlayerController.ItemIsBroken(offHandInventoryHandler.GetObjectData(0))) && !bagInventoryHandler.HasObject(0, objectID) && !lanternInventoryHandler.HasObject(0, objectID) && !pouchInventoryHandlers[0].HasObject(0, objectID) && !pouchInventoryHandlers[1].HasObject(0, objectID) && !pouchInventoryHandlers[2].HasObject(0, objectID))
		{
			return pouchInventoryHandlers[3].HasObject(0, objectID);
		}
		return true;
	}

	public InventoryHandler[] getAllItemInventoryHandlers()
	{
		return new InventoryHandler[13]
		{
			Manager.main.player.equipmentHandler.bagInventoryHandler,
			Manager.main.player.equipmentHandler.breastInventoryHandler,
			Manager.main.player.equipmentHandler.helmInventoryHandler,
			Manager.main.player.equipmentHandler.lanternInventoryHandler,
			Manager.main.player.equipmentHandler.pantsInventoryHandler,
			Manager.main.player.equipmentHandler.necklaceInventoryHandler,
			Manager.main.player.equipmentHandler.ring1InventoryHandler,
			Manager.main.player.equipmentHandler.ring2InventoryHandler,
			Manager.main.player.equipmentHandler.offHandInventoryHandler,
			Manager.main.player.equipmentHandler.pouchInventoryHandlers[0],
			Manager.main.player.equipmentHandler.pouchInventoryHandlers[1],
			Manager.main.player.equipmentHandler.pouchInventoryHandlers[2],
			Manager.main.player.equipmentHandler.pouchInventoryHandlers[3]
		};
	}

	public void GetActiveArmorObjectIDs(ref NativeList<ObjectID> objectIDs)
	{
		GetActiveObjectID(ref objectIDs, helmInventoryHandler);
		GetActiveObjectID(ref objectIDs, breastInventoryHandler);
		GetActiveObjectID(ref objectIDs, pantsInventoryHandler);
	}

	public void GetActiveVisibleArmorObjectIDs(ref NativeList<ObjectID> objectIDs, PlayerController pc)
	{
		try
		{
			if (pc == null)
			{
				Debug.Log("EquipmentHandler.GetActiveVisibleArmorObjectIDs: player object is null. Aborting.");
				return;
			}
			ObjectDataCD objectData = pc.vanitySlotsHandler.helmVanitySlotInventoryHandler.GetObjectData(0);
			ObjectDataCD objectData2 = pc.vanitySlotsHandler.breastVanitySlotInventoryHandler.GetObjectData(0);
			ObjectDataCD objectData3 = pc.vanitySlotsHandler.pantsVanitySlotInventoryHandler.GetObjectData(0);
			if (objectData.objectID != ObjectID.None)
			{
				objectIDs.Add(in objectData.objectID);
			}
			else
			{
				GetActiveObjectID(ref objectIDs, breastInventoryHandler);
			}
			if (objectData2.objectID != ObjectID.None)
			{
				objectIDs.Add(in objectData2.objectID);
			}
			else
			{
				GetActiveObjectID(ref objectIDs, helmInventoryHandler);
			}
			if (objectData3.objectID != ObjectID.None)
			{
				objectIDs.Add(in objectData3.objectID);
			}
			else
			{
				GetActiveObjectID(ref objectIDs, pantsInventoryHandler);
			}
		}
		catch (NullReferenceException exception)
		{
			Debug.LogException(exception);
		}
	}

	private void GetActiveObjectID(ref NativeList<ObjectID> objectIDs, InventoryHandler inventoryHandler)
	{
		ObjectDataCD objectData = inventoryHandler.GetObjectData(0);
		if (objectData.amount > 0)
		{
			objectIDs.Add(in objectData.objectID);
		}
	}
}
