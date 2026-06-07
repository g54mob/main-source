using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMChannelMixerShaker_HDRP")]
	public class MMChannelMixerShaker_HDRP : MMShaker
	{
		public bool RelativeValues;

		[Tooltip("the curve used to animate the red value on")]
		[MMInspectorGroup("Red", true, 42)]
		public AnimationCurve ShakeRed;

		[Range(-200f, 200f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapRedZero;

		[Range(-200f, 200f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapRedOne;

		[Tooltip("the curve used to animate the green value on")]
		[MMInspectorGroup("Green", true, 43)]
		public AnimationCurve ShakeGreen;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-200f, 200f)]
		public float RemapGreenZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-200f, 200f)]
		public float RemapGreenOne;

		[MMInspectorGroup("Blue", true, 44)]
		[Tooltip("the curve used to animate the blue value on")]
		public AnimationCurve ShakeBlue;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-200f, 200f)]
		public float RemapBlueZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-200f, 200f)]
		public float RemapBlueOne;
	}
}
