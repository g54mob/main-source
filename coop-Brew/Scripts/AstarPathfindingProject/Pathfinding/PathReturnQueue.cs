using System;
using System.Collections.Generic;

namespace Pathfinding
{
	internal class PathReturnQueue
	{
		private readonly Queue<Path> pathReturnQueue;

		private readonly object pathsClaimedSilentlyBy;

		private readonly Action OnReturnedPaths;

		public PathReturnQueue(object pathsClaimedSilentlyBy, Action OnReturnedPaths)
		{
		}

		public void Enqueue(Path path)
		{
		}

		public void ReturnPaths(bool timeSlice)
		{
		}
	}
}
