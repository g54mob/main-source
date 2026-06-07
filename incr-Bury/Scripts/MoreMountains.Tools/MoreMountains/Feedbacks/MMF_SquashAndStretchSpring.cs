using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Squash and Stretch Spring")]
	[FeedbackHelp("This feedback will let you animate the scale of the target object over time, with a spring + squash and stretch effect")]
	public class MMF_SquashAndStretchSpring : MMF_Feedback
	{
		public enum Modes
		{
			MoveTo = 0,
			MoveToAdditive = 1,
			Bump = 2
		}

		public enum PossibleAxis
		{
			XtoYZ = 0,
			XtoY = 1,
			XtoZ = 2,
			YtoXZ = 3,
			YtoX = 4,
			YtoZ = 5,
			ZtoXZ = 6,
			ZtoX = 7,
			ZtoY = 8
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Target", true, 12, true, false)]
		[Tooltip("the object to animate")]
		public Transform AnimateScaleTarget;

		[Tooltip("spring duration is determined by the spring (and could be impacted real time), so it's up to you to determine how long this feedback should last, from the point of view of its parent MMF Player")]
		public float DeclaredDuration;

		[Tooltip("the axis on which to operate squashing and stretching")]
		public PossibleAxis Axis;

		[MMFInspectorGroup("Spring Settings", true, 18, false, false)]
		[Tooltip("the dumping ratio determines how fast the spring will evolve after a disturbance. At a low value, it'll oscillate for a long time, while closer to 1 it'll stop oscillating quickly")]
		[Range(0.01f, 1f)]
		public float Damping = 0.4f;

		[Tooltip("the frequency determines how fast the spring will oscillate when disturbed, low frequency means less oscillations per second, high frequency means more oscillations per second")]
		public float Frequency = 6f;

		[MMFInspectorGroup("Spring Mode", true, 19, false, false)]
		[Tooltip("the chosen mode for this spring. MoveTo will move the target the specified scale (randomized between min and max). MoveToAdditive will add the specified scale (randomized between min and max) to the target's current scale. Bump will bump the target's scale by the specified power (randomized between min and max)")]
		public Modes Mode = Modes.Bump;

		[Tooltip("the min value from which to pick a random target value when in MoveTo or MoveToAdditive modes")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public float MoveToMin = 1f;

		[Tooltip("the max value from which to pick a random target value when in MoveTo or MoveToAdditive modes")]
		[MMFEnumCondition("Mode", new int[] { 0, 1 })]
		public float MoveToMax = 2f;

		[Tooltip("the min value from which to pick a random bump amount when in Bump mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float BumpScaleMin = 20f;

		[Tooltip("the max value from which to pick a random bump amount when in Bump mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float BumpScaleMax = 30f;

		protected float _currentValue;

		protected float _targetValue;

		protected float _velocity;

		protected Coroutine _coroutine;

		protected float _velocityLowThreshold = 0.001f;

		protected Vector3 _newScale;

		protected Vector3 _initialScale;

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

		protected virtual bool LowVelocity => Mathf.Abs(_velocity) < _velocityLowThreshold;

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
			_currentValue = AnimateScaleTarget.localScale.x;
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
					_targetValue = Random.Range(MoveToMin, MoveToMax);
					break;
				case Modes.MoveToAdditive:
					_targetValue += Random.Range(MoveToMin, MoveToMax);
					break;
				case Modes.Bump:
					_velocity = Random.Range(BumpScaleMin, BumpScaleMax);
					break;
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
			_velocity = 0f;
			_currentValue = _targetValue;
			ApplyValue();
			IsPlaying = false;
		}

		protected virtual void UpdateSpring()
		{
			MMMaths.Spring(ref _currentValue, _targetValue, ref _velocity, Damping, Frequency, FeedbackDeltaTime);
			ApplyValue();
		}

		protected virtual void ApplyValue()
		{
			float currentValue = _currentValue;
			float num = 1f / Mathf.Sqrt(currentValue);
			switch (Axis)
			{
			case PossibleAxis.XtoYZ:
				_newScale.x = currentValue;
				_newScale.y = num;
				_newScale.z = num;
				break;
			case PossibleAxis.XtoY:
				_newScale.x = currentValue;
				_newScale.y = num;
				_newScale.z = _initialScale.z;
				break;
			case PossibleAxis.XtoZ:
				_newScale.x = currentValue;
				_newScale.y = _initialScale.y;
				_newScale.z = num;
				break;
			case PossibleAxis.YtoXZ:
				_newScale.x = num;
				_newScale.y = currentValue;
				_newScale.z = num;
				break;
			case PossibleAxis.YtoX:
				_newScale.x = num;
				_newScale.y = currentValue;
				_newScale.z = _initialScale.z;
				break;
			case PossibleAxis.YtoZ:
				_newScale.x = currentValue;
				_newScale.y = _initialScale.y;
				_newScale.z = num;
				break;
			case PossibleAxis.ZtoXZ:
				_newScale.x = num;
				_newScale.y = num;
				_newScale.z = currentValue;
				break;
			case PossibleAxis.ZtoX:
				_newScale.x = num;
				_newScale.y = _initialScale.y;
				_newScale.z = currentValue;
				break;
			case PossibleAxis.ZtoY:
				_newScale.x = _initialScale.x;
				_newScale.y = num;
				_newScale.z = currentValue;
				break;
			}
			_newScale.x = Mathf.Abs(_newScale.x);
			_newScale.y = Mathf.Abs(_newScale.y);
			_newScale.z = Mathf.Abs(_newScale.z);
			AnimateScaleTarget.localScale = _newScale;
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
				_velocity = 0f;
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
				_velocity = 0f;
				ApplyValue();
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				_currentValue = _initialScale.x;
				_targetValue = _currentValue;
				ApplyValue();
			}
		}
	}
}
