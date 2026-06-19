using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoCursorsBlockView : UIView, IPointerDownHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	[SerializeField]
	private RectTransform dragHandle;

	private RectTransform rectTransform;

	private Canvas canvas;

	private bool isDragging;

	private Vector2 pointerOffset;

	protected override void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvas = GetComponentInParent<Canvas>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (RectTransformUtility.RectangleContainsScreenPoint(dragHandle, eventData.position, eventData.pressEventCamera))
		{
			isDragging = true;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var localPoint);
			pointerOffset = localPoint;
		}
		else
		{
			isDragging = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (isDragging && !(canvas == null) && RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
		{
			rectTransform.localPosition = localPoint - pointerOffset;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		isDragging = false;
	}
}
