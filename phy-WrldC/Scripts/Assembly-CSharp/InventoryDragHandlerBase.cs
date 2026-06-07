using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InventoryDragHandlerBase<TItemView, TItemModel> : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler where TItemView : Component where TItemModel : class
{
	private Canvas canvas;

	private GameObject draggedSlotObject;

	[SerializeField]
	private GameObject placeholderSlotPrefab;

	private GameObject placeholderSlotObject;

	private InventorySlotBase<TItemView, TItemModel> inventorySlot;

	public int InventorySlotIndex { get; private set; }

	public GameObject DropZoneObject { get; set; }

	public event Action OnBeginDragEvent;

	public event Action OnEndDragEvent;

	protected virtual void Awake()
	{
		inventorySlot = GetComponent<InventorySlotBase<TItemView, TItemModel>>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.OnBeginDragEvent != null)
		{
			this.OnBeginDragEvent();
		}
		canvas = GetParentCanvas();
		bool toggleValue = inventorySlot.GetToggleValue();
		draggedSlotObject = UnityEngine.Object.Instantiate(base.gameObject);
		draggedSlotObject.transform.SetParent(canvas.transform);
		draggedSlotObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		draggedSlotObject.GetComponent<InventorySlotBase<TItemView, TItemModel>>().ClearToggleGroup();
		draggedSlotObject.transform.localScale = Vector3.one;
		draggedSlotObject.GetComponent<RectTransform>().sizeDelta = new Vector2(96f, 96f);
		if (toggleValue)
		{
			inventorySlot.SetToggleValue(isOn: true);
		}
		InventorySlotIndex = inventorySlot.SlotIndex;
		DropZoneObject = null;
	}

	protected abstract Canvas GetParentCanvas();

	public void OnDrag(PointerEventData eventData)
	{
		draggedSlotObject.transform.position = Util.ConvertMousePositionToRectTransform(canvas);
		draggedSlotObject.transform.SetLocalPositionZ(-400f);
		if (DropZoneObject != null)
		{
			if (placeholderSlotObject == null)
			{
				placeholderSlotObject = UnityEngine.Object.Instantiate(placeholderSlotPrefab);
				placeholderSlotObject.transform.SetParent(DropZoneObject.transform);
				placeholderSlotObject.transform.localScale = Vector3.one;
				placeholderSlotObject.transform.SetLocalPositionZ(0f);
			}
			int num = DropZoneObject.transform.childCount;
			foreach (Transform item in DropZoneObject.transform)
			{
				if (draggedSlotObject.transform.position.x < item.position.x)
				{
					num = item.GetSiblingIndex();
					if (placeholderSlotObject.transform.GetSiblingIndex() < num)
					{
						num--;
					}
					break;
				}
			}
			if (num >= DropZoneObject.transform.childCount)
			{
				num = DropZoneObject.transform.childCount - 1;
			}
			placeholderSlotObject.transform.SetSiblingIndex(num);
			QuickInventoryDropHandlerBase<TItemView, TItemModel> component = DropZoneObject.GetComponent<QuickInventoryDropHandlerBase<TItemView, TItemModel>>();
			if (component != null)
			{
				component.DroppedSlotIndex = num;
			}
		}
		else if (placeholderSlotObject != null)
		{
			UnityEngine.Object.Destroy(placeholderSlotObject);
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.OnEndDragEvent != null)
		{
			this.OnEndDragEvent();
		}
		UnityEngine.Object.Destroy(draggedSlotObject);
		if (placeholderSlotObject != null)
		{
			UnityEngine.Object.Destroy(placeholderSlotObject);
		}
		if (DropZoneObject == null)
		{
			OnEndDragHandler();
		}
	}

	protected abstract void OnEndDragHandler();
}
