using System;

namespace Pathfinding
{
	[Flags]
	public enum GraphUpdateDebugMode
	{
		Nothing = 0,
		VisualizeOriginalBounds = 1,
		VisualizeAffectedBounds = 2,
		VisualizeOverTime = 4
	}
}
