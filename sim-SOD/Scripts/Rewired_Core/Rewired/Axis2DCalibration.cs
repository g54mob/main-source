using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Axis2DCalibration
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The calculation type for the dead zone.")]
		private DeadZone2DType _deadZoneType;

		[Tooltip("Calculation type for sensitivity on 2D axes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AxisSensitivity2DType _sensitivityType;

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

		internal Axis2DCalibration()
		{
		}

		internal Vector2 GetCalibrated2DValue(float valueRawX, float valueRawY, AxisCalibration xAxis, AxisCalibration yAxis)
		{
			return default(Vector2);
		}

		internal static Vector2 GetCalibrated2DValue(float valueRawX, float valueRawY, AxisCalibration xAxis, AxisCalibration yAxis, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return default(Vector2);
		}
	}
}
