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
			isPointerEntered = false;
			UpdateStatusContent();
		}

		private void initCanvasGroup()
		{
			if (canvasGroupCheckmark == null)
			{
				canvasGroupCheckmark = checkmark.gameObject.GetComponent<CanvasGroup>();
			}
			if (canvasGroupOn == null)
			{
				canvasGroupOn = on.gameObject.GetComponent<CanvasGroup>();
			}
			if (canvasGroupOff == null)
			{
				canvasGroupOff = off.gameObject.GetComponent<CanvasGroup>();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isPointerEntered = true;
			UpdateStatusContent();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isPointerEntered = false;
			UpdateStatusContent();
		}

		public void UpdateStatusContent()
		{
			initCanvasGroup();
			if (!toggle.isOn)
			{
				if (isPointerEntered)
				{
					SetCanvasGroupAlpha(canvasGroupOn, 0f);
					SetCanvasGroupAlpha(canvasGroupOff, 1f);
					SetCanvasGroupAlpha(canvasGroupCheckmark, 0f);
				}
				else
				{
					SetCanvasGroupAlpha(canvasGroupOn, 0f);
					SetCanvasGroupAlpha(canvasGroupOff, 0.4f);
					SetCanvasGroupAlpha(canvasGroupCheckmark, 0f);
				}
			}
		}

		public void SetTabOn(bool bOn)
		{
			initCanvasGroup();
			if (bOn)
			{
				SetCanvasGroupAlpha(canvasGroupOn, 1f);
				SetCanvasGroupAlpha(canvasGroupOff, 0f);
				SetCanvasGroupAlpha(canvasGroupCheckmark, 1f);
			}
			else
			{
				SetCanvasGroupAlpha(canvasGroupOn, 0f);
				SetCanvasGroupAlpha(canvasGroupOff, 0.4f);
				SetCanvasGroupAlpha(canvasGroupCheckmark, 0f);
			}
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
			obj.alpha = alpha;
		}
	}
}
