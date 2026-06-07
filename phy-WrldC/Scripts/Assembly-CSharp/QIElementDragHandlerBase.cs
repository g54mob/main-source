using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class QIElementDragHandlerBase : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	private Canvas canvas;

	[SerializeField]
	private bool isYaxis;

	[SerializeField]
	private GameObject placeholderElementPrefab;

	private GameObject placeholderElementObject;

	private GameObject draggedSlotObject;

	private GameObject dropZoneObject;

	private int oldElementIndex;

	private int newElementIndex;

	private Transform parentTransform;

	public event Action OnBeginDragEvent;

	public event Action OnEndDragEvent;

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.OnBeginDragEvent != null)
		{
			this.OnBeginDragEvent();
		}
		canvas = GetParentCanvas();
		draggedSlotObject = base.gameObject;
		dropZoneObject = draggedSlotObject.transform.parent.gameObject;
		oldElementIndex = draggedSlotObject.transform.GetSiblingIndex();
		parentTransform = draggedSlotObject.transform.parent;
		draggedSlotObject.transform.SetParent(canvas.transform);
		draggedSlotObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		placeholderElementObject = UnityEngine.Object.Instantiate(placeholderElementPrefab);
		placeholderElementObject.transform.SetParent(dropZoneObject.transform);
		placeholderElementObject.transform.localScale = Vector3.one;
		placeholderElementObject.transform.SetLocalPositionZ(0f);
		placeholderElementObject.transform.SetSiblingIndex(oldElementIndex);
	}

	protected abstract Canvas GetParentCanvas();

	public void OnDrag(PointerEventData eventData)
	{
		if (!isYaxis)
		{
			draggedSlotObject.transform.SetPositionX(Util.ConvertMousePositionToRectTransform(canvas).x);
		}
		else
		{
			draggedSlotObject.transform.SetPositionY(Util.ConvertMousePositionToRectTransform(canvas).y);
		}
		draggedSlotObject.transform.SetLocalPositionZ(-300f);
		int num = dropZoneObject.transform.childCount;
		foreach (Transform item in dropZoneObject.transform)
		{
			float num2 = (isYaxis ? draggedSlotObject.transform.position.y : draggedSlotObject.transform.position.x);
			float num3 = (isYaxis ? item.position.y : item.position.x);
			if (isYaxis ? (num2 > num3) : (num2 < num3))
			{
				num = item.GetSiblingIndex();
				if (placeholderElementObject.transform.GetSiblingIndex() < num)
				{
					num--;
				}
				break;
			}
		}
		if (num >= dropZoneObject.transform.childCount)
		{
			num = dropZoneObject.transform.childCount - 1;
		}
		placeholderElementObject.transform.SetSiblingIndex(num);
		newElementIndex = num;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.OnEndDragEvent != null)
		{
			this.OnEndDragEvent();
		}
		UnityEngine.Object.Destroy(placeholderElementObject);
		draggedSlotObject.transform.SetParent(parentTransform, worldPositionStays: false);
		draggedSlotObject.transform.SetLocalPositionZ(0f);
		draggedSlotObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
		OnEndDragHandler(oldElementIndex, newElementIndex);
	}

	protected abstract void OnEndDragHandler(int oldElementIndex, int newElementIndex);
}
