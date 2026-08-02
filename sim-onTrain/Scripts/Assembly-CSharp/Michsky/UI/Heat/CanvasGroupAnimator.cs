using System.Collections;
using UnityEngine;

namespace Michsky.UI.Heat
{
	[AddComponentMenu("Heat UI/Animation/Canvas Group Animator")]
	public class CanvasGroupAnimator : MonoBehaviour
	{
		public enum StartBehaviour
		{
			Default = 0,
			FadeIn = 1,
			FadeOut = 2
		}

		[Header("Resources")]
		[SerializeField]
		private CanvasGroup canvasGroup;

		[Header("Settings")]
		[Tooltip("Enable or disable the object after the animation.")]
		[SerializeField]
		private bool setActive = true;

		[Range(0.5f, 10f)]
		public float fadeSpeed = 4f;

		[SerializeField]
		private StartBehaviour startBehaviour;

		private void Start()
		{
			if (canvasGroup == null)
			{
				canvasGroup = GetComponent<CanvasGroup>();
			}
			if (startBehaviour == StartBehaviour.FadeIn)
			{
				FadeIn();
			}
			else if (startBehaviour == StartBehaviour.FadeOut)
			{
				FadeOut();
			}
		}

		public void FadeIn()
		{
			canvasGroup.gameObject.SetActive(value: true);
			StopCoroutine("FadeOutHelper");
			StopCoroutine("FadeInHelper");
			StartCoroutine("FadeInHelper");
		}

		public void FadeOut()
		{
			canvasGroup.gameObject.SetActive(value: true);
			StopCoroutine("FadeInHelper");
			StopCoroutine("FadeOutHelper");
			StartCoroutine("FadeOutHelper");
		}

		private IEnumerator FadeInHelper()
		{
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
			while ((double)canvasGroup.alpha < 0.99)
			{
				canvasGroup.alpha += fadeSpeed * Time.unscaledDeltaTime;
				yield return null;
			}
			canvasGroup.alpha = 1f;
		}

		private IEnumerator FadeOutHelper()
		{
			canvasGroup.alpha = 1f;
			while ((double)canvasGroup.alpha > 0.01)
			{
				canvasGroup.alpha -= fadeSpeed * Time.unscaledDeltaTime;
				yield return null;
			}
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
			if (setActive)
			{
				canvasGroup.gameObject.SetActive(value: false);
			}
		}
	}
}
