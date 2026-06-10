namespace Rewired.Platforms.PS4
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IPS4GamepadExtensionSource : ggTkdwJMwyHZjrvxNfFQYoCehWyD, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad
	{
		int GetConnectionType();

		int GetAnalogDeadZoneLeft();

		int GetAnalogDeadZoneRight();
	}
}
