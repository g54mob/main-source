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

		public HardwareJoystickMap_InputManager(HardwareControllerMapIdentifier hardwareMapIdentifier, JoystickType[] joystickTypes, HardwareJoystickMap.Platform hardwarePlatformMap, string controllerName, int buttonCount, int axisCount, int elementIdentifierCount, HardwareJoystickMap.CompoundElement[] compoundElements)
		{
		}

		public HardwareControllerMap_Game ToGameHardwareControllerMap()
		{
			return null;
		}
	}
}
