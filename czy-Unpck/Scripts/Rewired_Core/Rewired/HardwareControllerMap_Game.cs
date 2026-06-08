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
			while (true)
			{
				int num = -1236570669;
				while (true)
				{
					switch (num ^ -1236570671)
					{
					case 0:
						break;
					default:
						return;
					case 2:
					{
						this.hardwareMapIdentifier = hardwareMapIdentifier;
						if (joystickTypes != null)
						{
							goto IL_0059;
						}
						JoystickType[] array = new JoystickType[1];
						this.joystickTypes = array;
						return;
					}
					case 1:
						goto IL_0059;
					case 3:
						return;
					}
					break;
					IL_0059:
					this.joystickTypes = ArrayTools.ShallowCopy(joystickTypes);
					num = -1236570670;
				}
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
				elementIdentifiers_cache[j] = hardwareElementIdentifiers[j];
				elementIdentifiers.Add(hardwareElementIdentifiers[j].id, hardwareElementIdentifiers[j]);
			}
			for (int k = 0; k < num; k++)
			{
				int num5 = PwsPDDburSxIXcdUawxIgORFMjO(hardwareElementIdentifiers, buttonElementIdentifierIds[k]);
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
				int num6 = PwsPDDburSxIXcdUawxIgORFMjO(hardwareElementIdentifiers, axisElementIdentifierIds[l]);
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
				int num7 = PwsPDDburSxIXcdUawxIgORFMjO(hardwareElementIdentifiers, array[m]);
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
				int num8 = PwsPDDburSxIXcdUawxIgORFMjO(hardwareElementIdentifiers, array2[n]);
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
				int num2 = 1187514119;
				while (true)
				{
					switch (num2 ^ 0x46C80705)
					{
					case 3:
						break;
					case 2:
						num2 = 1187514117;
						continue;
					case 1:
						if (axisElementIdentifierIds[num] == elementIdentifierId)
						{
							return num;
						}
						num++;
						num2 = 1187514117;
						continue;
					case 0:
					{
						int num3;
						if (num < axisCount)
						{
							num2 = 1187514116;
							num3 = num2;
						}
						else
						{
							num2 = 1187514113;
							num3 = num2;
						}
						continue;
					}
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
				num2 = -28543548;
				goto IL_0015;
			}
			goto IL_0036;
			IL_0015:
			while (true)
			{
				switch (num2 ^ -28543552)
				{
				case 0:
					break;
				case 1:
					goto IL_0036;
				case 4:
					num2 = -28543549;
					continue;
				case 2:
					goto IL_0054;
				default:
					if (num >= count)
					{
						return -1;
					}
					goto IL_0054;
				}
				break;
				IL_0054:
				if (elementIdentifiers_cache[num].name.Equals(elementIdentifierName, StringComparison.OrdinalIgnoreCase))
				{
					return GetAxisIndex(elementIdentifiers_cache[num].id);
				}
				num++;
				num2 = -28543549;
			}
			goto IL_0010;
			IL_0036:
			return -1;
			IL_0010:
			num2 = -28543551;
			goto IL_0015;
		}

		public int GetButtonIndex(int elementIdentifierId)
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < buttonCount)
				{
					num2 = 985536332;
					num3 = num2;
				}
				else
				{
					num2 = 985536334;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x3ABE174F)
					{
					case 0:
						num2 = 985536332;
						continue;
					case 3:
						if (buttonElementIdentifierIds[num] == elementIdentifierId)
						{
							return num;
						}
						num++;
						num2 = 985536333;
						continue;
					case 2:
						break;
					default:
						return -1;
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
					int num = -670545665;
					while (true)
					{
						switch (num ^ -670545668)
						{
						case 0:
							break;
						case 3:
							goto IL_0029;
						case 2:
							goto end_IL_0003;
						case 1:
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
						num = -670545672;
						continue;
						IL_0029:
						if (elementIdentifierName == string.Empty)
						{
							num = -670545666;
							continue;
						}
						count = elementIdentifiers.Count;
						num2 = 0;
						num = -670545672;
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
					int num2 = -496535702;
					while (true)
					{
						switch (num2 ^ -496535701)
						{
						case 0:
							num2 = -496535703;
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
				int num3 = 603238223;
				while (true)
				{
					switch (num3 ^ 0x23F4AF4E)
					{
					case 3:
						break;
					case 1:
						num3 = 603238222;
						continue;
					case 2:
						if (buttonElementIdentifierIds[num2] == id)
						{
							return buttonElementIdentifiers_cache[num2];
						}
						num2++;
						num3 = 603238222;
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
			while (num2 < num)
			{
				while (true)
				{
					if (axisElementIdentifierIds[num2] == id)
					{
						return axisElementIdentifiers_cache[num2];
					}
					num2++;
					int num3 = -1911718145;
					while (true)
					{
						switch (num3 ^ -1911718145)
						{
						case 2:
							num3 = -1911718146;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0029;
						}
						break;
					}
					continue;
					end_IL_0029:
					break;
				}
			}
			return null;
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
				int num3 = 2123976314;
				while (true)
				{
					switch (num3 ^ 0x7E994E7B)
					{
					case 2:
						break;
					case 1:
						num3 = 2123976312;
						continue;
					case 0:
						if (compoundElements[num2] != null && compoundElements[num2].type == CompoundControllerElementType.Axis2D)
						{
							if (num == index)
							{
								return compoundElements[num2];
							}
							num++;
							num3 = 2123976319;
							continue;
						}
						goto case 4;
					case 4:
						num2++;
						num3 = 2123976312;
						continue;
					default:
						if (num2 >= compoundElements.Length)
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
				int num2 = 256830356;
				while (true)
				{
					switch (num2 ^ 0xF4EEB97)
					{
					case 0:
						break;
					case 4:
						num3++;
						num2 = 256830354;
						continue;
					case 2:
						return compoundElements[num3];
					case 1:
						if (compoundElements[num3] != null && compoundElements[num3].type == CompoundControllerElementType.Hat)
						{
							if (num != index)
							{
								num++;
								num2 = 256830355;
							}
							else
							{
								num2 = 256830357;
							}
							continue;
						}
						goto case 4;
					case 3:
						num3 = 0;
						num2 = 256830354;
						continue;
					default:
						if (num3 >= compoundElements.Length)
						{
							return null;
						}
						goto case 1;
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

		private int PwsPDDburSxIXcdUawxIgORFMjO(ControllerElementIdentifier[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				return -1;
			}
			int result = -1;
			int num2 = default(int);
			while (true)
			{
				int num = 1122593452;
				while (true)
				{
					switch (num ^ 0x42E96AAE)
					{
					case 3:
						break;
					case 6:
						if (P_0[num2].id == P_1)
						{
							result = num2;
							num = 1122593451;
							continue;
						}
						goto case 0;
					case 1:
						num = 1122593450;
						continue;
					case 0:
						num2++;
						num = 1122593450;
						continue;
					case 2:
						num2 = 0;
						num = 1122593455;
						continue;
					case 4:
					{
						int num3;
						if (num2 >= P_0.Length)
						{
							num = 1122593451;
							num3 = num;
						}
						else
						{
							num = 1122593448;
							num3 = num;
						}
						continue;
					}
					default:
						return result;
					}
					break;
				}
			}
		}
	}
}
