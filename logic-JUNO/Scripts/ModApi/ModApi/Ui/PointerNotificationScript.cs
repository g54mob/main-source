using UnityEngine;
using UnityEngine.EventSystems;

namespace ModApi.Ui
{
	public class PointerNotificationScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
	{
		public delegate void PointerEventHandler(PointerNotificationScript source, PointerEventData eventData);

		public delegate void PointerEventHandlerNoSource(PointerEventData eventData);

		public event PointerEventHandler PointerClick;

		public event PointerEventHandlerNoSource PointerClickNoSource;

		public event PointerEventHandler PointerEnter;

		public event PointerEventHandlerNoSource PointerEnterNoSource;

		public event PointerEventHandler PointerExit;

		public event PointerEventHandlerNoSource PointerExitNoSource;

		public event PointerEventHandler Scroll;

		public event PointerEventHandlerNoSource ScrollNoSource;

		public void OnPointerClick(PointerEventData eventData)
		{
			this.PointerClick?.Invoke(this, eventData);
			this.PointerClickNoSource?.Invoke(eventData);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.PointerEnter?.Invoke(this, eventData);
			this.PointerEnterNoSource?.Invoke(eventData);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			this.PointerExit?.Invoke(this, eventData);
			this.PointerExitNoSource?.Invoke(eventData);
		}

		public void OnScroll(PointerEventData eventData)
		{
			this.Scroll?.Invoke(this, eventData);
			this.ScrollNoSource?.Invoke(eventData);
		}
	}
}
