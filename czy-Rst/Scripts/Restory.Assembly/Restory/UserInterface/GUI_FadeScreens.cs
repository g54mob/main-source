using System;
using UnityEngine;

namespace Restory.UserInterface
{
	public class GUI_FadeScreens : MonoBehaviour
	{
		private bool isDefaultFadeScreenAnimationInProgress;

		private bool isblackScreenAnimationInProgress;

		[SerializeField]
		private GUI_FadeScreen defaultFadeScreen;

		[SerializeField]
		private GUI_FadeScreen blackScreen;

		private int screensAwaitingFullFadeOut;

		public bool IsAnyFadeScreenOn
		{
			get
			{
				if (defaultFadeScreen.IsFullyTransparent)
				{
					return !blackScreen.IsFullyTransparent;
				}
				return true;
			}
		}

		public float CurrentMostVisibleFadeScreenAlpha
		{
			get
			{
				if (!(defaultFadeScreen.CurrentAlpha > blackScreen.CurrentAlpha))
				{
					return blackScreen.CurrentAlpha;
				}
				return defaultFadeScreen.CurrentAlpha;
			}
		}

		public event Action OnFadeInStarted;

		public event Action OnFadeOutEnded;

		public void PreInit()
		{
			defaultFadeScreen.gameObject.SetActive(value: false);
			blackScreen.gameObject.SetActive(value: false);
		}

		public void FadeInDefaultScreen(float duration = -1f, Action onStart = null, Action onFinish = null)
		{
			onStart = (Action)Delegate.Combine(onStart, (Action)delegate
			{
				this.OnFadeInStarted?.Invoke();
				Debug.Log("Default FadeIn Started");
			});
			defaultFadeScreen.FadeIn(duration, 0f, onStart, onFinish);
		}

		public void FadeInBlackScreen(float duration = -1f, Action onStart = null, Action onFinish = null)
		{
			onStart = (Action)Delegate.Combine(onStart, (Action)delegate
			{
				this.OnFadeInStarted?.Invoke();
				Debug.Log("Black Screen started fadin' in");
			});
			blackScreen.FadeIn(duration, 0f, onStart, onFinish);
		}

		public void FadeOut(float duration = -1f)
		{
			screensAwaitingFullFadeOut = 2;
			blackScreen.FadeOut(duration, -1f, null, ProcessScreenFadeOutEnded);
			defaultFadeScreen.FadeOut(duration, -1f, null, ProcessScreenFadeOutEnded);
		}

		private void ProcessScreenFadeOutEnded()
		{
			screensAwaitingFullFadeOut--;
			if (screensAwaitingFullFadeOut <= 0)
			{
				this.OnFadeOutEnded?.Invoke();
				Debug.Log("FadeOuts completed");
			}
		}
	}
}
