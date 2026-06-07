using UnityEngine;
using UnityEngine.EventSystems;

namespace CompassNavigatorPro
{
	[AddComponentMenu("")]
	public class CompassIconEventHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
	{
		public CompassProPOI poi;

		public CompassPro compass;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!(compass == null))
			{
				compass.BubbleEvent(compass.OnPOIMiniMapIconMouseEnter, poi);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (!(compass == null))
			{
				compass.BubbleEvent(compass.OnPOIMiniMapIconMouseExit, poi);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!(compass == null))
			{
				compass.BubbleEvent(compass.OnPOIMiniMapIconMouseClick, poi, (int)eventData.button);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (!(compass == null))
			{
				compass.BubbleEvent(compass.OnPOIMiniMapIconMouseDown, poi, (int)eventData.button);
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (!(compass == null))
			{
				compass.BubbleEvent(compass.OnPOIMiniMapIconMouseUp, poi, (int)eventData.button);
			}
		}
	}
}
