using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.HDRP", null)]
	[FeedbackHelp("This feedback allows you to control vignette intensity over time. It requires you have in your scene an object with a Volume with Vignette active, and a MMVignetteShaker_HDRP component.")]
	public class MMF_Vignette_HDRP : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Vignette", true, 28, false, false)]
		[Tooltip("the duration of the shake, in seconds")]
		public float Duration = 0.2f;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake = true;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake = true;

		[MMFInspectorGroup("Intensity", true, 29, false, false)]
		[Tooltip("the curve to animate the intensity on")]
		public AnimationCurve Intensity = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's zero to")]
		[Range(0f, 1f)]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the curve's one to")]
		[Range(0f, 1f)]
		public float RemapIntensityOne = 1f;

		[Tooltip("whether or not to add to the initial intensity")]
		public bool RelativeIntensity;

		[Header("Color")]
		[Tooltip("whether or not to also animate the vignette's color")]
		public bool InterpolateColor;

		[Tooltip("the curve to animate the color on")]
		public AnimationCurve ColorCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.05f, 1f), new Keyframe(0.95f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 1f)]
		public float RemapColorZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 1f)]
		public float RemapColorOne = 1f;

		[Tooltip("the color to lerp towards")]
		public Color TargetColor = Color.red;

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
				MMVignetteShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, attenuation, ChannelData, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, ComputedTimescaleMode, stop: false, restore: false, InterpolateColor, ColorCurve, RemapColorZero, RemapColorOne, TargetColor);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				MMVignetteShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, 1f, ChannelData, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: true);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				MMVignetteShakeEvent_HDRP.Trigger(Intensity, FeedbackDuration, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, 1f, ChannelData, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: false, restore: true);
			}
		}

		public override void AutomaticShakerSetup()
		{
		}
	}
}
