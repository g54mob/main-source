using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils;
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

		private Dictionary<int, AxisCalibrationInfo> _hardwareCalibrations = new Dictionary<int, AxisCalibrationInfo> { 
		{
			0,
			AxisCalibrationInfo.tSbZBjYJCYOnsPccOfYwbnjYglLnA(AxisCalibrationData.Default)
		} };

		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _enabled = true;

		[Tooltip("Gets or sets the dead zone. If the Axis's absolute value is less than or equal to the dead zone, it will return 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _deadZone;

		[Tooltip("Gets or sets the upper dead zone. If the Axis's absolute value is greater than or equal to extents minus the upper dead zone, it will return min/max.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _upperDeadZone;

		[Tooltip("Gets or sets the zero value. This can be used to correct a non-zero resting state.")]
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
		[FieldRange(0f, float.PositiveInfinity)]
		private float _sensitivity;

		[Tooltip("Gets or sets the sensitivity curve. The curve has no effect unless sensitivityType is set to Curve.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AnimationCurve _sensitivityCurve;

		[Tooltip("If enabled, calibratedMin, calibratedMax, and calibratedZero will be used to convert the value to a new range.\nIf disabled, calibratedMin, calibratedMax, and calibratedZero will have no effect on the final value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _applyRangeCalibration = true;

		public bool enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
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
				_deadZone = MathTools.Abs(value);
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
				_upperDeadZone = MathTools.Abs(value);
			}
		}

		public float calibratedZero
		{
			get
			{
				return _calibratedZero;
			}
			set
			{
				_calibratedZero = value;
			}
		}

		public float calibratedMin
		{
			get
			{
				return _calibratedMin;
			}
			set
			{
				_calibratedMin = value;
			}
		}

		public float calibratedMax
		{
			get
			{
				return _calibratedMax;
			}
			set
			{
				_calibratedMax = value;
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

		internal AlternateAxisCalibrationType calibrationMode
		{
			get
			{
				return _calibrationMode;
			}
			set
			{
				if (value != _calibrationMode)
				{
					_calibrationMode = value;
					Reset();
				}
			}
		}

		internal AxisCalibration()
		{
			StoreDefaultValues();
			Reset();
		}

		internal AxisCalibration(bool P_0, Dictionary<int, AxisCalibrationInfo> P_1, float P_2, float P_3, float P_4, float P_5, float P_6, bool P_7, bool P_8, AxisSensitivityType P_9, float P_10, AnimationCurve P_11)
		{
			_enabled = P_0;
			_deadZone = P_2;
			_upperDeadZone = P_3;
			_calibratedZero = P_4;
			_calibratedMin = P_5;
			_calibratedMax = P_6;
			_invert = P_7;
			_sensitivityType = P_9;
			_sensitivity = P_10;
			_sensitivityCurve = P_11;
			_applyRangeCalibration = P_8;
			InitHardwareCalibrations(P_1, GetData());
			Reset();
		}

		internal AxisCalibration(AxisCalibrationData P_0)
		{
			_enabled = P_0.enabled;
			InitHardwareCalibrations(P_0.calibrations, P_0);
			Reset();
		}

		internal void CopyFrom(AxisCalibration data, bool copyHardwareData)
		{
			if (data != null)
			{
				if (copyHardwareData)
				{
					_hardwareCalibrations = MiscTools.DeepClone(data._hardwareCalibrations);
				}
				_enabled = data._enabled;
				_deadZone = MathTools.Abs(data._deadZone);
				_upperDeadZone = MathTools.Abs(data._upperDeadZone);
				_calibratedZero = data._calibratedZero;
				_calibratedMin = data._calibratedMin;
				_calibratedMax = data._calibratedMax;
				_invert = data._invert;
				_applyRangeCalibration = data._applyRangeCalibration;
				_sensitivityType = data._sensitivityType;
				_sensitivity = data._sensitivity;
				_sensitivityCurve = UnityTools.Copy(data._sensitivityCurve);
			}
		}

		internal void StoreDefaultValues()
		{
			CreateDefaultHardwareCalibration(GetData());
		}

		public float GetCalibratedValue(float value)
		{
			return GetCalibratedValue(value, _deadZone, _upperDeadZone, applySensitivity: true, applyInversion: true);
		}

		internal float GetCalibratedValue(float value, float customDeadzone, float customUpperDeadZone, bool applySensitivity, bool applyInversion)
		{
			if (!_enabled)
			{
				return 0f;
			}
			if (_applyRangeCalibration)
			{
				return InputTools.GetCalibratedAxisValueClamped(value, _calibratedZero, _calibratedMin, _calibratedMax, customDeadzone, customUpperDeadZone, applyInversion && _invert, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
			}
			return InputTools.GetCalibratedAxisValue(value, customDeadzone, applyInversion && _invert, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
		}

		public float GetCalibratedValue(float value, AxisRange axisRange)
		{
			return GetCalibratedValue(value, axisRange, _deadZone, _upperDeadZone, applySensitivity: true, applyInversion: true);
		}

		internal float GetCalibratedValue(float value, AxisRange axisRange, float customDeadzone, float customUpperDeadZone, bool applySensitivity, bool applyInversion)
		{
			if (!_enabled)
			{
				return 0f;
			}
			value = ((!_applyRangeCalibration) ? InputTools.GetCalibratedAxisValue(value, customDeadzone, invert: false, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve) : InputTools.GetCalibratedAxisValueClamped(value, _calibratedZero, _calibratedMin, _calibratedMax, customDeadzone, customUpperDeadZone, invert: false, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve));
			switch (axisRange)
			{
			case AxisRange.Positive:
				if (value < 0f)
				{
					return 0f;
				}
				break;
			case AxisRange.Negative:
				if (value > 0f)
				{
					return 0f;
				}
				break;
			}
			if (MathTools.Approximately(value, 0f))
			{
				return 0f;
			}
			if (applyInversion && _invert)
			{
				value *= -1f;
			}
			return value;
		}

		public AxisCalibrationData GetData()
		{
			AxisCalibrationData result = new AxisCalibrationData(_enabled, _deadZone, _upperDeadZone, _calibratedZero, _calibratedMin, _calibratedMax, _invert, _applyRangeCalibration, _sensitivityType, _sensitivity, _sensitivityCurve);
			result.calibrations = MiscTools.DeepClone(_hardwareCalibrations);
			return result;
		}

		public void SetData(AxisCalibrationData data)
		{
			_enabled = data.enabled;
			_deadZone = MathTools.Abs(data.deadZone);
			_upperDeadZone = MathTools.Abs(data.upperDeadZone);
			_calibratedZero = data.zero;
			_calibratedMin = data.min;
			_calibratedMax = data.max;
			_invert = data.invert;
			_applyRangeCalibration = data.applyRangeCalibration;
			_sensitivityType = data.sensitivityType;
			_sensitivity = data.sensitivity;
			_sensitivityCurve = data.sensitivityCurve;
		}

		public void Reset()
		{
			_enabled = true;
			AxisCalibrationInfo hardwareDefault = GetHardwareDefault();
			if (hardwareDefault == null)
			{
				Logger.LogError("Hardware default calibration info was not found.");
				return;
			}
			_deadZone = hardwareDefault.deadZone;
			_upperDeadZone = hardwareDefault.upperDeadZone;
			_calibratedZero = hardwareDefault.zero;
			_calibratedMin = hardwareDefault.min;
			_calibratedMax = hardwareDefault.max;
			_invert = hardwareDefault.invert;
			_applyRangeCalibration = hardwareDefault.applyRangeCalibration;
			_sensitivityType = hardwareDefault.sensitivityType;
			_sensitivity = hardwareDefault.sensitivity;
			_sensitivityCurve = UnityTools.Copy(hardwareDefault.sensitivityCurve);
		}

		internal SerializedObject ExportData()
		{
			return new SerializedObject(GetType(), SerializedObject.ObjectType.Object)
			{
				{ "enabled", _enabled },
				{ "deadZone", _deadZone },
				{ "upperDeadZone", _upperDeadZone },
				{ "calibratedZero", _calibratedZero },
				{ "calibratedMin", _calibratedMin },
				{ "calibratedMax", _calibratedMax },
				{ "invert", _invert },
				{ "sensitivity", _sensitivity },
				{ "applyRangeCalibration", _applyRangeCalibration },
				{ "sensitivityType", _sensitivityType },
				{ "sensitivityCurve", _sensitivityCurve }
			};
		}

		internal void Import(SerializedObject serializedObject)
		{
			if (serializedObject != null)
			{
				Reset();
				serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
				serializedObject.TryGetDeserializedValueByRef("deadZone", ref _deadZone);
				serializedObject.TryGetDeserializedValueByRef("upperDeadZone", ref _upperDeadZone);
				serializedObject.TryGetDeserializedValueByRef("calibratedZero", ref _calibratedZero);
				serializedObject.TryGetDeserializedValueByRef("calibratedMin", ref _calibratedMin);
				serializedObject.TryGetDeserializedValueByRef("calibratedMax", ref _calibratedMax);
				serializedObject.TryGetDeserializedValueByRef("invert", ref _invert);
				serializedObject.TryGetDeserializedValueByRef("sensitivity", ref _sensitivity);
				serializedObject.TryGetDeserializedValueByRef("applyRangeCalibration", ref _applyRangeCalibration);
				serializedObject.TryGetDeserializedValueByRef("sensitivityType", ref _sensitivityType);
				serializedObject.TryGetDeserializedValueByRef("sensitivityCurve", ref _sensitivityCurve);
				_deadZone = MathTools.Abs(_deadZone);
				_upperDeadZone = MathTools.Abs(_upperDeadZone);
			}
		}

		private void InitHardwareCalibrations(Dictionary<int, AxisCalibrationInfo> hardwareCalibrations, AxisCalibrationData defaultData)
		{
			_hardwareCalibrations.Clear();
			if (hardwareCalibrations != null)
			{
				foreach (KeyValuePair<int, AxisCalibrationInfo> hardwareCalibration in hardwareCalibrations)
				{
					_hardwareCalibrations.Add(hardwareCalibration.Key, MiscTools.DeepClone(hardwareCalibration.Value));
				}
			}
			CreateDefaultHardwareCalibration(defaultData);
		}

		private void CreateDefaultHardwareCalibration(AxisCalibrationData defaultData)
		{
			if (!_hardwareCalibrations.ContainsKey(0))
			{
				AxisCalibrationInfo value = AxisCalibrationInfo.tSbZBjYJCYOnsPccOfYwbnjYglLnA(defaultData);
				_hardwareCalibrations.Add(0, value);
			}
		}

		private AxisCalibrationInfo GetHardwareDefault()
		{
			AxisCalibrationInfo value = null;
			if (_calibrationMode == AlternateAxisCalibrationType.ThrottleZeroCenter && ReInput.configVars.throttleCalibrationMode == ThrottleCalibrationMode.NegativeOneToOne && _hardwareCalibrations.TryGetValue(1, out value))
			{
				return value;
			}
			_hardwareCalibrations.TryGetValue(0, out value);
			return value;
		}

		internal static AxisCalibration CreateRelative()
		{
			AxisSensitivityType axisSensitivityType = (ReInput.isReady ? ReInput.configVars.defaultAxisSensitivityType : AxisSensitivityType.Multiplier);
			return new AxisCalibration(true, new Dictionary<int, AxisCalibrationInfo> { 
			{
				0,
				new AxisCalibrationInfo(0f, 0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f))
			} }, 0f, 0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f));
		}
	}
}
