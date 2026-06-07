using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu(null)]
	[FeedbackPath("PostProcess/Film Grain HDRP")]
	[FeedbackHelp("This feedback allows you to control Film Grain intensity over time. It requires you have in your scene an object with a Volume with Film Grain active, and a MMFilmGrainShaker_HDRP component.")]
	public class MMFeedbackFilmGrain_HDRP : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Film Grain")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("the curve to animate the intensity on")]
		[Header("Intensity")]
		public AnimationCurve Intensity;

		[Range(0f, 1f)]
		[Tooltip("the value to remap the curve's zero to")]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the curve's one to")]
		[Range(0f, 1f)]
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
