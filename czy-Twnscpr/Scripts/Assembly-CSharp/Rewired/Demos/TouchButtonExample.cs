using UnityEngine;
using UnityEngine.EventSystems;

namespace Rewired.Demos
{
	public class TouchButtonExample : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public bool allowMouseControl;

		public bool isPressed { get; private set; }

		private void Awake()
		{
		}

		private void Restart()
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		private static bool IsMousePointerId(int id)
		{
			return false;
		}
	}
}
