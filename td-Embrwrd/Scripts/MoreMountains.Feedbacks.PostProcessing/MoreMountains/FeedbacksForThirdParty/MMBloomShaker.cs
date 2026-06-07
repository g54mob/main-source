using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMBloomShaker")]
	public class MMBloomShaker : MMShaker
	{
		public bool RelativeValues;

		[Tooltip("the curve used to animate the intensity value on")]
		[MMInspectorGroup("Bloom Intensity", true, 45)]
		public AnimationCurve ShakeIntensity;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapIntensityOne;

		[MMInspectorGroup("Bloom Threshold", true, 46)]
		[Tooltip("the curve used to animate the threshold value on")]
		public AnimationCurve ShakeThreshold;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapThresholdZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapThresholdOne;
	}
}
