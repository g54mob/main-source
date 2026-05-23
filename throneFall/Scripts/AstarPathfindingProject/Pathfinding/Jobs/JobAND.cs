using Pathfinding.Graphs.Grid;
using Unity.Collections;

namespace Pathfinding.Jobs
{
	public struct JobAND : GridIterationUtilities.ISliceAction
	{
		public NativeArray<bool> result;

		[ReadOnly]
		public NativeArray<bool> data;

		public void Execute(uint outerIdx, uint innerIdx)
		{
			result[(int)outerIdx] &= data[(int)outerIdx];
		}
	}
}
