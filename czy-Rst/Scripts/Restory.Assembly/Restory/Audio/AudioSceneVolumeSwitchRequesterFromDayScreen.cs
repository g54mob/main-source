using System;
using System.Collections;
using Restory.Gameplay.DayStartScreen;
using Restory.Infrastructure.ProjectServices;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class AudioSceneVolumeSwitchRequesterFromDayScreen : IInitializable, IDisposable
	{
		private readonly ICoroutineRunner coroutineRunner;

		private readonly AudioSceneVolumeSwitcher volumeSwitcher;

		private readonly DayScreenWorkService dayScreenWorkService;

		private Coroutine dayScreenTrackingCoroutine;

		public AudioSceneVolumeSwitchRequesterFromDayScreen(ICoroutineRunner coroutineRunner, AudioSceneVolumeSwitcher volumeSwitcher, DayScreenWorkService dayScreenWorkService)
		{
			this.dayScreenWorkService = dayScreenWorkService;
			this.volumeSwitcher = volumeSwitcher;
			this.coroutineRunner = coroutineRunner;
		}

		public void Initialize()
		{
			dayScreenWorkService.OnTransitionStarted += ResolveFadeInStarted;
			dayScreenWorkService.OnTransitionEndedAndScreenFullyHidden += ResolveFadeOutEnded;
		}

		public void Dispose()
		{
			if (dayScreenWorkService != null)
			{
				dayScreenWorkService.OnTransitionStarted -= ResolveFadeInStarted;
				dayScreenWorkService.OnTransitionEndedAndScreenFullyHidden -= ResolveFadeOutEnded;
			}
		}

		private void ResolveFadeInStarted()
		{
			if (dayScreenTrackingCoroutine == null)
			{
				dayScreenTrackingCoroutine = coroutineRunner.Run(DayScreenTrackingCoroutine());
			}
		}

		private void ResolveFadeOutEnded()
		{
			if (dayScreenTrackingCoroutine != null)
			{
				coroutineRunner.Stop(dayScreenTrackingCoroutine);
				dayScreenTrackingCoroutine = null;
			}
			volumeSwitcher.RequestVolumeChange(1f);
		}

		private IEnumerator DayScreenTrackingCoroutine()
		{
			yield return null;
			while (dayScreenWorkService.IsDayScreenActive)
			{
				volumeSwitcher.RequestVolumeChange(1f - dayScreenWorkService.DayScreenCurrentVisibility);
				yield return null;
			}
			dayScreenTrackingCoroutine = null;
		}
	}
}
