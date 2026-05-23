using Pathfinding.Jobs;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	internal struct JobCheckCollisions : IJobTimeSliced, IJob
	{
		[ReadOnly]
		public NativeArray<Vector3> nodePositions;

		public NativeArray<bool> collisionResult;

		public GraphCollision collision;

		private int startIndex;

		public void Execute()
		{
			Execute(TimeSlice.Infinite);
		}

		public bool Execute(TimeSlice timeSlice)
		{
			for (int i = startIndex; i < nodePositions.Length; i++)
			{
				collisionResult[i] = collisionResult[i] && collision.Check(nodePositions[i]);
				if ((i & 0x7F) == 0 && timeSlice.expired)
				{
					startIndex = i + 1;
					return false;
				}
			}
			return true;
		}
	}
}
