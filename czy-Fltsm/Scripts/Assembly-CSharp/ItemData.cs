using System.Collections.Generic;

public class ItemData
{
	private int _storageCapacity;

	private bool _updateStorageCapacty;

	public ItemProperties ItemProperties { get; private set; }

	public List<Storage> Storages { get; private set; } = new List<Storage>();

	public List<ItemDataItemProvider> ItemProviders { get; private set; } = new List<ItemDataItemProvider>();

	public ItemData(ItemProperties itemProperties)
	{
		ItemProperties = itemProperties;
	}

	public void AddStorage(Storage storage)
	{
		storage.e_FilterUpdated.AddListener(OnStorageFilterUpdate);
		OnStorageFilterUpdate(storage);
	}

	public void RemoveStorage(Storage storage)
	{
		storage.e_FilterUpdated.RemoveListener(OnStorageFilterUpdate);
		Storages.Remove(storage);
		storage.Updated -= OnStorageUpdated;
		OnStorageUpdated();
	}

	public void AddItemProvider(ItemDataItemProvider itemProvider)
	{
		itemProvider.InventoryLateUpdated += OnItemProviderUpdated;
		OnItemProviderUpdated(itemProvider);
	}

	public void RemoveItemProvider(ItemDataItemProvider itemProvider)
	{
		if (itemProvider != null)
		{
			ItemProviders.Remove(itemProvider);
			itemProvider.InventoryLateUpdated -= OnItemProviderUpdated;
		}
	}

	private void OnStorageFilterUpdate(Storage storage)
	{
		if (storage.AcceptsItem(ItemProperties))
		{
			if (Storages.AddUnique(storage))
			{
				storage.Updated += OnStorageUpdated;
				OnStorageUpdated();
			}
		}
		else if (Storages.Remove(storage))
		{
			storage.Updated -= OnStorageUpdated;
			OnStorageUpdated();
		}
	}

	private void OnStorageUpdated()
	{
		_updateStorageCapacty = true;
	}

	private void OnItemProviderUpdated(ItemDataItemProvider itemProvider)
	{
		if (itemProvider.ContainsUnreservedItem(ItemProperties))
		{
			ItemProviders.AddUnique(itemProvider);
		}
		else
		{
			ItemProviders.Remove(itemProvider);
		}
	}

	public void PopulateItemProviders(IPathfindingNodeProvider destination, List<ItemDataItemProvider> itemProviders)
	{
		foreach (ItemDataItemProvider itemProvider in ItemProviders)
		{
			if (!itemProviders.Contains(itemProvider) && itemProvider.ReturnItemCount(ItemProperties) > 0)
			{
				itemProvider.PopulatePath(destination);
				itemProviders.Add(itemProvider);
			}
		}
	}

	public bool ReturnFitsItem()
	{
		if (!ItemProperties.IsQuestItem)
		{
			return 0 < ReturnStorageCapacity();
		}
		return true;
	}

	public int ReturnStorageCapacity()
	{
		if (_updateStorageCapacty)
		{
			if (ItemProperties.IsQuestItem)
			{
				_storageCapacity = int.MaxValue;
			}
			_storageCapacity = ReturnUnlimitedStorageCapacity();
			_updateStorageCapacty = false;
		}
		return _storageCapacity;
	}

	private int ReturnUnlimitedStorageCapacity()
	{
		int num = 0;
		foreach (Storage storage in Storages)
		{
			num += storage.ReturnAvailableCapacity(ItemProperties);
		}
		return num;
	}

	public int ReturnItemCount(bool includedReserved = false)
	{
		int num = 0;
		foreach (ItemDataItemProvider itemProvider in ItemProviders)
		{
			num += itemProvider.ReturnItemCount(ItemProperties, includedReserved);
		}
		return num;
	}

	public int ReturnStoredAndIncomingItemCount(bool includedReserved = false)
	{
		int num = 0;
		foreach (ItemDataItemProvider itemProvider in ItemProviders)
		{
			num += itemProvider.ReturnStoredAndIncomingItemCount(ItemProperties, includedReserved);
		}
		return num;
	}
}
