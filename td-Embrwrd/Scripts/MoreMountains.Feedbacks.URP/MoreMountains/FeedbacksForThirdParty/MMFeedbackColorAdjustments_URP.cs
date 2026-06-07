using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackPath("PostProcess/Color Adjustments URP")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback allows you to control color adjustments' post exposure, hue shift, saturation and contrast over time. It requires you have in your scene an object with a Volume with Color Adjustments active, and a MMColorAdjustmentsShaker_URP component.")]
	public class MMFeedbackColorAdjustments_URP : MMFeedback
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

		[Tooltip("the curve used to animate the focus distance value on")]
		[Header("Post Exposure")]
		public AnimationCurve ShakePostExposure;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapPostExposureZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapPostExposureOne;

		[Tooltip("the curve used to animate the aperture value on")]
		[Header("Hue Shift")]
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

		[Tooltip("the selected color filter mode :None : nothing will happen,gradient : evaluates the color over time on that gradient, from left to right,interpolate : lerps from the current color to the destination one ")]
		[Header("Color Filter")]
		public MMColorAdjustmentsShaker_URP.ColorFilterModes ColorFilterMode;

		[GradientUsage(true)]
		[MMFEnumCondition("ColorFilterMode", new int[] { 1 })]
		[Tooltip("the gradient to use to animate the color filter over time")]
		public Gradient ColorFilterGradient;

		[MMFEnumCondition("ColorFilterMode", new int[] { 2 })]
		[Tooltip("the destination color when in interpolate mode")]
		public Color ColorFilterDestination;

		[MMFEnumCondition("ColorFilterMode", new int[] { 2 })]
		[Tooltip("the curve to use when interpolating towards the destination color")]
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
