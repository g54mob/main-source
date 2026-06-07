using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackPath("PostProcess/Motion Blur HDRP")]
	[FeedbackHelp("This feedback allows you to control motion blur intensity over time. It requires you have in your scene an object with a Volume with MotionBlur active, and a MMMotionBlurShaker_HDRP component.")]
	[AddComponentMenu(null)]
	public class MMFeedbackMotionBlur_HDRP : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Motion Blur")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Header("Intensity")]
		[Tooltip("the curve to animate the intensity on")]
		public AnimationCurve Intensity;

		[Tooltip("the value to which to remap the curve's zero to")]
		public float RemapIntensityZero;

		[Tooltip("the value to which to remap the curve's one to")]
		public float RemapIntensityOne;

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
