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
		private AxisCalibration[] XiWNbwUWYHoLPxZyOZhRZbiCuVm;

		private IList<AxisCalibration> nYasuOAWCkWCjLwudRMRcwFcQNi;

		private readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

		public IList<AxisCalibration> Axes => nYasuOAWCkWCjLwudRMRcwFcQNi;

		public int axisCount
		{
			get
			{
				if (XiWNbwUWYHoLPxZyOZhRZbiCuVm == null)
				{
					return 0;
				}
				return XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length;
			}
		}

		private CalibrationMap()
		{
			fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] hardwareAxisCalibrationData)
			: this()
		{
			int num = ((hardwareAxisCalibrationData != null) ? hardwareAxisCalibrationData.Length : 0);
			XiWNbwUWYHoLPxZyOZhRZbiCuVm = new AxisCalibration[num];
			for (int i = 0; i < num; i++)
			{
				XiWNbwUWYHoLPxZyOZhRZbiCuVm[i] = new AxisCalibration(hardwareAxisCalibrationData[i]);
			}
			nYasuOAWCkWCjLwudRMRcwFcQNi = new ReadOnlyCollection<AxisCalibration>(XiWNbwUWYHoLPxZyOZhRZbiCuVm);
		}

		public CalibrationMap(AxisCalibration[] axisCalibrations)
			: this()
		{
			XiWNbwUWYHoLPxZyOZhRZbiCuVm = axisCalibrations;
			nYasuOAWCkWCjLwudRMRcwFcQNi = new ReadOnlyCollection<AxisCalibration>(XiWNbwUWYHoLPxZyOZhRZbiCuVm);
		}

		public void Reset()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return;
			}
			for (int i = 0; i < XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length; i++)
			{
				XiWNbwUWYHoLPxZyOZhRZbiCuVm[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if (index < 0 || index >= XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length)
			{
				return null;
			}
			return XiWNbwUWYHoLPxZyOZhRZbiCuVm[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length)
			{
				return value;
			}
			return XiWNbwUWYHoLPxZyOZhRZbiCuVm[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (index < 0 || index >= XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length)
			{
				return false;
			}
			XiWNbwUWYHoLPxZyOZhRZbiCuVm[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length)
			{
				return default(AxisCalibrationData);
			}
			return XiWNbwUWYHoLPxZyOZhRZbiCuVm[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length != XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length; i++)
			{
				XiWNbwUWYHoLPxZyOZhRZbiCuVm[i].CopyFrom(map.XiWNbwUWYHoLPxZyOZhRZbiCuVm[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return qnRcKibdUQgUDehMYaMNRcmEEUp().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return string.Empty;
			}
			try
			{
				return qnRcKibdUQgUDehMYaMNRcmEEUp().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject qnRcKibdUQgUDehMYaMNRcmEEUp()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				zYwYmGHTCLOJxCByvWzioBevSzj = "dataVersion",
				HpxePuhaScltgSCBmgsrsCpjliL = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				LwDBNnNFqBxCeHOdFxAkCpxXHQR = "xmlns",
				zYwYmGHTCLOJxCByvWzioBevSzj = "xsi",
				oseqaDGmYbdubOOmISVVBGRFzNc = null,
				HpxePuhaScltgSCBmgsrsCpjliL = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.OyVEtLlgkNfHXzDuiVPrVGAKdJW
			{
				LwDBNnNFqBxCeHOdFxAkCpxXHQR = "xsi",
				zYwYmGHTCLOJxCByvWzioBevSzj = "schemaLocation",
				oseqaDGmYbdubOOmISVVBGRFzNc = null,
				HpxePuhaScltgSCBmgsrsCpjliL = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((XiWNbwUWYHoLPxZyOZhRZbiCuVm != null) ? XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (XiWNbwUWYHoLPxZyOZhRZbiCuVm[i] != null)
				{
					list.Add(XiWNbwUWYHoLPxZyOZhRZbiCuVm[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void JYyEPkmZztzXfbEgKghAFieAytO(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, XiWNbwUWYHoLPxZyOZhRZbiCuVm.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && XiWNbwUWYHoLPxZyOZhRZbiCuVm[i] != null)
				{
					XiWNbwUWYHoLPxZyOZhRZbiCuVm[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
