using System;

namespace Simulator
{
	[Flags]
	public enum EDebugCategoryFlags
	{
		BASE = 1,
		EVENTS = 2,
		CASH_REGISTER = 4,
		SETTINGS = 8,
		AUDIO = 0x10,
		UI = 0x20,
		PRODUCT = 0x40,
		TUTORIAL = 0x80,
		Analytics = 0x100,
		IMPORT = 0x200,
		STEAM_ACHIEVEMENT = 0x400
	}
}
