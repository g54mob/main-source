using UnityEngine;

namespace DG.Tweening.Timeline.Core
{
	public abstract class DOTweenClipComponentBase : MonoBehaviour
	{
		[HideInInspector]
		public bool killTweensOnDestroy;

		[HideInInspector]
		public OnEnableBehaviour onEnableBehaviour;

		[HideInInspector]
		public OnDisableBehaviour onDisableBehaviour;

		internal abstract DOTweenClipBase clipBase { get; }

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public Sequence Play(bool restartIfExists = true)
		{
			return null;
		}

		public void KillTween(bool complete = false)
		{
		}

		public void RewindTween(bool includeDelay = true)
		{
		}

		public void CompleteTween(bool withCallbacks = false)
		{
		}

		public void RestartTween(bool includeDelay = true)
		{
		}

		public void RestartTween(bool includeDelay, float changeDelayTo)
		{
		}

		public void RestartTweenFromHere(bool includeDelay = true)
		{
		}

		public void RestartTweenFromHere(bool includeDelay, float changeDelayTo)
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
	}
}
