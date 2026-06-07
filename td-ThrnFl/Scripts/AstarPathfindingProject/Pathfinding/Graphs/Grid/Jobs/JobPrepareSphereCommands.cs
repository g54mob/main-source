using Pathfinding.Util;
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
			UnsafeSpan<OverlapSphereCommand> span = commands.AsUnsafeSpan();
			QueryParameters queryParameters = new QueryParameters(mask, hitMultipleFaces: false, QueryTriggerInteraction.Ignore);
			span.Fill(new OverlapSphereCommand(physicsScene, Vector3.zero, radius, queryParameters));
			for (int i = 0; i < span.Length; i++)
			{
				Vector3 point = origins[i] + originOffset;
				span[i].point = point;
			}
		}
	}
}
