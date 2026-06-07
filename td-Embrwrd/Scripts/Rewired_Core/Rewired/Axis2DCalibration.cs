using System;
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
		private DeadZone2DType _deadZoneType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Calculation type for sensitivity on 2D axes.")]
		private AxisSensitivity2DType _sensitivityType;

		[CustomObfuscation(rename = false)]
		[Tooltip("Clamp type.")]
		[SerializeField]
		private Axis2DClampType _clampType;

		[NonSerialized]
		private Axis2DCalibrationData _hardwareCalibration;

		public DeadZone2DType deadZoneType
		{
			get
			{
				return default(DeadZone2DType);
			}
			set
			{
			}
		}

		public AxisSensitivity2DType sensitivityType
		{
			get
			{
				return default(AxisSensitivity2DType);
			}
			set
			{
			}
		}

		public Axis2DClampType clampType
		{
			get
			{
				return default(Axis2DClampType);
			}
			set
			{
			}
		}

		internal Axis2DCalibration()
		{
		}

		internal Axis2DCalibration(Axis2DCalibrationData P_0)
		{
		}

		public Axis2DCalibrationData GetData()
		{
			return default(Axis2DCalibrationData);
		}

		public void SetData(Axis2DCalibrationData data)
		{
		}

		public void Reset()
		{
		}

		internal void CopyFrom(Axis2DCalibration data, bool copyHardwareData)
		{
		}

		internal void StoreDefaultValues()
		{
		}

		internal SerializedObject ExportData()
		{
			return null;
		}

		internal void Import(SerializedObject serializedObject)
		{
		}

		internal static Vector2 GetCalibratedValue(Axis2DCalibration calibration2d, AxisCalibration xAxis, AxisCalibration yAxis, float valueRawX, float valueRawY)
		{
			return default(Vector2);
		}
	}
}
