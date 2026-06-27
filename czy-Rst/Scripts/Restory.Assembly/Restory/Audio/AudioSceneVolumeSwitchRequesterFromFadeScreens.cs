using System;
using System.Collections;
using Restory.Infrastructure.ProjectServices;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class AudioSceneVolumeSwitchRequesterFromFadeScreens : IInitializable, IDisposable
	{
		private readonly ICoroutineRunner coroutineRunner;

		private readonly GUI_FadeScreens fadeScreens;

		private readonly AudioSceneVolumeSwitcher volumeSwitcher;

		private Coroutine fadeScreensTrackingCoroutine;

		public AudioSceneVolumeSwitchRequesterFromFadeScreens(AudioSceneVolumeSwitcher volumeSwitcher, ICoroutineRunner coroutineRunner, GUI_FadeScreens fadeScreens)
		{
			this.volumeSwitcher = volumeSwitcher;
			this.coroutineRunner = coroutineRunner;
			this.fadeScreens = fadeScreens;
		}

		public void Initialize()
		{
			fadeScreens.OnFadeInStarted += ResolveFadeInStarted;
			fadeScreens.OnFadeOutEnded += ResolveFadeOutEnded;
		}

		public void Dispose()
		{
			if (fadeScreens.MonoShellExists())
			{
				fadeScreens.OnFadeInStarted -= ResolveFadeInStarted;
				fadeScreens.OnFadeOutEnded -= ResolveFadeOutEnded;
			}
		}

		private void ResolveFadeInStarted()
		{
			if (fadeScreensTrackingCoroutine == null)
			{
				fadeScreensTrackingCoroutine = coroutineRunner.Run(FadeScreensTrackingCoroutine());
			}
		}

		private void ResolveFadeOutEnded()
		{
			if (fadeScreensTrackingCoroutine != null)
			{
				coroutineRunner.Stop(fadeScreensTrackingCoroutine);
				fadeScreensTrackingCoroutine = null;
			}
			volumeSwitcher.RequestVolumeChange(1f);
		}

		private IEnumerator FadeScreensTrackingCoroutine()
		{
			yield return null;
			while (fadeScreens.IsAnyFadeScreenOn)
			{
				volumeSwitcher.RequestVolumeChange(1f - fadeScreens.CurrentMostVisibleFadeScreenAlpha);
				yield return null;
			}
			fadeScreensTrackingCoroutine = null;
		}
	}
}
