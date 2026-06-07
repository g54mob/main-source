using System;
using System.Collections.Generic;
using DV;
using DV.CabControls;
using DV.InventorySystem;
using DV.OriginShift;
using DV.ThingTypes;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public static class StorageSerializer
{
	private static List<StorageItemData> storageItemList = new List<StorageItemData>();

	public static void SaveStorage(this StorageBase storage, SaveGameData saveGameData)
	{
		StorageType storageType = storage.storageType;
		string storageSavegameKey = GetStorageSavegameKey(storageType);
		if (string.IsNullOrEmpty(storageSavegameKey))
		{
			Debug.LogError($"Storage '{storageType}' doesn't have a save game key. Saving Skipped.");
			return;
		}
		storageItemList.Clear();
		List<ItemBase> list = null;
		if (storageType == StorageType.Inventory)
		{
			list = new List<ItemBase>();
			GameObject[] itemsArray = SingletonBehaviour<Inventory>.Instance.GetItemsArray(includingDropped: false);
			for (int i = 0; i < itemsArray.Length; i++)
			{
				GameObject gameObject = itemsArray[i];
				if (!(gameObject == null))
				{
					ItemBase component = gameObject.GetComponent<ItemBase>();
					if (component != null)
					{
						list.Add(component);
					}
					else
					{
						Debug.LogError(string.Format("Unexpected state: Inventory[{0}] item doesn't have {1} script. Skipping item {2} from savegame", i, "ItemBase", gameObject.name), gameObject);
					}
				}
			}
		}
		else
		{
			list = storage.GetStorageItemList();
		}
		if (list.Count > 0)
		{
			storage.RemovePotentialNulls();
			bool flag = VRManager.IsVREnabled();
			PlayerCameraSwitcher instance = SingletonBehaviour<PlayerCameraSwitcher>.Instance;
			foreach (ItemBase item7 in list)
			{
				if (item7 != null && item7.SpecItem.excludeFromStorageSerialization.HasIntFlag(storage.storageType))
				{
					continue;
				}
				TrainCar storageItemCar = GetStorageItemCar(item7, storageType);
				string carGuid = ((storageItemCar != null) ? storageItemCar.CarGUID : null);
				(Vector3 itemPosition, Quaternion itemRotation) storageItemPositionAndRotation = GetStorageItemPositionAndRotation(item7, storageType, storageItemCar);
				Vector3 item = storageItemPositionAndRotation.itemPosition;
				Quaternion item2 = storageItemPositionAndRotation.itemRotation;
				(string itemPrefabName, bool belongsToPlayer) storageItemSpecData = GetStorageItemSpecData(item7);
				string item3 = storageItemSpecData.itemPrefabName;
				bool item4 = storageItemSpecData.belongsToPlayer;
				ItemSaveData component2 = item7.GetComponent<ItemSaveData>();
				JObject state = null;
				if (component2 != null)
				{
					try
					{
						state = component2.SaveItemData();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				GameObject gameObject2 = item7.gameObject;
				(string containerId, int index) storageItemContainerIdAndIndex = GetStorageItemContainerIdAndIndex(gameObject2, storageType);
				string item5 = storageItemContainerIdAndIndex.containerId;
				int item6 = storageItemContainerIdAndIndex.index;
				int num = SingletonBehaviour<Inventory>.Instance.IndexOf(gameObject2);
				bool inLockedSlot = num >= 0 && SingletonBehaviour<Inventory>.Instance.GetSlotLockState(num);
				bool isDropped = num >= 0 && SingletonBehaviour<Inventory>.Instance.GetSlotDroppedState(num);
				bool isGrabbed = item7.IsGrabbed();
				if (!flag && (bool)instance && item7.gameObject == SingletonBehaviour<PlayerCameraSwitcher>.Instance.HiddenItem)
				{
					isGrabbed = true;
					num = SingletonBehaviour<PlayerCameraSwitcher>.Instance.HiddenItemSlot;
				}
				storageItemList.Add(new StorageItemData(item3, item, item2, item4, isGrabbed, carGuid, state, num, item6, inLockedSlot, isDropped, item5));
			}
		}
		saveGameData.SetObject(storageSavegameKey, storageItemList);
	}

	private static string GetStorageSavegameKey(StorageType storageType)
	{
		switch (storageType)
		{
		case StorageType.Inventory:
			return "Storage_Inventory";
		case StorageType.LostAndFound:
			return "Storage_LostAndFound";
		case StorageType.World:
			return "Storage_World";
		case StorageType.InstalledGadgets:
			return "Storage_InstalledGadgets";
		case StorageType.ItemContainers:
			return "Storage_ItemContainers";
		default:
			return string.Empty;
		}
	}

	public static (string itemPrefabName, bool belongsToPlayer) GetStorageItemSpecData(ItemBase item)
	{
		InventoryItemSpec inventorySpecs = item.InventorySpecs;
		return (itemPrefabName: inventorySpecs.ItemPrefabName, belongsToPlayer: inventorySpecs.BelongsToPlayer);
	}

	private static TrainCar GetStorageItemCar(ItemBase item, StorageType storageType)
	{
		if (storageType != StorageType.World)
		{
			return null;
		}
		return TrainCar.Resolve(item.gameObject);
	}

	private static (string containerId, int index) GetStorageItemContainerIdAndIndex(GameObject item, StorageType storageType)
	{
		if (storageType != StorageType.ItemContainers)
		{
			return (containerId: null, index: -1);
		}
		return SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.GetItemContainerIdAndIndex(item);
	}

	private static (Vector3 itemPosition, Quaternion itemRotation) GetStorageItemPositionAndRotation(ItemBase item, StorageType storageType, TrainCar car)
	{
		int num;
		switch (storageType)
		{
		case StorageType.Inventory:
			return (itemPosition: default(Vector3), itemRotation: default(Quaternion));
		case StorageType.World:
			num = ((car != null) ? 1 : 0);
			break;
		default:
			num = 0;
			break;
		}
		Transform transform = item.transform;
		Vector3 vector = default(Vector3);
		Quaternion quaternion = default(Quaternion);
		if (num != 0)
		{
			Transform interior = car.interior;
			vector = interior.InverseTransformPoint(transform.position);
			quaternion = Quaternion.Inverse(interior.rotation) * transform.rotation;
		}
		else if (storageType == StorageType.LostAndFound)
		{
			(Vector3 localPosition, Quaternion localRotation, bool hasValidPositionAndRotation) itemTransformValues = SingletonBehaviour<StorageController>.Instance.ItemTransformControllerLostAndFound.GetItemTransformValues(item);
			Vector3 item2 = itemTransformValues.localPosition;
			Quaternion item3 = itemTransformValues.localRotation;
			vector = (itemTransformValues.hasValidPositionAndRotation ? item2 : StorageItemTransformController.IGNORE_POSITION_VALUE);
			quaternion = item3;
		}
		else
		{
			vector = transform.AbsolutePosition();
			quaternion = transform.rotation;
		}
		if (float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z))
		{
			vector = ((storageType == StorageType.LostAndFound) ? StorageItemTransformController.IGNORE_POSITION_VALUE : new Vector3(5000f, 0f, 0f));
			Debug.LogWarning($"Item {transform.name} has at least one of the position coordinates marked as NaN. Saving using position value of {vector}");
		}
		return (itemPosition: vector, itemRotation: quaternion);
	}

	public static List<StorageItemData> LoadStorageData(StorageType storageType, SaveGameData saveGameData)
	{
		List<StorageItemData> list;
		switch (storageType)
		{
		case StorageType.Inventory:
			list = saveGameData.GetObject<List<StorageItemData>>("Storage_Inventory");
			break;
		case StorageType.LostAndFound:
			list = saveGameData.GetObject<List<StorageItemData>>("Storage_LostAndFound");
			break;
		case StorageType.World:
			list = saveGameData.GetObject<List<StorageItemData>>("Storage_World");
			break;
		case StorageType.InstalledGadgets:
			list = saveGameData.GetObject<List<StorageItemData>>("Storage_InstalledGadgets");
			break;
		case StorageType.ItemContainers:
			list = saveGameData.GetObject<List<StorageItemData>>("Storage_ItemContainers");
			break;
		default:
			Debug.LogError($"Unexpected storage of type '{storageType}' for deserialization. Trying to recover.");
			list = new List<StorageItemData>();
			break;
		}
		if (list == null)
		{
			list = new List<StorageItemData>();
		}
		return list;
	}
}
