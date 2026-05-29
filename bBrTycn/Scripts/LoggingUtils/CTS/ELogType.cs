using System;

namespace CTS
{
	[Flags]
	public enum ELogType
	{
		General = 1,
		Managers = 2,
		Audio = 4,
		UI = 8,
		Units = 0x10,
		Player = 0x20,
		NPC = 0x40,
		VFX = 0x80,
		Animation = 0x100,
		Physics = 0x200,
		Sound = 0x400,
		Rendering = 0x800,
		Inputs = 0x1000
	}
}
