using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMExposureShaker_HDRP")]
	public class MMExposureShaker_HDRP : MMShaker
	{
		[Tooltip("whether or not to add to the initial value")]
		[MMInspectorGroup("Exposure Intensity", true, 46)]
		public bool RelativeIntensity;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeFixedExposure;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFixedExposureZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFixedExposureOne;
	}
}
