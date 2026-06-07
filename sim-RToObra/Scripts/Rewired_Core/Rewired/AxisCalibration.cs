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
			AxisCalibrationInfo.BNYbzazGtsWWlyXpclpCOdPuKOD(AxisCalibrationData.Default)
		} };

		[SerializeField]
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[CustomObfuscation(rename = false)]
		private bool _enabled = true;

		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _deadZone;

		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _calibratedZero;

		[Tooltip("Gets or sets the minimum value. This can be used to transform the value to a new range.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _calibratedMin;

		[SerializeField]
		[Tooltip("Gets or sets the maximum value. This can be used to transform the value to a new range.")]
		[CustomObfuscation(rename = false)]
		private float _calibratedMax;

		[Tooltip("If true, the final value will be multiplied by -1. This can be used to correct an inverted Axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _invert;

		[SerializeField]
		[Tooltip("Determines how sensitivity will be calculated.\nIf sensitivityType is set to Multiplier or Power, the sensitivity property is used to calculate the value.\nIf sensitivityType is set to Curve, the sensitivityCurve property is used to calculate the value.")]
		[CustomObfuscation(rename = false)]
		private AxisSensitivityType _sensitivityType;

		[FieldRange(0f, float.PositiveInfinity)]
		[Tooltip("Gets or sets the sensitivity value.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _sensitivity;

		[Tooltip("Gets or sets the sensitivity curve. The curve has no effect unless sensitivityType is set to Curve.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AnimationCurve _sensitivityCurve;

		[Tooltip("If enabled, calibratedMin, calibratedMax, and calibratedZero will be used to convert the value to a new range.\nIf disabled, calibratedMin, calibratedMax, and calibratedZero will have no effect on the final value.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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
					return;
				}
				while (true)
				{
					_calibrationMode = value;
					int num = 780942781;
					while (true)
					{
						switch (num ^ 0x2E8C3DBD)
						{
						case 2:
							goto IL_000a;
						case 1:
							break;
						default:
							Reset();
							return;
						}
						break;
						IL_000a:
						num = 780942780;
					}
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
					num = -1483116327;
					goto IL_0009;
				}
				goto IL_006b;
				IL_0009:
				while (true)
				{
					switch (num ^ -1483116323)
					{
					case 3:
						num = -1483116321;
						continue;
					case 2:
						break;
					case 0:
						_calibratedMax = data._calibratedMax;
						_invert = data._invert;
						num = -1483116324;
						continue;
					case 4:
						goto IL_006b;
					case 1:
						_applyRangeCalibration = data._applyRangeCalibration;
						_sensitivityType = data._sensitivityType;
						_sensitivity = data._sensitivity;
						num = -1483116328;
						continue;
					default:
						_sensitivityCurve = UnityTools.Copy(data._sensitivityCurve);
						return;
					}
					break;
				}
				continue;
				IL_006b:
				_enabled = data._enabled;
				_deadZone = MathTools.Abs(data._deadZone);
				_calibratedZero = data._calibratedZero;
				_calibratedMin = data._calibratedMin;
				num = -1483116323;
				goto IL_0009;
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
				value = InputTools.GetCalibratedAxisValueClamped(value, _calibratedZero, _calibratedMin, _calibratedMax, customDeadzone, false, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
				goto IL_00b4;
			}
			goto IL_00f9;
			IL_00f9:
			value = InputTools.GetCalibratedAxisValue(value, customDeadzone, false, applySensitivity, _sensitivityType, _sensitivity, _sensitivityCurve);
			int num = -677338958;
			goto IL_0050;
			IL_0121:
			return value;
			IL_00b4:
			switch (axisRange)
			{
			case AxisRange.Positive:
				goto IL_00d9;
			case AxisRange.Negative:
				goto IL_00e7;
			}
			num = -677338957;
			goto IL_0050;
			IL_00e7:
			if (value > 0f)
			{
				num = -677338955;
				goto IL_0050;
			}
			goto IL_0082;
			IL_0082:
			if (MathTools.Approximately(value, 0f))
			{
				return 0f;
			}
			if (applyInversion && _invert)
			{
				value *= -1f;
				num = -677338953;
				goto IL_0050;
			}
			goto IL_0121;
			IL_00d9:
			if (value < 0f)
			{
				return 0f;
			}
			goto IL_0082;
			IL_0050:
			while (true)
			{
				switch (num ^ -677338953)
				{
				case 3:
					num = -677338954;
					continue;
				case 2:
					return 0f;
				case 4:
					break;
				case 5:
					goto IL_00b4;
				case 6:
					goto IL_00d9;
				case 1:
					goto IL_00f9;
				default:
					goto IL_0121;
				}
				break;
			}
			goto IL_0082;
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
			_deadZone = MathTools.Abs(data.deadZone);
			while (true)
			{
				int num = -198539006;
				while (true)
				{
					switch (num ^ -198539008)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						_applyRangeCalibration = data.applyRangeCalibration;
						_sensitivityType = data.sensitivityType;
						_sensitivity = data.sensitivity;
						_sensitivityCurve = data.sensitivityCurve;
						InitHardwareCalibrations(_hardwareCalibrations, data);
						num = -198539004;
						continue;
					case 3:
						_invert = data.invert;
						num = -198539007;
						continue;
					case 2:
						_calibratedZero = data.zero;
						_calibratedMin = data.min;
						_calibratedMax = data.max;
						num = -198539005;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public void Reset()
		{
			_enabled = true;
			AxisCalibrationInfo hardwareDefault = default(AxisCalibrationInfo);
			while (true)
			{
				int num = 727976788;
				while (true)
				{
					switch (num ^ 0x2B640B55)
					{
					case 3:
						break;
					default:
						return;
					case 2:
						_calibratedZero = hardwareDefault.zero;
						_calibratedMin = hardwareDefault.min;
						_calibratedMax = hardwareDefault.max;
						_invert = hardwareDefault.invert;
						_applyRangeCalibration = hardwareDefault.applyRangeCalibration;
						_sensitivityType = hardwareDefault.sensitivityType;
						_sensitivity = hardwareDefault.sensitivity;
						num = 727976789;
						continue;
					case 4:
						Logger.LogError("Hardware default calibration info was not found.");
						return;
					case 0:
						_sensitivityCurve = UnityTools.Copy(hardwareDefault.sensitivityCurve);
						num = 727976784;
						continue;
					case 1:
					{
						hardwareDefault = GetHardwareDefault();
						int num2;
						if (hardwareDefault == null)
						{
							num = 727976785;
							num2 = num;
						}
						else
						{
							num = 727976787;
							num2 = num;
						}
						continue;
					}
					case 6:
						_deadZone = hardwareDefault.deadZone;
						num = 727976791;
						continue;
					case 5:
						return;
					}
					break;
				}
			}
		}

		internal SerializedObject ExportData()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("enabled", _enabled);
			serializedObject.Add("deadZone", _deadZone);
			while (true)
			{
				int num = -1471726565;
				while (true)
				{
					switch (num ^ -1471726568)
					{
					case 5:
						break;
					case 2:
						serializedObject.Add("sensitivityCurve", _sensitivityCurve);
						num = -1471726568;
						continue;
					case 1:
						serializedObject.Add("sensitivityType", _sensitivityType);
						num = -1471726566;
						continue;
					case 4:
						serializedObject.Add("invert", _invert);
						serializedObject.Add("sensitivity", _sensitivity);
						serializedObject.Add("applyRangeCalibration", _applyRangeCalibration);
						num = -1471726567;
						continue;
					case 3:
						serializedObject.Add("calibratedZero", _calibratedZero);
						serializedObject.Add("calibratedMin", _calibratedMin);
						serializedObject.Add("calibratedMax", _calibratedMax);
						num = -1471726564;
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
				int num = -1722501577;
				while (true)
				{
					switch (num ^ -1722501579)
					{
					case 0:
						num = -1722501578;
						continue;
					case 3:
						break;
					case 2:
						serializedObject.TryGetDeserializedValueByRef("calibratedMax", ref _calibratedMax);
						num = -1722501583;
						continue;
					case 4:
						serializedObject.TryGetDeserializedValueByRef("invert", ref _invert);
						serializedObject.TryGetDeserializedValueByRef("sensitivity", ref _sensitivity);
						serializedObject.TryGetDeserializedValueByRef("applyRangeCalibration", ref _applyRangeCalibration);
						num = -1722501580;
						continue;
					default:
						serializedObject.TryGetDeserializedValueByRef("sensitivityType", ref _sensitivityType);
						serializedObject.TryGetDeserializedValueByRef("sensitivityCurve", ref _sensitivityCurve);
						_deadZone = MathTools.Abs(_deadZone);
						return;
					}
					break;
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
							_hardwareCalibrations.Add(current.Key, MiscTools.DeepClone(current.Value));
							int num = 1765608452;
							while (true)
							{
								switch (num ^ 0x693D0C04)
								{
								case 2:
									num = 1765608453;
									continue;
								case 1:
									break;
								default:
									goto end_IL_0035;
								}
								break;
							}
							continue;
							end_IL_0035:
							break;
						}
					}
				}
			}
			CreateDefaultHardwareCalibration(defaultData);
		}

		private void CreateDefaultHardwareCalibration(AxisCalibrationData defaultData)
		{
			if (_hardwareCalibrations.ContainsKey(0))
			{
				return;
			}
			AxisCalibrationInfo value = AxisCalibrationInfo.BNYbzazGtsWWlyXpclpCOdPuKOD(defaultData);
			while (true)
			{
				int num = 1806576327;
				while (true)
				{
					switch (num ^ 0x6BAE2AC6)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0033;
					case 0:
						return;
					}
					break;
					IL_0033:
					_hardwareCalibrations.Add(0, value);
					num = 1806576326;
				}
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
				new AxisCalibrationInfo(0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f))
			} }, 0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f));
		}
	}
}
