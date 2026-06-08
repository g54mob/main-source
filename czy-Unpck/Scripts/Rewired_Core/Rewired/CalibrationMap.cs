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
		private AxisCalibration[] PdPvqHQYrfTEtGcYrKwAnNuIEVr;

		private IList<AxisCalibration> vBzdrdMIpYsKNmxYGcnGAvRapqx;

		private readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

		public IList<AxisCalibration> Axes => vBzdrdMIpYsKNmxYGcnGAvRapqx;

		public int axisCount
		{
			get
			{
				if (PdPvqHQYrfTEtGcYrKwAnNuIEVr == null)
				{
					return 0;
				}
				return PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length;
			}
		}

		private CalibrationMap()
		{
			vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] hardwareAxisCalibrationData)
			: this()
		{
			int num = ((hardwareAxisCalibrationData != null) ? hardwareAxisCalibrationData.Length : 0);
			PdPvqHQYrfTEtGcYrKwAnNuIEVr = new AxisCalibration[num];
			for (int i = 0; i < num; i++)
			{
				PdPvqHQYrfTEtGcYrKwAnNuIEVr[i] = new AxisCalibration(hardwareAxisCalibrationData[i]);
			}
			vBzdrdMIpYsKNmxYGcnGAvRapqx = new ReadOnlyCollection<AxisCalibration>(PdPvqHQYrfTEtGcYrKwAnNuIEVr);
		}

		public CalibrationMap(AxisCalibration[] axisCalibrations)
			: this()
		{
			PdPvqHQYrfTEtGcYrKwAnNuIEVr = axisCalibrations;
			vBzdrdMIpYsKNmxYGcnGAvRapqx = new ReadOnlyCollection<AxisCalibration>(PdPvqHQYrfTEtGcYrKwAnNuIEVr);
		}

		public void Reset()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = 1596549729;
				while (true)
				{
					switch (num2 ^ 0x5F296A65)
					{
					case 2:
						num2 = 1596549732;
						continue;
					default:
						return;
					case 1:
						break;
					case 4:
					{
						int num3;
						if (num < PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length)
						{
							num2 = 1596549733;
							num3 = num2;
						}
						else
						{
							num2 = 1596549734;
							num3 = num2;
						}
						continue;
					}
					case 0:
						PdPvqHQYrfTEtGcYrKwAnNuIEVr[num].Reset();
						num++;
						num2 = 1596549729;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length)
				{
					num = 1132071474;
					goto IL_001e;
				}
				return PdPvqHQYrfTEtGcYrKwAnNuIEVr[index];
			}
			goto IL_004f;
			IL_001e:
			switch (num ^ 0x437A0A32)
			{
			case 2:
				break;
			case 1:
				return null;
			default:
				goto IL_004f;
			}
			goto IL_0019;
			IL_0019:
			num = 1132071475;
			goto IL_001e;
			IL_004f:
			return null;
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length)
			{
				return value;
			}
			return PdPvqHQYrfTEtGcYrKwAnNuIEVr[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = -605485176;
				num2 = num;
			}
			else
			{
				num = -605485175;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -605485173;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -605485175)
				{
				case 3:
					break;
				case 2:
					return false;
				case 1:
					if (index >= PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length)
					{
						goto IL_005d;
					}
					PdPvqHQYrfTEtGcYrKwAnNuIEVr[index].SetData(data);
					return true;
				default:
					return false;
				}
				break;
				IL_005d:
				num = -605485175;
			}
			goto IL_0019;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length)
				{
					num = 2031362908;
					goto IL_001e;
				}
				return PdPvqHQYrfTEtGcYrKwAnNuIEVr[index].GetData();
			}
			goto IL_0062;
			IL_001e:
			AxisCalibrationData result = default(AxisCalibrationData);
			while (true)
			{
				switch (num ^ 0x7914235F)
				{
				case 0:
					break;
				case 2:
					result = default(AxisCalibrationData);
					num = 2031362910;
					continue;
				case 1:
					return result;
				default:
					goto IL_0062;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num = 2031362909;
			goto IL_001e;
			IL_0062:
			return default(AxisCalibrationData);
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				IL_0063:
				int num;
				if (map.PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length != PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length)
				{
					Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
					num = -762725428;
					goto IL_0009;
				}
				goto IL_0039;
				IL_0009:
				while (true)
				{
					switch (num ^ -762725430)
					{
					case 0:
						num = -762725425;
						continue;
					default:
						return;
					case 4:
						break;
					case 7:
						PdPvqHQYrfTEtGcYrKwAnNuIEVr[num2].CopyFrom(map.PdPvqHQYrfTEtGcYrKwAnNuIEVr[num2], copyHardwareDeadzone);
						num2++;
						num = -762725429;
						continue;
					case 5:
						goto IL_0063;
					case 2:
						num = -762725429;
						continue;
					case 1:
						goto IL_0090;
					case 6:
						return;
					case 3:
						return;
					}
					break;
					IL_0090:
					int num3;
					if (num2 >= PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length)
					{
						num = -762725431;
						num3 = num;
					}
					else
					{
						num = -762725427;
						num3 = num;
					}
				}
				goto IL_0039;
				IL_0039:
				num2 = 0;
				num = -762725432;
				goto IL_0009;
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return mtMtVVrohwWTxFPivXmGbDyGevo().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_0035:
					int num = -1824553183;
					while (true)
					{
						switch (num ^ -1824553184)
						{
						case 0:
							break;
						default:
							goto end_IL_003a;
						case 1:
							goto IL_0053;
						case 2:
							goto end_IL_003a;
						}
						goto IL_0035;
						IL_0053:
						Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
						num = -1824553182;
						continue;
						end_IL_003a:
						break;
					}
					break;
				}
			}
			return empty;
		}

		public string ToJsonString()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return string.Empty;
			}
			try
			{
				return mtMtVVrohwWTxFPivXmGbDyGevo().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject mtMtVVrohwWTxFPivXmGbDyGevo()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			List<object> list = default(List<object>);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 1732122479;
				while (true)
				{
					int num4;
					switch (num ^ 0x673E176B)
					{
					case 7:
						break;
					case 3:
						if (PdPvqHQYrfTEtGcYrKwAnNuIEVr == null)
						{
							num = 1732122474;
							continue;
						}
						num4 = PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length;
						goto IL_00a8;
					case 0:
						list = new List<object>();
						serializedObject.Add("axes", list);
						num = 1732122472;
						continue;
					case 5:
						num2++;
						num = 1732122477;
						continue;
					case 2:
						if (PdPvqHQYrfTEtGcYrKwAnNuIEVr[num2] != null)
						{
							list.Add(PdPvqHQYrfTEtGcYrKwAnNuIEVr[num2].ExportData());
							num = 1732122478;
							continue;
						}
						goto case 5;
					case 1:
						num4 = 0;
						goto IL_00a8;
					case 4:
						serializedObject.Add("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
						serializedObject.xmlInfo = new SerializedObject.XmlInfo();
						serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
						{
							localName = "dataVersion",
							value = 4.ToString()
						});
						serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
						{
							prefix = "xmlns",
							localName = "xsi",
							ns = null,
							value = "http://www.w3.org/2001/XMLSchema-instance"
						});
						serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
						{
							prefix = "xsi",
							localName = "schemaLocation",
							ns = null,
							value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
						});
						num = 1732122475;
						continue;
					default:
						{
							if (num2 >= num3)
							{
								return serializedObject;
							}
							goto case 2;
						}
						IL_00a8:
						num3 = num4;
						num2 = 0;
						num = 1732122477;
						continue;
					}
					break;
				}
			}
		}

		private void FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject P_0)
		{
			SerializedObject value = null;
			int num4 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = -2145250658;
				while (true)
				{
					switch (num ^ -2145250661)
					{
					case 3:
						break;
					default:
						return;
					case 5:
						if (P_0.TryGetDeserializedValueByRef("axes", ref value))
						{
							num4 = MathTools.Min(value.count, PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length);
							num = -2145250663;
							continue;
						}
						return;
					case 0:
					{
						int num5;
						if (num2 >= num4)
						{
							num = -2145250657;
							num5 = num;
						}
						else
						{
							num = -2145250660;
							num5 = num;
						}
						continue;
					}
					case 2:
						num2 = 0;
						num = -2145250661;
						continue;
					case 1:
						num2++;
						num = -2145250661;
						continue;
					case 6:
						PdPvqHQYrfTEtGcYrKwAnNuIEVr[num2].Import((SerializedObject)value[num2].value);
						num = -2145250662;
						continue;
					case 7:
						if (value[num2].value is SerializedObject)
						{
							int num3;
							if (PdPvqHQYrfTEtGcYrKwAnNuIEVr[num2] != null)
							{
								num = -2145250659;
								num3 = num;
							}
							else
							{
								num = -2145250662;
								num3 = num;
							}
							continue;
						}
						goto case 1;
					case 4:
						return;
					}
					break;
				}
			}
		}

		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, GetAxis(xAxisIndex), GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}
	}
}
