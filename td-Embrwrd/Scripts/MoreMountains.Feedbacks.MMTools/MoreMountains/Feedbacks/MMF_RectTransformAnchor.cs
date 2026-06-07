using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("UI/RectTransform Anchor")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the min and max anchors of a RectTransform over time. That's the normalized position in the parent RectTransform that the lower left and upper right corners are anchored to.")]
	public class MMF_RectTransformAnchor : MMF_FeedbackBase
	{
		[MMFInspectorGroup("Target RectTransform", true, 37, true, false)]
		[Tooltip("the target RectTransform to control")]
		public RectTransform TargetRectTransform;

		[Tooltip("whether or not to modify the min anchor")]
		[MMFInspectorGroup("Anchor Min", true, 43, false, false)]
		public bool ModifyAnchorMin;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to animate the min anchor on")]
		public MMTweenType AnchorMinCurve;

		[Tooltip("the value to remap the min anchor curve's 0 on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 AnchorMinRemapZero;

		[Tooltip("the value to remap the min anchor curve's 1 on")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 AnchorMinRemapOne;

		[Tooltip("whether or not to modify the max anchor")]
		[MMFInspectorGroup("Anchor Max", true, 44, false, false)]
		public bool ModifyAnchorMax;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to animate the max anchor on")]
		public MMTweenType AnchorMaxCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the max anchor curve's 0 on")]
		public Vector2 AnchorMaxRemapZero;

		[Tooltip("the value to remap the max anchor curve's 1 on")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 AnchorMaxRemapOne;

		public override bool HasAutomatedTargetAcquisition => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void FillTargets()
		{
		}
	}
}
