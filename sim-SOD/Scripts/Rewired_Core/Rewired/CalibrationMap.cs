using System.Collections.Generic;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CalibrationMap
	{
		private AxisCalibration[] jfSzAhoLMSSmYVeJnsaVjFknPkD;

		private IList<AxisCalibration> XButcNwMKjywabZeIUoPMjBRrbT;

		private readonly int RSGBQYfltigFuhDMRviugFIbvohH;

		public IList<AxisCalibration> Axes => null;

		public int axisCount => 0;

		private CalibrationMap()
		{
		}

		internal CalibrationMap(AxisCalibrationData[] hardwareAxisCalibrationData)
		{
		}

		public CalibrationMap(AxisCalibration[] axisCalibrations)
		{
		}

		public void Reset()
		{
		}

		public AxisCalibration GetAxis(int index)
		{
			return null;
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			return 0f;
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			return false;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			return default(AxisCalibrationData);
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
		}

		public string ToXmlString()
		{
			return null;
		}

		public string ToJsonString()
		{
			return null;
		}

		public bool ImportXmlString(string xmlString)
		{
			return false;
		}

		public bool ImportJsonString(string jsonString)
		{
			return false;
		}

		private SerializedObject IJTYgxRVETFGIEeOvEZXpvilyrI()
		{
			return null;
		}

		private void jygDICBMHaTDOHrItEJCbjkpEXhs(SerializedObject P_0)
		{
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return default(Vector2);
		}
	}
}
