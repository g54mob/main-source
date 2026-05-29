using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobPrepareRaycasts : IJob
	{
		public Vector3 direction;

		public Vector3 originOffset;

		public float distance;

		public LayerMask mask;

		public PhysicsScene physicsScene;

		[ReadOnly]
		public NativeArray<Vector3> origins;

		[WriteOnly]
		public NativeArray<RaycastCommand> raycastCommands;

		public void Execute()
		{
			Vector3 normalized = direction.normalized;
			raycastCommands.AsUnsafeSpan();
			for (int i = 0; i < raycastCommands.Length; i++)
			{
				raycastCommands[i] = new RaycastCommand(origins[i] + originOffset, normalized, distance, mask);
			}
		}
	}
}
