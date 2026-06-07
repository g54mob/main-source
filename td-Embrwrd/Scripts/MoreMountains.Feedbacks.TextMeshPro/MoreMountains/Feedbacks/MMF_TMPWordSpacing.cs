using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("TextMesh Pro/TMP Word Spacing")]
	[FeedbackHelp("This feedback lets you control the word spacing of a target TMP over time.")]
	[AddComponentMenu(null)]
	public class MMF_TMPWordSpacing : MMF_FeedbackBase
	{
		[Tooltip("the TMP_Text component to control")]
		[MMFInspectorGroup("Target", true, 12, true, false)]
		public TMP_Text TargetTMPText;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to tween on")]
		[MMFInspectorGroup("Word Spacing", true, 15, false, false)]
		public MMTweenType WordSpacingCurve;

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
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
