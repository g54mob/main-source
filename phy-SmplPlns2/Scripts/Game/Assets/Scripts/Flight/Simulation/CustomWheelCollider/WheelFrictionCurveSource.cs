using UnityEngine;

namespace Assets.Scripts.Flight.Simulation.CustomWheelCollider
{
	public class WheelFrictionCurveSource
	{
		private struct WheelFrictionCurvePoint
		{
			public Vector2 SlipForcePoint;

			public float TValue;
		}

		private int _arraySize;

		private WheelFrictionCurvePoint[] _asymptotePoints;

		private float _asymptoteSlip;

		private float _asymptoteValue;

		private WheelFrictionCurvePoint[] _extremePoints;

		private float _extremumSlip;

		private float _extremumValue;

		private float _stiffness;

		public float AsymptoteSlip
		{
			get
			{
				return _asymptoteSlip;
			}
			set
			{
				_asymptoteSlip = value;
				UpdateArrays();
			}
		}

		public float AsymptoteValue
		{
			get
			{
				return _asymptoteValue;
			}
			set
			{
				_asymptoteValue = value;
				UpdateArrays();
			}
		}

		public float ExtremumSlip
		{
			get
			{
				return _extremumSlip;
			}
			set
			{
				_extremumSlip = value;
				UpdateArrays();
			}
		}

		public float ExtremumValue
		{
			get
			{
				return _extremumValue;
			}
			set
			{
				_extremumValue = value;
				UpdateArrays();
			}
		}

		public float Stiffness
		{
			get
			{
				return _stiffness;
			}
			set
			{
				_stiffness = value;
			}
		}

		public WheelFrictionCurveSource(float extremumSlip, float extremumForce, float asymptoteSlip, float asymptoteForce)
		{
			_extremumSlip = extremumSlip;
			_extremumValue = extremumForce;
			_asymptoteSlip = asymptoteSlip;
			_asymptoteValue = asymptoteForce;
			_stiffness = 1f;
			_arraySize = 50;
			_extremePoints = new WheelFrictionCurvePoint[_arraySize];
			_asymptotePoints = new WheelFrictionCurvePoint[_arraySize];
			UpdateArrays();
		}

		public float Evaluate(float slip)
		{
			slip = Mathf.Abs(slip);
			if (slip < _extremumSlip)
			{
				return Evaluate(slip, _extremePoints) * _stiffness;
			}
			if (slip < _asymptoteSlip)
			{
				return Evaluate(slip, _asymptotePoints) * _stiffness;
			}
			return _asymptoteValue * _stiffness;
		}

		private static Vector2 Hermite(float t, Vector2 p0, Vector2 p1, Vector2 m0, Vector2 m1)
		{
			float num = t * t;
			float num2 = num * t;
			return (2f * num2 - 3f * num + 1f) * p0 + (num2 - 2f * num + t) * m0 + (-2f * num2 + 3f * num) * p1 + (num2 - num) * m1;
		}

		private float Evaluate(float slip, WheelFrictionCurvePoint[] curvePoints)
		{
			int num = _arraySize - 1;
			int num2 = 0;
			int num3 = (int)((float)(num + num2) * 0.5f);
			WheelFrictionCurvePoint wheelFrictionCurvePoint = curvePoints[num3];
			while (num != num2 && num - num2 > 1)
			{
				if (wheelFrictionCurvePoint.SlipForcePoint.x <= slip)
				{
					num2 = num3;
				}
				else if (wheelFrictionCurvePoint.SlipForcePoint.x >= slip)
				{
					num = num3;
				}
				num3 = (int)((float)(num + num2) * 0.5f);
				wheelFrictionCurvePoint = curvePoints[num3];
			}
			float x = curvePoints[num2].SlipForcePoint.x;
			float x2 = curvePoints[num].SlipForcePoint.x;
			float y = curvePoints[num2].SlipForcePoint.y;
			float y2 = curvePoints[num].SlipForcePoint.y;
			float num4 = (slip - x) / (x2 - x);
			return y * (1f - num4) + y2 * num4;
		}

		private void UpdateArrays()
		{
			for (int i = 0; i < _arraySize; i++)
			{
				_extremePoints[i].TValue = (float)i / (float)_arraySize;
				_extremePoints[i].SlipForcePoint = Hermite((float)i / (float)_arraySize, Vector2.zero, new Vector2(_extremumSlip, _extremumValue), Vector2.zero, new Vector2(_extremumSlip * 0.5f + 1f, 0f));
				_asymptotePoints[i].TValue = (float)i / (float)_arraySize;
				_asymptotePoints[i].SlipForcePoint = Hermite((float)i / (float)_arraySize, new Vector2(_extremumSlip, _extremumValue), new Vector2(_asymptoteSlip, _asymptoteValue), new Vector2((_asymptoteSlip - _extremumSlip) * 0.5f + 1f, 0f), new Vector2((_asymptoteSlip - _extremumSlip) * 0.5f + 1f, 0f));
			}
		}
	}
}
