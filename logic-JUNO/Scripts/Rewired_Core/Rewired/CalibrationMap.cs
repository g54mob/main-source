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
		private AxisCalibration[] lwCmNmjubnNNksBGTSxnpbvVzQMK;

		private IList<AxisCalibration> qhDxHnpJhoZaKQMvseduDLwglycC;

		private readonly int PmsWhJMUTLbXBDOmzFhDXmMVIrkEA;

		public IList<AxisCalibration> Axes => qhDxHnpJhoZaKQMvseduDLwglycC;

		public int axisCount
		{
			get
			{
				if (lwCmNmjubnNNksBGTSxnpbvVzQMK == null)
				{
					return 0;
				}
				return lwCmNmjubnNNksBGTSxnpbvVzQMK.Length;
			}
		}

		private CalibrationMap()
		{
			PmsWhJMUTLbXBDOmzFhDXmMVIrkEA = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			lwCmNmjubnNNksBGTSxnpbvVzQMK = new AxisCalibration[num];
			for (int i = 0; i < num; i++)
			{
				lwCmNmjubnNNksBGTSxnpbvVzQMK[i] = new AxisCalibration(P_0[i]);
			}
			qhDxHnpJhoZaKQMvseduDLwglycC = new ReadOnlyCollection<AxisCalibration>(lwCmNmjubnNNksBGTSxnpbvVzQMK);
		}

		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			lwCmNmjubnNNksBGTSxnpbvVzQMK = P_0;
			qhDxHnpJhoZaKQMvseduDLwglycC = new ReadOnlyCollection<AxisCalibration>(lwCmNmjubnNNksBGTSxnpbvVzQMK);
		}

		public void Reset()
		{
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return;
			}
			for (int i = 0; i < lwCmNmjubnNNksBGTSxnpbvVzQMK.Length; i++)
			{
				lwCmNmjubnNNksBGTSxnpbvVzQMK[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return null;
			}
			if (index < 0 || index >= lwCmNmjubnNNksBGTSxnpbvVzQMK.Length)
			{
				return null;
			}
			return lwCmNmjubnNNksBGTSxnpbvVzQMK[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= lwCmNmjubnNNksBGTSxnpbvVzQMK.Length)
			{
				return value;
			}
			return lwCmNmjubnNNksBGTSxnpbvVzQMK[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return false;
			}
			if (index < 0 || index >= lwCmNmjubnNNksBGTSxnpbvVzQMK.Length)
			{
				return false;
			}
			lwCmNmjubnNNksBGTSxnpbvVzQMK[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= lwCmNmjubnNNksBGTSxnpbvVzQMK.Length)
			{
				return default(AxisCalibrationData);
			}
			return lwCmNmjubnNNksBGTSxnpbvVzQMK[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.lwCmNmjubnNNksBGTSxnpbvVzQMK.Length != lwCmNmjubnNNksBGTSxnpbvVzQMK.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < lwCmNmjubnNNksBGTSxnpbvVzQMK.Length; i++)
			{
				lwCmNmjubnNNksBGTSxnpbvVzQMK[i].CopyFrom(map.lwCmNmjubnNNksBGTSxnpbvVzQMK[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return FllXhvZPoXSXhoDNCDcGcmnCLZfJA().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return string.Empty;
			}
			try
			{
				return FllXhvZPoXSXhoDNCDcGcmnCLZfJA().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				TTvYDXUWjaoCWWwgqOYlTNPCqHZf(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != PmsWhJMUTLbXBDOmzFhDXmMVIrkEA)
			{
				ReInput.CheckInitialized(PmsWhJMUTLbXBDOmzFhDXmMVIrkEA);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				TTvYDXUWjaoCWWwgqOYlTNPCqHZf(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject FllXhvZPoXSXhoDNCDcGcmnCLZfJA()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "dataVersion",
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				GXuxQnHFoIjGhTjGJBCERvyaPbcC = "xmlns",
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "xsi",
				JTcffmzfUBZAVjPblkObnRNPpqZG = null,
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.StxLVFERPlwSUZNlMaKuFuVAjcqCb
			{
				GXuxQnHFoIjGhTjGJBCERvyaPbcC = "xsi",
				rVQdJsUVGueUoRlsQQCEHMDLFJOq = "schemaLocation",
				JTcffmzfUBZAVjPblkObnRNPpqZG = null,
				wqpBUPsVbkYZOHRjZkDHzExwrqmJ = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((lwCmNmjubnNNksBGTSxnpbvVzQMK != null) ? lwCmNmjubnNNksBGTSxnpbvVzQMK.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (lwCmNmjubnNNksBGTSxnpbvVzQMK[i] != null)
				{
					list.Add(lwCmNmjubnNNksBGTSxnpbvVzQMK[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void TTvYDXUWjaoCWWwgqOYlTNPCqHZf(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, lwCmNmjubnNNksBGTSxnpbvVzQMK.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && lwCmNmjubnNNksBGTSxnpbvVzQMK[i] != null)
				{
					lwCmNmjubnNNksBGTSxnpbvVzQMK[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
