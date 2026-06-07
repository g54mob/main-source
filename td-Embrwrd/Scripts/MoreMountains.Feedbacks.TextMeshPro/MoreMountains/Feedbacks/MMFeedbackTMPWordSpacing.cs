using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the word spacing of a target TMP over time.")]
	[FeedbackPath("TextMesh Pro/TMP Word Spacing")]
	[AddComponentMenu(null)]
	public class MMFeedbackTMPWordSpacing : MMFeedbackBase
	{
		[Tooltip("the TMP_Text component to control")]
		[Header("Target")]
		public TMP_Text TargetTMPText;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to tween on")]
		[Header("Word Spacing")]
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

		protected override void FillTargets()
		{
		}
	}
}
