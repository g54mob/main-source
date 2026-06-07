using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Scale Spring")]
	[FeedbackHelp("This feedback will let you animate the scale of the target object over time, with a spring effect.")]
	public class MMF_ScaleSpring : MMF_Feedback
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
		public Transform AnimateScaleTarget;

		[Tooltip("spring duration is determined by the spring (and could be impacted real time), so it's up to you to determine how long this feedback should last, from the point of view of its parent MMF Player")]
		public float DeclaredDuration;

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
		[Tooltip("the chosen mode for this spring. MoveTo will move the target the specified scale (randomized between min and max). MoveToAdditive will add the specified scale (randomized between min and max) to the target's current scale. Bump will bump the target's scale by the specified power (randomized between min and max)")]
		public Modes Mode = Modes.Bump;

		[Tooltip("the min value from which to pick a random target value when in MoveTo or MoveToAdditive modes")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector3 MoveToScaleMin = new Vector3(1f, 1f, 1f);

		[Tooltip("the max value from which to pick a random target value when in MoveTo or MoveToAdditive modes")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public Vector3 MoveToScaleMax = new Vector3(2f, 2f, 2f);

		[Tooltip("the min value from which to pick a random bump amount when in Bump mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Vector3 BumpScaleMin = new Vector3(20f, 20f, 20f);

		[Tooltip("the max value from which to pick a random bump amount when in Bump mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Vector3 BumpScaleMax = new Vector3(30f, 30f, 30f);

		protected Vector3 _currentValue = Vector3.zero;

		protected Vector3 _targetValue = Vector3.zero;

		protected Vector3 _velocity = Vector3.zero;

		protected Vector3 _initialScale;

		protected Coroutine _coroutine;

		protected float _velocityLowThreshold = 0.001f;

		protected Vector3 _newScale;

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
			AnimateScaleTarget = FindAutomatedTarget<Transform>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (Active && AnimateScaleTarget != null)
			{
				GetInitialValues();
			}
		}

		protected virtual void GetInitialValues()
		{
			_initialScale = AnimateScaleTarget.localScale;
			_currentValue = AnimateScaleTarget.localScale;
			_targetValue = _currentValue;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && !(AnimateScaleTarget == null))
			{
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				switch (Mode)
				{
				case Modes.MoveTo:
					_targetValue.x = Random.Range(MoveToScaleMin.x, MoveToScaleMax.x);
					_targetValue.y = Random.Range(MoveToScaleMin.y, MoveToScaleMax.y);
					_targetValue.z = Random.Range(MoveToScaleMin.z, MoveToScaleMax.z);
					break;
				case Modes.MoveToAdditive:
					_targetValue.x += Random.Range(MoveToScaleMin.x, MoveToScaleMax.x);
					_targetValue.y += Random.Range(MoveToScaleMin.y, MoveToScaleMax.y);
					_targetValue.z += Random.Range(MoveToScaleMin.z, MoveToScaleMax.z);
					break;
				case Modes.Bump:
				{
					_velocity.x = Random.Range(BumpScaleMin.x, BumpScaleMax.x);
					_velocity.y = Random.Range(BumpScaleMin.y, BumpScaleMax.y);
					_velocity.z = Random.Range(BumpScaleMin.z, BumpScaleMax.z);
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
			_newScale.x = Mathf.Abs(_currentValue.x);
			_newScale.y = Mathf.Abs(_currentValue.y);
			_newScale.z = Mathf.Abs(_currentValue.z);
			AnimateScaleTarget.localScale = _currentValue;
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
			if (Active && FeedbackTypeAuthorized && AnimateScaleTarget != null)
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
				_currentValue = _initialScale;
				_targetValue = _currentValue;
				ApplyValue();
			}
		}
	}
}
