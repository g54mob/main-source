using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class TooltipDetermine : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Tooltip tooltip;

		private void Start()
		{
			tooltip.gameObject.SetActive(value: false);
		}

		private void UpdatePosition()
		{
			RectTransform rectTransform = tooltip.GetComponent<RectTransform>().parent as RectTransform;
			if (!(rectTransform == null))
			{
				RectTransform component = GetComponent<RectTransform>();
				float width = component.rect.width;
				float height = component.rect.height;
				Vector3[] array = new Vector3[4];
				component.GetWorldCorners(array);
				Vector3[] array2 = new Vector3[4];
				for (int i = 0; i < 4; i++)
				{
					array2[i] = rectTransform.InverseTransformPoint(array[i]);
				}
				Vector3 position = (array2[0] + array2[2]) / 2f;
				tooltip.SetTooltipPosition(position, width, height);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			UpdatePosition();
			tooltip.ShowTooltip();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			tooltip.HideTooltip();
		}
	}
}
