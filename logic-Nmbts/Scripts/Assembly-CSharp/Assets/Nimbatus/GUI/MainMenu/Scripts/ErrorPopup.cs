using System;
using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ErrorPopup : MonoBehaviour
	{
		public UILabel Label;

		public TweenPosition Tween;

		private Action _retryAction;

		public void Show(string error, Action retryAction)
		{
			Label.text = error;
			_retryAction = retryAction;
			Tween.PlayForward();
		}

		public void Retry()
		{
			Tween.PlayReverse();
			StartCoroutine(InvokeRetry());
		}

		private IEnumerator InvokeRetry()
		{
			yield return new WaitForSeconds(0.5f);
			Action retryAction = _retryAction;
			if (retryAction != null)
			{
				retryAction();
			}
		}

		public void Cancel()
		{
			Tween.PlayReverse();
		}

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Cancel();
			}
		}
	}
}
