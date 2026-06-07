using UnityEngine;
using UnityEngine.EventSystems;

namespace SkywardRay.FileBrowser
{
	public class SfbResizeButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		public SfbResizeSide resizeSide;

		private SfbResizeable resizeable;

		private Vector2 oldpos;

		private void Start()
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
