using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScaledScrollRect : ScrollRect
{
	public Transform zoomContainer;

	private Vector2 lastLocalPointerPosition;

	private Canvas rootCanvas;

	protected override void Awake()
	{
		base.Awake();
		zoomContainer = base.content.parent;
		rootCanvas = GetComponentInParent<Canvas>();
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
		base.OnBeginDrag(eventData);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.viewport, eventData.position, eventData.pressEventCamera, out lastLocalPointerPosition);
	}

	public override void OnDrag(PointerEventData eventData)
	{
		if (IsActive() && !(base.content == null) && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.viewport, eventData.position, eventData.pressEventCamera, out var localPoint))
		{
			Vector3 vector = ((zoomContainer != null) ? zoomContainer.lossyScale : Vector3.one);
			vector.x /= rootCanvas.scaleFactor;
			vector.y /= rootCanvas.scaleFactor;
			Vector2 vector2 = localPoint - lastLocalPointerPosition;
			vector2.x /= vector.x;
			vector2.y /= vector.y;
			Vector2 contentAnchoredPosition = base.content.anchoredPosition + vector2;
			SetContentAnchoredPosition(contentAnchoredPosition);
			lastLocalPointerPosition = localPoint;
		}
	}
}
