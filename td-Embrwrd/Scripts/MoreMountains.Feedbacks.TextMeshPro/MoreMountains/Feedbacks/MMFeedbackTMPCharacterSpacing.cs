using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the character spacing of a target TMP over time.")]
	[FeedbackPath("TextMesh Pro/TMP Character Spacing")]
	[AddComponentMenu(null)]
	public class MMFeedbackTMPCharacterSpacing : MMFeedbackBase
	{
		[Tooltip("the TMP_Text component to control")]
		[Header("Target")]
		public TMP_Text TargetTMPText;

		[Header("Character Spacing")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to tween on")]
		public MMTweenType CharacterSpacingCurve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapZero;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapOne;

		[Tooltip("the value to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantFontSize;

		protected override void FillTargets()
		{
		}
	}
}
