using System;

[Flags]
public enum EConstructionResult
{
	NotEnoughtMoney = 2,
	NoMinimumSize = 4,
	NoMinimumCellCount = 8,
	HaveInvalideCells = 0x10,
	TooNear = 0x20
}
