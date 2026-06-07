using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
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

		private readonly DeviceLocalizationInfo MrWIoLIpftsWJMmFnYaGVlPXUgFh;

		public DeviceLocalizationInfo deviceLocalizationInfo => MrWIoLIpftsWJMmFnYaGVlPXUgFh;

		public HardwareJoystickMap_InputManager(HardwareControllerMapIdentifier P_0, JoystickType[] P_1, DeviceLocalizationInfo P_2, HardwareJoystickMap.Platform P_3, string P_4, int P_5, int P_6, int P_7, HardwareJoystickMap.CompoundElement[] P_8)
		{
			hardwareMapIdentifier = P_0;
			joystickTypes = P_1;
			map = P_3;
			controllerName = P_4;
			MrWIoLIpftsWJMmFnYaGVlPXUgFh = ((P_2 != null) ? P_2 : new DeviceLocalizationInfo(ControllerType.Joystick, false, P_0.guid, null, null));
			buttonCount = P_5;
			axisCount = P_6;
			elementIdentifiers = new ControllerElementIdentifier[P_7];
			compoundElements = P_8;
			isUnknownController = P_0.guid == Guid.Empty;
		}

		public HardwareControllerMap_Game ToGameHardwareControllerMap()
		{
			JoystickType[] array = ArrayTools.ShallowCopy(joystickTypes);
			map.GetGameElementIdentifierIdMappings(out var buttons, out var axes);
			AxisCalibrationData[] axisCalibrationData = map.GetAxisCalibrationData();
			if (axisCount > 0 && (axisCalibrationData == null || axisCalibrationData.Length != axisCount))
			{
				Logger.LogError("Axis mismatch!");
				return null;
			}
			List<Axis2DCalibrationData> list = new List<Axis2DCalibrationData>();
			if (compoundElements != null)
			{
				for (int i = 0; i < compoundElements.Length; i++)
				{
					if (compoundElements[i] != null && compoundElements[i].type == CompoundControllerElementType.Axis2D)
					{
						list.Add(compoundElements[i].GetAxis2DCalibrationData());
					}
				}
			}
			map.GetAxisData(out var axisRanges, out var axisInfos);
			if (axisRanges == null || axisRanges.Length != axisCount)
			{
				Logger.LogWarning("Invalid AxisRange array returned by HardwareJoystickMap!");
				if (axisRanges != null)
				{
					AxisRange[] array2 = new AxisRange[axisCount];
					for (int j = 0; j < MathTools.Min(axisRanges.Length, axisCount); j++)
					{
						array2[j] = axisRanges[j];
					}
					axisRanges = array2;
				}
				else
				{
					axisRanges = new AxisRange[axisCount];
				}
			}
			if (axisInfos == null || axisInfos.Length != axisCount)
			{
				Logger.LogWarning("Invalid HardwareAxisInfo array returned by HardwareJoystickMap!");
				if (axisInfos != null)
				{
					HardwareAxisInfo[] array3 = new HardwareAxisInfo[axisCount];
					for (int k = 0; k < axisCount; k++)
					{
						if (k < axisInfos.Length)
						{
							array3[k] = axisInfos[k];
						}
						if (array3[k] == null)
						{
							array3[k] = new HardwareAxisInfo();
						}
					}
					axisInfos = array3;
				}
				else
				{
					axisInfos = new HardwareAxisInfo[axisCount];
					for (int l = 0; l < axisCount; l++)
					{
						axisInfos[l] = new HardwareAxisInfo();
					}
				}
			}
			map.GetButtonData(out var buttonInfos);
			if (buttonInfos == null || buttonInfos.Length != buttonCount)
			{
				Logger.LogWarning("Invalid HardwareButtonInfo array returned by HardwareJoystickMap!");
				if (buttonInfos != null)
				{
					HardwareButtonInfo[] array4 = new HardwareButtonInfo[buttonCount];
					for (int m = 0; m < buttonCount; m++)
					{
						if (m < buttonInfos.Length)
						{
							array4[m] = buttonInfos[m];
						}
						if (array4[m] == null)
						{
							array4[m] = new HardwareButtonInfo();
						}
					}
					buttonInfos = array4;
				}
				else
				{
					buttonInfos = new HardwareButtonInfo[buttonCount];
					for (int n = 0; n < buttonCount; n++)
					{
						buttonInfos[n] = new HardwareButtonInfo();
					}
				}
			}
			return new HardwareControllerMap_Game(controllerName, MrWIoLIpftsWJMmFnYaGVlPXUgFh, hardwareMapIdentifier, array, elementIdentifiers, buttons, axes, axisCalibrationData, list.ToArray(), axisRanges, axisInfos, buttonInfos, compoundElements);
		}
	}
}
