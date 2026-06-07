using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the font size of a target Text over time.")]
	[FeedbackPath("UI/Text Font Size")]
	[AddComponentMenu(null)]
	public class MMF_TextFontSize : MMF_FeedbackBase
	{
		[Tooltip("the TMP_Text component to control")]
		[MMFInspectorGroup("Target", true, 58, true, false)]
		public Text TargetText;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to tween on")]
		[MMFInspectorGroup("Font Size", true, 59, false, false)]
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
