using System.Collections;
using FMODUnity;
using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core
{
	public sealed class AggroFadeSettingUI : MonoBehaviour
	{
		public CanvasGroup canvasGroup;

		public EventReference sfxShow;

		public void PrepareForShow()
		{
			canvasGroup.alpha = 0f;
			StopAllCoroutines();
		}

		internal void Show(float duration, EasingFunction.Ease ease)
		{
			StartCoroutine(ShowCo(duration, ease));
		}

		private IEnumerator ShowCo(float duration, EasingFunction.Ease ease)
		{
			AggroUtil.PlaySfxIfValid(sfxShow);
			float time = 0f;
			while (time < duration)
			{
				yield return null;
				time += Time.unscaledDeltaTime;
				canvasGroup.alpha = EasingFunction.Evaluate(ease, 0f, 1f, math.saturate(time / duration));
			}
		}
	}
}
