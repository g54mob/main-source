using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobPrepareCapsuleCommands : IJob
	{
		public Vector3 direction;

		public Vector3 originOffset;

		public float radius;

		public LayerMask mask;

		public PhysicsScene physicsScene;

		[ReadOnly]
		public NativeArray<Vector3> origins;

		[WriteOnly]
		public NativeArray<OverlapCapsuleCommand> commands;

		public void Execute()
		{
		}
	}
}
