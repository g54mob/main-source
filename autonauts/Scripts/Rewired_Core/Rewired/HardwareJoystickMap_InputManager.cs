using System;
using Rewired.Data.Mapping;
using Rewired.Utils;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class HardwareJoystickMap_InputManager
	{
		public string controllerName;

		public readonly HardwareControllerMapIdentifier hardwareMapIdentifier;

		public readonly HardwareJoystickMap.Platform map;

		public readonly int buttonCount;

		public readonly int axisCount;

		public readonly ControllerElementIdentifier[] elementIdentifiers;

		public readonly HardwareJoystickMap.CompoundElement[] compoundElements;

		public bool useSystemName;

		public readonly bool isUnknownController;

		public readonly JoystickType[] joystickTypes;

		public string[] GetAxisNames()
		{
			return map.GetAxisNames(elementIdentifiers);
		}

		public string[] GetEffectiveButtonNames()
		{
			return map.GetEffectiveButtonNames(elementIdentifiers);
		}

		public HardwareJoystickMap_InputManager(HardwareControllerMapIdentifier hardwareMapIdentifier, JoystickType[] joystickTypes, HardwareJoystickMap.Platform hardwarePlatformMap, string controllerName, int buttonCount, int axisCount, int elementIdentifierCount, HardwareJoystickMap.CompoundElement[] compoundElements)
		{
			this.hardwareMapIdentifier = hardwareMapIdentifier;
			this.joystickTypes = joystickTypes;
			map = hardwarePlatformMap;
			this.controllerName = controllerName;
			this.buttonCount = buttonCount;
			this.axisCount = axisCount;
			elementIdentifiers = new ControllerElementIdentifier[elementIdentifierCount];
			this.compoundElements = compoundElements;
			isUnknownController = hardwareMapIdentifier.guid == Guid.Empty;
		}

		public HardwareControllerMap_Game ToGameHardwareControllerMap()
		{
			JoystickType[] array = ArrayTools.ShallowCopy(joystickTypes);
			int[] buttons;
			int[] axes;
			map.GetGameElementIdentifierIdMappings(out buttons, out axes);
			AxisCalibrationData[] axisCalibrationData = map.GetAxisCalibrationData();
			HardwareAxisInfo[] axisInfos = default(HardwareAxisInfo[]);
			int num4 = default(int);
			HardwareAxisInfo[] array3 = default(HardwareAxisInfo[]);
			int num7 = default(int);
			HardwareButtonInfo[] array4 = default(HardwareButtonInfo[]);
			int num9 = default(int);
			int num8 = default(int);
			HardwareButtonInfo[] buttonInfos = default(HardwareButtonInfo[]);
			AxisRange[] axisRanges = default(AxisRange[]);
			AxisRange[] array2 = default(AxisRange[]);
			int num2 = default(int);
			while (true)
			{
				int num = 1265992223;
				while (true)
				{
					switch (num ^ 0x4B75821B)
					{
					case 0:
						break;
					case 22:
						axisInfos = new HardwareAxisInfo[axisCount];
						num4 = 0;
						num = 1265992213;
						continue;
					case 16:
						Logger.LogWarning("Invalid HardwareAxisInfo array returned by HardwareJoystickMap!");
						if (axisInfos != null)
						{
							array3 = new HardwareAxisInfo[axisCount];
							num7 = 0;
							num = 1265992220;
							continue;
						}
						goto case 22;
					case 1:
						array4 = new HardwareButtonInfo[buttonCount];
						num9 = 0;
						num = 1265992214;
						continue;
					case 14:
					{
						int num5;
						if (num4 < axisCount)
						{
							num = 1265992193;
							num5 = num;
						}
						else
						{
							num = 1265992212;
							num5 = num;
						}
						continue;
					}
					case 7:
						if (num7 >= axisCount)
						{
							axisInfos = array3;
							num = 1265992212;
							continue;
						}
						goto case 19;
					case 2:
					{
						int num14;
						if (num8 >= buttonCount)
						{
							num = 1265992197;
							num14 = num;
						}
						else
						{
							num = 1265992208;
							num14 = num;
						}
						continue;
					}
					case 25:
						num = 1265992209;
						continue;
					case 29:
						if (num9 < buttonInfos.Length)
						{
							array4[num9] = buttonInfos[num9];
							num = 1265992202;
							continue;
						}
						goto case 17;
					case 17:
						if (array4[num9] == null)
						{
							array4[num9] = new HardwareButtonInfo();
							num = 1265992201;
							continue;
						}
						goto case 18;
					case 9:
						Logger.LogError("Axis mismatch!");
						num = 1265992192;
						continue;
					case 27:
						return null;
					case 18:
						num9++;
						num = 1265992214;
						continue;
					case 3:
						if (array3[num7] == null)
						{
							array3[num7] = new HardwareAxisInfo();
							num = 1265992199;
							continue;
						}
						goto case 28;
					case 4:
						if (axisCount > 0)
						{
							if (axisCalibrationData == null)
							{
								goto case 9;
							}
							if (axisCalibrationData.Length != axisCount)
							{
								num = 1265992210;
								continue;
							}
						}
						map.GetAxisData(out axisRanges, out axisInfos);
						if (axisRanges != null)
						{
							int num13;
							if (axisRanges.Length == axisCount)
							{
								num = 1265992215;
								num13 = num;
							}
							else
							{
								num = 1265992211;
								num13 = num;
							}
							continue;
						}
						goto case 8;
					case 21:
						array2[num2] = axisRanges[num2];
						num2++;
						num = 1265992209;
						continue;
					case 8:
						Logger.LogWarning("Invalid AxisRange array returned by HardwareJoystickMap!");
						if (axisRanges != null)
						{
							array2 = new AxisRange[axisCount];
							num2 = 0;
							num = 1265992194;
							continue;
						}
						goto case 6;
					case 23:
						axisRanges = array2;
						num = 1265992215;
						continue;
					case 6:
						axisRanges = new AxisRange[axisCount];
						num = 1265992215;
						continue;
					case 26:
						axisInfos[num4] = new HardwareAxisInfo();
						num4++;
						num = 1265992213;
						continue;
					case 15:
						map.GetButtonData(out buttonInfos);
						if (buttonInfos != null)
						{
							int num10;
							if (buttonInfos.Length != buttonCount)
							{
								num = 1265992222;
								num10 = num;
							}
							else
							{
								num = 1265992197;
								num10 = num;
							}
							continue;
						}
						goto case 5;
					case 31:
						array3[num7] = axisInfos[num7];
						num = 1265992216;
						continue;
					case 11:
						buttonInfos[num8] = new HardwareButtonInfo();
						num8++;
						num = 1265992217;
						continue;
					case 20:
						buttonInfos = new HardwareButtonInfo[buttonCount];
						num = 1265992195;
						continue;
					case 19:
					{
						int num12;
						if (num7 >= axisInfos.Length)
						{
							num = 1265992216;
							num12 = num;
						}
						else
						{
							num = 1265992196;
							num12 = num;
						}
						continue;
					}
					case 28:
						num7++;
						num = 1265992220;
						continue;
					case 5:
					{
						Logger.LogWarning("Invalid HardwareButtonInfo array returned by HardwareJoystickMap!");
						int num11;
						if (buttonInfos == null)
						{
							num = 1265992207;
							num11 = num;
						}
						else
						{
							num = 1265992218;
							num11 = num;
						}
						continue;
					}
					case 13:
						if (num9 >= buttonCount)
						{
							buttonInfos = array4;
							num = 1265992197;
							continue;
						}
						goto case 29;
					case 24:
						num8 = 0;
						num = 1265992217;
						continue;
					case 12:
						if (axisInfos != null)
						{
							int num6;
							if (axisInfos.Length == axisCount)
							{
								num = 1265992212;
								num6 = num;
							}
							else
							{
								num = 1265992203;
								num6 = num;
							}
							continue;
						}
						goto case 16;
					case 10:
					{
						int num3;
						if (num2 < MathTools.Min(axisRanges.Length, axisCount))
						{
							num = 1265992206;
							num3 = num;
						}
						else
						{
							num = 1265992204;
							num3 = num;
						}
						continue;
					}
					default:
						return new HardwareControllerMap_Game(controllerName, hardwareMapIdentifier, array, elementIdentifiers, buttons, axes, axisCalibrationData, axisRanges, axisInfos, buttonInfos, compoundElements);
					}
					break;
				}
			}
		}
	}
}
