using System;

namespace UniversalInventorySystem
{
	[Serializable]
	public class CheckItemData
	{
		public readonly Inventory inventory;

		public readonly int[] slotsChecked;

		public readonly int[] slotsWithItem;

		public readonly int amount;

		public readonly bool hasItem;

		public readonly bool mustBeOnSameSlot;

		public readonly Item checkedItem;

		public CheckItemData(Inventory _inventory, int[] _slotsChecked, int[] _slotsWithItem, int _amount, bool _hasItem, bool _mustBeOnSameSlot, Item _checkedItem)
		{
			inventory = _inventory;
			slotsChecked = _slotsChecked;
			slotsWithItem = _slotsWithItem;
			amount = _amount;
			hasItem = _hasItem;
			mustBeOnSameSlot = _mustBeOnSameSlot;
			checkedItem = _checkedItem;
		}

		public static bool operator true(CheckItemData c)
		{
			return c.hasItem;
		}

		public static bool operator false(CheckItemData c)
		{
			return !c.hasItem;
		}

		public static bool operator !(CheckItemData c)
		{
			return !c.hasItem;
		}
	}
}
