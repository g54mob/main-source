using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.HDRP", null)]
	[FeedbackHelp("This feedback allows you to control HDRP Depth of Field focus distance or near/far ranges over time.It requires you have in your scene an object with a Volume with Depth of Field active, and a MMDepthOfFieldShaker_HDRP component.")]
	public class MMF_DepthOfField_HDRP : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Depth of Field", true, 28, false, false)]
		[Tooltip("the duration of the shake, in seconds")]
		public float Duration = 0.2f;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake = true;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake = true;

		[MMFInspectorGroup("Focus Distance", true, 53, false, false)]
		[Tooltip("whether or not to animate the focus distance")]
		public bool AnimateFocusDistance = true;

		[Tooltip("the curve used to animate the focus distance value on")]
		[MMFCondition("AnimateFocusDistance", true)]
		public AnimationCurve ShakeFocusDistance = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFCondition("AnimateFocusDistance", true)]
		public float RemapFocusDistanceZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFCondition("AnimateFocusDistance", true)]
		public float RemapFocusDistanceOne = 3f;

		[MMFInspectorGroup("Near Range", true, 52, false, false)]
		[Header("Near Range Start")]
		[Tooltip("whether or not to animate the near range start")]
		public bool AnimateNearRangeStart;

		[Tooltip("the curve used to animate the near range start on")]
		[MMFCondition("AnimateNearRangeStart", true)]
		public AnimationCurve ShakeNearRangeStart = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFCondition("AnimateNearRangeStart", true)]
		public float RemapNearRangeStartZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFCondition("AnimateNearRangeStart", true)]
		public float RemapNearRangeStartOne = 3f;

		[Header("Near Range End")]
		[Tooltip("whether or not to animate the near range end")]
		public bool AnimateNearRangeEnd;

		[Tooltip("the curve used to animate the near range end on")]
		[MMFCondition("AnimateNearRangeEnd", true)]
		public AnimationCurve ShakeNearRangeEnd = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFCondition("AnimateNearRangeEnd", true)]
		public float RemapNearRangeEndZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFCondition("AnimateNearRangeEnd", true)]
		public float RemapNearRangeEndOne = 3f;

		[MMFInspectorGroup("Far Range", true, 51, false, false)]
		[Header("Far Range Start")]
		[Tooltip("whether or not to animate the far range start")]
		public bool AnimateFarRangeStart;

		[Tooltip("the curve used to animate the far range start on")]
		[MMFCondition("AnimateFarRangeStart", true)]
		public AnimationCurve ShakeFarRangeStart = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFCondition("AnimateFarRangeStart", true)]
		public float RemapFarRangeStartZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFCondition("AnimateFarRangeStart", true)]
		public float RemapFarRangeStartOne = 3f;

		[Header("Far Range End")]
		[Tooltip("whether or not to animate the far range end")]
		public bool AnimateFarRangeEnd;

		[Tooltip("the curve used to animate the far range end on")]
		[MMFCondition("AnimateFarRangeEnd", true)]
		public AnimationCurve ShakeFarRangeEnd = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFCondition("AnimateFarRangeEnd", true)]
		public float RemapFarRangeEndZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFCondition("AnimateFarRangeEnd", true)]
		public float RemapFarRangeEndOne = 3f;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(Duration);
			}
			set
			{
				Duration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				float attenuation = ComputeIntensity(feedbacksIntensity, position);
				MMDepthOfFieldShakeEvent_HDRP.Trigger(Duration, attenuation, ChannelData, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, ComputedTimescaleMode, stop: false, restore: false, AnimateFocusDistance, ShakeFocusDistance, RemapFocusDistanceZero, RemapFocusDistanceOne, AnimateNearRangeStart, ShakeNearRangeStart, RemapNearRangeStartZero, RemapNearRangeStartOne, AnimateNearRangeEnd, ShakeNearRangeEnd, RemapNearRangeEndZero, RemapNearRangeEndOne, AnimateFarRangeStart, ShakeFarRangeStart, RemapFarRangeStartZero, RemapFarRangeStartOne, AnimateFarRangeEnd, ShakeFarRangeEnd, RemapFarRangeEndZero, RemapFarRangeEndOne);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				MMDepthOfFieldShakeEvent_HDRP.Trigger(Duration, 1f, ChannelData, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: true);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				MMDepthOfFieldShakeEvent_HDRP.Trigger(Duration, 1f, ChannelData, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: false, restore: true);
			}
		}

		public override void AutomaticShakerSetup()
		{
		}
	}
}
