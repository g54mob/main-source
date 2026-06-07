using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
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
			elementIdentifierCount = ((hardwareElementIdentifiers != null) ? hardwareElementIdentifiers.Length : 0);
			int num = ((buttonElementIdentifierIds != null) ? buttonElementIdentifierIds.Length : 0);
			int num2 = ((axisElementIdentifierIds != null) ? axisElementIdentifierIds.Length : 0);
			compoundElements = ArrayTools.DeepClone(compoundElements);
			this.compoundElements = compoundElements;
			compoundElementCount = ((compoundElements != null) ? compoundElements.Length : 0);
			int num3 = 0;
			int num4 = 0;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < compoundElementCount; i++)
			{
				if (compoundElements[i] != null)
				{
					if (compoundElements[i].type == CompoundControllerElementType.Axis2D)
					{
						num3++;
						list.Add(compoundElements[i].elementIdentifier);
					}
					else if (compoundElements[i].type == CompoundControllerElementType.Hat)
					{
						num4++;
						list2.Add(compoundElements[i].elementIdentifier);
						HardwareJoystickMap.CompoundElement.SortHatElementsClockwise(compoundElements[i]);
					}
				}
			}
			int[] array = list.ToArray();
			int[] array2 = list2.ToArray();
			elementIdentifiers = new ADictionary<int, ControllerElementIdentifier>(elementIdentifierCount);
			elementIdentifiers_cache = new ControllerElementIdentifier[elementIdentifierCount];
			buttonElementIdentifiers_cache = new ControllerElementIdentifier[num];
			axisElementIdentifiers_cache = new ControllerElementIdentifier[num2];
			axis2DElementIdentifiers_cache = new ControllerElementIdentifier[num3];
			hatElementIdentifiers_cache = new ControllerElementIdentifier[num4];
			elementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(elementIdentifiers_cache);
			buttonElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(buttonElementIdentifiers_cache);
			axisElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(axisElementIdentifiers_cache);
			axis2DElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(axis2DElementIdentifiers_cache);
			hatElementIdentifiers_readOnly = new ReadOnlyCollection<ControllerElementIdentifier>(hatElementIdentifiers_cache);
			for (int j = 0; j < elementIdentifierCount; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(hardwareElementIdentifiers[j]);
				elementIdentifiers_cache[j] = controllerElementIdentifier;
				elementIdentifiers.Add(hardwareElementIdentifiers[j].id, controllerElementIdentifier);
			}
			for (int k = 0; k < num; k++)
			{
				int num5 = qashcINgUYliSFAxvzTLoYaGxZn(hardwareElementIdentifiers, buttonElementIdentifierIds[k]);
				if (num5 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					buttonElementIdentifiers_cache[k] = hardwareElementIdentifiers[num5];
				}
			}
			for (int l = 0; l < num2; l++)
			{
				int num6 = qashcINgUYliSFAxvzTLoYaGxZn(hardwareElementIdentifiers, axisElementIdentifierIds[l]);
				if (num6 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					axisElementIdentifiers_cache[l] = hardwareElementIdentifiers[num6];
				}
			}
			for (int m = 0; m < num3; m++)
			{
				int num7 = qashcINgUYliSFAxvzTLoYaGxZn(hardwareElementIdentifiers, array[m]);
				if (num7 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					axis2DElementIdentifiers_cache[m] = hardwareElementIdentifiers[num7];
				}
			}
			for (int n = 0; n < num4; n++)
			{
				int num8 = qashcINgUYliSFAxvzTLoYaGxZn(hardwareElementIdentifiers, array2[n]);
				if (num8 < 0)
				{
					Logger.LogError("Invalid hardware element identifier id!");
				}
				else
				{
					hatElementIdentifiers_cache[n] = hardwareElementIdentifiers[num8];
				}
			}
			this.buttonElementIdentifierIds = buttonElementIdentifierIds;
			this.axisElementIdentifierIds = axisElementIdentifierIds;
			axis2DElementIdentifierIds = array;
			hatElementIdentifierIds = array2;
			elementIdentifierCount = ((elementIdentifiers != null) ? elementIdentifiers.Count : 0);
			buttonCount = ((buttonElementIdentifierIds != null) ? buttonElementIdentifierIds.Length : 0);
			axisCount = ((axisElementIdentifierIds != null) ? axisElementIdentifierIds.Length : 0);
			axis2DCount = num3;
			hatCount = num4;
			this.hwAxisCalibrationData = hwAxisCalibrationData;
			this.hwAxisRanges = hwAxisRanges;
			this.hwAxisInfo = hwAxisInfo;
			this.hwButtonInfo = hwButtonInfo;
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
			while (true)
			{
				int num2;
				int num3;
				if (num >= axisCount)
				{
					num2 = -863994960;
					num3 = num2;
				}
				else
				{
					num2 = -863994958;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -863994959)
					{
					case 2:
						num2 = -863994958;
						continue;
					case 3:
						if (axisElementIdentifierIds[num] == elementIdentifierId)
						{
							num2 = -863994959;
							continue;
						}
						num++;
						num2 = -863994955;
						continue;
					case 0:
						return num;
					case 4:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		public int GetAxisIndex(string elementIdentifierName)
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
				num2 = 1297925833;
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num2 ^ 0x4D5CC6CD)
				{
				case 0:
					break;
				case 3:
					goto IL_0036;
				case 2:
					goto IL_004d;
				case 4:
					goto IL_0082;
				default:
					return -1;
				}
				break;
				IL_0082:
				int num3;
				if (num < count)
				{
					num2 = 1297925839;
					num3 = num2;
				}
				else
				{
					num2 = 1297925836;
					num3 = num2;
				}
				continue;
				IL_004d:
				if (elementIdentifiers_cache[num].name.Equals(elementIdentifierName, StringComparison.OrdinalIgnoreCase))
				{
					return GetAxisIndex(elementIdentifiers_cache[num].id);
				}
				num++;
				num2 = 1297925833;
			}
			goto IL_0010;
			IL_0036:
			return -1;
			IL_0010:
			num2 = 1297925838;
			goto IL_0015;
		}

		public int GetButtonIndex(int elementIdentifierId)
		{
			int num = 0;
			while (true)
			{
				int num2 = 512110088;
				while (true)
				{
					switch (num2 ^ 0x1E862E0A)
					{
					case 3:
						break;
					case 2:
						num2 = 512110090;
						continue;
					case 1:
						if (buttonElementIdentifierIds[num] == elementIdentifierId)
						{
							return num;
						}
						num++;
						num2 = 512110090;
						continue;
					default:
						if (num >= buttonCount)
						{
							return -1;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public int GetButtonIndex(string elementIdentifierName)
		{
			if (elementIdentifierName != null)
			{
				int num2 = default(int);
				int count = default(int);
				while (true)
				{
					int num = 278648633;
					while (true)
					{
						switch (num ^ 0x109BD73B)
						{
						case 3:
							break;
						case 2:
							goto IL_0029;
						case 1:
							goto end_IL_0003;
						case 0:
							goto IL_0054;
						default:
							if (num2 >= count)
							{
								return -1;
							}
							goto IL_0054;
						}
						break;
						IL_0054:
						if (elementIdentifiers_cache[num2].name.Equals(elementIdentifierName, StringComparison.OrdinalIgnoreCase))
						{
							return GetButtonIndex(elementIdentifiers_cache[num2].id);
						}
						num2++;
						num = 278648639;
						continue;
						IL_0029:
						if (elementIdentifierName == string.Empty)
						{
							num = 278648634;
							continue;
						}
						count = elementIdentifiers.Count;
						num2 = 0;
						num = 278648639;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			return -1;
		}

		public ControllerElementIdentifier GetElementIdentifierById(int id)
		{
			int count = elementIdentifiers.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (elementIdentifiers_cache[num].id == id)
					{
						return elementIdentifiers_cache[num];
					}
					num++;
					int num2 = -927830409;
					while (true)
					{
						switch (num2 ^ -927830410)
						{
						case 0:
							num2 = -927830412;
							continue;
						case 2:
							break;
						default:
							goto end_IL_002e;
						}
						break;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			return null;
		}

		public ControllerElementIdentifier GetButtonElementIdentifierById(int id)
		{
			int num = buttonCount;
			int num2 = 0;
			while (true)
			{
				int num3 = -1741289534;
				while (true)
				{
					switch (num3 ^ -1741289536)
					{
					case 3:
						break;
					case 2:
						num3 = -1741289536;
						continue;
					case 1:
						if (buttonElementIdentifierIds[num2] == id)
						{
							return buttonElementIdentifiers_cache[num2];
						}
						num2++;
						num3 = -1741289536;
						continue;
					default:
						if (num2 >= num)
						{
							return null;
						}
						goto case 1;
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
				int num3;
				int num4;
				if (num2 >= num)
				{
					num3 = 2135645540;
					num4 = num3;
				}
				else
				{
					num3 = 2135645542;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x7F4B5D67)
					{
					case 2:
						num3 = 2135645542;
						continue;
					case 1:
						if (axisElementIdentifierIds[num2] == id)
						{
							return axisElementIdentifiers_cache[num2];
						}
						num2++;
						num3 = 2135645543;
						continue;
					case 0:
						break;
					default:
						return null;
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
			int num3 = default(int);
			while (true)
			{
				int num2 = -492444048;
				while (true)
				{
					switch (num2 ^ -492444044)
					{
					case 2:
						break;
					case 4:
						num3 = 0;
						num2 = -492444043;
						continue;
					case 0:
						if (compoundElements[num3] != null && compoundElements[num3].type == CompoundControllerElementType.Axis2D)
						{
							if (num == index)
							{
								return compoundElements[num3];
							}
							num++;
							num2 = -492444041;
							continue;
						}
						goto case 3;
					case 3:
						num3++;
						num2 = -492444043;
						continue;
					default:
						if (num3 >= compoundElements.Length)
						{
							return null;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public HardwareJoystickMap.CompoundElement GetHatData(int index)
		{
			if (compoundElements == null)
			{
				return null;
			}
			int num = 0;
			int num3 = default(int);
			while (true)
			{
				int num2 = -1074393165;
				while (true)
				{
					switch (num2 ^ -1074393162)
					{
					case 3:
						break;
					case 4:
						num3++;
						num2 = -1074393168;
						continue;
					case 2:
						return compoundElements[num3];
					case 7:
						if (compoundElements[num3] != null)
						{
							int num5;
							if (compoundElements[num3].type != CompoundControllerElementType.Hat)
							{
								num2 = -1074393166;
								num5 = num2;
							}
							else
							{
								num2 = -1074393162;
								num5 = num2;
							}
							continue;
						}
						goto case 4;
					case 0:
						if (num != index)
						{
							num++;
							num2 = -1074393166;
						}
						else
						{
							num2 = -1074393164;
						}
						continue;
					case 6:
					{
						int num4;
						if (num3 >= compoundElements.Length)
						{
							num2 = -1074393161;
							num4 = num2;
						}
						else
						{
							num2 = -1074393167;
							num4 = num2;
						}
						continue;
					}
					case 5:
						num3 = 0;
						num2 = -1074393168;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		public ControllerElementType GetElementType(int elementIdentifierId)
		{
			if (!elementIdentifiers.ContainsKey(elementIdentifierId))
			{
				return ControllerElementType.Button;
			}
			return elementIdentifiers[elementIdentifierId].elementType;
		}

		private int qashcINgUYliSFAxvzTLoYaGxZn(ControllerElementIdentifier[] P_0, int P_1)
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
				if (num < P_0.Length)
				{
					num2 = -1254717451;
					num3 = num2;
				}
				else
				{
					num2 = -1254717453;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1254717455)
					{
					case 0:
						num2 = -1254717451;
						continue;
					case 1:
						num++;
						num2 = -1254717452;
						continue;
					case 3:
						num2 = -1254717453;
						continue;
					case 5:
						break;
					case 4:
						if (P_0[num].id == P_1)
						{
							result = num;
							num2 = -1254717454;
							continue;
						}
						goto case 1;
					default:
						return result;
					}
					break;
				}
			}
		}
	}
}
