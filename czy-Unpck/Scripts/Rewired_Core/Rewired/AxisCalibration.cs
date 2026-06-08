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
			AxisCalibrationInfo.TzWGDgfQGoivVvcRNkAJfRtpdAh(AxisCalibrationData.Default)
		} };

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		private bool _enabled = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		private float _deadZone;

		[CustomObfuscation(rename = false)]
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		private float _calibratedZero;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Gets or sets the minimum value. This can be used to transform the value to a new range.")]
		private float _calibratedMin;

		[Tooltip("Gets or sets the maximum value. This can be used to transform the value to a new range.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _calibratedMax;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the final value will be multiplied by -1. This can be used to correct an inverted Axis.")]
		private bool _invert;

		[Tooltip("Determines how sensitivity will be calculated.\nIf sensitivityType is set to Multiplier or Power, the sensitivity property is used to calculate the value.\nIf sensitivityType is set to Curve, the sensitivityCurve property is used to calculate the value.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AxisSensitivityType _sensitivityType;

		[SerializeField]
		[Tooltip("Gets or sets the sensitivity value.")]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _sensitivity;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Gets or sets the sensitivity curve. The curve has no effect unless sensitivityType is set to Curve.")]
		private AnimationCurve _sensitivityCurve;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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
				if (value == _calibrationMode)
				{
					while (true)
					{
						switch (0x214829B1 ^ 0x214829B0)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_calibrationMode = value;
				Reset();
			}
		}

		internal AxisCalibration()
		{
			CreateDefaultHardwareCalibration(GetData());
			Reset();
		}

		internal AxisCalibration(bool enabled, Dictionary<int, AxisCalibrationInfo> hardwareCalibrations, float deadZone, float calibratedZero, float calibratedMin, float calibratedMax, bool invert, bool applyRangeCalibration, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			while (true)
			{
				int num = 519680388;
				while (true)
				{
					switch (num ^ 0x1EF9B185)
					{
					case 3:
						break;
					case 1:
						_enabled = enabled;
						_deadZone = deadZone;
						_calibratedZero = calibratedZero;
						_calibratedMin = calibratedMin;
						num = 519680391;
						continue;
					case 2:
						_calibratedMax = calibratedMax;
						_invert = invert;
						_sensitivityType = sensitivityType;
						num = 519680389;
						continue;
					default:
						_sensitivity = sensitivity;
						_sensitivityCurve = sensitivityCurve;
						_applyRangeCalibration = applyRangeCalibration;
						InitHardwareCalibrations(hardwareCalibrations, GetData());
						Reset();
						return;
					}
					break;
				}
			}
		}

		internal AxisCalibration(AxisCalibrationData hardwareData)
		{
			_enabled = hardwareData.enabled;
			InitHardwareCalibrations(hardwareData.calibrations, hardwareData);
			Reset();
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
				if (copyHardwareData)
				{
					_hardwareCalibrations = MiscTools.DeepClone(data._hardwareCalibrations);
					num = 1650259957;
					goto IL_000c;
				}
				goto IL_00e7;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x625CF7F7)
					{
					case 0:
						num = 1650259958;
						continue;
					default:
						return;
					case 3:
						_deadZone = MathTools.Abs(data._deadZone);
						_calibratedZero = data._calibratedZero;
						_calibratedMin = data._calibratedMin;
						num = 1650259953;
						continue;
					case 5:
						_invert = data._invert;
						_applyRangeCalibration = data._applyRangeCalibration;
						_sensitivityType = data._sensitivityType;
						_sensitivity = data._sensitivity;
						_sensitivityCurve = UnityTools.Copy(data._sensitivityCurve);
						num = 1650259955;
						continue;
					case 1:
						break;
					case 6:
						_calibratedMax = data._calibratedMax;
						num = 1650259954;
						continue;
					case 2:
						goto IL_00e7;
					case 4:
						return;
					}
					break;
				}
				continue;
				IL_00e7:
				_enabled = data._enabled;
				num = 1650259956;
				goto IL_000c;
			}
		}

		public float GetCalibratedValue(float value)
		{
			return GetCalibratedValue(value, _deadZone, applySensitivity: true, applyInversion: true);
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
			return GetCalibratedValue(value, axisRange, _deadZone, applySensitivity: true, applyInversion: true);
		}

		internal float GetCalibratedValue(float value, AxisRange axisRange, float customDeadzone, bool applySensitivity, bool applyInversion)
		{
			if (!_enabled)
			{
				return 0f;
			}
			if (_applyRangeCalibration)
			{
				value = InputTools.GetCalibratedAxisValueClamped(value, _calibratedZero, _calibratedMin, _calibratedMax, customDeadzone, invert: false, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
				goto IL_0049;
			}
			goto IL_00e7;
			IL_00e7:
			value = InputTools.GetCalibratedAxisValue(value, customDeadzone, invert: false, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
			int num = 842616863;
			goto IL_004e;
			IL_004e:
			AxisRange axisRange2 = default(AxisRange);
			while (true)
			{
				switch (num ^ 0x3239501B)
				{
				case 0:
					break;
				case 4:
					axisRange2 = axisRange;
					num = 842616861;
					continue;
				case 7:
					goto IL_008b;
				case 3:
					goto IL_00a7;
				case 8:
					num = 842616863;
					continue;
				case 2:
					return 0f;
				case 1:
					goto IL_00e7;
				case 6:
					goto IL_011b;
				default:
					goto IL_0135;
				}
				break;
				IL_011b:
				switch (axisRange2)
				{
				case AxisRange.Positive:
					break;
				case AxisRange.Negative:
					goto IL_0099;
				default:
					goto IL_012b;
				}
				goto IL_008b;
				IL_012b:
				num = 842616856;
				continue;
				IL_0099:
				if (value > 0f)
				{
					return 0f;
				}
				goto IL_00a7;
				IL_00a7:
				if (MathTools.Approximately(value, 0f))
				{
					num = 842616857;
					continue;
				}
				if (applyInversion && _invert)
				{
					value *= -1f;
					num = 842616862;
					continue;
				}
				goto IL_0135;
				IL_008b:
				if (value < 0f)
				{
					return 0f;
				}
				goto IL_00a7;
				IL_0135:
				return value;
			}
			goto IL_0049;
			IL_0049:
			num = 842616851;
			goto IL_004e;
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
				int num = -1006755087;
				while (true)
				{
					switch (num ^ -1006755088)
					{
					case 2:
						break;
					case 1:
						goto IL_002b;
					default:
						_calibratedMax = data.max;
						_invert = data.invert;
						_applyRangeCalibration = data.applyRangeCalibration;
						_sensitivityType = data.sensitivityType;
						_sensitivity = data.sensitivity;
						_sensitivityCurve = data.sensitivityCurve;
						InitHardwareCalibrations(_hardwareCalibrations, data);
						return;
					}
					break;
					IL_002b:
					_deadZone = MathTools.Abs(data.deadZone);
					_calibratedZero = data.zero;
					_calibratedMin = data.min;
					num = -1006755088;
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
			goto IL_004d;
			IL_0011:
			int num = -753898985;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num ^ -753898986)
				{
				case 2:
					break;
				case 1:
					Logger.LogError("Hardware default calibration info was not found.");
					return;
				case 3:
					goto IL_004d;
				case 0:
					_calibratedMin = hardwareDefault.min;
					_calibratedMax = hardwareDefault.max;
					num = -753898989;
					continue;
				case 5:
					_invert = hardwareDefault.invert;
					num = -753898990;
					continue;
				default:
					_applyRangeCalibration = hardwareDefault.applyRangeCalibration;
					_sensitivityType = hardwareDefault.sensitivityType;
					_sensitivity = hardwareDefault.sensitivity;
					_sensitivityCurve = UnityTools.Copy(hardwareDefault.sensitivityCurve);
					return;
				}
				break;
			}
			goto IL_0011;
			IL_004d:
			_deadZone = hardwareDefault.deadZone;
			_calibratedZero = hardwareDefault.zero;
			num = -753898986;
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
				int num = 1063845552;
				while (true)
				{
					switch (num ^ 0x3F68FEB2)
					{
					case 0:
						break;
					case 2:
						serializedObject.Add("calibratedMin", _calibratedMin);
						serializedObject.Add("calibratedMax", _calibratedMax);
						num = 1063845553;
						continue;
					case 3:
						serializedObject.Add("invert", _invert);
						serializedObject.Add("sensitivity", _sensitivity);
						serializedObject.Add("applyRangeCalibration", _applyRangeCalibration);
						num = 1063845555;
						continue;
					default:
						serializedObject.Add("sensitivityType", _sensitivityType);
						serializedObject.Add("sensitivityCurve", _sensitivityCurve);
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
				goto IL_0006;
			}
			goto IL_011f;
			IL_0006:
			int num = 1199939368;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num ^ 0x47859F2D)
				{
				case 0:
					break;
				case 7:
					serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
					serializedObject.TryGetDeserializedValueByRef("deadZone", ref _deadZone);
					serializedObject.TryGetDeserializedValueByRef("calibratedZero", ref _calibratedZero);
					num = 1199939371;
					continue;
				case 2:
					serializedObject.TryGetDeserializedValueByRef("applyRangeCalibration", ref _applyRangeCalibration);
					num = 1199939369;
					continue;
				case 6:
					serializedObject.TryGetDeserializedValueByRef("calibratedMin", ref _calibratedMin);
					serializedObject.TryGetDeserializedValueByRef("calibratedMax", ref _calibratedMax);
					serializedObject.TryGetDeserializedValueByRef("invert", ref _invert);
					serializedObject.TryGetDeserializedValueByRef("sensitivity", ref _sensitivity);
					num = 1199939375;
					continue;
				case 5:
					return;
				case 4:
					serializedObject.TryGetDeserializedValueByRef("sensitivityType", ref _sensitivityType);
					serializedObject.TryGetDeserializedValueByRef("sensitivityCurve", ref _sensitivityCurve);
					num = 1199939374;
					continue;
				case 1:
					goto IL_011f;
				default:
					_deadZone = MathTools.Abs(_deadZone);
					return;
				}
				break;
			}
			goto IL_0006;
			IL_011f:
			Reset();
			num = 1199939370;
			goto IL_000b;
		}

		private void InitHardwareCalibrations(Dictionary<int, AxisCalibrationInfo> hardwareCalibrations, AxisCalibrationData defaultData)
		{
			_hardwareCalibrations.Clear();
			while (true)
			{
				int num = -342643873;
				while (true)
				{
					switch (num ^ -342643875)
					{
					case 0:
						break;
					case 2:
						if (hardwareCalibrations != null)
						{
							goto IL_002c;
						}
						goto IL_00a0;
					default:
						{
							using (Dictionary<int, AxisCalibrationInfo>.Enumerator enumerator = hardwareCalibrations.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									while (true)
									{
										KeyValuePair<int, AxisCalibrationInfo> current = enumerator.Current;
										_hardwareCalibrations.Add(current.Key, MiscTools.DeepClone(current.Value));
										int num2 = -342643875;
										while (true)
										{
											switch (num2 ^ -342643875)
											{
											case 2:
												num2 = -342643876;
												continue;
											case 1:
												break;
											default:
												goto end_IL_005a;
											}
											break;
										}
										continue;
										end_IL_005a:
										break;
									}
								}
							}
							goto IL_00a0;
						}
						IL_00a0:
						CreateDefaultHardwareCalibration(defaultData);
						return;
					}
					break;
					IL_002c:
					num = -342643876;
				}
			}
		}

		private void CreateDefaultHardwareCalibration(AxisCalibrationData defaultData)
		{
			if (_hardwareCalibrations.ContainsKey(0))
			{
				return;
			}
			AxisCalibrationInfo value = AxisCalibrationInfo.TzWGDgfQGoivVvcRNkAJfRtpdAh(defaultData);
			while (true)
			{
				int num = 1972442349;
				while (true)
				{
					switch (num ^ 0x759114EF)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0033;
					case 1:
						return;
					}
					break;
					IL_0033:
					_hardwareCalibrations.Add(0, value);
					num = 1972442350;
				}
			}
		}

		private AxisCalibrationInfo GetHardwareDefault()
		{
			AxisCalibrationInfo value = null;
			if (_calibrationMode == AlternateAxisCalibrationType.ThrottleZeroCenter)
			{
				while (true)
				{
					int num = 517924808;
					while (true)
					{
						switch (num ^ 0x1EDEE7CA)
						{
						case 0:
							break;
						case 2:
							goto IL_0029;
						default:
							goto IL_003d;
						}
						break;
						IL_003d:
						if (!_hardwareCalibrations.TryGetValue(1, out value))
						{
							goto end_IL_000b;
						}
						return value;
						IL_0029:
						if (ReInput.configVars.throttleCalibrationMode != ThrottleCalibrationMode.NegativeOneToOne)
						{
							goto end_IL_000b;
						}
						num = 517924811;
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			_hardwareCalibrations.TryGetValue(0, out value);
			return value;
		}

		internal static AxisCalibration CreateRelative()
		{
			AxisSensitivityType axisSensitivityType = (ReInput.isReady ? ReInput.configVars.defaultAxisSensitivityType : AxisSensitivityType.Multiplier);
			return new AxisCalibration(enabled: true, new Dictionary<int, AxisCalibrationInfo> { 
			{
				0,
				new AxisCalibrationInfo(0f, 0f, -1f, 1f, invert: false, applyRangeCalibration: false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f))
			} }, 0f, 0f, -1f, 1f, invert: false, applyRangeCalibration: false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f));
		}
	}
}
