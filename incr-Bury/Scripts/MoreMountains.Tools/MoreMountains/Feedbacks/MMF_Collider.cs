using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you enable/disable/toggle a target collider, or change its trigger status")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("GameObject/Collider")]
	public class MMF_Collider : MMF_Feedback
	{
		public enum Modes
		{
			Enable = 0,
			Disable = 1,
			ToggleActive = 2,
			Trigger = 3,
			NonTrigger = 4,
			ToggleTrigger = 5
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Collider", true, 12, true, false)]
		[Tooltip("the collider to act upon")]
		public Collider TargetCollider;

		public Modes Mode = Modes.Disable;

		protected bool _initialState;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetCollider = FindAutomatedTarget<Collider>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && TargetCollider != null)
			{
				ApplyChanges(Mode);
			}
		}

		protected virtual void ApplyChanges(Modes mode)
		{
			switch (mode)
			{
			case Modes.Enable:
				_initialState = TargetCollider.enabled;
				TargetCollider.enabled = true;
				break;
			case Modes.Disable:
				_initialState = TargetCollider.enabled;
				TargetCollider.enabled = false;
				break;
			case Modes.ToggleActive:
				_initialState = TargetCollider.enabled;
				TargetCollider.enabled = !TargetCollider.enabled;
				break;
			case Modes.Trigger:
				_initialState = TargetCollider.isTrigger;
				TargetCollider.isTrigger = true;
				break;
			case Modes.NonTrigger:
				_initialState = TargetCollider.isTrigger;
				TargetCollider.isTrigger = false;
				break;
			case Modes.ToggleTrigger:
				_initialState = TargetCollider.isTrigger;
				TargetCollider.isTrigger = !TargetCollider.isTrigger;
				break;
			default:
				throw new ArgumentOutOfRangeException("mode", mode, null);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				switch (Mode)
				{
				case Modes.Enable:
					TargetCollider.enabled = _initialState;
					break;
				case Modes.Disable:
					TargetCollider.enabled = _initialState;
					break;
				case Modes.ToggleActive:
					TargetCollider.enabled = _initialState;
					break;
				case Modes.Trigger:
					TargetCollider.isTrigger = _initialState;
					break;
				case Modes.NonTrigger:
					TargetCollider.isTrigger = _initialState;
					break;
				case Modes.ToggleTrigger:
					TargetCollider.isTrigger = _initialState;
					break;
				}
			}
		}
	}
}
