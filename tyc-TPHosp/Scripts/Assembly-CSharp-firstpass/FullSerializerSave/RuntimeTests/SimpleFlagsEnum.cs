using System;

namespace FullSerializerSave.RuntimeTests
{
	[Flags]
	public enum SimpleFlagsEnum
	{
		A = 1,
		B = 2,
		C = 4,
		D = 8,
		E = 0x10
	}
}
