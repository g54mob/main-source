using UnityEngine;
using UnityEngine.EventSystems;

namespace SkywardRay.FileBrowser
{
	public class SfbDraggable : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler
	{
		private Vector2 oldpos;

		private RectTransform rectTransform;

		private RectTransform canvasRectTransform;

		public void Start()
		{
		}

		public void OnDrag(PointerEventData data)
		{
		}

		public void OnPointerDown(PointerEventData data)
		{
		}
	}
}
