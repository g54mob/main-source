using System;
using System.Collections.Generic;

namespace UniversalInventorySystem
{
	[Serializable]
	public class Inventory
	{
		public List<Slot> slots;

		public int slotAmounts;

		public int id;

		public bool areItemsUsable;

		public bool areItemsDroppable;

		public InventoryProtection interactiable;

		public bool hasInitializated;

		public Slot this[int i]
		{
			get
			{
				return slots[i];
			}
			set
			{
				slots[i] = value;
			}
		}

		public static bool operator true(Inventory inv)
		{
			return inv?.slots != null;
		}

		public static bool operator false(Inventory inv)
		{
			return inv?.slots == null;
		}

		public Inventory(List<Slot> _slots, int _slotAmounts, InventoryProtection _interactiable, bool _areItemsUsable = true, bool _areItemsDroppable = true)
		{
			slots = _slots;
			slotAmounts = _slotAmounts;
			areItemsUsable = _areItemsUsable;
			interactiable = _interactiable;
			areItemsDroppable = _areItemsDroppable;
		}

		public Inventory(List<Slot> _slots, int _slotAmounts, bool _areItemsUsable)
		{
			slots = _slots;
			slotAmounts = _slotAmounts;
			areItemsUsable = _areItemsUsable;
		}

		public Inventory(List<Slot> _slots, int _slotAmounts)
		{
			slots = _slots;
			slotAmounts = _slotAmounts;
		}

		public Inventory(int _slotAmounts, bool _areItemsUsable, InventoryProtection _interactiable = InventoryProtection.InventoryToInventory | InventoryProtection.SlotToSlot | InventoryProtection.Add | InventoryProtection.Remove | InventoryProtection.Use | InventoryProtection.Drop, bool _areItemsDroppable = true)
		{
			slots = new List<Slot>();
			slotAmounts = _slotAmounts;
			areItemsUsable = _areItemsUsable;
			interactiable = _interactiable;
			areItemsDroppable = _areItemsDroppable;
		}

		public Inventory(int _slotAmounts, bool _areItemsUsable, InventoryProtection _interactiable = InventoryProtection.InventoryToInventory | InventoryProtection.SlotToSlot | InventoryProtection.Add | InventoryProtection.Remove | InventoryProtection.Use | InventoryProtection.Drop)
		{
			slots = new List<Slot>();
			slotAmounts = _slotAmounts;
			areItemsUsable = _areItemsUsable;
			interactiable = _interactiable;
		}

		public Inventory(int _slotAmounts, bool _areItemsUsable = true)
		{
			slots = new List<Slot>();
			slotAmounts = _slotAmounts;
			areItemsUsable = _areItemsUsable;
		}

		public Inventory(int _slotAmounts)
		{
			slots = new List<Slot>();
			slotAmounts = _slotAmounts;
		}
	}
}
