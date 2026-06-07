using UnityEngine;
using UnityEngine.EventSystems;

namespace SkywardRay.FileBrowser
{
	public class SfbDisabledWindowOverlay : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
		private SfbInternal fileBrowser;

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

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
