using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Animation/Image Pulse")]
	public class ImagePulse : MonoBehaviour
	{
		[Header("Resources")]
		[SerializeField]
		private Image targetImage;

		[Header("Color")]
		[Range(0f, 1f)]
		public float minAlpha = 0.25f;

		[Range(0f, 1f)]
		public float maxAlpha = 1f;

		[Header("Animation")]
		[Range(0.5f, 10f)]
		public float pulseSpeed = 1f;

		[SerializeField]
		private AnimationCurve pulseCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		private void OnEnable()
		{
			StartPulse();
		}

		public void StartPulse()
		{
			if (!base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: true);
			}
			if (targetImage == null)
			{
				targetImage = GetComponent<Image>();
			}
			targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, minAlpha);
			StopCoroutine("PulseInAnimation");
			StopCoroutine("PulseOutAnimation");
			StartCoroutine("PulseInAnimation");
		}

		private IEnumerator PulseInAnimation()
		{
			float elapsedTime = 0f;
			targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, minAlpha);
			while (targetImage.color.a < maxAlpha)
			{
				elapsedTime += Time.unscaledDeltaTime;
				targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, Mathf.Lerp(minAlpha, maxAlpha, pulseCurve.Evaluate(elapsedTime * pulseSpeed)));
				yield return null;
			}
			targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, maxAlpha);
			StartCoroutine("PulseOutAnimation");
		}

		private IEnumerator PulseOutAnimation()
		{
			float elapsedTime = 0f;
			targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, maxAlpha);
			while (targetImage.color.a > minAlpha)
			{
				elapsedTime += Time.unscaledDeltaTime;
				targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, Mathf.Lerp(maxAlpha, minAlpha, pulseCurve.Evaluate(elapsedTime * pulseSpeed)));
				yield return null;
			}
			targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, minAlpha);
			StartCoroutine("PulseInAnimation");
		}
	}
}
