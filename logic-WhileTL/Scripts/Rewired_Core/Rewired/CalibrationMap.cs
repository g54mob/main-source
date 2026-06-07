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
		private AxisCalibration[] brSuYimOuyWJoTIlcMgUhFfimdIf;

		private IList<AxisCalibration> TOwWvUaVYDgcUrOYXKAIAkwQXAMP;

		private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		public IList<AxisCalibration> Axes => TOwWvUaVYDgcUrOYXKAIAkwQXAMP;

		public int axisCount
		{
			get
			{
				if (brSuYimOuyWJoTIlcMgUhFfimdIf == null)
				{
					return 0;
				}
				return brSuYimOuyWJoTIlcMgUhFfimdIf.Length;
			}
		}

		private CalibrationMap()
		{
			TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			brSuYimOuyWJoTIlcMgUhFfimdIf = new AxisCalibration[num];
			for (int i = 0; i < num; i++)
			{
				brSuYimOuyWJoTIlcMgUhFfimdIf[i] = new AxisCalibration(P_0[i]);
			}
			TOwWvUaVYDgcUrOYXKAIAkwQXAMP = new ReadOnlyCollection<AxisCalibration>(brSuYimOuyWJoTIlcMgUhFfimdIf);
		}

		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			brSuYimOuyWJoTIlcMgUhFfimdIf = P_0;
			TOwWvUaVYDgcUrOYXKAIAkwQXAMP = new ReadOnlyCollection<AxisCalibration>(brSuYimOuyWJoTIlcMgUhFfimdIf);
		}

		public void Reset()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return;
			}
			for (int i = 0; i < brSuYimOuyWJoTIlcMgUhFfimdIf.Length; i++)
			{
				brSuYimOuyWJoTIlcMgUhFfimdIf[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			if (index < 0 || index >= brSuYimOuyWJoTIlcMgUhFfimdIf.Length)
			{
				return null;
			}
			return brSuYimOuyWJoTIlcMgUhFfimdIf[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= brSuYimOuyWJoTIlcMgUhFfimdIf.Length)
			{
				return value;
			}
			return brSuYimOuyWJoTIlcMgUhFfimdIf[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (index < 0 || index >= brSuYimOuyWJoTIlcMgUhFfimdIf.Length)
			{
				return false;
			}
			brSuYimOuyWJoTIlcMgUhFfimdIf[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= brSuYimOuyWJoTIlcMgUhFfimdIf.Length)
			{
				return default(AxisCalibrationData);
			}
			return brSuYimOuyWJoTIlcMgUhFfimdIf[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.brSuYimOuyWJoTIlcMgUhFfimdIf.Length != brSuYimOuyWJoTIlcMgUhFfimdIf.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < brSuYimOuyWJoTIlcMgUhFfimdIf.Length; i++)
			{
				brSuYimOuyWJoTIlcMgUhFfimdIf[i].CopyFrom(map.brSuYimOuyWJoTIlcMgUhFfimdIf[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return OwZlvwNnIfDEsAMweyvGbtLoYQJtA().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return string.Empty;
			}
			try
			{
				return OwZlvwNnIfDEsAMweyvGbtLoYQJtA().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject OwZlvwNnIfDEsAMweyvGbtLoYQJtA()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "dataVersion",
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				zgPaEzAbwsGcNWlXnJVzKkGnHIbhb = "xmlns",
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "xsi",
				OTermNiKyMWnSeUawIBObeynBxKj = null,
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.adZRTZDsgqtDqZBIYAKuebvqeDeUA
			{
				zgPaEzAbwsGcNWlXnJVzKkGnHIbhb = "xsi",
				DBsVPUbyEmkoGqiATtBbUGsLwABr = "schemaLocation",
				OTermNiKyMWnSeUawIBObeynBxKj = null,
				pWbMhcBQKZEHHDwvEOhqpAUJhzfpA = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((brSuYimOuyWJoTIlcMgUhFfimdIf != null) ? brSuYimOuyWJoTIlcMgUhFfimdIf.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (brSuYimOuyWJoTIlcMgUhFfimdIf[i] != null)
				{
					list.Add(brSuYimOuyWJoTIlcMgUhFfimdIf[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, brSuYimOuyWJoTIlcMgUhFfimdIf.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && brSuYimOuyWJoTIlcMgUhFfimdIf[i] != null)
				{
					brSuYimOuyWJoTIlcMgUhFfimdIf[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
