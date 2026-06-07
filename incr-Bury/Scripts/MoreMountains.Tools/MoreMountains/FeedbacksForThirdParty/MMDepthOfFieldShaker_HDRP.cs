using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MM Depth Of Field Shaker HDRP")]
	public class MMDepthOfFieldShaker_HDRP : MMShaker
	{
		[MMInspectorGroup("Focus Distance", true, 53, false)]
		[Tooltip("whether or not to animate the focus distance")]
		public bool AnimateFocusDistance = true;

		[Tooltip("the curve used to animate the focus distance value on")]
		[MMCondition("AnimateFocusDistance", true)]
		public AnimationCurve ShakeFocusDistance = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMCondition("AnimateFocusDistance", true)]
		public float RemapFocusDistanceZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMCondition("AnimateFocusDistance", true)]
		public float RemapFocusDistanceOne = 3f;

		[MMInspectorGroup("Near Range", true, 52, false)]
		[Header("Near Range Start")]
		[Tooltip("whether or not to animate the near range start")]
		public bool AnimateNearRangeStart;

		[Tooltip("the curve used to animate the near range start on")]
		[MMCondition("AnimateNearRangeStart", true)]
		public AnimationCurve ShakeNearRangeStart = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMCondition("AnimateNearRangeStart", true)]
		public float RemapNearRangeStartZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMCondition("AnimateNearRangeStart", true)]
		public float RemapNearRangeStartOne = 3f;

		[Header("Near Range End")]
		[Tooltip("whether or not to animate the near range end")]
		public bool AnimateNearRangeEnd;

		[Tooltip("the curve used to animate the near range end on")]
		[MMCondition("AnimateNearRangeEnd", true)]
		public AnimationCurve ShakeNearRangeEnd = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMCondition("AnimateNearRangeEnd", true)]
		public float RemapNearRangeEndZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMCondition("AnimateNearRangeEnd", true)]
		public float RemapNearRangeEndOne = 3f;

		[MMInspectorGroup("Far Range", true, 51, false)]
		[Header("Far Range Start")]
		[Tooltip("whether or not to animate the far range start")]
		public bool AnimateFarRangeStart;

		[Tooltip("the curve used to animate the far range start on")]
		[MMCondition("AnimateFarRangeStart", true)]
		public AnimationCurve ShakeFarRangeStart = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMCondition("AnimateFarRangeStart", true)]
		public float RemapFarRangeStartZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMCondition("AnimateFarRangeStart", true)]
		public float RemapFarRangeStartOne = 3f;

		[Header("Far Range End")]
		[Tooltip("whether or not to animate the far range end")]
		public bool AnimateFarRangeEnd;

		[Tooltip("the curve used to animate the far range end on")]
		[MMCondition("AnimateFarRangeEnd", true)]
		public AnimationCurve ShakeFarRangeEnd = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[MMCondition("AnimateFarRangeEnd", true)]
		public float RemapFarRangeEndZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMCondition("AnimateFarRangeEnd", true)]
		public float RemapFarRangeEndOne = 3f;
	}
}
