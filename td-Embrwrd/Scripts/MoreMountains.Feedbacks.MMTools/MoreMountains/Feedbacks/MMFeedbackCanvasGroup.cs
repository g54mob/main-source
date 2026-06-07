using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the opacity of a canvas group over time.")]
	[FeedbackPath("UI/CanvasGroup")]
	public class MMFeedbackCanvasGroup : MMFeedbackBase
	{
		[Header("Target")]
		[Tooltip("the receiver to write the level to")]
		public CanvasGroup TargetCanvasGroup;

		[Header("Level")]
		[Tooltip("the curve to tween the opacity on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType AlphaCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the opacity curve's 0 to")]
		public float RemapZero;

		[Tooltip("the value to remap the opacity curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne;

		[Tooltip("the value to move the opacity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantAlpha;

		protected override void FillTargets()
		{
		}
	}
}
