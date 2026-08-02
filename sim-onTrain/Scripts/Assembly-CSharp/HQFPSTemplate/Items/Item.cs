using System;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[Serializable]
	public class Item
	{
		[NonSerialized]
		public Message<ItemProperty> PropertyChanged = new Message<ItemProperty>();

		[NonSerialized]
		public Message StackChanged = new Message();

		[SerializeField]
		private int m_Id;

		[SerializeField]
		private string m_Name;

		[SerializeField]
		private int m_CurrentStackSize;

		[SerializeField]
		private ItemProperty[] m_Properties;

		public ItemInfo Info => ItemDatabase.GetItemById(m_Id);

		public int Id => m_Id;

		public string Name => m_Name;

		public int CurrentStackSize
		{
			get
			{
				return m_CurrentStackSize;
			}
			set
			{
				int currentStackSize = m_CurrentStackSize;
				m_CurrentStackSize = value;
				if (m_CurrentStackSize != currentStackSize)
				{
					StackChanged.Send();
				}
			}
		}

		public ItemProperty[] Properties => m_Properties;

		public static implicit operator bool(Item item)
		{
			return item != null;
		}

		public static Item Create(string name, int count = 1)
		{
			ItemInfo itemInfo = null;
			if (AssetSingleton<ItemDatabase>.Instance != null)
			{
				itemInfo = ItemDatabase.GetItemByName(name);
			}
			else
			{
				Debug.LogWarning("Can't create item with name '" + name + "'. It doesn't exist in the database!");
			}
			if (itemInfo != null)
			{
				return new Item(itemInfo, count);
			}
			return null;
		}

		public Item(ItemInfo itemInfo, int count = 1, ItemProperty[] customProperties = null)
		{
			m_Id = itemInfo.Id;
			m_Name = itemInfo.Name;
			CurrentStackSize = Mathf.Clamp(count, 1, itemInfo.StackSize);
			if (customProperties != null)
			{
				m_Properties = CloneProperties(customProperties);
			}
			else
			{
				m_Properties = InstantiateProperties(itemInfo.Properties);
			}
			for (int i = 0; i < m_Properties.Length; i++)
			{
				m_Properties[i].Changed.AddListener(OnPropertyChanged);
			}
		}

		public bool HasProperty(string name)
		{
			for (int i = 0; i < m_Properties.Length; i++)
			{
				if (m_Properties[i].Name == name)
				{
					return true;
				}
			}
			return false;
		}

		public ItemProperty GetProperty(string name)
		{
			ItemProperty result = null;
			for (int i = 0; i < m_Properties.Length; i++)
			{
				if (m_Properties[i].Name == name)
				{
					result = m_Properties[i];
					break;
				}
			}
			return result;
		}

		public bool TryGetProperty(string name, out ItemProperty itemProperty)
		{
			itemProperty = null;
			for (int i = 0; i < m_Properties.Length; i++)
			{
				if (m_Properties[i].Name == name)
				{
					itemProperty = m_Properties[i];
					return true;
				}
			}
			return false;
		}

		public override string ToString()
		{
			return "Item Name: " + m_Name + " | Stack Size: " + m_CurrentStackSize;
		}

		private ItemProperty[] CloneProperties(ItemProperty[] properties)
		{
			ItemProperty[] array = new ItemProperty[properties.Length];
			for (int i = 0; i < properties.Length; i++)
			{
				array[i] = properties[i].GetMemberwiseClone();
			}
			return array;
		}

		private ItemProperty[] InstantiateProperties(ItemPropertyInfoList propertyInfos)
		{
			ItemProperty[] array = new ItemProperty[propertyInfos.Length];
			for (int i = 0; i < propertyInfos.Length; i++)
			{
				array[i] = new ItemProperty(propertyInfos[i]);
			}
			return array;
		}

		private void OnPropertyChanged(ItemProperty itemProperty)
		{
			PropertyChanged.Send(itemProperty);
		}
	}
}
