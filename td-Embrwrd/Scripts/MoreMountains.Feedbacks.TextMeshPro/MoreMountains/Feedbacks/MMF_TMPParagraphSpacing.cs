using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the paragraph spacing of a target TMP over time.")]
	[FeedbackPath("TextMesh Pro/TMP Paragraph Spacing")]
	[AddComponentMenu(null)]
	public class MMF_TMPParagraphSpacing : MMF_FeedbackBase
	{
		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[MMFInspectorGroup("Paragraph Spacing", true, 21, false, false)]
		[Tooltip("the curve to tween on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType ParagraphSpacingCurve;

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the value to move to in instant mode")]
		public float InstantFontSize;

		public override bool HasAutomatedTargetAcquisition => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void FillTargets()
		{
		}
	}
}
