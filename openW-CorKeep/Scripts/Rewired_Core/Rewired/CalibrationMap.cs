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
		private AxisCalibration[] OyjIJVsGAPJijKxgnaytqRTUalSj;

		private MappedArray<AxisCalibration> eOoaGmgQBCLmnGHDcFGiCMbTksfGA;

		private IList<AxisCalibration> coHFbQZFvXRCWDvkqnjwLHIGKwdl;

		private readonly int NtsrOcwMbuENPWyInkcDTtDhCDzJ;

		public IList<AxisCalibration> Axes => coHFbQZFvXRCWDvkqnjwLHIGKwdl;

		public int axisCount
		{
			get
			{
				if (OyjIJVsGAPJijKxgnaytqRTUalSj == null)
				{
					return 0;
				}
				return OyjIJVsGAPJijKxgnaytqRTUalSj.Length;
			}
		}

		private CalibrationMap()
		{
			NtsrOcwMbuENPWyInkcDTtDhCDzJ = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0, Func<int, int> P_1)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			OyjIJVsGAPJijKxgnaytqRTUalSj = new AxisCalibration[num];
			eOoaGmgQBCLmnGHDcFGiCMbTksfGA = new MappedArray<AxisCalibration>(OyjIJVsGAPJijKxgnaytqRTUalSj, P_1);
			for (int i = 0; i < num; i++)
			{
				OyjIJVsGAPJijKxgnaytqRTUalSj[i] = new AxisCalibration(P_0[i]);
			}
			coHFbQZFvXRCWDvkqnjwLHIGKwdl = new ReadOnlyCollection<AxisCalibration>(eOoaGmgQBCLmnGHDcFGiCMbTksfGA);
		}

		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			OyjIJVsGAPJijKxgnaytqRTUalSj = P_0;
			eOoaGmgQBCLmnGHDcFGiCMbTksfGA = new MappedArray<AxisCalibration>(OyjIJVsGAPJijKxgnaytqRTUalSj, null);
			coHFbQZFvXRCWDvkqnjwLHIGKwdl = new ReadOnlyCollection<AxisCalibration>(eOoaGmgQBCLmnGHDcFGiCMbTksfGA);
		}

		public void Reset()
		{
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return;
			}
			for (int i = 0; i < OyjIJVsGAPJijKxgnaytqRTUalSj.Length; i++)
			{
				OyjIJVsGAPJijKxgnaytqRTUalSj[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return null;
			}
			if (index < 0 || index >= OyjIJVsGAPJijKxgnaytqRTUalSj.Length)
			{
				return null;
			}
			return eOoaGmgQBCLmnGHDcFGiCMbTksfGA[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= OyjIJVsGAPJijKxgnaytqRTUalSj.Length)
			{
				return value;
			}
			return eOoaGmgQBCLmnGHDcFGiCMbTksfGA[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return false;
			}
			if (index < 0 || index >= OyjIJVsGAPJijKxgnaytqRTUalSj.Length)
			{
				return false;
			}
			eOoaGmgQBCLmnGHDcFGiCMbTksfGA[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= OyjIJVsGAPJijKxgnaytqRTUalSj.Length)
			{
				return default(AxisCalibrationData);
			}
			return eOoaGmgQBCLmnGHDcFGiCMbTksfGA[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.OyjIJVsGAPJijKxgnaytqRTUalSj.Length != OyjIJVsGAPJijKxgnaytqRTUalSj.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < OyjIJVsGAPJijKxgnaytqRTUalSj.Length; i++)
			{
				OyjIJVsGAPJijKxgnaytqRTUalSj[i].CopyFrom(map.OyjIJVsGAPJijKxgnaytqRTUalSj[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return PetpkWdJCgCStjRnGlgIyOyawJwE().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return string.Empty;
			}
			try
			{
				return PetpkWdJCgCStjRnGlgIyOyawJwE().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				VMvpKaaVyVflYZvImLBlDqMyiZQBA(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != NtsrOcwMbuENPWyInkcDTtDhCDzJ)
			{
				ReInput.CheckInitialized(NtsrOcwMbuENPWyInkcDTtDhCDzJ);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				VMvpKaaVyVflYZvImLBlDqMyiZQBA(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject PetpkWdJCgCStjRnGlgIyOyawJwE()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "dataVersion",
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				WxmFjndTttjqQAYFRlGSZJiUawrZ = "xmlns",
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "xsi",
				FnmpvPDmwsSGLmiBdhdjjjOdjSKDb = null,
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EndBkowpwOTxIGJnMBcsgiGqTpvf
			{
				WxmFjndTttjqQAYFRlGSZJiUawrZ = "xsi",
				pIIbLDKqkVfRyNCGQyHEEVIpxwRdA = "schemaLocation",
				FnmpvPDmwsSGLmiBdhdjjjOdjSKDb = null,
				qqfRFgGAtDPLKSLpFGzHGleMdWxAb = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((OyjIJVsGAPJijKxgnaytqRTUalSj != null) ? OyjIJVsGAPJijKxgnaytqRTUalSj.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (OyjIJVsGAPJijKxgnaytqRTUalSj[i] != null)
				{
					list.Add(OyjIJVsGAPJijKxgnaytqRTUalSj[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void VMvpKaaVyVflYZvImLBlDqMyiZQBA(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, OyjIJVsGAPJijKxgnaytqRTUalSj.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && OyjIJVsGAPJijKxgnaytqRTUalSj[i] != null)
				{
					OyjIJVsGAPJijKxgnaytqRTUalSj[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
