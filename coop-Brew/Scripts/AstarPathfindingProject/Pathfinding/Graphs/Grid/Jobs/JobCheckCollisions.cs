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
		}

		public bool Execute(TimeSlice timeSlice)
		{
			return false;
		}
	}
}
