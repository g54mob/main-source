using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the position of a RectTransform's pivot over time")]
	[FeedbackPath("UI/RectTransform Pivot")]
	[AddComponentMenu(null)]
	public class MMF_RectTransformPivot : MMF_FeedbackBase
	{
		[Tooltip("the RectTransform whose position you want to control over time")]
		[MMFInspectorGroup("Target RectTransform", true, 37, true, false)]
		public RectTransform TargetRectTransform;

		[MMFInspectorGroup("Pivot", true, 39, false, false)]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("The curve along which to evaluate the position of the RectTransform's pivot")]
		public MMTweenType SpeedCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the position to remap the curve's 0 to")]
		public Vector2 RemapZero;

		[Tooltip("the position to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 RemapOne;

		public override bool HasAutomatedTargetAcquisition => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void FillTargets()
		{
		}
	}
}
