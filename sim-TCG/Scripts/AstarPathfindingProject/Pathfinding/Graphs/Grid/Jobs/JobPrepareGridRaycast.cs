using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
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
			float magnitude = raycastDirection.magnitude;
			int3 size = bounds.size;
			Vector3 normalized = raycastDirection.normalized;
			UnsafeSpan<RaycastCommand> unsafeSpan = raycastCommands.AsUnsafeSpan();
			for (int i = 0; i < size.z; i++)
			{
				int num = i * size.x;
				for (int j = 0; j < size.x; j++)
				{
					int index = num + j;
					Vector3 vector = JobNodeGridLayout.NodePosition(graphToWorld, j + bounds.min.x, i + bounds.min.z);
					unsafeSpan[index] = new RaycastCommand(vector + raycastOffset, normalized, magnitude, raycastMask);
				}
			}
		}
	}
}
