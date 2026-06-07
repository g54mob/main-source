using System;
using UnityEngine;
using UnityEngine.Events;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class MMF_PlayerEvents
	{
		[Tooltip("whether or not this MMFeedbacks should fire MMFeedbacksEvents")]
		public bool TriggerMMFeedbacksEvents;

		[Tooltip("whether or not this MMFeedbacks should fire Unity Events")]
		public bool TriggerUnityEvents;

		[Tooltip("This event will fire every time this MMFeedbacks gets played")]
		public UnityEvent OnPlay;

		[Tooltip("This event will fire every time this MMFeedbacks starts a holding pause")]
		public UnityEvent OnPause;

		[Tooltip("This event will fire every time this MMFeedbacks resumes after a holding pause")]
		public UnityEvent OnResume;

		[Tooltip("This event will fire every time this MMFeedbacks reverts its play direction")]
		public UnityEvent OnRevert;

		[Tooltip("This event will fire every time this MMFeedbacks plays its last MMFeedback")]
		public UnityEvent OnComplete;

		public bool OnPlayIsNull { get; protected set; }

		public bool OnPauseIsNull { get; protected set; }

		public bool OnResumeIsNull { get; protected set; }

		public bool OnRevertIsNull { get; protected set; }

		public bool OnCompleteIsNull { get; protected set; }

		public virtual void Initialization()
		{
		}

		public virtual void TriggerOnPlay(MMF_Player source)
		{
		}

		public virtual void TriggerOnPause(MMF_Player source)
		{
		}

		public virtual void TriggerOnResume(MMF_Player source)
		{
		}

		public virtual void TriggerOnRevert(MMF_Player source)
		{
		}

		public virtual void TriggerOnComplete(MMF_Player source)
		{
		}
	}
}
