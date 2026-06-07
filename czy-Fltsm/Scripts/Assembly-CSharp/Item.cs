using System;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Item : IPersistentReference
{
	[Flags]
	public enum Tags : uint
	{
		None = 0u,
		Resource = 1u,
		Food = 2u,
		Drink = 4u,
		Construction = 8u,
		Fuel = 0x10u,
		Special = 0x20u,
		Ingredient = 0x40u,
		Medicine = 0x80u,
		Seed = 0x100u,
		Tool = 0x200u,
		Quest = 0x400u,
		Upgrade = 0x800u,
		Book = 0x1000u,
		Chow = 0x2000u,
		Liquid = 0x100000u,
		SalvageMarker = 0x20000000u,
		FishMarker = 0x40000000u
	}

	[HideInInspector]
	public ItemProperties Properties;

	[HideInInspector]
	public SubInventoryType SubInventory;

	[HideInInspector]
	public InventoryType InventoryType;

	[HideInInspector]
	public int VisualPrefabIndex;

	[HideInInspector]
	public bool IsSalvageAble = true;

	private GameObject _owner;

	private Item _subItem;

	public Project Project { get; set; }

	[HideInInspector]
	public GameObject Owner => _owner;

	[HideInInspector]
	public InventoryBase Inventory { get; set; }

	public bool IsReserved { get; private set; }

	public bool IsQuestItem => (Properties.Tags & Tags.Quest) != 0;

	[HideInInspector]
	public int PersistentIndex { get; set; } = -1;

	public Inventory MoveToInventory { get; set; }

	public event UnityAction<Item> OnReserved;

	public event UnityAction<Item> OnReservationCanceled;

	public Item(ItemProperties properties)
	{
		if (properties == null)
		{
			Debugger.Error("No item properties set.");
			return;
		}
		Properties = properties;
		Properties.ReturnVisualPrefab(out VisualPrefabIndex);
	}

	public Item(ItemProperties properties, InventoryBase inventory, SubInventoryType subInventory)
		: this(properties)
	{
		SetInventory(inventory, subInventory);
	}

	public void SetInventory(InventoryBase inventory, SubInventoryType subInventory)
	{
		if (inventory == null)
		{
			if (subInventory == SubInventoryType.Composition)
			{
				SubInventory = subInventory;
			}
			else
			{
				Debug.LogError("Owner is null!");
			}
		}
		else
		{
			Inventory = inventory;
			InventoryType = inventory.Type;
			SubInventory = subInventory;
			_owner = inventory.gameObject;
		}
	}

	public bool Reserve()
	{
		if (IsReserved)
		{
			return false;
		}
		if (this.OnReserved != null)
		{
			this.OnReserved(this);
		}
		IsReserved = true;
		return true;
	}

	public bool CancelReservation()
	{
		if (IsReserved)
		{
			if (this.OnReservationCanceled != null)
			{
				this.OnReservationCanceled(this);
			}
			IsReserved = false;
			return true;
		}
		return false;
	}

	public bool UnreserveMoveToInventory()
	{
		if (MoveToInventory == null)
		{
			return false;
		}
		MoveToInventory.UnreserveIncomingItem(this);
		MoveToInventory = null;
		return true;
	}

	public bool TakeFromInventory()
	{
		if (Inventory == null)
		{
			return false;
		}
		if (Properties.IsSuperItem)
		{
			throw new NotSupportedException($"Item.TakeFromInventory is not supported for super item '{Properties.LocalizedName}', use TryTakeFromInventory instead.");
		}
		return Inventory.TakeItem(this) == this;
	}

	public bool TryTakeFromInventory(out Item takenItem)
	{
		takenItem = null;
		if (Inventory == null)
		{
			return false;
		}
		takenItem = Inventory.TakeItem(this);
		return takenItem != null;
	}

	public bool IsAvailable()
	{
		if (!IsReserved)
		{
			return Project == null;
		}
		return false;
	}

	public Item ReturnSubItem()
	{
		if (_subItem == null && Properties.TryReturnSubItemProperties(out var subItemProperties, this))
		{
			_subItem = new Item(subItemProperties);
		}
		if (_subItem != null)
		{
			return _subItem;
		}
		return this;
	}

	public bool TryGetMoveToSubInventoryType(out SubInventoryType subInventoryType)
	{
		subInventoryType = SubInventoryType.Storage;
		if ((bool)MoveToInventory)
		{
			return MoveToInventory.TryGetIncomingItemReservedSubInventoryType(out subInventoryType, this);
		}
		return false;
	}

	public static bool ContainsTagSet(Tags tagSetA, Tags tagSetB)
	{
		return (tagSetA & tagSetB) != 0;
	}

	public bool ContainsTagSet(Tags tagSet)
	{
		return ContainsTagSet(Properties.Tags, tagSet);
	}

	public static int SortByQuality(Item lhs, Item rhs)
	{
		return lhs.Properties.Quality.Value.CompareTo(rhs.Properties.Quality.Value);
	}
}
