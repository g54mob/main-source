using Easing;
using UnityEngine;

namespace Motorways.Utility
{
	public class InertialFloat
	{
		private enum SpringTarget
		{
			None = 0,
			Min = 1,
			Max = 2,
			Absolute = 3
		}

		private float _min;

		private float _max;

		private float _range;

		private float _rawValue;

		private bool _resetVelocity = true;

		private float _previousRawValue;

		private SpringTarget _springTarget;

		private float _springTime = -1f;

		private float _springOrigin;

		private readonly Easings.Functions _springEasing;

		private const float Inertia = 0.55f;

		private readonly float _springDuration;

		public float AverageVelocity { get; private set; }

		public float SpringTargetAbsolute { get; set; }

		public float Min
		{
			get
			{
				return _min;
			}
			set
			{
				_min = value;
			}
		}

		public float Max
		{
			get
			{
				return _max;
			}
			set
			{
				_max = value;
			}
		}

		public float Range
		{
			get
			{
				if (_range >= 0f)
				{
					return _range;
				}
				return _max - _min;
			}
			set
			{
				_range = value;
			}
		}

		public float RawValue
		{
			get
			{
				return _rawValue;
			}
			set
			{
				_rawValue = value;
			}
		}

		public float ConstrainedValue
		{
			get
			{
				if (_rawValue >= _min && _rawValue <= _max)
				{
					return _rawValue;
				}
				float num = ((!(_rawValue < _min)) ? (_rawValue - _max) : (_min - _rawValue));
				float num2 = num * 0.55f / Range;
				num2 += 1f;
				num2 = 1f / num2;
				num2 = 1f - num2;
				num2 *= Range;
				if (_rawValue < _min)
				{
					return _min - num2;
				}
				return _max + num2;
			}
		}

		public bool IsWithinConstraints
		{
			get
			{
				if (_rawValue >= _min)
				{
					return _rawValue <= _max;
				}
				return false;
			}
		}

		public bool IsSpringing => _springTime >= 0f;

		public InertialFloat(float springDuration, Easings.Functions springEasing)
		{
			Reset();
			_springDuration = springDuration;
			_springEasing = springEasing;
		}

		public void Reset()
		{
			_min = 0f;
			_max = 1f;
			_range = -1f;
		}

		public void Tick(float elapsedTime)
		{
			if (_springTime > 0f)
			{
				_springTime -= elapsedTime;
				float num = _rawValue;
				if (_springTarget == SpringTarget.Min)
				{
					num = _min;
				}
				else if (_springTarget == SpringTarget.Max)
				{
					num = _max;
				}
				else if (_springTarget == SpringTarget.Absolute)
				{
					num = SpringTargetAbsolute;
				}
				if (_springTime <= 0f)
				{
					_springTime = -1f;
					_rawValue = num;
				}
				else
				{
					_rawValue = _springOrigin + Easings.Interpolate((_springDuration - _springTime) / _springDuration, _springEasing) * (num - _springOrigin);
				}
			}
			if (!_resetVelocity)
			{
				float num2 = _rawValue - _previousRawValue;
				float num3 = 1f - Mathf.Exp((0f - elapsedTime) / 0.3f);
				AverageVelocity = num3 * num2 + (1f - num3) * AverageVelocity;
			}
			else
			{
				_resetVelocity = false;
			}
			_previousRawValue = _rawValue;
		}

		public void SpringBackToExtents()
		{
			if (_rawValue > _max)
			{
				_springTarget = SpringTarget.Max;
			}
			else
			{
				if (!(_rawValue < _min))
				{
					return;
				}
				_springTarget = SpringTarget.Min;
			}
			_springTime = _springDuration;
			_springOrigin = _rawValue;
		}

		public void SpringToMin()
		{
			_springTarget = SpringTarget.Min;
			_springTime = _springDuration;
			_springOrigin = _rawValue;
		}

		public void SpringTo(float target)
		{
			_springTarget = SpringTarget.Absolute;
			SpringTargetAbsolute = target;
			_springTime = _springDuration;
			_springOrigin = _rawValue;
		}

		public void Hold()
		{
			_springTarget = SpringTarget.None;
			_springTime = -1f;
			_resetVelocity = true;
			AverageVelocity = 0f;
		}

		public InertialFloat Clone()
		{
			return new InertialFloat(_springDuration, _springEasing)
			{
				_min = _min,
				_max = _max,
				_range = _range,
				_rawValue = _rawValue,
				AverageVelocity = AverageVelocity,
				_resetVelocity = _resetVelocity,
				_previousRawValue = _previousRawValue,
				_springTarget = _springTarget,
				SpringTargetAbsolute = SpringTargetAbsolute,
				_springTime = _springTime,
				_springOrigin = _springOrigin
			};
		}

		public override bool Equals(object obj)
		{
			if (typeof(InertialFloat).IsAssignableFrom(obj.GetType()))
			{
				InertialFloat inertialFloat = (InertialFloat)obj;
				if (Mathf.Approximately(_min, inertialFloat._min) && Mathf.Approximately(_max, inertialFloat._max) && Mathf.Approximately(_range, inertialFloat._range) && Mathf.Approximately(_rawValue, inertialFloat._rawValue) && Mathf.Approximately(AverageVelocity, inertialFloat.AverageVelocity) && _resetVelocity == inertialFloat._resetVelocity && Mathf.Approximately(_previousRawValue, inertialFloat._previousRawValue) && _springTarget == inertialFloat._springTarget && Mathf.Approximately(SpringTargetAbsolute, inertialFloat.SpringTargetAbsolute) && Mathf.Approximately(_springTime, inertialFloat._springTime) && Mathf.Approximately(_springOrigin, inertialFloat._springOrigin))
				{
					return Mathf.Approximately(_springDuration, inertialFloat._springDuration);
				}
				return false;
			}
			return false;
		}
	}
}
