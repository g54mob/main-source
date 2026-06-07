using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommunityInventory : ICommunalInventory, IInventorySpaceLimiter
{
	private bool _hasUpdates;

	private readonly List<Storage> _storages = new List<Storage>();

	private readonly List<ResourceProvider> _resourceProviders = new List<ResourceProvider>();

	private readonly SortedDictionary<int, List<ResourceProvider>> _prioritizedResourceProviders = new SortedDictionary<int, List<ResourceProvider>>();

	private int _storageCount;

	private int _resourceProviderCount;

	private readonly SortInventoriesByDistance _distanceSorter = new SortInventoriesByDistance();

	private int _updateIndex;

	private ItemData[] _itemData;

	public UnityEvent InventoryUpdatedEvent { get; } = new UnityEvent();

	public CommunityInventory()
	{
		InitializeItemData();
	}

	public void LateUpdate()
	{
		if (_hasUpdates)
		{
			if (InventoryUpdatedEvent != null)
			{
				InventoryUpdatedEvent.Invoke();
			}
			GameEventDispatcher.Dispatch(GameEventType.CommunityInventoryUpdated);
			_hasUpdates = false;
		}
		if (_updateIndex < _resourceProviderCount)
		{
			_resourceProviders[_updateIndex++].Update();
		}
		else
		{
			_updateIndex = 0;
		}
	}

	private void InitializeItemData()
	{
		using ListPool<ItemProperties>.List list = ListPool<ItemProperties>.Get(192);
		_itemData = new ItemData[192];
		GameManager.PersistenceManager.PopulateReferences(PersistentProperties.Types.ItemProperties, list);
		foreach (ItemProperties item in list)
		{
			if (_itemData[item.Id] == null)
			{
				_itemData[item.Id] = new ItemData(item);
			}
			else
			{
				Debug.LogException(new Exception($"'{_itemData[item.Id].ItemProperties}' and '{item}' have the same ID! PersistentProperties is up-to-date and the ItemProperties.Ids are validated."));
			}
		}
	}

	public void AddItemProvider(ItemDataItemProvider itemProvider)
	{
		if (itemProvider != null)
		{
			ItemData[] itemData = _itemData;
			for (int i = 0; i < itemData.Length; i++)
			{
				itemData[i]?.AddItemProvider(itemProvider);
			}
		}
	}

	public void RemoveItemProvier(ItemDataItemProvider itemProvider)
	{
		ItemData[] itemData = _itemData;
		for (int i = 0; i < itemData.Length; i++)
		{
			itemData[i]?.RemoveItemProvider(itemProvider);
		}
	}

	public HashSet<ItemProperties> ReturnItemFilter(Item.Tags tags)
	{
		HashSet<ItemProperties> hashSet = new HashSet<ItemProperties>();
		ItemData[] itemData = _itemData;
		foreach (ItemData itemData2 in itemData)
		{
			if (itemData2 != null && (itemData2.ItemProperties.Tags & tags) != Item.Tags.None)
			{
				hashSet.Add(itemData2.ItemProperties);
			}
		}
		return hashSet;
	}

	public void AddStorage(Storage storage)
	{
		ItemData[] itemData = _itemData;
		for (int i = 0; i < itemData.Length; i++)
		{
			itemData[i]?.AddStorage(storage);
		}
		if (_storages.AddUnique(storage))
		{
			storage.Updated += OnStorageUpdated;
			_storageCount++;
			OnStorageUpdated();
		}
	}

	public void AddResourceProvider(ResourceProvider provider)
	{
		ItemData[] itemData = _itemData;
		for (int i = 0; i < itemData.Length; i++)
		{
			itemData[i]?.AddItemProvider(provider);
		}
		if (_resourceProviders.AddUnique(provider))
		{
			provider.InventoryUpdated += OnResourceProviderUpdated;
			_resourceProviderCount++;
			OnResourceProviderUpdated();
		}
	}

	public void RemoveStorage(Storage storage)
	{
		ItemData[] itemData = _itemData;
		for (int i = 0; i < itemData.Length; i++)
		{
			itemData[i]?.RemoveStorage(storage);
		}
		if (_storages.Remove(storage))
		{
			storage.Updated += OnStorageUpdated;
			_storageCount--;
			OnStorageUpdated();
		}
	}

	public void RemoveResourceProvider(ResourceProvider provider)
	{
		ItemData[] itemData = _itemData;
		for (int i = 0; i < itemData.Length; i++)
		{
			itemData[i]?.RemoveItemProvider(provider);
		}
		if (_resourceProviders.Remove(provider))
		{
			provider.InventoryUpdated -= OnResourceProviderUpdated;
			_resourceProviderCount--;
			OnResourceProviderUpdated();
		}
	}

	private void OnStorageUpdated()
	{
		_hasUpdates = true;
	}

	private void OnResourceProviderUpdated(ItemDataItemProvider itemProvider = null)
	{
		_hasUpdates = true;
	}

	public bool ReturnContainsItems(IEnumerable<CountedItemProperty> countedItems, SubInventoryType subInventory = SubInventoryType.Storage)
	{
		foreach (CountedItemProperty countedItem in countedItems)
		{
			if (!ReturnContainsItem(countedItem.ItemProperties, countedItem.Amount))
			{
				return false;
			}
		}
		return true;
	}

	public bool ReturnContainsItem(ItemProperties itemProperties, int amount, bool includeReserved = false)
	{
		return amount <= _itemData[itemProperties.Id].ReturnItemCount();
	}

	public bool TryReturnReserveClosestItems(IPathfindingNodeProvider destination, IReadOnlyList<CountedItemProperty> countedItems, out List<Item> reservedItems)
	{
		if (countedItems.Count == 1)
		{
			return TryReserveClosestItems(destination, countedItems[0], out reservedItems);
		}
		return TryReturnReserveClosestItems_ItemData(destination, countedItems, out reservedItems);
	}

	public bool TryReturnReserveClosestItems(IPathfindingNodeProvider destination, CountedItemProperty[] countedItems, out List<Item> reservedItems)
	{
		if (countedItems.Length == 1)
		{
			return TryReserveClosestItems(destination, countedItems[0], out reservedItems);
		}
		return TryReturnReserveClosestItems_ItemData(destination, countedItems, out reservedItems);
	}

	private bool TryReserveClosestItems(IPathfindingNodeProvider destination, CountedItemProperty countedItem, out List<Item> reservedItems)
	{
		return TryReserveClosestItems(destination, countedItem.ItemProperties, countedItem.Amount, out reservedItems);
	}

	private bool TryReturnReserveClosestItems_ItemData(IPathfindingNodeProvider destination, IEnumerable<CountedItemProperty> countedItems, out List<Item> reservedItems)
	{
		using ListPool<ItemDataItemProvider>.List list = ListPool<ItemDataItemProvider>.Get();
		foreach (CountedItemProperty countedItem in countedItems)
		{
			countedItem.ReservedAmount = 0;
			_itemData[countedItem.ItemProperties.Id].PopulateItemProviders(destination, list);
		}
		Sorting.SlowSort(list, _distanceSorter);
		reservedItems = new List<Item>();
		foreach (ItemDataItemProvider item in list)
		{
			if (item.ReserveItems(countedItems, reservedItems))
			{
				return true;
			}
		}
		throw new NotSupportedException("Items could not be reserved!");
	}

	public bool TryReserveClosestItems(IPathfindingNodeProvider destination, ItemProperties itemProperties, int amount, out List<Item> reservedItems)
	{
		using ListPool<ItemDataItemProvider>.List list = ListPool<ItemDataItemProvider>.Get();
		reservedItems = new List<Item>();
		foreach (ItemDataItemProvider itemProvider in _itemData[itemProperties.Id].ItemProviders)
		{
			if (0 < itemProvider.ReturnItemCount(itemProperties))
			{
				list.Add(itemProvider);
			}
		}
		while (0 < list.Count && reservedItems.Count < amount)
		{
			ItemDataItemProvider itemDataItemProvider = TownQueryCache.ReturnClosestDestination(destination, list);
			itemDataItemProvider.ReserveItems(itemProperties, amount, reservedItems);
			list.Remove(itemDataItemProvider);
		}
		return reservedItems.Count == amount;
	}

	public bool TryReserveItems(ItemProperties itemProperties, int amount, out List<Item> reservedItems)
	{
		ItemData itemData = _itemData[itemProperties.Id];
		reservedItems = null;
		if (itemData.ReturnItemCount() < amount)
		{
			return false;
		}
		reservedItems = new List<Item>();
		foreach (ItemDataItemProvider itemProvider in itemData.ItemProviders)
		{
			itemProvider.ReserveItems(itemProperties, amount, reservedItems);
			if (reservedItems.Count == amount)
			{
				return true;
			}
		}
		Debug.LogException(new Exception($"Unable to reserve {amount} '{itemProperties.name}'"));
		return false;
	}

	public bool TryReserveItem(ItemProperties itemProperties, out Item item)
	{
		ItemData itemData = _itemData[itemProperties.Id];
		if (0 < itemData.ReturnItemCount())
		{
			using ListPool<Item>.List list = ListPool<Item>.Get();
			foreach (ItemDataItemProvider itemProvider in itemData.ItemProviders)
			{
				itemProvider.ReserveItems(itemProperties, 1, list);
				if (list.Count == 1)
				{
					item = list[0];
					return true;
				}
			}
			Debug.LogException(new Exception("Unable to reserve '" + itemProperties.name + "'"));
		}
		item = null;
		return false;
	}

	public bool FitsItem(Item item)
	{
		if (!item.MoveToInventory)
		{
			return FitsItem(item.Properties);
		}
		return true;
	}

	public bool FitsItem(ItemProperties itemProperties)
	{
		return _itemData[itemProperties.Id].ReturnFitsItem();
	}

	public int GetCapacity(ItemProperties itemProperties)
	{
		return _itemData[itemProperties.Id].ReturnStorageCapacity();
	}

	public bool ReturnFitsItemWithProperties(ItemProperties itemProperties)
	{
		return _itemData[itemProperties.Id].ReturnFitsItem();
	}

	public bool ReturnFitsAnyItem(List<Item> items)
	{
		if (items == null || items.Count == 0)
		{
			return true;
		}
		using ListPool<Item>.List list = ItemHelper.ReturnUniqueItems(items);
		foreach (Item item in list)
		{
			if (FitsItem(item))
			{
				return true;
			}
		}
		return false;
	}

	public int ReturnItemContainingTagCount(Item.Tags tag, bool includeReserved = false)
	{
		int num = 0;
		ItemData[] itemData = _itemData;
		foreach (ItemData itemData2 in itemData)
		{
			if (itemData2 != null && itemData2.ItemProperties.Tags.HasFlag(tag))
			{
				num += itemData2.ReturnItemCount(includeReserved);
			}
		}
		return num;
	}

	public InventoryAuditor ReturnStorageCount(params SubInventoryType[] subInventories)
	{
		InventoryAuditor auditor = Inventory.Auditor;
		auditor.Reset();
		foreach (Storage storage in _storages)
		{
			foreach (SubInventoryType subInventoryType in subInventories)
			{
				storage.Count(auditor, subInventoryType);
			}
		}
		foreach (ResourceProvider resourceProvider in _resourceProviders)
		{
			if (!resourceProvider.IsStorage)
			{
				resourceProvider.Count(auditor);
			}
		}
		return auditor;
	}

	public int ReturnCapacity(SubInventoryType subInventory = SubInventoryType.Storage)
	{
		int num = 0;
		for (int i = 0; i < _storageCount; i++)
		{
			num += _storages[i].ReturnCapacity(subInventory);
		}
		return num;
	}

	public int ReturnCapacity(Item.Tags tag)
	{
		int num = 0;
		for (int i = 0; i < _storageCount; i++)
		{
			num += _storages[i].ReturnCapacity(tag);
		}
		return num;
	}

	public int ReturnCount(ItemProperties itemProperties, SubInventoryType subInventory = SubInventoryType.Storage, bool includeReserved = false)
	{
		return _itemData[itemProperties.Id].ReturnItemCount(includeReserved);
	}

	public int ReturnCount(ItemType itemType, bool includeReserved = false)
	{
		int num = 0;
		ItemData[] itemData = _itemData;
		foreach (ItemData itemData2 in itemData)
		{
			if (itemData2 != null && !(itemData2.ItemProperties.ItemType != itemType))
			{
				num += itemData2.ReturnItemCount(includeReserved);
			}
		}
		return num;
	}

	public int ReturnCount(SubInventoryType inventoryType = SubInventoryType.Storage, bool includeReserved = false)
	{
		int num = 0;
		for (int i = 0; i < _storageCount; i++)
		{
			num += _storages[i].ReturnCount(inventoryType, includeReserved);
		}
		for (int j = 0; j < _resourceProviderCount; j++)
		{
			num += _resourceProviders[j].ReturnCount(includeReserved);
		}
		return num;
	}

	public int ReturnCount(Item.Tags tag, bool includeReserved = false)
	{
		int num = 0;
		for (int i = 0; i < _storageCount; i++)
		{
			num += _storages[i].ReturnCount(tag, includeReserved);
		}
		return num;
	}

	public int ReturnStoredItemCount(ItemProperties itemProperties, bool includeReserved = false)
	{
		return _itemData[itemProperties.Id].ReturnStoredAndIncomingItemCount(includeReserved);
	}

	public float ReturnNutritionalValue(Item.Tags tag, bool includeReserved = false)
	{
		float num = 0f;
		for (int i = 0; i < _resourceProviderCount; i++)
		{
			num += _resourceProviders[i].ReturnNutritionalValue(tag, includeReserved);
		}
		return num;
	}

	public Item ReturnItem(ItemProperties itemProperties, SubInventoryType subInventory)
	{
		for (int i = 0; i < _storageCount; i++)
		{
			Item item = _storages[i].ReturnItem(itemProperties, subInventory);
			if (item != null)
			{
				return item;
			}
		}
		for (int j = 0; j < _resourceProviderCount; j++)
		{
			Item item = _resourceProviders[j].ReturnItem(itemProperties);
			if (item != null)
			{
				return item;
			}
		}
		return null;
	}

	public int ReturnIncomingItemsAmount(SubInventoryType subInventory)
	{
		int num = 0;
		for (int i = 0; i < _storageCount; i++)
		{
			num += _storages[i].ReturnIncomingItemCount(subInventory);
		}
		return num;
	}

	public int ReturnIncomingItemsAmount(Item.Tags tags)
	{
		int num = 0;
		for (int i = 0; i < _storageCount; i++)
		{
			num += _storages[i].ReturnIncomingItemCount(tags);
		}
		return num;
	}

	public List<Item> GetAllItems(SubInventoryType subInventoryType)
	{
		List<Item> list = new List<Item>();
		for (int i = 0; i < _storageCount; i++)
		{
			_storages[i].PopulateAllItems(list, subInventoryType);
		}
		return list;
	}

	public bool ReturnHasResourceProviderWithExportableItems()
	{
		for (int i = 0; i < _resourceProviderCount; i++)
		{
			if (_resourceProviders[i].HasExportableItems())
			{
				return true;
			}
		}
		return false;
	}

	public void PopulateResourceProviders(Agent agent, int haulingPriority, bool applyCapacityPriority, List<ResourceProvider> resourceProviders)
	{
		if (!_resourceProviders.IsNullOrEmpty())
		{
			resourceProviders.AddRange(_resourceProviders);
		}
	}

	public bool TryReturnPrioritizedResourceProvider(out ResourceProvider resourceProvider, AssignmentType prioritizedAssignmentTypes, int prioritizedAssignmentTypesPriority, int haulingPriority)
	{
		resourceProvider = null;
		if (_resourceProviders.IsNullOrEmpty())
		{
			return false;
		}
		using ListPool<ResourceProvider>.List list = ListPool<ResourceProvider>.Get(_resourceProviders.Count);
		foreach (ResourceProvider resourceProvider2 in _resourceProviders)
		{
			int num = (((prioritizedAssignmentTypes & resourceProvider2.AssignmentType) != AssignmentType.None) ? prioritizedAssignmentTypesPriority : haulingPriority);
			if (num > 0)
			{
				resourceProvider2.UpdatePriority(num);
				if (0 < resourceProvider2.Priority)
				{
					list.Add(resourceProvider2);
				}
			}
		}
		if (list.Count == 0)
		{
			return false;
		}
		Sorting.SlowSort(list);
		resourceProvider = list[0];
		return true;
	}

	public Item ReturnAvailableResourceProviderItem(AssignmentType assignmentType = AssignmentType.Hauling)
	{
		bool flag = assignmentType == AssignmentType.Hauling;
		for (int i = 0; i < _resourceProviderCount; i++)
		{
			ResourceProvider resourceProvider = _resourceProviders[i];
			if ((flag || (assignmentType & resourceProvider.AssignmentType) != AssignmentType.None) && resourceProvider.TryReturnFirstExportableItem(out var item))
			{
				return item;
			}
		}
		return null;
	}

	public AssignmentType ReturnResourceProvidersAssignmentTypes()
	{
		AssignmentType assignmentType = AssignmentType.None;
		for (int i = 0; i < _resourceProviderCount; i++)
		{
			ResourceProvider resourceProvider = _resourceProviders[i];
			if (resourceProvider.CanEmpty)
			{
				assignmentType |= resourceProvider.AssignmentType;
			}
		}
		return assignmentType;
	}

	public int ReturnItemCapacity(ItemProperties itemProperties)
	{
		return _itemData[itemProperties.Id].ReturnStorageCapacity();
	}

	public List<ItemProperties> ReturnItemPropertiesWithTags(Item.Tags tags)
	{
		List<ItemProperties> list = new List<ItemProperties>();
		ItemData[] itemData = _itemData;
		foreach (ItemData itemData2 in itemData)
		{
			if (itemData2 != null && (itemData2.ItemProperties.Tags & tags) == tags)
			{
				list.Add(itemData2.ItemProperties);
			}
		}
		return list;
	}
}
