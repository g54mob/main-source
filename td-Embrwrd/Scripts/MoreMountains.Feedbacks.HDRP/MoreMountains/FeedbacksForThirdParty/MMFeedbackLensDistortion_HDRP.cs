using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackHelp("This feedback allows you to control HDRP lens distortion intensity over time. It requires you have in your scene an object with a Volume with Lens Distortion active, and a MMLensDistortionShaker_HDRP component.")]
	[AddComponentMenu(null)]
	[FeedbackPath("PostProcess/Lens Distortion HDRP")]
	public class MMFeedbackLensDistortion_HDRP : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Lens Distortion")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Header("Intensity")]
		[Tooltip("whether or not to add to the initial intensity value")]
		public bool RelativeIntensity;

		[Tooltip("the curve to animate the intensity on")]
		public AnimationCurve Intensity;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-100f, 100f)]
		public float RemapIntensityZero;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapIntensityOne;

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
