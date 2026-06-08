using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rhizomatic.Utility
{
	public class RealClick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public UnityEvent onClick;

		private int downPointerId;

		private float downTime;

		private Vector2 downPosition;

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}
	}
}
