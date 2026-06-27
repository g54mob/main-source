using System;
using DG.Tweening;
using Restory.Data.SaveLoad;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public sealed class GUI_FadeScreen : MonoBehaviour
	{
		[Header("General settings")]
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float defaultDuration = 2f;

		private Sequence mainSequence;

		private TweenSequencesService tweenSequencesService;

		public float CurrentAlpha => canvasGroup.alpha;

		public bool IsFullyTransparent
		{
			get
			{
				if (!mainSequence.IsActive() || mainSequence.IsComplete())
				{
					return canvasGroup.alpha <= 0f;
				}
				return false;
			}
		}

		public event Action OnFadeInStarted;

		public event Action OnFadeOutEnded;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		private void OnDestroy()
		{
			if (tweenSequencesService != null)
			{
				tweenSequencesService.Kill(mainSequence);
			}
			mainSequence = null;
		}

		public void FadeIn(float duration = -1f, float startAlpha = -1f, Action onStart = null, Action onFinish = null)
		{
			OnConcurrentTasksStarted();
			if (duration <= 0f)
			{
				duration = defaultDuration;
			}
			if (mainSequence.IsActive())
			{
				mainSequence.Kill();
			}
			if (canvasGroup.alpha < 1f)
			{
				mainSequence = tweenSequencesService.Create();
				mainSequence.SetUpdate(isIndependentUpdate: true);
				mainSequence.OnStart(delegate
				{
					if (startAlpha >= 0f)
					{
						canvasGroup.alpha = startAlpha;
					}
					canvasGroup.blocksRaycasts = true;
					base.gameObject.SetActive(value: true);
					onStart?.Invoke();
					this.OnFadeInStarted?.Invoke();
				});
				mainSequence.Append(canvasGroup.DOFade(1f, duration));
				mainSequence.OnComplete(delegate
				{
					onFinish?.Invoke();
				});
				mainSequence.Play();
			}
			else
			{
				this.OnFadeInStarted?.Invoke();
				onFinish?.Invoke();
			}
			Debug.Log(string.Format("[{0}] FadeIn in process. TimeScale: {1}", "GUI_FadeScreen", Time.timeScale), base.gameObject);
		}

		public void FadeOut(float duration = -1f, float startAlpha = -1f, Action onStart = null, Action onFinish = null)
		{
			if (duration <= 0f)
			{
				duration = defaultDuration;
			}
			if (mainSequence.IsActive())
			{
				mainSequence.Kill();
			}
			if (canvasGroup.alpha > 0f)
			{
				mainSequence = tweenSequencesService.Create();
				mainSequence.SetUpdate(isIndependentUpdate: true);
				mainSequence.OnStart(delegate
				{
					if (startAlpha >= 0f)
					{
						canvasGroup.alpha = startAlpha;
					}
					canvasGroup.blocksRaycasts = false;
					base.gameObject.SetActive(value: true);
					onStart?.Invoke();
				});
				mainSequence.Append(canvasGroup.DOFade(0f, duration));
				mainSequence.OnComplete(delegate
				{
					base.gameObject.SetActive(value: false);
					onFinish?.Invoke();
					this.OnFadeOutEnded?.Invoke();
					OnConcurrentTasksFinished();
				});
				mainSequence.Play();
			}
			else
			{
				onFinish?.Invoke();
				this.OnFadeOutEnded?.Invoke();
				OnConcurrentTasksFinished();
			}
			Debug.Log(string.Format("[{0}] FadeOut in process. TimeScale: {1}", "GUI_FadeScreen", Time.timeScale), base.gameObject);
		}

		private static void OnConcurrentTasksStarted()
		{
			RunInBackgroundSolver.OnConcurrentTasksStarted();
		}

		private static void OnConcurrentTasksFinished()
		{
			RunInBackgroundSolver.OnConcurrentTasksFinished();
		}
	}
}
