using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will animate the target's rotation on the 3 specified animation curves (one per axis), for the specified duration (in seconds).")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Rotation")]
	public class MMF_Rotation : MMF_Feedback
	{
		public enum Modes
		{
			Absolute = 0,
			Additive = 1,
			ToDestination = 2
		}

		public enum TimeScales
		{
			Scaled = 0,
			Unscaled = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Rotation Target", true, 61, true, false)]
		[Tooltip("the object whose rotation you want to animate")]
		public Transform AnimateRotationTarget;

		[MMFInspectorGroup("Transition", true, 63, false, false)]
		[Tooltip("whether this feedback should animate in absolute values or additive")]
		public Modes Mode;

		[Tooltip("whether this feedback should play on local or world rotation")]
		public Space RotationSpace;

		[Tooltip("the duration of the transition")]
		public float AnimateRotationDuration = 0.2f;

		[Tooltip("the value to remap the curve's 0 value to")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public float RemapCurveZero;

		[Tooltip("the value to remap the curve's 1 value to")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public float RemapCurveOne = 360f;

		[Tooltip("if this is true, should animate the X rotation")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public bool AnimateX = true;

		[Tooltip("how the x part of the rotation should animate over time, in degrees")]
		public MMTweenType AnimateRotationTweenX = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "AnimateX", "");

		[Tooltip("if this is true, should animate the Y rotation")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public bool AnimateY = true;

		[Tooltip("how the y part of the rotation should animate over time, in degrees")]
		public MMTweenType AnimateRotationTweenY = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "AnimateY", "");

		[Tooltip("if this is true, should animate the Z rotation")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public bool AnimateZ = true;

		[Tooltip("how the z part of the rotation should animate over time, in degrees")]
		public MMTweenType AnimateRotationTweenZ = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)), "AnimateZ", "");

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("if this is true, initial and destination rotations will be recomputed on every play")]
		public bool DetermineRotationOnPlay;

		[Header("To Destination")]
		[Tooltip("the space in which the ToDestination mode should operate")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Space ToDestinationSpace;

		[Tooltip("the angles to match when in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Vector3 DestinationAngles = new Vector3(0f, 180f, 0f);

		[Tooltip("an optional transform we want to match the rotation of. if one is set, DestinationAngles will be ignored")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Transform ToDestinationTransform;

		[Tooltip("how the x part of the rotation should animate over time, in degrees")]
		public MMTweenType ToDestinationTween = new MMTweenType(MMTween.MMTweenCurve.EaseInQuintic, "", "Mode", 2);

		[HideInInspector]
		public AnimationCurve AnimateRotationX;

		[HideInInspector]
		public AnimationCurve AnimateRotationY;

		[HideInInspector]
		public AnimationCurve AnimateRotationZ;

		[HideInInspector]
		public AnimationCurve ToDestinationCurve;

		protected Quaternion _initialRotation;

		protected Vector3 _initialToDestinationAngles;

		protected Quaternion _destinationRotation;

		protected Coroutine _coroutine;

		public override bool HasAutomatedTargetAcquisition => true;

		public override bool CanForceInitialValue => true;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(AnimateRotationDuration);
			}
			set
			{
				AnimateRotationDuration = value;
			}
		}

		public override bool HasRandomness => true;

		protected override void AutomateTargetAcquisition()
		{
			AnimateRotationTarget = FindAutomatedTarget<Transform>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active && AnimateRotationTarget != null)
			{
				GetInitialRotation();
			}
		}

		protected virtual void GetInitialRotation()
		{
			_initialRotation = ((RotationSpace == Space.World) ? AnimateRotationTarget.rotation : AnimateRotationTarget.localRotation);
			_initialToDestinationAngles = _initialRotation.eulerAngles;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || AnimateRotationTarget == null)
			{
				return;
			}
			float num = ComputeIntensity(feedbacksIntensity, position);
			if (!Active && !Owner.AutoPlayOnEnable)
			{
				return;
			}
			if (Mode == Modes.Absolute || Mode == Modes.Additive)
			{
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (DetermineRotationOnPlay && NormalPlayDirection)
					{
						GetInitialRotation();
					}
					ClearCoroutine();
					_coroutine = Owner.StartCoroutine(AnimateRotation(AnimateRotationTarget, Vector3.zero, FeedbackDuration, AnimateRotationTweenX, AnimateRotationTweenY, AnimateRotationTweenZ, RemapCurveZero * num, RemapCurveOne * num));
				}
			}
			else if (Mode == Modes.ToDestination && (AllowAdditivePlays || _coroutine == null))
			{
				if (DetermineRotationOnPlay && NormalPlayDirection)
				{
					GetInitialRotation();
				}
				ClearCoroutine();
				_coroutine = Owner.StartCoroutine(RotateToDestination());
			}
		}

		protected virtual void ClearCoroutine()
		{
			if (_coroutine != null)
			{
				Owner.StopCoroutine(_coroutine);
				_coroutine = null;
			}
		}

		protected virtual IEnumerator RotateToDestination()
		{
			if (!(AnimateRotationTarget == null) && AnimateRotationTweenX != null && AnimateRotationTweenY != null && AnimateRotationTweenZ != null && FeedbackDuration != 0f)
			{
				Vector3 vector = DestinationAngles;
				if (ToDestinationTransform != null)
				{
					vector = ToDestinationTransform.eulerAngles;
				}
				Vector3 destinationAngles = (NormalPlayDirection ? vector : _initialToDestinationAngles);
				float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
				_initialRotation = AnimateRotationTarget.transform.rotation;
				if (ToDestinationSpace == Space.Self)
				{
					AnimateRotationTarget.transform.localRotation = Quaternion.Euler(destinationAngles);
				}
				else
				{
					AnimateRotationTarget.transform.rotation = Quaternion.Euler(destinationAngles);
				}
				_destinationRotation = AnimateRotationTarget.transform.rotation;
				AnimateRotationTarget.transform.rotation = _initialRotation;
				IsPlaying = true;
				while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
				{
					float t = Mathf.Clamp01(journey / FeedbackDuration);
					t = ToDestinationTween.Evaluate(t);
					Quaternion rotation = Quaternion.LerpUnclamped(_initialRotation, _destinationRotation, t);
					AnimateRotationTarget.transform.rotation = rotation;
					journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
					yield return null;
				}
				if (ToDestinationSpace == Space.Self)
				{
					AnimateRotationTarget.transform.localRotation = Quaternion.Euler(destinationAngles);
				}
				else
				{
					AnimateRotationTarget.transform.rotation = Quaternion.Euler(destinationAngles);
				}
				IsPlaying = false;
				_coroutine = null;
			}
		}

		protected virtual IEnumerator AnimateRotation(Transform targetTransform, Vector3 vector, float duration, MMTweenType curveX, MMTweenType curveY, MMTweenType curveZ, float remapZero, float remapOne)
		{
			if (!(targetTransform == null) && curveX != null && curveY != null && curveZ != null && duration != 0f)
			{
				float journey = (NormalPlayDirection ? 0f : duration);
				if (Mode == Modes.Additive)
				{
					_initialRotation = ((RotationSpace == Space.World) ? targetTransform.rotation : targetTransform.localRotation);
				}
				IsPlaying = true;
				while (journey >= 0f && journey <= duration && duration > 0f)
				{
					float percent = Mathf.Clamp01(journey / duration);
					ApplyRotation(targetTransform, remapZero, remapOne, curveX, curveY, curveZ, percent);
					journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
					yield return null;
				}
				ApplyRotation(targetTransform, remapZero, remapOne, curveX, curveY, curveZ, FinalNormalizedTime);
				_coroutine = null;
				IsPlaying = false;
			}
		}

		protected virtual void ApplyRotation(Transform targetTransform, float remapZero, float remapOne, MMTweenType curveX, MMTweenType curveY, MMTweenType curveZ, float percent)
		{
			if (RotationSpace == Space.World)
			{
				targetTransform.transform.rotation = _initialRotation;
			}
			else
			{
				targetTransform.transform.localRotation = _initialRotation;
			}
			if (AnimateX)
			{
				float angle = MMTween.Tween(percent, 0f, 1f, remapZero, remapOne, curveX);
				targetTransform.Rotate(Vector3.right, angle, RotationSpace);
			}
			if (AnimateY)
			{
				float angle2 = MMTween.Tween(percent, 0f, 1f, remapZero, remapOne, curveY);
				targetTransform.Rotate(Vector3.up, angle2, RotationSpace);
			}
			if (AnimateZ)
			{
				float angle3 = MMTween.Tween(percent, 0f, 1f, remapZero, remapOne, curveZ);
				targetTransform.Rotate(Vector3.forward, angle3, RotationSpace);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && _coroutine != null)
			{
				Owner.StopCoroutine(_coroutine);
				_coroutine = null;
				IsPlaying = false;
			}
		}

		public override void OnDisable()
		{
			_coroutine = null;
		}

		public override void OnValidate()
		{
			base.OnValidate();
			MMFeedbacksHelpers.MigrateCurve(AnimateRotationX, AnimateRotationTweenX, Owner);
			MMFeedbacksHelpers.MigrateCurve(AnimateRotationY, AnimateRotationTweenY, Owner);
			MMFeedbacksHelpers.MigrateCurve(AnimateRotationZ, AnimateRotationTweenZ, Owner);
			MMFeedbacksHelpers.MigrateCurve(ToDestinationCurve, ToDestinationTween, Owner);
			if (string.IsNullOrEmpty(AnimateRotationTweenX.ConditionPropertyName))
			{
				AnimateRotationTweenX.ConditionPropertyName = "AnimateX";
				AnimateRotationTweenY.ConditionPropertyName = "AnimateY";
				AnimateRotationTweenZ.ConditionPropertyName = "AnimateZ";
				ToDestinationTween.EnumConditionPropertyName = "Mode";
				ToDestinationTween.EnumConditions = new bool[32];
				ToDestinationTween.EnumConditions[2] = true;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				if (RotationSpace == Space.World)
				{
					AnimateRotationTarget.rotation = _initialRotation;
				}
				else
				{
					AnimateRotationTarget.localRotation = _initialRotation;
				}
			}
		}
	}
}
