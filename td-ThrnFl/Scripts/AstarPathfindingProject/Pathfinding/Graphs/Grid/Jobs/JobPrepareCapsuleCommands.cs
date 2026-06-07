using Pathfinding.Util;
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
			UnsafeSpan<OverlapCapsuleCommand> span = commands.AsUnsafeSpan();
			QueryParameters queryParameters = new QueryParameters(mask, hitMultipleFaces: false, QueryTriggerInteraction.Ignore);
			span.Fill(new OverlapCapsuleCommand(physicsScene, Vector3.zero, Vector3.zero, radius, queryParameters));
			for (int i = 0; i < span.Length; i++)
			{
				Vector3 vector = origins[i] + originOffset;
				span[i].point0 = vector;
				span[i].point1 = vector + direction;
			}
		}
	}
}
