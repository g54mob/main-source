using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UniversalInventorySystem
{
	public class ItemDropHandler : MonoBehaviour, IDropHandler, IEventSystemHandler
	{
		public void OnDrop(PointerEventData eventData)
		{
			List<InventoryUI> inventoriesUI = InventoryController.inventoriesUI;
			RectTransform component = GetComponent<RectTransform>();
			InventoryUI inventoryUI = null;
			foreach (InventoryUI item in inventoriesUI)
			{
				if (item.isDraging)
				{
					item.isDraging = false;
					component = item.DontDropItemRect.GetComponent<RectTransform>();
					inventoryUI = item;
					break;
				}
			}
			if (!(inventoryUI != null))
			{
				return;
			}
			if (!RectTransformUtility.RectangleContainsScreenPoint(component, Camera.main.ScreenToWorldPoint(Input.mousePosition)))
			{
				inventoryUI.shouldSwap = false;
				foreach (InventoryUI item2 in inventoriesUI)
				{
					if (!item2.togglableObject.activeInHierarchy || !item2.DontDropItemRect.activeInHierarchy || !RectTransformUtility.RectangleContainsScreenPoint(item2.DontDropItemRect.GetComponent<RectTransform>(), Camera.main.ScreenToWorldPoint(Input.mousePosition)))
					{
						continue;
					}
					float num = float.MaxValue;
					int targetSlotNumber = 0;
					for (int i = 0; i < item2.slots.Count; i++)
					{
						float num2 = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), item2.slots[i].GetComponent<RectTransform>().position);
						if (num2 <= num)
						{
							num = num2;
							targetSlotNumber = i;
						}
					}
					inventoryUI.inv.SwapItemThruInventoriesSlotToSlot(item2.inv, inventoryUI.dragSlotNumber ?? (-1), targetSlotNumber, inventoryUI.dragObj.GetComponent<DragSlot>().GetAmount());
					return;
				}
				inventoryUI.inv.slots[inventoryUI.dragSlotNumber.GetValueOrDefault()].item.OnDrop(inventoryUI.inv, tss: true, inventoryUI.dragSlotNumber.GetValueOrDefault(), inventoryUI.dragObj.GetComponent<DragSlot>().amount, dbui: true, Camera.main.ScreenToWorldPoint(Input.mousePosition));
			}
			else
			{
				inventoryUI.shouldSwap = true;
			}
		}
	}
}
