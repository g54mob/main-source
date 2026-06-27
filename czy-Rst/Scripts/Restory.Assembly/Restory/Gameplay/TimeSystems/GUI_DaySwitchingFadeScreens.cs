using System;
using Restory.UserInterface;
using TMPro;
using UnityEngine;

namespace Restory.Gameplay.TimeSystems
{
	public class GUI_DaySwitchingFadeScreens : MonoBehaviour
	{
		[SerializeField]
		private GUI_FadeScreen dayEndFadeScreen;

		[SerializeField]
		private GUI_FadeScreen nextDayStartFadeScreen;

		[SerializeField]
		private TextMeshProUGUI nextDayIndexText;

		public bool IsAnyFadeScreenOn
		{
			get
			{
				if (dayEndFadeScreen.IsFullyTransparent)
				{
					return !nextDayStartFadeScreen.IsFullyTransparent;
				}
				return true;
			}
		}

		public float CurrentMostVisibleFadeScreenAlpha
		{
			get
			{
				if (!(dayEndFadeScreen.CurrentAlpha > nextDayStartFadeScreen.CurrentAlpha))
				{
					return nextDayStartFadeScreen.CurrentAlpha;
				}
				return dayEndFadeScreen.CurrentAlpha;
			}
		}

		public event Action OnFadeInStarted;

		public event Action OnFadeOutEnded;

		public void FadeInCurrentDayEndScreen(float duration, Action onStart = null, Action onFinish = null)
		{
			dayEndFadeScreen.FadeIn(duration, 0f, onStart, onFinish);
		}

		public void FadeOutCurrentDayEndScreen(float duration, Action onStart = null, Action onFinish = null)
		{
			dayEndFadeScreen.FadeOut(duration, 1f, onStart, onFinish);
		}

		public void FadeInNextDayStartScreen(int nextDayIndex, float duration, Action onStart = null, Action onFinish = null)
		{
			nextDayIndexText.text = nextDayIndex.ToString();
			nextDayStartFadeScreen.FadeIn(duration, 0f, onStart, onFinish);
		}

		public void FadeOutNextDayStartScreen(float duration, Action onStart = null, Action onFinish = null)
		{
			nextDayStartFadeScreen.FadeOut(duration, 1f, onStart, onFinish);
		}
	}
}
