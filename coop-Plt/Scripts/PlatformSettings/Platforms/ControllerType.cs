using System;

namespace Platforms
{
	[Flags]
	public enum ControllerType
	{
		None = 0,
		Keyboard = 1,
		Xbox = 2,
		Playstation = 4,
		SwitchJoyConL = 8,
		SwitchJoyConR = 0x10,
		SwitchFull = 0x20,
		Mouse = 0x40
	}
}
