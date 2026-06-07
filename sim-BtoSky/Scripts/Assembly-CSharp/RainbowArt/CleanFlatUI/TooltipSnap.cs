using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace RainbowArt.CleanFlatUI
{
	public class TooltipSnap : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private TooltipSpecial tooltip;

		private RectTransform areaScope;

		private Camera cachedEnterEventCamera;

		private void Start()
		{
			areaScope = GetComponent<RectTransform>();
			tooltip.gameObject.SetActive(value: false);
			UpdatePosition();
		}

		private void Update()
		{
			if (tooltip.gameObject.activeSelf && cachedEnterEventCamera != null)
			{
				Vector2 screenPoint = Mouse.current.position.ReadValue();
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(areaScope, screenPoint, cachedEnterEventCamera, out var _))
				{
					UpdatePosition();
				}
			}
		}

		private void UpdatePosition()
		{
			Vector2 screenPoint = Mouse.current.position.ReadValue();
			Vector2 localPoint = Vector2.zero;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(tooltip.gameObject.GetComponent<RectTransform>().parent as RectTransform, screenPoint, cachedEnterEventCamera, out localPoint);
			tooltip.InitTooltip(localPoint, areaScope);
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
