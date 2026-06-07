using Pathfinding.Graphs.Grid;
using Unity.Burst;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct SliceActionJob<T> : IJob where T : struct, GridIterationUtilities.ISliceAction
	{
		public T action;

		public Slice3D slice;

		public void Execute()
		{
			GridIterationUtilities.ForEachCellIn3DSlice(slice, ref action);
		}
	}
}
