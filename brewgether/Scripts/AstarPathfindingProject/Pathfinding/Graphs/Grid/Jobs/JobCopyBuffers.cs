using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobCopyBuffers : IJob
	{
		[ReadOnly]
		[DisableUninitializedReadCheck]
		public GridGraphNodeData input;

		[WriteOnly]
		public GridGraphNodeData output;

		public IntBounds bounds;

		public bool copyPenaltyAndTags;

		public void Execute()
		{
		}
	}
}
