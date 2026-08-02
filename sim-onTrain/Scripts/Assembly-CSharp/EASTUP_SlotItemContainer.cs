using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EASTUP_SlotItemContainer : MonoBehaviour
{
	public List<EASTUP_InventorySlotItem> hotBorItems = new List<EASTUP_InventorySlotItem>();

	public List<EASTUP_InventorySlotItem> inventoryItems = new List<EASTUP_InventorySlotItem>();

	public UnityEvent<EASTUP_InventorySlotItem> OnSlotItemSelected = new UnityEvent<EASTUP_InventorySlotItem>();

	public EASTUP_InventorySlotItem selectedSlot;

	private void Awake()
	{
		selectedSlot = hotBorItems[0];
		foreach (EASTUP_InventorySlotItem hotBorItem in hotBorItems)
		{
			hotBorItem.DoRefresh();
		}
		foreach (EASTUP_InventorySlotItem inventoryItem in inventoryItems)
		{
			inventoryItem.DoRefresh();
		}
	}
}
