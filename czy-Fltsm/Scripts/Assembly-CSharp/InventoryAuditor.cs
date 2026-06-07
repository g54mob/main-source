using System;
using System.Collections.Generic;

public class InventoryAuditor
{
	public enum CountType
	{
		Unreserved = 0,
		Reserved = 1,
		All = 2
	}

	[Serializable]
	public class CountedItem : IComparable<CountedItem>
	{
		public ItemProperties ItemProperties;

		public int Index;

		public int UnreservedCount;

		public int ReservedCount;

		public bool WasCounted;

		public CountedItem(ItemProperties itemProperties)
		{
			ItemProperties = itemProperties;
			Index = GameSettings.Instance.ItemSettings.ItemProperties.IndexOf(itemProperties);
		}

		public int ReturnCount(CountType type)
		{
			return type switch
			{
				CountType.Reserved => ReservedCount, 
				CountType.Unreserved => UnreservedCount, 
				_ => ReservedCount + UnreservedCount, 
			};
		}

		public int CompareTo(CountedItem other)
		{
			return Index - other.Index;
		}
	}

	public enum Mode
	{
		All = 0,
		NotAssignedToProject = 1
	}

	public CountedItem[] _countedItemArray;

	private readonly Mode _mode;

	private List<CountedItem> _nonZeroCountedItems;

	private static InventoryAuditor _global;

	public int TotalItemCount { get; private set; }

	public List<CountedItem> CountedItems { get; }

	public static InventoryAuditor Global
	{
		get
		{
			if (_global == null)
			{
				_global = new InventoryAuditor();
			}
			return _global;
		}
	}

	public InventoryAuditor()
	{
		_countedItemArray = new CountedItem[192];
		_mode = Mode.All;
		CountedItems = new List<CountedItem>(192);
	}

	public InventoryAuditor(Mode mode)
		: this()
	{
		_mode = mode;
	}

	public void CountInventory(SubInventory inventory)
	{
		List<IInventorySlot> slots = inventory.Slots;
		int count = slots.Count;
		for (int i = 0; i < count; i++)
		{
			IncreaseOrAddItemCount(slots[i]);
		}
	}

	public void CountItems(List<Item> items, bool reset = true)
	{
		if (reset)
		{
			Reset();
		}
		int count = items.Count;
		for (int i = 0; i < count; i++)
		{
			CountOrAddItem(items[i]);
		}
	}

	public void CountItemProperties(List<ItemProperties> itemProperties)
	{
		int count = itemProperties.Count;
		for (int i = 0; i < count; i++)
		{
			CountOrAddItem(itemProperties[i]);
		}
	}

	public void CountItemProperties(ItemProperties itemProperties, int count = 1)
	{
		CountOrAddItem(itemProperties, count);
	}

	public void CountItemProperties(IEnumerable<CountedItemProperty> countedItemProperties)
	{
		foreach (CountedItemProperty countedItemProperty in countedItemProperties)
		{
			CountOrAddItem(countedItemProperty.ItemProperties, countedItemProperty.Amount);
		}
	}

	public void Reset()
	{
		CountedItem[] countedItemArray = _countedItemArray;
		foreach (CountedItem countedItem in countedItemArray)
		{
			if (countedItem != null)
			{
				countedItem.UnreservedCount = 0;
				countedItem.ReservedCount = 0;
				countedItem.WasCounted = false;
			}
		}
		TotalItemCount = 0;
	}

	private void IncreaseOrAddItemCount(IInventorySlot slot)
	{
		int unreservedCount = slot.UnreservedCount;
		int reservedCount = slot.ReservedCount;
		int num = unreservedCount + reservedCount;
		if (TryReturnCountedItem(slot.ItemProperties, out var countedItem))
		{
			countedItem.UnreservedCount += unreservedCount;
			countedItem.ReservedCount += reservedCount;
			countedItem.WasCounted = true;
		}
		else
		{
			AddCountedItem(slot.ItemProperties, unreservedCount, reservedCount);
		}
		TotalItemCount += num;
	}

	private void CountOrAddItem(Item item)
	{
		if (_mode != Mode.NotAssignedToProject || item.Project == null || !item.Project.IsCommunityProject)
		{
			CountOrAddItem(item.Properties);
		}
	}

	private void CountOrAddItem(ItemProperties itemProperties, int count = 1)
	{
		if (TryReturnCountedItem(itemProperties, out var countedItem))
		{
			countedItem.UnreservedCount += count;
		}
		else
		{
			AddCountedItem(itemProperties, count);
		}
		TotalItemCount += count;
	}

	private void AddCountedItem(ItemProperties itemProperties, int unreservedCount, int reservedCount = 0)
	{
		if (!itemProperties.IsNull())
		{
			CountedItem countedItem = new CountedItem(itemProperties)
			{
				UnreservedCount = unreservedCount,
				ReservedCount = reservedCount,
				WasCounted = true
			};
			_countedItemArray[itemProperties.Id] = countedItem;
			CountedItems.Add(countedItem);
		}
	}

	public int ReturnItemCount(ItemProperties itemProperties)
	{
		if (!TryReturnCountedItem(itemProperties, out var countedItem))
		{
			return 0;
		}
		return countedItem.UnreservedCount;
	}

	public List<CountedItem> ReturnNonZeroCountedItems()
	{
		if (_nonZeroCountedItems == null)
		{
			_nonZeroCountedItems = new List<CountedItem>(192);
		}
		else
		{
			_nonZeroCountedItems.Clear();
		}
		CountedItem[] countedItemArray = _countedItemArray;
		foreach (CountedItem countedItem in countedItemArray)
		{
			if (countedItem != null && (countedItem.UnreservedCount != 0 || countedItem.ReservedCount != 0))
			{
				_nonZeroCountedItems.Add(countedItem);
			}
		}
		return _nonZeroCountedItems;
	}

	public ItemProperties ReturnNonZeroItem()
	{
		CountedItem[] countedItemArray = _countedItemArray;
		foreach (CountedItem countedItem in countedItemArray)
		{
			if (countedItem != null && (countedItem.UnreservedCount != 0 || countedItem.ReservedCount != 0))
			{
				return countedItem.ItemProperties;
			}
		}
		return null;
	}

	private bool TryReturnCountedItem(ItemProperties itemProperties, out CountedItem countedItem)
	{
		if (itemProperties.IsNull())
		{
			countedItem = null;
			return false;
		}
		countedItem = _countedItemArray[itemProperties.Id];
		return countedItem != null;
	}
}
