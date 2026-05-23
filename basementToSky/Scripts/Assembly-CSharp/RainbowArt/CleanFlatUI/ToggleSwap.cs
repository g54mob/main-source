using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ToggleSwap : MonoBehaviour
	{
		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private Image background;

		[SerializeField]
		private Image foreground;

		private CanvasGroup canvasGroupBg;

		private CanvasGroup canvasGroupFg;

		private void Start()
		{
			UpdateGUI();
		}

		private void UpdateGUI()
		{
			if (toggle == null)
			{
				toggle = GetComponent<Toggle>();
			}
			if (canvasGroupBg == null)
			{
				canvasGroupBg = background.gameObject.GetComponent<CanvasGroup>();
			}
			if (canvasGroupFg == null)
			{
				canvasGroupFg = foreground.gameObject.GetComponent<CanvasGroup>();
			}
			toggle.onValueChanged.AddListener(ToggleValueChanged);
			ToggleValueChanged(toggle.isOn);
		}

		private void ToggleValueChanged(bool value)
		{
			if (value)
			{
				SetCanvasGroupAlpha(canvasGroupBg, 0f);
				SetCanvasGroupAlpha(canvasGroupFg, 1f);
			}
			else
			{
				SetCanvasGroupAlpha(canvasGroupBg, 1f);
				SetCanvasGroupAlpha(canvasGroupFg, 0f);
			}
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
			obj.alpha = alpha;
		}
	}
}
