using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.CabControls;
using DV.Customization;
using DV.InventorySystem;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class StorageController : SingletonBehaviour<StorageController>
{
	private const InventoryActionType VALID_INVENTORY_ACTIONS = InventoryActionType.Add | InventoryActionType.Drop | InventoryActionType.Purge | InventoryActionType.Equip;

	[NonSerialized]
	public List<StorageBase> allStorages = new List<StorageBase>();

	[NonSerialized]
	public List<StorageAccessPointBase> allAccessPoints = new List<StorageAccessPointBase>();

	[NonSerialized]
	public StorageBase StorageWorld;

	[NonSerialized]
	public StorageBase StorageLostAndFound;

	[NonSerialized]
	public StorageBase StorageInventory;

	[NonSerialized]
	public StorageBase StorageInstalledGadgets;

	[NonSerialized]
	public StorageBase StorageItemContainers;

	public StorageItemTransformController ItemTransformControllerLostAndFound { get; private set; }

	public new static string AllowAutoCreate()
	{
		return "[StorageController]";
	}

	protected override void Initialize()
	{
		base.Initialize();
		ItemTransformControllerLostAndFound = new StorageItemTransformController();
		InitStorage(ref StorageWorld, StorageType.World, acceptsNonEssential: false);
		InitStorage(ref StorageLostAndFound, StorageType.LostAndFound, acceptsNonEssential: false);
		InitStorage(ref StorageInventory, StorageType.Inventory, acceptsNonEssential: true);
		InitStorage(ref StorageInstalledGadgets, StorageType.InstalledGadgets, acceptsNonEssential: true);
		InitStorage(ref StorageItemContainers, StorageType.ItemContainers, acceptsNonEssential: true);
		SetupListeners(on: true);
	}

	private void InitStorage(ref StorageBase target, StorageType type, bool acceptsNonEssential)
	{
		if (!NumberUtils.IsPowerOfTwo((int)type))
		{
			Debug.LogError("[Storage] InitStorage type must contain a single flag!");
		}
		GameObject obj = new GameObject($"[Storage {type}]");
		obj.transform.SetParent(base.transform);
		StorageBase storageBase = obj.AddComponent<StorageBase>();
		storageBase.storageType = type;
		storageBase.acceptsNonEssential = acceptsNonEssential;
		allStorages.Add(storageBase);
		target = storageBase;
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged += OnInventoryStatusChanged;
		}
		else
		{
			SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryStatusChanged;
		}
	}

	public void AddStorageToList(StorageBase storage)
	{
		if (allStorages.Contains(storage))
		{
			Debug.LogWarning("Trying to add $" + storage.transform.name + " to list of storages but it is already there. Aborting.", storage);
		}
		else
		{
			allStorages.Add(storage);
		}
	}

	public void RemoveStorageFromList(StorageBase storage)
	{
		if (!allStorages.Contains(storage))
		{
			Debug.LogWarning("Trying to remove storage " + storage.transform.name + " from the list but it was never there to begin with. Aborting.", storage);
		}
		else
		{
			allStorages.Remove(storage);
		}
	}

	public void AddItemToLostAndFound(ItemBase item, bool updateTransformData = true)
	{
		AddItemToStorageItemList(StorageLostAndFound, item);
		if (updateTransformData)
		{
			ItemTransformControllerLostAndFound.UpdateItemTransformData(item);
		}
	}

	public void RemoveItemFromLostAndFound(ItemBase item)
	{
		RemoveItemFromStorageItemList(StorageLostAndFound, item);
	}

	public void AddItemToWorldStorage(ItemBase item)
	{
		AddItemToStorageItemList(StorageWorld, item);
	}

	public void AddItemToWorldStorage(GameObject item)
	{
		AddItemToStorageItemList(StorageWorld, item);
	}

	public void AddItemToInstalledGadgets(ItemBase item)
	{
		AddItemToStorageItemList(StorageInstalledGadgets, item);
		item.gameObject.SetActive(value: false);
	}

	public void AddItemToStorageItemContainers(ItemBase item)
	{
		AddItemToStorageItemList(StorageItemContainers, item);
	}

	public void RemoveItemFromStorageItemContainers(ItemBase item)
	{
		RemoveItemFromStorageItemList(StorageItemContainers, item);
	}

	public void AddItemToWorldStorageAfterOneFrame(GameObject item)
	{
		StartCoroutine(AddItemToWorldStorageAfterOneFrameCoro(item));
	}

	private IEnumerator AddItemToWorldStorageAfterOneFrameCoro(GameObject item)
	{
		yield return null;
		AddItemToWorldStorage(item);
	}

	public void MoveFromInstalledGadgetsToWorld(GameObject item)
	{
		ItemBase component = item.GetComponent<ItemBase>();
		if (component.BelongsToPlayer())
		{
			AddItemToWorldStorage(component);
		}
		else
		{
			RemoveItemFromStorageItemList(StorageInstalledGadgets, item);
		}
		item.gameObject.SetActive(value: true);
	}

	public void RemoveItemFromWorldStorage(ItemBase item)
	{
		RemoveItemFromStorageItemList(StorageWorld, item);
	}

	public void AddItemToStorageItemList(StorageBase storage, GameObject itemGO)
	{
		ItemBase component = itemGO.GetComponent<ItemBase>();
		if (component == null)
		{
			Debug.LogError("Cannot add item " + itemGO.name + " to storage " + storage.transform.name + ". It doesn't have ItemBase component. Aborting.", itemGO);
		}
		else
		{
			AddItemToStorageItemList(storage, component);
		}
	}

	public void AddItemToStorageItemList(StorageBase storage, ItemBase item)
	{
		if (item == null)
		{
			Debug.LogError("You are trying to add a null item to storage. Aborting.", this);
			return;
		}
		if (storage == null)
		{
			Debug.LogError("You are trying to add '" + item.transform.name + "' to a null storage. Aborting.", item);
			return;
		}
		RemoveItemFromStorageItemList(item);
		InventoryItemSpec component = item.GetComponent<InventoryItemSpec>();
		if (component == null)
		{
			Debug.LogError("You are trying to add '" + item.transform.name + "' to '" + storage.transform.name + "' but it doesn't have InventoryItemSpec. Aborting.", item);
		}
		else if (!component.BelongsToPlayer && !storage.acceptsNonEssential)
		{
			Debug.LogError("You are trying to add non-essential item '" + item.transform.name + "' but storage '" + storage.transform.name + "' doesn't allow it. Is this intentional? Aborting.", item);
		}
		else
		{
			storage.AddItem(item);
			item.GetComponent<RespawnOnDrop>().UpdateSpawnParams();
		}
	}

	public void RemoveItemFromStorageItemList(GameObject item)
	{
		if (item == null)
		{
			Debug.LogError("Trying to remove a null item from a storage. Aborting.", this);
			return;
		}
		StorageBase belongingStorage = GetBelongingStorage(item);
		if (belongingStorage != null)
		{
			RemoveItemFromStorageItemList(belongingStorage, item);
		}
	}

	public void RemoveItemFromStorageItemList(ItemBase item)
	{
		if (item == null)
		{
			Debug.LogError("You are trying to remove a null item from a storage. Null cleanup is done prior to saving the game. Aborting.", this);
			return;
		}
		StorageBase belongingStorage = GetBelongingStorage(item);
		if (belongingStorage != null)
		{
			RemoveItemFromStorageItemList(belongingStorage, item);
		}
	}

	public void RemoveItemFromStorageItemList(StorageBase storage, GameObject itemGO)
	{
		if (itemGO == null)
		{
			Debug.LogError("You are trying to remove a null item from a storage. Aborting.", this);
			return;
		}
		if (storage == null)
		{
			Debug.LogError("You are trying to remove item '" + itemGO.name + "' from the null storage. Aborting.", itemGO);
			return;
		}
		ItemBase component = itemGO.GetComponent<ItemBase>();
		if (component == null)
		{
			Debug.LogError("Cannot remove item " + itemGO.name + " from storage " + storage.transform.name + ". It doesn't have ItemBase component. Aborting.", itemGO);
		}
		else
		{
			RemoveItemFromStorageItemList(storage, component);
		}
	}

	public void RemoveItemFromStorageItemList(StorageBase storage, ItemBase item)
	{
		if (item == null)
		{
			Debug.LogError("Trying to remove null item from storage " + storage.transform.name + ". Aborting.");
		}
		else if (storage == null)
		{
			Debug.LogError("You are trying to remove item '" + item.transform.name + "' from the null storage. Aborting.", item);
		}
		else if (!storage.HasAnyItem())
		{
			Debug.LogError("Trying to remove " + item.transform.name + " from an empty storage " + storage.transform.name + ". Aborting.");
		}
		else if (!storage.ContainsItem(item))
		{
			Debug.LogError("Trying to remove " + item.transform.name + " from storage " + storage.transform.name + " which is not in the list. Aborting.");
		}
		else
		{
			storage.RemoveItem(item);
		}
	}

	public void RegisterStorageAccessPoint(StorageAccessPointBase sap)
	{
		if (sap == null)
		{
			Debug.LogError("Trying to register a null StorageAccessPoint. Aborting.", this);
			return;
		}
		if (allAccessPoints.Contains(sap))
		{
			Debug.LogError("Trying to add storage access point " + sap.transform.name + " but it is already in the list. Aborting.", sap);
			return;
		}
		allAccessPoints.Add(sap);
		SubscribeToAccessPointOnRegister(sap);
	}

	public void UnregisterStorageAccessPoint(StorageAccessPointBase sap)
	{
		if (sap == null)
		{
			Debug.LogError("Trying to unregister a null StorageAccessPoint. Aborting.", this);
			return;
		}
		if (!allAccessPoints.Contains(sap))
		{
			Debug.LogError("Trying to remove storage access point " + sap.transform.name + " but it is not in the list. Aborting.", sap);
			return;
		}
		UnsubscribeFromAccessPointOnUnregister(sap);
		allAccessPoints.Remove(sap);
	}

	private void SubscribeToAccessPointOnRegister(StorageAccessPointBase sap)
	{
		sap.PlayerInActivationRange += OnPlayerInActivationRange;
		sap.PlayerInDeactivationRange += OnPlayerInDeactivationRange;
	}

	private void UnsubscribeFromAccessPointOnUnregister(StorageAccessPointBase sap)
	{
		sap.PlayerInActivationRange -= OnPlayerInActivationRange;
		sap.PlayerInDeactivationRange -= OnPlayerInDeactivationRange;
	}

	private void OnPlayerInActivationRange(StorageAccessPointBase sap)
	{
		if (!sap.storage.itemsActiveOrActivating)
		{
			sap.shouldCheckForActivation = false;
			if (sap.AccessPointStorageType != StorageType.LostAndFound)
			{
				return;
			}
			StorageStaticParent componentInParent = sap.GetComponentInParent<StorageStaticParent>();
			SingletonCustomization<StorageShedCustomization>.I.transform.SetParent(componentInParent.transform, worldPositionStays: false);
			SingletonCustomization<StorageShedCustomization>.I.Enable();
			ItemTransformControllerLostAndFound.ActivateItems(componentInParent);
			{
				foreach (StorageAccessPointBase allAccessPoint in allAccessPoints)
				{
					if (allAccessPoint != sap && allAccessPoint.AccessPointStorageType == StorageType.LostAndFound)
					{
						allAccessPoint.shouldCheckForActivation = true;
					}
				}
				return;
			}
		}
		sap.shouldCheckForActivation = true;
	}

	private void OnPlayerInDeactivationRange(StorageAccessPointBase sap)
	{
		if (sap.AccessPointStorageType == StorageType.LostAndFound)
		{
			ItemTransformControllerLostAndFound.DeactivateItems();
			SingletonCustomization<StorageShedCustomization>.I.Disable();
		}
	}

	private void OnInventoryStatusChanged(InventorySlotState originState, InventoryActionType originActionType, InventorySlotState _, InventoryActionType __)
	{
		if (!originActionType.HasAnyIntFlag(InventoryActionType.Add | InventoryActionType.Drop | InventoryActionType.Purge | InventoryActionType.Equip))
		{
			return;
		}
		ItemBase itemBase = ((originState.item != null) ? originState.item.GetComponent<ItemBase>() : null);
		if (itemBase == null)
		{
			return;
		}
		if (originActionType.HasAnyIntFlag(InventoryActionType.Add))
		{
			AddItemToStorageItemList(StorageInventory, itemBase);
		}
		else
		{
			if (!originActionType.HasAnyIntFlag(InventoryActionType.Drop | InventoryActionType.Purge | InventoryActionType.Equip))
			{
				return;
			}
			if (!itemBase.BelongsToPlayer())
			{
				if (StorageInventory.ContainsItem(itemBase))
				{
					RemoveItemFromStorageItemList(StorageInventory, itemBase);
				}
			}
			else
			{
				AddItemToWorldStorage(itemBase);
			}
		}
	}

	public void MoveItemsFromWorldToLostAndFound(bool includeNonRespawnParents = true, bool includeRespawnParents = false, bool includeSnappedItems = false)
	{
		foreach (ItemBase item in new List<ItemBase>(StorageWorld.GetStorageItemList()))
		{
			if (item == null || item.IsGrabbed() || !item.GetComponent<InventoryItemSpec>().BelongsToPlayer)
			{
				continue;
			}
			bool isSnapped = item.IsSnapped;
			if (isSnapped && !includeSnappedItems)
			{
				continue;
			}
			if (item.GetComponent<RespawnOnDrop>().OnValidRespawnParent)
			{
				if (!includeRespawnParents || !PrepareItemForLostAndFound(item))
				{
					continue;
				}
			}
			else if (!includeNonRespawnParents)
			{
				if (!includeSnappedItems || !isSnapped || !PrepareItemForLostAndFound(item))
				{
					continue;
				}
			}
			else if (isSnapped && !PrepareItemForLostAndFound(item))
			{
				continue;
			}
			StorageWorld.RemoveItem(item);
			StorageLostAndFound.AddItem(item);
		}
	}

	private bool PrepareItemForLostAndFound(ItemBase item)
	{
		ItemReparentingBase component = item.GetComponent<ItemReparentingBase>();
		if (component == null)
		{
			Debug.LogError("Unexpected state ItemReparentingBase missing from item. Ignoring request to PrepareItemForLostAndFound.", this);
			return false;
		}
		if (item.IsSnapped)
		{
			item.SnappableItem.SnappedTo.UnsnapItem();
		}
		Transform originShiftParent = WorldMover.OriginShiftParent;
		if (component.CurrentParent == originShiftParent)
		{
			return true;
		}
		component.ParentItemExternal(originShiftParent, null);
		return true;
	}

	public bool AnyStorageContains(ItemBase item)
	{
		foreach (StorageBase allStorage in allStorages)
		{
			if (allStorage.ContainsItem(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool ItemInMultipleStorages(ItemBase item)
	{
		int num = 0;
		foreach (StorageBase allStorage in allStorages)
		{
			if (allStorage.ContainsItem(item))
			{
				num++;
				if (num > 1)
				{
					return true;
				}
			}
		}
		return false;
	}

	public StorageBase GetBelongingStorage(GameObject itemGO)
	{
		ItemBase itemBase = itemGO?.GetComponent<ItemBase>();
		if (itemBase == null)
		{
			Debug.LogError("Item " + itemGO.name + " does not have ItemBase component. Cannot get belonging storage. Aborting.");
			return null;
		}
		return GetBelongingStorage(itemBase);
	}

	public StorageBase GetBelongingStorage(ItemBase item)
	{
		foreach (StorageBase allStorage in allStorages)
		{
			if (allStorage.ContainsItem(item))
			{
				return allStorage;
			}
		}
		return null;
	}

	public bool IsInStorageWorld(ItemBase item)
	{
		return StorageWorld.ContainsItem(item);
	}

	public bool IsInStorageLostAndFound(ItemBase item)
	{
		return StorageLostAndFound.ContainsItem(item);
	}

	public List<ItemBase> GetAllStorageItems()
	{
		return allStorages.SelectMany((StorageBase s) => s.GetStorageItemList()).ToList();
	}

	public void RequestLostAndFoundItemActivation()
	{
		if (StorageLostAndFound == null)
		{
			Debug.LogError("StorageLostAndFound is null. Aborting L&F item activation.", this);
			return;
		}
		ItemTransformControllerLostAndFound.DeactivateItems();
		MoveItemsFromWorldToLostAndFound();
		RequestItemActivation();
	}

	private void RequestItemActivation()
	{
		foreach (StorageAccessPointBase allAccessPoint in allAccessPoints)
		{
			if (!(allAccessPoint == null))
			{
				allAccessPoint.shouldCheckForActivation = true;
			}
		}
	}

	public void ForceSummonAllWorldItemsToLostAndFound(bool includeNonRespawnParents, bool includeRespawnParents, bool includeSnappedItems)
	{
		if (StorageLostAndFound == null)
		{
			Debug.LogError("StorageLostAndFound is null. Aborting ForceSummonAllWorldItemsToLostAndFound.", this);
			return;
		}
		ItemTransformControllerLostAndFound.DeactivateItems();
		MoveItemsFromWorldToLostAndFound(includeNonRespawnParents, includeRespawnParents, includeSnappedItems);
		ItemTransformControllerLostAndFound.DeactivateItems();
		RequestItemActivation();
	}

	public static void RemoveItemFromCurrentStorageAndAddToWorld(ItemBase item, Vector3 position, Quaternion rotation)
	{
		VRManager.IsVREnabled();
		StorageController instance = SingletonBehaviour<StorageController>.Instance;
		if (instance != null)
		{
			if (item.IsGrabbed())
			{
				item.ForceEndInteraction();
			}
			else if (instance.StorageInventory.ContainsItem(item))
			{
				int num = SingletonBehaviour<Inventory>.Instance.IndexOf(item.gameObject);
				if (num != -1 && SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(num) == null)
				{
					Debug.LogError($"Unexpected state of inventory! Could not remove item from inventory at index {num}.", SingletonBehaviour<StorageController>.Instance);
				}
			}
			else if (instance.StorageLostAndFound.ContainsItem(item))
			{
				instance.StorageLostAndFound.RemoveItem(item);
			}
			else
			{
				SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.PurgeItemFromContainer(item.gameObject);
			}
			if (!instance.IsInStorageWorld(item) && item.InventorySpecs.BelongsToPlayer)
			{
				instance.StorageWorld.AddItem(item);
			}
		}
		Rigidbody component = item.GetComponent<Rigidbody>();
		if ((bool)component)
		{
			component.velocity = Vector3.zero;
			component.angularVelocity = Vector3.zero;
		}
		item.transform.SetParent(WorldMover.OriginShiftParent);
		item.transform.SetPositionAndRotation(position, rotation);
		item.gameObject.SetActive(value: true);
	}
}
