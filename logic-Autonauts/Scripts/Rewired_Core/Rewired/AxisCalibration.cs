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
			AxisCalibrationInfo.evMoibFVbyhNUKCcQxvEfTTeRgY(AxisCalibrationData.Default)
		} };

		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _enabled = true;

		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _deadZone;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		private float _calibratedZero;

		[CustomObfuscation(rename = false)]
		[Tooltip("Gets or sets the minimum value. This can be used to transform the value to a new range.")]
		[SerializeField]
		private float _calibratedMin;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Gets or sets the maximum value. This can be used to transform the value to a new range.")]
		private float _calibratedMax;

		[Tooltip("If true, the final value will be multiplied by -1. This can be used to correct an inverted Axis.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _invert;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Determines how sensitivity will be calculated.\nIf sensitivityType is set to Multiplier or Power, the sensitivity property is used to calculate the value.\nIf sensitivityType is set to Curve, the sensitivityCurve property is used to calculate the value.")]
		private AxisSensitivityType _sensitivityType;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		[SerializeField]
		[Tooltip("Gets or sets the sensitivity value.")]
		private float _sensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Gets or sets the sensitivity curve. The curve has no effect unless sensitivityType is set to Curve.")]
		private AnimationCurve _sensitivityCurve;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, calibratedMin, calibratedMax, and calibratedZero will be used to convert the value to a new range.\nIf disabled, calibratedMin, calibratedMax, and calibratedZero will have no effect on the final value.")]
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
			CreateDefaultHardwareCalibration(GetData());
			Reset();
		}

		internal AxisCalibration(bool enabled, Dictionary<int, AxisCalibrationInfo> hardwareCalibrations, float deadZone, float calibratedZero, float calibratedMin, float calibratedMax, bool invert, bool applyRangeCalibration, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			_enabled = enabled;
			_deadZone = deadZone;
			_calibratedZero = calibratedZero;
			_calibratedMin = calibratedMin;
			_calibratedMax = calibratedMax;
			_invert = invert;
			_sensitivityType = sensitivityType;
			_sensitivity = sensitivity;
			_sensitivityCurve = sensitivityCurve;
			_applyRangeCalibration = applyRangeCalibration;
			InitHardwareCalibrations(hardwareCalibrations, GetData());
			Reset();
		}

		internal AxisCalibration(AxisCalibrationData hardwareData)
		{
			while (true)
			{
				int num = 1705550166;
				while (true)
				{
					switch (num ^ 0x65A8A154)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0050;
					case 1:
						return;
					}
					break;
					IL_0050:
					_enabled = hardwareData.enabled;
					InitHardwareCalibrations(hardwareData.calibrations, hardwareData);
					Reset();
					num = 1705550165;
				}
			}
		}

		internal void CopyFrom(AxisCalibration data, bool copyHardwareData)
		{
			if (data == null)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (copyHardwareData)
				{
					num = -1719291156;
					num2 = num;
				}
				else
				{
					num = -1719291159;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1719291160)
					{
					case 0:
						num = -1719291155;
						continue;
					case 5:
						break;
					case 1:
						_enabled = data._enabled;
						_deadZone = MathTools.Abs(data._deadZone);
						num = -1719291158;
						continue;
					case 6:
						_calibratedMax = data._calibratedMax;
						_invert = data._invert;
						num = -1719291157;
						continue;
					case 4:
						_hardwareCalibrations = MiscTools.DeepClone(data._hardwareCalibrations);
						num = -1719291159;
						continue;
					case 2:
						_calibratedZero = data._calibratedZero;
						_calibratedMin = data._calibratedMin;
						num = -1719291154;
						continue;
					default:
						_applyRangeCalibration = data._applyRangeCalibration;
						_sensitivityType = data._sensitivityType;
						_sensitivity = data._sensitivity;
						_sensitivityCurve = UnityTools.Copy(data._sensitivityCurve);
						return;
					}
					break;
				}
			}
		}

		public float GetCalibratedValue(float value)
		{
			return GetCalibratedValue(value, _deadZone, true, true);
		}

		internal float GetCalibratedValue(float value, float customDeadzone, bool applySensitivity, bool applyInversion)
		{
			if (!_enabled)
			{
				return 0f;
			}
			if (_applyRangeCalibration)
			{
				return InputTools.GetCalibratedAxisValueClamped(value, _calibratedZero, _calibratedMin, _calibratedMax, customDeadzone, applyInversion && _invert, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
			}
			return InputTools.GetCalibratedAxisValue(value, customDeadzone, applyInversion && _invert, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
		}

		public float GetCalibratedValue(float value, AxisRange axisRange)
		{
			return GetCalibratedValue(value, axisRange, _deadZone, true, true);
		}

		internal float GetCalibratedValue(float value, AxisRange axisRange, float customDeadzone, bool applySensitivity, bool applyInversion)
		{
			if (!_enabled)
			{
				return 0f;
			}
			if (_applyRangeCalibration)
			{
				goto IL_0019;
			}
			goto IL_00c3;
			IL_00c3:
			value = InputTools.GetCalibratedAxisValue(value, customDeadzone, false, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
			int num = -1631467976;
			goto IL_001e;
			IL_0019:
			num = -1631467974;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -1631467975)
				{
				case 4:
					break;
				case 2:
					return 0f;
				case 1:
					goto IL_0085;
				case 6:
					goto IL_00a3;
				case 0:
					goto IL_00c3;
				case 3:
					value = InputTools.GetCalibratedAxisValueClamped(value, _calibratedZero, _calibratedMin, _calibratedMax, customDeadzone, false, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
					num = -1631467976;
					continue;
				default:
					goto IL_0125;
				}
				break;
				IL_0085:
				switch (axisRange)
				{
				case AxisRange.Positive:
					goto IL_00a3;
				case AxisRange.Negative:
					goto IL_00b1;
				}
				goto IL_0050;
				IL_00b1:
				if (value > 0f)
				{
					num = -1631467973;
					continue;
				}
				goto IL_0050;
				IL_0050:
				if (MathTools.Approximately(value, 0f))
				{
					return 0f;
				}
				if (applyInversion && _invert)
				{
					value *= -1f;
					num = -1631467972;
					continue;
				}
				goto IL_0125;
				IL_00a3:
				if (value < 0f)
				{
					return 0f;
				}
				goto IL_0050;
				IL_0125:
				return value;
			}
			goto IL_0019;
		}

		public AxisCalibrationData GetData()
		{
			AxisCalibrationData result = new AxisCalibrationData(_enabled, _deadZone, _calibratedZero, _calibratedMin, _calibratedMax, _invert, _applyRangeCalibration, _sensitivityType, _sensitivity, _sensitivityCurve);
			result.calibrations = MiscTools.DeepClone(_hardwareCalibrations);
			return result;
		}

		public void SetData(AxisCalibrationData data)
		{
			_enabled = data.enabled;
			while (true)
			{
				int num = -2123668124;
				while (true)
				{
					switch (num ^ -2123668123)
					{
					case 2:
						break;
					case 1:
						_deadZone = MathTools.Abs(data.deadZone);
						num = -2123668123;
						continue;
					case 3:
						_invert = data.invert;
						_applyRangeCalibration = data.applyRangeCalibration;
						_sensitivityType = data.sensitivityType;
						_sensitivity = data.sensitivity;
						num = -2123668127;
						continue;
					case 0:
						_calibratedZero = data.zero;
						num = -2123668128;
						continue;
					case 5:
						_calibratedMin = data.min;
						_calibratedMax = data.max;
						num = -2123668122;
						continue;
					default:
						_sensitivityCurve = data.sensitivityCurve;
						InitHardwareCalibrations(_hardwareCalibrations, data);
						return;
					}
					break;
				}
			}
		}

		public void Reset()
		{
			_enabled = true;
			AxisCalibrationInfo hardwareDefault = GetHardwareDefault();
			if (hardwareDefault == null)
			{
				goto IL_0011;
			}
			goto IL_0045;
			IL_0011:
			int num = -1422715613;
			goto IL_0016;
			IL_0016:
			switch (num ^ -1422715614)
			{
			case 3:
				break;
			case 1:
				Logger.LogError("Hardware default calibration info was not found.");
				return;
			case 0:
				goto IL_0045;
			default:
				_sensitivity = hardwareDefault.sensitivity;
				_sensitivityCurve = UnityTools.Copy(hardwareDefault.sensitivityCurve);
				return;
			}
			goto IL_0011;
			IL_0045:
			_deadZone = hardwareDefault.deadZone;
			_calibratedZero = hardwareDefault.zero;
			_calibratedMin = hardwareDefault.min;
			_calibratedMax = hardwareDefault.max;
			_invert = hardwareDefault.invert;
			_applyRangeCalibration = hardwareDefault.applyRangeCalibration;
			_sensitivityType = hardwareDefault.sensitivityType;
			num = -1422715616;
			goto IL_0016;
		}

		internal SerializedObject ExportData()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("enabled", _enabled);
			serializedObject.Add("deadZone", _deadZone);
			serializedObject.Add("calibratedZero", _calibratedZero);
			while (true)
			{
				int num = 1927002391;
				while (true)
				{
					switch (num ^ 0x72DBB913)
					{
					case 5:
						break;
					case 2:
						serializedObject.Add("sensitivityType", _sensitivityType);
						serializedObject.Add("sensitivityCurve", _sensitivityCurve);
						num = 1927002389;
						continue;
					case 3:
						serializedObject.Add("calibratedMax", _calibratedMax);
						num = 1927002387;
						continue;
					case 0:
						serializedObject.Add("invert", _invert);
						serializedObject.Add("sensitivity", _sensitivity);
						num = 1927002386;
						continue;
					case 4:
						serializedObject.Add("calibratedMin", _calibratedMin);
						num = 1927002384;
						continue;
					case 1:
						serializedObject.Add("applyRangeCalibration", _applyRangeCalibration);
						num = 1927002385;
						continue;
					default:
						return serializedObject;
					}
					break;
				}
			}
		}

		internal void Import(SerializedObject serializedObject)
		{
			if (serializedObject == null)
			{
				return;
			}
			while (true)
			{
				Reset();
				serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
				serializedObject.TryGetDeserializedValueByRef("deadZone", ref _deadZone);
				serializedObject.TryGetDeserializedValueByRef("calibratedZero", ref _calibratedZero);
				serializedObject.TryGetDeserializedValueByRef("calibratedMin", ref _calibratedMin);
				serializedObject.TryGetDeserializedValueByRef("calibratedMax", ref _calibratedMax);
				serializedObject.TryGetDeserializedValueByRef("invert", ref _invert);
				serializedObject.TryGetDeserializedValueByRef("sensitivity", ref _sensitivity);
				serializedObject.TryGetDeserializedValueByRef("applyRangeCalibration", ref _applyRangeCalibration);
				int num = 967258442;
				while (true)
				{
					switch (num ^ 0x39A7314B)
					{
					case 0:
						goto IL_0004;
					case 2:
						break;
					default:
						serializedObject.TryGetDeserializedValueByRef("sensitivityType", ref _sensitivityType);
						serializedObject.TryGetDeserializedValueByRef("sensitivityCurve", ref _sensitivityCurve);
						_deadZone = MathTools.Abs(_deadZone);
						return;
					}
					break;
					IL_0004:
					num = 967258441;
				}
			}
		}

		private void InitHardwareCalibrations(Dictionary<int, AxisCalibrationInfo> hardwareCalibrations, AxisCalibrationData defaultData)
		{
			_hardwareCalibrations.Clear();
			if (hardwareCalibrations != null)
			{
				using (Dictionary<int, AxisCalibrationInfo>.Enumerator enumerator = hardwareCalibrations.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							KeyValuePair<int, AxisCalibrationInfo> current = enumerator.Current;
							int num = -943735113;
							while (true)
							{
								switch (num ^ -943735115)
								{
								case 3:
									num = -943735116;
									continue;
								case 1:
									break;
								case 2:
									_hardwareCalibrations.Add(current.Key, MiscTools.DeepClone(current.Value));
									num = -943735115;
									continue;
								default:
									goto end_IL_0039;
								}
								break;
							}
							continue;
							end_IL_0039:
							break;
						}
					}
				}
			}
			CreateDefaultHardwareCalibration(defaultData);
		}

		private void CreateDefaultHardwareCalibration(AxisCalibrationData defaultData)
		{
			if (!_hardwareCalibrations.ContainsKey(0))
			{
				AxisCalibrationInfo value = AxisCalibrationInfo.evMoibFVbyhNUKCcQxvEfTTeRgY(defaultData);
				_hardwareCalibrations.Add(0, value);
			}
		}

		private AxisCalibrationInfo GetHardwareDefault()
		{
			AxisCalibrationInfo value = null;
			while (true)
			{
				int num = -641450690;
				while (true)
				{
					switch (num ^ -641450692)
					{
					case 0:
						break;
					case 2:
						if (_calibrationMode == AlternateAxisCalibrationType.ThrottleZeroCenter && ReInput.configVars.throttleCalibrationMode == ThrottleCalibrationMode.NegativeOneToOne && _hardwareCalibrations.TryGetValue(1, out value))
						{
							num = -641450689;
							continue;
						}
						_hardwareCalibrations.TryGetValue(0, out value);
						num = -641450691;
						continue;
					case 3:
						return value;
					default:
						return value;
					}
					break;
				}
			}
		}

		internal static AxisCalibration CreateRelative()
		{
			AxisSensitivityType axisSensitivityType = (ReInput.isReady ? ReInput.configVars.defaultAxisSensitivityType : AxisSensitivityType.Multiplier);
			return new AxisCalibration(true, new Dictionary<int, AxisCalibrationInfo> { 
			{
				0,
				new AxisCalibrationInfo(0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f))
			} }, 0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f));
		}
	}
}
