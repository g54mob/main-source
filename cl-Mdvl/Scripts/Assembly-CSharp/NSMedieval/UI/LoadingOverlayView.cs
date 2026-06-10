using System.Collections;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class LoadingOverlayView : MonoBehaviour
	{
		[SerializeField]
		private float fadeInDuration = 0.2f;

		[SerializeField]
		private float fadeOutDuration = 0.4f;

		[SerializeField]
		private CanvasGroupFader mainGroupFader;

		[SerializeField]
		private CanvasGroupFader sliderGroupFader;

		[SerializeField]
		private Slider slider;

		[SerializeField]
		private TMP_Text errorText;

		private void OnEnable()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(6, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LoadingOverlayView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(GetInstanceID());
				messageBuilder.AppendLiteral(" Start");
			}
			Log.Trace(messageBuilder);
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlayEvent += Show;
			MonoSingleton<LoadingController>.Instance.ShowLoadingErrorEvent += ShowLoadingErrorMessage;
		}

		private void OnDisable()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LoadingOverlayView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(GetInstanceID());
				messageBuilder.AppendLiteral(" OnDestroy");
			}
			Log.Trace(messageBuilder);
			if (MonoSingleton<LoadingOverlayController>.IsInstantiated())
			{
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlayEvent -= Show;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.ShowLoadingErrorEvent -= ShowLoadingErrorMessage;
			}
		}

		private void Show(bool show, bool showLoadingBar)
		{
			if (mainGroupFader.IsVisible != show)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(25, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LoadingOverlayView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetInstanceID());
					messageBuilder.AppendLiteral(" Show: ");
					messageBuilder.AppendFormatted(show);
					messageBuilder.AppendLiteral(" with LoadingBar: ");
					messageBuilder.AppendFormatted(showLoadingBar);
				}
				Log.Trace(messageBuilder);
				if (show)
				{
					StartCoroutine(ShowCoroutine(showLoadingBar));
					return;
				}
				StopAllCoroutines();
				StartCoroutine(HideCoroutine());
			}
		}

		private void ShowLoadingErrorMessage(string errorMessage)
		{
			errorText.gameObject.SetActive(value: true);
			errorText.text = MonoSingleton<LocalizationController>.Instance.GetText(errorMessage);
		}

		private void Reset()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(6, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LoadingOverlayView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(GetInstanceID());
				messageBuilder.AppendLiteral(" Reset");
			}
			Log.Trace(messageBuilder);
			errorText.gameObject.SetActive(value: false);
			mainGroupFader.SetBlockRaycasts(blockRaycasts: false);
			mainGroupFader.Hide();
			sliderGroupFader.Hide();
			slider.value = 0f;
		}

		private IEnumerator ShowCoroutine(bool showLoadingBar)
		{
			Reset();
			mainGroupFader.SetBlockRaycasts(blockRaycasts: true);
			mainGroupFader.FadeIn(fadeInDuration);
			yield return new WaitForSeconds(fadeInDuration + 0.1f);
			if (showLoadingBar)
			{
				sliderGroupFader.FadeIn(fadeInDuration);
				yield return new WaitForSeconds(fadeInDuration + 0.1f);
				yield return MoveSlider();
			}
		}

		private IEnumerator HideCoroutine()
		{
			if (sliderGroupFader.IsVisible)
			{
				sliderGroupFader.FadeOut(fadeOutDuration);
				yield return new WaitForSeconds(fadeOutDuration + 0.05f);
			}
			mainGroupFader.SetBlockRaycasts(blockRaycasts: false);
			mainGroupFader.FadeOut(fadeOutDuration);
			yield return new WaitForSeconds(fadeOutDuration + 0.05f);
			Reset();
		}

		private IEnumerator MoveSlider()
		{
			float step = 0.005f;
			float max = 0.1f;
			float percent = 0f;
			slider.value = percent;
			while (percent < max)
			{
				percent += step;
				slider.value = percent;
				yield return new WaitForSeconds(step);
			}
			slider.value = max;
		}
	}
}
