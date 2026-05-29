using System;

namespace ZLinq
{
	[Flags]
	public enum DropInGenerateTypes
	{
		None = 0,
		Array = 1,
		Span = 2,
		Memory = 4,
		List = 8,
		Enumerable = 0x10,
		Collection = 0xF,
		Everything = 0x1F
	}
}
