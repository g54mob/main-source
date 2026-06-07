using System;

namespace CTS.BBT
{
	[Flags]
	public enum EBarItemType
	{
		None = 0,
		OPlus = 1,
		OMinus = 2,
		APlus = 4,
		AMinus = 8,
		ABPlus = 0x10,
		ABMinus = 0x20,
		BPlus = 0x40,
		BMinus = 0x80
	}
}
