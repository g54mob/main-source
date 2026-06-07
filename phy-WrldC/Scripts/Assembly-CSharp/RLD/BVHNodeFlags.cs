using System;

namespace RLD
{
	[Flags]
	public enum BVHNodeFlags
	{
		None = 0,
		Root = 1,
		Terminal = 2
	}
}
