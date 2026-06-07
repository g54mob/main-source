using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you trigger a one time play on a target FloatController.")]
	[FeedbackPath("GameObject/FloatController")]
	[AddComponentMenu(null)]
	public class MMFeedbackFloatController : MMFeedback
	{
		public enum Modes
		{
			OneTime = 0,
			ToDestination = 1
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the mode this controller is in")]
		[Header("Float Controller")]
		public Modes Mode;

		[Tooltip("the float controller to trigger a one time play on")]
		public FloatController TargetFloatController;

		[Tooltip("whether this should revert to original at the end")]
		public bool RevertToInitialValueAfterEnd;

		[Tooltip("the duration of the One Time shake")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeDuration;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the amplitude of the One Time shake (this will be multiplied by the curve's height)")]
		public float OneTimeAmplitude;

		[Tooltip("the low value to remap the normalized curve value to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeRemapMin;

		[Tooltip("the high value to remap the normalized curve value to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float OneTimeRemapMax;

		[Tooltip("the curve to apply to the one time shake")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public AnimationCurve OneTimeCurve;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the value to move this float controller to")]
		public float ToDestinationValue;

		[Tooltip("the duration over which to move the value")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float ToDestinationDuration;

		[Tooltip("the curve over which to move the value in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public AnimationCurve ToDestinationCurve;

		protected float _oneTimeDurationStorage;

		protected float _oneTimeAmplitudeStorage;

		protected float _oneTimeRemapMinStorage;

		protected float _oneTimeRemapMaxStorage;

		protected AnimationCurve _oneTimeCurveStorage;

		protected float _toDestinationValueStorage;

		protected float _toDestinationDurationStorage;

		protected AnimationCurve _toDestinationCurveStorage;

		protected bool _revertToInitialValueAfterEndStorage;

		public override float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomReset()
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
