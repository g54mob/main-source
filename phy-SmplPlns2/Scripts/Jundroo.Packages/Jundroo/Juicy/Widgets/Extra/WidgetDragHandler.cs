using UnityEngine;
using UnityEngine.EventSystems;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class WidgetDragHandler : MonoBehaviour, IDragHandler, IEventSystemHandler
	{
		private Widget _widget;

		public void OnDrag(PointerEventData eventData)
		{
			_widget.Rect.anchoredPosition += eventData.delta;
		}

		protected virtual void Awake()
		{
			_widget = base.gameObject.GetComponent<Widget>();
		}
	}
}
