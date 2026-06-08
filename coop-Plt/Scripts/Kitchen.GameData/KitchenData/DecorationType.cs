using System;

namespace KitchenData
{
	[Flags]
	public enum DecorationType
	{
		Null = 0,
		Exclusive = 1,
		Affordable = 2,
		Charming = 4,
		Formal = 8,
		Kitchen = 0x10
	}
}
