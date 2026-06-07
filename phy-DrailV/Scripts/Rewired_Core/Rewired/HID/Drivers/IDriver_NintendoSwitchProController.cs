using Rewired.ControllerExtensions;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IDriver_NintendoSwitchProController : IControllerDriver, IDriver_NintendoSwitchController, IHIDControllerExtension
	{
	}
}
