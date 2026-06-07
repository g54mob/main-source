using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMDepthOfFieldShaker")]
	public class MMDepthOfFieldShaker : MMShaker
	{
		public bool RelativeValues;

		[MMInspectorGroup("Focus Distance", true, 49)]
		[Tooltip("the curve used to animate the focus distance value on")]
		public AnimationCurve ShakeFocusDistance;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFocusDistanceZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFocusDistanceOne;

		[MMInspectorGroup("Aperture", true, 50)]
		[Tooltip("the curve used to animate the aperture value on")]
		public AnimationCurve ShakeAperture;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0.1f, 32f)]
		public float RemapApertureZero;

		[Range(0.1f, 32f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapApertureOne;

		[Tooltip("the curve used to animate the focal length value on")]
		[MMInspectorGroup("Focal Length", true, 51)]
		public AnimationCurve ShakeFocalLength;

		[Range(0f, 300f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFocalLengthZero;

		[Range(0f, 300f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFocalLengthOne;
	}
}
