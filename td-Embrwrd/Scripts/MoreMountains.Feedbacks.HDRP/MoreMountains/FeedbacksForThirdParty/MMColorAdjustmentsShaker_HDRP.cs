using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMColorAdjustmentsShaker_HDRP")]
	public class MMColorAdjustmentsShaker_HDRP : MMShaker
	{
		public enum ColorFilterModes
		{
			None = 0,
			Gradient = 1,
			Interpolate = 2
		}

		public bool RelativeValues;

		[MMInspectorGroup("Post Exposure", true, 44)]
		[Tooltip("the curve used to animate the focus distance value on")]
		public AnimationCurve ShakePostExposure;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapPostExposureZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapPostExposureOne;

		[Tooltip("the curve used to animate the aperture value on")]
		[MMInspectorGroup("Hue Shift", true, 45)]
		public AnimationCurve ShakeHueShift;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-180f, 180f)]
		public float RemapHueShiftZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-180f, 180f)]
		public float RemapHueShiftOne;

		[Tooltip("the curve used to animate the focal length value on")]
		[MMInspectorGroup("Saturation", true, 46)]
		public AnimationCurve ShakeSaturation;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapSaturationZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapSaturationOne;

		[MMInspectorGroup("Contrast", true, 47)]
		[Tooltip("the curve used to animate the focal length value on")]
		public AnimationCurve ShakeContrast;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapContrastZero;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapContrastOne;

		[Tooltip("the color filter mode to work with (none, over a gradient, or interpolate to a destination color")]
		[MMInspectorGroup("Color Filter", true, 48)]
		public ColorFilterModes ColorFilterMode;

		[MMFEnumCondition("ColorFilterMode", new int[] { 1 })]
		[GradientUsage(true)]
		[Tooltip("the gradient over which to modify the color filter")]
		public Gradient ColorFilterGradient;

		[Tooltip("the destination color to match when in Interpolate mode")]
		[MMFEnumCondition("ColorFilterMode", new int[] { 2 })]
		public Color ColorFilterDestination;

		[MMFEnumCondition("ColorFilterMode", new int[] { 2 })]
		[Tooltip("the curve over which to interpolate the color filter")]
		public AnimationCurve ColorFilterCurve;
	}
}
