using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("TextMesh Pro/TMP Paragraph Spacing")]
	[FeedbackHelp("This feedback lets you control the paragraph spacing of a target TMP over time.")]
	[AddComponentMenu(null)]
	public class MMFeedbackTMPParagraphSpacing : MMFeedbackBase
	{
		[Header("Target")]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Header("Paragraph Spacing")]
		[Tooltip("the curve to tween on")]
		public MMTweenType ParagraphSpacingCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the curve's 0 to")]
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
