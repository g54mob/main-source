using System;

namespace Placemaker.SceneProcessing
{
	[Flags]
	public enum TargetPlatformFlags
	{
		Unknown = 0,
		Web = 2,
		Stadia = 4,
		Windows = 0x20,
		Mac = 0x40,
		Linux = 0x80,
		Android = 0x400,
		IOS = 0x800,
		WindowsGameCore = 0x4000,
		XboxOne = 0x8000,
		XboxSeries = 0x10000,
		Playstation5 = 0x20000,
		Switch = 0x40000,
		OcculusQuest = 0x100000,
		Editor = 0x40000000
	}
}
