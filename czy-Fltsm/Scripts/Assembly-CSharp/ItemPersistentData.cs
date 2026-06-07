using System;
using System.Collections.Generic;

[Serializable]
public class ItemPersistentData : PersistentReference<Item>
{
	public int PropertiesIndex;

	public bool IsReserved;

	public bool IsSalvageAble;

	public ItemPersistentData(Item item)
		: base(item)
	{
		PropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(item.Properties);
		IsReserved = item.IsReserved;
		IsSalvageAble = item.IsSalvageAble;
	}

	public bool TryRestore(bool filterSuperItems, out Item item)
	{
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(PropertiesIndex, out var reference))
		{
			if (filterSuperItems && reference.IsSuperItem && reference.TryReturnSubItemProperties(out var subItemProperties))
			{
				reference = subItemProperties;
			}
			item = new Item(reference);
			base.Instance = item;
			if (IsReserved)
			{
				base.Instance.Reserve();
			}
			item.IsSalvageAble = IsSalvageAble;
			base.Restore();
			return true;
		}
		item = null;
		return false;
	}

	public bool TryRestore(bool filterSuperItems, Inventory inventory, SubInventoryType subInventoryType, out Item item)
	{
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(PropertiesIndex, out var reference))
		{
			if (filterSuperItems && reference.IsSuperItem && reference.TryReturnSubItemProperties(out var subItemProperties))
			{
				reference = subItemProperties;
			}
			item = new Item(reference);
			if (!inventory.FitsInInventory(item, subInventoryType))
			{
				item = null;
				return false;
			}
			base.Instance = item;
			if (IsReserved)
			{
				base.Instance.Reserve();
			}
			item.IsSalvageAble = IsSalvageAble;
			base.Restore();
			return true;
		}
		item = null;
		return false;
	}

	public static ItemPersistentData[] FromItems(List<Item> items)
	{
		if (items.IsNullOrEmpty())
		{
			return null;
		}
		int count = items.Count;
		ItemPersistentData[] array = new ItemPersistentData[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = new ItemPersistentData(items[i]);
		}
		return array;
	}

	public static ListPool<Item>.List ToItems(ItemPersistentData[] data)
	{
		if (data.IsNullOrEmpty())
		{
			return null;
		}
		ListPool<Item>.List list = ListPool<Item>.Get(data.Length);
		for (int i = 0; i < data.Length; i++)
		{
			if (data[i].TryRestore(filterSuperItems: true, out var item))
			{
				list.Add(item);
			}
		}
		return list;
	}

	public static int[] ToIndices(List<Item> items)
	{
		if (items.IsNullOrEmpty())
		{
			return null;
		}
		int count = items.Count;
		int[] array = new int[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = items[i].PersistentIndex;
		}
		return array;
	}

	public static ListPool<Item>.List ToItems(int[] indices)
	{
		if (indices == null)
		{
			return null;
		}
		ListPool<Item>.List list = ListPool<Item>.Get(indices.Length);
		for (int i = 0; i < indices.Length; i++)
		{
			if (PersistentReference<Item>.TryReturnReference(indices[i], out var reference))
			{
				list.Add(reference);
			}
		}
		return list;
	}
}
