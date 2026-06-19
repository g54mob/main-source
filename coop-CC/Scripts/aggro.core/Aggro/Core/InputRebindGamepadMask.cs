using System;

namespace Aggro.Core
{
	[Flags]
	public enum InputRebindGamepadMask
	{
		None = 0,
		FaceButtons = 1,
		ShoulderTriggers = 2,
		ShoulderButtons = 4,
		DpadButtons = 8,
		StickButtons = 0x10,
		ReadOnly = 0x100,
		Shoulders = 6,
		AllButtons = 0x1F,
		AllButtonsButStick = 0xF
	}
}
