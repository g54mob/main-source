using UnityEngine;

namespace UniversalInventorySystem
{
	public class DragSlot : MonoBehaviour
	{
		[HideInInspector]
		public int amount;

		[HideInInspector]
		public int durability;

		[HideInInspector]
		public Item item;

		[HideInInspector]
		public int slotNumber;

		[HideInInspector]
		public InventoryUI invUI;

		[HideInInspector]
		public Inventory inv;

		public void SetAmount(int _amount)
		{
			amount = _amount;
		}

		public void SetDurability(int _durability)
		{
			durability = _durability;
		}

		public void SetItem(Item _item)
		{
			item = _item;
		}

		public void SetSlotNumber(int num)
		{
			slotNumber = num;
		}

		public void SetInventoryUI(InventoryUI _invUI)
		{
			invUI = _invUI;
		}

		public void SetInventory(Inventory _inv)
		{
			inv = _inv;
		}

		public int GetAmount()
		{
			return amount;
		}

		public int GetDurability()
		{
			return durability;
		}

		public Item GetItem()
		{
			return item;
		}

		public int GetSlotNumber()
		{
			return slotNumber;
		}

		public InventoryUI GetInventoryUI()
		{
			return invUI;
		}

		public Inventory GetInventory()
		{
			return inv;
		}
	}
}
