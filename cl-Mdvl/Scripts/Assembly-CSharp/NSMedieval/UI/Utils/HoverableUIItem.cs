using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI.Utils
{
	[RequireComponent(typeof(Image))]
	public class HoverableUIItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private float highlightAlphaAdd = 2f;

		[SerializeField]
		private bool alternateColor;

		private float alternateAlphaAdd = 2f;

		private Image image;

		private Color baseColor;

		private void Start()
		{
			image = GetComponent<Image>();
			baseColor = image.color;
			if (alternateColor && base.transform.GetSiblingIndex() % 2 == 0)
			{
				image.color = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a + alternateAlphaAdd / 255f);
				baseColor = image.color;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			image.color = new Color(baseColor.r, baseColor.g, baseColor.b, baseColor.a + highlightAlphaAdd / 255f);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			image.color = baseColor;
		}
	}
}
