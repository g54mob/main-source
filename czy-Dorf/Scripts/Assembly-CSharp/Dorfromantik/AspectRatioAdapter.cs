using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class AspectRatioAdapter : MonoBehaviour
	{
		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private float aspectRatioThresholdForToSmall = 1.5f;

		[SerializeField]
		private bool shouldAdaptRectTransformWidth;

		[SerializeField]
		private float smallRatioRectTransformWidth;

		[SerializeField]
		private float normalRatioRectTransformWidth;

		[SerializeField]
		private bool shouldAdaptRectTransformAnchoredPosition;

		[SerializeField]
		private Vector2 smallRatioRecTransformAnchoredPosition;

		[SerializeField]
		private Vector2 normalRatioRecTransformAnchoredPosition;

		private RectTransform rectTransform;

		private MainMenuScreen mainMenuScreen;

		private float currentAspectRatio;

		private bool isAdaptedToSmallAspectRatio;

		private RectTransform mainMenuCanvasRectTransform;

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			mainMenuScreen = GetComponent<MainMenuScreen>();
			mainMenuCanvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
			settingsRouter.OnResolutionChanged += AdaptLayoutToSmallAspectRatio;
			AdaptLayoutToSmallAspectRatioInNextFrame();
		}

		private void GetCurrentAspectRatio()
		{
			if (Application.isEditor)
			{
				currentAspectRatio = mainMenuCanvasRectTransform.sizeDelta.x / mainMenuCanvasRectTransform.sizeDelta.y;
			}
			else
			{
				currentAspectRatio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
			}
		}

		private void AdaptLayoutToSmallAspectRatio(Resolution resolution)
		{
			AdaptLayoutToSmallAspectRatioInNextFrame((float)resolution.width / (float)resolution.height);
		}

		private void AdaptLayoutToSmallAspectRatioInNextFrame(float overrideAspectRatio = -1f)
		{
			if (overrideAspectRatio > 0f)
			{
				currentAspectRatio = overrideAspectRatio;
			}
			else
			{
				GetCurrentAspectRatio();
			}
			bool flag = currentAspectRatio <= aspectRatioThresholdForToSmall;
			if (shouldAdaptRectTransformAnchoredPosition)
			{
				mainMenuScreen.SetVisibleAnchorPos(flag ? smallRatioRecTransformAnchoredPosition : normalRatioRecTransformAnchoredPosition);
			}
			if (shouldAdaptRectTransformWidth)
			{
				rectTransform.sizeDelta = (flag ? new Vector2(smallRatioRectTransformWidth, 0f) : new Vector2(normalRatioRectTransformWidth, 0f));
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
		}

		private void OnDestroy()
		{
			settingsRouter.OnResolutionChanged -= AdaptLayoutToSmallAspectRatio;
		}
	}
}
