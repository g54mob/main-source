using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	public struct AgentOffMeshLinkTraversal : IComponentData, IQueryTypeParameter
	{
		public float3 relativeStart;

		public float3 relativeEnd;

		public bool isReverse;

		[Obsolete("Use relativeStart instead")]
		public float3 firstPosition => default(float3);

		[Obsolete("Use relativeEnd instead")]
		public float3 secondPosition => default(float3);

		public AgentOffMeshLinkTraversal(OffMeshLinks.OffMeshLinkTracer linkInfo)
		{
			relativeStart = default(float3);
			relativeEnd = default(float3);
			isReverse = false;
		}
	}
}
