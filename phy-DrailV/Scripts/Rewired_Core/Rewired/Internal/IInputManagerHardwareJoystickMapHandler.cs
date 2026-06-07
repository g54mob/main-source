namespace Rewired.Internal
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal interface IInputManagerHardwareJoystickMapHandler
	{
		void InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap);
	}
}
