using Rewired.Data.Mapping;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
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
			return null;
		}

		public string[] GetEffectiveButtonNames()
		{
			return null;
		}

		public HardwareJoystickMap_InputManager(HardwareControllerMapIdentifier P_0, JoystickType[] P_1, HardwareJoystickMap.Platform P_2, string P_3, int P_4, int P_5, int P_6, HardwareJoystickMap.CompoundElement[] P_7)
		{
		}

		public HardwareControllerMap_Game ToGameHardwareControllerMap()
		{
			return null;
		}
	}
}
