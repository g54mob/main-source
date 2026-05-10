using System.Collections.Generic;

namespace Pathfinding
{
	internal class PathReturnQueue
	{
		private Queue<Path> pathReturnQueue;

		private object pathsClaimedSilentlyBy;

		public PathReturnQueue(object pathsClaimedSilentlyBy)
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
