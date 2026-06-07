using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobPrepareGridRaycast : IJob
	{
		public Matrix4x4 graphToWorld;

		public IntBounds bounds;

		public Vector3 raycastOffset;

		public Vector3 raycastDirection;

		public LayerMask raycastMask;

		public PhysicsScene physicsScene;

		[WriteOnly]
		public NativeArray<RaycastCommand> raycastCommands;

		public void Execute()
		{
		}
	}
}
