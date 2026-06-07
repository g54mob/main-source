using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobPrepareSphereCommands : IJob
	{
		public Vector3 originOffset;

		public float radius;

		public LayerMask mask;

		public PhysicsScene physicsScene;

		[ReadOnly]
		public NativeArray<Vector3> origins;

		[WriteOnly]
		public NativeArray<OverlapSphereCommand> commands;

		public void Execute()
		{
		}
	}
}
