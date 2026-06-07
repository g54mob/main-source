using Motorways.Themes;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class CinematicZoomButton : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private ThemeTypeToggler _symbolThemeToggler;

		[SerializeField]
		private CanvasGroup _fillCanvasGroup;

		[SerializeField]
		private CanvasGroup _outlineCanvasGroup;

		[SerializeField]
		private GameObject _highlightColor;

		[SerializeField]
		private GameObject _highlightOutline;

		[SerializeField]
		private TouchButton _touchButton;

		private float alphaOverride = 1f;

		public void Deactivate()
		{
			_symbolThemeToggler.SetSelectedTheme(isFirstSelected: false);
			_fillCanvasGroup.alpha = 0f;
			_outlineCanvasGroup.alpha = 1f;
			alphaOverride = 0.5f;
			_highlightColor.SetActive(value: false);
			_highlightOutline.SetActive(value: false);
			_touchButton.interactable = false;
			_touchButton.ForceInitializeState();
		}

		public void Activate()
		{
			_symbolThemeToggler.SetSelectedTheme(isFirstSelected: true);
			_fillCanvasGroup.alpha = 1f;
			_outlineCanvasGroup.alpha = 0f;
			alphaOverride = 1f;
			_highlightColor.SetActive(value: true);
			_highlightOutline.SetActive(value: true);
			_touchButton.interactable = true;
		}

		private void Update()
		{
			_canvasGroup.alpha = alphaOverride;
		}
	}
}
