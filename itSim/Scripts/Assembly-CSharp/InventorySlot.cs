using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public RectTransform area;

	public RectTransform rectItem;

	public Image rectIcon;

	public Image backgroundColor;

	public InventoryItem thisItem;

	public InventoryMode inventoryMode;

	public int idSlot;

	public Action<int> actionSlotInPcPort;

	public void SelectThisSlot()
	{
	}

	public void DropThisSlot()
	{
	}

	public void SetItem(InventoryItem item)
	{
	}
}
