using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMWhiteBalanceShaker_HDRP")]
	public class MMWhiteBalanceShaker_HDRP : MMShaker
	{
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeValues;

		[Tooltip("the curve used to animate the temperature value on")]
		[MMInspectorGroup("Temperature", true, 47)]
		public AnimationCurve ShakeTemperature;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-100f, 100f)]
		public float RemapTemperatureZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapTemperatureOne;

		[Tooltip("the curve used to animate the tint value on")]
		[MMInspectorGroup("Tint", true, 48)]
		public AnimationCurve ShakeTint;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapTintZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapTintOne;
	}
}
