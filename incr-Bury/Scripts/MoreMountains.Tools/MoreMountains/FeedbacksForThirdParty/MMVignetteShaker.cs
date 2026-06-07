using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MM Vignette Shaker")]
	public class MMVignetteShaker : MMShaker
	{
		[MMInspectorGroup("Vignette Intensity", true, 53, false)]
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeIntensity = true;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 1f)]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 1f)]
		public float RemapIntensityOne = 0.1f;

		[MMInspectorGroup("Vignette Color", true, 51, false)]
		[Tooltip("whether or not to also animate the vignette's color")]
		public bool InterpolateColor;

		[Tooltip("the curve to animate the color on")]
		public AnimationCurve ColorCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.05f, 1f), new Keyframe(0.95f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 1f)]
		public float RemapColorZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 1f)]
		public float RemapColorOne = 1f;

		[Tooltip("the color to lerp towards")]
		public Color TargetColor = Color.red;
	}
}
