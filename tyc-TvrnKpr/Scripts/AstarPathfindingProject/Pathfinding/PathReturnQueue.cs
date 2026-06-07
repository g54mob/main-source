using System;
using System.Collections.Generic;

namespace Pathfinding
{
	internal class PathReturnQueue
	{
		private Queue<Path> pathReturnQueueWriting;

		private Queue<Path> pathReturnQueueReading;

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
