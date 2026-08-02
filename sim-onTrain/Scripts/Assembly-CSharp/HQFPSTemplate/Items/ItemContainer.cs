using System;
using System.Collections;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[Serializable]
	public class ItemContainer : IEnumerable
	{
		public Value<int> SelectedSlot = new Value<int>();

		public Message<ItemSlot> Changed = new Message<ItemSlot>();

		private Transform m_Transform;

		[SerializeField]
		private string m_Name;

		[SerializeField]
		private ItemContainerFlags m_Flag;

		[SerializeField]
		private ItemSlot[] m_Slots;

		[SerializeField]
		private bool m_OneStackPerItem;

		[SerializeField]
		private string[] m_ValidCategories;

		[SerializeField]
		private string[] m_RequiredProperties;

		public ItemSlot this[int i]
		{
			get
			{
				return m_Slots[i];
			}
			set
			{
				m_Slots[i] = value;
			}
		}

		public int Count => m_Slots.Length;

		public ItemSlot[] Slots => m_Slots;

		public string Name => m_Name;

		public ItemContainerFlags Flag => m_Flag;

		public Transform Transform => m_Transform;

		public ItemContainer(string name, int size, Transform transform, ItemContainerFlags flag, bool oneStackPerItem, string[] validCategories, string[] requiredProperties)
		{
			m_Name = name;
			m_Slots = new ItemSlot[size];
			for (int i = 0; i < m_Slots.Length; i++)
			{
				m_Slots[i] = new ItemSlot();
				m_Slots[i].Changed.AddListener(OnSlotChanged);
			}
			m_Transform = transform;
			m_Flag = flag;
			m_OneStackPerItem = oneStackPerItem;
			m_ValidCategories = validCategories;
			m_RequiredProperties = requiredProperties;
			SelectedSlot.SetFilter(FilterSelectedSlotIndex);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_Slots.GetEnumerator();
		}

		private int FilterSelectedSlotIndex(int prevIndex, int newIndex)
		{
			return Mathf.Clamp(newIndex, 0, Slots.Length - 1);
		}

		public int AddItem(ItemInfo itemInfo, int amount, ItemProperty[] customProperties = null)
		{
			if (itemInfo == null || !AllowsItem(itemInfo))
			{
				return 0;
			}
			int num = 0;
			if (m_OneStackPerItem)
			{
				int slotIndexForItem = GetSlotIndexForItem(itemInfo.Id);
				if (slotIndexForItem == -1)
				{
					for (int i = 0; i < m_Slots.Length; i++)
					{
						if (!m_Slots[i].HasItem)
						{
							num += AddItemToSlot(m_Slots[i], itemInfo, amount, customProperties);
							break;
						}
					}
				}
				else
				{
					num += AddItemToSlot(m_Slots[slotIndexForItem], itemInfo, amount, customProperties);
				}
			}
			else
			{
				for (int j = 0; j < m_Slots.Length; j++)
				{
					num += AddItemToSlot(m_Slots[j], itemInfo, amount, customProperties);
					if (num == amount)
					{
						return num;
					}
				}
			}
			return num;
		}

		public int AddItem(string name, int amount, ItemProperty[] customProperties = null)
		{
			if (!ItemDatabase.TryGetItemByName(name, out var itemInfo) || !AllowsItem(itemInfo))
			{
				return 0;
			}
			return AddItem(itemInfo, amount, customProperties);
		}

		public int AddItem(int id, int amount, ItemProperty[] customProperties = null)
		{
			if (!ItemDatabase.TryGetItemById(id, out var itemInfo) || !AllowsItem(itemInfo))
			{
				return 0;
			}
			return AddItem(itemInfo, amount, customProperties);
		}

		public bool AddItem(Item item)
		{
			if (AllowsItem(item))
			{
				if (item.Info.StackSize > 1)
				{
					return AddItem(item.Info, item.CurrentStackSize, item.Properties) > 0;
				}
				for (int i = 0; i < m_Slots.Length; i++)
				{
					if (!m_Slots[i].HasItem)
					{
						m_Slots[i].SetItem(item);
						return true;
					}
				}
				return false;
			}
			return false;
		}

		public bool AddOrSwap(ItemContainer slotParent, ItemSlot slot)
		{
			if (!slot.HasItem)
			{
				return false;
			}
			Item item = slot.Item;
			if (AllowsItem(item))
			{
				for (int i = 0; i < m_Slots.Length; i++)
				{
					if (!m_Slots[i].HasItem)
					{
						m_Slots[i].SetItem(item);
						slot.SetItem(null);
						return true;
					}
				}
				if (slotParent.AllowsItem(m_Slots[0].Item))
				{
					Item item2 = m_Slots[0].Item;
					m_Slots[0].SetItem(item);
					slot.SetItem(item2);
					return true;
				}
				return false;
			}
			return false;
		}

		public int RemoveItem(string name, int amount)
		{
			int num = 0;
			for (int i = 0; i < m_Slots.Length; i++)
			{
				if (m_Slots[i].HasItem && m_Slots[i].Item.Name == name)
				{
					num += m_Slots[i].RemoveFromStack(amount - num);
					if (num == amount)
					{
						return num;
					}
				}
			}
			return num;
		}

		public int RemoveItem(int id, int amount)
		{
			int num = 0;
			for (int i = 0; i < m_Slots.Length; i++)
			{
				if (m_Slots[i].HasItem && m_Slots[i].Item.Id == id)
				{
					num += m_Slots[i].RemoveFromStack(amount - num);
					if (num == amount)
					{
						return num;
					}
				}
			}
			return num;
		}

		public bool RemoveItem(Item item)
		{
			for (int i = 0; i < m_Slots.Length; i++)
			{
				if (m_Slots[i].Item == item)
				{
					m_Slots[i].SetItem(null);
					return true;
				}
			}
			return false;
		}

		public bool ContainsItem(Item item)
		{
			for (int i = 0; i < m_Slots.Length; i++)
			{
				if (m_Slots[i].Item == item)
				{
					return true;
				}
			}
			return false;
		}

		public int GetItemCount(string name)
		{
			int num = 0;
			for (int i = 0; i < m_Slots.Length; i++)
			{
				if (m_Slots[i].HasItem && m_Slots[i].Item.Name == name)
				{
					num += m_Slots[i].Item.CurrentStackSize;
				}
			}
			return num;
		}

		public int GetItemCount(int id)
		{
			int num = 0;
			for (int i = 0; i < m_Slots.Length; i++)
			{
				if (m_Slots[i].HasItem && m_Slots[i].Item.Id == id)
				{
					num += m_Slots[i].Item.CurrentStackSize;
				}
			}
			return num;
		}

		public bool AllowsItem(Item item)
		{
			return AllowsItem(item.Info);
		}

		public bool AllowsItem(ItemInfo itemInfo)
		{
			bool flag = m_ValidCategories == null || m_ValidCategories.Length == 0;
			if (m_ValidCategories != null)
			{
				for (int i = 0; i < m_ValidCategories.Length; i++)
				{
					if (m_ValidCategories[i] == itemInfo.Category)
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				return false;
			}
			if (m_RequiredProperties != null)
			{
				for (int j = 0; j < m_RequiredProperties.Length; j++)
				{
					bool flag2 = false;
					for (int k = 0; k < itemInfo.Properties.Length; k++)
					{
						if (itemInfo.Properties[k].Name == m_RequiredProperties[j])
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						return false;
					}
				}
			}
			return true;
		}

		private int GetSlotIndexForItem(int id)
		{
			for (int i = 0; i < m_Slots.Length; i++)
			{
				if (m_Slots[i].HasItem && m_Slots[i].Item.Id == id)
				{
					return i;
				}
			}
			return -1;
		}

		private int AddItemToSlot(ItemSlot slot, ItemInfo itemInfo, int amount, ItemProperty[] properties = null)
		{
			if (slot.HasItem && itemInfo.Name != slot.Item.Name)
			{
				return 0;
			}
			bool flag = false;
			if (!slot.HasItem)
			{
				slot.SetItem(new Item(itemInfo, 1, properties));
				amount--;
				flag = true;
			}
			return slot.AddToStack(amount) + (flag ? 1 : 0);
		}

		public int GetPositionOfItem(Item item)
		{
			if (item == null)
			{
				return -1;
			}
			for (int i = 0; i < m_Slots.Length; i++)
			{
				if (m_Slots[i].Item == item)
				{
					return i;
				}
			}
			return -1;
		}

		private void OnSlotChanged(ItemSlot slot, SlotChangeType changeType)
		{
			Changed.Send(slot);
		}
	}
}
