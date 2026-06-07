using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Position Spring")]
	[FeedbackHelp("This feedback will let you animate the position of the target object over time, with a spring effect.")]
	public class MMF_PositionSpring : MMF_Feedback
	{
		public enum Modes
		{
			MoveTo = 0,
			MoveToAdditive = 1,
			Bump = 2
		}

		public enum Spaces
		{
			World = 0,
			Local = 1,
			RectTransform = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the object to animate")]
		public Transform AnimatePositionTarget;

		[Tooltip("spring duration is determined by the spring (and could be impacted real time), so it's up to you to determine how long this feedback should last, from the point of view of its parent MMF Player")]
		public float DeclaredDuration;

		[Tooltip("the space in which to move the position in")]
		public Spaces Space;

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
		[Tooltip("the chosen mode for this spring. MoveTo will move the target the specified position (randomized between min and max). MoveToAdditive will add the specified position (randomized between min and max) to the target's current position. Bump will bump the target's position by the specified power (randomized between min and max)")]
		public Modes Mode = Modes.Bump;

		[Tooltip("the min value from which to pick a random target value when in MoveTo or MoveToAdditive modes")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector3 MoveToPositionMin = new Vector3(1f, 1f, 1f);

		[Tooltip("the max value from which to pick a random target value when in MoveTo or MoveToAdditive modes")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector3 MoveToPositionMax = new Vector3(2f, 2f, 2f);

		[Tooltip("the min value from which to pick a random bump amount when in Bump mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Vector3 BumpPositionMin = new Vector3(0f, 20f, 0f);

		[Tooltip("the max value from which to pick a random bump amount when in Bump mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Vector3 BumpPositionMax = new Vector3(0f, 30f, 0f);

		public bool ForceAbsolute;

		protected Vector3 _currentValue = Vector3.zero;

		protected Vector3 _targetValue = Vector3.zero;

		protected Vector3 _velocity = Vector3.zero;

		protected Vector3 _initialPosition;

		protected Coroutine _coroutine;

		protected float _velocityLowThreshold = 0.001f;

		protected RectTransform _rectTransform;

		protected Vector3 _appliedPosition;

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
			AnimatePositionTarget = FindAutomatedTarget<Transform>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Space == Spaces.RectTransform)
			{
				_rectTransform = AnimatePositionTarget.GetComponent<RectTransform>();
			}
			if (Active && AnimatePositionTarget != null)
			{
				GetInitialValues();
			}
		}

		protected virtual void GetInitialValues()
		{
			switch (Space)
			{
			case Spaces.World:
				_initialPosition = AnimatePositionTarget.position;
				break;
			case Spaces.Local:
				_initialPosition = AnimatePositionTarget.localPosition;
				break;
			case Spaces.RectTransform:
				_initialPosition = _rectTransform.anchoredPosition3D;
				break;
			}
			_currentValue = _initialPosition;
			_targetValue = _currentValue;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(AnimatePositionTarget == null))
			{
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				switch (Mode)
				{
				case Modes.MoveTo:
					_targetValue.x = Random.Range(MoveToPositionMin.x, MoveToPositionMax.x);
					_targetValue.y = Random.Range(MoveToPositionMin.y, MoveToPositionMax.y);
					_targetValue.z = Random.Range(MoveToPositionMin.z, MoveToPositionMax.z);
					break;
				case Modes.MoveToAdditive:
					_targetValue.x += Random.Range(MoveToPositionMin.x, MoveToPositionMax.x);
					_targetValue.y += Random.Range(MoveToPositionMin.y, MoveToPositionMax.y);
					_targetValue.z += Random.Range(MoveToPositionMin.z, MoveToPositionMax.z);
					break;
				case Modes.Bump:
				{
					_velocity.x = Random.Range(BumpPositionMin.x, BumpPositionMax.x);
					_velocity.y = Random.Range(BumpPositionMin.y, BumpPositionMax.y);
					_velocity.z = Random.Range(BumpPositionMin.z, BumpPositionMax.z);
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
			_appliedPosition = _currentValue;
			if (ForceAbsolute)
			{
				_appliedPosition.x = Mathf.Abs(_appliedPosition.x - _initialPosition.x) + _initialPosition.x;
				_appliedPosition.y = Mathf.Abs(_appliedPosition.y - _initialPosition.y) + _initialPosition.y;
				_appliedPosition.z = Mathf.Abs(_appliedPosition.z - _initialPosition.z) + _initialPosition.z;
			}
			if (Space == Spaces.World)
			{
				AnimatePositionTarget.position = _appliedPosition;
			}
			else if (Space == Spaces.RectTransform)
			{
				_rectTransform.anchoredPosition3D = _appliedPosition;
			}
			else if (Space == Spaces.Local)
			{
				AnimatePositionTarget.localPosition = _appliedPosition;
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
			if (Active && FeedbackTypeAuthorized && AnimatePositionTarget != null)
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
				_currentValue = _initialPosition;
				_targetValue = _currentValue;
				ApplyValue();
			}
		}
	}
}
