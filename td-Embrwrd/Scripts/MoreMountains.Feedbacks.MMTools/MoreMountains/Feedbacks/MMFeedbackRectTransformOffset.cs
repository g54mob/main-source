using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the offset of the lower left corner of the rectangle relative to the lower left anchor, and the offset of the upper right corner of the rectangle relative to the upper right anchor.")]
	[FeedbackPath("UI/RectTransform Offset")]
	public class MMFeedbackRectTransformOffset : MMFeedbackBase
	{
		[Header("Target")]
		public RectTransform TargetRectTransform;

		[Header("Offset Min")]
		[Tooltip("whether we should modify the offset min or not")]
		public bool ModifyOffsetMin;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to animate the min offset on")]
		public MMTweenType OffsetMinCurve;

		[Tooltip("the value to remap the min curve's 0 on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 OffsetMinRemapZero;

		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		[Tooltip("the value to remap the min curve's 1 on")]
		public Vector2 OffsetMinRemapOne;

		[Header("Offset Max")]
		[Tooltip("whether we should modify the offset max or not")]
		public bool ModifyOffsetMax;

		[Tooltip("the curve to animate the max offset on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType OffsetMaxCurve;

		[Tooltip("the value to remap the max curve's 0 on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 OffsetMaxRemapZero;

		[Tooltip("the value to remap the max curve's 1 on")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 OffsetMaxRemapOne;

		protected override void FillTargets()
		{
		}
	}
}
