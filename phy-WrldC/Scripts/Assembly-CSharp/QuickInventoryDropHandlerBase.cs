using UnityEngine;
using UnityEngine.EventSystems;

public abstract class QuickInventoryDropHandlerBase<TItemView, TItemModel> : MonoBehaviour, IDropHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler where TItemView : Component where TItemModel : class
{
	public int OldSlotIndex { get; set; }

	public int DroppedSlotIndex { get; set; }

	protected virtual void Awake()
	{
		DroppedSlotIndex = 0;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			InventoryDragHandlerBase<TItemView, TItemModel> component = eventData.pointerDrag.GetComponent<InventoryDragHandlerBase<TItemView, TItemModel>>();
			if (component != null)
			{
				component.DropZoneObject = base.gameObject;
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			InventoryDragHandlerBase<TItemView, TItemModel> component = eventData.pointerDrag.GetComponent<InventoryDragHandlerBase<TItemView, TItemModel>>();
			if (component != null)
			{
				component.DropZoneObject = null;
			}
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		InventoryDragHandlerBase<TItemView, TItemModel> component = eventData.pointerDrag.GetComponent<InventoryDragHandlerBase<TItemView, TItemModel>>();
		if (component != null)
		{
			OnDropHandler(component.InventorySlotIndex);
		}
	}

	protected abstract void OnDropHandler(int inventorySlotIndex);
}
