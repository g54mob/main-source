using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public int inventoryCount;

	public int inventoryID;

	public InventoryItem InventoryItem;

	public InventorySlotType inventorySlotType;

	public bool isAdditional;

	public bool isShowing;

	public bool isBottomInventory;

	public GameObject selectionBG;

	public Image mainBorder;

	public bool HasItem;

	private void Start()
	{
		if (Singleton<GameSettings>.Instance != null)
		{
			inventoryCount = Singleton<GameSettings>.Instance.inventorySlotSize;
		}
	}

	public void Clear()
	{
		Clear(silent: false);
	}

	public void Clear(bool silent)
	{
		if (InventoryItem.collectableItemData != null && !silent)
		{
			HasItem = false;
		}
		inventoryCount = 0;
		if (InventoryItem != null)
		{
			InventoryItem.ClearInventoryData(silent);
		}
	}

	public void SetSelection(bool select)
	{
		selectionBG.SetActive(select);
		mainBorder.enabled = !select;
	}
}
