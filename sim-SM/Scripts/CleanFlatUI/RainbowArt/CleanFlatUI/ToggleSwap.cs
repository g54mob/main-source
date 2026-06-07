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
		}

		private void UpdateGUI()
		{
		}

		private void ToggleValueChanged(bool value)
		{
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
		}
	}
}
