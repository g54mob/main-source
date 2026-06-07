using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback triggers a MMTimeScaleEvent, which, if you have a MMTimeManager object in your scene, will be caught and used to modify the timescale according to the specified settings. These settings are the new timescale (0.5 will be twice slower than normal, 2 twice faster, etc), the duration of the timescale modification, and the optional speed at which to transition between normal and altered time scale.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Time/Timescale Modifier")]
	public class MMF_TimescaleModifier : MMF_Feedback
	{
		public enum Modes
		{
			Shake = 0,
			Change = 1,
			Reset = 2,
			Unfreeze = 3
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Timescale Modifier", true, 63, false, false)]
		[Tooltip("the selected mode : shake : changes the timescale for a certain duration- change : sets the timescale to a new value, forever (until you change it again)- reset : resets the timescale to its previous value")]
		public Modes Mode;

		[Tooltip("the new timescale to apply")]
		public float TimeScale = 0.5f;

		[Tooltip("the duration of the timescale modification")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float TimeScaleDuration = 1f;

		[Tooltip("whether to reset the timescale on Stop or not")]
		public bool ResetTimescaleOnStop;

		[MMFInspectorGroup("Interpolation", true, 63, false, false)]
		[Tooltip("whether or not we should lerp the timescale")]
		public bool TimeScaleLerp;

		[Tooltip("whether to lerp over a set duration, or at a certain speed")]
		public MMTimeScaleLerpModes TimescaleLerpMode;

		[Tooltip("in Speed mode, the speed at which to lerp the timescale")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 0 })]
		public float TimeScaleLerpSpeed = 1f;

		[Tooltip("in Duration mode, the curve to use to lerp the timescale")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 1 })]
		public MMTweenType TimescaleLerpCurve = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)));

		[Tooltip("in Duration mode, the duration of the timescale interpolation, in unscaled time seconds")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 1 })]
		public float TimescaleLerpDuration = 1f;

		[Tooltip("whether or not we should lerp the timescale as it goes back to normal afterwards")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 1 })]
		public bool TimeScaleLerpOnReset;

		[Tooltip("in Duration mode, the curve to use to lerp the timescale")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 1 })]
		public MMTweenType TimescaleLerpCurveOnReset = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)));

		[Tooltip("in Duration mode, the duration of the timescale interpolation, in unscaled time seconds")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 1 })]
		public float TimescaleLerpDurationOnReset = 1f;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(TimeScaleDuration);
			}
			set
			{
				TimeScaleDuration = value;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				switch (Mode)
				{
				case Modes.Shake:
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, TimeScale, FeedbackDuration, TimeScaleLerp, TimeScaleLerpSpeed, infinite: false, TimescaleLerpMode, TimescaleLerpCurve, TimescaleLerpDuration, TimeScaleLerpOnReset, TimescaleLerpCurveOnReset, TimescaleLerpDurationOnReset);
					break;
				case Modes.Change:
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, TimeScale, 0f, TimeScaleLerp, TimeScaleLerpSpeed, infinite: true, TimescaleLerpMode, TimescaleLerpCurve, TimescaleLerpDuration, TimeScaleLerpOnReset, TimescaleLerpCurveOnReset, TimescaleLerpDurationOnReset);
					break;
				case Modes.Reset:
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.Reset, TimeScale, 0f, lerp: false, 0f, infinite: true);
					break;
				case Modes.Unfreeze:
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.Unfreeze, TimeScale, 0f, lerp: false, 0f, infinite: true);
					break;
				}
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && ResetTimescaleOnStop)
			{
				MMTimeScaleEvent.Trigger(MMTimeScaleMethods.Reset, TimeScale, 0f, lerp: false, 0f, infinite: true);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				MMTimeScaleEvent.Trigger(MMTimeScaleMethods.Reset, TimeScale, 0f, lerp: false, 0f, infinite: true);
			}
		}

		public override void AutomaticShakerSetup()
		{
			if (Owner.gameObject.MMFindOrCreateObjectOfType<MMTimeManager>("MMTimeManager", null).createdNew)
			{
				MMDebug.DebugLogInfo("Added a MMTimeManager to the scene. You're all set.");
			}
		}
	}
}
