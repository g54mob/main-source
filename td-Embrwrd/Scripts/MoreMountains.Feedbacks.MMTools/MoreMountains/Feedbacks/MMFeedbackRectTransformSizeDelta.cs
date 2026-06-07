using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the size delta property (the size of this RectTransform relative to the distances between the anchors) of a RectTransform, over time")]
	[FeedbackPath("UI/RectTransformSizeDelta")]
	public class MMFeedbackRectTransformSizeDelta : MMFeedbackBase
	{
		[Header("Target")]
		[Tooltip("the rect transform we want to impact")]
		public RectTransform TargetRectTransform;

		[Header("Size Delta")]
		[Tooltip("the speed at which we should animate the size delta")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType SpeedCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the curve's 0 to")]
		public Vector2 RemapZero;

		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		[Tooltip("the value to remap the curve's 1 to")]
		public Vector2 RemapOne;

		protected override void FillTargets()
		{
		}
	}
}
