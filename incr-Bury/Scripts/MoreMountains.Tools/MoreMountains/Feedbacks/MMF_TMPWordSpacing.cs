using MoreMountains.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you control the word spacing of a target TMP over time.")]
	[FeedbackPath("TextMesh Pro/TMP Word Spacing")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.TextMeshPro", null)]
	public class MMF_TMPWordSpacing : MMF_FeedbackBase
	{
		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the TMP_Text component to control")]
		public TMP_Text TargetTMPText;

		[MMFInspectorGroup("Word Spacing", true, 15, false, false)]
		[Tooltip("the curve to tween on")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public MMTweenType WordSpacingCurve = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "", "");

		[Tooltip("the value to remap the curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapOne = 10f;

		[Tooltip("the value to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantWordSpacing;

		[Tooltip("the value to move to in destination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float DestinationWordSpacing;

		public override bool HasAutomatedTargetAcquisition => true;

		public override bool CanForceInitialValue => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetTMPText = FindAutomatedTarget<TMP_Text>();
		}

		protected override void FillTargets()
		{
			if (!(TargetTMPText == null))
			{
				MMF_FeedbackBaseTarget mMF_FeedbackBaseTarget = new MMF_FeedbackBaseTarget();
				MMPropertyReceiver mMPropertyReceiver = new MMPropertyReceiver();
				mMPropertyReceiver.TargetObject = TargetTMPText.gameObject;
				mMPropertyReceiver.TargetComponent = TargetTMPText;
				mMPropertyReceiver.TargetPropertyName = "wordSpacing";
				mMPropertyReceiver.RelativeValue = RelativeValues;
				mMF_FeedbackBaseTarget.Target = mMPropertyReceiver;
				mMF_FeedbackBaseTarget.LevelCurve = WordSpacingCurve;
				mMF_FeedbackBaseTarget.RemapLevelZero = RemapZero;
				mMF_FeedbackBaseTarget.RemapLevelOne = RemapOne;
				mMF_FeedbackBaseTarget.InstantLevel = InstantWordSpacing;
				mMF_FeedbackBaseTarget.ToDestinationLevel = DestinationWordSpacing;
				_targets.Add(mMF_FeedbackBaseTarget);
			}
		}
	}
}
