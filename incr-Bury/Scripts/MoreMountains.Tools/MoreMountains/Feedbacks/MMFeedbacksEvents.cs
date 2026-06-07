using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class MMFeedbacksEvents
	{
		[Tooltip("whether or not this MMFeedbacks should fire MMFeedbacksEvents")]
		public bool TriggerMMFeedbacksEvents;

		[Tooltip("whether or not this MMFeedbacks should fire Unity Events")]
		public bool TriggerUnityEvents = true;

		[Tooltip("This event will fire every time this MMFeedbacks gets played")]
		public UnityEvent OnPlay;

		[Tooltip("This event will fire every time this MMFeedbacks starts a holding pause")]
		public UnityEvent OnPause;

		[Tooltip("This event will fire every time this MMFeedbacks gets stopped via a call to the StopFeedbacks method")]
		public UnityEvent OnStop;

		[Tooltip("This event will fire every time this MMFeedbacks resumes after a holding pause")]
		public UnityEvent OnResume;

		[FormerlySerializedAs("OnRevert")]
		[Tooltip("This event will fire every time this MMFeedbacks changes its play direction")]
		public UnityEvent OnChangeDirection;

		[Tooltip("This event will fire every time this MMFeedbacks plays its last MMFeedback")]
		public UnityEvent OnComplete;

		[Tooltip("This event will fire every time this MMFeedbacks gets restored to its initial values")]
		public UnityEvent OnRestoreInitialValues;

		[Tooltip("This event will fire every time this MMFeedbacks gets skipped to the end")]
		public UnityEvent OnSkipToTheEnd;

		[Tooltip("This event will fire after the MMF Player is done initializing")]
		public UnityEvent OnInitializationComplete;

		[Tooltip("This event will fire every time this MMFeedbacks' game object gets enabled")]
		public UnityEvent OnEnable;

		[Tooltip("This event will fire every time this MMFeedbacks' game object gets disabled")]
		public UnityEvent OnDisable;

		public virtual bool OnPlayIsNull { get; protected set; }

		public virtual bool OnPauseIsNull { get; protected set; }

		public virtual bool OnResumeIsNull { get; protected set; }

		public virtual bool OnChangeDirectionIsNull { get; protected set; }

		public virtual bool OnCompleteIsNull { get; protected set; }

		public virtual bool OnRestoreInitialValuesIsNull { get; protected set; }

		public virtual bool OnSkipToTheEndIsNull { get; protected set; }

		public virtual bool OnInitializationCompleteIsNull { get; protected set; }

		public virtual bool OnEnableIsNull { get; protected set; }

		public virtual bool OnDisableIsNull { get; protected set; }

		public virtual bool OnStopIsNull { get; protected set; }

		public virtual void Initialization()
		{
			OnPlayIsNull = OnPlay == null;
			OnPauseIsNull = OnPause == null;
			OnResumeIsNull = OnResume == null;
			OnChangeDirectionIsNull = OnChangeDirection == null;
			OnCompleteIsNull = OnComplete == null;
			OnRestoreInitialValuesIsNull = OnRestoreInitialValues == null;
			OnSkipToTheEndIsNull = OnSkipToTheEnd == null;
			OnInitializationCompleteIsNull = OnInitializationComplete == null;
			OnEnableIsNull = OnEnable == null;
			OnDisableIsNull = OnDisable == null;
			OnStopIsNull = OnStop == null;
		}

		public virtual void TriggerOnPlay(MMFeedbacks source)
		{
			if (!OnPlayIsNull && TriggerUnityEvents)
			{
				OnPlay.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.Play);
			}
		}

		public virtual void TriggerOnPause(MMFeedbacks source)
		{
			if (!OnPauseIsNull && TriggerUnityEvents)
			{
				OnPause.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.Pause);
			}
		}

		public virtual void TriggerOnResume(MMFeedbacks source)
		{
			if (!OnResumeIsNull && TriggerUnityEvents)
			{
				OnResume.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.Resume);
			}
		}

		public virtual void TriggerOnChangeDirection(MMFeedbacks source)
		{
			if (!OnChangeDirectionIsNull && TriggerUnityEvents)
			{
				OnChangeDirection.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.ChangeDirection);
			}
		}

		public virtual void TriggerOnComplete(MMFeedbacks source)
		{
			if (!OnCompleteIsNull && TriggerUnityEvents)
			{
				OnComplete.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.Complete);
			}
		}

		public virtual void TriggerOnSkipToTheEnd(MMFeedbacks source)
		{
			if (!OnSkipToTheEndIsNull && TriggerUnityEvents)
			{
				OnSkipToTheEnd.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.SkipToTheEnd);
			}
		}

		public virtual void TriggerOnInitializationComplete(MMFeedbacks source)
		{
			if (!OnInitializationCompleteIsNull && TriggerUnityEvents)
			{
				OnInitializationComplete.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.InitializationComplete);
			}
		}

		public virtual void TriggerOnRestoreInitialValues(MMFeedbacks source)
		{
			if (!OnRestoreInitialValuesIsNull && TriggerUnityEvents)
			{
				OnRestoreInitialValues.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.RestoreInitialValues);
			}
		}

		public virtual void TriggerOnEnable(MMF_Player source)
		{
			if (!OnEnableIsNull && TriggerUnityEvents)
			{
				OnEnable.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.Enable);
			}
		}

		public virtual void TriggerOnDisable(MMF_Player source)
		{
			if (!OnDisableIsNull && TriggerUnityEvents)
			{
				OnDisable.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.Disable);
			}
		}

		public virtual void TriggerOnStop(MMF_Player source)
		{
			if (!OnDisableIsNull && TriggerUnityEvents)
			{
				OnStop.Invoke();
			}
			if (TriggerMMFeedbacksEvents)
			{
				MMFeedbacksEvent.Trigger(source, MMFeedbacksEvent.EventTypes.Stop);
			}
		}
	}
}
