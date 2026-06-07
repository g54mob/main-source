using UnityEngine;
using UnityEngine.EventSystems;

namespace Jundroo.Common.UI
{
	public class PointerNotificationScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public delegate void PointerEventHandler(PointerNotificationScript source, PointerEventData eventData);

		public delegate void PointerEventHandlerNoSource(PointerEventData eventData);

		public event PointerEventHandler PointerClick;

		public event PointerEventHandlerNoSource PointerClickNoSource;

		public event PointerEventHandler PointerEnter;

		public event PointerEventHandlerNoSource PointerEnterNoSource;

		public event PointerEventHandler PointerExit;

		public event PointerEventHandlerNoSource PointerExitNoSource;

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
	}
}
