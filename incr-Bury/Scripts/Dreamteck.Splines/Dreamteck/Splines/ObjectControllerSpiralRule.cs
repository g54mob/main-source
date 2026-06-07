using UnityEngine;

namespace Dreamteck.Splines
{
	[CreateAssetMenu(menuName = "Dreamteck/Splines/Object Controller Rules/Spiral Rule")]
	public class ObjectControllerSpiralRule : ObjectControllerCustomRuleBase
	{
		[SerializeField]
		private bool _useSplinePercent;

		[SerializeField]
		private float _revolve = 360f;

		[SerializeField]
		private Vector2 _startSize = Vector2.one;

		[SerializeField]
		private Vector2 _endSize = Vector2.one;

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

		public float revolve
		{
			get
			{
				return _revolve;
			}
			set
			{
				_revolve = value;
			}
		}

		public Vector2 startSize
		{
			get
			{
				return _startSize;
			}
			set
			{
				_startSize = value;
			}
		}

		public Vector2 endSize
		{
			get
			{
				return _endSize;
			}
			set
			{
				_endSize = value;
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
			Vector3 result = Quaternion.AngleAxis(_revolve * GetPercent(), Vector3.forward) * Vector3.up;
			Vector2 vector = Vector2.Lerp(_startSize, _endSize, GetPercent());
			result.x *= vector.x;
			result.y *= vector.y;
			return result;
		}

		public override Quaternion GetRotation()
		{
			return currentSample.rotation * Quaternion.AngleAxis(_revolve * (0f - GetPercent()), Vector3.forward);
		}

		private float GetPercent()
		{
			float num = (_useSplinePercent ? ((float)currentSample.percent) : (base.currentObjectPercent + _offset));
			if (num > 1f)
			{
				num -= (float)Mathf.FloorToInt(num);
			}
			if (num < 0f)
			{
				num += (float)Mathf.FloorToInt(0f - num);
			}
			return num;
		}
	}
}
