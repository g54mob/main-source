using System;
using UnityEngine;
using UnityEngine.Events;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class MMFeedbacksEvents
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

		[Tooltip("This event will fire every time this MMFeedbacks gets restored to its initial values")]
		public UnityEvent OnRestoreInitialValues;

		[Tooltip("This event will fire every time this MMFeedbacks gets skipped to the end")]
		public UnityEvent OnSkipToTheEnd;

		public bool OnPlayIsNull { get; protected set; }

		public bool OnPauseIsNull { get; protected set; }

		public bool OnResumeIsNull { get; protected set; }

		public bool OnRevertIsNull { get; protected set; }

		public bool OnCompleteIsNull { get; protected set; }

		public bool OnRestoreInitialValuesIsNull { get; protected set; }

		public bool OnSkipToTheEndIsNull { get; protected set; }

		public virtual void Initialization()
		{
		}

		public virtual void TriggerOnPlay(MMFeedbacks source)
		{
		}

		public virtual void TriggerOnPause(MMFeedbacks source)
		{
		}

		public virtual void TriggerOnResume(MMFeedbacks source)
		{
		}

		public virtual void TriggerOnRevert(MMFeedbacks source)
		{
		}

		public virtual void TriggerOnComplete(MMFeedbacks source)
		{
		}

		public virtual void TriggerOnSkipToTheEnd(MMFeedbacks source)
		{
		}

		public virtual void TriggerOnRestoreInitialValues(MMFeedbacks source)
		{
		}
	}
}
