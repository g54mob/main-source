using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace RainbowArt.CleanFlatUI
{
	public class TooltipInDetermine : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Tooltip tooltip;

		private RectTransform cachedRect;

		private Camera cachedEnterEventCamera;

		private void Start()
		{
			cachedRect = GetComponent<RectTransform>();
			tooltip.gameObject.SetActive(value: false);
			UpdatePosition();
		}

		private void Update()
		{
			if (tooltip.gameObject.activeSelf && cachedEnterEventCamera != null)
			{
				Vector2 screenPoint = Mouse.current.position.ReadValue();
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(cachedRect, screenPoint, cachedEnterEventCamera, out var _))
				{
					UpdatePosition();
				}
			}
		}

		private void UpdatePosition()
		{
			RectTransform rectTransform = tooltip.GetComponent<RectTransform>().parent as RectTransform;
			if (!(rectTransform == null))
			{
				Vector2 screenPoint = Mouse.current.position.ReadValue();
				RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, cachedEnterEventCamera, out var localPoint);
				Vector3 position = new Vector3(localPoint.x, localPoint.y, 0f);
				tooltip.SetTooltipPosition(position, 0f, 0f);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			cachedEnterEventCamera = eventData.enterEventCamera;
			tooltip.ShowTooltip();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			cachedEnterEventCamera = null;
			tooltip.HideTooltip();
		}
	}
}
