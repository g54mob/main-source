using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class VictoryScreen_StarsAnimation : MonoBehaviour
	{
		[Serializable]
		private struct StarsStruc
		{
			public GameObject StarParent;

			public Image StarImage;
		}

		[SerializeField]
		private List<StarsStruc> _starsList;

		[SerializeField]
		private float _sizeStars;

		[SerializeField]
		private float _animationDuration = 2f;

		[SerializeField]
		private float _delayBetweenStars = 0.5f;

		[SerializeField]
		private AnimationCurve _scaleCurve;

		[Header("Debug Settings")]
		[SerializeField]
		private float _fillRestDebug = 3f;

		[SerializeField]
		private float _fillByImageDebug = 1f;

		private float _fillRest;

		private float _fillByImage;

		public void SetUp(float fillRest, float fillbyimage)
		{
			_fillRest = fillRest;
			_fillByImage = fillbyimage;
		}

		private void ResetStars()
		{
			foreach (StarsStruc stars in _starsList)
			{
				stars.StarImage.fillAmount = 0f;
				stars.StarParent.transform.localScale = Vector3.one;
			}
		}

		public void LaunchAnim()
		{
			StartStarsAnimation(_fillByImage, _fillRest);
		}

		public void StartStarsAnimation(float fillPerImage, float fillRest)
		{
			ResetStars();
			StartCoroutine(StarsAnimation(fillPerImage, fillRest));
		}

		private IEnumerator StarsAnimation(float fillPerImage, float fillRest)
		{
			yield return new WaitForSecondsRealtime(0.5f);
			foreach (StarsStruc stars in _starsList)
			{
				float num = Mathf.Min(fillPerImage, fillRest);
				if (num <= 0f)
				{
					break;
				}
				fillRest -= num;
				yield return StartCoroutine(AnimateStar(stars));
				yield return new WaitForSecondsRealtime(_delayBetweenStars);
			}
		}

		private IEnumerator AnimateStar(StarsStruc star)
		{
			float elapsedTime = 0f;
			Vector3 originalScale = star.StarParent.transform.localScale;
			Vector3 targetScale = originalScale * _sizeStars;
			while (elapsedTime < _animationDuration)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float num = elapsedTime / _animationDuration;
				float t = _scaleCurve.Evaluate(num);
				star.StarParent.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
				if (num >= 0.5f)
				{
					star.StarImage.fillAmount = 1f;
				}
				yield return null;
			}
			star.StarParent.transform.localScale = originalScale;
		}

		[Button("Start Debug Animation", EButtonEnableMode.Always)]
		public void StartDebugAnimation()
		{
			ResetStars();
			StartStarsAnimation(_fillByImageDebug, _fillRestDebug);
		}
	}
}
