using System.Runtime.InteropServices;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public class MMLookAtShaker : MMShaker
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct MMLookAtShakeEvent
		{
			public delegate void Delegate(float duration, bool lockXAxis, bool lockYAxis, bool lockZAxis, MMF_LookAt.UpwardVectors upwardVector, MMF_LookAt.LookAtTargetModes lookAtTargetMode, Transform lookAtTarget, Vector3 lookAtTargetWorldPosition, Vector3 lookAtDirection, Transform transformToRotate, MMTweenType lookAtTween, bool useRange = false, float rangeDistance = 0f, bool useRangeFalloff = false, AnimationCurve rangeFalloff = null, Vector2 remapRangeFalloff = default(Vector2), Vector3 rangePosition = default(Vector3), float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false);

			private static event Delegate OnEvent;

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void RuntimeInitialization()
			{
				MMLookAtShakeEvent.OnEvent = null;
			}

			public static void Register(Delegate callback)
			{
				OnEvent += callback;
			}

			public static void Unregister(Delegate callback)
			{
				OnEvent -= callback;
			}

			public static void Trigger(float duration, bool lockXAxis, bool lockYAxis, bool lockZAxis, MMF_LookAt.UpwardVectors upwardVector, MMF_LookAt.LookAtTargetModes lookAtTargetMode, Transform lookAtTarget, Vector3 lookAtTargetWorldPosition, Vector3 lookAtDirection, Transform transformToRotate, MMTweenType lookAtTween, bool useRange = false, float rangeDistance = 0f, bool useRangeFalloff = false, AnimationCurve rangeFalloff = null, Vector2 remapRangeFalloff = default(Vector2), Vector3 rangePosition = default(Vector3), float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false)
			{
				MMLookAtShakeEvent.OnEvent?.Invoke(duration, lockXAxis, lockYAxis, lockZAxis, upwardVector, lookAtTargetMode, lookAtTarget, lookAtTargetWorldPosition, lookAtDirection, transformToRotate, lookAtTween, useRange, rangeDistance, useRangeFalloff, rangeFalloff, remapRangeFalloff, rangePosition, feedbacksIntensity, channelData, resetShakerValuesAfterShake, resetTargetValuesAfterShake, forwardDirection, timescaleMode, stop);
			}
		}

		[MMInspectorGroup("Look at settings", true, 37, false)]
		[Tooltip("the duration of this shake, in seconds")]
		public float Duration = 1f;

		[Tooltip("the curve over which to animate the look at transition")]
		public MMTweenType LookAtTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)));

		[Tooltip("whether or not to lock rotation on the x axis")]
		public bool LockXAxis;

		[Tooltip("whether or not to lock rotation on the y axis")]
		public bool LockYAxis;

		[Tooltip("whether or not to lock rotation on the z axis")]
		public bool LockZAxis;

		[MMInspectorGroup("What we want to rotate", true, 37, false)]
		[Tooltip("in Direct mode, the transform to rotate to have it look at our target - if left empty, will be the transform this shaker is on")]
		public Transform TransformToRotate;

		public MMF_LookAt.UpwardVectors UpwardVector = MMF_LookAt.UpwardVectors.Up;

		[MMInspectorGroup("What we want to look at", true, 37, false)]
		[Tooltip("the different target modes : either a specific transform to look at, the coordinates of a world position, or a direction vector")]
		public MMF_LookAt.LookAtTargetModes LookAtTargetMode;

		[Tooltip("the transform we want to look at")]
		[MMFEnumCondition("LookAtTargetMode", new int[] { 0 })]
		public Transform LookAtTarget;

		[Tooltip("the coordinates of a point the world that we want to look at")]
		[MMFEnumCondition("LookAtTargetMode", new int[] { 1 })]
		public Vector3 LookAtTargetWorldPosition = Vector3.forward;

		[Tooltip("a direction (from our rotating object) that we want to look at")]
		[MMFEnumCondition("LookAtTargetMode", new int[] { 2 })]
		public Vector3 LookAtDirection = Vector3.forward;

		[MMInspectorGroup("Test", true, 46, false)]
		[MMInspectorButton("StartShaking")]
		public bool StartShakingButton;

		protected Quaternion _newRotation;

		protected Vector3 _lookAtPosition;

		protected Vector3 _upwards;

		protected Vector3 _direction;

		protected Quaternion _initialRotation;

		protected float _originalDuration = 1f;

		protected MMTweenType _originalLookAtTween;

		protected bool _originalLockXAxis;

		protected bool _originalLockYAxis;

		protected bool _originalLockZAxis;

		protected MMF_LookAt.UpwardVectors _originalUpwardVector;

		protected MMF_LookAt.LookAtTargetModes _originalLookAtTargetMode;

		protected Transform _originalLookAtTarget;

		protected Vector3 _originalLookAtTargetWorldPosition;

		protected Vector3 _originalLookAtDirection;

		protected override void Initialization()
		{
			base.Initialization();
			if (TransformToRotate == null)
			{
				TransformToRotate = base.transform;
			}
			_initialRotation = TransformToRotate.rotation;
		}

		protected virtual void Reset()
		{
			ShakeDuration = 0.5f;
		}

		protected override void Shake()
		{
			ApplyRotation(_journey);
		}

		protected override void ShakeComplete()
		{
			ApplyRotation(1f);
			base.ShakeComplete();
		}

		protected virtual void ApplyRotation(float journey)
		{
			float t = Mathf.Clamp01(journey / ShakeDuration);
			t = LookAtTween.Evaluate(t);
			switch (LookAtTargetMode)
			{
			case MMF_LookAt.LookAtTargetModes.Transform:
				_lookAtPosition = LookAtTarget.position;
				break;
			case MMF_LookAt.LookAtTargetModes.TargetWorldPosition:
				_lookAtPosition = LookAtTargetWorldPosition;
				break;
			case MMF_LookAt.LookAtTargetModes.Direction:
				_lookAtPosition = TransformToRotate.position + LookAtDirection;
				break;
			}
			if (LockXAxis)
			{
				_lookAtPosition.x = TransformToRotate.position.x;
			}
			if (LockYAxis)
			{
				_lookAtPosition.y = TransformToRotate.position.y;
			}
			if (LockZAxis)
			{
				_lookAtPosition.z = TransformToRotate.position.z;
			}
			_direction = _lookAtPosition - TransformToRotate.position;
			_newRotation = Quaternion.LookRotation(_direction, _upwards);
			TransformToRotate.transform.rotation = Quaternion.SlerpUnclamped(_initialRotation, _newRotation, t);
		}

		public virtual void OnMMLookAtShakeEvent(float duration, bool lockXAxis, bool lockYAxis, bool lockZAxis, MMF_LookAt.UpwardVectors upwardVector, MMF_LookAt.LookAtTargetModes lookAtTargetMode, Transform lookAtTarget, Vector3 lookAtTargetWorldPosition, Vector3 lookAtDirection, Transform transformToRotate, MMTweenType lookAtTween, bool useRange = false, float rangeDistance = 0f, bool useRangeFalloff = false, AnimationCurve rangeFalloff = null, Vector2 remapRangeFalloff = default(Vector2), Vector3 rangePosition = default(Vector3), float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false)
		{
			if (!CheckEventAllowed(channelData, useRange, rangeDistance, rangePosition) || (!Interruptible && Shaking))
			{
				return;
			}
			if (stop)
			{
				Stop();
				return;
			}
			_resetShakerValuesAfterShake = resetShakerValuesAfterShake;
			_resetTargetValuesAfterShake = resetTargetValuesAfterShake;
			if (resetShakerValuesAfterShake)
			{
				_originalDuration = ShakeDuration;
				_originalLookAtTween = LookAtTween;
				_originalLockXAxis = LockXAxis;
				_originalLockYAxis = LockYAxis;
				_originalLockZAxis = LockZAxis;
				_originalUpwardVector = UpwardVector;
				_originalLookAtTargetMode = LookAtTargetMode;
				_originalLookAtTarget = LookAtTarget;
				_originalLookAtTargetWorldPosition = LookAtTargetWorldPosition;
				_originalLookAtDirection = LookAtDirection;
			}
			if (!OnlyUseShakerValues)
			{
				TimescaleMode = timescaleMode;
				ShakeDuration = duration;
				LookAtTween = lookAtTween;
				LockXAxis = lockXAxis;
				LockYAxis = lockYAxis;
				LockZAxis = lockZAxis;
				UpwardVector = upwardVector;
				LookAtTargetMode = lookAtTargetMode;
				LookAtTarget = lookAtTarget;
				LookAtTargetWorldPosition = lookAtTargetWorldPosition;
				LookAtDirection = lookAtDirection;
				ForwardDirection = forwardDirection;
			}
			Play();
		}

		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
			TransformToRotate.rotation = _initialRotation;
		}

		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalDuration;
			LookAtTween = _originalLookAtTween;
			LockXAxis = _originalLockXAxis;
			LockYAxis = _originalLockYAxis;
			LockZAxis = _originalLockZAxis;
			UpwardVector = _originalUpwardVector;
			LookAtTargetMode = _originalLookAtTargetMode;
			LookAtTarget = _originalLookAtTarget;
			LookAtTargetWorldPosition = _originalLookAtTargetWorldPosition;
			LookAtDirection = _originalLookAtDirection;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMLookAtShakeEvent.Register(OnMMLookAtShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMLookAtShakeEvent.Unregister(OnMMLookAtShakeEvent);
		}
	}
}
