using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CalibrationMap
	{
		private AxisCalibration[] rEwCUWdrnAvHNmyWPMTQEZZqEeEa;

		private IList<AxisCalibration> FBKJfibtVxxAbEEtqRjQyiqYUeI;

		private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

		public IList<AxisCalibration> Axes => FBKJfibtVxxAbEEtqRjQyiqYUeI;

		public int axisCount
		{
			get
			{
				if (rEwCUWdrnAvHNmyWPMTQEZZqEeEa == null)
				{
					return 0;
				}
				return rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length;
			}
		}

		private CalibrationMap()
		{
			VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] hardwareAxisCalibrationData)
			: this()
		{
			int num = ((hardwareAxisCalibrationData != null) ? hardwareAxisCalibrationData.Length : 0);
			rEwCUWdrnAvHNmyWPMTQEZZqEeEa = new AxisCalibration[num];
			for (int i = 0; i < num; i++)
			{
				rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i] = new AxisCalibration(hardwareAxisCalibrationData[i]);
			}
			FBKJfibtVxxAbEEtqRjQyiqYUeI = new ReadOnlyCollection<AxisCalibration>(rEwCUWdrnAvHNmyWPMTQEZZqEeEa);
		}

		public CalibrationMap(AxisCalibration[] axisCalibrations)
			: this()
		{
			rEwCUWdrnAvHNmyWPMTQEZZqEeEa = axisCalibrations;
			FBKJfibtVxxAbEEtqRjQyiqYUeI = new ReadOnlyCollection<AxisCalibration>(rEwCUWdrnAvHNmyWPMTQEZZqEeEa);
		}

		public void Reset()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			for (int i = 0; i < rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length; i++)
			{
				rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (index < 0 || index >= rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length)
			{
				return null;
			}
			return rEwCUWdrnAvHNmyWPMTQEZZqEeEa[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length)
			{
				return value;
			}
			return rEwCUWdrnAvHNmyWPMTQEZZqEeEa[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (index < 0 || index >= rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length)
			{
				return false;
			}
			rEwCUWdrnAvHNmyWPMTQEZZqEeEa[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length)
			{
				return default(AxisCalibrationData);
			}
			return rEwCUWdrnAvHNmyWPMTQEZZqEeEa[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length != rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length; i++)
			{
				rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i].CopyFrom(map.rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return MtzBZMSurJCTTdjsBqkSRhDyHCFi().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return string.Empty;
			}
			try
			{
				return MtzBZMSurJCTTdjsBqkSRhDyHCFi().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject.FromXml(GetType(), xmlString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from XML! " + ex.Message);
			}
			return false;
		}

		public bool ImportJsonString(string jsonString)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject MtzBZMSurJCTTdjsBqkSRhDyHCFi()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				NSIraOohUuxbwNWwnOfcoaPLKLA = "dataVersion",
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				tpjeoHgHRUvvsMOVGUmfENOfWgb = "xmlns",
				NSIraOohUuxbwNWwnOfcoaPLKLA = "xsi",
				KyKFPbDbzyvJvQZYVoBMpXenzVYN = null,
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				tpjeoHgHRUvvsMOVGUmfENOfWgb = "xsi",
				NSIraOohUuxbwNWwnOfcoaPLKLA = "schemaLocation",
				KyKFPbDbzyvJvQZYVoBMpXenzVYN = null,
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((rEwCUWdrnAvHNmyWPMTQEZZqEeEa != null) ? rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i] != null)
				{
					list.Add(rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i] != null)
				{
					rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
