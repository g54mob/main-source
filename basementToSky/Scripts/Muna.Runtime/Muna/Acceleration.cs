using System;

namespace Muna
{
	[Flags]
	public enum Acceleration
	{
		Auto = 0,
		CPU = 1,
		GPU = 2,
		NPU = 4
	}
}
