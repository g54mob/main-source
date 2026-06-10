using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you control the size delta property (the size of this RectTransform relative to the distances between the anchors) of a RectTransform, over time")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.MMTools", null)]
	[FeedbackPath("UI/RectTransformSizeDelta")]
	public class MMF_RectTransformSizeDelta : MMF_FeedbackBase
	{
		[MMFInspectorGroup("Target RectTransform", true, 37, true, false)]
		[Tooltip("the rect transform we want to impact")]
		public RectTransform TargetRectTransform;

		[MMFInspectorGroup("Size Delta", true, 38, false, false)]
		[Tooltip("the speed at which we should animate the size delta")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public MMTweenType SpeedCurve = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)), "", "");

		[Tooltip("the value to remap the curve's 0 to, randomized between its min and max - put the same value in both min and max if you don't want any randomness")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 RemapZero = Vector2.zero;

		[Tooltip("the value to remap the curve's 1 to, randomized between its min and max - put the same value in both min and max if you don't want any randomness")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector2 RemapOne = Vector2.one;

		public override bool HasAutomatedTargetAcquisition => true;

		public override bool CanForceInitialValue => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetRectTransform = FindAutomatedTarget<RectTransform>();
		}

		protected override void FillTargets()
		{
			if (!(TargetRectTransform == null))
			{
				MMF_FeedbackBaseTarget mMF_FeedbackBaseTarget = new MMF_FeedbackBaseTarget();
				MMPropertyReceiver mMPropertyReceiver = new MMPropertyReceiver();
				mMPropertyReceiver.TargetObject = TargetRectTransform.gameObject;
				mMPropertyReceiver.TargetComponent = TargetRectTransform;
				mMPropertyReceiver.TargetPropertyName = "sizeDelta";
				mMPropertyReceiver.RelativeValue = RelativeValues;
				mMPropertyReceiver.Vector2RemapZero = RemapZero;
				mMPropertyReceiver.Vector2RemapOne = RemapOne;
				mMF_FeedbackBaseTarget.Target = mMPropertyReceiver;
				mMF_FeedbackBaseTarget.LevelCurve = SpeedCurve;
				mMF_FeedbackBaseTarget.RemapLevelZero = 0f;
				mMF_FeedbackBaseTarget.RemapLevelOne = 1f;
				mMF_FeedbackBaseTarget.InstantLevel = 1f;
				_targets.Add(mMF_FeedbackBaseTarget);
			}
		}
	}
}
