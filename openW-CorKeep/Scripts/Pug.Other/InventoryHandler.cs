using System.Collections.Generic;
using Inventory;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class InventoryHandler
{
	public struct InventoryRequestData
	{
		public Entity inventoryEntity;

		public DynamicBuffer<InventoryChangeBuffer> inventoryUpdateBuffer;
	}

	public int size;

	public int maxSize;

	public int startPosInBuffer;

	private const string desc = "Desc";

	public int columns { get; private set; }

	public EntityMonoBehaviour entityMonoBehaviour { get; private set; }

	private World world => entityMonoBehaviour.world;

	public Entity inventoryEntity => entityMonoBehaviour.entity;

	public bool canOnlyContainOneItemPerSlot { get; private set; }

	public bool objectsGetLockedInPlace { get; private set; }

	public bool cantAddObjectsToInventory { get; private set; }

	public bool isBuyInventory { get; private set; }

	public int inventoryIndex { get; private set; }

	public bool treatAsAllInventoriesForTransfer { get; set; }

	public InventoryHandler(EntityMonoBehaviour entityMonoBehaviour, World world, bool isBuyInventory = false, int inventoryIndex = 0, bool treatAsAllInventoriesForTransfer = false)
	{
		this.entityMonoBehaviour = entityMonoBehaviour;
		if (EntityUtility.HasComponentData<InventoryBuffer>(inventoryEntity, world))
		{
			InventoryBuffer inventoryBuffer = EntityUtility.GetBuffer<InventoryBuffer>(inventoryEntity, world)[inventoryIndex];
			columns = inventoryBuffer.sizeX;
			size = inventoryBuffer.size;
			startPosInBuffer = inventoryBuffer.startIndex;
			maxSize = inventoryBuffer.maxSize;
			canOnlyContainOneItemPerSlot = inventoryBuffer.canOnlyContainOneItemPerSlot;
			objectsGetLockedInPlace = inventoryBuffer.objectsGetLockedInPlace;
			cantAddObjectsToInventory = inventoryBuffer.cantAddObjectsToInventory;
		}
		else if (EntityUtility.HasComponentData<VendingMachineCD>(inventoryEntity, world))
		{
			VendingMachineCD componentData = EntityUtility.GetComponentData<VendingMachineCD>(inventoryEntity, world);
			columns = componentData.sizeX;
			size = componentData.size;
			maxSize = componentData.size;
		}
		this.isBuyInventory = isBuyInventory;
		this.inventoryIndex = inventoryIndex;
		this.treatAsAllInventoriesForTransfer = treatAsAllInventoriesForTransfer;
	}

	public InventoryHandler(EntityMonoBehaviour entityMonoBehaviour, World world, int startPosInBuffer, int columns, int size)
	{
		this.entityMonoBehaviour = entityMonoBehaviour;
		this.startPosInBuffer = startPosInBuffer;
		InventoryBuffer inventoryBuffer = EntityUtility.GetBuffer<InventoryBuffer>(inventoryEntity, world)[0];
		this.columns = columns;
		maxSize = (this.size = size);
		canOnlyContainOneItemPerSlot = inventoryBuffer.canOnlyContainOneItemPerSlot;
		objectsGetLockedInPlace = inventoryBuffer.objectsGetLockedInPlace;
		cantAddObjectsToInventory = inventoryBuffer.cantAddObjectsToInventory;
	}

	public void UpdateSize(int inventoryIndex)
	{
		if (EntityUtility.HasComponentData<InventoryBuffer>(inventoryEntity, world))
		{
			InventoryBuffer inventoryBuffer = EntityUtility.GetBuffer<InventoryBuffer>(inventoryEntity, world)[inventoryIndex];
			size = inventoryBuffer.size;
			maxSize = inventoryBuffer.maxSize;
		}
	}

	public void SetStartPosInBuffer(int index)
	{
		startPosInBuffer = index;
	}

	private static void RegisterRequest(in InventoryChangeData inventoryChangeData, in InventoryRequestData inventoryRequestData)
	{
		inventoryRequestData.inventoryUpdateBuffer.Add(new InventoryChangeBuffer
		{
			playerEntity = inventoryRequestData.inventoryEntity,
			inventoryChangeData = inventoryChangeData
		});
	}

	public ObjectDataCD GetObjectData(int index)
	{
		return GetContainedObjectData(index).objectData;
	}

	public static ObjectDataCD GetObjectData(int index, Entity inventoryEntity, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<VendingMachineItemBuffer> vendingMachineItemBufferLookup)
	{
		return GetContainedObjectData(index, inventoryEntity, containedObjectsBufferLookup, vendingMachineItemBufferLookup).objectData;
	}

	public ContainedObjectsBuffer GetContainedObjectData(int index)
	{
		ContainedObjectsBuffer result = default(ContainedObjectsBuffer);
		int num = startPosInBuffer + index;
		DynamicBuffer<VendingMachineItemBuffer> value2;
		if (EntityUtility.TryGetBuffer(inventoryEntity, world, out DynamicBuffer<ContainedObjectsBuffer> value))
		{
			if (num < value.Length)
			{
				return value[num];
			}
		}
		else if (EntityUtility.TryGetBuffer(inventoryEntity, world, out value2) && num < value2.Length)
		{
			return new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = value2[num].objectID,
					amount = 1
				}
			};
		}
		return result;
	}

	public static ContainedObjectsBuffer GetContainedObjectData(int index, Entity inventoryEntity, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<VendingMachineItemBuffer> vendingMachineItemBufferLookup)
	{
		ContainedObjectsBuffer result = default(ContainedObjectsBuffer);
		DynamicBuffer<VendingMachineItemBuffer> bufferData2;
		if (containedObjectsBufferLookup.TryGetBuffer(inventoryEntity, out var bufferData))
		{
			if (index < bufferData.Length)
			{
				return bufferData[index];
			}
		}
		else if (vendingMachineItemBufferLookup.TryGetBuffer(inventoryEntity, out bufferData2) && index < bufferData2.Length)
		{
			return new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = bufferData2[index].objectID,
					amount = 1
				}
			};
		}
		return result;
	}

	public bool HasObject(int index)
	{
		return GetContainedObjectData(index).objectID != ObjectID.None;
	}

	public static bool HasObject(int index, Entity inventoryEntity, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<VendingMachineItemBuffer> vendingMachineItemBufferLookup)
	{
		return GetContainedObjectData(index, inventoryEntity, containedObjectsBufferLookup, vendingMachineItemBufferLookup).objectID != ObjectID.None;
	}

	public bool HasObject(int index, ObjectID objectID)
	{
		return GetContainedObjectData(index).objectID == objectID;
	}

	public bool IsLockedObject(int index)
	{
		int num = startPosInBuffer + index;
		if (EntityUtility.TryGetBuffer(inventoryEntity, world, out DynamicBuffer<LockedObjectsBuffer> value) && num < value.Length)
		{
			return value[num].Value;
		}
		return false;
	}

	public void DestroyObject(PlayerController playerController, int index, ObjectID objectID)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.DestroyObjectAt(inventoryEntity, startPosInBuffer + index, objectID)
		});
	}

	public void DestroyObjects(PlayerController playerController, int startIndex, int endIndex)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.DestroyObjects(inventoryEntity, startPosInBuffer + startIndex, startPosInBuffer + endIndex)
		});
	}

	public void CraftItem(PlayerController playerController, ObjectID objectID, int amount, int additionalFreeAmount)
	{
		if (Manager.ui.craftingMaterialsAreNotRequired)
		{
			additionalFreeAmount += amount;
			amount = 0;
		}
		Entity craftingEntity = playerController.activeCraftingHandler?.craftingEntity ?? playerController.entity;
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.Craft,
			craftActionData = Create.Craft(objectID, amount, additionalFreeAmount, playerController.entity, craftingEntity)
		});
	}

	public void SetAmount(PlayerController playerController, int index, ObjectID objectID, int amount)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.SetAmount(inventoryEntity, startPosInBuffer + index, objectID, amount)
		});
	}

	public static void SetAmount(int index, ObjectID objectID, int amount, in InventoryRequestData inventoryRequestData)
	{
		RegisterRequest(Create.SetAmount(inventoryRequestData.inventoryEntity, index, objectID, amount), in inventoryRequestData);
	}

	public static void SetVariation(int index, ObjectID objectID, int variation, in InventoryRequestData inventoryRequestData)
	{
		RegisterRequest(Create.SetVariation(inventoryRequestData.inventoryEntity, index, objectID, variation), in inventoryRequestData);
	}

	public void DropItem(PlayerController playerController, int index, Vector3 worldPosition, Entity blockImmediatePickFor = default(Entity))
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.DropAllItemsAt(inventoryEntity, startPosInBuffer + index, worldPosition, blockImmediatePickFor)
		});
	}

	public void DropItem(PlayerController playerController, int index, int amount, Vector3 worldPosition, Entity blockImmediatePickFor = default(Entity))
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.DropItem(inventoryEntity, startPosInBuffer + index, amount, worldPosition, blockImmediatePickFor)
		});
	}

	public void DropAllItemsWithRandomOffset(PlayerController playerController, Vector3 renderPosition, Entity blockImmediatePickFor = default(Entity))
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.DropAllItems(inventoryEntity, EntityMonoBehaviour.ToWorldFromRender(renderPosition), blockImmediatePickFor, randomOffset: true)
		});
	}

	public bool CanPlaceInSlot(ObjectDataCD objectData, int slotIndex)
	{
		int amount = 0;
		bool isStackable = PugDatabase.GetObjectInfo(objectData.objectID, objectData.variation)?.isStackable ?? false;
		DynamicBuffer<ContainedObjectsBuffer> buffer = EntityUtility.GetBuffer<ContainedObjectsBuffer>(inventoryEntity, world);
		return CanPlaceInSlot(objectData, buffer[startPosInBuffer + slotIndex].objectData, isStackable, ref amount);
	}

	private static bool CanPlaceInSlot(ObjectDataCD objectData, ObjectDataCD slot, bool isStackable, ref int amount)
	{
		bool result = slot.objectID == ObjectID.None || (slot.Equals(objectData) && isStackable && slot.amount < 9999);
		amount = math.min(objectData.amount, amount);
		amount = math.min(amount, 9999 - slot.amount);
		return result;
	}

	public bool HasRoomForObject(PlayerController playerController, ContainedObjectsBuffer containedObject)
	{
		PugDatabase.DatabaseBankCD singleton = playerController.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = EntityUtility.GetBuffer<ContainedObjectsBuffer>(inventoryEntity, world);
		DynamicBuffer<InventoryBuffer> buffer = EntityUtility.GetBuffer<InventoryBuffer>(inventoryEntity, world);
		DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotRequirementBuffer = EntityUtility.GetBuffer<InventorySlotRequirementBuffer>(inventoryEntity, world);
		ComponentLookup<ObjectCategoryTagsCD> componentLookup = playerController.querySystem.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObject.objectID, singleton.databaseBankBlob, containedObject.variation);
		ComponentLookup<OverrideLegendaryForSlotRequirementsCD> componentLookup2 = playerController.querySystem.GetComponentLookup<OverrideLegendaryForSlotRequirementsCD>(isReadOnly: true);
		int firstPos;
		return InventoryUtility.HasRoomForObject(containedObject, primaryPrefabEntity, 0, out firstPos, componentLookup, in containedObjectsBuffer, in inventorySlotRequirementBuffer, componentLookup2, startPosInBuffer, size, canOnlyContainOneItemPerSlot, singleton, buffer);
	}

	public bool IsEmpty()
	{
		DynamicBuffer<ContainedObjectsBuffer> buffer = EntityUtility.GetBuffer<ContainedObjectsBuffer>(inventoryEntity, world);
		int num = startPosInBuffer + size;
		for (int i = startPosInBuffer; i < num; i++)
		{
			if (buffer[i].objectID != ObjectID.None)
			{
				return false;
			}
		}
		return true;
	}

	public int GetExistingAmountOfObject(ObjectID objectID)
	{
		int num = 0;
		DynamicBuffer<ContainedObjectsBuffer> buffer = EntityUtility.GetBuffer<ContainedObjectsBuffer>(inventoryEntity, world);
		int num2 = startPosInBuffer + size;
		for (int i = startPosInBuffer; i < num2; i++)
		{
			if (buffer[i].objectID == objectID)
			{
				num += buffer[i].amount;
			}
		}
		return num;
	}

	public void MoveAllToOrDrop(PlayerController playerController, int indexFrom, InventoryHandler other, Vector3 renderPosition, int indexToHint = -1)
	{
		int num = ((indexToHint != -1 || other.startPosInBuffer == 0) ? indexToHint : 0);
		int endIndex = (other.treatAsAllInventoriesForTransfer ? (-1) : (other.startPosInBuffer + other.size));
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.MoveOrDropItem(inventoryEntity, startPosInBuffer + indexFrom, other.inventoryEntity, other.startPosInBuffer + num, endIndex, EntityMonoBehaviour.ToWorldFromRender(renderPosition))
		});
	}

	public void MoveAllToOrDropIgnoreGuestMode(PlayerController playerController, int indexFrom, InventoryHandler other, Vector3 renderPosition, int indexToHint = -1)
	{
		int num = ((indexToHint != -1 || other.startPosInBuffer == 0) ? indexToHint : 0);
		int endIndex = (other.treatAsAllInventoriesForTransfer ? (-1) : (other.startPosInBuffer + other.size));
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.MoveOrDropItemIgnoreGuestMode(inventoryEntity, startPosInBuffer + indexFrom, other.inventoryEntity, other.startPosInBuffer + num, endIndex, EntityMonoBehaviour.ToWorldFromRender(renderPosition))
		});
	}

	public void MoveOrDropItems(PlayerController playerController, InventoryHandler other, Vector3 renderPosition)
	{
		int fromEndIndex = (treatAsAllInventoriesForTransfer ? (-1) : (startPosInBuffer + size));
		int toEndIndex = (other.treatAsAllInventoriesForTransfer ? (-1) : (other.startPosInBuffer + other.size));
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.MoveOrDropItems(inventoryEntity, startPosInBuffer, fromEndIndex, other.inventoryEntity, other.startPosInBuffer, toEndIndex, EntityMonoBehaviour.ToWorldFromRender(renderPosition))
		});
	}

	public void TryMoveTo(PlayerController playerController, int indexFrom, InventoryHandler other, int indexToHint = -1, int amount = int.MaxValue)
	{
		int endIndex = (other.treatAsAllInventoriesForTransfer ? (-1) : (other.startPosInBuffer + other.size));
		int num = ((indexToHint != -1 || other.startPosInBuffer == 0) ? indexToHint : 0);
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.MoveAmount(inventoryEntity, startPosInBuffer + indexFrom, other.inventoryEntity, other.startPosInBuffer + num, endIndex, amount, destroyExisting: false)
		});
	}

	public void MoveTo(PlayerController playerController, int indexFrom, InventoryHandler other, int amount = 1, int indexToHint = -1, bool destroyExisting = false)
	{
		int endIndex = (other.treatAsAllInventoriesForTransfer ? (-1) : (other.startPosInBuffer + other.size));
		int num = ((indexToHint != -1 || other.startPosInBuffer == 0) ? indexToHint : 0);
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.MoveAmount(inventoryEntity, startPosInBuffer + indexFrom, other.inventoryEntity, other.startPosInBuffer + num, endIndex, amount, destroyExisting)
		});
	}

	public void MoveToAndDestroyAnyExisting(PlayerController playerController, int indexFrom, InventoryHandler other, int indexTo)
	{
		MoveTo(playerController, indexFrom, other, int.MaxValue, indexTo);
	}

	public void Swap(PlayerController playerController, int index, InventoryHandler other, int otherIndex)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.Swap(inventoryEntity, other.inventoryEntity, startPosInBuffer + index, other.startPosInBuffer + otherIndex)
		});
	}

	public int GetCoinValueAll(PlayerController playerController, bool buy)
	{
		int num = 0;
		for (int i = 0; i < size; i++)
		{
			num += GetCoinValue(playerController, buy, i);
		}
		return num;
	}

	public int GetCoinValue(PlayerController playerController, bool buy, int index)
	{
		ObjectDataCD objectData = GetObjectData(index);
		PugDatabase.DatabaseBankCD singleton = playerController.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		UpgradeCostsTableCD singleton2 = playerController.querySystem.GetSingleton<UpgradeCostsTableCD>();
		ComponentLookup<CantBeSoldCD> componentLookup = playerController.querySystem.GetComponentLookup<CantBeSoldCD>(isReadOnly: true);
		ComponentLookup<CookedFoodCD> componentLookup2 = playerController.querySystem.GetComponentLookup<CookedFoodCD>(isReadOnly: true);
		ComponentLookup<ObjectCategoryTagsCD> componentLookup3 = playerController.querySystem.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
		ComponentLookup<LevelCD> componentLookup4 = playerController.querySystem.GetComponentLookup<LevelCD>(isReadOnly: true);
		return InventoryUtility.GetCoinValue(singleton, singleton2, componentLookup, componentLookup2, componentLookup3, componentLookup4, objectData, buy);
	}

	public void SellAll(PlayerController playerController, float3 renderPosition)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.SellAll(startPosInBuffer, size, EntityMonoBehaviour.ToWorldFromRender(renderPosition), inventoryEntity)
		});
	}

	public void Buy(PlayerController playerController, InventoryHandler other, int index)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.Buy(other.inventoryEntity, other.startPosInBuffer + index, inventoryEntity, startPosInBuffer, size)
		});
	}

	public bool CanSalvageAnyItem()
	{
		bool result = false;
		for (int i = 0; i < size; i++)
		{
			if (CanSalvage(i))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public void SalvageAll(PlayerController playerController, InventoryHandler other, float3 renderPosition)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.SalvageAll(inventoryEntity, other.inventoryEntity, EntityMonoBehaviour.ToWorldFromRender(renderPosition), startPosInBuffer, size)
		});
	}

	private bool CanSalvage(int index)
	{
		bool num = HasObject(index);
		ObjectDataCD objectData = (num ? GetObjectData(index) : default(ObjectDataCD));
		ObjectInfo objectInfo = null;
		if (num)
		{
			objectInfo = PugDatabase.GetObjectInfo(objectData.objectID, objectData.variation);
		}
		if (objectInfo != null)
		{
			if (PugDatabase.HasComponent<LevelEntitiesBuffer>(objectData) || objectInfo.tags.Contains(ObjectCategoryTag.CanBeSalvaged))
			{
				return objectInfo.rarity != Rarity.Legendary;
			}
			return false;
		}
		return false;
	}

	public void QuickStack(PlayerController playerController, InventoryHandler other)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.QuickStack(inventoryEntity, other.inventoryEntity)
		});
	}

	public void Sort(PlayerController playerController, bool isPlayerInventory)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.Sort(inventoryEntity, isPlayerInventory)
		});
	}

	public void QuickStackToNearbyChests(PlayerController playerController)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.QuickStackToNearbyChests(inventoryEntity)
		});
	}

	public void ToggleLock(PlayerController playerController, int index)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.ToggleLock(inventoryEntity, index + startPosInBuffer)
		});
	}

	public bool ShouldShowErrorWhenTryingToPlaceInInventory(ObjectDataCD objectData, int slotIndex)
	{
		return !ObjectIsValidToPutInInventory(objectData.objectID, slotIndex);
	}

	public bool HasValidInventorySlotRequirementBuffer()
	{
		return EntityUtility.HasComponentData<InventorySlotRequirementBuffer>(inventoryEntity, world);
	}

	public List<InventorySlotRequirementBuffer> GetInventoryRequirements()
	{
		List<InventorySlotRequirementBuffer> list = new List<InventorySlotRequirementBuffer>();
		if (EntityUtility.TryGetBuffer(inventoryEntity, world, out DynamicBuffer<InventorySlotRequirementBuffer> value))
		{
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i].inventoryIndex == inventoryIndex)
				{
					list.Add(value[i]);
				}
			}
		}
		return list;
	}

	public List<ObjectCategoryTag> GetInventoryRequirementTags()
	{
		List<InventorySlotRequirementBuffer> inventoryRequirements = GetInventoryRequirements();
		if (inventoryRequirements.Count > 0)
		{
			return ObjectCategoryTagsCD.ConvertToList(inventoryRequirements[0].acceptsObjectsWithTags);
		}
		return null;
	}

	public bool ObjectIsValidToPutInInventory(ObjectID objectID, int checkSpecificIndexOnly = -1)
	{
		DynamicBuffer<InventorySlotRequirementBuffer> buffer = EntityUtility.GetBuffer<InventorySlotRequirementBuffer>(inventoryEntity, world);
		DynamicBuffer<InventoryBuffer> buffer2 = EntityUtility.GetBuffer<InventoryBuffer>(inventoryEntity, world);
		ObjectCategoryTagsCD objectTagCD = (PugDatabase.HasComponent<ObjectCategoryTagsCD>(objectID) ? PugDatabase.GetComponent<ObjectCategoryTagsCD>(objectID) : default(ObjectCategoryTagsCD));
		PugDatabase.DatabaseBankCD singleton = world.GetExistingSystemManaged<PugQuerySystem>().GetSingleton<PugDatabase.DatabaseBankCD>();
		ComponentLookup<OverrideLegendaryForSlotRequirementsCD> componentLookup = world.GetExistingSystemManaged<PugQuerySystem>().GetComponentLookup<OverrideLegendaryForSlotRequirementsCD>(isReadOnly: true);
		int indexFulfillingRequirements;
		return InventoryUtility.ObjectIsValidToPutInInventory(buffer, objectTagCD, objectID, buffer2, componentLookup, out indexFulfillingRequirements, singleton, startPosInBuffer + checkSpecificIndexOnly);
	}

	public TextAndFormatFields GetAnyRequirementInfoText(int slotIndex, bool getDesc = false)
	{
		List<ObjectCategoryTag> list = null;
		slotIndex += startPosInBuffer;
		if (EntityUtility.TryGetBuffer(inventoryEntity, world, out DynamicBuffer<InventorySlotRequirementBuffer> value) && value.Length > 0)
		{
			if (value[0].requirementAppliesToAllSlots && value[0].showInfoText)
			{
				list = ObjectCategoryTagsCD.ConvertToList(value[0].acceptsObjectsWithTags);
			}
			else if (value.Length > slotIndex && value[slotIndex].showInfoText)
			{
				list = ObjectCategoryTagsCD.ConvertToList(value[slotIndex].acceptsObjectsWithTags);
			}
		}
		if (list != null && list.Count > 0)
		{
			string text = list[0].ToString();
			return new TextAndFormatFields
			{
				text = (getDesc ? (text + "Desc") : text)
			};
		}
		return null;
	}

	public void SetNameOfInventoryObject(PlayerController player, int inventoryIndex, ObjectID objectId, FixedString64Bytes name)
	{
		player.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.SetName(inventoryEntity, startPosInBuffer + inventoryIndex, objectId, name)
		});
	}

	public void SetPetTalentPoints(PlayerController playerController, ObjectID objectId, int talentIndex, int points)
	{
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.SetPetTalentPoints(inventoryEntity, startPosInBuffer, objectId, talentIndex, points)
		});
	}

	public static bool TryGetExtraInventoryData<T>(ContainedObjectsBuffer containedObject, out T data) where T : unmanaged, IComponentData
	{
		return TryGetExtraInventoryData<T>(containedObject.auxDataIndex, out data);
	}

	public static bool TryGetExtraInventoryData<T>(int auxDataIndex, out T data) where T : unmanaged, IComponentData
	{
		World clientWorld = Manager.ecs.ClientWorld;
		return clientWorld.GetExistingSystemManaged<InventoryAuxDataSystem>().SystemData.TryGetExtraInventoryData<T>(clientWorld.EntityManager, auxDataIndex, out data);
	}

	public static bool TryGetExtraInventoryBuffer<T>(ContainedObjectsBuffer containedObject, out DynamicBuffer<T> buffer) where T : unmanaged, IBufferElementData
	{
		return TryGetExtraInventoryBuffer(containedObject.auxDataIndex, out buffer);
	}

	private static bool TryGetExtraInventoryBuffer<T>(int auxDataIndex, out DynamicBuffer<T> buffer) where T : unmanaged, IBufferElementData
	{
		World clientWorld = Manager.ecs.ClientWorld;
		return clientWorld.GetExistingSystemManaged<InventoryAuxDataSystem>().SystemData.TryGetExtraInventoryBufferData(clientWorld.EntityManager, auxDataIndex, out buffer);
	}

	public static void MoveAllOrDropThenTryMove(PlayerController player, InventoryHandler replaceInventory, int replaceVisualSlot, InventoryHandler moveToInventory, Vector3 renderPosition, InventoryHandler secondMoveFromInventory, int secondMoveFromIndex, int amount)
	{
		int replaceSlot = replaceInventory.startPosInBuffer + replaceVisualSlot;
		int moveToStart = moveToInventory.startPosInBuffer;
		int moveToEnd = (moveToInventory.treatAsAllInventoriesForTransfer ? (-1) : (moveToInventory.startPosInBuffer + moveToInventory.size));
		int secondMoveFromSlot = secondMoveFromInventory.startPosInBuffer + secondMoveFromIndex;
		player.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.InventoryChange,
			inventoryChangeData = Create.MoveAllOrDropThenTryMove(replaceInventory.inventoryEntity, replaceSlot, moveToInventory.inventoryEntity, moveToStart, moveToEnd, EntityMonoBehaviour.ToWorldFromRender(renderPosition), secondMoveFromInventory.inventoryEntity, secondMoveFromSlot, amount)
		});
	}
}
