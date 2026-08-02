using UnityEngine;
using UnityEngine.EventSystems;

namespace Rhizomatic
{
	public class CurveFieldRaycastHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public CurveFieldPopup popup;

		private float lastClick;

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
