using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMColorGradingShaker")]
	public class MMColorGradingShaker : MMShaker
	{
		public bool RelativeValues = true;

		[MMInspectorGroup("Post Exposure", true, 40, false)]
		[Tooltip("the curve used to animate the focus distance value on")]
		public AnimationCurve ShakePostExposure = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapPostExposureZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapPostExposureOne = 1f;

		[MMInspectorGroup("Hue Shift", true, 49, false)]
		[Tooltip("the curve used to animate the aperture value on")]
		public AnimationCurve ShakeHueShift = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-180f, 180f)]
		public float RemapHueShiftZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-180f, 180f)]
		public float RemapHueShiftOne = 180f;

		[MMInspectorGroup("Saturation", true, 48, false)]
		[Tooltip("the curve used to animate the focal length value on")]
		public AnimationCurve ShakeSaturation = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-100f, 100f)]
		public float RemapSaturationZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapSaturationOne = 100f;

		[MMInspectorGroup("Contrast", true, 47, false)]
		[Tooltip("the curve used to animate the focal length value on")]
		public AnimationCurve ShakeContrast = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-100f, 100f)]
		public float RemapContrastZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapContrastOne = 100f;

		[MMFInspectorGroup("Color Filter", true, 50, false, false)]
		[Tooltip("if this is true, the color filter will be animated over the gradient below")]
		public bool ShakeColorFilter;

		[Tooltip("the gradient to use to animate the color filter over time")]
		[GradientUsage(true)]
		public Gradient ColorFilterGradient;
	}
}
