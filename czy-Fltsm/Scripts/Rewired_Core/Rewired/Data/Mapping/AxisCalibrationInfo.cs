using System;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public class AxisCalibrationInfo : IDeepCloneable
	{
		[SerializeField]
		private bool _applyRangeCalibration;

		[SerializeField]
		private bool _invert;

		[SerializeField]
		private float _deadZone;

		[SerializeField]
		private float _upperDeadZone;

		[SerializeField]
		private float _zero;

		[SerializeField]
		private float _min;

		[SerializeField]
		private float _max;

		[SerializeField]
		private AxisSensitivityType _sensitivityType;

		[SerializeField]
		private float _sensitivity = 1f;

		[SerializeField]
		private AnimationCurve _sensitivityCurve;

		public bool applyRangeCalibration
		{
			get
			{
				return _applyRangeCalibration;
			}
			set
			{
				_applyRangeCalibration = value;
			}
		}

		public bool invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
			}
		}

		public float deadZone
		{
			get
			{
				return _deadZone;
			}
			set
			{
				_deadZone = value;
			}
		}

		public float upperDeadZone
		{
			get
			{
				return _upperDeadZone;
			}
			set
			{
				_upperDeadZone = value;
			}
		}

		public float zero
		{
			get
			{
				return _zero;
			}
			set
			{
				_zero = value;
			}
		}

		public float min
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

		public float max
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

		public AxisSensitivityType sensitivityType
		{
			get
			{
				return _sensitivityType;
			}
			set
			{
				_sensitivityType = value;
			}
		}

		public float sensitivity
		{
			get
			{
				return _sensitivity;
			}
			set
			{
				_sensitivity = value;
			}
		}

		public AnimationCurve sensitivityCurve
		{
			get
			{
				return _sensitivityCurve;
			}
			set
			{
				_sensitivityCurve = value;
			}
		}

		public AxisCalibrationInfo()
		{
		}

		[CustomObfuscation(rename = false)]
		internal AxisCalibrationInfo(float P_0, float P_1, float P_2, float P_3, float P_4, bool P_5, bool P_6, AxisSensitivityType P_7, float P_8, AnimationCurve P_9)
		{
			_deadZone = P_0;
			_upperDeadZone = P_1;
			_zero = P_2;
			_min = P_3;
			_max = P_4;
			_invert = P_5;
			_applyRangeCalibration = P_6;
			_sensitivityType = P_7;
			_sensitivity = P_8;
			_sensitivityCurve = P_9;
		}

		public object DeepClone()
		{
			return new AxisCalibrationInfo(_deadZone, _upperDeadZone, _zero, _min, _max, _invert, _applyRangeCalibration, _sensitivityType, _sensitivity, UnityTools.Copy(_sensitivityCurve));
		}

		object IDeepCloneable.DeepClone()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DeepClone
			return this.DeepClone();
		}

		internal static AxisCalibrationData hBOChnEummGFnQWcLdPwTYGRTsDw(AxisCalibrationInfo P_0)
		{
			if (P_0 == null)
			{
				return AxisCalibrationData.Default;
			}
			return new AxisCalibrationData(true, P_0._deadZone, P_0._upperDeadZone, P_0._zero, P_0._min, P_0._max, P_0._invert, P_0._applyRangeCalibration, P_0._sensitivityType, P_0._sensitivity, UnityTools.Copy(P_0._sensitivityCurve));
		}

		internal static AxisCalibrationInfo tSbZBjYJCYOnsPccOfYwbnjYglLnA(AxisCalibrationData P_0)
		{
			return new AxisCalibrationInfo(P_0.deadZone, P_0.upperDeadZone, P_0.zero, P_0.min, P_0.max, P_0.invert, P_0.applyRangeCalibration, P_0.sensitivityType, P_0.sensitivity, P_0.sensitivityCurve);
		}
	}
}
