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
		private AxisCalibration[] PbFORHCAibynPVwQMVeRWSjVVbJ;

		private IList<AxisCalibration> bErbZdGrOSfEhkpkfbRJQtnforXI;

		private readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

		public IList<AxisCalibration> Axes
		{
			get
			{
				return bErbZdGrOSfEhkpkfbRJQtnforXI;
			}
		}

		public int axisCount
		{
			get
			{
				if (PbFORHCAibynPVwQMVeRWSjVVbJ == null)
				{
					return 0;
				}
				return PbFORHCAibynPVwQMVeRWSjVVbJ.Length;
			}
		}

		private CalibrationMap()
		{
			znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
		}

		internal CalibrationMap(AxisCalibrationData[] hardwareAxisCalibrationData)
			: this()
		{
			int num = ((hardwareAxisCalibrationData != null) ? hardwareAxisCalibrationData.Length : 0);
			PbFORHCAibynPVwQMVeRWSjVVbJ = new AxisCalibration[num];
			for (int i = 0; i < num; i++)
			{
				PbFORHCAibynPVwQMVeRWSjVVbJ[i] = new AxisCalibration(hardwareAxisCalibrationData[i]);
			}
			bErbZdGrOSfEhkpkfbRJQtnforXI = new ReadOnlyCollection<AxisCalibration>(PbFORHCAibynPVwQMVeRWSjVVbJ);
		}

		public CalibrationMap(AxisCalibration[] axisCalibrations)
			: this()
		{
			PbFORHCAibynPVwQMVeRWSjVVbJ = axisCalibrations;
			bErbZdGrOSfEhkpkfbRJQtnforXI = new ReadOnlyCollection<AxisCalibration>(PbFORHCAibynPVwQMVeRWSjVVbJ);
		}

		public void Reset()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				goto IL_000d;
			}
			goto IL_004a;
			IL_000d:
			int num = 324331495;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x1354E7E3)
				{
				case 3:
					break;
				case 4:
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					num = 324331489;
					continue;
				case 0:
					goto IL_004a;
				case 1:
					PbFORHCAibynPVwQMVeRWSjVVbJ[num2].Reset();
					num2++;
					num = 324331494;
					continue;
				case 2:
					return;
				default:
					if (num2 >= PbFORHCAibynPVwQMVeRWSjVVbJ.Length)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
			goto IL_000d;
			IL_004a:
			num2 = 0;
			num = 324331494;
			goto IL_0012;
		}

		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = -1752261956;
				num2 = num;
			}
			else
			{
				num = -1752261953;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -1752261955;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -1752261954)
				{
				case 0:
					break;
				case 3:
					return null;
				case 1:
					if (index >= PbFORHCAibynPVwQMVeRWSjVVbJ.Length)
					{
						goto IL_005d;
					}
					return PbFORHCAibynPVwQMVeRWSjVVbJ[index];
				default:
					return null;
				}
				break;
				IL_005d:
				num = -1752261956;
			}
			goto IL_0019;
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= PbFORHCAibynPVwQMVeRWSjVVbJ.Length)
			{
				return value;
			}
			return PbFORHCAibynPVwQMVeRWSjVVbJ[axisIndex].GetCalibratedValue(value);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = 922767581;
					while (true)
					{
						switch (num ^ 0x370050DC)
						{
						case 2:
							break;
						case 1:
							goto IL_003d;
						default:
							goto end_IL_001f;
						}
						break;
						IL_003d:
						if (index >= PbFORHCAibynPVwQMVeRWSjVVbJ.Length)
						{
							num = 922767580;
							continue;
						}
						PbFORHCAibynPVwQMVeRWSjVVbJ[index].SetData(data);
						return true;
					}
					continue;
					end_IL_001f:
					break;
				}
			}
			return false;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 630688090;
				num2 = num;
			}
			else
			{
				num = 630688089;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 630688091;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x2597895A)
				{
				case 2:
					break;
				case 1:
					return default(AxisCalibrationData);
				case 0:
					if (index >= PbFORHCAibynPVwQMVeRWSjVVbJ.Length)
					{
						goto IL_0065;
					}
					return PbFORHCAibynPVwQMVeRWSjVVbJ[index].GetData();
				default:
					return default(AxisCalibrationData);
				}
				break;
				IL_0065:
				num = 630688089;
			}
			goto IL_0019;
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (map.PbFORHCAibynPVwQMVeRWSjVVbJ.Length == PbFORHCAibynPVwQMVeRWSjVVbJ.Length)
				{
					num = -656818082;
					num2 = num;
				}
				else
				{
					num = -656818088;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -656818082)
					{
					case 7:
						num = -656818085;
						continue;
					default:
						return;
					case 2:
						num3++;
						num = -656818081;
						continue;
					case 6:
						Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
						return;
					case 5:
						break;
					case 1:
					{
						int num4;
						if (num3 < PbFORHCAibynPVwQMVeRWSjVVbJ.Length)
						{
							num = -656818083;
							num4 = num;
						}
						else
						{
							num = -656818086;
							num4 = num;
						}
						continue;
					}
					case 0:
						num3 = 0;
						num = -656818081;
						continue;
					case 3:
						PbFORHCAibynPVwQMVeRWSjVVbJ[num3].CopyFrom(map.PbFORHCAibynPVwQMVeRWSjVVbJ[num3], copyHardwareDeadzone);
						num = -656818084;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return wGWQXZtIQyRkZMrIKWqTSlWZlQY().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
				return empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return string.Empty;
			}
			try
			{
				return wGWQXZtIQyRkZMrIKWqTSlWZlQY().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				DzhGtommJNlpRFKUAFaKGOCHKTz(SerializedObject.FromXml(GetType(), xmlString));
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
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				DzhGtommJNlpRFKUAFaKGOCHKTz(SerializedObject.FromJson(GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		private SerializedObject wGWQXZtIQyRkZMrIKWqTSlWZlQY()
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
			int num2 = default(int);
			List<object> list = default(List<object>);
			int num3 = default(int);
			while (true)
			{
				int num = 1218918832;
				while (true)
				{
					switch (num ^ 0x48A739B1)
					{
					case 3:
						break;
					case 0:
						if (PbFORHCAibynPVwQMVeRWSjVVbJ[num2] != null)
						{
							list.Add(PbFORHCAibynPVwQMVeRWSjVVbJ[num2].ExportData());
							num = 1218918837;
							continue;
						}
						goto case 4;
					case 4:
						num2++;
						num = 1218918835;
						continue;
					case 1:
						serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
						{
							prefix = "xsi",
							localName = "schemaLocation",
							ns = null,
							value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.3", "/", GetType().Name, ".xsd")
						});
						num = 1218918836;
						continue;
					case 5:
						list = new List<object>();
						serializedObject.Add("axes", list);
						num3 = ((PbFORHCAibynPVwQMVeRWSjVVbJ != null) ? PbFORHCAibynPVwQMVeRWSjVVbJ.Length : 0);
						num2 = 0;
						num = 1218918835;
						continue;
					default:
						if (num2 >= num3)
						{
							return serializedObject;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private void DzhGtommJNlpRFKUAFaKGOCHKTz(SerializedObject P_0)
		{
			SerializedObject value = null;
			if (!P_0.TryGetDeserializedValueByRef("axes", ref value))
			{
				return;
			}
			int num = MathTools.Min(value.count, PbFORHCAibynPVwQMVeRWSjVVbJ.Length);
			int num3 = default(int);
			while (true)
			{
				int num2 = 216576703;
				while (true)
				{
					switch (num2 ^ 0xCE8B2BC)
					{
					case 5:
						break;
					default:
						return;
					case 7:
					{
						int num4;
						if (value[num3].value is SerializedObject)
						{
							num2 = 216576702;
							num4 = num2;
						}
						else
						{
							num2 = 216576700;
							num4 = num2;
						}
						continue;
					}
					case 0:
						num3++;
						num2 = 216576701;
						continue;
					case 1:
					{
						int num5;
						if (num3 < num)
						{
							num2 = 216576699;
							num5 = num2;
						}
						else
						{
							num2 = 216576696;
							num5 = num2;
						}
						continue;
					}
					case 3:
						num3 = 0;
						num2 = 216576698;
						continue;
					case 6:
						num2 = 216576701;
						continue;
					case 2:
						if (PbFORHCAibynPVwQMVeRWSjVVbJ[num3] != null)
						{
							PbFORHCAibynPVwQMVeRWSjVVbJ[num3].Import((SerializedObject)value[num3].value);
							num2 = 216576700;
							continue;
						}
						goto case 0;
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
