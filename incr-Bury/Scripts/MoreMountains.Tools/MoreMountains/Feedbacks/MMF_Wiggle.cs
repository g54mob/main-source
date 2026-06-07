using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you trigger position, rotation and/or scale wiggles on an object equipped with a MMWiggle component, for the specified durations.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Wiggle")]
	public class MMF_Wiggle : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Target", true, 54, true, false)]
		[Tooltip("the Wiggle component to target")]
		public MMWiggle TargetWiggle;

		[MMFInspectorGroup("Position", true, 55, false, false)]
		[Tooltip("whether or not to wiggle position")]
		public bool WigglePosition = true;

		[Tooltip("the duration (in seconds) of the position wiggle")]
		public float WigglePositionDuration;

		[MMFInspectorGroup("Rotation", true, 26, false, false)]
		[Tooltip("whether or not to wiggle rotation")]
		public bool WiggleRotation;

		[Tooltip("the duration (in seconds) of the rotation wiggle")]
		public float WiggleRotationDuration;

		[MMFInspectorGroup("Scale", true, 57, false, false)]
		[Tooltip("whether or not to wiggle scale")]
		public bool WiggleScale;

		[Tooltip("the duration (in seconds) of the scale wiggle")]
		public float WiggleScaleDuration;

		public override bool HasAutomatedTargetAcquisition => true;

		public override float FeedbackDuration
		{
			get
			{
				return Mathf.Max(ApplyTimeMultiplier(WigglePositionDuration), ApplyTimeMultiplier(WiggleRotationDuration), ApplyTimeMultiplier(WiggleScaleDuration));
			}
			set
			{
				WigglePositionDuration = value;
				WiggleRotationDuration = value;
				WiggleScaleDuration = value;
			}
		}

		protected override void AutomateTargetAcquisition()
		{
			TargetWiggle = FindAutomatedTarget<MMWiggle>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetWiggle == null))
			{
				TargetWiggle.enabled = true;
				if (WigglePosition)
				{
					TargetWiggle.PositionWiggleProperties.UseUnscaledTime = !InScaledTimescaleMode;
					TargetWiggle.WigglePosition(ApplyTimeMultiplier(WigglePositionDuration));
				}
				if (WiggleRotation)
				{
					TargetWiggle.RotationWiggleProperties.UseUnscaledTime = !InScaledTimescaleMode;
					TargetWiggle.WiggleRotation(ApplyTimeMultiplier(WiggleRotationDuration));
				}
				if (WiggleScale)
				{
					TargetWiggle.ScaleWiggleProperties.UseUnscaledTime = !InScaledTimescaleMode;
					TargetWiggle.WiggleScale(ApplyTimeMultiplier(WiggleScaleDuration));
				}
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(TargetWiggle == null))
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				TargetWiggle.enabled = false;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TargetWiggle.RestoreInitialValues();
			}
		}
	}
}
