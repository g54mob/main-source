using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMColorGradingShaker")]
	public class MMColorGradingShaker : MMShaker
	{
		public bool RelativeValues;

		[MMInspectorGroup("Post Exposure", true, 40)]
		[Tooltip("the curve used to animate the focus distance value on")]
		public AnimationCurve ShakePostExposure;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapPostExposureZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapPostExposureOne;

		[Tooltip("the curve used to animate the aperture value on")]
		[MMInspectorGroup("Hue Shift", true, 49)]
		public AnimationCurve ShakeHueShift;

		[Range(-180f, 180f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapHueShiftZero;

		[Range(-180f, 180f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapHueShiftOne;

		[MMInspectorGroup("Saturation", true, 48)]
		[Tooltip("the curve used to animate the focal length value on")]
		public AnimationCurve ShakeSaturation;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapSaturationZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapSaturationOne;

		[Tooltip("the curve used to animate the focal length value on")]
		[MMInspectorGroup("Contrast", true, 47)]
		public AnimationCurve ShakeContrast;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-100f, 100f)]
		public float RemapContrastZero;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapContrastOne;
	}
}
