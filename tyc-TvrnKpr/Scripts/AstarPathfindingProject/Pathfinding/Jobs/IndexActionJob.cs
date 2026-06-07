using Pathfinding.Graphs.Grid;
using Unity.Burst;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct IndexActionJob<T> : IJob where T : struct, GridIterationUtilities.ISliceAction
	{
		public T action;

		public int length;

		public void Execute()
		{
		}
	}
}
