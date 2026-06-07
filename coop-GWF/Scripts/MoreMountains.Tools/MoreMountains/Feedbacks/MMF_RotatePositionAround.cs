using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will animate the target's position (not its rotation), on an arc around the specified rotation center, for the specified duration (in seconds).")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Rotate Position Around")]
	public class MMF_RotatePositionAround : MMF_Feedback
	{
		public enum TimeScales
		{
			Scaled = 0,
			Unscaled = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Animation Targets", true, 61, true, false)]
		[Tooltip("the object whose rotation you want to animate")]
		public Transform AnimateRotationTarget;

		[Tooltip("the object around which to rotate AnimateRotationTarget")]
		public Transform AnimateRotationCenter;

		[MMFInspectorGroup("Transition", true, 63, false, false)]
		[Tooltip("the duration of the transition")]
		public float AnimateRotationDuration = 0.2f;

		[Tooltip("the value to remap the curve's 0 value to")]
		public float RemapCurveZero;

		[Tooltip("the value to remap the curve's 1 value to")]
		public float RemapCurveOne = 180f;

		[Tooltip("if this is true, should animate movement on the X axis")]
		public bool AnimateX;

		[Tooltip("how the x part of the movement should animate over time, in degrees")]
		[MMCondition("AnimateX", true)]
		public AnimationCurve AnimateRotationX = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("if this is true, should animate movement on the Y axis")]
		public bool AnimateY = true;

		[Tooltip("how the y part of the rotation should animate over time, in degrees")]
		[MMCondition("AnimateY", true)]
		public AnimationCurve AnimateRotationY = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("if this is true, should animate movement on the Z axis")]
		public bool AnimateZ;

		[Tooltip("how the z part of the rotation should animate over time, in degrees")]
		[MMCondition("AnimateZ", true)]
		public AnimationCurve AnimateRotationZ = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("if this is true, initial and destination rotations will be recomputed on every play")]
		public bool DetermineRotationOnPlay;

		protected Vector3 _initialPosition;

		protected Vector3 _rotationAngles;

		protected Coroutine _coroutine;

		public override bool HasAutomatedTargetAcquisition => true;

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
				GetInitialPosition();
			}
		}

		protected virtual void GetInitialPosition()
		{
			_initialPosition = AnimateRotationTarget.transform.position;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || AnimateRotationTarget == null)
			{
				return;
			}
			float num = ComputeIntensity(feedbacksIntensity, position);
			if ((Active || Owner.AutoPlayOnEnable) && (AllowAdditivePlays || _coroutine == null))
			{
				if (DetermineRotationOnPlay && NormalPlayDirection)
				{
					GetInitialPosition();
				}
				ClearCoroutine();
				_coroutine = Owner.StartCoroutine(AnimateRotation(AnimateRotationTarget, Vector3.zero, FeedbackDuration, AnimateRotationX, AnimateRotationY, AnimateRotationZ, RemapCurveZero * num, RemapCurveOne * num));
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

		protected virtual IEnumerator AnimateRotation(Transform targetTransform, Vector3 vector, float duration, AnimationCurve curveX, AnimationCurve curveY, AnimationCurve curveZ, float remapZero, float remapOne)
		{
			if (!(targetTransform == null) && curveX != null && curveY != null && curveZ != null && duration != 0f)
			{
				float journey = (NormalPlayDirection ? 0f : duration);
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

		protected virtual void ApplyRotation(Transform targetTransform, float remapZero, float remapOne, AnimationCurve curveX, AnimationCurve curveY, AnimationCurve curveZ, float percent)
		{
			targetTransform.position = _initialPosition;
			_rotationAngles.x = 0f;
			_rotationAngles.y = 0f;
			_rotationAngles.z = 0f;
			if (AnimateX)
			{
				_rotationAngles.x = curveX.Evaluate(percent);
				_rotationAngles.x = MMFeedbacksHelpers.Remap(_rotationAngles.x, 0f, 1f, remapZero, remapOne);
			}
			if (AnimateY)
			{
				_rotationAngles.y = curveY.Evaluate(percent);
				_rotationAngles.y = MMFeedbacksHelpers.Remap(_rotationAngles.y, 0f, 1f, remapZero, remapOne);
			}
			if (AnimateZ)
			{
				_rotationAngles.z = curveZ.Evaluate(percent);
				_rotationAngles.z = MMFeedbacksHelpers.Remap(_rotationAngles.z, 0f, 1f, remapZero, remapOne);
			}
			targetTransform.position = MMMaths.RotatePointAroundPivot(targetTransform.position, AnimateRotationCenter.position, _rotationAngles);
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

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				AnimateRotationTarget.transform.position = _initialPosition;
			}
		}

		public override void OnDisable()
		{
			_coroutine = null;
		}
	}
}
