using System;
using UnityEngine;

namespace Dreamteck.Splines
{
	[CreateAssetMenu(menuName = "Dreamteck/Splines/Object Controller Rules/Sine Rule")]
	public class ObjectControllerSineRule : ObjectControllerCustomRuleBase
	{
		[SerializeField]
		private bool _useSplinePercent;

		[SerializeField]
		private float _frequency = 1f;

		[SerializeField]
		private float _amplitude = 1f;

		[SerializeField]
		private float _angle;

		[SerializeField]
		private float _minScale = 1f;

		[SerializeField]
		private float _maxScale = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _offset;

		public bool useSplinePercent
		{
			get
			{
				return _useSplinePercent;
			}
			set
			{
				_useSplinePercent = value;
			}
		}

		public float frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_frequency = value;
			}
		}

		public float amplitude
		{
			get
			{
				return _amplitude;
			}
			set
			{
				_amplitude = value;
			}
		}

		public float angle
		{
			get
			{
				return _angle;
			}
			set
			{
				_angle = value;
			}
		}

		public float minScale
		{
			get
			{
				return _minScale;
			}
			set
			{
				_minScale = value;
			}
		}

		public float maxScale
		{
			get
			{
				return _maxScale;
			}
			set
			{
				_maxScale = value;
			}
		}

		public float offset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
				if (_offset > 1f)
				{
					_offset -= Mathf.FloorToInt(_offset);
				}
				if (_offset < 0f)
				{
					_offset += Mathf.FloorToInt(0f - _offset);
				}
			}
		}

		public override Vector3 GetOffset()
		{
			float sine = GetSine();
			return Quaternion.AngleAxis(_angle, Vector3.forward) * Vector3.up * sine * _amplitude;
		}

		public override Vector3 GetScale()
		{
			return Vector3.Lerp(Vector3.one * _minScale, Vector3.one * _maxScale, GetSine());
		}

		private float GetSine()
		{
			float num = (_useSplinePercent ? ((float)currentSample.percent) : base.currentObjectPercent);
			return Mathf.Sin(MathF.PI * _offset + num * MathF.PI * _frequency);
		}
	}
}
