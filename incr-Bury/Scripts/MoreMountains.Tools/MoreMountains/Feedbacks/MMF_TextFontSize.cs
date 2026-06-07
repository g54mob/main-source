using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you control the font size of a target Text over time.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.MMTools", null)]
	[FeedbackPath("UI/Text Font Size")]
	public class MMF_TextFontSize : MMF_FeedbackBase
	{
		[MMFInspectorGroup("Target", true, 58, true, false)]
		[Tooltip("the TMP_Text component to control")]
		public Text TargetText;

		[MMFInspectorGroup("Font Size", true, 59, false, false)]
		[Tooltip("the curve to tween on")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public MMTweenType FontSizeCurve = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "", "");

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne = 1f;

		[Tooltip("the value to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantFontSize;

		[Tooltip("the value to move to in destination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float DestinationFontSize;

		public override bool HasAutomatedTargetAcquisition => true;

		public override bool CanForceInitialValue => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetText = FindAutomatedTarget<Text>();
		}

		protected override void FillTargets()
		{
			if (!(TargetText == null))
			{
				MMF_FeedbackBaseTarget mMF_FeedbackBaseTarget = new MMF_FeedbackBaseTarget();
				MMPropertyReceiver mMPropertyReceiver = new MMPropertyReceiver();
				mMPropertyReceiver.TargetObject = TargetText.gameObject;
				mMPropertyReceiver.TargetComponent = TargetText;
				mMPropertyReceiver.TargetPropertyName = "fontSize";
				mMPropertyReceiver.RelativeValue = RelativeValues;
				mMF_FeedbackBaseTarget.Target = mMPropertyReceiver;
				mMF_FeedbackBaseTarget.LevelCurve = FontSizeCurve;
				mMF_FeedbackBaseTarget.RemapLevelZero = RemapZero;
				mMF_FeedbackBaseTarget.RemapLevelOne = RemapOne;
				mMF_FeedbackBaseTarget.InstantLevel = InstantFontSize;
				mMF_FeedbackBaseTarget.ToDestinationLevel = DestinationFontSize;
				_targets.Add(mMF_FeedbackBaseTarget);
			}
		}
	}
}
