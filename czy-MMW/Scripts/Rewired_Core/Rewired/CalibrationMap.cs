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
		private AxisCalibration[] dPJjyjiaPTsfIoTenlBkFLlMZAkf;

		private IList<AxisCalibration> iNEyyzsROUaLRCjHABNlhfnfRYEi;

		private readonly int PPxggDRPUjogIFAbDCKYxRuKxXSM;

		public IList<AxisCalibration> Axes => iNEyyzsROUaLRCjHABNlhfnfRYEi;

		public int axisCount
		{
			get
			{
				if (dPJjyjiaPTsfIoTenlBkFLlMZAkf == null)
				{
					return 0;
				}
				return dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length;
			}
		}

		private CalibrationMap()
		{
			PPxggDRPUjogIFAbDCKYxRuKxXSM = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			dPJjyjiaPTsfIoTenlBkFLlMZAkf = new AxisCalibration[num];
			for (int i = 0; i < num; i++)
			{
				dPJjyjiaPTsfIoTenlBkFLlMZAkf[i] = new AxisCalibration(P_0[i]);
			}
			iNEyyzsROUaLRCjHABNlhfnfRYEi = new ReadOnlyCollection<AxisCalibration>(dPJjyjiaPTsfIoTenlBkFLlMZAkf);
		}

		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			dPJjyjiaPTsfIoTenlBkFLlMZAkf = P_0;
			iNEyyzsROUaLRCjHABNlhfnfRYEi = new ReadOnlyCollection<AxisCalibration>(dPJjyjiaPTsfIoTenlBkFLlMZAkf);
		}

		public void Reset()
		{
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return;
			}
			for (int i = 0; i < dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length; i++)
			{
				dPJjyjiaPTsfIoTenlBkFLlMZAkf[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return null;
			}
			if (index < 0 || index >= dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length)
			{
				return null;
			}
			return dPJjyjiaPTsfIoTenlBkFLlMZAkf[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length)
			{
				return value;
			}
			return dPJjyjiaPTsfIoTenlBkFLlMZAkf[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return false;
			}
			if (index < 0 || index >= dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length)
			{
				return false;
			}
			dPJjyjiaPTsfIoTenlBkFLlMZAkf[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length)
			{
				return default(AxisCalibrationData);
			}
			return dPJjyjiaPTsfIoTenlBkFLlMZAkf[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length != dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length; i++)
			{
				dPJjyjiaPTsfIoTenlBkFLlMZAkf[i].CopyFrom(map.dPJjyjiaPTsfIoTenlBkFLlMZAkf[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return REskgxOqvpgmkiXSmBPPYcPZcdBGA().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return string.Empty;
			}
			try
			{
				return REskgxOqvpgmkiXSmBPPYcPZcdBGA().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				TqwHvDTZNIJLHYjvApuqvbrTCddI(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != PPxggDRPUjogIFAbDCKYxRuKxXSM)
			{
				ReInput.CheckInitialized(PPxggDRPUjogIFAbDCKYxRuKxXSM);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				TqwHvDTZNIJLHYjvApuqvbrTCddI(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject REskgxOqvpgmkiXSmBPPYcPZcdBGA()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "dataVersion",
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				OehazIAPEcSENVTqpypPfkRtzKCK = "xmlns",
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "xsi",
				FqpwTkyfXldoEdOuFQPgNddSWNnN = null,
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				OehazIAPEcSENVTqpypPfkRtzKCK = "xsi",
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "schemaLocation",
				FqpwTkyfXldoEdOuFQPgNddSWNnN = null,
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((dPJjyjiaPTsfIoTenlBkFLlMZAkf != null) ? dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (dPJjyjiaPTsfIoTenlBkFLlMZAkf[i] != null)
				{
					list.Add(dPJjyjiaPTsfIoTenlBkFLlMZAkf[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void TqwHvDTZNIJLHYjvApuqvbrTCddI(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, dPJjyjiaPTsfIoTenlBkFLlMZAkf.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && dPJjyjiaPTsfIoTenlBkFLlMZAkf[i] != null)
				{
					dPJjyjiaPTsfIoTenlBkFLlMZAkf[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
