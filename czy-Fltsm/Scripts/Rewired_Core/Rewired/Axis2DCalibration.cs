using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Axis2DCalibration
	{
		[Tooltip("The calculation type for the dead zone.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private DeadZone2DType _deadZoneType = DeadZone2DType.Radial;

		[Tooltip("Calculation type for sensitivity on 2D axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisSensitivity2DType _sensitivityType;

		[Tooltip("Clamp type.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Axis2DClampType _clampType;

		[NonSerialized]
		private Axis2DCalibrationData _hardwareCalibration;

		public DeadZone2DType deadZoneType
		{
			get
			{
				if (_deadZoneType == (DeadZone2DType)(-1))
				{
					if (!ReInput.isReady)
					{
						return DeadZone2DType.Radial;
					}
					return ReInput.configuration.defaultJoystickAxis2DDeadZoneType;
				}
				return _deadZoneType;
			}
			set
			{
				_deadZoneType = value;
			}
		}

		public AxisSensitivity2DType sensitivityType
		{
			get
			{
				if (_sensitivityType == (AxisSensitivity2DType)(-1))
				{
					if (!ReInput.isReady)
					{
						return AxisSensitivity2DType.Radial;
					}
					return ReInput.configuration.defaultJoystickAxis2DSensitivityType;
				}
				return _sensitivityType;
			}
			set
			{
				_sensitivityType = value;
			}
		}

		public Axis2DClampType clampType
		{
			get
			{
				return _clampType;
			}
			set
			{
				_clampType = value;
			}
		}

		internal Axis2DCalibration()
		{
			StoreDefaultValues();
		}

		internal Axis2DCalibration(Axis2DCalibrationData P_0)
		{
			_deadZoneType = P_0.deadZoneType;
			_sensitivityType = P_0.sensitivityType;
			_clampType = P_0.clampType;
			StoreDefaultValues();
		}

		public Axis2DCalibrationData GetData()
		{
			return new Axis2DCalibrationData(_deadZoneType, _sensitivityType, _clampType);
		}

		public void SetData(Axis2DCalibrationData data)
		{
			_deadZoneType = data.deadZoneType;
			_sensitivityType = data.sensitivityType;
			_clampType = data.clampType;
		}

		public void Reset()
		{
			_deadZoneType = _hardwareCalibration.deadZoneType;
			_sensitivityType = _hardwareCalibration.sensitivityType;
			_clampType = _hardwareCalibration.clampType;
		}

		internal void CopyFrom(Axis2DCalibration data, bool copyHardwareData)
		{
			if (data != null)
			{
				if (copyHardwareData)
				{
					_hardwareCalibration = data._hardwareCalibration;
				}
				_deadZoneType = data._deadZoneType;
				_sensitivityType = data._sensitivityType;
				_clampType = data._clampType;
			}
		}

		internal void StoreDefaultValues()
		{
			_hardwareCalibration = GetData();
		}

		internal SerializedObject ExportData()
		{
			return new SerializedObject(GetType(), SerializedObject.ObjectType.Object)
			{
				{ "deadZoneType", _deadZoneType },
				{ "sensitivityType", _sensitivityType },
				{ "clampType", _clampType }
			};
		}

		internal void Import(SerializedObject serializedObject)
		{
			if (serializedObject != null)
			{
				Reset();
				serializedObject.TryGetDeserializedValueByRef("deadZoneType", ref _deadZoneType);
				serializedObject.TryGetDeserializedValueByRef("sensitivityType", ref _sensitivityType);
				serializedObject.TryGetDeserializedValueByRef("clampType", ref _clampType);
			}
		}

		internal static Vector2 GetCalibratedValue(Axis2DCalibration calibration2d, AxisCalibration xAxis, AxisCalibration yAxis, float valueRawX, float valueRawY)
		{
			if (calibration2d == null)
			{
				return new Vector2(valueRawX, valueRawY);
			}
			Vector2 value = default(Vector2);
			bool flag = xAxis != null;
			bool flag2 = yAxis != null;
			switch (calibration2d.deadZoneType)
			{
			case DeadZone2DType.Axial:
				if (calibration2d.clampType == Axis2DClampType.Radial)
				{
					Vector2 vector = default(Vector2);
					Vector2 vector2 = default(Vector2);
					if (flag)
					{
						vector.x = xAxis.deadZone;
						vector2.x = xAxis.upperDeadZone;
					}
					if (flag2)
					{
						vector.y = yAxis.deadZone;
						vector2.y = yAxis.upperDeadZone;
					}
					if (vector.x > 0f)
					{
						vector2.x += vector.x * 0.4f;
					}
					if (vector.y > 0f)
					{
						vector2.y += vector.y * 0.4f;
					}
					value.x = (flag ? xAxis.GetCalibratedValue(valueRawX, vector.x, vector2.x, applySensitivity: false, applyInversion: false) : valueRawX);
					value.y = (flag2 ? yAxis.GetCalibratedValue(valueRawY, vector.y, vector2.y, applySensitivity: false, applyInversion: false) : valueRawY);
				}
				else
				{
					value.x = (flag ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, xAxis.upperDeadZone, applySensitivity: false, applyInversion: false) : valueRawX);
					value.y = (flag2 ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, yAxis.upperDeadZone, applySensitivity: false, applyInversion: false) : valueRawY);
				}
				break;
			case DeadZone2DType.Radial:
			{
				float lowerDeadzone = (flag ? xAxis.deadZone : (flag2 ? yAxis.deadZone : 0f));
				float num = (flag ? xAxis.upperDeadZone : (flag2 ? yAxis.upperDeadZone : 0f));
				value.x = (flag ? InputTools.TransformAxis2DComponentValue(valueRawX, xAxis.calibratedZero, xAxis.calibratedMin, xAxis.calibratedMax, 0f, -1f, 1f, clamp: false) : valueRawX);
				value.y = (flag2 ? InputTools.TransformAxis2DComponentValue(valueRawY, yAxis.calibratedZero, yAxis.calibratedMin, yAxis.calibratedMax, 0f, -1f, 1f, clamp: false) : valueRawY);
				value = InputTools.ApplyRadialDeadZone(value.x, value.y, lowerDeadzone, num, 1f, (num > 0f) ? InputTools.ClampAxis2D.RadialNormal : InputTools.ClampAxis2D.None);
				break;
			}
			default:
				throw new NotImplementedException();
			}
			switch (calibration2d.sensitivityType)
			{
			case AxisSensitivity2DType.Axial:
				if (flag)
				{
					value.x = InputTools.ApplySensitivity(value.x, xAxis.sensitivityType, xAxis.sensitivity, xAxis.sensitivityCurve);
				}
				if (flag2)
				{
					value.y = InputTools.ApplySensitivity(value.y, yAxis.sensitivityType, yAxis.sensitivity, yAxis.sensitivityCurve);
				}
				break;
			case AxisSensitivity2DType.Radial:
			{
				AxisCalibration axisCalibration = (flag ? xAxis : yAxis);
				if (axisCalibration != null)
				{
					InputTools.ApplyRadialSensitivity(ref value, axisCalibration.sensitivityType, axisCalibration.sensitivity, axisCalibration.sensitivityCurve);
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
			Axis2DClampType axis2DClampType = ((!ReInput.configuration.disableAxis2dClamping) ? calibration2d.clampType : Axis2DClampType.None);
			switch (axis2DClampType)
			{
			case Axis2DClampType.None:
			case Axis2DClampType.Axial:
				if ((flag && xAxis.applyRangeCalibration) || axis2DClampType == Axis2DClampType.Axial)
				{
					if (value.x > 0f)
					{
						if (value.x > 1f || 1f - value.x <= 0.001f)
						{
							value.x = 1f;
						}
					}
					else if (value.x < 0f && (value.x < -1f || value.x + 1f <= 0.001f))
					{
						value.x = -1f;
					}
				}
				if ((!flag2 || !yAxis.applyRangeCalibration) && axis2DClampType != Axis2DClampType.Axial)
				{
					break;
				}
				if (value.y > 0f)
				{
					if (value.y > 1f || 1f - value.y <= 0.001f)
					{
						value.y = 1f;
					}
				}
				else if (value.y < 0f && (value.y < -1f || value.y + 1f <= 0.001f))
				{
					value.y = -1f;
				}
				break;
			case Axis2DClampType.Radial:
				if (value.sqrMagnitude > 1f)
				{
					value.Normalize();
				}
				break;
			default:
				throw new NotImplementedException();
			}
			if (flag && xAxis.invert)
			{
				value.x *= -1f;
			}
			if (flag2 && yAxis.invert)
			{
				value.y *= -1f;
			}
			return value;
		}
	}
}
