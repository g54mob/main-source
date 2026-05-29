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
			for (int i = 0; i < length; i++)
			{
				action.Execute((uint)i, (uint)i);
			}
		}
	}
}
