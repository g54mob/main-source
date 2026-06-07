using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IDriver_NintendoSwitchJoyCon : IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		NintendoSwitchJoyConType joyConType { get; }

		NintendoSwitchJoyConGripStyle joyConGripStyle { get; set; }
	}
}
