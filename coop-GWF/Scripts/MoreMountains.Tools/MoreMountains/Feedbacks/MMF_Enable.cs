using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback allows you to change the state of a behaviour on a target gameobject from active to inactive (or the opposite), on init, play, stop or reset. For each of these you can specify if you want to force a state (enabled or disabled), or toggle it (enabled becomes disabled, disabled becomes enabled).")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("GameObject/Enable Behaviour")]
	public class MMF_Enable : MMF_Feedback
	{
		public enum PossibleStates
		{
			Enabled = 0,
			Disabled = 1,
			Toggle = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Enable Target Monobehaviour", true, 86, true, false)]
		[Tooltip("the gameobject we want to change the active state of")]
		public Behaviour TargetBehaviour;

		[Tooltip("a list of extra gameobjects we want to change the active state of")]
		public List<Behaviour> ExtraTargetBehaviours;

		[Tooltip("whether or not we should alter the state of the target object on init")]
		public bool SetStateOnInit;

		[MMFCondition("SetStateOnInit", true)]
		[Tooltip("how to change the state on init")]
		public PossibleStates StateOnInit = PossibleStates.Disabled;

		[Tooltip("whether or not we should alter the state of the target object on play")]
		public bool SetStateOnPlay;

		[MMFCondition("SetStateOnPlay", true)]
		[Tooltip("how to change the state on play")]
		public PossibleStates StateOnPlay = PossibleStates.Disabled;

		[Tooltip("whether or not we should alter the state of the target object on stop")]
		public bool SetStateOnStop;

		[Tooltip("how to change the state on stop")]
		[MMFCondition("SetStateOnStop", true)]
		public PossibleStates StateOnStop = PossibleStates.Disabled;

		[Tooltip("whether or not we should alter the state of the target object on reset")]
		public bool SetStateOnReset;

		[Tooltip("how to change the state on reset")]
		[MMFCondition("SetStateOnReset", true)]
		public PossibleStates StateOnReset = PossibleStates.Disabled;

		protected bool _initialState;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active && TargetBehaviour != null && SetStateOnInit)
			{
				SetStatus(StateOnInit);
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetBehaviour == null) && SetStateOnPlay)
			{
				SetStatus(StateOnPlay);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetBehaviour == null))
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				if (SetStateOnStop)
				{
					SetStatus(StateOnStop);
				}
			}
		}

		protected override void CustomReset()
		{
			base.CustomReset();
			if (!InCooldown && Active && FeedbackTypeAuthorized && !(TargetBehaviour == null) && SetStateOnReset)
			{
				SetStatus(StateOnReset);
			}
		}

		protected virtual void SetStatus(PossibleStates state)
		{
			SetStatus(state, TargetBehaviour);
			foreach (Behaviour extraTargetBehaviour in ExtraTargetBehaviours)
			{
				SetStatus(state, extraTargetBehaviour);
			}
		}

		protected virtual void SetStatus(PossibleStates state, Behaviour target)
		{
			_initialState = target.enabled;
			switch (state)
			{
			case PossibleStates.Enabled:
				target.enabled = (NormalPlayDirection ? true : false);
				break;
			case PossibleStates.Disabled:
				target.enabled = !NormalPlayDirection;
				break;
			case PossibleStates.Toggle:
				target.enabled = !target.enabled;
				break;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			TargetBehaviour.enabled = _initialState;
			foreach (Behaviour extraTargetBehaviour in ExtraTargetBehaviours)
			{
				extraTargetBehaviour.enabled = _initialState;
			}
		}
	}
}
