using System;

namespace Motorways.Audio
{
	[Flags]
	public enum UIAudioProfile
	{
		None = 0,
		Generic = 1,
		Back = 2,
		Clock = 4,
		Pause = 8,
		Play = 0x10,
		Map = 0x20,
		Upgrade = 0x40,
		ResumeDelete = 0x80,
		Theme = 0x100,
		NoHover = 0x200,
		Picture = 0x800,
		Checkbox = 0x1000,
		ArrowLeft = 0x2000,
		ArrowRight = 0x4000,
		Button = 0x8000,
		FastForward = 0x10000,
		StartGame = 0x20000,
		DrawModeToggle = 0x40000,
		Lock = 0x80000,
		ElectiveUpgrade = 0x100000,
		CreativeModePaint = 0x200000,
		CreativeModeTrash = 0x400000,
		CreativeModePaintWheel = 0x800000
	}
}
