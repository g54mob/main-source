using MoreMountains.Tools;
using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("TextMesh Pro/TMP Outline Width")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the outline width of a target TMP over time.")]
	public class MMFeedbackTMPOutlineWidth : MMFeedbackBase
	{
		[Header("Target")]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to tween on")]
		[Header("Outline Width")]
		public MMTweenType OutlineWidthCurve;

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
