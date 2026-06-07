using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("TextMesh Pro/TMP Line Spacing")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the line spacing of a target TMP over time.")]
	public class MMF_TMPLineSpacing : MMF_FeedbackBase
	{
		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[MMFInspectorGroup("Paragraph Spacing", true, 37, false, false)]
		[Tooltip("the curve to tween on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType LineSpacingCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne;

		[Tooltip("the value to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
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
