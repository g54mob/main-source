using System;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class MMSpringFloat : MMSpringDefinition<float>
	{
		[Tooltip("the dumping ratio determines how fast the spring will evolve after a disturbance. At a low value, it'll oscillate for a long time, while closer to 1 it'll stop oscillating quickly")]
		[Range(0.01f, 1f)]
		public float Damping = 0.4f;

		[Tooltip("the frequency determines how fast the spring will oscillate when disturbed, low frequency means less oscillations per second, high frequency means more oscillations per second")]
		public float Frequency = 6f;

		public MMSpringClampSettings ClampSettings;

		public MMSpringDebug SpringDebug = new MMSpringDebug();

		[MMHidden]
		public bool UnifiedSpring;

		[MMHidden]
		public float CurrentValueDisplay;

		[MMHidden]
		public float TargetValueDisplay;

		[MMHidden]
		public float VelocityDisplay;

		protected float _actualCurrentValue;

		protected float _returnCurrentValue;

		protected float _targetValue;

		protected float _velocity;

		[MMInspectorGroup("Debug", true, 19, true)]
		[Tooltip("the current value of this spring")]
		public override float CurrentValue
		{
			get
			{
				return _returnCurrentValue;
			}
			set
			{
				_actualCurrentValue = value;
				_returnCurrentValue = value;
				UpdateSpringDebug();
			}
		}

		[Tooltip("the value towards which this spring is trending, and that it'll reach once it stops oscillating")]
		public override float TargetValue
		{
			get
			{
				return _targetValue;
			}
			set
			{
				_targetValue = ClampSettings.GetTargetValue(value, InitialValue);
				UpdateSpringDebug();
			}
		}

		[Tooltip("the current velocity of the spring")]
		public override float Velocity
		{
			get
			{
				return _velocity;
			}
			set
			{
				_velocity = value;
				UpdateSpringDebug();
			}
		}

		public float InitialValue { get; protected set; }

		public override void UpdateSpringValue(float deltaTime)
		{
			MMMaths.Spring(ref _actualCurrentValue, TargetValue, ref _velocity, Damping, Frequency, deltaTime);
			_returnCurrentValue = _actualCurrentValue;
			if (ClampSettings.ClampNeeded)
			{
				HandleClampMode();
			}
			UpdateSpringDebug();
		}

		protected virtual void HandleClampMode()
		{
			float num = (ClampSettings.ClampMinInitial ? InitialValue : ClampSettings.ClampMinValue);
			float num2 = (ClampSettings.ClampMaxInitial ? InitialValue : ClampSettings.ClampMaxValue);
			if (ClampSettings.ClampMin && _actualCurrentValue < num)
			{
				if (ClampSettings.ClampMinBounce)
				{
					_returnCurrentValue = Mathf.Abs(_actualCurrentValue - num) + num;
				}
				else
				{
					_returnCurrentValue = Mathf.Max(_actualCurrentValue, num);
				}
			}
			if (ClampSettings.ClampMax && _actualCurrentValue > num2)
			{
				if (ClampSettings.ClampMaxBounce)
				{
					_returnCurrentValue = num2 - (_actualCurrentValue - num2);
				}
				else
				{
					_returnCurrentValue = Mathf.Min(_actualCurrentValue, num2);
				}
			}
		}

		protected virtual void UpdateSpringDebug()
		{
		}

		public override void MoveToInstant(float newValue)
		{
			_actualCurrentValue = newValue;
			_returnCurrentValue = newValue;
			TargetValue = newValue;
			Velocity = 0f;
		}

		public override void Stop()
		{
			Velocity = 0f;
			TargetValue = _actualCurrentValue;
		}

		public override void SetInitialValue(float newInitialValue)
		{
			InitialValue = newInitialValue;
		}

		public override void RestoreInitialValue()
		{
			_actualCurrentValue = InitialValue;
			_returnCurrentValue = InitialValue;
			TargetValue = _actualCurrentValue;
			UpdateSpringDebug();
		}

		public override void SetCurrentValueAsInitialValue()
		{
			InitialValue = _actualCurrentValue;
		}

		public override void MoveTo(float newValue)
		{
			TargetValue = newValue;
		}

		public override void MoveToAdditive(float newValue)
		{
			TargetValue += newValue;
		}

		public override void MoveToSubtractive(float newValue)
		{
			TargetValue -= newValue;
		}

		public override void MoveToRandom(float min, float max)
		{
			TargetValue = UnityEngine.Random.Range(min, max);
		}

		public override void Bump(float bumpAmount)
		{
			Velocity += bumpAmount;
		}

		public override void BumpRandom(float min, float max)
		{
			Velocity += UnityEngine.Random.Range(min, max);
		}

		public override void Finish()
		{
			Velocity = 0f;
			_actualCurrentValue = TargetValue;
			_returnCurrentValue = TargetValue;
			UpdateSpringDebug();
		}
	}
}
