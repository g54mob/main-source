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

		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _enabled;

		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _deadZone;

		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _calibratedZero;

		[Tooltip("Gets or sets the minimum value. This can be used to transform the value to a new range.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _calibratedMin;

		[Tooltip("Gets or sets the maximum value. This can be used to transform the value to a new range.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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
		[FieldRange(0f, 1f / 0f)]
		private float _sensitivity;

		[Tooltip("Gets or sets the sensitivity curve. The curve has no effect unless sensitivityType is set to Curve.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AnimationCurve _sensitivityCurve;

		[Tooltip("If enabled, calibratedMin, calibratedMax, and calibratedZero will be used to convert the value to a new range.\nIf disabled, calibratedMin, calibratedMax, and calibratedZero will have no effect on the final value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		internal AxisCalibration(bool P_0, Dictionary<int, AxisCalibrationInfo> P_1, float P_2, float P_3, float P_4, float P_5, bool P_6, bool P_7, AxisSensitivityType P_8, float P_9, AnimationCurve P_10)
		{
		}

		internal AxisCalibration(AxisCalibrationData P_0)
		{
		}

		internal void CopyFrom(AxisCalibration data, bool copyHardwareData)
		{
		}

		public float GetCalibratedValue(float value)
		{
			return 0f;
		}

		internal float GetCalibratedValue(float value, float customDeadzone, bool applySensitivity, bool applyInversion)
		{
			return 0f;
		}

		public float GetCalibratedValue(float value, AxisRange axisRange)
		{
			return 0f;
		}

		internal float GetCalibratedValue(float value, AxisRange axisRange, float customDeadzone, bool applySensitivity, bool applyInversion)
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
