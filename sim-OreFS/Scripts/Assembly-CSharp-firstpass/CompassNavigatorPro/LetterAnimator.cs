using UnityEngine;
using UnityEngine.UI;

namespace CompassNavigatorPro
{
	public class LetterAnimator : MonoBehaviour
	{
		public float startTime;

		public float revealDuration;

		public float startFadeTime;

		public float fadeDuration;

		public Text text;

		public Text textShadow;

		public int poolIndex;

		public OnAnimationEndDelegate OnAnimationEnds;

		public bool used;

		private Vector3 originalScale;

		private void Awake()
		{
			base.enabled = false;
		}

		private void Update()
		{
			float time = Time.time;
			float num = time - startTime;
			if (num < revealDuration)
			{
				float t = Mathf.Clamp01(num / revealDuration);
				UpdateTextScale(t);
				UpdateTextAlpha(t);
			}
			else if (time < startFadeTime)
			{
				UpdateTextScale(1f);
				UpdateTextAlpha(1f);
			}
			else if (time < startFadeTime + fadeDuration)
			{
				float t2 = Mathf.Clamp01(1f - (time - startFadeTime) / fadeDuration);
				UpdateTextAlpha(t2);
			}
			else
			{
				OnAnimationEnds(poolIndex);
				base.enabled = false;
			}
		}

		public void Play()
		{
			if (originalScale.z == 0f)
			{
				originalScale = text.transform.localScale;
			}
			base.enabled = true;
			Update();
		}

		private void UpdateTextScale(float t)
		{
			Vector3 localScale = originalScale;
			localScale.x *= t;
			localScale.y *= t;
			text.transform.localScale = localScale;
			textShadow.transform.localScale = localScale;
		}

		private void UpdateTextAlpha(float t)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, t);
			textShadow.color = new Color(0f, 0f, 0f, t);
		}
	}
}
