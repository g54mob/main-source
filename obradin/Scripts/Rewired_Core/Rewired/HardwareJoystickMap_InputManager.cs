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
			if (axisCount > 0)
			{
				goto IL_0033;
			}
			goto IL_01f5;
			IL_0033:
			int num = 1570678616;
			goto IL_0038;
			IL_0038:
			AxisRange[] axisRanges = default(AxisRange[]);
			AxisRange[] array3 = default(AxisRange[]);
			int num2 = default(int);
			int num4 = default(int);
			HardwareAxisInfo[] axisInfos = default(HardwareAxisInfo[]);
			HardwareAxisInfo[] array4 = default(HardwareAxisInfo[]);
			int num6 = default(int);
			HardwareButtonInfo[] buttonInfos = default(HardwareButtonInfo[]);
			int num3 = default(int);
			int num5 = default(int);
			HardwareButtonInfo[] array2 = default(HardwareButtonInfo[]);
			while (true)
			{
				switch (num ^ 0x5D9EA748)
				{
				case 27:
					break;
				case 17:
					axisRanges = new AxisRange[axisCount];
					num = 1570678610;
					continue;
				case 2:
					goto IL_00f3;
				case 13:
					array3[num2] = axisRanges[num2];
					num2++;
					num = 1570678619;
					continue;
				case 4:
					num4++;
					num = 1570678612;
					continue;
				case 19:
					if (num2 >= MathTools.Min(axisRanges.Length, axisCount))
					{
						axisRanges = array3;
						num = 1570678610;
						continue;
					}
					goto case 13;
				case 15:
					Logger.LogWarning("Invalid HardwareAxisInfo array returned by HardwareJoystickMap!");
					if (axisInfos != null)
					{
						array4 = new HardwareAxisInfo[axisCount];
						num6 = 0;
						num = 1570678618;
						continue;
					}
					goto case 22;
				case 12:
					buttonInfos[num3] = new HardwareButtonInfo();
					num = 1570678601;
					continue;
				case 1:
					num3++;
					num = 1570678606;
					continue;
				case 8:
					num6++;
					num = 1570678632;
					continue;
				case 14:
					goto IL_01b9;
				case 21:
					if (array4[num6] == null)
					{
						array4[num6] = new HardwareAxisInfo();
						num = 1570678592;
						continue;
					}
					goto case 8;
				case 9:
					Logger.LogError("Axis mismatch!");
					return null;
				case 36:
					num5++;
					num = 1570678600;
					continue;
				case 10:
					if (buttonInfos != null)
					{
						array2 = new HardwareButtonInfo[buttonCount];
						num4 = 0;
						num = 1570678612;
						continue;
					}
					goto case 3;
				case 29:
					axisInfos[num5] = new HardwareAxisInfo();
					num = 1570678636;
					continue;
				case 32:
					if (num6 >= axisCount)
					{
						axisInfos = array4;
						num = 1570678620;
						continue;
					}
					goto IL_00f3;
				case 5:
					Logger.LogWarning("Invalid HardwareButtonInfo array returned by HardwareJoystickMap!");
					num = 1570678594;
					continue;
				case 7:
					array4[num6] = axisInfos[num6];
					num = 1570678621;
					continue;
				case 34:
					map.GetButtonData(out buttonInfos);
					if (buttonInfos == null)
					{
						goto case 5;
					}
					goto IL_02c4;
				case 22:
					axisInfos = new HardwareAxisInfo[axisCount];
					num5 = 0;
					num = 1570678600;
					continue;
				case 16:
					goto IL_02fe;
				case 25:
					if (num4 < buttonInfos.Length)
					{
						array2[num4] = buttonInfos[num4];
						num = 1570678614;
						continue;
					}
					goto IL_040e;
				case 35:
					array2[num4] = new HardwareButtonInfo();
					num = 1570678604;
					continue;
				case 26:
					if (axisInfos == null)
					{
						goto case 15;
					}
					goto IL_034f;
				case 23:
					goto IL_036f;
				case 24:
					num3 = 0;
					num = 1570678606;
					continue;
				case 0:
					goto IL_0390;
				case 3:
					buttonInfos = new HardwareButtonInfo[buttonCount];
					num = 1570678608;
					continue;
				case 33:
					if (axisRanges != null)
					{
						array3 = new AxisRange[axisCount];
						num2 = 0;
						num = 1570678619;
						continue;
					}
					goto case 17;
				case 6:
					goto IL_03e6;
				case 18:
					num = 1570678632;
					continue;
				case 30:
					goto IL_040e;
				case 31:
					buttonInfos = array2;
					num = 1570678595;
					continue;
				case 28:
					goto IL_0437;
				case 20:
					num = 1570678634;
					continue;
				default:
					return new HardwareControllerMap_Game(controllerName, hardwareMapIdentifier, array, elementIdentifiers, buttons, axes, axisCalibrationData, axisRanges, axisInfos, buttonInfos, compoundElements);
				}
				break;
				IL_0437:
				int num7;
				if (num4 < buttonCount)
				{
					num = 1570678609;
					num7 = num;
				}
				else
				{
					num = 1570678615;
					num7 = num;
				}
				continue;
				IL_02fe:
				int num8;
				if (axisCalibrationData != null)
				{
					num = 1570678598;
					num8 = num;
				}
				else
				{
					num = 1570678593;
					num8 = num;
				}
				continue;
				IL_01b9:
				if (axisCalibrationData.Length != axisCount)
				{
					num = 1570678593;
					continue;
				}
				goto IL_01f5;
				IL_03e6:
				int num9;
				if (num3 >= buttonCount)
				{
					num = 1570678595;
					num9 = num;
				}
				else
				{
					num = 1570678596;
					num9 = num;
				}
				continue;
				IL_00f3:
				int num10;
				if (num6 >= axisInfos.Length)
				{
					num = 1570678621;
					num10 = num;
				}
				else
				{
					num = 1570678607;
					num10 = num;
				}
				continue;
				IL_02c4:
				int num11;
				if (buttonInfos.Length == buttonCount)
				{
					num = 1570678595;
					num11 = num;
				}
				else
				{
					num = 1570678605;
					num11 = num;
				}
				continue;
				IL_0390:
				int num12;
				if (num5 >= axisCount)
				{
					num = 1570678634;
					num12 = num;
				}
				else
				{
					num = 1570678613;
					num12 = num;
				}
				continue;
				IL_034f:
				int num13;
				if (axisInfos.Length != axisCount)
				{
					num = 1570678599;
					num13 = num;
				}
				else
				{
					num = 1570678634;
					num13 = num;
				}
				continue;
				IL_040e:
				int num14;
				if (array2[num4] != null)
				{
					num = 1570678604;
					num14 = num;
				}
				else
				{
					num = 1570678635;
					num14 = num;
				}
			}
			goto IL_0033;
			IL_036f:
			Logger.LogWarning("Invalid AxisRange array returned by HardwareJoystickMap!");
			num = 1570678633;
			goto IL_0038;
			IL_01f5:
			map.GetAxisData(out axisRanges, out axisInfos);
			if (axisRanges != null)
			{
				int num15;
				if (axisRanges.Length == axisCount)
				{
					num = 1570678610;
					num15 = num;
				}
				else
				{
					num = 1570678623;
					num15 = num;
				}
				goto IL_0038;
			}
			goto IL_036f;
		}
	}
}
