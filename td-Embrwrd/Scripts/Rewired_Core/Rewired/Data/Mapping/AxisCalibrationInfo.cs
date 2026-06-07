using System;
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
		private float _sensitivity;

		[SerializeField]
		private AnimationCurve _sensitivityCurve;

		public bool applyRangeCalibration
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool invert
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float deadZone
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float upperDeadZone
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float zero
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float min
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float max
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AxisSensitivityType sensitivityType
		{
			get
			{
				return default(AxisSensitivityType);
			}
			set
			{
			}
		}

		public float sensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationCurve sensitivityCurve
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AxisCalibrationInfo()
		{
		}

		[CustomObfuscation(rename = false)]
		internal AxisCalibrationInfo(float P_0, float P_1, float P_2, float P_3, float P_4, bool P_5, bool P_6, AxisSensitivityType P_7, float P_8, AnimationCurve P_9)
		{
		}

		public object DeepClone()
		{
			return null;
		}

		internal static AxisCalibrationData jfsTBLxdowCncgWOQROpUueJDQvwA(AxisCalibrationInfo P_0)
		{
			return default(AxisCalibrationData);
		}

		internal static AxisCalibrationInfo tKDbfJffUYbFhdZCFVPbMSZQqFxYA(AxisCalibrationData P_0)
		{
			return null;
		}
	}
}
