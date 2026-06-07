using System;
using UnityEngine;
using UnityEngine.Events;

namespace DG.Tweening.Timeline.Core
{
	[Serializable]
	public abstract class DOTweenClipBase
	{
		internal class SettingsSnapshot
		{
			public bool invert;

			public StartupBehaviour startupBehaviour;

			public float startupDelay;

			public bool autoplay;

			public bool autokill;

			public bool ignoreTimeScale;

			public TimeMode timeMode;

			public float timeScale;

			public float durationOverload;

			public int loops;

			public LoopType loopType;

			public bool hasOnRewind;

			public bool hasOnComplete;

			public bool hasOnStepComplete;

			public bool hasOnUpdate;

			public UnityEvent onRewind;

			public UnityEvent onComplete;

			public UnityEvent onStepComplete;

			public UnityEvent onUpdate;

			public SettingsSnapshot Refresh(DOTweenClipBase clipBase, StartupBehaviour? startupBehaviourOverride = null, bool? autoplayOverride = null, bool? invertOverride = null)
			{
				return null;
			}
		}

		[SerializeField]
		protected string _guid;

		public bool invert;

		public StartupBehaviour startupBehaviour;

		public float startupDelay;

		public bool autoplay;

		public bool autokill;

		public bool ignoreTimeScale;

		public TimeMode timeMode;

		public float timeScale;

		public float durationOverload;

		public int loops;

		public LoopType loopType;

		public bool hasOnRewind;

		public bool hasOnComplete;

		public bool hasOnStepComplete;

		public bool hasOnUpdate;

		public UnityEvent onRewind;

		public UnityEvent onComplete;

		public UnityEvent onStepComplete;

		public UnityEvent onUpdate;

		internal static readonly SettingsSnapshot TmpSettingsSnapshot;

		public string guid => null;

		public Sequence tween { get; protected set; }

		public abstract Sequence Play(bool restartIfExists = true);

		public abstract Sequence GenerateTween(StartupBehaviour? behaviour = null, bool? andPlay = null, bool rewindIfExists = true);

		public abstract Sequence ForceGenerateTween(bool rewindIfExists = true, StartupBehaviour? behaviour = null, bool? andPlay = null);

		public void KillTween(bool complete = false)
		{
		}

		public void RewindTween(bool includeDelay = true)
		{
		}

		public void CompleteTween(bool withCallbacks = false)
		{
		}

		public void RestartTween(bool includeDelay = true, float changeDelayTo = -1f)
		{
		}

		public virtual void RestartTweenFromHere(bool includeDelay = true, float changeDelayTo = -1f)
		{
		}

		public void PauseTween()
		{
		}

		public void PlayTween()
		{
		}

		public void PlayTweenBackwards()
		{
		}

		public void PlayTweenForward()
		{
		}

		public bool HasTween()
		{
			return false;
		}

		public bool IsTweenComplete()
		{
			return false;
		}

		public bool IsTweenPlaying()
		{
			return false;
		}
	}
}
