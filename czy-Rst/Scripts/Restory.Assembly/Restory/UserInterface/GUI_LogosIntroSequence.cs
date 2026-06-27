using System;
using System.Collections.Generic;
using DG.Tweening;
using RSG;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_LogosIntroSequence : MonoBehaviour
	{
		[Serializable]
		private class LogoAnimationEntry
		{
			public CanvasGroup CanvasGroup;

			public float DelayBeforeShowing;

			public float FadeInDuration;

			public float ShowDuration;

			public float FadeOutDuration;

			public float DelayAfterShowing;
		}

		[SerializeField]
		private Ease logosFadeInEase = Ease.Linear;

		[SerializeField]
		private Ease logosFadeOutEase = Ease.Linear;

		[SerializeField]
		private LogoAnimationEntry[] logoAnimationEntries = Array.Empty<LogoAnimationEntry>();

		[SerializeField]
		private CanvasGroup allLogosParentCanvasGroup;

		[SerializeField]
		private float fadeOutDurationWhenSkipped = 1f;

		private TweenSequencesService tweenSequencesService;

		private Sequence currentLogoSequence;

		private Sequence auxiliarySequence;

		private Promise currentSequenceEndedPromise;

		private readonly Queue<Sequence> sequencesQueue = new Queue<Sequence>();

		public event Action OnSequenceEnded = delegate
		{
		};

		private void Awake()
		{
			LogoAnimationEntry[] array = logoAnimationEntries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].CanvasGroup.alpha = 0f;
			}
			allLogosParentCanvasGroup.alpha = 1f;
		}

		private void OnDisable()
		{
			if (currentLogoSequence.IsActive())
			{
				currentLogoSequence.Kill();
			}
			if (auxiliarySequence.IsActive())
			{
				auxiliarySequence.Kill();
			}
			PromiseState? promiseState = currentSequenceEndedPromise?.CurState;
			if (promiseState.HasValue && promiseState.GetValueOrDefault() == PromiseState.Pending)
			{
				currentSequenceEndedPromise.Reject(new Exception("Intro sequence promise rejected, because GUI got disabled."));
			}
		}

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		public void StartSequence()
		{
			PrepareSequences();
			Step();
		}

		public void SkipCurrentLogo()
		{
			if (!currentLogoSequence.IsActive())
			{
				return;
			}
			currentLogoSequence.Kill();
			auxiliarySequence = tweenSequencesService.Create();
			auxiliarySequence.Append(allLogosParentCanvasGroup.DOFade(0f, fadeOutDurationWhenSkipped)).AppendCallback(delegate
			{
				LogoAnimationEntry[] array = logoAnimationEntries;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CanvasGroup.alpha = 0f;
				}
				allLogosParentCanvasGroup.alpha = 1f;
			}).OnComplete(currentSequenceEndedPromise.Resolve);
		}

		public void SkipWholeSequence()
		{
			if (currentLogoSequence.IsActive())
			{
				currentLogoSequence.Kill();
				auxiliarySequence = tweenSequencesService.Create();
				auxiliarySequence.Append(allLogosParentCanvasGroup.DOFade(0f, fadeOutDurationWhenSkipped));
				auxiliarySequence.OnComplete(TriggerSequenceEnd);
				PromiseState? promiseState = currentSequenceEndedPromise?.CurState;
				if (promiseState.HasValue && promiseState.GetValueOrDefault() == PromiseState.Pending)
				{
					currentSequenceEndedPromise.Reject(new Exception("Intro sequence promise rejected, because intro was skipped."));
				}
			}
		}

		private void PrepareSequences()
		{
			LogoAnimationEntry[] array = logoAnimationEntries;
			foreach (LogoAnimationEntry entry in array)
			{
				Sequence sequence = tweenSequencesService.Create();
				AppendLogoAnimationToSequence(entry, sequence);
				sequence.OnComplete(delegate
				{
					currentSequenceEndedPromise?.Resolve();
				});
				sequence.Pause();
				sequencesQueue.Enqueue(sequence);
			}
		}

		private void Step()
		{
			if (sequencesQueue.Count > 0)
			{
				RunNextSequence(sequencesQueue.Dequeue());
			}
			else
			{
				TriggerSequenceEnd();
			}
		}

		private void RunNextSequence(Sequence sequence)
		{
			currentLogoSequence = sequence;
			currentSequenceEndedPromise = new Promise();
			currentSequenceEndedPromise.Then((Action)Step).Done();
			sequence.Play();
		}

		private void TriggerSequenceEnd()
		{
			this.OnSequenceEnded();
		}

		private void AppendLogoAnimationToSequence(LogoAnimationEntry entry, Sequence targetSequence)
		{
			targetSequence.AppendInterval(entry.DelayBeforeShowing).Append(entry.CanvasGroup.DOFade(1f, entry.FadeInDuration).SetEase(logosFadeInEase)).AppendInterval(entry.ShowDuration)
				.Append(entry.CanvasGroup.DOFade(0f, entry.FadeOutDuration).SetEase(logosFadeOutEase))
				.AppendCallback(delegate
				{
					entry.CanvasGroup.alpha = 0f;
				})
				.AppendInterval(entry.DelayAfterShowing);
		}
	}
}
