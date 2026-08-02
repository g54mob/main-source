using System.Collections;
using System.Collections.Generic;
using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate
{
	public class Inventory : EntityComponent
	{
		public Message ContainerChanged = new Message();

		[SerializeField]
		[Reorderable]
		private ContainerGeneratorList m_InitialContainers;

		private List<ItemContainer> m_SavableContainers;

		private List<ItemContainer> m_AllContainers;

		public List<ItemContainer> Containers
		{
			get
			{
				if (m_AllContainers == null)
				{
					InitiateContainers();
				}
				return m_AllContainers;
			}
		}

		public ContainerGenerator[] StartupContainers => m_InitialContainers.ToArray();

		public string[] GetAllContainerNames()
		{
			string[] array = new string[m_InitialContainers.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = m_InitialContainers[i].Name;
			}
			return array;
		}

		public void AddContainer(ItemContainer itemContainer, bool add)
		{
			if (add && !Containers.Contains(itemContainer))
			{
				Containers.Add(itemContainer);
				AddListeners(itemContainer, add: true);
			}
			else if (!add && Containers.Contains(itemContainer))
			{
				Containers.Remove(itemContainer);
				AddListeners(itemContainer, add: false);
			}
		}

		public bool HasContainerWithFlags(ItemContainerFlags flags)
		{
			for (int i = 0; i < Containers.Count; i++)
			{
				if (flags.HasFlag(Containers[i].Flag))
				{
					return true;
				}
			}
			return false;
		}

		public ItemContainer GetContainerWithFlags(ItemContainerFlags flags)
		{
			for (int i = 0; i < Containers.Count; i++)
			{
				if (flags.HasFlag(Containers[i].Flag))
				{
					return Containers[i];
				}
			}
			return null;
		}

		public ItemContainer GetContainerWithName(string name)
		{
			for (int i = 0; i < Containers.Count; i++)
			{
				if (Containers[i].Name == name)
				{
					return Containers[i];
				}
			}
			return null;
		}

		public bool AddItem(Item item, ItemContainerFlags flags)
		{
			for (int i = 0; i < Containers.Count; i++)
			{
				if (flags.HasFlag(Containers[i].Flag) && Containers[i].AddItem(item))
				{
					return true;
				}
			}
			return false;
		}

		public int AddItem(string itemName, int amountToAdd, ItemContainerFlags flags)
		{
			int num = 0;
			for (int i = 0; i < Containers.Count; i++)
			{
				if (flags.HasFlag(m_AllContainers[i].Flag))
				{
					int num2 = Containers[i].AddItem(itemName, amountToAdd);
					num += num2;
					if (num2 == num)
					{
						return num;
					}
				}
			}
			return num;
		}

		public int AddItem(int id, int amountToAdd, ItemContainerFlags flags)
		{
			int num = 0;
			for (int i = 0; i < Containers.Count; i++)
			{
				if (flags.HasFlag(m_AllContainers[i].Flag))
				{
					int num2 = Containers[i].AddItem(id, amountToAdd);
					num += num2;
					if (num2 == num)
					{
						return num;
					}
				}
			}
			return num;
		}

		public bool RemoveItem(Item item)
		{
			for (int i = 0; i < Containers.Count; i++)
			{
				if (m_AllContainers[i].RemoveItem(item))
				{
					return true;
				}
			}
			return false;
		}

		public int RemoveItemsWithID(int id, int amountToRemove, ItemContainerFlags flags)
		{
			int num = 0;
			for (int i = 0; i < Containers.Count; i++)
			{
				if (flags.HasFlag(Containers[i].Flag))
				{
					int num2 = Containers[i].RemoveItem(id, amountToRemove);
					num += num2;
					if (num == amountToRemove)
					{
						break;
					}
				}
			}
			return num;
		}

		public int RemoveItemsWithName(string itemName, int amountToRemove, ItemContainerFlags flags)
		{
			int num = 0;
			for (int i = 0; i < Containers.Count; i++)
			{
				if (flags.HasFlag(Containers[i].Flag))
				{
					int num2 = Containers[i].RemoveItem(itemName, amountToRemove);
					num += num2;
					if (num == amountToRemove)
					{
						break;
					}
				}
			}
			return num;
		}

		public int GetItemCount(string itemName)
		{
			int num = 0;
			for (int i = 0; i < Containers.Count; i++)
			{
				num += Containers[i].GetItemCount(itemName);
			}
			return num;
		}

		public int GetItemCount(int id)
		{
			int num = 0;
			for (int i = 0; i < Containers.Count; i++)
			{
				num += Containers[i].GetItemCount(id);
			}
			return num;
		}

		public ItemSlot GetItemSlot(Item item)
		{
			foreach (ItemContainer savableContainer in m_SavableContainers)
			{
				foreach (ItemSlot item2 in (IEnumerable)savableContainer)
				{
					if (item2.Item == item)
					{
						return item2;
					}
				}
			}
			return null;
		}

		private void Awake()
		{
			if (AssetSingleton<ItemDatabase>.Instance == null)
			{
				Debug.LogError("No ItemDatabase found, this storage component will be disabled!", this);
				base.enabled = false;
			}
			else
			{
				InitiateContainers();
			}
		}

		private void InitiateContainers()
		{
			m_SavableContainers = new List<ItemContainer>();
			for (int i = 0; i < m_InitialContainers.Count; i++)
			{
				ItemContainer itemContainer = m_InitialContainers[i].GenerateContainer(base.transform);
				m_SavableContainers.Add(itemContainer);
				AddListeners(itemContainer, add: true);
			}
			m_AllContainers = new List<ItemContainer>(m_SavableContainers);
		}

		private void AddListeners(ItemContainer container, bool add)
		{
			if (add)
			{
				container.Changed.AddListener(OnContainerChanged);
			}
			else
			{
				container.Changed.RemoveListener(OnContainerChanged);
			}
		}

		private void OnContainerChanged(ItemSlot slot)
		{
			try
			{
				ContainerChanged.Send();
			}
			catch
			{
			}
		}
	}
}
