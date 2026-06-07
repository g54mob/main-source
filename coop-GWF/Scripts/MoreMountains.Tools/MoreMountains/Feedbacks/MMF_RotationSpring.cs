using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Rotation Spring")]
	[FeedbackHelp("This feedback will let you animate the rotation of the target object over time, with a spring effect.")]
	public class MMF_RotationSpring : MMF_Feedback
	{
		public enum Modes
		{
			MoveTo = 0,
			MoveToAdditive = 1,
			Bump = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the object to animate")]
		public Transform AnimateRotationTarget;

		[Tooltip("spring duration is determined by the spring (and could be impacted real time), so it's up to you to determine how long this feedback should last, from the point of view of its parent MMF Player")]
		public float DeclaredDuration;

		[Tooltip("whether this feedback should play on local or world rotation")]
		public Space RotationSpace;

		[MMFInspectorGroup("Spring Settings", true, 18, false, false)]
		[Tooltip("the dumping ratio determines how fast the spring will evolve after a disturbance. At a low value, it'll oscillate for a long time, while closer to 1 it'll stop oscillating quickly")]
		[Range(0.01f, 1f)]
		public float DampingX = 0.4f;

		[Tooltip("the frequency determines how fast the spring will oscillate when disturbed, low frequency means less oscillations per second, high frequency means more oscillations per second")]
		public float FrequencyX = 6f;

		[Tooltip("the dumping ratio determines how fast the spring will evolve after a disturbance. At a low value, it'll oscillate for a long time, while closer to 1 it'll stop oscillating quickly")]
		[Range(0.01f, 1f)]
		public float DampingY = 0.4f;

		[Tooltip("the frequency determines how fast the spring will oscillate when disturbed, low frequency means less oscillations per second, high frequency means more oscillations per second")]
		public float FrequencyY = 6f;

		[Tooltip("the dumping ratio determines how fast the spring will evolve after a disturbance. At a low value, it'll oscillate for a long time, while closer to 1 it'll stop oscillating quickly")]
		[Range(0.01f, 1f)]
		public float DampingZ = 0.4f;

		[Tooltip("the frequency determines how fast the spring will oscillate when disturbed, low frequency means less oscillations per second, high frequency means more oscillations per second")]
		public float FrequencyZ = 6f;

		[MMFInspectorGroup("Spring Mode", true, 19, false, false)]
		[Tooltip("the chosen mode for this spring. MoveTo will move the target the specified rotation (randomized between min and max). MoveToAdditive will add the specified rotation (randomized between min and max) to the target's current rotation. Bump will bump the target's rotation by the specified power (randomized between min and max)")]
		public Modes Mode = Modes.Bump;

		[Tooltip("the min value from which to pick a random target value when in MoveTo or MoveToAdditive modes")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector3 MoveToRotationMin = new Vector3(45f, 0f, 0f);

		[Tooltip("the max value from which to pick a random target value when in MoveTo or MoveToAdditive modes")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector3 MoveToRotationMax = new Vector3(90f, 0f, 0f);

		[Tooltip("the min value from which to pick a random bump amount when in Bump mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Vector3 BumpRotationMin = new Vector3(2000f, 2000f, 0f);

		[Tooltip("the max value from which to pick a random bump amount when in Bump mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Vector3 BumpRotationMax = new Vector3(3000f, 3000f, 0f);

		protected Vector3 _currentValue = Vector3.zero;

		protected Vector3 _targetValue = Vector3.zero;

		protected Vector3 _velocity = Vector3.zero;

		protected Vector3 _initialRotation;

		protected Coroutine _coroutine;

		protected float _velocityLowThreshold = 0.001f;

		public override bool HasAutomatedTargetAcquisition => true;

		public override bool CanForceInitialValue => true;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(DeclaredDuration);
			}
			set
			{
				DeclaredDuration = value;
			}
		}

		public override bool HasRandomness => true;

		protected virtual bool LowVelocity => Mathf.Abs(_velocity.x) + Mathf.Abs(_velocity.y) + Mathf.Abs(_velocity.z) < _velocityLowThreshold;

		protected override void AutomateTargetAcquisition()
		{
			AnimateRotationTarget = FindAutomatedTarget<Transform>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active && AnimateRotationTarget != null)
			{
				GetInitialValues();
			}
		}

		protected virtual void GetInitialValues()
		{
			if (RotationSpace == Space.Self)
			{
				_initialRotation = AnimateRotationTarget.localRotation.eulerAngles;
			}
			else
			{
				_initialRotation = AnimateRotationTarget.rotation.eulerAngles;
			}
			_currentValue = _initialRotation;
			_targetValue = _currentValue;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(AnimateRotationTarget == null))
			{
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				switch (Mode)
				{
				case Modes.MoveTo:
					_targetValue.x = Random.Range(MoveToRotationMin.x, MoveToRotationMax.x);
					_targetValue.y = Random.Range(MoveToRotationMin.y, MoveToRotationMax.y);
					_targetValue.z = Random.Range(MoveToRotationMin.z, MoveToRotationMax.z);
					break;
				case Modes.MoveToAdditive:
					_targetValue.x += Random.Range(MoveToRotationMin.x, MoveToRotationMax.x);
					_targetValue.y += Random.Range(MoveToRotationMin.y, MoveToRotationMax.y);
					_targetValue.z += Random.Range(MoveToRotationMin.z, MoveToRotationMax.z);
					break;
				case Modes.Bump:
				{
					_velocity.x = Random.Range(BumpRotationMin.x, BumpRotationMax.x);
					_velocity.y = Random.Range(BumpRotationMin.y, BumpRotationMax.y);
					_velocity.z = Random.Range(BumpRotationMin.z, BumpRotationMax.z);
					float num = ComputeIntensity(feedbacksIntensity, position);
					_velocity.x *= num;
					break;
				}
				}
				_coroutine = Owner.StartCoroutine(Spring());
			}
		}

		protected virtual IEnumerator Spring()
		{
			IsPlaying = true;
			UpdateSpring();
			while (!LowVelocity)
			{
				yield return null;
				UpdateSpring();
				ApplyValue();
			}
			_velocity.x = 0f;
			_velocity.y = 0f;
			_velocity.z = 0f;
			_currentValue = _targetValue;
			ApplyValue();
			IsPlaying = false;
		}

		protected virtual void UpdateSpring()
		{
			MMMaths.Spring(ref _currentValue.x, _targetValue.x, ref _velocity.x, DampingX, FrequencyX, FeedbackDeltaTime);
			MMMaths.Spring(ref _currentValue.y, _targetValue.y, ref _velocity.y, DampingY, FrequencyY, FeedbackDeltaTime);
			MMMaths.Spring(ref _currentValue.z, _targetValue.z, ref _velocity.z, DampingZ, FrequencyZ, FeedbackDeltaTime);
			ApplyValue();
		}

		protected virtual void ApplyValue()
		{
			if (RotationSpace == Space.World)
			{
				AnimateRotationTarget.rotation = Quaternion.Euler(_currentValue);
			}
			else
			{
				AnimateRotationTarget.localRotation = Quaternion.Euler(_currentValue);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				IsPlaying = false;
				_velocity.x = 0f;
				_velocity.y = 0f;
				_velocity.z = 0f;
				_targetValue = _currentValue;
				ApplyValue();
			}
		}

		protected override void CustomSkipToTheEnd(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && AnimateRotationTarget != null)
			{
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				_currentValue = _targetValue;
				IsPlaying = false;
				_velocity.x = 0f;
				_velocity.y = 0f;
				_velocity.z = 0f;
				ApplyValue();
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				_currentValue = _initialRotation;
				_targetValue = _currentValue;
				ApplyValue();
			}
		}
	}
}
