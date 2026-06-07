using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu(null)]
	[FeedbackPath("PostProcess/Exposure HDRP")]
	[FeedbackHelp("This feedback allows you to control Exposure intensity over time. It requires you have in your scene an object with a Volume with Exposure active, and a MMExposureShaker_HDRP component.")]
	public class MMFeedbackExposure_HDRP : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the channel to emit on")]
		[Header("Exposure")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Header("Intensity")]
		[Tooltip("the curve to animate the intensity on")]
		public AnimationCurve FixedExposure;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFixedExposureZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFixedExposureOne;

		[Tooltip("whether or not to add to the initial intensity")]
		public bool RelativeFixedExposure;

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
