using System.Collections;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class CanvasGroupFader : MonoBehaviour
	{
		[Header("Fade In")]
		[SerializeField]
		private bool autoFadeIn;

		[SerializeField]
		private float fadeInDuration = 0.2f;

		[SerializeField]
		private AnimationCurve fadeInEasing = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Header("Fade Out")]
		[SerializeField]
		private float fadeOutDuration = 0.4f;

		[SerializeField]
		private AnimationCurve fadeOutEasing = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		private CanvasGroup canvasGroup;

		public bool IsVisible => canvasGroup.alpha > 0f;

		public float FadeOutDuration => fadeOutDuration;

		public float FadeInDuration => fadeInDuration;

		public void Show()
		{
			canvasGroup.alpha = 1f;
		}

		public void Hide()
		{
			canvasGroup.alpha = 0f;
		}

		public void SetBlockRaycasts(bool blockRaycasts)
		{
			canvasGroup.blocksRaycasts = blockRaycasts;
		}

		public void SetInteractable(bool interactable)
		{
			canvasGroup.interactable = interactable;
		}

		public void FadeIn(float duration = 0f)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(7, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CanvasGroupFader.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("FadeIn ");
				messageBuilder.AppendFormatted(base.gameObject.name);
			}
			Log.Debug(messageBuilder);
			duration = ((duration == 0f) ? FadeInDuration : duration);
			StartCoroutine(FadeInCr(duration));
		}

		public void FadeOut(float duration = 0f)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CanvasGroupFader.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("FadeOut ");
				messageBuilder.AppendFormatted(base.gameObject.name);
			}
			Log.Debug(messageBuilder);
			duration = ((duration == 0f) ? FadeOutDuration : duration);
			StartCoroutine(FadeOutCr(duration));
		}

		private IEnumerator FadeInCr(float duration)
		{
			if (duration == 0f)
			{
				Show();
				yield break;
			}
			Hide();
			float timer = 0f;
			while (timer < duration)
			{
				float time = timer / duration;
				float alpha = fadeInEasing.Evaluate(time);
				canvasGroup.alpha = alpha;
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(16, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CanvasGroupFader.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" Fade In alpha: ");
					messageBuilder.AppendFormatted(canvasGroup.alpha);
				}
				Log.Trace(messageBuilder);
				timer += Time.unscaledDeltaTime;
				yield return null;
			}
			Show();
		}

		private IEnumerator FadeOutCr(float duration)
		{
			if (duration == 0f)
			{
				Hide();
				yield break;
			}
			Show();
			float timer = 0f;
			while (timer < duration)
			{
				float time = timer / duration;
				float alpha = fadeOutEasing.Evaluate(time);
				canvasGroup.alpha = alpha;
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(17, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\CanvasGroupFader.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" Fade Out alpha: ");
					messageBuilder.AppendFormatted(canvasGroup.alpha);
				}
				Log.Trace(messageBuilder);
				timer += Time.unscaledDeltaTime;
				yield return null;
			}
			Hide();
		}

		private void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}

		private void OnEnable()
		{
			if (autoFadeIn)
			{
				FadeIn();
			}
		}
	}
}
