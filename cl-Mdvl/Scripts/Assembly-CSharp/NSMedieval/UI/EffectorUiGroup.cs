using System;

namespace NSMedieval.UI
{
	[Flags]
	public enum EffectorUiGroup
	{
		None = 0,
		Mood = 1,
		Health = 2,
		Stats = 4,
		Wounds = 8,
		Social = 0x10,
		MiscLog = 0x20
	}
}
