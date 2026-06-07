using System;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class UpdateControllerInfoEventArgs : EventArgs
	{
		public readonly IInputManagerJoystickPublic sourceJoystick;

		public UpdateControllerInfoEventArgs(IInputManagerJoystickPublic sourceJoystick)
		{
		}
	}
}
