using System;

namespace Motorways.Audio
{
	[Flags]
	public enum StateType
	{
		None = 0,
		MenuMain = 1,
		MenuOptions = 2,
		MenuMapSelect = 4,
		MenuMap = 8,
		GameActive = 0x10,
		GamePaused = 0x20,
		ModeEdit = 0x40,
		ModeDelete = 0x80,
		ModeNight = 0x100,
		MenuPause = 0x200,
		MenuUpgrades = 0x400,
		GameOver = 0x800,
		Credits = 0x1000,
		MenuLanguage = 0x4000,
		MenuResume = 0x8000,
		LateGame = 0x10000,
		SkippingMenu = 0x20000,
		MenuPhoto = 0x40000,
		Minimal = 0x80000
	}
}
