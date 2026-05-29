using System;

namespace Factory.FieldData
{
	[Flags]
	public enum eCarrierResultFlag
	{
		Normal = 0,
		NotWork = 1,
		Overflow = 2,
		Exhaustion = 4,
		BeMixedColors = 8,
		ShinExhaustion = 0x10,
		FromZero = 0x20
	}
}
