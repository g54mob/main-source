using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Restory.SimpleTweeners
{
	public abstract class SimpleTweenerBase : MonoBehaviour
	{
		[Serializable]
		public class Events
		{
			public UnityEvent OnBegin = new UnityEvent();

			public UnityEvent OnComplete = new UnityEvent();
		}

		[Header("General settings")]
		[SerializeField]
		[Min(0f)]
		private float delay;

		[SerializeField]
		protected float duration = 1f;

		[SerializeField]
		protected Ease ease = Ease.Linear;

		[SerializeField]
		protected Events events = new Events();

		protected float timeScale = 1f;

		protected Sequence Sequence;

		private TweenSequencesService tweenSequences;

		public abstract float Progress { get; set; }

		public float TimeScale
		{
			get
			{
				return timeScale;
			}
			set
			{
				timeScale = value;
				if (Sequence != null)
				{
					Sequence.timeScale = timeScale;
				}
			}
		}

		public Events TweenEvents
		{
			get
			{
				return events;
			}
			set
			{
				events = value;
			}
		}

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void Awake()
		{
			CacheInitialState();
		}

		protected abstract void CacheInitialState();

		public abstract void Play();

		public abstract void PlayImmediately();

		public void Stop()
		{
			Sequence.Kill();
		}

		public abstract void RevertState();

		protected Sequence InitSequence()
		{
			if (Sequence != null)
			{
				Sequence.Kill();
			}
			Sequence = tweenSequences.Create();
			Sequence.timeScale = timeScale;
			Sequence.OnStart(delegate
			{
				events.OnBegin.Invoke();
			});
			Sequence.OnComplete(delegate
			{
				events.OnComplete.Invoke();
			});
			if (delay > 0f)
			{
				Sequence.AppendInterval(delay);
			}
			return Sequence;
		}
	}
}
