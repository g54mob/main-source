using System;

namespace Motorways.EdgeLoopOperator
{
	[Flags]
	public enum TopologyType
	{
		None = 0,
		Flat = 1,
		Concave = 2,
		Convex = 4,
		ComplexCorner = 8,
		Any = 0xF
	}
}
