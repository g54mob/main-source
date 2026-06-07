using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	[RequireComponent(typeof(Image))]
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
