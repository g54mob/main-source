using UnityEngine;

namespace Pug.UnityExtensions
{
	public class CanvasFader : MonoBehaviour
	{
		[Header("References:")]
		public CanvasGroup canvasGroup;

		[Header("Settings:")]
		public bool UseUnscaledTime = true;

		public Fader fader;

		private void Awake()
		{
			float currentTime = (UseUnscaledTime ? Time.unscaledTime : Time.time);
			fader = new Fader(0f, Fader.FadeFunction.SmoothStep, currentTime);
		}

		private void LateUpdate()
		{
			if (canvasGroup != null)
			{
				float currentTime = (UseUnscaledTime ? Time.unscaledTime : Time.time);
				float alpha = fader.UpdateFadeValue(currentTime);
				canvasGroup.alpha = alpha;
			}
		}

		public void FadeIn(float dur)
		{
			float currentTime = (UseUnscaledTime ? Time.unscaledTime : Time.time);
			fader.FadeIn(dur, currentTime);
		}

		public void FadeOut(float dur)
		{
			float currentTime = (UseUnscaledTime ? Time.unscaledTime : Time.time);
			fader.FadeOut(dur, currentTime);
		}
	}
}
