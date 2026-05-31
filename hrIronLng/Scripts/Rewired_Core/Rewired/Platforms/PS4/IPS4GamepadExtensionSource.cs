namespace Rewired.Platforms.PS4
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IPS4GamepadExtensionSource : mvpKKVIFRgOLaSdVrHeNqVnjxUt, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad
	{
		int GetConnectionType();

		int GetAnalogDeadZoneLeft();

		int GetAnalogDeadZoneRight();
	}
}
