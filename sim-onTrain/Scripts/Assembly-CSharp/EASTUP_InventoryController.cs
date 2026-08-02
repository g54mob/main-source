using System.Collections.Generic;
using HQFPSTemplate.Items;
using UnityEngine;
using UnityEngine.Events;

public class EASTUP_InventoryController : MonoBehaviour
{
	[SerializeField]
	public List<CollectableItemData> m_AllContainers = new List<CollectableItemData>();

	public List<CollectableItemData> currentInventoryItems = new List<CollectableItemData>();

	public List<EASTUP_InventorySlotItem> slotItems = new List<EASTUP_InventorySlotItem>();

	public UnityEvent ContainerChanged = new UnityEvent();

	public int GetItemCount(int id)
	{
		return 1;
	}

	public int RemoveItemsWithID(int id, int amount, ItemContainerFlags flag)
	{
		return 1;
	}

	public void RemoveItem(CollectableItemData item)
	{
	}

	public int AddItem(int id, int amount, ItemContainerFlags flag)
	{
		return 1;
	}

	public bool AddItem(CollectableItemData item, ItemContainerFlags flag)
	{
		return false;
	}

	public CollectableItemData GetContainerWithName(string name)
	{
		foreach (CollectableItemData allContainer in m_AllContainers)
		{
			if (allContainer.name.Equals(name))
			{
				return allContainer;
			}
		}
		return null;
	}
}
