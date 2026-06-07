using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiInputTextFlags
	{
		None = 0,
		CharsDecimal = 1,
		CharsHexadecimal = 2,
		CharsUppercase = 4,
		CharsNoBlank = 8,
		AutoSelectAll = 0x10,
		EnterReturnsTrue = 0x20,
		CallbackCompletion = 0x40,
		CallbackHistory = 0x80,
		CallbackAlways = 0x100,
		CallbackCharFilter = 0x200,
		AllowTabInput = 0x400,
		CtrlEnterForNewLine = 0x800,
		NoHorizontalScroll = 0x1000,
		AlwaysOverwrite = 0x2000,
		ReadOnly = 0x4000,
		Password = 0x8000,
		NoUndoRedo = 0x10000,
		CharsScientific = 0x20000,
		CallbackResize = 0x40000,
		CallbackEdit = 0x80000,
		EscapeClearsAll = 0x100000
	}
}
