using System;
using UnityEngine;

namespace UniversalInventorySystem
{
	[Serializable]
	public struct Slot
	{
		public int amount;

		public Item item;

		public bool hasItem;

		[SerializeField]
		private int _durability;

		public bool isProductSlot;

		public SlotProtection interative;

		public ItemGroup whitelist;

		public static readonly Slot nullSlot = new Slot(null, 0, _hasItem: false, _isProductSlot: false, SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use, null, 0);

		public int durability
		{
			get
			{
				return _durability;
			}
			set
			{
				if (value > (item?.maxDurability ?? int.MaxValue))
				{
					throw new Exception("The value provided for durability is greter than the max durablity\nIf your intentions are of using a durability greter then the max one use the SetDurability function with op=true");
				}
				_durability = value;
			}
		}

		public int GetDurability()
		{
			return durability;
		}

		public bool GetDurabiliyValidation()
		{
			return _durability <= (item?.maxDurability ?? 0);
		}

		public static bool SetDurability(ref Slot slot, int value, bool op = false)
		{
			if (op)
			{
				slot._durability = value;
				return true;
			}
			if (slot.item == null || !slot.hasItem || value > slot.item.maxDurability || !slot.item.hasDurability)
			{
				return false;
			}
			slot._durability = value;
			return true;
		}

		public static Slot Set(ref Slot slot, Item _item, int _amount, bool _hasItem, bool _isProductSlot, SlotProtection _interactive, ItemGroup _whitelist, int _durability)
		{
			return slot = new Slot(_item, _amount, _hasItem, _isProductSlot, _interactive, _whitelist, _durability);
		}

		public static Slot Set(ref Slot slot, Slot _slot)
		{
			return slot = new Slot(_slot.item, _slot.amount, _slot.hasItem, _slot.isProductSlot, _slot.interative, _slot.whitelist, _slot.durability);
		}

		public static Slot Set(Item _item, int _amount, bool _hasItem, bool _isProductSlot, SlotProtection _interactive, ItemGroup _whitelist, int _durability)
		{
			return new Slot(_item, _amount, _hasItem, _isProductSlot, _interactive, _whitelist, _durability);
		}

		public static Slot SetSlotProperties(ref Slot slot, Slot _slot)
		{
			return slot = new Slot(slot.item, slot.amount, slot.hasItem, _slot.isProductSlot, _slot.interative, _slot.whitelist, slot.durability);
		}

		public static Slot SetSlotProperties(ref Slot slot, bool _isProductSlot, SlotProtection _interative, ItemGroup _whitelist)
		{
			return slot = new Slot(slot.item, slot.amount, slot.hasItem, _isProductSlot, _interative, _whitelist, slot.durability);
		}

		public static Slot SetSlotProperties(Slot slot, Slot _slot)
		{
			return new Slot(slot.item, slot.amount, slot.hasItem, _slot.isProductSlot, _slot.interative, _slot.whitelist, slot.durability);
		}

		public static Slot SetSlotProperties(Slot slot, bool _isProductSlot, SlotProtection _interative, ItemGroup _whitelist)
		{
			return new Slot(slot.item, slot.amount, slot.hasItem, _isProductSlot, _interative, _whitelist, slot.durability);
		}

		public static Slot SetItemProperties(ref Slot slot, Slot _slot)
		{
			return slot = new Slot(_slot.item, _slot.amount, _slot.hasItem, slot.isProductSlot, slot.interative, slot.whitelist, _slot.durability);
		}

		public static Slot SetItemProperties(ref Slot slot, Item _item, int _amount, bool _hasItem, int _durability)
		{
			return slot = new Slot(_item, _amount, _hasItem, slot.isProductSlot, slot.interative, slot.whitelist, _durability);
		}

		public static Slot SetItemProperties(Slot slot, Slot _slot)
		{
			return new Slot(_slot.item, _slot.amount, _slot.hasItem, slot.isProductSlot, slot.interative, slot.whitelist, _slot.durability);
		}

		public static Slot SetItemProperties(Slot slot, Item _item, int _amount, bool _hasItem, int _durability)
		{
			return new Slot(_item, _amount, _hasItem, slot.isProductSlot, slot.interative, slot.whitelist, _durability);
		}

		public Slot(Slot slot, bool _isProductSlot, SlotProtection _interactive, ItemGroup _whitelist)
		{
			item = slot.item;
			amount = slot.amount;
			hasItem = slot.hasItem;
			isProductSlot = _isProductSlot;
			interative = _interactive;
			whitelist = _whitelist;
			_durability = slot.durability;
			durability = slot.durability;
		}

		public Slot(Slot slot, bool _isProductSlot, SlotProtection _interactive)
		{
			item = slot.item;
			amount = slot.amount;
			hasItem = slot.hasItem;
			isProductSlot = _isProductSlot;
			interative = _interactive;
			whitelist = null;
			_durability = slot.durability;
			durability = slot.durability;
		}

		public Slot(Item _item)
		{
			item = _item;
			amount = 1;
			hasItem = !(item == null);
			isProductSlot = false;
			interative = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use;
			whitelist = null;
			_durability = 0;
			durability = 0;
		}

		public Slot(Item _item, int _amount)
		{
			item = _item;
			amount = _amount;
			hasItem = !(item == null);
			isProductSlot = false;
			interative = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use;
			whitelist = null;
			_durability = 0;
			durability = 0;
		}

		public Slot(Item _item, int _amount, bool _hasItem)
		{
			item = _item;
			amount = _amount;
			hasItem = _hasItem;
			isProductSlot = false;
			interative = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use;
			whitelist = null;
			_durability = 0;
			durability = 0;
		}

		public Slot(Item _item, int _amount, bool _hasItem, int _durability)
		{
			item = _item;
			amount = _amount;
			hasItem = _hasItem;
			isProductSlot = false;
			interative = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use;
			whitelist = null;
			this._durability = _durability;
			durability = _durability;
		}

		public Slot(Item _item, int _amount, bool _hasItem, bool _isProductSlot)
		{
			item = _item;
			amount = _amount;
			hasItem = _hasItem;
			isProductSlot = _isProductSlot;
			interative = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use;
			whitelist = null;
			_durability = 0;
			durability = 0;
		}

		public Slot(Item _item, int _amount, bool _hasItem, bool _isProductSlot, int _durability)
		{
			item = _item;
			amount = _amount;
			hasItem = _hasItem;
			isProductSlot = _isProductSlot;
			interative = SlotProtection.Add | SlotProtection.Remove | SlotProtection.Swap | SlotProtection.Use;
			whitelist = null;
			this._durability = _durability;
			durability = _durability;
		}

		public Slot(Item _item, int _amount, bool _hasItem, bool _isProductSlot, SlotProtection _interactive)
		{
			item = _item;
			amount = _amount;
			hasItem = _hasItem;
			isProductSlot = _isProductSlot;
			interative = _interactive;
			whitelist = null;
			_durability = 0;
			durability = 0;
		}

		public Slot(Item _item, int _amount, bool _hasItem, bool _isProductSlot, SlotProtection _interactive, ItemGroup _whitelist)
		{
			item = _item;
			amount = _amount;
			hasItem = _hasItem;
			isProductSlot = _isProductSlot;
			interative = _interactive;
			whitelist = _whitelist;
			_durability = 0;
			durability = 0;
		}

		public Slot(Item _item, int _amount, bool _hasItem, bool _isProductSlot, SlotProtection _interactive, ItemGroup _whitelist, int _durability)
		{
			item = _item;
			amount = _amount;
			hasItem = _hasItem;
			isProductSlot = _isProductSlot;
			interative = _interactive;
			whitelist = _whitelist;
			this._durability = _durability;
			durability = _durability;
		}

		public static bool operator !(Slot s)
		{
			return !s.hasItem;
		}

		public static bool operator true(Slot s)
		{
			return s.hasItem;
		}

		public static bool operator false(Slot s)
		{
			return !s.hasItem;
		}

		public static bool operator >=(Slot s, Slot s2)
		{
			return s.amount >= s2.amount;
		}

		public static bool operator <=(Slot s, Slot s2)
		{
			return s.amount <= s2.amount;
		}

		public static bool operator <(Slot s, Slot s2)
		{
			return s.amount < s2.amount;
		}

		public static bool operator >(Slot s, Slot s2)
		{
			return s.amount > s2.amount;
		}
	}
}
