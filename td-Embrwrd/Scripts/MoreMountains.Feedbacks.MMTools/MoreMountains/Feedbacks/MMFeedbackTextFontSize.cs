using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("UI/Text Font Size")]
	[FeedbackHelp("This feedback lets you control the font size of a target Text over time.")]
	[AddComponentMenu(null)]
	public class MMFeedbackTextFontSize : MMFeedbackBase
	{
		[Header("Target")]
		[Tooltip("the TMP_Text component to control")]
		public Text TargetText;

		[Header("Font Size")]
		[Tooltip("the curve to tween on")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType FontSizeCurve;

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
