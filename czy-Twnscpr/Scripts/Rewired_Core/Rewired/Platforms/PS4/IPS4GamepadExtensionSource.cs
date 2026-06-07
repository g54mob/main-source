namespace Rewired.Platforms.PS4
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IPS4GamepadExtensionSource : vluPtLjiOOBEtbozXjooaoxPcAqj, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad
	{
		int GetConnectionType();

		int GetAnalogDeadZoneLeft();

		int GetAnalogDeadZoneRight();
	}
}
