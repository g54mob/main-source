using UnityEngine;
using UnityEngine.EventSystems;

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
		}

		private void Update()
		{
		}

		private void UpdatePosition()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}
