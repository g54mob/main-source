using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackHelp("This feedback allows you to control color adjustments' post exposure, hue shift, saturation and contrast over time. It requires you have in your scene an object with a Volume with Color Adjustments active, and a MMColorAdjustmentsShaker_HDRP component.")]
	[FeedbackPath("PostProcess/Color Adjustments HDRP")]
	[AddComponentMenu(null)]
	public class MMFeedbackColorAdjustments_HDRP : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Color Grading")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float ShakeDuration;

		[Tooltip("whether or not to add to the initial intensity")]
		public bool RelativeIntensity;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Header("Post Exposure")]
		[Tooltip("the curve used to animate the focus distance value on")]
		public AnimationCurve ShakePostExposure;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapPostExposureZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapPostExposureOne;

		[Header("Hue Shift")]
		[Tooltip("the curve used to animate the aperture value on")]
		public AnimationCurve ShakeHueShift;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-180f, 180f)]
		public float RemapHueShiftZero;

		[Range(-180f, 180f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapHueShiftOne;

		[Tooltip("the curve used to animate the focal length value on")]
		[Header("Saturation")]
		public AnimationCurve ShakeSaturation;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapSaturationZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapSaturationOne;

		[Header("Contrast")]
		[Tooltip("the curve used to animate the focal length value on")]
		public AnimationCurve ShakeContrast;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-100f, 100f)]
		public float RemapContrastZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapContrastOne;

		[Header("Color Filter")]
		[Tooltip("the selected color filter mode :None : nothing will happen,gradient : evaluates the color over time on that gradient, from left to right,interpolate : lerps from the current color to the destination one ")]
		public MMColorAdjustmentsShaker_HDRP.ColorFilterModes ColorFilterMode;

		[Tooltip("the gradient to use to animate the color filter over time")]
		[MMFEnumCondition("ColorFilterMode", new int[] { 1 })]
		[GradientUsage(true)]
		public Gradient ColorFilterGradient;

		[Tooltip("the destination color when in interpolate mode")]
		[MMFEnumCondition("ColorFilterMode", new int[] { 2 })]
		public Color ColorFilterDestination;

		[Tooltip("the curve to use when interpolating towards the destination color")]
		[MMFEnumCondition("ColorFilterMode", new int[] { 2 })]
		public AnimationCurve ColorFilterCurve;

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
