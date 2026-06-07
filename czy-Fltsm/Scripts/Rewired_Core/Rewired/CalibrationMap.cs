using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CalibrationMap
	{
		public struct InitOptions
		{
			[CompilerGenerated]
			private IList<AxisCalibration> DxsUfEgPyUQgrJjwlUfXVbuGRSkF;

			[CompilerGenerated]
			private IList<Axis2DCalibration> GYmKuLiBwtNQKOqruBsfaiHckRxeA;

			public IList<AxisCalibration> axisCalibrations
			{
				[CompilerGenerated]
				get
				{
					return DxsUfEgPyUQgrJjwlUfXVbuGRSkF;
				}
				[CompilerGenerated]
				internal set
				{
					DxsUfEgPyUQgrJjwlUfXVbuGRSkF = dxsUfEgPyUQgrJjwlUfXVbuGRSkF;
				}
			}

			public IList<Axis2DCalibration> axis2DCalibrations
			{
				[CompilerGenerated]
				get
				{
					return GYmKuLiBwtNQKOqruBsfaiHckRxeA;
				}
				[CompilerGenerated]
				internal set
				{
					GYmKuLiBwtNQKOqruBsfaiHckRxeA = gYmKuLiBwtNQKOqruBsfaiHckRxeA;
				}
			}
		}

		private AxisCalibration[] CCdIQOYSsZFUXpSKajXIlTcnrNYd;

		private MappedArray<AxisCalibration> cQwGlSUpaYycZlfDhXxFVziarRxD;

		private Axis2DCalibration[] WKqnzKcoIasFfUqaWHRMYQGPyfsj;

		private IList<AxisCalibration> etPChHhQBZGAakkCnVeBPKMnkDjdA;

		private IList<Axis2DCalibration> hqNspcvSkYdDMwGINDQFKhHxdLle;

		private readonly int BOsvMlOHtuQfrdcfcbjgCeTYPrbj;

		public IList<AxisCalibration> Axes => etPChHhQBZGAakkCnVeBPKMnkDjdA;

		public int axisCount
		{
			get
			{
				if (CCdIQOYSsZFUXpSKajXIlTcnrNYd == null)
				{
					return 0;
				}
				return CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length;
			}
		}

		public IList<Axis2DCalibration> Axes2D => hqNspcvSkYdDMwGINDQFKhHxdLle;

		public int axis2DCount
		{
			get
			{
				if (WKqnzKcoIasFfUqaWHRMYQGPyfsj == null)
				{
					return 0;
				}
				return WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length;
			}
		}

		private CalibrationMap()
		{
			BOsvMlOHtuQfrdcfcbjgCeTYPrbj = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] P_0, Axis2DCalibrationData[] P_1, Func<int, int> P_2)
			: this()
		{
			int num = ((P_0 != null) ? P_0.Length : 0);
			CCdIQOYSsZFUXpSKajXIlTcnrNYd = new AxisCalibration[num];
			cQwGlSUpaYycZlfDhXxFVziarRxD = new MappedArray<AxisCalibration>(CCdIQOYSsZFUXpSKajXIlTcnrNYd, P_2);
			for (int i = 0; i < num; i++)
			{
				CCdIQOYSsZFUXpSKajXIlTcnrNYd[i] = new AxisCalibration(P_0[i]);
			}
			etPChHhQBZGAakkCnVeBPKMnkDjdA = new ReadOnlyCollection<AxisCalibration>(cQwGlSUpaYycZlfDhXxFVziarRxD);
			int num2 = ((P_1 != null) ? P_1.Length : 0);
			WKqnzKcoIasFfUqaWHRMYQGPyfsj = new Axis2DCalibration[num2];
			for (int j = 0; j < num2; j++)
			{
				WKqnzKcoIasFfUqaWHRMYQGPyfsj[j] = new Axis2DCalibration(P_1[j]);
			}
			hqNspcvSkYdDMwGINDQFKhHxdLle = new ReadOnlyCollection<Axis2DCalibration>(WKqnzKcoIasFfUqaWHRMYQGPyfsj);
		}

		[Obsolete("Use CalibrationMap(InitOptions) overload instead.", false)]
		public CalibrationMap(AxisCalibration[] P_0)
			: this()
		{
			CCdIQOYSsZFUXpSKajXIlTcnrNYd = P_0;
			cQwGlSUpaYycZlfDhXxFVziarRxD = new MappedArray<AxisCalibration>(CCdIQOYSsZFUXpSKajXIlTcnrNYd, null);
			etPChHhQBZGAakkCnVeBPKMnkDjdA = new ReadOnlyCollection<AxisCalibration>(cQwGlSUpaYycZlfDhXxFVziarRxD);
		}

		public CalibrationMap(InitOptions P_0)
			: this()
		{
			CCdIQOYSsZFUXpSKajXIlTcnrNYd = ((P_0.axisCalibrations != null) ? new AxisCalibration[P_0.axisCalibrations.Count] : new AxisCalibration[0]);
			for (int i = 0; i < CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length; i++)
			{
				if (P_0.axisCalibrations[i] == null)
				{
					throw new ArgumentNullException("initOptions.axisCalibrations[" + i + "]");
				}
				CCdIQOYSsZFUXpSKajXIlTcnrNYd[i] = P_0.axisCalibrations[i];
			}
			WKqnzKcoIasFfUqaWHRMYQGPyfsj = ((P_0.axis2DCalibrations != null) ? new Axis2DCalibration[P_0.axis2DCalibrations.Count] : new Axis2DCalibration[0]);
			for (int j = 0; j < WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length; j++)
			{
				if (P_0.axis2DCalibrations[j] == null)
				{
					throw new ArgumentNullException("initOptions.axis2DCalibrations[" + j + "]");
				}
				WKqnzKcoIasFfUqaWHRMYQGPyfsj[j] = P_0.axis2DCalibrations[j];
			}
		}

		public void Reset()
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return;
			}
			for (int i = 0; i < CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length; i++)
			{
				CCdIQOYSsZFUXpSKajXIlTcnrNYd[i].Reset();
			}
			for (int j = 0; j < WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length; j++)
			{
				WKqnzKcoIasFfUqaWHRMYQGPyfsj[j].Reset();
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return null;
			}
			if (index < 0 || index >= CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length)
			{
				return null;
			}
			return cQwGlSUpaYycZlfDhXxFVziarRxD[index];
		}

		public Axis2DCalibration GetAxis2D(int index)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return null;
			}
			if (index < 0 || index >= WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length)
			{
				return null;
			}
			return WKqnzKcoIasFfUqaWHRMYQGPyfsj[index];
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length)
			{
				return value;
			}
			return cQwGlSUpaYycZlfDhXxFVziarRxD[axisIndex].GetCalibratedValue(value);
		}

		public Vector2 GetCalibratedValue2D(int axis2DIndex, int xAxisIndex, int yAxisIndex, Vector2 value)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return default(Vector2);
			}
			if ((uint)axis2DIndex >= (uint)WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length)
			{
				return value;
			}
			return Axis2DCalibration.GetCalibratedValue(GetAxis2D(axis2DIndex), GetAxis(xAxisIndex), GetAxis(yAxisIndex), value.x, value.y);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return false;
			}
			if (index < 0 || index >= CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length)
			{
				return false;
			}
			cQwGlSUpaYycZlfDhXxFVziarRxD[index].SetData(data);
			return true;
		}

		public bool SetAxis2DData(int index, Axis2DCalibrationData data)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return false;
			}
			if (index < 0 || index >= WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length)
			{
				return false;
			}
			WKqnzKcoIasFfUqaWHRMYQGPyfsj[index].SetData(data);
			return true;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length)
			{
				return default(AxisCalibrationData);
			}
			return cQwGlSUpaYycZlfDhXxFVziarRxD[index].GetData();
		}

		public Axis2DCalibrationData GetAxis2DData(int index)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return default(Axis2DCalibrationData);
			}
			if (index < 0 || index >= CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length)
			{
				return default(Axis2DCalibrationData);
			}
			return WKqnzKcoIasFfUqaWHRMYQGPyfsj[index].GetData();
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length != CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length || map.WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length != WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length; i++)
			{
				CCdIQOYSsZFUXpSKajXIlTcnrNYd[i].CopyFrom(map.CCdIQOYSsZFUXpSKajXIlTcnrNYd[i], copyHardwareDeadzone);
			}
			for (int j = 0; j < WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length; j++)
			{
				WKqnzKcoIasFfUqaWHRMYQGPyfsj[j].CopyFrom(map.WKqnzKcoIasFfUqaWHRMYQGPyfsj[j], copyHardwareDeadzone);
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return ZbtrEBZLeqUDBSqPFoBhpsyTjXce().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return string.Empty;
			}
			try
			{
				return ZbtrEBZLeqUDBSqPFoBhpsyTjXce().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				HRxXUdCHOHsvaaeehXOOKhSBuYAr(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != BOsvMlOHtuQfrdcfcbjgCeTYPrbj)
			{
				ReInput.CheckInitialized(BOsvMlOHtuQfrdcfcbjgCeTYPrbj);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				HRxXUdCHOHsvaaeehXOOKhSBuYAr(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject ZbtrEBZLeqUDBSqPFoBhpsyTjXce()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add("dataVersion", 5, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "dataVersion",
				colvBdeALTpVyhJTAuogspkzwFfR = 5.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				YwqFzwdFPbsmyhvzUHNjHImbnvlAA = "xmlns",
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "xsi",
				JQeynGdKCohWfFHxkPiAfoQUYTUPA = null,
				colvBdeALTpVyhJTAuogspkzwFfR = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.GlzRlrSmJMPGyhIzDQJHlmQHORtg
			{
				YwqFzwdFPbsmyhvzUHNjHImbnvlAA = "xsi",
				pdYiVMKqONWNQjSqPcOhYrKSabZR = "schemaLocation",
				JQeynGdKCohWfFHxkPiAfoQUYTUPA = null,
				colvBdeALTpVyhJTAuogspkzwFfR = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.4", "/", GetType().Name, ".xsd")
			});
			List<object> list = new List<object>();
			serializedObject.Add("axes", list);
			int num = ((CCdIQOYSsZFUXpSKajXIlTcnrNYd != null) ? CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (CCdIQOYSsZFUXpSKajXIlTcnrNYd[i] != null)
				{
					list.Add(CCdIQOYSsZFUXpSKajXIlTcnrNYd[i].ExportData());
				}
			}
			List<object> list2 = new List<object>();
			serializedObject.Add("axes2d", list2);
			int num2 = ((WKqnzKcoIasFfUqaWHRMYQGPyfsj != null) ? WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length : 0);
			for (int j = 0; j < num2; j++)
			{
				if (WKqnzKcoIasFfUqaWHRMYQGPyfsj[j] != null)
				{
					list2.Add(WKqnzKcoIasFfUqaWHRMYQGPyfsj[j].ExportData());
				}
			}
			return serializedObject;
		}

		private void HRxXUdCHOHsvaaeehXOOKhSBuYAr(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				int num = MathTools.Min(value.count, CCdIQOYSsZFUXpSKajXIlTcnrNYd.Length);
				for (int i = 0; i < num; i++)
				{
					if (value[i].value is SerializedObject && CCdIQOYSsZFUXpSKajXIlTcnrNYd[i] != null)
					{
						CCdIQOYSsZFUXpSKajXIlTcnrNYd[i].Import((SerializedObject)value[i].value);
					}
				}
			}
			SerializedObject value2 = null;
			if (!P_0.TryGetDeserializedValueByRef("axes2d", ref value2))
			{
				return;
			}
			int num2 = MathTools.Min(value2.count, WKqnzKcoIasFfUqaWHRMYQGPyfsj.Length);
			for (int j = 0; j < num2; j++)
			{
				if (value2[j].value is SerializedObject && WKqnzKcoIasFfUqaWHRMYQGPyfsj[j] != null)
				{
					WKqnzKcoIasFfUqaWHRMYQGPyfsj[j].Import((SerializedObject)value2[j].value);
				}
			}
		}
	}
}
