using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the font size of a target TMP over time.")]
	[FeedbackPath("TextMesh Pro/TMP Font Size")]
	public class MMF_TMPFontSize : MMF_FeedbackBase
	{
		[Tooltip("the TMP_Text component to control")]
		[MMFInspectorGroup("Target", true, 12, true, false)]
		public TMP_Text TargetTMPText;

		[MMFInspectorGroup("Font Size", true, 16, false, false)]
		[Tooltip("the curve to tween on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType FontSizeCurve;

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapZero;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the curve's 1 to")]
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
