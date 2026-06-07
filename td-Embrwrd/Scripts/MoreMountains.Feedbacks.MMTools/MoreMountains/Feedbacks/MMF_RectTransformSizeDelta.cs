using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the size delta property (the size of this RectTransform relative to the distances between the anchors) of a RectTransform, over time")]
	[FeedbackPath("UI/RectTransformSizeDelta")]
	public class MMF_RectTransformSizeDelta : MMF_FeedbackBase
	{
		[Tooltip("the rect transform we want to impact")]
		[MMFInspectorGroup("Target RectTransform", true, 37, true, false)]
		public RectTransform TargetRectTransform;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[MMFInspectorGroup("Size Delta", true, 38, false, false)]
		[Tooltip("the speed at which we should animate the size delta")]
		public MMTweenType SpeedCurve;

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 RemapZero;

		[Tooltip("the value to remap the curve's 1 to")]
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
