using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackPath("UI/RectTransform Anchor")]
	[FeedbackHelp("This feedback lets you control the min and max anchors of a RectTransform over time. That's the normalized position in the parent RectTransform that the lower left and upper right corners are anchored to.")]
	public class MMFeedbackRectTransformAnchor : MMFeedbackBase
	{
		[Tooltip("the target RectTransform to control")]
		[Header("Target")]
		public RectTransform TargetRectTransform;

		[Header("Anchor Min")]
		[Tooltip("whether or not to modify the min anchor")]
		public bool ModifyAnchorMin;

		[Tooltip("the curve to animate the min anchor on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType AnchorMinCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the min anchor curve's 0 on")]
		public Vector2 AnchorMinRemapZero;

		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		[Tooltip("the value to remap the min anchor curve's 1 on")]
		public Vector2 AnchorMinRemapOne;

		[Tooltip("whether or not to modify the max anchor")]
		[Header("Anchor Max")]
		public bool ModifyAnchorMax;

		[Tooltip("the curve to animate the max anchor on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType AnchorMaxCurve;

		[Tooltip("the value to remap the max anchor curve's 0 on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 AnchorMaxRemapZero;

		[Tooltip("the value to remap the max anchor curve's 1 on")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 AnchorMaxRemapOne;

		protected override void FillTargets()
		{
		}
	}
}
