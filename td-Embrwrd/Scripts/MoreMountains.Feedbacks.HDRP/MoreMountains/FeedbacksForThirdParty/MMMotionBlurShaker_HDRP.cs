using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMMotionBlurShaker_HDRP")]
	public class MMMotionBlurShaker_HDRP : MMShaker
	{
		[Tooltip("whether or not to add to the initial value")]
		[MMInspectorGroup("Motion Blur Intensity", true, 48)]
		public bool RelativeIntensity;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeIntensity;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapIntensityOne;
	}
}
