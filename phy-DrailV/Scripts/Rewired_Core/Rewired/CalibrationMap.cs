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
		private AxisCalibration[] mFPxlyuWJSdFKRwUucoCXYdSWyFR;

		private MappedArray<AxisCalibration> tczliXzDSaWzsoVoLERzxwkyqbqv;

		private IList<AxisCalibration> csqqYLIKsJTcoOMoquvmTMFXGNQF;

		private readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

		public IList<AxisCalibration> Axes => csqqYLIKsJTcoOMoquvmTMFXGNQF;

		public int axisCount
		{
			get
			{
				if (mFPxlyuWJSdFKRwUucoCXYdSWyFR == null)
				{
					return 0;
				}
				return mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length;
			}
		}

		private CalibrationMap()
		{
			oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0, Func<int, int> P_1)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			mFPxlyuWJSdFKRwUucoCXYdSWyFR = new AxisCalibration[num];
			tczliXzDSaWzsoVoLERzxwkyqbqv = new MappedArray<AxisCalibration>(mFPxlyuWJSdFKRwUucoCXYdSWyFR, P_1);
			for (int i = 0; i < num; i++)
			{
				mFPxlyuWJSdFKRwUucoCXYdSWyFR[i] = new AxisCalibration(P_0[i]);
			}
			csqqYLIKsJTcoOMoquvmTMFXGNQF = new ReadOnlyCollection<AxisCalibration>(tczliXzDSaWzsoVoLERzxwkyqbqv);
		}

		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			mFPxlyuWJSdFKRwUucoCXYdSWyFR = P_0;
			tczliXzDSaWzsoVoLERzxwkyqbqv = new MappedArray<AxisCalibration>(mFPxlyuWJSdFKRwUucoCXYdSWyFR, null);
			csqqYLIKsJTcoOMoquvmTMFXGNQF = new ReadOnlyCollection<AxisCalibration>(tczliXzDSaWzsoVoLERzxwkyqbqv);
		}

		public void Reset()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return;
			}
			for (int i = 0; i < mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length; i++)
			{
				mFPxlyuWJSdFKRwUucoCXYdSWyFR[i].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if (index < 0 || index >= mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length)
			{
				return null;
			}
			return tczliXzDSaWzsoVoLERzxwkyqbqv[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length)
			{
				return value;
			}
			return tczliXzDSaWzsoVoLERzxwkyqbqv[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (index < 0 || index >= mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length)
			{
				return false;
			}
			tczliXzDSaWzsoVoLERzxwkyqbqv[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length)
			{
				return default(AxisCalibrationData);
			}
			return tczliXzDSaWzsoVoLERzxwkyqbqv[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length != mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length; i++)
			{
				mFPxlyuWJSdFKRwUucoCXYdSWyFR[i].CopyFrom(map.mFPxlyuWJSdFKRwUucoCXYdSWyFR[i], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return pMFmgpdCytjWAfCkBRuiiiznUeVd().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return string.Empty;
			}
			try
			{
				return pMFmgpdCytjWAfCkBRuiiiznUeVd().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject pMFmgpdCytjWAfCkBRuiiiznUeVd()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "dataVersion",
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				KxTTmcDyYaBSfMPvUfdDpAxeKhlL = "xmlns",
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "xsi",
				bQsOsCQXaUMzqJWgNvgeirDgvXAS = null,
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.FTFUnSdjCkoGMcOadgOCoYMlThuL
			{
				KxTTmcDyYaBSfMPvUfdDpAxeKhlL = "xsi",
				uEkKFXXRykNWeZGsmzkXBCXWCSXG = "schemaLocation",
				bQsOsCQXaUMzqJWgNvgeirDgvXAS = null,
				ANnyYrpgRHgHrBXsbJxMFrsUzupD = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((mFPxlyuWJSdFKRwUucoCXYdSWyFR != null) ? mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (mFPxlyuWJSdFKRwUucoCXYdSWyFR[i] != null)
				{
					list.Add(mFPxlyuWJSdFKRwUucoCXYdSWyFR[i].ExportData());
				}
			}
			return serializedObject;
		}

		private void IqWUQdetEUgWKmOIFRihysPfqZgC(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, mFPxlyuWJSdFKRwUucoCXYdSWyFR.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i].value is SerializedObject && mFPxlyuWJSdFKRwUucoCXYdSWyFR[i] != null)
				{
					mFPxlyuWJSdFKRwUucoCXYdSWyFR[i].Import((SerializedObject)value[i].value);
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
