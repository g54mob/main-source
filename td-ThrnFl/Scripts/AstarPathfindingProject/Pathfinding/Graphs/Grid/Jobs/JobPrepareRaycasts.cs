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
			UnsafeSpan<RaycastCommand> span = raycastCommands.AsUnsafeSpan();
			SpanExtensions.Fill(value: new RaycastCommand(queryParameters: new QueryParameters(mask, hitMultipleFaces: false, QueryTriggerInteraction.Ignore), physicsScene: physicsScene, from: Vector3.zero, direction: normalized, distance: distance), span: span);
			for (int i = 0; i < raycastCommands.Length; i++)
			{
				span[i].from = origins[i] + originOffset;
			}
		}
	}
}
