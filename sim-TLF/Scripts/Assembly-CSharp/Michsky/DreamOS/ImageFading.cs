using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[RequireComponent(typeof(Image))]
	[AddComponentMenu("DreamOS/Animation/Image Fading")]
	public class ImageFading : MonoBehaviour
	{
		public enum EnableBehaviour
		{
			None = 0,
			FadeIn = 1,
			FadeOut = 2
		}

		[Header("Settings")]
		public bool doPingPong;

		public bool frameSkip;

		[Range(0.5f, 12f)]
		public float fadeSpeed = 2f;

		[SerializeField]
		private AnimationCurve fadeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[SerializeField]
		private EnableBehaviour enableBehaviour;

		[Header("Events")]
		public UnityEvent onFadeIn = new UnityEvent();

		public UnityEvent onFadeInEnd = new UnityEvent();

		public UnityEvent onFadeOut = new UnityEvent();

		public UnityEvent onFadeOutEnd = new UnityEvent();

		private float frameDelay = 0.04f;

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
			if (!frameSkip)
			{
				StopCoroutine("DoFadeIn");
				StartCoroutine("DoFadeIn");
			}
			else
			{
				StopCoroutine("DoFadeInFrameSkip");
				StartCoroutine("DoFadeInFrameSkip");
			}
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
			if (!frameSkip)
			{
				StopCoroutine("DoFadeOut");
				StartCoroutine("DoFadeOut");
			}
			else
			{
				StopCoroutine("DoFadeOutFrameSkip");
				StartCoroutine("DoFadeOutFrameSkip");
			}
		}

		private IEnumerator DoFadeIn()
		{
			StopCoroutine("DoFadeOut");
			Color startingPoint = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 0f);
			float elapsedTime = 0f;
			while (targetImg.color.a < 0.99f)
			{
				elapsedTime += Time.deltaTime;
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
			StopCoroutine("DoFadeIn");
			Color startingPoint = targetImg.color;
			float elapsedTime = 0f;
			while (targetImg.color.a > 0.01f)
			{
				elapsedTime += Time.deltaTime;
				targetImg.color = Color.Lerp(startingPoint, new Color(startingPoint.r, startingPoint.g, startingPoint.b, 0f), fadeCurve.Evaluate(elapsedTime * fadeSpeed));
				yield return null;
			}
			targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 0f);
			onFadeOutEnd.Invoke();
			base.gameObject.SetActive(value: false);
		}

		private IEnumerator DoFadeInFrameSkip()
		{
			StopCoroutine("DoFadeOutFrameSkip");
			float startingAlpha = targetImg.color.a;
			yield return new WaitForSeconds(frameDelay);
			if (targetImg.color.a < 0.99f)
			{
				targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, startingAlpha + 0.08f);
				StartCoroutine("DoFadeInFrameSkip");
				yield break;
			}
			targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 1f);
			onFadeInEnd.Invoke();
			if (doPingPong)
			{
				StartCoroutine("DoFadeOutFrameSkip");
			}
		}

		private IEnumerator DoFadeOutFrameSkip()
		{
			StopCoroutine("DoFadeInFrameSkip");
			float startingAlpha = targetImg.color.a;
			yield return new WaitForSeconds(frameDelay);
			if (targetImg.color.a < 0.99f)
			{
				targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, startingAlpha - 0.08f);
				StartCoroutine("DoFadeInFrameSkip");
			}
			else
			{
				targetImg.color = new Color(targetImg.color.r, targetImg.color.g, targetImg.color.b, 0f);
				onFadeOutEnd.Invoke();
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
