using System;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Grid.Jobs
{
	public struct JobAllocateNodes : IJob
	{
		public AstarPath active;

		[ReadOnly]
		public NativeArray<float4> nodeNormals;

		public IntBounds dataBounds;

		public int3 nodeArrayBounds;

		public GridNodeBase[] nodes;

		public Func<GridNodeBase> newGridNodeDelegate;

		public void Execute()
		{
		}
	}
}
