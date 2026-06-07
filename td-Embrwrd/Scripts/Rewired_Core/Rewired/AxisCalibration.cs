using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class AxisCalibration
	{
		private AlternateAxisCalibrationType _calibrationMode;

		private Dictionary<int, AxisCalibrationInfo> _hardwareCalibrations;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		private bool _enabled;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Gets or sets the dead zone. If the Axis's absolute value is less than or equal to the dead zone, it will return 0.")]
		private float _deadZone;

		[CustomObfuscation(rename = false)]
		[Tooltip("Gets or sets the upper dead zone. If the Axis's absolute value is greater than or equal to extents minus the upper dead zone, it will return min/max.")]
		[SerializeField]
		private float _upperDeadZone;

		[SerializeField]
		[Tooltip("Gets or sets the zero value. This can be used to correct a non-zero resting state.")]
		[CustomObfuscation(rename = false)]
		private float _calibratedZero;

		[CustomObfuscation(rename = false)]
		[Tooltip("Gets or sets the minimum value. This can be used to transform the value to a new range.")]
		[SerializeField]
		private float _calibratedMin;

		[Tooltip("Gets or sets the maximum value. This can be used to transform the value to a new range.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _calibratedMax;

		[Tooltip("If true, the final value will be multiplied by -1. This can be used to correct an inverted Axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _invert;

		[Tooltip("Determines how sensitivity will be calculated.\nIf sensitivityType is set to Multiplier or Power, the sensitivity property is used to calculate the value.\nIf sensitivityType is set to Curve, the sensitivityCurve property is used to calculate the value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisSensitivityType _sensitivityType;

		[Tooltip("Gets or sets the sensitivity value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _sensitivity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Gets or sets the sensitivity curve. The curve has no effect unless sensitivityType is set to Curve.")]
		private AnimationCurve _sensitivityCurve;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, calibratedMin, calibratedMax, and calibratedZero will be used to convert the value to a new range.\nIf disabled, calibratedMin, calibratedMax, and calibratedZero will have no effect on the final value.")]
		private bool _applyRangeCalibration;

		public bool enabled
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

		public float calibratedZero
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float calibratedMin
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float calibratedMax
		{
			get
			{
				return 0f;
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

		internal AlternateAxisCalibrationType calibrationMode
		{
			get
			{
				return default(AlternateAxisCalibrationType);
			}
			set
			{
			}
		}

		internal AxisCalibration()
		{
		}

		internal AxisCalibration(bool P_0, Dictionary<int, AxisCalibrationInfo> P_1, float P_2, float P_3, float P_4, float P_5, float P_6, bool P_7, bool P_8, AxisSensitivityType P_9, float P_10, AnimationCurve P_11)
		{
		}

		internal AxisCalibration(AxisCalibrationData P_0)
		{
		}

		internal void CopyFrom(AxisCalibration data, bool copyHardwareData)
		{
		}

		internal void StoreDefaultValues()
		{
		}

		public float GetCalibratedValue(float value)
		{
			return 0f;
		}

		internal float GetCalibratedValue(float value, float customDeadzone, float customUpperDeadZone, bool applySensitivity, bool applyInversion)
		{
			return 0f;
		}

		public float GetCalibratedValue(float value, AxisRange axisRange)
		{
			return 0f;
		}

		internal float GetCalibratedValue(float value, AxisRange axisRange, float customDeadzone, float customUpperDeadZone, bool applySensitivity, bool applyInversion)
		{
			return 0f;
		}

		public AxisCalibrationData GetData()
		{
			return default(AxisCalibrationData);
		}

		public void SetData(AxisCalibrationData data)
		{
		}

		public void Reset()
		{
		}

		internal SerializedObject ExportData()
		{
			return null;
		}

		internal void Import(SerializedObject serializedObject)
		{
		}

		private void InitHardwareCalibrations(Dictionary<int, AxisCalibrationInfo> hardwareCalibrations, AxisCalibrationData defaultData)
		{
		}

		private void CreateDefaultHardwareCalibration(AxisCalibrationData defaultData)
		{
		}

		private AxisCalibrationInfo GetHardwareDefault()
		{
			return null;
		}

		internal static AxisCalibration CreateRelative()
		{
			return null;
		}
	}
}
