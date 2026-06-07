using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the line spacing of a target TMP over time.")]
	[FeedbackPath("TextMesh Pro/TMP Line Spacing")]
	public class MMFeedbackTMPLineSpacing : MMFeedbackBase
	{
		[Header("Target")]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[Header("Paragraph Spacing")]
		[Tooltip("the curve to tween on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType LineSpacingCurve;

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne;

		[Tooltip("the value to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantFontSize;

		protected override void FillTargets()
		{
		}
	}
}
