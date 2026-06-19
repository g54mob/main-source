using System.Collections.Generic;
using UnityEngine;

public class ItemBoxes : BoxList
{
	public GameObject itemPane;

	private ItemType type;

	private InventoryCore coreRef;

	private InventoryManager managerRef;

	public override void Preload()
	{
		coreRef = coreObject.GetComponent<InventoryCore>();
		managerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		ToggleBubs = itemPane.GetComponent<ItemPane>().ToggleBubs;
		ToggleScrollUp = itemPane.GetComponent<ItemPane>().ToggleScrollUp;
		ToggleScrollDown = itemPane.GetComponent<ItemPane>().ToggleScrollDown;
		base.Preload();
	}

	public void SetItemType(ItemType newType, bool refreshBoxes = true)
	{
		type = newType;
		if (refreshBoxes)
		{
			UpdateType();
		}
	}

	public void TossSelectedItem()
	{
		managerRef.TossItem((InventoryItem)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)]);
		UpdateType();
	}

	public override object GetSelectedObject()
	{
		return (InventoryItem)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)];
	}

	protected override GameObject GetPreviewObjectForObject(object obj)
	{
		return Object.Instantiate(((InventoryItem)obj).itemPrefab);
	}

	protected override string GetObjectNameForIndex(int index)
	{
		return ((InventoryItem)heldObjectsOfType[index]).itemNameLocalized;
	}

	protected override string GetObjectDescriptionForIndex(int index)
	{
		return ((InventoryItem)heldObjectsOfType[index]).itemDescriptionLocalized;
	}

	protected override void UpdateHeldObjectsOfType()
	{
		List<InventoryItem> heldItemsOfType = managerRef.GetHeldItemsOfType(type);
		heldObjectsOfType.Clear();
		for (int i = 0; i < heldItemsOfType.Count; i++)
		{
			heldObjectsOfType.Add(heldItemsOfType[i]);
		}
		if (heldObjectsOfType.Count == 0)
		{
			coreRef.HideInteractButtons();
		}
		else
		{
			coreRef.ShowInteractButtons();
		}
	}

	protected override int GetNumObjectsForIndex(int index)
	{
		return managerRef.GetNumberOfItemHeld((InventoryItem)heldObjectsOfType[index]);
	}

	protected override void NoObjectsOfTypeCallback()
	{
		coreRef.HideInteractButtons();
	}

	protected override List<object> GetAllObjects()
	{
		List<object> list = new List<object>();
		foreach (ItemType value in EnumUtils.GetValues<ItemType>())
		{
			List<InventoryItem> heldItemsOfType = managerRef.GetHeldItemsOfType(value);
			for (int i = 0; i < heldItemsOfType.Count; i++)
			{
				list.Add(heldItemsOfType[i]);
			}
		}
		return list;
	}
}
