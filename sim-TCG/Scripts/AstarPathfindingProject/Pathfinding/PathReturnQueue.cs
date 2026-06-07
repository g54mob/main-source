using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	internal class PathReturnQueue
	{
		private readonly Queue<Path> pathReturnQueue = new Queue<Path>();

		private readonly object pathsClaimedSilentlyBy;

		private readonly Action OnReturnedPaths;

		public PathReturnQueue(object pathsClaimedSilentlyBy, Action OnReturnedPaths)
		{
			this.pathsClaimedSilentlyBy = pathsClaimedSilentlyBy;
			this.OnReturnedPaths = OnReturnedPaths;
		}

		public void Enqueue(Path path)
		{
			lock (pathReturnQueue)
			{
				pathReturnQueue.Enqueue(path);
			}
		}

		public void ReturnPaths(bool timeSlice)
		{
			long num = (timeSlice ? (DateTime.UtcNow.Ticks + 10000) : 0);
			int num2 = 0;
			int num3 = 0;
			while (true)
			{
				Path path;
				lock (pathReturnQueue)
				{
					if (pathReturnQueue.Count == 0)
					{
						break;
					}
					path = pathReturnQueue.Dequeue();
					goto IL_005e;
				}
				IL_005e:
				((IPathInternals)path).AdvanceState(PathState.Returning);
				try
				{
					((IPathInternals)path).ReturnPath();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				((IPathInternals)path).AdvanceState(PathState.Returned);
				path.Release(pathsClaimedSilentlyBy, silent: true);
				num2++;
				num3++;
				if (num2 > 5 && timeSlice)
				{
					num2 = 0;
					if (DateTime.UtcNow.Ticks >= num)
					{
						break;
					}
				}
			}
			if (num3 > 0)
			{
				OnReturnedPaths();
			}
		}
	}
}
