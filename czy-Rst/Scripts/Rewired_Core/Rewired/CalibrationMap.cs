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
		private AxisCalibration[] TbCJWLVovLvwoRxIXSCCAGSYeRhs;

		private MappedArray<AxisCalibration> jRLUGuTXkIbKgZFbQGkXciyRHZMCA;

		private IList<AxisCalibration> zKkxCUsfQFqBLEeAOcFJnkLKlXGm;

		private readonly int STDhnoEDCaPuGsPcVKMgrxQpCfWmA;

		public IList<AxisCalibration> Axes => zKkxCUsfQFqBLEeAOcFJnkLKlXGm;

		public int axisCount
		{
			get
			{
				if (TbCJWLVovLvwoRxIXSCCAGSYeRhs == null)
				{
					return 0;
				}
				return TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length;
			}
		}

		private CalibrationMap()
		{
			STDhnoEDCaPuGsPcVKMgrxQpCfWmA = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0, Func<int, int> P_1)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			TbCJWLVovLvwoRxIXSCCAGSYeRhs = new AxisCalibration[num];
			jRLUGuTXkIbKgZFbQGkXciyRHZMCA = new MappedArray<AxisCalibration>(TbCJWLVovLvwoRxIXSCCAGSYeRhs, P_1);
			for (int i = 0; i < num; i++)
			{
				TbCJWLVovLvwoRxIXSCCAGSYeRhs[i] = new AxisCalibration(P_0[i]);
			}
			zKkxCUsfQFqBLEeAOcFJnkLKlXGm = new ReadOnlyCollection<AxisCalibration>(jRLUGuTXkIbKgZFbQGkXciyRHZMCA);
		}

		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			TbCJWLVovLvwoRxIXSCCAGSYeRhs = P_0;
			jRLUGuTXkIbKgZFbQGkXciyRHZMCA = new MappedArray<AxisCalibration>(TbCJWLVovLvwoRxIXSCCAGSYeRhs, null);
			zKkxCUsfQFqBLEeAOcFJnkLKlXGm = new ReadOnlyCollection<AxisCalibration>(jRLUGuTXkIbKgZFbQGkXciyRHZMCA);
		}

		public void Reset()
		{
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return;
			}
			for (int i = 0; i < TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length; i++)
			{
				TbCJWLVovLvwoRxIXSCCAGSYeRhs[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return null;
			}
			if (index < 0 || index >= TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length)
			{
				return null;
			}
			return jRLUGuTXkIbKgZFbQGkXciyRHZMCA[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length)
			{
				return value;
			}
			return jRLUGuTXkIbKgZFbQGkXciyRHZMCA[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return false;
			}
			if (index < 0 || index >= TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length)
			{
				return false;
			}
			jRLUGuTXkIbKgZFbQGkXciyRHZMCA[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length)
			{
				return default(AxisCalibrationData);
			}
			return jRLUGuTXkIbKgZFbQGkXciyRHZMCA[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length != TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length; i++)
			{
				TbCJWLVovLvwoRxIXSCCAGSYeRhs[i].CopyFrom(map.TbCJWLVovLvwoRxIXSCCAGSYeRhs[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return UIUZhEKNpwYugazJicVzINvmZRNl().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return string.Empty;
			}
			try
			{
				return UIUZhEKNpwYugazJicVzINvmZRNl().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				OSiOmNWPViLTJYmKHtMUxHgFonGb(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != STDhnoEDCaPuGsPcVKMgrxQpCfWmA)
			{
				ReInput.CheckInitialized(STDhnoEDCaPuGsPcVKMgrxQpCfWmA);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				OSiOmNWPViLTJYmKHtMUxHgFonGb(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject UIUZhEKNpwYugazJicVzINvmZRNl()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "dataVersion",
				lPGTilhMaDlHVZPffTpyFffKvRGC = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ZGFlSbWGOfUmLZdUdkUpxhWKZcME = "xmlns",
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "xsi",
				MFDdXiyHcPkUibxNoPMtNRhjvlXA = null,
				lPGTilhMaDlHVZPffTpyFffKvRGC = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.HSMGFcRrEEtwLPynqpRDQWJesQYg
			{
				ZGFlSbWGOfUmLZdUdkUpxhWKZcME = "xsi",
				ielDRFPPVThNrLWgcnBdvoVjXqeg = "schemaLocation",
				MFDdXiyHcPkUibxNoPMtNRhjvlXA = null,
				lPGTilhMaDlHVZPffTpyFffKvRGC = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((TbCJWLVovLvwoRxIXSCCAGSYeRhs != null) ? TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (TbCJWLVovLvwoRxIXSCCAGSYeRhs[i] != null)
				{
					list.Add(TbCJWLVovLvwoRxIXSCCAGSYeRhs[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void OSiOmNWPViLTJYmKHtMUxHgFonGb(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, TbCJWLVovLvwoRxIXSCCAGSYeRhs.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && TbCJWLVovLvwoRxIXSCCAGSYeRhs[i] != null)
				{
					TbCJWLVovLvwoRxIXSCCAGSYeRhs[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
