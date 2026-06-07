using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you animate the rotation of a transform to look at a target over time. You can also use it to broadcast a MMLookAtShake event, that MMLookAtShakers on the right channel will be able to listen for and act upon.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/LookAt")]
	public class MMF_LookAt : MMF_Feedback
	{
		public enum Modes
		{
			Direct = 0,
			Event = 1
		}

		public enum LookAtTargetModes
		{
			Transform = 0,
			TargetWorldPosition = 1,
			Direction = 2
		}

		public enum UpwardVectors
		{
			Forward = 0,
			Up = 1,
			Right = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Look at settings", true, 37, true, false)]
		[Tooltip("the duration of this feedback, in seconds")]
		public float Duration = 1f;

		[Tooltip("the curve over which to animate the look at transition")]
		public MMTweenType LookAtTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)));

		[Tooltip("whether or not to lock rotation on the x axis")]
		public bool LockXAxis;

		[Tooltip("whether or not to lock rotation on the y axis")]
		public bool LockYAxis;

		[Tooltip("whether or not to lock rotation on the z axis")]
		public bool LockZAxis;

		[MMFInspectorGroup("What we want to rotate", true, 37, true, false)]
		[Tooltip("whether to make a certain transform look at a target, or to broadcast an event")]
		public Modes Mode;

		[Tooltip("in Direct mode, the transform to rotate to have it look at our target")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Transform TransformToRotate;

		[Tooltip("the vector representing the up direction on the object we want to rotate and look at our target")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public UpwardVectors UpwardVector = UpwardVectors.Up;

		[Tooltip("whether or not to reset shaker values after shake")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool ResetShakerValuesAfterShake = true;

		[Tooltip("whether or not to reset the target's values after shake")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public bool ResetTargetValuesAfterShake = true;

		[MMFInspectorGroup("What we want to look at", true, 37, true, false)]
		[Tooltip("the different target modes : either a specific transform to look at, the coordinates of a world position, or a direction vector")]
		public LookAtTargetModes LookAtTargetMode;

		[Tooltip("the transform we want to look at")]
		[MMFEnumCondition("LookAtTargetMode", new int[] { 0 })]
		public Transform LookAtTarget;

		[Tooltip("the coordinates of a point the world that we want to look at")]
		[MMFEnumCondition("LookAtTargetMode", new int[] { 1 })]
		public Vector3 LookAtTargetWorldPosition = Vector3.forward;

		[Tooltip("a direction (from our rotating object) that we want to look at")]
		[MMFEnumCondition("LookAtTargetMode", new int[] { 2 })]
		public Vector3 LookAtDirection = Vector3.forward;

		protected Coroutine _coroutine;

		protected Quaternion _initialDirectTargetTransformRotation;

		protected Quaternion _newRotation;

		protected Vector3 _lookAtPosition;

		protected Vector3 _upwards;

		protected Vector3 _direction;

		protected Quaternion _initialRotation;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(Duration);
			}
			set
			{
				Duration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRange => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			switch (UpwardVector)
			{
			case UpwardVectors.Forward:
				_upwards = Vector3.forward;
				break;
			case UpwardVectors.Up:
				_upwards = Vector3.up;
				break;
			case UpwardVectors.Right:
				_upwards = Vector3.right;
				break;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && (Active || Owner.AutoPlayOnEnable))
			{
				InitiateLookAt(position);
			}
		}

		protected virtual void InitiateLookAt(Vector3 position)
		{
			_initialRotation = TransformToRotate.transform.rotation;
			switch (Mode)
			{
			case Modes.Direct:
				ClearCoroutine();
				_coroutine = Owner.StartCoroutine(AnimateLookAt());
				break;
			case Modes.Event:
				MMLookAtShaker.MMLookAtShakeEvent.Trigger(Duration, LockXAxis, LockYAxis, LockZAxis, UpwardVector, LookAtTargetMode, LookAtTarget, LookAtTargetWorldPosition, LookAtDirection, null, LookAtTween, UseRange, RangeDistance, UseRangeFalloff, RangeFalloff, RemapRangeFalloff, position, 1f, ChannelData, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, ComputedTimescaleMode);
				break;
			}
		}

		protected virtual IEnumerator AnimateLookAt()
		{
			if (TransformToRotate != null)
			{
				_initialDirectTargetTransformRotation = TransformToRotate.transform.rotation;
			}
			float duration = FeedbackDuration;
			float journey = (NormalPlayDirection ? 0f : duration);
			IsPlaying = true;
			while (journey >= 0f && journey <= duration && duration > 0f)
			{
				float t = Mathf.Clamp01(journey / duration);
				t = LookAtTween.Evaluate(t);
				ApplyRotation(t);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			ApplyRotation(LookAtTween.Evaluate(1f));
			_coroutine = null;
			IsPlaying = false;
		}

		protected virtual void ApplyRotation(float percent)
		{
			switch (LookAtTargetMode)
			{
			case LookAtTargetModes.Transform:
				_lookAtPosition = LookAtTarget.position;
				break;
			case LookAtTargetModes.TargetWorldPosition:
				_lookAtPosition = LookAtTargetWorldPosition;
				break;
			case LookAtTargetModes.Direction:
				_lookAtPosition = TransformToRotate.position + LookAtDirection;
				break;
			}
			_direction = _lookAtPosition - TransformToRotate.position;
			_newRotation = Quaternion.LookRotation(_direction, _upwards);
			if (LockXAxis)
			{
				_newRotation.x = TransformToRotate.rotation.x;
			}
			if (LockYAxis)
			{
				_newRotation.y = TransformToRotate.rotation.y;
			}
			if (LockZAxis)
			{
				_newRotation.z = TransformToRotate.rotation.z;
			}
			TransformToRotate.transform.rotation = Quaternion.SlerpUnclamped(_initialDirectTargetTransformRotation, _newRotation, percent);
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && _coroutine != null)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				ClearCoroutine();
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

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				TransformToRotate.transform.rotation = _initialRotation;
			}
		}
	}
}
