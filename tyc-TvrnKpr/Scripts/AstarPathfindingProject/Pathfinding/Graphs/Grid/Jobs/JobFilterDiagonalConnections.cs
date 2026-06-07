using Pathfinding.Collections;
using Pathfinding.Jobs;
using Unity.Burst;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobFilterDiagonalConnections : IJobParallelForBatched
	{
		public Slice3D slice;

		public NumNeighbours neighbours;

		public bool cutCorners;

		public UnsafeSpan<ulong> nodeConnections;

		public bool allowBoundsChecks => false;

		public void Execute(int start, int count)
		{
		}
	}
}
