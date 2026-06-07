using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback allows you to control depth of field focus distance, aperture and focal length over time. It requires you have in your scene an object with a PostProcessVolume with Depth of Field active, and a MMDepthOfFieldShaker component.")]
	[FeedbackPath("PostProcess/Depth Of Field")]
	public class MMFeedbackDepthOfField : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the channel to emit on")]
		[Header("Depth Of Field")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float ShakeDuration;

		[Tooltip("whether or not to add to the initial values")]
		public bool RelativeValues;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Header("Focus Distance")]
		[Tooltip("the curve used to animate the focus distance value on")]
		public AnimationCurve ShakeFocusDistance;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFocusDistanceZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFocusDistanceOne;

		[Tooltip("the curve used to animate the aperture value on")]
		[Header("Aperture")]
		public AnimationCurve ShakeAperture;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0.1f, 32f)]
		public float RemapApertureZero;

		[Range(0.1f, 32f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapApertureOne;

		[Header("Focal Length")]
		[Tooltip("the curve used to animate the focal length value on")]
		public AnimationCurve ShakeFocalLength;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 300f)]
		public float RemapFocalLengthZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 300f)]
		public float RemapFocalLengthOne;

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
