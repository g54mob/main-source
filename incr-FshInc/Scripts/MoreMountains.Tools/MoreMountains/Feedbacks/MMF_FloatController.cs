using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you trigger a one time play on a target FloatController.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.MMTools", null)]
	[FeedbackPath("GameObject/FloatController")]
	public class MMF_FloatController : MMF_Feedback
	{
		public enum Modes
		{
			OneTime = 0,
			ToDestination = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Float Controller", true, 36, true, false)]
		[Tooltip("the mode this controller is in")]
		public Modes Mode;

		[Tooltip("the float controller to trigger a one time play on")]
		public FloatController TargetFloatController;

		[Tooltip("a list of extra and optional float controllers to trigger a one time play on")]
		public List<FloatController> ExtraTargetFloatControllers;

		[Tooltip("whether this should revert to original at the end")]
		public bool RevertToInitialValueAfterEnd;

		[Tooltip("the duration of the One Time shake")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeDuration = 1f;

		[Tooltip("the amplitude of the One Time shake (this will be multiplied by the curve's height)")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeAmplitude = 1f;

		[Tooltip("the low value to remap the normalized curve value to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeRemapMin;

		[Tooltip("the high value to remap the normalized curve value to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeRemapMax = 1f;

		[Tooltip("the curve to apply to the one time shake")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public AnimationCurve OneTimeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to move this float controller to")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float ToDestinationValue = 1f;

		[Tooltip("the duration over which to move the value")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float ToDestinationDuration = 1f;

		[Tooltip("the curve over which to move the value in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public AnimationCurve ToDestinationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		protected float _oneTimeDurationStorage;

		protected float _oneTimeAmplitudeStorage;

		protected float _oneTimeRemapMinStorage;

		protected float _oneTimeRemapMaxStorage;

		protected AnimationCurve _oneTimeCurveStorage;

		protected float _toDestinationValueStorage;

		protected float _toDestinationDurationStorage;

		protected AnimationCurve _toDestinationCurveStorage;

		protected bool _revertToInitialValueAfterEndStorage;

		public override bool HasRandomness => true;

		public override bool CanForceInitialValue => true;

		public override bool ForceInitialValueDelayed => true;

		public override bool HasAutomatedTargetAcquisition => true;

		public override float FeedbackDuration
		{
			get
			{
				if (Mode != Modes.OneTime)
				{
					return ApplyTimeMultiplier(ToDestinationDuration);
				}
				return ApplyTimeMultiplier(OneTimeDuration);
			}
			set
			{
				OneTimeDuration = value;
				ToDestinationDuration = value;
			}
		}

		protected override void AutomateTargetAcquisition()
		{
			TargetFloatController = FindAutomatedTarget<FloatController>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			if (Active && TargetFloatController != null)
			{
				_oneTimeDurationStorage = TargetFloatController.OneTimeDuration;
				_oneTimeAmplitudeStorage = TargetFloatController.OneTimeAmplitude;
				_oneTimeCurveStorage = TargetFloatController.OneTimeCurve;
				_oneTimeRemapMinStorage = TargetFloatController.OneTimeRemapMin;
				_oneTimeRemapMaxStorage = TargetFloatController.OneTimeRemapMax;
				_toDestinationCurveStorage = TargetFloatController.ToDestinationCurve;
				_toDestinationDurationStorage = TargetFloatController.ToDestinationDuration;
				_toDestinationValueStorage = TargetFloatController.ToDestinationValue;
				_revertToInitialValueAfterEndStorage = TargetFloatController.RevertToInitialValueAfterEnd;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || TargetFloatController == null)
			{
				return;
			}
			float intensityMultiplier = ComputeIntensity(feedbacksIntensity, position);
			HandleFloatController(TargetFloatController, intensityMultiplier);
			foreach (FloatController extraTargetFloatController in ExtraTargetFloatControllers)
			{
				HandleFloatController(extraTargetFloatController, intensityMultiplier);
			}
		}

		protected virtual void HandleFloatController(FloatController target, float intensityMultiplier)
		{
			target.RevertToInitialValueAfterEnd = RevertToInitialValueAfterEnd;
			if (Mode == Modes.OneTime)
			{
				target.OneTimeDuration = FeedbackDuration;
				target.OneTimeAmplitude = OneTimeAmplitude;
				target.OneTimeCurve = OneTimeCurve;
				if (NormalPlayDirection)
				{
					target.OneTimeRemapMin = OneTimeRemapMin * intensityMultiplier;
					target.OneTimeRemapMax = OneTimeRemapMax * intensityMultiplier;
				}
				else
				{
					target.OneTimeRemapMin = OneTimeRemapMax * intensityMultiplier;
					target.OneTimeRemapMax = OneTimeRemapMin * intensityMultiplier;
				}
				target.OneTime();
			}
			if (Mode == Modes.ToDestination)
			{
				target.ToDestinationCurve = ToDestinationCurve;
				target.ToDestinationDuration = FeedbackDuration;
				target.ToDestinationValue = ToDestinationValue;
				target.ToDestination();
			}
		}

		protected override void CustomReset()
		{
			base.CustomReset();
			if (!Active || !FeedbackTypeAuthorized || !(TargetFloatController != null))
			{
				return;
			}
			ResetFloatController(TargetFloatController);
			foreach (FloatController extraTargetFloatController in ExtraTargetFloatControllers)
			{
				ResetFloatController(extraTargetFloatController);
			}
		}

		protected virtual void ResetFloatController(FloatController controller)
		{
			controller.OneTimeDuration = _oneTimeDurationStorage;
			controller.OneTimeAmplitude = _oneTimeAmplitudeStorage;
			controller.OneTimeCurve = _oneTimeCurveStorage;
			controller.OneTimeRemapMin = _oneTimeRemapMinStorage;
			controller.OneTimeRemapMax = _oneTimeRemapMaxStorage;
			controller.ToDestinationCurve = _toDestinationCurveStorage;
			controller.ToDestinationDuration = _toDestinationDurationStorage;
			controller.ToDestinationValue = _toDestinationValueStorage;
			controller.RevertToInitialValueAfterEnd = _revertToInitialValueAfterEndStorage;
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || !(TargetFloatController != null))
			{
				return;
			}
			TargetFloatController.Stop();
			foreach (FloatController extraTargetFloatController in ExtraTargetFloatControllers)
			{
				extraTargetFloatController.Stop();
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			TargetFloatController.RestoreInitialValues();
			foreach (FloatController extraTargetFloatController in ExtraTargetFloatControllers)
			{
				extraTargetFloatController.RestoreInitialValues();
			}
		}
	}
}
