using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class CreditsScreen : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect _scrollRect;

		public Transform CreditSectionContainer;

		[SerializeField]
		private float PassiveScrollSpeed = 0.01f;

		[SerializeField]
		private float PassiveScrollDelay = 1f;

		[SerializeField]
		private float ScrollResetDuration = 0.1f;

		private float _scrollProgress;

		private float _timerBeforeScrolling;

		private float _scrollProgressAtTransitionOut;

		public void OnInteractionToggled(bool toggle)
		{
			if (base.gameObject.activeInHierarchy)
			{
				if (toggle)
				{
					TransitionIn();
				}
				else
				{
					TransitionOut();
				}
			}
		}

		private void TransitionIn()
		{
			_scrollProgress = 0f;
			_timerBeforeScrolling = PassiveScrollDelay;
			_scrollRect.verticalNormalizedPosition = 1f;
			StopAllCoroutines();
		}

		private void TransitionOut()
		{
			StopAutoScroll();
			_scrollProgressAtTransitionOut = _scrollRect.verticalNormalizedPosition;
			StartCoroutine(ScrollBackToStart());
		}

		private void StopAutoScroll()
		{
			_scrollProgress = -1f;
		}

		public void Update()
		{
			if (_scrollProgress < 1f && _scrollProgress >= 0f)
			{
				if (_timerBeforeScrolling > 0f)
				{
					_timerBeforeScrolling -= Time.deltaTime;
					return;
				}
				_scrollRect.verticalNormalizedPosition = 1f - _scrollProgress;
				_scrollProgress += Time.deltaTime * PassiveScrollSpeed;
			}
		}

		private IEnumerator ScrollBackToStart()
		{
			for (float time = 0f; time < ScrollResetDuration; time += Time.deltaTime)
			{
				yield return new WaitForEndOfFrame();
				_scrollRect.verticalNormalizedPosition = Mathf.Lerp(_scrollProgressAtTransitionOut, 1f, time / ScrollResetDuration);
			}
		}

		public void OnScrollStart()
		{
			StopAutoScroll();
		}
	}
}
