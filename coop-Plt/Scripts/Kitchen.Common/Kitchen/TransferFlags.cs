using System;

namespace Kitchen
{
	[Flags]
	public enum TransferFlags
	{
		Null = 0,
		Interaction = 1,
		Drop = 2,
		Holder = 4,
		Storage = 8,
		RequireMerge = 0x10,
		NoReturns = 0x20,
		Provider = 0x40,
		RequireSplit = 0x80,
		Split = 0x100,
		RequireDrop = 0x200,
		NoDrops = 0x400,
		ToolSlot = 0x800,
		ToolGrab = 0x1000,
		TraySwapType = 0x2000,
		Refresh = 0x4000,
		SpecialInteraction = 0x8000,
		OrderSatisfaction = 0x10000,
		OnlyOrderSatisfaction = 0x20000,
		Buffet = 0x40000,
		PartialSatisfaction = 0x80000,
		LooseSplit = 0x100000
	}
}
