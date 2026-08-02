using UnityEngine;
using UnityEngine.EventSystems;

namespace JUTPS.InventorySystem.UI
{
	public class DropArea : MonoBehaviour, IDropHandler, IEventSystemHandler
	{
		public void OnDrop(PointerEventData eventData)
		{
			InventorySlotUI componentInParent = eventData.pointerDrag.GetComponentInParent<InventorySlotUI>();
			if (componentInParent != null && componentInParent.ItemIDToDraw > -1)
			{
				componentInParent.Drop();
				componentInParent.RefreshSlot();
			}
		}
	}
}
