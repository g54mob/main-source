using System.Collections.Generic;
using UnityEngine;

public class TownheartStorage : Storage
{
	[SerializeField]
	private int _liquidCapacity;

	[SerializeField]
	private Item.Tags _liquidTags = Item.Tags.Drink | Item.Tags.Liquid;

	private SubInventory _liquidInventory;

	private StorageResourceProvider _resourceProviderLiquid;

	private ResourceProvider _shutdownResourceProviderLiquid;

	private ItemDataItemProvider _itemDataItemProviderLiquid;

	public override void Initialize(Buildable buildable, bool restored = false)
	{
		Initialize(buildable, SubInventoryType.Storage);
		_liquidInventory = buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Liquid, _liquidCapacity);
		Construction.Townheart = buildable.ReturnExtendable<Construction>();
	}

	public override void Finish(bool restored = false)
	{
		base.Finish(restored);
		base.Buildable.Community.Inventory.AddItemProvider(_itemDataItemProviderLiquid);
		_shutdownResourceProviderLiquid?.Unregister();
		_liquidInventory.Updated += base.OnStorageInventoryUpdated;
		if (_resourceProviderLiquid == null)
		{
			_resourceProviderLiquid = new StorageResourceProvider(this, SubInventoryType.Liquid);
		}
		_resourceProviderLiquid.Register();
	}

	public override void Remove()
	{
		base.Remove();
		base.Buildable.Community.Inventory.RemoveItemProvier(_itemDataItemProviderLiquid);
		_liquidInventory.Updated -= base.OnStorageInventoryUpdated;
		_resourceProviderLiquid?.Unregister();
		_shutdownResourceProviderLiquid?.Unregister();
	}

	public override void Count(InventoryAuditor auditor, SubInventoryType subInventoryType)
	{
		if (subInventoryType == SubInventoryType.Liquid)
		{
			auditor.CountInventory(_liquidInventory);
		}
		else
		{
			base.Count(auditor, subInventoryType);
		}
	}

	public override void PopulateAllItems(List<Item> allItems, SubInventoryType subInventoryType)
	{
		if (subInventoryType == SubInventoryType.Liquid)
		{
			_liquidInventory.ReturnAllItems(allItems);
		}
		else
		{
			base.PopulateAllItems(allItems, subInventoryType);
		}
	}

	public override bool ReserveIncomingItem(Item item)
	{
		if (base.Buildable.BuildPhase == BuildPhase.Finished && IsLiquid(item))
		{
			return base.Buildable.Inventory.ReserveIncomingItem(item, SubInventoryType.Liquid);
		}
		return base.ReserveIncomingItem(item);
	}

	protected override void UnreserveStuckItems()
	{
		base.UnreserveStuckItems();
		base.Buildable.Community.UnreserveStuckItems(base.Buildable.Inventory, SubInventoryType.Liquid);
	}

	public override void Shutdown()
	{
		base.Shutdown();
		if (_shutdownResourceProviderLiquid == null)
		{
			_shutdownResourceProviderLiquid = ResourceProvider.Get(base.Buildable, SubInventoryType.Liquid, AssignmentType.Constructing);
		}
		_shutdownResourceProviderLiquid.Register();
	}

	public override bool CanBeSalvaged()
	{
		if (base.CanBeSalvaged() && _liquidInventory.ReturnItemCount(includeReserved: true) <= 0)
		{
			return _liquidInventory.IncomingItems.Count == 0;
		}
		return false;
	}

	public override bool AcceptsItem(ItemProperties itemProperties)
	{
		if (!itemProperties.ExcludeFromItemFilter)
		{
			return base.AcceptsItem(itemProperties);
		}
		return true;
	}

	public override int ReturnCount(SubInventoryType subInventoryType, bool includeReserved)
	{
		if (subInventoryType == SubInventoryType.Liquid)
		{
			return _liquidInventory.ReturnItemCount(includeReserved);
		}
		return base.ReturnCount(subInventoryType, includeReserved);
	}

	public override int ReturnCount(Item.Tags itemTags, bool includeReserved)
	{
		if (IsLiquid(itemTags))
		{
			return _liquidInventory.ReturnItemCount(includeReserved);
		}
		return base.ReturnCount(itemTags, includeReserved);
	}

	public override int ReturnAvailableCapacity(ItemProperties itemProperties)
	{
		if (IsLiquid(itemProperties))
		{
			return _liquidInventory.AvailableCapacity - _liquidInventory.IncomingItems.Count;
		}
		return base.ReturnAvailableCapacity(itemProperties);
	}

	public override int ReturnCapacity(SubInventoryType subInventoryType)
	{
		if (subInventoryType == SubInventoryType.Liquid)
		{
			return _liquidInventory.Capacity;
		}
		return base.ReturnCapacity(subInventoryType);
	}

	public override int ReturnCapacity(Item.Tags itemTags)
	{
		if (IsLiquid(itemTags))
		{
			return _liquidInventory.Capacity;
		}
		return base.ReturnCapacity(itemTags);
	}

	public override Item ReturnItem(ItemProperties itemProperties, SubInventoryType subInventoryType)
	{
		if (subInventoryType == SubInventoryType.Liquid)
		{
			return _liquidInventory.ReturnItemFromProperties(itemProperties);
		}
		return base.ReturnItem(itemProperties, subInventoryType);
	}

	public override int ReturnIncomingItemCount(SubInventoryType subInventoryType)
	{
		if (subInventoryType == SubInventoryType.Liquid)
		{
			return _liquidInventory.IncomingItems.Count;
		}
		return base.ReturnIncomingItemCount(subInventoryType);
	}

	public override int ReturnIncomingItemCount(Item.Tags tags)
	{
		if (IsLiquid(tags))
		{
			return _liquidInventory.IncomingItems.Count;
		}
		return base.ReturnIncomingItemCount(tags);
	}

	public override bool HasItemIncoming(Item item)
	{
		if (IsLiquid(item))
		{
			return _liquidInventory.IncomingItems.Contains(item);
		}
		return base.HasItemIncoming(item);
	}

	private bool IsLiquid(Item item)
	{
		if (item != null)
		{
			return IsLiquid(item.Properties);
		}
		return false;
	}

	private bool IsLiquid(ItemProperties itemProperties)
	{
		if (itemProperties != null)
		{
			return IsLiquid(itemProperties.Tags);
		}
		return false;
	}

	private bool IsLiquid(Item.Tags tags)
	{
		return (tags & _liquidTags) != 0;
	}
}
