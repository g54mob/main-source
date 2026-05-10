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
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}
	}
}
