using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the position of a RectTransform's pivot over time")]
	[FeedbackPath("UI/RectTransform Pivot")]
	public class MMFeedbackRectTransformPivot : MMFeedbackBase
	{
		[Header("Target")]
		[Tooltip("the RectTransform whose position you want to control over time")]
		public RectTransform TargetRectTransform;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("The curve along which to evaluate the position of the RectTransform's pivot")]
		[Header("Pivot")]
		public MMTweenType SpeedCurve;

		[Tooltip("the position to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 RemapZero;

		[Tooltip("the position to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 RemapOne;

		protected override void FillTargets()
		{
		}
	}
}
