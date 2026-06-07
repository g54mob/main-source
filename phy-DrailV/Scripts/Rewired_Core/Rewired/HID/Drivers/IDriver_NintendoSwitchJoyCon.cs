using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IDriver_NintendoSwitchJoyCon : IControllerDriver, IDriver_NintendoSwitchController, IAxisCalibrationIndexMap, IHIDControllerExtension
	{
		NintendoSwitchJoyConType joyConType { get; }

		NintendoSwitchJoyConGripStyle joyConGripStyle { get; set; }
	}
}
