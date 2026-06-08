using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

namespace Dorfromantik
{
	public class SplashScreenManager : Singleton<SplashScreenManager>
	{
		[Serializable]
		public class LogoAnimation
		{
			public CanvasGroup logoObject;

			public float appearDuration;

			public float stayDuration;

			public float disappearDuration;

			public float endDelay;

			public float targetScale;

			public AnimationCurve scaleCurve;
		}

		[SerializeField]
		private List<LogoAnimation> logos;

		[SerializeField]
		private SceneLoader sceneLoader;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private CanvasGroup background;

		[SerializeField]
		private float backgroundDisappearDuration;

		private Sequence startupSequence;

		private Touchscreen touchScreen;

		private List<UnityEngine.InputSystem.InputDevice> disabledDevices;

		private void Start()
		{
			inputRouter.SetIsSplashScreenActive(splashScreenActive: true);
			sceneLoader.OnSceneLoaded += ShowSplashScreenAnimation;
			sceneLoader.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
		}

		private void ShowSplashScreenAnimation(Scene obj)
		{
			startupSequence = DOTween.Sequence();
			foreach (LogoAnimation logo in logos)
			{
				TweenExtensions.Duration(startupSequence);
				TweenSettingsExtensions.Append(startupSequence, DOTweenModuleUI.DOFade(logo.logoObject, 1f, logo.appearDuration));
				TweenSettingsExtensions.AppendInterval(startupSequence, logo.stayDuration);
				TweenSettingsExtensions.Append(startupSequence, DOTweenModuleUI.DOFade(logo.logoObject, 0f, logo.appearDuration));
				TweenSettingsExtensions.AppendInterval(startupSequence, logo.endDelay);
			}
			TweenSettingsExtensions.Append(startupSequence, DOTweenModuleUI.DOFade(background, 0f, backgroundDisappearDuration));
			TweenSettingsExtensions.AppendCallback(startupSequence, SplashScreenFinished);
			sceneLoader.OnSceneLoaded -= ShowSplashScreenAnimation;
			EventSystem.current.GetComponent<InputSystemUIInputModule>().enabled = false;
		}

		private void SplashScreenFinished()
		{
			EventSystem.current.GetComponent<InputSystemUIInputModule>().enabled = true;
			inputRouter.SetIsSplashScreenActive(splashScreenActive: false);
			UnityEngine.Object.Destroy(background.gameObject);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private new void OnDestroy()
		{
			base.OnDestroy();
			sceneLoader.OnSceneLoaded -= ShowSplashScreenAnimation;
		}
	}
}
