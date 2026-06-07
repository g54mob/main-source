using Rewired.Data.Mapping;
using Rewired.Internal.Localization;

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

		private readonly DeviceLocalizationInfo IPYIneCSUQDXRnuNyGLwRRDUpopR;

		public DeviceLocalizationInfo deviceLocalizationInfo => null;

		public HardwareJoystickMap_InputManager(HardwareControllerMapIdentifier P_0, JoystickType[] P_1, DeviceLocalizationInfo P_2, HardwareJoystickMap.Platform P_3, string P_4, int P_5, int P_6, int P_7, HardwareJoystickMap.CompoundElement[] P_8)
		{
		}

		public HardwareControllerMap_Game ToGameHardwareControllerMap()
		{
			return null;
		}
	}
}
