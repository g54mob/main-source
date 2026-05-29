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
		private AxisCalibration[] qbVJMDgYpnJuvznLeFDMdGeZUGX;

		private IList<AxisCalibration> WDtgAwyWAQIbMKJdXdTHDAnjfmKg;

		private readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

		public IList<AxisCalibration> Axes
		{
			get
			{
				return WDtgAwyWAQIbMKJdXdTHDAnjfmKg;
			}
		}

		public int axisCount
		{
			get
			{
				if (qbVJMDgYpnJuvznLeFDMdGeZUGX == null)
				{
					return 0;
				}
				return qbVJMDgYpnJuvznLeFDMdGeZUGX.Length;
			}
		}

		private CalibrationMap()
		{
			SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] hardwareAxisCalibrationData)
			: this()
		{
			int num = ((hardwareAxisCalibrationData != null) ? hardwareAxisCalibrationData.Length : 0);
			qbVJMDgYpnJuvznLeFDMdGeZUGX = new AxisCalibration[num];
			for (int i = 0; i < num; i++)
			{
				qbVJMDgYpnJuvznLeFDMdGeZUGX[i] = new AxisCalibration(hardwareAxisCalibrationData[i]);
			}
			WDtgAwyWAQIbMKJdXdTHDAnjfmKg = new ReadOnlyCollection<AxisCalibration>(qbVJMDgYpnJuvznLeFDMdGeZUGX);
		}

		public CalibrationMap(AxisCalibration[] axisCalibrations)
			: this()
		{
			qbVJMDgYpnJuvznLeFDMdGeZUGX = axisCalibrations;
			WDtgAwyWAQIbMKJdXdTHDAnjfmKg = new ReadOnlyCollection<AxisCalibration>(qbVJMDgYpnJuvznLeFDMdGeZUGX);
		}

		public void Reset()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			goto IL_006a;
			IL_000d:
			int num = -29626226;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -29626228)
				{
				case 0:
					break;
				case 3:
					qbVJMDgYpnJuvznLeFDMdGeZUGX[num2].Reset();
					num = -29626231;
					continue;
				case 5:
					num2++;
					num = -29626227;
					continue;
				case 2:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return;
				case 4:
					goto IL_006a;
				default:
					if (num2 >= qbVJMDgYpnJuvznLeFDMdGeZUGX.Length)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
			goto IL_000d;
			IL_006a:
			num2 = 0;
			num = -29626227;
			goto IL_0012;
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= qbVJMDgYpnJuvznLeFDMdGeZUGX.Length)
				{
					num = -1833999664;
					goto IL_001e;
				}
				return qbVJMDgYpnJuvznLeFDMdGeZUGX[index];
			}
			goto IL_004f;
			IL_001e:
			switch (num ^ -1833999663)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				goto IL_004f;
			}
			goto IL_0019;
			IL_0019:
			num = -1833999661;
			goto IL_001e;
			IL_004f:
			return null;
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= qbVJMDgYpnJuvznLeFDMdGeZUGX.Length)
			{
				return value;
			}
			return qbVJMDgYpnJuvznLeFDMdGeZUGX[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= qbVJMDgYpnJuvznLeFDMdGeZUGX.Length)
				{
					num = -305507854;
					goto IL_001e;
				}
				qbVJMDgYpnJuvznLeFDMdGeZUGX[index].SetData(data);
				return true;
			}
			goto IL_004f;
			IL_001e:
			switch (num ^ -305507854)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				goto IL_004f;
			}
			goto IL_0019;
			IL_0019:
			num = -305507853;
			goto IL_001e;
			IL_004f:
			return false;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= qbVJMDgYpnJuvznLeFDMdGeZUGX.Length)
				{
					num = 972034710;
					goto IL_001e;
				}
				return qbVJMDgYpnJuvznLeFDMdGeZUGX[index].GetData();
			}
			goto IL_0062;
			IL_001e:
			AxisCalibrationData result = default(AxisCalibrationData);
			while (true)
			{
				switch (num ^ 0x39F01297)
				{
				case 2:
					break;
				case 3:
					result = default(AxisCalibrationData);
					num = 972034711;
					continue;
				case 0:
					return result;
				default:
					goto IL_0062;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num = 972034708;
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
			while (true)
			{
				if (map.qbVJMDgYpnJuvznLeFDMdGeZUGX.Length == qbVJMDgYpnJuvznLeFDMdGeZUGX.Length)
				{
					while (true)
					{
						int num = 0;
						int num2 = 1512729281;
						while (true)
						{
							switch (num2 ^ 0x5A2A6AC1)
							{
							case 4:
								num2 = 1512729283;
								continue;
							case 5:
								qbVJMDgYpnJuvznLeFDMdGeZUGX[num].CopyFrom(map.qbVJMDgYpnJuvznLeFDMdGeZUGX[num], copyHardwareDeadzone);
								num2 = 1512729282;
								continue;
							case 1:
								break;
							case 0:
								num2 = 1512729287;
								continue;
							case 2:
								goto end_IL_004f;
							case 3:
								num++;
								num2 = 1512729287;
								continue;
							default:
								if (num >= qbVJMDgYpnJuvznLeFDMdGeZUGX.Length)
								{
									return;
								}
								goto case 5;
							}
							break;
						}
						continue;
						end_IL_004f:
						break;
					}
					continue;
				}
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				break;
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return LxAJUQVkKiSNqkaHsfsZAlQLTqTK().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return string.Empty;
			}
			try
			{
				return LxAJUQVkKiSNqkaHsfsZAlQLTqTK().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (string.IsNullOrEmpty(xmlString))
			{
				num = 880752666;
				goto IL_0012;
			}
			try
			{
				kLnQybMiVBnKwrnVkGeKjoKJKGa(SerializedObject.FromXml(GetType(), xmlString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from XML! " + ex.Message);
			}
			return false;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x347F381B)
				{
				case 2:
					break;
				case 3:
					goto IL_002f;
				case 0:
					return false;
				default:
					return false;
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				num = 880752667;
			}
			goto IL_000d;
			IL_000d:
			num = 880752664;
			goto IL_0012;
		}

		public bool ImportJsonString(string jsonString)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				kLnQybMiVBnKwrnVkGeKjoKJKGa(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject LxAJUQVkKiSNqkaHsfsZAlQLTqTK()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
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
			List<object> list = default(List<object>);
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 1185213458;
				while (true)
				{
					switch (num ^ 0x46A4EC13)
					{
					case 3:
						break;
					case 1:
						serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
						{
							prefix = "xsi",
							localName = "schemaLocation",
							ns = null,
							value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
						});
						list = new List<object>();
						serializedObject.Add("axes", list);
						num3 = ((qbVJMDgYpnJuvznLeFDMdGeZUGX != null) ? qbVJMDgYpnJuvznLeFDMdGeZUGX.Length : 0);
						num2 = 0;
						num = 1185213457;
						continue;
					case 2:
						num = 1185213463;
						continue;
					case 0:
						if (qbVJMDgYpnJuvznLeFDMdGeZUGX[num2] != null)
						{
							list.Add(qbVJMDgYpnJuvznLeFDMdGeZUGX[num2].ExportData());
							num = 1185213461;
							continue;
						}
						goto case 6;
					case 6:
						num2++;
						num = 1185213463;
						continue;
					case 4:
					{
						int num4;
						if (num2 >= num3)
						{
							num = 1185213462;
							num4 = num;
						}
						else
						{
							num = 1185213459;
							num4 = num;
						}
						continue;
					}
					default:
						return serializedObject;
					}
					break;
				}
			}
		}

		private void kLnQybMiVBnKwrnVkGeKjoKJKGa(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, qbVJMDgYpnJuvznLeFDMdGeZUGX.Length);
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = 1142948175;
					num4 = num3;
				}
				else
				{
					num3 = 1142948174;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x4420014C)
					{
					case 0:
						num3 = 1142948175;
						continue;
					default:
						return;
					case 5:
						num2++;
						num3 = 1142948168;
						continue;
					case 1:
						qbVJMDgYpnJuvznLeFDMdGeZUGX[num2].Import((SerializedObject)value[num2].value);
						num3 = 1142948169;
						continue;
					case 3:
						if (value[num2].value is SerializedObject)
						{
							int num5;
							if (qbVJMDgYpnJuvznLeFDMdGeZUGX[num2] != null)
							{
								num3 = 1142948173;
								num5 = num3;
							}
							else
							{
								num3 = 1142948169;
								num5 = num3;
							}
							continue;
						}
						goto case 5;
					case 4:
						break;
					case 2:
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
