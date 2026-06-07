using UnityEngine;
using UnityEngine.EventSystems;

namespace SLS.Widgets.Table
{
	public class ResizePanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler
	{
		public Vector2 minSize;

		public Vector2 maxSize;

		private RectTransform rectTransform;

		private Vector2 currentPointerPosition;

		private Vector2 previousPointerPosition;

		private void Awake()
		{
		}

		public void OnPointerDown(PointerEventData data)
		{
		}

		public void OnDrag(PointerEventData data)
		{
		}
	}
}
