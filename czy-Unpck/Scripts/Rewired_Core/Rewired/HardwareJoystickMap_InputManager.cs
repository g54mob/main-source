using System;
using Rewired.Data.Mapping;
using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
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
			map.GetGameElementIdentifierIdMappings(out var buttons, out var axes);
			AxisCalibrationData[] axisCalibrationData = map.GetAxisCalibrationData();
			if (axisCount > 0)
			{
				if (axisCalibrationData == null)
				{
					goto IL_00e4;
				}
				if (axisCalibrationData.Length != axisCount)
				{
					goto IL_0047;
				}
			}
			AxisRange[] axisRanges = default(AxisRange[]);
			HardwareAxisInfo[] axisInfos = default(HardwareAxisInfo[]);
			map.GetAxisData(out axisRanges, out axisInfos);
			int num = -1706059177;
			goto IL_004c;
			IL_004c:
			HardwareButtonInfo[] array4 = default(HardwareButtonInfo[]);
			int num5 = default(int);
			int num4 = default(int);
			HardwareAxisInfo[] array3 = default(HardwareAxisInfo[]);
			HardwareButtonInfo[] buttonInfos = default(HardwareButtonInfo[]);
			int num2 = default(int);
			int num6 = default(int);
			AxisRange[] array2 = default(AxisRange[]);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1706059199)
				{
				case 15:
					break;
				case 26:
					goto IL_00e4;
				case 25:
					array4[num5] = new HardwareButtonInfo();
					num = -1706059188;
					continue;
				case 0:
					num = -1706059180;
					continue;
				case 29:
					if (num4 < axisInfos.Length)
					{
						array3[num4] = axisInfos[num4];
						num = -1706059179;
						continue;
					}
					goto case 20;
				case 21:
					goto IL_0146;
				case 24:
					goto IL_0164;
				case 1:
					num = -1706059184;
					continue;
				case 6:
					goto IL_018c;
				case 33:
					buttonInfos = new HardwareButtonInfo[buttonCount];
					num2 = 0;
					num = -1706059175;
					continue;
				case 18:
					if (axisInfos != null)
					{
						goto IL_01cb;
					}
					goto case 28;
				case 3:
					goto IL_01eb;
				case 13:
					num5++;
					num = -1706059193;
					continue;
				case 14:
					axisInfos[num6] = new HardwareAxisInfo();
					num6++;
					num = -1706059180;
					continue;
				case 7:
					axisRanges = new AxisRange[axisCount];
					num = -1706059181;
					continue;
				case 8:
					Logger.LogWarning("Invalid AxisRange array returned by HardwareJoystickMap!");
					if (axisRanges != null)
					{
						array2 = new AxisRange[axisCount];
						num = -1706059192;
						continue;
					}
					goto case 7;
				case 23:
					array2[num3] = axisRanges[num3];
					num3++;
					num = -1706059196;
					continue;
				case 4:
					num = -1706059174;
					continue;
				case 11:
					buttonInfos = array4;
					num = -1706059200;
					continue;
				case 10:
					if (num5 < buttonInfos.Length)
					{
						array4[num5] = buttonInfos[num5];
						num = -1706059197;
						continue;
					}
					goto IL_0416;
				case 12:
					array4 = new HardwareButtonInfo[buttonCount];
					num5 = 0;
					num = -1706059193;
					continue;
				case 27:
					if (num4 >= axisCount)
					{
						axisInfos = array3;
						num = -1706059183;
						continue;
					}
					goto case 29;
				case 5:
					if (num3 >= MathTools.Min(axisRanges.Length, axisCount))
					{
						axisRanges = array2;
						num = -1706059167;
						continue;
					}
					goto case 23;
				case 28:
					Logger.LogWarning("Invalid HardwareAxisInfo array returned by HardwareJoystickMap!");
					if (axisInfos != null)
					{
						array3 = new HardwareAxisInfo[axisCount];
						num4 = 0;
						num = -1706059195;
						continue;
					}
					goto case 19;
				case 32:
					num = -1706059181;
					continue;
				case 9:
					num3 = 0;
					num = -1706059196;
					continue;
				case 30:
					buttonInfos[num2] = new HardwareButtonInfo();
					num2++;
					num = -1706059175;
					continue;
				case 19:
					axisInfos = new HardwareAxisInfo[axisCount];
					num6 = 0;
					num = -1706059199;
					continue;
				case 16:
					goto IL_0390;
				case 20:
					if (array3[num4] == null)
					{
						array3[num4] = new HardwareAxisInfo();
						num = -1706059170;
						continue;
					}
					goto case 31;
				case 22:
					if (axisRanges == null)
					{
						goto case 8;
					}
					goto IL_03e6;
				case 31:
					num4++;
					num = -1706059174;
					continue;
				case 2:
					goto IL_0416;
				default:
					return new HardwareControllerMap_Game(controllerName, hardwareMapIdentifier, array, elementIdentifiers, buttons, axes, axisCalibrationData, axisRanges, axisInfos, buttonInfos, compoundElements);
				}
				break;
				IL_03e6:
				int num7;
				if (axisRanges.Length == axisCount)
				{
					num = -1706059181;
					num7 = num;
				}
				else
				{
					num = -1706059191;
					num7 = num;
				}
				continue;
				IL_01eb:
				Logger.LogWarning("Invalid HardwareButtonInfo array returned by HardwareJoystickMap!");
				int num8;
				if (buttonInfos != null)
				{
					num = -1706059187;
					num8 = num;
				}
				else
				{
					num = -1706059168;
					num8 = num;
				}
				continue;
				IL_0164:
				int num9;
				if (num2 >= buttonCount)
				{
					num = -1706059184;
					num9 = num;
				}
				else
				{
					num = -1706059169;
					num9 = num;
				}
				continue;
				IL_0390:
				map.GetButtonData(out buttonInfos);
				if (buttonInfos != null)
				{
					int num10;
					if (buttonInfos.Length == buttonCount)
					{
						num = -1706059184;
						num10 = num;
					}
					else
					{
						num = -1706059198;
						num10 = num;
					}
					continue;
				}
				goto IL_01eb;
				IL_0146:
				int num11;
				if (num6 >= axisCount)
				{
					num = -1706059183;
					num11 = num;
				}
				else
				{
					num = -1706059185;
					num11 = num;
				}
				continue;
				IL_01cb:
				int num12;
				if (axisInfos.Length != axisCount)
				{
					num = -1706059171;
					num12 = num;
				}
				else
				{
					num = -1706059183;
					num12 = num;
				}
				continue;
				IL_018c:
				int num13;
				if (num5 >= buttonCount)
				{
					num = -1706059190;
					num13 = num;
				}
				else
				{
					num = -1706059189;
					num13 = num;
				}
				continue;
				IL_0416:
				int num14;
				if (array4[num5] == null)
				{
					num = -1706059176;
					num14 = num;
				}
				else
				{
					num = -1706059188;
					num14 = num;
				}
			}
			goto IL_0047;
			IL_00e4:
			Logger.LogError("Axis mismatch!");
			return null;
			IL_0047:
			num = -1706059173;
			goto IL_004c;
		}
	}
}
