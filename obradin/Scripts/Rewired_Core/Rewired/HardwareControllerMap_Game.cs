using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class HardwareControllerMap_Game
	{
		public readonly string controllerName;

		public readonly HardwareControllerMapIdentifier hardwareMapIdentifier;

		public readonly int customControllerSourceId;

		public readonly ADictionary<int, ControllerElementIdentifier> elementIdentifiers;

		public readonly ControllerElementIdentifier[] elementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] buttonElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] axisElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] axis2DElementIdentifiers_cache;

		public readonly ControllerElementIdentifier[] hatElementIdentifiers_cache;

		public readonly IList<ControllerElementIdentifier> elementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> buttonElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> axisElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> axis2DElementIdentifiers_readOnly;

		public readonly IList<ControllerElementIdentifier> hatElementIdentifiers_readOnly;

		public readonly int[] buttonElementIdentifierIds;

		public readonly int[] axisElementIdentifierIds;

		public readonly int[] axis2DElementIdentifierIds;

		public readonly int[] hatElementIdentifierIds;

		public readonly int elementIdentifierCount;

		public readonly int axisCount;

		public readonly int buttonCount;

		public readonly int compoundElementCount;

		public readonly int axis2DCount;

		public readonly int hatCount;

		public readonly JoystickType[] joystickTypes;

		public readonly AxisCalibrationData[] hwAxisCalibrationData;

		public readonly AxisRange[] hwAxisRanges;

		public readonly HardwareAxisInfo[] hwAxisInfo;

		public readonly HardwareButtonInfo[] hwButtonInfo;

		public readonly HardwareJoystickMap.CompoundElement[] compoundElements;

		private HardwareControllerMap_Game(string controllerName)
		{
			this.controllerName = controllerName;
		}

		public HardwareControllerMap_Game(string controllerName, int customControllerSourceId, ControllerElementIdentifier[] hardwareElementIdentifiers, int[] buttonElementIdentifierIds, int[] axisElementIdentifierIds, AxisCalibrationData[] hwAxisCalibrationData, AxisRange[] hwAxisRanges, HardwareAxisInfo[] hwAxisInfo, HardwareButtonInfo[] hwButtonInfo, HardwareJoystickMap.CompoundElement[] compoundElements)
			: this(controllerName, hardwareElementIdentifiers, buttonElementIdentifierIds, axisElementIdentifierIds, hwAxisCalibrationData, hwAxisRanges, hwAxisInfo, hwButtonInfo, compoundElements)
		{
			this.customControllerSourceId = customControllerSourceId;
		}

		public HardwareControllerMap_Game(string controllerName, HardwareControllerMapIdentifier hardwareMapIdentifier, JoystickType[] joystickTypes, ControllerElementIdentifier[] hardwareElementIdentifiers, int[] buttonElementIdentifierIds, int[] axisElementIdentifierIds, AxisCalibrationData[] hwAxisCalibrationData, AxisRange[] hwAxisRanges, HardwareAxisInfo[] hwAxisInfo, HardwareButtonInfo[] hwButtonInfo, HardwareJoystickMap.CompoundElement[] compoundElements)
			: this(controllerName, hardwareElementIdentifiers, buttonElementIdentifierIds, axisElementIdentifierIds, hwAxisCalibrationData, hwAxisRanges, hwAxisInfo, hwButtonInfo, compoundElements)
		{
			this.hardwareMapIdentifier = hardwareMapIdentifier;
			if (joystickTypes == null)
			{
				JoystickType[] array = new JoystickType[1];
				this.joystickTypes = array;
			}
			else
			{
				this.joystickTypes = ArrayTools.ShallowCopy(joystickTypes);
			}
		}

		public HardwareControllerMap_Game(string controllerName, HardwareControllerMapIdentifier hardwareMapIdentifier, ControllerElementIdentifier[] hardwareElementIdentifiers, int[] buttonElementIdentifierIds, int[] axisElementIdentifierIds, AxisCalibrationData[] hwAxisCalibrationData, AxisRange[] hwAxisRanges, HardwareAxisInfo[] hwAxisInfo, HardwareButtonInfo[] hwButtonInfo, HardwareJoystickMap.CompoundElement[] compoundElements)
			: this(controllerName, hardwareMapIdentifier, null, hardwareElementIdentifiers, buttonElementIdentifierIds, axisElementIdentifierIds, hwAxisCalibrationData, hwAxisRanges, hwAxisInfo, hwButtonInfo, compoundElements)
		{
		}

		private HardwareControllerMap_Game(string controllerName, ControllerElementIdentifier[] hardwareElementIdentifiers, int[] buttonElementIdentifierIds, int[] axisElementIdentifierIds, AxisCalibrationData[] hwAxisCalibrationData, AxisRange[] hwAxisRanges, HardwareAxisInfo[] hwAxisInfo, HardwareButtonInfo[] hwButtonInfo, HardwareJoystickMap.CompoundElement[] compoundElements)
			: this(controllerName)
		{
			int num5 = default(int);
			int[] array2 = default(int[]);
			List<int> list2 = default(List<int>);
			int num4 = default(int);
			int num13 = default(int);
			int num7 = default(int);
			int num8 = default(int);
			int num2 = default(int);
			int num9 = default(int);
			int num16 = default(int);
			int num6 = default(int);
			int[] array = default(int[]);
			int num10 = default(int);
			int num14 = default(int);
			int num3 = default(int);
			List<int> list = default(List<int>);
			int num17 = default(int);
			int num19 = default(int);
			while (true)
			{
				int num = -802461987;
				while (true)
				{
					int num12;
					switch (num ^ -802462015)
					{
					case 14:
						break;
					case 35:
						num5 = 0;
						num = -802461981;
						continue;
					case 20:
						array2 = list2.ToArray();
						elementIdentifiers = new ADictionary<int, ControllerElementIdentifier>(elementIdentifierCount);
						elementIdentifiers_cache = new ControllerElementIdentifier[elementIdentifierCount];
						buttonElementIdentifiers_cache = new ControllerElementIdentifier[num4];
						axisElementIdentifiers_cache = new ControllerElementIdentifier[num13];
						axis2DElementIdentifiers_cache = new ControllerElementIdentifier[num7];
						hatElementIdentifiers_cache = new ControllerElementIdentifier[num8];
						elementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(elementIdentifiers_cache);
						buttonElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(buttonElementIdentifiers_cache);
						axisElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(axisElementIdentifiers_cache);
						axis2DElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(axis2DElementIdentifiers_cache);
						hatElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(hatElementIdentifiers_cache);
						num = -802461990;
						continue;
					case 2:
						if (compoundElements[num2].type == CompoundControllerElementType.Hat)
						{
							num8++;
							list2.Add(compoundElements[num2].elementIdentifier);
							num = -802462000;
							continue;
						}
						goto case 10;
					case 3:
						Logger.LogError("Invalid hardware element identifier id!");
						num = -802461994;
						continue;
					case 41:
						if (num9 >= num4)
						{
							num16 = 0;
							num = -802461988;
							continue;
						}
						goto case 9;
					case 11:
						num9 = 0;
						num = -802461976;
						continue;
					case 42:
					{
						num6 = JJqmxHxPKYaPbztuToXPTZiExSg(hardwareElementIdentifiers, array[num5]);
						int num11;
						if (num6 >= 0)
						{
							num = -802461999;
							num11 = num;
						}
						else
						{
							num = -802462014;
							num11 = num;
						}
						continue;
					}
					case 8:
						num12 = 0;
						goto IL_022b;
					case 25:
						buttonElementIdentifiers_cache[num9] = hardwareElementIdentifiers[num10];
						num = -802461989;
						continue;
					case 13:
						num14++;
						num = -802462002;
						continue;
					case 29:
						num = -802461998;
						continue;
					case 24:
						elementIdentifierCount = ((elementIdentifiers != null) ? elementIdentifiers.Count : 0);
						buttonCount = ((buttonElementIdentifierIds != null) ? buttonElementIdentifierIds.Length : 0);
						num = -802461971;
						continue;
					case 37:
					{
						int num15;
						if (num3 < elementIdentifierCount)
						{
							num = -802461978;
							num15 = num;
						}
						else
						{
							num = -802462006;
							num15 = num;
						}
						continue;
					}
					case 1:
						num = -802461989;
						continue;
					case 5:
						this.compoundElements = compoundElements;
						compoundElementCount = ((compoundElements != null) ? compoundElements.Length : 0);
						num7 = 0;
						num8 = 0;
						list = new List<int>();
						list2 = new List<int>();
						num = -802462015;
						continue;
					case 16:
						axis2DElementIdentifiers_cache[num5] = hardwareElementIdentifiers[num6];
						num = -802461994;
						continue;
					case 19:
					{
						int num20;
						if (num16 < num13)
						{
							num = -802461983;
							num20 = num;
						}
						else
						{
							num = -802461982;
							num20 = num;
						}
						continue;
					}
					case 6:
						axisElementIdentifiers_cache[num16] = hardwareElementIdentifiers[num17];
						num = -802461979;
						continue;
					case 10:
						num2++;
						num = -802461986;
						continue;
					case 23:
						num5++;
						num = -802461981;
						continue;
					case 17:
						HardwareJoystickMap.CompoundElement.SortHatElementsClockwise(compoundElements[num2]);
						num = -802462005;
						continue;
					case 15:
						if (num14 >= num8)
						{
							this.buttonElementIdentifierIds = buttonElementIdentifierIds;
							this.axisElementIdentifierIds = axisElementIdentifierIds;
							axis2DElementIdentifierIds = array;
							hatElementIdentifierIds = array2;
							num = -802461991;
							continue;
						}
						goto case 33;
					case 44:
						axisCount = ((axisElementIdentifierIds != null) ? axisElementIdentifierIds.Length : 0);
						axis2DCount = num7;
						num = -802462011;
						continue;
					case 32:
						num17 = JJqmxHxPKYaPbztuToXPTZiExSg(hardwareElementIdentifiers, axisElementIdentifierIds[num16]);
						if (num17 < 0)
						{
							Logger.LogError("Invalid hardware element identifier id!");
							num = -802461977;
							continue;
						}
						goto case 6;
					case 38:
						num = -802461979;
						continue;
					case 12:
						Logger.LogError("Invalid hardware element identifier id!");
						num = -802462016;
						continue;
					case 7:
						num3++;
						num = -802461980;
						continue;
					case 4:
						hatCount = num8;
						this.hwAxisCalibrationData = hwAxisCalibrationData;
						num = -802461993;
						continue;
					case 36:
						num16++;
						num = -802461998;
						continue;
					case 9:
					{
						num10 = JJqmxHxPKYaPbztuToXPTZiExSg(hardwareElementIdentifiers, buttonElementIdentifierIds[num9]);
						int num18;
						if (num10 < 0)
						{
							num = -802462003;
							num18 = num;
						}
						else
						{
							num = -802461992;
							num18 = num;
						}
						continue;
					}
					case 43:
						if (axisElementIdentifierIds != null)
						{
							num12 = axisElementIdentifierIds.Length;
							goto IL_022b;
						}
						num = -802462007;
						continue;
					case 40:
						hatElementIdentifiers_cache[num14] = hardwareElementIdentifiers[num19];
						num = -802462004;
						continue;
					case 26:
						num9++;
						num = -802461976;
						continue;
					case 27:
						num3 = 0;
						num = -802461980;
						continue;
					case 18:
						compoundElements = ArrayTools.DeepClone(compoundElements);
						num = -802462012;
						continue;
					case 33:
						num19 = JJqmxHxPKYaPbztuToXPTZiExSg(hardwareElementIdentifiers, array2[num14]);
						if (num19 < 0)
						{
							Logger.LogError("Invalid hardware element identifier id!");
							num = -802462004;
							continue;
						}
						goto case 40;
					case 31:
						if (num2 >= compoundElementCount)
						{
							array = list.ToArray();
							num = -802461995;
							continue;
						}
						goto case 30;
					case 34:
						if (num5 >= num7)
						{
							num14 = 0;
							num = -802462002;
							continue;
						}
						goto case 42;
					case 28:
						elementIdentifierCount = ((hardwareElementIdentifiers != null) ? hardwareElementIdentifiers.Length : 0);
						num4 = ((buttonElementIdentifierIds != null) ? buttonElementIdentifierIds.Length : 0);
						num = -802461974;
						continue;
					case 30:
						if (compoundElements[num2] != null)
						{
							if (compoundElements[num2].type == CompoundControllerElementType.Axis2D)
							{
								num7++;
								list.Add(compoundElements[num2].elementIdentifier);
								num = -802462005;
								continue;
							}
							goto case 2;
						}
						goto case 10;
					case 39:
					{
						ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(hardwareElementIdentifiers[num3]);
						elementIdentifiers_cache[num3] = controllerElementIdentifier;
						elementIdentifiers.Add(hardwareElementIdentifiers[num3].id, controllerElementIdentifier);
						num = -802462010;
						continue;
					}
					case 22:
						this.hwAxisRanges = hwAxisRanges;
						num = -802461996;
						continue;
					case 0:
						num2 = 0;
						num = -802461986;
						continue;
					default:
						{
							this.hwAxisInfo = hwAxisInfo;
							this.hwButtonInfo = hwButtonInfo;
							return;
						}
						IL_022b:
						num13 = num12;
						num = -802461997;
						continue;
					}
					break;
				}
			}
		}

		public string GetElementIdentifierName(int elementIdentifierId)
		{
			if (!elementIdentifiers.ContainsKey(elementIdentifierId))
			{
				return string.Empty;
			}
			return elementIdentifiers[elementIdentifierId].name;
		}

		public string GetElementIdentifierPositiveName(int elementIdentifierId)
		{
			if (!elementIdentifiers.ContainsKey(elementIdentifierId))
			{
				return string.Empty;
			}
			return elementIdentifiers[elementIdentifierId].positiveName;
		}

		public string GetElementIdentifierNegativeName(int elementIdentifierId)
		{
			if (!elementIdentifiers.ContainsKey(elementIdentifierId))
			{
				return string.Empty;
			}
			return elementIdentifiers[elementIdentifierId].negativeName;
		}

		public int GetAxisIndex(int elementIdentifierId)
		{
			int num = 0;
			while (num < axisCount)
			{
				while (true)
				{
					if (axisElementIdentifierIds[num] == elementIdentifierId)
					{
						return num;
					}
					num++;
					int num2 = -103839645;
					while (true)
					{
						switch (num2 ^ -103839645)
						{
						case 2:
							num2 = -103839646;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			return -1;
		}

		public int GetAxisIndex(string elementIdentifierName)
		{
			int count = default(int);
			int num;
			if (elementIdentifierName != null)
			{
				if (elementIdentifierName == string.Empty)
				{
					goto IL_0010;
				}
				count = elementIdentifiers.Count;
				num = -1339239576;
				goto IL_0015;
			}
			goto IL_0078;
			IL_0015:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1339239571)
				{
				case 2:
					break;
				case 4:
					goto IL_003a;
				case 5:
					num2 = 0;
					num = -1339239572;
					continue;
				case 3:
					goto IL_0078;
				case 1:
					num = -1339239571;
					continue;
				default:
					if (num2 >= count)
					{
						return -1;
					}
					goto IL_003a;
				}
				break;
				IL_003a:
				if (elementIdentifiers_cache[num2].name.Equals(elementIdentifierName, StringComparison.OrdinalIgnoreCase))
				{
					return GetAxisIndex(elementIdentifiers_cache[num2].id);
				}
				num2++;
				num = -1339239571;
			}
			goto IL_0010;
			IL_0078:
			return -1;
			IL_0010:
			num = -1339239570;
			goto IL_0015;
		}

		public int GetButtonIndex(int elementIdentifierId)
		{
			int num = 0;
			while (true)
			{
				int num2 = -692228774;
				while (true)
				{
					switch (num2 ^ -692228776)
					{
					case 0:
						break;
					case 2:
						num2 = -692228775;
						continue;
					case 3:
						if (buttonElementIdentifierIds[num] == elementIdentifierId)
						{
							return num;
						}
						num++;
						num2 = -692228775;
						continue;
					default:
						if (num >= buttonCount)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public int GetButtonIndex(string elementIdentifierName)
		{
			int count = default(int);
			int num = default(int);
			int num2;
			if (elementIdentifierName != null)
			{
				if (elementIdentifierName == string.Empty)
				{
					goto IL_0010;
				}
				count = elementIdentifiers.Count;
				num = 0;
				num2 = -734669027;
				goto IL_0015;
			}
			goto IL_003a;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -734669025)
				{
				case 4:
					break;
				case 1:
					goto IL_003a;
				case 5:
					return GetButtonIndex(elementIdentifiers_cache[num].id);
				case 2:
					goto IL_0070;
				case 3:
					goto IL_0085;
				default:
					return -1;
				}
				break;
				IL_0085:
				if (!elementIdentifiers_cache[num].name.Equals(elementIdentifierName, StringComparison.OrdinalIgnoreCase))
				{
					num++;
					num2 = -734669027;
				}
				else
				{
					num2 = -734669030;
				}
				continue;
				IL_0070:
				int num3;
				if (num < count)
				{
					num2 = -734669028;
					num3 = num2;
				}
				else
				{
					num2 = -734669025;
					num3 = num2;
				}
			}
			goto IL_0010;
			IL_003a:
			return -1;
			IL_0010:
			num2 = -734669026;
			goto IL_0015;
		}

		public ControllerElementIdentifier GetElementIdentifierById(int id)
		{
			int count = elementIdentifiers.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < count)
				{
					num2 = 2031751771;
					num3 = num2;
				}
				else
				{
					num2 = 2031751770;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x791A1258)
					{
					case 0:
						num2 = 2031751771;
						continue;
					case 3:
						if (elementIdentifiers_cache[num].id == id)
						{
							return elementIdentifiers_cache[num];
						}
						num++;
						num2 = 2031751769;
						continue;
					case 1:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		public ControllerElementIdentifier GetButtonElementIdentifierById(int id)
		{
			int num = buttonCount;
			int num2 = 0;
			while (true)
			{
				int num3 = -1016083607;
				while (true)
				{
					switch (num3 ^ -1016083608)
					{
					case 0:
						break;
					case 1:
						num3 = -1016083605;
						continue;
					case 2:
						if (buttonElementIdentifierIds[num2] == id)
						{
							return buttonElementIdentifiers_cache[num2];
						}
						num2++;
						num3 = -1016083605;
						continue;
					default:
						if (num2 >= num)
						{
							return null;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public ControllerElementIdentifier GetAxisElementIdentifierById(int id)
		{
			int num = axisCount;
			int num2 = 0;
			while (true)
			{
				int num3 = 1318007080;
				while (true)
				{
					switch (num3 ^ 0x4E8F3129)
					{
					case 2:
						break;
					case 1:
						num3 = 1318007081;
						continue;
					case 3:
						if (axisElementIdentifierIds[num2] == id)
						{
							return axisElementIdentifiers_cache[num2];
						}
						num2++;
						num3 = 1318007081;
						continue;
					default:
						if (num2 >= num)
						{
							return null;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public HardwareJoystickMap.CompoundElement GetAxis2DData(int index)
		{
			if (compoundElements == null)
			{
				return null;
			}
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < compoundElements.Length)
				{
					num3 = 891834390;
					num4 = num3;
				}
				else
				{
					num3 = 891834388;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x35285010)
					{
					case 2:
						num3 = 891834390;
						continue;
					case 1:
						return compoundElements[num2];
					case 3:
						break;
					case 6:
						if (compoundElements[num2] != null)
						{
							int num5;
							if (compoundElements[num2].type != CompoundControllerElementType.Axis2D)
							{
								num3 = 891834389;
								num5 = num3;
							}
							else
							{
								num3 = 891834384;
								num5 = num3;
							}
							continue;
						}
						goto case 5;
					case 5:
						num2++;
						num3 = 891834387;
						continue;
					case 0:
						if (num != index)
						{
							num++;
							num3 = 891834389;
						}
						else
						{
							num3 = 891834385;
						}
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		public HardwareJoystickMap.CompoundElement GetHatData(int index)
		{
			if (compoundElements == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 1644021531;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num3 ^ 0x61FDC71B)
				{
				case 4:
					break;
				case 1:
					return null;
				case 3:
					if (compoundElements[num2].type == CompoundControllerElementType.Hat)
					{
						if (num == index)
						{
							num3 = 1644021533;
							continue;
						}
						num++;
						num3 = 1644021529;
						continue;
					}
					goto case 2;
				case 2:
					num2++;
					num3 = 1644021534;
					continue;
				case 0:
					num3 = 1644021534;
					continue;
				case 6:
					return compoundElements[num2];
				case 7:
				{
					int num4;
					if (compoundElements[num2] == null)
					{
						num3 = 1644021529;
						num4 = num3;
					}
					else
					{
						num3 = 1644021528;
						num4 = num3;
					}
					continue;
				}
				default:
					if (num2 >= compoundElements.Length)
					{
						return null;
					}
					goto case 7;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num3 = 1644021530;
			goto IL_000d;
		}

		public ControllerElementType GetElementType(int elementIdentifierId)
		{
			if (!elementIdentifiers.ContainsKey(elementIdentifierId))
			{
				return ControllerElementType.Button;
			}
			return elementIdentifiers[elementIdentifierId].elementType;
		}

		private int JJqmxHxPKYaPbztuToXPTZiExSg(ControllerElementIdentifier[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				return -1;
			}
			int result = -1;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= P_0.Length)
				{
					num2 = -1981796300;
					num3 = num2;
				}
				else
				{
					num2 = -1981796301;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1981796297)
					{
					case 0:
						num2 = -1981796301;
						continue;
					case 4:
						if (P_0[num].id == P_1)
						{
							result = num;
							num2 = -1981796300;
							continue;
						}
						goto case 2;
					case 1:
						break;
					case 2:
						num++;
						num2 = -1981796298;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}
	}
}
