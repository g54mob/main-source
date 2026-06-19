using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
	public class UIDraggableWindow : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[Header("Drag Settings")]
		[SerializeField]
		private RectTransform dragHandle;

		[SerializeField]
		private RectTransform windowRoot;

		[SerializeField]
		private float dragThreshold = 8f;

		private Vector2 pointerDownPos;

		private Vector2 offset;

		private bool isDragging;

		private void Awake()
		{
			if (windowRoot == null)
			{
				windowRoot = GetComponent<RectTransform>();
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (RectTransformUtility.RectangleContainsScreenPoint(dragHandle, eventData.position, eventData.pressEventCamera))
			{
				pointerDownPos = eventData.position;
				isDragging = false;
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (Vector2.Distance(eventData.position, pointerDownPos) > dragThreshold && RectTransformUtility.RectangleContainsScreenPoint(dragHandle, eventData.position, eventData.pressEventCamera))
			{
				isDragging = true;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(windowRoot, eventData.position, eventData.pressEventCamera, out offset);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (isDragging && RectTransformUtility.ScreenPointToLocalPointInRectangle(windowRoot.parent as RectTransform, eventData.position, eventData.pressEventCamera, out var localPoint))
			{
				windowRoot.localPosition = localPoint - offset;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			isDragging = false;
		}
	}
}
