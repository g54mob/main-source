using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile]
	public struct JobCalculateTriangleConnections : IJob
	{
		public struct TileNodeConnectionsUnsafe
		{
			public UnsafeAppendBuffer neighbours;

			public UnsafeAppendBuffer neighbourCounts;
		}

		[ReadOnly]
		public NativeArray<TileMesh.TileMeshUnsafe> tileMeshes;

		[WriteOnly]
		public NativeArray<TileNodeConnectionsUnsafe> nodeConnections;

		public void Execute()
		{
		}
	}
}
