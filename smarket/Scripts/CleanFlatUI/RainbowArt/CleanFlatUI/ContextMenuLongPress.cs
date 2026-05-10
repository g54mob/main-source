using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class ContextMenuLongPress : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		[SerializeField]
		private ContextMenu contextMenu;

		[SerializeField]
		private RectTransform areaScope;

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

		private void showContextMenu()
		{
		}

		private void UpdatePosition()
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

		private void ContextMenuValueChanged(int index)
		{
		}
	}
}
