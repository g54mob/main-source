using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackHelp("This feedback allows you to control chromatic aberration intensity over time. It requires you have in your scene an object with a Volume with Chromatic Aberration active, and a MMChromaticAberrationShaker_HDRP component.")]
	[FeedbackPath("PostProcess/Chromatic Aberration HDRP")]
	[AddComponentMenu(null)]
	public class MMFeedbackChromaticAberration_HDRP : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the channel to emit on")]
		[Header("Chromatic Aberration")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Range(0f, 1f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapIntensityZero;

		[Range(0f, 1f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapIntensityOne;

		[Tooltip("the curve to animate the intensity on")]
		[Header("Intensity")]
		public AnimationCurve Intensity;

		[Range(0f, 1f)]
		[Tooltip("the multiplier to apply to the intensity curve")]
		public float Amplitude;

		[Tooltip("whether or not to add to the initial intensity")]
		public bool RelativeIntensity;

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
