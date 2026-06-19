using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CirclesAndArrowsAnimator : MonoBehaviour
	{
		[Serializable]
		public class Arrow
		{
			[SerializeField]
			public RectTransform ArrowRootTransform;

			[SerializeField]
			public Image ArrowShaft;

			[SerializeField]
			public Image ArrowHead;

			[SerializeField]
			public Vector2 ArrowAnimOffset;

			[NonSerialized]
			public Vector2 StartLocation;

			[NonSerialized]
			public Vector2 OffsetLocation;
		}

		[SerializeField]
		private List<Image> _circles = new List<Image>();

		[SerializeField]
		private List<Arrow> _arrows = new List<Arrow>();

		[SerializeField]
		private float _circleAnimationTime = 0.5f;

		[SerializeField]
		private float _arrowShaftAnimationTime = 0.12f;

		[SerializeField]
		private float _arrowHeadAnimationTime = 0.12f;

		[SerializeField]
		private float _arrowAnimToOffsetTime = 0.8f;

		[SerializeField]
		private float _arrowAnimBackToStartTime = 0.27f;

		[SerializeField]
		private float _pauseBeforeCircles = 0.5f;

		[SerializeField]
		private float _pauseBetweenCircles = 0.15f;

		[SerializeField]
		private float _pauseAfterCircles = 3f;

		[SerializeField]
		private float _pauseBetweenArrows = 0.15f;

		[SerializeField]
		private float _pauseAfterArrows = 0.5f;

		[SerializeField]
		private float _pauseBetweenArrowMovementAnims = 1.5f;

		[SerializeField]
		private bool _useLargeCircleSound = true;

		private string TutorialSmallCircle_AudioEvent = "SmallCircleDraw:Tutorial";

		private string TutorialLargeCircle_AudioEvent = "LargeCircleDraw:Tutorial";

		private string TutorialArrow_AudioEvent = "ArrowDraw:Tutorial";

		private Coroutine _coroutine;

		public void SetShowArrows(bool bSet)
		{
			foreach (Arrow arrow in _arrows)
			{
				arrow.ArrowRootTransform.gameObject.SetActive(bSet);
			}
		}

		protected void Start()
		{
			foreach (Arrow arrow in _arrows)
			{
				arrow.StartLocation = arrow.ArrowRootTransform.transform.localPosition;
				arrow.OffsetLocation = arrow.StartLocation + arrow.ArrowAnimOffset;
			}
		}

		protected void OnEnable()
		{
			if (_coroutine == null)
			{
				_coroutine = StartCoroutine(CirclesAndArrowsAnimationCoroutine());
			}
		}

		protected void OnDisable()
		{
			StopCoroutine(_coroutine);
			_coroutine = null;
		}

		protected IEnumerator CirclesAndArrowsAnimationCoroutine()
		{
			foreach (Image circle2 in _circles)
			{
				circle2.fillAmount = 0f;
			}
			foreach (Arrow arrow in _arrows)
			{
				arrow.ArrowHead.fillAmount = 0f;
				arrow.ArrowShaft.fillAmount = 0f;
			}
			yield return new WaitForSecondsRealtime(_pauseBeforeCircles);
			foreach (Image circle in _circles)
			{
				if (_circleAnimationTime <= 0f)
				{
					circle.fillAmount = 1f;
					yield return new WaitForSecondsRealtime(_pauseBetweenCircles);
					continue;
				}
				float elapsedTime = 0f;
				if (circle.gameObject.activeSelf)
				{
					if (_useLargeCircleSound)
					{
						AudioManager.Instance.Play(TutorialLargeCircle_AudioEvent);
					}
					else
					{
						AudioManager.Instance.Play(TutorialSmallCircle_AudioEvent);
					}
				}
				while (elapsedTime <= _circleAnimationTime)
				{
					elapsedTime += Time.unscaledDeltaTime;
					float p = elapsedTime / _circleAnimationTime;
					circle.fillAmount = EasingsUtils.CubicEaseInOut(p);
					yield return null;
				}
				circle.fillAmount = 1f;
				yield return new WaitForSecondsRealtime(_pauseBetweenCircles);
			}
			yield return new WaitForSecondsRealtime(_pauseAfterCircles);
			foreach (Arrow arrowItem in _arrows)
			{
				if (_arrowShaftAnimationTime <= 0f)
				{
					arrowItem.ArrowShaft.fillAmount = 1f;
				}
				else
				{
					if (arrowItem.ArrowShaft.gameObject.activeSelf)
					{
						AudioManager.Instance.Play(TutorialArrow_AudioEvent);
					}
					float elapsedTime = 0f;
					while (elapsedTime <= _arrowShaftAnimationTime)
					{
						elapsedTime += Time.unscaledDeltaTime;
						float p2 = elapsedTime / _arrowShaftAnimationTime;
						arrowItem.ArrowShaft.fillAmount = EasingsUtils.CubicEaseInOut(p2);
						yield return null;
					}
					arrowItem.ArrowShaft.fillAmount = 1f;
				}
				if (_arrowHeadAnimationTime <= 0f)
				{
					arrowItem.ArrowHead.fillAmount = 1f;
				}
				else
				{
					float elapsedTime = 0f;
					while (elapsedTime <= _arrowHeadAnimationTime)
					{
						elapsedTime += Time.unscaledDeltaTime;
						float p3 = elapsedTime / _arrowHeadAnimationTime;
						arrowItem.ArrowHead.fillAmount = EasingsUtils.CubicEaseInOut(p3);
						yield return null;
					}
					arrowItem.ArrowHead.fillAmount = 1f;
				}
				yield return new WaitForSecondsRealtime(_pauseBetweenArrows);
			}
			yield return new WaitForSecondsRealtime(_pauseAfterArrows);
			while (true)
			{
				float elapsedTime = 0f;
				while (elapsedTime <= _arrowAnimToOffsetTime)
				{
					elapsedTime += Time.unscaledDeltaTime;
					float p4 = elapsedTime / _arrowAnimToOffsetTime;
					foreach (Arrow arrow2 in _arrows)
					{
						arrow2.ArrowRootTransform.localPosition = Vector2.Lerp(arrow2.StartLocation, arrow2.OffsetLocation, EasingsUtils.CubicEaseInOut(p4));
					}
					yield return null;
				}
				elapsedTime = 0f;
				while (elapsedTime <= _arrowAnimBackToStartTime)
				{
					elapsedTime += Time.unscaledDeltaTime;
					float p5 = elapsedTime / _arrowAnimBackToStartTime;
					foreach (Arrow arrow3 in _arrows)
					{
						arrow3.ArrowRootTransform.localPosition = Vector2.Lerp(arrow3.OffsetLocation, arrow3.StartLocation, EasingsUtils.CubicEaseInOut(p5));
					}
					yield return null;
				}
				yield return new WaitForSecondsRealtime(_pauseBetweenArrowMovementAnims);
			}
		}
	}
}
