using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Minigames
{
	public class MinigameViewModel : ViewModelBase
	{
		private readonly ObservableProperty<float> _boltProgress = new ObservableProperty<float>(0f);

		private readonly ObservableProperty<bool> _isEngaged = new ObservableProperty<bool>(value: false);

		private readonly ObservableProperty<bool> _isAligned = new ObservableProperty<bool>(value: false);

		private readonly ObservableProperty<bool> _isBlocked = new ObservableProperty<bool>(value: false);

		private readonly ObservableProperty<float> _keyRotation = new ObservableProperty<float>(0f);

		private readonly ObservableProperty<float> _boltRotation = new ObservableProperty<float>(0f);

		private readonly ObservableProperty<Vector2> _keyPosition = new ObservableProperty<Vector2>(Vector2.zero);

		private float _totalRotation;

		private float _previousAngle;

		private AnimationCurve _rotationCurve;

		private float _initialAngleOffset;

		public IObservableProperty<float> BoltProgress => _boltProgress;

		public IObservableProperty<bool> IsEngaged => _isEngaged;

		public IObservableProperty<bool> IsAligned => _isAligned;

		public IObservableProperty<bool> IsBlocked => _isBlocked;

		public IObservableProperty<float> KeyRotation => _keyRotation;

		public IObservableProperty<float> BoltRotation => _boltRotation;

		public IObservableProperty<Vector2> KeyPosition => _keyPosition;

		public float InitialAngleOffset
		{
			get
			{
				return _initialAngleOffset;
			}
			set
			{
				_initialAngleOffset = value;
			}
		}

		public void Initialize(AnimationCurve rotationCurve)
		{
			_rotationCurve = rotationCurve;
			_boltProgress.Value = 0f;
			_totalRotation = 0f;
		}

		public void SetEngaged(bool engaged)
		{
			_isEngaged.Value = engaged;
			if (engaged)
			{
				_previousAngle = 0f;
			}
		}

		public void SetAligned(bool aligned)
		{
			_isAligned.Value = aligned;
		}

		public void SetBlocked(bool blocked)
		{
			_isBlocked.Value = blocked;
		}

		public void SetKeyRotation(float rotation)
		{
			_keyRotation.Value = rotation;
		}

		public void SetBoltRotation(float rotation)
		{
			_boltRotation.Value = rotation;
		}

		public void SetKeyPosition(Vector2 position)
		{
			_keyPosition.Value = position;
		}

		public void UpdateBoltRotation(float currentAngle)
		{
			if (_isEngaged.Value && !_isBlocked.Value)
			{
				float f = Mathf.DeltaAngle(_previousAngle, currentAngle);
				_totalRotation += Mathf.Abs(f);
				_previousAngle = currentAngle;
				UpdateProgress();
			}
		}

		public void ResetPreviousAngle(float angle)
		{
			_previousAngle = angle;
		}

		private void UpdateProgress()
		{
			if (_rotationCurve == null || _rotationCurve.length == 0)
			{
				_boltProgress.Value = Mathf.Clamp(_totalRotation / 360f, 0f, 2f);
				return;
			}
			float time = _totalRotation / 360f;
			float value = _rotationCurve.Evaluate(time);
			_boltProgress.Value = Mathf.Clamp(value, 0f, 2f);
		}

		public bool IsKeyAlignedWithBolt(float keyAngle, float boltAngle, int boltSides, float alignTolerance)
		{
			float t = Mathf.DeltaAngle(boltAngle, keyAngle) - _initialAngleOffset;
			float num = 360f / (float)boltSides;
			float num2 = Mathf.Repeat(t, num);
			if (num2 > num / 2f)
			{
				num2 = num - num2;
			}
			return num2 <= alignTolerance;
		}

		public void ResetProgress()
		{
			_boltProgress.Value = 0f;
			_totalRotation = 0f;
			_previousAngle = 0f;
		}
	}
}
