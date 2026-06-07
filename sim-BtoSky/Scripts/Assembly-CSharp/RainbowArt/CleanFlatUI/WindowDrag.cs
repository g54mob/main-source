using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class WindowDrag : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		[SerializeField]
		private RectTransform draggableArea;

		private RectTransform cachedParentRect;

		private RectTransform cachedSelfRect;

		private bool isDraggableArea;

		private Vector2 dragPosOffset;

		private void Awake()
		{
			cachedSelfRect = GetComponent<RectTransform>();
			cachedParentRect = cachedSelfRect.parent as RectTransform;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (RectTransformUtility.RectangleContainsScreenPoint(draggableArea, eventData.position, eventData.pressEventCamera))
			{
				Vector2 localPoint = Vector2.zero;
				Vector2 vector = cachedSelfRect.localPosition;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(cachedParentRect, eventData.position, eventData.pressEventCamera, out localPoint);
				dragPosOffset = vector - localPoint;
				isDraggableArea = true;
			}
			else
			{
				isDraggableArea = false;
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			isDraggableArea = false;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (isDraggableArea)
			{
				Vector2 localPoint = Vector2.zero;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(cachedParentRect, eventData.position, eventData.pressEventCamera, out localPoint))
				{
					cachedSelfRect.localPosition = localPoint + dragPosOffset;
				}
			}
		}
	}
}
