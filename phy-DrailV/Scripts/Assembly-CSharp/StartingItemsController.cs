using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.CabControls;
using DV.InventorySystem;
using DV.Items;
using DV.ThingTypes;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class StartingItemsController : SingletonBehaviour<StartingItemsController>
{
	private struct InventoryItemData
	{
		public GameObject Item { get; }

		public int Slot { get; }

		public bool IsInLockedSlot { get; }

		public bool IsDropped { get; }

		public bool IsGrabbed { get; }

		public InventoryItemData(GameObject item, int slot, bool isInLockedSlot, bool isDropped, bool isGrabbed)
		{
			Item = item;
			Slot = slot;
			IsInLockedSlot = isInLockedSlot;
			IsDropped = isDropped;
			IsGrabbed = isGrabbed;
		}
	}

	private static readonly Vector3 ITEM_INSTANTIATION_SAFETY_POSITION = new Vector3(0f, 5000f, 0f);

	private static readonly Vector3 ITEM_INSTANTIATION_SAFETY_OFFSET = new Vector3(0f, 1.5f, 0f);

	private int instantiatedItemCount;

	[Header("Set to true in dev scenes")]
	public bool itemsLoaded;

	public new static string AllowAutoCreate()
	{
		return null;
	}

	public void AddStartingItems(SaveGameData saveGameData, bool firstTime = false)
	{
		float? num = saveGameData.GetFloat("Player_money");
		if (num.HasValue)
		{
			SingletonBehaviour<Inventory>.Instance.SetMoney(num.Value);
		}
		StartCoroutine(AddStartingItemsCoro(saveGameData, firstTime));
	}

	private IEnumerator AddStartingItemsCoro(SaveGameData saveGameData, bool firstTime)
	{
		Debug.Log("StartingItemsController initializing", this);
		HashSet<Rigidbody> itemRigidBodiesToToggleOffKinematicState = new HashSet<Rigidbody>();
		List<StorageItemData> list = StorageSerializer.LoadStorageData(StorageType.Inventory, saveGameData);
		List<StorageItemData> list2 = StorageSerializer.LoadStorageData(StorageType.LostAndFound, saveGameData);
		List<StorageItemData> list3 = StorageSerializer.LoadStorageData(StorageType.World, saveGameData);
		List<StorageItemData> list4 = StorageSerializer.LoadStorageData(StorageType.InstalledGadgets, saveGameData);
		List<StorageItemData> itemsItemContainers = StorageSerializer.LoadStorageData(StorageType.ItemContainers, saveGameData);
		Dictionary<GameObject, StorageItemData> inventoryBelongingData = new Dictionary<GameObject, StorageItemData>();
		List<StorageItemData> combinedSavedItems = CombineAndResolveIllegalDuplicates(list, list2, list3, list4, itemsItemContainers);
		StartingItemsSafeguard(list, combinedSavedItems, saveGameData, firstTime);
		LicensesSafeguard(list2, combinedSavedItems, saveGameData, firstTime);
		SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.canRegisterContainers = false;
		HashSet<(ItemSaveData itemSaveData, JObject itemState)> itemSaveDataCollection = new HashSet<(ItemSaveData, JObject)>();
		InstantiateStorageItems(list4, ignoreNulls: true, ref inventoryBelongingData, itemSaveDataCollection, itemRigidBodiesToToggleOffKinematicState);
		InstantiateStorageItems(list, ignoreNulls: true, ref inventoryBelongingData, itemSaveDataCollection, itemRigidBodiesToToggleOffKinematicState);
		Transform worldParent;
		Dictionary<GameObject, (Vector3, Quaternion, Rigidbody, Transform, bool)> transformRelatedWorldItemStates = InstantiateStorageItemsWorld(list3, inventoryBelongingData, list2, out worldParent, itemSaveDataCollection, itemRigidBodiesToToggleOffKinematicState);
		List<GameObject> instantiatedItemsWorld = new List<GameObject>(transformRelatedWorldItemStates.Keys);
		List<(GameObject item, string containerId, StorageItemData data)> instantiatedItemsItemContainers = InstantiateStorageItemsItemContainers(itemsItemContainers, ref inventoryBelongingData, list2, itemSaveDataCollection, itemRigidBodiesToToggleOffKinematicState);
		List<(GameObject item, StorageItemData data)> instantiatedItemsLostAndFound = InstantiateStorageItemsLostAndFound(list2, ignoreNulls: true, ref inventoryBelongingData, itemSaveDataCollection, itemRigidBodiesToToggleOffKinematicState);
		yield return null;
		yield return FinalizeItemStateLoading(transformRelatedWorldItemStates, worldParent, itemSaveDataCollection, itemRigidBodiesToToggleOffKinematicState);
		List<InventoryItemData> inventoryBelongingData2 = CreateInventoryData(inventoryBelongingData);
		InitializeInventory(inventoryBelongingData2);
		AddItemsToContainers(instantiatedItemsItemContainers, instantiatedItemsLostAndFound);
		foreach (var item3 in itemSaveDataCollection)
		{
			ItemSaveData item = item3.itemSaveData;
			try
			{
				item.PostContainerLoadData();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
		foreach (var item4 in instantiatedItemsLostAndFound)
		{
			var (gameObject, _) = item4;
			SingletonBehaviour<StorageController>.Instance.AddItemToStorageItemList(SingletonBehaviour<StorageController>.Instance.StorageLostAndFound, gameObject);
			StorageItemData item2 = item4.data;
			if (!(item2.ItemPosition == StorageItemTransformController.IGNORE_POSITION_VALUE))
			{
				ItemBase component = gameObject.GetComponent<ItemBase>();
				SingletonBehaviour<StorageController>.Instance.ItemTransformControllerLostAndFound.ForceSetItemTransformValues(component, item2.ItemPosition, item2.ItemRotation);
			}
		}
		foreach (GameObject item5 in instantiatedItemsWorld)
		{
			SingletonBehaviour<StorageController>.Instance.AddItemToStorageItemList(SingletonBehaviour<StorageController>.Instance.StorageWorld, item5);
		}
		itemsLoaded = true;
	}

	private void StartingItemsSafeguard(List<StorageItemData> itemsInventory, List<StorageItemData> combinedSavedItems, SaveGameData saveGameData, bool firstTime)
	{
		List<StartingItems.StartingItem> startingItemsPrefabs = GetStartingItemsPrefabs(saveGameData);
		HashSet<int> hashSet = new HashSet<int>(combinedSavedItems.Select((StorageItemData t) => t.inventorySlotIndex));
		HashSet<int> hashSet2 = new HashSet<int>();
		for (int num = 0; num <= 35; num++)
		{
			if (!hashSet.Contains(num))
			{
				hashSet2.Add(num);
			}
		}
		List<StartingItems.StartingItem> list = new List<StartingItems.StartingItem>(startingItemsPrefabs);
		for (int num2 = list.Count - 1; num2 >= 0; num2--)
		{
			StartingItems.StartingItem startingItem = list[num2];
			foreach (StorageItemData combinedSavedItem in combinedSavedItems)
			{
				string itemPrefabName = combinedSavedItem.itemPrefabName;
				if (!(itemPrefabName != startingItem.ItemPrefabName))
				{
					list.RemoveAt(num2);
					if (!combinedSavedItem.belongsToPlayer)
					{
						Debug.LogError("Saved item " + itemPrefabName + " is not marked as belonging to player, it is a part of the starting items. Fixing.", this);
						combinedSavedItem.belongsToPlayer = true;
					}
					break;
				}
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		if (!firstTime)
		{
			Debug.LogError("Some starting items are missing from the savegame: " + string.Join(", ", list.Select((StartingItems.StartingItem t) => t.item.name)) + ". Adding them.", this);
		}
		foreach (StartingItems.StartingItem item2 in list)
		{
			int inventorySlotIndex = -1;
			if (hashSet2.Count > 0)
			{
				int num3 = item2.preferredRelativeSlot - 1 + (item2.backpackPriority ? 12 : 0);
				for (int num4 = 0; num4 < 36; num4++)
				{
					num3 = (num3 + 1) % 36;
					if (hashSet2.Remove(num3))
					{
						inventorySlotIndex = num3;
						break;
					}
				}
			}
			StorageItemData item = new StorageItemData(item2.ItemPrefabName, Vector3.zero, Quaternion.identity, belongsToPlayer: true, isGrabbed: false, null, null, inventorySlotIndex);
			itemsInventory.Add(item);
		}
	}

	private void LicensesSafeguard(List<StorageItemData> itemsLostAndFound, List<StorageItemData> combinedSavedItems, SaveGameData saveGameData, bool addMissingLicenseItemsSilently)
	{
		if (saveGameData.GetString("Game_mode") == "Career")
		{
			bool? flag = saveGameData.GetBool("Tutorial_01_completed");
			if (!flag.HasValue || !flag.Value)
			{
				return;
			}
		}
		string[] array = saveGameData.GetStringArray("Licenses_General");
		if (array == null)
		{
			array = Array.Empty<string>();
		}
		Dictionary<string, string> dictionary = Globals.G.Types.generalLicenses.Where((GeneralLicenseType_v2 t) => t.licensePrefab != null).ToDictionary((GeneralLicenseType_v2 t) => t.id, (GeneralLicenseType_v2 p) => p.licensePrefab.name);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (!dictionary.TryGetValue(text, out var prefabName))
			{
				Debug.LogError("Unknown saved license: '" + text + "'. This should not happen. Skipping.", this);
			}
			else if (!string.IsNullOrWhiteSpace(prefabName) && !combinedSavedItems.Any((StorageItemData t) => t.itemPrefabName == prefabName))
			{
				if (!addMissingLicenseItemsSilently)
				{
					Debug.LogError("License item for saved general license with id '" + text + "' is not present in the save game. Adding it to Lost and Found collection.", this);
				}
				StorageItemData item = new StorageItemData(prefabName, Vector3.zero, Quaternion.identity, belongsToPlayer: true);
				itemsLostAndFound.Add(item);
			}
		}
		string[] array3 = saveGameData.GetStringArray("Licenses_Jobs");
		if (array3 == null)
		{
			array3 = Array.Empty<string>();
		}
		Dictionary<string, string> dictionary2 = Globals.G.Types.jobLicenses.Where((JobLicenseType_v2 t) => t.licensePrefab != null).ToDictionary((JobLicenseType_v2 t) => t.id, (JobLicenseType_v2 p) => p.licensePrefab.name);
		array2 = array3;
		foreach (string text2 in array2)
		{
			if (!dictionary2.TryGetValue(text2, out var prefabName2))
			{
				Debug.LogError("Unknown saved license: '" + text2 + "'. This should not happen. Skipping.", this);
			}
			else if (!string.IsNullOrWhiteSpace(prefabName2) && !combinedSavedItems.Any((StorageItemData t) => t.itemPrefabName == prefabName2))
			{
				if (!addMissingLicenseItemsSilently)
				{
					Debug.LogError("License item for saved job license with id '" + text2 + "' is not present in the save game. Adding it to Lost and Found collection.", this);
				}
				StorageItemData item2 = new StorageItemData(prefabName2, Vector3.zero, Quaternion.identity, belongsToPlayer: true);
				itemsLostAndFound.Add(item2);
			}
		}
	}

	private List<StorageItemData> CombineAndResolveIllegalDuplicates(List<StorageItemData> itemsInventory, List<StorageItemData> itemsLostAndFound, List<StorageItemData> itemsWorld, List<StorageItemData> itemsInstalledGadgets, List<StorageItemData> itemsItemContainers)
	{
		foreach (KeyValuePair<string, int> item in GenerateItemCounters(new List<StorageItemData>[5] { itemsInventory, itemsLostAndFound, itemsWorld, itemsInstalledGadgets, itemsItemContainers }))
		{
			int num = item.Value;
			while (num > 1)
			{
				num--;
				string key = item.Key;
				if (!RemoveDuplicate(key, itemsLostAndFound, first: true) && !RemoveDuplicate(key, itemsWorld, first: true) && !RemoveDuplicate(key, itemsInventory, first: false) && !RemoveDuplicate(key, itemsInstalledGadgets, first: true))
				{
					RemoveDuplicate(key, itemsItemContainers, first: true);
				}
			}
		}
		return (from t in itemsInventory.Concat(itemsLostAndFound).Concat(itemsWorld).Concat(itemsInstalledGadgets)
				.Concat(itemsItemContainers)
			where t != null && !string.IsNullOrWhiteSpace(t.itemPrefabName)
			select t).ToList();
		Dictionary<string, int> GenerateItemCounters(List<StorageItemData>[] itemCollections)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (StartingItems.StartingItem startingItem in Globals.G.Items.GetStartingItemsAsset(GameParams.StartingItemsType.Basic).GetStartingItems())
			{
				dictionary[startingItem.ItemPrefabName] = 0;
			}
			foreach (GeneralLicenseType_v2 generalLicense in Globals.G.Types.generalLicenses)
			{
				GameObject licensePrefab = generalLicense.licensePrefab;
				string text = ((licensePrefab != null) ? licensePrefab.name : null);
				if (!string.IsNullOrWhiteSpace(text))
				{
					dictionary[text] = 0;
				}
			}
			foreach (JobLicenseType_v2 jobLicense in Globals.G.Types.jobLicenses)
			{
				GameObject licensePrefab2 = jobLicense.licensePrefab;
				string text2 = ((licensePrefab2 != null) ? licensePrefab2.name : null);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					dictionary[text2] = 0;
				}
			}
			for (int i = 0; i < itemCollections.Length; i++)
			{
				foreach (StorageItemData item2 in itemCollections[i])
				{
					if (item2 != null && dictionary.ContainsKey(item2.itemPrefabName))
					{
						dictionary[item2.itemPrefabName]++;
					}
				}
			}
			return dictionary;
		}
		bool RemoveDuplicate(string itemPrefabName, List<StorageItemData> items, bool first)
		{
			StorageItemData storageItemData = ((!first) ? items.LastOrDefault((StorageItemData t) => t.itemPrefabName == itemPrefabName) : items.FirstOrDefault((StorageItemData t) => t.itemPrefabName == itemPrefabName));
			if (storageItemData == null)
			{
				return false;
			}
			Debug.LogError("Found a basic item or license item duplicate: " + storageItemData.itemPrefabName + ". Removing it.", this);
			items.Remove(storageItemData);
			return true;
		}
	}

	private List<StartingItems.StartingItem> GetStartingItemsPrefabs(SaveGameData data)
	{
		int? num = data?.GetInt("Starting_items");
		if (!num.HasValue || !Enum.IsDefined(typeof(GameParams.StartingItemsType), num.Value))
		{
			Debug.LogError($"Starting items value is not set or is invalid. Using {GameParams.StartingItemsType.Basic}", this);
			num = 0;
		}
		GameParams.StartingItemsType value = (GameParams.StartingItemsType)num.Value;
		List<StartingItems.StartingItem> startingItems = Globals.G.Items.GetStartingItemsAsset(value).GetStartingItems();
		if (startingItems != null)
		{
			return startingItems;
		}
		Debug.LogError($"Starting items for type {value} are null. Using basic starting items.", this);
		return Globals.G.Items.GetStartingItemsAsset(GameParams.StartingItemsType.Basic).GetStartingItems();
	}

	private void InitializeInventory(List<InventoryItemData> inventoryBelongingData)
	{
		List<InventoryItemData> list = inventoryBelongingData.Where((InventoryItemData t) => t.Item != null && t.IsGrabbed).ToList();
		List<InventoryItemData> list2 = inventoryBelongingData.Where((InventoryItemData t) => t.Item != null && !t.IsGrabbed && t.Slot < 0).ToList();
		foreach (InventoryItemData inventoryBelongingDatum in inventoryBelongingData)
		{
			if (!(inventoryBelongingDatum.Item == null) && inventoryBelongingDatum.Slot >= 0 && !inventoryBelongingDatum.IsGrabbed)
			{
				SingletonBehaviour<Inventory>.Instance.AddItemToInventory(inventoryBelongingDatum.Item, inventoryBelongingDatum.Slot, inventoryBelongingDatum.IsDropped);
				if (inventoryBelongingDatum.IsInLockedSlot)
				{
					SingletonBehaviour<Inventory>.Instance.ToggleSlotLock(inventoryBelongingDatum.Slot);
				}
			}
		}
		for (int num = 0; num < list.Count; num++)
		{
			InventoryItemData inventoryItemData = list[num];
			GameObject item = inventoryItemData.Item;
			if (num == 0 && !VRManager.IsVREnabled())
			{
				int slot = inventoryItemData.Slot;
				SingletonBehaviour<Inventory>.Instance.EquipItem(item, slot, 0);
			}
			else if (inventoryItemData.Slot >= 0)
			{
				SingletonBehaviour<Inventory>.Instance.AddItemToInventory(item, inventoryItemData.Slot);
			}
			else
			{
				AddItemToInventoryFallback(item, isDropped: false);
			}
		}
		if (list2.Count <= 0)
		{
			return;
		}
		Debug.LogError($"Found total of {list2.Count} items without slot while initializing inventory:", this);
		foreach (InventoryItemData item3 in list2)
		{
			GameObject item2 = item3.Item;
			Debug.LogError("Trying to add " + item2.name + " to inventory. Failure will make the item go to L&F.", this);
			AddItemToInventoryFallback(item2, item3.IsDropped);
		}
	}

	private void AddItemsToContainers(List<(GameObject item, string containerId, StorageItemData data)> instantiatedItemsItemContainers, List<(GameObject item, StorageItemData data)> instantiatedItemsLostAndFound)
	{
		List<(GameObject, int, AItemContainer)> list = new List<(GameObject, int, AItemContainer)>();
		foreach (var instantiatedItemsItemContainer in instantiatedItemsItemContainers)
		{
			GameObject item = instantiatedItemsItemContainer.item;
			string item2 = instantiatedItemsItemContainer.containerId;
			StorageItemData item3 = instantiatedItemsItemContainer.data;
			AItemContainer container = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.GetContainer(item2);
			int containerSlotIndex = item3.containerSlotIndex;
			if (container == null || !containerSlotIndex.IsInRange(0, container.Capacity - 1))
			{
				Debug.LogError($"Missing container with id '{item2}' for item '{item.name}' or index out of range ({containerSlotIndex}, range (0-{(container ? (container.Capacity - 1) : 0)}). Item moved to Lost and Found Storage.", item);
				MoveToLostAndFound(item, item3);
			}
			else if (container[containerSlotIndex] == null)
			{
				container.AddItem(item, containerSlotIndex);
			}
			else
			{
				list.Add((item, containerSlotIndex, container));
			}
		}
		foreach (var item7 in list)
		{
			GameObject item4 = item7.Item1;
			int item5 = item7.Item2;
			AItemContainer item6 = item7.Item3;
			int firstFreeSlot = item6.GetFirstFreeSlot();
			if (firstFreeSlot < 0)
			{
				Debug.LogError($"Container '{item6.ContainerId}' is full. Item '{item4.name}' with desired index '{item5}' moved to Lost and Found Storage.", item4);
				MoveToLostAndFound(item4, null);
				continue;
			}
			Debug.LogWarning($"Item '{item4.name}' couldn't be added to container '{item6.ContainerId}' at index {item5}. Adding it to first free slot '{firstFreeSlot}'.", item4);
			item6.AddItem(item4, firstFreeSlot);
		}
		void MoveToLostAndFound(GameObject item7, StorageItemData data)
		{
			data.itemPositionX = StorageItemTransformController.IGNORE_POSITION_VALUE.x;
			data.itemPositionY = StorageItemTransformController.IGNORE_POSITION_VALUE.y;
			data.itemPositionZ = StorageItemTransformController.IGNORE_POSITION_VALUE.z;
			instantiatedItemsLostAndFound.Add((item7, data));
		}
	}

	private void AddItemToInventoryFallback(GameObject item, bool isDropped)
	{
		if (SingletonBehaviour<Inventory>.Instance.AddItemToInventory(item, isDropped) < 0)
		{
			SingletonBehaviour<StorageController>.Instance.AddItemToStorageItemList(SingletonBehaviour<StorageController>.Instance.StorageLostAndFound, item);
			Debug.LogWarning("Couldn't add item " + item.name + " to full inventory. Item moved to Lost and Found Storage.", item);
		}
	}

	private List<InventoryItemData> CreateInventoryData(Dictionary<GameObject, StorageItemData> inventoryBelongingData)
	{
		List<InventoryItemData> list = new List<InventoryItemData>();
		foreach (KeyValuePair<GameObject, StorageItemData> inventoryBelongingDatum in inventoryBelongingData)
		{
			GameObject key = inventoryBelongingDatum.Key;
			StorageItemData value = inventoryBelongingDatum.Value;
			if (key == null || value == null)
			{
				Debug.LogError($"Unexpected inventory item data, both item and data cannot be null: item: {key}, data {value}", this);
				continue;
			}
			InventoryItemData item = new InventoryItemData(key, value.inventorySlotIndex, value.inLockedSlot, value.isDropped, value.isGrabbed);
			list.Add(item);
		}
		return list;
	}

	private GameObject InstantiateItem(StorageItemData itemData, HashSet<(ItemSaveData itemSaveData, JObject itemState)> itemSaveDataCollection, HashSet<Rigidbody> itemRigidbodies)
	{
		bool flag = !string.IsNullOrEmpty(itemData.itemPrefabName);
		GameObject gameObject = (flag ? (Resources.Load(itemData.itemPrefabName) as GameObject) : null);
		if (gameObject == null)
		{
			if (flag)
			{
				Debug.LogError("Couldn't find item prefab with the name '" + itemData.itemPrefabName + "'. Loading of item '" + itemData.itemPrefabName + "' skipped.");
			}
			return null;
		}
		Vector3 vector = ITEM_INSTANTIATION_SAFETY_OFFSET * instantiatedItemCount;
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, ITEM_INSTANTIATION_SAFETY_POSITION + vector, Quaternion.identity);
		instantiatedItemCount++;
		gameObject2.name = itemData.itemPrefabName;
		gameObject2.GetComponent<InventoryItemSpec>().BelongsToPlayer = itemData.belongsToPlayer;
		Rigidbody component = gameObject2.GetComponent<Rigidbody>();
		if (component != null)
		{
			itemRigidbodies.Add(component);
			component.isKinematic = true;
		}
		else
		{
			Debug.LogWarning("Item " + gameObject2.name + " doesn't have a rigidbody. This is not a problem but might cause issues with item physics.", gameObject2);
		}
		ItemSaveData component2 = gameObject2.GetComponent<ItemSaveData>();
		if (component2 != null)
		{
			itemSaveDataCollection.Add((component2, itemData.state));
		}
		return gameObject2;
	}

	private List<GameObject> InstantiateStorageItems(List<StorageItemData> storageItems, bool ignoreNulls, ref Dictionary<GameObject, StorageItemData> inventoryItemData, HashSet<(ItemSaveData itemSaveData, JObject itemState)> itemSaveDataCollection, HashSet<Rigidbody> itemRigidBodies)
	{
		List<GameObject> list = new List<GameObject>();
		foreach (StorageItemData storageItem in storageItems)
		{
			GameObject gameObject = ((storageItem != null) ? InstantiateItem(storageItem, itemSaveDataCollection, itemRigidBodies) : null);
			if (!(gameObject == null && ignoreNulls))
			{
				list.Add(gameObject);
				if (gameObject != null && storageItem.inventorySlotIndex >= 0)
				{
					inventoryItemData.Add(gameObject, storageItem);
				}
			}
		}
		return list;
	}

	private List<(GameObject item, StorageItemData data)> InstantiateStorageItemsLostAndFound(List<StorageItemData> storageItems, bool ignoreNulls, ref Dictionary<GameObject, StorageItemData> inventoryItemData, HashSet<(ItemSaveData itemSaveData, JObject itemState)> itemSaveDataCollection, HashSet<Rigidbody> itemRigidBodies)
	{
		List<(GameObject, StorageItemData)> list = new List<(GameObject, StorageItemData)>();
		foreach (StorageItemData storageItem in storageItems)
		{
			GameObject gameObject = ((storageItem != null) ? InstantiateItem(storageItem, itemSaveDataCollection, itemRigidBodies) : null);
			if (!(gameObject == null && ignoreNulls))
			{
				list.Add((gameObject, storageItem));
				if (gameObject != null && storageItem.inventorySlotIndex >= 0)
				{
					inventoryItemData.Add(gameObject, storageItem);
				}
			}
		}
		return list;
	}

	private Dictionary<GameObject, (Vector3, Quaternion, Rigidbody, Transform, bool)> InstantiateStorageItemsWorld(List<StorageItemData> storageItemData, Dictionary<GameObject, StorageItemData> inventoryItemData, List<StorageItemData> itemsLostAndFound, out Transform worldParent, HashSet<(ItemSaveData itemSaveData, JObject itemState)> itemSaveDataCollection, HashSet<Rigidbody> itemRigidBodiesToToggleOffKinematicState)
	{
		Dictionary<GameObject, (Vector3, Quaternion, Rigidbody, Transform, bool)> dictionary = new Dictionary<GameObject, (Vector3, Quaternion, Rigidbody, Transform, bool)>();
		Collider[] array = new Collider[16];
		LayerMask layerMask = LayerMask.GetMask("Default");
		Vector3 vector;
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			worldParent = WorldMover.OriginShiftParent;
			vector = WorldMover.currentMove;
		}
		else
		{
			worldParent = null;
			vector = default(Vector3);
		}
		foreach (StorageItemData storageItemDatum in storageItemData)
		{
			string carGuid = storageItemDatum.carGuid;
			TrainCar trainCar = null;
			if (!string.IsNullOrEmpty(carGuid))
			{
				trainCar = SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(carGuid);
				if (trainCar == null)
				{
					Debug.LogError("Car with GUID `" + carGuid + "` not found. Item '" + storageItemDatum.itemPrefabName + "' is sent to Lost and Found.", this);
					itemsLostAndFound.Add(storageItemDatum);
					continue;
				}
			}
			GameObject gameObject = InstantiateItem(storageItemDatum, itemSaveDataCollection, itemRigidBodiesToToggleOffKinematicState);
			if (gameObject == null)
			{
				continue;
			}
			Transform transform = null;
			bool item = false;
			Rigidbody item2 = null;
			Vector3 itemPosition = storageItemDatum.ItemPosition;
			Quaternion itemRotation = storageItemDatum.ItemRotation;
			if (trainCar != null)
			{
				transform = trainCar.interior;
				item = true;
				item2 = trainCar.rb;
				Rigidbody component = gameObject.GetComponent<Rigidbody>();
				itemRigidBodiesToToggleOffKinematicState.Remove(component);
			}
			else
			{
				itemPosition += vector;
				int num = Physics.OverlapSphereNonAlloc(itemPosition, 0.1f, array, layerMask, QueryTriggerInteraction.Collide);
				for (int i = 0; i < num; i++)
				{
					ItemStaticParent itemStaticParent = array[i].GetComponent<ItemStaticParent>();
					if (itemStaticParent == null)
					{
						itemStaticParent = array[i].GetComponentInParent<ItemStaticParentCollider>()?.StaticParent;
					}
					if (!(itemStaticParent == null) && itemStaticParent.ValidParentFor(gameObject.GetComponent<ItemBase>()))
					{
						transform = itemStaticParent.transform;
						break;
					}
				}
				if (transform == null)
				{
					transform = worldParent;
				}
			}
			dictionary.Add(gameObject, (itemPosition, itemRotation, item2, transform, item));
			if (storageItemDatum.inventorySlotIndex >= 0 || storageItemDatum.isGrabbed)
			{
				inventoryItemData.Add(gameObject, storageItemDatum);
			}
		}
		return dictionary;
	}

	private List<(GameObject item, string containerId, StorageItemData data)> InstantiateStorageItemsItemContainers(List<StorageItemData> itemsItemContainers, ref Dictionary<GameObject, StorageItemData> inventoryBelongingData, List<StorageItemData> itemsLostAndFound, HashSet<(ItemSaveData itemSaveData, JObject itemState)> itemSaveDataCollection, HashSet<Rigidbody> itemRigidBodiesToToggleOffKinematicState)
	{
		List<(GameObject, string, StorageItemData)> list = new List<(GameObject, string, StorageItemData)>();
		foreach (StorageItemData itemsItemContainer in itemsItemContainers)
		{
			GameObject gameObject = InstantiateItem(itemsItemContainer, itemSaveDataCollection, itemRigidBodiesToToggleOffKinematicState);
			if (!(gameObject == null))
			{
				if (itemsItemContainer.inventorySlotIndex >= 0)
				{
					inventoryBelongingData.Add(gameObject, itemsItemContainer);
				}
				ItemSaveData component = gameObject.GetComponent<ItemSaveData>();
				if (component != null)
				{
					itemSaveDataCollection.Add((component, itemsItemContainer.state));
				}
				string containerId = itemsItemContainer.containerId;
				if (string.IsNullOrWhiteSpace(containerId))
				{
					Debug.LogError("Item " + itemsItemContainer.itemPrefabName + " was saved in the container but doesn't have a valid container ID. Item moved to Lost and Found.", gameObject);
					itemsItemContainer.itemPositionX = StorageItemTransformController.IGNORE_POSITION_VALUE.x;
					itemsItemContainer.itemPositionY = StorageItemTransformController.IGNORE_POSITION_VALUE.y;
					itemsItemContainer.itemPositionZ = StorageItemTransformController.IGNORE_POSITION_VALUE.z;
					itemsLostAndFound.Add(itemsItemContainer);
				}
				else
				{
					list.Add((gameObject, containerId, itemsItemContainer));
				}
			}
		}
		return list;
	}

	private IEnumerator FinalizeItemStateLoading(Dictionary<GameObject, (Vector3, Quaternion, Rigidbody, Transform, bool)> transformData, Transform worldParent, HashSet<(ItemSaveData itemSaveData, JObject itemState)> itemSaveDataCollection, HashSet<Rigidbody> itemRigidBodiesToToggleOffKinematicState)
	{
		SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.canRegisterContainers = true;
		foreach (KeyValuePair<GameObject, (Vector3, Quaternion, Rigidbody, Transform, bool)> transformDatum in transformData)
		{
			GameObject key = transformDatum.Key;
			(Vector3, Quaternion, Rigidbody, Transform, bool) value = transformDatum.Value;
			Vector3 vector = value.Item1;
			Quaternion quaternion = value.Item2;
			Rigidbody item = value.Item3;
			Transform item2 = value.Item4;
			bool item3 = value.Item5;
			Vector3 vector2 = new Vector3(0f, 0.3f, 0f);
			if (item3)
			{
				vector2 = Vector3.zero;
				vector = item2.TransformPoint(vector);
				quaternion = item2.rotation * quaternion;
			}
			else if (worldParent != item2)
			{
				vector2 = Vector3.zero;
			}
			key.transform.SetPositionAndRotation(vector + vector2, quaternion);
			ItemReparentingBase component = key.GetComponent<ItemReparentingBase>();
			if (component != null)
			{
				component.ParentItemExternal(item2, item);
				continue;
			}
			Debug.LogError("ItemReparentingBase missing from item. Trying to fix. This can cause issues.", this);
			key.transform.SetParent(item2, worldPositionStays: true);
		}
		foreach (Rigidbody item5 in itemRigidBodiesToToggleOffKinematicState)
		{
			item5.isKinematic = false;
		}
		foreach (var (itemSaveData, data) in itemSaveDataCollection)
		{
			try
			{
				itemSaveData.LoadItemData(data);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
		foreach (var item6 in itemSaveDataCollection)
		{
			ItemSaveData item4 = item6.itemSaveData;
			try
			{
				item4.PostLoadItemData();
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
		}
		itemRigidBodiesToToggleOffKinematicState.RemoveWhere((Rigidbody rb) => rb.isKinematic);
		foreach (Rigidbody item7 in itemRigidBodiesToToggleOffKinematicState)
		{
			item7.isKinematic = true;
		}
		yield return WaitFor.FixedUpdate;
		foreach (Rigidbody item8 in itemRigidBodiesToToggleOffKinematicState)
		{
			item8.isKinematic = false;
		}
	}
}
