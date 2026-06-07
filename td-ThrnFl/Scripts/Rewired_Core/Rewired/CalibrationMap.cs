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
		private AxisCalibration[] ppHfTmSWrRUpYAUPCFRzvYuXjsNG;

		private MappedArray<AxisCalibration> BUboJOKmOxoWUvmBbRcTdCQivaP;

		private IList<AxisCalibration> XglcQzgzWPlLdORBBPWkYoxHeLeIA;

		private readonly int oZWOmRUETmNXkOlmCTJWYavaZuGB;

		public IList<AxisCalibration> Axes => XglcQzgzWPlLdORBBPWkYoxHeLeIA;

		public int axisCount
		{
			get
			{
				if (ppHfTmSWrRUpYAUPCFRzvYuXjsNG == null)
				{
					return 0;
				}
				return ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length;
			}
		}

		private CalibrationMap()
		{
			oZWOmRUETmNXkOlmCTJWYavaZuGB = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0, Func<int, int> P_1)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			ppHfTmSWrRUpYAUPCFRzvYuXjsNG = new AxisCalibration[num];
			BUboJOKmOxoWUvmBbRcTdCQivaP = new MappedArray<AxisCalibration>(ppHfTmSWrRUpYAUPCFRzvYuXjsNG, P_1);
			for (int i = 0; i < num; i++)
			{
				ppHfTmSWrRUpYAUPCFRzvYuXjsNG[i] = new AxisCalibration(P_0[i]);
			}
			XglcQzgzWPlLdORBBPWkYoxHeLeIA = new ReadOnlyCollection<AxisCalibration>(BUboJOKmOxoWUvmBbRcTdCQivaP);
		}

		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			ppHfTmSWrRUpYAUPCFRzvYuXjsNG = P_0;
			BUboJOKmOxoWUvmBbRcTdCQivaP = new MappedArray<AxisCalibration>(ppHfTmSWrRUpYAUPCFRzvYuXjsNG, null);
			XglcQzgzWPlLdORBBPWkYoxHeLeIA = new ReadOnlyCollection<AxisCalibration>(BUboJOKmOxoWUvmBbRcTdCQivaP);
		}

		public void Reset()
		{
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return;
			}
			for (int i = 0; i < ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length; i++)
			{
				ppHfTmSWrRUpYAUPCFRzvYuXjsNG[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return null;
			}
			if (index < 0 || index >= ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length)
			{
				return null;
			}
			return BUboJOKmOxoWUvmBbRcTdCQivaP[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length)
			{
				return value;
			}
			return BUboJOKmOxoWUvmBbRcTdCQivaP[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return false;
			}
			if (index < 0 || index >= ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length)
			{
				return false;
			}
			BUboJOKmOxoWUvmBbRcTdCQivaP[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length)
			{
				return default(AxisCalibrationData);
			}
			return BUboJOKmOxoWUvmBbRcTdCQivaP[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length != ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length; i++)
			{
				ppHfTmSWrRUpYAUPCFRzvYuXjsNG[i].CopyFrom(map.ppHfTmSWrRUpYAUPCFRzvYuXjsNG[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return wnVYQdFfhsRpGpAZrKNOhTQfdTdD().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return string.Empty;
			}
			try
			{
				return wnVYQdFfhsRpGpAZrKNOhTQfdTdD().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				sgXsjRMCZHygnVzdXCqrETdvNSPu(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != oZWOmRUETmNXkOlmCTJWYavaZuGB)
			{
				ReInput.CheckInitialized(oZWOmRUETmNXkOlmCTJWYavaZuGB);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				sgXsjRMCZHygnVzdXCqrETdvNSPu(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject wnVYQdFfhsRpGpAZrKNOhTQfdTdD()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "dataVersion",
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				hwMaMUHTAbktdLOuownSwUDJVxiDA = "xmlns",
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "xsi",
				kGESCebYXkaHwqimYjUfiApoHXHAA = null,
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.vaFqdHQxGUQBtSFqxHiqhgbjfOejA
			{
				hwMaMUHTAbktdLOuownSwUDJVxiDA = "xsi",
				MqiGgwQfPHmSRCgxvJyAMdrqqrIv = "schemaLocation",
				kGESCebYXkaHwqimYjUfiApoHXHAA = null,
				HDNykFqkGTdIdaCMqpOZhaRNJXwGb = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((ppHfTmSWrRUpYAUPCFRzvYuXjsNG != null) ? ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (ppHfTmSWrRUpYAUPCFRzvYuXjsNG[i] != null)
				{
					list.Add(ppHfTmSWrRUpYAUPCFRzvYuXjsNG[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void sgXsjRMCZHygnVzdXCqrETdvNSPu(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, ppHfTmSWrRUpYAUPCFRzvYuXjsNG.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && ppHfTmSWrRUpYAUPCFRzvYuXjsNG[i] != null)
				{
					ppHfTmSWrRUpYAUPCFRzvYuXjsNG[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
