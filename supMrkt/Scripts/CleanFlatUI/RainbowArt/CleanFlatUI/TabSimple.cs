using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class TabSimple : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private RectTransform checkmark;

		[SerializeField]
		private RectTransform on;

		[SerializeField]
		private RectTransform off;

		private CanvasGroup canvasGroupCheckmark;

		private CanvasGroup canvasGroupOn;

		private CanvasGroup canvasGroupOff;

		private bool isPointerEntered;

		private void OnEnable()
		{
		}

		private void initCanvasGroup()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void UpdateStatusContent()
		{
		}

		public void SetTabOn(bool bOn)
		{
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
		}
	}
}
