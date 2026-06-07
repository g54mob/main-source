using System.Collections.Generic;

public class StorageResourceProvider : ResourceProvider
{
	private Storage _storage;

	private SubInventory _subInventory;

	private bool _hasItemsToExport;

	public StorageResourceProvider(Storage storage, SubInventoryType subInventory = SubInventoryType.Storage)
		: base(storage.Buildable, subInventory, AssignmentType.Hauling)
	{
		_storage = storage;
		_subInventory = storage.Buildable.Inventory.ReturnInventory(subInventory);
	}

	public override void Register()
	{
		base.Register();
		_storage.Filter.OnUpdated.AddListener(OnFilterUpdated);
		OnFilterUpdated();
	}

	public override void Unregister()
	{
		base.Unregister();
		_storage.Filter.OnUpdated.RemoveListener(OnFilterUpdated);
	}

	public override bool HasExportableItems()
	{
		Item item;
		return TryReturnFirstExportableItem(out item, base.RegisteredCommunity.Inventory);
	}

	public override bool TryReturnFirstExportableItem(out Item item, IInventorySpaceLimiter limiter = null)
	{
		item = null;
		if (base.Locked || !_hasItemsToExport)
		{
			return false;
		}
		foreach (IInventorySlot slot in _subInventory.Slots)
		{
			if (slot.UnreservedCount != 0 && !_storage.AcceptsItem(slot.ItemProperties) && slot.TryReturnFirstAvailableItem(base.SubInventoryType, out item, limiter))
			{
				return true;
			}
		}
		return false;
	}

	public override void PopulateUnreservedItems(List<ItemProperties> itemProperties)
	{
		SubInventory subInventory = base.Inventory.ReturnInventory(base.SubInventoryType);
		if (base.Locked || subInventory.IsEmpty)
		{
			return;
		}
		foreach (InventorySlot slot in subInventory.Slots)
		{
			if (!_storage.AcceptsItem(slot.ItemProperties) && slot.ReturnHasUnreservedItem())
			{
				itemProperties.AddUnique(slot.ItemProperties);
			}
		}
	}

	protected override void UpdateBlocked()
	{
	}

	protected override float ReturnPriority()
	{
		if (base.Locked || !_hasItemsToExport)
		{
			return 0f;
		}
		foreach (InventorySlot slot in _subInventory.Slots)
		{
			if (!_storage.AcceptsItem(slot.ItemProperties) && slot.ReturnHasUnreservedItem())
			{
				return 1f;
			}
		}
		return 0f;
	}

	public override int GetAssignmentPriority(Agent agent, int haulingPriority)
	{
		return haulingPriority;
	}

	protected override void OnInventoryUpdate()
	{
		base.OnInventoryUpdate();
		OnFilterUpdated();
	}

	private void OnFilterUpdated()
	{
		_hasItemsToExport = HasItemsToExport();
	}

	private bool HasItemsToExport()
	{
		if (base.SubInventory.IsEmpty)
		{
			return false;
		}
		foreach (IInventorySlot slot in _subInventory.Slots)
		{
			if (slot.UnreservedCount != 0 && !_storage.AcceptsItem(slot.ItemProperties))
			{
				return true;
			}
		}
		return false;
	}
}
