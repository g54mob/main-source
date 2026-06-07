using System;

namespace SaintsField
{
	[Flags]
	public enum EXP
	{
		None = 0,
		NoInitSign = 2,
		NoAutoResignToValue = 4,
		NoAutoResignToNull = 8,
		NoResignButton = 0x10,
		NoMessage = 0x20,
		NoPicker = 0x40,
		KeepOriginalPicker = 0x80,
		ForceReOrder = 0x100,
		NoAutoResign = 0xC,
		Silent = 0x2C,
		JustPicker = 0x3E,
		Message = 0x1C
	}
}
