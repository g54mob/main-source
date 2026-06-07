using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableBorderComponent : Selectable, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	public DraggableBorder draggableBorder;

	public new Image image;

	private bool isDragging;

	public void OnBeginDrag(PointerEventData eventData)
	{
		draggableBorder.OnBeginDrag(this);
		isDragging = true;
	}

	public void OnDrag(PointerEventData eventData)
	{
		draggableBorder.OnDrag();
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		if (!draggableBorder.isDragging)
		{
			SetImageState(shouldShow: true);
		}
		draggableBorder.OnHover(this);
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		if (!isDragging)
		{
			SetImageState(shouldShow: false);
			MenuManager.Instance.cursorDisplay.SetCursorDefault();
		}
	}

	private void SetImageState(bool shouldShow)
	{
		image.color = (shouldShow ? new Color(1f, 1f, 1f, 0.5f) : Color.clear);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		isDragging = false;
		draggableBorder.OnEndDrag();
		SetImageState(shouldShow: false);
		MenuManager.Instance.cursorDisplay.SetCursorDefault();
	}
}
