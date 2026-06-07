using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the opacity of a canvas group over time.")]
	[FeedbackPath("UI/CanvasGroup")]
	[AddComponentMenu(null)]
	public class MMF_CanvasGroup : MMF_FeedbackBase
	{
		[Tooltip("the receiver to write the level to")]
		[MMFInspectorGroup("Canvas Group", true, 12, true, false)]
		public CanvasGroup TargetCanvasGroup;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to tween the opacity on")]
		public MMTweenType AlphaCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the opacity curve's 0 to")]
		public float RemapZero;

		[Tooltip("the value to remap the opacity curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the value to move the opacity to in instant mode")]
		public float InstantAlpha;

		public override bool HasAutomatedTargetAcquisition => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		public override void OnAddFeedback()
		{
		}

		protected override void FillTargets()
		{
		}
	}
}
