using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;

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
		[Tooltip("the selected mode : shake : changes the timescale for a certain duration\n- shake : sets the timescale to a new value for the specified TimeScaleDuration then reverts it back to what it was before\n- change : sets the timescale to a new value, forever (until you change it again)\n- reset : resets the timescale to its NormalTimescale value, defined in the MMTimeManager\n- unfreeze : sets the timescale back to its previous value, before the last change")]
		public Modes Mode;

		[Tooltip("the new timescale to apply")]
		public float TimeScale = 0.5f;

		[Tooltip("the duration of the timescale modification")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float TimeScaleDuration = 1f;

		[Tooltip("whether to reset the timescale on Stop or not")]
		public bool ResetTimescaleOnStop;

		[Tooltip("whether to unfreeze the timescale on Stop or not - if you set this to true, ResetTimescaleOnStop will be ignored")]
		public bool UnfreezeTimescaleOnStop;

		[MMFInspectorGroup("Interpolation", true, 63, false, false)]
		[Tooltip("whether or not we should lerp the timescale")]
		public bool TimeScaleLerp;

		[Tooltip("whether to lerp over a set duration, or at a certain speed")]
		public MMTimeScaleLerpModes TimescaleLerpMode;

		[Tooltip("in Speed mode, the speed at which to lerp the timescale")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 0 })]
		public float TimeScaleLerpSpeed = 1f;

		[Tooltip("in Duration mode, the curve to use to lerp the timescale")]
		public MMTweenType TimescaleLerpCurve = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)), "", "TimescaleLerpMode", 1);

		[Tooltip("in Duration mode, the duration of the timescale interpolation, in unscaled time seconds")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 1 })]
		public float TimescaleLerpDuration = 1f;

		[FormerlySerializedAs("TimeScaleLerpOnReset")]
		[Tooltip("whether or not we should lerp the timescale as it goes back to normal afterwards when using Unfreeze mode")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 1 })]
		public bool TimeScaleLerpOnUnfreeze;

		[FormerlySerializedAs("TimescaleLerpCurveOnReset")]
		[Tooltip("in Duration mode, the curve to use to lerp the timescale when unfreezing if TimeScaleLerpOnUnfreeze is true")]
		public MMTweenType TimescaleLerpCurveOnUnfreeze = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)), "", "TimescaleLerpMode", 1);

		[FormerlySerializedAs("TimescaleLerpDurationOnReset")]
		[Tooltip("in Duration mode, the duration of the timescale interpolation, in unscaled time seconds when unfreezing if TimeScaleLerpOnUnfreeze is true")]
		[MMFEnumCondition("TimescaleLerpMode", new int[] { 1 })]
		public float TimescaleLerpDurationOnUnfreeze = 1f;

		public override float FeedbackDuration
		{
			get
			{
				float num = ((Mode == Modes.Shake) ? TimeScaleDuration : 0f);
				if (TimescaleLerpMode == MMTimeScaleLerpModes.Duration)
				{
					num += (TimeScaleLerp ? TimescaleLerpDuration : 0f);
					if (Mode == Modes.Shake)
					{
						num += (TimeScaleLerpOnUnfreeze ? TimescaleLerpDurationOnUnfreeze : 0f);
					}
				}
				return ApplyTimeMultiplier(num);
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
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, TimeScale, TimeScaleDuration, TimeScaleLerp, TimeScaleLerpSpeed, infinite: false, TimescaleLerpMode, TimescaleLerpCurve, TimescaleLerpDuration, TimeScaleLerpOnUnfreeze, TimescaleLerpCurveOnUnfreeze, TimescaleLerpDurationOnUnfreeze);
					break;
				case Modes.Change:
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, TimeScale, 0f, TimeScaleLerp, TimeScaleLerpSpeed, infinite: true, TimescaleLerpMode, TimescaleLerpCurve, TimescaleLerpDuration, TimeScaleLerpOnUnfreeze, TimescaleLerpCurveOnUnfreeze, TimescaleLerpDurationOnUnfreeze);
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
			if (Active && FeedbackTypeAuthorized && (ResetTimescaleOnStop || UnfreezeTimescaleOnStop))
			{
				if (UnfreezeTimescaleOnStop)
				{
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.Unfreeze, TimeScale, 0f, lerp: false, 0f, infinite: true);
				}
				else if (ResetTimescaleOnStop)
				{
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.Reset, TimeScale, 0f, lerp: false, 0f, infinite: true);
				}
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

		public override void OnValidate()
		{
			base.OnValidate();
			if (string.IsNullOrEmpty(TimescaleLerpCurve.EnumConditionPropertyName))
			{
				TimescaleLerpCurve.EnumConditionPropertyName = "TimescaleLerpMode";
				TimescaleLerpCurveOnUnfreeze.EnumConditionPropertyName = "TimescaleLerpMode";
				TimescaleLerpCurve.EnumConditions = new bool[32];
			}
			if (!TimescaleLerpCurve.EnumConditions[1])
			{
				TimescaleLerpCurve.EnumConditions[1] = true;
				TimescaleLerpCurveOnUnfreeze.EnumConditions[1] = true;
			}
		}
	}
}
