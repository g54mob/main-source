using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class PopupMenuLongPress : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		[SerializeField]
		private PopupMenu popupMenu;

		private Camera cachedEnterEventCamera;

		private bool isPressed;

		private float elapsedTime;

		private float duration;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void showPopupMenu()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		private void PopupMenuValueChanged(int index)
		{
		}
	}
}
