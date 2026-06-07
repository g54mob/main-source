using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the character spacing of a target TMP over time.")]
	[FeedbackPath("TextMesh Pro/TMP Character Spacing")]
	[AddComponentMenu(null)]
	public class MMF_TMPCharacterSpacing : MMF_FeedbackBase
	{
		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[MMFInspectorGroup("Character Spacing", true, 16, false, false)]
		[Tooltip("the curve to tween on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType CharacterSpacingCurve;

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapZero;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the curve's 1 to")]
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
