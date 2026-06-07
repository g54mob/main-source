using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you trigger position, rotation and/or scale wiggles on an object equipped with a MMWiggle component, for the specified durations.")]
	[FeedbackPath("Transform/Wiggle")]
	public class MMFeedbackWiggle : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Target")]
		[Tooltip("the Wiggle component to target")]
		public MMWiggle TargetWiggle;

		[Header("Position")]
		[Tooltip("whether or not to wiggle position")]
		public bool WigglePosition;

		[Tooltip("the duration (in seconds) of the position wiggle")]
		public float WigglePositionDuration;

		[Header("Rotation")]
		[Tooltip("whether or not to wiggle rotation")]
		public bool WiggleRotation;

		[Tooltip("the duration (in seconds) of the rotation wiggle")]
		public float WiggleRotationDuration;

		[Tooltip("whether or not to wiggle scale")]
		[Header("Scale")]
		public bool WiggleScale;

		[Tooltip("the duration (in seconds) of the scale wiggle")]
		public float WiggleScaleDuration;

		public override float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
