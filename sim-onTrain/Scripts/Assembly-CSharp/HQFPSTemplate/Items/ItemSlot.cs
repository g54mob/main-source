using System;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[Serializable]
	public class ItemSlot
	{
		public Message<ItemSlot, SlotChangeType> Changed = new Message<ItemSlot, SlotChangeType>();

		[SerializeField]
		private Item m_Item;

		public bool HasItem => Item != null;

		public Item Item => m_Item;

		public static implicit operator bool(ItemSlot slot)
		{
			return slot != null;
		}

		public void OnDeserialization(object sender)
		{
			Changed = new Message<ItemSlot, SlotChangeType>();
			if ((bool)Item)
			{
				if (Item.PropertyChanged == null)
				{
					Item.PropertyChanged = new Message<ItemProperty>();
					Item.StackChanged = new Message();
				}
				Item.PropertyChanged.AddListener(OnPropertyChanged);
				Item.StackChanged.AddListener(OnStackChanged);
			}
		}

		public void SetItem(Item item)
		{
			Item item2 = Item;
			if (Item != null)
			{
				Item.PropertyChanged.RemoveListener(OnPropertyChanged);
				Item.StackChanged.RemoveListener(OnStackChanged);
			}
			m_Item = item;
			if (Item != null)
			{
				Item.PropertyChanged.AddListener(OnPropertyChanged);
				Item.StackChanged.AddListener(OnStackChanged);
			}
			if (m_Item != item2)
			{
				Changed.Send(this, SlotChangeType.ItemChanged);
			}
		}

		public int RemoveFromStack(int amount)
		{
			if (!HasItem)
			{
				return 0;
			}
			if (amount >= Item.CurrentStackSize)
			{
				int currentStackSize = Item.CurrentStackSize;
				SetItem(null);
				return currentStackSize;
			}
			int currentStackSize2 = Item.CurrentStackSize;
			Item.CurrentStackSize = Mathf.Max(Item.CurrentStackSize - amount, 0);
			if (currentStackSize2 != Item.CurrentStackSize)
			{
				Changed.Send(this, SlotChangeType.StackChanged);
			}
			return currentStackSize2 - Item.CurrentStackSize;
		}

		public int AddToStack(int amount)
		{
			if (!HasItem || Item.Info.StackSize <= 1)
			{
				return 0;
			}
			int currentStackSize = Item.CurrentStackSize;
			int num = amount + currentStackSize - Item.Info.StackSize;
			int num2 = currentStackSize;
			num2 = ((num > 0) ? Item.Info.StackSize : (num2 + amount));
			Item.CurrentStackSize = num2;
			return num2 - currentStackSize;
		}

		private void OnPropertyChanged(ItemProperty itemProperty)
		{
			Changed.Send(this, SlotChangeType.PropertyChanged);
		}

		private void OnStackChanged()
		{
			Changed.Send(this, SlotChangeType.StackChanged);
		}
	}
}
