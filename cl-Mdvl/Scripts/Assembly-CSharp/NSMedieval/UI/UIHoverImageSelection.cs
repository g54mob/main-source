using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(Image))]
	public class UIHoverImageSelection : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private Image hilightImage;

		private Color highlightedColor;

		private Color transparentColor;

		private void Awake()
		{
			hilightImage = GetComponent<Image>();
			highlightedColor = hilightImage.color;
			transparentColor = highlightedColor;
			transparentColor.a = 0f;
			hilightImage.color = transparentColor;
			hilightImage.enabled = true;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			hilightImage.color = highlightedColor;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			hilightImage.color = transparentColor;
		}
	}
}
