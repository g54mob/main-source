using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TooltipSnap : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private TooltipSpecial tooltip;

		private RectTransform areaRect;

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
