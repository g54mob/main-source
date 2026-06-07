using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you trigger a play on a target MMRadioSignal (usually used by a MMRadioBroadcaster to emit a value that can then be listened to by MMRadioReceivers. From this feedback you can also specify a duration, timescale and multiplier.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.MMTools", null)]
	[FeedbackPath("GameObject/MMRadioSignal")]
	public class MMF_RadioSignal : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Radio Signal", true, 72, false, false)]
		[Tooltip("The target MMRadioSignal to trigger")]
		public MMRadioSignal TargetSignal;

		[Tooltip("the timescale to operate on")]
		public MMRadioSignal.TimeScales TimeScale;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration = 1f;

		[Tooltip("a global multiplier to apply to the end result of the combination")]
		public float GlobalMultiplier = 1f;

		public override float FeedbackDuration => 0f;

		public override bool HasRandomness => true;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetSignal = FindAutomatedTarget<MMRadioSignal>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && TargetSignal != null)
			{
				float num = ComputeIntensity(feedbacksIntensity, position);
				TargetSignal.Duration = Duration;
				TargetSignal.GlobalMultiplier = GlobalMultiplier * num;
				TargetSignal.TimeScale = TimeScale;
				TargetSignal.StartShaking();
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			base.CustomStopFeedback(position, feedbacksIntensity);
			if (Active && TargetSignal != null)
			{
				TargetSignal.Stop();
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized && TargetSignal != null)
			{
				TargetSignal.Stop();
				TargetSignal.ApplyLevel(0f);
			}
		}
	}
}
