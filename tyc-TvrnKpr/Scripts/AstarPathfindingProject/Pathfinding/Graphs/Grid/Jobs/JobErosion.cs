using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobErosion<AdjacencyMapper> : IJob where AdjacencyMapper : GridAdjacencyMapper, new()
	{
		public IntBounds bounds;

		public IntBounds writeMask;

		public NumNeighbours neighbours;

		public int erosion;

		public bool erosionUsesTags;

		public int erosionStartTag;

		[ReadOnly]
		public NativeArray<ulong> nodeConnections;

		[ReadOnly]
		public NativeArray<bool> nodeWalkable;

		[WriteOnly]
		public NativeArray<bool> outNodeWalkable;

		public NativeArray<int> nodeTags;

		public int erosionTagsPrecedenceMask;

		private static readonly int[] hexagonNeighbourIndices;

		public void Execute()
		{
		}
	}
}
