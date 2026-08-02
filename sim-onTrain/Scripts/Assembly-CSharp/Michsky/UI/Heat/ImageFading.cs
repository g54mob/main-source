using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(Image))]
	[AddComponentMenu("Heat UI/Animation/Image Fading")]
	public class ImageFading : MonoBehaviour
	{
		public enum EnableBehaviour
		{
			None = 0,
			FadeIn = 1,
			FadeOut = 2
		}

		[Header("Settings")]
		[SerializeField]
		private bool doPingPong;

		[SerializeField]
		[Range(0.5f, 12f)]
		private float fadeSpeed = 2f;

		[SerializeField]
		private AnimationCurve fadeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[SerializeField]
		private EnableBehaviour enableBehaviour;

		[Header("Events")]
		public UnityEvent onFadeIn;

		public UnityEvent onFadeInEnd;

		public UnityEvent onFadeOut;

		public UnityEvent onFadeOutEnd;

		private Image targetImg;

		private void OnEnable()
		{
			if (enableBehaviour == EnableBehaviour.FadeIn)
			{
				FadeIn();
			}
			else if (enableBehaviour == EnableBehaviour.FadeOut)
			{
				FadeOut();
			}
		}

		public void FadeIn()
		{
			if (!base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: true);
			}
			if (targetImg == null)
			{
				targetImg = GetComponent<Image>();
			}
			targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 0f);
			onFadeIn.Invoke();
			StopCoroutine("DoFadeIn");
			StopCoroutine("DoFadeOut");
			StartCoroutine("DoFadeIn");
		}

		public void FadeOut()
		{
			if (!base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: true);
			}
			if (targetImg == null)
			{
				targetImg = GetComponent<Image>();
			}
			targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 1f);
			onFadeOut.Invoke();
			StopCoroutine("DoFadeIn");
			StopCoroutine("DoFadeOut");
			StartCoroutine("DoFadeOut");
		}

		private IEnumerator DoFadeIn()
		{
			Color startingPoint = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 0f);
			float elapsedTime = 0f;
			while (targetImg.color.a < 0.99f)
			{
				elapsedTime += Time.unscaledDeltaTime;
				targetImg.color = Color.Lerp(startingPoint, new Color(startingPoint.r, startingPoint.g, startingPoint.b, 1f), fadeCurve.Evaluate(elapsedTime * fadeSpeed));
				yield return null;
			}
			targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 1f);
			onFadeInEnd.Invoke();
			if (doPingPong)
			{
				StartCoroutine("DoFadeOut");
			}
		}

		private IEnumerator DoFadeOut()
		{
			Color startingPoint = targetImg.color;
			float elapsedTime = 0f;
			while (targetImg.color.a > 0.01f)
			{
				elapsedTime += Time.unscaledDeltaTime;
				targetImg.color = Color.Lerp(startingPoint, new Color(startingPoint.r, startingPoint.g, startingPoint.b, 0f), fadeCurve.Evaluate(elapsedTime * fadeSpeed));
				yield return null;
			}
			targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 0f);
			onFadeOutEnd.Invoke();
			base.gameObject.SetActive(value: false);
		}
	}
}
